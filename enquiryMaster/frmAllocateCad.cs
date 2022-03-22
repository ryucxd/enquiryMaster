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
    public partial class frmAllocateCad : Form
    {
        public frmAllocateCad()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "select forename + ' ' + surname from [user_info].dbo.[user] where(actual_department = 'drawing' or allocation_dept_2 = 'drawing' or allocation_dept_3 = 'drawing' or allocation_dept_4 = 'drawing' " +
                    "or allocation_dept_5 = 'drawing' or allocation_dept_6 = 'drawing') and[current] = 1 order by forename asc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        cmbStaff.Items.Add(row[0].ToString());
                    conn.Close();
                }
            }
        }

        private void btnChooseAllocation_Click(object sender, EventArgs e)
        {
            this.Height = 185;
        }

        private void btnAllocateToMyself_Click(object sender, EventArgs e)
        {
            CONNECT.cadAllocationPath = 2;
            //only allow this path is the current logged in user is in drawing for today
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                String sql = " Select forename +' ' + surname from[user_info].dbo.[user] where(actual_department = 'drawing' or allocation_dept_2 = 'drawing' or allocation_dept_3 = 'drawing' or allocation_dept_4 = 'drawing' " +
                    " or allocation_dept_5 = 'drawing' or allocation_dept_6 = 'drawing') and[current] = 1 and id =  " + CONNECT.staffID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var data = (string)cmd.ExecuteScalar();
                    if (data == null)
                    {
                        MessageBox.Show("You are not allowed to take CAD jobs!","Invalid user",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }    
                    conn.Close();
                    this.Close();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.cadAllocationPath = 3;
            this.Close();
        }

        private void btnAllocateToStaff_Click(object sender, EventArgs e)
        {
            if (cmbStaff.Text == "")
            {
                MessageBox.Show("Please select a staff before allocating!", "Staff required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //get the staff id
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbStaff.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    CONNECT.cadAllocationPath = 1;
                    CONNECT.cadAllocationStaffPicked = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    conn.Close();
                }
            }
            this.Close();
        }
    }
}
