using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        // Temporary placeholder model — replace with your real Order class/DB entity later
        public class OrderRow
        {
            public DateTime OrderDate { get; set; }
            public string ItemSummary { get; set; }
            public decimal Total { get; set; }
            public string Status { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            // TEMP sample data — replace with a real database query later,
            // filtered by the logged-in user (e.g. Session["UserId"])
            List<OrderRow> allOrders = new List<OrderRow>
            {
                new OrderRow { OrderDate = DateTime.Now.AddDays(-5),   ItemSummary = "Cappuccino, Butter Croissant", Total = 63.00m, Status = "Completed" },
                new OrderRow { OrderDate = DateTime.Now.AddDays(-20),  ItemSummary = "Breakfast Combo",              Total = 65.00m, Status = "Completed" },
                new OrderRow { OrderDate = DateTime.Now.AddMonths(-2), ItemSummary = "Iced Latte, Blueberry Muffin", Total = 67.00m, Status = "Completed" },
                new OrderRow { OrderDate = DateTime.Now.AddMonths(-5), ItemSummary = "Cheese Toastie",               Total = 32.00m, Status = "Completed" },
                new OrderRow { OrderDate = DateTime.Now.AddMonths(-9), ItemSummary = "Cappuccino x2",                Total = 70.00m, Status = "Completed" },
            };

            int months = int.Parse(ddlFilter.SelectedValue);
            DateTime cutoff = DateTime.Now.AddMonths(-months);

            var filtered = allOrders
                .Where(o => o.OrderDate >= cutoff)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            rptOrders.DataSource = filtered;
            rptOrders.DataBind();

            lblNoOrders.Visible = filtered.Count == 0;
        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}