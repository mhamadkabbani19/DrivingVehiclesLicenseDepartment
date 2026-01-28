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
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtAllDetainedLicenses;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _dtAllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtAllDetainedLicenses;
            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D. ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L. ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D. Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "National No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App. ID";
                dgvDetainedLicenses.Columns[8].Width = 150;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTarget.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Released";

            cbIsReleased.Visible = cbFilterBy.Text != "None" && cbFilterBy.Text == "Is Released";
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "License ID" || cbFilterBy.Text == "Detain ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

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
                _dtAllDetainedLicenses.DefaultView.RowFilter = "";
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "License ID":
                    FilterColumn = "LicenseID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "" || cbFilterBy.Text == "None")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.Text == "License ID" || cbFilterBy.Text == "Detain ID")
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtTarget.Text);
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtTarget.Text);

            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // In the table we know if the License is released or not
            tsmiReleaseDetainedLicense.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmShowPersonInfo frm = new frmShowPersonInfo(license.DriverInfo.PersonID);
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(license.DriverInfo.PersonID);
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }
    }
}
