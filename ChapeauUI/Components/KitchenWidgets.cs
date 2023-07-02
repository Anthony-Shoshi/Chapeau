using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChapeauUI.Components.KitchenWidgets;

namespace ChapeauUI.Components
{
    public partial class KitchenWidgets : UserControl
    {
        private Order order;
        bool compleatedOrReady;
        private TimeSpan waitTime;
        private KitchenService kitchenService;
        private Employee currEmp;
        private IDictionary<string, List<OrderItem>> itemByCategory = new Dictionary<string, List<OrderItem>>();
        public delegate void ChangeOrderStatus(int orderId, OrderStatus status);
        public delegate void RefreshPage();
        private RefreshPage RefreshPageFunc;
        private ChangeOrderStatus ChangeOrderStatusFunc;
        public KitchenWidgets()
        {
            InitializeComponent();
            kitchenService = new KitchenService();
            currEmp = Employee.GetInstance();
            timer1.Tick += new EventHandler(IncrementWaitTimeTimer);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void IncrementWaitTimeTimer(Object myObject,
                                         EventArgs myEventArgs)
        {
            if (order != null && order.Status != OrderStatus.OrderCompleted || order.Status != OrderStatus.OrderReadyToServe)
            {
                this.waitTime = this.waitTime.Add(TimeSpan.FromSeconds(1));
                waitingTimeLabel.Text = this.waitTime.ToString(@"hh\:mm\:ss");
                if (order.Status == OrderStatus.OrderCompleted || order.Status == OrderStatus.OrderReadyToServe) timer1.Stop();
            }
            else timer1.Stop();
        }


        private void itemTitle1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Blue) this.BackColor = Color.GhostWhite;
            else this.BackColor = Color.Blue;
        }


        public void GetOrder(Order order, int priority, IDictionary<string, List<OrderItem>> itemByCategory, ChangeOrderStatus changeOrderStatus, RefreshPage refreshPage)
        {
            this.order = order;
            this.waitTime = order.WaitingTime;
            this.itemByCategory = itemByCategory;
            this.ChangeOrderStatusFunc = new ChangeOrderStatus(changeOrderStatus);
            this.RefreshPageFunc = refreshPage;
            this.compleatedOrReady = order.Status == OrderStatus.OrderCompleted || order.Status == OrderStatus.OrderReadyToServe;
            if (compleatedOrReady)
            {
                labWaitingTime.Visible = false;
                waitingTimeLabel.Visible = false;
                labBarmanName.Visible = false;
                labwaitername.Visible = false;
            }

            priorityLabel.Text = $"{priority}";
            waitingTimeLabel.Text = compleatedOrReady ? "-" : this.waitTime.ToString(@"dd\:hh\:mm\:ss");
            btnUpdate.Enabled = order.OrderItems.Where(item =>
            {
                if (currEmp.UserType == UserType.Bartender) return item.MenuItem.Category.CategoryName == "Drinks" && item.Status != OrderItemStatus.Ready;
                if (currEmp.UserType == UserType.Chef) return item.MenuItem.Category.CategoryName != "Drinks" && item.Status != OrderItemStatus.Ready;
                return true;
             }).Any();
            //btnUpdate.Enabled = order.Status != OrderStatus.OrderCompleted && order.Status != OrderStatus.OrderReadyToServe;
            btnUpdate.BackColor = btnUpdate.Enabled ? SystemColors.HotTrack : Color.Gray;

            tableNumberLabel.Text = order.Table.Number.ToString();
            orderTimeLabel.Text = order.PlacedTime.ToString("T");
            DisplayOrderItems();
        }

        public void DisplayOrderItems()
        {
            panelButtom.AutoScroll = true;
            panelButtom.HorizontalScroll.Visible = false;
            int count = 0;
            foreach (KeyValuePair<string, List<OrderItem>> kvp in this.itemByCategory)
            {
                Label lb = new Label();
                lb.Text = kvp.Key;
                lb.Visible = true;
                lb.BackColor = SystemColors.HighlightText;
                lb.AutoSize = true;
                lb.ForeColor = SystemColors.MenuHighlight;
                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold, GraphicsUnit.Point);
                int y = count > 0 ? 35 * (count + GetPrevItems(count)) : 0;
                lb.Location = new Point(4, y);

                panelButtom.Controls.Add(lb);

                int subY = y + 35;
                foreach (OrderItem item in kvp.Value)
                {
                    DisplayMenuItem(item, 4, subY);
                    subY += 35;
                }
                count++;
            }
        }

        private int GetPrevItems(int count)
        {
            List<string> keys = itemByCategory.Keys.ToList();
            int prev = 0;
            for (int i = 0; i < count; i++)
            {
                prev += itemByCategory[keys[i]].Count;
            }

            return prev;
        }

        public void DisplayMenuItem(OrderItem orderItem, int startX, int startY)
        {
            CheckBox cb = new CheckBox();
            cb.Text = orderItem.MenuItem.Name;
            Name = $"{orderItem.MenuItem.MenuId}";
            cb.Visible = true;
            cb.AutoSize = true;
            cb.MaximumSize = new Size(370, 0);
            cb.AutoEllipsis = true;
            cb.Font = new Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point);
            cb.Location = new Point(startX, startY);
            cb.Enabled = orderItem.Status != OrderItemStatus.Ready;
            panelButtom.Controls.Add(cb);

            Label noteLabel = new Label
            {
                Text = orderItem.Note.Length > 0 ? orderItem.Note : "No Note",
                Visible = true,
                BackColor = SystemColors.HighlightText,
                AutoSize = true,
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(startX + 20, startY + 20),
            };
            panelButtom.Controls.Add(noteLabel);

            Label lb = new Label
            {
                Text = $"X",
                Visible = true,
                BackColor = SystemColors.HighlightText,
                AutoSize = true,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 12, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(384, startY),
            };
            panelButtom.Controls.Add(lb);
            Label quantity = new Label
            {
                Text = $"{orderItem.Quantity}",
                Visible = true,
                BackColor = SystemColors.HighlightText,
                AutoSize = true,
                ForeColor = Color.OrangeRed,
                Font = new Font("Segoe UI", 12, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(401, startY),
            };
            panelButtom.Controls.Add(quantity);

            Panel statusPanel = new Panel()
            {
                Location = new Point(424, startY),
                Name = $"{orderItem.OrderItemId}-{orderItem.MenuItem.MenuId}",
                AutoSize = false,
                BackColor = SystemColors.MenuHighlight,
                Size = new Size(102, 28)

            };

            panelButtom.Controls.Add(statusPanel);

            string statusText = orderItem.Status == OrderItemStatus.Ordered ? "Ordered" : orderItem.Status == OrderItemStatus.BeingPrepared ? "Being Prepared" : "Ready";

            Label status = new Label
            {
                Text = $"{statusText}",
                Name = $"{orderItem.OrderItemId}-{orderItem.MenuItem.MenuId}",
                Visible = true,
                BackColor = SystemColors.MenuHighlight,
                AutoSize = true,
                ForeColor = SystemColors.HighlightText,
                Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(2, 6),
            };

            statusPanel.Controls.Add(status);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (var control in panelButtom.Controls.OfType<CheckBox>())
            {
                if (control.Checked)
                {
                    OrderItem item = order.OrderItems.Where(o => o.MenuItem.Name == control.Text).FirstOrDefault();
                    Panel statusPanel = panelButtom.Controls.OfType<Panel>().Where(p => p.Name == $"{item.OrderItemId}-{item.MenuItem.MenuId}").FirstOrDefault();
                    Label currItemLabel = statusPanel.Controls.OfType<Label>().Where(lb => lb.Name == $"{item.OrderItemId}-{item.MenuItem.MenuId}").FirstOrDefault();
                    if (item == null || currItemLabel == null) return;

                    switch (item.Status)
                    {
                        case OrderItemStatus.Ordered:
                            kitchenService.UpdateOrderItemStatus(item.Order.OrderId, item.MenuItem.MenuId, OrderItemStatus.BeingPrepared);
                            item.Status = OrderItemStatus.BeingPrepared;
                            if (order.Status != OrderStatus.OrderProcessing) ChangeOrderStatusFunc(order.OrderId, OrderStatus.OrderProcessing);
                            currItemLabel.Text = "Being Prepared";
                            break;
                        case OrderItemStatus.BeingPrepared:
                            kitchenService.UpdateOrderItemStatus(item.Order.OrderId, item.MenuItem.MenuId, OrderItemStatus.Ready);
                            item.Status = OrderItemStatus.Ready;
                            if (CheckOrderStatus(OrderItemStatus.Ready)) ChangeOrderStatusFunc(order.OrderId,OrderStatus.OrderReadyToServe);
                            currItemLabel.Text = "Ready";
                            this.RefreshPageFunc();
                            break;
                    }
                    control.Checked = false;
                }
            }
        }

        private bool CheckOrderStatus(OrderItemStatus status)
        {
            return order.OrderItems.Where(item => item.Status != status).Count() == 0;
        }

    }
}
