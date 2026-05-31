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

        public frmNewOrder()
        {
            InitializeComponent();
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Test.TestOrder' table. You can move, or remove it, as needed.
            this.testOrderTableAdapter.Fill(this.dsCafe101Test.TestOrder);
            // TODO: This line of code loads data into the 'dsCafe101Test.TestMenuItems' table. You can move, or remove it, as needed.
            this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
            // TODO: This line of code loads data into the 'dsCafe101Test.TestCustomer' table. You can move, or remove it, as needed.
            this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);
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

                cmbOrderType.SelectedIndex = 0; // Default to Regular
                dtpEventDate.Visible = false;
                dtpEventTime.Visible = false;
                lblEventDate.Visible = false;
                lblEventTime.Visible = false;


                // Load all menu items from database into the grid
                this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
                dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;
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

            DataTable recipes = testRecipeTableAdapter1.GetData();
            DataTable ingredients = testIngredientTableAdapter1.GetData();

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
                    cell.Items.Add("0");
                    cell.Value = "0";
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

                this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

                var results = this.dsCafe101Test.TestCustomer.Where(c =>
                    c.FirstName.ToLower().Contains(txtSearchedCust.Text.ToLower()) ||
                    c.Surname.ToLower().Contains(txtSearchedCust.Text.ToLower()));

                if (results.Any())
                {
                    var customer = results.First();
                    selectedCustomerID = customer.CustomerID;
                    txtSearchedName.Text = customer.FirstName + " " + customer.Surname;

                    // Hide grid once customer is selected
                    dgvCustomers.DataSource = null;
                    dgvCustomers.Visible = false;
                }
                else
                {
                    // Show grid with all customers so cashier can browse
                    dgvCustomers.DataSource = this.dsCafe101Test.TestCustomer;
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
                    this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
                    dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;
                    return;
                }

                // Use the FillByMenuItem query to filter by name
                this.testMenuItemsTableAdapter.FillByMenuItems(this.dsCafe101Test.TestMenuItems, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;

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
                 DataTable recipes = testRecipeTableAdapter1.GetData();
                 DataTable ingredients = testIngredientTableAdapter1.GetData();
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
            try
            {
                this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

                DataTable dt = new DataTable();
                dt.Columns.Add("CustomerID", typeof(int));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("Surname", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                string search = txtSearchedCust.Text.ToLower();

                foreach (DataRow row in this.dsCafe101Test.TestCustomer.Rows)
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
                dgvCustomers.Columns["CustomerID"].Visible = false;
                dgvCustomers.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
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
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value.ToString().Replace("R ", "").Trim());

            if (currentQty <= 1)
            {
                orderTotal -= price;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");
               dgvCart.Rows.Remove(row);

                // Reset dropdown in menu grid
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
            else
            {
                int newQty = currentQty - 1;
                decimal newSubtotal = newQty * price;
                row.Cells["Qty"].Value = newQty;
                row.Cells["Subtotal"].Value = "R " + newSubtotal.ToString("0.00");
                orderTotal -= price;
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

                // Insert the order and get the new OrderID back
                object result = testOrderTableAdapter.InsertOrder(
                     selectedCustomerID,
                     1,
                     cmbOrderType.SelectedItem.ToString(),
                     DateTime.Now,
                     cmbOrderType.SelectedItem.ToString() == "Event" ? dtpEventDate.Value.ToString("yyyy-MM-dd") : null,
                     cmbOrderType.SelectedItem.ToString() == "Event" ? dtpEventTime.Value.ToString("HH:mm:ss") : null, "Pending",
                     "Cash",
                     orderTotal,
                     0);

                if (result == null)
                {
                    MessageBox.Show("Failed to get Order ID. Order not saved.");
                    return;
                }

                int newOrderID = GetNewOrderID();

                //MessageBox.Show("New Order ID is: " + newOrderID);

                // Insert each cart item into ItemOrder table
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["MenuItemID"].Value == null) continue;

                    int menuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString().Replace("R ", "").Trim());

                    testOrderItemTableAdapter1.InsertItemOrder(newOrderID, menuItemID, qty, subtotal);
                }

                DeductStock();
                MessageBox.Show("Order #" + newOrderID + " saved successfully!\nTotal: R " + orderTotal.ToString("0.00") + "\nHandling payment in Checkout...");

                // Uncomment when frmCheckout is ready

                frmCheckout checkout = new frmCheckout(newOrderID, orderTotal);
                checkout.ShowDialog();

                // Reset the form for the next order
                dgvCart.Rows.Clear();
                orderTotal = 0;
                lblAmount.Text = "R0.00";
                selectedCustomerID = 0;
                txtSearchedCust.Text = "";
                txtSearchedName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming order: " + ex.Message);
            }
        }

        private bool CheckStock()
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["MenuItemID"].Value == null) continue;

                int menuItemID = Convert.ToInt32(row.Cells["MenuItemID"].Value);
                int qtyOrdered = Convert.ToInt32(row.Cells["Qty"].Value);

                DataTable allRecipes = testRecipeTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                    int amountNeeded = quantityNeeded * qtyOrdered;

                    DataTable allStock = testIngredientTableAdapter1.GetData();

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

                DataTable allRecipes = testRecipeTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    int quantityNeeded = Convert.ToInt32(recipe["QuantityNeeded"]);
                    int amountToDeduct = quantityNeeded * qtyOrdered;

                    testIngredientTableAdapter1.DeductStock(amountToDeduct, ingredientID);
                }
            }
        }

        private int GetNewOrderID()
        {
            int orderID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(testOrderTableAdapter.Connection.ConnectionString))
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT MAX(OrderID) FROM TestOrder", conn);
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

                dgvCustomers.DataSource = null;
                dgvCustomers.Visible = false;
                txtSearchedCust.Text = "";
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
                    this.testMenuItemsTableAdapter.Fill(this.dsCafe101Test.TestMenuItems);
                    dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;
                    RebuildQtyColumn();
                    return;
                }

                this.testMenuItemsTableAdapter.FillByMenuItems(this.dsCafe101Test.TestMenuItems, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101Test.TestMenuItems;
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
            selectedCustomerID = 0;
            txtSearchedName.Text = "";
            txtSearchedCust.Text = "";
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

            DataTable recipes = testRecipeTableAdapter1.GetData();
            DataTable ingredients = testIngredientTableAdapter1.GetData();

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

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(320, 420);
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;

                Label lblTitle = new Label();
                lblTitle.Text = "📋 How To Place An Order";
                lblTitle.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
                lblTitle.ForeColor = System.Drawing.Color.White;
                lblTitle.Location = new System.Drawing.Point(10, 10);
                lblTitle.Size = new System.Drawing.Size(300, 25);

                Label lblSteps = new Label();
                lblSteps.Text =
                    "1. SEARCH CUSTOMER\r\n" +
                    "   Type a name and press Search,\r\n" +
                    "   or click a row in the list.\r\n\r\n" +
                    "2. CLEAR CUSTOMER\r\n" +
                    "   Press Clear to select a\r\n" +
                    "   different customer.\r\n\r\n" +
                    "3. SEARCH MENU ITEM\r\n" +
                    "   Type an item name to filter\r\n" +
                    "   the menu list.\r\n\r\n" +
                    "4. SELECT QUANTITY\r\n" +
                    "   Click the Quantity dropdown\r\n" +
                    "   on the item row.\r\n\r\n" +
                    "5. ADD TO CART\r\n" +
                    "   Click Add To Cart to add\r\n" +
                    "   the selected item.\r\n\r\n" +
                    "6. ADJUST CART\r\n" +
                    "   Use Decrease Quantity or\r\n" +
                    "   Remove Item to edit cart.\r\n\r\n" +
                    "7. CONFIRM ORDER\r\n" +
                    "   Click Confirm Order to\r\n" +
                    "   save and process payment.";
                lblSteps.Font = new System.Drawing.Font("Segoe UI", 9);
                lblSteps.ForeColor = System.Drawing.Color.LightGray;
                lblSteps.Location = new System.Drawing.Point(10, 45);
                lblSteps.Size = new System.Drawing.Size(295, 360);

                Button btnClose = new Button();
                btnClose.Text = "✕ Close Help";
                btnClose.Size = new System.Drawing.Size(120, 30);
                btnClose.Location = new System.Drawing.Point(190, 380);
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
                pnlHelp.Controls.Add(lblSteps);
                pnlHelp.Controls.Add(btnClose);
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            // Position it near the help button
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
            this.Hide();
        }
    }
    
}