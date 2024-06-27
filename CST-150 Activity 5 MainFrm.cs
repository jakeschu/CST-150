/* Jake Schumacher 
 * CST-150
 * Activity 5
 * June 27, 2024
 */
namespace CST_150_Dog_Class.PresentationLayer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            lblErrorMessage.Visible = false;
        }

        /// <summary>
        /// Click event to add a new dog to the datagrdview tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDog_Click(object sender, EventArgs e)
        {
            //Declare and initialize
            bool isValidEntries = true;
            double weight = 0.00D, neckRad = 0.00D, neckCircum = 0.00D;

            bool isValid = false;

            lblErrorMessage.Visible = false;

            Utility utility = new Utility();

            if (!utility.NotNull(txtName.Text) || !utility.NotNull(txtColor.Text) || (cmbSit.SelectedItem == null))
            {
                isValidEntries = false;
            }

            (neckRad, isValid) = utility.ValidDouble(txtNeck.Text);
            if (!isValid)
            {
                isValidEntries = false;
            }

            (weight, isValid) = utility.ValidDouble(txtWeight.Text);
            if (!isValid)
            {
                isValidEntries = false;
            }

            var bill = txtName.Text;
            var combobox = cmbSit.SelectedItem;

            Dog ginger = new Dog("Ginger", 12.24, "Golden Cream", 57.25, false);

            var name = ginger.Name;
            var color = ginger.Color;

            if (isValidEntries)
            {
                Dog dogObject = new Dog(txtName.Text, neckRad, txtColor.Text, weight, utility.ConvertToBool(cmbSit.Text));
                gvShowDogs.Rows.Add(dogObject.Name, dogObject.CalCircumference(), dogObject.Sit, dogObject.CalWeight(), dogObject.Color);

            }
            else
            {
                lblErrorMessage.Visible = true;
            }


        }

        /// <summary>
        /// When the form loads, execute this event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            gvShowDogs.ColumnCount = 5;
            gvShowDogs.Columns[0].Name = "Name";
            gvShowDogs.Columns[1].Name = "Neck Circum";
            gvShowDogs.Columns[2].Name = "Sitting";
            gvShowDogs.Columns[3].Name = "Weight";
            gvShowDogs.Columns[4].Name = "Color";

            gvShowDogs.Columns[1].DefaultCellStyle.Format = "#.00";
            gvShowDogs.Columns[3].DefaultCellStyle.Format = "#.00";

        }
    }
}
