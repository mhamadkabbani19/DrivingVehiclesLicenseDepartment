namespace DrivingVehiclesLicense
{
    partial class frmListPeople
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmsManagePeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCallPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmsManagePeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(451, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage People";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmsManagePeople;
            this.dgvPeople.Location = new System.Drawing.Point(12, 211);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.Size = new System.Drawing.Size(1374, 474);
            this.dgvPeople.TabIndex = 1;
            // 
            // cmsManagePeople
            // 
            this.cmsManagePeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManagePeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowDetails,
            this.tsmiAddNewPerson,
            this.tsmiEditPerson,
            this.tsmiDeletePerson,
            this.toolStripMenuItem1,
            this.tsmiSendEmail,
            this.tsmiCallPhone});
            this.cmsManagePeople.Name = "cmsManagePeople";
            this.cmsManagePeople.Size = new System.Drawing.Size(192, 166);
            this.cmsManagePeople.Text = "Manage People";
            // 
            // tsmiShowDetails
            // 
            this.tsmiShowDetails.Image = global::DrivingVehiclesLicense.Properties.Resources.view_details;
            this.tsmiShowDetails.Name = "tsmiShowDetails";
            this.tsmiShowDetails.Size = new System.Drawing.Size(191, 26);
            this.tsmiShowDetails.Text = "Show Details";
            this.tsmiShowDetails.Click += new System.EventHandler(this.tsmiShowDetails_Click);
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Image = global::DrivingVehiclesLicense.Properties.Resources.AddNewPerson;
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(191, 26);
            this.tsmiAddNewPerson.Text = "Add New Person";
            this.tsmiAddNewPerson.Click += new System.EventHandler(this.tsmiAddNewPerson_Click);
            // 
            // tsmiEditPerson
            // 
            this.tsmiEditPerson.Image = global::DrivingVehiclesLicense.Properties.Resources.edit;
            this.tsmiEditPerson.Name = "tsmiEditPerson";
            this.tsmiEditPerson.Size = new System.Drawing.Size(191, 26);
            this.tsmiEditPerson.Text = "Edit";
            this.tsmiEditPerson.Click += new System.EventHandler(this.tsmiEditPerson_Click);
            // 
            // tsmiDeletePerson
            // 
            this.tsmiDeletePerson.Image = global::DrivingVehiclesLicense.Properties.Resources.delete;
            this.tsmiDeletePerson.Name = "tsmiDeletePerson";
            this.tsmiDeletePerson.Size = new System.Drawing.Size(191, 26);
            this.tsmiDeletePerson.Text = "Delete";
            this.tsmiDeletePerson.Click += new System.EventHandler(this.tsmiDeletePerson_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Image = global::DrivingVehiclesLicense.Properties.Resources.email;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(191, 26);
            this.tsmiSendEmail.Text = "Send Email";
            this.tsmiSendEmail.Click += new System.EventHandler(this.tsmiSendEmail_Click);
            // 
            // tsmiCallPhone
            // 
            this.tsmiCallPhone.Image = global::DrivingVehiclesLicense.Properties.Resources.call;
            this.tsmiCallPhone.Name = "tsmiCallPhone";
            this.tsmiCallPhone.Size = new System.Drawing.Size(191, 26);
            this.tsmiCallPhone.Text = "Call Phone";
            this.tsmiCallPhone.Click += new System.EventHandler(this.tsmiCallPhone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(131, 170);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(249, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewPerson.Image = global::DrivingVehiclesLicense.Properties.Resources.AddNewPerson;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1277, 115);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(109, 90);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 699);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(105, 699);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(51, 20);
            this.lblRecordsCount.TabIndex = 7;
            this.lblRecordsCount.Text = "[???]";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(395, 173);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(249, 22);
            this.txtTarget.TabIndex = 8;
            this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarget_KeyPress);
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 746);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmListPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmsManagePeople.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmsManagePeople;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiCallPhone;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.TextBox txtTarget;
    }
}