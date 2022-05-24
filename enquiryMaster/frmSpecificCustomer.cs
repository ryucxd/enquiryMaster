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
    public partial class frmSpecificCustomer : Form
    {
        public int idIndex { get; set; }
        public int customerIndex { get; set; }
        public int emailIndex { get; set; }
        public int staffIndex { get; set; }
        public int removeIndex { get; set; }
        public frmSpecificCustomer()
        {
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            if (dataGridView1.Columns.Contains("Remove") == true)
            {
                dataGridView1.Columns.Remove("Remove");
            }
            // dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;
            cmbStaff.Items.Clear();
            //fill the  cmb box 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "select forename + ' ' + surname as [FullName] from [user_info].dbo.[user] where ([grouping] = 5 or [user].id = 27)  and [current] = 1 and (non_user = 0 or non_user is null) order by FullName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        cmbStaff.Items.Add(row[0].ToString());
                }
                sql = "SELECT c.id,forename + ' ' + surname as [Full Name],customer_name as [Customer],customer_email_suffix as [Email Suffix] from dbo.user_specific_customer c left join[user_info].dbo.[user] u on c.[user_id] = u.id ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    idIndex = dataGridView1.Columns["id"].Index;
                    staffIndex = dataGridView1.Columns["Full Name"].Index;
                    customerIndex = dataGridView1.Columns["Customer"].Index;
                    emailIndex = dataGridView1.Columns["Email Suffix"].Index;

                }
            }


            int columnIndex = 0;
            columnIndex = emailIndex + 1;
            DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
            removeButton.Name = "Remove";
            removeButton.Text = "Remove";
            removeButton.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["Remove"] == null)
            {
                dataGridView1.Columns.Insert(0, removeButton);
            }
            idIndex = dataGridView1.Columns["id"].Index;
            staffIndex = dataGridView1.Columns["Full Name"].Index;
            customerIndex = dataGridView1.Columns["Customer"].Index;
            emailIndex = dataGridView1.Columns["Email Suffix"].Index;
            removeIndex = dataGridView1.Columns["Remove"].Index;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "";
            cmbStaff.Text = cmbStaff.Text.Replace("'", "");
            txtCustomerName.Text = txtCustomerName.Text.Replace("'", "");
            txtEmailSuffix.Text = txtEmailSuffix.Text.Replace("'", "");

            if (cmbStaff.Text.Length < 1)
            {
                MessageBox.Show("Please Select a staff member before allocating a specific customer");
                return;
            }
            if (txtCustomerName.Text.Length < 1)
            {
                MessageBox.Show("Please enter a customer name before allocating a specific customer");
                return;
            }
            if (txtEmailSuffix.Text.Length < 1)
            {
                MessageBox.Show("Please enter an email suffix before allocating a specific customer");
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //get this staff members user id 
                int staff_id = 0;
                sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbStaff.Text + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //add this persont to user spec

                sql = "INSERT INTO dbo.user_specific_customer (customer_name,user_id,customer_email_suffix) VALUES ('" + txtCustomerName.Text + "'," + staff_id.ToString() + ",'" + txtEmailSuffix.Text + "')";
                //MessageBox.Show(sql);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();
            }

            txtEmailSuffix.Text = "";
            txtCustomerName.Text = "";
            cmbStaff.Text = "";
            getData();
            format();
        }

        private void frmSpecificCustomer_Shown(object sender, EventArgs e)
        {
            format();
        }
        private void format()
        {
            dataGridView1.Columns[idIndex].Visible = false;
            dataGridView1.Columns[staffIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[customerIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[emailIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //hide id
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //remove from user spec where id = idcolumn
                string sql = "DELETE  FROM dbo.user_specific_customer WHERE id = " + dataGridView1.Rows[e.RowIndex].Cells[idIndex].Value.ToString();
                //   MessageBox.Show(sql);
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    getData();
                    format();
                }
            }
        }
    }
}
