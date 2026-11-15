using Cafe101.Data;
using Cafe101.Logic;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace Cafe101.Web
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private readonly AuthenticationService authService = new AuthenticationService();

        // Holds an employee found by email
        private class EmployeeAccount
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowStep1();
            }
        }

        // ===================== STEP 1: SEND TEMPORARY PASSWORD =====================

        protected void BtnSendTempPassword_Click(object sender, EventArgs e)
        {
            lblMessage1.Text = "";
            string email = (txtEmail.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError1("Please enter your email address.");
                return;
            }

            // Look in CustomerTable first, then EmployeeTable
            string accountType;
            int accountId;
            string accountEmail;
            string accountFirstName;

            var customer = authService.GetCustomerByEmail(email);

            if (customer != null)
            {
                if (!string.Equals(customer.Status, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    ShowError1("This account is currently inactive. Please contact Cafe101 support.");
                    return;
                }

                accountType = "Customer";
                accountId = customer.CustomerID;
                accountEmail = customer.Email;
                accountFirstName = customer.FirstName;
            }
            else
            {
                EmployeeAccount employee = FindEmployeeByEmail(email);

                if (employee == null)
                {
                    ShowSuccess1("If an account with that email exists, a temporary password has been sent.");
                    return;
                }

                if (!string.Equals(employee.Status, "Active", StringComparison.OrdinalIgnoreCase))
                {
                    ShowError1("This account is currently inactive. Please contact Cafe101 support.");
                    return;
                }

                accountType = "Employee";
                accountId = employee.EmployeeID;
                accountEmail = employee.Email;
                accountFirstName = employee.FirstName;
            }

            string tempPassword = GenerateTempPassword();

            Session["ResetAccountType"] = accountType;
            Session["ResetAccountID"] = accountId;
            Session["ResetEmail"] = accountEmail;
            Session["ResetFirstName"] = accountFirstName;
            Session["TempPassword"] = tempPassword;
            Session["TempPasswordExpiry"] = DateTime.Now.AddMinutes(30);

            bool emailSent = SendTempPasswordEmailViaSendGrid(accountEmail, accountFirstName, tempPassword);

            if (!emailSent)
            {
                ClearResetSession();
                ShowError1("We could not send the email. Please try again later.");
                return;
            }

            ShowStep2();
        }

        // ===================== STEP 2: CHANGE PASSWORD AND SIGN IN =====================

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            lblMessage2.Text = "";

            if (Session["ResetAccountID"] == null || Session["TempPassword"] == null)
            {
                ShowError2("Session expired. Please start the process again.");
                ShowStep1();
                return;
            }

            if (Session["TempPasswordExpiry"] == null ||
                DateTime.Now > (DateTime)Session["TempPasswordExpiry"])
            {
                ShowError2("The temporary password has expired. Please request a new one.");
                ClearResetSession();
                ShowStep1();
                return;
            }

            string enteredTempPassword = (txtTempPassword.Text ?? "").Trim();
            string newPassword = (txtNewPassword.Text ?? "").Trim();
            string confirmPassword = (txtConfirmPassword.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(enteredTempPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowError2("All fields are required.");
                return;
            }

            if (newPassword.Length < 6)
            {
                ShowError2("New password must be at least 6 characters long.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                ShowError2("New password and Confirm password do not match.");
                return;
            }

            string correctTempPassword = Session["TempPassword"].ToString();

            if (enteredTempPassword != correctTempPassword)
            {
                ShowError2("The temporary password is incorrect. Please check your email and try again.");
                return;
            }

            int accountId = Convert.ToInt32(Session["ResetAccountID"]);
            string accountType = Session["ResetAccountType"]?.ToString() ?? "Customer";
            string email = Session["ResetEmail"].ToString();

            // Update the correct table
            bool updated = accountType == "Employee"
                ? UpdateEmployeePassword(accountId, newPassword)
                : authService.UpdateCustomerPassword(accountId, newPassword);

            if (!updated)
            {
                ShowError2("Could not update your password. Please try again.");
                return;
            }

            ClearResetSession();

            // Sign the person in automatically (customers and employees alike)
            var loginResult = authService.SignIn(email, newPassword);

            if (!loginResult.Success)
            {
                ShowError2("Password updated successfully. Please go to Sign In and log in with your new password.");
                return;
            }

            Session["UserID"] = loginResult.UserID;
            Session["UserType"] = loginResult.UserType;
            Session["Role"] = loginResult.Role;
            Session["FirstName"] = loginResult.FirstName;
            Session["Surname"] = loginResult.Surname;
            Session["Email"] = loginResult.Email;
            Session["Address"] = loginResult.Address;
            Session["PhoneNumber"] = loginResult.PhoneNumber;

            Response.Redirect(GetDashboardFor(accountType, loginResult.Role));
        }

        // Decides which dashboard to open after the password reset
        private string GetDashboardFor(string accountType, string role)
        {
            if (accountType == "Customer")
                return "~/CustomerDashboard.aspx";

            switch ((role ?? "").Trim().ToLower())
            {
                case "manager":
                    return "~/ManagerDashboard.aspx";

                // Add your other staff pages here, for example:
                // case "cashier":        return "~/CashierDashboard.aspx";
                // case "kitchen staff":  return "~/KitchenDashboard.aspx";

                default:
                    return "~/SignIn.aspx";
            }
        }

        // ===================== EMPLOYEE HELPERS =====================

        private EmployeeAccount FindEmployeeByEmail(string email)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT EmployeeID, FirstName, Email, EmployeeStatus FROM EmployeeTable WHERE Email = @email", conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new EmployeeAccount
                    {
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        FirstName = r["FirstName"].ToString(),
                        Email = r["Email"].ToString(),
                        Status = r["EmployeeStatus"].ToString()
                    };
                }
            }
        }

        private bool UpdateEmployeePassword(int employeeId, string newPassword)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE EmployeeTable SET Password = @pw WHERE EmployeeID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@pw", newPassword);
                cmd.Parameters.AddWithValue("@id", employeeId);
                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // ===================== EMAIL =====================

        private bool SendTempPasswordEmailViaSendGrid(string toEmail, string firstName, string tempPassword)
        {
            try
            {
                string user = ConfigurationManager.AppSettings["SmtpUser"];
                string pass = (ConfigurationManager.AppSettings["SmtpPassword"] ?? "").Replace(" ", "");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (var msg = new MailMessage())
                {
                    msg.From = new MailAddress(user, "Cafe 101");
                    msg.To.Add(new MailAddress(toEmail, firstName));
                    msg.Subject = "Cafe 101 - Temporary Password";
                    msg.IsBodyHtml = true;
                    msg.Body = BuildEmailHtml(firstName, tempPassword);

                    using (var client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(user, pass);
                        client.Send(msg);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        private string BuildEmailHtml(string firstName, string tempPassword)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #8B4513; color: white; padding: 20px; text-align: center; border-radius: 5px 5px 0 0; }}
        .content {{ background-color: #f9f9f9; padding: 20px; border: 1px solid #ddd; border-radius: 0 0 5px 5px; }}
        .temp-password {{ background-color: #fff3cd; padding: 15px; margin: 20px 0; border-left: 4px solid #ffc107; font-family: monospace; font-weight: bold; }}
        .footer {{ margin-top: 20px; font-size: 12px; color: #666; text-align: center; }}
        .warning {{ background-color: #ffe0e0; padding: 10px; margin: 10px 0; border-radius: 3px; color: #d32f2f; }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <h1>Cafe 101 Password Reset</h1>
        </div>
        <div class=""content"">
            <p>Hi {firstName},</p>
            
            <p>You requested a password reset for your Cafe101 account. If you didn't make this request, you can ignore this email.</p>
            
            <p>Your temporary password is:</p>
            <div class=""temp-password"">{tempPassword}</div>
            
            <p><strong>Instructions:</strong></p>
            <ol>
                <li>Return to the Forgot Password page</li>
                <li>Enter the temporary password above</li>
                <li>Enter your new permanent password</li>
                <li>Click ""Change Password & Sign In""</li>
            </ol>
            
            <div class=""warning"">
                <strong>Important Security Notes:</strong><br>
                • This temporary password expires in 30 minutes<br>
                • Do not share this password with anyone<br>
                • Never reply to this email or share it
            </div>
            
            <p>Questions? Contact our support team at support@cafe101.com</p>
        </div>
        <div class=""footer"">
            <p>© Cafe 101 - This is an automated email. Please do not reply.</p>
        </div>
    </div>
</body>
</html>";
        }

        // ===================== PAGE HELPERS =====================

        private void ShowStep1()
        {
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
        }

        private void ShowStep2()
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
        }

        private void ClearResetSession()
        {
            Session.Remove("ResetAccountType");
            Session.Remove("ResetAccountID");
            Session.Remove("ResetEmail");
            Session.Remove("ResetFirstName");
            Session.Remove("TempPassword");
            Session.Remove("TempPasswordExpiry");
        }

        private string GenerateTempPassword()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$";
            var random = new Random();
            char[] password = new char[10];
            for (int i = 0; i < password.Length; i++)
                password[i] = chars[random.Next(chars.Length)];
            return new string(password);
        }

        private void ShowError1(string msg)
        {
            lblMessage1.CssClass = "d-block text-danger small mb-3";
            lblMessage1.Text = msg;
        }

        private void ShowSuccess1(string msg)
        {
            lblMessage1.CssClass = "d-block text-success small mb-3";
            lblMessage1.Text = msg;
        }

        private void ShowError2(string msg)
        {
            lblMessage2.CssClass = "d-block text-danger small mb-3";
            lblMessage2.Text = msg;
        }

        private void ShowSuccess2(string msg)
        {
            lblMessage2.CssClass = "d-block text-success small mb-3";
            lblMessage2.Text = msg;
        }
    }
}