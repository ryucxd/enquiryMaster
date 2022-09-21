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
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace enquiryMaster
{
    public partial class frmEnquiryDetails : Form
    {
        public string htmlstring { get; set; }
        public int _enquiryID { get; set; }
        public int skipUpdate { get; set; }
        public int oldQty { get; set; }
        public int skipFirstPrint { get; set; }
        public frmEnquiryDetails(int enquiryID)
        {
            InitializeComponent();
            this.Text = "Enquiry: " + enquiryID.ToString();
            _enquiryID = enquiryID;

            if (CONNECT.isSlimline == -1)
            {
                cmbABC.Visible = true;
                chkPriority.Visible = false;
            }
            else
            {
                cmbABC.Visible = false;
                chkPriority.Visible = true;
            }

            skipUpdate = -1;
            skipFirstPrint = -1;
            refreshData();
            if (skipFirstPrint == -1)
                skipFirstPrint = 0;

        }

        private void refreshData()
        {
            //get alll the enquiry data
            string sql = "select enquiry_log.id,recieved_time,sender_email_address,es.[description] as [status], priority_job,price_qty_required as [quotes_required],revision,slimline_request,is_aluminium,is_technical," + //is technical is 9
                "u_estimator.forename + ' ' + u_estimator.surname as [allocated_to_estimator],drawing_qty_required,cad_revision,u_cad.forename + ' ' + u_cad.surname as [allocated_to_cad],as_built,from_scratch,on_hold,detailed,on_hold_note," + // on hold note is 18
                "u_checked.forename + ' ' + u_checked.surname + ' - ' + CAST(checked_date as nvarchar(max)) as checked_by," +//checked 19
                " u_processed.forename + ' ' + u_processed.surname + ' - ' + CAST(processed_date as nvarchar(max)) as processed_by, " + //processed by 20
                "u_processed_cad.forename + ' ' + u_processed_cad.surname + ' - ' + CAST(processed_cad_date as nvarchar(max)) as processed_by_cad, " +//processed cad 21
                "u_complete.forename + ' ' + u_complete.surname + ' - ' + CAST(complete_date as nvarchar(max)) as complete_by," + //complete 22
                "enquiry_notes,cad_note,Body,tender_due_date,estimator_note,estimator_note_pending,priority from dbo.enquiry_log " +
                "left join dbo.enquiry_status es on es.id = enquiry_log.status_id left join[user_info].dbo.[user] u_estimator on u_estimator.id = enquiry_log.allocated_to_id " +
                "left join[user_info].dbo.[user] u_cad on u_cad.id = enquiry_log.allocated_to_cad_id left join[user_info].dbo.[user] u_checked on u_checked.id = enquiry_log.checked_by_id " +
                "left join[user_info].dbo.[user] u_processed on u_processed.id = enquiry_log.processed_by_id left join[user_info].dbo.[user] u_processed_cad on u_processed_cad.id = enquiry_log.processed_cad_by_id " +
                "left join[user_info].dbo.[user] u_complete on u_complete.id = enquiry_log.complete_by_id " +
                "where enquiry_log.id =" + _enquiryID;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //use this dt to fill out all the  boxes
                    txtID.Text = dt.Rows[0][0].ToString();
                    txtRecieved.Text = dt.Rows[0][1].ToString();
                    txtSentBy.Text = dt.Rows[0][2].ToString();
                    //change sent by if its an internal email 
                    if (txtSentBy.Text.Contains("EXCHANGELABS/OU=EXCHANGE"))
                    {
                        //remove all the clutter
                        string temp = txtSentBy.Text;
                        txtSentBy.Text = temp.Substring(temp.IndexOf("-") + 1);
                    }

                    cmbStatus.Text = dt.Rows[0][3].ToString();
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkPriority.Checked = true;
                    else
                        chkPriority.Checked = false;
                    txtQuotesRequired.Text = dt.Rows[0][5].ToString();
                    if (dt.Rows[0][6].ToString() == "-1")
                        chkRevisionRequest.Checked = true;
                    else
                        chkRevisionRequest.Checked = false;
                    if (dt.Rows[0][7].ToString() == "-1")
                        chkSlimline.Checked = true;
                    else
                        chkSlimline.Checked = false;
                    if (dt.Rows[0][8].ToString() == "-1")
                        chkAluminium.Checked = true;
                    else
                        chkAluminium.Checked = false;
                    if (dt.Rows[0][9].ToString() == "-1")
                        chkTechnical.Checked = true;
                    else
                        chkAluminium.Checked = false;
                    cmbAllocatedTo.Text = dt.Rows[0][10].ToString();
                    txtCadDrawingsRequired.Text = dt.Rows[0][11].ToString();
                    if (dt.Rows[0][12].ToString() == "-1")
                        chkRevisionRequestCad.Checked = true;
                    else
                        chkRevisionRequestCad.Checked = false;
                    cmbAllocatedToCAD.Text = dt.Rows[0][13].ToString();
                    if (dt.Rows[0][14].ToString() == "-1")
                        chkAsBuilt.Checked = true;
                    else
                        chkAsBuilt.Checked = false;
                    if (dt.Rows[0][15].ToString() == "-1")
                        chkFromScratch.Checked = true;
                    else
                        chkFromScratch.Checked = false;
                    if (dt.Rows[0][16].ToString() == "-1")
                        chkOnHold.Checked = true;
                    else
                        chkOnHold.Checked = false;
                    if (dt.Rows[0][17].ToString() == "-1")
                        chkDetailed.Checked = true;
                    else
                        chkDetailed.Checked = false;
                    richOnHoldNote.Text = dt.Rows[0][18].ToString();
                    txtChecking.Text = dt.Rows[0][19].ToString();
                    txtProcessingQuote.Text = dt.Rows[0][20].ToString();
                    txtProcessingCAD.Text = dt.Rows[0][21].ToString();
                    txtComplete.Text = dt.Rows[0][22].ToString();
                    richEnquiryNotes.Text = dt.Rows[0][23].ToString();
                    richCadNote.Text = dt.Rows[0][24].ToString();
                    webBrowser1.DocumentText = dt.Rows[0][25].ToString();
                    htmlstring = dt.Rows[0][25].ToString();
                    if (String.IsNullOrEmpty(dt.Rows[0][26].ToString()))
                    {
                        dteTenderDueDate.CustomFormat = " "; //'An empty SPACE
                        dteTenderDueDate.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dteTenderDueDate.Value = Convert.ToDateTime(dt.Rows[0][26].ToString());
                    }
                    txtEstimatorNote.Text = dt.Rows[0][27].ToString();
                    if (dt.Rows[0][28].ToString() == "-1")
                        chkResolved.Checked = true;
                    else
                        chkResolved.Checked = false;
                    cmbABC.Text = dt.Rows[0][29].ToString();
                }
                //load the allocated to comboboxes
                sql = "select forename + ' ' + surname from [user_info].dbo.[user] where [grouping] = 5 and [current] = 1 and (non_user = 0 or non_user is null) order by forename asc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        cmbAllocatedTo.Items.Add(row[0].ToString());
                }
                sql = "select forename + ' ' + surname from [user_info].dbo.[user] where(actual_department = 'drawing' or allocation_dept_2 = 'drawing' or allocation_dept_3 = 'drawing' or allocation_dept_4 = 'drawing' " +
                    "or allocation_dept_5 = 'drawing' or allocation_dept_6 = 'drawing') and[current] = 1 order by forename asc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        cmbAllocatedToCAD.Items.Add(row[0].ToString());
                }
                //load the attachements
                sql = "SELECT full_file_path  as [File Location] FROM dbo.attachment_log WHERE email_id = " + _enquiryID.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttachments.DataSource = dt;
                }
                dgvAttachments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                conn.Close();
            }
            skipUpdate = 0;
        }

        private void dgvAttachments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (File.Exists(dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    Process.Start("explorer.exe", dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else
                    MessageBox.Show("The file you are trying to open cannot be located. It is very likely it has been deleted or renamed.", "Unreachable file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }
        }
        private void filterAttachments()
        {
            //here we compare every file attached with the html string and if there is a match then we will remove it from the dgv
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAttachments.DataSource];
            currencyManager1.SuspendBinding();
            //first up we need to strip out the extension and everything before the [number]_
            int count = 0;
            for (int i = 0; i < dgvAttachments.Rows.Count; i++)
            {
                string attachment_name = dgvAttachments.Rows[i].Cells[0].Value.ToString();
                attachment_name = System.IO.Path.ChangeExtension(attachment_name, null);
                string enquiry_and_item_string = _enquiryID.ToString() + "_" + count.ToString() + "_";
                //attachment_name = attachment_name.Substring(0, attachment_name.Length - 4); //this is the code that remove the file type + the . (but there could be more than 3 letters on the file type AND in some cases there can be no extension
                attachment_name = attachment_name.Substring(attachment_name.IndexOf(enquiry_and_item_string) + enquiry_and_item_string.Length);
                //MessageBox.Show(attachment_name);

                //check if attachment_name exists in the html 
                if (htmlstring.Contains(attachment_name))
                    dgvAttachments.Rows[i].Visible = false;

                count++;
            }
            currencyManager1.ResumeBinding();

            foreach (DataGridViewColumn col in dgvAttachments.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void frmEnquiryDetails_Shown(object sender, EventArgs e)
        {
            //  filterAttachments();
        }
        private void updateDetails(string sql)
        {
            if (skipUpdate != -1)
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the new status 
            string sql = "SELECT id FROM dbo.enquiry_status WHERE description = '" + cmbStatus.Text + "'";
            int new_status = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    new_status = (int)cmd.ExecuteScalar();
                    conn.Close();
                }
            }
            sql = "UPDATE dbo.enquiry_log SET status_id = " + new_status.ToString() + " WHERE id = " + _enquiryID.ToString();
            updateDetails(sql);

            //print the enquiry - taken out as request of nick 09/08/2022
            //if (chkSlimline.Checked == false)
            //{
            //    if (cmbStatus.Text == "Checked")
            //    {
            //        if (skipFirstPrint == 0)
            //        {
            //            //
            //            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //            {
            //                conn.Open();
            //                using (SqlCommand cmd = new SqlCommand("usp_shuffle_load_individual", conn))
            //                {
            //                    cmd.CommandType = CommandType.StoredProcedure;
            //                    cmd.Parameters.AddWithValue("@enquiry_id", SqlDbType.Int).Value = Convert.ToInt32(txtID.Text);
            //                    cmd.ExecuteNonQuery();
            //                    //refresh all of the boxes (even tho the only one updating should be the allocated to combobox
            //                    refreshData();
            //                }
            //                conn.Close();
            //            }
            //            print();
            //        }
            //    }
            //}
        }

        private void print()
        {
            MessageBox.Show("Please wait while the Enquiry sheet prints!");
            // Store the Excel processes before opening.
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel.
            string temp = @"\\designsvr1\apps\Design and Supply CSharp\Enquiry_template.xlsx";
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Open(temp);
            var xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
            // Get Excel processes after opening the file.
            Process[] processesAfter = Process.GetProcessesByName("excel");

            xlWorksheet.Cells[2][2].Value2 = txtID.Text;
            xlWorksheet.Cells[2][3].Value2 = txtRecieved.Text; //recieved by
            xlWorksheet.Cells[2][4].Value2 = txtSentBy.Text; //sent by
            xlWorksheet.Cells[2][5].Value2 = txtQuotesRequired.Text; //number of items
            xlWorksheet.Cells[2][6].Value2 = cmbAllocatedTo.Text; //allocated to
            xlWorksheet.Cells[2][7].Value2 = DateTime.Now.ToString(); //printed on 
            xlWorksheet.Cells[1][9].Value2 = richEnquiryNotes.Text; // enquiry notes


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

        private void chkPriority_CheckedChanged(object sender, EventArgs e)
        {
            int priority = 0;
            if (chkPriority.Checked == true)
                priority = -1;
            string sql = "UPDATE dbo.enquiry_log SET priority_job = " + priority.ToString() + " WHERE id = " + _enquiryID.ToString();
            updateDetails(sql);
        }

        private void txtQuotesRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtCadDrawingsRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtQuotesRequired_Leave(object sender, EventArgs e)
        {
            if (txtQuotesRequired.Text.Length < 1)
            {
                MessageBox.Show("Quotes Required must have a quantity!", "Reverting to the old quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuotesRequired.Text = oldQty.ToString();
                return;
            }
            else
            {
                string sql = "UPDATE dbo.enquiry_log SET  price_qty_required = " + txtQuotesRequired.Text + " WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void txtQuotesRequired_Enter(object sender, EventArgs e)
        {
            oldQty = Convert.ToInt32(txtQuotesRequired.Text);
        }

        private void txtQuotesRequired_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuotesRequired.Text.Length < 1)
                {
                    MessageBox.Show("Quotes Required must have a quantity!", "Reverting to the old quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuotesRequired.Text = oldQty.ToString();
                    return;
                }
                string sql = "UPDATE dbo.enquiry_log SET  price_qty_required = " + txtQuotesRequired.Text + " WHERE id = " + _enquiryID;
                updateDetails(sql);

            }
        }

        private void txtCadDrawingsRequired_Enter(object sender, EventArgs e)
        {
            oldQty = Convert.ToInt32(txtCadDrawingsRequired.Text);
        }

        private void txtCadDrawingsRequired_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCadDrawingsRequired.Text.Length < 1)
                {
                    MessageBox.Show("CAD Drawings Required must have a quantity!", "Reverting to the old quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCadDrawingsRequired.Text = oldQty.ToString();
                    return;
                }
                string sql = "UPDATE dbo.enquiry_log SET  drawing_qty_required = " + txtCadDrawingsRequired.Text + " WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void txtCadDrawingsRequired_Leave(object sender, EventArgs e)
        {
            if (txtCadDrawingsRequired.Text.Length < 1)
            {
                MessageBox.Show("CAD Drawings Required must have a quantity!", "Reverting to the old quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCadDrawingsRequired.Text = oldQty.ToString();
                return;
            }
            string sql = "UPDATE dbo.enquiry_log SET  drawing_qty_required = " + txtCadDrawingsRequired.Text + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkRevisionRequest_CheckedChanged(object sender, EventArgs e)
        {
            int revision = 0;
            if (chkRevisionRequest.Checked == true)
                revision = -1;

            string sql = "UPDATE dbo.enquiry_log SET revision = " + revision.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkSlimline_CheckedChanged(object sender, EventArgs e)
        {
            int slimline = 0;
            if (chkSlimline.Checked == true)
                slimline = -1;

            string sql = "UPDATE dbo.enquiry_log SET slimline_request = " + slimline.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkAluminium_CheckedChanged(object sender, EventArgs e)
        {
            int aluminium = 0;
            if (chkAluminium.Checked == true)
                aluminium = -1;

            string sql = "UPDATE dbo.enquiry_log SET is_aluminium = " + aluminium.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkTechnical_CheckedChanged(object sender, EventArgs e)
        {
            int technical = 0;
            if (chkTechnical.Checked == true)
                technical = -1;

            string sql = "UPDATE dbo.enquiry_log SET is_technical = " + technical.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkRevisionRequestCad_CheckedChanged(object sender, EventArgs e)
        {
            int revision = 0;
            if (chkRevisionRequestCad.Checked == true)
                revision = -1;

            string sql = "UPDATE dbo.enquiry_log SET cad_revision = " + revision.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkAsBuilt_CheckedChanged(object sender, EventArgs e)
        {
            int asBuilt = 0;
            if (chkAsBuilt.Checked == true)
                asBuilt = -1;

            string sql = "UPDATE dbo.enquiry_log SET as_built = " + asBuilt.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkFromScratch_CheckedChanged(object sender, EventArgs e)
        {
            int fromScratch = 0;
            if (chkFromScratch.Checked == true)
                fromScratch = -1;

            string sql = "UPDATE dbo.enquiry_log SET from_scratch = " + fromScratch.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkOnHold_CheckedChanged(object sender, EventArgs e)
        {
            int onHold = 0;
            if (chkOnHold.Checked == true)
                onHold = -1;

            string sql = "UPDATE dbo.enquiry_log SET on_hold = " + onHold.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void chkDetailed_CheckedChanged(object sender, EventArgs e)
        {
            int detailed = 0;
            if (chkDetailed.Checked == true)
                detailed = -1;

            string sql = "UPDATE dbo.enquiry_log SET detailed = " + detailed.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void richOnHoldNote_Leave(object sender, EventArgs e)
        {
            richOnHoldNote.Text = richOnHoldNote.Text.Replace("'", "");
            string sql = "UPDATE dbo.enquiry_log SET  on_hold_note = '" + richOnHoldNote.Text + "' WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void richOnHoldNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richOnHoldNote.Text = richOnHoldNote.Text.Replace("'", "");
                string sql = "UPDATE dbo.enquiry_log SET  on_hold_note = '" + richOnHoldNote.Text + "' WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void richEnquiryNotes_Leave(object sender, EventArgs e)
        {
            richEnquiryNotes.Text = richEnquiryNotes.Text.Replace("'", "");
            string sql = "UPDATE dbo.enquiry_log SET  enquiry_notes = '" + richEnquiryNotes.Text + "' WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void richEnquiryNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richEnquiryNotes.Text = richEnquiryNotes.Text.Replace("'", "");
                string sql = "UPDATE dbo.enquiry_log SET  enquiry_notes = '" + richEnquiryNotes.Text + "' WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void richCadNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richCadNote.Text = richCadNote.Text.Replace("'", "");
                string sql = "UPDATE dbo.enquiry_log SET  cad_note = '" + richCadNote.Text + "' WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void richCadNote_Leave(object sender, EventArgs e)
        {
            richCadNote.Text = richCadNote.Text.Replace("'", "");
            string sql = "UPDATE dbo.enquiry_log SET  cad_note = '" + richCadNote.Text + "' WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void cmbAllocatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //need to get the id of the new person!
            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname  = '" + cmbAllocatedTo.Text + "'";
            int id = 260; //default to me incase of an issue?
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
            }
            sql = "UPDATE dbo.enquiry_log SET allocated_to_id = " + id + "  WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void cmbAllocatedToCAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //need to get the id of the new person!
            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname  = '" + cmbAllocatedToCAD.Text + "'";
            int id = 260; //default to me incase of an issue?
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
            }
            sql = "UPDATE dbo.enquiry_log SET allocated_to_cad_id = " + id + "  WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void btnPrintCad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please wait while the CAD sheet prints!");
            string email = "";
            //drawing_qty is on the form
            //cad due date is on the form
            string estimator = "";
            string enquiry_notes = "";
            string date_stamp = "";
            string cadDueDate = "";
            //try
            //{
                //get all the variables for each item on the print out
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    //first up is email
                    string sql = "SELECT sender_email_address FROM dbo.enquiry_log WHERE id = " + txtID.Text;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        email = (string)cmd.ExecuteScalar();
                        if (email.Contains("EXCHANGELABS/OU=EXCHANGE"))
                            email = email.Substring(email.IndexOf("-") + 1);
                    }
                    //currently logged in estimator
                    sql = "select forename + ' ' +surname as fullName from dbo.enquiry_log left join[user_info].dbo.[user] u on u.id = estimator_id where  enquiry_log.id = " + txtID.Text;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        estimator = (string)cmd.ExecuteScalar();
                    //cad_due_date
                    sql = "select cad_due_date from dbo.enquiry_log where id =  " + txtID.Text; //
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DateTime tempDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
                        cadDueDate = tempDateTime.ToLongDateString();
                    }
                    //date stamp
                    sql = "select estimator_cad_click_stamp from dbo.enquiry_log where id =   " + txtID.Text;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DateTime tempDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
                        date_stamp = tempDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    //notes
                    sql = "SELECT enquiry_notes FROM dbo.enquiry_log WHERE id = " + txtID.Text;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        enquiry_notes = (string)cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            //}
            //catch
            //{
            //    MessageBox.Show("There was an error printing this request. Please inform IT!", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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

            xlWorksheet.Cells[2][2].Value2 = txtID.Text;
            xlWorksheet.Cells[2][3].Value2 = email;
            xlWorksheet.Cells[2][4].Value2 = txtCadDrawingsRequired.Text;
            xlWorksheet.Cells[2][5].Value2 = cadDueDate;
            xlWorksheet.Cells[2][6].Value2 = estimator;
            xlWorksheet.Cells[2][7].Value2 = date_stamp;
            xlWorksheet.Cells[1][9].Value2 = enquiry_notes;


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {

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
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintNew frm = new frmPrintNew(Convert.ToInt32(txtID.Text));
            frm.ShowDialog();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                string currentUrl = e.Url.ToString();

                if (currentUrl.Contains("http"))
                {
                    Process.Start(currentUrl);
                    webBrowser1.DocumentText = htmlstring;
                }
            }
            catch { }
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            //if cad compelte dont allow this
            //check if the the entry has already been marked as compelte
            string sql = "";
            int alreadyComplete = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                sql = "SELECT COALESCE(cad_complete,0) FROM dbo.enquiry_log WHERE id = " + _enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var temp = Convert.ToInt32(cmd.ExecuteScalar());
                    if (temp != null)
                        alreadyComplete = temp;
                }
                conn.Close();
            }
            if (alreadyComplete == -1)
            {
                MessageBox.Show("This job is already marked as complete in CAD.", "Action Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmAllocateCad frm = new frmAllocateCad();
            frm.ShowDialog();
            //CONNECT.cadAllocationPath
            // 1 = choose allocation
            int id = 0;
            if (CONNECT.cadAllocationPath == 1)
            {
                //someone is selected
                sql = "UPDATE dbo.enquiry_log SET  allocated_to_cad_id = " + CONNECT.cadAllocationStaffPicked + ", processed_cad_by_id = " + CONNECT.staffID + ", processed_cad_date = GETDATE() WHERE id = " + _enquiryID;
                id = CONNECT.cadAllocationStaffPicked;
            }
            //2 = current login 
            else if (CONNECT.cadAllocationPath == 2)
            {
                //its the current user
                sql = "UPDATE dbo.enquiry_log SET  allocated_to_cad_id = " + CONNECT.staffID + ", processed_cad_by_id = " + CONNECT.staffID + ", processed_cad_date = GETDATE() WHERE id = " + _enquiryID;
                id = CONNECT.staffID;
            }
            //3 cancel
            else
            {
                MessageBox.Show("Process action cancelled.", "Aborted.", MessageBoxButtons.OK);
                return;
            }
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();


                //get the NEW allocated_to_cad_id AND then 
                sql = "select u.forename + ' ' + u.surname from [EnquiryLog].dbo.[enquiry_log] LEFT JOIN[user_info].dbo.[user] u on u.id = allocated_to_cad_id where[EnquiryLog].dbo.[enquiry_log].id = " + _enquiryID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmbAllocatedToCAD.Text = cmd.ExecuteScalar().ToString();

                conn.Close();
            }
        }

        private void btnCadComplete_Click(object sender, EventArgs e)
        {
            string sql = "";

            DialogResult compResult = MessageBox.Show("Mark this job as 'Complete'?", "Complete / Hold", MessageBoxButtons.YesNo);
            if (compResult == DialogResult.Yes)
            {
                //put it on comp
                sql = "UPDATE dbo.enquiry_log SET cad_complete = -1, complete_cad_date = GETDATE() WHERE id = " + _enquiryID;
            }
            else
            {
                DialogResult holdResult = MessageBox.Show("Mark this job as 'On Hold'?", "Complete / Hold", MessageBoxButtons.YesNo);
                if (holdResult == DialogResult.Yes)
                {
                    //put it on hold
                    frmCadHoldNote frm = new frmCadHoldNote();
                    frm.ShowDialog();
                    //get a note from the user
                    if (CONNECT.cadOnHoldNote == "*cancel clicked*")
                    {
                        MessageBox.Show("Action Cancelled.", "Aborted", MessageBoxButtons.OK);
                        return;
                    }
                    sql = "UPDATE dbo.enquiry_log SET on_hold_note = '" + CONNECT.cadOnHoldNote + "', on_hold = -1 WHERE id = " + _enquiryID;
                }
                else
                {
                    MessageBox.Show("Action Cancelled.", "Aborted", MessageBoxButtons.OK);
                    return;
                }
            }
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void frmEnquiryDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            webBrowser1.Focus();
        }

        private void dteTenderDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dteTenderDueDate_CloseUp(object sender, EventArgs e)
        {
            dteTenderDueDate.Format = DateTimePickerFormat.Short;
            string sql = "UPDATE dbo.enquiry_log SET  tender_due_date = '" + dteTenderDueDate.Value.ToString("yyyyMMdd") + "' WHERE id = " + _enquiryID;
            updateDetails(sql);

        }

        private void txtEstimatorNote_Leave(object sender, EventArgs e)
        {
            string sql = "UPDATE dbo.enquiry_log SET  estimator_note = '" + txtEstimatorNote.Text + "',estimator_note_pending = -1 WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void txtEstimatorNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "UPDATE dbo.enquiry_log SET  estimator_note = '" + txtEstimatorNote.Text + "',estimator_note_pending = -1 WHERE id = " + _enquiryID;
                updateDetails(sql);
            }
        }

        private void chkResolved_CheckedChanged(object sender, EventArgs e)
        {
            int resolved = 0;
            if (chkResolved.Checked == true)
                resolved = -1;

            string sql = "UPDATE dbo.enquiry_log SET estimator_note_pending = " + resolved.ToString() + " WHERE id = " + _enquiryID;
            updateDetails(sql);
        }

        private void cmbABC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "UPDATE dbo.enquiry_log SET priority = '" + cmbABC.Text.ToString() + "' WHERE id = " + _enquiryID.ToString();
            updateDetails(sql);
        }
    }
}
