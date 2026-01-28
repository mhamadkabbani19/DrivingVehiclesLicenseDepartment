using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace DrivingVehiclesLicense
{
    public class clsUtil
    {
        public static string GenerateGuid()
        {
            Guid guid = new Guid();

            return guid.ToString();
        }

        public static bool CreateFileIfDoesNotExists(string FilePath)
        {
            if (!Directory.Exists(FilePath))
            {
                try
                {
                    Directory.CreateDirectory(FilePath);
                    return true;
                }
                catch (IOException ex)
                {
                    string sourceName = "DVLD";

                    if (!EventLog.SourceExists(sourceName))
                        EventLog.CreateEventSource(sourceName, "Application");

                    EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
                }
            }

            return true;
        }

        public static string ReplaceFileNameWithGuid(string sourcePath)
        {
            // This function Replace the file name with a guid by get the Path and get its Extention and 
            // Generate a guid then concatinate it with the Extention

            string FileName = sourcePath;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension;
            return GenerateGuid() + extn;
        }

        public static bool CopyImageToProjectImageFolder(ref string sourceFile)
        {
            // This function is to Copy the image to images of the project folder by initialize the Destination Folder
            // and concatinate it with the image path that has been a Guid with an Extention then copy it to the Project Images Folder

            string destinationFolder = @"C:\Users\HP\source\repos\DrivingVehiclesLicense\PeopleImages";

            if (!CreateFileIfDoesNotExists(destinationFolder))
                return false;

            string destinationFile = destinationFolder + ReplaceFileNameWithGuid(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }

            sourceFile = destinationFile;
            return true;
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
