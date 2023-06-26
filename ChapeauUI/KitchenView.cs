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
        private List<KitchenWidgets> wids;
        private OrderService orderService;
        public KitchenView()
        {
            InitializeComponent();
            wids = new List<KitchenWidgets>();
            orderService = new OrderService();
        }

        private void KitchenView_Load(object sender, EventArgs e)
        {
            SetOrderTypeCombo();
            SetOrders();
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
                KitchenWidgets w = new KitchenWidgets();
                int x = ((i - (3 * ((int)i / 3))) * w.Width) + 10;
                int y = ((int)i / 3 * w.Height) + 10;
                i++;
                w.Location = new Point(x, y);
                w.GetOrder(order, i);
                wids.Add(w);
                mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                mainPanel.Controls.Add(w);
            }
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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
