using System;

namespace Cafe101.Web
{
    public partial class CustomerDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User must be logged in
            if (Session["UserID"] == null ||
                Session["UserType"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            // User must be a customer
            if (!Session["UserType"]
                .ToString()
                .Equals(
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (Session["FirstName"] != null)
                {
                    string firstName =
                        Session["FirstName"].ToString();

                    // Welcome message
                    litFirstName.Text = firstName;

                    // Name in top-right corner
                    lblTopCustomerName.Text = firstName;

                    // First letter for profile circle
                    if (!string.IsNullOrWhiteSpace(firstName))
                    {
                        lblCustomerInitials.Text =
                            firstName.Substring(0, 1).ToUpper();
                    }
                }
            }
        }


        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}