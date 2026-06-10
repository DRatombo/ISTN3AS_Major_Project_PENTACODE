using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageRecipes : Form
    {
        public frmManageRecipes()
        {
            InitializeComponent();
        }

        private void frmManageRecipes_Load(object sender, EventArgs e)
        {
            // Live connection only - no DataSets
            LoadAllRecipes();
            LoadMenuItemsCombo();
            LoadIngredientsCombo();

            // Manually attach event handler for menu item selection
            this.cboMenuItems.SelectedIndexChanged += cboMenuItems_SelectedIndexChanged;

            // Attach cell click event for the DataGridView
            this.dgvRecipe.CellClick += dgvRecipe_CellClick;
        }

        // Show ALL recipes (MenuItemName, Ingredient Description, QuantityNeeded)
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
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRecipe.DataSource = dt;

                    // Hide the ID columns if they exist (optional)
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

        // Event handler for when a recipe row is clicked - populates the combo boxes and quantity
        private void dgvRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a valid row (not header)
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dgvRecipe.Rows.Count) return;

            DataGridViewRow row = dgvRecipe.Rows[e.RowIndex];
            if (row == null || row.IsNewRow) return;

            // Get the underlying DataRowView to access column values
            DataRowView rowView = row.DataBoundItem as DataRowView;
            if (rowView == null) return;

            // Populate Menu Item ComboBox
            string menuItemName = rowView["MenuItemName"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(menuItemName))
            {
                // Find and select the matching menu item in the combo box
                foreach (DataRowView item in cboMenuItems.Items)
                {
                    if (item["MenuItemName"].ToString() == menuItemName)
                    {
                        cboMenuItems.SelectedItem = item;
                        break;
                    }
                }
            }

            // Populate Ingredient ComboBox
            string ingredientName = rowView["Ingredient"]?.ToString() ?? "";
            if (!string.IsNullOrEmpty(ingredientName))
            {
                // Find and select the matching ingredient in the combo box
                foreach (DataRowView item in cboIngredients.Items)
                {
                    if (item["Description"].ToString() == ingredientName)
                    {
                        cboIngredients.SelectedItem = item;
                        break;
                    }
                }
            }

            // Populate Quantity
            decimal quantity = 0;
            if (rowView["QuantityNeeded"] != DBNull.Value)
                decimal.TryParse(rowView["QuantityNeeded"].ToString().Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out quantity);
            numQuantity.Value = quantity > 0 ? quantity : 1;
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
            if (cboMenuItems.SelectedIndex == -1 || cboIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Select both a menu item and an ingredient.", "Validation");
                return;
            }
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity needed must be greater than zero.", "Validation");
                return;
            }

            int? menuId = GetSelectedMenuItemId();
            int? ingId = GetSelectedIngredientId();
            if (menuId == null || ingId == null) return;

            // Check if this combination already exists
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

            // Get the Description of the selected ingredient
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
            LoadMenuItemsCombo();
            LoadIngredientsCombo();
            LoadAllRecipes();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new frmMain();
            form.Show();
            this.Close();
        }
    }
}