using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class SignUp : System.Web.UI.Page
    {
        private AuthenticationService authService =
            new AuthenticationService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnJoin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            SignUpResult result =
                authService.SignUpCustomer(
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtPhone.Text,
                    txtStreetAddress.Text,
                    txtSuburb.Text,
                    txtCity.Text,
                    txtEmail.Text,
                    txtPassword.Text,
                    chkTerms.Checked
                );

            if (!result.Success)
            {
                lblMessage.CssClass =
                    "d-block text-danger small mb-3";

                lblMessage.Text = result.Message;

                return;
            }

            /*
             * Since they have literally just created the account,
             * we can sign them into the website immediately.
             */

            Session["UserID"] = result.CustomerID;
            Session["UserType"] = "Customer";
            Session["Role"] = "Customer";
            Session["FirstName"] =
                txtFirstName.Text.Trim();

            Session["Email"] =
                txtEmail.Text.Trim();

            Response.Redirect(
                "~/CustomerDashboard.aspx");
        }
    }
}