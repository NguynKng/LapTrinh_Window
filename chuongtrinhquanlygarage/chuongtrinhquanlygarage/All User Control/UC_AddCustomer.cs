using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;
using chuongtrinhquanlygarage.Models;
using static chuongtrinhquanlygarage.Logic.Utils;
using System.Web;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_AddCustomer : UserControl
    {
        private readonly CustomerRepository cusRepo = new CustomerRepository(new DatabaseContext());
        public UC_AddCustomer()
        {
            InitializeComponent();
        }

        private async Task LoadCustomerBoard(string searchQuery = null)
        {
            try
            {
                // Get the list of employees from the repository
                List<Motor> list = await Task.Run(() => cusRepo.GetAllCustomerWithMotor(searchQuery));

                // Clear any existing data in the DataGridView
                dgvCustomer.Rows.Clear();

                // Loop through each employee and add to DataGridView
                foreach (var customer in list)
                {
                    dgvCustomer.Rows.Add(
                        customer.Customer.Id,
                        customer.Customer.Name,
                        customer.LicensePlate,
                        customer.Model + $" ({customer.Year})",
                        customer.Customer.Email,
                        customer.Customer.PhoneNumber,
                        customer.Customer.Address
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải bảng khách hàng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UC_AddCustomer_Load(object sender, EventArgs e)
        {
            await LoadCustomerBoard();
            clearAll();
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string typeMotor = txtType.Text.Trim();
            string licensePlate = txtLicenseplate.Text.Trim();
            string yearModel = txtYear.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || 
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || 
                    string.IsNullOrEmpty(typeMotor) || string.IsNullOrEmpty(licensePlate)) {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(yearModel))
                    yearModel = "0";

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidLicensePlate(licensePlate))
                {
                    MessageBox.Show("Biển số xe không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Customer customer = new Customer
                {
                    Id = cusRepo.GetNextCustomerID(),
                    Name = name,
                    Address = address,
                    Email = email,
                    PhoneNumber = phoneNumber,
                };

                Motor motor = new Motor
                {
                    Customer = customer,
                    LicensePlate = licensePlate,
                    Model = typeMotor,
                    Year = int.Parse(yearModel),
                };
                bool isCustomerAdded = cusRepo.AddCustomerAndMotors(motor);
                if (isCustomerAdded)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomerBoard();
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể thêm khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearAll();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void clearAll()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtType.Clear();
            txtLicenseplate.Clear();
            dgvCustomer.ClearSelection();
        }

        private void UC_AddCustomer_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddCustomer_Enter(object sender, EventArgs e)
        {
            UC_AddCustomer_Load(this, null);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];

                // Check if the selected row has valid data in the employee ID column
                if (selectedRow.Cells["customerIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["customerIDCol"].Value.ToString()))
                {
                    MessageBox.Show("Dòng được chọn không có dữ liệu để sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve the employee ID from the row
                string customerID = selectedRow.Cells["customerIDCol"].Value.ToString();
                string licensePlate = selectedRow.Cells["licensePlateCol"].Value.ToString();

                try
                {
                    // Get the employee data from the repository
                    var customer = cusRepo.GetCustomerByLicensePlate(licensePlate);

                    // Check if the employee was found
                    if (customer != null)
                    {
                        // Open the EditEmployeeForm and pass the employee data
                        using (UC_EditCustomer editForm = new UC_EditCustomer(customer))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK) // Check if the edit form is closed successfully
                            {
                                // After successful update, reload the employee list
                                await LoadCustomerBoard();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với mã ID này.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur during the data fetch
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để chỉnh sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];

                    // Get the employee ID from the selected row
                    string customerID = selectedRow.Cells["customerIDCol"].Value.ToString();
                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá khách hàng này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (result == DialogResult.Yes)
                    {
                        // Call the method to delete both employee and user account
                        bool success = cusRepo.DeleteCustomerByID(customerID);

                        if (success)
                        {
                            MessageBox.Show("Xoá khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the DataGridView after deletion
                            await LoadCustomerBoard();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xoá khách hàng.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xoá !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim(); // Get the search keyword from the TextBox
            try
            {
                if (string.IsNullOrEmpty(searchName))
                {
                    await LoadCustomerBoard();
                }
                else
                {
                    await LoadCustomerBoard(searchName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tìm kiếm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            await LoadCustomerBoard(search);
        }
    }
}
