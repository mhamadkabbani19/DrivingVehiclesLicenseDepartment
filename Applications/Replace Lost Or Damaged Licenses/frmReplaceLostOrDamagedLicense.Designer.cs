namespace DrivingVehiclesLicense
{
    partial class frmReplaceLostOrDamagedLicense
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
            this.btnReplace = new System.Windows.Forms.Button();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.ctrlLicenseDetailsWithFilter1 = new DrivingVehiclesLicense.ctrlDrivingLicenseInfoWithFilter();
            this.gbReplaceFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.gbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbReplaceFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // llblShowLicenseInfo
            // 
            this.llblShowLicenseInfo.AutoSize = true;
            this.llblShowLicenseInfo.Location = new System.Drawing.Point(165, 604);
            this.llblShowLicenseInfo.Name = "llblShowLicenseInfo";
            this.llblShowLicenseInfo.Size = new System.Drawing.Size(114, 16);
            this.llblShowLicenseInfo.TabIndex = 20;
            this.llblShowLicenseInfo.TabStop = true;
            this.llblShowLicenseInfo.Text = "Show License Info";
            this.llblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseInfo_LinkClicked);
            // 
            // llblShowLicenseHistory
            // 
            this.llblShowLicenseHistory.AutoSize = true;
            this.llblShowLicenseHistory.Location = new System.Drawing.Point(17, 604);
            this.llblShowLicenseHistory.Name = "llblShowLicenseHistory";
            this.llblShowLicenseHistory.Size = new System.Drawing.Size(142, 16);
            this.llblShowLicenseHistory.TabIndex = 19;
            this.llblShowLicenseHistory.TabStop = true;
            this.llblShowLicenseHistory.Text = "Show Licenses History";
            this.llblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(796, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 31);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(894, 607);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(92, 31);
            this.btnReplace.TabIndex = 17;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.pictureBox8);
            this.gbApplicationInfo.Controls.Add(this.pictureBox7);
            this.gbApplicationInfo.Controls.Add(this.pictureBox5);
            this.gbApplicationInfo.Controls.Add(this.pictureBox4);
            this.gbApplicationInfo.Controls.Add(this.pictureBox2);
            this.gbApplicationInfo.Controls.Add(this.pictureBox1);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Location = new System.Drawing.Point(20, 470);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(966, 131);
            this.gbApplicationInfo.TabIndex = 16;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(704, 91);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(36, 16);
            this.lblCreatedBy.TabIndex = 23;
            this.lblCreatedBy.Text = "[???]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(704, 62);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(36, 16);
            this.lblOldLicenseID.TabIndex = 21;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(704, 33);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(36, 16);
            this.lblReplacedLicenseID.TabIndex = 20;
            this.lblReplacedLicenseID.Text = "[???]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(178, 91);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(36, 16);
            this.lblApplicationFees.TabIndex = 19;
            this.lblApplicationFees.Text = "[???]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(180, 62);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(36, 16);
            this.lblApplicationDate.TabIndex = 17;
            this.lblApplicationDate.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DrivingVehiclesLicense.Properties.Resources.world;
            this.pictureBox8.Location = new System.Drawing.Point(681, 33);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(17, 16);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DrivingVehiclesLicense.Properties.Resources.user__1_;
            this.pictureBox7.Location = new System.Drawing.Point(681, 91);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(17, 16);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DrivingVehiclesLicense.Properties.Resources.IDCard;
            this.pictureBox5.Location = new System.Drawing.Point(681, 62);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(17, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DrivingVehiclesLicense.Properties.Resources.money;
            this.pictureBox4.Location = new System.Drawing.Point(155, 91);
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
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Location = new System.Drawing.Point(180, 33);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(36, 16);
            this.lblApplicationID.TabIndex = 8;
            this.lblApplicationID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(504, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Created By :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(504, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Old License ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(504, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Replaced License ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "I.L Application ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Application Date :";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(12, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(970, 54);
            this.lblFormTitle.TabIndex = 15;
            this.lblFormTitle.Text = "Replace for Damaged License Application";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlLicenseDetailsWithFilter1
            // 
            this.ctrlLicenseDetailsWithFilter1.FilterEnabled = true;
            this.ctrlLicenseDetailsWithFilter1.Location = new System.Drawing.Point(12, 66);
            this.ctrlLicenseDetailsWithFilter1.Name = "ctrlLicenseDetailsWithFilter1";
            this.ctrlLicenseDetailsWithFilter1.Size = new System.Drawing.Size(970, 397);
            this.ctrlLicenseDetailsWithFilter1.TabIndex = 14;
            this.ctrlLicenseDetailsWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseDetailsWithFilter1_OnLicenseSelected);
            // 
            // gbReplaceFor
            // 
            this.gbReplaceFor.Controls.Add(this.rbLost);
            this.gbReplaceFor.Controls.Add(this.rbDamaged);
            this.gbReplaceFor.Location = new System.Drawing.Point(782, 70);
            this.gbReplaceFor.Name = "gbReplaceFor";
            this.gbReplaceFor.Size = new System.Drawing.Size(195, 93);
            this.gbReplaceFor.TabIndex = 21;
            this.gbReplaceFor.TabStop = false;
            this.gbReplaceFor.Text = "Replacement For";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(11, 60);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(53, 20);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Location = new System.Drawing.Point(11, 26);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(89, 20);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // frmReplaceLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 648);
            this.Controls.Add(this.gbReplaceFor);
            this.Controls.Add(this.llblShowLicenseInfo);
            this.Controls.Add(this.llblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.ctrlLicenseDetailsWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmReplaceLostOrDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement For Lost Or Damaged License";
            this.Load += new System.EventHandler(this.frmReplacementForLostOrDamagedLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbReplaceFor.ResumeLayout(false);
            this.gbReplaceFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormTitle;
        private ctrlDrivingLicenseInfoWithFilter ctrlLicenseDetailsWithFilter1;
        private System.Windows.Forms.GroupBox gbReplaceFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}