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

                txtEmployeeName.DataSource = listEmployee ;
                txtEmployeeName.DisplayMember = "Name";
                txtEmployeeName.ValueMember = "Id";
                txtEmployeeName.DropDownStyle = ComboBoxStyle.DropDownList;
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
                List<Part> listParts = await Task.Run(() => partRepo.GetAllParts(name));

                checkListPart.Items.Clear();
                selectedParts.Clear();
                partDetails.Clear();
                string displayText;

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

                    checkListPart.Items.Add(displayText);

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
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách phụ tùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadMotorBoard(string searchQuery = null)
        {
            try
            {
                List<Motor> motors = await Task.Run(() => cusRepo.GetMotorWaiting());

                dgvMotor.Rows.Clear();

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
                List<Order> orders = await Task.Run(() => orderRepo.GetAllOrders());

                dgvOrder.Rows.Clear();

                foreach (var order in orders)
                {
                    dgvOrder.Rows.Add(
                        order.OrderId,
                        order.EmployeeID,
                        order.LicensePlate,
                        order.Status,
                        order.Note,
                        order.CreatedAt.ToString("dd/MM/yyyy hh:mm tt"),
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
                string newOrderID = await Task.Run(() => orderRepo.GetNextOrderID());
                string licensePlate = txtLicenseplate.Text;
                string note = txtCondition.Text.Trim();
                string status = txtStatus.Text.Trim();
                string total = txtTotal.Text.Trim().Replace(",", "");
                List<DetailOrder> details = new List<DetailOrder>();
                List<Part> parts = new List<Part>();

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

                    if (!partDetails.ContainsKey(partName))
                    {
                        MessageBox.Show($"Chi tiết phụ tùng không tìm thấy: {partName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var partInfo = partDetails[partName];

                    int quantity = selectedPart.Value.Quantity;
                    int price = partInfo.Price;
                    string partId = partInfo.PartId;

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

                    DetailOrder detailOrder = new DetailOrder
                    {
                        OrderId = newOrderID,
                        PartId = partId,
                        Quantity = quantity,
                        Price = price
                    };
                    details.Add(detailOrder);
                }

                bool isOrderAdded = await Task.Run(() => orderRepo.AddOrder(newOrder));
                bool areDetailsAdded = await Task.Run(() => orderRepo.AddDetailOrders(details));
                bool isUpdateQuantity = await Task.Run(() => partRepo.updatePartQuantity(parts));

                if (isOrderAdded && areDetailsAdded)
                {
                    if (isUpdateQuantity)
                    {
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

                    e.NewValue = CheckState.Unchecked;
                    return;
                }

                if (e.NewValue == CheckState.Checked)
                {
                    if (!selectedParts.ContainsKey(selectedPartName))
                    {
                        selectedParts[selectedPartName] = (1, part.Price);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (selectedParts.ContainsKey(selectedPartName))
                    {
                        int quantity = selectedParts[selectedPartName].Quantity;
                        int price = selectedParts[selectedPartName].Price;

                        int totalCostToRemove = quantity * price;

                        selectedParts.Remove(selectedPartName);

                        total -= totalCostToRemove;
                    }
                }

                RecalculateTotal();
            }
        }

        private void checkListPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkListPart.SelectedItem != null)
            {
                string selectedPartName = checkListPart.SelectedItem.ToString().Split('-')[0].Trim();

                if (selectedParts.ContainsKey(selectedPartName))
                {
                    txtQuantity.Enabled = true;
                    txtQuantity.Value = selectedParts[selectedPartName].Quantity;
                }
                else
                {
                    txtQuantity.Enabled = false;
                    txtQuantity.Value = 0;

                }
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            string selectedPartName = checkListPart.SelectedItem?.ToString()?.Split('-')[0].Trim();

            if (!string.IsNullOrEmpty(selectedPartName) && partDetails.ContainsKey(selectedPartName))
            {
                Part part = partDetails[selectedPartName];
                int newQuantity = (int)txtQuantity.Value;

                if (newQuantity > part.Quantity)
                {
                    MessageBox.Show($"Số lượng không thể vượt quá tồn trong kho: {part.Quantity}.", "Quantity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Value = selectedParts[selectedPartName].Quantity;
                }
                else
                {
                    if (selectedParts.ContainsKey(selectedPartName))
                    {
                        int oldQuantity = selectedParts[selectedPartName].Quantity;
                        int price = selectedParts[selectedPartName].Price;

                        int oldTotalCost = oldQuantity * price;
                        total -= oldTotalCost;

                        selectedParts[selectedPartName] = (newQuantity, price);

                        int newTotalCost = newQuantity * price;
                        total += newTotalCost;
                    }
                }
            }

            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            total = 0;

            foreach (var part in selectedParts)
            {
                int quantity = part.Value.Quantity;
                int price = part.Value.Price;
                total += quantity * price;
            }

            txtTotal.Text = total.ToString("N0");
        }

        private void dgvMotor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMotor.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvMotor.SelectedRows[0];

                    if (selectedRow.Cells["cusIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["cusIDCol"].Value.ToString()))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
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
                if (dgvOrder.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvOrder.SelectedRows[0];

                    if (selectedRow.Cells["orderIDCol"].Value == null ||
                        string.IsNullOrWhiteSpace(selectedRow.Cells["orderIDCol"].Value.ToString()))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu để xem.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }

                    string orderId = selectedRow.Cells["orderIDCol"].Value.ToString();
                    string licensePlate = selectedRow.Cells["LPCol"].Value.ToString();

                    Order order = orderRepo.GetOrderByID(orderId);
                    List<DetailOrder> orderDetails = orderRepo.GetDetailOrderByID(orderId);
                    Motor motor = cusRepo.GetCustomerByLicensePlate(licensePlate);

                    if (order != null && orderDetails != null)
                    {
                        using (UC_EditDetailOrder editForm = new UC_EditDetailOrder(order, orderDetails, motor))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
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
                MessageBox.Show($"Lỗi xảy ra khi chọn đơn: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
