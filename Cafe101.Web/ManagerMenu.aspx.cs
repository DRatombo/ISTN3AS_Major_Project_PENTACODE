using Cafe101.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class ManagerMenu :
        System.Web.UI.Page
    {
        private readonly MenuService menuService =
            new MenuService();


        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!ManagerIsLoggedIn())
            {
                return;
            }


            if (!IsPostBack)
            {
                LoadManagerHeader();

                LoadCategoryFilter();

                LoadMenu();
            }
        }


        // ============================================================
        // SECURITY
        // ============================================================

        private bool ManagerIsLoggedIn()
        {
            if (Session["UserID"] == null ||
                Session["Role"] == null)
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return false;
            }


            string role =
                Session["Role"]
                .ToString();


            if (!role.Equals(
                "Manager",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect(
                    "~/SignIn.aspx");

                return false;
            }


            return true;
        }


        // ============================================================
        // MANAGER HEADER
        // ============================================================

        private void LoadManagerHeader()
        {
            string firstName =
                Session["FirstName"]?.ToString()
                ?? "";

            string surname =
                Session["Surname"]?.ToString()
                ?? "";

            string role =
                Session["Role"]?.ToString()
                ?? "Manager";


            string fullName =
                (firstName + " " + surname)
                .Trim();


            if (string.IsNullOrWhiteSpace(
                fullName))
            {
                fullName =
                    "Manager";
            }


            lblTopManagerName.Text =
                fullName;

            lblTopManagerRole.Text =
                role;

            lblTopManagerInitials.Text =
                CreateInitials(
                    firstName,
                    surname);
        }


        private string CreateInitials(
            string firstName,
            string surname)
        {
            string initials =
                "";


            if (!string.IsNullOrWhiteSpace(
                firstName))
            {
                initials +=
                    firstName.Substring(
                        0,
                        1)
                    .ToUpper();
            }


            if (!string.IsNullOrWhiteSpace(
                surname))
            {
                initials +=
                    surname.Substring(
                        0,
                        1)
                    .ToUpper();
            }


            return
                string.IsNullOrWhiteSpace(
                    initials)
                ? "M"
                : initials;
        }


        // ============================================================
        // CATEGORY FILTER
        // ============================================================

        private void LoadCategoryFilter()
        {
            ddlCategory.Items.Clear();


            ddlCategory.Items.Add(
                new ListItem(
                    "All Categories",
                    ""));


            List<string> categories =
                menuService
                .GetCategories();


            foreach (string category
                in categories)
            {
                ddlCategory.Items.Add(
                    new ListItem(
                        category,
                        category));
            }
        }


        // ============================================================
        // LOAD MENU
        // ============================================================

        private void LoadMenu()
        {
            try
            {
                List<MenuItemDetails> items =
                    menuService
                    .GetMenuItems();


                // Search
                string search =
                    txtSearch.Text
                    .Trim();


                if (!string.IsNullOrWhiteSpace(
                    search))
                {
                    items =
                        items
                        .Where(
                            item =>
                                item.MenuItemName
                                .IndexOf(
                                    search,
                                    StringComparison
                                    .OrdinalIgnoreCase)
                                >= 0
                                ||
                                item.Category
                                .IndexOf(
                                    search,
                                    StringComparison
                                    .OrdinalIgnoreCase)
                                >= 0)
                        .ToList();
                }


                // Category
                if (!string.IsNullOrWhiteSpace(
                    ddlCategory
                    .SelectedValue))
                {
                    string category =
                        ddlCategory
                        .SelectedValue;


                    items =
                        items
                        .Where(
                            item =>
                                item.Category
                                .Equals(
                                    category,
                                    StringComparison
                                    .OrdinalIgnoreCase))
                        .ToList();
                }


                // Status
                if (!string.IsNullOrWhiteSpace(
                    ddlStatus
                    .SelectedValue))
                {
                    string status =
                        ddlStatus
                        .SelectedValue;


                    items =
                        items
                        .Where(
                            item =>
                                item.StockStatus
                                .Equals(
                                    status,
                                    StringComparison
                                    .OrdinalIgnoreCase))
                        .ToList();
                }


                rptMenuItems.DataSource =
                    items;

                rptMenuItems.DataBind();


                // ================================================
                // SUMMARY CARDS
                // ================================================

                List<MenuItemDetails>
                    allItems =
                    menuService
                    .GetMenuItems();


                lblTotalItems.Text =
                    allItems.Count
                    .ToString();


                lblAvailable.Text =
                    allItems
                    .Count(
                        item =>
                            item.StockStatus ==
                            "Available")
                    .ToString();


                lblUnavailable.Text =
                    allItems
                    .Count(
                        item =>
                            item.StockStatus ==
                            "Unavailable")
                    .ToString();


                lblCategoryCount.Text =
                    allItems
                    .Select(
                        item =>
                            item.Category)
                    .Where(
                        category =>
                            !string
                            .IsNullOrWhiteSpace(
                                category))
                    .Distinct(
                        StringComparer
                        .OrdinalIgnoreCase)
                    .Count()
                    .ToString();


                lblShowingItems.Text =
                    "Showing " +
                    items.Count +
                    " of " +
                    allItems.Count +
                    " items";


                // ================================================
                // LOW STOCK
                // ================================================

                List<MenuItemDetails>
                    lowStockItems =
                    allItems
                    .Where(
                        item =>
                            item.StockStatus ==
                            "Low Stock")
                    .OrderBy(
                        item =>
                            item.AvailableQuantity)
                    .Take(4)
                    .ToList();


                rptLowStock.DataSource =
                    lowStockItems;

                rptLowStock.DataBind();


                // ================================================
                // CATEGORY SUMMARY
                // ================================================

                var categories =
                    allItems
                    .GroupBy(
                        item =>
                            item.Category)
                    .Select(
                        group =>
                            new
                            {
                                Category =
                                    group.Key,

                                ItemCount =
                                    group.Count()
                            })
                    .OrderBy(
                        group =>
                            group.Category)
                    .ToList();


                rptCategories.DataSource =
                    categories;

                rptCategories.DataBind();


                // ================================================
                // SELECT FIRST ITEM
                // ================================================

                if (allItems.Count > 0)
                {
                    int selectedID;


                    if (ViewState[
                        "SelectedMenuItemID"]
                        != null)
                    {
                        selectedID =
                            Convert.ToInt32(
                                ViewState[
                                    "SelectedMenuItemID"]);
                    }
                    else
                    {
                        selectedID =
                            allItems[0]
                            .MenuItemID;
                    }


                    LoadSelectedItem(
                        selectedID);
                }
                else
                {
                    pnlSelectedItem.Visible =
                        false;
                }


                lblMessage.Text =
                    "";
            }
            catch (Exception ex)
            {
                lblMessage.CssClass =
                    "alert alert-danger d-block";

                lblMessage.Text =
                    "Unable to load menu items. " +
                    ex.Message;
            }
        }


        // ============================================================
        // SELECT MENU ITEM
        // ============================================================

        protected void SelectMenuItem_Command(
            object sender,
            CommandEventArgs e)
        {
            int menuItemID;


            if (!int.TryParse(
                e.CommandArgument
                .ToString(),
                out menuItemID))
            {
                return;
            }


            ViewState[
                "SelectedMenuItemID"] =
                menuItemID;


            LoadSelectedItem(
                menuItemID);
        }


        private void LoadSelectedItem(
            int menuItemID)
        {
            MenuItemDetails item =
                menuService
                .GetMenuItemByID(
                    menuItemID);


            if (item == null)
            {
                pnlSelectedItem.Visible =
                    false;

                return;
            }


            pnlSelectedItem.Visible =
                true;


            lblSelectedName.Text =
                item.MenuItemName;


            lblSelectedCategory.Text =
                item.Category;


            lblSelectedPrice.Text =
                item.SellingPrice
                .ToString("C2")
                .Replace("$", "R");


            lblSelectedCost.Text =
                item.CostToMake
                .ToString("C2")
                .Replace("$", "R");


            lblSelectedPreparation.Text =
                item.PreparationTime +
                " minutes";


            lblSelectedQuantity.Text =
                item.AvailableQuantity
                .ToString();


            lblSelectedSold.Text =
                item.QuantitySold
                .ToString();


            lblSelectedStatus.Text =
                item.StockStatus;


            lblSelectedStatus.CssClass =
                GetStatusCssClass(
                    item.StockStatus);


            lblSelectedEmoji.Text =
                GetCategoryEmoji(
                    item.Category);
        }


        // ============================================================
        // FILTER EVENTS
        // ============================================================

        protected void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadMenu();
        }


        protected void DdlCategory_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadMenu();
        }


        protected void DdlStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadMenu();
        }


        protected void BtnRefresh_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text =
                "";

            ddlCategory.SelectedIndex =
                0;

            ddlStatus.SelectedIndex =
                0;


            LoadMenu();
        }


        // ============================================================
        // DELETE
        // ============================================================

        protected void BtnDeleteSelected_Click(
            object sender,
            EventArgs e)
        {
            if (ViewState[
                "SelectedMenuItemID"]
                == null)
            {
                lblMessage.CssClass =
                    "alert alert-warning d-block";

                lblMessage.Text =
                    "Please select a menu item first.";

                return;
            }


            try
            {
                int menuItemID =
                    Convert.ToInt32(
                        ViewState[
                            "SelectedMenuItemID"]);


                string result =
                    menuService
                    .DeleteMenuItem(
                        menuItemID);


                if (!string.IsNullOrWhiteSpace(
                    result))
                {
                    lblMessage.CssClass =
                        "alert alert-warning d-block";

                    lblMessage.Text =
                        result;

                    return;
                }


                ViewState[
                    "SelectedMenuItemID"] =
                    null;


                lblMessage.CssClass =
                    "alert alert-success d-block";

                lblMessage.Text =
                    "Menu item deleted successfully.";


                LoadCategoryFilter();

                LoadMenu();
            }
            catch (Exception ex)
            {
                lblMessage.CssClass =
                    "alert alert-danger d-block";

                lblMessage.Text =
                    "Unable to delete the menu item. " +
                    ex.Message;
            }
        }


        // ============================================================
        // DISPLAY HELPERS
        // ============================================================

        public string GetStatusCssClass(
            string status)
        {
            if (status.Equals(
                "Available",
                StringComparison.OrdinalIgnoreCase))
            {
                return
                    "manager-menu-status status-available";
            }


            if (status.Equals(
                "Low Stock",
                StringComparison.OrdinalIgnoreCase))
            {
                return
                    "manager-menu-status status-low-stock";
            }


            return
                "manager-menu-status status-unavailable";
        }


        public string GetCategoryEmoji(
            string category)
        {
            if (string.IsNullOrWhiteSpace(
                category))
            {
                return "🍽";
            }


            string value =
                category.ToLower();


            if (value.Contains(
                "drink"))
            {
                return "🥤";
            }


            if (value.Contains(
                "beverage"))
            {
                return "☕";
            }


            if (value.Contains(
                "burger"))
            {
                return "🍔";
            }


            if (value.Contains(
                "wing"))
            {
                return "🍗";
            }


            if (value.Contains(
                "side"))
            {
                return "🍟";
            }


            if (value.Contains(
                "combo"))
            {
                return "🍱";
            }


            return "🍽";
        }


        // ============================================================
        // LOGOUT
        // ============================================================

        protected void LnkLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect(
                "~/SignIn.aspx");
        }
    }
}