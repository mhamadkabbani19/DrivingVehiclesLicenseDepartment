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
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 110;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Active")
            {
                txtSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtSearch.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterColumn, int.Parse(txtSearch.Text));
            else
                _dtAllUsers.DefaultView.RowFilter = String.Format("[{0}] LIKE {1}%", FilterColumn, txtSearch.Text);

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void tsmiUserDetails_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void tsmiAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void tsmiEditUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void tsmiDeleteUser_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (clsGlobal.CurrentUser.UserID == UserID)
            {
                MessageBox.Show("You cant delete this user while he is currently on system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsUser.Delete(UserID))
            {
                MessageBox.Show("User with ID = " + UserID.ToString() + " Deleted Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }
            else
                MessageBox.Show("You cant delete this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
             frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
             frm.ShowDialog();
        }
    }
}
