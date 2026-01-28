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
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        enum enMode { AddNew, Update };
        enMode Mode;

        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            Mode = enMode.Update;
        }

        private void _FillLicenseClassInComboBox()
        {
            // Read the License Class Row by row to fill the combo box with class names :
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasss();
            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassInComboBox();

            if (Mode == enMode.AddNew)
            {
                // In case we are in Add New Mode, We Initialize the default Info For any Local Driving License Application :

                lblFormTitle.Text = "Add New Local Driving License Application";
                this.Text = "Add New Local Driving License Application";
                _localDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonDetailsWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                // Here in Edit Mode, We don't need to Initialize default Info... Just the title and enable some Controls :

                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            // In Edit Mode, There is no need to make the user choose a person
            ctrlPersonDetailsWithFilter1.FilterEnabled = false;

            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Could not found this Local Driving License Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Initialize Controls with the Local License Application Info :
            ctrlPersonDetailsWithFilter1.LoadPersonInfo(_localDrivingLicenseApplication.ApplicantPersonID);
            lblDrivingLicenseApplicationID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_localDrivingLicenseApplication.LicenseClassID).ClassName);
            lblApplicationDate.Text = _localDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _localDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByUserID(_localDrivingLicenseApplication.CreatedByUserID).UserName.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcNewLCLAppData.SelectedTab = tcNewLCLAppData.TabPages["tpApplicationInfo"];
                return;
            }

            if (ctrlPersonDetailsWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcNewLCLAppData.SelectedTab = tcNewLCLAppData.TabPages["tpApplicationInfo"];
            }

            else
            {
                MessageBox.Show("Please Select a Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonDetailsWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Person Already have an application of this License Class, Choose another Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("Person Already have an active License of this License Class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // We created an object of Local Driving License Application in The very first of this form, now we enter its values and save it
            _localDrivingLicenseApplication.ApplicantPersonID = ctrlPersonDetailsWithFilter1.PersonID;
            _localDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _localDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _localDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _localDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _localDrivingLicenseApplication.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees;
            _localDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _localDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (_localDrivingLicenseApplication.Save())
            {
                lblDrivingLicenseApplicationID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                Mode = enMode.Update;
                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                MessageBox.Show("LDL Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Save Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.Update)
                _LoadData();
        }

        private void ctrlPersonDetailsWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddEditLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonDetailsWithFilter1.FilterFocus();
        }
    }
}
