using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Cafe101.Web
{
    public static class ReportEmailSender
    {
        public static void Send(string toEmail, string toName, string rangeLabel, byte[] pdf, string fileName)
        {
            string user = ConfigurationManager.AppSettings["SmtpUser"];
            string password = ConfigurationManager.AppSettings["SmtpPassword"];

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Email settings (SmtpUser / SmtpPassword) are missing in Web.config.");

            // Gmail app passwords work without the spaces
            password = password.Replace(" ", "");

            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(user, "Cafe101");
                msg.To.Add(toEmail);
                msg.Subject = "Cafe101 Business Report - " + rangeLabel;
                msg.IsBodyHtml = true;
                msg.Body =
                    "<p>Hi " + WebUtility.HtmlEncode(toName) + ",</p>" +
                    "<p>Your Cafe101 business report for <strong>" + WebUtility.HtmlEncode(rangeLabel) +
                    "</strong> is attached as a PDF.</p>" +
                    "<p>Regards,<br/>Cafe101 Manager System</p>";

                msg.Attachments.Add(new Attachment(new MemoryStream(pdf), fileName, "application/pdf"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(user, password);
                    smtp.Send(msg);
                }
            }
        }
    }
}