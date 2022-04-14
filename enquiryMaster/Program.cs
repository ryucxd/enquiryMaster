using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace enquiryMaster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string username = "", password = "";

            // Store the Excel processes before opening.
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel.
            string temp = @"C:\DesignAndSupply_Programs\Session\user_session.csv";
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Open(temp);
            var xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet

            // Get Excel processes after opening the file.
            Process[] processesAfter = Process.GetProcessesByName("excel");

            username = (string)(xlWorksheet.Cells[2, 1] as Microsoft.Office.Interop.Excel.Range).Value; // get the values
            password = (string)(xlWorksheet.Cells[2, 2] as Microsoft.Office.Interop.Excel.Range).Value;
            // xlWorkbook.Close(true); //close the excel sheet
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


            //get the user logon
            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE username = '" + username + "' AND password = '" + password + "'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = cmd.ExecuteScalar();
                    if (data != null)
                        CONNECT.staffID = Convert.ToInt32(data);
                    else
                    {
                        MessageBox.Show("Invalid login... Please start the program loader and enter your logins and try again!", "INVALID LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conn.Close();
                        System.Environment.Exit(0);
                    }

                }
                using (SqlCommand cmd = new SqlCommand("SELECT forename + ' ' + surname FROM [user_info].dbo.[user] WHERE username = '" + username + "' AND password = '" + password + "'", conn))
                {
                    CONNECT.staffFullName = cmd.ExecuteScalar().ToString();

                }
                sql = " Select forename +' ' + surname from[user_info].dbo.[user] where(actual_department = 'drawing' or allocation_dept_2 = 'drawing' or allocation_dept_3 = 'drawing' or allocation_dept_4 = 'drawing' " +
                    " or allocation_dept_5 = 'drawing' or allocation_dept_6 = 'drawing') and[current] = 1 and id =  " + CONNECT.staffID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = (string)cmd.ExecuteScalar();
                    if (data != null)
                        CONNECT.openCAD = -1;
                    else
                        CONNECT.openCAD = 0;
                }
                conn.Close();
            }
            if (CONNECT.openCAD == -1)
                Application.Run(new frmCAD());
            else
                Application.Run(new frmMain());
        }
    }
}
