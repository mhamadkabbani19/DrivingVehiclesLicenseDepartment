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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _internationalLicenseID = -1;
        private clsInternationalLicense _internationalLicense;

        public int InternationalLicenseID
        {
            get
            {
                return _internationalLicenseID;
            }
        }
        public clsInternationalLicense InternationalLicenseInfo
        {
            get
            {
                return _internationalLicense;
            }
        }

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            // If the gender is Boy we load an image of boy and if not we load a girl image
            if (_internationalLicense.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.person_boy;
            else
                pbPersonImage.Image = Properties.Resources.person_girl;

            // But if the person has an image, we load his image in the Picture box
            string ImagePath = _internationalLicense.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not found this image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _internationalLicenseID = InternationalLicenseID;
            _internationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (_internationalLicense == null)
            {
                MessageBox.Show("Could not found International License With ID = " + InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // If we reach here, then the International License is found so we initialize its Info to the controls
            lblName.Text = _internationalLicense.ApplicantFullName;
            lblInternationalLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            lblNationalNo.Text = _internationalLicense.PersonInfo.NationalNo;
            lblGendor.Text = (_internationalLicense.PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblIssueDate.Text = _internationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblIsActive.Text = (_internationalLicense.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = _internationalLicense.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _internationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _internationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();
        }
    }
}
