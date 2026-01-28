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
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        private int _newLicenseID = -1;

        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            // We initialize the known values of any License we need to Replace
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            btnReplace.Enabled = false;
            rbDamaged.Checked = true;
        }

        private void ctrlLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            llblShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            if (ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo == null)
                return;

            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License Is Not Active.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplace.Enabled = false;
                return;
            }

            btnReplace.Enabled = true;
        }

        private int _GetApplicationTypeID()
        {
            if (rbDamaged.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Replacement For Damaged License";
            this.Text = lblFormTitle.Text;

            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Replacement For Lost License";
            this.Text = lblFormTitle.Text;

            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace this License ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                , MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            clsLicense NewLicense = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.Replace((clsLicense.enIssueReason)_GetApplicationTypeID(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Renew Failed.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // If we reach here, now we have succeed Replacing The License and have a new one
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _newLicenseID = NewLicense.LicenseID;
            lblReplacedLicenseID.Text = _newLicenseID.ToString();
            MessageBox.Show("License Renewed Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReplace.Enabled = false;
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
            gbReplaceFor.Enabled = false;
            llblShowLicenseInfo.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_newLicenseID);
            frm.ShowDialog();
        }
    }
}