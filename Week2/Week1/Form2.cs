namespace Bai1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void TinhBtn(object sender, EventArgs e)
        {
            String a_txt = aTxt.Text;
            String b_txt = bTxt.Text;
            float a = float.Parse(a_txt);
            float b = float.Parse(b_txt);
            if (a == 0)
            {
                if (b == 0)
                {
                    ketquaTxt.Text = "Phương trình có vô số nghiệm.";
                }
                else
                {
                    ketquaTxt.Text = "Phương trình vô nghiệm.";
                }
            }
            else
            {
                double x = -b / a;
                ketquaTxt.Text = "Phương trình có nghiệm.";
                nghiemTxt.Text = x.ToString();
            }
        }

        private void TiepBtn(object sender, EventArgs e)
        {
            Week1.Form3 form3 = new Week1.Form3();
            form3.Show(); // Open Form2
            this.Hide();
        }

        private void ThoatBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
