using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageEmployees : Form
    {
        private DataTable originalEmployeeData;
        private bool helpVisible = false;
        private Panel pnlHelp = null;

        public frmManageEmployees()
        {
            InitializeComponent();
            AttachValidationEvents();
        }

        private void AttachValidationEvents()
        {
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            txtSurname.TextChanged += txtSurname_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtPassword.TextChanged += txtPassword_TextChanged;
        }

        // ============================================================
        // VALIDATION METHODS
        // ============================================================

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidateFirstName();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            ValidateSurname();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private bool ValidateFirstName()
        {
            string value = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblFirstNameStatus.Text = "⚠️ Required";
                lblFirstNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            // Check for letters only (no spaces, no numbers, no special characters)
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                    lblFirstNameStatus.Text = "⚠️ Letters only";
                    lblFirstNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            txtFirstName.BackColor = Color.FromArgb(220, 245, 220);
            lblFirstNameStatus.Text = "✓";
            lblFirstNameStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateSurname()
        {
            string value = txtSurname.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurnameStatus.Text = "⚠️ Required";
                lblSurnameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            // Check for letters only (no spaces, no numbers, no special characters)
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                    lblSurnameStatus.Text = "⚠️ Letters only";
                    lblSurnameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            txtSurname.BackColor = Color.FromArgb(220, 245, 220);
            lblSurnameStatus.Text = "✓";
            lblSurnameStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Required";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            int atIndex = email.IndexOf('@');
            if (atIndex < 1)
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Missing '@'";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            int dotIndex = email.IndexOf('.', atIndex);
            if (dotIndex < atIndex + 2 || dotIndex >= email.Length - 1)
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Invalid domain";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtEmail.BackColor = Color.FromArgb(220, 245, 220);
            lblEmailStatus.Text = "✓";
            lblEmailStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePassword()
        {
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordStatus.Text = "⚠️ Required";
                lblPasswordStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (password.Length < 6)
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordStatus.Text = "⚠️ Min 6 chars";
                lblPasswordStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtPassword.BackColor = Color.FromArgb(220, 245, 220);
            lblPasswordStatus.Text = "✓";
            lblPasswordStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool IsFormValid()
        {
            return ValidateFirstName() && ValidateSurname() && ValidateEmail() && ValidatePassword();
        }

        // ============================================================
        // END OF VALIDATION METHODS
        // ============================================================

        private void frmManageEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            this.txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT EmployeeID, FirstName, Surname, Address, Email, Role FROM EmployeeTable";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    originalEmployeeData = new DataTable();
                    da.Fill(originalEmployeeData);
                    dgvEmployees.DataSource = originalEmployeeData;

                    if (dgvEmployees.Columns.Count > 0)
                        dgvEmployees.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (originalEmployeeData == null) return;

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvEmployees.DataSource = originalEmployeeData;
            }
            else
            {
                DataView dv = originalEmployeeData.DefaultView;
                dv.RowFilter = $"FirstName LIKE '%{searchTerm}%' OR Surname LIKE '%{searchTerm}%' OR Email LIKE '%{searchTerm}%' OR Role LIKE '%{searchTerm}%' OR Address LIKE '%{searchTerm}%'";
                dgvEmployees.DataSource = dv;
            }

            if (dgvEmployees.Columns.Count > 0)
                dgvEmployees.Columns[0].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ClearFields();
            LoadEmployees();
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            cboRole.SelectedIndex = -1;
            btnUpdate.Tag = null;

            txtFirstName.BackColor = System.Drawing.Color.White;
            txtSurname.BackColor = System.Drawing.Color.White;
            txtEmail.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
            lblFirstNameStatus.Text = "";
            lblSurnameStatus.Text = "";
            lblEmailStatus.Text = "";
            lblPasswordStatus.Text = "";
        }

        private bool IsEmployeeDuplicate(string firstName, string surname, int? excludeEmployeeId = null)
        {
            string query = "SELECT COUNT(*) FROM EmployeeTable WHERE LOWER(FirstName) = LOWER(@firstName) AND LOWER(Surname) = LOWER(@surname)";
            if (excludeEmployeeId.HasValue)
                query += " AND EmployeeID != @excludeId";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim());
                cmd.Parameters.AddWithValue("@surname", surname.Trim());
                if (excludeEmployeeId.HasValue)
                    cmd.Parameters.AddWithValue("@excludeId", excludeEmployeeId.Value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        private bool IsEmailDuplicate(string email, int? excludeEmployeeId = null)
        {
            string query = "SELECT COUNT(*) FROM EmployeeTable WHERE LOWER(Email) = LOWER(@email)";
            if (excludeEmployeeId.HasValue)
                query += " AND EmployeeID != @excludeId";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email.Trim());
                if (excludeEmployeeId.HasValue)
                    cmd.Parameters.AddWithValue("@excludeId", excludeEmployeeId.Value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        private bool IsPasswordDuplicate(string password, int? excludeEmployeeId = null)
        {
            string query = "SELECT COUNT(*) FROM EmployeeTable WHERE Password = @pass";
            if (excludeEmployeeId.HasValue)
                query += " AND EmployeeID != @excludeId";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pass", password);
                if (excludeEmployeeId.HasValue)
                    cmd.Parameters.AddWithValue("@excludeId", excludeEmployeeId.Value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before adding.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role (Manager or Cashier).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsEmployeeDuplicate(txtFirstName.Text, txtSurname.Text))
            {
                MessageBox.Show("An employee with the same First Name and Surname already exists.", "Duplicate Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsEmailDuplicate(txtEmail.Text))
            {
                MessageBox.Show("An employee with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsPasswordDuplicate(txtPassword.Text))
            {
                MessageBox.Show("This password is already in use.", "Duplicate Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO EmployeeTable (FirstName, Surname, Address, Email, Role, Password)
                                 VALUES (@firstName, @surname, @address, @email, @role, @pass)";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                DataRowView rowView = row.DataBoundItem as DataRowView;
                if (rowView == null) return;

                txtFirstName.Text = rowView["FirstName"]?.ToString() ?? "";
                txtSurname.Text = rowView["Surname"]?.ToString() ?? "";
                txtAddress.Text = rowView["Address"]?.ToString() ?? "";
                txtEmail.Text = rowView["Email"]?.ToString() ?? "";
                cboRole.Text = rowView["Role"]?.ToString() ?? "";
                txtPassword.Text = "";
                btnUpdate.Tag = rowView["EmployeeID"];

                DataView dv = originalEmployeeData.DefaultView;
                dv.RowFilter = $"EmployeeID = {btnUpdate.Tag}";
                dgvEmployees.DataSource = dv;

                if (dgvEmployees.Columns.Count > 0)
                    dgvEmployees.Columns[0].Visible = false;

                txtSearch.Text = "";

                ValidateFirstName();
                ValidateSurname();
                ValidateEmail();
                ValidatePassword();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an employee first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before updating.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentId = Convert.ToInt32(btnUpdate.Tag);

            if (IsEmployeeDuplicate(txtFirstName.Text, txtSurname.Text, currentId))
            {
                MessageBox.Show("Another employee with the same First Name and Surname already exists.", "Duplicate Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsEmailDuplicate(txtEmail.Text, currentId))
            {
                MessageBox.Show("Another employee with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && IsPasswordDuplicate(txtPassword.Text, currentId))
            {
                MessageBox.Show("This password is already in use.", "Duplicate Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query;
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    query = @"UPDATE EmployeeTable SET FirstName=@firstName, Surname=@surname, Address=@address, Email=@email, Role=@role, Password=@pass WHERE EmployeeID=@id";
                }
                else
                {
                    query = @"UPDATE EmployeeTable SET FirstName=@firstName, Surname=@surname, Address=@address, Email=@email, Role=@role WHERE EmployeeID=@id";
                }
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", currentId);
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Employee updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an employee first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string newPassword = "temp123";
                string query = "UPDATE EmployeeTable SET Password = @pass WHERE EmployeeID = @id";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pass", newPassword);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show($"Password reset to '{newPassword}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Password reset failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an employee to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dr = MessageBox.Show("Delete this employee? This cannot be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM EmployeeTable WHERE EmployeeID = @id";
                    using (SqlConnection conn = DbHelper.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Employee removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadEmployees();
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new frmMain();
            form.Show();
            this.Hide();
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            if (helpVisible)
            {
                if (pnlHelp != null)
                {
                    pnlHelp.Visible = false;
                }
                helpVisible = false;
                btnHelp.Text = "❓ Help";
                return;
            }

            string stepTitle;
            string stepDetail;

            if (btnUpdate.Tag == null)
            {
                stepTitle = "📍 Step 1 of 2 — Add a New Employee";
                stepDetail =
                    "You haven't selected an employee to edit.\r\n\r\n" +
                    "➕ ADD NEW EMPLOYEE:\r\n" +
                    "• Fill in: First Name, Surname, Email, Address,\r\n" +
                    "  Role (Manager/Cashier), and Password.\r\n" +
                    "• First Name and Surname: LETTERS ONLY (no spaces, numbers, or special characters)\r\n" +
                    "• Password: minimum 6 characters\r\n" +
                    "• Click the 'Add' button.\r\n\r\n" +
                    "✏️ EDIT EXISTING EMPLOYEE:\r\n" +
                    "• Click any row in the list to select an employee.\r\n" +
                    "• Only that employee will remain visible.\r\n" +
                    "• Edit the fields as needed.\r\n" +
                    "• Click 'Update' to save changes.\r\n\r\n" +
                    "🔍 SEARCH:\r\n" +
                    "• Type name, email, or role in the search box.\r\n" +
                    "• Results filter automatically as you type.\r\n" +
                    "• Click 'Clear' to reset search.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all employee data.\r\n\r\n" +
                    "🔑 RESET PASSWORD:\r\n" +
                    "• Select an employee, then click 'Reset PW'.\r\n" +
                    "• Password resets to 'temp123'.\r\n\r\n" +
                    "🗑️ DELETE:\r\n" +
                    "• Select an employee, then click 'Delete'.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }
            else
            {
                stepTitle = "📍 Step 2 of 2 — Update or Delete Employee";
                stepDetail =
                    "Employee selected: " + txtFirstName.Text + " " + txtSurname.Text + "\r\n\r\n" +
                    "✏️ TO UPDATE:\r\n" +
                    "• Edit the fields you want to change.\r\n" +
                    "• First Name and Surname: LETTERS ONLY (no spaces, numbers, or special characters)\r\n" +
                    "• Click 'Update' to save changes.\r\n" +
                    "• Click 'Refresh' to see all employees again.\r\n\r\n" +
                    "🗑️ TO DELETE:\r\n" +
                    "• Click 'Delete' button.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "🔑 RESET PASSWORD:\r\n" +
                    "• Click 'Reset PW' to reset password to 'temp123'.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all employee data.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(370, 420);
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            pnlHelp.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(350, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 9);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(10, 50);
            lblDetail.Size = new System.Drawing.Size(350, 320);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.Location = new System.Drawing.Point(255, 380);
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "❓ Help";
            };

            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            int xPos = btnHelp.Left + btnHelp.Width + 5;
            int yPos = btnHelp.Top - 10;

            if (xPos + pnlHelp.Width > this.ClientSize.Width)
            {
                xPos = btnHelp.Left - pnlHelp.Width - 5;
            }

            if (yPos + pnlHelp.Height > this.ClientSize.Height)
            {
                yPos = this.ClientSize.Height - pnlHelp.Height - 10;
            }

            if (yPos < 0)
            {
                yPos = 5;
            }

            pnlHelp.Location = new System.Drawing.Point(xPos, yPos);
            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "❓ Help (ON)";
        }
    }

    // ============================================================
    // DbHelper Class
    // ============================================================
   /* public static class DbHelper
    {
        private static string server = "146.230.177.46";
        private static string database = "GroupWst22";
        private static string username = "GroupWst22";
        private static string password = "n38mc";
        private static string connectionString = $"Server={server};Database={database};User Id={username};Password={password};Connection Timeout=30;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }*/
}