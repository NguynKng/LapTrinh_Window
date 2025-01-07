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


            try
            {
                string query = @"SELECT partID, partName, quantity, price, buyPrice, employeePrice, limitStock, unit FROM parts";

                var partParams = new Dictionary<string, object>();

                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE lower(partName) LIKE @Name";
                    partParams.Add("@Name", $"%{name.ToLower()}%");
                }
                query += " Order by partName asc";
                var result = _context.ExecuteSelectQuery(query, partParams);

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

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No rows were updated.");
                    return false;
                }

                return true;
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
            string deletePartQuery = @"DELETE FROM parts WHERE partID = @PartID";
            var parameters = new Dictionary<string, object>
            {
                { "@PartID", partID }
            };

            try
            {
                int partRowsAffected = _context.ExecuteNonQueryAndReturnRowsAffected(deletePartQuery, parameters);

                if (partRowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("No part found with the given ID.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting part: {ex.Message}");
                return false;
            }
        }


        public Part GetPartByID(string partID)
        {
            Part part = null;

            string query = @"SELECT partID, partName, quantity, price, buyPrice, employeePrice, unit, limitStock
                FROM parts where partID = @PartID";

            var parameters = new Dictionary<string, object>
            {
                { "@PartID", partID }
            };

            try
            {
                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
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
            string query = "SELECT partID FROM parts ORDER BY partID DESC LIMIT 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "P001";
            }

            string lastPartID = result.Rows[0]["partID"].ToString();

            int numericOrder = int.Parse(lastPartID.Substring(1));

            numericOrder++;

            return "P" + numericOrder.ToString("D3");
        }

    }
}
