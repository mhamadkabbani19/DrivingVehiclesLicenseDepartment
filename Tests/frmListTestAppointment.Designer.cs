namespace DrivingVehiclesLicense
{
    partial class frmListTestAppointment
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
            this.components = new System.ComponentModel.Container();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseApplicationInfo1 = new DrivingVehiclesLicense.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(273, 131);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(306, 38);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Test Appointments";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.contextMenuStrip;
            this.dgvAppointments.Location = new System.Drawing.Point(13, 578);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(846, 165);
            this.dgvAppointments.TabIndex = 3;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditAppointment,
            this.tsmiTakeTest});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(142, 56);
            // 
            // tsmiEditAppointment
            // 
            this.tsmiEditAppointment.Image = global::DrivingVehiclesLicense.Properties.Resources.edit;
            this.tsmiEditAppointment.Name = "tsmiEditAppointment";
            this.tsmiEditAppointment.Size = new System.Drawing.Size(141, 26);
            this.tsmiEditAppointment.Text = "Edit";
            this.tsmiEditAppointment.Click += new System.EventHandler(this.tsmiEditAppointment_Click);
            // 
            // tsmiTakeTest
            // 
            this.tsmiTakeTest.Image = global::DrivingVehiclesLicense.Properties.Resources.test;
            this.tsmiTakeTest.Name = "tsmiTakeTest";
            this.tsmiTakeTest.Size = new System.Drawing.Size(141, 26);
            this.tsmiTakeTest.Text = "Take Test";
            this.tsmiTakeTest.Click += new System.EventHandler(this.tsmiTakeTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 746);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(115, 750);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(36, 16);
            this.lblRecordsCount.TabIndex = 6;
            this.lblRecordsCount.Text = "[???]";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Image = global::DrivingVehiclesLicense.Properties.Resources.test_add__2_;
            this.btnAddAppointment.Location = new System.Drawing.Point(823, 542);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(35, 32);
            this.btnAddAppointment.TabIndex = 7;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // pbTestImage
            // 
            this.pbTestImage.Location = new System.Drawing.Point(371, 12);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(106, 98);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 1;
            this.pbTestImage.TabStop = false;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 172);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(847, 375);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frmListTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 772);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pbTestImage);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointment";
            this.Load += new System.EventHandler(this.frmTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditAppointment;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakeTest;
    }
}