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
using System.Text.RegularExpressions;

namespace DrivingVehiclesLicense
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        enum enGendor { Male = 0, Female = 1};
        enum enMode { AddNew, Update };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPerson _person;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            _Mode = enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            // We get the Countries from the Countries Table in Database
            // and initialize them row by row in the combo box Control

            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add New Person";
                _person = new clsPerson();
            }
            else
                lblFormTitle.Text = "Update Person";

            // If the person is male we load a boy image in the Picture box but if not we load a girl image
            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.person_boy;
            else
                pbPersonImage.Image = Properties.Resources.person_girl;

            llblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            // The age of the person Should be between 18 and 64
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-64);

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            rbMale.Checked = true;
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

        }

        private void _LoadData()
        {
            _person = clsPerson.Find(_PersonID);

            if (_person == null)
            {
                MessageBox.Show("Cannot find a person with ID : " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;
            dtpDateOfBirth.Value = _person.DateOfBirth;

            if (_person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _person.Address;
            txtPhone.Text = _person.Phone;
            txtEmail.Text = _person.Email;

            cbCountry.SelectedIndex = cbCountry.FindString(_person.CountryInfo.CountryName);

            if (_person.ImagePath != "")
                pbPersonImage.ImageLocation = _person.ImagePath;

            llblRemoveImage.Visible = (_person.ImagePath != "");
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.person_boy;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.person_girl;
        }

        private void llblAddEditPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdAddEditPhoto.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdAddEditPhoto.FilterIndex = 1;
            ofdAddEditPhoto.RestoreDirectory = true;

            if(ofdAddEditPhoto.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = ofdAddEditPhoto.FileName;
                pbPersonImage.ImageLocation = SelectedFilePath;
                llblRemoveImage.Visible = true;
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.person_boy;
            else
                pbPersonImage.Image = Properties.Resources.person_girl;

            llblRemoveImage.Visible = false;
        }

        private bool _HandlePersonImage()
        {
            if (_person.ImagePath != pbPersonImage.ImageLocation) // If the person changed his image
            {
                if (_person.ImagePath != "") // If the image exists
                {
                    try
                    {
                        File.Delete(_person.ImagePath); // Delete this Image
                    }
                    catch (IOException)
                    {

                    }
                }
            }

            if (pbPersonImage.ImageLocation != null) // If the person choose an Image for him
            {
                string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImageFolder(ref SourceImageFile)) // We Copy this image to the images of The project Folder
                {
                    pbPersonImage.ImageLocation = SourceImageFile; // We put the image source file in the Picture box image location
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes should have a value, put the mouse on the red icon to know the error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.Phone = txtPhone.Text.Trim();
            _person.Email = txtEmail.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.NationalityCountryID = NationalityCountryID;
            _person.Address = txtAddress.Text.Trim();

            if (rbMale.Checked)
                _person.Gendor = (byte)enGendor.Male;
            else
                _person.Gendor = (byte)enGendor.Female;

            if (pbPersonImage.ImageLocation != null) // If the photo exists
                _person.ImagePath = pbPersonImage.ImageLocation;
            else
                _person.ImagePath = "";

            if (_person.Save())
            {
                lblPersonID.Text = _person.PersonID.ToString();

                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _person.PersonID); // To send person data to the form or control that waits for data to send back
            }
            else
                MessageBox.Show("Error saving this person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Value_Validating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(Temp, "You must enter a value");
            }
            else
                errorProvider.SetError(Temp, null);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, "you must enter a valid email");
            }
            else
                errorProvider.SetError(txtEmail, null);
        }

        private void NameLettersKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsPunctuation(e.KeyChar) || char.IsNumber(e.KeyChar);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNo, "You must enter a value");
            }
            else
                errorProvider.SetError(txtNationalNo, null);

            if (txtNationalNo.Text.Trim() != _person.NationalNo && clsPerson.isPersonExists(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNo, "NationalNo is used by another person.");
            }
            else
                errorProvider.SetError(txtNationalNo, null);
        }
    }
}
