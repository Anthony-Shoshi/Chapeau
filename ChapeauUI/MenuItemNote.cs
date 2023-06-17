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
    public partial class MenuItemNote : Form
    {
        public MenuItem MenuItem { get; private set; }
        public string NoteText
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }
        public event EventHandler<string> SaveButtonClicked;

        public MenuItemNote(MenuItem menuItem)
        {
            InitializeComponent();
            MenuItem = menuItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string note = txtNote.Text;
            SaveButtonClicked?.Invoke(this, note);
            Close();
        }

        private void btnCancelNote_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
