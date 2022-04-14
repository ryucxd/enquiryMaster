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
using System.Drawing.Printing;

namespace enquiryMaster
{
    public partial class frmPrintNew : Form
    {
        public frmPrintNew(int enquiry_id)
        {
            InitializeComponent();
            fill_data(enquiry_id);
            //this.MaximumSize = new Size(952, Screen.PrimaryScreen.Bounds.Height);
            Size = new Size(1023, Screen.PrimaryScreen.WorkingArea.Height);

            this.Shown += (s, e) =>
            {
                Task.Run(() =>
                {
                    int i = 0;
                    while (i < 1)
                    {
                        System.Threading.Thread.Sleep(500); // optional?
                        printImage();
                        i = 99;
                        this.Invoke((MethodInvoker)delegate
                       {
                           //can close the form on this thread now
                           this.Close();
                       });

                    }
                });
            };
        }
        private void fill_data(int enquiry_id)
        {
            string sql = "select Enquiry_Log.id,recieved_time,sender_email_address,subject,Body from dbo.Enquiry_Log  where Enquiry_Log.id = " + enquiry_id;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //use this dt to fill out all the  boxes

                    txtRecieved.Text = dt.Rows[0][1].ToString();
                    txtSentBy.Text = dt.Rows[0][2].ToString();
                    //change sent by if its an internal email 
                    if (txtSentBy.Text.Contains("EXCHANGELABS/OU=EXCHANGE"))
                    {
                        //remove all the clutter
                        string temp = txtSentBy.Text;
                        txtSentBy.Text = temp.Substring(temp.IndexOf("-") + 1);
                    }
                    txtSubject.Text = dt.Rows[0][3].ToString();
                    webBrowser1.DocumentText = dt.Rows[0][4].ToString();
                    txtID.Text = dt.Rows[0][0].ToString();

                }

            }
        }



        private void printImage()
        {
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(@"C:\temp\temp.jpg");
                }


                //var frm = Form.ActiveForm;
                //using (var bmp = new Bitmap(frm.Width, frm.Height))
                //{
                //    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                //    bmp.Save(@"C:\temp\temp.jpg");
                //}



                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(@"C:\temp\temp.jpg");
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = false;
                //Margins margins = new Margins(50, 50, 50, 50);
                //pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }

        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            System.Threading.Thread.Sleep(200);
            printImage();
            this.Close();
        }




    }
}
