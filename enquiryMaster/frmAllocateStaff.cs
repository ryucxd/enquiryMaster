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
    public partial class frmAllocateStaff : Form
    {
        public frmAllocateStaff()
        {
            InitializeComponent();
            fillGrid();
        }

        private void fillGrid()
        {
            //slimline will use this string x2
            string sql = "";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString)) //
            {
                conn.Open();
                sql = "select id as [ID],forename + ' ' + surname as [FullName] from [user_info].dbo.[user] where [grouping] = 25 and [current] = 1 and actual_department = 'Estimating'  order by FullName ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSlimlineEstimating.DataSource = dt;

                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSlimlineCAD.DataSource = dt;
                }
                sql = "select id as [ID],forename + ' ' + surname as [FullName] from [user_info].dbo.[user] where [grouping] = 1 and [current] = 1 and id <> 226 order by FullName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCAD.DataSource = dt;
                }
                sql = "select id as [ID],forename + ' ' + surname as [FullName] from [user_info].dbo.[user] where ([grouping] = 5 or [user].id = 27)  and [current] = 1 and (non_user = 0 or non_user is null) order by FullName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEstimating.DataSource = dt;
                }
                conn.Close();
            }

        }

        private void frmAllocateStaff_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void format()
        {
            dgvEstimating.Columns[0].Visible = false;
            dgvSlimlineEstimating.Columns[0].Visible = false;
            dgvCAD.Columns[0].Visible = false;
            dgvSlimlineCAD.Columns[0].Visible = false;
            dgvEstimating.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSlimlineEstimating.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCAD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSlimlineCAD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            currentAllocated();

        }

        private void currentAllocated()
        {
            //select string from dbo.view_department_reverse_concat where placement_date = CAST(GETDATE() as date) AND
            //(department = 'Estimating' or department = 'Drawing' or department = 'SL Drawing' or department = 'SL Estimating')

            string sql = "";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //estimating 
                sql = "select [string] from [order_database].dbo.view_department_reverse_concat where placement_date = CAST(GETDATE() as date) AND (department = 'Estimating')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataGridViewRow dgvRow in dgvEstimating.Rows)
                        {
                            if (row[0].ToString() == dgvRow.Cells[0].Value.ToString())
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
                //drawing
                sql = "select [string] from [order_database].dbo.view_department_reverse_concat where placement_date = CAST(GETDATE() as date) AND (department = 'Drawing')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataGridViewRow dgvRow in dgvCAD.Rows)
                        {
                            if (row[0].ToString() == dgvRow.Cells[0].Value.ToString())
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
                //slimline estimating
                sql = "select [string] from [order_database].dbo.view_department_reverse_concat where placement_date = CAST(GETDATE() as date) AND (department = 'SL Estimating')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataGridViewRow dgvRow in dgvSlimlineEstimating.Rows)
                        {
                            if (row[0].ToString() == dgvRow.Cells[0].Value.ToString())
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
                //slimline drawing
                sql = "select [string] from [order_database].dbo.view_department_reverse_concat where placement_date = CAST(GETDATE() as date) AND (department = 'SL Drawing')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataGridViewRow dgvRow in dgvSlimlineCAD.Rows)
                        {
                            if (row[0].ToString() == dgvRow.Cells[0].Value.ToString())
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void dgvEstimating_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.LightSkyBlue)
                dgvEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            else
                dgvEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvEstimating.ClearSelection();
        }

        private void dgvCAD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.LightSkyBlue)
                dgvCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            else
                dgvCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvCAD.ClearSelection();
        }

        private void dgvSlimlineEstimating_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSlimlineEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.LightSkyBlue)
                dgvSlimlineEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            else
                dgvSlimlineEstimating.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvSlimlineCAD.ClearSelection();
            dgvSlimlineEstimating.ClearSelection();
        }

        private void dgvSlimlineCAD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSlimlineCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.LightSkyBlue)
                dgvSlimlineCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            else
                dgvSlimlineCAD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvSlimlineCAD.ClearSelection();
            dgvSlimlineEstimating.ClearSelection();
        }

        private void dgvSlimlineEstimating_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSlimlineCAD.ClearSelection();
            dgvSlimlineEstimating.ClearSelection();
        }

        private void dgvSlimlineCAD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSlimlineCAD.ClearSelection();
            dgvSlimlineEstimating.ClearSelection();
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            //check all have at least one blue before going forward
            int validation = 0;
            int colour_count = 0;
            //estimating
            foreach (DataGridViewRow row in dgvEstimating.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Empty)
                    colour_count++;
            }
            if (colour_count == dgvEstimating.Rows.Count)
                validation = -1;
            colour_count = 0;
            //cad
            foreach (DataGridViewRow row in dgvCAD.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Empty)
                    colour_count++;
            }
            if (colour_count == dgvCAD.Rows.Count)
                validation = -1;
            colour_count = 0;
            //slimline estimating
            foreach (DataGridViewRow row in dgvSlimlineEstimating.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Empty)
                    colour_count++;
            }
            if (colour_count == dgvSlimlineEstimating.Rows.Count)
                validation = -1;
            colour_count = 0;
            //slimline cad
            foreach (DataGridViewRow row in dgvSlimlineCAD.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Empty)
                    colour_count++;
            }
            if (colour_count == dgvSlimlineCAD.Rows.Count)
                validation = -1;

            if (validation == -1)
            {
                MessageBox.Show("There must be at least one user in each department before you can allocate!", "Missing Staff", MessageBoxButtons.OK);
                return;
            }    
            string sql = "";
            //go through each dgv > delete the department entry > reupload all the selected entires
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //delete all the entries for today
                sql = "DELETE FROM [order_database].dbo.department_placement_planner WHERE placement_date = CAST(GETDATE() as date) AND" +
                    " (department = 'Estimating' or department = 'Drawing' or department = 'SL Drawing' or department = 'SL Estimating') ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                string staff_id_string = "";


                //estimating 
                foreach (DataGridViewRow row in dgvEstimating.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightSkyBlue)
                        staff_id_string = staff_id_string + row.Cells[0].Value.ToString() + ",";
                }
                staff_id_string = staff_id_string.Remove(staff_id_string.Length - 1, 1);
                sql = "INSERT INTO [order_database].dbo.department_placement_planner (placement_date,department,staff_id_string,office_or_shopfloor)" +
                    "VALUES ('" + DateTime.Now.ToString("yyyyMMdd") + "','Estimating','" + staff_id_string + "','Office')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                staff_id_string = "";


                // drawing
                foreach (DataGridViewRow row in dgvCAD.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightSkyBlue)
                        staff_id_string = staff_id_string + row.Cells[0].Value.ToString() + ",";
                }
                staff_id_string = staff_id_string.Remove(staff_id_string.Length - 1, 1);
                sql = "INSERT INTO [order_database].dbo.department_placement_planner (placement_date,department,staff_id_string,office_or_shopfloor)" +
                    "VALUES ('" + DateTime.Now.ToString("yyyyMMdd") + "','Drawing','" + staff_id_string + "','Office')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                staff_id_string = "";


                // slimline estimating 
                foreach (DataGridViewRow row in dgvSlimlineEstimating.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightSkyBlue)
                        staff_id_string = staff_id_string + row.Cells[0].Value.ToString() + ",";
                }
                staff_id_string = staff_id_string.Remove(staff_id_string.Length - 1, 1);
                sql = "INSERT INTO [order_database].dbo.department_placement_planner (placement_date,department,staff_id_string,office_or_shopfloor)" +
                    "VALUES ('" + DateTime.Now.ToString("yyyyMMdd") + "','SL Estimating','" + staff_id_string + "','Office')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                staff_id_string = "";

                // slimline drawings
                foreach (DataGridViewRow row in dgvSlimlineCAD.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightSkyBlue)
                        staff_id_string = staff_id_string + row.Cells[0].Value.ToString() + ",";
                }
                staff_id_string = staff_id_string.Remove(staff_id_string.Length - 1, 1);
                sql = "INSERT INTO [order_database].dbo.department_placement_planner (placement_date,department,staff_id_string,office_or_shopfloor)" +
                    "VALUES ('" + DateTime.Now.ToString("yyyyMMdd") + "','SL Drawing','" + staff_id_string + "','Office')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                staff_id_string = "";


                conn.Close();
                MessageBox.Show("Placements updated!", " ", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void dgvEstimating_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmSpecificCustomer frm = new frmSpecificCustomer();
            frm.ShowDialog();
        }
    }
}