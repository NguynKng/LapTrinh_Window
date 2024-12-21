using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace chuongtrinhquanlygarage.Database
{
    public class DatabaseContext
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public SqlConnection GetConnection()
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
                using (SqlCommand command = new SqlCommand(query, _connection))
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
                using (SqlCommand command = new SqlCommand(query, _connection))
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
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
