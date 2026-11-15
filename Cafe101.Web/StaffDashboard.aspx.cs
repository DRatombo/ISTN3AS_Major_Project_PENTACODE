
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Cafe101.Data;

namespace Cafe101.Web
{
    public partial class StaffDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check that the employee is logged in.
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            // Only staff, cashiers and managers can access this page.
            string role = Session["Role"].ToString();

            bool allowed =
                role.Equals("Cashier", StringComparison.OrdinalIgnoreCase) ||
                role.Equals("Staff", StringComparison.OrdinalIgnoreCase) ||
                role.Equals("Manager", StringComparison.OrdinalIgnoreCase);

            if (!allowed)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadLoggedInStaff();
            }

            // Load real database information.
            LoadRecentOrders();
            LoadRecentAlerts();
        }

        // Display the logged-in employee's information.
        private void LoadLoggedInStaff()
        {
            string firstName = Session["FirstName"]?.ToString() ?? "";
            string surname = Session["Surname"]?.ToString() ?? "";
            string role = Session["Role"]?.ToString() ?? "";

            string fullName = (firstName + " " + surname).Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = "Staff Member";
            }

            lblStaffName.Text =
                string.IsNullOrWhiteSpace(firstName) ? "Staff" : firstName;

            lblTopStaffName.Text = fullName;
            lblTopStaffRole.Text = role;

            // Generate the employee's initials.
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

        // Load the five newest orders.
        private void LoadRecentOrders()
        {
            string sql = @"
                SELECT TOP 5
                    o.OrderID,

                    CASE
                        WHEN c.CustomerID IS NULL THEN 'Walk-in Customer'
                        ELSE LTRIM(RTRIM(
                            ISNULL(c.FirstName, '') + ' ' +
                            ISNULL(c.Surname, '')
                        ))
                    END AS CustomerName,

                    ISNULL(SUM(oi.QuantityOrdered), 0) AS ItemCount,

                    o.TotalAmountDue,
                    o.OrderStatus,
                    o.OrderDateTime

                FROM OrderTable o

                LEFT JOIN CustomerTable c
                    ON o.CustomerID = c.CustomerID

                LEFT JOIN OrderItemTable oi
                    ON o.OrderID = oi.OrderID

                GROUP BY
                    o.OrderID,
                    c.CustomerID,
                    c.FirstName,
                    c.Surname,
                    o.TotalAmountDue,
                    o.OrderStatus,
                    o.OrderDateTime

                ORDER BY o.OrderDateTime DESC;";

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(command))
                {
                    DataTable orders = new DataTable();

                    adapter.Fill(orders);

                    rptRecentOrders.DataSource = orders;
                    rptRecentOrders.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Your error message");
            }
        }

        // Load the latest three orders that still need attention.
        private void LoadRecentAlerts()
        {
            string sql = @"
                SELECT TOP 3
                    o.OrderID,
                    o.OrderStatus,
                    o.OrderDateTime

                FROM OrderTable o

                WHERE o.OrderStatus IN
                    ('Pending', 'Preparing', 'Ready')

                ORDER BY o.OrderDateTime DESC;";

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(command))
                {
                    DataTable alerts = new DataTable();

                    adapter.Fill(alerts);

                    rptRecentAlerts.DataSource = alerts;
                    rptRecentAlerts.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Your error message");
            }
        }

        // Assign the correct status CSS class.
        protected string GetStatusCss(string status)
        {
            switch ((status ?? "").Trim().ToLower())
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

        // Display a suitable alert heading.
        protected string GetAlertHeading(string status)
        {
            switch ((status ?? "").Trim().ToLower())
            {
                case "pending":
                    return "New Order Received";

                case "preparing":
                    return "Order Preparing";

                case "ready":
                    return "Order Ready";

                default:
                    return "Order Update";
            }
        }

        // Log the employee out.
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}
