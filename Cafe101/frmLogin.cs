using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Red;
                lblEmailMsg.Text = "Required";
                return false;
            }
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                txtEmail.BackColor = Color.Red;
                lblEmailMsg.Text = "Invalid email";
                return false;
            }
            txtEmail.BackColor = Color.Green;
            lblEmailMsg.Text = "";
            return true;
        }
        private bool ValidatePassword()
        {
            string pwd = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.BackColor = Color.Red;
                return false;
            } else
            {
                txtPassword.BackColor = Color.Green;
               
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            bool isValid = false;
            cashierTableAdapter1.Fill(dsLogin1.Cashier);
            foreach (DataRow row in dsLogin1.Cashier.Rows)
            {
                if (row["Email"].ToString() == Email && row["Password"].ToString() == Password)
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                MessageBox.Show("Login successful!");
                frmMain mainMenu = new frmMain();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
                txtEmail.Clear();
                txtPassword.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }
    }
}
