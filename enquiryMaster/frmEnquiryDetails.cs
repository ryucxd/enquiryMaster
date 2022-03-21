﻿using System;
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

namespace enquiryMaster
{
    public partial class frmEnquiryDetails : Form
    {
        public string htmlstring { get; set; }
        public int _enquiryID { get; set; }
        public int skipUpdate { get; set; }
        public int oldQty { get; set; }
        public frmEnquiryDetails(int enquiryID)
        {
            InitializeComponent();
            this.Text = "Enquiry: " + enquiryID.ToString();
            _enquiryID = enquiryID;
            skipUpdate = -1;

            //get alll the enquiry data

            string sql = "select Enquiry_Log.id,recieved_time,sender_email_address,es.[description] as [status], priority_job,price_qty_required as [quotes_required],revision,slimline_request,is_aluminium,is_technical," + //is technical is 9
                "u_estimator.forename + ' ' + u_estimator.surname as [allocated_to_estimator],drawing_qty_required,cad_revision,u_cad.forename + ' ' + u_cad.surname as [allocated_to_cad],as_built,from_scratch,on_hold,detailed,on_hold_note," + // on hold note is 18
                "u_checked.forename + ' ' + u_checked.surname + ' - ' + CAST(checked_date as nvarchar(max)) as checked_by," +//checked 19
                " u_processed.forename + ' ' + u_processed.surname + ' - ' + CAST(processed_date as nvarchar(max)) as processed_by, " + //processed by 20
                "u_processed_cad.forename + ' ' + u_processed_cad.surname + ' - ' + CAST(processed_cad_date as nvarchar(max)) as processed_by_cad, " +//processed cad 21
                "u_complete.forename + ' ' + u_complete.surname + ' - ' + CAST(complete_date as nvarchar(max)) as complete_by," + //complete 22
                "enquiry_notes,cad_note,Body from dbo.Enquiry_Log " +
                "left join dbo.enquiry_status es on es.id = enquiry_log.status_id left join[user_info].dbo.[user] u_estimator on u_estimator.id = Enquiry_Log.allocated_to_id " +
                "left join[user_info].dbo.[user] u_cad on u_cad.id = Enquiry_Log.allocated_to_cad_id left join[user_info].dbo.[user] u_checked on u_checked.id = Enquiry_Log.checked_by_id " +
                "left join[user_info].dbo.[user] u_processed on u_processed.id = Enquiry_Log.processed_by_id left join[user_info].dbo.[user] u_processed_cad on u_processed_cad.id = Enquiry_Log.processed_cad_by_id " +
                "left join[user_info].dbo.[user] u_complete on u_complete.id = Enquiry_Log.complete_by_id " +
                "where Enquiry_Log.id =" + enquiryID;

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
                sql = "SELECT full_file_path  as [File Location] FROM dbo.attachment_log WHERE email_id = " + enquiryID.ToString();
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
            filterAttachments();
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
    }
}
