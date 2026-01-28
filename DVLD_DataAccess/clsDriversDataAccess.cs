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
    public class clsDriversDataAccess
    {
        public static bool GetDriverByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GetDriverByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    DriverID = InsertedID;
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

            return DriverID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update Drivers
                         Set PersonID = @PersonID,
                             CreatedByUserID = @CreatedByUserID
                         Where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static DataTable GetAllDrivers()
        {
            DataTable dtDrivers = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Drivers_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    dtDrivers.Load(reader);
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

            return dtDrivers;
        }
    }
}
