using Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class ManagerStaff :
        System.Web.UI.Page
    {
        private readonly EmployeeManagementService employeeService =
            new EmployeeManagementService();


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

                LoadRoleFilter();

                LoadEmployees();
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
                Session["Role"].ToString();


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
        // MANAGER HEADER
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
                (firstName + " " + surname).Trim();


            if (string.IsNullOrWhiteSpace(fullName))
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
        // ROLE FILTER
        // ============================================================

        private void LoadRoleFilter()
        {
            ddlRole.Items.Clear();


            ddlRole.Items.Add(
                new ListItem(
                    "All Roles",
                    ""));


            List<EmployeeAccountDetails> employees =
                employeeService
                .GetAllEmployees();


            List<string> roles =
                employees
                .Select(
                    employee =>
                        employee.Role)
                .Where(
                    role =>
                        !string.IsNullOrWhiteSpace(
                            role))
                .Distinct(
                    StringComparer.OrdinalIgnoreCase)
                .OrderBy(
                    role =>
                        role)
                .ToList();


            foreach (string role in roles)
            {
                ddlRole.Items.Add(
                    new ListItem(
                        role,
                        role));
            }
        }


        // ============================================================
        // LOAD EMPLOYEES
        // ============================================================

        private void LoadEmployees()
        {
            try
            {
                List<EmployeeAccountDetails> allEmployees =
                    employeeService
                    .GetAllEmployees();


                List<EmployeeAccountDetails> filteredEmployees =
                    allEmployees;


                // ====================================================
                // SEARCH
                // ====================================================

                string search =
                    txtSearch.Text
                    .Trim();


                if (!string.IsNullOrWhiteSpace(
                    search))
                {
                    filteredEmployees =
                        filteredEmployees
                        .Where(
                            employee =>
                            {
                                string fullName =
                                    (
                                        (employee.FirstName ?? "")
                                        +
                                        " "
                                        +
                                        (employee.Surname ?? "")
                                    ).Trim();


                                return
                                    fullName.IndexOf(
                                        search,
                                        StringComparison.OrdinalIgnoreCase)
                                    >= 0
                                    ||
                                    (employee.Email ?? "")
                                    .IndexOf(
                                        search,
                                        StringComparison.OrdinalIgnoreCase)
                                    >= 0
                                    ||
                                    employee.EmployeeID
                                    .ToString()
                                    .Contains(
                                        search);
                            })
                        .ToList();
                }


                // ====================================================
                // ROLE FILTER
                // ====================================================

                if (!string.IsNullOrWhiteSpace(
                    ddlRole.SelectedValue))
                {
                    string selectedRole =
                        ddlRole.SelectedValue;


                    filteredEmployees =
                        filteredEmployees
                        .Where(
                            employee =>
                                (employee.Role ?? "")
                                .Equals(
                                    selectedRole,
                                    StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }


                // ====================================================
                // STATUS FILTER
                // ====================================================

                if (!string.IsNullOrWhiteSpace(
                    ddlStatus.SelectedValue))
                {
                    string selectedStatus =
                        ddlStatus.SelectedValue;


                    filteredEmployees =
                        filteredEmployees
                        .Where(
                            employee =>
                                (employee.EmployeeStatus ?? "")
                                .Equals(
                                    selectedStatus,
                                    StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }


                // ====================================================
                // BIND TABLE
                // ====================================================

                rptEmployees.DataSource =
                    filteredEmployees;


                rptEmployees.DataBind();


                // ====================================================
                // SUMMARY CARDS
                // ====================================================

                lblTotalStaff.Text =
                    allEmployees.Count
                    .ToString();


                lblActiveStaff.Text =
                    allEmployees
                    .Count(
                        employee =>
                            (employee.EmployeeStatus ?? "")
                            .Equals(
                                "Active",
                                StringComparison.OrdinalIgnoreCase))
                    .ToString();


                lblManagers.Text =
                    allEmployees
                    .Count(
                        employee =>
                            (employee.Role ?? "")
                            .Equals(
                                "Manager",
                                StringComparison.OrdinalIgnoreCase)
                            &&
                            (employee.EmployeeStatus ?? "")
                            .Equals(
                                "Active",
                                StringComparison.OrdinalIgnoreCase))
                    .ToString();


                lblKitchenStaff.Text =
                    allEmployees
                    .Count(
                        employee =>
                            (employee.Role ?? "")
                            .Equals(
                                "Kitchen Staff",
                                StringComparison.OrdinalIgnoreCase)
                            &&
                            (employee.EmployeeStatus ?? "")
                            .Equals(
                                "Active",
                                StringComparison.OrdinalIgnoreCase))
                    .ToString();


                lblShowingStaff.Text =
                    "Showing "
                    +
                    filteredEmployees.Count
                    +
                    " of "
                    +
                    allEmployees.Count
                    +
                    " staff members";


                // ====================================================
                // SELECT EMPLOYEE
                // ====================================================

                if (allEmployees.Count > 0)
                {
                    int selectedEmployeeID;


                    if (ViewState[
                        "SelectedEmployeeID"]
                        != null)
                    {
                        selectedEmployeeID =
                            Convert.ToInt32(
                                ViewState[
                                    "SelectedEmployeeID"]);
                    }
                    else
                    {
                        selectedEmployeeID =
                            allEmployees[0]
                            .EmployeeID;
                    }


                    LoadSelectedEmployee(
                        selectedEmployeeID);
                }
                else
                {
                    pnlSelectedEmployee.Visible =
                        false;
                }


                if (string.IsNullOrWhiteSpace(
                    lblMessage.Text))
                {
                    lblMessage.CssClass =
                        "d-none";
                }
            }
            catch (Exception ex)
            {
                lblMessage.CssClass =
                    "alert alert-danger d-block";


                lblMessage.Text =
                    "Unable to load employees. "
                    +
                    ex.Message;
            }
        }


        // ============================================================
        // SELECT EMPLOYEE
        // ============================================================

        protected void SelectEmployee_Command(
            object sender,
            CommandEventArgs e)
        {
            int employeeID;


            if (!int.TryParse(
                e.CommandArgument
                .ToString(),
                out employeeID))
            {
                return;
            }


            ViewState[
                "SelectedEmployeeID"] =
                employeeID;


            LoadSelectedEmployee(
                employeeID);
        }


        private void LoadSelectedEmployee(
            int employeeID)
        {
            EmployeeAccountDetails employee =
                employeeService
                .GetEmployeeByID(
                    employeeID);


            if (employee == null)
            {
                pnlSelectedEmployee.Visible =
                    false;

                return;
            }


            pnlSelectedEmployee.Visible =
                true;


            string fullName =
                (
                    (employee.FirstName ?? "")
                    +
                    " "
                    +
                    (employee.Surname ?? "")
                ).Trim();


            if (string.IsNullOrWhiteSpace(
                fullName))
            {
                fullName =
                    "Employee";
            }


            lblSelectedInitials.Text =
                CreateInitials(
                    employee.FirstName,
                    employee.Surname);


            lblSelectedName.Text =
                fullName;


            lblSelectedRole.Text =
                string.IsNullOrWhiteSpace(
                    employee.Role)
                ? "Not assigned"
                : employee.Role;


            lblSelectedRoleDetail.Text =
                string.IsNullOrWhiteSpace(
                    employee.Role)
                ? "Not assigned"
                : employee.Role;


            lblSelectedEmployeeID.Text =
                employee.EmployeeID
                .ToString();


            lblSelectedEmail.Text =
                string.IsNullOrWhiteSpace(
                    employee.Email)
                ? "Not provided"
                : employee.Email;


            lblSelectedAddress.Text =
                string.IsNullOrWhiteSpace(
                    employee.Address)
                ? "Not provided"
                : employee.Address;


            lblSelectedStatus.Text =
                string.IsNullOrWhiteSpace(
                    employee.EmployeeStatus)
                ? "Active"
                : employee.EmployeeStatus;


            lblSelectedHireDate.Text =
                employee.HireDate.HasValue
                ? employee.HireDate.Value
                    .ToString(
                        "dd MMMM yyyy")
                : "Not recorded";


            // ========================================================
            // STATUS BUTTON
            // ========================================================

            if ((employee.EmployeeStatus ?? "")
                .Equals(
                    "Inactive",
                    StringComparison.OrdinalIgnoreCase))
            {
                btnToggleStatus.Text =
                    "Reactivate Employee";


                btnToggleStatus.CssClass =
                    "manager-selected-action btn btn-success";
            }
            else
            {
                btnToggleStatus.Text =
                    "Deactivate Employee";


                btnToggleStatus.CssClass =
                    "manager-selected-action manager-selected-action-red";
            }
        }


        // ============================================================
        // SEARCH
        // ============================================================

        protected void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadEmployees();
        }


        // ============================================================
        // ROLE FILTER CHANGE
        // ============================================================

        protected void DdlRole_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadEmployees();
        }


        // ============================================================
        // STATUS FILTER CHANGE
        // ============================================================

        protected void DdlStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadEmployees();
        }


        // ============================================================
        // REFRESH
        // ============================================================

        protected void BtnRefresh_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text =
                "";


            ddlRole.SelectedIndex =
                0;


            ddlStatus.SelectedIndex =
                0;


            lblMessage.Text =
                "";


            lblMessage.CssClass =
                "d-none";


            LoadEmployees();
        }


        // ============================================================
        // ACTIVATE / DEACTIVATE EMPLOYEE
        // ============================================================

        protected void BtnToggleStatus_Click(
            object sender,
            EventArgs e)
        {
            if (ViewState[
                "SelectedEmployeeID"]
                == null)
            {
                lblMessage.CssClass =
                    "alert alert-warning d-block";


                lblMessage.Text =
                    "Please select an employee first.";


                return;
            }


            try
            {
                int employeeID =
                    Convert.ToInt32(
                        ViewState[
                            "SelectedEmployeeID"]);


                int managerID =
                    Convert.ToInt32(
                        Session[
                            "UserID"]);


                EmployeeAccountDetails employee =
                    employeeService
                    .GetEmployeeByID(
                        employeeID);


                if (employee == null)
                {
                    lblMessage.CssClass =
                        "alert alert-warning d-block";


                    lblMessage.Text =
                        "Employee could not be found.";


                    return;
                }


                string newStatus =
                    (employee.EmployeeStatus ?? "")
                    .Equals(
                        "Inactive",
                        StringComparison.OrdinalIgnoreCase)
                    ? "Active"
                    : "Inactive";


                string result =
                    employeeService
                    .UpdateEmployeeStatus(
                        employeeID,
                        newStatus,
                        managerID);


                if (!string.IsNullOrWhiteSpace(
                    result))
                {
                    lblMessage.CssClass =
                        "alert alert-warning d-block";


                    lblMessage.Text =
                        result;


                    return;
                }


                lblMessage.CssClass =
                    "alert alert-success d-block";


                lblMessage.Text =
                    newStatus.Equals(
                        "Active",
                        StringComparison.OrdinalIgnoreCase)
                    ? "Employee reactivated successfully."
                    : "Employee deactivated successfully.";


                LoadEmployees();
            }
            catch (Exception ex)
            {
                lblMessage.CssClass =
                    "alert alert-danger d-block";


                lblMessage.Text =
                    "Unable to update employee status. "
                    +
                    ex.Message;
            }
        }


        // ============================================================
        // STATUS CSS
        // ============================================================

        public string GetEmployeeStatusClass(
            string status)
        {
            if ((status ?? "")
                .Equals(
                    "Active",
                    StringComparison.OrdinalIgnoreCase))
            {
                return
                    "manager-staff-status status-active-staff";
            }


            return
                "manager-staff-status status-off-duty";
        }


        // ============================================================
        // HIRE DATE DISPLAY
        // ============================================================

        public string GetHireDateText(
            object hireDate)
        {
            if (hireDate == null ||
                hireDate == DBNull.Value)
            {
                return
                    "Not recorded";
            }


            DateTime date;


            if (DateTime.TryParse(
                hireDate.ToString(),
                out date))
            {
                return
                    date.ToString(
                        "dd MMM yyyy");
            }


            return
                "Not recorded";
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