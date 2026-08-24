using System;

namespace Cafe101.Web
{
    public partial class ManagerDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Make sure someone is logged in
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            // Make sure they are actually a manager
            string role = Session["Role"].ToString();

            if (!role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            // Display logged-in manager's name
            if (!IsPostBack)
            {
                if (Session["FirstName"] != null)
                {
                    lblManagerName.Text =
                        Session["FirstName"].ToString();
                    lblTopManagerName.Text = Session["FirstName"].ToString();
                }
            }
        }

        protected void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Default.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}