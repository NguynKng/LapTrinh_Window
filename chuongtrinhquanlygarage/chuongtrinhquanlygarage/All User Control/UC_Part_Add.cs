using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Database;
using chuongtrinhquanlygarage.Models;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Part_Add : Form
    {
        private readonly Part _part; // Holds the part being edited (if any)
        private readonly PartRepository partRepo = new PartRepository(new DatabaseContext());

        public UC_Part_Add(Part part = null)
        {
            InitializeComponent();
            _part = part;
        }

        private void UC_Part_Add_Load(object sender, EventArgs e)
        {           
            setPartData();
        }

        private async void setPartData()
        {
            if (_part != null)
            {
                txtPartID.Text = _part.PartId;
                txtName.Text = _part.PartName;
                txtQuantity.Text = _part.Quantity.ToString();
                txtLimitStock.Text = _part.LimitStock.ToString();
                txtPrice.Text = _part.Price.ToString();
                txtBuyPrice.Text = _part.BuyPrice.ToString();
                txtEmployeePrice.Text = _part.EmployeePrice.ToString();
                txtUnit.Text = _part.Unit;
                titleLabel.Text = "Sửa Phụ Tùng";
                btnSave.Text = "Cập nhật";
                txtName.Focus();
            }
            else
            {
                txtPartID.Text = await Task.Run(() => partRepo.GetNextPartID());
                txtName.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtLimitStock.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtBuyPrice.Text = string.Empty;
                txtEmployeePrice.Text = string.Empty;
                txtUnit.Text = string.Empty;

                // Update form UI to indicate add mode
                titleLabel.Text = "Thêm Phụ Tùng"; // Vietnamese: Add New Part
                btnSave.Text = "Thêm";
                txtName.Focus();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrEmpty(txtBuyPrice.Text) || 
                    string.IsNullOrWhiteSpace(txtEmployeePrice.Text) || string.IsNullOrWhiteSpace(txtUnit.Text) ||
                    string.IsNullOrWhiteSpace(txtLimitStock.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse values from input fields
                string partID = txtPartID.Text.Trim();
                string partName = txtName.Text.Trim();
                int quantity = int.TryParse(txtQuantity.Text.Trim().Replace(",", ""), out int q) ? q : 0;
                int price = int.TryParse(txtPrice.Text.Trim().Replace(",", ""), out int p) ? p : 0;
                int buyPrice = int.TryParse(txtBuyPrice.Text.Trim().Replace(",", ""), out int bp) ? bp : 0;
                int employeePrice = int.TryParse(txtEmployeePrice.Text.Trim().Replace(",", ""), out int ep) ? ep : 0;
                string unit = txtUnit.Text.Trim();
                int limitStock = int.TryParse(txtLimitStock.Text.Trim(), out int ls) ? ls : 0;

                if (quantity < 0 || price <= 0 || buyPrice < 0 || employeePrice < 0)
                {
                    MessageBox.Show("Số lượng và giá phải là số phù hợp", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(quantity < limitStock)
                {
                    MessageBox.Show("Tồn không thể ít hơn tồn tối thiểu", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_part != null) // Update part
                {
                    _part.PartName = partName;
                    _part.Quantity = quantity;
                    _part.Price = price;
                    _part.BuyPrice = buyPrice;
                    _part.EmployeePrice = employeePrice;
                    _part.Unit = unit;
                    _part.LimitStock = limitStock;

                    bool isUpdated = await Task.Run(() => partRepo.UpdatePart(_part));
                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật phụ tùng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật phụ tùng thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Add new part
                {
                    var newPart = new Part
                    {
                        PartId = partID,
                        PartName = partName,
                        Quantity = quantity,
                        Price = price,
                        BuyPrice = buyPrice,
                        EmployeePrice = employeePrice,
                        Unit = unit,
                        LimitStock = limitStock
                    };

                    bool isAdded = await Task.Run (() => partRepo.AddPart(newPart));
                    if (isAdded)
                    {
                        MessageBox.Show("Thêm phụ tùng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm phụ tùng thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            FormatTextBoxWithCommas(txtPrice);
        }

        private void txtBuyPrice_TextChanged(object sender, EventArgs e)
        {
            FormatTextBoxWithCommas(txtBuyPrice);
        }

        private void txtEmployeePrice_TextChanged(object sender, EventArgs e)
        {
            FormatTextBoxWithCommas(txtEmployeePrice);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            FormatTextBoxWithCommas(txtQuantity);
        }

        private void FormatTextBoxWithCommas(Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            // Save the cursor position to avoid jumping
            int cursorPosition = textBox.SelectionStart;

            // Remove formatting
            string unformattedText = textBox.Text.Replace(",", "");

            if (int.TryParse(unformattedText, out int number))
            {
                // Format the number with thousand separators
                textBox.Text = string.Format("{0:N0}", number);
                textBox.SelectionStart = Math.Min(cursorPosition, textBox.Text.Length);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimitStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmployeePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
