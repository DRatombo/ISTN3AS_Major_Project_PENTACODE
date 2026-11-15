using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class StaffHelp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // USER MUST BE LOGGED IN
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }

            string role = Session["Role"].ToString();

            // CHECK STAFF ACCESS
            bool allowed =
                role.Equals("Cashier",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals("Staff",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals("Manager",
                    StringComparison.OrdinalIgnoreCase);

            if (!allowed)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }
            // Determine which navigation the Help page should display
            bool isManager = role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase);

            pnlManagerNavigation.Visible = isManager;
            pnlStaffNavigation.Visible = !isManager;
            pnlReportsHelp.Visible = isManager;
            pnlReportsCard.Visible = isManager;
            pnlAdministrationHelp.Visible = isManager;
            pnlAdministrationCard.Visible = isManager;

            // DISPLAY LOGGED-IN USER'S NAME IN THE HEADER
            string firstName = Convert.ToString(Session["FirstName"]);
            string surname = Convert.ToString(Session["Surname"]);

            string fullName = (firstName + " " + surname).Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = role;
            }

            lblLoggedInUser.Text = fullName;

            // DISPLAY EMPLOYEE INITIALS
            string initials = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials += firstName.Substring(0, 1).ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials += surname.Substring(0, 1).ToUpper();
            }

            if (string.IsNullOrWhiteSpace(initials))
            {
                initials = role.Substring(0, 1).ToUpper();
            }

            lblTopInitials.Text = initials;

            // DISPLAY EMPLOYEE ROLE
            lblTopRole.Text = role;

        }
        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            // Clear all session information
            Session.Clear();
            Session.Abandon();

            // Redirect the user to the Sign In page
            Response.Redirect("~/SignIn.aspx");
        }


    }
}
