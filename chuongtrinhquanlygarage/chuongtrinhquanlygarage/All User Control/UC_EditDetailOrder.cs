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
    public partial class UC_EditDetailOrder : Form
    {
        private readonly Order _order;
        private readonly List<DetailOrder> _details;
        private readonly Motor _motor;
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        private readonly EmployeeRepository empRepo = new EmployeeRepository(new DatabaseContext());
        private readonly PartRepository partRepo = new PartRepository(new DatabaseContext());

        public UC_EditDetailOrder(Order order, List<DetailOrder> details, Motor motor)
        {
            InitializeComponent();
            _order = order;
            _details = details;
            _motor = motor;
        }

        private async Task LoadTechnicianEmployee()
        {
            try
            {
                List<Employee> listEmployee = await Task.Run(() => empRepo.GetEmployeeByRole("Kỹ Thuật Viên"));

                // Populate the combo box with roles
                txtEmployeeName.DataSource = listEmployee;
                txtEmployeeName.DisplayMember = "Name"; // Assuming Employee class has a 'Name' property
                txtEmployeeName.ValueMember = "Id";    // Optional: sets the value to the Employee ID
                txtEmployeeName.DropDownStyle = ComboBoxStyle.DropDownList; // Optional: makes it read-only
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải chức vụ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UC_EditDetailOrder_Load(object sender, EventArgs e)
        {
            await LoadTechnicianEmployee();
            await setListPart();
            setData();
        }

        private void setData()
        {
            txtCusID.Text = _motor.Customer.Id;
            orderIDLabel.Text = _order.OrderId;
            txtCusName.Text = _motor.Customer.Name;
            txtLicenseplate.Text = _motor.LicensePlate;
            txtModel.Text = _motor.Model;
            txtYear.Text = _motor.Year.ToString();
            txtCondition.Text = _order.Note;
            txtStatus.SelectedItem = _order.Status;
            txtEmployeeName.SelectedValue = _order.EmployeeID;
            txtTotal.Text = _order.Total.ToString("N0");
            dateLabel.Text = _order.CreatedAt.ToString("dd/MM/yyyy");
            dgvPart.ClearSelection();
        }

        private async Task setListPart()
        {
            try
            {
                // Fetch the list of parts asynchronously
                List<Part> listParts = await Task.Run(() => partRepo.GetListPartFromOrder(_order.OrderId));
                dgvPart.Rows.Clear();

                // Add each part to the CheckedListBox
                foreach (var part in listParts)
                {
                    dgvPart.Rows.Add(
                        part.PartId,
                        part.PartName,
                        part.Quantity,
                        part.Unit,
                        part.Price.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                // Handle errors and show message
                MessageBox.Show($"Lỗi xảy ra khi tải phụ tùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string orderID = orderIDLabel.Text;
            string licensePlate = txtLicenseplate.Text;
            string total = txtTotal.Text.Replace(",", "");
            string employeeID = txtEmployeeName.SelectedValue.ToString();
            string status = txtStatus.SelectedItem.ToString();
            string note = txtCondition.Text;
            try
            {
                Order order = new Order
                {
                    OrderId = orderID,
                    Status = status,
                    LicensePlate = licensePlate,
                    EmployeeID = employeeID,
                    Note = note,
                    Total = int.Parse(total),
                    CreatedAt = _order.CreatedAt
                };
                if (orderRepo.updateOrderStatus(order)) {
                    MessageBox.Show("Cập nhật trạng thái đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể cập nhật trạng thái đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
