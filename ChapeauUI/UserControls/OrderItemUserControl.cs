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
        public event EventHandler NoteDoubleClick;

        public OrderItemUserControl(MenuItem menuItem, ItemDetails itemDetails)
        {
            InitializeComponent();

            IncrementButton = btnIncrement;
            DecrementButton = btnDecrement;
            lblMenuItemName.DoubleClick += LblMenuItemName_DoubleClick;

            MenuItem = menuItem;
            ItemDetails = itemDetails;
            UpdateData();
        }

        private void LblMenuItemName_DoubleClick(object sender, EventArgs e)
        {
            NoteDoubleClick?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateData()
        {
            lblMenuItemName.Text = MenuItem.Name;

            ToolTip yourToolTip = new ToolTip();
            yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            yourToolTip.SetToolTip(lblMenuItemName, MenuItem.Name);

            lblQnty.Text = ItemDetails.Quantity.ToString();

            if (ItemDetails.Note.Equals(""))
            {
                lblNote.Hide();
            }
            else
            {
                lblNote.Text = ItemDetails.Note;
            }
        }
    }
}
