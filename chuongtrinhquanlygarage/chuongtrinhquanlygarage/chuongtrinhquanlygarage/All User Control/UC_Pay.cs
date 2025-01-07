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
using System.Xml.Linq;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using chuongtrinhquanlygarage.Logic;
using System.Threading;

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Pay : UserControl
    {
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        private readonly CustomerRepository cusRepo = new CustomerRepository(new DatabaseContext());
        private CancellationTokenSource _debounceCts;
        public UC_Pay()
        {
            InitializeComponent();
        }

        private void EnableTextBox()
        {
            dateCheckOut.Enabled = true;
            radioCash.Enabled = true;
            radioTransfer.Enabled = true;
            btnPay.Enabled = true;
            txtTotal.Enabled = true;
        }

        private async Task LoadOrderCompleted()
        {
            try
            {
                
                List<Order> listOrder = await Task.Run(() => orderRepo.GetAllOrdersIsCompleted());

                // Reset the ListView
                listViewOrder.Items.Clear();
                int index = 1;

                foreach (var order in listOrder)
                {
                    ListViewItem item = new ListViewItem(index.ToString());
                    item.SubItems.Add(order.OrderId);
                    item.SubItems.Add(order.LicensePlate);
                    item.SubItems.Add(order.CreatedAt.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(order.Total.ToString());

                    listViewOrder.Items.Add(item);
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách đơn hàng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadInvoiceBoard(string name = null)
        {
            _debounceCts?.Cancel();
            _debounceCts = new CancellationTokenSource();
            var token = _debounceCts.Token;

            try
            {
                await Task.Delay(300, token);

                List<Invoice> listInvoice = await Task.Run(() => orderRepo.GetAllInvoice(name));

                if (token.IsCancellationRequested)
                    return;

                listViewInvoice.Items.Clear();
                foreach (var invoice in listInvoice)
                {
                    ListViewItem item = new ListViewItem(invoice.Id);
                    item.SubItems.Add(invoice.OrderID);
                    item.SubItems.Add(invoice.CustomerName);
                    item.SubItems.Add(invoice.EmployeeName);
                    item.SubItems.Add(invoice.Method);
                    item.SubItems.Add(invoice.Total.ToString());
                    item.SubItems.Add(invoice.CheckIn.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(invoice.CheckOut.ToString("dd/MM/yyyy"));

                    listViewInvoice.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                if (!(ex is TaskCanceledException))
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void UC_Pay_Load(object sender, EventArgs e)
        {
            await LoadOrderCompleted();
            await LoadInvoiceBoard();
            cmbSort.SelectedItem = "Mặc định";
        }

        private async void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if any item is selected in the ListView
            if (listViewOrder.SelectedItems.Count > 0)
            {
                EnableTextBox();
                try
                {
                    ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                    Motor motor = await Task.Run(() => cusRepo.GetCustomerByLicensePlate(selectedItem.SubItems[2].Text));

                    txtOrderID.Text = selectedItem.SubItems[1].Text;
                    txtCusID.Text = motor.Customer.Id;
                    txtName.Text = motor.Customer.Name;
                    string dateString = selectedItem.SubItems[3].Text;
                    string dateFormat = "dd/MM/yyyy";
                    // Parse the date string using DateTime.ParseExact
                    DateTime selectedDate = DateTime.ParseExact(dateString, dateFormat,
                                                               System.Globalization.CultureInfo.InvariantCulture);
                    dateCheckIn.Value = selectedDate;
                    txtTotal.Text = int.Parse(selectedItem.SubItems[4].Text).ToString("N0");

                }
                catch (Exception ex)
                {
                    // Handle errors and show message
                    MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrder.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                    string orderId = selectedItem.SubItems[1].Text;
                    if (string.IsNullOrWhiteSpace(orderId))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu hợp lệ để thanh toán.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Invoice invoice = await Task.Run(() => orderRepo.GetInvoiceByOrderID(orderId));
                    if (invoice == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn cho đơn hàng được chọn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    invoice.CheckOut = dateCheckOut.Value;
                    if (radioCash.Checked)
                    {
                        invoice.Method = radioCash.Text;
                    }
                    else if (radioTransfer.Checked)
                    {
                        invoice.Method = radioTransfer.Text;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    invoice.Id = await Task.Run(() => orderRepo.GetNextInvoiceID());
                    if (invoice != null)
                    {
                        using (UC_Invoice editForm = new UC_Invoice(invoice))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                await LoadOrderCompleted();
                                await LoadInvoiceBoard();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu đơn hàng hoặc chi tiết.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xem.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchByName.Text;

            if (string.IsNullOrWhiteSpace(search))
            {
                listViewOrder.Items.Clear();
                await LoadInvoiceBoard();
            }
            else
            {
                listViewOrder.Items.Clear();
                await LoadInvoiceBoard(search);
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedMode = cmbSort.SelectedItem.ToString();

                int sortColumn = 0;
                bool ascending = true;

                switch (selectedMode)
                {
                    case "Mặc định":
                        sortColumn = 0;
                        ascending = true;
                        break;
                    case "Tên A-Z":
                        sortColumn = 2;
                        ascending = true;
                        break;
                    case "Tên Z-A":
                        sortColumn = 2;
                        ascending = false;
                        break;
                    case "Trị giá ↑":
                        sortColumn = 5;
                        ascending = true;
                        break;
                    case "Trị giá ↓":
                        sortColumn = 5;
                        ascending = false;
                        break;
                    case "Ngày gần nhất":
                        sortColumn = 7;
                        ascending = false;
                        break;
                }

                listViewInvoice.ListViewItemSorter = new ListViewItemComparer(sortColumn, ascending);
                listViewInvoice.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn tác vụ sắp xếp: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewInvoice.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewInvoice.SelectedItems[0];
                    string invoiceId = selectedItem.SubItems[0].Text;
                    if (string.IsNullOrWhiteSpace(invoiceId))
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu hợp lệ để xem hoá đơn.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Invoice invoice = await Task.Run(() => orderRepo.GetInvoiceByID(invoiceId));
                    if (invoice == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn cho đơn hàng được chọn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (invoice != null)
                    {
                        using (var invoiceForm = new UC_Invoice1(invoice))
                        {
                            invoiceForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu hoá đơn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hoá đơn để xem.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi chọn hoá đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewInvoiceBtn.Enabled = true;
        }

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            await LoadInvoiceBoard();
            await LoadOrderCompleted();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
