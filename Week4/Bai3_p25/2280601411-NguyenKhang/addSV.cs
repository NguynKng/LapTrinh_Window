using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2280601411_NguyenKhang
{
    public partial class addSV : Form
    {
        private Bai3 mainForm; // Reference to the main form
        public addSV(Bai3 parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes in child form
            string mssv = txtMSSV.Text.Trim();
            string name = txtName.Text.Trim();
            string faculty = txtFaculty.Text.Trim();
            string grade = txtGrade.Text.Trim();

            // Validate input (optional)
            if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(faculty) || string.IsNullOrEmpty(grade))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pass the data to the main form to add it to the DataGridView
            mainForm.AddDataToDataGridView(mssv, name, faculty, grade);

            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
