using System.Formats.Nrbf;

namespace bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Pay()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("vui long nhap ten KH");
                textBox1.Focus();
            }
            else
            {
                long tong = 0;
                if (checkBox1.Checked == true)
                {
                    tong += 100000;
                }
                if (checkBox2.Checked == true)
                {
                    tong += 1200000;
                }
                if (checkBox3.Checked == true)
                {
                    tong += 200000;
                }
                int soluong = int.Parse(numericUpDown1.Value.ToString());

                tong += soluong * 80000;

                textBox2.Text = string.Format("{0:#,###} đồng", tong);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pay();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
