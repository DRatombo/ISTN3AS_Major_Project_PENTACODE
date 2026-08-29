using System;

namespace Cafe101.Web
{
    public partial class StaffOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User must be logged in
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            string role = Session["Role"].ToString();

            // Cashier / Staff / Manager may access this page
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
                LoadLoggedInStaff();
            }
        }

        private void LoadLoggedInStaff()
        {
            string firstName =
                Session["FirstName"]?.ToString() ?? "";

            string surname =
                Session["Surname"]?.ToString() ?? "";

            string role =
                Session["Role"]?.ToString() ?? "";

            string fullName =
                (firstName + " " + surname).Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = "Staff Member";
            }

            // Name and role
            lblTopStaffName.Text = fullName;
            lblTopStaffRole.Text = role;

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
                initials = "SM";
            }

            lblTopInitials.Text = initials;
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