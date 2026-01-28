using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DrivingVehiclesLicense
{
    public partial class frmListInternationalLicenses : Form
    {
        private DataTable _dtAllInternationalLicenses;

        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _dtAllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtAllInternationalLicenses;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTarget.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active";

            cbIsActive.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text == "Is Active";
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Local License ID":
                    FilterColumn = "LicenseID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "" || cbFilterBy.Text == "None")
            {
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }

            _dtAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtTarget.Text);

            lblRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void btnAddNewInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.FindByDriverID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);

            frmShowPersonInfo frm = new frmShowPersonInfo(driver.PersonID);
            frm.ShowDialog();
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.FindByDriverID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(driver.PersonID);
            frm.ShowDialog();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
            else
                _dtAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }
    }
}
