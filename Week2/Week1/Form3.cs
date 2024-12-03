using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai1;

namespace Week1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void findClick(object sender, EventArgs e)
        {
            String number = number_txt.Text;
            String ketqua = "";
            for (int i = number.Length-1; i >= 0; i--)
            {

                ketqua += number[i];
            }
            result_txt.Text = ketqua;
        }

        private void nextClick(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void exitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
