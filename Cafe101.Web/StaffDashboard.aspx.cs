using System;

namespace Cafe101.Web
{
    public partial class StaffDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Make sure a user is logged in
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            string role = Session["Role"].ToString();

            // Staff/Cashier OR Manager can access this page
            bool allowed =
                role.Equals(
                    "Cashier",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals(
                    "Staff",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals(
                    "Manager",
                    StringComparison.OrdinalIgnoreCase);

            if (!allowed)
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

                    lblStaffName.Text = firstName;
                    lblTopStaffName.Text = firstName;
                }
            }
        }

        protected void lnkLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}