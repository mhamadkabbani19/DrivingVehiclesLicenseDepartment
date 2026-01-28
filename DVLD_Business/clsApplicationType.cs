using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }

        public string ApplicationTypeTitle { get; set; }

        public decimal ApplicationFees { get; set; }

        enum enMode { AddNew, Update }
        enMode Mode;

        private clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0.0m;

            Mode = enMode.AddNew;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationTypeFees;

            Mode = enMode.Update;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationTypeFees = 0.0m;

            if (clsApplicationTypesDataAccess.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);

            else
                return null;
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationTypesDataAccess.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);

            return this.ApplicationTypeID != -1;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplicationType();
            }

            return false;
        }
    }
}
