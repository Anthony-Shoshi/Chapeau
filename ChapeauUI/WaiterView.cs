using System.Windows.Forms;
using ChapeauUI.UserControls;
using Model;
using Service;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        bool isAlcoholic;
        private ListView listView;
        private Dictionary<MenuItem, ItemDetails> orderMenuItems = new Dictionary<MenuItem, ItemDetails>();

        public WaiterView()
        {
            InitializeComponent();
            GeneratTable();
            HidePanels();
            lblUsername.Text = Employee.GetInstance().Username;
            isAlcoholic = false;
            btnDeleteMenuItem.Visible = false;
            btnMenuItemUpdate.Visible = false;
            HidePanels();
            tableLayoutPanelTable.Show();
        }

        private void HidePanels()
        {
            tableLayoutPanelTable.Hide();
            pnlMenu.Hide();
            pnlMenuCrud.Hide();
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

        private void GeneratTable()
        {
            TableService tableService = new TableService();
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
            TableService service = new TableService();
            TableUserControl clickedTable = (TableUserControl)sender;
            if (clickedTable.Table.Status == TableStatus.Available)
            {
                DialogResult result = MessageBox.Show("Do you want to occupy the table?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    lblOrderTable.Text = $"Order - Table {clickedTable.Table.Number}";
                    ShowMenuPanel();
                    service.UpdateStatus(clickedTable.Table.TableId, TableStatus.Occupied);
                }

            }
            else if (clickedTable.Table.Status == TableStatus.Occupied)
            {

            }
        }

        //============================== END TABLE OVERVIEW ============================================

        //============================== START ORDER MENU ============================================

        private void ShowMenuPanel()
        {
            HidePanels();
            pnlMenu.Show();
            LoadMenu();
        }

        private void LoadMenu()
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
                        listItem.Group = listViewGroup;
                        listView.Items.Add(listItem);
                    }
                }

                tabPage.Controls.Add(listView);
                tabControlMenu.TabPages.Add(tabPage);
            }

            // Select the first tab by default
            if (tabControlMenu.TabPages.Count > 0)
                tabControlMenu.SelectedIndex = 0;
        }

        private ListView AddMenuItemList()
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Price");
            listView.Columns.Add("Quantity");

            listView.Columns[0].Width = 350;
            listView.Columns[1].Width = 50;

            listView.Click += MenuItemClicked;

            return listView;
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                MenuItem menuItem = (MenuItem)selectedItem.Tag;


                if (orderMenuItems.ContainsKey(menuItem))
                {
                    orderMenuItems[menuItem].Quantity++;
                }
                else
                {
                    orderMenuItems.Add(menuItem, new ItemDetails { Quantity = 1, Note = "" });
                }

                UpdateOrderItem();
            }
        }

        private void UpdateOrderItem()
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
        }

        private void OrderItemUserControl_NoteDoubleClick(object sender, EventArgs e)
        {
            OrderItemUserControl orderItemUserControl = (OrderItemUserControl)sender;
            MenuItem menuItem = orderItemUserControl.MenuItem;

            MenuItemNote menuItemNote = new MenuItemNote(menuItem);
            menuItemNote.NoteText = orderItemUserControl.ItemDetails.Note;
            menuItemNote.SaveButtonClicked += MenuItemNote_SaveButtonClicked;
            menuItemNote.Show();
        }

        private void MenuItemNote_SaveButtonClicked(object sender, string note)
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

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            OrderItemUserControl orderItemUserControl = (OrderItemUserControl)((Button)sender).Parent;

            MenuItem menuItem = orderItemUserControl.MenuItem;
            ItemDetails itemDetails = orderItemUserControl.ItemDetails;

            itemDetails.Quantity++;

            orderItemUserControl.UpdateData();
        }

        private void DecrementButton_Click(object sender, EventArgs e)
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

    }
}
