using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DVLD_Business;
using Microsoft.Win32;
using System.Diagnostics;

namespace DrivingVehiclesLicense
{
    public class clsGlobal
    {
        public static clsUser CurrentUser; // The Current User of the System

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            // This function get the Username and Password from the Login Screen and
            // put the Username and Password in the Windows Registry Current User file.

            string keyPath = @"HKEY_CURRENT_USER\Software\DVLDUserInfo";

            string usernameValue = "Username";
            string passwordValue = "Password";

            try
            {
                Registry.SetValue(keyPath, usernameValue, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, passwordValue, Password, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);

                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            // This function is to get the Stored Username and Password from the Windows Registry 
            // then we have a stored data so we need to get them and Store them in Username 
            // and Password Referenced Parameters and return true if it's done

            string keyPath = @"HKEY_CURRENT_USER\Software\DVLDUserInfo";

            string usernameValue = "Username";
            string passwordValue = "Password";

            try
            {
                Username = Registry.GetValue(keyPath, usernameValue, null) as string;
                Password = Registry.GetValue(keyPath, passwordValue, null) as string;

                if (Username != null && Password != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);

                return false;
            }
        }
    }
}
