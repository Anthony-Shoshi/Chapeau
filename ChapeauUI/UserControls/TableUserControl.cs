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

namespace ChapeauUI
{
    public partial class TableUserControl : UserControl
    {
        public Table Table;
        public TableUserControl(Table table)
        {
            InitializeComponent();
            Table = table;
            UpdateData();            
        }

        private void UpdateData()
        {
            btnTableNo.Text = "Table "  + Table.Number.ToString();
            UpdatePanelColor();
        }

        private void UpdatePanelColor()
        {
            switch (Table.Status)
            {
                case TableStatus.Available:
                    setColor(Color.Green);
                    break;
                case TableStatus.Occupied:
                    setColor(Color.Red);
                    break;
                case TableStatus.Reserved:
                    setColor(Color.Yellow);
                    break;
                default:
                    setColor(Color.Gray);
                    break;
            }
        }

        private void setColor(Color color)
        {
            btnTableNo.BackColor = color;
            pnlTableTop.BackColor = color;
            pnlTableRight.BackColor = color;
            pnlTableBottom.BackColor = color;
            pnlTableLeft.BackColor = color;

            if (color.Equals(Color.Yellow))
            {
                btnTableNo.ForeColor = Color.Black;
            }
        }

        private void btnTableNo_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
