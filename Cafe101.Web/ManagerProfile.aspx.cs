
using Cafe101.Logic;
using System;
using System.Web;

namespace Cafe101.Web
{
    public partial class ManagerProfile : System.Web.UI.Page
    {
        private readonly EmployeeAccountService accountService =
            new EmployeeAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // =============================================
            // CHECK THAT THE USER IS LOGGED IN
            // =============================================

            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                RedirectToSignIn();
                return;
            }

            // =============================================
            // CHECK THAT THE LOGGED-IN USER IS A MANAGER
            // =============================================

            string role = Convert.ToString(Session["Role"]);

            role = role.Trim();

            if (!role.Equals("Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                RedirectToSignIn();
                return;
            }

            // =============================================
            // LOAD PROFILE ON FIRST PAGE LOAD
            // =============================================

            if (!IsPostBack)
            {
                LoadManagerProfile();
            }
        }

        // =============================================
        // REDIRECT TO SIGN IN
        // =============================================

        private void RedirectToSignIn()
        {
            Response.Redirect("~/SignIn.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        // =============================================
        // LOAD MANAGER DETAILS FROM DATABASE
        // =============================================

        private void LoadManagerProfile()
        {
            try
            {
                // Get the logged-in employee ID
                int employeeID =
                    Convert.ToInt32(Session["UserID"]);

                // Retrieve manager information
                EmployeeAccountDetails manager =
                    accountService.GetEmployeeByID(employeeID);

                // Check whether the manager exists
                if (manager == null)
                {
                    lblProfileMessage.CssClass =
                        "d-block text-danger small mt-3";

                    lblProfileMessage.Text =
                        "Manager account information could not be found.";

                    return;
                }

                // =============================================
                // GET MANAGER INFORMATION
                // =============================================

                string firstName = manager.FirstName ?? "";
                string surname = manager.Surname ?? "";
                string email = manager.Email ?? "";
                string address = manager.Address ?? "";
                string role = manager.Role ?? "Manager";

                string fullName =
                    (firstName + " " + surname).Trim();

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    fullName = "Manager";
                }

                // Create initials for profile avatar
                string initials =
                    CreateInitials(firstName, surname);

                // =============================================
                // TOP NAVBAR
                // =============================================

                lblTopManagerInitials.Text = initials;
                lblTopManagerName.Text = fullName;
                lblTopManagerRole.Text = role;

                // =============================================
                // PROFILE SUMMARY
                // =============================================

                lblProfileInitials.Text = initials;
                lblProfileName.Text = fullName;
                lblProfileRole.Text = role;

                lblProfileEmail.Text =
                    string.IsNullOrWhiteSpace(email)
                    ? "Not provided"
                    : email;

                // =============================================
                // PERSONAL INFORMATION
                // =============================================

                lblFullName.Text = fullName;

                lblEmail.Text =
                    string.IsNullOrWhiteSpace(email)
                    ? "Not provided"
                    : email;

                lblAddress.Text =
                    string.IsNullOrWhiteSpace(address)
                    ? "Not provided"
                    : address;

                lblRole.Text = role;

                // =============================================
                // WORK INFORMATION
                // =============================================

                lblEmployeeID.Text = employeeID.ToString();

                lblAccountStatus.Text = "Active";

                // =============================================
                // UPDATE SESSION INFORMATION
                // =============================================

                Session["FirstName"] = firstName;
                Session["Surname"] = surname;
                Session["Email"] = email;

                // Do not change the authenticated role here.
                // The role was already checked above.

                lblProfileMessage.Text = "";
            }
            catch (FormatException)
            {
                lblProfileMessage.CssClass =
                    "d-block text-danger small mt-3";

                lblProfileMessage.Text =
                    "Your account session contains an invalid employee ID.";
            }
            catch (Exception)
            {
                lblProfileMessage.CssClass =
                    "d-block text-danger small mt-3";

                lblProfileMessage.Text =
                    "Unable to load your profile information. Please try again.";
            }
        }

        // =============================================
        // CREATE PROFILE INITIALS
        // =============================================

        private string CreateInitials(
            string firstName,
            string surname)
        {
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
                initials = "M";
            }

            return initials;
        }

        // =============================================
        // LOGOUT
        // =============================================

        protected void LnkLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
