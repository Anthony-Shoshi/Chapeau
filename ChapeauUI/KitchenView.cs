using ChapeauUI.Components;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
        private Employee currentEmployee;
        private KitchenService kitchenService;
        private OrderService orderService;
        public KitchenView()
        {
            InitializeComponent();
            kitchenService = new KitchenService();
            orderService = new OrderService();
            currentEmployee = Employee.GetInstance();
        }

        private void KitchenView_Load(object sender, EventArgs e)
        {
            SetEmployeeInfo();
            SetOrderTypeCombo();
            SetOrders();
        }

        private void SetEmployeeInfo()
        {
            viewTypeLabel.Text = currentEmployee.UserType == UserType.Chef ? "Kitchen View" : "Bar View";
            userNameLabel.Text = currentEmployee.EmployeeName;
        }

        private void ChangeOrderStatus(int orderId, OrderStatus status)
        {
            orderService.UpdateOrderStatus(orderId, status);
            if (status == OrderStatus.OrderCompleted || status == OrderStatus.OrderReadyToServe)
            {
                SetOrders();
            }
        }


        private List<Order> GetOrdersForUserType(List<Order> orders)
        {
            return orders.Where(order =>
            {
                return order.OrderItems.Where(item =>
                {
                    if (currentEmployee.UserType == UserType.Bartender) return item.MenuItem.Category.CategoryName == "Drinks";
                    if (currentEmployee.UserType == UserType.Chef) return item.MenuItem.Category.CategoryName != "Drinks";
                    return true;
                }).Any();
            }).ToList();
        }

        private List<Order> GetOrdersForOrderType(List<Order> orders)
        {
            return orders.Where(order =>
            {
                if (orderTypeCombo.Text == "Completed orders") return order.Status == OrderStatus.OrderCompleted;

                else if (orderTypeCombo.Text == "Ready orders") return ((!order.OrderItems.Where(item =>
                {
                    if (currentEmployee.UserType == UserType.Bartender) return item.MenuItem.Category.CategoryName == "Drinks" && item.Status != OrderItemStatus.Ready;
                    if (currentEmployee.UserType == UserType.Chef) return item.MenuItem.Category.CategoryName != "Drinks" && item.Status != OrderItemStatus.Ready;
                    return true;
                }).Any()) && order.Status != OrderStatus.OrderCompleted);
                else if (orderTypeCombo.Text == "Placed orders") return ((order.OrderItems.Where(item =>
                {
                    if (currentEmployee.UserType == UserType.Bartender) return item.MenuItem.Category.CategoryName == "Drinks" && item.Status != OrderItemStatus.Ready;
                    if (currentEmployee.UserType == UserType.Chef) return item.MenuItem.Category.CategoryName != "Drinks" && item.Status != OrderItemStatus.Ready;
                    return true;
                }).Any()) && (order.Status == OrderStatus.OrderPlaced || order.Status == OrderStatus.OrderReceived || order.Status == OrderStatus.OrderProcessing));
                return true;
            }).OrderByDescending(o => o.WaitingTime).ToList();
        }


        private void SetOrders()
        {
            List<Order> orders = kitchenService.GetOrders();
            orders = GetOrdersForUserType(orders);
            orders = GetOrdersForOrderType(orders);

            mainPanel.Controls.Clear();
            if (orders.Count == 0)
            {
                Label noOrderLabel = new Label()
                {
                    Visible = true,
                    //Location = new Point(373, 182),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 30, FontStyle.Bold, GraphicsUnit.Point)
                };

                switch (orderTypeCombo.Text)
                {
                    case "Placed orders":
                        noOrderLabel.Text = "No new orders.";
                        break;
                    case "Ready orders":
                        noOrderLabel.Text = "No ready orders.";
                        break;
                    case "Completed orders":
                        noOrderLabel.Text = "No compleated orders.";
                        break;
                    default:
                        noOrderLabel.Text = "No order found.";
                        break;
                }
                mainPanel.Controls.Add(noOrderLabel);
                return;
            }
            mainPanel.Controls.Clear();
            int i = 0;
            foreach (Order order in orders)
            {
                IDictionary<string, List<OrderItem>> itemByCategory = GetItemCategories(order);
                if (itemByCategory.Count == 0) continue;

                KitchenWidgets w = new KitchenWidgets();
                int x = ((i - (3 * ((int)i / 3))) * w.Width) + 10;
                int y = ((int)i / 3 * w.Height) + 10;
                w.Location = new Point(x, y);

                i++;
                w.GetOrder(order, i, itemByCategory, ChangeOrderStatus, SetOrders);
                mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                mainPanel.Controls.Add(w);
            }
        }

        private IDictionary<string, List<OrderItem>> GetItemCategories(Order order)
        {
            IDictionary<string, List<OrderItem>> itemByCategory = new Dictionary<string, List<OrderItem>>();
            foreach (OrderItem item in order.OrderItems)
            {
                if (currentEmployee.UserType == UserType.Bartender && item.MenuItem.Category.CategoryName != "Drinks") continue;
                else if (currentEmployee.UserType == UserType.Chef && item.MenuItem.Category.CategoryName == "Drinks") continue;
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
            orderTypeCombo.Items.Add("Ready orders");

            orderTypeCombo.Text = "Placed orders";
        }

        private void orderTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOrders();
        }


        private void refreshButton_Click(object sender, EventArgs e)
        {
            SetOrders();
        }
    }
}
