using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enApplicationType { NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6, RetakeTest = 7 };

        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 };

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo;

        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;

        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Canceled:
                        return "Canceled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }

        public DateTime LastStatusDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public enum enMode { AddNew, Update };
        public enMode Mode;

        public clsApplication()
        {
            this.ApplicantPersonID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            if (clsApplicationDataAccess.GetApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate,
                ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
                ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationDataAccess.DeleteApplicationByID(ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplicationDataAccess.UpdateStatus(ApplicationID, 2);
        }

        public bool SetCompleted()
        {
            return clsApplicationDataAccess.UpdateStatus(ApplicationID, 3);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }

        public static bool isApplicationExists(int ApplicationID)
        {
            return clsApplicationDataAccess.isApplicationExists(ApplicationID);
        }

        public static bool DoesPersonHasActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationDataAccess.DoesPersonHasActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHasActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationDataAccess.DoesPersonHasActiveApplication(ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationType)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(PersonID, (int)ApplicationType);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationType, int LicenseClassID)
        {
            return clsApplicationDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationType, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(ApplicantPersonID, (int)ApplicationTypeID);
        }
    }
}
