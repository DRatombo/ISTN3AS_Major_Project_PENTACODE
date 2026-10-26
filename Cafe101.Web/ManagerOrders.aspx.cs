using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class ManagerOrders : System.Web.UI.Page
    {
        // =========================================================
        // SETTINGS AND CONNECTION
        // =========================================================
        private const int PageSize = 6;
        private static readonly CultureInfo MoneyCulture =
            CultureInfo.GetCultureInfo("en-ZA");

        private string ConnectionString
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["Cafe101Db"].ConnectionString;
            }
        }

        // =========================================================
        // PAGE LOAD AND MANAGER SECURITY
        // =========================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ManagerIsLoggedIn())
                return;

            if (!IsPostBack)
            {
                LoadManagerHeader();
                LoadOrderCounts();
                LoadOrders();
            }
        }

        private bool ManagerIsLoggedIn()
        {
            if (Session["UserID"] == null || Session["Role"] == null ||
                !string.Equals(Session["Role"].ToString(), "Manager",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return false;
            }

            return true;
        }

        // The existing project uses FindPageControl rather than relying
        // on generated .designer.cs fields. This works with nested panels.
        private T FindPageControl<T>(string id) where T : Control
        {
            ContentPlaceHolder content =
                Master.FindControl("MainContent") as ContentPlaceHolder;

            if (content == null)
                throw new InvalidOperationException("MainContent was not found in Site.Master.");

            T result = FindNestedControl<T>(content, id);
            if (result == null)
                throw new InvalidOperationException("ManagerOrders.aspx is missing: " + id);

            return result;
        }

        private T FindNestedControl<T>(Control parent, string id) where T : Control
        {
            foreach (Control child in parent.Controls)
            {
                if (child.ID == id && child is T)
                    return (T)child;

                T found = FindNestedControl<T>(child, id);
                if (found != null)
                    return found;
            }

            return null;
        }

        private void LoadManagerHeader()
        {
            string firstName = Convert.ToString(Session["FirstName"]) ?? "";
            string surname = Convert.ToString(Session["Surname"]) ?? "";
            string fullName = (firstName + " " + surname).Trim();

            FindPageControl<Label>("lblTopManagerName").Text =
                HttpUtility.HtmlEncode(fullName.Length == 0 ? "Manager" : fullName);
            FindPageControl<Label>("lblTopManagerRole").Text = "Manager";
            FindPageControl<Label>("lblTopManagerInitials").Text =
                CreateInitials(firstName, surname);
        }

        private string CreateInitials(string firstName, string surname)
        {
            string initials = "";
            if (!string.IsNullOrWhiteSpace(firstName))
                initials += firstName.Substring(0, 1).ToUpperInvariant();
            if (!string.IsNullOrWhiteSpace(surname))
                initials += surname.Substring(0, 1).ToUpperInvariant();
            return initials.Length == 0 ? "M" : initials;
        }

        // =========================================================
        // REAL SUMMARY COUNTS (ALL ORDERS, NOT THE CURRENT FILTER)
        // =========================================================
        private void LoadOrderCounts()
        {
            const string sql = @"
                SELECT
                    COUNT(*) AS TotalOrders,
                    COALESCE(SUM(CASE WHEN LTRIM(RTRIM(OrderStatus)) = 'Pending'
                        THEN 1 ELSE 0 END), 0) AS PendingOrders,
                    COALESCE(SUM(CASE WHEN LTRIM(RTRIM(OrderStatus)) = 'Completed'
                        THEN 1 ELSE 0 END), 0) AS CompletedOrders,
                    COALESCE(SUM(CASE WHEN LTRIM(RTRIM(OrderStatus)) = 'Declined'
                        THEN 1 ELSE 0 END), 0) AS DeclinedOrders
                FROM dbo.OrderTable";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    FindPageControl<Label>("lblTotalOrders").Text =
                        Convert.ToString(r["TotalOrders"]);
                    FindPageControl<Label>("lblPendingOrders").Text =
                        Convert.ToString(r["PendingOrders"]);
                    FindPageControl<Label>("lblCompletedOrders").Text =
                        Convert.ToString(r["CompletedOrders"]);
                    FindPageControl<Label>("lblDeclinedOrders").Text =
                        Convert.ToString(r["DeclinedOrders"]);
                }
            }
        }

        // =========================================================
        // FILTERS FOR ORDER LIST AND CSV EXPORT
        // =========================================================
        private const string FilterWhere = @"
            FROM dbo.OrderTable o
            LEFT JOIN dbo.CustomerTable c ON c.CustomerID = o.CustomerID
            WHERE
                (@Search = '' OR
                 CONVERT(VARCHAR(20), o.OrderID) LIKE @Pattern OR
                 CONVERT(VARCHAR(20), o.CustomerID) LIKE @Pattern OR
                 (COALESCE(c.FirstName, '') + ' ' +
                  COALESCE(c.Surname, '')) LIKE @Pattern)
                AND (@Status = '' OR LTRIM(RTRIM(o.OrderStatus)) = @Status)
                AND (@StartDate IS NULL OR o.OrderDateTime >= @StartDate)
                AND (@EndDate IS NULL OR o.OrderDateTime < @EndDate)";

        private const string SelectOrderColumns = @"
            SELECT
                o.OrderID, o.CustomerID, o.OrderType,
                COALESCE(NULLIF(LTRIM(RTRIM(
                    COALESCE(c.FirstName, '') + ' ' +
                    COALESCE(c.Surname, ''))), ''), 'Walk-in Customer') AS CustomerName,
                COALESCE((SELECT SUM(i.QuantityOrdered)
                    FROM dbo.ItemOrder i WHERE i.OrderID = o.OrderID), 0) AS ItemCount,
                o.TotalAmountDue, o.PaymentMethod, o.OrderStatus, o.OrderDateTime ";

        private void AddFilterParameters(SqlCommand cmd)
        {
            string search = FindPageControl<TextBox>("txtOrderSearch").Text.Trim();
            string status = FindPageControl<DropDownList>("ddlOrderStatus").SelectedValue;
            string dateRange = FindPageControl<DropDownList>("ddlDateRange").SelectedValue;

            // Brackets, percent and underscore have special meaning in LIKE.
            string safeSearch = search.Replace("[", "[[]")
                .Replace("%", "[%]").Replace("_", "[_]");

            DateTime? start = null;
            DateTime? end = null;
            if (dateRange == "Today")
                start = DateTime.Today;
            else if (dateRange == "7")
                start = DateTime.Today.AddDays(-6);
            else if (dateRange == "30")
                start = DateTime.Today.AddDays(-29);

            if (start.HasValue)
                end = DateTime.Today.AddDays(1);

            cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 200).Value = search;
            cmd.Parameters.Add("@Pattern", SqlDbType.NVarChar, 220).Value =
                "%" + safeSearch + "%";
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 30).Value = status;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value =
                start.HasValue ? (object)start.Value : DBNull.Value;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value =
                end.HasValue ? (object)end.Value : DBNull.Value;
        }

        private int PageIndex
        {
            get { return ViewState["PageIndex"] == null ? 0 : (int)ViewState["PageIndex"]; }
            set { ViewState["PageIndex"] = Math.Max(0, value); }
        }

        // =========================================================
        // LOAD FILTERED ORDERS (10 RECORDS PER PAGE)
        // =========================================================
        private void LoadOrders()
        {
            DataTable orders = new DataTable();
            int totalRows;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand countCmd = new SqlCommand(
                    "SELECT COUNT(*) " + FilterWhere, conn))
                {
                    AddFilterParameters(countCmd);
                    totalRows = Convert.ToInt32(countCmd.ExecuteScalar());
                }

                int totalPages = Math.Max(1, (totalRows + PageSize - 1) / PageSize);
                if (PageIndex >= totalPages)
                    PageIndex = totalPages - 1;

                string sql = SelectOrderColumns + FilterWhere + @"
                    ORDER BY o.OrderDateTime DESC, o.OrderID DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddFilterParameters(cmd);
                    cmd.Parameters.Add("@Offset", SqlDbType.Int).Value = PageIndex * PageSize;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(orders);
                }

                Repeater rows = FindPageControl<Repeater>("rptOrders");
                rows.DataSource = orders;
                rows.DataBind();

                FindPageControl<Panel>("pnlNoOrders").Visible = (totalRows == 0);

                LinkButton previous = FindPageControl<LinkButton>("lnkPrevious");
                LinkButton next = FindPageControl<LinkButton>("lnkNext");
                previous.Enabled = PageIndex > 0;
                next.Enabled = PageIndex < totalPages - 1;

                FindPageControl<Label>("lblCurrentPage").Text =
                    "Page " + (PageIndex + 1) + " of " + totalPages;

                int first = totalRows == 0 ? 0 : PageIndex * PageSize + 1;
                int last = Math.Min(totalRows, (PageIndex + 1) * PageSize);
                FindPageControl<Label>("lblShowing").Text =
                    "Showing " + first + "–" + last + " of " + totalRows + " matching orders";
            }
        }

        // =========================================================
        // SEARCH, FILTER, REFRESH AND PAGINATION BUTTONS
        // =========================================================
        protected void ApplyFilters_Click(object sender, EventArgs e)
        {
            PageIndex = 0;
            HideSelectedOrder();
            LoadOrders();
        }

        protected void ApplyFilters_Changed(object sender, EventArgs e)
        {
            ApplyFilters_Click(sender, e);
        }

        protected void RefreshOrders_Click(object sender, EventArgs e)
        {
            FindPageControl<TextBox>("txtOrderSearch").Text = "";
            FindPageControl<DropDownList>("ddlOrderStatus").SelectedIndex = 0;
            FindPageControl<DropDownList>("ddlDateRange").SelectedIndex = 0;
            PageIndex = 0;
            HideSelectedOrder();
            LoadOrderCounts();
            LoadOrders();
        }

        protected void PreviousPage_Click(object sender, EventArgs e)
        {
            PageIndex--;
            HideSelectedOrder();
            LoadOrders();
        }

        protected void NextPage_Click(object sender, EventArgs e)
        {
            PageIndex++;
            HideSelectedOrder();
            LoadOrders();
        }

        private void HideSelectedOrder()
        {
            FindPageControl<HiddenField>("hfSelectedOrderID").Value = "";
            FindPageControl<Panel>("pnlSelectedOrder").Visible = false;
            FindPageControl<Panel>("pnlSelectPrompt").Visible = true;
        }

        // =========================================================
        // VIEW THE ORDER SELECTED BY ITS UNIQUE ORDER ID
        // =========================================================
        protected void ViewOrder_Command(object sender, CommandEventArgs e)
        {
            if (!ManagerIsLoggedIn()) return;

            int orderID;
            if (e.CommandArgument == null ||
                !int.TryParse(e.CommandArgument.ToString(), out orderID))
                return;

            LoadSelectedOrder(orderID);
        }

        private void LoadSelectedOrder(int orderID)
        {
            const string orderSql = @"
                SELECT
                    o.OrderID, o.CustomerID, o.EmployeeID, o.OrderType,
                    o.OrderDateTime, o.EventDate, o.EventTime,
                    o.OrderStatus, o.PaymentMethod, o.TotalAmountDue,
                    COALESCE(NULLIF(LTRIM(RTRIM(
                        COALESCE(c.FirstName, '') + ' ' +
                        COALESCE(c.Surname, ''))), ''), 'Walk-in Customer') AS CustomerName,
                    c.Email
                FROM dbo.OrderTable o
                LEFT JOIN dbo.CustomerTable c ON c.CustomerID = o.CustomerID
                WHERE o.OrderID = @OrderID";

            const string itemSql = @"
                SELECT
                    COALESCE(m.MenuItemName,
                        'Item #' + CONVERT(VARCHAR(20), i.MenuItemID)) AS MenuItemName,
                    i.QuantityOrdered, i.SubTotal
                FROM dbo.ItemOrder i
                LEFT JOIN dbo.MenuItemsTable m ON m.MenuItemID = i.MenuItemID
                WHERE i.OrderID = @OrderID
                ORDER BY i.MenuItemID";

            decimal recordedTotal = 0m;
            bool found = false;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(orderSql, conn))
                {
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            found = true;
                            FindPageControl<Label>("lblDetailOrderID").Text =
                                Convert.ToString(r["OrderID"]);
                            FindPageControl<Label>("lblDetailCustomerID").Text =
                                r["CustomerID"] == DBNull.Value ? "Not recorded" : Convert.ToString(r["CustomerID"]);
                            FindPageControl<Label>("lblDetailCustomer").Text =
                                HttpUtility.HtmlEncode(Convert.ToString(r["CustomerName"]));
                            FindPageControl<Label>("lblDetailEmail").Text =
                                r["Email"] == DBNull.Value ? "Email not recorded" :
                                HttpUtility.HtmlEncode(Convert.ToString(r["Email"]));
                            string type = Convert.ToString(r["OrderType"]);
                            FindPageControl<Label>("lblDetailType").Text = HttpUtility.HtmlEncode(type);
                            FindPageControl<Label>("lblDetailPayment").Text =
                                HttpUtility.HtmlEncode(Convert.ToString(r["PaymentMethod"]));
                            FindPageControl<Label>("lblDetailEmployeeID").Text =
                                r["EmployeeID"] == DBNull.Value ? "Not recorded" : Convert.ToString(r["EmployeeID"]);
                            string status = Convert.ToString(r["OrderStatus"]);
                            Label statusLabel = FindPageControl<Label>("lblDetailStatus");
                            statusLabel.Text = HttpUtility.HtmlEncode(status);
                            statusLabel.CssClass = "order-status " + GetStatusCssClass(status);
                            FindPageControl<Label>("lblDetailDate").Text =
                                r["OrderDateTime"] == DBNull.Value ? "Date not recorded" :
                                Convert.ToDateTime(r["OrderDateTime"]).ToString("dd MMM yyyy HH:mm");

                            recordedTotal = r["TotalAmountDue"] == DBNull.Value ? 0m :
                                Convert.ToDecimal(r["TotalAmountDue"]);
                            FindPageControl<Label>("lblDetailTotal").Text =
                                recordedTotal.ToString("N2", MoneyCulture);

                            Panel eventPanel = FindPageControl<Panel>("pnlEventDetails");
                            eventPanel.Visible = string.Equals(type, "Event", StringComparison.OrdinalIgnoreCase);
                            if (eventPanel.Visible)
                            {
                                FindPageControl<Label>("lblDetailEventDate").Text =
                                    r["EventDate"] == DBNull.Value ? "Not recorded" :
                                    Convert.ToDateTime(r["EventDate"]).ToString("dd MMM yyyy");

                                string eventTime = "Not recorded";
                                if (r["EventTime"] != DBNull.Value)
                                {
                                    if (r["EventTime"] is TimeSpan)
                                        eventTime = ((TimeSpan)r["EventTime"]).ToString(@"hh\:mm");
                                    else
                                        eventTime = Convert.ToString(r["EventTime"]);
                                }
                                FindPageControl<Label>("lblDetailEventTime").Text =
                                    HttpUtility.HtmlEncode(eventTime);
                            }
                        }
                    }
                }

                if (!found)
                {
                    HideSelectedOrder();
                    return;
                }

                DataTable items = new DataTable();
                using (SqlCommand cmd = new SqlCommand(itemSql, conn))
                {
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(items);
                }

                Repeater itemRepeater = FindPageControl<Repeater>("rptOrderItems");
                itemRepeater.DataSource = items;
                itemRepeater.DataBind();
                FindPageControl<Label>("lblNoOrderItems").Visible = (items.Rows.Count == 0);

                decimal itemSubtotal = 0m;
                foreach (DataRow row in items.Rows)
                {
                    if (row["SubTotal"] != DBNull.Value)
                        itemSubtotal += Convert.ToDecimal(row["SubTotal"]);
                }
                FindPageControl<Label>("lblDetailSubtotal").Text =
                    itemSubtotal.ToString("N2", MoneyCulture);

                Label difference = FindPageControl<Label>("lblAmountDifference");
                difference.Visible = Math.Abs(itemSubtotal - recordedTotal) > 0.01m;
                if (difference.Visible)
                    difference.Text = "The recorded order total differs from the sum of its item subtotals. " +
                        "Check the order/checkout data before treating it as a receipt.";
            }

            FindPageControl<HiddenField>("hfSelectedOrderID").Value = orderID.ToString();
            FindPageControl<Panel>("pnlSelectPrompt").Visible = false;
            FindPageControl<Panel>("pnlSelectedOrder").Visible = true;
        }

        // =========================================================
        // EXPORT THE CURRENT FILTERED LIST, NOT JUST PAGE 1
        // =========================================================
        protected void ExportOrders_Click(object sender, EventArgs e)
        {
            if (!ManagerIsLoggedIn()) return;

            DataTable data = new DataTable();
            string sql = SelectOrderColumns + FilterWhere +
                " ORDER BY o.OrderDateTime DESC, o.OrderID DESC";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                AddFilterParameters(cmd);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(data);
            }

            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Order ID,Customer ID,Customer,Order Type,Total Items,Amount (ZAR),Payment,Status,Order Date");
            foreach (DataRow r in data.Rows)
            {
                string[] cells =
                {
                    Convert.ToString(r["OrderID"]), Convert.ToString(r["CustomerID"]),
                    Convert.ToString(r["CustomerName"]), Convert.ToString(r["OrderType"]),
                    Convert.ToString(r["ItemCount"]),
                    r["TotalAmountDue"] == DBNull.Value ? "" :
                        Convert.ToDecimal(r["TotalAmountDue"]).ToString("0.00", CultureInfo.InvariantCulture),
                    Convert.ToString(r["PaymentMethod"]), Convert.ToString(r["OrderStatus"]),
                    r["OrderDateTime"] == DBNull.Value ? "" :
                        Convert.ToDateTime(r["OrderDateTime"]).ToString("yyyy-MM-dd HH:mm:ss")
                };

                for (int i = 0; i < cells.Length; i++)
                    cells[i] = CsvCell(cells[i]);

                csv.AppendLine(string.Join(",", cells));
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("Content-Disposition",
                "attachment; filename=Cafe101_Orders_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
            Response.Write("\uFEFF" + csv.ToString());
            Response.Flush();
            Response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        // Quote CSV cells and prevent spreadsheet-formula injection.
        private string CsvCell(string value)
        {
            string s = value ?? "";
            if (s.Length > 0 && (s[0] == '=' || s[0] == '+' || s[0] == '-' ||
                s[0] == '@' || s[0] == '\t' || s[0] == '\r' || s[0] == '\n'))
                s = "'" + s;
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }

        // =========================================================
        // COLOURED STATUS BADGES MATCH THE REAL DATABASE VALUES
        // =========================================================
        protected string GetStatusCssClass(object value)
        {
            string status = value == null || value == DBNull.Value
                ? "" : Convert.ToString(value).Trim().ToLowerInvariant();
            switch (status)
            {
                case "pending": return "status-pending";
                case "completed": return "status-completed";
                case "declined": return "status-declined";
                default: return "";
            }
        }

        // =========================================================
        // LOGOUT
        // =========================================================
        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }
    }
}
