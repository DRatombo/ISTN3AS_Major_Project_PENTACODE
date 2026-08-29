using Cafe101.Logic;
using System;

namespace Cafe101.Web
{
    public partial class MyAccount : System.Web.UI.Page
    {
        private readonly CustomerAccountService accountService =
            new CustomerAccountService();


        protected void Page_Load(object sender, EventArgs e)
        {
            // User must be logged in
            if (Session["UserID"] == null ||
                Session["UserType"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // Only customers may access this page
            if (!Session["UserType"]
                .ToString()
                .Equals(
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return;
            }


            if (!IsPostBack)
            {
                LoadUserDetails();

                SetFieldsEnabled(false);
            }
        }


        // ============================================================
        // LOAD CUSTOMER DETAILS
        // ============================================================

        private void LoadUserDetails()
        {
            int customerID =
                Convert.ToInt32(
                    Session["UserID"]);


            CustomerAccountDetails customer =
                accountService.GetCustomerByID(
                    customerID);


            if (customer == null)
            {
                Session.Clear();

                Response.Redirect("~/SignIn.aspx");
                return;
            }


            // Personal information
            txtFirstName.Text =
                customer.FirstName;

            txtLastName.Text =
                customer.Surname;

            txtPhone.Text =
                customer.PhoneNumber;

            txtEmail.Text =
                customer.Email;


            // Account information
            litCustomerID.Text =
                customer.CustomerID.ToString();

            litAccountStatus.Text =
                string.IsNullOrWhiteSpace(customer.Status)
                ? "Active"
                : customer.Status;


            // ========================================================
            // ADDRESS
            //
            // Stored as:
            // Street Address, Suburb, City
            // ========================================================

            string[] addressParts =
                (customer.Address ?? "")
                .Split(',');


            txtStreetAddress.Text =
                addressParts.Length > 0
                ? addressParts[0].Trim()
                : "";


            txtSuburb.Text =
                addressParts.Length > 1
                ? addressParts[1].Trim()
                : "";


            txtCity.Text =
                addressParts.Length > 2
                ? addressParts[2].Trim()
                : "";


            // Full name
            string fullName =
                (
                    customer.FirstName +
                    " " +
                    customer.Surname
                ).Trim();


            litFullName.Text =
                fullName;

            litEmailDisplay.Text =
                customer.Email;


            // ========================================================
            // INITIALS
            // ========================================================

            string initials = "";


            if (!string.IsNullOrWhiteSpace(
                customer.FirstName))
            {
                initials +=
                    customer.FirstName
                    .Substring(0, 1)
                    .ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(
                customer.Surname))
            {
                initials +=
                    customer.Surname
                    .Substring(0, 1)
                    .ToUpper();
            }


            if (string.IsNullOrWhiteSpace(initials))
            {
                initials = "C";
            }


            litInitials.Text =
                initials;

            lblTopCustomerInitials.Text =
                initials;

            lblTopCustomerName.Text =
                fullName;


            // ========================================================
            // KEEP SESSION INFORMATION UPDATED
            // ========================================================

            Session["FirstName"] =
                customer.FirstName;

            Session["Surname"] =
                customer.Surname;

            Session["Email"] =
                customer.Email;

            Session["PhoneNumber"] =
                customer.PhoneNumber;

            Session["Address"] =
                customer.Address;
        }


        // ============================================================
        // EDIT DETAILS
        // ============================================================

        protected void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            SetFieldsEnabled(true);

            btnEdit.Visible =
                false;

            btnSave.Visible =
                true;

            btnCancel.Visible =
                true;

            lblStatus.Text =
                "";
        }


        // ============================================================
        // SAVE DETAILS
        // ============================================================

        protected void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            lblStatus.Text =
                "";


            string firstName =
                txtFirstName.Text.Trim();

            string surname =
                txtLastName.Text.Trim();

            string phone =
                txtPhone.Text.Trim();

            string street =
                txtStreetAddress.Text.Trim();

            string suburb =
                txtSuburb.Text.Trim();

            string city =
                txtCity.Text.Trim();

            string email =
                txtEmail.Text.Trim();


            // ========================================================
            // VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(firstName))
            {
                ShowError(
                    "First name is required.");

                return;
            }


            if (string.IsNullOrWhiteSpace(surname))
            {
                ShowError(
                    "Surname is required.");

                return;
            }


            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowError(
                    "Phone number is required.");

                return;
            }


            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError(
                    "Email address is required.");

                return;
            }


            if (string.IsNullOrWhiteSpace(street) ||
                string.IsNullOrWhiteSpace(suburb) ||
                string.IsNullOrWhiteSpace(city))
            {
                ShowError(
                    "Please complete all address fields.");

                return;
            }


            string fullAddress =
                street + ", " +
                suburb + ", " +
                city;


            int customerID =
                Convert.ToInt32(
                    Session["UserID"]);


            try
            {
                bool updated =
                    accountService.UpdateCustomer(
                        customerID,
                        firstName,
                        surname,
                        phone,
                        fullAddress,
                        email);


                if (!updated)
                {
                    ShowError(
                        "Your account could not be updated.");

                    return;
                }


                // Reload updated database record
                LoadUserDetails();


                SetFieldsEnabled(false);


                btnEdit.Visible =
                    true;

                btnSave.Visible =
                    false;

                btnCancel.Visible =
                    false;


                lblStatus.CssClass =
                    "d-block mt-3 small text-success";


                lblStatus.Text =
                    "Your details have been updated successfully.";
            }
            catch (Exception)
            {
                ShowError(
                    "An error occurred while updating your account. Please try again.");
            }
        }


        // ============================================================
        // CANCEL EDITING
        // ============================================================

        protected void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            // Reload original database values
            LoadUserDetails();


            SetFieldsEnabled(false);


            btnEdit.Visible =
                true;

            btnSave.Visible =
                false;

            btnCancel.Visible =
                false;


            lblStatus.Text =
                "";
        }


        // ============================================================
        // ENABLE / DISABLE FIELDS
        // ============================================================

        private void SetFieldsEnabled(
            bool enabled)
        {
            txtFirstName.Enabled =
                enabled;

            txtLastName.Enabled =
                enabled;

            txtPhone.Enabled =
                enabled;

            txtStreetAddress.Enabled =
                enabled;

            txtSuburb.Enabled =
                enabled;

            txtCity.Enabled =
                enabled;

            txtEmail.Enabled =
                enabled;
        }


        // ============================================================
        // ERROR MESSAGE
        // ============================================================

        private void ShowError(
            string message)
        {
            lblStatus.CssClass =
                "d-block mt-3 small text-danger";

            lblStatus.Text =
                message;
        }


        // ============================================================
        // LOG OUT
        // ============================================================

        protected void LnkLogOut_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx");
        }
    }
}