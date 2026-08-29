using System;

namespace Cafe101.Web
{
    public partial class CustomerDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (Session["UserID"] == null ||
                Session["UserType"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

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
                LoadLoggedInCustomer();
            }
        }


        private void LoadLoggedInCustomer()
        {
            string firstName =
                Session["FirstName"]?.ToString() ?? "";

            string surname =
                Session["Surname"]?.ToString() ?? "";

            string fullName =
                (firstName + " " + surname).Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = "Customer";
            }

            // Welcome message
            litFirstName.Text =
                !string.IsNullOrWhiteSpace(firstName)
                ? firstName
                : "Customer";

            // Top-right full name
            lblTopCustomerName.Text =
                fullName;

            // Initials
            string initials = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials += firstName
                    .Substring(0, 1)
                    .ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials += surname
                    .Substring(0, 1)
                    .ToUpper();
            }

            if (string.IsNullOrWhiteSpace(initials))
            {
                initials = "C";
            }

            lblCustomerInitials.Text =
                initials;
        }


        protected void lnkLogOut_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}