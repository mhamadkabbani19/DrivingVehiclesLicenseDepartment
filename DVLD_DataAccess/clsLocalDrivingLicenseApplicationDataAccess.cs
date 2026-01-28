using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        public static bool GetLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetLocalDrivingLicenseApplicationByApplicationID(ref int LocalDrivingLicenseApplicationID, int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dtApplications = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View ORDER BY ApplicationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    dtApplications.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dtApplications;
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"INSERT INTO LocalDrivingLicenseApplications 
                                    (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    LocalDrivingLicenseApplicationID = InsertedID;
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update LocalDrivingLicenseApplications
                         Set ApplicationID = @ApplicationID,
                             LicenseClassID = @LicenseClassID
                         Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeleteLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Delete From LocalDrivingLicenseApplications
                             Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select top 1 TestResult from LocalDrivingLicenseApplications INNER JOIN 
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TestAppointments.TestTypeID = @TestTypeID
                             ORDER BY TestAppointments.TestAppointmentID Desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    result = (bool)reader["TestResult"];
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select top 1 Found=1 from LocalDrivingLicenseApplications INNER JOIN 
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TestAppointments.TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select TotalTrialsPerTest = count(TestID) from LocalDrivingLicenseApplications INNER JOIN 
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TestAppointments.TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    TotalTrialsPerTest = (byte)reader["TotalTrialsPerTest"];
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;
        }

        public static bool isThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"select top 1 Found=1 from LocalDrivingLicenseApplications INNER JOIN 
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TestAppointments.TestTypeID = @TestTypeID AND TestAppointments.IsLocked = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";

                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
