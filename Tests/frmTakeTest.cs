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
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _test;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestType;

            ctrlScheduledTest1.LoadInfo(_TestAppointmentID);

            if (ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            _TestID = ctrlScheduledTest1.TestID;
            if (_TestID != -1)
            {
                // If the Test is taken and finished then we should show its Info and don't allow to edit its Info
                _test = clsTest.Find(_TestID);

                if (_test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = _test.Notes;

                lblUserMessage.Visible = true;
                btnSave.Enabled = false;

                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            else
                _test = new clsTest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this Test Data ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            _test.TestAppointmentID = _TestAppointmentID;
            _test.TestResult = rbPass.Checked;
            _test.Notes = txtNotes.Text.Trim();
            _test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if(_test.Save())
            {
                btnSave.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                lblUserMessage.Visible = true;

                MessageBox.Show("Test saved successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
