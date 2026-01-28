using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
        }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryDataAccess.GetCountryByID(CountryID, ref CountryName))
                return new clsCountry(CountryID, CountryName);

            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryDataAccess.GetCountryByName(ref CountryID, CountryName))
                return new clsCountry(CountryID, CountryName);

            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
    }
}
