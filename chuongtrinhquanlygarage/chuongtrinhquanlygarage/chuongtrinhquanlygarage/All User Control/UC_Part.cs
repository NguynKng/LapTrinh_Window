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
using System.Threading;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Part : UserControl
    {
        private readonly PartRepository partRepo = new PartRepository(new DatabaseContext());
        private CancellationTokenSource _debounceCts;
        public UC_Part()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (UC_Part_Add editForm = new UC_Part_Add())
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadPartBoard();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Lỗi xảy ra khi hiện form thêm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPartBoard(string name = null)
        {
            try
            {
                List<Part> listParts = await Task.Run(() => partRepo.GetAllParts(name));

                // Reset the collections
                dgvPart.Rows.Clear();

                foreach (var part in listParts)
                {
                    dgvPart.Rows.Add(
                        part.PartId,
                        part.PartName,
                        part.Quantity,
                        part.LimitStock,
                        part.Unit,
                        part.BuyPrice,
                        part.EmployeePrice,
                        part.Price
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách phụ tùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UC_Part_Load(object sender, EventArgs e)
        {
            await LoadPartBoard();
            dgvPart.ClearSelection();
            cmbSort.SelectedItem = "Mặc định";
            cmbSortPrice.SelectedIndex = -1;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            try
            {
                List<Part> listParts = await Task.Run(() => partRepo.GetAllParts(searchQuery));

                dgvPart.Rows.Clear();

                foreach (var part in listParts)
                {
                    dgvPart.Rows.Add(
                        part.PartId,
                        part.PartName,
                        part.Quantity,
                        part.LimitStock,
                        part.Unit,
                        part.BuyPrice.ToString("N0"),
                        part.EmployeePrice.ToString("N0"),
                        part.Price.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tìm kiếm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPart.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = dgvPart.SelectedRows[0];

                if (selectedRow.Cells["partIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["partIDCol"].Value.ToString()))
                {
                    MessageBox.Show("Dòng được chọn không có dữ liệu để sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string partID = selectedRow.Cells["partIDCol"].Value.ToString();

                try
                {
                    var part = partRepo.GetPartByID(partID);

                    
                    if (part != null)
                    {
                        using (UC_Part_Add editForm = new UC_Part_Add(part))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                await LoadPartBoard();
                                cmbSort.SelectedItem = "Mặc định";
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
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để chỉnh sửa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPart.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvPart.SelectedRows[0];

                    if (selectedRow.Cells["partIDCol"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["partIDCol"].Value.ToString()))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu để xoá.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string partID = selectedRow.Cells["partIDCol"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        "Bạn có muốn xoá phụ tùng này ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = await Task.Run(() => partRepo.DeletePartByID(partID));

                        if (success)
                        {
                            MessageBox.Show("Xoá phụ tùng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPartBoard();
                            cmbSort.SelectedItem = "Mặc định";
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xoá phụ tùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phụ tùng để xoá.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi xoá phụ tùng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSortPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = cmbSortPrice.SelectedItem.ToString();
                DataGridViewColumn sortColumn = null;
                ListSortDirection direction = ListSortDirection.Ascending;

                switch (selectedMode)
                {
                    case "Giá Mua ↑":
                        sortColumn = dgvPart.Columns["buyPriceCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Giá Mua ↓":
                        sortColumn = dgvPart.Columns["buyPriceCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    case "Giá Bán ↑":
                        sortColumn = dgvPart.Columns["priceCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Giá Bán ↓":
                        sortColumn = dgvPart.Columns["priceCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    case "Giá Thợ ↑":
                        sortColumn = dgvPart.Columns["employeePriceCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Giá Thợ ↓":
                        sortColumn = dgvPart.Columns["employeePriceCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    default:
                        MessageBox.Show("Chế độ sắp xếp không có", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                
                dgvPart.Sort(sortColumn, direction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi sắp xếp: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                await LoadPartBoard(search);
            }
            catch (Exception ex)
            {
                if (!(ex is TaskCanceledException))
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbSort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = cmbSort.SelectedItem.ToString();
                DataGridViewColumn sortColumn = dgvPart.Columns["partIDCol"];
                ListSortDirection direction = ListSortDirection.Ascending;

                switch (selectedMode)
                {
                    case "Tên A-Z":
                        sortColumn = dgvPart.Columns["partNameCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Tên Z-A":
                        sortColumn = dgvPart.Columns["partNameCol"];
                        direction = ListSortDirection.Descending;
                        break;
                    case "Tồn ↑":
                        sortColumn = dgvPart.Columns["quantityCol"];
                        direction = ListSortDirection.Ascending;
                        break;
                    case "Tồn ↓":
                        sortColumn = dgvPart.Columns["quantityCol"];
                        direction = ListSortDirection.Descending;
                        break;
                }

                dgvPart.Sort(sortColumn, direction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tìm kiếm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
