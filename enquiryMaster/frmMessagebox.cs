using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enquiryMaster
{
    public partial class frmMessagebox : Form
    {
        public frmMessagebox(int enquiry_id)
        {
            InitializeComponent();
            lblRed.Text = "LASTEST ENQUIRY NUMBER: " + enquiry_id;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
