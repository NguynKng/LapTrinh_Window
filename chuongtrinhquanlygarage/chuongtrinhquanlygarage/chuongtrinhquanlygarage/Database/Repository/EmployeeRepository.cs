using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chuongtrinhquanlygarage.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace chuongtrinhquanlygarage.Database.Repository
{
    public class EmployeeRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool AddEmployee(Employee employee)
        {
            string getRoleIDQuery = "SELECT empTypeID FROM empType WHERE name = @EmpType";

            string empTypeID = null;

            var roleParams = new Dictionary<string, object>
            {
                { "@EmpType", employee.EmpType }
            };

            try
            {
                var roleResult = _context.ExecuteSelectQuery(getRoleIDQuery, roleParams);

                if (roleResult.Rows.Count > 0)
                {
                    empTypeID = roleResult.Rows[0]["empTypeID"].ToString();
                }
                else
                {
                    Console.WriteLine($"Role {employee.EmpType} not found.");
                    return false;
                }

                string employeeInsertQuery = @"INSERT INTO employees (employeeID, employeeName, phoneNumber, gender, email, empTypeID, baseSalary)
                    VALUES (@EmployeeID, @EmployeeName, @PhoneNumber, @Gender, @Email, @EmpTypeID, @BaseSalary);";

                var employeeParams = new Dictionary<string, object>
                {
                    { "@EmployeeID", employee.Id },
                    { "@EmployeeName", employee.Name },
                    { "@PhoneNumber", employee.PhoneNumber },
                    { "@Gender", employee.Gender },
                    { "@Email", employee.Email },
                    { "@EmpTypeID", empTypeID },
                    { "@BaseSalary", employee.BaseSalary }
                };

                _context.ExecuteQuery(employeeInsertQuery, employeeParams);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            string getRoleIDQuery = "SELECT empTypeID FROM empType WHERE name = @EmpType";

            string empTypeID = null;

            var roleParams = new Dictionary<string, object>
            {
                { "@EmpType", employee.EmpType }
            };

            try
            {
                var roleResult = _context.ExecuteSelectQuery(getRoleIDQuery, roleParams);

                if (roleResult.Rows.Count > 0)
                {
                    empTypeID = roleResult.Rows[0]["empTypeID"].ToString();
                }
                else
                {
                    Console.WriteLine($"Role {employee.EmpType} not found.");
                    return false;
                }

                string employeeUpdateQuery = @"Update employees set employeeName = @Name, phoneNumber = @PhoneNum, 
                                                gender = @Gender, email = @Email, empTypeID = @EmpTypeID, 
                                                    baseSalary = @BaseSalary where employeeID = @EmployeeID";

                var employeeParams = new Dictionary<string, object>
                {
                    { "@EmployeeID", employee.Id },
                    { "@Name", employee.Name },
                    { "@PhoneNum", employee.PhoneNumber },
                    { "@Gender", employee.Gender },
                    { "@Email", employee.Email },
                    { "@EmpTypeID", empTypeID },
                    { "@BaseSalary", employee.BaseSalary }
                };

                int rowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(employeeUpdateQuery, employeeParams);

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No rows were updated.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEmployeeByID(string employeeID)
        {
            string deleteEmployeeQuery = @"DELETE FROM employees WHERE employeeID = @EmployeeID";
            var parameters = new Dictionary<string, object>
            {
                { "@EmployeeID", employeeID }
            };

            try
            {
                int employeeRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deleteEmployeeQuery, parameters);

                if (employeeRowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting employee and user account.", ex);
            }
        }


        public Employee GetEmployeeByID(string employeeID)
        {
            Employee employee = null;

            string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, name, baseSalary
                FROM employees join empType on (employees.empTypeID = empType.empTypeID)
                WHERE employeeID = @EmployeeID;";

            var parameters = new Dictionary<string, object>
            {
                { "@EmployeeID", employeeID }
            };

            try
            {
                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    employee = new Employee
                    {
                        Id = result.Rows[0]["employeeID"].ToString(),
                        Name = result.Rows[0]["employeeName"].ToString(),
                        PhoneNumber = result.Rows[0]["phoneNumber"].ToString(),
                        Gender = result.Rows[0]["gender"].ToString(),
                        Email = result.Rows[0]["email"].ToString(),
                        EmpType = result.Rows[0]["name"].ToString(),
                        BaseSalary = result.Rows[0]["baseSalary"] != DBNull.Value ? int.Parse(result.Rows[0]["baseSalary"].ToString()) : 0
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving employee data.", ex);
            }

            return employee;
        }


        public List<Employee> GetAllEmployees(string name = null)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, empType.name AS EmpType, baseSalary
                     FROM employees JOIN empType ON employees.empTypeID = empType.empTypeID";

                var employeeParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE lower(employeeName) LIKE @Name";
                    employeeParams.Add("@Name", $"%{name.ToLower()}%");
                }
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, employeeParams);

                foreach (DataRow row in result.Rows)
                {
                    Employee employee = new Employee
                    {
                        Id = row["employeeID"].ToString(),
                        Name = row["employeeName"].ToString(),
                        PhoneNumber = row["phoneNumber"].ToString(),
                        Gender = row["gender"].ToString(),
                        Email = row["email"].ToString(),
                        BaseSalary = row["baseSalary"] != DBNull.Value ? int.Parse(row["baseSalary"].ToString()) : 0,
                        EmpType = row["EmpType"].ToString(),
                    };

                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving employee data.", ex);
            }

            return employees;
        }


        public string GetNextEmployeeID()
        {
            string query = "SELECT employeeID FROM employees ORDER BY employeeID DESC limit 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "E0001";
            }

            string lastEmployeeID = result.Rows[0]["employeeID"].ToString();

            int numericPart = int.Parse(lastEmployeeID.Substring(1));

            numericPart++;

            return "E" + numericPart.ToString("D4");
        }

        public bool ExistedPhoneNumber(string number)
        {
            string query = "SELECT phoneNumber FROM employees WHERE phoneNumber = @Number";

            var parameters = new Dictionary<string, object>
            {
                { "@Number", number }
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

        public bool ExistedEmail(string email)
        {
            string query = "SELECT email FROM employees WHERE email = @Email";

            var parameters = new Dictionary<string, object>
            {
                { "@Email", email }
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

        public List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();

            string query = @"SELECT name FROM empType";

            try
            {
                var result = _context.ExecuteSelectQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    roles.Add(row["name"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving employee data.", ex);
            }

            return roles;
        }

        public List<Employee> GetEmployeeByRole(string role)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, empType.name AS EmpType, baseSalary
                     FROM employees JOIN empType ON employees.empTypeID = empType.empTypeID where empType.name = @Role";
                var parameters = new Dictionary<string, object>
                {
                    { "@Role", role }
                };
                var result = _context.ExecuteSelectQuery(query, parameters);

                foreach (DataRow row in result.Rows)
                {
                    Employee employee = new Employee
                    {
                        Id = row["employeeID"].ToString(),
                        Name = row["employeeName"].ToString(),
                        PhoneNumber = row["phoneNumber"].ToString(),
                        Gender = row["gender"].ToString(),
                        Email = row["email"].ToString(),
                        BaseSalary = row["baseSalary"] != DBNull.Value ? int.Parse(row["baseSalary"].ToString()) : 0,
                        EmpType = row["EmpType"].ToString(),
                    };

                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving employee data.", ex);
            }
            return employees;
        }

    }
}
