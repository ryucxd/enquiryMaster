namespace enquiryMaster
{
    partial class frmMessagebox
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
            this.lblTile = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTile
            // 
            this.lblTile.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.lblTile.Location = new System.Drawing.Point(8, 9);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(746, 105);
            this.lblTile.TabIndex = 0;
            this.lblTile.Text = "THERE IS A NEWER ENQUIRY WITH A MATCHING SUBJECT AND EMAIL ADDRESS";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRed
            // 
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblRed.ForeColor = System.Drawing.Color.Red;
            this.lblRed.Location = new System.Drawing.Point(15, 124);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(739, 59);
            this.lblRed.TabIndex = 1;
            this.lblRed.Text = "aaaa";
            this.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnOk.Location = new System.Drawing.Point(294, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(178, 39);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "I UNDERSTAND";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmMessagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 252);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.lblTile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMessagebox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WARNING";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTile;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Button btnOk;
    }
}