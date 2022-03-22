namespace enquiryMaster
{
    partial class frmAllocateCad
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
            this.btnChooseAllocation = new System.Windows.Forms.Button();
            this.btnAllocateToMyself = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.btnAllocateToStaff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChooseAllocation
            // 
            this.btnChooseAllocation.Location = new System.Drawing.Point(12, 36);
            this.btnChooseAllocation.Name = "btnChooseAllocation";
            this.btnChooseAllocation.Size = new System.Drawing.Size(89, 35);
            this.btnChooseAllocation.TabIndex = 0;
            this.btnChooseAllocation.Text = "Choose Allocation";
            this.btnChooseAllocation.UseVisualStyleBackColor = true;
            this.btnChooseAllocation.Click += new System.EventHandler(this.btnChooseAllocation_Click);
            // 
            // btnAllocateToMyself
            // 
            this.btnAllocateToMyself.Location = new System.Drawing.Point(113, 36);
            this.btnAllocateToMyself.Name = "btnAllocateToMyself";
            this.btnAllocateToMyself.Size = new System.Drawing.Size(89, 35);
            this.btnAllocateToMyself.TabIndex = 1;
            this.btnAllocateToMyself.Text = "Allocate to myself";
            this.btnAllocateToMyself.UseVisualStyleBackColor = true;
            this.btnAllocateToMyself.Click += new System.EventHandler(this.btnAllocateToMyself_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please choose how to allocate this job";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(76, 89);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(171, 21);
            this.cmbStaff.TabIndex = 4;
            // 
            // btnAllocateToStaff
            // 
            this.btnAllocateToStaff.Location = new System.Drawing.Point(113, 116);
            this.btnAllocateToStaff.Name = "btnAllocateToStaff";
            this.btnAllocateToStaff.Size = new System.Drawing.Size(89, 22);
            this.btnAllocateToStaff.TabIndex = 5;
            this.btnAllocateToStaff.Text = "Allocate to staff";
            this.btnAllocateToStaff.UseVisualStyleBackColor = true;
            this.btnAllocateToStaff.Click += new System.EventHandler(this.btnAllocateToStaff_Click);
            // 
            // frmAllocateCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 77);
            this.ControlBox = false;
            this.Controls.Add(this.btnAllocateToStaff);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAllocateToMyself);
            this.Controls.Add(this.btnChooseAllocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAllocateCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAD Allocation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseAllocation;
        private System.Windows.Forms.Button btnAllocateToMyself;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Button btnAllocateToStaff;
    }
}