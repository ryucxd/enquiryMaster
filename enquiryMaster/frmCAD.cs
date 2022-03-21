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
    public partial class frmCAD : Form
    {
        public int idIndex { get; set; }
        public int recievedTimeIndex { get; set; }
        public int senderEmailIndex { get; set; }
        public int subjectIndex { get; set; }
        public int priorityIndex { get; set; }
        public int revisionCheckBoxIndex { get; set; }
        public int revisionIndex { get; set; }
        public int revisionCheckboxIndex { get; set; }
        public int drawingQuantityIndex { get; set; }
        public int cadDueDateIndex { get; set; }
        public int cadButtonIndex { get; set; }
        public int onHoldIndex { get; set; }
        public int allocatedToCadIndex { get; set; }
        public int processButtonIndex { get; set; }
        public int cadCompholdButtonIndex { get; set; }
        public int cadProcessedByIndex { get; set; }
        public int cadCompleteCheckboxIndex { get; set; }
        public int cadCompleteIndex { get; set; }
        public int asBuiltCheckboxIndex { get; set; }
        public int asBuiltIndex { get; set; }
        public int completeDateIndex { get; set; }
        public int estimatorIndex { get; set; }
        public int estimatorClickIndex { get; set; }
        public int rowID { get; set; }
        public frmCAD()
        {
            InitializeComponent();
        }

        private void apply_filter()
        {
            dgvEnquiryLog.DataSource = null;
            dgvEnquiryLog.Rows.Clear();
            dgvEnquiryLog.Columns.Clear();
            string sql = "SELECT top 200 enquiry_log.id,recieved_time,sender_email_address,[subject],priority_job,revision,drawing_qty_required,cad_due_date," +
                "on_hold,cad_u.forename + ' ' + cad_u.surname as allocated_to_cad_id, processed_cad_by_id,cad_complete,as_built,complete_date,estimator_u.forename + ' ' + estimator_u.surname as estimator,estimator_cad_click_stamp " +
                "FROM dbo.Enquiry_Log left join[user_info].dbo.[user] estimator_u on estimator_u.id = estimator_id left join[user_info].dbo.[user] cad_u on cad_u.id = allocated_to_cad_id  WHERE  (slimline_request=0 or slimline_request is null) AND requires_cad = -1     AND ";
            //filter based on user inputs
            if (txtID.TextLength > 0)
                sql = sql + " enquiry_log.id like '%" + txtID.Text + "%'  AND ";
            if (txtSenderEmail.TextLength > 0)
                sql = sql + "sender_email_address like '%" + txtSenderEmail.Text + "%'  AND ";
            if (txtEmailSubject.TextLength > 0)
                sql = sql + "[subject] LIKE '%" + txtEmailSubject.Text + "%'   AND  ";
            if (cmbCadStatus.Text == "Outstanding")
                sql = sql + " cad_complete is null AND (on_hold = 0 OR on_hold is null)    AND ";
            if (cmbCadStatus.Text == "On Hold")
                sql = sql + "  cad_complete is null AND on_hold = -1   AND ";
            if (cmbCadStatus.Text == "CAD Complete")
                sql = sql + "cad_complete = -1    AND ";
            sql = sql.Substring(0, sql.Length - 5);
            sql = sql + " ORDER BY id desc";


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

                sql = "SELECT u.forename + ' ' + u.surname as Engineer,item_count as [Item Load] FROM [EnquiryLog].[dbo].[view_grouped_item_count_cad]" +
                         "  LEFT JOIN[user_info].dbo.[user] u on [view_grouped_item_count_cad].allocated_to_cad_id = u.id   WHERE allocated_to_cad_id is not null";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCAD.DataSource = dt;
                }
                conn.Close();
            }

            column_index_refresh();
            addbuttons();
            column_index_refresh();
            check_checkboxes();

            format();
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
            colour_grid();
            dgvCAD.ClearSelection();
            dgvEnquiryLog.ClearSelection();


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
            dgvEnquiryLog.Columns[priorityIndex].HeaderText = "is Priority";
            dgvEnquiryLog.Columns[revisionCheckboxIndex].HeaderText = "is Revision";
            dgvEnquiryLog.Columns[drawingQuantityIndex].HeaderText = "Drawing QTY";
            dgvEnquiryLog.Columns[cadDueDateIndex].HeaderText = "CAD Due Date";
            dgvEnquiryLog.Columns[allocatedToCadIndex].HeaderText = "Allocated to";
            dgvEnquiryLog.Columns[cadCompleteCheckboxIndex].HeaderText = "CAD Complete";
            dgvEnquiryLog.Columns[asBuiltCheckboxIndex].HeaderText = "As Built";
            dgvEnquiryLog.Columns[completeDateIndex].HeaderText = "Complete Date";
            dgvEnquiryLog.Columns[estimatorIndex].HeaderText = "Estimator";
            dgvEnquiryLog.Columns[estimatorClickIndex].HeaderText = "Requested On";

            try
            {
                //cad
                dgvCAD.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCAD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
            //hide the checkbox data columns
            dgvEnquiryLog.Columns[revisionIndex].Visible = false;
            dgvEnquiryLog.Columns[cadCompleteIndex].Visible = false;
            dgvEnquiryLog.Columns[asBuiltIndex].Visible = false;
            dgvEnquiryLog.Columns[cadProcessedByIndex].Visible = false;

            //hide the other data columns (onhold/prio)
            dgvEnquiryLog.Columns[priorityIndex].Visible = false;
            dgvEnquiryLog.Columns[onHoldIndex].Visible = false;

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


        }

        private void column_index_refresh()
        {
            idIndex = dgvEnquiryLog.Columns["id"].Index;
            recievedTimeIndex = dgvEnquiryLog.Columns["recieved_time"].Index;
            senderEmailIndex = dgvEnquiryLog.Columns["sender_email_address"].Index;
            subjectIndex = dgvEnquiryLog.Columns["subject"].Index;
            priorityIndex = dgvEnquiryLog.Columns["priority_job"].Index;
            //checkbox for revision
            if (dgvEnquiryLog.Columns.Contains("revision_checkbox") == true)
                revisionCheckboxIndex = dgvEnquiryLog.Columns["revision_checkbox"].Index;

            revisionIndex = dgvEnquiryLog.Columns["revision"].Index;
            drawingQuantityIndex = dgvEnquiryLog.Columns["drawing_qty_required"].Index;
            cadDueDateIndex = dgvEnquiryLog.Columns["cad_due_date"].Index;
            onHoldIndex = dgvEnquiryLog.Columns["on_hold"].Index;
            allocatedToCadIndex = dgvEnquiryLog.Columns["allocated_to_cad_id"].Index;
            //buttons
            if (dgvEnquiryLog.Columns.Contains("cad_complete_checkbox") == true)
                cadCompleteCheckboxIndex = dgvEnquiryLog.Columns["cad_complete_checkbox"].Index;
            if (dgvEnquiryLog.Columns.Contains("Process") == true)
                processButtonIndex = dgvEnquiryLog.Columns["Process"].Index;
            if (dgvEnquiryLog.Columns.Contains("CAD Comp/Hold") == true)
                cadCompleteCheckboxIndex = dgvEnquiryLog.Columns["CAD Comp/Hold"].Index;
            //cad comp checkbox
            if (dgvEnquiryLog.Columns.Contains("cad_complete_checkbox") == true)
                cadCompleteCheckboxIndex = dgvEnquiryLog.Columns["cad_complete_checkbox"].Index;

            cadProcessedByIndex = dgvEnquiryLog.Columns["processed_cad_by_id"].Index;
            cadCompleteIndex = dgvEnquiryLog.Columns["cad_complete"].Index;
            //asbuilt checkbox
            if (dgvEnquiryLog.Columns.Contains("as_built_checkbox") == true)
                asBuiltCheckboxIndex = dgvEnquiryLog.Columns["as_built_checkbox"].Index;

            asBuiltIndex = dgvEnquiryLog.Columns["as_built"].Index;
            completeDateIndex = dgvEnquiryLog.Columns["complete_date"].Index;
            estimatorIndex = dgvEnquiryLog.Columns["estimator"].Index;
            estimatorClickIndex = dgvEnquiryLog.Columns["estimator_cad_click_stamp"].Index;




        }

        private void addbuttons()
        {
            int columnIndex = 0;
            if (dgvEnquiryLog.Columns.Contains("CAD") == true)
            {
                dgvEnquiryLog.Columns.Remove("CAD");
            }
            if (dgvEnquiryLog.Columns.Contains("Process") == true)
            {
                dgvEnquiryLog.Columns.Remove("Process");
            }
            if (dgvEnquiryLog.Columns.Contains("CAD Comp/Hold") == true)
            {
                dgvEnquiryLog.Columns.Remove("CAD Comp/Hold");
            }



            column_index_refresh();
            columnIndex = allocatedToCadIndex + 1;
            DataGridViewButtonColumn processButton = new DataGridViewButtonColumn();
            processButton.Name = "Process";
            processButton.Text = "Process";
            processButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["Process"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, processButton);
            }
            columnIndex = allocatedToCadIndex + 2;
            DataGridViewButtonColumn cadCompHoldButton = new DataGridViewButtonColumn();
            cadCompHoldButton.Name = "CAD Comp/Hold";
            cadCompHoldButton.Text = "CAD Comp/Hold";
            cadCompHoldButton.UseColumnTextForButtonValue = true;
            if (dgvEnquiryLog.Columns["CAD Comp/Hold"] == null)
            {
                dgvEnquiryLog.Columns.Insert(columnIndex, cadCompHoldButton);
            }

            //add checkboxes for revision/requires cad/complete cad
            DataGridViewCheckBoxColumn revisionCheckBox = new DataGridViewCheckBoxColumn();
            revisionCheckBox.HeaderText = "revision_checkbox";
            revisionCheckBox.Name = "revision_checkbox";
            dgvEnquiryLog.Columns.Insert(revisionIndex, revisionCheckBox);

            column_index_refresh();

            DataGridViewCheckBoxColumn cadCompleteCheckbox = new DataGridViewCheckBoxColumn();
            cadCompleteCheckbox.HeaderText = "cad_complete_checkbox";
            cadCompleteCheckbox.Name = "cad_complete_checkbox";
            dgvEnquiryLog.Columns.Insert(cadCompleteIndex, cadCompleteCheckbox);

            column_index_refresh();

            DataGridViewCheckBoxColumn asBuiltCheckbox = new DataGridViewCheckBoxColumn();
            asBuiltCheckbox.HeaderText = "as_built_checkbox";
            asBuiltCheckbox.Name = "as_built_checkbox";
            dgvEnquiryLog.Columns.Insert(asBuiltIndex, asBuiltCheckbox);
            column_index_refresh();
        }

        public void check_checkboxes()
        {
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                if (row.Cells[revisionIndex].Value.ToString() == "-1")
                {
                    row.Cells[revisionCheckboxIndex].Value = "true";
                }
                if (row.Cells[cadCompleteIndex].Value.ToString() == "-1")
                {
                    row.Cells[cadCompleteCheckboxIndex].Value = "true";
                }
                if (row.Cells[asBuiltIndex].Value.ToString() == "-1")
                {
                    row.Cells[asBuiltCheckboxIndex].Value = "true";
                }
            }
        }

        private void colour_grid()
        {
            Color redColour = Color.PaleVioletRed;
            Color yellowColour = Color.Gold;
            Color greenColour = Color.MediumAquamarine;

            if (CONNECT.staffID == 241) //adjust colours for the blind boy
            {
                redColour = Color.PaleVioletRed;
                yellowColour = Color.Yellow;
                greenColour = Color.LightSeaGreen;
            }

            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                //unique cad stuff
                if (row.Cells[cadProcessedByIndex].Value.ToString() != "")
                {
                    row.Cells[allocatedToCadIndex].Style.BackColor = yellowColour;
                    row.Cells[cadCompleteCheckboxIndex].Style.BackColor = yellowColour;
                    row.Cells[asBuiltCheckboxIndex].Style.BackColor = yellowColour;
                    row.Cells[completeDateIndex].Style.BackColor = yellowColour;
                    row.Cells[estimatorIndex].Style.BackColor = yellowColour;
                    row.Cells[estimatorClickIndex].Style.BackColor = yellowColour;

                }
                else
                {
                    row.Cells[allocatedToCadIndex].Style.BackColor = redColour;
                    row.Cells[cadCompleteCheckboxIndex].Style.BackColor = redColour;
                    row.Cells[asBuiltCheckboxIndex].Style.BackColor = redColour;
                    row.Cells[completeDateIndex].Style.BackColor = redColour;
                    row.Cells[estimatorIndex].Style.BackColor = redColour;
                    row.Cells[estimatorClickIndex].Style.BackColor = redColour;
                }
                //on hold
                if (row.Cells[onHoldIndex].Value.ToString() == "-1")
                {
                    row.Cells[idIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[recievedTimeIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[senderEmailIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[subjectIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[drawingQuantityIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[cadDueDateIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[allocatedToCadIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[cadCompleteCheckboxIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[asBuiltCheckboxIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[completeDateIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[estimatorIndex].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[estimatorClickIndex].Style.BackColor = Color.LightSkyBlue;

                }//cad complete
                else if (row.Cells[cadCompleteIndex].Value.ToString() == "-1")
                {
                    row.Cells[idIndex].Style.BackColor = greenColour;
                    row.Cells[recievedTimeIndex].Style.BackColor = greenColour;
                    row.Cells[senderEmailIndex].Style.BackColor = greenColour;
                    row.Cells[subjectIndex].Style.BackColor = greenColour;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = greenColour;
                    row.Cells[drawingQuantityIndex].Style.BackColor = greenColour;
                    row.Cells[cadDueDateIndex].Style.BackColor = greenColour;
                    row.Cells[allocatedToCadIndex].Style.BackColor = greenColour;
                    row.Cells[cadCompleteCheckboxIndex].Style.BackColor = greenColour;
                    row.Cells[asBuiltCheckboxIndex].Style.BackColor = greenColour;
                    row.Cells[completeDateIndex].Style.BackColor = greenColour;
                    row.Cells[estimatorIndex].Style.BackColor = greenColour;
                    row.Cells[estimatorClickIndex].Style.BackColor = greenColour;
                }//processing
                else
                {
                    row.Cells[idIndex].Style.BackColor = redColour;
                    row.Cells[recievedTimeIndex].Style.BackColor = redColour;
                    row.Cells[senderEmailIndex].Style.BackColor = redColour;
                    row.Cells[subjectIndex].Style.BackColor = redColour;
                    row.Cells[revisionCheckboxIndex].Style.BackColor = redColour;
                    row.Cells[drawingQuantityIndex].Style.BackColor = redColour;
                    row.Cells[cadDueDateIndex].Style.BackColor = redColour;
                }


                //if CAD COMPLETE DATE  < today

                string temp = row.Cells[cadDueDateIndex].Value.ToString();
                if (temp == "")
                    continue; //this shouldnt happen
                temp = Convert.ToDateTime(temp).ToString("yyyy-MM-dd");
                DateTime cadDueDate = Convert.ToDateTime(temp);

                temp = row.Cells[completeDateIndex].Value.ToString();
                if (temp == "") //is null make cad date today
                    temp = DateTime.Now.ToString("yyyy-MM-dd");
                else
                    temp = Convert.ToDateTime(temp).ToString("yyyy-MM-dd");

                DateTime cadCompleteDate = Convert.ToDateTime(temp);

                if (row.Cells[cadCompleteIndex].Value.ToString() == "-1")
                {
                    //unique path for cad compelte
                    try
                    {
                        if (cadDueDate < cadCompleteDate)
                        {
                            row.Cells[cadDueDateIndex].Style.BackColor = Color.Orange;
                            row.Cells[completeDateIndex].Style.BackColor = Color.Orange;
                        }
                    }
                    catch { }
                }
                else
                {
                    if (cadDueDate < DateTime.Now)
                    {
                        row.Cells[cadDueDateIndex].Style.BackColor = Color.Orange;
                        row.Cells[completeDateIndex].Style.BackColor = Color.Orange;
                    }
                }


            }
        }
        private void frmCAD_Shown(object sender, EventArgs e)
        {
            apply_filter();
          //  colour_grid();
        }

        private void dgvEnquiryLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == idIndex)
            {
                frmEnquiryDetails frm = new frmEnquiryDetails(Convert.ToInt32(dgvEnquiryLog.Rows[e.RowIndex].Cells[0].Value.ToString()));
                frm.ShowDialog();
                rowID = e.RowIndex;
                apply_filter();
            } //opens enquiry details
            if (e.ColumnIndex == processButtonIndex)
            {
                frmAllocateCad frm = new frmAllocateCad();
                frm.ShowDialog();
                //CONNECT.cadAllocationPath
                // 1 = choose allocation

                //2 = current login 

                //3 cancel

            } //processing button

            //if (e.ColumnIndex == cadButtonIndex)
            //{



            //}//cad button
            //if (e.ColumnIndex == completeButton)
            //{

            //} //complete button
            //if (e.ColumnIndex == cancelButtonIndex)
            //{

            //}
        }
    }
}
