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
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Validation
        private bool ValidateFirstName()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.Red;
                lblFirstNameMsg.Text = "Required";
                return false;
            }
            if (!txtFirstName.Text.All(char.IsLetter))
            {
                txtFirstName.BackColor = Color.Red;
                lblFirstNameMsg.Text = "Letters only";
                return false;
            }
            txtFirstName.BackColor = Color.Green;
            lblFirstNameMsg.Text = "";
            return true;
        }

        private bool ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.BackColor = Color.Red;
                lblSurnameMsg.Text = "Required";
                return false;
            }
            if (!txtSurname.Text.All(char.IsLetter))
            {
                txtSurname.BackColor = Color.Red;
                lblSurnameMsg.Text = "Letters only";
                return false;
            }
            txtSurname.BackColor = Color.Green;
            lblSurnameMsg.Text = "";
            return true;
        }

        private bool ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNum.Text))
            {
                txtPhoneNum.BackColor = Color.Red;
                lblPhoneMsg.Text = "Required";
                return false;
            }
            if (!txtPhoneNum.Text.All(char.IsDigit) || txtPhoneNum.Text.Length != 10)
            {
                txtPhoneNum.BackColor = Color.Red;
                lblPhoneMsg.Text = "Must be 10 digits";
                return false;
            }
            txtPhoneNum.BackColor = Color.Green;
            lblPhoneMsg.Text = "";
            return true;
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

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = Color.Red;
                lblAddressMsg.Text = "Required";
                return false;
            }
            txtAddress.BackColor = Color.Green;
            lblAddressMsg.Text = "";
            return true;
        }

        private bool ValidatePassword()
        {
            string pwd = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.BackColor = Color.Red;
                lblPasswordMsg.Text = "Required";
                return false;
            }
            if (pwd.Length < 8)
            {
                txtPassword.BackColor = Color.Red;
                lblPasswordMsg.Text = "Min 8 characters";
                return false;
            }
            if (!pwd.Any(char.IsUpper))
            {
                txtPassword.BackColor = Color.Red;
                lblPasswordMsg.Text = "Need uppercase";
                return false;
            }
            if (!pwd.Any(char.IsDigit))
            {
                txtPassword.BackColor = Color.Red;
                lblPasswordMsg.Text = "Need a number";
                return false;
            }
            txtPassword.BackColor = Color.Green;
            lblPasswordMsg.Text = "";
            return true;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidateFirstName();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            ValidateSurname();
        }

        private void txtPhoneNum_TextChanged(object sender, EventArgs e)
        {
            ValidatePhone();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateAddress();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            frmNewOrder orders = new frmNewOrder();
            orders.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnSaveCust_Click(object sender, EventArgs e)
        {
            //save information to database here


            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }
    }
}
