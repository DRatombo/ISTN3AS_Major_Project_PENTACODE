using System;

namespace Cafe101.Web
{
    public partial class ManagerDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            // =====================================================
            // USER MUST BE LOGGED IN
            // =====================================================

            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // =====================================================
            // MANAGER ACCESS ONLY
            // =====================================================

            string role =
                Session["Role"].ToString();


            if (!role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // =====================================================
            // LOAD PAGE
            // =====================================================

            if (!IsPostBack)
            {
                LoadLoggedInManager();
                LoadCurrentDate();
            }
        }


        // =========================================================
        // LOAD LOGGED-IN MANAGER
        // =========================================================

        private void LoadLoggedInManager()
        {
            string firstName =
                Session["FirstName"]?.ToString() ?? "";

            string surname =
                Session["Surname"]?.ToString() ?? "";

            string role =
                Session["Role"]?.ToString() ?? "Manager";


            string fullName =
                (firstName + " " + surname).Trim();


            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName = "Manager";
            }


            // Welcome card
            lblManagerName.Text =
                !string.IsNullOrWhiteSpace(firstName)
                ? firstName
                : "Manager";


            // Top-right header
            lblTopManagerName.Text =
                fullName;

            lblTopManagerRole.Text =
                role;


            // Initials
            string initials = "";


            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials +=
                    firstName.Substring(0, 1)
                    .ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials +=
                    surname.Substring(0, 1)
                    .ToUpper();
            }


            if (string.IsNullOrWhiteSpace(initials))
            {
                initials = "M";
            }


            lblTopManagerInitials.Text =
                initials;
        }


        // =========================================================
        // CURRENT DATE
        // =========================================================

        private void LoadCurrentDate()
        {
            lblCurrentDate.Text =
                DateTime.Now.ToString(
                    "dddd, dd MMMM yyyy");
        }


        // =========================================================
        // LOGOUT
        // =========================================================

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