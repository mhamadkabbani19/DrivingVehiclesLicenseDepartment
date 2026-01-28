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
    public partial class frmListTestAppointment : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmListTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);

            dgvAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordsCount.Text = dgvAppointments.Rows.Count.ToString();

            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 150;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[1].Width = 200;

                dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAppointments.Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAppointments.Columns[3].Width = 100;
            }

            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    this.Text = "Vision Test";
                    pbTestImage.Image = Properties.Resources.eye_open;
                    break;
                case clsTestType.enTestType.WrittenTest:
                    this.Text = "Written Test";
                    pbTestImage.Image = Properties.Resources.test;
                    break;
                case clsTestType.enTestType.StreetTest:
                    this.Text = "Street Test";
                    pbTestImage.Image = Properties.Resources.street_racing;
                    break;
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            // If there is an active Test Appointment then we should exit
            if (localDrivingLicenseApplication.isThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
                frm1.ShowDialog();

                frmTestAppointment_Load(null, null);
                return;
            }

            // If the person had a Test before and he Passed it then we should exit
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("Person Already Passed This Test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();

            frmTestAppointment_Load(null, null);
        }

        private void tsmiEditAppointment_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();

            frmTestAppointment_Load(null, null);
        }

        private void tsmiTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestTypeID);
            frm.ShowDialog();

            frmTestAppointment_Load(null, null);
        }
    }
}
