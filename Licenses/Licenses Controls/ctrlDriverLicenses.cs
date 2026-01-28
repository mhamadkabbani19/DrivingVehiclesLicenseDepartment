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
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDriver _driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenses()
        {
            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);
            dgvPersonLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalRecordsCount.Text = dgvPersonLocalLicenses.Rows.Count.ToString();

            if (dgvPersonLocalLicenses.Rows.Count > 0)
            {
                dgvPersonLocalLicenses.Columns[0].HeaderText = "Lic. ID";
                dgvPersonLocalLicenses.Columns[0].Width = 110;

                dgvPersonLocalLicenses.Columns[1].HeaderText = "App. ID";
                dgvPersonLocalLicenses.Columns[1].Width = 110;

                dgvPersonLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvPersonLocalLicenses.Columns[2].Width = 270;

                dgvPersonLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvPersonLocalLicenses.Columns[3].Width = 170;

                dgvPersonLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvPersonLocalLicenses.Columns[4].Width = 170;

                dgvPersonLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvPersonLocalLicenses.Columns[5].Width = 110;
            }
        }

        private void _LoadInternationalLicenses()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);
            dgvPersonInternationalLicenses.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalRecordsCount.Text = dgvPersonLocalLicenses.Rows.Count.ToString();

            if (dgvPersonInternationalLicenses.Rows.Count > 0)
            {
                dgvPersonInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvPersonInternationalLicenses.Columns[0].Width = 160;

                dgvPersonInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvPersonInternationalLicenses.Columns[1].Width = 130;

                dgvPersonInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvPersonInternationalLicenses.Columns[2].Width = 130;

                dgvPersonInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvPersonInternationalLicenses.Columns[3].Width = 180;

                dgvPersonInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvPersonInternationalLicenses.Columns[4].Width = 180;

                dgvPersonInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvPersonInternationalLicenses.Columns[5].Width = 120;
            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _driver = clsDriver.FindByDriverID(DriverID);

            if (_driver == null)
            {
                MessageBox.Show("Could not find Driver With ID = " + DriverID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If we reach here, Then we have a driver and he of course has Licenses
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _driver = clsDriver.FindByPersonID(PersonID);

            if (_driver == null)
            {
                MessageBox.Show("Could not find Person With ID = " + PersonID.ToString() + " Linked with Driver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _driver.DriverID;

            // If we reach here, Then we have a driver and he of course has Licenses
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvPersonLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvPersonInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
