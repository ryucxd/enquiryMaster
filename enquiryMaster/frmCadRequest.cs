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
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace enquiryMaster
{
    public partial class frmCadRequest : Form
    {
        public int _enquiryID { get; set; }
        public int _userID { get; set; }
        public string urgent_note { get; set; }
        public frmCadRequest(int enquiryID, int userID)
        {
            InitializeComponent();
            _enquiryID = enquiryID;
            _userID = userID;
            //make datetimepicker add one working day
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select [order_database].dbo.func_work_days_plus(cast(getdate() as date),1)", conn))
                {
                    dteCad.Value = Convert.ToDateTime(cmd.ExecuteScalar().ToString());
                }
                conn.Close();
            }

            //log the entry time and who did it

        }

        private void btnCAD_Click(object sender, EventArgs e)
        {
            string sql = "";
            string cad_note = "";
            int cad_revision = 0;
            int existing_order = 0;

            //sort out the controls into proper values for sql string
            richNote.Text = richNote.Text.Replace("'", "");
            if (richNote.Text.Length < 3)
            {
                MessageBox.Show("Please enter a detailed note before requesting CAD.", "Note Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkCadRevision.Checked == true)
                cad_revision = -1;
            if (chkExistingOrder.Checked == true)
                existing_order = -1;
            if (txtDrawingsRequired.Text.Length < 1)
            {
                MessageBox.Show("Please enter the amount of drawings you require before requesting CAD.", "No drawing quantity.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //get the old CAD note
                sql = "SELECT cad_note FROM dbo.enquiry_log WHERE id = " + _enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = (string)cmd.ExecuteScalar().ToString();
                    if (data != null)
                        cad_note = data + " - " + richNote.Text;
                    else
                        cad_note = richNote.Text;
                }
                string enquiry_note = "";
                sql = "SELECT enquiry_notes FROM dbo.enquiry_log WHERE id = " + _enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = (string)cmd.ExecuteScalar().ToString();
                    if (data != null)
                        enquiry_note = data + " - " + richNote.Text;
                    else
                        enquiry_note = richNote.Text;
                }
                int priorityJob = 0;
                if (chkUrgent.Checked == true)
                {
                    priorityJob = -1;
                    urgent_note = "URGENT JOB";
                }
                else
                    urgent_note = "";
                //update CAD details
                sql = "UPDATE dbo.enquiry_log SET enquiry_notes =  '" + richNote.Text + "',cad_note = '" + cad_note + "',requires_cad = -1,drawing_qty_required = " + txtDrawingsRequired.Text + "," +
                          "cad_revision = " + cad_revision + ",cad_due_date = '" + dteCad.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',existing_order = " + existing_order + ", estimator_cad_click_stamp = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                          "estimator_id = " + _userID + ",priority_job = " + priorityJob + " WHERE id = " + _enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();
            }
            // at this point we need to print out a sheet 
            print(_enquiryID);
            //now close
            this.Close();
        }
        private void print(int enquiryID)
        {
            MessageBox.Show("Please wait while the CAD sheet prints!");
            // Store the Excel processes before opening.
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel.
            string temp = @"\\designsvr1\apps\Design and Supply CSharp\CAD_Request_template.xlsx";
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
            string email_subject = "";
            string date_stamp = "";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //first up is email
                string sql = "SELECT sender_email_address FROM dbo.enquiry_log WHERE id = " + enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    email = (string)cmd.ExecuteScalar();
                    if (email.Contains("EXCHANGELABS/OU=EXCHANGE"))
                        email = email.Substring(email.IndexOf("-") + 1);
                }
                //currently logged in estimator
                sql = "SELECT forename + ' ' + surname FROM [user_info].dbo.[user] WHERE id = " + _userID.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    estimator = (string)cmd.ExecuteScalar();
                //date stamp
                date_stamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //notes
                sql = "SELECT enquiry_notes FROM dbo.enquiry_log WHERE id = " + enquiryID.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    enquiry_notes = (string)cmd.ExecuteScalar().ToString();
                //email subject
                sql = "SELECT [subject] FROM dbo.enquiry_log WHERE id = " + enquiryID.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    email_subject = (string)cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            


            xlWorksheet.Cells[2][2].Value2 = enquiryID;
            xlWorksheet.Cells[2][3].Value2 = estimator;
            xlWorksheet.Cells[2][4].Value2 = txtDrawingsRequired.Text;
            xlWorksheet.Cells[2][5].Value2 = dteCad.Value.ToLongDateString();
            xlWorksheet.Cells[2][6].Value2 = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            xlWorksheet.Cells[2][7].Value2 = email;
            xlWorksheet.Cells[2][8].Value2 = email_subject;
            xlWorksheet.Cells[1][10].Value2 = enquiry_notes;
            xlWorksheet.Cells[1][32].Value2 = urgent_note;



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
        }

        private void txtDrawingsRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.skipShuffle = true;
            this.Close();
        }

        private void richNote_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnCAD.PerformClick();
            //}
        }
    }
}
