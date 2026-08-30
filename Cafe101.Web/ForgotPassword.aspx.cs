using Cafe101.Logic;
using System;
using System.Net;
using System.Net.Mail;
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
                // Start on Step 1
                ShowStep1();
            }
        }

        // ============================================================
        // STEP 1: SEND TEMPORARY PASSWORD
        // ============================================================
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

            // Generate temporary password (DO NOT save it to the database)
            string tempPassword = GenerateTempPassword();

            // Store everything needed in Session only
            Session["ResetCustomerID"] = customer.CustomerID;
            Session["ResetEmail"] = customer.Email;
            Session["ResetFirstName"] = customer.FirstName;
            Session["TempPassword"] = tempPassword;
            Session["TempPasswordExpiry"] = DateTime.Now.AddMinutes(30); // valid for 30 minutes

            // Send the email
            bool emailSent = SendTempPasswordEmail(customer.Email, customer.FirstName, tempPassword);

            if (!emailSent)
            {
                // Clear session if email failed
                Session.Remove("ResetCustomerID");
                Session.Remove("ResetEmail");
                Session.Remove("ResetFirstName");
                Session.Remove("TempPassword");
                Session.Remove("TempPasswordExpiry");

                ShowError1("We could not send the email. Please try again later.");
                return;
            }

            // Move to Step 2
            ShowStep2();
        }

        // ============================================================
        // STEP 2: VERIFY TEMP PASSWORD + SET NEW PASSWORD + LOGIN
        // ============================================================
        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            lblMessage2.Text = "";

            // Check if the reset session is still valid
            if (Session["ResetCustomerID"] == null || Session["TempPassword"] == null)
            {
                ShowError2("Session expired. Please start the process again.");
                ShowStep1();
                return;
            }

            // Check if the temporary password has expired
            if (Session["TempPasswordExpiry"] == null ||
                DateTime.Now > (DateTime)Session["TempPasswordExpiry"])
            {
                ShowError2("The temporary password has expired. Please request a new one.");
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

            // Verify the temporary password against what is stored in Session
            string correctTempPassword = Session["TempPassword"].ToString();

            if (enteredTempPassword != correctTempPassword)
            {
                ShowError2("The temporary password is incorrect. Please check your email and try again.");
                return;
            }

            int customerId = Convert.ToInt32(Session["ResetCustomerID"]);
            string email = Session["ResetEmail"].ToString();

            // NOW update the real password in the database
            bool updated = authService.UpdateCustomerPassword(customerId, newPassword);

            if (!updated)
            {
                ShowError2("Could not update your password. Please try again.");
                return;
            }

            // Clear the reset session
            Session.Remove("ResetCustomerID");
            Session.Remove("ResetEmail");
            Session.Remove("ResetFirstName");
            Session.Remove("TempPassword");
            Session.Remove("TempPasswordExpiry");

            // Log the customer in using the NEW password
            var loginResult = authService.SignIn(email, newPassword);

            if (!loginResult.Success)
            {
                // Password was updated but login failed for some reason
                ShowError2("Password updated successfully. Please go to Sign In and log in with your new password.");
                return;
            }

            // Set session the same way as normal Sign In
            Session["UserID"] = loginResult.UserID;
            Session["UserType"] = loginResult.UserType;
            Session["Role"] = loginResult.Role;
            Session["FirstName"] = loginResult.FirstName;
            Session["Surname"] = loginResult.Surname;
            Session["Email"] = loginResult.Email;
            Session["Address"] = loginResult.Address;
            Session["PhoneNumber"] = loginResult.PhoneNumber;

            // Redirect to Customer Dashboard
            Response.Redirect("~/CustomerDashboard.aspx");
        }

        // ============================================================
        // HELPERS
        // ============================================================
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

        private string GenerateTempPassword()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789!@#$";
            var random = new Random();
            char[] password = new char[10];
            for (int i = 0; i < password.Length; i++)
                password[i] = chars[random.Next(chars.Length)];
            return new string(password);
        }

        private bool SendTempPasswordEmail(string toEmail, string firstName, string tempPassword)
        {
            try
            {
                string fromEmail = "mayisesnakhokonke7@gmail.com";
                string appPassword = "nkwl wept pruf ljyk";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail, "Cafe 101");
                    mail.To.Add(toEmail);
                    mail.Subject = "Cafe 101 – Temporary Password";
                    mail.Body =
                        $"Hi {firstName},\n\n" +
                        "You requested a password reset for your Cafe101 account.\n\n" +
                        $"Your temporary password is:\n\n" +
                        $"    {tempPassword}\n\n" +
                        "Please return to the Forgot Password page and enter this temporary password " +
                        "together with your new permanent password.\n\n" +
                        "Do not share this password with anyone.\n\n" +
                        "– Cafe 101 Team\n" +
                        "(This is an automated do-not-reply email)";

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
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