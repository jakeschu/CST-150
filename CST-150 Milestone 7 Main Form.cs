using CST_150_Milestone_5.BusinessLogic;
using System.Data;

namespace CST_150_Milestone_5
{
    public partial class Form1 : Form
    {
        List<InvItem> invItems = new List<InvItem>();
        List<InvItem> invSearch = new List<InvItem>();

        private int SelectedGridIndex { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void GetFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open Text File"
            };

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] fileLines = ReadInventoryFromFile(filePath);
                DisplayInventory(fileLines);
            }
        }

        private string[] ReadInventoryFromFile(string filePath)
        {
            // Read the contents of the file
            return File.ReadAllLines(filePath);
        }
        private void DisplayInventory(string[] inventoryLines)
        {
            // Assuming the inventoryLines contain a header row followed by data rows
            // Create a DataTable to hold the data
            DataTable dt = new DataTable();

            // Split the first line to get the column names and add them to the DataTable
            string[] columnNames = inventoryLines[0].Split(',');
            foreach (string columnName in columnNames)
            {
                dt.Columns.Add(columnName);
            }

            // Add the data rows to the DataTable
            for (int i = 1; i < inventoryLines.Length; i++)
            {
                string[] rowData = inventoryLines[i].Split(',');
                dt.Rows.Add(rowData);
            }

            // Set the DataSource of the DataGridView to the DataTable
            gvInv.DataSource = dt;
        }

        private void BtnDeleteItem_EventHandler(object sender, EventArgs e)
        {
            invItems.RemoveAt(SelectedGridIndex);
            gvInv.DataSource = null;
            gvInv.DataSource = invItems;
        }

        private void GridView_ClickEventHandler(object sender, EventArgs e)
        {
            SelectedGridIndex = gvInv.CurrentRow.Index;
        }

        private void BtnSearch_ClickEvent(object sender, EventArgs e)
        {
            string searchFor = txtSearch.Text;
            Inventory businessLayer = new Inventory();
            invSearch = businessLayer.SearchItem(invItems, invSearch, searchFor);

            FrmSecondary frmSecondary = new FrmSecondary(invSearch);
            frmSecondary.ShowDialog();
        }

        private void PopulateGrid_LoadEventHandler(object sender, EventArgs e)
        {
            Inventory readInv = new Inventory();
            invItems = readInv.ReadInventory(invItems);

            gvInv.DataSource = null;
            gvInv.DataSource = invItems;

            foreach (DataGridViewColumn column in gvInv.Columns)
            {
                switch (column.Index)
                {
                    case 0:
                        column.HeaderText = "Name";
                        break;
                    case 1:
                        column.HeaderText = "Quantity";
                        break;
                    case 2:
                        column.HeaderText = "Price";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    default:
                        MessageBox.Show("Invalid column was trying to be accessed!");
                        break;
                }
            }
        }

        private void btnIncQty_Click(object sender, EventArgs e)
        {
            Inventory incQty = new Inventory();
            invItems = incQty.IncQtyValue(invItems, SelectedGridIndex);
            gvInv.Refresh();
        }
    }
}
