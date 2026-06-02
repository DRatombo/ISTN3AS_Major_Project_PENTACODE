using Cafe101.dsCafe101TestTableAdapters;
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
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ResetForm();
            CentreControls();
        }

        private void frmAddCustomer_Resize(object sender, EventArgs e)
        {
            CentreControls();
        }

        private void CentreControls()
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;

            int inputWidth = Math.Max(300, formW / 5);
            int labelWidth = Math.Max(120, formW / 10);
            int totalWidth = labelWidth + 10 + inputWidth + 80;
            int startX = (formW - totalWidth) / 2;
            int labelX = startX;
            int inputX = startX + labelWidth + 10;
            int msgX = inputX + inputWidth + 5;

            int rowHeight = Math.Max(42, formH / 14);
            int controlHeight = Math.Max(32, rowHeight - 12);
            int startY = 10;

            float fontSize = Math.Max(10, Math.Min(16, formW / 90f));
            Font fieldFont = new Font("Segoe UI", fontSize);
            Font labelFont = new Font("Segoe UI", fontSize, FontStyle.Bold);
            Font btnFont = new Font("Segoe UI", fontSize, FontStyle.Bold);

            // Logo
            int logoSize = Math.Max(100, formH / 8);
            pictureBox1.Size = new Size(logoSize, logoSize);
            pictureBox1.Location = new Point(formW / 2 - logoSize / 2, startY);

            // Title
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.AutoSize = false;
            lblTitle.Width = formW;
            lblTitle.Height = 30;
            lblTitle.Location = new Point(0, startY + logoSize + 10);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            int y = startY + logoSize + 55;

            // First Name
            lblFirstName.Font = labelFont;
            lblFirstName.AutoSize = false;
            lblFirstName.Size = new Size(labelWidth, controlHeight);
            lblFirstName.Location = new Point(labelX, y + 3);
            txtFirstName.Font = fieldFont;
            txtFirstName.Location = new Point(inputX, y);
            txtFirstName.Size = new Size(inputWidth, controlHeight);
            lblFirstNameMsg.AutoSize = false;
            lblFirstNameMsg.Size = new Size(180, controlHeight);
            lblFirstNameMsg.Font = fieldFont;
            lblFirstNameMsg.Location = new Point(msgX, y + 3);
            y += rowHeight;

            // Surname
            lblSurname.Font = labelFont;
            lblSurname.AutoSize = false;
            lblSurname.Size = new Size(labelWidth, controlHeight);
            lblSurname.Location = new Point(labelX, y + 3);
            txtSurname.Font = fieldFont;
            txtSurname.Location = new Point(inputX, y);
            txtSurname.Size = new Size(inputWidth, controlHeight);
            lblSurnameMsg.AutoSize = false;
            lblSurnameMsg.Size = new Size(180, controlHeight);
            lblSurnameMsg.Font = fieldFont;
            lblSurnameMsg.Location = new Point(msgX, y + 3);
            y += rowHeight;

            // Phone
            lblPhoneNum.Font = labelFont;
            lblPhoneNum.AutoSize = false;
            lblPhoneNum.Size = new Size(labelWidth, controlHeight);
            lblPhoneNum.Location = new Point(labelX, y + 3);
            txtPhoneNum.Font = fieldFont;
            txtPhoneNum.Location = new Point(inputX, y);
            txtPhoneNum.Size = new Size(inputWidth, controlHeight);
            lblPhoneMsg.AutoSize = false;
            lblPhoneMsg.Size = new Size(180, controlHeight);
            lblPhoneMsg.Font = fieldFont;
            lblPhoneMsg.Location = new Point(msgX, y + 3);
            y += rowHeight;

            // Email
            lblEmail.Font = labelFont;
            lblEmail.AutoSize = false;
            lblEmail.Size = new Size(labelWidth, controlHeight);
            lblEmail.Location = new Point(labelX, y + 3);
            txtEmail.Font = fieldFont;
            txtEmail.Location = new Point(inputX, y);
            txtEmail.Size = new Size(inputWidth, controlHeight);
            lblEmailMsg.AutoSize = false;
            lblEmailMsg.Size = new Size(180, controlHeight);
            lblEmailMsg.Font = fieldFont;
            lblEmailMsg.Location = new Point(msgX, y + 3);
            y += rowHeight;

            // Address
            lblAddress.Font = labelFont;
            lblAddress.AutoSize = false;
            lblAddress.Size = new Size(labelWidth, controlHeight);
            lblAddress.Location = new Point(labelX, y + 3);
            txtAddress.Font = fieldFont;
            txtAddress.Location = new Point(inputX, y);
            txtAddress.Size = new Size(inputWidth, controlHeight * 2);
            lblAddressMsg.AutoSize = false;
            lblAddressMsg.Size = new Size(180, controlHeight);
            lblAddressMsg.Font = fieldFont;
            lblAddressMsg.Location = new Point(msgX, y + 3);
            y += rowHeight + controlHeight * 2;

            // Password
            lblPassword.Font = labelFont;
            lblPassword.AutoSize = false;
            lblPassword.Size = new Size(labelWidth, controlHeight);
            lblPassword.Location = new Point(labelX, y + 3);
            txtPassword.Font = fieldFont;
            txtPassword.Location = new Point(inputX, y);
            txtPassword.Size = new Size(inputWidth, controlHeight);
            lblPasswordMsg.AutoSize = false;
            lblPasswordMsg.Size = new Size(180, controlHeight);
            lblPasswordMsg.Font = fieldFont;
            lblPasswordMsg.Location = new Point(msgX, y + 3);
            y += rowHeight + 15;

            // Buttons — centred as pairs
            int btnWidth = Math.Max(140, formW / 9);
            int btnHeight = Math.Max(36, controlHeight + 6);
            int btnGap = 10;
            int btnStartX = formW / 2 - btnWidth - btnGap / 2;

            btnSaveCust.Font = btnFont;
            btnSaveCust.Size = new Size(btnWidth, btnHeight);
            btnSaveCust.Location = new Point(btnStartX, y);

            btnCanel.Font = btnFont;
            btnCanel.Size = new Size(btnWidth, btnHeight);
            btnCanel.Location = new Point(btnStartX + btnWidth + btnGap, y);
            y += btnHeight + 8;

            btnHome.Font = btnFont;
            btnHome.Size = new Size(btnWidth, btnHeight);
            btnHome.Location = new Point(btnStartX, y);

            btnHelp.Font = btnFont;
            btnHelp.Size = new Size(btnWidth, btnHeight);
            btnHelp.Location = new Point(btnStartX + btnWidth + btnGap, y);
        }
        // ---------------------------------------------------------------
        // VALIDATION
        // ---------------------------------------------------------------
        private bool ValidateFirstName()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.FromArgb(180, 30, 30);
                lblFirstNameMsg.Text = "First name is required";
                lblFirstNameMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!txtFirstName.Text.All(char.IsLetter))
            {
                txtFirstName.BackColor = Color.FromArgb(180, 30, 30);
                lblFirstNameMsg.Text = "Letters only, no numbers";
                lblFirstNameMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtFirstName.BackColor = Color.FromArgb(30, 130, 80);
            lblFirstNameMsg.Text = "✓";
            lblFirstNameMsg.ForeColor = Color.LightGreen;
            return true;
        }

        private bool ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.BackColor = Color.FromArgb(180, 30, 30);
                lblSurnameMsg.Text = "⚠ Surname is required";
                lblSurnameMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!txtSurname.Text.All(char.IsLetter))
            {
                txtSurname.BackColor = Color.FromArgb(180, 30, 30);
                lblSurnameMsg.Text = "⚠ Letters only, no numbers";
                lblSurnameMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtSurname.BackColor = Color.FromArgb(30, 130, 80);
            lblSurnameMsg.Text = "✓";
            lblSurnameMsg.ForeColor = Color.LightGreen;
            return true;
        }

        private bool ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNum.Text))
            {
                txtPhoneNum.BackColor = Color.FromArgb(180, 30, 30);
                lblPhoneMsg.Text = "⚠ Phone number is required";
                lblPhoneMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!txtPhoneNum.Text.All(char.IsDigit) || txtPhoneNum.Text.Length != 10)
            {
                txtPhoneNum.BackColor = Color.FromArgb(180, 30, 30);
                lblPhoneMsg.Text = "⚠ Must be exatly 10 digits";
                lblPhoneMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtPhoneNum.BackColor = Color.FromArgb(30, 130, 80);
            lblPhoneMsg.Text = "✓";
            lblPhoneMsg.ForeColor = Color.LightGreen;
            return true;
        }

        private bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.BackColor = Color.FromArgb(180, 30, 30);
                lblEmailMsg.Text = "⚠ Email is Required";
                lblEmailMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                txtEmail.BackColor = Color.FromArgb(180, 30, 30);
                lblEmailMsg.Text = "⚠ Invalid email - must contain @ and a dot";
                lblEmailMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtEmail.BackColor = Color.FromArgb(30, 130, 80);
            lblEmailMsg.Text = "✓";
            lblEmailMsg.ForeColor = Color.LightGreen;
            return true;
        }

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = Color.FromArgb(180, 30, 30);
                lblAddressMsg.Text = "⚠ Address is Required";
                lblAddressMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtAddress.BackColor = Color.FromArgb(30, 130, 80);
            lblAddressMsg.Text = "✓";
            lblAddressMsg.ForeColor = Color.LightGreen;
            return true;
        }

        private bool ValidatePassword()
        {
            string pwd = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.BackColor = Color.FromArgb(180, 30, 30);
                lblPasswordMsg.Text = "⚠ Password is Required";
                lblPasswordMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (pwd.Length < 8)
            {
                txtPassword.BackColor = Color.FromArgb(180, 30, 30);
                lblPasswordMsg.Text = "⚠ Minimum 8 characters";
                lblPasswordMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!pwd.Any(char.IsUpper))
            {
                txtPassword.BackColor = Color.FromArgb(180, 30, 30);
                lblPasswordMsg.Text = "⚠ Need 1 uppercase letter";
                lblPasswordMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            if (!pwd.Any(char.IsDigit))
            {
                txtPassword.BackColor = Color.FromArgb(180, 30, 30);
                lblPasswordMsg.Text = "⚠ Need atleast 1 number";
                lblPasswordMsg.ForeColor = Color.OrangeRed;
                return false;
            }
            txtPassword.BackColor = Color.FromArgb(30, 130, 80);
            lblPasswordMsg.Text = "✓";
            lblPasswordMsg.ForeColor = Color.LightGreen;
            return true;
        }

        // ---------------------------------------------------------------
        // LIVE VALIDATION ON TEXT CHANGE
        // ---------------------------------------------------------------
        private void txtFirstName_TextChanged(object sender, EventArgs e) { ValidateFirstName(); }
        private void txtSurname_TextChanged(object sender, EventArgs e) { ValidateSurname(); }
        private void txtPhoneNum_TextChanged(object sender, EventArgs e) { ValidatePhone(); }
        private void txtEmail_TextChanged(object sender, EventArgs e) { ValidateEmail(); }
        private void txtAddress_TextChanged(object sender, EventArgs e) { ValidateAddress(); }
        private void txtPassword_TextChanged(object sender, EventArgs e) { ValidatePassword(); }

        // ---------------------------------------------------------------
        // SAVE CUSTOMER
        // ---------------------------------------------------------------
        private void btnSaveCust_Click(object sender, EventArgs e)
        {
            // Run all validations first
            bool valid = ValidateFirstName() & ValidateSurname() &
                         ValidatePhone() & ValidateEmail() &
                         ValidateAddress() & ValidatePassword();

            if (!valid)
            {
                MessageBox.Show("Please fix the errors above before saving.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Save to DB using your customer table adapter
                // *** Make sure your InsertQuery is set up in the Dataset Designer ***
                testCustomerTableAdapter1.Insert(
                    txtFirstName.Text.Trim(),
                    txtSurname.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim());

                MessageBox.Show(
                    "✅ Customer " + txtFirstName.Text + " " + txtSurname.Text + " added successfully!",
                    "Customer Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close(); // Return to New Order screen
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer: " + ex.Message,
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        // CANCEL – just close and go back to New Order
        // ---------------------------------------------------------------
        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ---------------------------------------------------------------
        // HOME
        // ---------------------------------------------------------------
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        // ---------------------------------------------------------------
        // HELP BUTTON
        // ---------------------------------------------------------------

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
                return;
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new Size(300, 320);
                pnlHelp.BackColor = Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;

                Label lblTitle = new Label();
                lblTitle.Text = "📋 How To Add A Customer";
                lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTitle.ForeColor = Color.White;
                lblTitle.Location = new Point(10, 10);
                lblTitle.Size = new Size(280, 22);

                Label lblSteps = new Label();
                lblSteps.Text =
                    "1. FIRST NAME & SURNAME\r\n" +
                    "   Letters only, no numbers.\r\n\r\n" +
                    "2. PHONE NUMBER\r\n" +
                    "   Must be exactly 10 digits.\r\n\r\n" +
                    "3. EMAIL\r\n" +
                    "   Must contain @ and a dot.\r\n\r\n" +
                    "4. ADDRESS\r\n" +
                    "   Full street address.\r\n\r\n" +
                    "5. PASSWORD\r\n" +
                    "   Min 8 chars, 1 uppercase,\r\n" +
                    "   1 number.\r\n\r\n" +
                    "6. SAVE CUSTOMER\r\n" +
                    "   All fields must show ✓\r\n" +
                    "   before saving.";
                lblSteps.Font = new Font("Segoe UI", 9);
                lblSteps.ForeColor = Color.LightGray;
                lblSteps.Location = new Point(10, 40);
                lblSteps.Size = new Size(280, 240);

                Button btnClose = new Button();
                btnClose.Text = "✕ Close Help";
                btnClose.Size = new Size(120, 28);
                btnClose.Location = new Point(165, 283);
                btnClose.BackColor = Color.FromArgb(0, 120, 215);
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.Click += (s, ev) =>
                {
                    pnlHelp.Visible = false;
                    helpVisible = false;
                    btnHelp.Text = "? Help";
                };

                pnlHelp.Controls.Add(lblTitle);
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
            btnHelp.Text = "? Help (ON)";
        }
        // ---------------------------------------------------------------
        // HELPER – Reset all fields
        // ---------------------------------------------------------------
        private void ResetForm()
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtPhoneNum.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPassword.Clear();

            Color defaultBg = Color.White;
            txtFirstName.BackColor = defaultBg;
            txtSurname.BackColor = defaultBg;
            txtPhoneNum.BackColor = defaultBg;
            txtEmail.BackColor = defaultBg;
            txtAddress.BackColor = defaultBg;
            txtPassword.BackColor = defaultBg;

            lblFirstNameMsg.Text = "";
            lblSurnameMsg.Text = "";
            lblPhoneMsg.Text = "";
            lblEmailMsg.Text = "";
            lblAddressMsg.Text = "";
            lblPasswordMsg.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }
    }
}