using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageEmployees : Form
    {
        private DataTable originalEmployeeData;

        public frmManageEmployees()
        {
            InitializeComponent();
        }

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
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Surname is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role (Manager or Cashier).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email address is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Filter to show ONLY the selected row
                DataView dv = originalEmployeeData.DefaultView;
                dv.RowFilter = $"EmployeeID = {btnUpdate.Tag}";
                dgvEmployees.DataSource = dv;

                // Hide ID column after filtering
                if (dgvEmployees.Columns.Count > 0)
                    dgvEmployees.Columns[0].Visible = false;

                // Clear search box
                txtSearch.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an employee first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Surname cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email address cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Reload full data after update
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
            this.Close();
        }
    }
}

// ============================================================
// DbHelper Class
// ============================================================
public static class DbHelper
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

        public static bool TestConnection()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
