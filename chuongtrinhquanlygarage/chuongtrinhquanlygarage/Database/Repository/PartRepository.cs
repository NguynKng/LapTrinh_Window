using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using chuongtrinhquanlygarage.Models;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace chuongtrinhquanlygarage.Database.Repository
{
    public class PartRepository
    {
        private readonly DatabaseContext _context;

        public PartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Part> GetAllParts(string name = null)
        {
            List<Part> parts = new List<Part>();

            // SQL query to get all employees with their details

            try
            {
                string query = @"SELECT partID, partName, quantity, price, buyPrice, employeePrice, limitStock, unit FROM parts";

                var partParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE partName LIKE @Name";
                    partParams.Add("@Name", $"%{name}%");
                }
                query += " Order by partName asc";
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, partParams);

                // Loop through the results and map them to Employee objects
                foreach (DataRow row in result.Rows)
                {
                    Part part = new Part
                    {
                        PartId = row["partID"].ToString(),
                        PartName = row["partName"].ToString(),
                        Quantity = int.Parse(row["quantity"].ToString()),
                        Price = int.Parse(row["price"].ToString()),
                        BuyPrice = int.Parse(row["buyPrice"].ToString()),
                        EmployeePrice = int.Parse(row["employeePrice"].ToString()),
                        LimitStock = int.Parse(row["limitStock"].ToString()),
                        Unit = row["unit"].ToString()
                    };

                    // Add each employee to the list
                    parts.Add(part);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving part data.", ex);
            }

            return parts;
        }

        public bool updatePartQuantity(List <Part> parts)
        {
            if (parts == null || parts.Count == 0)
            {
                MessageBox.Show("Nothing to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                string detailInsertQuery = @"update parts set quantity = quantity - @Quantity where @PartID = partID";

                foreach (var part in parts)
                {
                    var detailParams = new Dictionary<string, object>
                    {
                        { "@PartID", part.PartId },
                        { "@Quantity", part.Quantity }
                    };

                    _context.ExecuteQuery(detailInsertQuery, detailParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update part quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<Part> GetListPartFromOrder(string repairOrderID)
        {
            if (string.IsNullOrEmpty(repairOrderID))
            {
                MessageBox.Show("Order ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                string query = "select p.partID, partName, r.quantity, r.price, unit from parts p join RepairDetail r on (p.partID = r.partID) " +
                "where r.RepairOrderID = @RepairOrderID";

                var parameters = new Dictionary<string, object>
                {
                    { "@RepairOrderID", repairOrderID }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("No part found for this order.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                List<Part> listParts = new List<Part>();

                foreach (DataRow row in result.Rows)
                {
                    Part part = new Part
                    {
                        PartId = row["partID"].ToString(),
                        PartName = row["partName"].ToString(),
                        Quantity = Convert.ToInt32(row["quantity"]),
                        Price = row["price"] != DBNull.Value ? Convert.ToInt32(row["price"]) : 0,
                        Unit = row["unit"].ToString()
                    };

                    listParts.Add(part);
                }

                return listParts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve part from order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool AddPart(Part part)
        {
            try
            {
                string partInsertQuery = @"INSERT INTO parts (partID, partName, quantity, price, buyPrice, employeePrice, unit, limitStock)
                                   VALUES (@PartID, @PartName, @Quantity, @Price, @BuyPrice, @EmployeePrice, @Unit, @LimitStock)";

                var partParams = new Dictionary<string, object>
                {
                    { "@PartID", part.PartId },
                    { "@PartName", part.PartName },
                    { "@Quantity", part.Quantity },
                    { "@Price", part.Price },
                    { "@BuyPrice", part.BuyPrice },
                    { "@EmployeePrice", part.EmployeePrice },
                    { "@Unit", part.Unit },
                    { "@LimitStock", part.LimitStock }
                };

                // Execute the insert query with the parameters
                _context.ExecuteQuery(partInsertQuery, partParams);
                return true;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }


        // Update employee method using SQL query
        public bool UpdatePart(Part part)
        {
            try
            {
                string partUpdateQuery = @"UPDATE parts 
                                   SET partName = @PartName, 
                                       quantity = @Quantity, 
                                       price = @Price, 
                                       buyPrice = @BuyPrice, 
                                       employeePrice = @EmployeePrice, 
                                       unit = @Unit, 
                                       limitStock = @LimitStock 
                                   WHERE partID = @PartID";

                var partParams = new Dictionary<string, object>
                {
                    { "@PartID", part.PartId },
                    { "@PartName", part.PartName },
                    { "@Quantity", part.Quantity },
                    { "@Price", part.Price },
                    { "@BuyPrice", part.BuyPrice },
                    { "@EmployeePrice", part.EmployeePrice },
                    { "@Unit", part.Unit },
                    { "@LimitStock", part.LimitStock }
                };

                int rowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(partUpdateQuery, partParams);

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
                // Log the error
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeletePartByID(string partID)
        {
            // SQL query to delete a part by its ID
            string deletePartQuery = @"DELETE FROM parts WHERE partID = @PartID";
            var parameters = new Dictionary<string, object>
            {
                { "@PartID", partID }
            };

            try
            {
                // Execute the delete query
                int partRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deletePartQuery, parameters);

                // Check if the deletion was successful
                if (partRowsAffected > 0)
                {
                    return true; // Successfully deleted the part
                }
                else
                {
                    // Handle the case where the part deletion failed
                    Console.WriteLine("No part found with the given ID.");
                    return false; // Part deletion failed
                }
            }
            catch (Exception ex)
            {
                // Log or handle any errors
                Console.WriteLine($"Error occurred while deleting part: {ex.Message}");
                return false;
            }
        }


        public Part GetPartByID(string partID)
        {
            Part part = null;

            // SQL query to get employee details by employeeID
            string query = @"SELECT partID, partName, quantity, price, buyPrice, employeePrice, unit, limitStock
                FROM parts where partID = @PartID";

            var parameters = new Dictionary<string, object>
            {
                { "@PartID", partID }
            };

            try
            {
                // Execute the query and fetch the result
                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    // Map the result to an Employee object
                    part = new Part
                    {
                        PartId = result.Rows[0]["partID"].ToString(),
                        PartName = result.Rows[0]["partName"].ToString(),
                        Quantity = result.Rows[0]["quantity"] != DBNull.Value ? int.Parse(result.Rows[0]["quantity"].ToString()) : 0,
                        Price = result.Rows[0]["price"] != DBNull.Value ? int.Parse(result.Rows[0]["price"].ToString()) : 0,
                        BuyPrice = result.Rows[0]["buyPrice"] != DBNull.Value ? int.Parse(result.Rows[0]["buyPrice"].ToString()) : 0,
                        EmployeePrice = result.Rows[0]["employeePrice"] != DBNull.Value ? int.Parse(result.Rows[0]["employeePrice"].ToString()) : 0,
                        Unit = result.Rows[0]["unit"].ToString(),
                        LimitStock = result.Rows[0]["limitStock"] != DBNull.Value ? int.Parse(result.Rows[0]["limitStock"].ToString()) : 0
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving part data.", ex);
            }

            return part;
        }

        public string GetNextPartID()
        {
            // Query to get the highest employeeID in the database
            string query = "SELECT TOP 1 partID FROM parts ORDER BY partID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there is no employee, start with "E0001"
            if (result.Rows.Count == 0)
            {
                return "P001";
            }

            // Get the highest employeeID and increment it
            string lastPartID = result.Rows[0]["partID"].ToString();

            int numericOrder = int.Parse(lastPartID.Substring(1));

            // Increment the numeric part
            numericOrder++;

            return "P" + numericOrder.ToString("D3");
        }
    }
}
