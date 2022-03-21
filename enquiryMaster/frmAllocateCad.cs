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
    public partial class frmAllocateCad : Form
    {
        public frmAllocateCad()
        {
            InitializeComponent();
        }

        private void btnChooseAllocation_Click(object sender, EventArgs e)
        {
            CONNECT.cadAllocationPath = 1;
            this.Height = 185;


        }

        private void btnAllocateToMyself_Click(object sender, EventArgs e)
        {
            CONNECT.cadAllocationPath = 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.cadAllocationPath = 3;
            this.Close();
        }
    }
}
