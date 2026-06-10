using Cafe101.dsCafe101HubTableAdapters;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmAddCustomer : Form
    {
        private bool helpVisible = false;
        private Panel pnlHelp;

        public frmAddCustomer()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(13, 27, 110);
            txtPassword.PasswordChar = '*'; 
            ResetForm();
            ApplyStyles();

            LoadCustomers();

            // Fill the groupbox fully and style the grid
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.GridColor = Color.LightGray;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 27, 110);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dgvCustomers.DefaultCellStyle.BackColor = Color.White;
            dgvCustomers.DefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 20);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 27, 110);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 240, 255);
            dgvCustomers.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 20);

            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.White;

            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;

            btnShowPwd.Location = new Point(txtPassword.Right + 6, txtPassword.Top);
            btnShowPwd.Size = new Size(55, txtPassword.Height);
        }

        private void LoadCustomers()
        {
            dgvCustomers.DataSource = customerTableTableAdapter1.GetData();
            dgvCustomers.Columns[5].Visible = false; // Hide password column
        }

        // ---------------------------------------------------------------
        // STYLES — run once on load
        // ---------------------------------------------------------------
        private void ApplyStyles()
        {
            // Form background
            this.BackColor = Color.FromArgb(13, 27, 110);

            // All labels — white text, transparent bg
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.White;
                }
            }

            // Field labels — slightly muted
            Color fieldLabelColor = Color.FromArgb(190, 210, 255);
            lblFirstName.ForeColor = fieldLabelColor;
            lblSurname.ForeColor = fieldLabelColor;
            lblPhoneNum.ForeColor = fieldLabelColor;
            lblEmail.ForeColor = fieldLabelColor;
            lblAddress.ForeColor = fieldLabelColor;
            lblPassword.ForeColor = fieldLabelColor;

            // Title
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Inputs
            Color inputBg = Color.White;
            Color inputFg = Color.FromArgb(20, 20, 20);
            Font inputFont = new Font("Segoe UI", 11);

            foreach (var txt in new Control[] {
                txtFirstName, txtSurname, txtPhoneNumber,
                txtCustEmail, txtAddress, txtPassword })
            {
                txt.BackColor = inputBg;
                txt.ForeColor = inputFg;
                txt.Font = inputFont;
            }

            // Msg labels
            Font msgFont = new Font("Segoe UI", 9);
            foreach (var lbl in new[] {
                lblNameMes, lblSurMes, lblPhonMes,
                lblEmailMes, lblAddressMes, lblPassMes })
            {
                lbl.Font = msgFont;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.White;
            }

            // Save button — white pill
            btnSaveCust.FlatStyle = FlatStyle.Flat;
            btnSaveCust.FlatAppearance.BorderSize = 0;
            btnSaveCust.BackColor = Color.White;
            btnSaveCust.ForeColor = Color.FromArgb(13, 27, 110);
            btnSaveCust.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSaveCust.Cursor = Cursors.Hand;

            // Other buttons — ghost style
            foreach (var btn in new[] { btnCanel, btnHome, btnHelp })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(120, 255, 255, 255);
                btn.FlatAppearance.BorderSize = 1;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10);
                btn.Cursor = Cursors.Hand;
            }

            // Password visibility button
            btnShowPwd.FlatStyle = FlatStyle.Flat;
            btnShowPwd.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            btnShowPwd.FlatAppearance.BorderSize = 1;
            btnShowPwd.BackColor = Color.White;
            btnShowPwd.ForeColor = Color.FromArgb(13, 27, 110);
            btnShowPwd.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnShowPwd.Text = "Show";
            btnShowPwd.Cursor = Cursors.Hand;
        }

        // ---------------------------------------------------------------
        // VALIDATION
        // ---------------------------------------------------------------
        private bool ValidateFirstName()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblNameMes.Text = "⚠ Required";
                lblNameMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtFirstName.Text.All(char.IsLetter))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblNameMes.Text = "⚠ Letters only";
                lblNameMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtFirstName.BackColor = Color.FromArgb(220, 245, 220);
            lblNameMes.Text = "✓";
            lblNameMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurMes.Text = "⚠ Required";
                lblSurMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtSurname.Text.All(char.IsLetter))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurMes.Text = "⚠ Letters only";
                lblSurMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtSurname.BackColor = Color.FromArgb(220, 245, 220);
            lblSurMes.Text = "✓";
            lblSurMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.FromArgb(255, 220, 220);
                lblPhonMes.Text = "⚠ Required";
                lblPhonMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (!txtPhoneNumber.Text.All(char.IsDigit) ||
                txtPhoneNumber.Text.Length != 10)
            {
                txtPhoneNumber.BackColor = Color.FromArgb(255, 220, 220);
                lblPhonMes.Text = "⚠ Must be exactly 10 digits";
                lblPhonMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtPhoneNumber.BackColor = Color.FromArgb(220, 245, 220);
            lblPhonMes.Text = "✓";
            lblPhonMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtCustEmail.Text))
            {
                txtCustEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailMes.Text = "⚠ Required";
                lblEmailMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtCustEmail.Text.Contains("@") || !txtCustEmail.Text.Contains("."))
            {
                txtCustEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailMes.Text = "⚠ Must contain @ and a dot";
                lblEmailMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtCustEmail.BackColor = Color.FromArgb(220, 245, 220);
            lblEmailMes.Text = "✓";
            lblEmailMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = Color.FromArgb(255, 220, 220);
                lblAddressMes.Text = "⚠ Required";
                lblAddressMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtAddress.BackColor = Color.FromArgb(220, 245, 220);
            lblAddressMes.Text = "✓";
            lblAddressMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePassword()
        {
            string pwd = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPassMes.Text = "⚠ Required";
                lblPassMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (pwd.Length < 8)
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPassMes.Text = "⚠ Minimum 8 characters";
                lblPassMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!pwd.Any(char.IsUpper))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPassMes.Text = "⚠ Need 1 uppercase letter";
                lblPassMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!pwd.Any(char.IsDigit))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPassMes.Text = "⚠ Need at least 1 number";
                lblPassMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtPassword.BackColor = Color.FromArgb(220, 245, 220);
            lblPassMes.Text = "✓";
            lblPassMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        // ---------------------------------------------------------------
        // LIVE VALIDATION
        // ---------------------------------------------------------------
        private void txtFirstName_TextChanged(object sender, EventArgs e) { ValidateFirstName(); }
        private void txtSurname_TextChanged(object sender, EventArgs e) { ValidateSurname(); }
        private void txtPhoneNumber_TextChanged(object sender, EventArgs e) { ValidatePhone(); }
        private void txtCustEmail_TextChanged(object sender, EventArgs e) { ValidateEmail(); }
        private void txtAddress_TextChanged(object sender, EventArgs e) { ValidateAddress(); }
        private void txtPassword_TextChanged(object sender, EventArgs e) { ValidatePassword(); }

        // ---------------------------------------------------------------
        // SAVE
        // ---------------------------------------------------------------
        private void btnSaveCust_Click(object sender, EventArgs e)
        {
            bool valid = ValidateFirstName() & ValidateSurname() &
                         ValidatePhone() & ValidateEmail() &
                         ValidateAddress() & ValidatePassword();

            if (!valid)
            {
                MessageBox.Show("Please fix the errors above before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                customerTableTableAdapter1.InsertCust(
                    txtFirstName.Text.Trim(),
                    txtSurname.Text.Trim(),
                    txtPhoneNumber.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtCustEmail.Text.Trim(),
                    txtPassword.Text.Trim()
                );
                
                MessageBox.Show(
                    "Customer " + txtFirstName.Text.Trim() + " " + txtSurname.Text.Trim() + " added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ResetForm();
                LoadCustomers(); // refresh grid AFTER reset so new customer appears
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer: " + ex.Message,
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // ---------------------------------------------------------------
        // CANCEL
        // ---------------------------------------------------------------
        private void btnCanel_Click(object sender, EventArgs e)
        {
            frmNewOrder newOrder = new frmNewOrder();
            newOrder.Show();
            this.Close();
        }
        // ---------------------------------------------------------------
        // HOME
        // ---------------------------------------------------------------
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        // ---------------------------------------------------------------
        // HELP
        // ---------------------------------------------------------------
        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "Help";
                return;
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new Size(280, 300);
                pnlHelp.BackColor = Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;

                var lblHelpTitle = new Label();
                lblHelpTitle.Text = "How to add a customer";
                lblHelpTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblHelpTitle.ForeColor = Color.White;
                lblHelpTitle.Location = new Point(12, 12);
                lblHelpTitle.Size = new Size(256, 20);

                var lblSteps = new Label();
                lblSteps.Text =
                    "1. First name & surname\r\n" +
                    "   Letters only.\r\n\r\n" +
                    "2. Phone number\r\n" +
                    "   Exactly 10 digits.\r\n\r\n" +
                    "3. Email\r\n" +
                    "   Must have @ and a dot.\r\n\r\n" +
                    "4. Address\r\n" +
                    "   Full street address.\r\n\r\n" +
                    "5. Password\r\n" +
                    "   Min 8 chars, 1 uppercase,\r\n" +
                    "   1 number.\r\n\r\n" +
                    "All fields must show ✓ to save.";
                lblSteps.Font = new Font("Segoe UI", 9);
                lblSteps.ForeColor = Color.FromArgb(200, 220, 255);
                lblSteps.Location = new Point(12, 40);
                lblSteps.Size = new Size(256, 220);

                var btnClose = new Button();
                btnClose.Text = "Close";
                btnClose.Size = new Size(80, 28);
                btnClose.Location = new Point(188, 264);
                btnClose.BackColor = Color.FromArgb(0, 120, 215);
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) =>
                {
                    pnlHelp.Visible = false;
                    helpVisible = false;
                    btnHelp.Text = "Help";
                };

                pnlHelp.Controls.Add(lblHelpTitle);
                pnlHelp.Controls.Add(lblSteps);
                pnlHelp.Controls.Add(btnClose);
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            pnlHelp.Location = new Point(
                btnHelp.Left,
                btnHelp.Top - pnlHelp.Height - 5);

            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "Help (ON)";
        }

        // ---------------------------------------------------------------
        // RESET
        // ---------------------------------------------------------------
        private void ResetForm()
        {
            txtFirstName.Clear(); txtSurname.Clear();
            txtPhoneNumber.Clear(); txtCustEmail.Clear();
            txtAddress.Clear(); txtPassword.Clear();

            foreach (var txt in new Control[] {
                txtFirstName, txtSurname, txtPhoneNumber,
                txtCustEmail, txtAddress, txtPassword })
                txt.BackColor = Color.White;

            foreach (var lbl in new[] {
                lblNameMes, lblSurMes, lblPhonMes,
                lblEmailMes, lblAddressMes, lblPassMes })
                lbl.Text = "";
        }

        //  PICTURE BOX — go home

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void lblAddress_Click(object sender, EventArgs e) { }

        private void btnShowPwd_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                btnShowPwd.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowPwd.Text = "Show";
            }
        }
    }
}