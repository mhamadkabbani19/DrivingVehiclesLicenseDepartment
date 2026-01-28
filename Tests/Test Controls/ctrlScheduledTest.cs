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
    public partial class ctrlScheduledTest : UserControl
    {
        private int _TestAppointmentID = -1;
        private int _TestID = -1;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

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

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private clsTestAppointment _testAppointment;

        public void LoadInfo(int TestAppointmentID)
        {
            _testAppointment = clsTestAppointment.Find(TestAppointmentID);

            if (_testAppointment == null)
            {
                MessageBox.Show("Could not found this Test Appointment with ID = " + TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestAppointmentID = _testAppointment.TestAppointmentID;
            _TestID = _testAppointment.TestID;
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_testAppointment.LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Could not found this Local Driving License Application with ID = " + TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If we reach here, then we have the Test Appointment and the Local Driving License Application Infos
            // and we need to initialize its values to the controls
            lblDLAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _localDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _localDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = _localDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _testAppointment.AppointmentDate.ToShortDateString();
            lblFees.Text = _testAppointment.PaidFees.ToString();

            lblTestID.Text = (_testAppointment.TestID == -1) ? "Not Taked Yet" : _testAppointment.TestID.ToString();
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
    }
}
