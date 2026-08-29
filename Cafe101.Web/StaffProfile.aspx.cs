using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class WebForm1 :
        System.Web.UI.Page
    {
        private readonly EmployeeManagementService employeeService =
            new EmployeeManagementService();


        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!StaffIsLoggedIn())
            {
                return;
            }


            if (!IsPostBack)
            {
                LoadProfile();
            }
        }


        // ============================================================
        // SECURITY
        // ============================================================

        private bool StaffIsLoggedIn()
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
                .ToString()
                .Trim();


            bool isStaff =
                role.Equals(
                    "Cashier",
                    StringComparison.OrdinalIgnoreCase)
                ||
                role.Equals(
                    "Staff",
                    StringComparison.OrdinalIgnoreCase);


            if (!isStaff)
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return false;
            }


            return true;
        }


        // ============================================================
        // LOAD PROFILE
        // ============================================================

        private void LoadProfile()
        {
            try
            {
                int employeeID =
                    Convert.ToInt32(
                        Session["UserID"]);


                EmployeeAccountDetails employee =
                    employeeService
                    .GetEmployeeByID(
                        employeeID);


                if (employee == null)
                {
                    Session.Clear();
                    Session.Abandon();

                    Response.Redirect(
                        "~/SignIn.aspx");

                    return;
                }


                string firstName =
                    employee.FirstName ?? "";


                string surname =
                    employee.Surname ?? "";


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
                        "Staff Member";
                }


                string role =
                    string.IsNullOrWhiteSpace(
                        employee.Role)
                    ? "Employee"
                    : employee.Role;


                string email =
                    string.IsNullOrWhiteSpace(
                        employee.Email)
                    ? "Not provided"
                    : employee.Email;


                string address =
                    string.IsNullOrWhiteSpace(
                        employee.Address)
                    ? "Not provided"
                    : employee.Address;


                string status =
                    string.IsNullOrWhiteSpace(
                        employee.EmployeeStatus)
                    ? "Active"
                    : employee.EmployeeStatus;


                string hireDate =
                    employee.HireDate.HasValue
                    ? employee.HireDate.Value
                        .ToString(
                            "dd MMMM yyyy")
                    : "Not recorded";


                string initials =
                    CreateInitials(
                        firstName,
                        surname);


                // ====================================================
                // HEADER
                // ====================================================

                lblTopStaffName.Text =
                    fullName;


                lblTopStaffRole.Text =
                    role;


                lblTopInitials.Text =
                    initials;


                // ====================================================
                // PROFILE SUMMARY
                // ====================================================

                lblProfileInitials.Text =
                    initials;


                lblProfileName.Text =
                    fullName;


                lblProfileRole.Text =
                    role;


                lblProfileEmail.Text =
                    email;


                lblProfileHireDate.Text =
                    hireDate;


                // ====================================================
                // PERSONAL INFORMATION
                // ====================================================

                lblFullName.Text =
                    fullName;


                lblPersonalEmail.Text =
                    email;


                lblAddress.Text =
                    address;


                lblRole.Text =
                    role;


                // ====================================================
                // WORK INFORMATION
                // ====================================================

                lblEmployeeID.Text =
                    employee.EmployeeID
                    .ToString();


                lblHireDate.Text =
                    hireDate;


                lblEmployeeStatus.Text =
                    status;


                lblEmployeeStatus.CssClass =
                    status.Equals(
                        "Active",
                        StringComparison.OrdinalIgnoreCase)
                    ? "staff-profile-status-active"
                    : "staff-profile-status-inactive";


                // ====================================================
                // UPDATE SESSION WITH CURRENT DB VALUES
                // ====================================================

                Session["FirstName"] =
                    employee.FirstName;


                Session["Surname"] =
                    employee.Surname;


                Session["Email"] =
                    employee.Email;


                Session["Address"] =
                    employee.Address;


                Session["Role"] =
                    employee.Role;
            }
            catch (Exception ex)
            {
                lblProfileMessage.CssClass =
                    "alert alert-danger d-block";


                lblProfileMessage.Text =
                    "Unable to load your profile. "
                    +
                    ex.Message;
            }
        }


        // ============================================================
        // INITIALS
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
                ? "S"
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