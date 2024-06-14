using System.Runtime.CompilerServices;

namespace CST_150_Activity_3
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            selectFileDialog.InitialDirectory = Application.StartupPath + @"Data";
            selectFileDialog.Title = "Browse Text Files";
            selectFileDialog.DefaultExt = "txt";
            selectFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            lblResults.Visible = false;
            lblSelectedFile.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtFile = "";
            string dirlocation = "";
            const int PadSpace = 20;
            string header1 = "Type", header2 = "Color", header3 = "Qty";
            string headerLine1 = "----", headerLine2 = "-----", headerLine3 = "---";

            if (this.selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile = this.selectFileDialog.FileName;
                dirlocation = Path.GetFullPath(selectFileDialog.FileName);
                lblSelectedFile.Text = txtFile;
                lblSelectedFile.Visible = true;

                string[] lines = File.ReadAllLines(txtFile);
                lblResults.Text = "";

                lblResults.Text = string.Format("{0}{1}{2}\n", header1.PadRight(PadSpace), header2.PadRight(PadSpace), header3.PadRight(PadSpace));
                lblResults.Text += string.Format("{0}{1}{2}\n", headerLine1.PadRight(PadSpace), headerLine2.PadRight(PadSpace), headerLine3.PadRight(PadSpace));
                foreach (string line in lines)
                {
                    string[] inventoryList = line.Split(",");
                    for(int i = 0; i < inventoryList.Length; i++)
                    {
                        lblResults.Text = inventoryList[i].PadRight(PadSpace);
                    }
                    lblResults.Text += string.Format("{0}\n", line);
                }
                lblResults.Visible = true;
            }
        }
    }
}
