﻿using System.Globalization;
using ChapeauUI.UserControls;
using Model;
using Service;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        private Table ClickedTable;
        bool isAlcoholic;
        private ListView listView;
        private Dictionary<MenuItem, ItemDetails> orderMenuItems = new Dictionary<MenuItem, ItemDetails>();
        private TableService tableService;
        private OrderStatus orderStatus;
        private OrderService orderService;

        private decimal totalCost;
        private int currentOrderId;

        public WaiterView()
        {
            InitializeComponent();
            UpdateMenuOnUserRole();
            GeneratTable();
            HidePanels();
            lblUsername.Text = Employee.GetInstance().Username;
            isAlcoholic = false;
            btnDeleteMenuItem.Visible = false;
            btnMenuItemUpdate.Visible = false;
            HidePanels();
            tableLayoutPanelTable.Show();

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("en-IE");
        }

        private void UpdateMenuOnUserRole()
        {
            if (Employee.GetInstance().UserType == UserType.Manager)
            {
                pictureBoxMenuMenu.Show();
                pnlMenuMenu.Show();
            }
            else
            {
                pictureBoxMenuMenu.Hide();
                pnlMenuMenu.Hide();
            }
        }

        private void HidePanels()
        {
            tableLayoutPanelTable.Hide();
            pnlMenu.Hide();
            pnlMenuCrud.Hide();
            panelTableStatus.Hide();
            pnlOrderDetails.Hide();
            pnlPaymentPage.Hide();
        }

        //============================== START TABLE OVERVIEW ============================================

        private void pictureBoxTableMenu_Click(object sender, EventArgs e)
        {
            HidePanels();
            tableLayoutPanelTable.Controls.Clear();
            tableLayoutPanelTable.Show();
            GeneratTable();
        }

        private void lblTableMenu_Click(object sender, EventArgs e)
        {
            HidePanels();
            tableLayoutPanelTable.Controls.Clear();
            tableLayoutPanelTable.Show();
            GeneratTable();
        }

        private void RefreshStatusPanel()
        {
            panelTableStatus.Hide();
            tableLayoutPanelTable.Controls.Clear();
            tableLayoutPanelTable.Show();
            GeneratTable();
        }

        private void GeneratTable()
        {
            tableService = new TableService();
            List<Table> tables = tableService.GetAllTables();
            int columnCount = 5;
            int rowIndex = 0;
            int columnIndex = 0;

            if (tableLayoutPanelTable.Controls.Count == 0)
            {
                foreach (var table in tables)
                {
                    UserControl tableControl = new TableUserControl(table);
                    tableLayoutPanelTable.Controls.Add(tableControl, columnIndex, rowIndex);

                    columnIndex++;
                    if (columnIndex >= columnCount)
                    {
                        columnIndex = 0;
                        rowIndex++;
                    }

                    tableControl.Click += TableControl_Click;

                }
            }
        }

        private void TableControl_Click(object sender, EventArgs e)
        {
            try
            {
                tableService = new TableService();
                TableUserControl clickedTable = (TableUserControl)sender;
                ClickedTable = clickedTable.Table;
                if (clickedTable.Table.Status == TableStatus.Available)
                {
                    DialogResult result = MessageBox.Show("Do you want to occupy the table?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblOrderTable.Text = $"Order - Table {clickedTable.Table.Number}";
                        ShowMenuPanel();
                        tableService.UpdateStatus(clickedTable.Table.TableId, TableStatus.Occupied);
                    }
                }
                else if (clickedTable.Table.Status == TableStatus.Occupied)
                {
                    ShowTableStatusPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTableStatusPanel()
        {
            HidePanels();
            panelTableStatus.Show();
            DisplayOrderStatus(ClickedTable.TableId);
        }

        private void buttonFreeTable_Click(object sender, EventArgs e)
        {
            try
            {
                tableService = new TableService();

                TableUserControl selectedTable = new TableUserControl(ClickedTable);
                if (selectedTable.Table.Status == TableStatus.Occupied)
                {
                    DialogResult result = MessageBox.Show("Do you want to free the table?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblOrderTable.Text = $"Order - Table {selectedTable.Table.Number}";
                        tableService.UpdateStatus(selectedTable.Table.TableId, TableStatus.Available);
                        RefreshStatusPanel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayOrderStatus(int TableId)
        {
            try
            {
                orderService = new OrderService();
                List<Order> orders = orderService.GetOrderByStatus(TableId);
                listViewOrderStatus.Items.Clear();
                foreach (Order order in orders)
                {

                    ListViewItem item = new ListViewItem($"{order.OrderId}");
                    item.SubItems.Add(orderStatus.ToString());
                    item.SubItems.Add(order.FormattedWaitingTime.ToString());
                    item.Tag = order;
                    listViewOrderStatus.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tableId = ClickedTable.TableId;

                if (listViewOrderStatus.SelectedItems.Count > 0)
                {
                    Order SelectedOrder = (Order)listViewOrderStatus.SelectedItems[0].Tag;
                    if (SelectedOrder.Status == OrderStatus.OrderReadyToServe)
                    {
                        orderService.UpdateOrderStatus(SelectedOrder.OrderId, OrderStatus.OrderCompleted);
                        MessageBox.Show("The order has been served.", "Order Served", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayOrderStatus(tableId);
                    }
                    else
                    {
                        MessageBox.Show("The order is not yet ready to serve.", "Order Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            lblOrderTable.Text = $"Order - Table {ClickedTable.Number}";
            ShowMenuPanel();
        }


        //============================== END TABLE OVERVIEW ============================================

        //============================== START ORDER MENU ============================================

        private void ShowMenuPanel()
        {
            HidePanels();
            LoadMenu();
            UpdatePlaceOrderButton();
            pnlMenu.Show();
        }

        private void UpdatePlaceOrderButton()
        {
            if (orderMenuItems.Count() > 0)
            {
                btnPlaceOrder.Enabled = true;
                btnClearOrder.Visible = true;
            }
            else
            {
                btnPlaceOrder.Enabled = false;
                btnClearOrder.Visible = false;
            }
        }

        private void LoadMenu()
        {
            try
            {
                MenuService menuService = new MenuService();
                List<MenuCategory> categories = menuService.GetAllMenuCategories();

                tabControlMenu.TabPages.Clear();

                foreach (MenuCategory category in categories)
                {
                    TabPage tabPage = new TabPage(category.CategoryName);
                    tabPage.Tag = category.CategoryId;

                    List<MenuItem> items = menuService.GetMenuItemsByCategoryId(category.CategoryId);

                    ListView listView = AddMenuItemList();

                    listView.Items.Clear();

                    var menuTypeGroups = items.GroupBy(item => item.MenuType);

                    foreach (var group in menuTypeGroups)
                    {
                        ListViewGroup listViewGroup = new ListViewGroup(group.Key.ToString());
                        listView.Groups.Add(listViewGroup);

                        foreach (MenuItem item in group)
                        {
                            ListViewItem listItem = new ListViewItem(item.Name);
                            listItem.Tag = item;
                            listItem.SubItems.Add(item.Price.ToString());
                            listItem.SubItems.Add(item.Stock.ToString());
                            listItem.Group = listViewGroup;
                            listView.Items.Add(listItem);
                        }
                    }

                    tabPage.Controls.Add(listView);
                    tabControlMenu.TabPages.Add(tabPage);
                }

                // default tab
                if (tabControlMenu.TabPages.Count > 0)
                    tabControlMenu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ListView AddMenuItemList()
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Price");
            listView.Columns.Add("Stock");

            listView.Columns[0].Width = 350;
            listView.Columns[1].Width = 50;

            listView.Click += MenuItemClicked;

            return listView;
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            try
            {
                ListView listView = (ListView)sender;

                if (listView.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listView.SelectedItems[0];
                    MenuItem menuItem = (MenuItem)selectedItem.Tag;

                    if (menuItem.Stock > 0)
                    {
                        if (orderMenuItems.ContainsKey(menuItem))
                        {
                            orderMenuItems[menuItem].Quantity++;
                        }
                        else
                        {
                            orderMenuItems.Add(menuItem, new ItemDetails { Quantity = 1, Note = "" });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Item is out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    UpdateOrderItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderItem()
        {
            try
            {
                pnlOrderItemList.Controls.Clear();

                FlowLayoutPanel flpnlOrderItems = new FlowLayoutPanel();
                flpnlOrderItems.Dock = DockStyle.Fill;
                flpnlOrderItems.FlowDirection = FlowDirection.TopDown;
                flpnlOrderItems.AutoScroll = true;
                flpnlOrderItems.WrapContents = false;

                foreach (var item in orderMenuItems)
                {
                    MenuItem menuItem = item.Key;
                    ItemDetails itemDetails = item.Value;

                    OrderItemUserControl orderItemUserControl = new OrderItemUserControl(menuItem, itemDetails);

                    orderItemUserControl.IncrementButton.Click += IncrementButton_Click;
                    orderItemUserControl.DecrementButton.Click += DecrementButton_Click;
                    orderItemUserControl.NoteDoubleClick += OrderItemUserControl_NoteDoubleClick;
                    flpnlOrderItems.Controls.Add(orderItemUserControl);
                }

                pnlOrderItemList.Controls.Add(flpnlOrderItems);
                UpdatePlaceOrderButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderItemUserControl_NoteDoubleClick(object sender, EventArgs e)
        {
            try
            {
                OrderItemUserControl orderItemUserControl = (OrderItemUserControl)sender;
                MenuItem menuItem = orderItemUserControl.MenuItem;

                MenuItemNote menuItemNote = new MenuItemNote(menuItem);
                menuItemNote.NoteText = orderItemUserControl.ItemDetails.Note;
                menuItemNote.SaveButtonClicked += MenuItemNote_SaveButtonClicked;
                menuItemNote.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuItemNote_SaveButtonClicked(object sender, string note)
        {
            try
            {
                MenuItemNote menuItemNote = (MenuItemNote)sender;
                MenuItem menuItem = menuItemNote.MenuItem;

                if (orderMenuItems.ContainsKey(menuItem))
                {
                    orderMenuItems[menuItem].Note = note;
                }
                else
                {
                    orderMenuItems[menuItem].Note = "";
                }

                UpdateOrderItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderItemUserControl orderItemUserControl = (OrderItemUserControl)((Button)sender).Parent;

                MenuItem menuItem = orderItemUserControl.MenuItem;
                ItemDetails itemDetails = orderItemUserControl.ItemDetails;

                if (itemDetails.Quantity < menuItem.Stock)
                {
                    itemDetails.Quantity++;
                    orderItemUserControl.UpdateData();
                }
                else
                {
                    MessageBox.Show("Only " + menuItem.Stock + " item(s) available in stock.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecrementButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderItemUserControl orderItemUserControl = (OrderItemUserControl)((Button)sender).Parent;

                MenuItem menuItem = orderItemUserControl.MenuItem;
                ItemDetails itemDetails = orderItemUserControl.ItemDetails;

                if (itemDetails.Quantity > 0)
                {
                    itemDetails.Quantity--;

                    if (itemDetails.Quantity == 0)
                    {
                        orderMenuItems.Remove(menuItem);
                        UpdateOrderItem();
                    }
                    else
                    {
                        orderItemUserControl.UpdateData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to place order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Order order = new Order();
                    order.Table = ClickedTable;
                    order.Employee = Employee.GetInstance();
                    order.Status = OrderStatus.OrderPlaced;
                    order.PlacedTime = DateTime.Now;

                    OrderService orderService = new OrderService();
                    MenuService menuService = new MenuService();

                    int orderId = orderService.PlaceOrder(order);
                    order.OrderId = orderId;

                    foreach (var item in orderMenuItems)
                    {
                        MenuItem menuItem = item.Key;
                        ItemDetails itemDetails = item.Value;

                        OrderItem orderItem = new OrderItem();
                        orderItem.Order = order;
                        orderItem.MenuItem = menuItem;
                        orderItem.Quantity = itemDetails.Quantity;
                        orderItem.Note = itemDetails.Note;
                        orderItem.UnitPrice = menuItem.Price;

                        orderService.AddOrderItem(orderItem);

                        menuItem.Stock -= itemDetails.Quantity;
                        menuService.UpdateMenuItem(menuItem);
                    }

                    MessageBox.Show("Order Placed Successfully!");
                    orderMenuItems.Clear();
                    LoadMenu();
                    UpdateOrderItem();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear order items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    orderMenuItems.Clear();
                    UpdateOrderItem();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        //============================== END ORDER MENU ============================================

        //============================== START MENU CRUD ============================================

        private void pictureBoxMenuMenu_Click(object sender, EventArgs e)
        {
            ShowMenuCrudPanel();
        }

        private void lblMenuMenu_Click(object sender, EventArgs e)
        {
            ShowMenuCrudPanel();
        }

        private void ShowMenuCrudPanel()
        {
            HidePanels();
            pnlMenuCrud.Show();
            InitializeListView();
            PopulateMenuData();
            PopulateCategoryData();
            PopulateMenuTypeData();
        }

        private void InitializeListView()
        {
            listView = new ListView();
            listView.SelectedIndexChanged += ListView_SelectedIndexChanged;
            listView.FullRowSelect = true;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;

            listView.Columns.Add("Name", 150);
            listView.Columns.Add("Price", 100);
            listView.Columns.Add("Category", 80);
            listView.Columns.Add("Type", 80);
            listView.Columns.Add("Stock", 50);

            pnlMenuList.Controls.Add(listView);
        }

        private void PopulateMenuTypeData()
        {
            Array menuTypes = Enum.GetValues(typeof(MenuType));
            comboBoxMenuType.DataSource = menuTypes;
        }

        private void PopulateCategoryData()
        {
            MenuService menuService = new MenuService();
            List<MenuCategory> menuCategories = menuService.GetAllMenuCategories();

            comboBoxMenuCategory.DataSource = menuCategories;
            comboBoxMenuCategory.DisplayMember = "CategoryName";
            comboBoxMenuCategory.ValueMember = "CategoryId";
        }

        private void PopulateMenuData()
        {
            MenuService menuService = new MenuService();
            List<MenuCategory> menuCategories = menuService.GetAllMenuCategories();

            listView.Items.Clear();

            var menuTypeGroups = menuService.GetMenuItems().GroupBy(item => item.MenuType);

            foreach (var group in menuTypeGroups)
            {
                ListViewGroup listViewGroup = new ListViewGroup(group.Key.ToString());
                listView.Groups.Add(listViewGroup);

                foreach (MenuItem item in group)
                {
                    ListViewItem listItem = new ListViewItem(item.Name);
                    listItem.Tag = item;
                    listItem.SubItems.Add(item.Price.ToString());
                    listItem.SubItems.Add(item.Category.CategoryName.ToString());
                    listItem.SubItems.Add(item.MenuType.ToString());
                    listItem.SubItems.Add(item.Stock.ToString());
                    listItem.Group = listViewGroup;
                    listView.Items.Add(listItem);
                }
            }
        }

        private void radioButtonIsAlcoYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIsAlcoYes.Checked)
            {
                isAlcoholic = true;
            }
        }

        private void radioButtonIsAlcoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIsAlcoNo.Checked)
            {
                isAlcoholic = false;
            }
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            string name = textBoxMenuItemName.Text;
            decimal price;
            int categoryId;
            string menuType = comboBoxMenuType.SelectedItem.ToString();
            int stock;

            if (!decimal.TryParse(textBoxMenuPrice.Text, out price))
            {
                MessageBox.Show("Invalid price value. Please enter a valid decimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(comboBoxMenuCategory.SelectedValue.ToString(), out categoryId))
            {
                MessageBox.Show("Invalid category ID. Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxStock.Text, out stock))
            {
                MessageBox.Show("Invalid stock value. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MenuService menuService = new MenuService();
            MenuCategory category = menuService.GetMenuCategoryById(categoryId);

            try
            {
                MenuItem menuItem = new MenuItem()
                {
                    Name = name,
                    Price = price,
                    IsAlcoholic = isAlcoholic,
                    Category = category,
                    MenuType = menuType,
                    Stock = stock
                };

                bool isAdded = menuService.AddMenuItem(menuItem);

                if (isAdded)
                {
                    MessageBox.Show("Menu item added successfully!");
                    PopulateMenuData();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Something went wrong while adding Menu item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong while adding Menu item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetInput()
        {
            textBoxMenuItemName.Text = string.Empty;
            textBoxMenuPrice.Text = string.Empty;
            radioButtonIsAlcoYes.Checked = false;
            radioButtonIsAlcoNo.Checked = true;
            comboBoxMenuCategory.SelectedIndex = 0;
            comboBoxMenuType.SelectedIndex = 0;
            textBoxStock.Text = string.Empty;
            btnAddMenu.Visible = true;
            btnMenuItemUpdate.Visible = false;
            btnDeleteMenuItem.Visible = false;
            btnMenuItemUpdate.Visible = false;
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeleteButtonVisibility();
        }

        private void UpdateDeleteButtonVisibility()
        {
            if (listView.SelectedItems.Count > 0)
            {
                btnEditMenuItem.Visible = true;
                btnDeleteMenuItem.Visible = true;
            }
            else
            {
                btnEditMenuItem.Visible = false;
                btnDeleteMenuItem.Visible = false;
            }
        }

        private void btnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                MenuItem menuItem = (MenuItem)selectedItem.Tag;
                int menuId = menuItem.MenuId;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MenuService menuService = new MenuService();
                    menuService.DeleteMenuItem(menuId);
                    ResetInput();
                    PopulateMenuData();
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                MenuItem menuItem = (MenuItem)selectedItem.Tag;

                textBoxMenuItemName.Text = menuItem.Name;
                textBoxMenuPrice.Text = menuItem.Price.ToString();
                comboBoxMenuCategory.SelectedValue = menuItem.Category.CategoryId;
                comboBoxMenuType.SelectedItem = menuItem.MenuType;
                textBoxStock.Text = menuItem.Stock.ToString();

                if (menuItem.IsAlcoholic)
                {
                    radioButtonIsAlcoYes.Checked = true;
                    radioButtonIsAlcoNo.Checked = false;
                }
                else
                {
                    radioButtonIsAlcoYes.Checked = false;
                    radioButtonIsAlcoNo.Checked = true;
                }

                btnAddMenu.Visible = false;
                btnMenuItemUpdate.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a menu item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenuItemUpdate_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                MenuItem menuItem = (MenuItem)selectedItem.Tag;

                if (string.IsNullOrWhiteSpace(textBoxMenuItemName.Text))
                {
                    MessageBox.Show("Please enter a menu item name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal price;
                if (!decimal.TryParse(textBoxMenuPrice.Text, out price))
                {
                    MessageBox.Show("Invalid price value. Please enter a valid decimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int stock;
                if (!int.TryParse(textBoxStock.Text, out stock))
                {
                    MessageBox.Show("Invalid stock value. Please enter a valid integer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                menuItem.Name = textBoxMenuItemName.Text;
                menuItem.Price = price;
                menuItem.Category = (MenuCategory)comboBoxMenuCategory.SelectedItem;
                menuItem.MenuType = comboBoxMenuType.SelectedItem.ToString();
                menuItem.Stock = stock;
                menuItem.IsAlcoholic = radioButtonIsAlcoYes.Checked;

                MenuService menuService = new MenuService();
                bool isUpdated = menuService.UpdateMenuItem(menuItem);

                if (isUpdated)
                {
                    MessageBox.Show("Menu item updated successfully!");
                    PopulateMenuData();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Something went wrong while updating the menu item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //============================== END MENU CRUD ============================================

        //============================== START PAYMENT ============================================

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            HidePanels();
            ShowOrderViewPanel();
        }

        private void ShowOrderViewPanel()
        {
            pnlOrderDetails.Show();
            lblOrderViewHeader.Text = $"Order Details- Table {ClickedTable.Number}";
            GetOrderDetails();
        }

        private void GetOrderDetails()
        {
            OrderService orderService = new OrderService();
            Order order = orderService.GetOrderWithItemsByTableId(ClickedTable.Number);

            if (order == null)
            {
                MessageBox.Show("No order found for the selected table.");
                return;
            }

            listViewOrderDetails.Items.Clear();
            listViewOrderDetails.Groups.Clear();

            decimal subTotal = 0;

            foreach (OrderItem orderItem in order.OrderItems)
            {
                MenuItem menuItem = orderItem.MenuItem;
                decimal vatRate = menuItem.IsAlcoholic ? 0.21m : 0.09m;
                decimal vatCost = orderItem.UnitPrice * vatRate * orderItem.Quantity;
                decimal total = vatCost + (orderItem.UnitPrice * orderItem.Quantity);

                ListViewItem item = new ListViewItem(menuItem.Name);
                item.SubItems.Add(menuItem.Price.ToString("C2"));
                item.SubItems.Add(orderItem.Quantity.ToString());
                item.SubItems.Add(vatCost.ToString("C2"));
                item.SubItems.Add(total.ToString("C2"));
                listViewOrderDetails.Items.Add(item);

                subTotal += total;
            }

            totalCost = subTotal;
            currentOrderId = order.OrderId;

            AddGrandTotalValue(subTotal);
        }

        private void AddGrandTotalValue(decimal subTotal)
        {
            ListViewItem grandTotalItem = new ListViewItem("Grand Total");
            grandTotalItem.Font = new Font(listViewOrderDetails.Font, FontStyle.Bold);
            grandTotalItem.SubItems.Add("");
            grandTotalItem.SubItems.Add("");
            grandTotalItem.SubItems.Add("");
            grandTotalItem.SubItems.Add(subTotal.ToString("C2"));

            ListViewGroup grandTotalGroup = new ListViewGroup();
            listViewOrderDetails.Items.Add(new ListViewItem(string.Empty) { Group = grandTotalGroup });
            listViewOrderDetails.Groups.Add(grandTotalGroup);
            listViewOrderDetails.Items.Add(grandTotalItem);

            listViewOrderDetails.Groups.RemoveAt(0);
        }

        private void btnProceedPayment_Click(object sender, EventArgs e)
        {
            HidePanels();
            ShowPaymentPanel();
        }

        private void ShowPaymentPanel()
        {
            pnlPaymentPage.Show();
            lblPaymentPageHeader.Text = $"Payment For {ClickedTable.Number}";
            lblTotalAmnt.Text = $"Total: {totalCost.ToString("C2")}";
        }

        private void chckbxSpliteBill_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxSpliteBill.Checked)
            {
                txtNumPeople.ReadOnly = false;
                txtTotalAmount.ReadOnly = true;
            }
            else
            {
                txtNumPeople.ReadOnly = true;
                txtTotalAmount.ReadOnly = false;
                txtNumPeople.Text = "";
                txtTotalAmount.Text = "";
            }
        }

        private void calculateSplitAmount()
        {
            decimal payableAmnt;

            if (!txtTipAmount.Text.Equals(""))
            {
                payableAmnt = (totalCost + int.Parse(txtTipAmount.Text)) / int.Parse(txtNumPeople.Text);
            }
            else
            {
                payableAmnt = totalCost / int.Parse(txtNumPeople.Text);
            }

            txtTotalAmount.Text = payableAmnt.ToString("C2");
        }

        private void txtTipAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTipAmount.Text.Equals(""))
            { 
                chckbxTip.Enabled = true;
            }
            else
            {
                chckbxTip.Enabled = false;
            }

            if (!txtTipAmount.Text.Equals("") && chckbxSpliteBill.Checked && int.TryParse(txtTipAmount.Text, out int number))
                calculateSplitAmount();
            return;

        }

        private void txtNumPeople_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtNumPeople.Text.Equals("") && int.TryParse(txtNumPeople.Text, out int number))
                calculateSplitAmount();
            return;
        }

        private void txtTotalAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTotalAmount.Text.Equals(""))
            {
                chckbxSpliteBill.Enabled = true;
            }
            else
            {
                chckbxSpliteBill.Enabled = false;
            }


            if (!txtTotalAmount.Text.Equals("") && int.TryParse(txtTotalAmount.Text, out int number) && chckbxTip.Checked)
            {
                txtTipAmount.ReadOnly = true;
                decimal totalAmount = decimal.Parse(txtTotalAmount.Text);

                if (!txtCashAmount.Text.Equals("") && int.TryParse(txtCashAmount.Text, out int number1))
                {
                    totalAmount = totalAmount + (decimal)number1;
                }

                decimal tips = totalAmount - totalCost;
                txtTipAmount.Text = tips.ToString("C2");
            }
            else
            {
                txtTipAmount.ReadOnly = false;
                //txtTipAmount.Text = "";
            }
        }

        private void chckbxTip_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxTip.Checked && !txtTotalAmount.Text.Equals(""))
            {
                txtTipAmount.ReadOnly = true;
                decimal tips = decimal.Parse(txtTotalAmount.Text) - totalCost;
                txtTipAmount.Text = tips.ToString("C2");
            }
            else
            {
                txtTipAmount.ReadOnly = false;
                txtTipAmount.Text = "";
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            string totalAmountText = txtTotalAmount.Text.Trim();
            string tipAmountText = txtTipAmount.Text.Trim();
            decimal totalAmount;

            if (totalAmountText.Contains("€"))
            {
                totalAmountText = totalAmountText.Replace("€", "");
            }

            if (tipAmountText.Contains("€"))
            {
                tipAmountText = tipAmountText.Replace("€", "");
            }

            if (!decimal.TryParse(totalAmountText, out totalAmount))
            {
                MessageBox.Show("Please enter payable amount!");
                return;
            }

            decimal tipAmount;
            if (!decimal.TryParse(tipAmountText, out tipAmount))
            {
                tipAmount = 0;
            }

            string paymentMethod = GetSelectedPaymentMethod();
            string comment = txtComment.Text.Trim();

            PaymentService paymentService = new PaymentService();
            TableService tableService = new TableService();

            decimal cashAmount;
            if (decimal.TryParse(txtCashAmount.Text, out cashAmount))
            {
                if (cashAmount > totalAmount)
                {
                    MessageBox.Show("Cash amount cannot be greater than the total payable amount.");
                    return;
                }
            }

            Payment payment = new Payment
            {
                PaymentDate = DateTime.Now,
                Tip = tipAmount,
                Comment = comment,
                OrderId = currentOrderId,
                Amount = totalAmount,
                CashAmount = cashAmount,
                PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod)
            };


           // MessageBox.Show(txtTipAmount.ToString());


            int paymentId = paymentService.AddPayment(payment);
            payment.PaymentId = paymentId;

            if (chckbxSpliteBill.Checked)
            {
                int numberOfPeople;
                if (!int.TryParse(txtNumPeople.Text, out numberOfPeople))
                {
                    MessageBox.Show("Invalid number of people.");
                    return;
                }

                decimal amountPerPerson = totalAmount;
                BillSplit billSplit = new BillSplit
                {
                    Payment = payment,
                    NumberOfPeople = numberOfPeople,
                    AmountPerPerson = amountPerPerson
                };

                paymentService.AddBillSplit(billSplit);
            }

            tableService.UpdateStatus(ClickedTable.TableId, TableStatus.Available);

            MessageBox.Show("Payment completed successfully.");

            ResetPaymentInput();
            HidePanels();
            tableLayoutPanelTable.Controls.Clear();
            tableLayoutPanelTable.Show();
            GeneratTable();
        }

        private void ResetPaymentInput()
        {
            txtTipAmount.Text = "";
            txtComment.Text = "";
            txtTotalAmount.Text = "";
            chckbxSpliteBill.Enabled = true;
            chckbxSpliteBill.Enabled = true;
        }

        private string GetSelectedPaymentMethod()
        {
            string selectedPaymentMethod = "";

            if (rbCash.Checked)
            {
                selectedPaymentMethod = rbCash.Text;
            }
            else if (rbVisa.Checked)
            {
                selectedPaymentMethod = rbVisa.Text;
            }
            else if (rbMaster.Checked)
            {
                selectedPaymentMethod = rbMaster.Text;
            }
            else if (rbAmex.Checked)
            {
                selectedPaymentMethod = rbAmex.Text;
            }

            selectedPaymentMethod = selectedPaymentMethod.Replace(" ", "");

            return selectedPaymentMethod;
        }


        //============================== END PAYMENT ============================================

    }
}
