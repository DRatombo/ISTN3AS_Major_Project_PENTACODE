using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageIngredients : Form
    {
        public frmManageIngredients()
        {
            InitializeComponent();
        }

        private void frmManageIngredients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TestIngredient' table. You can move, or remove it, as needed.
            this.testIngredientTableAdapter.Fill(this.dataSet1.TestIngredient);
            // TODO: This line of code loads data into the 'dsCafe101.Ingredient' table. You can move, or remove it, as needed.
            this.ingredientTableAdapter.Fill(this.dsCafe101.Ingredient);
            LoadIngredients();
        }

        private void LoadIngredients()
        {
            try
            {
                // Match exactly the columns in your table: IngredientID, Description, QuantityOnHand, RestockLevel, CostPrice
                string query = "SELECT IngredientID, Description, QuantityOnHand, RestockLevel, CostPrice FROM TestIngredient ORDER BY Description";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvIngredients.DataSource = dt;

                    if (dgvIngredients.Columns.Count > 0)
                        dgvIngredients.Columns[0].Visible = false; // Hide IngredientID

                    // Format numeric columns
                    if (dgvIngredients.Columns.Count > 2)
                        dgvIngredients.Columns[2].DefaultCellStyle.Format = "N2"; // QuantityOnHand
                    if (dgvIngredients.Columns.Count > 3)
                        dgvIngredients.Columns[3].DefaultCellStyle.Format = "N2"; // RestockLevel
                    if (dgvIngredients.Columns.Count > 4)
                        dgvIngredients.Columns[4].DefaultCellStyle.Format = "C2"; // CostPrice

                    // Highlight low stock – safely handle NULL values and comma decimal separators
                    foreach (DataGridViewRow row in dgvIngredients.Rows)
                    {
                        if (row.IsNewRow) continue;

                        object qtyObj = row.Cells[2].Value;
                        object restockObj = row.Cells[3].Value;

                        decimal qty = 0m;
                        decimal restock = 0m;
                        if (qtyObj != DBNull.Value)
                            decimal.TryParse(qtyObj.ToString().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out qty);
                        if (restockObj != DBNull.Value)
                            decimal.TryParse(restockObj.ToString().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out restock);

                        if (qty <= restock)
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ingredients: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtDescription.Text = "";
            numQuantityInStock.Value = 0;
            numRestockLevel.Value = 0;
            numCostPrice.Value = 0;
            btnUpdate.Tag = null;
            // txtUnits is ignored because the table has no Units column
        }

        // Helper method to check duplicate description (case‑insensitive)
        private bool IsDescriptionDuplicate(string description, int? excludeIngredientId = null)
        {
            string query = "SELECT COUNT(*) FROM TestIngredient WHERE LOWER(Description) = LOWER(@desc)";
            if (excludeIngredientId.HasValue)
                query += " AND IngredientID != @excludeId";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desc", description.Trim());
                if (excludeIngredientId.HasValue)
                    cmd.Parameters.AddWithValue("@excludeId", excludeIngredientId.Value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numQuantityInStock.Value <= 0)
            {
                MessageBox.Show("Quantity on hand must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numRestockLevel.Value <= 0)
            {
                MessageBox.Show("Restock level must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numCostPrice.Value <= 0)
            {
                MessageBox.Show("Cost price must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate description
            if (IsDescriptionDuplicate(txtDescription.Text))
            {
                MessageBox.Show("An ingredient with this description already exists. Please use a different description.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO TestIngredient (Description, QuantityOnHand, RestockLevel, CostPrice)
                                 VALUES (@desc, @qty, @restock, @cost)";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@qty", numQuantityInStock.Value);
                    cmd.Parameters.AddWithValue("@restock", numRestockLevel.Value);
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Ingredient added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIngredients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvIngredients.Rows.Count)
            {
                DataGridViewRow row = dgvIngredients.Rows[e.RowIndex];
                if (row == null) return;

                // Ensure we have enough columns
                if (dgvIngredients.Columns.Count < 5) return;

                txtDescription.Text = row.Cells[1].Value?.ToString() ?? "";

                decimal qty = 0;
                decimal restock = 0;
                decimal cost = 0;

                // ---- QuantityOnHand (column index 2) ----
                if (row.Cells[2].Value != null && row.Cells[2].Value != DBNull.Value)
                {
                    string val = row.Cells[2].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out qty);
                }
                // Clamp to the NumericUpDown's allowed range
                if (qty < numQuantityInStock.Minimum) qty = numQuantityInStock.Minimum;
                if (qty > numQuantityInStock.Maximum) qty = numQuantityInStock.Maximum;
                numQuantityInStock.Value = qty;

                // ---- RestockLevel (column index 3) ----
                if (row.Cells[3].Value != null && row.Cells[3].Value != DBNull.Value)
                {
                    string val = row.Cells[3].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out restock);
                }
                if (restock < numRestockLevel.Minimum) restock = numRestockLevel.Minimum;
                if (restock > numRestockLevel.Maximum) restock = numRestockLevel.Maximum;
                numRestockLevel.Value = restock;

                // ---- CostPrice (column index 4) ----
                if (row.Cells[4].Value != null && row.Cells[4].Value != DBNull.Value)
                {
                    string val = row.Cells[4].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out cost);
                }
                if (cost < numCostPrice.Minimum) cost = numCostPrice.Minimum;
                if (cost > numCostPrice.Maximum) cost = numCostPrice.Maximum;
                numCostPrice.Value = cost;

                // Store the ID for updates
                btnUpdate.Tag = row.Cells[0].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an ingredient first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numQuantityInStock.Value <= 0)
            {
                MessageBox.Show("Quantity on hand must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numRestockLevel.Value <= 0)
            {
                MessageBox.Show("Restock level must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numCostPrice.Value <= 0)
            {
                MessageBox.Show("Cost price must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentId = Convert.ToInt32(btnUpdate.Tag);
            // Check duplicate description excluding the current ingredient
            if (IsDescriptionDuplicate(txtDescription.Text, currentId))
            {
                MessageBox.Show("Another ingredient with this description already exists. Please use a different description.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE TestIngredient 
                                 SET Description = @desc, QuantityOnHand = @qty, RestockLevel = @restock, CostPrice = @cost
                                 WHERE IngredientID = @id";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@qty", numQuantityInStock.Value);
                    cmd.Parameters.AddWithValue("@restock", numRestockLevel.Value);
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);
                    cmd.Parameters.AddWithValue("@id", currentId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Ingredient updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIngredients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an ingredient to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dr = MessageBox.Show("Delete this ingredient? This cannot be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM TestIngredient WHERE IngredientID = @id";
                    using (SqlConnection conn = DbHelper.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Ingredient deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIngredients();
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
            LoadIngredients();
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