using System.Data;

namespace bai_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tên món", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dataGridView1.DataSource = dt;

            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += button_Click;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string tenmon = btn.Text;
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null) return;

            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("Tên món") == tenmon);

            if (existingRow != null)
            {
                existingRow["Số lượng"] = Convert.ToInt32(existingRow["Số lượng"]) + 1;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["Tên món"] = tenmon;
                newRow["Số lượng"] = 1;
                dt.Rows.Add(newRow);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string tenmon = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên món muốn xóa:",
                "Xóa món",
                ""
            );

            if (string.IsNullOrWhiteSpace(tenmon))
            {
                MessageBox.Show("Tên món không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                MessageBox.Show("Không tìm thấy nguồn dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int dong = mondachon(tenmon, dt);
            if (dong != -1)
            {
                dt.Rows.RemoveAt(dong);
                MessageBox.Show($"Đã xóa món: {tenmon}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Không tìm thấy món: {tenmon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int mondachon(string tenmon, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Tên món"].ToString() == tenmon)
                {
                    return i;
                }
            }
            return -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
