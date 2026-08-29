using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageMenuItems : Form
    {
        private DataTable originalMenuItemsData;
        private bool helpVisible = false;
        private Panel pnlHelp = null;
        private Label lblPrepTimeStatus;
        private int pendingMenuItemId = -1;
        private bool isAddingWithRecipe = false;

        public frmManageMenuItems()
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            CreatePrepTimeStatusLabel();
            AttachValidationEvents();
        }

        private void CreatePrepTimeStatusLabel()
        {
            lblPrepTimeStatus = new Label();
            lblPrepTimeStatus.AutoSize = true;
            lblPrepTimeStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblPrepTimeStatus.ForeColor = System.Drawing.Color.White;
            lblPrepTimeStatus.Location = new System.Drawing.Point(120, 218);
            lblPrepTimeStatus.Name = "lblPrepTimeStatus";
            lblPrepTimeStatus.Size = new System.Drawing.Size(0, 20);
            lblPrepTimeStatus.TabIndex = 11;
            this.grpMenuItemDetails.Controls.Add(lblPrepTimeStatus);
        }

        private void AttachValidationEvents()
        {
            txtItemName.TextChanged += txtItemName_TextChanged;
            txtPrepTime.TextChanged += txtPrepTime_TextChanged;
            txtPrepTime.KeyPress += txtPrepTime_KeyPress;
        }

        // ============================================================
        // VALIDATION METHODS (Spaces allowed in Name)
        // ============================================================

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            ValidateItemName();
        }

        private void txtPrepTime_TextChanged(object sender, EventArgs e)
        {
            ValidatePrepTime();
        }

        private void txtPrepTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateItemName()
        {
            string value = txtItemName.Text;

            if (string.IsNullOrWhiteSpace(value))
            {
                txtItemName.BackColor = Color.FromArgb(255, 220, 220);
                lblItemNameStatus.Text = "⚠️ Required";
                lblItemNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    txtItemName.BackColor = Color.FromArgb(255, 220, 220);
                    lblItemNameStatus.Text = "⚠️ Letters and spaces only";
                    lblItemNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            txtItemName.BackColor = Color.FromArgb(220, 245, 220);
            lblItemNameStatus.Text = "✓";
            lblItemNameStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePrepTime()
        {
            string value = txtPrepTime.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtPrepTime.BackColor = Color.FromArgb(255, 220, 220);
                lblPrepTimeStatus.Text = "⚠️ Required";
                lblPrepTimeStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    txtPrepTime.BackColor = Color.FromArgb(255, 220, 220);
                    lblPrepTimeStatus.Text = "⚠️ Numbers only";
                    lblPrepTimeStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            int prepTime = int.Parse(value);
            if (prepTime < 1)
            {
                txtPrepTime.BackColor = Color.FromArgb(255, 220, 220);
                lblPrepTimeStatus.Text = "⚠️ Min 1 minute";
                lblPrepTimeStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }
            if (prepTime > 999)
            {
                txtPrepTime.BackColor = Color.FromArgb(255, 220, 220);
                lblPrepTimeStatus.Text = "⚠️ Max 999 minutes";
                lblPrepTimeStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtPrepTime.BackColor = Color.FromArgb(220, 245, 220);
            lblPrepTimeStatus.Text = "✓";
            lblPrepTimeStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool IsFormValid()
        {
            return ValidateItemName() && ValidatePrepTime();
        }

        // ============================================================
        // END OF VALIDATION METHODS
        // ============================================================

        private void frmManageMenuItems_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
            this.txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadMenuItems()
        {
            string query = "SELECT MenuItemID, MenuItemName, SellingPrice, CostToMake, Category, PreparationTime FROM MenuItemsTable";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    originalMenuItemsData = new DataTable();
                    da.Fill(originalMenuItemsData);
                    dgvMenuItems.DataSource = originalMenuItemsData;

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (originalMenuItemsData == null) return;

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvMenuItems.DataSource = originalMenuItemsData;
            }
            else
            {
                DataView dv = originalMenuItemsData.DefaultView;
                dv.RowFilter = $"MenuItemName LIKE '%{searchTerm}%' OR Category LIKE '%{searchTerm}%'";
                dgvMenuItems.DataSource = dv;
            }

            if (dgvMenuItems.Columns.Count > 0)
                dgvMenuItems.Columns[0].Visible = false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ClearFields();
            LoadMenuItems();
        }

        private void ClearFields()
        {
            txtItemName.Text = "";
            numSellingPrice.Value = 0;
            numCostPrice.Value = 0;
            cboCategory.SelectedIndex = -1;
            txtPrepTime.Text = "";
            btnUpdate.Tag = null;
            isAddingWithRecipe = false;
            pendingMenuItemId = -1;

            txtItemName.BackColor = System.Drawing.Color.White;
            txtPrepTime.BackColor = System.Drawing.Color.White;
            lblItemNameStatus.Text = "";
            lblPrepTimeStatus.Text = "";
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

        // ============================================================
        // Check if menu item has at least one recipe
        // ============================================================
        private bool HasRecipe(int menuItemId)
        {
            string query = "SELECT COUNT(*) FROM RecipeTable WHERE MenuItemID = @menuItemId";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@menuItemId", menuItemId);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        // ============================================================
        // Delete menu item (called if user cancels recipe addition)
        // ============================================================
        public void DeletePendingMenuItem()
        {
            if (pendingMenuItemId > 0)
            {
                try
                {
                    string query = "DELETE FROM MenuItemsTable WHERE MenuItemID = @id";
                    using (SqlConnection conn = DbHelper.GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", pendingMenuItemId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    pendingMenuItemId = -1;
                    isAddingWithRecipe = false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error deleting pending menu item: {ex.Message}");
                }
            }
        }

        // ============================================================
        // Save menu item and return the new ID
        // ============================================================
        private int SaveMenuItem()
        {
            string query = @"INSERT INTO MenuItemsTable (MenuItemName, SellingPrice, CostToMake, Category, PreparationTime) 
                              VALUES (@name, @price, @cost, @cat, @prep);
                              SELECT SCOPE_IDENTITY();";
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
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return newId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before adding.\n\n- Name: Letters and spaces only\n- Prep Time: Numbers only (1-999 minutes)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // ============================================================
            // Force user to add a recipe first - Save the item first
            // ============================================================
            DialogResult result = MessageBox.Show(
                "You must add ingredients (recipe) for this menu item.\n\n" +
                "The menu item will be saved temporarily, and you will be taken to\n" +
                "the Manage Recipes form to add ingredients.\n\n" +
                "If you close Manage Recipes without adding any ingredients,\n" +
                "this menu item will be automatically deleted.\n\n" +
                "Do you want to continue?",
                "Recipe Required",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Save the menu item first
                int newId = SaveMenuItem();
                if (newId > 0)
                {
                    pendingMenuItemId = newId;
                    isAddingWithRecipe = true;

                    // Refresh the grid to show the new item
                    LoadMenuItems();

                    // Open Manage Recipes form
                    frmManageRecipes recipesForm = new frmManageRecipes();
                    recipesForm.FormClosed += RecipesForm_FormClosed;
                    recipesForm.Show();
                    this.Hide();
                }
            }
        }

        // ============================================================
        // EVENT HANDLER: When Manage Recipes form closes
        // ============================================================
        private void RecipesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isAddingWithRecipe && pendingMenuItemId > 0)
            {
                // Check if the menu item now has recipes
                if (!HasRecipe(pendingMenuItemId))
                {
                    // No recipe was added - delete the menu item
                    DialogResult result = MessageBox.Show(
                        "No ingredients were added for this menu item.\n\n" +
                        "The menu item will be deleted because it requires at least one ingredient.\n\n" +
                        "Do you want to keep the menu item without ingredients?",
                        "Recipe Not Added",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        // Delete the menu item
                        DeletePendingMenuItem();
                        MessageBox.Show("Menu item has been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // User chose to keep it without recipe
                        MessageBox.Show("Menu item saved without ingredients. This is not recommended.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Menu item added successfully with all ingredients!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reset flags
                isAddingWithRecipe = false;
                pendingMenuItemId = -1;
                LoadMenuItems();
                ClearFields();
                this.Show();
            }
            else
            {
                // Not adding a new item, just show this form again
                this.Show();
            }
        }

        private void dgvMenuItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenuItems.Rows[e.RowIndex];
                DataRowView rowView = row.DataBoundItem as DataRowView;
                if (rowView == null) return;

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

                int menuItemId = Convert.ToInt32(rowView["MenuItemID"]);
                btnUpdate.Tag = menuItemId;

                DataView dv = originalMenuItemsData.DefaultView;
                dv.RowFilter = $"MenuItemID = {menuItemId}";
                dgvMenuItems.DataSource = dv;

                if (dgvMenuItems.Columns.Count > 0)
                    dgvMenuItems.Columns[0].Visible = false;

                txtSearch.Text = "";

                ValidateItemName();
                ValidatePrepTime();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Please select a menu item from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before updating.\n\n- Name: Letters and spaces only\n- Prep Time: Numbers only (1-999 minutes)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Check if the menu item has a recipe before allowing update
            if (!HasRecipe(currentId))
            {
                DialogResult result = MessageBox.Show(
                    "This menu item does not have any ingredients linked to it.\n\n" +
                    "Would you like to add ingredients now?\n\n" +
                    "• Click 'Yes' to go to Manage Recipes\n" +
                    "• Click 'No' to update anyway (not recommended)\n" +
                    "• Click 'Cancel' to cancel updating",
                    "Recipe Required",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Open Manage Recipes form
                    frmManageRecipes recipesForm = new frmManageRecipes();
                    recipesForm.Show();
                    this.Hide();
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Cancel updating
                }
                // If No, continue with updating (user chose to update without recipe)
            }

            // Update the menu item
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
            txtSearch.Text = "";
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
                stepTitle = "📍 Step 1 of 2 — Add a New Menu Item";
                stepDetail =
                    "You haven't selected a menu item to edit.\r\n\r\n" +
                    "➕ ADD NEW MENU ITEM:\r\n" +
                    "• Fill in: Name (LETTERS and SPACES only),\r\n" +
                    "  Selling Price, Cost Price, Category, and Preparation Time (NUMBERS ONLY).\r\n" +
                    "• Click 'Add New' button.\r\n" +
                    "• You MUST add a recipe (ingredients) for this item.\r\n" +
                    "• The menu item will be saved temporarily, then you'll add ingredients.\r\n" +
                    "• If you don't add any ingredients, the menu item will be deleted.\r\n\r\n" +
                    "✏️ EDIT EXISTING MENU ITEM:\r\n" +
                    "• Click any row in the list to select an item.\r\n" +
                    "• Only that item will remain visible.\r\n" +
                    "• Edit the fields as needed.\r\n" +
                    "• Click 'Update' to save changes.\r\n\r\n" +
                    "🔍 SEARCH:\r\n" +
                    "• Type a name or category in the search box.\r\n" +
                    "• Results filter automatically as you type.\r\n" +
                    "• Click 'Clear' to reset search.\r\n\r\n" +
                    "📊 CATEGORIES:\r\n" +
                    "• Burger, Wings, Sides, Drinks, Combo\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all menu item data.\r\n\r\n" +
                    "🗑️ DELETE:\r\n" +
                    "• Select a menu item, then click 'Deactivate'.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }
            else
            {
                stepTitle = "📍 Step 2 of 2 — Update or Delete Menu Item";
                stepDetail =
                    "Menu item selected: " + txtItemName.Text + "\r\n\r\n" +
                    "✏️ TO UPDATE:\r\n" +
                    "• Edit the price, category, or prep time.\r\n" +
                    "• Name must contain only LETTERS and SPACES.\r\n" +
                    "• Prep Time must contain only NUMBERS.\r\n" +
                    "• Click 'Update' to save changes.\r\n" +
                    "• Click 'Refresh' to see all items again.\r\n\r\n" +
                    "🗑️ TO DELETE:\r\n" +
                    "• Click 'Deactivate' button.\r\n" +
                    "• Confirm deletion when prompted.\r\n\r\n" +
                    "🔄 REFRESH:\r\n" +
                    "• Click 'Refresh' to reload all menu item data.\r\n\r\n" +
                    "◀ BACK:\r\n" +
                    "• Returns to the main menu.";
            }

            // ============================================================
            // HELP PANEL — dynamic height, positioned RIGHT of Help button
            // ============================================================

            int panelWidth = 400;
            int padding = 10;

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            pnlHelp.Controls.Clear();

            // Title label
            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(padding, padding);
            lblTitle.Size = new System.Drawing.Size(panelWidth - padding * 2, 30);

            // Detail label — AutoSize so it grows to fit ALL content, never cuts off
            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 9);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(padding, 50);
            lblDetail.MaximumSize = new System.Drawing.Size(panelWidth - padding * 2, 0);
            lblDetail.AutoSize = true;

            // Close button
            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "❓ Help";
            };

            // Add title and detail first so layout can be measured
            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);

            // Force layout so lblDetail.Height is calculated before we use it
            pnlHelp.PerformLayout();
            lblDetail.PerformLayout();

            // Place close button below the detail label with some spacing
            int closeButtonY = lblDetail.Bottom + 10;
            btnClose.Location = new System.Drawing.Point(panelWidth - 110, closeButtonY);

            // Panel height = close button bottom + padding
            int panelHeight = closeButtonY + btnClose.Height + padding;
            pnlHelp.Size = new System.Drawing.Size(panelWidth, panelHeight);
            pnlHelp.Controls.Add(btnClose);

            // ---- Positioning: always to the RIGHT of the Help button ----
            // Convert button's screen position to form client coordinates
            Point btnScreenPos = btnHelp.PointToScreen(Point.Empty);
            Point btnFormPos = this.PointToClient(btnScreenPos);

            int xPos = btnFormPos.X + btnHelp.Width + 5;       // right of button
            int yPos = btnFormPos.Y - (panelHeight / 2);        // vertically centred on button

            // If panel won't fit to the right, flip it to the left
            if (xPos + panelWidth > this.ClientSize.Width - 5)
                xPos = btnFormPos.X - panelWidth - 5;

            // Keep panel within vertical bounds of the form
            if (yPos + panelHeight > this.ClientSize.Height - 5)
                yPos = this.ClientSize.Height - panelHeight - 5;

            if (yPos < 5)
                yPos = 5;

            pnlHelp.Location = new System.Drawing.Point(xPos, yPos);
            pnlHelp.Visible = true;
            pnlHelp.BringToFront();
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