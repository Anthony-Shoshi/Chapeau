using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ChapeauUI.UserControls
{
    public partial class OrderItemUserControl : UserControl
    {
        public MenuItem MenuItem;
        public ItemDetails ItemDetails;
        public Button IncrementButton { get; set; }
        public Button DecrementButton { get; set; }

        public OrderItemUserControl(MenuItem menuItem, ItemDetails itemDetails)
        {
            InitializeComponent();

            IncrementButton = btnIncrement;
            DecrementButton = btnDecrement;

            MenuItem = menuItem;
            ItemDetails = itemDetails;
            UpdateData();
        }

        public void UpdateData()
        {
            lblMenuItemName.Text = MenuItem.Name;
            lblQnty.Text = ItemDetails.Quantity.ToString();
        }
    }
}
