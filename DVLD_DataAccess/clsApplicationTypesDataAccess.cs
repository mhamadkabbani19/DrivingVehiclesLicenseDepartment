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
    public class clsApplicationTypesDataAccess
    {
        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];
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

        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int ApplicationTypeID = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Insert Into ApplicationTypes
                             (ApplicationTypeTitle, ApplicationFees)
                             Values (@ApplicationTypeTitle, @ApplicationFees);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    ApplicationTypeID = InsertedID;
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

            return ApplicationTypeID;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update ApplicationTypes
                             Set ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                             Where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM ApplicationTypes ORDER BY ApplicationTypeTitle";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    dtApplicationTypes.Load(reader);
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

            return dtApplicationTypes;
        }
    }
}
