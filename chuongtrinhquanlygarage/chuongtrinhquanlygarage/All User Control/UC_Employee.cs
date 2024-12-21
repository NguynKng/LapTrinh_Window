using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Models;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;
using static chuongtrinhquanlygarage.Logic.Utils;
using BCrypt.Net;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        private readonly EmployeeRepository empRepo = new EmployeeRepository(new DatabaseContext());
        private readonly UserRepository userRepo = new UserRepository(new DatabaseContext());
        public UC_Employee()
        {
            InitializeComponent();
        }


        private async void UC_Employee_Load(object sender, EventArgs e)
        {
            try
            {
                // Set the label text with the next employee ID
                labelToSet.Text = await Task.Run(() => empRepo.GetNextEmployeeID()); // Ensure this method is async-friendly if possible

                // Load roles, employees, and user board asynchronously
                await LoadRoles();
                await LoadEmployeeBoard();
                await LoadUserBoard();

                // Clear all fields after data is loaded
                clearAll();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                MessageBox.Show($"Lỗi xảy ra khi tải dữ liệu nhân viên: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployeeBoard(string name = null)
        {
            try
            {
                // Get the list of employees from the repository
                List<Employee> employees = await Task.Run(() => empRepo.GetAllEmployees(name));

                // Filter the users based on the search query (case-insensitive)

                // Clear any existing data in the DataGridView
                dgvEmployee.Rows.Clear();

                // Loop through each employee and add to DataGridView
                foreach (var employee in employees)
                {
                    dgvEmployee.Rows.Add(
                        employee.Id,
                        employee.Name,
                        employee.PhoneNumber,
                        employee.Gender,
                        employee.Email,
                        employee.EmpType,
                        employee.BaseSalary
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải dữ liệu nhân viên: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUserBoard()
        {
            try
            {
                List<User> users = await Task.Run(() => userRepo.GetAllUsers());

                // Clear any existing data in the DataGridView
                dgvUser.Rows.Clear();

                // Loop through each employee and add to DataGridView
                foreach (var user in users)
                {
                    dgvUser.Rows.Add(
                        user.UserID,
                        user.EmpID,
                        user.Username,
                        user.Role,
                        user.CreatedAt.ToString("dd-MM-yyyy HH:mm:ss"),
                        user.UpdatedAt?.ToString("dd-MM-yyyy HH:mm:ss") ?? "N/A"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải dữ liệu người dùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRoles()
        {
            try
            {
                List<string> roles = await Task.Run(() => empRepo.GetAllRoles());

                // Populate the combo box with roles
                txtRole.DataSource = roles;
                txtRole.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải dữ liệu chức vụ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                string employId = txtEmpId.Text;
                // Get user inputs from textboxes
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(employId))
                {
                    // Check if the employee exists
                    var existedEmployee = await Task.Run(() => empRepo.GetEmployeeByID(employId));

                    if (existedEmployee == null)
                    {
                        MessageBox.Show("Không tìm thấy mã nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Check if the employee already has an account
                    var existedUser = await Task.Run(() => userRepo.getUserByEmpID(employId));
                    if (existedUser != null)
                    {
                        MessageBox.Show("Nhân viên này đã có tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Check if the username already exists
                    if (userRepo.ExistedUsername(username))
                    {
                        MessageBox.Show("Username đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Create the user account
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
                    User user = new User
                    {
                        UserID = userRepo.GetNextUserID(),
                        EmpID = employId,
                        Username = username,
                        PasswordHash = hashedPassword,
                        Role = "user"
                    };

                    // Attempt to add the user account
                    if (await Task.Run(() => userRepo.AddUserAccount(user)))
                    {
                        MessageBox.Show("Tạo tài khoản cho nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUserBoard();
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearAll();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void clearAll()
        {
            try
            {
                // Clear text fields
                labelToSet.Text = await Task.Run(() => empRepo.GetNextEmployeeID());
                txtName.Clear();
                txtPhoneNo.Clear();
                txtEmail.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                txtEmpId.Clear();
                txtSalary.Clear();

                // Reset combo boxes
                txtGender.SelectedIndex = -1;
                txtRole.SelectedIndex = -1;
                cmbSort.SelectedItem = "Mặc định";

                // Clear DataGridView selections
                dgvEmployee.ClearSelection();
                dgvUser.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private async void addEmpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate the next employee ID asynchronously
                string employId = await Task.Run(() => empRepo.GetNextEmployeeID());

                // Get user inputs from textboxes
                string name = txtName.Text.Trim();
                string phoneNum = txtPhoneNo.Text.Trim();
                string gender = txtGender.Text.Trim();
                string email = txtEmail.Text.Trim();
                string salary = txtSalary.Text.Replace(",", "");
                string role = txtRole.Text.Trim();

                // Validate input fields
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) ||
                    string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(role) || string.IsNullOrEmpty(salary))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    // Check if the email already exists asynchronously
                if (await Task.Run(() => empRepo.ExistedEmail(email)))
                {
                    MessageBox.Show("Email đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!IsValidPhoneNumber(phoneNum)) {
                    MessageBox.Show("Số điện thoại không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                // Check if the phone number already exists asynchronously
                if (await Task.Run(() => empRepo.ExistedPhoneNumber(phoneNum)))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a new Employee object
                Employee employee = new Employee
                {
                    Id = employId,
                    Name = name,
                    PhoneNumber = phoneNum,
                    Gender = gender,
                    Email = email,
                    EmpType = role,
                    BaseSalary = int.Parse(salary)
                };

                // Try to add the employee to the database asynchronously
                bool isAdded = await Task.Run(() => empRepo.AddEmployee(employee));

                if (isAdded)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEmployeeBoard(); // Ensure that the employee board reloads asynchronously
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể thêm nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, backspace, and delete keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            // Save the cursor position to avoid jumping
            int cursorPosition = txtSalary.SelectionStart;

            // Remove formatting
            string unformattedText = txtSalary.Text.Replace(",", "");

            if (long.TryParse(unformattedText, out long number))
            {
                // Format the number with thousand separators
                txtSalary.Text = string.Format("{0:N0}", number);
                txtSalary.SelectionStart = Math.Min(cursorPosition, txtSalary.Text.Length);
            }
        }

        private async void delEmpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvEmployee.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];

                    // Get the employee ID from the selected row
                    string employeeID = selectedRow.Cells["empIDCol"].Value.ToString();
                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá nhân viên này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if(result == DialogResult.Yes)
                    {
                        // Call the method to delete both employee and user account
                        bool success = await Task.Run(() => empRepo.DeleteEmployeeByID(employeeID));

                        if (success)
                        {
                            MessageBox.Show("Xoá nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the DataGridView after deletion
                            await LoadEmployeeBoard();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xoá nhân viên.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xoá !.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra khi xoá nhân viên.", ex);
            }
        }

        private async void editEmpBtn_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];

                // Check if the selected row has valid data in the employee ID column
                if (selectedRow.Cells["empIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["empIDCol"].Value.ToString()))
                {
                    MessageBox.Show("Dòng được chọn không có dữ liệu để sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve the employee ID from the row
                string empId = selectedRow.Cells["empIDCol"].Value.ToString();

                try
                {
                    // Get the employee data from the repository asynchronously
                    var employee = await Task.Run(() => empRepo.GetEmployeeByID(empId)); // Assuming this method is async

                    // Check if the employee was found
                    if (employee != null)
                    {
                        // Open the EditEmployeeForm and pass the employee data
                        using (UC_EditEmployee editForm = new UC_EditEmployee(employee))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK) // Check if the edit form is closed successfully
                            {
                                // After successful update, reload the employee list asynchronously
                                await LoadEmployeeBoard(); // Assuming UC_Employee_Load can be made async
                                await LoadRoles();
                                clearAll();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với mã ID này.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur during the data fetch
                    MessageBox.Show($"Có lỗi xảy ra khi tải dữ liệu nhân viên: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để chỉnh sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void delUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvUser.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvUser.SelectedRows[0];

                    // Get the user ID from the selected row
                    string userID = selectedRow.Cells["userIDCol"].Value.ToString();

                    // Show a confirmation dialog
                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá người dùng này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Call the method to delete the user account asynchronously
                        bool success = await Task.Run(() => userRepo.DeleteUserAccountByID(userID)); // Assuming this method is async

                        if (success)
                        {
                            MessageBox.Show("Xoá người dùng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the DataGridView after deletion asynchronously
                            await LoadUserBoard(); // Assuming UC_Employee_Load can be made async
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xoá người dùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // If the user clicks "No", do nothing
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn người dùng để xoá.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi xoá người dùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Determine the column and sort order
                string selectedMode = cmbSort.SelectedItem.ToString();
                DataGridViewColumn sortColumn = dgvEmployee.Columns["empIDCol"]; // Default column
                ListSortDirection direction = ListSortDirection.Ascending;

                switch (selectedMode)
                {
                    case "Tên A-Z":
                        sortColumn = dgvEmployee.Columns["nameCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Tên Z-A":
                        sortColumn = dgvEmployee.Columns["nameCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    case "Lương ↑":
                        sortColumn = dgvEmployee.Columns["salaryCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Lương ↓":
                        sortColumn = dgvEmployee.Columns["salaryCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    case "Chức vụ":
                        sortColumn = dgvEmployee.Columns["roleCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                }

                // Sort the DataGridView
                dgvEmployee.Sort(sortColumn, direction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn tác vụ sắp xếp: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim(); // Get the search keyword from the TextBox
            try
            {
                if (string.IsNullOrEmpty(searchName))
                {
                    await LoadEmployeeBoard();
                }
                else
                {
                    await LoadEmployeeBoard(searchName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tìm kiếm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            await LoadEmployeeBoard(search);
        }
    }
}
