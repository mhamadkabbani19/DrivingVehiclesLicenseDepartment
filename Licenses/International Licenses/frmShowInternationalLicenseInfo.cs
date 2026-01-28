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
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private int _internationalLicenseID;

        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _internationalLicenseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseDetails_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseDetails1.LoadInternationalLicenseInfo(_internationalLicenseID);
        }
    }
}
