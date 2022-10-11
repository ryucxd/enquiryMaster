namespace enquiryMaster
{
    partial class frmProblem
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
            this.txtIssue = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequestedChange = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProblems = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dteCreated = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtIssue
            // 
            this.txtIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtIssue.Location = new System.Drawing.Point(12, 319);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(761, 167);
            this.txtIssue.TabIndex = 0;
            this.txtIssue.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblTitle.Location = new System.Drawing.Point(12, 283);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(761, 33);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Existing Issues with this pack:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnAttachments
            // 
            this.btnAttachments.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAttachments.Location = new System.Drawing.Point(289, 698);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(103, 25);
            this.btnAttachments.TabIndex = 2;
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(398, 698);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.label1.Location = new System.Drawing.Point(16, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(761, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Requested Change:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtRequestedChange
            // 
            this.txtRequestedChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtRequestedChange.Location = new System.Drawing.Point(16, 113);
            this.txtRequestedChange.Name = "txtRequestedChange";
            this.txtRequestedChange.Size = new System.Drawing.Size(761, 167);
            this.txtRequestedChange.TabIndex = 4;
            this.txtRequestedChange.Text = "";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.label2.Location = new System.Drawing.Point(12, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(761, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Problem description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtProblems
            // 
            this.txtProblems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtProblems.Location = new System.Drawing.Point(12, 525);
            this.txtProblems.Name = "txtProblems";
            this.txtProblems.Size = new System.Drawing.Size(761, 167);
            this.txtProblems.TabIndex = 6;
            this.txtProblems.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.label3.Location = new System.Drawing.Point(221, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Project:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtProject
            // 
            this.txtProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtProject.Location = new System.Drawing.Point(289, 14);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(285, 24);
            this.txtProject.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtQuantity.Location = new System.Drawing.Point(289, 46);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 24);
            this.txtQuantity.TabIndex = 12;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.label4.Location = new System.Drawing.Point(211, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quantity:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.label5.Location = new System.Drawing.Point(375, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Created:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteCreated
            // 
            this.dteCreated.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dteCreated.Enabled = false;
            this.dteCreated.Location = new System.Drawing.Point(453, 48);
            this.dteCreated.Name = "dteCreated";
            this.dteCreated.Size = new System.Drawing.Size(121, 20);
            this.dteCreated.TabIndex = 14;
            // 
            // frmProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 730);
            this.Controls.Add(this.dteCreated);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProblems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRequestedChange);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtIssue);
            this.Name = "frmProblem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProblem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtIssue;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtRequestedChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtProblems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteCreated;
    }
}