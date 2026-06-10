using Cafe101.dsCafe101HubTableAdapters;
using Cafe101.dsCafe101TestTableAdapters;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmNewOrder : Form
    {
        // Global variables
        private int selectedCustomerID = 0; // Stores the selected customer's ID
        private decimal orderTotal = 0; // Keeps track of the running order total
        private bool suppressCustomerSearch = false; // Flag to prevent search logic during programmatic changes    

        public frmNewOrder()
        {
            InitializeComponent();
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Hub.MenuItemsTable' table. You can move, or remove it, as needed.
            this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
            // TODO: This line of code loads data into the 'dsCafe101Hub.CustomerTable' table. You can move, or remove it, as needed.
            this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);
            // TODO: This line of code loads data into the 'dsCafe101Test.TestOrder' table. You can move, or remove it, as needed.
            this.testOrderTableAdapter.Fill(this.dsCafe101Test.TestOrder);
            // TODO: This line of code loads data into the 'dsCafe101Test.TestMenuItems' table. You can move, or remove it, as needed.
            //this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
            this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
            // TODO: This line of code loads data into the 'dsCafe101Test.TestCustomer' table. You can move, or remove it, as needed.
           // this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

            this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);

           // dgvCustomers.DataSource = dsCafe101Hub.CustomerTable;

           /* dgvCustomers.DataSource = dsCafe101Hub.CustomerTable;
            dgvCustomers.Columns["CustomerID"].Visible = false;
            dgvCustomers.Columns["CustomerID"].Visible = false;
            dgvCustomers.Columns["FirstName"].Width = 100;
            dgvCustomers.Columns["Surname"].Width = 100;*/

            dgvMenuItems.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvMenuItems.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvMenuItems.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvMenuItems.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvMenuItems.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvMenuItems.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvCustomers.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomers.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvCustomers.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomers.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            dgvMenuItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;


            dgvCart.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCart.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvCart.BackgroundColor = System.Drawing.Color.FromArgb(13, 27, 62);
            dgvCart.GridColor = System.Drawing.Color.FromArgb(13, 27, 62);
            dgvCart.BorderStyle = BorderStyle.None;

            dgvCustomers.Visible = true;
            txtSearchedName.ReadOnly = true;

            dgvMenuItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           // dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMenuItems.BackgroundColor = System.Drawing.Color.FromArgb(13, 27, 62);
            dgvCart.BackgroundColor = System.Drawing.Color.FromArgb(13, 27, 62);
            dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(13, 27, 62);

            try
            {
                // Setup cart columns manually - cart is not bound to database
                dgvCart.Columns.Clear();
                dgvCart.Columns.Add("MenuItemID", "MenuItemID");
                dgvCart.Columns.Add("ItemName", "Item");
                dgvCart.Columns.Add("Qty", "Quantity");
                dgvCart.Columns.Add("Price", "Price");
                dgvCart.Columns.Add("Subtotal", "Subtotal");
                dgvCart.Columns["MenuItemID"].Visible = false; // Hide ID column from user

                dgvCart.ReadOnly = true;
                dgvCart.AllowUserToAddRows = false;
                dgvCart.AllowUserToDeleteRows = false;

                cmbOrderType.SelectedIndex = 0; // Default to Regular
                dtpEventDate.Visible = false;
                dtpEventTime.Visible = false;
                lblEventDate.Visible = false;
                lblEventTime.Visible = false;


                // Load all menu items from database into the grid
              /*  this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
                dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;*/

                this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                dgvMenuItems.DataSource = this.dsCafe101Hub.MenuItemsTable;

                RebuildQtyColumn();

                // Reset total label
                lblAmount.Text = "R0.00";

                // Handle the DataError event to suppress combobox errors
                dgvMenuItems.DataError += (s, ev) => { ev.Cancel = true; };

                // Set default quantity to 1 for all rows after data loads
              /*  foreach (DataGridViewRow row in dgvMenuItems.Rows)
                {
                    if (!row.IsNewRow)
                        // Default quantity is 1 - user can change via dropdown
                        row.Cells["ItemQty"].Value = 1;
                }*/
      

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the form: " + ex.Message);
            }
        }

        private void RebuildQtyColumn()
        {
            if (dgvMenuItems.Columns.Contains("ItemQty"))
                dgvMenuItems.Columns.Remove("ItemQty");

            var qtyCol = new DataGridViewComboBoxColumn();
            qtyCol.Name = "ItemQty";
            qtyCol.HeaderText = "Quantity";
            qtyCol.Width = 80;
            qtyCol.ValueType = typeof(string);
            dgvMenuItems.Columns.Add(qtyCol);

           /* DataTable recipes = testRecipeTableAdapter1.GetData();
            DataTable ingredients = testIngredientTableAdapter1.GetData();
*/
            DataTable recipes = recipeTableTableAdapter1.GetData();
            DataTable ingredients = ingredientTableTableAdapter1.GetData();

            foreach (DataGridViewRow row in dgvMenuItems.Rows)
            {
                if (row.IsNewRow) continue;

                var cell = row.Cells["ItemQty"] as DataGridViewComboBoxCell;

                int menuItemID = Convert.ToInt32(row.Cells[0].Value);
                int maxCanMake = int.MaxValue;
                bool hasRecipe = false;

                foreach (DataRow recipe in recipes.Rows)
                {
                    // Skip if any value is null
                    if (recipe["MenuItemID"] == DBNull.Value ||
                        recipe["IngredientID"] == DBNull.Value ||
                        recipe["QuantityNeeded"] == DBNull.Value) continue;

                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    hasRecipe = true;
                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);

                    if (quantityNeeded <= 0) continue;

                    foreach (DataRow ingredient in ingredients.Rows)
                    {
                        if (ingredient["IngredientID"] == DBNull.Value ||
                            ingredient["QuantityOnHand"] == DBNull.Value) continue;

                        if (Convert.ToInt32(ingredient["IngredientID"]) != ingredientID) continue;

                        int onHand = Convert.ToInt32(ingredient["QuantityOnHand"]);
                        int canMake = onHand / quantityNeeded;
                        if (canMake < maxCanMake)
                            maxCanMake = canMake;
                    }
                }

                cell.Items.Clear();

                if (!hasRecipe || maxCanMake == int.MaxValue || maxCanMake <= 0)
                {
                    cell.Items.Add("Out of stock");
                    cell.Value = "Out of stock";
                }
                else
                {
                    for (int i = 1; i <= maxCanMake; i++)
                        cell.Items.Add(i.ToString());
                    cell.Value = null;
                }
            }
        }
        private void btnSearchCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearchedCust.Text))
                {
                    MessageBox.Show("Please enter a customer name to search for.");
                    return;
                }

              //  this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);
              this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable); 

                var results = this.dsCafe101Hub.CustomerTable.Where(c =>
                    c.FirstName.ToLower().Contains(txtSearchedCust.Text.ToLower()) ||
                    c.Surname.ToLower().Contains(txtSearchedCust.Text.ToLower()));

                /*var results = this.dsCafe101Test.TestCustomer.Where(c =>
                    c.FirstName.ToLower().Contains(txtSearchedCust.Text.ToLower()) ||
                    c.Surname.ToLower().Contains(txtSearchedCust.Text.ToLower()));*/

                if (results.Any())
                {
                    var customer = results.First();
                    selectedCustomerID = customer.CustomerID;
                    txtSearchedName.Text = customer.FirstName + " " + customer.Surname;
                    suppressCustomerSearch = true;
                    dgvCustomers.DataSource = null;
                    dgvCustomers.Visible = false;
                    suppressCustomerSearch = false;

                    // Hide grid once customer is selected
                    dgvCustomers.DataSource = null;
                    dgvCustomers.Visible = false;
                }
                else
                {
                    // Show grid with all customers so cashier can browse
/*                    dgvCustomers.DataSource = this.dsCafe101Test.TestCustomer;
 */                 dgvCustomers.DataSource = this.dsCafe101Hub.CustomerTable;
                    dgvCustomers.Visible = true;

                    DialogResult result = MessageBox.Show(
                        "Customer not found. Do you want to create a new customer?",
                        "Customer Not Found",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        frmAddCustomer addCust = new frmAddCustomer();
                        addCust.ShowDialog();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the customer: " + ex.Message);
            }
        }
        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            try
            {
                // If search box is empty - show all menu items
                if (string.IsNullOrWhiteSpace(textItemSearch.Text))
                {
                    /*this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
                    dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;*/

                    this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                    dgvMenuItems.DataSource = this.dsCafe101Hub.MenuItemsTable;
                     RebuildQtyColumn();
                    return;
                }

                // Use the FillByMenuItem query to filter by name
                /*this.testMenuItemsTableAdapter.FillByMenuItems(this.dsCafe101Test.TestMenuItems, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;*/

                this.menuItemsTableTableAdapter.FillByMenuItems(this.dsCafe101Hub.MenuItemsTable, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101Hub.MenuItemsTable; 

                // Reset quantity dropdown to 1 after search
                foreach (DataGridViewRow row in dgvMenuItems.Rows)
                {
                    if (!row.IsNewRow)
                        row.Cells["ItemQty"].Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching menu items: " + ex.Message);
            }
        }

        /* private void txtSearchedCust_TextChanged(object sender, EventArgs e)
         {
             if (string.IsNullOrWhiteSpace(txtSearchedCust.Text))
             {
                 dgvCustomers.DataSource = null;
                 dgvCustomers.Visible = false;
                 return;
             }

             try
             {
                 this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

                 string search = txtSearchedCust.Text.ToLower();

                 DataTable dt = new DataTable();
                 dt.Columns.Add("CustomerID", typeof(int));
                 dt.Columns.Add("FirstName", typeof(string));
                 dt.Columns.Add("Surname", typeof(string));
                 dt.Columns.Add("Email", typeof(string));

                 foreach (DataRow row in this.dsCafe101Test.TestCustomer.Rows)
                 {
                     if (row.RowState == DataRowState.Deleted ||
                         row.RowState == DataRowState.Detached) continue;

                     string fn = row["FirstName"].ToString().ToLower();
                     string sn = row["Surname"].ToString().ToLower();

                     if (fn.Contains(search) || sn.Contains(search))
                     {
                         dt.Rows.Add(row["CustomerID"], row["FirstName"], row["Surname"], row["Email"]);
                     }
                 }

                 dgvCustomers.DataSource = null;
                 dgvCustomers.DataSource = dt;

                 // Hide CustomerID column from user but keep it accessible
                 dgvCustomers.Columns["CustomerID"].Visible = false;

                 dgvCustomers.Visible = dt.Rows.Count > 0;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Search error: " + ex.Message);
             }
         }

        */
         private void btnAddToCart_Click(object sender, EventArgs e)
         {
             try
             {
                 if (selectedCustomerID == 0)
                 {
                     MessageBox.Show("Please select a customer before adding items to the cart.");
                     return;
                 }

                 if (dgvMenuItems.SelectedRows.Count == 0)
                 {
                     MessageBox.Show("Please select an item to order.");
                     return;
                 }

                 int menuItemID = Convert.ToInt32(dgvMenuItems.SelectedRows[0].Cells["MenuItemID"].Value);
                 string itemName = dgvMenuItems.SelectedRows[0].Cells["MenuItemName"].Value.ToString();
                 string priceStr = dgvMenuItems.SelectedRows[0].Cells["SellingPrice"].Value.ToString()
                     .Replace(",", ".").Trim();
                 decimal price = decimal.Parse(priceStr, System.Globalization.CultureInfo.InvariantCulture);

                 string qtyRaw = dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value?.ToString() ?? "";
                 if (string.IsNullOrEmpty(qtyRaw) || qtyRaw == "0" || qtyRaw == "Out of stock")
                 {
                     MessageBox.Show("Please select a quantity first.");
                     return;
                 }

                 int quantity = Convert.ToInt32(qtyRaw);

                 // ── Calculate max stock for this item ──────────────────────────
                 DataTable recipes = recipeTableTableAdapter1.GetData();
                 DataTable ingredients = ingredientTableTableAdapter1.GetData();
                 int maxCanMake = int.MaxValue;

                 foreach (DataRow recipe in recipes.Rows)
                 {
                     if (recipe["MenuItemID"] == DBNull.Value ||
                         recipe["IngredientID"] == DBNull.Value ||
                         recipe["QuantityNeeded"] == DBNull.Value) continue;
                     if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                     int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                     int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                     if (quantityNeeded <= 0) continue;

                     foreach (DataRow ingredient in ingredients.Rows)
                     {
                         if (ingredient["IngredientID"] == DBNull.Value ||
                             ingredient["QuantityOnHand"] == DBNull.Value) continue;
                         if (Convert.ToInt32(ingredient["IngredientID"]) != ingredientID) continue;

                         int onHand = Convert.ToInt32(ingredient["QuantityOnHand"]);
                         int canMake = onHand / quantityNeeded;
                         if (canMake < maxCanMake) maxCanMake = canMake;
                     }
                 }

                 if (maxCanMake == int.MaxValue) maxCanMake = 0;

                 // ── Add to cart or update existing ────────────────────────────
                 int newCartQty = quantity;

                 foreach (DataGridViewRow row in dgvCart.Rows)
                 {
                     if (row.Cells["MenuItemID"].Value == null) continue;
                     if (Convert.ToInt32(row.Cells["MenuItemID"].Value) == menuItemID)
                     {
                         int existingQty = Convert.ToInt32(row.Cells["Qty"].Value);
                         newCartQty = existingQty + quantity;
                         decimal newSubtotal = newCartQty * price;
                         row.Cells["Qty"].Value = newCartQty;
                         row.Cells["Subtotal"].Value = "R " + newSubtotal.ToString("0.00");
                         orderTotal += quantity * price;
                         lblAmount.Text = "R " + orderTotal.ToString("0.00");

                         // Update dropdown for existing item
                         UpdateDropdown(menuItemID, maxCanMake, newCartQty);
                         return;
                     }
                 }

                 // New row
                 dgvCart.Rows.Add(
                     menuItemID,
                     itemName,
                     quantity,
                     "R " + price.ToString("0.00"),
                     "R " + (quantity * price).ToString("0.00"));

                 orderTotal += quantity * price;
                 lblAmount.Text = "R " + orderTotal.ToString("0.00");

                 // Update dropdown for new item
                 UpdateDropdown(menuItemID, maxCanMake, newCartQty);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error adding to cart: " + ex.Message);
             }
         }
 

        private void txtSearchedCust_TextChanged(object sender, EventArgs e)
        {
            /* try
             {
                 this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);

                 DataTable dt = new DataTable();
                 dt.Columns.Add("CustomerID", typeof(int));
                 dt.Columns.Add("FirstName", typeof(string));
                 dt.Columns.Add("Surname", typeof(string));
                 dt.Columns.Add("Address", typeof(string));
                 dt.Columns.Add("Email", typeof(string));

                 string search = txtSearchedCust.Text.ToLower();

                 foreach (DataRow row in this.dsCafe101Hub.CustomerTable.Rows)
                 {
                     if (row.RowState == DataRowState.Deleted ||
                         row.RowState == DataRowState.Detached) continue;

                     string fn = row["FirstName"].ToString().ToLower();
                     string sn = row["Surname"].ToString().ToLower();

                     if (string.IsNullOrWhiteSpace(search) ||
                         fn.Contains(search) || sn.Contains(search))
                     {
                         dt.Rows.Add(
                             row["CustomerID"],
                             row["FirstName"],
                             row["Surname"],
                             row["Address"],
                             row["Email"]);
                     }
                 }

                 dgvCustomers.DataSource = null;
                 dgvCustomers.DataSource = dt;

                 // Hide and size columns after DataSource is set
                 if (dgvCustomers.Columns.Contains("CustomerID"))
                     dgvCustomers.Columns["CustomerID"].Visible = false;

                 dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                 dgvCustomers.Columns["FirstName"].Width = 110;
                 dgvCustomers.Columns["Surname"].Width = 110;
                 dgvCustomers.Columns["Email"].Width = 180;
                 dgvCustomers.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                 dgvCustomers.Visible = true;

                 if (string.IsNullOrWhiteSpace(txtSearchedCust.Text))
                 {
                     customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);

                     dgvCustomers.DataSource = dsCafe101Hub.CustomerTable;
                     dgvCustomers.Visible = true;
                     return;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Search error: " + ex.Message);
             }*/

            if (suppressCustomerSearch) return;
            PopulateCustomerGrid(txtSearchedCust.Text.ToLower());
        }


        private void UpdateDropdown(int menuItemID, int maxCanMake, int alreadyInCart)
        {
            foreach (DataGridViewRow menuRow in dgvMenuItems.Rows)
            {
                if (menuRow.IsNewRow) continue;
                if (Convert.ToInt32(menuRow.Cells[0].Value) != menuItemID) continue;

                var cell = menuRow.Cells["ItemQty"] as DataGridViewComboBoxCell;
                cell.Items.Clear();

                int remaining = maxCanMake - alreadyInCart;

                if (remaining <= 0)
                {
                    cell.Items.Add("Out of stock");
                    cell.Value = "Out of stock";
                }
                else
                {
                    for (int i = 1; i <= remaining; i++)
                        cell.Items.Add(i.ToString());
                    cell.Value = null;
                }
                break;
            }
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item in the cart first.");
                return;
            }

            DataGridViewRow row = dgvCart.SelectedRows[0];
            int removedMenuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
            int currentQty = Convert.ToInt32(row.Cells["Qty"].Value);
            decimal price = decimal.Parse(
                row.Cells["Price"].Value.ToString().Replace("R", "").Replace(" ", "").Trim(),
                System.Globalization.CultureInfo.InvariantCulture);

            if (currentQty <= 1)
            {
                orderTotal -= price;
                if (orderTotal < 0) orderTotal = 0;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");
                dgvCart.Rows.Remove(row);
                btnClearCustName.Enabled = dgvCart.Rows.Count > 0;
                RebuildQtyColumnWithCart();
            }
            else
            {
                int newQty = currentQty - 1;
                decimal newSubtotal = newQty * price;
                row.Cells["Qty"].Value = newQty;
                row.Cells["Subtotal"].Value = "R " + newSubtotal.ToString("0.00");
                orderTotal -= price;
                if (orderTotal < 0) orderTotal = 0;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");
                RebuildQtyColumnWithCart();
            }
        }

        private void btnRemoveItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item in the cart first.");
                return;
            }

            DataGridViewRow row = dgvCart.SelectedRows[0];
            int removedMenuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
            decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString().Replace("R ", "").Trim());

            orderTotal -= subtotal;
            if (orderTotal < 0) orderTotal = 0;
            lblAmount.Text = "R " + orderTotal.ToString("0.00");

             dgvCart.Rows.Remove(row);

              // Reset the quantity dropdown in dgvMenuItems for this item
              foreach (DataGridViewRow menuRow in dgvMenuItems.Rows)
              {
                  if (menuRow.IsNewRow) continue;
                  if (Convert.ToInt32(menuRow.Cells[0].Value) == removedMenuItemID)
                  {
                      menuRow.Cells["ItemQty"].Value = null;
                      break;
                  }
              }

            dgvCart.Rows.Remove(row);
            RebuildQtyColumnWithCart();
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomerID == 0)
                {
                    MessageBox.Show("Please select a customer before confirming.");
                    return;
                }

                int itemCount = 0;
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["MenuItemID"].Value != null)
                        itemCount++;
                }

                if (itemCount == 0)
                {
                    MessageBox.Show("The cart is empty. Please add items.");
                    return;
                }

                if (!CheckStock())
                    return;


                if (cmbOrderType.SelectedItem.ToString() == "Event")
                {
                    DateTime eventDateTime = dtpEventDate.Value.Date + dtpEventTime.Value.TimeOfDay;
                    if (eventDateTime <= DateTime.Now)
                    {
                        MessageBox.Show(
                            "Event date and time must be in the future.\nPlease select a valid upcoming date and time.",
                            "Invalid Event Date",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Replace the orderTableTableAdapter1.SaveOrder(...) or Insert(...) call
                // with this direct SQL approach

                int newOrderID = 0;

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                    orderTableTableAdapter1.Connection.ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO OrderTable 
                        (CustomerID, EmployeeID, OrderType, OrderDateTime, EventDate, EventTime, 
                         OrderStatus, PaymentMethod, TotalAmountDue, TotalChangeDue)
                        VALUES 
                        (@CustomerID, @EmployeeID, @OrderType, @OrderDateTime, @EventDate, @EventTime,
                         @OrderStatus, @PaymentMethod, @TotalAmountDue, @TotalChangeDue)
                        SELECT SCOPE_IDENTITY()";

                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID);
                        cmd.Parameters.AddWithValue("@EmployeeID", 1);
                        cmd.Parameters.AddWithValue("@OrderType", cmbOrderType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@OrderDateTime", DateTime.Now);

                        if (cmbOrderType.SelectedItem.ToString() == "Event")
                        {
                            cmd.Parameters.AddWithValue("@EventDate", dtpEventDate.Value.Date);
                            cmd.Parameters.AddWithValue("@EventTime", dtpEventDate.Value.TimeOfDay);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EventDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@EventTime", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                        cmd.Parameters.AddWithValue("@PaymentMethod", "Cash");
                        cmd.Parameters.AddWithValue("@TotalAmountDue", orderTotal);
                        cmd.Parameters.AddWithValue("@TotalChangeDue", 0m);

                        object result = cmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Order could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        newOrderID = Convert.ToInt32(result);
                    }
                }

                if (newOrderID <= 0)
                {
                    MessageBox.Show("Order saved but ID could not be retrieved.", "Warning");
                    return;
                }
                // Insert each cart item into ItemOrder table
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["MenuItemID"].Value == null) continue;

                    int menuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString().Replace("R ", "").Trim());

                    try
                    {
                        orderItemTableTableAdapter1.InsertItemOrder(newOrderID, menuItemID, qty, subtotal);
                    }
                    catch (Exception exItem)
                    {
                        MessageBox.Show("OrderItem insert failed: " + exItem.Message + "\nOrderID=" + newOrderID + " MenuItemID=" + menuItemID);
                        return;
                    }
                }

                DeductStock();
                MessageBox.Show("Order #" + newOrderID + " saved successfully!\nTotal: R " + orderTotal.ToString("0.00") + "\nHandling payment in Checkout...");

                // Uncomment when frmCheckout is ready

                frmCheckout checkout = new frmCheckout(newOrderID, orderTotal);
                checkout.Owner = this;
                checkout.ShowDialog();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming order: " + ex.Message);
            }
        }


        public void ResetOrder()
        {
            dgvCart.Rows.Clear();
            orderTotal = 0;
            lblAmount.Text = "R0.00";

            selectedCustomerID = 0;
            txtSearchedCust.Text = "";
            txtSearchedName.Text = "";
        }

        private bool CheckStock()
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["MenuItemID"].Value == null) continue;

                int menuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
                int qtyOrdered = Convert.ToInt32(row.Cells["Qty"].Value);

                DataTable allRecipes = recipeTableTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                    int amountNeeded = quantityNeeded * qtyOrdered;

                    DataTable allStock = ingredientTableTableAdapter1.GetData();

                    foreach (DataRow stockRow in allStock.Rows)
                    {
                        if (Convert.ToInt32(stockRow["IngredientID"]) != ingredientID) continue;

                        int quantityOnHand = Convert.ToInt32(stockRow["QuantityOnHand"]);

                        if (quantityOnHand < amountNeeded)
                        {
                            string itemName = row.Cells["ItemName"].Value.ToString();
                            MessageBox.Show(
                                "Not enough stock to complete this order.\n" +
                                "Item: " + itemName + "\n" +
                                "Required: " + amountNeeded + "\n" +
                                "In Stock: " + quantityOnHand,
                                "Insufficient Stock",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void DeductStock()
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["MenuItemID"].Value == null) continue;

                int menuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
                int qtyOrdered = Convert.ToInt32(row.Cells["Qty"].Value);

                DataTable allRecipes = recipeTableTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                    int amountToDeduct = quantityNeeded * qtyOrdered;

                    ingredientTableTableAdapter1.DeductStock(amountToDeduct, ingredientID);
                }
            }
        }

        private int GetNewOrderID()
        {
            int orderID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(orderTableTableAdapter1.Connection.ConnectionString))
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT MAX(OrderID) FROM OrderTable", conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    orderID = Convert.ToInt32(result);
            }
            return orderID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmMain backMain = new frmMain();
            backMain.Show();    
            this.Hide();    
        }

        private void dgvMenuItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain backMain = new frmMain();
            backMain.Show();
            this.Hide();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                // Use column name not index since we built the DataTable with named columns
                object idVal = dgvCustomers.Rows[e.RowIndex].Cells["CustomerID"].Value;
                object firstVal = dgvCustomers.Rows[e.RowIndex].Cells["FirstName"].Value;
                object surnameVal = dgvCustomers.Rows[e.RowIndex].Cells["Surname"].Value;

                if (idVal == null || idVal == DBNull.Value) return;

                selectedCustomerID = Convert.ToInt32(idVal);
                txtSearchedName.Text = firstVal.ToString() + " " + surnameVal.ToString();

                suppressCustomerSearch = true;
                dgvCustomers.DataSource = null;
                dgvCustomers.Visible = false;
                txtSearchedCust.Text = "";
                suppressCustomerSearch = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting customer: " + ex.Message);
            }
        }

        private void textItemSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textItemSearch.Text))
                {
                    this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                    dgvMenuItems.DataSource = this.dsCafe101Hub.MenuItemsTable;
                    RebuildQtyColumn();
                    return;
                }

                this.menuItemsTableTableAdapter.FillByMenuItems(this.dsCafe101Hub.MenuItemsTable, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101Hub.MenuItemsTable;
                RebuildQtyColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering menu items: " + ex.Message);
            }
        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderType.SelectedItem.ToString() == "Event")
            {
                dtpEventDate.Visible = true;
                dtpEventTime.Visible = true;
                lblEventDate.Visible = true;
                lblEventTime.Visible = true;
            }
            else
            {
                dtpEventDate.Visible = false;
                dtpEventTime.Visible = false;
                lblEventDate.Visible = false;
                lblEventTime.Visible = false;
            }
        }
        private void btnClearCustName_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                MessageBox.Show("Cannot change customer while items are in the cart.\nUse Cancel Order to start over.");
                return;
            }
            suppressCustomerSearch = true;
            selectedCustomerID = 0;
            txtSearchedName.Text = "";
            txtSearchedCust.Text = "";
            suppressCustomerSearch = false;
            PopulateCustomerGrid("");
        }


        private void RebuildQtyColumnWithCart()
        {
            if (dgvMenuItems.Columns.Contains("ItemQty"))
                dgvMenuItems.Columns.Remove("ItemQty");

            var qtyCol = new DataGridViewComboBoxColumn();
            qtyCol.Name = "ItemQty";
            qtyCol.HeaderText = "Quantity";
            qtyCol.Width = 80;
            qtyCol.ValueType = typeof(string);
            dgvMenuItems.Columns.Add(qtyCol);

            DataTable recipes = recipeTableTableAdapter1.GetData();
            DataTable ingredients = ingredientTableTableAdapter1.GetData();

            foreach (DataGridViewRow row in dgvMenuItems.Rows)
            {
                if (row.IsNewRow) continue;

                var cell = row.Cells["ItemQty"] as DataGridViewComboBoxCell;
                int menuItemID = Convert.ToInt32(row.Cells[0].Value);
                int maxCanMake = int.MaxValue;
                bool hasRecipe = false;

                foreach (DataRow recipe in recipes.Rows)
                {
                    if (recipe["MenuItemID"] == DBNull.Value ||
                        recipe["IngredientID"] == DBNull.Value ||
                        recipe["QuantityNeeded"] == DBNull.Value) continue;
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    hasRecipe = true;
                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                    if (quantityNeeded <= 0) continue;

                    foreach (DataRow ingredient in ingredients.Rows)
                    {
                        if (ingredient["IngredientID"] == DBNull.Value ||
                            ingredient["QuantityOnHand"] == DBNull.Value) continue;
                        if (Convert.ToInt32(ingredient["IngredientID"]) != ingredientID) continue;

                        int onHand = Convert.ToInt32(ingredient["QuantityOnHand"]);
                        int canMake = onHand / quantityNeeded;
                        if (canMake < maxCanMake) maxCanMake = canMake;
                    }
                }

                if (maxCanMake == int.MaxValue || !hasRecipe) maxCanMake = 0;

                // Subtract what's already in the cart for this item
                int inCart = 0;
                foreach (DataGridViewRow cartRow in dgvCart.Rows)
                {
                    if (cartRow.Cells["MenuItemID"].Value == null) continue;
                    if (Convert.ToInt32(cartRow.Cells["MenuItemID"].Value) == menuItemID)
                    {
                        inCart = Convert.ToInt32(cartRow.Cells["Qty"].Value);
                        break;
                    }
                }

                int remaining = maxCanMake - inCart;

                cell.Items.Clear();
                if (remaining <= 0)
                {
                    cell.Items.Add("Out of stock");
                    cell.Value = "Out of stock";
                }
                else
                {
                    for (int i = 1; i <= remaining; i++)
                        cell.Items.Add(i.ToString());
                    cell.Value = null;
                }
            }
        }


        private bool helpVisible = false;
        private Panel pnlHelp;

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
                return;
            }

            // --- Detect current step ---
            string stepTitle;
            string stepDetail;

            if (selectedCustomerID == 0)
            {
                stepTitle = "📍 Step 1 of 3 — Select a Customer";
                stepDetail =
                    "You haven't selected a customer yet.\r\n\r\n" +
                    "• Type a name in the Search Customer box\r\n" +
                    "  and press Search.\r\n\r\n" +
                    "• Or click any row in the customer list\r\n" +
                    "  to select them directly.\r\n\r\n" +
                    "• If the customer isn't in the system,\r\n" +
                    "  click Add New Customer to register them.\r\n\r\n" +
                    "💡 You cannot add items to the cart until\r\n" +
                    "   a customer is selected.";
            }
            else if (dgvCart.Rows.Count == 0)
            {
                string custName = txtSearchedName.Text;
                stepTitle = "📍 Step 2 of 3 — Build the Order";
                stepDetail =
                    "Customer: " + custName + " ✔\r\n\r\n" +
                    "Now add items to the cart:\r\n\r\n" +
                    "• Use Search Menu Item to filter items.\r\n\r\n" +
                    "• Click a row to select an item, then\r\n" +
                    "  choose a quantity from the dropdown\r\n" +
                    "  in the Quantity column.\r\n\r\n" +
                    "• Press Add To Cart to add it.\r\n\r\n" +
                    "• Quantities shown = max you can make\r\n" +
                    "  based on current stock levels.\r\n\r\n" +
                    "💡 Items showing '0' or 'Out of stock'\r\n" +
                    "   cannot be ordered.";
            }
            else
            {
                string orderType = cmbOrderType.SelectedItem?.ToString() ?? "Regular";
                stepTitle = "📍 Step 3 of 3 — Confirm the Order";
                stepDetail =
                    "Cart has " + dgvCart.Rows.Count + " item(s). Total: " + lblAmount.Text + "\r\n\r\n" +
                    "• To adjust: select a cart row and\r\n" +
                    "  use Decrease Quantity or Remove Item.\r\n\r\n" +
                    "• Order Type is set to: " + orderType + "\r\n" +
                    (orderType == "Event"
                        ? "  ➤ Set a future Event Date and Time.\r\n\r\n"
                        : "  ➤ Regular orders process immediately.\r\n\r\n") +
                    "• Press Confirm Order when ready.\r\n\r\n" +
                    "💡 Stock is deducted automatically\r\n" +
                    "   when the order is confirmed.";
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(330, 340);
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            // Clear and rebuild contents each time (context may have changed)
            pnlHelp.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(310, 25);

            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 9);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(10, 42);
            lblDetail.Size = new System.Drawing.Size(305, 260);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 28);
            btnClose.Location = new System.Drawing.Point(220, 302);
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
            };

            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            pnlHelp.Location = new System.Drawing.Point(
                btnHelp.Left,
                btnHelp.Top - pnlHelp.Height - 5);

            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "? Help (ON)";
        }

        private void btnAddNewCust_Click(object sender, EventArgs e)
        {
            frmAddCustomer newCust = new frmAddCustomer();
            newCust.ShowDialog();
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0 && selectedCustomerID == 0) return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel this order?\nAll cart items will be cleared.",
                "Cancel Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                dgvCart.Rows.Clear();
                orderTotal = 0;
                lblAmount.Text = "R0.00";
                selectedCustomerID = 0;
                txtSearchedName.Text = "";
                txtSearchedCust.Text = "";
                btnClearCustName.Enabled = true;
                RebuildQtyColumnWithCart();
                PopulateCustomerGrid("");
            }
        }

        private void PopulateCustomerGrid(string search)
        {
            try
            {
                this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);

                DataTable dt = new DataTable();
                dt.Columns.Add("CustomerID", typeof(int));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("Surname", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                foreach (DataRow row in this.dsCafe101Hub.CustomerTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted ||
                        row.RowState == DataRowState.Detached) continue;

                    string fn = row["FirstName"].ToString().ToLower();
                    string sn = row["Surname"].ToString().ToLower();

                    if (string.IsNullOrWhiteSpace(search) ||
                        fn.Contains(search) || sn.Contains(search))
                    {
                        dt.Rows.Add(
                             row["CustomerID"],
                             row["FirstName"],
                             row["Surname"],
                             row.Table.Columns.Contains("Address") ? row["Address"] : "",
                             row["Email"]);
                    }
                }

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = dt;
                dgvCustomers.AllowUserToAddRows = false;
                dgvCustomers.AllowUserToDeleteRows = false;

                dgvCustomers.EnableHeadersVisualStyles = false;
                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvCustomers.Columns.Contains("CustomerID"))
                {
                    dgvCustomers.Columns["CustomerID"].Visible = false;
                    dgvCustomers.Columns["CustomerID"].FillWeight = 1;
                }
                if (dgvCustomers.Columns.Contains("FirstName"))
                    dgvCustomers.Columns["FirstName"].FillWeight = 22;
                if (dgvCustomers.Columns.Contains("Surname"))
                    dgvCustomers.Columns["Surname"].FillWeight = 22;
                if (dgvCustomers.Columns.Contains("Address"))
                    dgvCustomers.Columns["Address"].FillWeight = 30;
                if (dgvCustomers.Columns.Contains("Email"))
                    dgvCustomers.Columns["Email"].FillWeight = 25;

                dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(13, 27, 62);
                dgvCustomers.GridColor = System.Drawing.Color.FromArgb(30, 50, 100);
                dgvCustomers.BorderStyle = BorderStyle.None;
                dgvCustomers.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvCustomers.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomers.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvCustomers.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 255);
                dgvCustomers.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                dgvCustomers.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n\nStack:\n" + ex.StackTrace);
            }
            /* catch (Exception ex)
             {
                 MessageBox.Show("Error loading customers: " + ex.Message);
             }*/
        }
    }
    
}