using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class SignIn : System.Web.UI.Page
    {
        private AuthenticationService authService =
            new AuthenticationService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            LoginResult result =
                authService.SignIn(
                    txtEmail.Text,
                    txtPassword.Text
                );

            if (!result.Success)
            {
                lblMessage.CssClass =
                    "d-block text-danger small mb-3";

                lblMessage.Text =
                    result.Message;

                return;
            }

            // ----------------------------------------
            // CREATE USER SESSION
            // ----------------------------------------

            Session["UserID"] = result.UserID;
            Session["UserType"] = result.UserType;
            Session["Role"] = result.Role;
            Session["FirstName"] = result.FirstName;
            Session["Email"] = result.Email;


            // ----------------------------------------
            // CUSTOMER
            // ----------------------------------------

            if (result.UserType == "Customer")
            {
                Response.Redirect(
                    "~/CustomerDashboard.aspx");

                return;
            }


            // ----------------------------------------
            // MANAGER
            // ----------------------------------------

            if (result.Role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/ManagerDashboard.aspx");

                return;
            }


            // ----------------------------------------
            // CASHIER / STAFF
            // ----------------------------------------

            if (result.Role.Equals(
                    "Cashier",
                    StringComparison.OrdinalIgnoreCase)
                ||
                result.Role.Equals(
                    "Staff",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/StaffDashboard.aspx");

                return;
            }


            // Unknown employee role
            Session.Clear();

            lblMessage.Text =
                "Your account does not have a valid system role.";
        }
    }
}