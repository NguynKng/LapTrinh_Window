using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace chuongtrinhquanlygarage.Database
{
    public class DatabaseContext
    {
        private readonly string _connectionString;
        private SQLiteConnection _connection;

        public DatabaseContext()
        {
            // Use ConfigurationManager to get the SQLite connection string from App.config or Web.config
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SQLiteConnection(_connectionString);
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }

        public void OpenConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error opening the database connection.", ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error closing the database connection.", ex);
            }
        }

        public void ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            OpenConnection();

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing the query.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteNonQueryAndReturnRowsAffected(string query, Dictionary<string, object> parameters = null)
        {
            OpenConnection();

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // ExecuteNonQuery returns the number of affected rows
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing the query.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            OpenConnection();
            DataTable result = new DataTable();

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing the select query.", ex);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
    }
}
