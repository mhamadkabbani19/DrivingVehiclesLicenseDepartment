namespace DrivingVehiclesLicense
{
    partial class frmListInternationalLicenses
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnAddNewInternationalDrivingLicense = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingVehiclesLicense.Properties.Resources.papers;
            this.pictureBox1.Location = new System.Drawing.Point(636, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(381, 192);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(249, 22);
            this.txtTarget.TabIndex = 24;
            this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarget_KeyPress);
            // 
            // btnAddNewInternationalDrivingLicense
            // 
            this.btnAddNewInternationalDrivingLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewInternationalDrivingLicense.Image = global::DrivingVehiclesLicense.Properties.Resources.papers__2_;
            this.btnAddNewInternationalDrivingLicense.Location = new System.Drawing.Point(1358, 114);
            this.btnAddNewInternationalDrivingLicense.Name = "btnAddNewInternationalDrivingLicense";
            this.btnAddNewInternationalDrivingLicense.Size = new System.Drawing.Size(123, 103);
            this.btnAddNewInternationalDrivingLicense.TabIndex = 23;
            this.btnAddNewInternationalDrivingLicense.UseVisualStyleBackColor = true;
            this.btnAddNewInternationalDrivingLicense.Click += new System.EventHandler(this.btnAddNewInternationalDrivingLicense_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(126, 192);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(249, 24);
            this.cbFilterBy.TabIndex = 22;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter By :";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenuStrip;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(12, 223);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 24;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1469, 474);
            this.dgvInternationalLicenses.TabIndex = 20;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonDetails,
            this.tsmiShowLicenseDetails,
            this.tsmiShowPersonLicenseHistory});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(269, 82);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.user__1_;
            this.tsmiShowPersonDetails.Name = "tsmiShowPersonDetails";
            this.tsmiShowPersonDetails.Size = new System.Drawing.Size(268, 26);
            this.tsmiShowPersonDetails.Text = "Show Person Details";
            this.tsmiShowPersonDetails.Click += new System.EventHandler(this.tsmiShowPersonDetails_Click);
            // 
            // tsmiShowLicenseDetails
            // 
            this.tsmiShowLicenseDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.id;
            this.tsmiShowLicenseDetails.Name = "tsmiShowLicenseDetails";
            this.tsmiShowLicenseDetails.Size = new System.Drawing.Size(268, 26);
            this.tsmiShowLicenseDetails.Text = "Show License Details";
            this.tsmiShowLicenseDetails.Click += new System.EventHandler(this.tsmiShowLicenseDetails_Click);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::DrivingVehiclesLicense.Properties.Resources.SearchPerson2;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(268, 26);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(411, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 57);
            this.label1.TabIndex = 19;
            this.label1.Text = "International Driving Licenses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 700);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(143, 705);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(50, 22);
            this.lblRecordsCount.TabIndex = 28;
            this.lblRecordsCount.Text = "[???]";
            // 
            // cbIsActive
            // 
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(381, 192);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(121, 24);
            this.cbIsActive.TabIndex = 29;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // frmListInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 747);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btnAddNewInternationalDrivingLicense);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International License";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnAddNewInternationalDrivingLicense;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ComboBox cbIsActive;
    }
}