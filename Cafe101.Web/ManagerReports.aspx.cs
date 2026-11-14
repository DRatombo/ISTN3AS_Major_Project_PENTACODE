using System;
using System.Data;                      
using System.Data.SqlClient;            
using System.Web.Services;
using Cafe101.Data;                     
using Cafe101.Logic;

namespace Cafe101.Web
{
    public partial class ManagerReports : System.Web.UI.Page
    {
        private readonly ReportService reportService = new ReportService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ManagerIsLoggedIn()) return;

            if (!IsPostBack)
            {
                LoadManagerHeader();
                LoadReportSummary();
            }
        }

        private bool ManagerIsLoggedIn()
        {
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return false;
            }

            if (!Session["Role"].ToString().Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return false;
            }
            return true;
        }

        private void LoadManagerHeader()
        {
            string firstName = Session["FirstName"]?.ToString() ?? "";
            string surname = Session["Surname"]?.ToString() ?? "";
            string role = Session["Role"]?.ToString() ?? "Manager";

            string fullName = (firstName + " " + surname).Trim();
            if (string.IsNullOrWhiteSpace(fullName)) fullName = "Manager";

            lblTopManagerName.Text = fullName;
            lblTopManagerRole.Text = role;
            lblTopManagerInitials.Text = CreateInitials(firstName, surname);
        }

        private string CreateInitials(string firstName, string surname)
        {
            string initials = "";
            if (!string.IsNullOrWhiteSpace(firstName)) initials += firstName[0].ToString().ToUpper();
            if (!string.IsNullOrWhiteSpace(surname)) initials += surname[0].ToString().ToUpper();
            return string.IsNullOrWhiteSpace(initials) ? "M" : initials;
        }

        protected void DdlReportDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportSummary();
        }

        private void LoadReportSummary()
        {
            try
            {
                var summary = reportService.GetSummaryByDateRange(ddlReportDateRange.SelectedValue);

                lblTotalRevenue.Text = "R" + summary.TotalRevenue.ToString("N2");
                lblCompletedOrders.Text = summary.CompletedOrders.ToString();
                lblAverageOrderValue.Text = "R" + summary.AverageOrderValue.ToString("N2");
            }
            catch
            {
                lblTotalRevenue.Text = "Unavailable";
                lblCompletedOrders.Text = "Unavailable";
                lblAverageOrderValue.Text = "Unavailable";
            }
        }

        // ===================== EXPORT REPORT (PDF BY EMAIL) =====================   NEW

        protected void BtnExport_Click(object sender, EventArgs e)                      // NEW
        {
            try
            {
                string email = GetManagerEmail();
                if (string.IsNullOrWhiteSpace(email))
                {
                    ShowExportMessage("We couldn't find an email address for your account.", false);
                    return;
                }

                string firstName = Session["FirstName"]?.ToString() ?? "";
                string surname = Session["Surname"]?.ToString() ?? "";
                string name = (firstName + " " + surname).Trim();
                if (name == "") name = "Manager";

                string range = ddlReportDateRange.SelectedValue;
                string rangeLabel = ddlReportDateRange.SelectedItem.Text;

                byte[] pdf = ReportPdfBuilder.Build(range, rangeLabel, name);
                string fileName = "Cafe101-Report-" + range + "-" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                ReportEmailSender.Send(email, name, rangeLabel, pdf, fileName);

                ShowExportMessage("Report (" + rangeLabel + ") was sent to " + email + ".", true);
            }
            catch (Exception)
            {
                ShowExportMessage("The report could not be sent. Please try again.", false);
            }
        }

        private string GetManagerEmail()                                                
        {
            string sessionEmail = Session["Email"]?.ToString();
            if (!string.IsNullOrWhiteSpace(sessionEmail)) return sessionEmail;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT Email FROM EmployeeTable WHERE EmployeeID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["UserID"]));

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? null : result.ToString();
            }
        }

        private void ShowExportMessage(string message, bool success)                    // NEW
        {
            lblExportMessage.Text = Server.HtmlEncode(message);
            lblExportMessage.CssClass = "export-message " + (success ? "export-ok" : "export-err");
            lblExportMessage.Visible = true;
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }

        // ===================== CHART WEB METHODS =====================

        [System.Web.Services.WebMethod]
        public static object GetRevenueChartData(string dateRange)
        {
            var service = new ReportService();
            var data = service.GetRevenueTrend(dateRange);
            return new { labels = data.Labels, values = data.Values };
        }

        [System.Web.Services.WebMethod]
        public static object GetCategoryChartData(string dateRange)
        {
            var service = new ReportService();
            var data = service.GetSalesByCategory(dateRange);
            return new { labels = data.Labels, values = data.Values };
        }
    }
}