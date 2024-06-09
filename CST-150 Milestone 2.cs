//Jake Schumacher. This is my own code. June 09, 2024
namespace CST_150_Milestone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;

            string quantityString = QuantityTextBox.Text;
            double quantity = double.Parse(quantityString);

            string priceString = PriceTextBox.Text;
            double price = double.Parse(priceString);

            ListLabel.Text = quantity + " " + name + " for $" + Math.Round(price * quantity, 2);
        }
    }
}
