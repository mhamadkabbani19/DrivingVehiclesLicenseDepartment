using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; set; }

        public clsTestType.enTestType TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public bool IsLocked { get; set; }

        public int RetakeTestApplicationID { get; set; }

        public clsApplication RetakeTestApplicationInfo { get; set; }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        enum enMode { AddNew, Update };
        enMode Mode;

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0.0m;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int testAppointmentID, clsTestType.enTestType testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate,
            decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(retakeTestApplicationID);

            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);

            return this.TestAppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID,
                this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0.0m;
            bool IsLocked = false;

            if (clsTestAppointmentsDataAccess.GetTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            else
                return null;
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            // Return the Last Test Appointment by Local Driving License Application and Test Type
            int TestAppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0.0m;
            bool IsLocked = false;

            if (clsTestAppointmentsDataAccess.GetLastTestAppointment(ref TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointments();
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LDLAppID, clsTestType.enTestType TestTypeID)
        {
            // Return all Test Appointment determined by an Applicant Person of Local Driving License Applicaiton 
            // and Test Type ID

            return clsTestAppointmentsDataAccess.GetApplicationTestAppointmentsPerTestType(LDLAppID, (int)TestTypeID);
        }

        private int _GetTestID()
        {
            // Return the Test ID of the Test Appointment if Found, -1 if not
            return clsTestAppointmentsDataAccess.GetTestID(this.TestAppointmentID);
        }
    }
}
