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
using System.Threading;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        private readonly EmployeeRepository empRepo = new EmployeeRepository(new DatabaseContext());
        private readonly UserRepository userRepo = new UserRepository(new DatabaseContext());
        private CancellationTokenSource _debounceCts;
        public UC_Employee()
        {
            InitializeComponent();
        }


        private async void UC_Employee_Load(object sender, EventArgs e)
        {
            try
            {
                labelToSet.Text = await Task.Run(() => empRepo.GetNextEmployeeID());

                await LoadRoles();
                await LoadEmployeeBoard();
                await LoadUserBoard();

                clearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải dữ liệu nhân viên: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployeeBoard(string name = null)
        {
            try
            {
                List<Employee> employees = await Task.Run(() => empRepo.GetAllEmployees(name));

                dgvEmployee.Rows.Clear();

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

                dgvUser.Rows.Clear();

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
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(employId))
                {
                    var existedEmployee = await Task.Run(() => empRepo.GetEmployeeByID(employId));

                    if (existedEmployee == null)
                    {
                        MessageBox.Show("Không tìm thấy mã nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var existedUser = await Task.Run(() => userRepo.getUserByEmpID(employId));
                    if (existedUser != null)
                    {
                        MessageBox.Show("Nhân viên này đã có tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (userRepo.ExistedUsername(username))
                    {
                        MessageBox.Show("Username đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
                    User user = new User
                    {
                        UserID = userRepo.GetNextUserID(),
                        EmpID = employId,
                        Username = username,
                        PasswordHash = hashedPassword,
                        Role = "user"
                    };

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
                labelToSet.Text = await Task.Run(() => empRepo.GetNextEmployeeID());
                txtName.Clear();
                txtPhoneNo.Clear();
                txtEmail.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                txtEmpId.Clear();
                txtSalary.Clear();

                txtRole.SelectedIndex = -1;
                txtGender.SelectedIndex = -1;
                cmbSort.SelectedItem = "Mặc định";

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
                string employId = await Task.Run(() => empRepo.GetNextEmployeeID());

                string name = txtName.Text.Trim();
                string phoneNum = txtPhoneNo.Text.Trim();
                string gender = txtGender.Text.Trim();
                string email = txtEmail.Text.Trim();
                string salary = txtSalary.Text.Replace(",", "");
                string role = txtRole.Text.Trim();

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
                if (await Task.Run(() => empRepo.ExistedEmail(email)))
                {
                    MessageBox.Show("Email đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!IsValidPhoneNumber(phoneNum)) {
                    MessageBox.Show("Số điện thoại không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (await Task.Run(() => empRepo.ExistedPhoneNumber(phoneNum)))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

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

                bool isAdded = await Task.Run(() => empRepo.AddEmployee(employee));

                if (isAdded)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEmployeeBoard();
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtSalary.SelectionStart;

            string unformattedText = txtSalary.Text.Replace(",", "");

            if (long.TryParse(unformattedText, out long number))
            {
                txtSalary.Text = string.Format("{0:N0}", number);
                txtSalary.SelectionStart = Math.Min(cursorPosition, txtSalary.Text.Length);
            }
        }

        private async void delEmpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];

                    string employeeID = selectedRow.Cells["empIDCol"].Value.ToString();
                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá nhân viên này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if(result == DialogResult.Yes)
                    {
                        bool success = await Task.Run(() => empRepo.DeleteEmployeeByID(employeeID));

                        if (success)
                        {
                            MessageBox.Show("Xoá nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadEmployeeBoard();
                            clearAll();
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
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];

                if (selectedRow.Cells["empIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["empIDCol"].Value.ToString()))
                {
                    MessageBox.Show("Dòng được chọn không có dữ liệu để sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string empId = selectedRow.Cells["empIDCol"].Value.ToString();

                try
                {
                    var employee = await Task.Run(() => empRepo.GetEmployeeByID(empId));

                    if (employee != null)
                    {
                        using (UC_EditEmployee editForm = new UC_EditEmployee(employee))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                await LoadEmployeeBoard();
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
                if (dgvUser.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvUser.SelectedRows[0];

                    string userID = selectedRow.Cells["userIDCol"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá người dùng này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = await Task.Run(() => userRepo.DeleteUserAccountByID(userID));

                        if (success)
                        {
                            MessageBox.Show("Xoá người dùng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUserBoard();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xoá người dùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                string selectedMode = cmbSort.SelectedItem.ToString();
                DataGridViewColumn sortColumn = dgvEmployee.Columns["empIDCol"];
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

                dgvEmployee.Sort(sortColumn, direction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn tác vụ sắp xếp: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _debounceCts?.Cancel();
            _debounceCts = new CancellationTokenSource();
            var token = _debounceCts.Token;

            try
            {
                await Task.Delay(300, token);

                string search = txtSearch.Text.Trim();
                await LoadEmployeeBoard(search);
            }
            catch (Exception ex)
            {
                if (!(ex is TaskCanceledException))
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
