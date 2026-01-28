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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public frmIssueDrivingLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Could not found this Local Driving License Application With ID = " + _LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_localDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass all Tests First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // To make sure the person didn't Issued an Active License of the same class before
            int LicenseID = _localDrivingLicenseApplication.GetActiveLicenseID();

            if (LicenseID != -1)
            {
                MessageBox.Show("Person already issued this License With ID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlLocalDrivingLicenseApplicationInfo.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _localDrivingLicenseApplication.IssueLicenseForFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully With ID = " + LicenseID.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License does not Issued.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
