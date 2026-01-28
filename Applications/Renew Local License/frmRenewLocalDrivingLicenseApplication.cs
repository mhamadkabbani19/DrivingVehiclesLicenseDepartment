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
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _newLicenseID = -1;

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            // We Initialize the known values of any License We need to Renew
            ctrlLicenseDetailsWithFilter1.FilterFocus();

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
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

            // If we Reach here, we know the License Info so we initialize its value in the controls
            int DefaultValidityLength = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblLicenseFees.Text) + Convert.ToDecimal(lblApplicationFees.Text)).ToString();
            txtNotes.Text = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.Notes;

            // We need to Know if the License Expired or not
            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.isLicenseExpired())
            {
                MessageBox.Show("This license is not expired yet, It will Expire on : " + ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License Is Not Active.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew this License ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
                , MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            clsLicense NewLicense = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.Renew(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Renew Failed.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // If we reach here, then we Succeed Renewing The License and have a new License
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _newLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _newLicenseID.ToString();
            MessageBox.Show("License Renewed Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
