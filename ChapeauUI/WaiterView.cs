using Model;
using Service;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        bool isAlcoholic;
        private ListView listView;

        public WaiterView()
        {
            InitializeComponent();
            GeneratTable();
            HidePanels();
            lblUsername.Text = Employee.GetInstance().Username;
            isAlcoholic = false;
            HidePanels();
            tableLayoutPanelTable.Show();
        }

        private void HidePanels()
        {
            tableLayoutPanelTable.Hide();

        }

        private void GeneratTable()
        {
            TableService tableService = new TableService();
            List<Table> tables = tableService.GetAllTables();
            int columnCount = 5;
            int rowIndex = 0;
            int columnIndex = 0;

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

        private void TableControl_Click(object sender, EventArgs e)
        {
            TableUserControl clickedTable = (TableUserControl)sender;
        }


    }
}
