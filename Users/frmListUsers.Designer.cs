namespace DrivingVehiclesLicense
{
    partial class frmListUsers
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmsManageUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCallPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsManageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsManageUsers;
            this.dgvUsers.Location = new System.Drawing.Point(12, 280);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(1142, 370);
            this.dgvUsers.TabIndex = 0;
            // 
            // cmsManageUsers
            // 
            this.cmsManageUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUserDetails,
            this.tsmiAddNewUser,
            this.tsmiEditUser,
            this.tsmiDeleteUser,
            this.tsmiChangePassword,
            this.toolStripMenuItem1,
            this.tsmiSendEmail,
            this.tsmiCallPhone});
            this.cmsManageUsers.Name = "cmsManageUsers";
            this.cmsManageUsers.Size = new System.Drawing.Size(198, 192);
            // 
            // tsmiUserDetails
            // 
            this.tsmiUserDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.view_details;
            this.tsmiUserDetails.Name = "tsmiUserDetails";
            this.tsmiUserDetails.Size = new System.Drawing.Size(197, 26);
            this.tsmiUserDetails.Text = "User Details";
            this.tsmiUserDetails.Click += new System.EventHandler(this.tsmiUserDetails_Click);
            // 
            // tsmiAddNewUser
            // 
            this.tsmiAddNewUser.Image = global::DrivingVehiclesLicense.Properties.Resources.user_add__1_;
            this.tsmiAddNewUser.Name = "tsmiAddNewUser";
            this.tsmiAddNewUser.Size = new System.Drawing.Size(197, 26);
            this.tsmiAddNewUser.Text = "Add User";
            this.tsmiAddNewUser.Click += new System.EventHandler(this.tsmiAddNewUser_Click);
            // 
            // tsmiEditUser
            // 
            this.tsmiEditUser.Image = global::DrivingVehiclesLicense.Properties.Resources.edit;
            this.tsmiEditUser.Name = "tsmiEditUser";
            this.tsmiEditUser.Size = new System.Drawing.Size(197, 26);
            this.tsmiEditUser.Text = "Edit User";
            this.tsmiEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Image = global::DrivingVehiclesLicense.Properties.Resources.delete;
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(197, 26);
            this.tsmiDeleteUser.Text = "Delete User";
            this.tsmiDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Image = global::DrivingVehiclesLicense.Properties.Resources.banner_design;
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(197, 26);
            this.tsmiChangePassword.Text = "Change Password";
            this.tsmiChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Image = global::DrivingVehiclesLicense.Properties.Resources.email;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(197, 26);
            this.tsmiSendEmail.Text = "Send Email";
            // 
            // tsmiCallPhone
            // 
            this.tsmiCallPhone.Image = global::DrivingVehiclesLicense.Properties.Resources.call;
            this.tsmiCallPhone.Name = "tsmiCallPhone";
            this.tsmiCallPhone.Size = new System.Drawing.Size(197, 26);
            this.tsmiCallPhone.Text = "Call Phone";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.White;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "User Name",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(13, 250);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(225, 24);
            this.cbFilterBy.TabIndex = 1;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(245, 251);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(225, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.White;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(245, 249);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(225, 24);
            this.cbIsActive.TabIndex = 3;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRecordsCount.Location = new System.Drawing.Point(122, 661);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(46, 20);
            this.lblRecordsCount.TabIndex = 5;
            this.lblRecordsCount.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingVehiclesLicense.Properties.Resources.users;
            this.pictureBox1.Location = new System.Drawing.Point(477, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(381, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 83);
            this.label2.TabIndex = 7;
            this.label2.Text = "Manage Users";
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Image = global::DrivingVehiclesLicense.Properties.Resources.user_add__1_;
            this.btnAddNewUser.Location = new System.Drawing.Point(1064, 184);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(90, 90);
            this.btnAddNewUser.TabIndex = 8;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 695);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dgvUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsManageUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.ContextMenuStrip cmsManageUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiCallPhone;
    }
}