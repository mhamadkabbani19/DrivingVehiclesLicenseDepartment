using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingVehiclesLicense
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LocalDrivingLicenseApplicationDetails;

        public frmLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationDetails = LocalDrivingLicenseApplicationID;
        }

        private void frmApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlApplicationDetails1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationDetails);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
