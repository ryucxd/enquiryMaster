namespace enquiryMaster
{
    partial class frmAllocateStaff
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEstimating = new System.Windows.Forms.DataGridView();
            this.dgvCAD = new System.Windows.Forms.DataGridView();
            this.dgvSlimlineEstimating = new System.Windows.Forms.DataGridView();
            this.dgvSlimlineCAD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAllocate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlimlineEstimating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlimlineCAD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstimating
            // 
            this.dgvEstimating.AllowUserToAddRows = false;
            this.dgvEstimating.AllowUserToDeleteRows = false;
            this.dgvEstimating.AllowUserToResizeColumns = false;
            this.dgvEstimating.AllowUserToResizeRows = false;
            this.dgvEstimating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstimating.Location = new System.Drawing.Point(12, 59);
            this.dgvEstimating.Name = "dgvEstimating";
            this.dgvEstimating.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstimating.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEstimating.RowHeadersVisible = false;
            this.dgvEstimating.Size = new System.Drawing.Size(208, 230);
            this.dgvEstimating.TabIndex = 0;
            this.dgvEstimating.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstimating_CellClick);
            this.dgvEstimating.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstimating_CellDoubleClick);
            // 
            // dgvCAD
            // 
            this.dgvCAD.AllowUserToAddRows = false;
            this.dgvCAD.AllowUserToDeleteRows = false;
            this.dgvCAD.AllowUserToResizeColumns = false;
            this.dgvCAD.AllowUserToResizeRows = false;
            this.dgvCAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCAD.Location = new System.Drawing.Point(229, 59);
            this.dgvCAD.Name = "dgvCAD";
            this.dgvCAD.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCAD.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCAD.RowHeadersVisible = false;
            this.dgvCAD.Size = new System.Drawing.Size(208, 230);
            this.dgvCAD.TabIndex = 1;
            this.dgvCAD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCAD_CellDoubleClick);
            // 
            // dgvSlimlineEstimating
            // 
            this.dgvSlimlineEstimating.AllowUserToAddRows = false;
            this.dgvSlimlineEstimating.AllowUserToDeleteRows = false;
            this.dgvSlimlineEstimating.AllowUserToResizeColumns = false;
            this.dgvSlimlineEstimating.AllowUserToResizeRows = false;
            this.dgvSlimlineEstimating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSlimlineEstimating.Location = new System.Drawing.Point(460, 59);
            this.dgvSlimlineEstimating.Name = "dgvSlimlineEstimating";
            this.dgvSlimlineEstimating.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlimlineEstimating.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSlimlineEstimating.RowHeadersVisible = false;
            this.dgvSlimlineEstimating.Size = new System.Drawing.Size(208, 230);
            this.dgvSlimlineEstimating.TabIndex = 2;
            this.dgvSlimlineEstimating.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlimlineEstimating_CellClick);
            this.dgvSlimlineEstimating.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlimlineEstimating_CellDoubleClick);
            // 
            // dgvSlimlineCAD
            // 
            this.dgvSlimlineCAD.AllowUserToAddRows = false;
            this.dgvSlimlineCAD.AllowUserToDeleteRows = false;
            this.dgvSlimlineCAD.AllowUserToResizeColumns = false;
            this.dgvSlimlineCAD.AllowUserToResizeRows = false;
            this.dgvSlimlineCAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSlimlineCAD.Location = new System.Drawing.Point(677, 59);
            this.dgvSlimlineCAD.Name = "dgvSlimlineCAD";
            this.dgvSlimlineCAD.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlimlineCAD.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSlimlineCAD.RowHeadersVisible = false;
            this.dgvSlimlineCAD.Size = new System.Drawing.Size(208, 230);
            this.dgvSlimlineCAD.TabIndex = 3;
            this.dgvSlimlineCAD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlimlineCAD_CellClick);
            this.dgvSlimlineCAD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlimlineCAD_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estimating";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "CAD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(677, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Slimline CAD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(460, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Slimline Estimating";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnAllocate
            // 
            this.btnAllocate.Location = new System.Drawing.Point(810, 295);
            this.btnAllocate.Name = "btnAllocate";
            this.btnAllocate.Size = new System.Drawing.Size(75, 23);
            this.btnAllocate.TabIndex = 8;
            this.btnAllocate.Text = "Allocate";
            this.btnAllocate.UseVisualStyleBackColor = true;
            this.btnAllocate.Click += new System.EventHandler(this.btnAllocate_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(565, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 72;
            this.label17.Text = "     ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(593, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 16);
            this.label14.TabIndex = 71;
            this.label14.Text = "Allocated";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(869, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "Double click a user to allocate them!";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(62, 9);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(105, 23);
            this.btnCustomer.TabIndex = 74;
            this.btnCustomer.Text = "Customer Specific";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // frmAllocateStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 323);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnAllocate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSlimlineCAD);
            this.Controls.Add(this.dgvSlimlineEstimating);
            this.Controls.Add(this.dgvCAD);
            this.Controls.Add(this.dgvEstimating);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllocateStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Allocate Staff";
            this.Shown += new System.EventHandler(this.frmAllocateStaff_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlimlineEstimating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlimlineCAD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstimating;
        private System.Windows.Forms.DataGridView dgvCAD;
        private System.Windows.Forms.DataGridView dgvSlimlineEstimating;
        private System.Windows.Forms.DataGridView dgvSlimlineCAD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAllocate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCustomer;
    }
}