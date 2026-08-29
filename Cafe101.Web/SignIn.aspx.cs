using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class SignIn :
        System.Web.UI.Page
    {
        private readonly AuthenticationService authService =
            new AuthenticationService();


        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            // Nothing required here yet
        }


        // ============================================================
        // SIGN IN
        // ============================================================

        protected void BtnSignIn_Click(
            object sender,
            EventArgs e)
        {
            lblMessage.Text = "";


            LoginResult result =
                authService.SignIn(
                    txtEmail.Text,
                    txtPassword.Text);


            // ========================================================
            // LOGIN FAILED
            // ========================================================

            if (!result.Success)
            {
                lblMessage.CssClass =
                    "d-block text-danger small mb-3";


                lblMessage.Text =
                    result.Message;


                return;
            }


            // ========================================================
            // CREATE SESSION
            // ========================================================

            Session["UserID"] =
                result.UserID;


            Session["UserType"] =
                result.UserType;


            Session["Role"] =
                result.Role;


            Session["FirstName"] =
                result.FirstName;


            Session["Surname"] =
                result.Surname;


            Session["Email"] =
                result.Email;


            Session["Address"] =
                result.Address;


            Session["PhoneNumber"] =
                result.PhoneNumber;


            // ========================================================
            // CUSTOMER
            // ========================================================

            if ((result.UserType ?? "")
                .Equals(
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/CustomerDashboard.aspx");

                return;
            }


            // ========================================================
            // EMPLOYEE ROLE
            // ========================================================

            string role =
                (result.Role ?? "")
                .Trim();


            // ========================================================
            // MANAGER
            // ========================================================

            if (role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/ManagerDashboard.aspx");

                return;
            }


            // ========================================================
            // CASHIER / STAFF
            // ========================================================

            if (role.Equals(
                    "Cashier",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals(
                    "Staff",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/StaffDashboard.aspx");

                return;
            }


            // ========================================================
            // KITCHEN STAFF
            // ========================================================

           /* if (role.Equals(
                "Kitchen Staff",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/KitchenDashboard.aspx");

                return;
            }*/


            // ========================================================
            // UNKNOWN EMPLOYEE ROLE
            // ========================================================

            Session.Clear();
            Session.Abandon();


            lblMessage.CssClass =
                "d-block text-danger small mb-3";


            lblMessage.Text =
                "Your account does not have a valid system role.";
        }
    }
}