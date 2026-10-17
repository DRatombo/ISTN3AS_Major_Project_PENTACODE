using Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class Menu : System.Web.UI.Page
    {
        // Uses the existing logic layer to retrieve menu data.
        private readonly MenuService menuService = new MenuService();

        private List<CartItem> Cart
        {
            get
            {
                // Reuse the cart saved for this browser session.
                var cart = Session["Cart"] as List<CartItem>;

                // Create an empty cart on the first visit.
                if (cart == null)
                {
                    cart = new List<CartItem>();
                    Session["Cart"] = cart;
                }

                return cart;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only signed-in customers can use this ordering page.
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

            // Refresh the header using the customer currently signed in.
            LoadCustomerHeader();

            // Load the initial menu once.
            // Postbacks keep the selected category through ViewState.
            if (!IsPostBack)
            {
                try
                {
                    LoadCategories();

                    // Select the category requested from the dashboard.
                    // Ignore values that are not in the database category list.
                    string requestedCategory = Request.QueryString["cat"];

                    if (!string.IsNullOrWhiteSpace(requestedCategory))
                    {
                        var matchingCategory = ddlCategory.Items
                            .Cast<System.Web.UI.WebControls.ListItem>()
                            .FirstOrDefault(option => string.Equals(
                                option.Value,
                                requestedCategory,
                                StringComparison.OrdinalIgnoreCase));

                        if (matchingCategory != null)
                        {
                            ddlCategory.ClearSelection();
                            matchingCategory.Selected = true;
                        }
                    }

                    LoadMenu();
                }
                catch (Exception ex)
                {
                    // Record the technical error and show a readable message.
                    System.Diagnostics.Trace.TraceError("Menu loading failed: {0}", ex);
                    ShowMessage(
                        "The menu could not be loaded. Please try again.",
                        true);
                }
            }

            UpdateCartCount();
        }
        // Only recognised stock statuses with a positive quantity can be ordered.
        protected bool CanOrder(object stockStatus, object availableQuantity)
        {
            string status = Convert.ToString(stockStatus).Trim();
            int quantity = Convert.ToInt32(availableQuantity);

            bool available =
                status.Equals("Available", StringComparison.OrdinalIgnoreCase) ||
                status.Equals("Low Stock", StringComparison.OrdinalIgnoreCase);

            return available && quantity > 0;
        }
        private void LoadCategories()
        {
            ddlCategory.Items.Clear();

            // An empty value means no category filter is applied.
            ddlCategory.Items.Add(
                new ListItem("Full Menu", ""));

            // Use the categories already stored in MenuItemsTable.
            foreach (string category in menuService.GetCategories())
            {
                ddlCategory.Items.Add(
                    new ListItem(category, category));
            }
        }

        private void LoadMenu()
        {
            // Retrieve current products, prices and availability from the database.
            List<MenuItemDetails> items = menuService.GetMenuItems();

            string category = ddlCategory.SelectedValue;
            string search = txtMenuSearch.Text.Trim();

            if (!string.IsNullOrEmpty(category))
            {
                items = items
                    .Where(item => string.Equals(
                        item.Category,
                        category,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Match part of the product name without requiring the same letter case.
            if (!string.IsNullOrWhiteSpace(search))
            {
                items = items
                    .Where(item =>
                        (item.MenuItemName ?? "").IndexOf(
                            search,
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            rptMenu.DataSource = items;
            rptMenu.DataBind();

            lblNoItems.Text =
                "No items match your search and selected category.";

            lblNoItems.Visible = items.Count == 0;
        }

        private void LoadCustomerHeader()
        {
            // These values were saved when the customer successfully signed in.
            string firstName =
                Convert.ToString(Session["FirstName"]).Trim();

            string surname =
                Convert.ToString(Session["Surname"]).Trim();

            string fullName = (firstName + " " + surname).Trim();

            // Encode mode on the Literal controls safely displays the customer's name.
            litCustomerName.Text =
                string.IsNullOrWhiteSpace(fullName) ? "Customer" : fullName;

            string initials = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                initials += firstName.Substring(0, 1).ToUpperInvariant();
            }

            if (!string.IsNullOrWhiteSpace(surname))
            {
                initials += surname.Substring(0, 1).ToUpperInvariant();
            }

            litCustomerInitials.Text =
                string.IsNullOrEmpty(initials) ? "C" : initials;
        }

        protected void ddlCategory_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            // Clear feedback from the previous action.
            lblMessage.Text = "";

            try
            {
                LoadMenu();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Category loading failed: {0}", ex);
                ShowMessage(
                    "This category could not be loaded. Please try again.",
                    true);
            }
        }

        protected void rptMenu_ItemCommand(
            object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "AddToCart")
                return;

            int menuItemID;

            // Check the command argument before using it as a product ID.
            if (!int.TryParse(
                Convert.ToString(e.CommandArgument),
                out menuItemID))
            {
                ShowMessage("Please select a valid menu item.", true);
                return;
            }

            try
            {
                // Read the product again in case its price or stock changed
                // after the customer opened the page.
                MenuItemDetails item =
                    menuService.GetMenuItemByID(menuItemID);

                if (item == null)
                {
                    ShowMessage(
                        "This menu item is no longer available.",
                        true);

                    LoadMenu();
                    return;
                }

                // Check availability on the server as well.
                // A disabled button alone does not protect the ordering process.
                if (!CanOrder(item.StockStatus, item.AvailableQuantity))
                {
                    ShowMessage(
                        "This item is unavailable and cannot be added to your cart.",
                        true);

                    LoadMenu();
                    return;
                }

                // Check whether this product is already in the cart.
                CartItem existing = Cart.FirstOrDefault(
                    line => line.MenuItemID == menuItemID);

                int requestedQuantity =
                    existing == null ? 1 : existing.Quantity + 1;

                // Compare the total requested quantity with current stock.
                // Adding to the cart does not reserve or deduct stock.
                if (requestedQuantity > item.AvailableQuantity)
                {
                    ShowMessage(
                        "There is not enough stock to add another of this item.",
                        true);
                    return;
                }

                if (existing == null)
                {
                    // First selection of this product creates a new cart line.
                    Cart.Add(new CartItem
                    {
                        MenuItemID = item.MenuItemID,
                        MenuItemName = item.MenuItemName,
                        UnitPrice = item.SellingPrice,
                        Quantity = 1
                    });
                }
                else
                {
                    // Repeated selections increase the existing quantity.
                    // Refresh the name and price from the database as well.
                    existing.Quantity = requestedQuantity;
                    existing.MenuItemName = item.MenuItemName;
                    existing.UnitPrice = item.SellingPrice;
                }

                // Reassign the cart so session providers save the changes.
                Session["Cart"] = Cart;

                UpdateCartCount();
                // The sidebar shows the updated selection, so no success banner is needed.
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Adding to cart failed: {0}", ex);
                ShowMessage(
                    "The item could not be added. Please try again.",
                    true);
            }
        }

        private void UpdateCartCount()
        {
            // Refresh the sidebar whenever the cart changes.
            List<CartItem> cart = Cart;

            rptCart.DataSource = cart;
            rptCart.DataBind();

            int quantity = cart.Sum(item => item.Quantity);

            // Keep the header count in sync with the cart sidebar.
            litHeaderCartCount.Text = quantity.ToString();

            lblCartCount.Text = quantity + " item(s)";
            lblCartSubtotal.Text =
                "R " + cart.Sum(item => item.LineTotal).ToString("0.00");

            pnlEmptyCart.Visible = cart.Count == 0;
            pnlCartSummary.Visible = cart.Count > 0;
        }

        protected void rptCart_ItemCommand(
    object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "RemoveItem")
                return;

            int menuItemID;

            if (!int.TryParse(
                Convert.ToString(e.CommandArgument),
                out menuItemID))
            {
                ShowMessage("The selected cart item could not be removed.", true);
                return;
            }

            // Remove the whole product line, including all its selected quantities.
            List<CartItem> cart = Cart;

            int removed = cart.RemoveAll(
                item => item.MenuItemID == menuItemID);

            Session["Cart"] = cart;

            UpdateCartCount();

            ShowMessage(
                removed > 0
                    ? "Item removed from your cart."
                    : "This item is already removed from your cart.",
                removed == 0);
        }

        private void ShowMessage(string message, bool isError)
        {
            lblMessage.Text = message;

            // Red for errors and green for successful actions.
            lblMessage.CssClass = isError
                ? "d-block mb-3 text-danger"
                : "d-block mb-3 text-success";
        }

        protected void btnMenuSearch_Click(object sender, EventArgs e)
        {
            RefreshSearchResults();
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            // Clear the search while keeping the selected category.
            txtMenuSearch.Text = "";
            RefreshSearchResults();
        }

        private void RefreshSearchResults()
        {
            lblMessage.Text = "";

            try
            {
                LoadMenu();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "Menu search failed: {0}", ex);

                ShowMessage(
                    "The search could not be completed. Please try again.",
                    true);
            }
        }
    }
}