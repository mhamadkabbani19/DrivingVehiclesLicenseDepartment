using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccess;
using System.Security.Cryptography;

namespace DVLD_Business
{
    public class clsUser
    {
        public int UserID { get; set; }

        public int PersonID { get; set; }
        public clsPerson PersonInfo;

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        enum enMode { AddNew, Update };

        enMode Mode = enMode.AddNew;

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, ComputeHash(this.Password), this.IsActive);

            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, ComputeHash(this.Password), this.IsActive);
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUserDataAccess.GetUserByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUserDataAccess.GetUserByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static bool Delete(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool isUserExists(int UserID)
        {
            return clsUserDataAccess.isUserExists(UserID);
        }

        public static bool isUserExists(string UserName)
        {
            return clsUserDataAccess.isUserExists(UserName);
        }

        public static bool isUserExistsByPersonID(int PersonID)
        {
            return clsUserDataAccess.isUserExistsForPersonID(PersonID);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserDataAccess.ChangePassword(this.UserID, NewPassword);
        }
    }
}
