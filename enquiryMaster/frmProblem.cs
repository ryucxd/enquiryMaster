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
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

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
            if (txtQuantity.Text.Length == 0)
                txtQuantity.Text = "0";
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
            //replace all the ' in all of the text boxes
            txtProject.Text = txtProject.Text.Replace("'", "");
            txtRequestedChange.Text = txtRequestedChange.Text.Replace("'", "");
            txtIssue.Text = txtIssue.Text.Replace("'", "");
            txtProblems.Text = txtProblems.Text.Replace("'", "");



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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //quickly save everything before going  (AND INSERT INTO ACTIVITY)
            if (1 == 1)
            {
                //replace all the ' in all of the text boxes
                txtProject.Text = txtProject.Text.Replace("'", "");
                txtRequestedChange.Text = txtRequestedChange.Text.Replace("'", "");
                txtIssue.Text = txtIssue.Text.Replace("'", "");
                txtProblems.Text = txtProblems.Text.Replace("'", "");



                string sql = "UPDATE dbo.problem_log SET project = '" + txtProject.Text + "',quantity = " + txtQuantity.Text + ",requested_change = '" + txtRequestedChange.Text + "'," +
                    "issues = '" + txtIssue.Text + "',problems = '" + txtProblems.Text + "' WHERE enquiry_id = " + enquiry_id.ToString();
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        //update activity log
                        sql = "SELECT id FROM dbo.problem_log WHERE enquiry_id = " + enquiry_id.ToString();
                        int problem_id = 0;
                        using (SqlCommand cmdProblem = new SqlCommand(sql, conn))
                            problem_id = Convert.ToInt32(cmdProblem.ExecuteScalar().ToString());

                            sql = "INSERT INTO dbo.problem_log_activity (problem_log_id,viewed,viewed_by,printed,printed_by,date_of_action) VALUES (" + problem_id + ",NULL,NULL,-1," + CONNECT.staffID.ToString() + ",GETDATE())";
                        using (SqlCommand cmdActivity = new SqlCommand(sql, conn))
                            cmdActivity.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }


            // Store the Excel processes before opening.
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel.
            string temp = @"\\designsvr1\apps\Design and Supply CSharp\enquiry_problem_template.xlsx";
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Open(temp);
            var xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
            // Get Excel processes after opening the file.
            Process[] processesAfter = Process.GetProcessesByName("excel");

            //get all the variables for each item on the print out
            string email = "";
            //drawing_qty is on the form
            //cad due date is on the form
            string estimator = "";
            string enquiry_notes = "";
            string date_stamp = "";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //first up is email
                string sql = "SELECT 'Enquiry ' + CAST(enquiry_id as nvarchar(max)) + ' - Problem Logged - ' + convert(varchar(255), date_created, 103),project,quantity,requested_change,issues,problems FROM dbo.problem_log  WHERE enquiry_id = " + enquiry_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    xlWorksheet.Cells[1][1].Value2 = dt.Rows[0][0].ToString() ;
                    xlWorksheet.Cells[2][2].Value2 = dt.Rows[0][1].ToString();
                    xlWorksheet.Cells[2][3].Value2 = dt.Rows[0][2].ToString();
                    xlWorksheet.Cells[1][5].Value2 = dt.Rows[0][3].ToString();
                    xlWorksheet.Cells[1][7].Value2 = dt.Rows[0][4].ToString();
                    xlWorksheet.Cells[1][9].Value2 = dt.Rows[0][5].ToString();

                }
               
                conn.Close();
            }



            //print it
            xlWorksheet.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            xlWorkbook.Close(false); //close the excel sheet without saving
            // xlApp.Quit();


            // Manual disposal because of COM
            xlApp.Quit();

            // Now find the process id that was created, and store it.
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                }
            }

            // And now kill the process.
            if (processID != 0)
            {
                Process process = Process.GetProcessById(processID);
                process.Kill();
            }
            MessageBox.Show("The printout has been sent to your default printer!", "Print successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
