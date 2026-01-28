using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        // The International License is also an Application, So it's inherites it

        public int InternationalLicenseID { get; set; }

        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }

        public int IssuedUsingLocalLicenseID { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        public enum enMode { AddNew, Update };
        public enMode _Mode;

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.PersonInfo = clsPerson.Find(ApplicantPersonID);
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool IsActive = false;

            bool isFound = clsInternationalLicensesDataAccess.GetInternationalLicenseByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (isFound)
            {
                // If it's found, we get the Application too
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, CreatedByUserID, InternationalLicenseID,
                    DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
            }

            else
                return null;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesDataAccess.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return this.InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicensesDataAccess.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)_Mode;

            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static DataTable GetDriverInternationalLicense(int DriverID)
        {
            return clsInternationalLicensesDataAccess.GetDriverInternationalLicenses(DriverID);
        }
    }
}
