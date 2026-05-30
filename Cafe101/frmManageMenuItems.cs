using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageMenuItems : Form
    {
        public frmManageMenuItems()
        {
            InitializeComponent();
        }

        private void frmManageMenuItems_Load(object sender, EventArgs e)
        {
            // Remove designer adapter call to avoid schema mismatch
            // this.menuItemsTableAdapter.Fill(this.dsCafe101.MenuItems);
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            // Column order: MenuItemID, MenuItemName, Price, CostPrice, Category, PrepTime
            string query = "SELECT MenuItemID, MenuItemName, Price, CostPrice, Category, PrepTime FROM MenuItems";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMenuItems.DataSource = dt;

                    // Hide ID column (index 0)
                    if (dgvMenuItems.Columns.Count > 0)
                        dgvMenuItems.Columns[0].Visible = false;

                    // Format price columns using indexes
                    if (dgvMenuItems.Columns.Count > 2) // Price at index 2
                        dgvMenuItems.Columns[2].DefaultCellStyle.Format = "C2";
                    if (dgvMenuItems.Columns.Count > 3) // CostPrice at index 3
                        dgvMenuItems.Columns[3].DefaultCellStyle.Format = "C2";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu items: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            txtItemName.Text = "";
            numSellingPrice.Value = 0;
            numCostPrice.Value = 0;
            cboCategory.SelectedIndex = -1;
            txtPrepTime.Text = "";
            btnUpdate.Tag = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter a menu item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO MenuItems (MenuItemName, Price, CostPrice, Category, PrepTime) 
                             VALUES (@name, @price, @cost, @cat, @prep)";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtItemName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", numSellingPrice.Value);
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);
                    cmd.Parameters.AddWithValue("@cat", cboCategory.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@prep", txtPrepTime.Text.Trim());

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Menu item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMenuItems();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMenuItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenuItems.Rows[e.RowIndex];

                // Use column indexes (matching SELECT order)
                // Index 0: MenuItemID, 1: MenuItemName, 2: Price, 3: CostPrice, 4: Category, 5: PrepTime
                txtItemName.Text = row.Cells[1].Value?.ToString() ?? "";
                numSellingPrice.Value = Convert.ToDecimal(row.Cells[2].Value);
                numCostPrice.Value = Convert.ToDecimal(row.Cells[3].Value);
                cboCategory.Text = row.Cells[4].Value?.ToString() ?? "";
                txtPrepTime.Text = row.Cells[5].Value?.ToString() ?? "";

                // Store ID for update/delete
                btnUpdate.Tag = row.Cells[0].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Please select a menu item from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Item name cannot be empty.", "Validation Error");
                return;
            }

            string query = @"UPDATE MenuItems 
                             SET MenuItemName = @name, Price = @price, CostPrice = @cost, 
                                 Category = @cat, PrepTime = @prep
                             WHERE MenuItemID = @id";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtItemName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", numSellingPrice.Value);
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);
                    cmd.Parameters.AddWithValue("@cat", cboCategory.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@prep", txtPrepTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Menu item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenuItems();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Please select a menu item to remove.", "No Selection");
                return;
            }

            DialogResult dr = MessageBox.Show("Remove this menu item from the database? This action cannot be undone.",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string query = "DELETE FROM MenuItems WHERE MenuItemID = @id";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Menu item removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMenuItems();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Remove failed: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMenuItems();
            ClearFields();
        }

        private void grpMenuItemDetails_Enter(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new frmMain();
            form.Show();
            this.Close();
        }
    }

    // DbHelper class is already defined elsewhere; if not, this is the fallback.
    // Remove this if your project already has a global DbHelper to avoid duplicate.
    public static class DbHelper
    {
        private static string server = "146.230.177.46";
        private static string database = "GroupWst22";
        private static string username = "GroupWst22";
        private static string password = "n38mc";
        private static string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";

        public static SqlConnection GetConnection() => new SqlConnection(connectionString);

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