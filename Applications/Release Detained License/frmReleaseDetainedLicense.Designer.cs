namespace DrivingVehiclesLicense
{
    partial class frmReleaseDetainedLicense
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
            this.llblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblApplcationID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.ctrlLicenseDetailsWithFilter1 = new DrivingVehiclesLicense.ctrlDrivingLicenseInfoWithFilter();
            this.gbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // llblShowLicenseInfo
            // 
            this.llblShowLicenseInfo.AutoSize = true;
            this.llblShowLicenseInfo.Location = new System.Drawing.Point(160, 616);
            this.llblShowLicenseInfo.Name = "llblShowLicenseInfo";
            this.llblShowLicenseInfo.Size = new System.Drawing.Size(114, 16);
            this.llblShowLicenseInfo.TabIndex = 35;
            this.llblShowLicenseInfo.TabStop = true;
            this.llblShowLicenseInfo.Text = "Show License Info";
            this.llblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseInfo_LinkClicked);
            // 
            // llblShowLicenseHistory
            // 
            this.llblShowLicenseHistory.AutoSize = true;
            this.llblShowLicenseHistory.Location = new System.Drawing.Point(12, 616);
            this.llblShowLicenseHistory.Name = "llblShowLicenseHistory";
            this.llblShowLicenseHistory.Size = new System.Drawing.Size(142, 16);
            this.llblShowLicenseHistory.TabIndex = 34;
            this.llblShowLicenseHistory.TabStop = true;
            this.llblShowLicenseHistory.Text = "Show Licenses History";
            this.llblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(792, 619);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 31);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Enabled = false;
            this.btnRelease.Location = new System.Drawing.Point(890, 619);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(92, 31);
            this.btnRelease.TabIndex = 32;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lblApplcationID);
            this.gbApplicationInfo.Controls.Add(this.pictureBox8);
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbApplicationInfo.Controls.Add(this.pictureBox6);
            this.gbApplicationInfo.Controls.Add(this.label1);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.pictureBox3);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.lblFineFees);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbApplicationInfo.Controls.Add(this.pictureBox7);
            this.gbApplicationInfo.Controls.Add(this.pictureBox5);
            this.gbApplicationInfo.Controls.Add(this.pictureBox4);
            this.gbApplicationInfo.Controls.Add(this.pictureBox2);
            this.gbApplicationInfo.Controls.Add(this.pictureBox1);
            this.gbApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 460);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(966, 153);
            this.gbApplicationInfo.TabIndex = 31;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info";
            // 
            // lblApplcationID
            // 
            this.lblApplcationID.AutoSize = true;
            this.lblApplcationID.Location = new System.Drawing.Point(707, 121);
            this.lblApplcationID.Name = "lblApplcationID";
            this.lblApplcationID.Size = new System.Drawing.Size(36, 16);
            this.lblApplcationID.TabIndex = 33;
            this.lblApplcationID.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DrivingVehiclesLicense.Properties.Resources.papers;
            this.pictureBox8.Location = new System.Drawing.Point(682, 121);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(17, 16);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 32;
            this.pictureBox8.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(505, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Application ID :";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(182, 121);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(36, 16);
            this.lblTotalFees.TabIndex = 30;
            this.lblTotalFees.Text = "[???]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DrivingVehiclesLicense.Properties.Resources.money;
            this.pictureBox6.Location = new System.Drawing.Point(157, 121);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(17, 16);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 29;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Total Fees :";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(182, 92);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(36, 16);
            this.lblApplicationFees.TabIndex = 27;
            this.lblApplicationFees.Text = "[???]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DrivingVehiclesLicense.Properties.Resources.money;
            this.pictureBox3.Location = new System.Drawing.Point(157, 92);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Application Fees :";
            // 
            // lblFineFees
            // 
            this.lblFineFees.AutoSize = true;
            this.lblFineFees.Location = new System.Drawing.Point(707, 92);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(36, 16);
            this.lblFineFees.TabIndex = 24;
            this.lblFineFees.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(705, 62);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(36, 16);
            this.lblCreatedBy.TabIndex = 23;
            this.lblCreatedBy.Text = "[???]";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Location = new System.Drawing.Point(705, 33);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(36, 16);
            this.lblLicenseID.TabIndex = 21;
            this.lblLicenseID.Text = "[???]";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Location = new System.Drawing.Point(180, 62);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(36, 16);
            this.lblDetainDate.TabIndex = 17;
            this.lblDetainDate.Text = "[???]";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DrivingVehiclesLicense.Properties.Resources.user__1_;
            this.pictureBox7.Location = new System.Drawing.Point(682, 62);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(17, 16);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DrivingVehiclesLicense.Properties.Resources.IDCard;
            this.pictureBox5.Location = new System.Drawing.Point(682, 33);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(17, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DrivingVehiclesLicense.Properties.Resources.money;
            this.pictureBox4.Location = new System.Drawing.Point(682, 92);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(17, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrivingVehiclesLicense.Properties.Resources.field_date;
            this.pictureBox2.Location = new System.Drawing.Point(157, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingVehiclesLicense.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(157, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Location = new System.Drawing.Point(180, 33);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(36, 16);
            this.lblDetainID.TabIndex = 8;
            this.lblDetainID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Created By :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(505, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "License ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(505, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fine Fees :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Detain ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detain Date :";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(186, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(592, 54);
            this.lblFormTitle.TabIndex = 30;
            this.lblFormTitle.Text = "Release Detained License";
            // 
            // ctrlLicenseDetailsWithFilter1
            // 
            this.ctrlLicenseDetailsWithFilter1.FilterEnabled = true;
            this.ctrlLicenseDetailsWithFilter1.Location = new System.Drawing.Point(12, 66);
            this.ctrlLicenseDetailsWithFilter1.Name = "ctrlLicenseDetailsWithFilter1";
            this.ctrlLicenseDetailsWithFilter1.Size = new System.Drawing.Size(970, 397);
            this.ctrlLicenseDetailsWithFilter1.TabIndex = 29;
            this.ctrlLicenseDetailsWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseDetailsWithFilter1_OnLicenseSelected);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 655);
            this.Controls.Add(this.llblShowLicenseInfo);
            this.Controls.Add(this.llblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.ctrlLicenseDetailsWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License";
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormTitle;
        private ctrlDrivingLicenseInfoWithFilter ctrlLicenseDetailsWithFilter1;
        private System.Windows.Forms.Label lblApplcationID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFineFees;
    }
}