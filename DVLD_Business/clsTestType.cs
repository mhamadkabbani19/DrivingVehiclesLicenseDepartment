using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsTestType
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.Update;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public clsTestType.enTestType TestTypeID { get; set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public decimal TestTypeFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0.0m;

            Mode = enMode.AddNew;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            Mode = enMode.Update;
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = 0.0m;

            if (clsTestTypesDataAccess.GetTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

            else
                return null;
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (clsTestType.enTestType)clsTestTypesDataAccess.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return this.TestTypeTitle != "";
        }

        public bool _UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestType();
            }

            return false;
        }
    }
}
