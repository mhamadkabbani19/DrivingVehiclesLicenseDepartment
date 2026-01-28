namespace DrivingVehiclesLicense
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchedultVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(386, 204);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(249, 22);
            this.txtTarget.TabIndex = 14;
            this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarget_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(131, 204);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(249, 24);
            this.cbFilterBy.TabIndex = 12;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By :";
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.contextMenuStrip;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 235);
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 24;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1490, 474);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 10;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowApplicationDetails,
            this.toolStripMenuItem1,
            this.tsmiEditApplication,
            this.tsmiDeleteApplication,
            this.tsmiCancelApplication,
            this.toolStripMenuItem2,
            this.tsmiSechduleTests,
            this.toolStripMenuItem3,
            this.tsmiIssueDrivingLicenseFirstTime,
            this.toolStripSeparator1,
            this.tsmiShowLicense,
            this.toolStripSeparator2,
            this.tsmiShowPersonLicenseHistory});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(297, 242);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsmiShowApplicationDetails
            // 
            this.tsmiShowApplicationDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.view_details;
            this.tsmiShowApplicationDetails.Name = "tsmiShowApplicationDetails";
            this.tsmiShowApplicationDetails.Size = new System.Drawing.Size(296, 26);
            this.tsmiShowApplicationDetails.Text = "Show Application Details";
            this.tsmiShowApplicationDetails.Click += new System.EventHandler(this.tsmiShowApplicationDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(293, 6);
            // 
            // tsmiEditApplication
            // 
            this.tsmiEditApplication.Image = global::DrivingVehiclesLicense.Properties.Resources.banner_design;
            this.tsmiEditApplication.Name = "tsmiEditApplication";
            this.tsmiEditApplication.Size = new System.Drawing.Size(296, 26);
            this.tsmiEditApplication.Text = "Edit Application";
            this.tsmiEditApplication.Click += new System.EventHandler(this.tsmiEditApplication_Click);
            // 
            // tsmiDeleteApplication
            // 
            this.tsmiDeleteApplication.Image = global::DrivingVehiclesLicense.Properties.Resources.delete;
            this.tsmiDeleteApplication.Name = "tsmiDeleteApplication";
            this.tsmiDeleteApplication.Size = new System.Drawing.Size(296, 26);
            this.tsmiDeleteApplication.Text = "Delete Application";
            this.tsmiDeleteApplication.Click += new System.EventHandler(this.tsmiDeleteApplication_Click);
            // 
            // tsmiCancelApplication
            // 
            this.tsmiCancelApplication.Image = global::DrivingVehiclesLicense.Properties.Resources.cancel;
            this.tsmiCancelApplication.Name = "tsmiCancelApplication";
            this.tsmiCancelApplication.Size = new System.Drawing.Size(296, 26);
            this.tsmiCancelApplication.Text = "Cancel Application";
            this.tsmiCancelApplication.Click += new System.EventHandler(this.tsmiCancelApplication_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(293, 6);
            // 
            // tsmiSechduleTests
            // 
            this.tsmiSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSchedultVisionTest,
            this.tsmiScheduleWrittenTest,
            this.tsmiScheduleStreetTest});
            this.tsmiSechduleTests.Image = global::DrivingVehiclesLicense.Properties.Resources.test;
            this.tsmiSechduleTests.Name = "tsmiSechduleTests";
            this.tsmiSechduleTests.Size = new System.Drawing.Size(296, 26);
            this.tsmiSechduleTests.Text = "Schedule Tests";
            // 
            // tsmiSchedultVisionTest
            // 
            this.tsmiSchedultVisionTest.Image = global::DrivingVehiclesLicense.Properties.Resources.eye_open;
            this.tsmiSchedultVisionTest.Name = "tsmiSchedultVisionTest";
            this.tsmiSchedultVisionTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiSchedultVisionTest.Text = "Schedule Vision Test";
            this.tsmiSchedultVisionTest.Click += new System.EventHandler(this.tsmiSchedultVisionTest_Click);
            // 
            // tsmiScheduleWrittenTest
            // 
            this.tsmiScheduleWrittenTest.Image = global::DrivingVehiclesLicense.Properties.Resources.edit;
            this.tsmiScheduleWrittenTest.Name = "tsmiScheduleWrittenTest";
            this.tsmiScheduleWrittenTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiScheduleWrittenTest.Text = "Schedule Written Test";
            this.tsmiScheduleWrittenTest.Click += new System.EventHandler(this.tsmiScheduleWrittenTest_Click);
            // 
            // tsmiScheduleStreetTest
            // 
            this.tsmiScheduleStreetTest.Image = global::DrivingVehiclesLicense.Properties.Resources.street_racing;
            this.tsmiScheduleStreetTest.Name = "tsmiScheduleStreetTest";
            this.tsmiScheduleStreetTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiScheduleStreetTest.Text = "Schedule Street Test";
            this.tsmiScheduleStreetTest.Click += new System.EventHandler(this.tsmiScheduleStreetTest_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(293, 6);
            // 
            // tsmiIssueDrivingLicenseFirstTime
            // 
            this.tsmiIssueDrivingLicenseFirstTime.Image = global::DrivingVehiclesLicense.Properties.Resources.IDCard;
            this.tsmiIssueDrivingLicenseFirstTime.Name = "tsmiIssueDrivingLicenseFirstTime";
            this.tsmiIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(296, 26);
            this.tsmiIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.tsmiIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.tsmiIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Image = global::DrivingVehiclesLicense.Properties.Resources.id;
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(296, 26);
            this.tsmiShowLicense.Text = "Show License";
            this.tsmiShowLicense.Click += new System.EventHandler(this.tsmiShowLicense_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(293, 6);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::DrivingVehiclesLicense.Properties.Resources.SearchPerson;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(296, 26);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(376, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(697, 57);
            this.label1.TabIndex = 9;
            this.label1.Text = "Local Driving License Applications";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(109, 712);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(51, 20);
            this.lblRecordsCount.TabIndex = 17;
            this.lblRecordsCount.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 712);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Records :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingVehiclesLicense.Properties.Resources.papers__1_;
            this.pictureBox1.Location = new System.Drawing.Point(643, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewLocalDrivingLicenseApplication.Image = global::DrivingVehiclesLicense.Properties.Resources.papers__2_;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1379, 126);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(123, 103);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 13;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 761);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchedultVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleStreetTest;
    }
}