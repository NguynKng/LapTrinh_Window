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
    public partial class UC_Invoice : Form
    {
        private readonly Invoice _invoice;
        private readonly PartRepository partRepo = new PartRepository(new DatabaseContext());
        private readonly OrderRepository orderRepo = new OrderRepository(new DatabaseContext());
        public UC_Invoice(Invoice invoice)
        {
            InitializeComponent();
            _invoice = invoice;
        }

        public async void setData()
        {
            labelInvoiceID.Text = _invoice.Id;
            labelCusName.Text = _invoice.CustomerName;
            labelEmpName.Text = _invoice.EmployeeName;
            labelOrderID.Text = _invoice.OrderID;
            labelCheckIn.Text = _invoice.CheckIn.ToString("dd/MM/yyyy");
            labelCheckOut.Text = _invoice.CheckOut.ToString("dd/MM/yyyy");
            labelTotal.Text = _invoice.Total.ToString() + " VND";
            labelMethod.Text = _invoice.Method;
            await LoadListViewOrder();
        }

        private async Task LoadListViewOrder()
        {
            List<Part> listParts = await Task.Run(() => partRepo.GetListPartFromOrder(_invoice.OrderID));
            listViewDetailOrder.Items.Clear();
            int index = 1;
            foreach (var part in listParts)
            {
                var item = new ListViewItem(index.ToString());

                item.SubItems.Add(part.PartId);
                item.SubItems.Add(part.PartName);
                item.SubItems.Add(part.Quantity.ToString());
                item.SubItems.Add(part.Price.ToString());
                int total = part.Quantity * part.Price;
                item.SubItems.Add(total.ToString());

                listViewDetailOrder.Items.Add(item);
                index++;
            }
        }

        private void UC_Invoice_Load(object sender, EventArgs e)
        {
            setData();  
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderRepo.InsertInvoice(_invoice))
                {
                    MessageBox.Show("In hoá đơn thành công.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra! Không thể in hoá đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
