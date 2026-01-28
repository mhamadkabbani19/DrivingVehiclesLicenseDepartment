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
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _SelectedLicenseID;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;
            ctrlLicenseDetailsWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
        }

        private void ctrlLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llblShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
                return;

            if (ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo == null)
                return;

            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License is not Detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }

            // Here, we have the Detained License info and it is ready to release
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();
            lblDetainID.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DetainInfo.DetaineID.ToString();
            lblLicenseID.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblCreatedBy.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DetainInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DetainInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblFineFees.Text) + Convert.ToDecimal(lblApplicationFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this Detained License ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            int ApplicationID = -1;

            bool IsReleased = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);

            if (!IsReleased)
            {
                MessageBox.Show("Failed To Release This Detained License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplcationID.Text = ApplicationID.ToString();

            btnRelease.Enabled = false;
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;

            MessageBox.Show("Detained License Released Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlLicenseDetailsWithFilter1.LicenseID);
            frm.ShowDialog();
        }
    }
}
