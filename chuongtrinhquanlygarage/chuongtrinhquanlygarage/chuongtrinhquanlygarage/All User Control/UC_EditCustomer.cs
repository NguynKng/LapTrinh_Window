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
    public partial class UC_EditCustomer : Form
    {
        private readonly Motor _motor;
        private readonly CustomerRepository cusRepo = new CustomerRepository(new DatabaseContext());
        public UC_EditCustomer(Motor motor)
        {
            InitializeComponent();
            _motor = motor;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = txtCusID.Text.Trim();
                string name = txtName.Text.Trim();
                string phoneNum = txtPhoneNum.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string licensePlate = txtLicensePlate.Text.Trim();
                string type = txtType.Text.Trim();
                string modelYear = txtYear.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(licensePlate) || string.IsNullOrEmpty(type))
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

                if (!IsValidLicensePlate(licensePlate))
                {
                    MessageBox.Show("Biển số xe không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Customer customer = new Customer { 
                    Id = customerId,
                    Name = name,
                    Email = email,
                    Address = address,
                    PhoneNumber = phoneNum,
                };

                Motor motor = new Motor
                {
                    Customer = customer,
                    LicensePlate = licensePlate,
                    Model = type,
                    Year = modelYear != null ? int.Parse(modelYear.ToString()) : 0
                };

                if (cusRepo.UpdateCustomer(motor))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể cập nhật thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setData()
        {
            txtCusID.Text = _motor.Customer.Id;
            txtName.Text = _motor.Customer.Name;
            txtPhoneNum.Text = _motor.Customer.PhoneNumber;
            txtEmail.Text = _motor.Customer.Email;
            txtAddress.Text = _motor.Customer.Address;
            txtType.Text = _motor.Model;
            txtLicensePlate.Text = _motor.LicensePlate;
            txtYear.Text = _motor.Year.ToString();
        }

        private void UC_EditCustomer_Load(object sender, EventArgs e)
        {
            setData();
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
