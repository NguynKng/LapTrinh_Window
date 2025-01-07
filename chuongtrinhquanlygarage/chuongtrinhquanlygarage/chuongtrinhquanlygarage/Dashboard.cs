using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage.Models;

namespace chuongtrinhquanlygarage
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void LoadUserData()
        {
            if (UserSession.CurrentUser != null)
            {
                // Example of loading specific data based on role
                if (UserSession.HasRole("Thu Ngân"))
                {
                    btnPart.Enabled = false;
                    btnReport.Enabled = false;
                    btnEmployee.Enabled = false;
                }
                else
                {
                    btnPart.Enabled = true;
                    btnReport.Enabled = true;
                    btnPart.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("User session not found. Please log in again.");
                this.Close();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadUserData();
            uC_AddCustomer1.Visible = false;
            uC_Vehicle1.Visible = false;
            uC_Part1.Visible = false;
            uC_Employee1.Visible = false;
            btnAddCustomer.PerformClick();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnAddCustomer.Left + 85;
            uC_AddCustomer1.Visible = true;
            uC_AddCustomer1.BringToFront();
        }


        private void btnVehicle_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnVehicle.Left + 87;
            uC_Vehicle1.Visible = true;
            uC_Vehicle1.BringToFront();
        }

        private void btnPart_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnPart.Left + 87;
            uC_Part1.Visible = true;
            uC_Part1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnEmployee.Left + 87;
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnReport.Left + 87;
            uC_Report1.Visible = true;
            uC_Report1.BringToFront();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnInvoice.Left + 87;
            uC_Pay1.Visible = true;
            uC_Pay1.BringToFront();
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            // Confirm logout action
            // Access current user data

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserSession.Clear();
                formLogin loginForm = new formLogin();
                loginForm.Show();

                this.Close();
            }
        }
    }
}
