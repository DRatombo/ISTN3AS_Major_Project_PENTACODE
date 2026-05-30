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

                // Load all menu items from database into the grid
                this.menuItemsTableAdapter1.Fill(this.dsCafe101.MenuItems);
                dgvMenuItems.DataSource = this.dsCafe101.MenuItems;
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

            for (int i = 0; i <= 20; i++)
                qtyCol.Items.Add(i.ToString());

            dgvMenuItems.Columns.Add(qtyCol);

            foreach (DataGridViewRow row in dgvMenuItems.Rows)
            {
                if (!row.IsNewRow)
                    row.Cells["ItemQty"].Value = "0";
            }
        }

        private void btnSearchCust_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if search box is empty before searching
                if (string.IsNullOrEmpty(txtSearchedCust.Text))
                {
                    MessageBox.Show("Please enter a customer name to search for.");
                    return;
                }

                // Load all customers from database into dataset
                this.customerTableAdapter1.Fill(this.dsCafe101.Customer);

                // Search through customers - match by first name OR surname
                // ToLower() makes search case insensitive
                var results = this.dsCafe101.Customer.Where(c =>
                    c.FirstName.ToLower().Contains(txtSearchedCust.Text.ToLower()) ||
                    c.Surname.ToLower().Contains(txtSearchedCust.Text.ToLower()));

                if (results.Any()) // At least one customer found
                {
                    // Take the first matching customer
                    var customer = results.First();

                    // Store customer ID so we can link it to the order later
                    selectedCustomerID = customer.CustomerID;

                    // Display customer full name in the NAME textbox
                    txtSearchedName.Text = customer.FirstName + " " + customer.Surname;
                }
                else // No customer found
                {
                    // Ask if user wants to add a new customer
                    DialogResult result = MessageBox.Show(
                        "Customer not found. Do you want to create a new customer?",
                        "Customer Not Found",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Open the Add Customer form
                        frmAddCustomer addCust = new frmAddCustomer();
                        addCust.ShowDialog(); // Wait for form to close before continuing
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
                    this.menuItemsTableAdapter1.Fill(this.dsCafe101.MenuItems);
                    dgvMenuItems.DataSource = this.dsCafe101.MenuItems;
                    return;
                }

                // Use the FillByMenuItem query to filter by name
                this.menuItemsTableAdapter1.FillByMenuItem(this.dsCafe101.MenuItems, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101.MenuItems;

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

        private void textItemSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // If search box is empty - reload and show all menu items
                if (string.IsNullOrWhiteSpace(textItemSearch.Text))
                {
                    this.menuItemsTableAdapter1.Fill(this.dsCafe101.MenuItems);
                    dgvMenuItems.DataSource = this.dsCafe101.MenuItems;

                    // Reset quantity to 1 for all rows
                    foreach (DataGridViewRow row in dgvMenuItems.Rows)
                    {
                        if (!row.IsNewRow)
                            row.Cells["ItemQty"].Value = 1;
                    }
                    return;
                }

                // Filter as user types using the custom query
                this.menuItemsTableAdapter1.FillByMenuItem(this.dsCafe101.MenuItems, textItemSearch.Text);
                dgvMenuItems.DataSource = this.dsCafe101.MenuItems;

                // Reset quantity to 1 after filtering
                foreach (DataGridViewRow row in dgvMenuItems.Rows)
                {
                    if (!row.IsNewRow)
                        row.Cells["ItemQty"].Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering menu items: " + ex.Message);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a customer has been selected first
                if (selectedCustomerID == 0)
                {
                    MessageBox.Show("Please select a customer before adding items to the cart.");
                    return;
                }

                // Check if a menu item has been selected in the grid
                if (dgvMenuItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to order.");
                    return;
                }

                /* // Get selected item details from the grid
                 int menuItemID = Convert.ToInt32(dgvMenuItems.SelectedRows[0].Cells["MenuItemID"].Value);
                 // Column header is "Item Name" so we use index 0 to get the value
                 string itemName = dgvMenuItems.SelectedRows[0].Cells["Item Name"].Value.ToString(); decimal price = Convert.ToDecimal(dgvMenuItems.SelectedRows[0].Cells["Price"].Value);

                 // Get quantity from dropdown - default to 1 if nothing selected
                 int quantity = 1;
                 if (dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value != null &&
                     dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value.ToString() != "")
                     quantity = Convert.ToInt32(dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value);*/

                int menuItemID = Convert.ToInt32(dgvMenuItems.SelectedRows[0].Cells[1].Value);
                string itemName = dgvMenuItems.SelectedRows[0].Cells[0].Value.ToString();
                decimal price = Convert.ToDecimal(dgvMenuItems.SelectedRows[0].Cells[2].Value.ToString().Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                int quantity = 0;
                if (dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value != null &&
                    dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value.ToString() != "")
                    quantity = Convert.ToInt32(dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value);

                if (quantity == 0)
                {
                    MessageBox.Show("Please select a quantity greater than 0.");
                    return;
                }

                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["MenuItemID"].Value != null &&
                        Convert.ToInt32(row.Cells["MenuItemID"].Value) == menuItemID)
                    {
                        int existingQty = Convert.ToInt32(row.Cells["Qty"].Value);
                        int newQty = existingQty + quantity;
                        decimal newSubtotal = newQty * price;

                        row.Cells["Qty"].Value = newQty;
                        row.Cells["Subtotal"].Value = "R " + newSubtotal.ToString("0.00");

                        orderTotal += quantity * price;
                        lblAmount.Text = "R " + orderTotal.ToString("0.00");
                        return;
                    }
                }

                // Item not in cart yet - add as a new row
                dgvCart.Rows.Add(
                    menuItemID,         // Hidden ID for reference
                    itemName,           // Item name
                    quantity,           // Selected quantity
                    "R " + price.ToString("0.00"),                    // Unit price
                    "R " + (quantity * price).ToString("0.00"));      // Subtotal

                // Update running order total
                orderTotal += quantity * price;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");

                dgvMenuItems.SelectedRows[0].Cells["ItemQty"].Value = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message);
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
            int currentQty = Convert.ToInt32(row.Cells["Qty"].Value);
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value.ToString().Replace("R ", "").Trim());

            if (currentQty <= 1)
            {
                // If quantity is 1, remove the row completely
                orderTotal -= price;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");
                dgvCart.Rows.Remove(row);
            }
            else
            {
                int newQty = currentQty - 1;
                decimal newSubtotal = newQty * price;

                row.Cells["Qty"].Value = newQty;
                row.Cells["Subtotal"].Value = "R " + newSubtotal.ToString("0.00");

                orderTotal -= price;
                lblAmount.Text = "R " + orderTotal.ToString("0.00");
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
            decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString().Replace("R ", "").Trim());

            orderTotal -= subtotal;
            if (orderTotal < 0) orderTotal = 0;
            lblAmount.Text = "R " + orderTotal.ToString("0.00");

            dgvCart.Rows.Remove(row);
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
                object result = orderTableAdapter1.InsertOrder(
                    selectedCustomerID,
                    1,
                    DateTime.Now,
                    "Pending",
                    "Cash",
                    orderTotal,
                    0,
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

                    itemOrderTableAdapter1.InsertItemOrder(newOrderID, menuItemID, qty, subtotal);
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

                // Get ingredients for this menu item using GetData and filter manually
                DataTable allRecipes = recipeItemTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    decimal proportion = Convert.ToDecimal(recipe["Proportion"].ToString().Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                    decimal amountNeeded = proportion * qtyOrdered;

                    DataTable allStock = ingredientTableAdapter1.GetData();

                    foreach (DataRow stockRow in allStock.Rows)
                    {
                        if (Convert.ToInt32(stockRow["IngredientID"]) != ingredientID) continue;

                        decimal quantityInStock = Convert.ToDecimal(stockRow["QuantityInStock"]);

                        if (quantityInStock < amountNeeded)
                        {
                            string itemName = row.Cells["Item"].Value.ToString();
                            MessageBox.Show(
                                "Not enough stock to complete this order.\n" +
                                "Item: " + itemName + "\n" +
                                "Required: " + amountNeeded + "\n" +
                                "In Stock: " + quantityInStock,
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

                DataTable allRecipes = recipeItemTableAdapter1.GetData();

                foreach (DataRow recipe in allRecipes.Rows)
                {
                    if (Convert.ToInt32(recipe["MenuItemID"]) != menuItemID) continue;

                    int ingredientID = Convert.ToInt32(recipe["IngredientID"]);
                    decimal proportion = Convert.ToDecimal(recipe["Proportion"].ToString().Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                    decimal amountToDeduct = proportion * qtyOrdered;

                    ingredientTableAdapter1.DeductStock(amountToDeduct, ingredientID);
                }
            }
        }

        private int GetNewOrderID()
        {
            int orderID = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(orderTableAdapter1.Connection.ConnectionString))
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT MAX(OrderID) FROM [Order]", conn);
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
    }
}