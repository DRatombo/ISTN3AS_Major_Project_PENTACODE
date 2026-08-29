using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class ManagerProfile : System.Web.UI.Page
    {
        private readonly EmployeeAccountService accountService =
            new EmployeeAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // =============================================
            // USER MUST BE LOGGED IN
            // =============================================

            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // =============================================
            // MANAGER ACCESS ONLY
            // =============================================

            string role = Session["Role"].ToString();

            if (!role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // =============================================
            // LOAD PROFILE
            // =============================================

            if (!IsPostBack)
            {
                LoadManagerProfile();
            }
        }


        // =============================================
        // LOAD MANAGER FROM DATABASE
        // =============================================

        private void LoadManagerProfile()
        {
            try
            {
                int employeeID =
                    Convert.ToInt32(Session["UserID"]);


                EmployeeAccountDetails manager =
                    accountService.GetEmployeeByID(employeeID);


                if (manager == null)
                {
                    lblProfileMessage.CssClass =
                        "d-block text-danger small mt-3";

                    lblProfileMessage.Text =
                        "Manager account information could not be found.";

                    return;
                }


                string firstName =
                    manager.FirstName ?? "";

                string surname =
                    manager.Surname ?? "";

                string email =
                    manager.Email ?? "";

                string address =
                    manager.Address ?? "";

                string role =
                    manager.Role ?? "Manager";


                string fullName =
                    (firstName + " " + surname).Trim();


                if (string.IsNullOrWhiteSpace(fullName))
                {
                    fullName = "Manager";
                }


                string initials =
                    CreateInitials(
                        firstName,
                        surname);


                // =============================================
                // TOP NAVBAR
                // =============================================

                lblTopManagerInitials.Text =
                    initials;

                lblTopManagerName.Text =
                    fullName;

                lblTopManagerRole.Text =
                    role;


                // =============================================
                // PROFILE SUMMARY
                // =============================================

                lblProfileInitials.Text =
                    initials;

                lblProfileName.Text =
                    fullName;

                lblProfileRole.Text =
                    role;

                lblProfileEmail.Text =
                    string.IsNullOrWhiteSpace(email)
                        ? "Not provided"
                        : email;


                // =============================================
                // PERSONAL INFORMATION
                // =============================================

                lblFullName.Text =
                    fullName;

                lblEmail.Text =
                    string.IsNullOrWhiteSpace(email)
                        ? "Not provided"
                        : email;

                lblAddress.Text =
                    string.IsNullOrWhiteSpace(address)
                        ? "Not provided"
                        : address;

                lblRole.Text =
                    role;


                // =============================================
                // WORK INFORMATION
                // =============================================

                lblEmployeeID.Text =
                    employeeID.ToString();

                lblAccountStatus.Text =
                    "Active";


                // =============================================
                // KEEP SESSION CONSISTENT
                // =============================================

                Session["FirstName"] =
                    firstName;

                Session["Surname"] =
                    surname;

                Session["Email"] =
                    email;

                Session["Role"] =
                    role;


                lblProfileMessage.Text = "";
            }
            catch (Exception)
            {
                lblProfileMessage.CssClass =
                    "d-block text-danger small mt-3";

                lblProfileMessage.Text =
                    "Unable to load your profile information.";
            }
        }


        // =============================================
        // CREATE INITIALS
        // =============================================

        private string CreateInitials(
            string firstName,
            string surname)
        {
            string initials = "";


            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials +=
                    firstName.Substring(0, 1).ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials +=
                    surname.Substring(0, 1).ToUpper();
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

            Response.Redirect("~/SignIn.aspx");
        }
    }
}