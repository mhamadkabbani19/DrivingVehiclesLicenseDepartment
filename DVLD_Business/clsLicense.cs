using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicense
    {
        enum enMode { AddNew, Update };
        enMode Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { get; set; }

        public int ApplicationID { get; set; }

        public int DriverID { get; set; }
        public clsDriver DriverInfo;

        public int LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public clsDetainedLicense DetainInfo;

        public int CreatedByUserID { get; set; }

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.isLicenseDetained(this.LicenseID);
            }
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damage";
                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";
                default:
                    return "Unknown";
            }
        }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = String.Empty;
            this.PaidFees = 0.0m;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate,
            DateTime expirationDate, string notes, decimal paidFees, bool isActive, enIssueReason issueReason,
            int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            DriverInfo = clsDriver.FindByDriverID(driverID);
            LicenseClass = licenseClass;
            LicenseClassInfo = clsLicenseClass.Find(licenseClass);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            DetainInfo = clsDetainedLicense.FindByLicenseID(licenseID);

            Mode = enMode.Update;
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            string Notes = String.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 1;

            if (clsLicensesDataAccess.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate
                , ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes,
                    PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

            else
                return null;
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return this.LicenseID != -1;
        }

        private bool _Update()
        {
            return clsLicensesDataAccess.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesDataAccess.GetAllLicense();
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            return clsLicensesDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClass);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClass)
        {
            return GetActiveLicenseIDByPersonID(PersonID, LicenseClass) != -1;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesDataAccess.GetDriverLicenses(DriverID);
        }

        public Boolean isLicenseExpired()
        {
            // If this Date is later than The Expiration Date then the License Is Expired
            return this.ExpirationDate < DateTime.Now;
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicensesDataAccess.DeactivateLicense(this.LicenseID);
        }

        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            // This function is to Detain License and Return the new Detain ID
            clsDetainedLicense detainedLicense = new clsDetainedLicense();

            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
                return -1;

            return detainedLicense.DetaineID;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            // This function is To Release a Detained License, But the Release has an Application in The System
            // So we Initialize an Application

            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees;
            application.CreatedByUserID = ReleasedByUserID;

            if (!application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = application.ApplicationID;

            return this.DetainInfo.Release(ReleasedByUserID, application.ApplicationID);
        }

        public clsLicense Renew(string Notes, int CreatedByUserID)
        {
            // This function is To Renew an Expired License, But the Renew has an Application in The System
            // So we Initialize an Application

            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees;
            application.CreatedByUserID = CreatedByUserID;

            if (!application.Save())
            {
                return null;
            }

            // After Renewing a License, We should have a New License Renewed
            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = clsLicenseClass.Find(this.LicenseClass).DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            // If we have an Active Renew License then We Should Deactivate This License
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            // This function is To Replace a Damaged or Lost License, But the Replace has an Application in The System
            // So we Initialize an Application

            clsApplication application = new clsApplication();

            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ? (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees;
            application.CreatedByUserID = CreatedByUserID;

            if (!application.Save())
            {
                return null;
            }

            // After Replace a License, We should have a New License Replaced
            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            // If we have an Active Replaced License then We Should Deactivate This License
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
    }
}
