using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace chuongtrinhquanlygarage.Database.Repository
{
    public class OrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            string query = "select RepairOrderID, licensePlate, employeeID, status, note, total, createdAt from RepairOrder where status != 'Hoàn Thành'";

            try
            {
                var result = _context.ExecuteSelectQuery(query, null);
                foreach (DataRow row in result.Rows)
                {
                    Order order = new Order
                    {
                        OrderId = row["RepairOrderID"].ToString(),
                        LicensePlate = row["licensePlate"].ToString(),
                        EmployeeID = row["employeeID"].ToString(),
                        Status = row["status"].ToString(),
                        Note = row["note"] != DBNull.Value ? row["note"].ToString() : "",
                        Total = row["total"] != DBNull.Value ? Convert.ToInt32(row["total"]) : 0,
                        CreatedAt = Convert.ToDateTime(row["createdAt"]),
                    };

                    // Add each employee to the list
                    orders.Add(order);
                }

                return orders;
            } catch (Exception ex) {
                throw new Exception("Error occurred while retrieving order data.", ex);
            }
        }

        public List<Order> GetAllOrdersIsCompleted()
        {
            List<Order> orders = new List<Order>();

            string query = "select RepairOrderID, licensePlate, employeeID, status, note, total, createdAt " +
                "from RepairOrder where status = 'Hoàn Thành' and RepairOrderID not in (select RepairOrderID from Invoice)";

            var partParams = new Dictionary<string, object>();

            try
            {
                var result = _context.ExecuteSelectQuery(query, null);
                foreach (DataRow row in result.Rows)
                {
                    Order order = new Order
                    {
                        OrderId = row["RepairOrderID"].ToString(),
                        LicensePlate = row["licensePlate"].ToString(),
                        EmployeeID = row["employeeID"].ToString(),
                        Status = row["status"].ToString(),
                        Note = row["note"] != DBNull.Value ? row["note"].ToString() : "",
                        Total = row["total"] != DBNull.Value ? Convert.ToInt32(row["total"]) : 0,
                        CreatedAt = Convert.ToDateTime(row["createdAt"]),
                    };

                    // Add each employee to the list
                    orders.Add(order);
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving order data.", ex);
            }
        }

        public List<Invoice> GetAllInvoice(string name = null)
        {
            List<Invoice> invoices = new List<Invoice>();

            string query = "select invoiceID, RepairOrderID, CheckIn, CheckOut, total, method, customerName, employeeName from Invoice";

            var Params = new Dictionary<string, object>();

            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    query += " where customerName like @Name";
                    Params.Add("@Name", $"%{name}%");
                }
                    var result = _context.ExecuteSelectQuery(query, Params);
                foreach (DataRow row in result.Rows)
                {
                    Invoice invoice = new Invoice
                    {
                        Id = row["invoiceID"].ToString(),
                        OrderID = row["RepairOrderID"].ToString(),
                        CheckIn = Convert.ToDateTime(row["CheckIn"]),
                        CheckOut = Convert.ToDateTime(row["CheckOut"]),
                        Method = row["method"].ToString(),
                        Total = row["total"] != DBNull.Value ? Convert.ToInt32(row["total"]) : 0,
                        CustomerName = row["customerName"].ToString(),
                        EmployeeName = row["employeeName"].ToString()
                    };

                    // Add each employee to the list
                    invoices.Add(invoice);
                }

                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving invoice data.", ex);
            }
        }

        public Invoice GetInvoiceByID(string invoiceID)
        {
            if (string.IsNullOrEmpty(invoiceID))
            {
                MessageBox.Show("Invoice ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Invoice invoice = null;
            try
            {
                string query = "select invoiceID, RepairOrderID, CheckIn, CheckOut, total, method, customerName, employeeName from Invoice where invoiceID = @InvoiceID";

                var Params = new Dictionary<string, object>
                {
                    { "@InvoiceID", invoiceID }
                };
                
                var result = _context.ExecuteSelectQuery(query, Params);
                if(result.Rows.Count > 0)
                {
                    invoice = new Invoice
                    {
                        Id = result.Rows[0]["invoiceID"].ToString(),
                        OrderID = result.Rows[0]["RepairOrderID"].ToString(),
                        CheckIn = Convert.ToDateTime(result.Rows[0]["CheckIn"]),
                        CheckOut = Convert.ToDateTime(result.Rows[0]["CheckOut"]),
                        Method = result.Rows[0]["method"].ToString(),
                        Total = result.Rows[0]["total"] != DBNull.Value ? Convert.ToInt32(result.Rows[0]["total"]) : 0,
                        CustomerName = result.Rows[0]["customerName"].ToString(),
                        EmployeeName = result.Rows[0]["employeeName"].ToString()
                    };
                }

                return invoice;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving invoice data.", ex);
            }
        }

        public bool AddOrder(Order order)
        {
            try
            {
                // Step 3: Insert the new employee into the database
                string orderInsertQuery = @"INSERT INTO RepairOrder (RepairOrderID, createdAt, status, licensePlate, employeeID, note, total)
                    VALUES (@RepairOrderID, @CreatedAt, @Status, @LicensePlate, @EmployeeID, @Note, @Total);";

                var orderParams = new Dictionary<string, object>
                {
                    { "@RepairOrderID", order.OrderId },
                    { "@CreatedAt", order.CreatedAt },
                    { "@Status", order.Status },
                    { "@LicensePlate", order.LicensePlate },
                    { "@EmployeeID", order.EmployeeID },
                    { "@Note", order.Note },
                    { "@Total", order.Total }
                };

                // Step 4: Execute the insert query for the employee
                _context.ExecuteQuery(orderInsertQuery, orderParams);
                return true;
            }
            catch (Exception ex)
            {
                // Step 5: Handle errors and throw custom exception
                Console.WriteLine($"Error occurred: {ex.Message}");
                return false;
            }
        }

        public bool AddDetailOrders(List<DetailOrder> detailOrders)
        {
            if (detailOrders == null || detailOrders.Count == 0)
            {
                MessageBox.Show("No details to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                string detailInsertQuery = @"INSERT INTO RepairDetail (partID, RepairOrderID, quantity, price)
                                     VALUES (@PartID, @RepairOrderID, @Quantity, @Price);";

                foreach (var detail in detailOrders)
                {
                    var detailParams = new Dictionary<string, object>
                    {
                        { "@PartID", detail.PartId },
                        { "@RepairOrderID", detail.OrderId },
                        { "@Quantity", detail.Quantity },
                        { "@Price", detail.Price }
                    };

                    _context.ExecuteQuery(detailInsertQuery, detailParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Order GetOrderByID(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Order ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                string query = @"SELECT RepairOrderID, licensePlate, employeeID, status, note, total, createdAt 
                         FROM RepairOrder WHERE RepairOrderID = @OrderID";

                var parameters = new Dictionary<string, object>
                {
                    { "@OrderID", orderId }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Order not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                DataRow row = result.Rows[0];

                Order order = new Order
                {
                    OrderId = row["RepairOrderID"].ToString(),
                    LicensePlate = row["licensePlate"].ToString(),
                    EmployeeID = row["employeeID"].ToString(),
                    Status = row["status"].ToString(),
                    Note = row["note"] != DBNull.Value ? row["note"].ToString() : "",
                    Total = row["total"] != DBNull.Value ? Convert.ToInt32(row["total"]) : 0,
                    CreatedAt = Convert.ToDateTime(row["createdAt"])
                };

                return order;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public Invoice GetInvoiceByOrderID(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Order ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                string query = @"select ro.RepairOrderID as orderId, ro.createdAt, name, employeeName, total from RepairOrder ro join employees e on ro.employeeID = e.employeeID
						   join motors m on m.licensePlate = ro.licensePlate
						   join customers c on m.customerID = c.customerID where ro.RepairOrderID = @OrderID";

                var parameters = new Dictionary<string, object>
                {
                    { "@OrderID", orderId }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Order not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                DataRow row = result.Rows[0];

                Invoice invoice = new Invoice
                {
                    OrderID = row["orderID"].ToString(),
                    CustomerName = row["name"].ToString(),
                    EmployeeName = row["employeeName"].ToString(),
                    Total = row["total"] != DBNull.Value ? Convert.ToInt32(row["total"]) : 0,
                    CheckIn = Convert.ToDateTime(row["createdAt"])
                };

                return invoice;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool updateOrderStatus(Order order)
        {
            if (string.IsNullOrEmpty(order.OrderId))
            {
                MessageBox.Show("Order ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                string query = "update RepairOrder set status = @Status, employeeID = @EmployeeID, note = @Note where RepairOrderID = @RepairOrderID";
                var parameters = new Dictionary<string, object>
                {
                    { "@RepairOrderID", order.OrderId },
                    {"@Status", order.Status },
                    {"@EmployeeID", order.EmployeeID },
                    {"@Note", order.Note }
                };
                // Execute customer insert query
                int rowAffectedOrder = _context.ExecuteNonQueryAndReturnRowsAffected(query, parameters);

                // Ensure customer insertion was successful before proceeding to motor insertion
                if (rowAffectedOrder > 0)
                {
                    //// Execute motor insert query
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<DetailOrder> GetDetailOrderByID(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Order ID cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                string query = @"SELECT partID, RepairOrderID, quantity, price 
                         FROM RepairDetail WHERE RepairOrderID = @OrderID";

                var parameters = new Dictionary<string, object>
                {
                    { "@OrderID", orderId }
                };

                var result = _context.ExecuteSelectQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("No details found for this order.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                List<DetailOrder> detailOrders = new List<DetailOrder>();

                foreach (DataRow row in result.Rows)
                {
                    DetailOrder detailOrder = new DetailOrder
                    {
                        PartId = row["partID"].ToString(),
                        OrderId = row["RepairOrderID"].ToString(),
                        Quantity = Convert.ToInt32(row["quantity"]),
                        Price = row["price"] != DBNull.Value ? Convert.ToInt32(row["price"]) : 0
                    };

                    detailOrders.Add(detailOrder);
                }

                return detailOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string GetNextOrderID()
        {
            // Query to get the highest employeeID in the database
            string query = "SELECT TOP 1 RepairOrderID FROM RepairOrder ORDER BY RepairOrderID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there is no employee, start with "E0001"
            if (result.Rows.Count == 0)
            {
                return "RP00000001";
            }

            // Get the highest employeeID and increment it
            string lastOrderID = result.Rows[0]["RepairOrderID"].ToString();

            // Extract the numeric part of the employeeID (assumes format "E0001")
            int numericOrder = int.Parse(lastOrderID.Substring(2));

            // Increment the numeric part
            numericOrder++;

            return "RP" + numericOrder.ToString("D8");
        }

        public string GetNextInvoiceID()
        {
            // Query to get the highest employeeID in the database
            string query = "SELECT TOP 1 invoiceID FROM invoice ORDER BY invoiceID DESC";

            var result = _context.ExecuteSelectQuery(query);

            // If there is no employee, start with "E0001"
            if (result.Rows.Count == 0)
            {
                return "HD00000001";
            }

            // Get the highest employeeID and increment it
            string lastInvoiceID = result.Rows[0]["invoiceID"].ToString();

            // Extract the numeric part of the employeeID (assumes format "E0001")
            int numericOrder = int.Parse(lastInvoiceID.Substring(2));

            numericOrder++;

            return "HD" + numericOrder.ToString("D8");
        }

        public List<double> GetRevenueByYear(int year)
        {
            string query = @"
                    SELECT MONTH(CheckOut) AS Month, SUM(total) AS Total
                    FROM Invoice
                    WHERE YEAR(CheckOut) = @Year
                    GROUP BY MONTH(CheckOut)
                    ORDER BY MONTH(CheckOut)";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            // Initialize a list to hold the totals for each month (default 0.0)
            List<double> monthlyTotals = Enumerable.Repeat(0.0, 12).ToList();

            // Populate the totals for months with data
            foreach (DataRow row in result.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                int total = row["Total"] != DBNull.Value ? Convert.ToInt32(row["Total"]) : 0;

                // Divide by 1000000 and round to two decimal places, then store the result as a double
                monthlyTotals[month - 1] = Math.Round(total / 1000000.0, 3);
            }

            return monthlyTotals;
        }

        public List<int> GetQuantityCustomerOfMonth(int year)
        {
            string query = @"
                    SELECT MONTH(createdAt) AS Month, count(licensePlate) AS Total
                    FROM RepairOrder
                    WHERE YEAR(createdAt) = @Year
                    GROUP BY MONTH(createdAt)
                    ORDER BY MONTH(createdAt)";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            // Initialize a list to hold the totals for each month (default 0.0)
            List<int> monthlyTotals = Enumerable.Repeat(0, 12).ToList();

            // Populate the totals for months with data
            foreach (DataRow row in result.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                int total = row["Total"] != DBNull.Value ? Convert.ToInt32(row["Total"]) : 0;

                // Divide by 1000000 and round to two decimal places, then store the result as a double
                monthlyTotals[month - 1] = total;
            }

            return monthlyTotals;
        }


        public Dictionary<string, List<(string PartName, int Quantity)>> GetTop5PartsSell(int year, int quarter)
        {
            string query = @"select top 5 p.partID, partName, sum(rd.quantity) as TotalQuantity from RepairDetail rd join Invoice i on rd.RepairOrderID = i.RepairOrderID 
                                join parts p on p.partID = rd.partID where Year(Checkout) = @Year and (
                                                                            (@Quarter = 1 and Month(CheckOut) between 1 and 3) or
                                                                            (@Quarter = 2 and Month(CheckOut) between 4 and 6) or
                                                                            (@Quarter = 3 and Month(CheckOut) between 7 and 9) or
                                                                            (@Quarter = 4 and Month(CheckOut) between 10 and 12))
								group by p.partID, partName
								order by sum(rd.quantity) desc";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year },
                { "@Quarter", quarter }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            // Initialize a dictionary to hold part IDs as keys and lists of tuples (PartName, Quantity)
            var partSales = new Dictionary<string, List<(string PartName, int Quantity)>>();

            // Populate the dictionary with part IDs, part names, and their quantities
            foreach (DataRow row in result.Rows)
            {
                string partID = row["partID"].ToString();
                string partName = row["partName"].ToString();
                int totalQuantity = row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;

                // If the partID already exists in the dictionary, add the new tuple to its list
                if (!partSales.ContainsKey(partID))
                {
                    partSales[partID] = new List<(string, int)>();
                }

                partSales[partID].Add((partName, totalQuantity));
            }
            return partSales;
        }

        public bool InsertInvoice(Invoice invoice)
        {
            try
            {
                // SQL query to insert a new invoice
                string invoiceInsertQuery = @"INSERT INTO Invoice 
            (invoiceID, RepairOrderID, CheckIn, CheckOut, total, method, customerName, employeeName) VALUES 
            (@InvoiceID, @RepairOrderID, @CheckIn, @CheckOut, @Total, @Method, @CustomerName, @EmployeeName)";

                // Parameters for the SQL query
                var invoiceParams = new Dictionary<string, object>
                {
                    { "@InvoiceID", invoice.Id },
                    { "@RepairOrderID", invoice.OrderID },
                    { "@CheckIn", invoice.CheckIn },
                    { "@CheckOut", invoice.CheckOut },
                    { "@Total", invoice.Total },
                    { "@Method", invoice.Method },
                    { "@CustomerName", invoice.CustomerName },
                    { "@EmployeeName", invoice.EmployeeName }
                };

                // Execute the insert query
                _context.ExecuteQuery(invoiceInsertQuery, invoiceParams);

                return true; // Return true if the insertion succeeds
            }
            catch (Exception ex)
            {
                // Log the error and return false
                Console.WriteLine($"Error occurred while inserting the invoice: {ex.Message}");
                return false;
            }
        }

    }
}
