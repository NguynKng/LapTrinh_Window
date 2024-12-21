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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        bool isPrime(int so)
        {
            // Loại bỏ các trường hợp đặc biệt
            if (so <= 1)
                return false; // Các số nhỏ hơn hoặc bằng 1 không phải số nguyên tố

            // Kiểm tra từ 2 đến căn bậc hai của số
            for (int i = 2; i <= Math.Sqrt(so); i++)
            {
                if (so % i == 0) // Nếu chia hết cho bất kỳ số nào trong khoảng này
                    return false; // Không phải số nguyên tố
            }

            return true; // Nếu không chia hết cho số nào, đó là số nguyên tố
        }

        private void findBtn(object sender, EventArgs e)
        {
            int n = int.Parse(number_txt.Text);
            var primes = new List<int>();

            // Loop to find prime numbers
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                    primes.Add(i);
            }

            // Display the prime numbers in the TextBox as a comma-separated list
            list_txt.Text = string.Join(", ", primes);
        }

        private void nextBtn(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void exitBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
