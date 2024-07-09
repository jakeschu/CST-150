using System;
using System.Linq;
using System.Windows.Forms;

namespace CST_150_Milestone_6
{
    public partial class Form1 : Form
    {
        private Inventory inventory;
        private string filePath;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvInventory.Columns.Add("Name", "Name");
            dgvInventory.Columns.Add("Quantity", "Quantity");
            dgvInventory.Columns.Add("Price", "Price");

            dgvInventory.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInventory.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInventory.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        private void GetFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open Text File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                LoadInventoryFromFile(filePath);
            }
        }

        private void LoadInventoryFromFile(string filePath)
        {
            inventory = new Inventory(filePath);
            DisplayInventory();
        }

        private void DisplayInventory()
        {
            dgvInventory.Rows.Clear();
            foreach (var item in inventory.InventoryItems)
            {
                dgvInventory.Rows.Add(item.Name, item.Quantity, item.Price);
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            var newItem = new InventoryItem(name, quantity, price);
            inventory.AddItem(newItem);
            DisplayInventory();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    var item = inventory.InventoryItems.Find(i => i.Name == name);
                    inventory.RemoveItem(item);
                }
                DisplayInventory();
            }
        }

        private void IncrementQuantityButton_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    var item = inventory.InventoryItems.Find(i => i.Name == name);
                    inventory.IncrementQuantity(item);
                }
                DisplayInventory();
            }
        }

        private void DecrementQuantityButton_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    string name = row.Cells["Name"].Value.ToString();
                    var item = inventory.InventoryItems.Find(i => i.Name == name);
                    inventory.DecrementQuantity(item);
                }
                DisplayInventory();
            }
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                inventory.WriteInventoryToFile(filePath);
            }
        }
    }
}
