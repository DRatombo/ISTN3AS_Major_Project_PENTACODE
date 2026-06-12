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

        // Status label for Prep Time (add this to your designer or create dynamically)
        private Label lblPrepTimeStatus;

        public frmManageMenuItems()
        {
            InitializeComponent();
            CreatePrepTimeStatusLabel();
            AttachValidationEvents();
        }

        private void CreatePrepTimeStatusLabel()
        {
            // Create status label for Prep Time (positioned below the Prep Time textbox)
            lblPrepTimeStatus = new Label();
            lblPrepTimeStatus.AutoSize = true;
            lblPrepTimeStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblPrepTimeStatus.ForeColor = System.Drawing.Color.White;
            lblPrepTimeStatus.Location = new System.Drawing.Point(120, 172); // Adjust X,Y as needed
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
        // VALIDATION METHODS
        // ============================================================

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            ValidateItemName();
        }

        private void txtPrepTime_TextChanged(object sender, EventArgs e)
        {
            ValidatePrepTime();
        }

        // Prevent non-digit characters from being entered
        private void txtPrepTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and control characters
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateItemName()
        {
            string value = txtItemName.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtItemName.BackColor = Color.FromArgb(255, 220, 220);
                lblItemNameStatus.Text = "⚠️ Required";
                lblItemNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            // Check for letters only (no spaces, no numbers, no special characters)
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    txtItemName.BackColor = Color.FromArgb(255, 220, 220);
                    lblItemNameStatus.Text = "⚠️ Letters only";
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

            // Check for numbers only
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

            // Optional: Check for reasonable range (e.g., 1-999 minutes)
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

            // Reset validation colors and status labels
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before adding.\n\n- Name: Letters only (no spaces, numbers, or special characters)\n- Prep Time: Numbers only (1-999 minutes)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Trigger validation on loaded data
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
                MessageBox.Show("Please correct the highlighted fields before updating.\n\n- Name: Letters only (no spaces, numbers, or special characters)\n- Prep Time: Numbers only (1-999 minutes)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (btnUpdate.Tag == null)
            {
                stepTitle = "📍 Step 1 of 2 — Add a New Menu Item";
                stepDetail =
                    "You haven't selected a menu item to edit.\r\n\r\n" +
                    "➕ ADD NEW MENU ITEM:\r\n" +
                    "• Fill in: Name (LETTERS ONLY - no spaces, numbers, or special characters),\r\n" +
                    "  Selling Price, Cost Price, Category, and Preparation Time (NUMBERS ONLY).\r\n" +
                    "• Click 'Add New' button.\r\n\r\n" +
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
                    "• Name must contain only LETTERS (no spaces, numbers, or special characters).\r\n" +
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

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(370, 380);
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
            lblDetail.Size = new System.Drawing.Size(350, 280);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.Location = new System.Drawing.Point(255, 340);
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

            int xPos = btnHelp.Left + btnHelp.Width + 5;
            int yPos = btnHelp.Top - 10;

            if (xPos + pnlHelp.Width > this.ClientSize.Width)
            {
                xPos = btnHelp.Left - pnlHelp.Width - 5;
            }

            if (yPos + pnlHelp.Height > this.ClientSize.Height)
            {
                yPos = this.ClientSize.Height - pnlHelp.Height - 10;
            }

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
   /* public static class DbHelper
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