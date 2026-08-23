using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserDetails();
            }
        }

        private void LoadUserDetails()
        {
            // TEMP placeholder data — replace with real database lookup later,
            // e.g. using Session["UserId"] to fetch the logged-in user's record.
            txtFirstName.Text = "Jane";
            txtLastName.Text = "Doe";
            txtPhone.Text = "0821234567";
            txtStreetAddress.Text = "12 Palm Street";
            txtSuburb.Text = "Westville";
            txtCity.Text = "Durban";
            txtEmail.Text = "jane.doe@example.com";
            txtPassword.Text = "••••••••"; // never show the real password in plain text

            litFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
            litEmailDisplay.Text = txtEmail.Text;
            litInitials.Text = (txtFirstName.Text.Length > 0 ? txtFirstName.Text[0].ToString() : "")
                              + (txtLastName.Text.Length > 0 ? txtLastName.Text[0].ToString() : "");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SetFieldsEnabled(true);
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            lblStatus.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Save txtFirstName.Text, txtLastName.Text, etc. to the database here

            SetFieldsEnabled(false);
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            lblStatus.CssClass = "d-block text-center mt-3 small text-success";
            lblStatus.Text = "Your details have been updated.";

            litFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
            litEmailDisplay.Text = txtEmail.Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadUserDetails(); // discard edits, reload original values
            SetFieldsEnabled(false);
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            lblStatus.Text = "";
        }

        private void SetFieldsEnabled(bool enabled)
        {
            txtFirstName.Enabled = enabled;
            txtLastName.Enabled = enabled;
            txtPhone.Enabled = enabled;
            txtStreetAddress.Enabled = enabled;
            txtSuburb.Enabled = enabled;
            txtCity.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtPassword.Enabled = enabled;
        }
    }
}
