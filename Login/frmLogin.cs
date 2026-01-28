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
using System.IO;

namespace DrivingVehiclesLicense
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUserNameAndPassword(txtUserName.Text.Trim(), clsUtil.ComputeHash(txtPassword.Text.Trim()));

            if (user != null)
            {
                if (cbRememberMe.Checked)
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                if (!user.IsActive)
                {
                    MessageBox.Show("User is not active, contact admin to solve this problem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMainScreen frm = new frmMainScreen(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username/Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            // If the save file have a username and a password, then we should get them to the login form
            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
                cbRememberMe.Checked = false;
        }
    }
}
