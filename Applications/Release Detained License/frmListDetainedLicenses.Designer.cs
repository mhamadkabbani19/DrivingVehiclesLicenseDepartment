namespace DrivingVehiclesLicense
{
    partial class frmListDetainedLicenses
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
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(379, 219);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(249, 24);
            this.cbIsReleased.TabIndex = 26;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingVehiclesLicense.Properties.Resources.id__1_;
            this.pictureBox1.Location = new System.Drawing.Point(625, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(379, 218);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(249, 22);
            this.txtTarget.TabIndex = 24;
            this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarget_KeyPress);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDetainLicense.Image = global::DrivingVehiclesLicense.Properties.Resources.id__1_;
            this.btnDetainLicense.Location = new System.Drawing.Point(1372, 140);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(123, 103);
            this.btnDetainLicense.TabIndex = 23;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "License ID",
            "National No.",
            "Full Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(124, 218);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(249, 24);
            this.cbFilterBy.TabIndex = 22;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter By :";
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.contextMenuStrip;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(5, 249);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.RowHeadersWidth = 51;
            this.dgvDetainedLicenses.RowTemplate.Height = 24;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1490, 467);
            this.dgvDetainedLicenses.TabIndex = 20;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonDetails,
            this.tsmiShowLicenseDetails,
            this.tsmiShowPersonLicenseHistory,
            this.toolStripSeparator1,
            this.tsmiReleaseDetainedLicense});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(269, 114);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.person_man;
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
            this.tsmiShowPersonLicenseHistory.Image = global::DrivingVehiclesLicense.Properties.Resources.user_clock;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(268, 26);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // tsmiReleaseDetainedLicense
            // 
            this.tsmiReleaseDetainedLicense.Image = global::DrivingVehiclesLicense.Properties.Resources.card__3_;
            this.tsmiReleaseDetainedLicense.Name = "tsmiReleaseDetainedLicense";
            this.tsmiReleaseDetainedLicense.Size = new System.Drawing.Size(268, 26);
            this.tsmiReleaseDetainedLicense.Text = "Release Detained License";
            this.tsmiReleaseDetainedLicense.Click += new System.EventHandler(this.tsmiReleaseDetainedLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(532, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 57);
            this.label1.TabIndex = 19;
            this.label1.Text = "Detained Licenses";
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReleaseLicense.Image = global::DrivingVehiclesLicense.Properties.Resources.card__3_;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1243, 140);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(123, 103);
            this.btnReleaseLicense.TabIndex = 27;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 719);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(107, 723);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(40, 18);
            this.lblRecordsCount.TabIndex = 29;
            this.lblRecordsCount.Text = "[???]";
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 747);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}