using Cafe101.Data;
using global::Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Cafe101.Web
{
    public partial class CartandPayment : System.Web.UI.Page
    {
        // Passes the cart total to the page's JavaScript (live change calculation)
        protected string TotalForJs { get; private set; } = "0";

        // ---------------------------------------------------------------
        // PAGE LOAD: customer must be logged in, then show the cart
        // ---------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null ||
                !string.Equals(
                    Convert.ToString(Session["UserType"]),
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            LoadCart();
        }

        // ---------------------------------------------------------------
        // READ THE CART FROM SESSION (empty list if none)
        // ---------------------------------------------------------------
        private List<CartItem> GetCart()
        {
            return Session["Cart"] as List<CartItem> ?? new List<CartItem>();
        }

        // ---------------------------------------------------------------
        // SHOW THE CART + FILL ORDER ID / ORDER TOTAL
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
            txtOrderTotal.Text = "R " + total.ToString("0.00", CultureInfo.InvariantCulture);
            TotalForJs = total.ToString(CultureInfo.InvariantCulture);
        }

        // ---------------------------------------------------------------
        // READ A MONEY AMOUNT (accepts "250.50" and "250,50")
        // ---------------------------------------------------------------
        private bool TryReadAmount(string text, out decimal amount)
        {
            text = (text ?? "").Trim().Replace(',', '.');
            bool ok = decimal.TryParse(text, NumberStyles.AllowDecimalPoint,
                                       CultureInfo.InvariantCulture, out amount);
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
                if (!TryReadAmount(txtAmountTendered.Text, out amountTendered) || amountTendered <= 0)
                {
                    ShowError("Please enter the amount tendered as a number greater than 0.");
                    return;
                }
            }

            int customerId = Convert.ToInt32(Session["UserID"]);

            try
            {
                int orderId = CreateOrder(cart, customerId, paymentMethod, amountTendered);

                // Clear the cart only AFTER the order is saved
                Session["Cart"] = null;
                Session["LastOrderID"] = orderId;

                Response.Redirect("~/Receipt.aspx?orderId=" + orderId, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (InvalidOperationException ex)
            {
                // Our own friendly errors (item unavailable, amount too low)
                ShowError(ex.Message);
            }
            catch (Exception)
            {
                // TODO: log the real exception
                ShowError("Sorry, we couldn't save your payment. Please try again.");

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
        private int CreateOrder(List<CartItem> cart, int customerId, string paymentMethod, decimal amountTendered)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1) Re-price every item from the database (never trust the session)
                        var lines = new List<Tuple<int, int, decimal>>(); // MenuItemID, Qty, Subtotal
                        decimal orderTotal = 0m;

                        foreach (CartItem item in cart)
                        {
                            decimal price;
                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT SellingPrice FROM MenuItemsTable WHERE MenuItemID = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", item.MenuItemID);
                                object r = cmd.ExecuteScalar();
                                if (r == null || r == DBNull.Value)
                                    throw new InvalidOperationException(
                                        "\"" + item.MenuItemName + "\" is no longer available. Please remove it from your cart.");
                                price = Convert.ToDecimal(r);
                            }

                            decimal subtotal = price * item.Quantity;
                            orderTotal += subtotal;
                            lines.Add(Tuple.Create(item.MenuItemID, item.Quantity, subtotal));
                        }

                        // 2) Cash must cover the real total; card has no change
                        decimal change = 0m;
                        if (paymentMethod == "Cash")
                        {
                            if (amountTendered < orderTotal)
                                throw new InvalidOperationException(
                                    "The amount tendered does not cover the order total of R " +
                                    orderTotal.ToString("0.00", CultureInfo.InvariantCulture) + ".");
                            change = amountTendered - orderTotal;
                        }

                        // 3) Insert the order
                        int orderId;
                        using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO [OrderTable]
                            (CustomerID, EmployeeID, OrderType, OrderDateTime, OrderStatus, 
                             PaymentMethod, TotalAmountDue, TotalChangeDue)
                        VALUES
                            (@cust, @emp, @ordertype, GETDATE(), 'Completed', 
                             @method, @total, @change);
                        SELECT CAST(SCOPE_IDENTITY() AS int);", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@cust", customerId);
                            cmd.Parameters.AddWithValue("@emp", 1);                    // or whatever employee should be used
                            cmd.Parameters.AddWithValue("@ordertype", "Regular");      // since this is a normal cart order
                            cmd.Parameters.AddWithValue("@method", paymentMethod);
                            cmd.Parameters.AddWithValue("@total", orderTotal);
                            cmd.Parameters.AddWithValue("@change", change);

                            orderId = (int)cmd.ExecuteScalar();
                        }

                        // 4) Insert each order line
                        foreach (var line in lines)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO ItemOrder (OrderID, MenuItemID, QuantityOrdered, Subtotal)
                                VALUES (@oid, @mid, @qty, @sub)", conn, tx))
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