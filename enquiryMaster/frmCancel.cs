using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace enquiryMaster
{
    public partial class frmCancel : Form
    {
        public int _enquiryID { get; set; }
        public frmCancel(int enquiryID)
        {
            InitializeComponent();
            _enquiryID = enquiryID;
            lblEnquiry.Text = "Enquiry ID: " + enquiryID.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (richCancel.Text.Length < 3)
            {
                MessageBox.Show("Please enter a detailed cancellation reason before pressing confirm!", "Note Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this enquiry?", "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string cancel_reason = richCancel.Text.Replace("'", "");
                // "UPDATE dbo_enquiry_log SET status_id = 5,enquiry_notes = enquiry_notes &  '" & vbCrLf & vbCrLf & "Cancellation Note:" & Me.txt_note & "' WHERE id = " & TempVars!cancellation_enquiry_id & ";"


                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT enquiry_notes FROM dbo.enquiry_log  WHERE id = " + _enquiryID;
                    string enquiry_notes = "";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        enquiry_notes = cmd.ExecuteScalar().ToString();
                    }

                    sql = "UPDATE dbo.enquiry_log SET status_id = 5,enquiry_notes = '" + enquiry_notes + Environment.NewLine + " Cancel Reason: " + cancel_reason + "',allocated_to_id = null WHERE id = " + _enquiryID;

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
