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
            // Step 2: Get empTypeID for the specified employee's role (empType)
            string getRoleIDQuery = "SELECT empTypeID FROM empType WHERE name = @EmpType";

            string empTypeID = null;

            var roleParams = new Dictionary<string, object>
            {
                { "@EmpType", employee.EmpType }
            };

            try
            {
                // Execute the query to get the empTypeID
                var roleResult = _context.ExecuteSelectQuery(getRoleIDQuery, roleParams);

                // If the query returns a result, assign the empTypeID
                if (roleResult.Rows.Count > 0)
                {
                    empTypeID = roleResult.Rows[0]["empTypeID"].ToString();
                }
                else
                {
                    // Handle case when the empType does not exist (optional)
                    Console.WriteLine($"Role {employee.EmpType} not found.");
                    return false;
                }

                // Step 3: Insert the new employee into the database
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

                // Step 4: Execute the insert query for the employee
                _context.ExecuteQuery(employeeInsertQuery, employeeParams);
                return true;
            }
            catch (Exception ex)
            {
                // Step 5: Handle errors and throw custom exception
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        // Update employee method using SQL query
        public bool UpdateEmployee(Employee employee)
        {
            // Step 2: Get empTypeID for the specified employee's role (empType)
            string getRoleIDQuery = "SELECT empTypeID FROM empType WHERE name = @EmpType";

            string empTypeID = null;

            var roleParams = new Dictionary<string, object>
            {
                { "@EmpType", employee.EmpType }
            };

            try
            {
                // Execute the query to get the empTypeID
                var roleResult = _context.ExecuteSelectQuery(getRoleIDQuery, roleParams);

                // If the query returns a result, assign the empTypeID
                if (roleResult.Rows.Count > 0)
                {
                    empTypeID = roleResult.Rows[0]["empTypeID"].ToString();
                }
                else
                {
                    // Handle case when the empType does not exist (optional)
                    Console.WriteLine($"Role {employee.EmpType} not found.");
                    return false;
                }

                // Step 3: Insert the new employee into the database
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

                // If no rows were affected, the update might have failed
                if (rowsAffected == 0)
                {
                    Console.WriteLine("No rows were updated.");
                    return false;
                }

                return true; // Successful update
            }
            catch (Exception ex)
            {
                // Step 5: Handle errors and throw custom exception
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEmployeeByID(string employeeID)
        {
            // If user account deletion was successful, delete the employee
            string deleteEmployeeQuery = @"DELETE FROM employees WHERE employeeID = @EmployeeID";
            var parameters = new Dictionary<string, object>
            {
                { "@EmployeeID", employeeID }
            };

            try
            {
                int employeeRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deleteEmployeeQuery, parameters);

                // Check if employee deletion was successful
                if (employeeRowsAffected > 0)
                {
                    return true; // Successfully deleted both employee and user account
                }
                else
                {
                    // Handle the case where employee deletion failed
                    return false; // Employee deletion failed
                }
            }
            catch (Exception ex)
            {
                // Log or handle any errors
                throw new Exception("Error occurred while deleting employee and user account.", ex);
            }
        }


        public Employee GetEmployeeByID(string employeeID)
        {
            Employee employee = null;

            // SQL query to get employee details by employeeID
            string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, name, baseSalary
                FROM employees join empType on (employees.empTypeID = empType.empTypeID)
                WHERE employeeID = @EmployeeID;";

            var parameters = new Dictionary<string, object>
            {
                { "@EmployeeID", employeeID }
            };

            try
            {
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    // Map the result to an Employee object
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

            // SQL query to get all employees with their details
            try
            {
                string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, empType.name AS EmpType, baseSalary
                     FROM employees JOIN empType ON employees.empTypeID = empType.empTypeID";

                var employeeParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE employeeName LIKE @Name";
                    employeeParams.Add("@Name", $"%{name}%");
                }
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, employeeParams);

                // Loop through the results and map them to Employee objects
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

                    // Add each employee to the list
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
            // Query to get the highest employeeID in the database
            string query = "SELECT TOP 1 employeeID FROM employees ORDER BY employeeID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there is no employee, start with "E0001"
            if (result.Rows.Count == 0)
            {
                return "E0001";
            }

            // Get the highest employeeID and increment it
            string lastEmployeeID = result.Rows[0]["employeeID"].ToString();

            // Extract the numeric part of the employeeID (assumes format "E0001")
            int numericPart = int.Parse(lastEmployeeID.Substring(1));

            // Increment the numeric part
            numericPart++;

            // Generate the next employeeID (e.g., "E0002")
            return "E" + numericPart.ToString("D4");
        }

        public bool ExistedPhoneNumber(string number)
        {
            // SQL query to check if the username exists in the users table
            string query = "SELECT phoneNumber FROM employees WHERE phoneNumber = @Number";

            var parameters = new Dictionary<string, object>
            {
                { "@Number", number }
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

        public bool ExistedEmail(string email)
        {
            // SQL query to check if the username exists in the users table
            string query = "SELECT email FROM employees WHERE email = @Email";

            var parameters = new Dictionary<string, object>
            {
                { "@Email", email }
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

        public List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();

            // SQL query to get all roles from the empType table
            string query = @"SELECT name FROM empType";

            try
            {
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query);

                // Iterate through the rows and add roles to the list
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
                // SQL query to get all employees with their details
                string query = @"SELECT employeeID, employeeName, phoneNumber, gender, email, empType.name AS EmpType, baseSalary
                     FROM employees JOIN empType ON employees.empTypeID = empType.empTypeID where empType.name = @Role";
                var parameters = new Dictionary<string, object>
                {
                    { "@Role", role }
                };
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, parameters);

                // Loop through the results and map them to Employee objects
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

                    // Add each employee to the list
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
