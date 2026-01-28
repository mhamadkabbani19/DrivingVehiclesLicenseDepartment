using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        // The Local Driving License is also an Application, So it's inherites it

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }
        }

        enum enMode { AddNew, Update };
        enMode _Mode;

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            _Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplication(
                this.ApplicationID, this.LicenseClassID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplication(
                this.LocalDrivingLicenseApplicationID, this.ApplicationID,this.LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            bool isFound = clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationByID(
                LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (isFound)
            {
                // If it's found, then we get the Base Application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, (enApplicationType)Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int LicenseClassID = -1;

            bool isFound = clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationByApplicationID(
                ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID);

            if (isFound)
            {
                // If it's found, then we get the Base Application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, (enApplicationType)Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public bool Delete()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DeleteLocalDrivingLicenseApplicationByID(this.LocalDrivingLicenseApplicationID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;

            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            // Return true if the applicant Person of Local Driving License Application Pass The Test Type given
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            // Return true if the applicant Person of Local Driving License Application Attend The Test Type given
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            // Return how many times the Applicant Person did this Test Type given
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            // Return true if the Applicant Person Did this Test Type given
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public bool AttendedTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public static bool isThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            // Return true if there is an Active Scheduled Test for the Applicant Person
            return clsLocalDrivingLicenseApplicationDataAccess.isThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool isThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.isThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            // Return the last Test this Applicant Person did by The Test Type given
            return clsTest.FindByPersonAndTestTypeAndLicenseClass(this.ApplicantPersonID, TestTypeID, this.LicenseClassID);
        }

        public int IssueLicenseForFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            // Check if the Driver already exists in the System
            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            // Then we create a new License and initialize its Info
            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                this.SetCompleted(); // After saving the License we Set This Application Completed

                return License.LicenseID;
            }
            else
                return -1;
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            // Return true if the Applicant Person Pass All The Tests
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public int GetActiveLicenseID()
        {
            // Return the Active License ID if Issued, and -1 if not
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool isLicenseIssued()
        {
            // Return true if the License has been Issued
            return GetActiveLicenseID() != -1;
        }
    }
}
