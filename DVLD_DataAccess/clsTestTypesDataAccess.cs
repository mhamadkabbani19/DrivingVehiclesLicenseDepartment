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
    public class clsTestTypesDataAccess
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];
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

        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int TestTypeID = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                                            VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    TestTypeID = InsertedID;
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

            return TestTypeID;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update TestTypes
                             Set TestTypeTitle = @TestTypeTitle,
                                 TestTypeDescription = @TestTypeDescription,
                                 TestTypeFees = @TestTypeFees
                             Where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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

        public static DataTable GetAllTestTypes()
        {
            DataTable dtTestTypes = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM TestTypes ORDER BY TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtTestTypes.Load(reader);
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

            return dtTestTypes;
        }
    }
}
