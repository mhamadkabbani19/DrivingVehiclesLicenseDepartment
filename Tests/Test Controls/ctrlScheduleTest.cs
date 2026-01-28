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
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _testAppointment;
        private int _TestAppointmentID = -1;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                // We change the Test Type Image and Text if the Test Type has Changed
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbTestImage.Image = Properties.Resources.eye_open;
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbTestImage.Image = Properties.Resources.test;
                        break;
                    case clsTestType.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestImage.Image = Properties.Resources.street_racing;
                        break;
                }
            }
        }

        private bool _LoadTestAppointmentData()
        {
            _testAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_testAppointment == null)
            {
                MessageBox.Show("Could not found this Test Appointment with ID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _testAppointment.PaidFees.ToString();

            // We should handle the problem if this Date is before the Test Appointment Date
            // because the Date Time Picker minimum date is the known Test Appointment date
            if (DateTime.Compare(DateTime.Now, _testAppointment.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = _testAppointment.AppointmentDate;

            dtpDate.Value = _testAppointment.AppointmentDate;

            if (_testAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeTestAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
                lblFormTitle.Text = "Schedule Test";
                gbRetakeTest.Enabled = false;
            }
            else
            {
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeTestAppFees.Text = _testAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                gbRetakeTest.Enabled = true;
                lblFormTitle.Text = "Schedule Retake Test";
            }

            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.isThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person Already have an active appointment for this Test Type.";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_testAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for this Test, appointment is locked";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        // If the Test is Vision Test no need to check because it's the first Test
                        lblUserMessage.Visible = false;
                        return true;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        // Here we should Check if the Vision Test is Passed to Move to Written Test
                        if (!_localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                        {
                            lblUserMessage.Visible = true;
                            lblUserMessage.Text = "Cannot schedule, Vision test should be passed first";
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                        }

                        return true;
                    }

                case clsTestType.enTestType.StreetTest:
                    {
                        // And here we should Check if the Written Test is Passed to Move to Street Test
                        if (!_localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                        {
                            lblUserMessage.Visible = true;
                            lblUserMessage.Text = "Cannot schedule, Written test should be passed first";
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                        }

                        return true;
                    }
            }

            return false;
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local Driving License Application With ID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // If this Local Driving License Application had a Test of determined Test Type before then it is attended
            // Meaning he is retaking the test
            if (_localDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeTestAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees.ToString();
                lblFormTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
                gbRetakeTest.Enabled = true;
            }
            else
            {
                lblRetakeTestAppFees.Text = "0";
                lblFormTitle.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";
                gbRetakeTest.Enabled = false;
            }

            lblDLAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.Find(_localDrivingLicenseApplication.LicenseClassID).ClassName;
            lblName.Text = _localDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = _localDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestTypeID).TestTypeFees.ToString();
                dtpDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";
                _testAppointment = new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = (Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblRetakeTestAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;
        }

        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                // Retaking a Test is an Application
                clsApplication application = new clsApplication();

                application.ApplicantPersonID = _localDrivingLicenseApplication.ApplicantPersonID;
                application.ApplicationDate = DateTime.Now;
                application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                application.LastStatusDate = DateTime.Now;
                application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;
                application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!application.Save())
                {
                    _testAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to create Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _testAppointment.RetakeTestApplicationID = application.ApplicationID;
            }

            return true;
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _testAppointment.TestTypeID = _TestTypeID;
            _testAppointment.LocalDrivingLicenseApplicationID = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _testAppointment.AppointmentDate = dtpDate.Value;
            _testAppointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            _testAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_testAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Appointment saved successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Appointment does not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
