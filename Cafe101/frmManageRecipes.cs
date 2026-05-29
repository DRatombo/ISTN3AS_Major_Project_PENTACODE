using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Cafe101;

namespace RestaurantSystem
{
    public partial class frmManageRecipes : Form
    {
        public frmManageRecipes()
        {
            InitializeComponent();
        }

        private void frmManageRecipes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101.Ingredient' table. You can move, or remove it, as needed.
            this.ingredientTableAdapter.Fill(this.dsCafe101.Ingredient);
            // Comment out designer adapter if it causes issues
            // this.recipeItemTableAdapter.Fill(this.dsCafe101.RecipeItem);
            LoadMenuItemsCombo();
            LoadIngredientsCombo();
        }

        private void LoadMenuItemsCombo()
        {
            string query = "SELECT MenuItemID, MenuItemName FROM MenuItems ORDER BY MenuItemName";
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

        private void LoadIngredientsCombo()
        {
            string query = "SELECT IngredientID, Description, Units FROM Ingredient ORDER BY Description";
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

        // Helper method to get MenuItemID from selected combo box
        private int? GetSelectedMenuItemId()
        {
            if (cboMenuItems.SelectedItem == null) return null;
            DataRowView drv = cboMenuItems.SelectedItem as DataRowView;
            if (drv == null) return null;
            object val = drv["MenuItemID"];
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        // Helper method to get IngredientID from selected combo box
        private int? GetSelectedIngredientId()
        {
            if (cboIngredients.SelectedItem == null) return null;
            DataRowView drv = cboIngredients.SelectedItem as DataRowView;
            if (drv == null) return null;
            object val = drv["IngredientID"];
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void LoadRecipe()
        {
            int? menuItemId = GetSelectedMenuItemId();
            if (menuItemId == null)
            {
                dgvRecipe.DataSource = null;
                return;
            }

            string query = @"SELECT r.IngredientID, r.MenuItemID, i.Description AS Ingredient, r.Proportion, i.Units 
                     FROM RecipeItem r
                     INNER JOIN Ingredient i ON r.MenuItemID = i.IngredientID
                     WHERE r.MenuItemID = @menuId
                     ORDER BY i.Description";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@menuId", menuItemId.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecipe.DataSource = dt;
            }
        }

        private void cboIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = cboIngredients.SelectedItem as DataRowView;
            if (drv != null)
            {
                txtDisplayUnit.Text = drv["Units"].ToString();
            }
            else
            {
                txtDisplayUnit.Text = "";
            }
        }

        private void cboMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecipe();
        }

        private void btnAddToRecipe_Click(object sender, EventArgs e)
        {
            // Validation
            if (cboMenuItems.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a menu item.", "Validation");
                return;
            }
            if (cboIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an ingredient.", "Validation");
                return;
            }
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity/proportion must be greater than zero.", "Validation");
                return;
            }

            int? menuId = GetSelectedMenuItemId();
            int? ingId = GetSelectedIngredientId();
            if (menuId == null || ingId == null)
            {
                MessageBox.Show("Invalid selection. Please try again.");
                return;
            }

            decimal proportion = numQuantity.Value;

            string deleteQuery = "DELETE FROM RecipeItem WHERE MenuItemID = @menuId AND IngredientID = @ingId";
            string insertQuery = "INSERT INTO RecipeItem (MenuItemID, IngredientID, Proportion) VALUES (@menuId, @ingId, @prop)";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdDel = new SqlCommand(deleteQuery, conn);
                    cmdDel.Parameters.AddWithValue("@menuId", menuId.Value);
                    cmdDel.Parameters.AddWithValue("@ingId", ingId.Value);
                    cmdDel.ExecuteNonQuery();

                    SqlCommand cmdIns = new SqlCommand(insertQuery, conn);
                    cmdIns.Parameters.AddWithValue("@menuId", menuId.Value);
                    cmdIns.Parameters.AddWithValue("@ingId", ingId.Value);
                    cmdIns.Parameters.AddWithValue("@prop", proportion);
                    cmdIns.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Recipe link saved.", "Success");
                    LoadRecipe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (cboMenuItems.SelectedIndex == -1 || cboIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Select both a menu item and an ingredient to remove.");
                return;
            }

            int? menuId = GetSelectedMenuItemId();
            int? ingId = GetSelectedIngredientId();
            if (menuId == null || ingId == null)
            {
                MessageBox.Show("Invalid selection.");
                return;
            }

            DialogResult dr = MessageBox.Show("Remove this ingredient from the recipe?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string query = "DELETE FROM RecipeItem WHERE MenuItemID = @menuId AND IngredientID = @ingId";
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@menuId", menuId.Value);
                    cmd.Parameters.AddWithValue("@ingId", ingId.Value);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                LoadRecipe();
                MessageBox.Show("Removed.");
            }
        }

        private void btnRefreshRecipe_Click(object sender, EventArgs e)
        {
            LoadMenuItemsCombo();
            LoadIngredientsCombo();
            LoadRecipe();
        }

        private void lblUnit_Click(object sender, EventArgs e)
        {
            // Optional
        }
    }
}