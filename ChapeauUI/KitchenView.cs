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
        OrderService orderService;
        public KitchenView()
        {
            InitializeComponent();
            orderService = new OrderService();
        }

        private void KitchenView_Load(object sender, EventArgs e)
        {
            List<OrderRestaurantView> orders = new List<OrderRestaurantView>();
            orders = orderService.GetOrderRestaurantViews();
            DisplayRestaurantOrders(orders);
        }

        private void DisplayRestaurantOrders(List<OrderRestaurantView> orders)
        {
            listView1.Items.Clear();

            foreach (OrderRestaurantView order in orders)
            {
                ListViewItem li = new ListViewItem(order.Id.ToString());
                li.Tag = order;   // link student object to listview item

                li.SubItems.Add(order.EmployeeName.ToString());
                li.SubItems.Add(order.TableNumber.ToString());
                li.SubItems.Add(order.TableStatus.ToString());
                li.SubItems.Add(order.Status.ToString());
                li.SubItems.Add(order.PlacedTime.ToString());
                li.SubItems.Add(order.Quantity.ToString());
                li.SubItems.Add(order.Note.ToString());
                li.SubItems.Add(order.UnitPrice.ToString());
                li.SubItems.Add(order.MenuItemName.ToString());
                li.SubItems.Add(order.Price.ToString());
                li.SubItems.Add(order.MenuType.ToString());
                li.SubItems.Add(order.CategoryName.ToString());

                listView1.Items.Add(li);
            }
        }
    }
}
