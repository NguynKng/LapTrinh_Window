namespace bai_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Không đủ thông tin");
                return;
            }

            ListViewItem lvi = listView1.Items.Add(textBox1.Text);
            lvi.SubItems.Add(dateTimePicker1.Value.ToShortDateString());
            lvi.SubItems.Add(textBox2.Text);
            lvi.SubItems.Add(textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = dateTimePicker1.Value.ToShortDateString();
                listView1.SelectedItems[0].SubItems[2].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[3].Text = textBox3.Text;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có thật sự muốn thoát chương trình?",  // Message
        "Thông báo!",                              // Title
        MessageBoxButtons.YesNo,                   // Buttons
        MessageBoxIcon.Question                    // Icon
    );

            // Check the user's response
            if (result == DialogResult.No)
            {
                // Cancel the closing event
                e.Cancel = true;
            }
        }
    }
}
