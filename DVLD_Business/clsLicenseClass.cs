using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        enum enMode { AddNew, Update };
        enMode Mode;

        public int LicenseClassID { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        public byte MinimumAllowedAge { get; set; }

        public byte DefaultValidityLength { get; set; }

        public decimal ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0.0m;

            Mode = enMode.AddNew;
        }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, 
            byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            decimal ClassFees = 0.0m;
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;

            if (clsLicenseClassesDataAccess.GetLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);

            else
                return null;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            decimal ClassFees = 0.0m;
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;

            if (clsLicenseClassesDataAccess.GetLicenseClassByName(ref LicenseClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);

            else
                return null;
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassesDataAccess.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                this.DefaultValidityLength, this.ClassFees);

            return this.LicenseClassID != -1;
        }

        private bool _Update()
        {
            return clsLicenseClassesDataAccess.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public static DataTable GetAllLicenseClasss()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasss();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
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
