namespace bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = listBox1.Items.Count;
            for (int i = 0; i < n; i++)
            {
                int tam = int.Parse(listBox1.Items[i].ToString()) + 2;
                listBox1.Items.RemoveAt(i);
                listBox1.Items.Insert(i, tam.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = listBox1.Items.Count;
            for (int i = 0; i < n - 1; i++)
            {
                if (int.Parse(listBox1.Items[i].ToString()) % 2 == 0)
                {
                    string s = listBox1.Items[i].ToString();
                    listBox1.SelectedItem = s;
                    break;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = listBox1.Items.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                if (int.Parse(listBox1.Items[i].ToString()) % 2 == 1)
                {
                    string s = listBox1.Items[i].ToString();
                    listBox1.SelectedItem = s;
                    break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedItems.Count;
            for (int i = n - 1; i >= 0; i--)
                listBox1.Items.Remove(listBox1.SelectedItems[i].ToString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.Items[0].ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = listBox1.Items.Count;

            listBox1.Items.Remove(listBox1.Items[n - 1].ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) && e.KeyChar == (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có thật sự muốn thoát chương trình?",  // Message
        "Thông báo!",                              // Title
        MessageBoxButtons.YesNo,                   // Buttons
        MessageBoxIcon.Question                    // Icon
    );

           
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
