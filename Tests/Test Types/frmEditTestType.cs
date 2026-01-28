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
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        clsTestType _TestType;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes have errors, put the mouse on the red icon to know how to solve this problem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeTitle = txtTestTypeTitle.Text.Trim();
            _TestType.TestTypeDescription = txtTestTypeDescription.Text.Trim();
            _TestType.TestTypeFees = Convert.ToDecimal(txtTestTypeFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Test Type does not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            // This Form is always on the Edit mode so we don't need to check if Add New or Edit
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblTestTypeID.Text = ((int)_TestTypeID).ToString();
                txtTestTypeTitle.Text = _TestType.TestTypeTitle;
                txtTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Could not find Test Type with ID : " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "This feild should be implemented.");
            }
            else
                errorProvider1.SetError(txtTestTypeTitle, null);
        }

        private void txtTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "This feild should be implemented.");
            }
            else
                errorProvider1.SetError(txtTestTypeDescription, null);
        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "This feild should be implemented.");
            }
            else
                errorProvider1.SetError(txtTestTypeFees, null);

            if (!clsValidation.IsNumber(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Must be a number.");
            }
            else
                errorProvider1.SetError(txtTestTypeFees, null);
        }
    }
}
