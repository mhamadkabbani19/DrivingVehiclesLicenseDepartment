using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using DVLD_Business;

namespace DrivingVehiclesLicense
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _person;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public int PersonID { get { return _PersonID; } }

        public clsPerson SelectedPersonInfo { get { return _person; } }

        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGendor.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";

            pbPersonImage.Image = Properties.Resources.person_boy;
        }

        private void _LoadPersonImage()
        {
            // If the gender is Boy we load an image of boy and if not we load a girl image
            if (_person.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.person_boy;
            else
                pbPersonImage.Image = Properties.Resources.person_girl;

            // But if the person has an image, we load his image in the Picture box
            string ImagePath = _person.ImagePath;

            if(ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Picture could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillPersonInfo()
        {
            llblEditPersonInfo.Enabled = true;

            lblPersonID.Text = _person.PersonID.ToString();
            lblName.Text = _person.FullName;
            lblNationalNo.Text = _person.NationalNo;
            lblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
            lblGendor.Text = (_person.Gendor == 0) ? "Male" : "Female";
            lblCountry.Text = _person.CountryInfo.CountryName;
            lblAddress.Text = _person.Address;
            lblPhone.Text = _person.Phone;
            lblEmail.Text = _person.Email;
            _LoadPersonImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _person = clsPerson.Find(PersonID);

            if (_person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("Person with ID : " + PersonID.ToString() + " Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _person = clsPerson.Find(NationalNo);
            _PersonID = _person.PersonID;

            if (_person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("Person with NationalNo : " + NationalNo + " Was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
    }
}
