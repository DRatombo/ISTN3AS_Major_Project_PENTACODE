using global::Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe101.Web
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        private readonly MenuService menuService = new MenuService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check the login before loading any customer information.
            if (Session["UserID"] == null ||
                !string.Equals(
                    Convert.ToString(Session["UserType"]),
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            LoadLoggedInCustomer();
            LoadCartCount();

            if (!IsPostBack)
            {
                LoadDashboardMenu();
            }
        }

        private void LoadLoggedInCustomer()
        {
            // Authentication saves these details when the customer signs in.
            string firstName =
                Convert.ToString(Session["FirstName"]).Trim();

            string surname =
                Convert.ToString(Session["Surname"]).Trim();

            string fullName = (firstName + " " + surname).Trim();

            // The welcome Literal must have Mode="Encode" in the ASPX file.
            litFirstName.Text =
                string.IsNullOrWhiteSpace(firstName)
                    ? "Customer"
                    : firstName;

            lblTopCustomerName.Text = HttpUtility.HtmlEncode(
                string.IsNullOrWhiteSpace(fullName)
                    ? "Customer"
                    : fullName);

            string initials = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials += firstName.Substring(0, 1).ToUpperInvariant();
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials += surname.Substring(0, 1).ToUpperInvariant();
            }

            lblCustomerInitials.Text = HttpUtility.HtmlEncode(
                string.IsNullOrEmpty(initials) ? "C" : initials);
        }

        private void LoadCartCount()
        {
            // Read the same session cart used by the menu page.
            List<CartItem> cart = Session["Cart"] as List<CartItem>;

            int quantity = 0;

            if (cart != null)
            {
                quantity = cart.Sum(item => item.Quantity);
            }

            // Update the red badge without replacing the cart icon.
            litDashboardCartCount.Text = quantity.ToString();
        }

        private void LoadDashboardMenu()
        {
            lblDashboardMessage.Text = "";

            try
            {
                // Reuse one menu result for the popular and preview sections.
                List<MenuItemDetails> items = menuService.GetMenuItems();

                rptCategories.DataSource = menuService.GetCategories();
                rptCategories.DataBind();

                // Only display popular items when recorded sales exist.
                List<MenuItemDetails> popularItems = items
                    .Where(item => item.QuantitySold > 0)
                    .OrderByDescending(item => item.QuantitySold)
                    .ThenBy(item => item.MenuItemName)
                    .Take(6)
                    .ToList();

                rptPopularItems.DataSource = popularItems;
                rptPopularItems.DataBind();

                pnlPopularItems.Visible = popularItems.Count > 0;

                string search = txtSearch.Text.Trim();

                List<MenuItemDetails> previewItems;

                if (string.IsNullOrWhiteSpace(search))
                {
                    previewItems = items
                        .OrderBy(item => item.MenuItemName)
                        .Take(8)
                        .ToList();
                }
                else
                {
                    // Match product names without requiring the same letter case.
                    previewItems = items
                        .Where(item =>
                            (item.MenuItemName ?? "").IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase) >= 0)
                        .OrderBy(item => item.MenuItemName)
                        .ToList();
                }

                rptMenuPreview.DataSource = previewItems;
                rptMenuPreview.DataBind();

                lblNoMenuItems.Visible = previewItems.Count == 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "Dashboard menu loading failed: {0}", ex);

                // Remove old results if the database request fails.
                rptCategories.DataSource = new List<string>();
                rptCategories.DataBind();

                rptPopularItems.DataSource = new List<MenuItemDetails>();
                rptPopularItems.DataBind();

                rptMenuPreview.DataSource = new List<MenuItemDetails>();
                rptMenuPreview.DataBind();

                pnlPopularItems.Visible = false;
                lblNoMenuItems.Visible = false;

                lblDashboardMessage.Text =
                    "The menu could not be loaded. Please try again.";
            }
        }

        protected string GetCategoryUrl(string category)
        {
            // Encode spaces and special characters in category links.
            return "Menu.aspx?cat=" + HttpUtility.UrlEncode(category);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDashboardMenu();
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            // End the customer's session and clear its cart.
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/SignIn.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}