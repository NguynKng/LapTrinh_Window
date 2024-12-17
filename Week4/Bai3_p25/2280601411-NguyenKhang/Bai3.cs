using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2280601411_NguyenKhang
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addSV addSV = new addSV(this);
            addSV.Show();
        }

        public void AddDataToDataGridView(string mssv, string name, string faculty, string grade)
        {
            // Check if MSSV already exists in the DataGridView
            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == mssv)
                {
                    // Show a message box if MSSV exists
                    MessageBox.Show("MSSV already exists. Please enter a different MSSV.", "Duplicate MSSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method without adding the data
                }
            }
            // Add the data to the DataGridView
            int rowIndex = dgvSV.Rows.Add();
            dgvSV.Rows[rowIndex].Cells[0].Value = rowIndex + 1;  // Index column
            dgvSV.Rows[rowIndex].Cells[1].Value = mssv;           // MSSV column
            dgvSV.Rows[rowIndex].Cells[2].Value = name;           // Name column
            dgvSV.Rows[rowIndex].Cells[3].Value = faculty;        // Faculty column
            dgvSV.Rows[rowIndex].Cells[4].Value = grade;          // Grade column
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower(); // Get the search query and make it lowercase for case-insensitive search

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                // Skip the row if it is a new row (empty row at the end of the DataGridView)
                if (row.IsNewRow)
                    continue;

                bool rowMatches = false;

                // Loop through all the columns in the row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check if the cell's value is not null and contains the search query
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(search))
                    {
                        rowMatches = true;
                        break; // If any cell matches, we can stop searching this row
                    }
                }

                // Show or hide the row based on whether it matches the search
                row.Visible = rowMatches;
            }
        }
    }
}
