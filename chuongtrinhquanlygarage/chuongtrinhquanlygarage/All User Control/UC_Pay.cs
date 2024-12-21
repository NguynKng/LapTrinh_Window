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

namespace chuongtrinhquanlygarage.All_User_Control
{
    public partial class UC_Pay : UserControl
    {
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        private readonly CustomerRepository cusRepo = new CustomerRepository(new DatabaseContext());
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
                // Fetch the list of orders asynchronously
                List<Order> listOrder = await Task.Run(() => orderRepo.GetAllOrdersIsCompleted());

                // Reset the ListView
                listViewOrder.Items.Clear();

                // Add each order to the ListView
                foreach (var order in listOrder)
                {
                    // Create a new ListViewItem (represents a row in the ListView)
                    ListViewItem item = new ListViewItem(order.OrderId.ToString()); // First column: Order ID
                    // Add subitems for each column
                    item.SubItems.Add(order.LicensePlate);  // Second column: License Plate
                    item.SubItems.Add(order.CreatedAt.ToString("MM/dd/yyyy")); // Third column: Created Date (formatted as dd/mm/yyyy)
                    item.SubItems.Add(order.Total.ToString());  // Fourth column: Total (formatted as currency)

                    // Add the item (row) to the ListView
                    listViewOrder.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Handle errors and show message
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách đơn hàng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadInvoiceBoard(string name = null)
        {
            try
            {
                // Fetch the list of orders asynchronously
                List<Invoice> listInvoice = await Task.Run(() => orderRepo.GetAllInvoice(name));

                // Reset the ListView
                listViewInvoice.Items.Clear();

                // Add each order to the ListView
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

                    // Add the item (row) to the ListView
                    listViewInvoice.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Handle errors and show message
                MessageBox.Show($"Lỗi xảy ra khi tải danh sách hoá đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Get the selected item
                    ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                    Motor motor = await Task.Run(() => cusRepo.GetCustomerByLicensePlate(selectedItem.SubItems[1].Text));

                    txtOrderID.Text = selectedItem.SubItems[0].Text;
                    txtCusID.Text = motor.Customer.Id;
                    txtName.Text = motor.Customer.Name;
                    string dateString = selectedItem.SubItems[2].Text;  // Assuming date is in the 3rd column

                    DateTime selectedDate = DateTime.Parse(dateString);
                    dateCheckIn.Value = selectedDate;
                    txtTotal.Text = selectedItem.SubItems[3].Text;

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
                // Check if any row is selected in the DataGridView
                if (listViewOrder.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                    string orderId = selectedItem.SubItems[0].Text;
                    // Check if the selected row has a valid Order ID
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
                    // Check the payment method
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
                        // Open the Edit Order form and pass the order and its details
                        using (UC_Invoice editForm = new UC_Invoice(invoice))
                        {
                            // Check if the user saved changes successfully
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                await LoadOrderCompleted();
                                await LoadInvoiceBoard();
                                // Reload the order list after successful update
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
                // Handle exceptions gracefully
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
                // Determine the selected sorting mode
                string selectedMode = cmbSort.SelectedItem.ToString();

                // Default sort column and order
                int sortColumn = 0; // Default to the first column
                bool ascending = true;

                // Set sort column and order based on the selected mode
                switch (selectedMode)
                {
                    case "Mặc định":
                        sortColumn = 0; // Default to the first column
                        ascending = true;
                        break;
                    case "Tên A-Z":
                        sortColumn = 2; // Assuming the name is in column index 1
                        ascending = true;
                        break;
                    case "Tên Z-A":
                        sortColumn = 2; // Assuming the name is in column index 1
                        ascending = false;
                        break;
                    case "Trị giá ↑":
                        sortColumn = 4; // Assuming the salary is in column index 2
                        ascending = true;
                        break;
                    case "Trị giá ↓":
                        sortColumn = 4; // Assuming the salary is in column index 2
                        ascending = false;
                        break;
                    case "Ngày gần nhất":
                        sortColumn = 7; // Assuming the role is in column index 3
                        ascending = true;
                        break;
                }

                // Apply the sort using a custom comparer
                listViewInvoice.ListViewItemSorter = new ListViewItemComparer(sortColumn, ascending);
                listViewInvoice.Sort(); // Sort the ListView
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
                // Check if any row is selected in the DataGridView
                if (listViewInvoice.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewInvoice.SelectedItems[0];
                    string invoiceId = selectedItem.SubItems[0].Text;
                    // Check if the selected row has a valid Order ID
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
                        // Open the Edit Order form and pass the order and its details
                        using (var invoiceForm = new UC_Invoice1(invoice))
                        {
                            invoiceForm.ShowDialog(); // Display the form as a dialog
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
                // Handle exceptions gracefully
                MessageBox.Show($"Lỗi xảy ra khi chọn hoá đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewInvoiceBtn.Enabled = true;
        }
    }
}
