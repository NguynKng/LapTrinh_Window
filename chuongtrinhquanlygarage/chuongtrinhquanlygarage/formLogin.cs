using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chuongtrinhquanlygarage;
using chuongtrinhquanlygarage.Database.Repository;
using chuongtrinhquanlygarage.Models;
using chuongtrinhquanlygarage.Database;

namespace chuongtrinhquanlygarage
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();

            txtUsername.KeyDown += new KeyEventHandler(txtKeyDown);
            txtPassword.KeyDown += new KeyEventHandler(txtKeyDown);
        }

        private void txtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.SuppressKeyPress = true;
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


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Create an instance of the UserRepository
            UserRepository userRepository = new UserRepository(new DatabaseContext());
            User user = await Task.Run(() => userRepository.getUserByUsername(username));

            // Check if the user exists
            if (user != null)
            {
                // Compare the hashed password using bcrypt
                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) && user.HasRole("Admin"))
                {
                    labelError.Visible = false;

                    // Open the dashboard
                    Dashboard dash = new Dashboard();
                    this.Hide();
                    dash.Show();
                }
                else
                {
                    // Display error and clear the password field
                    labelError.Visible = true;
                    txtPassword.Clear();
                }
            }
            else
            {
                // Display error if the user does not exist
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }
    }
}
