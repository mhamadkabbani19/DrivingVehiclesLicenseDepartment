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
    public partial class frmNewInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;

        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmNewInternationalLicense_Load(object sender, EventArgs e)
        {
            // On form load, we initialize the known values.

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
        }

        private void ctrlLicenseDetailsWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            llblShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
                return;

            if (ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo == null) 
                return; // In case we did not select an exist License

            if (ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("You can't make an International License With a License With Class 3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            // To make sure we dont have an active International License with this Driver :
            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("License Already has an Active International License With ID = " + ActiveInternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llblShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternationalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("License is Inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue this Internatioanl License ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            clsInternationalLicense internationalLicense = new clsInternationalLicense();

            // Initialize the Application Info :
            internationalLicense.ApplicantPersonID = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            internationalLicense.ApplicationDate = DateTime.Now;
            internationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            internationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees;
            internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            // Initialize the International License Info :
            internationalLicense.DriverID = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ctrlLicenseDetailsWithFilter1.LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.IsActive = true;
            
            if (!internationalLicense.Save())
            {
                MessageBox.Show("International License Does Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            lblInternationalLicenseApplicationID.Text = internationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = internationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();

            btnIssue.Enabled = false;
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;

            MessageBox.Show("International License Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
