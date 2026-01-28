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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        private clsApplication _application;

        public int ApplicationID { get { return _ApplicationID; } }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            lblAppID.Text = "[???]";
            lblAppStatus.Text = "[???]";
            lblAppFees.Text = "[$$$]";
            lblAppType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblAppDate.Text = "[??/??/????]";
            lblAppStatusDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[???]";

            llblViewPersonInfo.Enabled = false;
        }

        private void _FillApplicationInfo()
        {
            lblAppID.Text = _application.ApplicationID.ToString();
            lblAppStatus.Text = _application.StatusText;
            lblAppFees.Text = _application.PaidFees.ToString();
            lblAppType.Text = clsApplicationType.Find(_application.ApplicationTypeID).ApplicationTypeTitle;
            lblApplicant.Text = _application.ApplicantFullName;
            lblAppDate.Text = _application.ApplicationDate.ToShortDateString();
            lblAppStatusDate.Text = _application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsUser.FindByUserID(_application.CreatedByUserID).UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _application = clsApplication.FindBaseApplication(ApplicationID);
            _ApplicationID = ApplicationID;

            if (_application == null)
            {
                // If there is no Application we need to reset the control values
                ResetApplicationInfo();

                MessageBox.Show("Could not found this application with id = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfo();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_application.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
