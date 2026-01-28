using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        public int DriverID { get; set; }

        public int PersonID { get; set; }
        public clsPerson PersonInfo;

        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        enum enMode { AddNew, Update };
        enMode Mode;

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.MinValue;

            Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.DriverID = clsDriversDataAccess.AddNewDriver(this.PersonID, this.CreatedByUserID);

            return this.DriverID != -1;
        }

        private bool _Update()
        {
            return clsDriversDataAccess.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriversDataAccess.GetDriverByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriversDataAccess.GetDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
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

        public static DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicense(DriverID);
        }
    }
}
