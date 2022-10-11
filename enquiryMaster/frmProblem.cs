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
    public partial class frmProblem : Form
    {

        public int enquiry_id { get; set; }
        public frmProblem(int _enquiry_id)
        {
            InitializeComponent();
            enquiry_id = _enquiry_id;
            this.Text = enquiry_id.ToString();

            fillGrid();

        }

        private void fillGrid()
        {
            string sql = "SELECT project,quantity,requested_change,issues,problems,date_created FROM dbo.problem_log WHERE enquiry_id = " + enquiry_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    txtProject.Text = dt.Rows[0][0].ToString();
                    txtQuantity.Text = dt.Rows[0][1].ToString();
                    txtRequestedChange.Text = dt.Rows[0][2].ToString();
                    txtIssue.Text = dt.Rows[0][3].ToString();
                    txtProblems.Text = dt.Rows[0][4].ToString();
                    dteCreated.Value = Convert.ToDateTime(dt.Rows[0][5].ToString());

                    conn.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtIssue.Text = txtIssue.Text.Replace("'", "");
            string sql = "UPDATE dbo.problem_log SET project = '" + txtProject.Text + "',quantity = " + txtQuantity.Text + ",requested_change = '" + txtRequestedChange.Text + "'," +
                "issues = '" + txtIssue.Text + "',problems = '" + txtProblems.Text + "' WHERE enquiry_id = " + enquiry_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.Close();
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"\\designsvr1\public\Enquiry Log Problems\" + enquiry_id.ToString());
            System.Diagnostics.Process.Start(@"\\designsvr1\public\Enquiry Log Problems\" + enquiry_id.ToString());
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

        }
    }
}
