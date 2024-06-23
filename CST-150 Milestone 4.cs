//Jake Schumacher. This is my own code. June 22, 2024
namespace CST_150_Milestone_4
{
    public partial class Form1 : Form
    {
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
            // Display the contents in the label
            lblFileContent.Text = string.Empty;
            foreach (string line in inventoryLines)
            {
                lblFileContent.Text += line + Environment.NewLine;
            }
        }
    }
}
