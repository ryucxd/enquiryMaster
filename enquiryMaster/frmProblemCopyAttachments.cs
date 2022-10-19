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
using System.IO;

namespace enquiryMaster
{
    public partial class frmProblemCopyAttachments : Form
    {
        public int enquiry_id { get; set; }
        public int file_index { get; set; }
        public int checkbox_index { get; set; }
        public frmProblemCopyAttachments(int _enquiry_id)
        {
            InitializeComponent();
            enquiry_id = _enquiry_id;
            loadData();
            column_index();
            add_check_box();
            column_index();
            dgvAttachments.Columns[checkbox_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private void add_check_box()
        {
            if (dgvAttachments.Columns.Contains("Copy") == true)
            {
                dgvAttachments.Columns.Remove("Copy");
            }

            //add checkboxes for revision/requires cad/complete cad
            DataGridViewCheckBoxColumn copyCheckBox = new DataGridViewCheckBoxColumn();
            copyCheckBox.HeaderText = "Copy";
            copyCheckBox.Name = "Copy";
            dgvAttachments.Columns.Insert(file_index + 1, copyCheckBox);

        }
        private void column_index()
        {
            file_index = dgvAttachments.Columns["File Location"].Index;
            if (dgvAttachments.Columns.Contains("Copy") == true)
                checkbox_index = dgvAttachments.Columns["Copy"].Index;
        }

        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT full_file_path  as [File Location] FROM dbo.attachment_log WHERE email_id = " + enquiry_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttachments.DataSource = dt;
                }
                dgvAttachments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                foreach (DataGridViewColumn col in dgvAttachments.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                conn.Close();
            }
        }

        private void dgvAttachments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            column_index();
            if (e.ColumnIndex == file_index)
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
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            column_index();
            //for each ticked row -- copy to the folder for this enquiry
            //vv if the path does not exist then it creates it
            System.IO.Directory.CreateDirectory(@"\\designsvr1\public\Enquiry Log Problems\" + enquiry_id.ToString());



            for (int i = 0; i < dgvAttachments.Rows.Count; i++)
            {
                try
                {
                    //need to trim the P:\
                    string file_to_copy = dgvAttachments.Rows[i].Cells[file_index].Value.ToString();
                    file_to_copy = file_to_copy.Remove(0, 2);
                    file_to_copy = @"\\designsvr1\public" + file_to_copy;

                    string new_location = @"\\designsvr1\public\Enquiry Log Problems\" + enquiry_id.ToString() + @"\";
                    //we have to add the file name and type to the end of the new location

                    new_location = new_location + file_to_copy.Substring(file_to_copy.LastIndexOf(@"\") + 1);



                    if (Convert.ToBoolean(dgvAttachments.Rows[i].Cells[checkbox_index].Value) == true)
                        File.Copy(file_to_copy, new_location, true);

                }
                catch
                { }
            }
            System.Diagnostics.Process.Start(@"\\designsvr1\public\Enquiry Log Problems\" + enquiry_id.ToString());
            this.Close();
        }
            
            

        }
    }

