using System;
using System.Web;
using System.Web.Script.Serialization;
using Cafe101.Logic;

namespace Cafe101.Web
{
    public class ReportData : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["Role"] == null ||
                !context.Session["Role"].ToString().Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 401;
                return;
            }

            string type = context.Request["type"];
            string dateRange = context.Request["dateRange"] ?? "AllTime";

            var service = new ReportService();
            object result;

            switch (type)
            {
                case "category":
                    var cat = service.GetSalesByCategory(dateRange);
                    result = new { labels = cat.Labels, values = cat.Values };
                    break;

                case "staff":
                    var staff = service.GetStaffPerformance(dateRange);
                    result = new { labels = staff.Labels, values = staff.Values };
                    break;

                case "popular":
                    result = service.GetPopularItems(dateRange);
                    break;

                case "lowstock":
                    result = service.GetLowStock();
                    break;

                case "dashcards":
                    result = service.GetDashboardCards();
                    break;

                case "recent":
                    result = service.GetRecentOrders();
                    break;

                case "dashstaff":
                    result = service.GetDashboardStaff();
                    break;

                default:
                    var rev = service.GetRevenueTrend(dateRange);
                    result = new { labels = rev.Labels, values = rev.Values };
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(result));
        }

        public bool IsReusable { get { return false; } }
    }
}