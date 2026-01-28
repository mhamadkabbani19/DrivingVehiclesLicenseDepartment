using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Business;

namespace DrivingVehiclesLicense
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsLicense _license;

        public int LicenseID { get { return _LicenseID; }  }

        public clsLicense SelectedLicenseInfo { get { return _license; } }

        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            // If the gender is Boy we load an image of boy and if not we load a girl image
            if (_license.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.person_boy;
            else
                pbPersonImage.Image = Properties.Resources.person_girl;

            // But if the person has an image, we load his image in the Picture box
            string ImagePath = _license.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not found this image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _license = clsLicense.Find(_LicenseID);

            if (_license == null)
            {
                MessageBox.Show("Could not found this License With ID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // If we reach here, then we have a License to show its Info in the Controls
            lblClassName.Text = _license.LicenseClassInfo.ClassName;
            lblFullName.Text = _license.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _license.LicenseID.ToString();
            lblNationalNo.Text = _license.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_license.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblIssueDate.Text = _license.IssueDate.ToShortDateString();
            lblIssueReason.Text = _license.IssueReasonText;
            lblNotes.Text = (_license.Notes == "") ? "No Notes" : _license.Notes;
            lblIsActive.Text = (_license.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = _license.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _license.DriverID.ToString();
            lblExpirationDate.Text = _license.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = (_license.IsDetained) ? "Yes" : "No";

            _LoadPersonImage();
        }
    }
}
