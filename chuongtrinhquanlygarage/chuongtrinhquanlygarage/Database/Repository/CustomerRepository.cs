using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chuongtrinhquanlygarage.Models;

namespace chuongtrinhquanlygarage.Database.Repository
{
    public class CustomerRepository
    {
        private readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool AddCustomerAndMotors(Motor motor)
        {
            string customerInsertQuery = @"INSERT INTO customers (customerID, name, address, phoneNumber, email)
                                   VALUES (@CustomerID, @Name, @Address, @PhoneNumber, @Email)";

            string motorInsertQuery = @"INSERT INTO motors (licensePlate, customerID, model, year)
                                VALUES (@LicensePlate, @CustomerID, @Model, @Year);";

            //Console.WriteLine($"Customer ID: {motor.Customer.Id}, License Plate: {motor.LicensePlate}, Models: {motor.Model}, Year: {motor.Year}");
            //Console.WriteLine($"Customer ID: {motor.Customer.Id}, Name: {motor.Customer.Name}, Email: {motor.Customer.Email}, phone: {motor.Customer.PhoneNumber}");
            // Parameters for the customer insert query
            var customerParams = new Dictionary<string, object>
            {
                { "@CustomerID", motor.Customer.Id },
                { "@Name", motor.Customer.Name },
                { "@Address", motor.Customer.Address },
                { "@PhoneNumber", motor.Customer.PhoneNumber },
                { "@Email", motor.Customer.Email },
            };

            // Parameters for the motor insert query
            var motorParams = new Dictionary<string, object>
            {
                { "@LicensePlate", motor.LicensePlate },
                { "@CustomerID", motor.Customer.Id },
                { "@Model", motor.Model },
                { "@Year", motor.Year }
            };

            try
            {
                // Execute customer insert query
                int rowAffectedCustomer = _context.ExecuteNonQueryAndReturnRowsAffected(customerInsertQuery, customerParams);

                // Ensure customer insertion was successful before proceeding to motor insertion
                if (rowAffectedCustomer > 0)
                {
                    //// Execute motor insert query
                    int rowAffectedMotor = _context.ExecuteNonQueryAndReturnRowsAffected(motorInsertQuery, motorParams);

                    if (rowAffectedMotor > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }


        // Update employee method using SQL query
        public bool UpdateCustomer(Motor motor)
        {
            // Step 1: Update the customer details
            string customerUpdateQuery = @"UPDATE customers 
                                   SET name = @Name, address = @Address, phoneNumber = @PhoneNum, email = @Email 
                                   WHERE customerID = @CustomerID";

            string motorUpdateQuery = @"UPDATE motors 
                                    SET licensePlate = @LicensePlate, model = @Model, year = @Year 
                                    WHERE licensePlate = @LicensePlate AND customerID = @CustomerID";

            var customerParams = new Dictionary<string, object>
            {
                { "@CustomerID", motor.Customer.Id },
                { "@Name", motor.Customer.Name },
                { "@Address", motor.Customer.Address },
                { "@PhoneNum", motor.Customer.PhoneNumber },
                { "@Email", motor.Customer.Email }
            };

            var motorParams = new Dictionary<string, object>
            {
                { "@LicensePlate", motor.LicensePlate },
                { "@CustomerID", motor.Customer.Id },
                { "@Model", motor.Model },
                { "@Year", motor.Year }
            };

            try
            {
                // Step 2: Execute the customer update query
                int customerRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(customerUpdateQuery, customerParams);

                // If no rows were affected, the customer update might have failed
                if (customerRowsAffected > 0)
                {
                    int motorRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(motorUpdateQuery, motorParams);
                    // If no rows were affected, the motor update might have failed
                    if (motorRowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle errors and log exception
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }


        public bool DeleteCustomerByID(string customerID)
        {
            // If user account deletion was successful, delete the employee
            string deleteCustomerQuery = @"DELETE FROM customers WHERE customerID = @CustomerID";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", customerID }
            };

            try
            {
                int customerRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deleteCustomerQuery, parameters);

                // Check if employee deletion was successful
                if (customerRowsAffected > 0)
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

        public Motor GetCustomerByLicensePlate(string licensePlate)
        {
            Motor motor = null;

            try
            {
                // Query to join customers and motors and fetch details by license plate
                string query = @"SELECT m.licensePlate, m.model, m.year, c.customerID, c.name AS customerName, 
                    c.phoneNumber, c.address, c.email FROM motors m JOIN customers c ON m.customerID = c.customerID WHERE 
                        m.licensePlate = @LicensePlate";

                var parameters = new Dictionary<string, object>
                {
                    { "@LicensePlate", licensePlate }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

                // Map the query result to a Motor object
                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    Customer customer = new Customer
                    {
                        Id = row["customerID"].ToString(),
                        Name = row["customerName"].ToString(),
                        PhoneNumber = row["phoneNumber"].ToString(),
                        Address = row["address"].ToString(),
                        Email = row["email"].ToString()
                    };

                    motor = new Motor(
                        customer,
                        row["licensePlate"].ToString(),
                        row["model"].ToString(),
                        row["year"] != DBNull.Value ? int.Parse(row["year"].ToString()) : 0
                    );
                }
                else
                {
                    Console.WriteLine("No motor found for the specified license plate.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving motor data.", ex);
            }

            return motor; // Return the Motor object
        }


        public List<Motor> GetAllCustomerWithMotor(string searchName = null)
        {
            List<Motor> motors = new List<Motor>();
            Dictionary<string, Customer> customerDict = new Dictionary<string, Customer>();

            try
            {
                // Step 1: Fetch all customers or filter by name
                string customerQuery = "SELECT customerID, name, phoneNumber, address, email FROM customers";
                var customerParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(searchName))
                {
                    customerQuery += " WHERE name LIKE @Name";
                    customerParams.Add("@Name", $"%{searchName}%");
                }

                customerQuery += " ORDER BY customerID"; // Add ORDER BY clause to sort by customerID

                var customerResult = _context.ExecuteSelectQuery(customerQuery, customerParams);

                // Store customers in a dictionary for easy lookup by customerID
                foreach (DataRow row in customerResult.Rows)
                {
                    Customer customer = new Customer
                    {
                        Id = row["customerID"].ToString(),
                        Name = row["name"].ToString(),
                        PhoneNumber = row["phoneNumber"].ToString(),
                        Address = row["address"].ToString(),
                        Email = row["email"].ToString(),
                    };

                    customerDict[customer.Id] = customer;
                }

                // Step 2: Fetch all motors and link with customer data
                string motorQuery = "SELECT licensePlate, customerID, model, year FROM motors order by customerID";
                var motorResult = _context.ExecuteSelectQuery(motorQuery, new Dictionary<string, object>());

                foreach (DataRow row in motorResult.Rows)
                {
                    string customerID = row["customerID"].ToString();
                    if (customerDict.TryGetValue(customerID, out Customer customer))
                    {
                        Motor motor = new Motor(customer,
                                                row["licensePlate"].ToString(),
                                                row["model"].ToString(),
                                                row["year"] != DBNull.Value ? int.Parse(row["year"].ToString()) : 0);

                        motors.Add(motor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving customer or motor data.", ex);
            }

            return motors;
        }

        public List<Motor> GetMotorWaiting(string searchName = null)
        {
            List<Motor> motors = new List<Motor>();
            Dictionary<string, Customer> customerDict = new Dictionary<string, Customer>();

            try
            {
                // Step 1: Fetch all customers or filter by name
                string customerQuery = "SELECT customerID, name, phoneNumber, address, email FROM customers";
                var customerParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(searchName))
                {
                    customerQuery += " WHERE name LIKE @Name";
                    customerParams.Add("@Name", $"%{searchName}%");
                }

                customerQuery += " ORDER BY customerID"; // Add ORDER BY clause to sort by customerID

                var customerResult = _context.ExecuteSelectQuery(customerQuery, customerParams);

                // Store customers in a dictionary for easy lookup by customerID
                foreach (DataRow row in customerResult.Rows)
                {
                    Customer customer = new Customer
                    {
                        Id = row["customerID"].ToString(),
                        Name = row["name"].ToString(),
                        PhoneNumber = row["phoneNumber"].ToString(),
                        Address = row["address"].ToString(),
                        Email = row["email"].ToString(),
                    };

                    customerDict[customer.Id] = customer;
                }

                // Step 2: Fetch all motors and link with customer data
                string motorQuery = "SELECT licensePlate, customerID, model, year FROM motors where licensePlate not in (select licensePlate from RepairOrder where status != 'Hoàn Thành') order by customerID";
                var motorResult = _context.ExecuteSelectQuery(motorQuery, new Dictionary<string, object>());

                foreach (DataRow row in motorResult.Rows)
                {
                    string customerID = row["customerID"].ToString();
                    if (customerDict.TryGetValue(customerID, out Customer customer))
                    {
                        Motor motor = new Motor(customer,
                                                row["licensePlate"].ToString(),
                                                row["model"].ToString(),
                                                row["year"] != DBNull.Value ? int.Parse(row["year"].ToString()) : 0);

                        motors.Add(motor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving customer or motor data.", ex);
            }

            return motors;
        }

        public string GetNextCustomerID()
        {
            // Query to get the highest customerID in the database
            string query = "SELECT TOP 1 customerID FROM customers ORDER BY customerID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there are no customers, start with "KH00000001"
            if (result.Rows.Count == 0)
            {
                return "KH00000001";
            }

            // Get the highest customerID
            string lastCustomerID = result.Rows[0]["customerID"].ToString();

            // Extract the numeric part of the customerID (assumes format "KH00000001")
            int numericPart = int.Parse(lastCustomerID.Substring(2));

            // Increment the numeric part
            numericPart++;

            // Generate the next customerID, formatted as "KH00000002"
            return "KH" + numericPart.ToString("D8");  // "D8" ensures the number is padded to 8 digits
        }

    }
}
