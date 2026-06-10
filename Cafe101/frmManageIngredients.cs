using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageIngredients : Form
    {
        private DataTable originalIngredientData;

        public frmManageIngredients()
        {
            InitializeComponent();
        }

        private void frmManageIngredients_Load(object sender, EventArgs e)
        {
            LoadIngredients();
            this.txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadIngredients()
        {
            try
            {
                string query = "SELECT IngredientID, Description, QuantityOnHand, RestockLevel, CostPrice FROM IngredientTable ORDER BY Description";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    originalIngredientData = new DataTable();
                    da.Fill(originalIngredientData);
                    dgvIngredients.DataSource = originalIngredientData;

                    if (dgvIngredients.Columns.Count > 0)
                        dgvIngredients.Columns[0].Visible = false;

                    if (dgvIngredients.Columns.Count > 2)
                        dgvIngredients.Columns[2].DefaultCellStyle.Format = "N2";
                    if (dgvIngredients.Columns.Count > 3)
                        dgvIngredients.Columns[3].DefaultCellStyle.Format = "N2";
                    if (dgvIngredients.Columns.Count > 4)
                        dgvIngredients.Columns[4].DefaultCellStyle.Format = "C2";

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (originalIngredientData == null) return;

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvIngredients.DataSource = originalIngredientData;
            }
            else
            {
                DataView dv = originalIngredientData.DefaultView;
                dv.RowFilter = $"Description LIKE '%{searchTerm}%'";
                dgvIngredients.DataSource = dv;
            }

            if (dgvIngredients.Columns.Count > 0)
                dgvIngredients.Columns[0].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadIngredients();
        }

        private void ClearFields()
        {
            txtDescription.Text = "";
            numQuantityInStock.Value = 0;
            numRestockLevel.Value = 0;
            numCostPrice.Value = 0;
            btnUpdate.Tag = null;
        }

        private bool IsDescriptionDuplicate(string description, int? excludeIngredientId = null)
        {
            string query = "SELECT COUNT(*) FROM IngredientTable WHERE LOWER(Description) = LOWER(@desc)";
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

            if (IsDescriptionDuplicate(txtDescription.Text))
            {
                MessageBox.Show("An ingredient with this description already exists. Please use a different description.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO IngredientTable (Description, QuantityOnHand, RestockLevel, CostPrice)
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
                if (dgvIngredients.Columns.Count < 5) return;

                txtDescription.Text = row.Cells[1].Value?.ToString() ?? "";

                decimal qty = 0, restock = 0, cost = 0;

                if (row.Cells[2].Value != null && row.Cells[2].Value != DBNull.Value)
                {
                    string val = row.Cells[2].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out qty);
                }
                if (qty < numQuantityInStock.Minimum) qty = numQuantityInStock.Minimum;
                if (qty > numQuantityInStock.Maximum) qty = numQuantityInStock.Maximum;
                numQuantityInStock.Value = qty;

                if (row.Cells[3].Value != null && row.Cells[3].Value != DBNull.Value)
                {
                    string val = row.Cells[3].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out restock);
                }
                if (restock < numRestockLevel.Minimum) restock = numRestockLevel.Minimum;
                if (restock > numRestockLevel.Maximum) restock = numRestockLevel.Maximum;
                numRestockLevel.Value = restock;

                if (row.Cells[4].Value != null && row.Cells[4].Value != DBNull.Value)
                {
                    string val = row.Cells[4].Value.ToString().Trim();
                    decimal.TryParse(val.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out cost);
                }
                if (cost < numCostPrice.Minimum) cost = numCostPrice.Minimum;
                if (cost > numCostPrice.Maximum) cost = numCostPrice.Maximum;
                numCostPrice.Value = cost;

                int ingredientId = Convert.ToInt32(row.Cells[0].Value);
                btnUpdate.Tag = ingredientId;

                // Filter to show ONLY the selected row
                DataView dv = originalIngredientData.DefaultView;
                dv.RowFilter = $"IngredientID = {ingredientId}";
                dgvIngredients.DataSource = dv;

                if (dgvIngredients.Columns.Count > 0)
                    dgvIngredients.Columns[0].Visible = false;

                txtSearch.Text = "";
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
            if (IsDescriptionDuplicate(txtDescription.Text, currentId))
            {
                MessageBox.Show("Another ingredient with this description already exists. Please use a different description.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE IngredientTable 
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
                    string query = "DELETE FROM IngredientTable WHERE IngredientID = @id";
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
            txtSearch.Text = "";
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