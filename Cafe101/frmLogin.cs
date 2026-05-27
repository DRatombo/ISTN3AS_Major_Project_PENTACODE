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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            bool isValid = false;
            cashierTableAdapter1.Fill(dsLogin1.Cashier);
            foreach (DataRow row in dsLogin1.Cashier.Rows)
            {
                if (row["Email"].ToString() == Username && row["Password"].ToString() == Password)
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
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}
