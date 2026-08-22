using System;
using Cafe101.Logic;

namespace Cafe101.Web
{
    public partial class DatabaseTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool connected = DatabaseTestService.TestConnection();

                if (connected)
                {
                    lblResult.Text = "Database connection successful!";
                }
                else
                {
                    lblResult.Text = "Database connection failed.";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database connection error: " + ex.Message;
            }
        }
    }
}