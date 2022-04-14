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
    public partial class frmCadHoldNote : Form
    {
        public frmCadHoldNote()
        {
            InitializeComponent();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            string note = richNote.Text;
            note = note.Replace("'", "");
            if (note.Length < 3)
            {
                MessageBox.Show("A detailed note is required before marking this job as 'On Hold'", "Note Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //note is fine
            CONNECT.cadOnHoldNote = note;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.cadOnHoldNote = "*cancel clicked*";
            this.Close();
        }

        private void richNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNote.PerformClick();
            }
        }
    }
}
