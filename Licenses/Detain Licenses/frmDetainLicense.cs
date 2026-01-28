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
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            // On Form load, We initialize the known value of any Detained License
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
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

            if (!ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License Is Inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            if (ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License Is Already Detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (txtFineFees.Text.Trim() == "") // To Check if the user didn't determin a Fine Fees
            {
                MessageBox.Show("Must Enter a value of Fine Fees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (MessageBox.Show("Are you sure you want to Detain this License ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            _DetainID = ctrlLicenseDetailsWithFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal(txtFineFees.Text), clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("Failed To Detain This License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // If we reach here, then the License Detained Successfully 
            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully With ID = " + _DetainID.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            txtFineFees.Enabled = false;
            ctrlLicenseDetailsWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered value is number or not
            e.Handled = !clsValidation.IsNumber(e.KeyChar.ToString());
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}