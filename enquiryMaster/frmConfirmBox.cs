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
    public partial class frmConfirmBox : Form
    {
        public frmConfirmBox()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.confirmCorrect = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "confirm" || txtConfirm.Text == "Confirm" || txtConfirm.Text == "CONFIRM")
            {
                CONNECT.confirmCorrect = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please check your spelling and try again!", "Confirm Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Text = "";
            }
        }

        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
