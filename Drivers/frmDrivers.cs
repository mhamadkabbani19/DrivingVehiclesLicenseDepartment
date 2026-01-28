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
    public partial class frmDrivers : Form
    {
        private DataTable _dtAllDrivers;

        public frmDrivers()
        {
            InitializeComponent();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtTarget.Visible = false;
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;

            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();

            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active License";
                dgvDrivers.Columns[5].Width = 150;
            }
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTarget.Visible = (cbFilterBy.SelectedIndex != 0);
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtTarget.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                _dtAllDrivers.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterColumn, txtTarget.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", FilterColumn, txtTarget.Text.Trim());

            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
