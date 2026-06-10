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
            // DataSet adapter removed - using live connection only
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            string query = "SELECT MenuItemID, MenuItemName, SellingPrice, CostToMake, Category, PreparationTime FROM MenuItemsTable";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMenuItems.DataSource = dt;

                    if (dgvMenuItems.Columns.Count > 0)
                        dgvMenuItems.Columns[0].Visible = false;

                    if (dgvMenuItems.Columns.Count > 2)
                        dgvMenuItems.Columns[2].DefaultCellStyle.Format = "C2";
                    if (dgvMenuItems.Columns.Count > 3)
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

        private bool IsMenuItemNameDuplicate(string name, int? excludeMenuItemId = null)
        {
            string query = "SELECT COUNT(*) FROM MenuItemsTable WHERE MenuItemName = @name";
            if (excludeMenuItemId.HasValue)
                query += " AND MenuItemID != @excludeId";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name.Trim());
                if (excludeMenuItemId.HasValue)
                    cmd.Parameters.AddWithValue("@excludeId", excludeMenuItemId.Value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
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
            if (numSellingPrice.Value <= 0)
            {
                MessageBox.Show("Selling price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numCostPrice.Value <= 0)
            {
                MessageBox.Show("Cost price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsMenuItemNameDuplicate(txtItemName.Text))
            {
                MessageBox.Show("A menu item with this name already exists. Please use a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO MenuItemsTable (MenuItemName, SellingPrice, CostToMake, Category, PreparationTime) 
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
                // Get the underlying DataRowView
                DataGridViewRow row = dgvMenuItems.Rows[e.RowIndex];
                DataRowView rowView = row.DataBoundItem as DataRowView;
                if (rowView == null) return;

                // Access columns by name from the DataRowView (safe and reliable)
                txtItemName.Text = rowView["MenuItemName"]?.ToString() ?? "";

                decimal sellingPrice = 0;
                if (rowView["SellingPrice"] != DBNull.Value)
                    decimal.TryParse(rowView["SellingPrice"].ToString().Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out sellingPrice);
                numSellingPrice.Value = sellingPrice;

                decimal costPrice = 0;
                if (rowView["CostToMake"] != DBNull.Value)
                    decimal.TryParse(rowView["CostToMake"].ToString().Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out costPrice);
                numCostPrice.Value = costPrice;

                cboCategory.Text = rowView["Category"]?.ToString() ?? "";
                txtPrepTime.Text = rowView["PreparationTime"]?.ToString() ?? "";

                btnUpdate.Tag = rowView["MenuItemID"];
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
            if (numSellingPrice.Value <= 0)
            {
                MessageBox.Show("Selling price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numCostPrice.Value <= 0)
            {
                MessageBox.Show("Cost price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentId = Convert.ToInt32(btnUpdate.Tag);
            if (IsMenuItemNameDuplicate(txtItemName.Text, currentId))
            {
                MessageBox.Show("Another menu item with this name already exists. Please use a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE MenuItemsTable 
                             SET MenuItemName = @name, SellingPrice = @price, CostToMake = @cost, 
                                 Category = @cat, PreparationTime = @prep
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
                    cmd.Parameters.AddWithValue("@id", currentId);

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
                string query = "DELETE FROM MenuItemsTable WHERE MenuItemID = @id";
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