namespace CSt_150_Milestone_3
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
                // Read the contents of the file
                string filePath = openFileDialog.FileName;
                string[] fileLines = File.ReadAllLines(filePath);

                // Display the contents in the label
                lblFileContent.Text = string.Empty;
                foreach (string line in fileLines)
                {
                    lblFileContent.Text += line + Environment.NewLine;
                }

            }
        }
    }
}
