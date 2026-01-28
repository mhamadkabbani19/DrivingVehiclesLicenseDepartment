using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTest
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestType;

        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }

        public bool TestResult { get; set; }

        public string Notes { get; set; }

        public int CreatedByUserID { get; set; }

        enum enMode { AddNew, Update };
        enMode Mode;

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsDataAccess.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);

            return this.TestID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestsDataAccess.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (clsTestsDataAccess.GetTestByID(TestID, ref TestAppointmentID, ref TestResult,
                ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            else
                return null;
        }

        public static clsTest FindByPersonAndTestTypeAndLicenseClass(int PersonID, clsTestType.enTestType TestTypeID, int LicenseClassID)
        {
            int TestID = -1, TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (clsTestsDataAccess.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, (int)TestTypeID, LicenseClassID, ref TestID, ref TestAppointmentID, ref TestResult,
                ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            // Return the number of Passed Test of an Applicant Person of Local Driving License Application
            return clsTestsDataAccess.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            // Return true if the Applicant Person Passed All the Tests (There is 3 Tests)
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }
    }
}
