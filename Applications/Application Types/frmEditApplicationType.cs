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
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes have errors, put the mouse on the red icon to know how to solve this problem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text;
            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtApplicationTypeFees.Text);

            if (_ApplicationType.Save())
                MessageBox.Show("Application Updated Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Application does not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            // It is always on Edit Mode so we initialize the values of the application type in the form controls

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            
            if (_ApplicationType != null)
            {
                txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtApplicationTypeFees.Text = _ApplicationType.ApplicationFees.ToString();
            }
        }

        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationTypeTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeTitle, "This feild need to be implemented.");
            }
            else
                errorProvider1.SetError(txtApplicationTypeTitle, null);
        }

        private void txtApplicationTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeFees, "This feild need to be implemented.");
                return;
            }
            else
                errorProvider1.SetError(txtApplicationTypeFees, null);

            if (!clsValidation.IsNumber(txtApplicationTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeFees, "Must enter a number.");
                return;
            }
            else
                errorProvider1.SetError(txtApplicationTypeFees, null);
        }
    }
}
