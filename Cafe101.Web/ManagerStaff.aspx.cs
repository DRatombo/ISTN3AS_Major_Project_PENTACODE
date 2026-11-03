using Cafe101.Logic;
using Cafe101.Data;
using Cafe101;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
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
        // STAFF PAGINATION
        private const int StaffPageSize = 6;

        private int StaffPageIndex
        {
            get
            {
                return ViewState["StaffPageIndex"] == null
                    ? 0
                    : Convert.ToInt32(ViewState["StaffPageIndex"]);
            }
            set
            {
                ViewState["StaffPageIndex"] = value;
            }
        }

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

                // PAGINATION
                int totalFiltered = filteredEmployees.Count;

                int totalPages = Math.Max(
                    1,
                    (totalFiltered + StaffPageSize - 1) / StaffPageSize
                );

                if (StaffPageIndex >= totalPages)
                {
                    StaffPageIndex = totalPages - 1;
                }

                // Update pagination controls
                lblStaffPage.Text =
                    $"Page {StaffPageIndex + 1} of {totalPages}";

                btnPreviousStaff.Enabled =
                    StaffPageIndex > 0;

                btnNextStaff.Enabled =
                    StaffPageIndex < totalPages - 1;

                List<EmployeeAccountDetails> pageEmployees =
                    filteredEmployees
                        .Skip(StaffPageIndex * StaffPageSize)
                        .Take(StaffPageSize)
                        .ToList();

                rptEmployees.DataSource = pageEmployees;
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


                int start = totalFiltered == 0
                    ? 0
                    : StaffPageIndex * StaffPageSize + 1;

                int end = Math.Min(
                    (StaffPageIndex + 1) * StaffPageSize,
                    totalFiltered
                );

                lblShowingStaff.Text =
                    $"Showing {start}-{end} of {totalFiltered} staff members";


                // ====================================================
                // SELECT EMPLOYEE
                // ====================================================

                if (IsAddingEmployee)
                {
                    pnlSelectedEmployee.Visible = true;
                }
                else if (allEmployees.Count > 0)
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
        // OPEN / CLOSE STAFF DETAILS SLIDE
        // ============================================================

        private void SetStaffSlide(bool open)
        {
            var mainContent = Master.FindControl("MainContent");

            HiddenField slideField = mainContent == null
                ? null
                : mainContent.FindControl("hdnStaffPanelOpen") as HiddenField;

            if (slideField != null)
            {
                slideField.Value = open ? "1" : "0";
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

            SetStaffSlide(true);
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

            IsAddingEmployee = false;
            lblEmployeeFormHeading.Text = "Edit Employee Details";
            btnSaveEmployee.Text = "Save Changes";
            btnResetEmployeePassword.Visible = true;
            btnDeleteEmployee.Visible = true;
            btnToggleStatus.Visible = true;
            txtEmployeeFirstName.Text = employee.FirstName ?? "";
            txtEmployeeSurname.Text = employee.Surname ?? "";
            txtEmployeeEmail.Text = employee.Email ?? "";
            txtEmployeeAddress.Text = employee.Address ?? "";
            ddlEmployeeRole.SelectedValue = ddlEmployeeRole.Items.FindByValue(employee.Role ?? "") != null
                ? employee.Role : "";
            txtEmployeePassword.Text = "";
            ClearValidationMessages();


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
        // STAFF PAGINATION
        // ============================================================

        protected void BtnPreviousStaff_Click(object sender, EventArgs e)
        {
            if (StaffPageIndex > 0)
            {
                StaffPageIndex--;
            }

            LoadEmployees();
        }

        protected void BtnNextStaff_Click(object sender, EventArgs e)
        {
            StaffPageIndex++;
            LoadEmployees();
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
        // EMPLOYEE FORM AND CRUD
        // ============================================================

        private bool IsAddingEmployee
        {
            get { return ViewState["IsAddingEmployee"] != null && (bool)ViewState["IsAddingEmployee"]; }
            set { ViewState["IsAddingEmployee"] = value; }
        }

        protected void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            IsAddingEmployee = true;
            ViewState["SelectedEmployeeID"] = null;
            ClearEmployeeForm();
            pnlSelectedEmployee.Visible = true;
            lblEmployeeFormHeading.Text = "Add New Employee";
            btnSaveEmployee.Text = "Add Employee";
            btnResetEmployeePassword.Visible = false;
            btnDeleteEmployee.Visible = false;
            btnToggleStatus.Visible = false;
            lblSelectedName.Text = "New Employee";
            lblSelectedInitials.Text = "+";
            lblSelectedEmployeeID.Text = "Not assigned";
            lblSelectedEmail.Text = "—";
            lblSelectedRole.Text = "New account";
            lblSelectedRoleDetail.Text = "—";
            lblSelectedStatus.Text = "Pending";
            lblSelectedHireDate.Text = "—";
            lblSelectedAddress.Text = "—";
            SetStaffSlide(true);
        }

        protected void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            bool adding = IsAddingEmployee;
            int? id = adding || ViewState["SelectedEmployeeID"] == null
                ? (int?)null : Convert.ToInt32(ViewState["SelectedEmployeeID"]);

            if (!adding && !id.HasValue)
            {
                ShowStaffMessage("Select an employee or click Add Employee.", "warning");
                return;
            }
            if (!ValidateEmployeeForm(adding))
            {
                ShowStaffMessage("Please correct the highlighted fields.", "warning");
                SetStaffSlide(true);
                return;
            }

            string first = txtEmployeeFirstName.Text.Trim();
            string surname = txtEmployeeSurname.Text.Trim();
            string email = txtEmployeeEmail.Text.Trim();
            string address = txtEmployeeAddress.Text.Trim();
            string role = ddlEmployeeRole.SelectedValue;
            string password = txtEmployeePassword.Text;

            try
            {
                if (IsEmployeeDuplicate(first, surname, id))
                {
                    lblSurnameValidation.Text = "This employee name already exists.";
                    ShowStaffMessage("Duplicate employee name.", "warning"); SetStaffSlide(true); return;
                }
                if (IsEmailDuplicate(email, id))
                {
                    lblEmailValidation.Text = "This email is already in use.";
                    ShowStaffMessage("Duplicate email address.", "warning"); SetStaffSlide(true); return;
                }
                if (!String.IsNullOrWhiteSpace(password) && IsPasswordDuplicate(password, id))
                {
                    lblPasswordValidation.Text = "This password is already in use.";
                    ShowStaffMessage("Duplicate password.", "warning"); SetStaffSlide(true); return;
                }

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    if (adding)
                    {
                        cmd.CommandText = @"INSERT INTO EmployeeTable
                            (FirstName,Surname,Address,Email,Role,Password)
                            VALUES (@FirstName,@Surname,@Address,@Email,@Role,@Password)";
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE EmployeeTable SET FirstName=@FirstName,
                            Surname=@Surname,Address=@Address,Email=@Email,Role=@Role
                            WHERE EmployeeID=@ID";
                        if (!String.IsNullOrWhiteSpace(password))
                        {
                            cmd.CommandText = @"UPDATE EmployeeTable SET FirstName=@FirstName,
                                Surname=@Surname,Address=@Address,Email=@Email,Role=@Role,
                                Password=@Password WHERE EmployeeID=@ID";
                            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                        }
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id.Value;
                    }

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = first;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = surname;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250).Value = address;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
                    cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 50).Value = role;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 0 && !adding)
                    {
                        ShowStaffMessage("Employee record was not updated.", "warning");
                        return;
                    }
                }

                IsAddingEmployee = false;
                ViewState["SelectedEmployeeID"] = null;
                StaffPageIndex = 0;
                ShowStaffMessage(adding ? "Employee added successfully." : "Employee updated successfully.", "success");
                LoadEmployees();
                SetStaffSlide(false);
            }
            catch (Exception ex) { ShowStaffMessage("Unable to save employee. " + ex.Message, "danger"); }
        }

        protected void BtnClearEmployeeForm_Click(object sender, EventArgs e)
        {
            ClearEmployeeForm();
            SetStaffSlide(true);
        }

        protected void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (IsAddingEmployee || ViewState["SelectedEmployeeID"] == null)
            {
                ShowStaffMessage("Select an existing employee first.", "warning"); return;
            }
            try
            {
                int id = Convert.ToInt32(ViewState["SelectedEmployeeID"]);
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeTable WHERE EmployeeID=@ID", conn))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        ShowStaffMessage("Employee could not be found.", "warning"); return;
                    }
                }
                IsAddingEmployee = false;
                ViewState["SelectedEmployeeID"] = null;
                StaffPageIndex = 0;
                ShowStaffMessage("Employee removed successfully.", "success");
                LoadEmployees();
                SetStaffSlide(false);
            }
            catch (Exception ex) { ShowStaffMessage("Unable to delete employee. " + ex.Message, "danger"); }
        }

        protected void BtnResetEmployeePassword_Click(object sender, EventArgs e)
        {
            if (IsAddingEmployee || ViewState["SelectedEmployeeID"] == null)
            {
                ShowStaffMessage("Select an existing employee first.", "warning"); return;
            }
            const string temporaryPassword = "temp123";
            int id = Convert.ToInt32(ViewState["SelectedEmployeeID"]);
            try
            {
                if (IsPasswordDuplicate(temporaryPassword, id))
                {
                    ShowStaffMessage("The temporary password is already used by another employee.", "warning"); return;
                }
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeTable SET Password=@Password WHERE EmployeeID=@ID", conn))
                {
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = temporaryPassword;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    conn.Open(); cmd.ExecuteNonQuery();
                }
                txtEmployeePassword.Text = "";
                ShowStaffMessage("Password reset successfully to temp123.", "success");
                SetStaffSlide(true);
            }
            catch (Exception ex) { ShowStaffMessage("Unable to reset password. " + ex.Message, "danger"); }
        }

        private bool ValidateEmployeeForm(bool adding)
        {
            ClearValidationMessages();
            bool valid = true;
            string first = txtEmployeeFirstName.Text.Trim();
            string surname = txtEmployeeSurname.Text.Trim();
            string email = txtEmployeeEmail.Text.Trim();
            string address = txtEmployeeAddress.Text.Trim();
            string password = txtEmployeePassword.Text;

            if (first.Length == 0 || !first.All(Char.IsLetter))
            { lblFirstNameValidation.Text = first.Length == 0 ? "Required." : "Letters only."; valid = false; }
            if (surname.Length == 0 || !surname.All(Char.IsLetter))
            { lblSurnameValidation.Text = surname.Length == 0 ? "Required." : "Letters only."; valid = false; }
            try { MailAddress parsed = new MailAddress(email); if (parsed.Address != email) throw new Exception(); }
            catch { lblEmailValidation.Text = "Enter a valid email address."; valid = false; }
            if (address.Length == 0 || !address.Any(Char.IsDigit) || address.Count(c => c == ',') < 2)
            { lblAddressValidation.Text = "Use: number street, suburb, city."; valid = false; }
            if (String.IsNullOrWhiteSpace(ddlEmployeeRole.SelectedValue))
            { lblRoleValidation.Text = "Select a role."; valid = false; }
            if ((adding && password.Length == 0) || (password.Length > 0 && password.Length < 6))
            { lblPasswordValidation.Text = adding && password.Length == 0 ? "Required." : "Minimum 6 characters."; valid = false; }
            return valid;
        }

        private void ClearEmployeeForm()
        {
            txtEmployeeFirstName.Text = "";
            txtEmployeeSurname.Text = "";
            txtEmployeeEmail.Text = "";
            txtEmployeeAddress.Text = "";
            txtEmployeePassword.Text = "";
            ddlEmployeeRole.SelectedIndex = 0;
            ClearValidationMessages();
        }

        private void ClearValidationMessages()
        {
            lblFirstNameValidation.Text = "";
            lblSurnameValidation.Text = "";
            lblEmailValidation.Text = "";
            lblAddressValidation.Text = "";
            lblRoleValidation.Text = "";
            lblPasswordValidation.Text = "";
        }

        private bool IsEmployeeDuplicate(string first, string surname, int? excludeID)
        {
            string sql = "SELECT COUNT(*) FROM EmployeeTable WHERE LOWER(FirstName)=LOWER(@F) AND LOWER(Surname)=LOWER(@S)";
            if (excludeID.HasValue) sql += " AND EmployeeID<>@ID";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@F", SqlDbType.NVarChar, 50).Value = first;
                cmd.Parameters.Add("@S", SqlDbType.NVarChar, 50).Value = surname;
                if (excludeID.HasValue) cmd.Parameters.Add("@ID", SqlDbType.Int).Value = excludeID.Value;
                conn.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool IsEmailDuplicate(string email, int? excludeID)
        {
            string sql = "SELECT COUNT(*) FROM EmployeeTable WHERE LOWER(Email)=LOWER(@Email)";
            if (excludeID.HasValue) sql += " AND EmployeeID<>@ID";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
                if (excludeID.HasValue) cmd.Parameters.Add("@ID", SqlDbType.Int).Value = excludeID.Value;
                conn.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool IsPasswordDuplicate(string password, int? excludeID)
        {
            string sql = "SELECT COUNT(*) FROM EmployeeTable WHERE Password=@Password";
            if (excludeID.HasValue) sql += " AND EmployeeID<>@ID";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                if (excludeID.HasValue) cmd.Parameters.Add("@ID", SqlDbType.Int).Value = excludeID.Value;
                conn.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void ShowStaffMessage(string message, string type)
        {
            lblMessage.CssClass = "alert alert-" + type + " d-block";
            lblMessage.Text = Server.HtmlEncode(message);
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