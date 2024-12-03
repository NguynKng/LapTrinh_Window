namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tinhBtn(object sender, EventArgs e)
        {
            String m = sodauTxt.Text;
            String n = socuoiTxt.Text;
            Int32 tong = 0;
            Int32 sodau = Int32.Parse(m);
            Int32 socuoi = Int32.Parse(n);
            for (Int32 i = sodau; i <= socuoi; i++)
            {
                tong = tong + i;
            }
            ketquaTxt.Text = tong.ToString();
        }

        private void tiepBtn(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); // Open Form2
            this.Hide();
        }

        private void exitBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
