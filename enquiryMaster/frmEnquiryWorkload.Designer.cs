namespace enquiryMaster
{
    partial class frmEnquiryWorkload
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
            this.dteWorkDay = new System.Windows.Forms.DateTimePicker();
            this.dgvEnquiryLog = new System.Windows.Forms.DataGridView();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblRotec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnquiryLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dteWorkDay
            // 
            this.dteWorkDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dteWorkDay.Location = new System.Drawing.Point(12, 20);
            this.dteWorkDay.Name = "dteWorkDay";
            this.dteWorkDay.Size = new System.Drawing.Size(227, 24);
            this.dteWorkDay.TabIndex = 0;
            this.dteWorkDay.CloseUp += new System.EventHandler(this.dteWorkDay_CloseUp);
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
            this.dgvEnquiryLog.Location = new System.Drawing.Point(12, 52);
            this.dgvEnquiryLog.Name = "dgvEnquiryLog";
            this.dgvEnquiryLog.RowHeadersVisible = false;
            this.dgvEnquiryLog.Size = new System.Drawing.Size(1215, 643);
            this.dgvEnquiryLog.TabIndex = 1;
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblItem.Location = new System.Drawing.Point(245, 20);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(319, 24);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Total Items available: 0";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRotec
            // 
            this.lblRotec.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblRotec.Location = new System.Drawing.Point(570, 20);
            this.lblRotec.Name = "lblRotec";
            this.lblRotec.Size = new System.Drawing.Size(411, 24);
            this.lblRotec.TabIndex = 3;
            this.lblRotec.Text = "Total Rotec Items available: 0";
            this.lblRotec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEnquiryWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 707);
            this.Controls.Add(this.lblRotec);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.dgvEnquiryLog);
            this.Controls.Add(this.dteWorkDay);
            this.Name = "frmEnquiryWorkload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Load";
            this.Shown += new System.EventHandler(this.frmEnquiryWorkload_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnquiryLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteWorkDay;
        private System.Windows.Forms.DataGridView dgvEnquiryLog;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblRotec;
    }
}