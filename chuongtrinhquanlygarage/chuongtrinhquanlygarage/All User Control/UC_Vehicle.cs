using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;
using chuongtrinhquanlygarage.Models;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Vehicle : UserControl
    {
        private readonly PartRepository partRepo = new PartRepository(new DatabaseContext());
        private readonly EmployeeRepository empRepo = new EmployeeRepository(new DatabaseContext());
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        private readonly CustomerRepository cusRepo = new CustomerRepository(new DatabaseContext());
        private Dictionary<string, (int Quantity, int Price)> selectedParts = new Dictionary<string, (int, int)>();
        private Dictionary<string, Part> partDetails = new Dictionary<string, Part>();
        private int total = 0;

        public UC_Vehicle()
        {
            InitializeComponent();
        }

        private async Task LoadTechnicianEmployee()
        {
            try
            {
                List<Employee> listEmployee = await Task.Run(() => empRepo.GetEmployeeByRole("Kỹ Thuật Viên"));

                // Populate the combo box with roles
                txtEmployeeName.DataSource = listEmployee ;
                txtEmployeeName.DisplayMember = "Name"; // Assuming Employee class has a 'Name' property
                txtEmployeeName.ValueMember = "Id";    // Optional: sets the value to the Employee ID
                txtEmployeeName.DropDownStyle = ComboBoxStyle.DropDownList; // Optional: makes it read-only
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải chức vụ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadParts(string name = null)
        {
            try
            {
                // Fetch the list of parts asynchronously
                List<Part> listParts = await Task.Run(() => partRepo.GetAllParts(name));

                // Reset the collections
                checkListPart.Items.Clear();
                selectedParts.Clear();
                partDetails.Clear();
                string displayText;

                // Add each part to the CheckedListBox
                foreach (var part in listParts)
                {
                    if (part.Quantity == 0)
                    {
                        displayText = $"{part.PartName} - Giá: {part.Price:N0} - Tồn: hết";
                    }
                    else
                    {
                        displayText = $"{part.PartName} - Giá: {part.Price:N0} - Tồn: {part.Quantity}";
                    }

                    // Add the part's name to the CheckedListBox
                    checkListPart.Items.Add(displayText);

                    // Store the part's details in the dictionary
                    partDetails[part.PartName] = new Part
                    {
                        PartId = part.PartId,
                        PartName = part.PartName,
                        Quantity = part.Quantity,
                        Price = part.Price
                    };
                }
            }
            catch (Exception ex)
            {
                // Handle errors and show message
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách phụ tùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadMotorBoard(string searchQuery = null)
        {
            try
            {
                // Get the list of employees from the repository
                List<Motor> motors = await Task.Run(() => cusRepo.GetMotorWaiting());

                // Clear any existing data in the DataGridView
                dgvMotor.Rows.Clear();

                // Loop through each employee and add to DataGridView
                foreach (var motor in motors)
                {
                    dgvMotor.Rows.Add(
                        motor.Customer.Id,
                        motor.Customer.Name,
                        motor.LicensePlate,
                        motor.Model,
                        motor.Year
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách xe chưa kiểm tra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOrderBoard()
        {
            try
            {
                // Get the list of employees from the repository
                List<Order> orders = await Task.Run(() => orderRepo.GetAllOrders());

                // Clear any existing data in the DataGridView
                dgvOrder.Rows.Clear();

                // Loop through each employee and add to DataGridView
                foreach (var order in orders)
                {
                    dgvOrder.Rows.Add(
                        order.OrderId,
                        order.EmployeeID,
                        order.LicensePlate,
                        order.Status,
                        order.Note,
                        order.CreatedAt,
                        order.Total
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearAll()
        {
            txtName.Clear();
            txtCondition.Clear();
            txtLicenseplate.Clear();
            txtYear.Clear();
            txtStatus.SelectedIndex = -1;      
            txtEmployeeName.SelectedIndex = -1;
            checkListPart.ClearSelected();
            selectedParts.Clear();
            txtQuantity.Value = 0;
            txtTotal.Text = total.ToString();
            txtModel.Clear();
            dgvMotor.ClearSelection();
            dgvOrder.ClearSelection();
            RecalculateTotal();
            txtQuantity.Enabled = false;
            checkListPart.Enabled = false;
            txtEmployeeName.Enabled = false;
            txtStatus.Enabled = false;
            txtCondition.Enabled = false;
        }

        private async void UC_Vehicle_Load(object sender, EventArgs e)
        {
            // Reset the collections
            await LoadTechnicianEmployee();
            await LoadParts();
            await LoadMotorBoard();
            await LoadOrderBoard();
            ClearAll();
        }

        private async void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate a new Order ID
                string newOrderID = await Task.Run(() => orderRepo.GetNextOrderID());
                string licensePlate = txtLicenseplate.Text;
                string note = txtCondition.Text.Trim();
                string status = txtStatus.Text.Trim();
                string total = txtTotal.Text.Trim().Replace(",", "");
                List<DetailOrder> details = new List<DetailOrder>();
                List<Part> parts = new List<Part>();
                // Validate inputs

                if (string.IsNullOrEmpty(licensePlate))
                {
                    MessageBox.Show("Không có xe để thêm đơn.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedParts.Count == 0)
                {
                    MessageBox.Show("Không có phụ tùng được chọn. Xin hãy chọn phụ tùng thay thế", "No Parts Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(string.IsNullOrEmpty(txtEmployeeName.Text))
                {
                    MessageBox.Show("Vui lòng chọn kỹ thuật viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtStatus.Text))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái đơn hàng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtCondition.Text))
                {
                    MessageBox.Show("Vui lòng nhập tình trạng xe", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new Order object
                Order newOrder = new Order
                {
                    OrderId = newOrderID,
                    CreatedAt = DateTime.Now,
                    Note = note,
                    Status = status,
                    Total = int.Parse(total),
                    EmployeeID = txtEmployeeName.SelectedValue.ToString(),
                    LicensePlate = licensePlate
                };

                foreach (var selectedPart in selectedParts)
                {
                    string partName = selectedPart.Key;

                    // Retrieve part details from the partDetails dictionary
                    if (!partDetails.ContainsKey(partName))
                    {
                        MessageBox.Show($"Chi tiết phụ tùng không tìm thấy: {partName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var partInfo = partDetails[partName];

                    int quantity = selectedPart.Value.Quantity; // Quantity selected by the user
                    int price = partInfo.Price;            // Use the price from partDetails
                    string partId = partInfo.PartId;           // Get the PartID from partDetails

                    if (string.IsNullOrEmpty(partId))
                    {
                        MessageBox.Show($"Mã phụ tùng không tìm thấy: {partName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Part part = new Part
                    {
                        PartId = partInfo.PartId,
                        PartName = partName,
                        Price = partInfo.Price,
                        Quantity = selectedPart.Value.Quantity,
                    };
                    parts.Add(part);

                    // Add a DetailOrder object for this part
                    DetailOrder detailOrder = new DetailOrder
                    {
                        OrderId = newOrderID,
                        PartId = partId,
                        Quantity = quantity,
                        Price = price
                    };
                    details.Add(detailOrder);
                }
                //Console.WriteLine("Hello");

                // Save the order using the OrderRepository
                bool isOrderAdded = await Task.Run(() => orderRepo.AddOrder(newOrder));
                bool areDetailsAdded = await Task.Run(() => orderRepo.AddDetailOrders(details));
                bool isUpdateQuantity = await Task.Run(() => partRepo.updatePartQuantity(parts));

                if (isOrderAdded && areDetailsAdded)
                {
                    if (isUpdateQuantity)
                    {
                        // Notify the user
                        MessageBox.Show("Thêm đơn thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UC_Vehicle_Load(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại khi cập nhật tồn phụ tùng. Xin hãy thử lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại khi thêm đơn. Xin hãy thử lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi thêm đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkListPart_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string selectedPartName = checkListPart.Items[e.Index].ToString().Split('-')[0].Trim();

            if (partDetails.TryGetValue(selectedPartName, out Part part))
            {
                // Prevent checking an item if its quantity is 0
                if (e.NewValue == CheckState.Checked && part.Quantity <= 0)
                {
                    MessageBox.Show($"Phụ tùng '{part.PartName}' đã hết và không thể chọn", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Cancel the check action
                    e.NewValue = CheckState.Unchecked;
                    return;
                }

                // Check whether the item is being checked or unchecked
                if (e.NewValue == CheckState.Checked)
                {
                    // Add the item to the selected parts dictionary with the correct price and default quantity
                    if (!selectedParts.ContainsKey(selectedPartName))
                    {
                        selectedParts[selectedPartName] = (1, part.Price); // Default quantity = 1
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    // Remove the part from the selected parts dictionary
                    if (selectedParts.ContainsKey(selectedPartName))
                    {
                        // Subtract the total cost of this part (quantity * price) when it's unchecked
                        int quantity = selectedParts[selectedPartName].Quantity;
                        int price = selectedParts[selectedPartName].Price;

                        int totalCostToRemove = quantity * price;

                        // Remove the part from the dictionary
                        selectedParts.Remove(selectedPartName);

                        // Recalculate the total cost after update
                        total -= totalCostToRemove;
                    }
                }

                // Recalculate the total cost after update
                RecalculateTotal();
            }
        }

        private void checkListPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkListPart.SelectedItem != null)
            {
                string selectedPartName = checkListPart.SelectedItem.ToString().Split('-')[0].Trim();

                // Check if the part is in the selectedParts dictionary and is checked
                if (selectedParts.ContainsKey(selectedPartName))
                {
                    txtQuantity.Enabled = true;
                    // Display the quantity of the part in txtQuantity
                    txtQuantity.Value = selectedParts[selectedPartName].Quantity;
                }
                else
                {
                    txtQuantity.Enabled = false;
                    txtQuantity.Value = 0;

                    // If the part is not in the selected parts, reset to 1 (default quantity)
                }
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected part's name
            string selectedPartName = checkListPart.SelectedItem?.ToString()?.Split('-')[0].Trim();

            if (!string.IsNullOrEmpty(selectedPartName) && partDetails.ContainsKey(selectedPartName))
            {
                // Get the part details from the dictionary
                Part part = partDetails[selectedPartName];
                int newQuantity = (int)txtQuantity.Value;

                // Check if the new quantity exceeds the stock
                if (newQuantity > part.Quantity)
                {
                    // Notify the user and reset the quantity to the maximum allowed
                    MessageBox.Show($"Số lượng không thể vượt quá tồn trong kho: {part.Quantity}.", "Quantity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Value = selectedParts[selectedPartName].Quantity; // Reset to max allowed
                }
                else
                {
                    // Update the quantity in the selected parts dictionary
                    if (selectedParts.ContainsKey(selectedPartName))
                    {
                        int oldQuantity = selectedParts[selectedPartName].Quantity;
                        int price = selectedParts[selectedPartName].Price;

                        // Subtract the old total cost from the total
                        int oldTotalCost = oldQuantity * price;
                        total -= oldTotalCost;

                        // Update the part's quantity and price in the dictionary
                        selectedParts[selectedPartName] = (newQuantity, price);

                        // Add the new total cost to the total
                        int newTotalCost = newQuantity * price;
                        total += newTotalCost;
                    }
                }
            }

            // Recalculate the total cost after quantity change
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            total = 0;

            // Calculate the total based on all selected parts
            foreach (var part in selectedParts)
            {
                int quantity = part.Value.Quantity;   // Quantity of the part
                int price = part.Value.Price;     // Price of one unit
                total += quantity * price;            // Total for this part (quantity * price)
            }

            // Update the total text box to show the formatted total
            txtTotal.Text = total.ToString("N0"); // Formats as currency (e.g., 1,000,000)
        }

        private void dgvMotor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvMotor.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvMotor.SelectedRows[0];

                    if (selectedRow.Cells["cusIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["cusIDCol"].Value.ToString()))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Get the user ID from the selected row
                    //string cusID = selectedRow.Cells["cusIDCol"].Value.ToString();
                    string customerName = selectedRow.Cells["cusNameCol"].Value.ToString();
                    string licensePlate = selectedRow.Cells["licensePlateCol"].Value.ToString();
                    string yearModel = selectedRow.Cells["yearModelCol"].Value.ToString();
                    string model = selectedRow.Cells["modelCol"].Value.ToString();

                    txtName.Text = customerName;
                    txtLicenseplate.Text = licensePlate;
                    txtYear.Text = yearModel;
                    txtModel.Text = model;
                    checkListPart.Enabled = true;
                    txtEmployeeName.Enabled = true;
                    txtStatus.Enabled = true;
                    txtCondition.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn xe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            await LoadMotorBoard();
            dgvMotor.ClearSelection();
        }

        private async void editOrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected in the DataGridView
                if (dgvOrder.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvOrder.SelectedRows[0];

                    // Check if the selected row has a valid Order ID
                    if (selectedRow.Cells["orderIDCol"].Value == null ||
                        string.IsNullOrWhiteSpace(selectedRow.Cells["orderIDCol"].Value.ToString()))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu để xem.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }

                    // Get the Order ID from the selected row
                    string orderId = selectedRow.Cells["orderIDCol"].Value.ToString();
                    string licensePlate = selectedRow.Cells["LPCol"].Value.ToString();

                    // Fetch order data
                    Order order = orderRepo.GetOrderByID(orderId);
                    List<DetailOrder> orderDetails = orderRepo.GetDetailOrderByID(orderId); // Ensure you fetch the associated details
                    Motor motor = cusRepo.GetCustomerByLicensePlate(licensePlate);

                    if (order != null && orderDetails != null)
                    {
                        // Open the Edit Order form and pass the order and its details
                        using (UC_EditDetailOrder editForm = new UC_EditDetailOrder(order, orderDetails, motor))
                        {
                            // Check if the user saved changes successfully
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                // Reload the order list after successful update
                                await LoadOrderBoard();
                                await LoadMotorBoard();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu đơn hàng hoặc chi tiết.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xem.","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                MessageBox.Show($"Lỗi xảy ra khi chọn đơn: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
