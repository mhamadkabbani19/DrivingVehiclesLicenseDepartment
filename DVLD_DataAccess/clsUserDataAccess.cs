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
    public class clsUserDataAccess
    {
        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;

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

        public static bool GetUserByPersonID(ref int UserID, int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;

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

        public static bool GetUserByUserNameAndPassword(ref int UserID, ref int PersonID, string UserName, string Password, ref bool IsActive)
        {
            bool isFound = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;

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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                             VALUES (@PersonID, @UserName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    UserID = InsertedID;
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

            return UserID;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update Users
                         Set PersonID = @PersonID,
                             UserName = @UserName,
                             Password = @Password,
                             IsActive = @IsActive
                         Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Delete From Users
                             Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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

            return dtUsers;
        }

        public static bool isUserExists(int UserID)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                result = false;
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

        public static bool isUserExists(string UserName)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                result = false;

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

        public static bool isUserExistsForPersonID(int PersonID)
        {
            bool result = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;

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

            return result;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Update Users
                             Set Password = @Password
                             Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", NewPassword);

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
    }
}
