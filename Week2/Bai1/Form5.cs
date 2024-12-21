using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private int sumList(int m, int n)
        {
            int ketqua = 0;
            for(int i = m; i <= n; i++)
            {
                ketqua += i;
            }

            // Display the prime numbers in the TextBox as a comma-separated list

            return ketqua; 
        }

        private void findBtn(object sender, EventArgs e)
        {
            int m = int.Parse(sodauTxt.Text);
            int n = int.Parse(socuoiTxt.Text);
            ketquaTxt.Text = sumList(m,n).ToString();
        }

        private void exitBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
