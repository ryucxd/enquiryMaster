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
    public partial class frmMain : Form
    {
        public int idIndex { get; set; }
        public int recievedTimeIndex { get; set; }
        public int senderEmailIndex { get; set; }
        public int subjectIndex { get; set; }
        public int priorityJobIndex { get; set; }
        public int revisionIndex { get; set; }
        public int priceQtyRequiredIndex { get; set; }
        public int statusIndex { get; set; }
        public int allocatedToIndex { get; set; }
        public int processedButtonIndex { get; set; }
        public int cadButtonIndex { get; set; }
        public int onHoldIndex { get; set; }
        public int requiresCadIndex { get; set; }
        public int allocatedToCadIndex { get; set; }
        public int cadCompleteIndex { get; set; }
        public int completeDateIndex { get; set; }
        public int completeButton { get; set; }
        public int cancelButtonIndex { get; set; }

        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void apply_filter()
        {
            //        If cmbCADStatus.Value = "Outstanding" Then
            //sql = sql & "cad_complete is null AND (on_hold = 0 OR on_hold is null)    AND  "
            //    End If

            //    If cmbCADStatus.Value = "On Hold" Then
            //        sql = sql & "cad_complete is null AND on_hold = -1    AND  "
            //    End If

            //    If cmbCADStatus.Value = "CAD Complete" Then
            //        sql = sql & "cad_complete = -1    AND  "
            //    End If

            //^^ cad status is unique



            //get the main datagridview filtered (and apply any colourts etc
            string sql = "SET DATEFORMAT dmy;SELECT TOP 300 enquiry_log.id,recieved_time,sender_email_address,[subject],priority_job,revision,price_qty_required,es.[description] as [status],u_estimator.forename + ' ' + u_estimator.surname as allocated_to," +
                "on_hold,requires_cad,u_cad.forename + ' ' + u_cad.surname as allocate_to_CAD,cad_complete,complete_date FROM dbo.enquiry_log WITH(NOLOCK) " +
                "LEFT JOIN[user_info].dbo.[user] u_estimator on u_estimator.id = Enquiry_Log.allocated_to_id " +
                "LEFT JOIN[user_info].dbo.[user] u_cad on u_cad.id = Enquiry_Log.allocated_to_cad_id " +
                "LEFT JOIN enquiry_status es on es.id = Enquiry_Log.status_id " +
                "WHERE(slimline_request = 0 or slimline_request is null)";

            //filter based on user inputs


            sql = sql +  "ORDER BY id desc";

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
                column_index_refresh();
                //add buttons
                addbuttons();
                format();
            }
        }
        private void addbuttons()
        {

        }
        private void column_index_refresh()
        {
            idIndex = dgvEnquiryLog.Columns["id"].Index;
            recievedTimeIndex = dgvEnquiryLog.Columns["recieved_time"].Index;
            senderEmailIndex = dgvEnquiryLog.Columns["sender_email_address"].Index;
            subjectIndex = dgvEnquiryLog.Columns["subject"].Index;
            priorityJobIndex = dgvEnquiryLog.Columns["priority_job"].Index;
            revisionIndex = dgvEnquiryLog.Columns["revision"].Index;
            priceQtyRequiredIndex = dgvEnquiryLog.Columns["price_qty_required"].Index;
            statusIndex = dgvEnquiryLog.Columns["status"].Index;
            allocatedToIndex = dgvEnquiryLog.Columns["allocated_to"].Index;
            onHoldIndex = dgvEnquiryLog.Columns["on_hold"].Index;
            requiresCadIndex = dgvEnquiryLog.Columns["requires_cad"].Index;
            allocatedToCadIndex = dgvEnquiryLog.Columns["allocate_to_CAD"].Index;
            cadCompleteIndex = dgvEnquiryLog.Columns["cad_complete"].Index;
            completeDateIndex = dgvEnquiryLog.Columns["complete_date"].Index;
        }
        private void format()
        {
            dgvEnquiryLog.Columns[idIndex].HeaderText = "ID";
            dgvEnquiryLog.Columns[recievedTimeIndex].HeaderText = "Recieved";
            dgvEnquiryLog.Columns[senderEmailIndex].HeaderText = "Sender Email";
            dgvEnquiryLog.Columns[subjectIndex].HeaderText = "Email Subject";
            dgvEnquiryLog.Columns[priorityJobIndex].HeaderText = "is Priority";
            dgvEnquiryLog.Columns[revisionIndex].HeaderText = "is Revision";
            dgvEnquiryLog.Columns[priceQtyRequiredIndex].HeaderText = "Item QTY";
            dgvEnquiryLog.Columns[statusIndex].HeaderText = "Enquiry Status";
            dgvEnquiryLog.Columns[allocatedToIndex].HeaderText = "Allocated to";
            dgvEnquiryLog.Columns[onHoldIndex].HeaderText = "on Hold";
            dgvEnquiryLog.Columns[requiresCadIndex].HeaderText = "Requires CAD";
            dgvEnquiryLog.Columns[allocatedToCadIndex].HeaderText = "Allocated to CAD";
            dgvEnquiryLog.Columns[cadCompleteIndex].HeaderText = "CAD Complete";
            dgvEnquiryLog.Columns[completeDateIndex].HeaderText = "Date Complete";

            foreach(DataGridViewColumn col in dgvEnquiryLog.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvEnquiryLog.Columns[senderEmailIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEnquiryLog.Columns[senderEmailIndex].Width = 300;
            dgvEnquiryLog.Columns[subjectIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEnquiryLog.Columns[subjectIndex].Width = 300;
        }


    }
}
