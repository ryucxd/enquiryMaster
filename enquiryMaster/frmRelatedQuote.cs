using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enquiryMaster
{
    public partial class frmRelatedQuote : Form
    {
        public int enquiry_id { get; set; }
        public frmRelatedQuote(int _enquiry_id)
        {
            InitializeComponent();
            enquiry_id = _enquiry_id;
        }

        private void txtQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check if this is a valid quote?

            string sql = "select cast(quote_id as nvarchar) + '-' + CAST(revision_number as nvarchar) from [order_database].dbo.solidworks_quotation_log " +
                "where cast(quote_id as nvarchar) + '-' + CAST(revision_number as nvarchar) = '" + txtQuote.Text + "-" + txtRev.Text + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    var valid_quote = (string)cmd.ExecuteScalar();

                    if (string.IsNullOrEmpty(valid_quote))
                    {
                        MessageBox.Show("This is not a valid quote, please check the details and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //update the enquiry > related_quote < 

                sql = "UPDATE dbo.enquiry_log SET related_quote = '" + txtQuote.Text + "-" + txtRev.Text + "',related_quote_by = " + CONNECT.staffID + ",related_quote_stamp = GETDATE() WHERE id = " + enquiry_id.ToString() ;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                    conn.Close();

                CONNECT.cancelRelatedQuote = 0;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.cancelRelatedQuote = -1;
            this.Close();
        }

        private void btnNoRelatedQuotes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to mark this as not having a related quote?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                   string  sql = "UPDATE dbo.enquiry_log SET related_quote = 'No Related Quote',related_quote_by = " + CONNECT.staffID + ",related_quote_stamp = GETDATE() WHERE id = " + enquiry_id.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    conn.Close();

                    this.Close();
                }
            }
        }
    }
}
