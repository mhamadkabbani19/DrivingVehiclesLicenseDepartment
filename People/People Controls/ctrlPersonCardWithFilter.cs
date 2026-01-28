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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
                handler(PersonID);
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonID { get { return ctrlPersonCard1.PersonID; } }

        public clsPerson SelectedPersonInfo { get { return ctrlPersonCard1.SelectedPersonInfo; } }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtSearch.Text));
                    break;

                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtSearch.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtSearch.Text = PersonID.ToString();
            FindNow();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some attributes should be implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSearch.Text.Trim() == "")
                return;

            FindNow();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtSearch.Focus();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "You must enter a value.");
            }
            else
                errorProvider1.SetError(txtSearch, null);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();

            // If we add new person, we need to send it back to this User Control
            frm.DataBack += DataBackEvent;

            frm.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtSearch.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            this.FilterEnabled = false;
        }

        public void FilterFocus()
        {
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
