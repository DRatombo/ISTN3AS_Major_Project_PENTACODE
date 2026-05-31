using Cafe101.dsCafe101TestTableAdapters;
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
            if (!txtEmail.Text.Contains("@cafe101.com"))
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
            this.testEmployeeTableAdapter1.Fill(this.dsCafe101Test1.TestEmployee);
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            bool isValid = false;

            // cashierTableAdapter1.Fill(dsLogin1.Cashier);
          
            foreach (DataRow row in dsCafe101Test1.TestEmployee.Rows)
            {
                if (row["Email"].ToString() == Email && Email.Contains("@cafe101.com") && row["Password"].ToString() == Password && Password.Length == 8)
                {
                    isValid = true;
                    SessionManager.FirstName = row["FirstName"].ToString();
                    SessionManager.Surname = row["Surname"].ToString();
                    SessionManager.Role = row["Role"].ToString();
                    SessionManager.Email = row["Email"].ToString();
                    SessionManager.LoginTime = DateTime.Now;
                }
            }
            if (isValid)
            {
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtHelp.Show(); 
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtHelp.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtHelp.Hide();
        }

        private void pBLogin_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pBHelp_Click(object sender, EventArgs e)
        {

        }

        private void lblEmailMsg_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtHelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Are you sure you want to exit?",
        "Exit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
