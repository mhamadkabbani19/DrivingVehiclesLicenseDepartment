using System;
using System.Windows.Forms;
using DVLD_Business;

namespace DrivingVehiclesLicense
{
    public partial class ctrlDrivingLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if(handler != null)
                handler(LicenseID);
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;
        public int LicenseID
        {
            get
            {
                return ctrlDrivingLicenseInfo1.LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDrivingLicenseInfo1.SelectedLicenseInfo;
            }
        }

        public ctrlDrivingLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes should be implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }

            if (txtLicenseID.Text.Trim() == "")
                return;

            // Here we have a License ID and we send it to the main User Control
            _LicenseID = int.Parse(txtLicenseID.Text);
            ctrlDrivingLicenseInfo1.LoadInfo(_LicenseID);

            // We make sure to fire the event if we have an event of this control
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);
        }

        public void FilterFocus()
        {
            txtLicenseID.Focus();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDrivingLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDrivingLicenseInfo1.LicenseID;

            // We make sure to fire the event if we have an event of this control
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(LicenseID);
        }
    }
}
