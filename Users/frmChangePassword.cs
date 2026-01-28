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
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        clsUser _user;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _user = clsUser.FindByUserID(_UserID);

            if (_user == null)
            {
                MessageBox.Show("Could not FindByLocalDrivingLicenseApplicationID User With ID : " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes should be implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_user.ChangePassword(clsUtil.ComputeHash(txtNewPassword.Text.Trim())))
            {
                MessageBox.Show("Password changed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password change failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "You must enter your Password.");
                return;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

            if (clsUtil.ComputeHash(txtCurrentPassword.Text.Trim()) != _user.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "You must enter your true Old Password.");
                return;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "You must enter your New Password.");
                return;
            }
            else
                errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "You must enter a Password.");
                return;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm password failed.");
                return;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }
    }
}
