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
    public partial class frmDriverLicenseHistory : Form
    {
        private int _PersonID;

        public frmDriverLicenseHistory()
        {
            InitializeComponent();
        }

        public frmDriverLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonDetailsWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonDetailsWithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonDetailsWithFilter1.FilterEnabled = true;
                ctrlPersonDetailsWithFilter1.FilterFocus();
            }
        }

        private void ctrlPersonDetailsWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
                ctrlDriverLicenses1.Clear();
            else
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
