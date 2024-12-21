using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chuongtrinhquanlygarage.Models;

namespace chuongtrinhquanlygarage.Database.Repository
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User getUserByUsername(string username)
        {
            User user = null;

            string query = "SELECT userID, username, password, role, createdAt, updatedAt FROM users WHERE username = @Username";

            var parameters = new Dictionary<string, object> {
                { "@Username", username }
            };

            try
            {
                DataTable result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];

                    user = new User
                    {
                        UserID = row["userID"].ToString(),
                        Username = row["username"].ToString(),
                        PasswordHash = row["password"].ToString(),
                        Role = row["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(row["createdAt"]),
                        UpdatedAt = row["updatedAt"] as DateTime?
                    };
                }
            } catch (Exception ex) {
                throw new Exception("Error occurred while logging in.", ex);
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            // SQL query to retrieve all user data
            string query = @"SELECT userID, employeeID, username, role , createdAt, updatedAt FROM users";

            try
            {
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query);

                // Loop through the result rows and map them to User objects
                foreach (DataRow row in result.Rows)
                {
                    User user = new User
                    {
                        UserID = row["userID"].ToString(),
                        EmpID = row["employeeID"].ToString(),
                        Username = row["username"].ToString(),
                        Role = row["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(row["createdAt"]),
                        UpdatedAt = row["updatedAt"] as DateTime?
                    };

                    // Add the user to the list
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception("Error occurred while retrieving users from the database.", ex);
            }

            return users;
        }

        public User getUserByEmpID(string empID)
        {
            User user = null;

            string query = "SELECT userID, employeeID, username, password, role, createdAt, updatedAt FROM users WHERE employeeID = @EmpID";

            var parameters = new Dictionary<string, object> {
                { "@EmpID", empID }
            };

            try
            {
                DataTable result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];

                    user = new User
                    {
                        UserID = row["userID"].ToString(),
                        Username = row["username"].ToString(),
                        PasswordHash = row["password"].ToString(),
                        Role = row["role"].ToString(),
                        CreatedAt = Convert.ToDateTime(row["createdAt"]),
                        UpdatedAt = row["updatedAt"] as DateTime?
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while logging in.", ex);
            }

            return user;
        }

        public bool AddUserAccount(User user)
        {
            string userInsertQuery = @"INSERT INTO users (userID, username, password, role, employeeID)
                    VALUES (@UserID, @Username, @Password, @Role, @EmployeeID)";

            var userParams = new Dictionary<string, object>
                {
                    { "@UserID", user.UserID },
                    { "@Username", user.Username },
                    { "@Password", user.PasswordHash }, // Ensure to hash the password in real-world scenarios
                    { "@Role", user.Role },  // Assuming the role is "employee" by default
                    { "@EmployeeID", user.EmpID }
                };
            try
            {
                // Query to insert a new user account

                // Execute the query to insert the user account
                _context.ExecuteQuery(userInsertQuery, userParams);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding the user account.", ex);
                return false;

            }
        }

        public bool DeleteUserAccountByID(string userID)
        {
            // SQL query to delete the user account by employeeID
            string query = @"DELETE FROM users WHERE userID = @UserID";

            var parameters = new Dictionary<string, object>
            {
                { "@UserID", userID }
            };

            try
            {
                // Execute the query to delete the user account
                int rowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(query, parameters);

                // If rowsAffected is greater than 0, deletion was successful
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it, rethrow, or return false)
                throw new Exception("Error occurred while deleting the user account.", ex);
            }
        }

        public string GetNextUserID()
        {
            // Query to get the highest employeeID in the database
            string query = "SELECT TOP 1 userID FROM users ORDER BY userID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there is no employee, start with "E0001"
            if (result.Rows.Count == 0)
            {
                return "U0001";
            }

            // Get the highest employeeID and increment it
            string lastEmployeeID = result.Rows[0]["userID"].ToString();

            // Extract the numeric part of the employeeID (assumes format "E0001")
            int numericPart = int.Parse(lastEmployeeID.Substring(1));

            // Increment the numeric part
            numericPart++;

            // Generate the next employeeID (e.g., "E0002")
            return "U" + numericPart.ToString("D4");
        }

        public bool ExistedUsername(string username)
        {
            // SQL query to check if the username exists in the users table
            string query = "SELECT username FROM users WHERE username = @Username";

            var parameters = new Dictionary<string, object>
            {
                { "@Username", username }
            };

            try
            {
                // Execute the query
                var result = _context.ExecuteSelectQuery(query, parameters);

                // If the result count is greater than 0, it means the username exists
                if (result.Rows.Count > 0)
                {
                    return true;  // Username exists
                }

                return false;  // Username does not exist
            }
            catch (Exception ex)
            {
                // Handle exceptions (optional: log the error or rethrow)
                Console.WriteLine($"Error checking username: {ex.Message}");
                return false;  // Return false if an error occurs
            }
        }
    }
}
