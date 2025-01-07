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
                    query += " where lower(customerName) like @Name";
                    Params.Add("@Name", $"%{name.ToLower()}%");
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

                _context.ExecuteQuery(orderInsertQuery, orderParams);
                return true;
            }
            catch (Exception ex)
            {
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
                int rowAffectedOrder = _context.ExecuteNonQueryAndReturnRowsAffected(query, parameters);

                if (rowAffectedOrder > 0)
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
            string query = "SELECT RepairOrderID FROM RepairOrder ORDER BY RepairOrderID DESC limit 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "RP00000001";
            }

            string lastOrderID = result.Rows[0]["RepairOrderID"].ToString();

            int numericOrder = int.Parse(lastOrderID.Substring(2));

            numericOrder++;

            return "RP" + numericOrder.ToString("D8");
        }

        public string GetNextInvoiceID()
        {
            string query = "SELECT invoiceID FROM invoice ORDER BY invoiceID DESC limit 1";

            var result = _context.ExecuteSelectQuery(query);

            if (result.Rows.Count == 0)
            {
                return "HD00000001";
            }

            string lastInvoiceID = result.Rows[0]["invoiceID"].ToString();

            int numericOrder = int.Parse(lastInvoiceID.Substring(2));

            numericOrder++;

            return "HD" + numericOrder.ToString("D8");
        }

        public List<double> GetRevenueByYear(int year)
        {
            string query = @"
            SELECT strftime('%m', CheckOut) AS Month, SUM(total) AS Total
            FROM Invoice
            WHERE strftime('%Y', CheckOut) = @Year
            GROUP BY strftime('%m', CheckOut)
            ORDER BY Month";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year.ToString() }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            List<double> monthlyTotals = Enumerable.Repeat(0.0, 12).ToList();

            foreach (DataRow row in result.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                double total = row["Total"] != DBNull.Value ? Convert.ToDouble(row["Total"]) : 0;
                monthlyTotals[month - 1] = total; // Convert to millions
                                                              // monthlyTotals[month - 1] = Math.Round(total / 1000000.0, 3); // Convert to millions
            }

            return monthlyTotals;
        }


        public List<int> GetQuantityCustomerOfMonth(int year)
        {
            string query = @"
            SELECT strftime('%m', createdAt) AS Month, count(licensePlate) AS Total
            FROM RepairOrder
            WHERE strftime('%Y', createdAt) = @Year
            GROUP BY strftime('%m', createdAt)
            ORDER BY Month";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year.ToString() }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            List<int> monthlyTotals = Enumerable.Repeat(0, 12).ToList();

            foreach (DataRow row in result.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                int total = row["Total"] != DBNull.Value ? Convert.ToInt32(row["Total"]) : 0;

                monthlyTotals[month - 1] = total;
            }

            return monthlyTotals;
        }


        public Dictionary<string, List<(string PartName, int Quantity)>> GetTop5PartsSell(int year, int quarter)
        {
            string query = @"
                SELECT p.partID, p.partName, SUM(rd.quantity) AS TotalQuantity
                FROM RepairDetail rd
                JOIN Invoice i ON rd.RepairOrderID = i.RepairOrderID 
                JOIN parts p ON p.partID = rd.partID 
                WHERE strftime('%Y', i.CheckOut) = @Year 
                AND (
                    (@Quarter = 1 AND strftime('%m', i.CheckOut) BETWEEN '01' AND '03') OR
                    (@Quarter = 2 AND strftime('%m', i.CheckOut) BETWEEN '04' AND '06') OR
                    (@Quarter = 3 AND strftime('%m', i.CheckOut) BETWEEN '07' AND '09') OR
                    (@Quarter = 4 AND strftime('%m', i.CheckOut) BETWEEN '10' AND '12')
                )
                GROUP BY p.partID, p.partName
                ORDER BY TotalQuantity DESC
                LIMIT 5";

            var parameters = new Dictionary<string, object>
            {
                { "@Year", year.ToString() },
                { "@Quarter", quarter }
            };

            var result = _context.ExecuteSelectQuery(query, parameters);

            var partSales = new Dictionary<string, List<(string PartName, int Quantity)>>();

            foreach (DataRow row in result.Rows)
            {
                string partID = row["partID"].ToString();
                string partName = row["partName"].ToString();
                int totalQuantity = row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;

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
                string invoiceInsertQuery = @"INSERT INTO Invoice 
            (invoiceID, RepairOrderID, CheckIn, CheckOut, total, method, customerName, employeeName) VALUES 
            (@InvoiceID, @RepairOrderID, @CheckIn, @CheckOut, @Total, @Method, @CustomerName, @EmployeeName)";

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

                _context.ExecuteQuery(invoiceInsertQuery, invoiceParams);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while inserting the invoice: {ex.Message}");
                return false;
            }
        }

    }
}
