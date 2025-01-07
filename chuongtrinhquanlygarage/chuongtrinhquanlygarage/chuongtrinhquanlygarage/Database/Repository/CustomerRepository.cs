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

           
            var customerParams = new Dictionary<string, object>
            {
                { "@CustomerID", motor.Customer.Id },
                { "@Name", motor.Customer.Name },
                { "@Address", motor.Customer.Address },
                { "@PhoneNumber", motor.Customer.PhoneNumber },
                { "@Email", motor.Customer.Email },
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
                int rowAffectedCustomer = _context.ExecuteNonQueryAndReturnRowsAffected(customerInsertQuery, customerParams);

                if (rowAffectedCustomer > 0)
                {
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
                int customerRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(customerUpdateQuery, customerParams);

                if (customerRowsAffected > 0)
                {
                    int motorRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(motorUpdateQuery, motorParams);
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
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }


        public bool DeleteCustomerByID(string customerID)
        {
            string deleteCustomerQuery = @"DELETE FROM customers WHERE customerID = @CustomerID";

            var parameters = new Dictionary<string, object>
            {
                { "@CustomerID", customerID }
            };

            try
            {
                int customerRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deleteCustomerQuery, parameters);

                if (customerRowsAffected > 0)
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

        public Motor GetCustomerByLicensePlate(string licensePlate)
        {
            Motor motor = null;

            try
            {
                string query = @"SELECT m.licensePlate, m.model, m.year, c.customerID, c.name AS customerName, 
                    c.phoneNumber, c.address, c.email FROM motors m JOIN customers c ON m.customerID = c.customerID WHERE 
                        m.licensePlate = @LicensePlate";

                var parameters = new Dictionary<string, object>
                {
                    { "@LicensePlate", licensePlate }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

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

            return motor;
        }


        public List<Motor> GetAllCustomerWithMotor(string searchName = null)
        {
            List<Motor> motors = new List<Motor>();
            Dictionary<string, Customer> customerDict = new Dictionary<string, Customer>();

            try
            {
                string customerQuery = "SELECT customerID, name, phoneNumber, address, email FROM customers";
                var customerParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(searchName))
                {
                    customerQuery += " WHERE name LIKE @Name";
                    customerParams.Add("@Name", $"%{searchName}%");
                }

                customerQuery += " ORDER BY customerID";

                var customerResult = _context.ExecuteSelectQuery(customerQuery, customerParams);

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
                string customerQuery = "SELECT customerID, name, phoneNumber, address, email FROM customers";
                var customerParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(searchName))
                {
                    customerQuery += " WHERE lower(name) LIKE @Name";
                    customerParams.Add("@Name", $"%{searchName.ToLower()}%");
                }

                customerQuery += " ORDER BY customerID";

                var customerResult = _context.ExecuteSelectQuery(customerQuery, customerParams);

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
            string query = "SELECT customerID FROM customers ORDER BY customerID DESC Limit 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "KH00000001";
            }

            string lastCustomerID = result.Rows[0]["customerID"].ToString();

            int numericPart = int.Parse(lastCustomerID.Substring(2));

            numericPart++;

            return "KH" + numericPart.ToString("D8");
        }

    }
}
