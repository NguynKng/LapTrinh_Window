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

            UserRepository userRepository = new UserRepository(new DatabaseContext());
            User user = await Task.Run(() => userRepository.getUserByUsername(username));

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    UserSession.SetUser(user);
                    labelError.Visible = false;

                    Dashboard dash = new Dashboard();
                    this.Hide();
                    dash.Show();
                }
                else
                {
                    labelError.Visible = true;
                    txtPassword.Clear();
                }
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }
    }
}
