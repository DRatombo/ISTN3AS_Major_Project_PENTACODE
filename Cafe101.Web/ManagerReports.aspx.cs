using System;
using System.Web.Services;
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