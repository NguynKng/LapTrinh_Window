using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        private int rows = 4;
        private int cols = 5;
        private int[,] seatMatrix;
        private int total = 0;

        public Form1()
        {
            InitializeComponent();
            seatMatrix = new int[rows, cols];
            InitializeMatrix();
            textBox1.Text = "0";
        }

        private void InitializeMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    seatMatrix[i, j] = 0; // Set all seats as available
                }
            }
        }

        private void seatBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Retrieve the matrix position from the Tag
                string tagValue = clickedButton.Tag.ToString(); // e.g., "0,0"
                string[] position = tagValue.Split(','); // Split into row and column
                int row = int.Parse(position[0]);
                int col = int.Parse(position[1]);

                // Handle seat state based on BackColor and matrix value
                if (seatMatrix[row, col] == 0) // Unoccupied (White)
                {
                    updateBill(row);
                    seatMatrix[row, col] = 1; // Mark as selected
                    clickedButton.BackColor = Color.Green; // Change to Green
                }
                else if (seatMatrix[row, col] == 1) // Selected (Green)
                {
                    substractBill(row);
                    seatMatrix[row, col] = 0; // Mark as unoccupied
                    clickedButton.BackColor = Color.White; // Change to White
                }
                else if (seatMatrix[row, col] == 2) // Unavailable (Red)
                {
                    MessageBox.Show("This seat is unavailable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    // Find selected seats (green) and mark them as unavailable (red)
                    if (seatMatrix[row, col] == 1)
                    {
                        seatMatrix[row, col] = 2; // Mark seat as unavailable
                        string buttonName = $"seat{row}_{col}";
                        Button seatButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                        if (seatButton != null)
                        {
                            seatButton.BackColor = Color.Red; // Change the color to red
                        }
                    }
                }
            }
            resetBill();
            // Optionally, you can display a message saying the seats have been chosen
            MessageBox.Show("Seats have been chosen and are now unavailable.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    // Find selected seats (green) and mark them as unavailable (red)
                    if (seatMatrix[row, col] == 1)
                    {
                        seatMatrix[row, col] = 0; // Mark seat as unavailable
                        string buttonName = $"seat{row}_{col}";
                        Button seatButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                        if (seatButton != null)
                        {
                            seatButton.BackColor = Color.White; // Change the color to red
                        }
                    }
                }
            }
            resetBill();
            // Optionally, you can display a message saying the seats have been chosen
            MessageBox.Show("Seats have been canceled and are now available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateBill(int row)
        {
            if (row == 0)
                total += 30000;
            else if (row == 1)
                total += 40000;
            else if (row == 2)
                total += 50000;
            else
                total += 80000;
            textBox1.Text = total.ToString();
        }

        private void substractBill(int row)
        {
            if (row == 0)
                total -= 30000;
            else if (row == 1)
                total -= 40000;
            else if (row == 2)
                total -= 50000;
            else
                total -= 80000;
            textBox1.Text = total.ToString();
        }

        private void resetBill()
        {
            total = 0;
            textBox1.Text = "0";
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
