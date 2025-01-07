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
using static chuongtrinhquanlygarage.Logic.Utils;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_EditEmployee : Form
    {
        private readonly Employee _employee;
        private readonly EmployeeRepository empRepo = new EmployeeRepository(new DatabaseContext());
        public UC_EditEmployee(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
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
                MessageBox.Show($"An error occurred while loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UC_EditEmployee_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            setData();
        }

        private void setData()
        {
            txtEmpID.Text = _employee.Id;
            txtName.Text = _employee.Name;
            txtPhoneNum.Text = _employee.PhoneNumber;
            txtGender.Text = _employee.Gender;
            txtEmail.Text = _employee.Email;
            txtSalary.Text = _employee.BaseSalary.ToString();
            txtRole.Text = _employee.EmpType;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user inputs from textboxes
                string employId = txtEmpID.Text.Trim();
                string name = txtName.Text.Trim();
                string phoneNum = txtPhoneNum.Text.Trim();
                string gender = txtGender.Text.Trim();
                string email = txtEmail.Text.Trim();
                string salary = txtSalary.Text.Replace(",", "").Trim();
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

                if (!IsValidPhoneNumber(phoneNum))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if the email already exists
                if (email != _employee.Email && empRepo.ExistedEmail(email))
                {
                    MessageBox.Show("Email đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if the phone number already exists
                if (phoneNum != _employee.PhoneNumber && empRepo.ExistedPhoneNumber(phoneNum))
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
                    BaseSalary = int.Parse(salary),
                    EmpType = role
                };

                if (empRepo.UpdateEmployee(employee))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể cập nhật nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtSalary.SelectionStart;

            // Remove formatting
            string unformattedText = txtSalary.Text.Replace(",", "");

            if (long.TryParse(unformattedText, out long number))
            {
                txtSalary.Text = string.Format("{0:N0}", number);
                txtSalary.SelectionStart = Math.Min(cursorPosition, txtSalary.Text.Length);
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
