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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;
        int _LicenseID = -1;

        int LocalDrivingLicenseApplication
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
            }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void ResetLocalDrivingLicenseApplicationInfo()
        {
            lblLDAppID.Text = "[???]";
            lblLicenseClass.Text = "[???]";
            ctrlApplicationBasicInfo1.ResetApplicationInfo();

            llblShowLicenseInfo.Enabled = false;
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _localDrivingLicenseApplication.GetActiveLicenseID();
            llblShowLicenseInfo.Enabled = (_LicenseID != -1);

            lblLDAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.Find(_localDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = clsTest.GetPassedTestCount(_LocalDrivingLicenseApplicationID).ToString() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.ApplicationID);
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();

                MessageBox.Show("Could not found this LDL Application with ID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            _LocalDrivingLicenseApplicationID = _localDrivingLicenseApplication.ApplicationID;

            if (_localDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();

                MessageBox.Show("Could not found this LDL Application with AppID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}
