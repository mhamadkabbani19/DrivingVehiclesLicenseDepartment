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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L App ID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 150;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 350;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 150;
            }

            cbFilterBy.SelectedIndex = 0;
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtTarget.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterColumn, txtTarget.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", FilterColumn, txtTarget.Text.Trim());

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTarget.Visible = (cbFilterBy.SelectedIndex != 0);
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = 
                new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Application ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            // We need to get the Local Driving License Application to Cancel it
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (localDrivingLicenseApplication != null)
            {
                if (localDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Canceled Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmManageLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application has not Canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Application ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            // We need to get the Local Driving License Application to Delete it
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (localDrivingLicenseApplication != null)
            {
                if (localDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmManageLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application has not Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm =
                new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            // We already have the Passed Test Count from the Local Driving License View Table
            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = localDrivingLicenseApplication.isLicenseIssued();

            tsmiIssueDrivingLicenseFirstTime.Enabled = (TotalPassedTests == 3) && !LicenseExists;
            tsmiShowLicense.Enabled = LicenseExists;
            tsmiEditApplication.Enabled = !LicenseExists && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            tsmiCancelApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            tsmiDeleteApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New) 
                || (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.Canceled);

            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            tsmiSechduleTests.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (tsmiSechduleTests.Enabled)
            {
                tsmiSchedultVisionTest.Enabled = !PassedVisionTest;

                tsmiScheduleWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;

                tsmiScheduleStreetTest.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);

            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiSchedultVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmListTestAppointment frm = new frmListTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmListTestAppointment frm = new frmListTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiScheduleStreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmListTestAppointment frm = new frmListTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            frmShowLicenseInfo frm = new frmShowLicenseInfo(ldlApp.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}
