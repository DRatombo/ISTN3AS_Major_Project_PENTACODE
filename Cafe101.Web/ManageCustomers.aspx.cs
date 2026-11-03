using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using global::Cafe101.Data;

namespace Cafe101.Web
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected string ManagerDisplayName
        {
            get
            {
                string name =
                    (Convert.ToString(Session["FirstName"]).Trim() + " " +
                     Convert.ToString(Session["Surname"]).Trim()).Trim();

                return name.Length == 0 ? "Manager" : name;
            }
        }

        protected string ManagerInitials
        {
            get
            {
                string first = Convert.ToString(Session["FirstName"]).Trim();
                string last = Convert.ToString(Session["Surname"]).Trim();

                string initials =
                    (first.Length > 0 ? first.Substring(0, 1) : "") +
                    (last.Length > 0 ? last.Substring(0, 1) : "");

                return initials.Length == 0
                    ? "M"
                    : initials.ToUpperInvariant();
            }
        }

        private bool HasSelection
        {
            get { return ViewState["SelectedCustomerID"] != null; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Session["UserID"] == null ||
                !string.Equals(
                    Convert.ToString(Session["Role"]),
                    "Manager",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshPage();
            }
        }

        private void ShowMessage(string message, bool error)
        {
            lblCustomerMessage.Text =
                System.Web.HttpUtility.HtmlEncode(message);

            lblCustomerMessage.CssClass = error
                ? "d-block mb-3 text-danger"
                : "d-block mb-3 text-success";
        }

        private DataTable ReadTable(string sql, string search = null)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (search != null)
                {
                    command.Parameters.Add(
                        "@Search", SqlDbType.NVarChar, 202
                    ).Value = "%" + search + "%";
                }

                DataTable table = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }

                return table;
            }
        }

        private void LoadCustomers()
        {
            gvCustomers.SelectedIndex = -1;

            gvCustomers.DataSource = ReadTable(@"
                SELECT
                    CustomerID,
                    FirstName,
                    Surname,
                    Email,
                    Address,
                    Status
                FROM dbo.CustomerTable
                WHERE FirstName LIKE @Search
                   OR Surname LIKE @Search
                   OR Email LIKE @Search
                ORDER BY Surname, FirstName;",
                txtSearch.Text.Trim());

            gvCustomers.DataBind();
        }

        private void ClearSelection()
        {
            ViewState.Remove("SelectedCustomerID");

            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;

            lblCustomerSelection.Text = "New customer account";

            btnAddCustomer.Enabled = true;
            btnUpdateCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
            btnResetPassword.Enabled = false;

            gvCustomers.SelectedIndex = -1;
            ResetValidationStyles();
        }

        private void ResetValidationStyles()
        {
            txtFirstName.CssClass = "form-control";
            txtSurname.CssClass = "form-control";
            txtEmail.CssClass = "form-control";
            txtAddress.CssClass = "form-control";

            lblFirstNameStatus.Text = "";
            lblSurnameStatus.Text = "";
            lblEmailStatus.Text = "";
            lblAddressStatus.Text = "";
        }

        private void RefreshPage()
        {
            lblCustomerMessage.Text = "";

            try
            {
                ClearSelection();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        private void ReportError(Exception ex)
        {
            System.Diagnostics.Trace.TraceError(
                "Customer operation failed: {0}", ex);

            ShowMessage(
                "The customer operation could not be completed. Please try again.",
                true);
        }

        protected void gvCustomers_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            try
            {
                int customerID = Convert.ToInt32(
                    gvCustomers.SelectedDataKey.Value);

                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                using (SqlCommand command = new SqlCommand(@"
                    SELECT CustomerID, FirstName, Surname, Email, Address, Status
                    FROM dbo.CustomerTable
                    WHERE CustomerID = @CustomerID;", connection))
                {
                    command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException(
                                "This customer no longer exists.");

                        txtFirstName.Text = Convert.ToString(reader["FirstName"]);
                        txtSurname.Text = Convert.ToString(reader["Surname"]);
                        txtEmail.Text = Convert.ToString(reader["Email"]);
                        txtAddress.Text = Convert.ToString(reader["Address"]);

                        string status = Convert.ToString(reader["Status"]);
                        if (cmbStatus.Items.FindByValue(status) != null)
                        {
                            cmbStatus.SelectedValue = status;
                        }
                    }
                }

                ViewState["SelectedCustomerID"] = customerID;

                btnAddCustomer.Enabled = false;
                btnUpdateCustomer.Enabled = true;
                btnDeleteCustomer.Enabled = true;
                btnResetPassword.Enabled = true;

                lblCustomerSelection.Text = "Editing selected customer";
                ShowMessage("Customer selected.", false);
                ResetValidationStyles();
            }
            catch (InvalidOperationException ex)
            {
                ClearSelection();
                ShowMessage(ex.Message, true);
            }
            catch (Exception ex)
            {
                ClearSelection();
                ReportError(ex);
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            ResetValidationStyles();

            string firstName = txtFirstName.Text.Trim();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                txtFirstName.CssClass = "form-control is-invalid";
                lblFirstNameStatus.Text = "First name is required.";
                isValid = false;
            }

            string surname = txtSurname.Text.Trim();
            if (string.IsNullOrWhiteSpace(surname))
            {
                txtSurname.CssClass = "form-control is-invalid";
                lblSurnameStatus.Text = "Surname is required.";
                isValid = false;
            }

            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                txtEmail.CssClass = "form-control is-invalid";
                lblEmailStatus.Text = "Valid email address is required.";
                isValid = false;
            }

            string address = txtAddress.Text.Trim();
            if (string.IsNullOrWhiteSpace(address) || !address.Contains(","))
            {
                txtAddress.CssClass = "form-control is-invalid";
                lblAddressStatus.Text = "Address must include street number and commas (e.g. 46 Lion Road, Durban).";
                isValid = false;
            }

            return isValid;
        }

        private void SaveCustomer(string operation)
        {
            if (operation != "add" && !HasSelection)
            {
                ShowMessage("Select a customer first.", true);
                return;
            }

            if (operation != "remove" && !ValidateForm())
            {
                ShowMessage("Please correct the validation errors before saving.", true);
                return;
            }

            int customerID = HasSelection ? (int)ViewState["SelectedCustomerID"] : 0;

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction transaction =
                        connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        string sql;

                        if (operation == "add")
                        {
                            sql = @"
                                INSERT INTO dbo.CustomerTable
                                    (FirstName, Surname, Email, Address, Password, Status)
                                VALUES
                                    (@FirstName, @Surname, @Email, @Address, @Password, @Status);";
                        }
                        else if (operation == "update")
                        {
                            sql = @"
                                UPDATE dbo.CustomerTable
                                SET FirstName = @FirstName,
                                    Surname = @Surname,
                                    Email = @Email,
                                    Address = @Address,
                                    Status = @Status
                                WHERE CustomerID = @CustomerID;";
                        }
                        else
                        {
                            sql = @"
                                DELETE FROM dbo.CustomerTable
                                WHERE CustomerID = @CustomerID;";
                        }

                        using (SqlCommand command =
                            new SqlCommand(sql, connection, transaction))
                        {
                            if (operation != "remove")
                            {
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = txtFirstName.Text.Trim();
                                command.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = txtSurname.Text.Trim();
                                command.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();
                                command.Parameters.Add("@Address", SqlDbType.VarChar, 200).Value = txtAddress.Text.Trim();
                                command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = cmbStatus.SelectedValue;

                                if (operation == "add")
                                {
                                    command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = "temp1";
                                }
                            }

                            if (operation != "add")
                            {
                                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                            }

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
                return;
            }

            ClearSelection();

            try
            {
                txtSearch.Text = "";
                LoadCustomers();

                ShowMessage(
                    operation == "add" ? "Customer added successfully with temporary password 'temp1'." :
                    operation == "update" ? "Customer updated successfully." :
                    "Customer deleted successfully.",
                    false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "Customer refresh failed after saving: {0}", ex);

                ShowMessage(
                    "The change was saved, but the list could not be refreshed.",
                    true);
            }
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SaveCustomer("add");
        }

        protected void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            SaveCustomer("update");
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            SaveCustomer("remove");
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!HasSelection)
            {
                ShowMessage("Select a customer first.", true);
                return;
            }

            int customerID = (int)ViewState["SelectedCustomerID"];
            string tempPassword = "temp1";

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                using (SqlCommand command = new SqlCommand(@"
                    UPDATE dbo.CustomerTable
                    SET Password = @Password
                    WHERE CustomerID = @CustomerID;", connection))
                {
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = tempPassword;
                    command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                ShowMessage("Password reset to 'temp1' successfully.", false);
                LoadCustomers();
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCustomers();
        }

        protected void btnRefreshCustomers_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ClearSelection();
            lblCustomerMessage.Text = "";
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }
    }
}