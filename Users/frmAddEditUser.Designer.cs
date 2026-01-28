namespace DrivingVehiclesLicense
{
    partial class frmAddEditUser
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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonData = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonDetailsWithFilter = new DrivingVehiclesLicense.ctrlPersonCardWithFilter();
            this.tpUserData = new System.Windows.Forms.TabPage();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcUserInfo.SuspendLayout();
            this.tpPersonData.SuspendLayout();
            this.tpUserData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonData);
            this.tcUserInfo.Controls.Add(this.tpUserData);
            this.tcUserInfo.Location = new System.Drawing.Point(12, 64);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(927, 425);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tpPersonData
            // 
            this.tpPersonData.Controls.Add(this.btnNext);
            this.tpPersonData.Controls.Add(this.ctrlPersonDetailsWithFilter);
            this.tpPersonData.Location = new System.Drawing.Point(4, 25);
            this.tpPersonData.Name = "tpPersonData";
            this.tpPersonData.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonData.Size = new System.Drawing.Size(919, 396);
            this.tpPersonData.TabIndex = 0;
            this.tpPersonData.Text = "PersonData";
            this.tpPersonData.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(820, 351);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 35);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonDetailsWithFilter
            // 
            this.ctrlPersonDetailsWithFilter.FilterEnabled = true;
            this.ctrlPersonDetailsWithFilter.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonDetailsWithFilter.Name = "ctrlPersonDetailsWithFilter";
            this.ctrlPersonDetailsWithFilter.ShowAddPerson = true;
            this.ctrlPersonDetailsWithFilter.Size = new System.Drawing.Size(908, 339);
            this.ctrlPersonDetailsWithFilter.TabIndex = 0;
            // 
            // tpUserData
            // 
            this.tpUserData.Controls.Add(this.lblUserID);
            this.tpUserData.Controls.Add(this.label4);
            this.tpUserData.Controls.Add(this.cbIsActive);
            this.tpUserData.Controls.Add(this.txtUserName);
            this.tpUserData.Controls.Add(this.txtPassword);
            this.tpUserData.Controls.Add(this.txtConfirmPassword);
            this.tpUserData.Controls.Add(this.label3);
            this.tpUserData.Controls.Add(this.label2);
            this.tpUserData.Controls.Add(this.label1);
            this.tpUserData.Location = new System.Drawing.Point(4, 25);
            this.tpUserData.Name = "tpUserData";
            this.tpUserData.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserData.Size = new System.Drawing.Size(919, 396);
            this.tpUserData.TabIndex = 1;
            this.tpUserData.Text = "UserData";
            this.tpUserData.UseVisualStyleBackColor = true;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(244, 37);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(57, 25);
            this.lblUserID.TabIndex = 9;
            this.lblUserID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "User ID :";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(249, 249);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(79, 20);
            this.cbIsActive.TabIndex = 6;
            this.cbIsActive.Text = "Is Active";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(249, 88);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(211, 22);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(249, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(211, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(249, 197);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(211, 22);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(841, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(741, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(309, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(312, 52);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Add New User";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 538);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonData.ResumeLayout(false);
            this.tpUserData.ResumeLayout(false);
            this.tpUserData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonData;
        private ctrlPersonCardWithFilter ctrlPersonDetailsWithFilter;
        private System.Windows.Forms.TabPage tpUserData;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
    }
}