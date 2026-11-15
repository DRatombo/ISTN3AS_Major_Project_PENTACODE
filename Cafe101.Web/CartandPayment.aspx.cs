
using Cafe101.Data;
using global::Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Cafe101.Web
{
    public partial class CartandPayment : System.Web.UI.Page
    {
        // Passes the cart total to JavaScript for live change calculation.
        protected string TotalForJs { get; private set; } = "0";

        private bool IsCustomer
        {
            get
            {
                return string.Equals(
                    Convert.ToString(Session["UserType"]),
                    "Customer",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool IsStaffAllowed
        {
            get
            {
                string userType = Convert.ToString(Session["UserType"]);
                string role = Convert.ToString(Session["Role"]);

                return string.Equals(userType, "Employee",
                           StringComparison.OrdinalIgnoreCase)
                    && (string.Equals(role, "Manager",
                            StringComparison.OrdinalIgnoreCase)
                        || string.Equals(role, "Cashier",
                            StringComparison.OrdinalIgnoreCase));
            }
        }

        // ---------------------------------------------------------------
        // PAGE LOAD
        // ---------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            // A user must be logged in.
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            // Customers, managers and cashiers may use this checkout.
            if (!IsCustomer && !IsStaffAllowed)
            {
                Response.Redirect("~/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            // Customer selection is only available to managers/cashiers.
            pnlCustomerSelection.Visible = IsStaffAllowed;

            if (!IsPostBack && IsStaffAllowed)
            {
                LoadCustomers("");
            }

            LoadCart();
        }

        // ---------------------------------------------------------------
        // LOAD CUSTOMERS FOR STAFF CHECKOUT
        // ---------------------------------------------------------------
        private void LoadCustomers(string searchText)
        {
            ddlCustomer.Items.Clear();

            // This is a prompt, not a real customer record.
            ddlCustomer.Items.Add(
                new System.Web.UI.WebControls.ListItem(
                    "Select a customer", ""));

            string sql = @"
                SELECT
                    CustomerID,
                    FirstName,
                    Surname,
                    Email
                FROM CustomerTable
                WHERE
                    (
                        @Search = ''
                        OR FirstName LIKE @SearchLike
                        OR Surname LIKE @SearchLike
                        OR (FirstName + ' ' + Surname) LIKE @SearchLike
                        OR Email LIKE @SearchLike
                        OR (FirstName + ' ' + Surname) = 'Walk-in Customer'
                    )
                ORDER BY
                    CASE
                        WHEN LTRIM(RTRIM(FirstName + ' ' + Surname))
                             = 'Walk-in Customer' THEN 0
                        ELSE 1
                    END,
                    FirstName,
                    Surname;";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                string search = (searchText ?? "").Trim();

                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 150)
                    .Value = search;

                cmd.Parameters.Add("@SearchLike", SqlDbType.NVarChar, 152)
                    .Value = "%" + search + "%";

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int customerId =
                            Convert.ToInt32(reader["CustomerID"]);

                        string firstName =
                            Convert.ToString(reader["FirstName"]);

                        string surname =
                            Convert.ToString(reader["Surname"]);

                        string email =
                            Convert.ToString(reader["Email"]);

                        string fullName =
                            (firstName + " " + surname).Trim();

                        string displayText = fullName;

                        if (!string.IsNullOrWhiteSpace(email))
                        {
                            displayText += " (" + email + ")";
                        }

                        ddlCustomer.Items.Add(
                            new System.Web.UI.WebControls.ListItem(
                                displayText,
                                customerId.ToString()));
                    }
                }
            }

            // Automatically select Walk-in Customer if that customer
            // actually exists in CustomerTable.
            System.Web.UI.WebControls.ListItem walkInItem =
                ddlCustomer.Items.FindByText("Walk-in Customer");

            if (walkInItem == null)
            {
                foreach (System.Web.UI.WebControls.ListItem item
                    in ddlCustomer.Items)
                {
                    if (item.Text.StartsWith(
                        "Walk-in Customer (",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        walkInItem = item;
                        break;
                    }
                }
            }

            if (walkInItem != null)
            {
                walkInItem.Selected = true;
                lblCustomerMessage.Text = "";
            }
            else
            {
                ddlCustomer.SelectedIndex = 0;

                lblCustomerMessage.Text =
                    "Walk-in Customer is not registered in the database. " +
                    "Please select an existing customer.";
            }

            if (ddlCustomer.Items.Count == 1)
            {
                lblCustomerMessage.Text =
                    "No matching customers were found.";
            }
        }

        // ---------------------------------------------------------------
        // SEARCH BUTTON
        // ---------------------------------------------------------------
        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!IsStaffAllowed)
            {
                ShowError("You are not allowed to search for customers.");
                return;
            }

            LoadCustomers(txtCustomerSearch.Text);
        }

        // ---------------------------------------------------------------
        // READ THE CART FROM SESSION
        // ---------------------------------------------------------------
        private List<CartItem> GetCart()
        {
            return Session["Cart"] as List<CartItem>
                   ?? new List<CartItem>();
        }

        // ---------------------------------------------------------------
        // SHOW THE CART + ORDER TOTAL
        // ---------------------------------------------------------------
        private void LoadCart()
        {
            List<CartItem> cart = GetCart();

            rptCartItems.DataSource = cart;
            rptCartItems.DataBind();

            bool empty = cart.Count == 0;

            pnlEmptyCart.Visible = empty;
            pnlCheckout.Visible = !empty;

            decimal total = cart.Sum(i => i.LineTotal);

            txtOrderID.Text = "Assigned on payment";

            txtOrderTotal.Text =
                "R " + total.ToString(
                    "0.00", CultureInfo.InvariantCulture);

            TotalForJs =
                total.ToString(CultureInfo.InvariantCulture);
        }

        // ---------------------------------------------------------------
        // READ A MONEY AMOUNT
        // ---------------------------------------------------------------
        private bool TryReadAmount(string text, out decimal amount)
        {
            text = (text ?? "").Trim().Replace(',', '.');

            bool ok = decimal.TryParse(
                text,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out amount);

            amount = Math.Round(amount, 2);

            return ok;
        }

        // ---------------------------------------------------------------
        // CONFIRM PAYMENT BUTTON
        // ---------------------------------------------------------------
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<CartItem> cart = GetCart();

            if (cart.Count == 0)
            {
                ShowError("Your cart is empty.");
                return;
            }

            if (cart.Any(i => i.Quantity <= 0 || i.Quantity > 50))
            {
                ShowError("One or more items have an invalid quantity.");
                return;
            }

            string paymentMethod = rblPayment.SelectedValue;

            if (paymentMethod != "Cash" && paymentMethod != "Card")
            {
                ShowError("Please select a payment method (Cash or Card).");
                return;
            }

            decimal amountTendered = 0m;

            if (paymentMethod == "Cash")
            {
                if (!TryReadAmount(
                    txtAmountTendered.Text, out amountTendered)
                    || amountTendered <= 0)
                {
                    ShowError(
                        "Please enter the amount tendered as a number greater than 0.");
                    return;
                }
            }

            int customerId;
            int employeeId;

            if (IsCustomer)
            {
                // Customer checkout: use the account currently signed in.
                customerId = Convert.ToInt32(Session["UserID"]);

                // Keep the existing default employee ID for customer web orders.
                employeeId = 1;
            }
            else if (IsStaffAllowed)
            {
                // Staff checkout: use the customer selected from the database.
                if (string.IsNullOrWhiteSpace(ddlCustomer.SelectedValue))
                {
                    ShowError("Please select a customer before confirming payment.");
                    return;
                }

                if (!int.TryParse(
                    ddlCustomer.SelectedValue, out customerId))
                {
                    ShowError("The selected customer is invalid. Please search again.");
                    return;
                }

                // The logged-in cashier/manager is the employee processing the order.
                employeeId = Convert.ToInt32(Session["UserID"]);
            }
            else
            {
                ShowError("You are not authorised to process this order.");
                return;
            }

            try
            {
                int orderId = CreateOrder(
                    cart,
                    customerId,
                    employeeId,
                    paymentMethod,
                    amountTendered);

                // Clear the cart only after the order is successfully saved.
                Session["Cart"] = null;
                Session["LastOrderID"] = orderId;

                Response.Redirect(
                    "~/Receipt.aspx?orderId=" + orderId, false);

                Context.ApplicationInstance.CompleteRequest();
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception)
            {
                // Keep the detailed exception out of the customer-facing page.
                ShowError(
                    "Sorry, we couldn't save your payment. Please try again.");
            }
        }

        // ---------------------------------------------------------------
        // SHOW AN ERROR MESSAGE
        // ---------------------------------------------------------------
        private void ShowError(string message)
        {
            lblMessage.Text = Server.HtmlEncode(message);
            lblMessage.Visible = true;
            btnConfirm.Text = "Confirm Payment";
        }

        // ---------------------------------------------------------------
        // SAVE THE ORDER + ITEMS IN ONE TRANSACTION
        // ---------------------------------------------------------------
        private int CreateOrder(
            List<CartItem> cart,
            int customerId,
            int employeeId,
            string paymentMethod,
            decimal amountTendered)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-price every item using the database price.
                        var lines =
                            new List<Tuple<int, int, decimal>>();

                        decimal orderTotal = 0m;

                        foreach (CartItem item in cart)
                        {
                            decimal price;

                            using (SqlCommand cmd = new SqlCommand(
                                @"SELECT SellingPrice
                                  FROM MenuItemsTable
                                  WHERE MenuItemID = @id",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id", item.MenuItemID);

                                object result = cmd.ExecuteScalar();

                                if (result == null || result == DBNull.Value)
                                {
                                    throw new InvalidOperationException(
                                        "\"" + item.MenuItemName +
                                        "\" is no longer available. Please remove it from your cart.");
                                }

                                price = Convert.ToDecimal(result);
                            }

                            decimal subtotal = price * item.Quantity;

                            orderTotal += subtotal;

                            lines.Add(Tuple.Create(
                                item.MenuItemID,
                                item.Quantity,
                                subtotal));
                        }

                        // 2. Check that cash covers the order total.
                        decimal change = 0m;

                        if (paymentMethod == "Cash")
                        {
                            if (amountTendered < orderTotal)
                            {
                                throw new InvalidOperationException(
                                    "The amount tendered does not cover the order total of R " +
                                    orderTotal.ToString(
                                        "0.00", CultureInfo.InvariantCulture) + ".");
                            }

                            change = amountTendered - orderTotal;
                        }

                        // 3. Insert the order.
                        int orderId;

                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO [OrderTable]
                                (CustomerID, EmployeeID, OrderType,
                                 OrderDateTime, OrderStatus, PaymentMethod,
                                 TotalAmountDue, TotalChangeDue)
                            VALUES
                                (@cust, @emp, @ordertype, GETDATE(),
                                 'Completed', @method, @total, @change);

                            SELECT CAST(SCOPE_IDENTITY() AS int);",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@cust", customerId);
                            cmd.Parameters.AddWithValue("@emp", employeeId);
                            cmd.Parameters.AddWithValue("@ordertype", "Regular");
                            cmd.Parameters.AddWithValue("@method", paymentMethod);
                            cmd.Parameters.AddWithValue("@total", orderTotal);
                            cmd.Parameters.AddWithValue("@change", change);

                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 4. Insert each order item.
                        foreach (var line in lines)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO OrderItemTable
                                    (OrderID, MenuItemID, QuantityOrdered, Subtotal)
                                VALUES
                                    (@oid, @mid, @qty, @sub)",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@oid", orderId);
                                cmd.Parameters.AddWithValue("@mid", line.Item1);
                                cmd.Parameters.AddWithValue("@qty", line.Item2);
                                cmd.Parameters.AddWithValue("@sub", line.Item3);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();

                        return orderId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
