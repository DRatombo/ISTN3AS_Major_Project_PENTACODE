using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Cafe101;

namespace RestaurantSystem
{
    public partial class frmManageCashiers : Form
    {
        public frmManageCashiers()
        {
            InitializeComponent();
        }

        private void frmManageCashiers_Load(object sender, EventArgs e)
        {
            // Remove designer adapter call – it may cause schema mismatch
            // this.cashierTableAdapter.Fill(this.dsCafe101.Cashier);
            LoadCashiers();
        }

        private void LoadCashiers()
        {
            // Column order: CashierID, FirstName, Surname, Email, Address, Password (if needed)
            // We exclude Password from display for security.
            string query = "SELECT CashierID, FirstName, Surname, Email, Address FROM Cashier";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCashiers.DataSource = dt;

                // Hide ID column (index 0)
                if (dgvCashiers.Columns.Count > 0)
                    dgvCashiers.Columns[0].Visible = false;
            }
        }

        private void ClearCashierFields()
        {
            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            btnUpdateCashier.Tag = null;
        }

        private void btnAddCashier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("First Name and Password are required.", "Validation");
                return;
            }

            string query = @"INSERT INTO Cashier (FirstName, Surname, Email, Address, Password) 
                             VALUES (@firstName, @surname, @email, @address, @pass)";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cashier added.");
                    LoadCashiers();
                    ClearCashierFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCashiers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCashiers.Rows[e.RowIndex];

                // Use column indexes (matching SELECT order):
                // Index 0: CashierID, 1: FirstName, 2: Surname, 3: Email, 4: Address
                txtFirstName.Text = row.Cells[1].Value?.ToString() ?? "";
                txtSurname.Text = row.Cells[2].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells[3].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells[4].Value?.ToString() ?? "";
                txtPassword.Text = ""; // do not show password

                // Store ID for update/reset
                btnUpdateCashier.Tag = row.Cells[0].Value;   // CashierID
            }
        }

        private void btnUpdateCashier_Click(object sender, EventArgs e)
        {
            if (btnUpdateCashier.Tag == null)
            {
                MessageBox.Show("Select a cashier first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                query = @"UPDATE Cashier SET FirstName = @firstName, Surname = @surname, Email = @email, Address = @address, Password = @pass WHERE CashierID = @id";
            }
            else
            {
                query = @"UPDATE Cashier SET FirstName = @firstName, Surname = @surname, Email = @email, Address = @address WHERE CashierID = @id";
            }

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdateCashier.Tag));
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cashier updated.");
                    LoadCashiers();
                    ClearCashierFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (btnUpdateCashier.Tag == null)
            {
                MessageBox.Show("Select a cashier to reset password.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string newPassword = "temp123";
            string query = "UPDATE Cashier SET Password = @pass WHERE CashierID = @id";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pass", newPassword);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdateCashier.Tag));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show($"Password reset to '{newPassword}'. Please advise cashier to change it on first login.");
        }

        private void btnRefreshCashiers_Click(object sender, EventArgs e)
        {
            LoadCashiers();
            ClearCashierFields();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            // optional
        }
    }

    // DbHelper class is already defined elsewhere – but if not, this is the fallback.
    // If your project already has a global DbHelper, remove this one to avoid conflict.
    public static class DbHelper
    {
        private static string connectionString = $"Server=146.230.177.46;Database=GroupWst22;User Id=GroupWst22;Password=n38mc;";

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
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}