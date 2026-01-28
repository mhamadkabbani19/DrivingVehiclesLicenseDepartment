using System;
using System.Windows.Forms;
using DVLD_Business;
using System.Data;

namespace DrivingVehiclesLicense
{
    public partial class frmListPeople : Form
    {
        private static DataTable dtAllPeople = clsPerson.GetAllPeople();

        private DataTable dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email"); // To get a view of the People List

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = dtPeople;
            lblRecordsCount.Text = dtPeople.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }
        }

        private void _RefreshPeopleList()
        {
            dtAllPeople = clsPerson.GetAllPeople();
            dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email");

            dgvPeople.DataSource = dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTarget.Visible = (cbFilterBy.Text != "None");

            if(txtTarget.Visible)
            {
                txtTarget.Text = "";
                txtTarget.Focus();
            }
        }

        private void tsmiShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void tsmiEditPerson_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void tsmiDeletePerson_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person With ID :" + dgvPeople.CurrentRow.Cells[0].Value.ToString() + " ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;

            if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                MessageBox.Show("Person with ID = " + (int)dgvPeople.CurrentRow.Cells[0].Value + " Deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Delete Person failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _RefreshPeopleList();
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtTarget.Text.Trim() == "" || FilterColumn == "None")
            {
                dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                dtPeople.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterColumn, txtTarget.Text.Trim());
            else
                dtPeople.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", FilterColumn, txtTarget.Text.Trim());

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void tsmiSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send an Email is not empleminted yet.", "Coming Soon...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void tsmiCallPhone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Call Phone is not empleminted yet.", "Coming Soon...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
