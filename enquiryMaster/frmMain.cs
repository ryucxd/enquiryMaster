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
using DataTable = System.Data.DataTable;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace enquiryMaster
{
    public partial class frmMain : Form
    {
        //session file
        public int rowID { get; set; }
        //dte prompts
        public int dteRecievedStartChange { get; set; }
        public int dteRecievedEndChange { get; set; }
        public int dteStartChange { get; set; }
        public int dteEndChange { get; set; }

        //dgv indexs
        public int idIndex { get; set; }
        public int recievedTimeIndex { get; set; }
        public int senderEmailIndex { get; set; }
        public int subjectIndex { get; set; }
        public int priorityJobIndex { get; set; }
        public int revisionCheckboxIndex { get; set; }
        public int revisionIndex { get; set; }
        public int priceQtyRequiredIndex { get; set; }
        public int statusIndex { get; set; }
        public int allocatedToIndex { get; set; }
        public int processedButtonIndex { get; set; }
        public int cadButtonIndex { get; set; }
        public int onHoldIndex { get; set; }
        public int requiresCadIndex { get; set; }
        public int requiresCadCheckboxIndex { get; set; }
        public int allocatedToCadIndex { get; set; }
        public int processedByCadIndex { get; set; }
        public int cadCompleteIndex { get; set; }
        public int cadCompleteCheckboxIndex { get; set; }
        public int completeDateIndex { get; set; }
        public int completeButton { get; set; }
        public int cancelButtonIndex { get; set; }
        public int tender_index { get; set; }
        public int pending_index { get; set; }
        public int estimator_note_index { get; set; }


        public frmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.windows_log_off;
            this.Text = "Enquiry Log - " + CONNECT.staffFullName;

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //if (CONNECT.openCAD == -1)
            //    btnCAD.Visible = false;
            if (CONNECT.openCAD == -1)
                menuStrip1.Items[2].Visible = false;
            if (CONNECT.isSlimline == -1)
                menuStrip1.Items[3].Visible = false;

            apply_filter();
            colour_grid();
            fillAllocatedTo();



            //release all memory - stop EXCEL.exe from hanging around.
            //if (xlWorkbook != null) { Marshal.ReleaseComObject(xlWorkbook); } //release each workbook like this
            //if (xlWorkbooks != null) { Marshal.ReleaseComObject(xlWorkbooks); } //release each workbook like this
            //if (xlWorksheet != null) { Marshal.ReleaseComObject(xlWorksheet); } //release each worksheet like this
            //if (xlApp != null) { Marshal.ReleaseComObject(xlApp); } //release the Excel application
            //xlWorkbook = null; //set each memory reference to null.
            //xlWorkbooks = null;
            //xlWorksheet = null;
            //xlApp = null;
            //GC.Collect();
        }
        private void fillAllocatedTo()
        {
            //loop through dgv get alll the unique entries for allocated to
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                if (cmbAllocatedTo.Items.Contains(row.Cells[allocatedToIndex].Value.ToString()))
                { } //nothing
                else
                    cmbAllocatedTo.Items.Add(row.Cells[allocatedToIndex].Value.ToString());
                if (cmbAllocatedToCad.Items.Contains(row.Cells[allocatedToCadIndex].Value.ToString()))
                { } //nothing
                else
                    cmbAllocatedToCad.Items.Add(row.Cells[allocatedToCadIndex].Value.ToString());
                //
            }
        }

        private void apply_filter()
        {
            dgvEnquiryLog.DataSource = null;
            dgvEnquiryLog.Rows.Clear();
            dgvEnquiryLog.Columns.Clear();

            //get the main datagridview filtered (and apply any colourts etc
            string sql = "SET DATEFORMAT dmy;SELECT TOP 300 enquiry_log.id,recieved_time,sender_email_address,[subject],priority_job,revision,price_qty_required,es.[description] as [status],u_estimator.forename + ' ' + u_estimator.surname as allocated_to," +
                "'' as Process,'' as CAD,on_hold,requires_cad,u_cad.forename + ' ' + u_cad.surname as allocate_to_CAD,processed_cad_by_id,cad_complete,complete_date,tender_due_date,estimator_note_pending FROM dbo.enquiry_log WITH(NOLOCK) " +
                "LEFT JOIN[user_info].dbo.[user] u_estimator on u_estimator.id = Enquiry_Log.allocated_to_id " +
                "LEFT JOIN[user_info].dbo.[user] u_cad on u_cad.id = Enquiry_Log.allocated_to_cad_id " +
                "LEFT JOIN enquiry_status es on es.id = Enquiry_Log.status_id " +
                "WHERE (slimline_request = 0 or slimline_request is null)   AND ";

            //filter based on user inputs
            if (txtID.TextLength > 0)
                sql = sql + " enquiry_log.id like '%" + txtID.Text + "%'  AND ";
            if (dteRecievedStartChange == -1)
                sql = sql + "recieved_time >= '" + dteRecievedStart.Value.ToString("yyyyMMdd") + "'  AND ";
            if (dteRecievedEndChange == -1)
                sql = sql + "recieved_time <= '" + dteRecievedEnd.Value.ToString("yyyyMMdd") + "'  AND ";
            if (txtSenderEmail.TextLength > 0)
                sql = sql + "sender_email_address like '%" + txtSenderEmail.Text + "%'  AND ";
            if (txtEmailSubject.TextLength > 0)
                sql = sql + "[subject] LIKE '%" + txtEmailSubject.Text + "%'  AND  ";
            if (cmbStatus.Text.Length > 0)
                sql = sql + "es.[description] = '" + cmbStatus.Text + "'  AND  ";
            if (cmbAllocatedTo.Text.Length > 0)
                sql = sql + " u_estimator.forename + ' ' + u_estimator.surname = '" + cmbAllocatedTo.Text + "'  AND  ";
            if (cmbAllocatedToCad.Text.Length > 0)
                sql = sql + " u_cad.forename + ' ' + u_cad.surname  = '" + cmbAllocatedToCad.Text + "'  AND  ";
            if (cmbCadStatus.Text == "Outstanding")
                sql = sql + "requires_cad = -1 AND cad_complete is null AND (on_hold = 0 OR on_hold is null)    AND ";
            if (cmbCadStatus.Text == "On Hold")
                sql = sql + "requires_cad = -1 AND  cad_complete is null AND on_hold = -1   AND ";
            if (cmbCadStatus.Text == "CAD Complete")
                sql = sql + "cad_complete = -1    AND ";
            if (dteStartChange == -1)
                sql = sql + "cast(complete_date as date) >= '" + dteStart.Value.ToString("yyyyMMdd") + "'  AND ";
            if (dteEndChange == -1)
                sql = sql + "cast(complete_date as date) <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'  AND ";
            if (chkOutstanding.Checked == true)
                sql = sql + "  (enquiry_log.status_id = 1 or enquiry_log.status_id = 2 or enquiry_log.status_id = 3)   AND ";


            sql = sql.Substring(0, sql.Length - 5);
            sql = sql + "ORDER BY id desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEnquiryLog.DataSource = dt;
                }

                //fill the other two datagrids (estimator/cad load)
                sql = "SELECT u.forename + ' ' + u.surname as Estimator,item_count as [Item Load] FROM[EnquiryLog].[dbo].[view_grouped_item_count] " +
                    "LEFT JOIN[user_info].dbo.[user] u on [view_grouped_item_count].allocated_to_id = u.id   WHERE allocated_to_id is not null";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEstimator.DataSource = dt;
                }
                sql = "SELECT u.forename + ' ' + u.surname as Engineer,item_count as [Item Load] FROM [EnquiryLog].[dbo].[view_grouped_item_count_cad]" +
                    "  LEFT JOIN[user_info].dbo.[user] u on [view_grouped_item_count_cad].allocated_to_cad_id = u.id   WHERE allocated_to_cad_id is not null";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCAD.DataSource = dt;
                }

                column_index_refresh();
                //add buttons
                addbuttons();
                column_index_refresh(); //< get the new columns
                check_dgv_checkbox();
                format();
                colour_grid();
                //foreach (DataGridViewColumn col in dgvEnquiryLog.Columns)
                //    MessageBox.Show(col.ToString());
                conn.Close();
                if (rowID != 0)
                {
                    try
                    {
                        dgvEnquiryLog.FirstDisplayedScrollingRowIndex = rowID;
                        rowID = 0;
                    }
                    catch
                    {
                        rowID = 0;
                    }
                }
                dgvCAD.ClearSelection();
                dgvEstimator.ClearSelection();
                dgvEnquiryLog.ClearSelection();
            }
        }
        private void check_dgv_checkbox()
        {
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                if (row.Cells[revisionIndex].Value.ToString() == "-1")
                {
                    row.Cells[revisionCheckboxIndex].Value = "true";
                }
                if (row.Cells[requiresCadIndex].Value.ToString() == "-1")
                {
                    row.Cells[requiresCadCheckboxIndex].Value = "true";
                }
                if (row.Cells[cadCompleteIndex].Value.ToString() == "-1")
                {
                    row.Cells[cadCompleteCheckboxIndex].Value = "true";
                }
            }
        }
        private void addbuttons()
        {
            int columnIndex = 0;
            if (dgvEnquiryLog.Columns.Contains("Process") == true)
            {
                dgvEnquiryLog.Columns.Remove("Process");
            }
            if (dgvEnquiryLog.Columns.Contains("CAD") == true)
            {
                dgvEnquiryLog.Columns.Remove("CAD");
            }
            if (dgvEnquiryLog.Columns.Contains("Complete") == true)
            {
                dgvEnquiryLog.Columns.Remove("Complete");
            }
            if (dgvEnquiryLog.Columns.Contains("Cancel") == true)
            {
                dgvEnquiryLog.Columns.Remove("Cancel");
            }

            columnIndex = allocatedToIndex + 1;
            DataGridViewButtonColumn processedButton = new DataGridViewButtonColumn();
            processedButton.Name = "Process";
            processedButton.Text = "Process";
            processedButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["Process_column"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, processedButton);
            }
            columnIndex = allocatedToIndex + 2;
            DataGridViewButtonColumn cadButton = new DataGridViewButtonColumn();
            cadButton.Name = "CAD";
            cadButton.Text = "CAD";
            cadButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["CAD_column"] == null)
            { dgvEnquiryLog.Columns.Insert(columnIndex, cadButton); }

            columnIndex = completeDateIndex + 1;
            DataGridViewButtonColumn completeButton = new DataGridViewButtonColumn();
            completeButton.Name = "Complete";
            completeButton.Text = "Complete";
            completeButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["Complete"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, completeButton);
            }
            columnIndex = completeDateIndex + 2;
            DataGridViewButtonColumn cancelButton = new DataGridViewButtonColumn();
            cancelButton.Name = "Cancel";
            cancelButton.Text = "Cancel";
            cancelButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["Cancel"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, cancelButton);
            }
            if (dgvEnquiryLog.Columns["Cancel"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, cancelButton);
            }

            //add checkboxes for revision/requires cad/complete cad
            DataGridViewCheckBoxColumn revisionCheckBox = new DataGridViewCheckBoxColumn();
            revisionCheckBox.HeaderText = "revision_checkbox";
            revisionCheckBox.Name = "revision_checkbox";
            dgvEnquiryLog.Columns.Insert(revisionIndex, revisionCheckBox);

            column_index_refresh();

            DataGridViewCheckBoxColumn requiresCadCheckbox = new DataGridViewCheckBoxColumn();
            requiresCadCheckbox.HeaderText = "requires_cad_checkbox";
            requiresCadCheckbox.Name = "requires_cad_checkbox";
            dgvEnquiryLog.Columns.Insert(requiresCadIndex, requiresCadCheckbox);

            column_index_refresh();

            DataGridViewCheckBoxColumn cadCompleteCheckbox = new DataGridViewCheckBoxColumn();
            cadCompleteCheckbox.HeaderText = "cad_complete_checkbox";
            cadCompleteCheckbox.Name = "cad_complete_checkbox";
            dgvEnquiryLog.Columns.Insert(cadCompleteIndex, cadCompleteCheckbox);
        }
        private void column_index_refresh()
        {
            idIndex = dgvEnquiryLog.Columns["id"].Index;
            recievedTimeIndex = dgvEnquiryLog.Columns["recieved_time"].Index;
            senderEmailIndex = dgvEnquiryLog.Columns["sender_email_address"].Index;
            subjectIndex = dgvEnquiryLog.Columns["subject"].Index;
            priorityJobIndex = dgvEnquiryLog.Columns["priority_job"].Index;
            //checkbox for revision
            if (dgvEnquiryLog.Columns.Contains("revision_checkbox") == true)
                revisionCheckboxIndex = dgvEnquiryLog.Columns["revision_checkbox"].Index;
            revisionIndex = dgvEnquiryLog.Columns["revision"].Index;

            priceQtyRequiredIndex = dgvEnquiryLog.Columns["price_qty_required"].Index;
            statusIndex = dgvEnquiryLog.Columns["status"].Index;
            allocatedToIndex = dgvEnquiryLog.Columns["allocated_to"].Index;
            processedButtonIndex = dgvEnquiryLog.Columns["Process"].Index;
            cadButtonIndex = dgvEnquiryLog.Columns["CAD"].Index;
            onHoldIndex = dgvEnquiryLog.Columns["on_hold"].Index;
            //checkbox for requires CAD
            if (dgvEnquiryLog.Columns.Contains("requires_cad_checkbox") == true)
                requiresCadCheckboxIndex = dgvEnquiryLog.Columns["requires_cad_checkbox"].Index;
            requiresCadIndex = dgvEnquiryLog.Columns["requires_cad"].Index;

            processedByCadIndex = dgvEnquiryLog.Columns["processed_cad_by_id"].Index;
            allocatedToCadIndex = dgvEnquiryLog.Columns["allocate_to_CAD"].Index;
            //checkbox complete CAD
            if (dgvEnquiryLog.Columns.Contains("cad_complete_checkbox") == true)
                cadCompleteCheckboxIndex = dgvEnquiryLog.Columns["cad_complete_checkbox"].Index;
            cadCompleteIndex = dgvEnquiryLog.Columns["cad_complete"].Index;

            completeDateIndex = dgvEnquiryLog.Columns["complete_date"].Index;
            if (dgvEnquiryLog.Columns.Contains("Complete") == true)
                completeButton = dgvEnquiryLog.Columns["Complete"].Index;
            if (dgvEnquiryLog.Columns.Contains("Cancel") == true)
                cancelButtonIndex = dgvEnquiryLog.Columns["Cancel"].Index;
            tender_index = dgvEnquiryLog.Columns["tender_due_date"].Index;
            pending_index = dgvEnquiryLog.Columns["estimator_note_pending"].Index;

        }
        private void format()
        {
            //try going through all the records and changing any 
            // /O=EXCHANGELABS/OU=EXCHANGE ADMINISTRATIVE GROUP (FYDIBOHF23SPDLT)/CN=RECIPIENTS/CN=A09D0E9AB7004714BC4F733514D27285-RHYS
            // to the last few letters
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                if (row.Cells[senderEmailIndex].Value.ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                {
                    //remove all the clutter
                    string temp = row.Cells[senderEmailIndex].Value.ToString();
                    row.Cells[senderEmailIndex].Value = temp.Substring(temp.IndexOf("-") + 1);
                }
            }


            dgvEnquiryLog.Columns[idIndex].HeaderText = "ID";
            dgvEnquiryLog.Columns[recievedTimeIndex].HeaderText = "Recieved";
            dgvEnquiryLog.Columns[senderEmailIndex].HeaderText = "Sender Email";
            dgvEnquiryLog.Columns[subjectIndex].HeaderText = "Email Subject";
            dgvEnquiryLog.Columns[priorityJobIndex].HeaderText = "is Priority";
            dgvEnquiryLog.Columns[revisionCheckboxIndex].HeaderText = "is Revision";
            dgvEnquiryLog.Columns[priceQtyRequiredIndex].HeaderText = "Item QTY";
            dgvEnquiryLog.Columns[statusIndex].HeaderText = "Enquiry Status";
            dgvEnquiryLog.Columns[allocatedToIndex].HeaderText = "Allocated to";
            dgvEnquiryLog.Columns[onHoldIndex].HeaderText = "on Hold";
            dgvEnquiryLog.Columns[requiresCadCheckboxIndex].HeaderText = "Requires CAD";
            dgvEnquiryLog.Columns[allocatedToCadIndex].HeaderText = "Allocated to CAD";
            dgvEnquiryLog.Columns[cadCompleteCheckboxIndex].HeaderText = "CAD Complete";
            dgvEnquiryLog.Columns[completeDateIndex].HeaderText = "Date Complete";

            try
            {
                //estimator
                dgvEstimator.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvEstimator.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //cad
                dgvCAD.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCAD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
            //hide the checkbox data columns
            dgvEnquiryLog.Columns[revisionIndex].Visible = false;
            dgvEnquiryLog.Columns[requiresCadIndex].Visible = false;
            dgvEnquiryLog.Columns[cadCompleteIndex].Visible = false;
            dgvEnquiryLog.Columns[processedByCadIndex].Visible = false;

            //hide the other data columns (onhold/prio)
            dgvEnquiryLog.Columns[priorityJobIndex].Visible = false;
            dgvEnquiryLog.Columns[onHoldIndex].Visible = false;
            dgvEnquiryLog.Columns[tender_index].Visible = false;
            dgvEnquiryLog.Columns[pending_index].Visible = false;

            foreach (DataGridViewColumn col in dgvEnquiryLog.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvEnquiryLog.Columns[senderEmailIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEnquiryLog.Columns[senderEmailIndex].Width = 300;
            dgvEnquiryLog.Columns[subjectIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvEnquiryLog.Columns[subjectIndex].Width = 300;

            //stop auto filtering of columns
            foreach (DataGridViewColumn col in dgvEnquiryLog.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.ReadOnly = true;
            }
            foreach (DataGridViewColumn col in dgvCAD.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn col in dgvEstimator.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }
        private void colour_grid()
        {
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                //complete
                if (row.Cells[statusIndex].Value.ToString() == "Complete")
                {
                    row.Cells[idIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[subjectIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[statusIndex].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.MediumAquamarine;
                }
                //checked
                if (row.Cells[statusIndex].Value.ToString() == "Checked")
                {
                    row.Cells[idIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[subjectIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[statusIndex].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.PaleVioletRed;
                }
                //processing
                if (row.Cells[statusIndex].Value.ToString() == "Processing")
                {
                    row.Cells[idIndex].Style.BackColor = Color.Gold;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.Gold;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.Gold;
                    row.Cells[subjectIndex].Style.BackColor = Color.Gold;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.Gold;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.Gold;
                    row.Cells[statusIndex].Style.BackColor = Color.Gold;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.Gold;
                }
                //on hold
                if (row.Cells[onHoldIndex].Value.ToString() == "-1")
                {
                    row.Cells[idIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[subjectIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[statusIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.LightSkyBlue;

                }
                //CAD COLOURS 
                if (row.Cells[allocatedToCadIndex].Value.ToString().Length > 0) //red by default (if theres a job assigned)
                    row.Cells[allocatedToCadIndex].Style.BackColor = Color.PaleVioletRed;
                if (row.Cells[processedByCadIndex].Value.ToString().Length > 0) //not null
                    row.Cells[allocatedToCadIndex].Style.BackColor = Color.Gold;
                if (row.Cells[cadCompleteIndex].Value.ToString() == "-1")
                    row.Cells[allocatedToCadIndex].Style.BackColor = Color.MediumAquamarine;
                if (row.Cells[onHoldIndex].Value.ToString() == "-1")
                    row.Cells[allocatedToCadIndex].Style.BackColor = Color.LightSkyBlue;

                if (row.Cells[tender_index].Value.ToString().Length > 0)
                {
                    row.Cells[idIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[subjectIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.Gainsboro;
                    //row.Cells[statusIndex].Style.BackColor = Color.Gainsboro;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.Gainsboro;
                }
                if (row.Cells[pending_index].Value.ToString() == "-1")
                {
                    row.Cells[idIndex].Style.BackColor = Color.Salmon;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.Salmon;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.Salmon;
                    row.Cells[subjectIndex].Style.BackColor = Color.Salmon;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.Salmon;
                    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.Salmon;
                    row.Cells[statusIndex].Style.BackColor = Color.Salmon;
                    row.Cells[allocatedToIndex].Style.BackColor = Color.Salmon;
                }

            }
        }



        private void dteRecievedStart_ValueChanged(object sender, EventArgs e)
        {
            dteRecievedStartChange = -1;
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void dteRecievedEnd_ValueChanged(object sender, EventArgs e)
        {
            dteRecievedEndChange = -1;
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void cmbAllocatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void cmbAllocatedToCad_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void cmbCadStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            dteStartChange = -1;
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            dteEndChange = -1;
            apply_filter();
            dgvEnquiryLog.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            dteRecievedStartChange = 0;
            dteRecievedEndChange = 0;
            txtEmailSubject.Text = "";
            txtSenderEmail.Text = "";
            cmbStatus.Text = "";
            cmbAllocatedTo.Text = "";
            cmbAllocatedToCad.Text = "";
            cmbStatus.Text = "";
            dteStartChange = 0;
            dteEndChange = 0;
            chkOutstanding.Checked = false;
            apply_filter();

        }


        private void chkOutstanding_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
            dgvEnquiryLog.Focus();
        }



        private void dgvEnquiryLog_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sql = "";
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == idIndex || e.ColumnIndex == recievedTimeIndex || e.ColumnIndex == senderEmailIndex || e.ColumnIndex == subjectIndex)
            {
                frmEnquiryDetails frm = new frmEnquiryDetails(Convert.ToInt32(dgvEnquiryLog.Rows[e.RowIndex].Cells[0].Value.ToString()));
                frm.ShowDialog();
                rowID = e.RowIndex;
                apply_filter();
            } //opens enquiry details
            if (e.ColumnIndex == processedButtonIndex)
            {
                //has to be status_id = 2 to continue down this route
                if (dgvEnquiryLog.Rows[e.RowIndex].Cells[statusIndex].Value.ToString() != "Checked")
                {
                    MessageBox.Show("This enquiry is currently marked as '" + dgvEnquiryLog.Rows[e.RowIndex].Cells[statusIndex].Value.ToString() + "', Processing will only work on enquiries marked as 'Checked'.", "Processing Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = "", subject = "";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    sql = "select  sender_email_address,[subject] from dbo.Enquiry_Log where id = " + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        email = dt.Rows[0][0].ToString();
                        subject = dt.Rows[0][1].ToString();
                    }
                    sql = "select  cast(id as nvarchar(max)) from dbo.Enquiry_Log where  sender_email_address = '" + email + "' and [subject] = '" + subject + "' and id >" + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 1)
                        {

                            frmMessagebox frm = new frmMessagebox(Convert.ToInt32(dt.Rows[0][0].ToString()));
                            frm.ShowDialog();

                        }
                    }
                    conn.Close();
                }


                //check if the person whos logged in has this job allocated to them  -- this is now turned off though
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    sql = "SELECT allocated_to_id FROM dbo.enquiry_log WHERE id = " + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var data = cmd.ExecuteScalar().ToString();
                        if (data != null)
                        {
                            //if (Convert.ToInt32(data) != CONNECT.staffID)
                            //{
                            //    ////prompt the user to confirm
                            //    //frmConfirmBox frm = new frmConfirmBox();
                            //    //frm.ShowDialog();
                            //    //if (CONNECT.confirmCorrect == false)
                            //    //return;
                            //}
                            //update the entry
                            sql = "UPDATE dbo.enquiry_log SET allocated_to_id = " + CONNECT.staffID + ",status_id = 3,processed_by_id = " + CONNECT.staffID + ",processed_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id = " + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                            using (SqlCommand cmdUpdate = new SqlCommand(sql, conn))
                            {
                                cmdUpdate.ExecuteNonQuery();
                                rowID = e.RowIndex;
                                apply_filter();
                            } //thi

                        }
                    }
                    conn.Close();
                }
            } //processing button
            if (e.ColumnIndex == cadButtonIndex)
            {
                frmCadRequest frm = new frmCadRequest(Convert.ToInt32(dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString()), CONNECT.staffID);
                frm.ShowDialog();
                if (CONNECT.skipShuffle == false)
                {
                    rowID = e.RowIndex;
                    //menuStrip1.Items[1].PerformClick();
                    apply_filter();
                }
                else
                    CONNECT.skipShuffle = false;

            }//cad button
            if (e.ColumnIndex == completeButton)
            {
                //needs to be status id 3 only 
                if (dgvEnquiryLog.Rows[e.RowIndex].Cells[statusIndex].Value.ToString() != "Processing")
                {
                    MessageBox.Show("This enquiry is currently marked as '" + dgvEnquiryLog.Rows[e.RowIndex].Cells[statusIndex].Value.ToString() + "', Complete will only work on enquiries marked as 'Processing'.", "Compelte Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    //check if there is a quote (and rev num) assigned to this 

                    sql = "SELECT related_quote FROM dbo.enquiry_log WHERE id = " + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string data = (string)cmd.ExecuteScalar().ToString();
                        if (String.IsNullOrEmpty(data))
                        {
                            //prompt user for the related quote 
                            frmRelatedQuote frm = new frmRelatedQuote(Convert.ToInt32(dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString()));
                            frm.ShowDialog();

                            if (CONNECT.cancelRelatedQuote == -1)
                            {
                                MessageBox.Show("The related quote was not assigned to this enquiry so it has not been marked as complete.", "Complete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }
                    }


                        //update the columns + then reshuffle
                        //"UPDATE dbo_enquiry_log SET  allocated_to_id = " & TempVars!gl_userid & ", status_id = 4, complete_by_id =" & TempVars!gl_userid & ", complete_date = '" & Now() & "' WHERE id = " & Me.id

                        sql = "UPDATE dbo.enquiry_log SET allocated_to_id = " + CONNECT.staffID.ToString() + ",status_id = 4,complete_by_id = " + CONNECT.staffID + ", complete_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',estimator_note_pending = 0 WHERE id = " + dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value.ToString();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteScalar();
                        rowID = e.RowIndex;
                        //  menuStrip1.Items[1].PerformClick();
                        apply_filter();
                    }
                    conn.Close();
                }
            } //complete button
            if (e.ColumnIndex == cancelButtonIndex)
            {
                frmCancel frm = new frmCancel(Convert.ToInt32(dgvEnquiryLog.Rows[e.RowIndex].Cells[idIndex].Value));
                frm.ShowDialog();
                rowID = e.RowIndex;
                menuStrip1.Items[0].PerformClick();
            } //cancel button
        }

        private void txtSenderEmail_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtSenderEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                apply_filter();
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                apply_filter();
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtEmailSubject_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtEmailSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                apply_filter();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void reshuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ////lock this behind a password
            //frmRefreshPassword frm = new frmRefreshPassword();
            //frm.ShowDialog();
            //if (CONNECT.confirmCorrect == true)
            //{
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_shuffle_load", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            } //this is the 
            CONNECT.confirmCorrect = false;
            apply_filter();
            //}
        }

        private void cADLOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmCAD frm = new frmCAD();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void dgvEnquiryLog_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == idIndex || e.ColumnIndex == recievedTimeIndex || e.ColumnIndex == senderEmailIndex || e.ColumnIndex == subjectIndex)
                dgvEnquiryLog.Cursor = Cursors.Hand;
            else
                dgvEnquiryLog.Cursor = Cursors.Default;
        }

        private void slimlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmSlimline frm = new frmSlimline();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void allocateUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllocateStaff frm = new frmAllocateStaff();
            frm.ShowDialog();
            reshuffleToolStripMenuItem.PerformClick();
        }

        private void aRCHIVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmArchive frm = new frmArchive();
            frm.ShowDialog();
            this.Visible = true;

        }
    }
}
