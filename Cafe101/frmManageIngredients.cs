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
        private bool helpVisible = false;
        private Panel pnlHelp = null;

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
            // Clear search box
            txtSearch.Text = "";

            // Clear all input fields
            ClearFields();

            // Reload full data
            LoadIngredients();
        }

        // ============================================================
        // HELP BUTTON - Panel-based contextual help (with your icons)
        // ============================================================
      /*  private void btnHelp_Click(object sender, EventArgs e)
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
                stepTitle = "📍 Step 1 of 2 — Add a New Ingredient";
                stepDetail =
                    "You haven't selected an ingredient to edit.\r\n\r\n" +
                    "➕ ADD NEW INGREDIENT:\r\n" +
                    "• Fill in: Description, Quantity On Hand,\r\n" +
                    "  Restock Level, and Cost Price.\r\n" +
                    "• Click 'Add New' button.\r\n\r\n" +
                    "✏️ EDIT EXISTING INGREDIENT:\r\n" +
                    "• Click any row in the list to select an ingredient.\r\n" +
                    "• Only that ingredient will remain visible.\r\n" +
                    "• Edit the fields as needed.\r\n" +
                    "• Click 'Update' to save changes.\r\n\r\n" +
                    "🔍 SEARCH:\r\n" +
                    "• Type an ingredient name in the search box.\r\n" +
                    "• Results filter automatically as you type.\r\n" +
                    "• Click 'Clear' to reset search.\r\n\r\n" +
                    "⚠️ LOW STOCK WARNING:\r\n" +
                    "• Ingredients with Quantity ≤ Restock Level\r\n" +
                    "  are highlighted in YELLOW.\r\n" +
                    "• These need to be reordered soon.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all ingredient data.\r\n\r\n" +
                    "🗑️ DELETE:\r\n" +
                    "• Select an ingredient, then click 'Remove'.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }
            else
            {
                stepTitle = "📍 Step 2 of 2 — Update or Delete Ingredient";
                stepDetail =
                    "Ingredient selected: " + txtDescription.Text + "\r\n\r\n" +
                    "✏️ TO UPDATE:\r\n" +
                    "• Edit the Quantity, Restock Level, or Cost Price.\r\n" +
                    "• Click 'Update' to save changes.\r\n" +
                    "• Click 'Refresh' to see all ingredients again.\r\n\r\n" +
                    "🗑️ TO DELETE:\r\n" +
                    "• Click 'Remove' button.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "⚠️ LOW STOCK:\r\n" +
                    "• If Quantity ≤ Restock Level, the row is YELLOW.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all ingredient data.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(370, 400);
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
            lblDetail.Size = new System.Drawing.Size(350, 300);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.Location = new System.Drawing.Point(255, 360);
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

            // Calculate position - place to the right of the button, but ensure it stays within form bounds
            int xPos = btnHelp.Left + btnHelp.Width + 5;
            int yPos = btnHelp.Top - 10;

            // Ensure panel doesn't go off the right edge of the form
            if (xPos + pnlHelp.Width > this.ClientSize.Width)
            {
                xPos = btnHelp.Left - pnlHelp.Width - 5;
            }

            // Ensure panel doesn't go off the bottom of the form
            if (yPos + pnlHelp.Height > this.ClientSize.Height)
            {
                yPos = this.ClientSize.Height - pnlHelp.Height - 10;
            }

            // Ensure panel doesn't go off the top of the form
            if (yPos < 0)
            {
                yPos = 5;
            }

            pnlHelp.Location = new System.Drawing.Point(xPos, yPos);
            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "❓ Help (ON)";
        }*/

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
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                stepTitle = "📍 Step 1 of 2 — Add a New Ingredient";
                stepDetail =
                    "You haven't selected an ingredient to edit.\r\n\r\n" +
                    "➕ ADD NEW INGREDIENT:\r\n" +
                    "• Fill in: Description, Quantity On Hand,\r\n" +
                    "  Restock Level, and Cost Price.\r\n" +
                    "• Click 'Add New' button.\r\n\r\n" +
                    "✏️ EDIT EXISTING INGREDIENT:\r\n" +
                    "• Click any row in the list to select an ingredient.\r\n" +
                    "• Only that ingredient will remain visible.\r\n" +
                    "• Edit the fields as needed.\r\n" +
                    "• Click 'Update' to save changes.\r\n\r\n" +
                    "🔍 SEARCH:\r\n" +
                    "• Type an ingredient name in the search box.\r\n" +
                    "• Results filter automatically as you type.\r\n" +
                    "• Click 'Clear' to reset search.\r\n\r\n" +
                    "⚠️ LOW STOCK WARNING:\r\n" +
                    "• Ingredients with Quantity ≤ Restock Level\r\n" +
                    "  are highlighted in YELLOW.\r\n" +
                    "• These need to be reordered soon.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all ingredient data.\r\n\r\n" +
                    "🗑️ DELETE:\r\n" +
                    "• Select an ingredient, then click 'Remove'.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }
            else
            {
                stepTitle = "📍 Step 2 of 2 — Update or Delete Ingredient";
                stepDetail =
                    "Ingredient selected: " + txtDescription.Text + "\r\n\r\n" +
                    "✏️ TO UPDATE:\r\n" +
                    "• Edit the Quantity, Restock Level, or Cost Price.\r\n" +
                    "• Click 'Update' to save changes.\r\n" +
                    "• Click 'Refresh' to see all ingredients again.\r\n\r\n" +
                    "🗑️ TO DELETE:\r\n" +
                    "• Click 'Remove' button.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "⚠️ LOW STOCK:\r\n" +
                    "• If Quantity ≤ Restock Level, the row is YELLOW.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all ingredient data.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(370, 400);
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
            lblDetail.Size = new System.Drawing.Size(350, 300);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.Location = new System.Drawing.Point(255, 360);
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

            // Calculate position - place to the right of the button, but ensure it stays within form bounds
            int xPos = btnHelp.Left + btnHelp.Width + 5;
            int yPos = btnHelp.Top - 10;

            // Ensure panel doesn't go off the right edge of the form
            if (xPos + pnlHelp.Width > this.ClientSize.Width)
            {
                xPos = btnHelp.Left - pnlHelp.Width - 5;
            }

            // Ensure panel doesn't go off the bottom of the form
            if (yPos + pnlHelp.Height > this.ClientSize.Height)
            {
                yPos = this.ClientSize.Height - pnlHelp.Height - 10;
            }

            // Ensure panel doesn't go off the top of the form
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
    }
}