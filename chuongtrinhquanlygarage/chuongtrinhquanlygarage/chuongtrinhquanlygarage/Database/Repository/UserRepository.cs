using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chuongtrinhquanlygarage.Models;
using System.IO;
using System.Windows.Forms;

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

            string query = "SELECT userID, employeeID, username, password, role, createdAt, updatedAt FROM users WHERE username = @Username";

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
                        EmpID = row["employeeID"].ToString(),
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

            string query = @"SELECT userID, employeeID, username, role , createdAt, updatedAt FROM users";

            try
            {
                var result = _context.ExecuteSelectQuery(query);

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

                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
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
                    { "@Password", user.PasswordHash },
                    { "@Role", user.Role },
                    { "@EmployeeID", user.EmpID }
                };
            try
            {

                _context.ExecuteQuery(userInsertQuery, userParams);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding the user account.", ex);
                return false;

            }
        }

        public string GetRoleEmployee(string empID)
        {
            string userRoleQuery = @"select et.name as ChucVu 
from employees e join empType et on e.empTypeID = et.empTypeID 
join users u on u.employeeID = e.employeeID where u.employeeID = @EmpID";

            var userParams = new Dictionary<string, object>
                {
                    {"@EmpID", empID }
                };
            try
            {
                var result = _context.ExecuteSelectQuery(userRoleQuery, userParams);

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["ChucVu"].ToString();
                }
                else
                {
                    return "Role not found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while get employee role.", ex);
                return "Something wrong";
            }
        }

        public bool DeleteUserAccountByID(string userID)
        {
            string query = @"DELETE FROM users WHERE userID = @UserID";

            var parameters = new Dictionary<string, object>
            {
                { "@UserID", userID }
            };

            try
            {
                int rowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(query, parameters);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the user account.", ex);
            }
        }

        public string GetNextUserID()
        {
            string query = "SELECT userID FROM users ORDER BY userID DESC limit 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "U0001";
            }

            string lastEmployeeID = result.Rows[0]["userID"].ToString();

            int numericPart = int.Parse(lastEmployeeID.Substring(1));

            numericPart++;

            return "U" + numericPart.ToString("D4");
        }

        public bool ExistedUsername(string username)
        {
            string query = "SELECT username FROM users WHERE username = @Username";

            var parameters = new Dictionary<string, object>
            {
                { "@Username", username }
            };

            try
            {
                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking username: {ex.Message}");
                return false;
            }
        }
    }
}
