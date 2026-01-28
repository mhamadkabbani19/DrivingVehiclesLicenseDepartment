namespace DrivingVehiclesLicense
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tcDriverLicensesData = new System.Windows.Forms.TabControl();
            this.tpLocalPage = new System.Windows.Forms.TabPage();
            this.lblLocalRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPersonLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tpInternationalPage = new System.Windows.Forms.TabPage();
            this.lblInternationalRecordsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPersonInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDriverLicenses.SuspendLayout();
            this.tcDriverLicensesData.SuspendLayout();
            this.tpLocalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonLocalLicenses)).BeginInit();
            this.tpInternationalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonInternationalLicenses)).BeginInit();
            this.cmsLocalLicenses.SuspendLayout();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tcDriverLicensesData);
            this.gbDriverLicenses.Location = new System.Drawing.Point(3, 3);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(932, 307);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tcDriverLicensesData
            // 
            this.tcDriverLicensesData.Controls.Add(this.tpLocalPage);
            this.tcDriverLicensesData.Controls.Add(this.tpInternationalPage);
            this.tcDriverLicensesData.Location = new System.Drawing.Point(6, 30);
            this.tcDriverLicensesData.Name = "tcDriverLicensesData";
            this.tcDriverLicensesData.SelectedIndex = 0;
            this.tcDriverLicensesData.Size = new System.Drawing.Size(925, 278);
            this.tcDriverLicensesData.TabIndex = 4;
            // 
            // tpLocalPage
            // 
            this.tpLocalPage.Controls.Add(this.lblLocalRecordsCount);
            this.tpLocalPage.Controls.Add(this.label3);
            this.tpLocalPage.Controls.Add(this.label2);
            this.tpLocalPage.Controls.Add(this.dgvPersonLocalLicenses);
            this.tpLocalPage.Location = new System.Drawing.Point(4, 25);
            this.tpLocalPage.Name = "tpLocalPage";
            this.tpLocalPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalPage.Size = new System.Drawing.Size(917, 249);
            this.tpLocalPage.TabIndex = 0;
            this.tpLocalPage.Text = "Local";
            this.tpLocalPage.UseVisualStyleBackColor = true;
            // 
            // lblLocalRecordsCount
            // 
            this.lblLocalRecordsCount.AutoSize = true;
            this.lblLocalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecordsCount.Location = new System.Drawing.Point(100, 217);
            this.lblLocalRecordsCount.Name = "lblLocalRecordsCount";
            this.lblLocalRecordsCount.Size = new System.Drawing.Size(51, 20);
            this.lblLocalRecordsCount.TabIndex = 7;
            this.lblLocalRecordsCount.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Records :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Local Driving Licenses :";
            // 
            // dgvPersonLocalLicenses
            // 
            this.dgvPersonLocalLicenses.AllowUserToAddRows = false;
            this.dgvPersonLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvPersonLocalLicenses.AllowUserToOrderColumns = true;
            this.dgvPersonLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonLocalLicenses.ContextMenuStrip = this.cmsLocalLicenses;
            this.dgvPersonLocalLicenses.Location = new System.Drawing.Point(0, 50);
            this.dgvPersonLocalLicenses.Name = "dgvPersonLocalLicenses";
            this.dgvPersonLocalLicenses.ReadOnly = true;
            this.dgvPersonLocalLicenses.RowHeadersWidth = 51;
            this.dgvPersonLocalLicenses.RowTemplate.Height = 24;
            this.dgvPersonLocalLicenses.Size = new System.Drawing.Size(917, 164);
            this.dgvPersonLocalLicenses.TabIndex = 0;
            // 
            // tpInternationalPage
            // 
            this.tpInternationalPage.Controls.Add(this.lblInternationalRecordsCount);
            this.tpInternationalPage.Controls.Add(this.label4);
            this.tpInternationalPage.Controls.Add(this.label1);
            this.tpInternationalPage.Controls.Add(this.dgvPersonInternationalLicenses);
            this.tpInternationalPage.Location = new System.Drawing.Point(4, 25);
            this.tpInternationalPage.Name = "tpInternationalPage";
            this.tpInternationalPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalPage.Size = new System.Drawing.Size(917, 249);
            this.tpInternationalPage.TabIndex = 1;
            this.tpInternationalPage.Text = "International";
            this.tpInternationalPage.UseVisualStyleBackColor = true;
            // 
            // lblInternationalRecordsCount
            // 
            this.lblInternationalRecordsCount.AutoSize = true;
            this.lblInternationalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecordsCount.Location = new System.Drawing.Point(100, 217);
            this.lblInternationalRecordsCount.Name = "lblInternationalRecordsCount";
            this.lblInternationalRecordsCount.Size = new System.Drawing.Size(51, 20);
            this.lblInternationalRecordsCount.TabIndex = 6;
            this.lblInternationalRecordsCount.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Records :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "International Driving Licenses :";
            // 
            // dgvPersonInternationalLicenses
            // 
            this.dgvPersonInternationalLicenses.AllowUserToAddRows = false;
            this.dgvPersonInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvPersonInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvPersonInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicenses;
            this.dgvPersonInternationalLicenses.Location = new System.Drawing.Point(0, 49);
            this.dgvPersonInternationalLicenses.Name = "dgvPersonInternationalLicenses";
            this.dgvPersonInternationalLicenses.ReadOnly = true;
            this.dgvPersonInternationalLicenses.RowHeadersWidth = 51;
            this.dgvPersonInternationalLicenses.RowTemplate.Height = 24;
            this.dgvPersonInternationalLicenses.Size = new System.Drawing.Size(917, 165);
            this.dgvPersonInternationalLicenses.TabIndex = 1;
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenses.Name = "cmsLocalLicenses";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DrivingVehiclesLicense.Properties.Resources.id;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.cmsInternationalLicenses.Name = "cmsInternationalLicenses";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DrivingVehiclesLicense.Properties.Resources.id;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(941, 321);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tcDriverLicensesData.ResumeLayout(false);
            this.tpLocalPage.ResumeLayout(false);
            this.tpLocalPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonLocalLicenses)).EndInit();
            this.tpInternationalPage.ResumeLayout(false);
            this.tpInternationalPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonInternationalLicenses)).EndInit();
            this.cmsLocalLicenses.ResumeLayout(false);
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tcDriverLicensesData;
        private System.Windows.Forms.TabPage tpLocalPage;
        private System.Windows.Forms.DataGridView dgvPersonLocalLicenses;
        private System.Windows.Forms.TabPage tpInternationalPage;
        private System.Windows.Forms.DataGridView dgvPersonInternationalLicenses;
        private System.Windows.Forms.Label lblLocalRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInternationalRecordsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}
