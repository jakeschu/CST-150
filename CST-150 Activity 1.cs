namespace Activity1
{
    public partial class Form1 : Form
    {

        string name;
        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayNameButton_Click(object sender, EventArgs e)
        {
            name = NameTextbox.Text;
            NameDisplayLabel.Text = "Your Name Is: " + name;
        }
    }
}
