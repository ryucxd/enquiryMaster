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
using System.Net.NetworkInformation;

namespace enquiryMaster
{
    public partial class frmEnquiryWorkload : Form
    {

        public int id_index { get; set; }
        public int recieved_time_index { get; set; }
        public int sender_email_index { get; set; }
        public int subject_index { get; set; }
        public int revision_index { get; set; }
        public int item_qty_index { get; set; }
        public int status_index { get; set; }
        public int allocated_estimator_index { get; set; }
        public int requires_cad_index { get; set; }
        public int allocated_cad_index { get; set; }
        public int cad_complete_index { get; set; }
        public int complete_date_index { get; set; }
        public int on_hold_index { get; set; }
        public frmEnquiryWorkload()
        {
            InitializeComponent();

            load_data();
        }

        private void load_data()
        {
            string sql = "select e.id,e.recieved_time,e.sender_email_address,e.[subject]," +
                "CASE WHEN e.revision = 0 THEN CAST(0 AS BIT) WHEN e.revision IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [revision]," +
                "e.price_qty_required as item_qty,es.[description] as [status],u_estimator.forename + ' ' + u_estimator.surname as allocated_estimator," +
                "CASE WHEN e.requires_cad = 0 THEN CAST(0 AS BIT) WHEN e.requires_cad IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [requires_cad]," +
                "u_cad.forename + ' ' + u_cad.surname as allocated_cad," +
                "CASE WHEN e.cad_complete = 0 THEN CAST(0 AS BIT) WHEN e.cad_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [cad_complete]," +
                "e.complete_date," +
                "CASE WHEN e.on_hold = 0 THEN CAST(0 AS BIT) WHEN e.on_hold IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [on_hold] " +
                "from dbo.Enquiry_Log e " +
                "left join dbo.enquiry_status es on e.status_id = es.id " +
                "left join [user_info].dbo.[user] u_estimator on e.allocated_to_id = u_estimator.id " +
                "left join [user_info].dbo.[user] u_cad on e.allocated_to_cad_id = u_cad.id " +
                "where  cast(recieved_time as date) = '" + dteWorkDay.Value.ToString("yyyyMMdd") + "' and " +
                "(cast(complete_date as date) > '" + dteWorkDay.Value.ToString("yyyyMMdd") + "' or complete_date is null) " +
                "and status_id < 5 and (slimline_request = 0 or slimline_request is null)";

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

                conn.Close();
            }
            column_index();
            format();
        }

        private void column_index()
        {
            id_index = dgvEnquiryLog.Columns["id"].Index;
            recieved_time_index = dgvEnquiryLog.Columns["recieved_time"].Index;
            sender_email_index = dgvEnquiryLog.Columns["sender_email_address"].Index;
            subject_index = dgvEnquiryLog.Columns["subject"].Index;
            revision_index = dgvEnquiryLog.Columns["revision"].Index;
            item_qty_index = dgvEnquiryLog.Columns["item_qty"].Index;
            status_index = dgvEnquiryLog.Columns["status"].Index;
            allocated_estimator_index = dgvEnquiryLog.Columns["allocated_estimator"].Index;
            requires_cad_index = dgvEnquiryLog.Columns["requires_cad"].Index;
            allocated_cad_index = dgvEnquiryLog.Columns["allocated_cad"].Index;
            cad_complete_index = dgvEnquiryLog.Columns["cad_complete"].Index;
            complete_date_index = dgvEnquiryLog.Columns["complete_date"].Index;
            on_hold_index = dgvEnquiryLog.Columns["on_hold"].Index;

        }

        private void format()
        {
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                if (row.Cells[sender_email_index].Value.ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                {
                    //remove all the clutter
                    string temp = row.Cells[sender_email_index].Value.ToString();
                    row.Cells[sender_email_index].Value = temp.Substring(temp.IndexOf("-") + 1);
                }
            }


            dgvEnquiryLog.Columns[id_index].HeaderText = "ID";
            dgvEnquiryLog.Columns[recieved_time_index].HeaderText = "Recieved";
            dgvEnquiryLog.Columns[sender_email_index].HeaderText = "Sender Email";
            dgvEnquiryLog.Columns[subject_index].HeaderText = "Email Subject";
            //dgvEnquiryLog.Columns[priorityJobIndex].HeaderText = "is Priority";
            dgvEnquiryLog.Columns[revision_index].HeaderText = "is Revision";
            dgvEnquiryLog.Columns[item_qty_index].HeaderText = "Item QTY";
            dgvEnquiryLog.Columns[status_index].HeaderText = "Enquiry Status";
            dgvEnquiryLog.Columns[allocated_estimator_index].HeaderText = "Allocated to";
            //dgvEnquiryLog.Columns[onHoldIndex].HeaderText = "on Hold";
            dgvEnquiryLog.Columns[requires_cad_index].HeaderText = "Requires CAD";
            dgvEnquiryLog.Columns[allocated_cad_index].HeaderText = "Allocated to CAD";
            dgvEnquiryLog.Columns[cad_complete_index].HeaderText = "CAD Complete";
            dgvEnquiryLog.Columns[complete_date_index].HeaderText = "Date Complete";
            dgvEnquiryLog.Columns[on_hold_index].Visible = false;

            foreach (DataGridViewColumn col in dgvEnquiryLog.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvEnquiryLog.Columns[sender_email_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEnquiryLog.Columns[sender_email_index].Width = 300;
            dgvEnquiryLog.Columns[subject_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            //colours
            foreach (DataGridViewRow row in dgvEnquiryLog.Rows)
            {
                //complete
                if (row.Cells[status_index].Value.ToString() == "Complete")
                {
                    row.Cells[id_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[recieved_time_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[sender_email_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[subject_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[revision_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[item_qty_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[status_index].Style.BackColor = Color.MediumAquamarine;
                    row.Cells[allocated_estimator_index].Style.BackColor = Color.MediumAquamarine;
                }
                //checked
                if (row.Cells[status_index].Value.ToString() == "Checked")
                {
                    row.Cells[id_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[recieved_time_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[sender_email_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[subject_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[revision_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[item_qty_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[status_index].Style.BackColor = Color.PaleVioletRed;
                    row.Cells[allocated_estimator_index].Style.BackColor = Color.PaleVioletRed;
                }
                //processing
                if (row.Cells[status_index].Value.ToString() == "Processing")
                {
                    row.Cells[id_index].Style.BackColor = Color.Gold;
                    row.Cells[recieved_time_index].Style.BackColor = Color.Gold;
                    row.Cells[sender_email_index].Style.BackColor = Color.Gold;
                    row.Cells[subject_index].Style.BackColor = Color.Gold;
                    row.Cells[revision_index].Style.BackColor = Color.Gold;
                    row.Cells[item_qty_index].Style.BackColor = Color.Gold;
                    row.Cells[status_index].Style.BackColor = Color.Gold;
                    row.Cells[allocated_estimator_index].Style.BackColor = Color.Gold;
                }
                //on hold
                if (row.Cells[on_hold_index].Value.ToString() == "-1")
                {
                    row.Cells[id_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[recieved_time_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[sender_email_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[subject_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[revision_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[item_qty_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[status_index].Style.BackColor = Color.LightSkyBlue;
                    row.Cells[allocated_estimator_index].Style.BackColor = Color.LightSkyBlue;

                }
                //CAD COLOURS 
                if (row.Cells[allocated_cad_index].Value.ToString().Length > 0) //red by default (if theres a job assigned)
                    row.Cells[allocated_cad_index].Style.BackColor = Color.PaleVioletRed;
                if (row.Cells[allocated_cad_index].Value.ToString().Length > 0) //not null
                    row.Cells[allocated_cad_index].Style.BackColor = Color.Gold;
                if (row.Cells[cad_complete_index].Value.ToString() == "-1")
                    row.Cells[allocated_cad_index].Style.BackColor = Color.MediumAquamarine;
                if (row.Cells[on_hold_index].Value.ToString() == "-1")
                    row.Cells[allocated_cad_index].Style.BackColor = Color.LightSkyBlue;

                //if (row.Cells[tender_index].Value.ToString().Length > 0)
                //{
                //    row.Cells[idIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[recievedTimeIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[senderEmailIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[subjectIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.Gainsboro;
                //    //row.Cells[statusIndex].Style.BackColor = Color.Gainsboro;
                //    row.Cells[allocatedToIndex].Style.BackColor = Color.Gainsboro;
                //}
                //if (row.Cells[pending_index].Value.ToString() == "-1")
                //{
                //    row.Cells[idIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[recievedTimeIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[senderEmailIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[subjectIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[revisionCheckboxIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[priceQtyRequiredIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[statusIndex].Style.BackColor = Color.Salmon;
                //    row.Cells[allocatedToIndex].Style.BackColor = Color.Salmon;
                //}


                //end of format >> sum up item qty

                if (dgvEnquiryLog.Rows.Count > 0)
                {
                    int item_count = 0;
                    int item_count_rotec = 0;
                    for (int i = 0; i < dgvEnquiryLog.Rows.Count; i++)
                    {
                        if (dgvEnquiryLog.Rows[i].Cells[sender_email_index].Value.ToString().Contains("rotec"))
                            item_count_rotec = item_count_rotec + Convert.ToInt32(dgvEnquiryLog.Rows[i].Cells[item_qty_index].Value.ToString());
                        else
                            item_count = item_count + Convert.ToInt32(dgvEnquiryLog.Rows[i].Cells[item_qty_index].Value.ToString());
                    }
                    lblItem.Text = "Total Items available: " + item_count.ToString();
                    lblRotec.Text = "Total Rotec Items available: " + item_count_rotec.ToString();
                }
                else
                {
                    lblItem.Text = "Total Items available: 0";
                    lblRotec.Text = "Total Rotec Items available: 0";
                }

            }

        }

        private void frmEnquiryWorkload_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void dteWorkDay_CloseUp(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
