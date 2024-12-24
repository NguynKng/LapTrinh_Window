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
using Bai2.Models;

namespace Bai2
{
    public partial class Bai3 : Form
    {
        public bool themmoi = false;
        Nhanvien nv = new Nhanvien();
        public Bai3()
        {
            InitializeComponent();
        }

        void HienthiNhanvien()
        {
            DataTable dt = nv.LayDSNhanvien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }

        void HienthiBangcap()
        {
            DataTable dt = nv.LayBangcap();
            cmbDegree.DataSource = dt;
            cmbDegree.DisplayMember = "TenBangcap";
            cmbDegree.ValueMember = "MaBangcap";
        }



        private void Bai3_Load(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            HienthiNhanvien();
            HienthiBangcap();
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            txtName.Focus();

        }

        void setNull()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        void setButton(bool val)
        {
            addBtn.Enabled = val;
            delBtn.Enabled = val;
            editBtn.Enabled = val;
            exitBtn.Enabled = val;
            saveBtn.Enabled = !val;
            cancelBtn.Enabled = !val;
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                txtName.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                //Chuyen sang kieu dateTime
                txtBirth.Value = DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[2].Text);
                txtAddress.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtPhone.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                //Tìm vị trí của Tên bằng cấp trong Combobox
                cmbDegree.SelectedIndex = cmbDegree.FindString(lsvNhanVien.SelectedItems[0].SubItems[5].Text);
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật","Sửa mẫu tin");

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(
lsvNhanVien.SelectedItems[0].SubItems[0].Text);
                    lsvNhanVien.Items.RemoveAt(
lsvNhanVien.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}",txtBirth.Value);
            //Định dạng ngày tương ứng với trong CSDL SQLserver
            if (themmoi)
            {
                nv.ThemNhanVien(txtName.Text, ngay, txtAddress.Text,
txtPhone.Text, cmbDegree.SelectedValue.ToString());
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                nv.CapNhatNhanVien(
lsvNhanVien.SelectedItems[0].SubItems[0].Text,
txtName.Text, ngay, txtAddress.Text, txtPhone.Text, cmbDegree.SelectedValue.ToString());
                MessageBox.Show("Cập nhật thành công");
            }
            HienthiNhanvien();
            setNull();
        }
    }
}
