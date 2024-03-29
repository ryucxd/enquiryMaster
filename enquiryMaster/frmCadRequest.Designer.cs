﻿namespace enquiryMaster
{
    partial class frmCadRequest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richNote = new System.Windows.Forms.RichTextBox();
            this.txtDrawingsRequired = new System.Windows.Forms.TextBox();
            this.chkCadRevision = new System.Windows.Forms.CheckBox();
            this.chkExistingOrder = new System.Windows.Forms.CheckBox();
            this.dteCad = new System.Windows.Forms.DateTimePicker();
            this.btnCAD = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUrgent = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total CAD drawings required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Are these CAD drawings revisions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Existing Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "CAD due date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Note:";
            // 
            // richNote
            // 
            this.richNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richNote.Location = new System.Drawing.Point(27, 149);
            this.richNote.Name = "richNote";
            this.richNote.Size = new System.Drawing.Size(337, 96);
            this.richNote.TabIndex = 5;
            this.richNote.Text = "";
            this.richNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richNote_KeyDown);
            // 
            // txtDrawingsRequired
            // 
            this.txtDrawingsRequired.Location = new System.Drawing.Point(228, 22);
            this.txtDrawingsRequired.Name = "txtDrawingsRequired";
            this.txtDrawingsRequired.Size = new System.Drawing.Size(100, 20);
            this.txtDrawingsRequired.TabIndex = 6;
            this.txtDrawingsRequired.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrawingsRequired_KeyPress);
            // 
            // chkCadRevision
            // 
            this.chkCadRevision.AutoSize = true;
            this.chkCadRevision.Location = new System.Drawing.Point(237, 46);
            this.chkCadRevision.Name = "chkCadRevision";
            this.chkCadRevision.Size = new System.Drawing.Size(15, 14);
            this.chkCadRevision.TabIndex = 7;
            this.chkCadRevision.UseVisualStyleBackColor = true;
            // 
            // chkExistingOrder
            // 
            this.chkExistingOrder.AutoSize = true;
            this.chkExistingOrder.Location = new System.Drawing.Point(237, 70);
            this.chkExistingOrder.Name = "chkExistingOrder";
            this.chkExistingOrder.Size = new System.Drawing.Size(15, 14);
            this.chkExistingOrder.TabIndex = 9;
            this.chkExistingOrder.UseVisualStyleBackColor = true;
            // 
            // dteCad
            // 
            this.dteCad.Location = new System.Drawing.Point(193, 114);
            this.dteCad.Name = "dteCad";
            this.dteCad.Size = new System.Drawing.Size(135, 20);
            this.dteCad.TabIndex = 10;
            // 
            // btnCAD
            // 
            this.btnCAD.Location = new System.Drawing.Point(200, 251);
            this.btnCAD.Name = "btnCAD";
            this.btnCAD.Size = new System.Drawing.Size(93, 23);
            this.btnCAD.TabIndex = 11;
            this.btnCAD.Text = "Request CAD";
            this.btnCAD.UseVisualStyleBackColor = true;
            this.btnCAD.Click += new System.EventHandler(this.btnCAD_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(83, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkUrgent
            // 
            this.chkUrgent.AutoSize = true;
            this.chkUrgent.Location = new System.Drawing.Point(237, 94);
            this.chkUrgent.Name = "chkUrgent";
            this.chkUrgent.Size = new System.Drawing.Size(15, 14);
            this.chkUrgent.TabIndex = 14;
            this.chkUrgent.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Urgent Job";
            // 
            // frmCadRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 277);
            this.ControlBox = false;
            this.Controls.Add(this.chkUrgent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCAD);
            this.Controls.Add(this.dteCad);
            this.Controls.Add(this.chkExistingOrder);
            this.Controls.Add(this.chkCadRevision);
            this.Controls.Add(this.txtDrawingsRequired);
            this.Controls.Add(this.richNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCadRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CAD Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richNote;
        private System.Windows.Forms.TextBox txtDrawingsRequired;
        private System.Windows.Forms.CheckBox chkCadRevision;
        private System.Windows.Forms.CheckBox chkExistingOrder;
        private System.Windows.Forms.DateTimePicker dteCad;
        private System.Windows.Forms.Button btnCAD;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkUrgent;
        private System.Windows.Forms.Label label6;
    }
}