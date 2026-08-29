using System;

namespace Cafe101.Web
{
    public partial class StaffDashboard :
        System.Web.UI.Page
    {
        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            // -----------------------------------------
            // USER MUST BE LOGGED IN
            // -----------------------------------------

            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return;
            }


            string role =
                Session["Role"].ToString();


            // -----------------------------------------
            // CHECK STAFF ACCESS
            // -----------------------------------------

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
                Response.Redirect(
                    "~/SignIn.aspx");

                return;
            }


            // -----------------------------------------
            // LOAD USER INFORMATION
            // -----------------------------------------

            if (!IsPostBack)
            {
                LoadLoggedInStaff();
            }
        }



        private void LoadLoggedInStaff()
        {
            string firstName =
                Session["FirstName"] != null
                ? Session["FirstName"].ToString()
                : "";


            string surname =
                Session["Surname"] != null
                ? Session["Surname"].ToString()
                : "";


            string role =
                Session["Role"] != null
                ? Session["Role"].ToString()
                : "";


            // -----------------------------------------
            // FULL NAME
            // -----------------------------------------

            string fullName =
                (firstName + " " + surname)
                .Trim();


            if (string.IsNullOrWhiteSpace(fullName))
            {
                fullName =
                    "Staff Member";
            }



            // -----------------------------------------
            // WELCOME MESSAGE
            //
            // Keep first name only:
            // Welcome back, Emily!
            // -----------------------------------------

            lblStaffName.Text =
                !string.IsNullOrWhiteSpace(firstName)
                ? firstName
                : "Staff";



            // -----------------------------------------
            // TOP-RIGHT HEADER
            //
            // Emily Ratasoki
            // Cashier
            // -----------------------------------------

            lblTopStaffName.Text =
                fullName;


            lblTopStaffRole.Text =
                role;



            // -----------------------------------------
            // CREATE INITIALS
            //
            // Emily Ratasoki = ER
            // -----------------------------------------

            string initials = "";


            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials +=
                    firstName
                    .Substring(0, 1)
                    .ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials +=
                    surname
                    .Substring(0, 1)
                    .ToUpper();
            }


            if (string.IsNullOrWhiteSpace(initials))
            {
                initials =
                    "SM";
            }


            lblTopInitials.Text =
                initials;
        }



        protected void lnkLogout_Click(
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