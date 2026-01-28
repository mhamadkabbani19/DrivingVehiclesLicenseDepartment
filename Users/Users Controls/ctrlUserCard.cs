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
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _user;
        private int _UserID = -1;

        public int UserID { get { return _UserID; } }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _user = clsUser.FindByUserID(UserID);

            if (_user == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No user with UserID : " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _ResetUserInfo()
        {
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
        }

        private void _FillUserInfo()
        {
            ctrlPersonDetails.LoadPersonInfo(_user.PersonID);
            lblUserID.Text = _user.UserID.ToString();
            lblUserName.Text = _user.UserName.ToString();
            lblIsActive.Text = (_user.IsActive) ? "Yes" : "No";
        }
    }
}
