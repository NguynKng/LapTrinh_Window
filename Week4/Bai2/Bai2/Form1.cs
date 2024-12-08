using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int GetSelectedRow(string mssv)
        {
            for (int i = 0; i<dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow && dataGridView1.Rows[i].Cells[0].Value.ToString() == mssv)
                {
                    return i;
                }
            }
            return -1;
        }

        private void insertUpdate(int selectedRow)
        {
            dataGridView1.Rows[selectedRow].Cells["mssvCol"].Value = mssvTxt.Text;
            dataGridView1.Rows[selectedRow].Cells["nameCol"].Value = nameTxt.Text;
            dataGridView1.Rows[selectedRow].Cells["sexCol"].Value = namRadio.Checked ? "Nam" : "Nữ";
            dataGridView1.Rows[selectedRow].Cells["gradeCol"].Value = diemTxt.Text;
            dataGridView1.Rows[selectedRow].Cells["facultyCol"].Value = majorTxt.Text;
            quantityMaleTxt.Text = countMale().ToString();
            quantityFemaleTxt.Text = countFemale().ToString();
        }

        private void addEditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var regexItem = new Regex("^[a-zA-Z0-9]");
                if (string.IsNullOrEmpty(mssvTxt.Text) || string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(diemTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên", "Thông báo", MessageBoxButtons.OK);
                    resetForm();
                }
                else
                {
                    if (!regexItem.IsMatch(mssvTxt.Text) || !regexItem.IsMatch(nameTxt.Text))
                    {
                        MessageBox.Show("Vui lòng không nhập kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK);
                    } else
                    {
                        int selectedRow = GetSelectedRow(mssvTxt.Text);
                        if (selectedRow == -1)
                        {
                            selectedRow = dataGridView1.Rows.Add();
                            insertUpdate(selectedRow);
                            MessageBox.Show("Thêm sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                            resetForm();

                        }
                        else
                        {
                            insertUpdate(selectedRow);
                            MessageBox.Show("Cập nhật thông tin sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                            resetForm();
                        }
                    }
                }
                quantityMaleTxt.Text = countMale().ToString();
                quantityFemaleTxt.Text = countFemale().ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetForm()
        {
            mssvTxt.Text = "";
            nameTxt.Text = "";
            diemTxt.Text = "";
            namRadio.Checked = true;
            majorTxt.SelectedIndex = 0;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá sinh viên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);           
                    if (result == DialogResult.Yes) {
                        int deleteIndex = dataGridView1.SelectedRows[0].Index;

                        updateTrack(dataGridView1.Rows[deleteIndex].Cells["mssvCol"].Value.ToString(), dataGridView1.Rows[deleteIndex].Cells["nameCol"].Value.ToString(), dataGridView1.Rows[deleteIndex].Cells["sexCol"].Value.ToString(), dataGridView1.Rows[deleteIndex].Cells["gradeCol"].Value.ToString(), dataGridView1.Rows[deleteIndex].Cells["facultyCol"].Value.ToString());
                        dataGridView1.Rows.RemoveAt(deleteIndex);
                        MessageBox.Show("Xoá sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                        resetForm();
                    }

                } else {
                    MessageBox.Show("Vui lòng chọn sinh viên để xoá !", "Thông báo", MessageBoxButtons.OK);
                }
                quantityMaleTxt.Text = countMale().ToString();
                quantityFemaleTxt.Text = countFemale().ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                mssvTxt.Text = selectedRow.Cells["mssvCol"].Value?.ToString();
                nameTxt.Text = selectedRow.Cells["nameCol"].Value?.ToString();
                diemTxt.Text = selectedRow.Cells["gradeCol"].Value?.ToString();
                majorTxt.Text = selectedRow.Cells["facultyCol"].Value?.ToString();
                if (selectedRow.Cells["sexCol"].Value.ToString() == "Nam")
                {
                    namRadio.Checked = true;
                }
                else
                {
                    nuRadio.Checked = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            majorTxt.SelectedIndex = 0;
            mssvTxt.Focus();
            namRadio.Checked = true;
            quantityMaleTxt.Text = countMale().ToString();
            quantityFemaleTxt.Text = countFemale().ToString();
        }

        private int countMale()
        {
            int count = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    if (dataGridView1.Rows[i].Cells["sexCol"].Value.ToString() == "Nam")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int countFemale()
        {
            int count = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    if (dataGridView1.Rows[i].Cells["sexCol"].Value.ToString() == "Nữ")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void updateTrack(string mssv, string ten, string sex, string diem, string khoa)
        {
            int addIndex = dataGridView2.Rows.Add();
            dataGridView2.Rows[addIndex].Cells["mssvTrackCol"].Value = mssv;
            dataGridView2.Rows[addIndex].Cells["nameTrackCol"].Value = ten;
            dataGridView2.Rows[addIndex].Cells["sexTrackCol"].Value = sex;
            dataGridView2.Rows[addIndex].Cells["gradeTrackCol"].Value = diem;
            dataGridView2.Rows[addIndex].Cells["facultyTrackCol"].Value = khoa;
            dataGridView2.Rows[addIndex].Cells["timeCol"].Value = System.DateTime.Today;
        }
    }
}
