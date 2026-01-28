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
    public partial class frmAddEditUser : Form
    {
        private int _UserID = -1;
        clsUser _user;

        enum enMode { AddNew, Update };
        enMode _Mode;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add New User";
                this.Text = "Add New User";

                _user = new clsUser();

                tpUserData.Enabled = false;
                ctrlPersonDetailsWithFilter.FilterFocus();
            }
            else
            {
                // If it's in edit mode no need to initialize values
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";

                tpUserData.Enabled = true;

                btnSave.Enabled = true;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _user = clsUser.FindByUserID(_UserID);
            ctrlPersonDetailsWithFilter.FilterEnabled = false;

            if (_user == null)
            {
                MessageBox.Show("No user with ID : " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            // If we reach here, then we initialize User Info in the User Control
            lblUserID.Text = _user.UserID.ToString();
            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            cbIsActive.Checked = _user.IsActive;
            ctrlPersonDetailsWithFilter.LoadPersonInfo(_user.PersonID);
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpUserData.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpUserData"];
                return;
            }

            if (ctrlPersonDetailsWithFilter.PersonID != -1)
            {
                if (clsUser.isUserExistsByPersonID(ctrlPersonDetailsWithFilter.PersonID))
                {
                    MessageBox.Show("Person is already a user in this system, please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonDetailsWithFilter.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpUserData.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpUserData"];
                }
            }
            else
            {
                MessageBox.Show("Please select a person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonDetailsWithFilter.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes should be implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.PersonID = ctrlPersonDetailsWithFilter.PersonID;
            _user.UserName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text.Trim();
            _user.IsActive = cbIsActive.Checked;

            if (_user.Save())
            {
                lblUserID.Text = _user.UserID.ToString();
                _Mode = enMode.Update;

                lblFormTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Saved Successfully... With ID = " + _user.UserID.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This User has not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtUserName, "You must enter a UserName.");
            }
            else
                errorProvider.SetError(txtUserName, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, "You must enter a Password.");
            }
            else
                errorProvider.SetError(txtPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() == "" || txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Confirm password failed.");
            }
            else
                errorProvider.SetError(txtConfirmPassword, null);
        }
    }
}
