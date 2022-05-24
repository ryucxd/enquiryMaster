namespace enquiryMaster
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dgvEnquiryLog = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dteRecievedStart = new System.Windows.Forms.DateTimePicker();
            this.dteRecievedEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAllocatedToCad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCadStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSenderEmail = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvEstimator = new System.Windows.Forms.DataGridView();
            this.dgvCAD = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkOutstanding = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reshuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADLOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allocateUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aRCHIVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnquiryLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEnquiryLog
            // 
            this.dgvEnquiryLog.AllowUserToAddRows = false;
            this.dgvEnquiryLog.AllowUserToDeleteRows = false;
            this.dgvEnquiryLog.AllowUserToResizeRows = false;
            this.dgvEnquiryLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnquiryLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnquiryLog.Location = new System.Drawing.Point(12, 247);
            this.dgvEnquiryLog.Name = "dgvEnquiryLog";
            this.dgvEnquiryLog.RowHeadersVisible = false;
            this.dgvEnquiryLog.Size = new System.Drawing.Size(1753, 493);
            this.dgvEnquiryLog.TabIndex = 0;
            this.dgvEnquiryLog.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEnquiryLog_CellMouseClick);
            this.dgvEnquiryLog.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnquiryLog_CellMouseEnter);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 195);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enquiry ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteRecievedStart
            // 
            this.dteRecievedStart.Location = new System.Drawing.Point(118, 195);
            this.dteRecievedStart.Name = "dteRecievedStart";
            this.dteRecievedStart.Size = new System.Drawing.Size(147, 20);
            this.dteRecievedStart.TabIndex = 3;
            this.dteRecievedStart.ValueChanged += new System.EventHandler(this.dteRecievedStart_ValueChanged);
            // 
            // dteRecievedEnd
            // 
            this.dteRecievedEnd.Location = new System.Drawing.Point(118, 221);
            this.dteRecievedEnd.Name = "dteRecievedEnd";
            this.dteRecievedEnd.Size = new System.Drawing.Size(147, 20);
            this.dteRecievedEnd.TabIndex = 4;
            this.dteRecievedEnd.ValueChanged += new System.EventHandler(this.dteRecievedEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(118, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recieved";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Location = new System.Drawing.Point(464, 195);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(187, 20);
            this.txtEmailSubject.TabIndex = 6;
            this.txtEmailSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailSubject_KeyDown);
            this.txtEmailSubject.Leave += new System.EventHandler(this.txtEmailSubject_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(464, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email Subject";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Checked",
            "Processing",
            "Complete",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(657, 195);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 8;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(657, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Enquiry Status";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(784, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Allocated to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbAllocatedTo
            // 
            this.cmbAllocatedTo.FormattingEnabled = true;
            this.cmbAllocatedTo.Location = new System.Drawing.Point(784, 195);
            this.cmbAllocatedTo.Name = "cmbAllocatedTo";
            this.cmbAllocatedTo.Size = new System.Drawing.Size(121, 21);
            this.cmbAllocatedTo.TabIndex = 10;
            this.cmbAllocatedTo.SelectedIndexChanged += new System.EventHandler(this.cmbAllocatedTo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(919, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Allocated to CAD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbAllocatedToCad
            // 
            this.cmbAllocatedToCad.FormattingEnabled = true;
            this.cmbAllocatedToCad.Location = new System.Drawing.Point(919, 195);
            this.cmbAllocatedToCad.Name = "cmbAllocatedToCad";
            this.cmbAllocatedToCad.Size = new System.Drawing.Size(121, 21);
            this.cmbAllocatedToCad.TabIndex = 12;
            this.cmbAllocatedToCad.SelectedIndexChanged += new System.EventHandler(this.cmbAllocatedToCad_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(1046, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "CAD Status";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCadStatus
            // 
            this.cmbCadStatus.FormattingEnabled = true;
            this.cmbCadStatus.Items.AddRange(new object[] {
            "Outstanding",
            "On Hold",
            "CAD Complete"});
            this.cmbCadStatus.Location = new System.Drawing.Point(1046, 195);
            this.cmbCadStatus.Name = "cmbCadStatus";
            this.cmbCadStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbCadStatus.TabIndex = 14;
            this.cmbCadStatus.SelectedIndexChanged += new System.EventHandler(this.cmbCadStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(159, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "End";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(6, 36);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(147, 20);
            this.dteStart.TabIndex = 17;
            this.dteStart.ValueChanged += new System.EventHandler(this.dteStart_ValueChanged);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(159, 36);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(147, 20);
            this.dteEnd.TabIndex = 16;
            this.dteEnd.ValueChanged += new System.EventHandler(this.dteEnd_ValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Start";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(271, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "Sender Email";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtSenderEmail
            // 
            this.txtSenderEmail.Location = new System.Drawing.Point(271, 195);
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Size = new System.Drawing.Size(187, 20);
            this.txtSenderEmail.TabIndex = 21;
            this.txtSenderEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenderEmail_KeyDown);
            this.txtSenderEmail.Leave += new System.EventHandler(this.txtSenderEmail_Leave);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1488, 192);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvEstimator
            // 
            this.dgvEstimator.AllowUserToAddRows = false;
            this.dgvEstimator.AllowUserToDeleteRows = false;
            this.dgvEstimator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEstimator.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEstimator.Location = new System.Drawing.Point(322, 28);
            this.dgvEstimator.Name = "dgvEstimator";
            this.dgvEstimator.ReadOnly = true;
            this.dgvEstimator.RowHeadersVisible = false;
            this.dgvEstimator.Size = new System.Drawing.Size(220, 138);
            this.dgvEstimator.TabIndex = 25;
            // 
            // dgvCAD
            // 
            this.dgvCAD.AllowUserToAddRows = false;
            this.dgvCAD.AllowUserToDeleteRows = false;
            this.dgvCAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCAD.Location = new System.Drawing.Point(548, 28);
            this.dgvCAD.Name = "dgvCAD";
            this.dgvCAD.ReadOnly = true;
            this.dgvCAD.RowHeadersVisible = false;
            this.dgvCAD.Size = new System.Drawing.Size(220, 138);
            this.dgvCAD.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(10, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // chkOutstanding
            // 
            this.chkOutstanding.AutoSize = true;
            this.chkOutstanding.Location = new System.Drawing.Point(84, 155);
            this.chkOutstanding.Name = "chkOutstanding";
            this.chkOutstanding.Size = new System.Drawing.Size(137, 17);
            this.chkOutstanding.TabIndex = 28;
            this.chkOutstanding.Text = "Show Only Outstanding";
            this.chkOutstanding.UseVisualStyleBackColor = true;
            this.chkOutstanding.CheckedChanged += new System.EventHandler(this.chkOutstanding_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(809, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Checked";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(809, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "Processing";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(809, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "On Hold";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(809, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "Complete";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(774, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "     ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(774, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 36;
            this.label17.Text = "     ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Gold;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(774, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 20);
            this.label18.TabIndex = 35;
            this.label18.Text = "     ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.PaleVioletRed;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(774, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 20);
            this.label19.TabIndex = 34;
            this.label19.Text = "     ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dteEnd);
            this.groupBox1.Controls.Add(this.dteStart);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(1173, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 68);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Complete";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.reshuffleToolStripMenuItem,
            this.cADLOGToolStripMenuItem,
            this.slimlineToolStripMenuItem,
            this.allocateUsersToolStripMenuItem,
            this.aRCHIVEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1777, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // reshuffleToolStripMenuItem
            // 
            this.reshuffleToolStripMenuItem.Name = "reshuffleToolStripMenuItem";
            this.reshuffleToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.reshuffleToolStripMenuItem.Text = "Reshuffle";
            this.reshuffleToolStripMenuItem.Click += new System.EventHandler(this.reshuffleToolStripMenuItem_Click);
            // 
            // cADLOGToolStripMenuItem
            // 
            this.cADLOGToolStripMenuItem.Name = "cADLOGToolStripMenuItem";
            this.cADLOGToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.cADLOGToolStripMenuItem.Text = "CAD LOG";
            this.cADLOGToolStripMenuItem.Click += new System.EventHandler(this.cADLOGToolStripMenuItem_Click);
            // 
            // slimlineToolStripMenuItem
            // 
            this.slimlineToolStripMenuItem.Name = "slimlineToolStripMenuItem";
            this.slimlineToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.slimlineToolStripMenuItem.Text = "Slimline";
            this.slimlineToolStripMenuItem.Click += new System.EventHandler(this.slimlineToolStripMenuItem_Click);
            // 
            // allocateUsersToolStripMenuItem
            // 
            this.allocateUsersToolStripMenuItem.Name = "allocateUsersToolStripMenuItem";
            this.allocateUsersToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.allocateUsersToolStripMenuItem.Text = "Allocate Users";
            this.allocateUsersToolStripMenuItem.Click += new System.EventHandler(this.allocateUsersToolStripMenuItem_Click);
            // 
            // aRCHIVEToolStripMenuItem
            // 
            this.aRCHIVEToolStripMenuItem.Name = "aRCHIVEToolStripMenuItem";
            this.aRCHIVEToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aRCHIVEToolStripMenuItem.Text = "ARCHIVE";
            this.aRCHIVEToolStripMenuItem.Click += new System.EventHandler(this.aRCHIVEToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 752);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkOutstanding);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvCAD);
            this.Controls.Add(this.dgvEstimator);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSenderEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCadStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbAllocatedToCad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAllocatedTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmailSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteRecievedEnd);
            this.Controls.Add(this.dteRecievedStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dgvEnquiryLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry Log";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnquiryLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEnquiryLog;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteRecievedStart;
        private System.Windows.Forms.DateTimePicker dteRecievedEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAllocatedTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAllocatedToCad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCadStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSenderEmail;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvEstimator;
        private System.Windows.Forms.DataGridView dgvCAD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkOutstanding;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reshuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADLOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slimlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocateUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aRCHIVEToolStripMenuItem;
    }
}

