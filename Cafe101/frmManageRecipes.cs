using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageRecipes : Form
    {
        private DataTable originalRecipesData;
        private bool helpVisible = false;
        private Panel pnlHelp = null;

        public frmManageRecipes()
        {
            InitializeComponent();
            AttachValidationEvents();
        }

        private void AttachValidationEvents()
        {
            numQuantity.TextChanged += numQuantity_TextChanged;
            numQuantity.ValueChanged += numQuantity_ValueChanged;
        }

        // ============================================================
        // VALIDATION METHODS
        // ============================================================

        private void numQuantity_TextChanged(object sender, EventArgs e)
        {
            ValidateQuantity();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            ValidateQuantity();
        }

        private bool ValidateQuantity()
        {
            if (numQuantity.Value <= 0)
            {
                numQuantity.BackColor = Color.FromArgb(255, 220, 220);
                return false;
            }
            else
            {
                numQuantity.BackColor = Color.FromArgb(220, 245, 220);
                return true;
            }
        }

        private bool IsFormValid()
        {
            return ValidateQuantity();
        }

        // ============================================================
        // END OF VALIDATION METHODS
        // ============================================================

        private void frmManageRecipes_Load(object sender, EventArgs e)
        {
            LoadAllRecipes();
            LoadMenuItemsCombo();
            LoadIngredientsCombo();

            this.cboMenuItems.SelectedIndexChanged += cboMenuItems_SelectedIndexChanged;
            this.dgvRecipe.CellClick += dgvRecipe_CellClick;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadAllRecipes()
        {
            try
            {
                string query = @"SELECT m.MenuItemName, i.Description AS Ingredient, r.QuantityNeeded, 
                                        m.MenuItemID, i.IngredientID
                                 FROM RecipeTable r
                                 INNER JOIN MenuItemsTable m ON r.MenuItemID = m.MenuItemID
                                 INNER JOIN IngredientTable i ON r.IngredientID = i.IngredientID
                                 ORDER BY m.MenuItemName, i.Description";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    originalRecipesData = new DataTable();
                    da.Fill(originalRecipesData);
                    dgvRecipe.DataSource = originalRecipesData;

                    if (dgvRecipe.Columns["MenuItemID"] != null)
                        dgvRecipe.Columns["MenuItemID"].Visible = false;
                    if (dgvRecipe.Columns["IngredientID"] != null)
                        dgvRecipe.Columns["IngredientID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recipes: {ex.Message}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (originalRecipesData == null) return;

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvRecipe.DataSource = originalRecipesData;
            }
            else
            {
                DataView dv = originalRecipesData.DefaultView;
                dv.RowFilter = $"MenuItemName LIKE '%{searchTerm}%' OR Ingredient LIKE '%{searchTerm}%'";
                dgvRecipe.DataSource = dv;
            }

            if (dgvRecipe.Columns["MenuItemID"] != null)
                dgvRecipe.Columns["MenuItemID"].Visible = false;
            if (dgvRecipe.Columns["IngredientID"] != null)
                dgvRecipe.Columns["IngredientID"].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            // Clear search box
            txtSearch.Text = "";

            // Reset combo boxes
            cboMenuItems.SelectedIndex = -1;
            cboIngredients.SelectedIndex = -1;

            // Reset quantity to 1
            numQuantity.Value = 1;

            // Reset validation color
            numQuantity.BackColor = System.Drawing.Color.White;

            // Reload full data
            LoadAllRecipes();
        }

        private void LoadMenuItemsCombo()
        {
            try
            {
                string query = "SELECT MenuItemID, MenuItemName FROM MenuItemsTable ORDER BY MenuItemName";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboMenuItems.DataSource = dt;
                    cboMenuItems.DisplayMember = "MenuItemName";
                    cboMenuItems.ValueMember = "MenuItemID";
                    cboMenuItems.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu items: {ex.Message}");
            }
        }

        private void LoadIngredientsCombo()
        {
            try
            {
                string query = "SELECT IngredientID, Description FROM IngredientTable ORDER BY Description";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboIngredients.DataSource = dt;
                    cboIngredients.DisplayMember = "Description";
                    cboIngredients.ValueMember = "IngredientID";
                    cboIngredients.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ingredients: {ex.Message}");
            }
        }

        private void dgvRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dgvRecipe.Rows.Count) return;

            DataGridViewRow row = dgvRecipe.Rows[e.RowIndex];
            if (row == null || row.IsNewRow) return;

            DataRowView rowView = row.DataBoundItem as DataRowView;
            if (rowView == null) return;

            string menuItemName = rowView["MenuItemName"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(menuItemName))
            {
                foreach (DataRowView item in cboMenuItems.Items)
                {
                    if (item["MenuItemName"].ToString() == menuItemName)
                    {
                        cboMenuItems.SelectedItem = item;
                        break;
                    }
                }
            }

            string ingredientName = rowView["Ingredient"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(ingredientName))
            {
                foreach (DataRowView item in cboIngredients.Items)
                {
                    if (item["Description"].ToString() == ingredientName)
                    {
                        cboIngredients.SelectedItem = item;
                        break;
                    }
                }
            }

            decimal quantity = 0;
            if (rowView["QuantityNeeded"] != DBNull.Value)
                decimal.TryParse(rowView["QuantityNeeded"].ToString().Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out quantity);
            numQuantity.Value = quantity > 0 ? quantity : 1;

            int menuItemId = Convert.ToInt32(rowView["MenuItemID"]);
            int ingredientId = Convert.ToInt32(rowView["IngredientID"]);

            DataView dv = originalRecipesData.DefaultView;
            dv.RowFilter = $"MenuItemID = {menuItemId} AND IngredientID = {ingredientId}";
            dgvRecipe.DataSource = dv;

            if (dgvRecipe.Columns["MenuItemID"] != null)
                dgvRecipe.Columns["MenuItemID"].Visible = false;
            if (dgvRecipe.Columns["IngredientID"] != null)
                dgvRecipe.Columns["IngredientID"].Visible = false;

            txtSearch.Text = "";

            // Validate quantity after loading
            ValidateQuantity();
        }

        private int? GetSelectedMenuItemId()
        {
            if (cboMenuItems.SelectedItem == null) return null;
            DataRowView drv = cboMenuItems.SelectedItem as DataRowView;
            if (drv == null) return null;
            return Convert.ToInt32(drv["MenuItemID"]);
        }

        private int? GetSelectedIngredientId()
        {
            if (cboIngredients.SelectedItem == null) return null;
            DataRowView drv = cboIngredients.SelectedItem as DataRowView;
            if (drv == null) return null;
            return Convert.ToInt32(drv["IngredientID"]);
        }

        private void cboMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllRecipes();
        }

        private void btnAddToRecipe_Click(object sender, EventArgs e)
        {
            // Validate quantity before adding
            if (!IsFormValid())
            {
                MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMenuItems.SelectedIndex == -1 || cboIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Select both a menu item and an ingredient.", "Validation");
                return;
            }

            int? menuId = GetSelectedMenuItemId();
            int? ingId = GetSelectedIngredientId();
            if (menuId == null || ingId == null) return;

            string checkQuery = "SELECT COUNT(*) FROM RecipeTable WHERE MenuItemID = @menuId AND IngredientID = @ingId";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand(checkQuery, conn);
                cmdCheck.Parameters.AddWithValue("@menuId", menuId);
                cmdCheck.Parameters.AddWithValue("@ingId", ingId);
                int existingCount = (int)cmdCheck.ExecuteScalar();
                if (existingCount > 0)
                {
                    MessageBox.Show("This ingredient is already linked to the selected menu item. Use Remove first if you want to change the quantity.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }
                conn.Close();
            }

            DataRowView drv = cboIngredients.SelectedItem as DataRowView;
            string description = drv?["Description"]?.ToString() ?? "";

            decimal qty = numQuantity.Value;

            try
            {
                string insertQuery = @"INSERT INTO RecipeTable (MenuItemID, IngredientID, QuantityNeeded, Description) 
                                       VALUES (@menuId, @ingId, @qty, @desc)";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmdIns = new SqlCommand(insertQuery, conn);
                    cmdIns.Parameters.AddWithValue("@menuId", menuId);
                    cmdIns.Parameters.AddWithValue("@ingId", ingId);
                    cmdIns.Parameters.AddWithValue("@qty", qty);
                    cmdIns.Parameters.AddWithValue("@desc", description);
                    cmdIns.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Recipe link saved.", "Success");
                LoadAllRecipes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (cboMenuItems.SelectedIndex == -1 || cboIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Select both a menu item and an ingredient.");
                return;
            }
            int? menuId = GetSelectedMenuItemId();
            int? ingId = GetSelectedIngredientId();
            if (menuId == null || ingId == null) return;

            DialogResult dr = MessageBox.Show("Remove this ingredient from the recipe?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM RecipeTable WHERE MenuItemID = @menuId AND IngredientID = @ingId";
                    using (SqlConnection conn = DbHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@menuId", menuId);
                        cmd.Parameters.AddWithValue("@ingId", ingId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    LoadAllRecipes();
                    MessageBox.Show("Removed.", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete failed: {ex.Message}");
                }
            }
        }

        private void btnRefreshRecipe_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadMenuItemsCombo();
            LoadIngredientsCombo();
            LoadAllRecipes();
            numQuantity.BackColor = System.Drawing.Color.White;
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

            if (cboMenuItems.SelectedIndex == -1 && cboIngredients.SelectedIndex == -1)
            {
                stepTitle = "📍 Step 1 of 2 — Add a New Recipe Link";
                stepDetail =
                    "A recipe links a Menu Item with an Ingredient and Quantity.\r\n\r\n" +
                    "➕ ADD NEW RECIPE LINK:\r\n" +
                    "• Select a Menu Item from the first dropdown.\r\n" +
                    "• Select an Ingredient from the second dropdown.\r\n" +
                    "• Enter the Quantity needed (must be greater than zero).\r\n" +
                    "• Click 'Add' button.\r\n\r\n" +
                    "🔍 SEARCH:\r\n" +
                    "• Type a menu item name or ingredient in the search box.\r\n" +
                    "• Results filter automatically as you type.\r\n" +
                    "• Click 'Clear' to reset search.\r\n\r\n" +
                    "✏️ EDIT EXISTING RECIPE:\r\n" +
                    "• Click any row in the recipe list to auto-select\r\n" +
                    "  that menu item and ingredient.\r\n" +
                    "• Change the quantity, then click 'Remove' and 'Add'.\r\n\r\n" +
                    "📋 EXAMPLE:\r\n" +
                    "• 'Chicken Burger' needs 'Chicken Wings' (2),\r\n" +
                    "  'Burger Buns' (1), 'Lettuce' (2), etc.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all recipe data.\r\n\r\n" +
                    "🗑️ REMOVE:\r\n" +
                    "• Select a menu item and ingredient, then click 'Remove'.\r\n" +
                    "• Confirm removal when prompted.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }
            else
            {
                stepTitle = "📍 Step 2 of 2 — Remove Recipe Link";
                stepDetail =
                    "Selected: " + (cboMenuItems.SelectedItem != null ? cboMenuItems.Text : "") +
                    " + " + (cboIngredients.SelectedItem != null ? cboIngredients.Text : "") + "\r\n\r\n" +
                    "✏️ TO MODIFY QUANTITY:\r\n" +
                    "• Change the quantity in the Quantity box.\r\n" +
                    "• Quantity must be greater than zero.\r\n" +
                    "• Click 'Remove' then 'Add' with the new quantity.\r\n\r\n" +
                    "🗑️ TO REMOVE THE RECIPE LINK:\r\n" +
                    "• Click 'Remove' button.\r\n" +
                    "• Confirm removal when prompted.\r\n\r\n" +
                    "🔄 TO SEE ALL RECIPES AGAIN:\r\n" +
                    "• Click 'Refresh' to reload all recipe data.\r\n\r\n" +
                    "💡 TIP:\r\n" +
                    "• Click any row in the recipe list to automatically\r\n" +
                    "  select that menu item and ingredient for editing.\r\n\r\n" +
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
    /*public static class DbHelper
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