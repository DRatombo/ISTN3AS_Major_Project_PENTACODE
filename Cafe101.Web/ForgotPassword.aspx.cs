using Cafe101.Logic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Web.UI;

namespace Cafe101.Web
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private readonly AuthenticationService authService = new AuthenticationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowStep1();
            }
        }

        protected void BtnSendTempPassword_Click(object sender, EventArgs e)
        {
            lblMessage1.Text = "";
            string email = (txtEmail.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError1("Please enter your email address.");
                return;
            }

            var customer = authService.GetCustomerByEmail(email);

            if (customer == null)
            {
                ShowSuccess1("If an account with that email exists, a temporary password has been sent.");
                return;
            }

            if (!string.Equals(customer.Status, "Active", StringComparison.OrdinalIgnoreCase))
            {
                ShowError1("This account is currently inactive. Please contact Cafe101 support.");
                return;
            }

            string tempPassword = GenerateTempPassword();

            Session["ResetCustomerID"] = customer.CustomerID;
            Session["ResetEmail"] = customer.Email;
            Session["ResetFirstName"] = customer.FirstName;
            Session["TempPassword"] = tempPassword;
            Session["TempPasswordExpiry"] = DateTime.Now.AddMinutes(30);

            bool emailSent = SendTempPasswordEmailViaSendGrid(customer.Email, customer.FirstName, tempPassword);

            if (!emailSent)
            {
                ClearResetSession();
                ShowError1("We could not send the email. Please try again later.");
                return;
            }

            ShowStep2();
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            lblMessage2.Text = "";

            if (Session["ResetCustomerID"] == null || Session["TempPassword"] == null)
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

            int customerId = Convert.ToInt32(Session["ResetCustomerID"]);
            string email = Session["ResetEmail"].ToString();

            bool updated = authService.UpdateCustomerPassword(customerId, newPassword);

            if (!updated)
            {
                ShowError2("Could not update your password. Please try again.");
                return;
            }

            ClearResetSession();

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

            Response.Redirect("~/CustomerDashboard.aspx");
        }

        private bool SendTempPasswordEmailViaSendGrid(string toEmail, string firstName, string tempPassword)
        {
            try
            {
                string sendGridApiKey = ConfigurationManager.AppSettings["SendGridApiKey"];

                if (string.IsNullOrWhiteSpace(sendGridApiKey))
                {
                    LogError("SendGrid API key not configured in Web.config");
                    return false;
                }

                var client = new SendGridClient(sendGridApiKey);

                var from = new EmailAddress("mayisesnakhokonke7@gmail.com", "Cafe 101");
                var subject = "Cafe 101 – Temporary Password";
                var to = new EmailAddress(toEmail, firstName);

                string htmlContent = BuildEmailHtml(firstName, tempPassword);
                string plainTextContent = BuildEmailPlainText(firstName, tempPassword);

                var msg = new SendGridMessage()
                {
                    From = from,
                    Subject = subject,
                    HtmlContent = htmlContent,
                    PlainTextContent = plainTextContent
                };

                msg.AddTo(to);

                var response = client.SendEmailAsync(msg).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    LogInfo($"Email sent successfully to {toEmail}");
                    return true;
                }
                else
                {
                    LogError($"SendGrid returned status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError($"Email sending exception: {ex.Message} | Inner: {ex.InnerException?.Message}");
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
                <strong>⚠️ Important Security Notes:</strong><br>
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

        private string BuildEmailPlainText(string firstName, string tempPassword)
        {
            return $@"
Hi {firstName},

You requested a password reset for your Cafe101 account. If you didn't make this request, you can ignore this email.

Your temporary password is:

    {tempPassword}

INSTRUCTIONS:
1. Return to the Forgot Password page
2. Enter the temporary password above
3. Enter your new permanent password
4. Click 'Change Password & Sign In'

IMPORTANT SECURITY NOTES:
- This temporary password expires in 30 minutes
- Do not share this password with anyone
- Never reply to this email or share it

Questions? Contact our support team at support@cafe101.com

---
© Cafe 101 - This is an automated email. Please do not reply.";
        }

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
            Session.Remove("ResetCustomerID");
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

        private void LogError(string message)
        {
            try
            {
                System.Diagnostics.EventLog.WriteEntry("Cafe101",
                    $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}",
                    System.Diagnostics.EventLogEntryType.Error);
            }
            catch { }
        }

        private void LogInfo(string message)
        {
            try
            {
                System.Diagnostics.EventLog.WriteEntry("Cafe101",
                    $"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}",
                    System.Diagnostics.EventLogEntryType.Information);
            }
            catch { }
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