using System;

namespace Cafe101.Web
{
    public partial class ManagerReports :
        System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!ManagerIsLoggedIn())
            {
                return;
            }


            if (!IsPostBack)
            {
                LoadManagerHeader();
            }
        }


        // ============================================================
        // SECURITY
        // ============================================================

        private bool ManagerIsLoggedIn()
        {
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return false;
            }


            string role =
                Session["Role"]
                .ToString();


            if (!role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return false;
            }


            return true;
        }


        // ============================================================
        // LOAD MANAGER HEADER
        // ============================================================

        private void LoadManagerHeader()
        {
            string firstName =
                Session["FirstName"]?.ToString()
                ?? "";


            string surname =
                Session["Surname"]?.ToString()
                ?? "";


            string role =
                Session["Role"]?.ToString()
                ?? "Manager";


            string fullName =
                (
                    firstName
                    +
                    " "
                    +
                    surname
                ).Trim();


            if (string.IsNullOrWhiteSpace(
                fullName))
            {
                fullName =
                    "Manager";
            }


            lblTopManagerName.Text =
                fullName;


            lblTopManagerRole.Text =
                role;


            lblTopManagerInitials.Text =
                CreateInitials(
                    firstName,
                    surname);
        }


        // ============================================================
        // CREATE INITIALS
        // ============================================================

        private string CreateInitials(
            string firstName,
            string surname)
        {
            string initials =
                "";


            if (!string.IsNullOrWhiteSpace(
                firstName))
            {
                initials +=
                    firstName
                    .Substring(0, 1)
                    .ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(
                surname))
            {
                initials +=
                    surname
                    .Substring(0, 1)
                    .ToUpper();
            }


            return string.IsNullOrWhiteSpace(
                initials)
                ? "M"
                : initials;
        }


        // ============================================================
        // LOGOUT
        // ============================================================

        protected void LnkLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();

            Session.Abandon();


            Response.Redirect(
                "~/SignIn.aspx");
        }
    }
}