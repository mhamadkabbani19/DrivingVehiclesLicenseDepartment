using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public int DetaineID { get; set; }

        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }

        public decimal FineFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        public bool IsReleased { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUserInfo { get; set; }

        public int ReleaseApplicationID { get; set; }

        enum enMode { AddNew, Update };
        enMode Mode;

        public clsDetainedLicense()
        {
            this.DetaineID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0.0m;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int detainedLicenseID, int licenseID, DateTime detainDate, decimal fineFees,
            int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            this.DetaineID = detainedLicenseID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(createdByUserID);
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleasedByUserInfo = clsUser.FindByUserID(releasedByUserID);
            this.ReleaseApplicationID = releaseApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetaineID = clsDetainedLicensesDataAccess.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID);

            return this.DetaineID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesDataAccess.UpdateDetainedLicense(this.DetaineID, this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID);
        }

        public static clsDetainedLicense Find(int DetainedLicenseID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0.0m;
            bool IsReleased = false;

            if (clsDetainedLicensesDataAccess.GetDetainedLicenseByID(DetainedLicenseID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense(DetainedLicenseID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            else
                return null;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainedLicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0.0m;
            bool IsReleased = false;

            if (clsDetainedLicensesDataAccess.GetDetainedLicenseByLicenseID(ref DetainedLicenseID, LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense(DetainedLicenseID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesDataAccess.GetAllDetainedLicenses();
        }

        public static bool isLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesDataAccess.isLicenseDetained(LicenseID);
        }

        public bool Release(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicensesDataAccess.ReleaseDetainedLicense(this.DetaineID, ReleasedByUserID, ReleaseApplicationID);
        }
    }
}
