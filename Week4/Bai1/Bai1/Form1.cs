using System;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void subtractBtn_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void divideBtn_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        // Method to perform the operation
        private void PerformOperation(string operation)
        {
            // Get the values from the textboxes and try to parse them to numbers
            if (double.TryParse(textBox1.Text, out double number1) && double.TryParse(textBox2.Text, out double number2))
            {
                double result = 0;

                // Perform the operation based on the button clicked
                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
                    case "*":
                        result = number1 * number2;
                        break;
                    case "/":
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    default:
                        return;
                }

                // Display the result in textBox3
                textBox3.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers in both input fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
