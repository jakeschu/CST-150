using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_150_Milestone_5
{
    public partial class FrmSecondary : Form
    {
        List<InvItem> mySearch = new List<InvItem>();

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="invSearch"></param>
        public FrmSecondary(List<InvItem> invSearch)
        {
            InitializeComponent();
            this.mySearch = invSearch;
        }

        private void FrmSecondary_Load(object sender, EventArgs e)
        {
            gvSearchResults.DataSource = this.mySearch;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close the form.
            this.Close();
        }
    }
}
