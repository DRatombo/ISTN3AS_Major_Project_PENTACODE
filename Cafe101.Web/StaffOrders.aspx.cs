
using System;
using System.Data;
using System.Data.SqlClient;
using Cafe101.Data;

namespace Cafe101.Web
{
    public partial class StaffOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User must be logged in
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            string role = Session["Role"].ToString();

            // Cashier / Staff / Manager may access this page
            bool allowed =
                role.Equals("Cashier", StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals("Staff", StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals("Manager", StringComparison.OrdinalIgnoreCase);

            if (!allowed)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadLoggedInStaff();

                // Load the order information when the page first opens
                LoadOrderCounts();
                LoadOrders();
            }
        }

        // -----------------------------------------
        // LOAD LOGGED-IN STAFF DETAILS
        // -----------------------------------------
        private void LoadLoggedInStaff()
        {
            string firstName =
                Session["FirstName"]?.ToString() ?? "";

            string surname =
                Session["Surname"]?.ToString() ?? "";

            string role =
                Session["Role"]?.ToString() ?? "";

            string fullName =
                (firstName + " " + surname).Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = "Staff Member";
            }

            lblTopStaffName.Text = fullName;
            lblTopStaffRole.Text = role;

            // Get the staff member's initials
            string initials = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials += firstName.Substring(0, 1).ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials += surname.Substring(0, 1).ToUpper();
            }

            if (string.IsNullOrWhiteSpace(initials))
            {
                initials = "SM";
            }

            lblTopInitials.Text = initials;
        }

        // -----------------------------------------
        // LOAD ORDER COUNTS FOR THE DASHBOARD
        // -----------------------------------------
        private void LoadOrderCounts()
        {
            string query = @"
                SELECT
                    (SELECT COUNT(*)
                     FROM [Order]
                     WHERE OrderStatus = 'Pending') AS NewOrders,

                    (SELECT COUNT(*)
                     FROM [Order]
                     WHERE OrderStatus = 'Preparing') AS PreparingOrders,

                    (SELECT COUNT(*)
                     FROM [Order]
                     WHERE OrderStatus = 'Ready') AS ReadyOrders,

                    (SELECT COUNT(*)
                     FROM [Order]
                     WHERE OrderStatus = 'Completed'
                     AND CAST(OrderDateTime AS DATE) = CAST(GETDATE() AS DATE))
                     AS CompletedToday;
            ";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNewOrdersCount.Text =
                            Convert.ToInt32(reader["NewOrders"]).ToString();

                        lblPreparingCount.Text =
                            Convert.ToInt32(reader["PreparingOrders"]).ToString();

                        lblReadyCount.Text =
                            Convert.ToInt32(reader["ReadyOrders"]).ToString();

                        lblCompletedTodayCount.Text =
                            Convert.ToInt32(reader["CompletedToday"]).ToString();
                    }
                }
            }
        }

        // -----------------------------------------
        // LOAD ORDERS FROM THE DATABASE
        // -----------------------------------------
        private void LoadOrders()
        {
            string query = @"
                SELECT
                    o.OrderID,

                    CASE
                        WHEN c.CustomerID IS NULL THEN 'Walk-in Customer'
                        ELSE
                            ISNULL(c.FirstName, '') + ' ' +
                            ISNULL(c.Surname, '')
                    END AS CustomerName,

                    ISNULL(
                        (
                            SELECT SUM(oi.QuantityOrdered)
                            FROM ItemOrder oi
                            WHERE oi.OrderID = o.OrderID
                        ), 0
                    ) AS ItemCount,

                    o.TotalAmountDue,
                    o.OrderDateTime,
                    o.OrderStatus,

                    ISNULL(
                        STUFF(
                            (
                                SELECT
                                    '|' +
                                    CAST(oi2.QuantityOrdered AS VARCHAR(10)) +
                                    ' × ' +
                                    ISNULL(mi.MenuItemName, 'Menu Item') +
                                    '~R' +
                                    CONVERT(VARCHAR(20), oi2.SubTotal)
                                FROM ItemOrder oi2
                                LEFT JOIN MenuItems mi
                                    ON oi2.MenuItemID = mi.MenuItemID
                                WHERE oi2.OrderID = o.OrderID
                                FOR XML PATH(''), TYPE
                            ).value('.', 'NVARCHAR(MAX)'),
                            1, 1, ''
                        ),
                        ''
                    ) AS ItemsSummary

                FROM [Order] o

                LEFT JOIN Customer c
                    ON o.CustomerID = c.CustomerID

                WHERE
                    (
                        @Status = ''
                        OR o.OrderStatus = @Status
                    )

                    AND
                    (
                        @Search = ''
                        OR CAST(o.OrderID AS VARCHAR(20))
                            LIKE '%' + @Search + '%'
                        OR ISNULL(c.FirstName, '')
                            LIKE '%' + @Search + '%'
                        OR ISNULL(c.Surname, '')
                            LIKE '%' + @Search + '%'
                    )

                ORDER BY o.OrderDateTime DESC;
            ";

            // Get the current search text
            string search = txtOrderSearch.Text.Trim();

            // Get the selected status
            string status = ddlStatusFilter.SelectedValue;

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 30).Value =
                    status;

                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 100).Value =
                    search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    // Display the database records in the Repeater
                    rptAllOrders.DataSource = dt;
                    rptAllOrders.DataBind();
                }
            }
        }

        // -----------------------------------------
        // SEARCH AND STATUS FILTER
        // -----------------------------------------
        protected void FilterOrders_Changed(object sender, EventArgs e)
        {
            LoadOrders();
        }

        // -----------------------------------------
        // GET CSS CLASS FOR ORDER STATUS
        // -----------------------------------------
        protected string GetStatusCss(object status)
        {
            if (status == null || status == DBNull.Value)
            {
                return "";
            }

            string orderStatus = status.ToString().ToLower();

            switch (orderStatus)
            {
                case "pending":
                    return "status-pending";

                case "preparing":
                    return "status-preparing";

                case "ready":
                    return "status-ready";

                case "completed":
                    return "status-completed";

                default:
                    return "";
            }
        }

        // -----------------------------------------
        // LOG OUT
        // -----------------------------------------
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}
