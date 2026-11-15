
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using Cafe101.Data;

namespace Cafe101.Web
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        // This holds one order displayed on the Order History page.
        public class OrderRow
        {
            public DateTime OrderDate { get; set; }
            public string ItemSummary { get; set; }
            public decimal Total { get; set; }
            public string Status { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only logged-in customers may view their order history.
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

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            try
            {
                // Get the ID of the customer currently logged in.
                int customerId = Convert.ToInt32(Session["UserID"]);

                // Get the selected date filter.
                int months = Convert.ToInt32(ddlFilter.SelectedValue);

                List<OrderRow> orders = new List<OrderRow>();

                string query = @"
                    SELECT
                        o.OrderDateTime AS OrderDate,
                        o.TotalAmountDue AS Total,
                        o.OrderStatus AS Status,

                        ISNULL(
                            STUFF((
                                SELECT
                                    ', ' + m.MenuItemName
                                    + ' x' + CAST(oi.QuantityOrdered AS VARCHAR(10))
                                FROM OrderItemTable oi
                                INNER JOIN MenuItemsTable m
                                    ON oi.MenuItemID = m.MenuItemID
                                WHERE oi.OrderID = o.OrderID
                                FOR XML PATH(''), TYPE
                            ).value('.', 'NVARCHAR(MAX)'), 1, 2, ''),
                            'No item details'
                        ) AS ItemSummary

                    FROM OrderTable o

                    WHERE o.CustomerID = @CustomerID
                      AND o.OrderDateTime >= DATEADD(
                            MONTH, -@Months, GETDATE()
                          )

                    ORDER BY o.OrderDateTime DESC;";

                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        // Parameters prevent user input being inserted
                        // directly into the SQL query.
                        command.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        command.Parameters.AddWithValue(
                            "@Months", months);

                        connection.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orders.Add(new OrderRow
                                {
                                    OrderDate = Convert.ToDateTime(
                                        reader["OrderDate"]),

                                    ItemSummary = Convert.ToString(
                                        reader["ItemSummary"]),

                                    Total = Convert.ToDecimal(
                                        reader["Total"]),

                                    Status = Convert.ToString(
                                        reader["Status"])
                                });
                            }
                        }
                    }
                }

                // Display the orders retrieved from the database.
                rptOrders.DataSource = orders;
                rptOrders.DataBind();

                // Show a message if the customer has no orders
                // in the selected time period.
                lblNoOrders.Visible = orders.Count == 0;
            }
            catch (Exception)
            {
                rptOrders.DataSource = null;
                rptOrders.DataBind();

                lblNoOrders.Text =
                    "Unable to load your order history. Please try again.";

                lblNoOrders.Visible = true;
            }
        }

        protected void ddlFilter_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
