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
            CentreControls();
        }

        private void frmAddCustomer_Resize(object sender, EventArgs e)
        {
            CentreControls();
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
                txtFirstName, txtSurname, txtPhoneNum,
                txtEmail, txtAddress, txtPassword })
            {
                txt.BackColor = inputBg;
                txt.ForeColor = inputFg;
                txt.Font = inputFont;
            }

            // Msg labels
            Font msgFont = new Font("Segoe UI", 9);
            foreach (var lbl in new[] {
                lblFirstNameMsg, lblSurnameMsg, lblPhoneMsg,
                lblEmailMsg, lblAddressMsg, lblPasswordMsg })
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

            // Eye button
            btnShowPwd.FlatStyle = FlatStyle.Flat;
            btnShowPwd.FlatAppearance.BorderSize = 0;
            btnShowPwd.BackColor = Color.Transparent;
            btnShowPwd.ForeColor = Color.FromArgb(100, 100, 100);
            btnShowPwd.Font = new Font("Segoe UI", 11);
            btnShowPwd.Cursor = Cursors.Hand;
            btnShowPwd.Text = "👁";
        }

        // ---------------------------------------------------------------
        // LAYOUT
        // ---------------------------------------------------------------
        private void CentreControls()
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;

            // Card dimensions — narrow centred column
            int cardW = Math.Min(520, (int)(formW * 0.45));
            int cardX = (formW - cardW) / 2;
            int inputH = 36;
            int halfW = (cardW - 12) / 2;
            int labelH = 20;
            int msgH = 16;
            int gap = 14;  // space between fields
            Font labelFont = new Font("Segoe UI", 9, FontStyle.Regular);

            // ── LOGO ──────────────────────────────────────────
            int logoSize = 80;
            pictureBox1.Size = new Size(logoSize, logoSize);
            pictureBox1.Location = new Point(formW / 2 - logoSize / 2, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // ── TITLE ─────────────────────────────────────────
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(cardW, 32);
            lblTitle.Location = new Point(cardX, 20 + logoSize + 10);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            int y = 20 + logoSize + 52;

            // ── FIRST NAME + SURNAME (side by side) ───────────
            lblFirstName.AutoSize = false;
            lblFirstName.Font = labelFont;
            lblFirstName.Size = new Size(halfW, labelH);
            lblFirstName.Location = new Point(cardX, y);

            lblSurname.AutoSize = false;
            lblSurname.Font = labelFont;
            lblSurname.Size = new Size(halfW, labelH);
            lblSurname.Location = new Point(cardX + halfW + 12, y);
            y += labelH + 4;

            txtFirstName.Size = new Size(halfW, inputH);
            txtFirstName.Location = new Point(cardX, y);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;

            txtSurname.Size = new Size(halfW, inputH);
            txtSurname.Location = new Point(cardX + halfW + 12, y);
            txtSurname.BorderStyle = BorderStyle.FixedSingle;
            y += inputH + 2;

            lblFirstNameMsg.AutoSize = false;
            lblFirstNameMsg.Size = new Size(halfW, msgH);
            lblFirstNameMsg.Location = new Point(cardX, y);

            lblSurnameMsg.AutoSize = false;
            lblSurnameMsg.Size = new Size(halfW, msgH);
            lblSurnameMsg.Location = new Point(cardX + halfW + 12, y);
            y += msgH + gap;

            // ── PHONE ─────────────────────────────────────────
            lblPhoneNum.AutoSize = false;
            lblPhoneNum.Font = labelFont;
            lblPhoneNum.Size = new Size(cardW, labelH);
            lblPhoneNum.Location = new Point(cardX, y);
            y += labelH + 4;

            txtPhoneNum.Size = new Size(cardW, inputH);
            txtPhoneNum.Location = new Point(cardX, y);
            txtPhoneNum.BorderStyle = BorderStyle.FixedSingle;
            y += inputH + 2;

            lblPhoneMsg.AutoSize = false;
            lblPhoneMsg.Size = new Size(cardW, msgH);
            lblPhoneMsg.Location = new Point(cardX, y);
            y += msgH + gap;

            // ── EMAIL ─────────────────────────────────────────
            lblEmail.AutoSize = false;
            lblEmail.Font = labelFont;
            lblEmail.Size = new Size(cardW, labelH);
            lblEmail.Location = new Point(cardX, y);
            y += labelH + 4;

            txtEmail.Size = new Size(cardW, inputH);
            txtEmail.Location = new Point(cardX, y);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            y += inputH + 2;

            lblEmailMsg.AutoSize = false;
            lblEmailMsg.Size = new Size(cardW, msgH);
            lblEmailMsg.Location = new Point(cardX, y);
            y += msgH + gap;

            // ── ADDRESS ───────────────────────────────────────
            lblAddress.AutoSize = false;
            lblAddress.Font = labelFont;
            lblAddress.Size = new Size(cardW, labelH);
            lblAddress.Location = new Point(cardX, y);
            y += labelH + 4;

            txtAddress.Size = new Size(cardW, inputH * 2);
            txtAddress.Location = new Point(cardX, y);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            y += inputH * 2 + 2;

            lblAddressMsg.AutoSize = false;
            lblAddressMsg.Size = new Size(cardW, msgH);
            lblAddressMsg.Location = new Point(cardX, y);
            y += msgH + gap;

            // ── PASSWORD ──────────────────────────────────────
            lblPassword.AutoSize = false;
            lblPassword.Font = labelFont;
            lblPassword.Size = new Size(cardW, labelH);
            lblPassword.Location = new Point(cardX, y);
            y += labelH + 4;

            txtPassword.Size = new Size(cardW, inputH);
            txtPassword.Location = new Point(cardX, y);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;

            // Eye button inside password field right edge
            btnShowPwd.Size = new Size(inputH, inputH);
            btnShowPwd.Location = new Point(cardX + cardW - inputH, y);
            btnShowPwd.BringToFront();
            y += inputH + 2;

            lblPasswordMsg.AutoSize = false;
            lblPasswordMsg.Size = new Size(cardW, msgH);
            lblPasswordMsg.Location = new Point(cardX, y);
            y += msgH + 28;

            // ── BUTTONS ───────────────────────────────────────
            int btnH = 38;
            int btnW = (cardW - 12) / 2;
            int btnGap = 12;

            btnSaveCust.Size = new Size(btnW, btnH);
            btnSaveCust.Location = new Point(cardX, y);

            btnCanel.Size = new Size(btnW, btnH);
            btnCanel.Location = new Point(cardX + btnW + btnGap, y);
            y += btnH + 10;

            btnHome.Size = new Size(btnW, btnH);
            btnHome.Location = new Point(cardX, y);

            btnHelp.Size = new Size(btnW, btnH);
            btnHelp.Location = new Point(cardX + btnW + btnGap, y);
        }

        // ---------------------------------------------------------------
        // PASSWORD TOGGLE
        // ---------------------------------------------------------------
        private void btnShowPwd_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                btnShowPwd.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '●';
                btnShowPwd.Text = "👁";
            }
        }

        // ---------------------------------------------------------------
        // VALIDATION
        // ---------------------------------------------------------------
        private bool ValidateFirstName()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblFirstNameMsg.Text = "⚠ Required";
                lblFirstNameMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtFirstName.Text.All(char.IsLetter))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblFirstNameMsg.Text = "⚠ Letters only";
                lblFirstNameMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtFirstName.BackColor = Color.FromArgb(220, 245, 220);
            lblFirstNameMsg.Text = "✓";
            lblFirstNameMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurnameMsg.Text = "⚠ Required";
                lblSurnameMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtSurname.Text.All(char.IsLetter))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurnameMsg.Text = "⚠ Letters only";
                lblSurnameMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtSurname.BackColor = Color.FromArgb(220, 245, 220);
            lblSurnameMsg.Text = "✓";
            lblSurnameMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePhone()
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNum.Text))
            {
                txtPhoneNum.BackColor = Color.FromArgb(255, 220, 220);
                lblPhoneMsg.Text = "⚠ Required";
                lblPhoneMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtPhoneNum.Text.All(char.IsDigit) || txtPhoneNum.Text.Length != 10)
            {
                txtPhoneNum.BackColor = Color.FromArgb(255, 220, 220);
                lblPhoneMsg.Text = "⚠ Must be exactly 10 digits";
                lblPhoneMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtPhoneNum.BackColor = Color.FromArgb(220, 245, 220);
            lblPhoneMsg.Text = "✓";
            lblPhoneMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailMsg.Text = "⚠ Required";
                lblEmailMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailMsg.Text = "⚠ Must contain @ and a dot";
                lblEmailMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtEmail.BackColor = Color.FromArgb(220, 245, 220);
            lblEmailMsg.Text = "✓";
            lblEmailMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = Color.FromArgb(255, 220, 220);
                lblAddressMsg.Text = "⚠ Required";
                lblAddressMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtAddress.BackColor = Color.FromArgb(220, 245, 220);
            lblAddressMsg.Text = "✓";
            lblAddressMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePassword()
        {
            string pwd = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordMsg.Text = "⚠ Required";
                lblPasswordMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (pwd.Length < 8)
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordMsg.Text = "⚠ Minimum 8 characters";
                lblPasswordMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!pwd.Any(char.IsUpper))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordMsg.Text = "⚠ Need 1 uppercase letter";
                lblPasswordMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (!pwd.Any(char.IsDigit))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordMsg.Text = "⚠ Need at least 1 number";
                lblPasswordMsg.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            txtPassword.BackColor = Color.FromArgb(220, 245, 220);
            lblPasswordMsg.Text = "✓";
            lblPasswordMsg.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        // ---------------------------------------------------------------
        // LIVE VALIDATION
        // ---------------------------------------------------------------
        private void txtFirstName_TextChanged(object sender, EventArgs e) { ValidateFirstName(); }
        private void txtSurname_TextChanged(object sender, EventArgs e) { ValidateSurname(); }
        private void txtPhoneNum_TextChanged(object sender, EventArgs e) { ValidatePhone(); }
        private void txtEmail_TextChanged(object sender, EventArgs e) { ValidateEmail(); }
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
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                testCustomerTableAdapter1.Insert(
                    txtFirstName.Text.Trim(),
                    txtSurname.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim());

                MessageBox.Show(
                    "Customer " + txtFirstName.Text + " " + txtSurname.Text + " added successfully!",
                    "Customer Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
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
            txtPhoneNum.Clear(); txtEmail.Clear();
            txtAddress.Clear(); txtPassword.Clear();

            foreach (var txt in new Control[] {
                txtFirstName, txtSurname, txtPhoneNum,
                txtEmail, txtAddress, txtPassword })
                txt.BackColor = Color.White;

            foreach (var lbl in new[] {
                lblFirstNameMsg, lblSurnameMsg, lblPhoneMsg,
                lblEmailMsg, lblAddressMsg, lblPasswordMsg })
                lbl.Text = "";
        }

        // ---------------------------------------------------------------
        // PICTURE BOX — go home
        // ---------------------------------------------------------------
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

        private void lblAddress_Click(object sender, EventArgs e) { }

        private void btnShowPwd_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                // Show password
                txtPassword.PasswordChar = '\0';
                btnShowPwd.Text = "Hide";
            }
            else
            {
                // Hide password
                txtPassword.PasswordChar = '*';
                btnShowPwd.Text = "Show";
            }
        }
    }
}