using ChapeauUI.Components;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class KitchenView : Form
    {
        private Employee currEmp;
        private List<KitchenWidgets> wids;
        private OrderService orderService;
        public KitchenView()
        {
            InitializeComponent();
            wids = new List<KitchenWidgets>();
            orderService = new OrderService();
            currEmp = Employee.GetInstance();
        }

        private void KitchenView_Load(object sender, EventArgs e)
        {
            SetEmployeeInfo();
            SetOrderTypeCombo();
            SetOrders();
        }

        private void SetEmployeeInfo()
        {
            viewTypeLabel.Text = currEmp.UserType == UserType.Chef ? "Kitchen View" : "Bar View";
            userNameLabel.Text = currEmp.EmployeeName;
        }

        private void SetOrders()
        {
            List<Order> orders = orderService.GetOrders();
            int i = 0;
            orders = orders.Where(o =>
            {
                if (orderTypeCombo.Text == "Completed orders") return o.Status == OrderStatus.OrderCompleted;
                else if (orderTypeCombo.Text == "Placed orders") return o.Status == OrderStatus.OrderPlaced || o.Status == OrderStatus.OrderReceived;
                return true;
            }).OrderByDescending(o => o.WaitingTime).ToList();
            mainPanel.Controls.Clear();
            foreach (Order order in orders)
            {
                IDictionary<string, List<OrderItem>> itemByCategory = GetItemCategories(order);
                if (itemByCategory.Count == 0) continue;
                KitchenWidgets w = new KitchenWidgets();
                int x = ((i - (3 * ((int)i / 3))) * w.Width) + 10;
                int y = ((int)i / 3 * w.Height) + 10;
                i++;
                w.Location = new Point(x, y);
                w.GetOrder(order, i, currEmp, itemByCategory);
                wids.Add(w);
                mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                mainPanel.Controls.Add(w);
            }
        }

        private IDictionary<string, List<OrderItem>> GetItemCategories(Order order)
        {
            IDictionary<string, List<OrderItem>> itemByCategory = new Dictionary<string, List<OrderItem>>();
            foreach (OrderItem item in order.OrderItems)
            {
                if (currEmp.UserType == UserType.Bartender && item.MenuItem.Category.CategoryName != "Drinks") continue;
                else if (currEmp.UserType == UserType.Chef && item.MenuItem.Category.CategoryName == "Drinks") continue;
                if (itemByCategory.ContainsKey(item.MenuItem.MenuType))
                {
                    itemByCategory[item.MenuItem.MenuType].Add(item);
                }
                else
                {
                    itemByCategory[item.MenuItem.MenuType] = new List<OrderItem>() { item };
                }
            }

            return itemByCategory;
        }

        private void SetOrderTypeCombo()
        {
            orderTypeCombo.Items.Add("All orders");
            orderTypeCombo.Items.Add("Placed orders");
            orderTypeCombo.Items.Add("Completed orders");

            orderTypeCombo.Text = "All orders";
        }

        private void orderTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOrders();
        }

    }
}
