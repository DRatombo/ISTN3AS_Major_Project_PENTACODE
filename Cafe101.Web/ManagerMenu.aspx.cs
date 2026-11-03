using Cafe101.Logic;
using Cafe101.Data;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe101.Web
{
    public partial class ManagerMenu : Page
    {
        private readonly MenuService menuService = new MenuService();
        private const int PageSize = 6;

        // A newly-created menu item is not considered complete until it has a recipe.
        private int? PendingMenuItemID
        {
            get
            {
                int id;
                return Session["PendingMenuItemID"] != null &&
                       int.TryParse(Convert.ToString(Session["PendingMenuItemID"]), out id)
                    ? (int?)id : null;
            }
            set
            {
                if (value.HasValue) Session["PendingMenuItemID"] = value.Value;
                else Session.Remove("PendingMenuItemID");
            }
        }

        private bool HasRecipe(int menuItemID)
        {
            DataTable ingredients = menuService.GetRecipeIngredients(menuItemID);
            return ingredients != null && ingredients.Rows.Count > 0;
        }

        private bool IsDuplicateMenuItemName(string name, int? excludeID = null)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (SqlCommand command = connection.CreateCommand())
            {
                string sql = "SELECT COUNT(*) FROM MenuItemsTable WHERE LOWER(LTRIM(RTRIM(MenuItemName))) = LOWER(@Name)";
                if (excludeID.HasValue) sql += " AND MenuItemID <> @ID";
                command.CommandText = sql;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name.Trim();
                if (excludeID.HasValue) command.Parameters.Add("@ID", SqlDbType.Int).Value = excludeID.Value;
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private void LoadRecipeIngredientOptions()
        {
            DropDownList ingredients = MenuControl<DropDownList>("ddlRecipeIngredient");
            ingredients.Items.Clear();
            ingredients.DataSource = menuService.GetAllIngredients();
            ingredients.DataTextField = "Description";
            ingredients.DataValueField = "IngredientID";
            ingredients.DataBind();
            ingredients.Items.Insert(0, new ListItem("-- Select Ingredient --", ""));
            MenuControl<TextBox>("txtRecipeQuantity").Text = "";
        }

        private void OpenRecipeEditor(int menuItemID, bool pendingNewItem)
        {
            SelectedMenuItemID = menuItemID;
            LoadRecipeIngredientOptions();
            SetEditMode(false);
            MenuControl<Panel>("pnlViewItem").Visible = false;
            pnlEditItem.Visible = false;
            MenuControl<Panel>("pnlAddItem").Visible = false;
            MenuControl<Panel>("pnlManageRecipe").Visible = true;
            pnlSelectedItem.Visible = true;
            MenuControl<Label>("lblRecipeInstructions").Text = pendingNewItem
                ? "Add at least one ingredient, then select Finish Recipe to complete this menu item. Cancelling will delete the pending item."
                : "Add ingredients and quantities required to prepare one menu item.";
            ClearMessage();
        }

        private void DeletePendingMenuItem()
        {
            if (!PendingMenuItemID.HasValue) return;
            int id = PendingMenuItemID.Value;
            // The pending item has not been made available to orders; remove it if its recipe is abandoned.
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteRecipe = new SqlCommand(
                            "DELETE FROM RecipeTable WHERE MenuItemID = @ID", connection, transaction))
                        {
                            deleteRecipe.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                            deleteRecipe.ExecuteNonQuery();
                        }
                        using (SqlCommand deleteItem = new SqlCommand(
                            "DELETE FROM MenuItemsTable WHERE MenuItemID = @ID", connection, transaction))
                        {
                            deleteItem.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                            deleteItem.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            PendingMenuItemID = null;
        }

        private void CompletePendingMenuItem()
        {
            if (!PendingMenuItemID.HasValue) return;
            int id = PendingMenuItemID.Value;
            if (!HasRecipe(id))
            {
                ShowMessage("Add at least one ingredient before finishing this menu item.", "warning");
                return;
            }

            PendingMenuItemID = null;
            MenuControl<Panel>("pnlManageRecipe").Visible = false;
            pnlSelectedItem.Visible = false;
            txtSearch.Text = "";
            ddlCategory.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            LoadCategoryFilter();
            List<MenuItemDetails> items = menuService.GetMenuItems();
            int index = items.FindIndex(x => x.MenuItemID == id);
            CurrentMenuPage = index < 0 ? 0 : index / PageSize;
            SelectedMenuItemID = id;
            LoadMenu();
            ShowMessage("Menu item added successfully with its recipe.", "success");
        }


        // A cleared hidden field means the details drawer is closed.
        private HiddenField SelectedField
        {
            get { return MenuControl<HiddenField>("hfSelectedMenuItemID"); }
        }

        private int? SelectedMenuItemID
        {
            get
            {
                int id;
                return SelectedField != null && int.TryParse(SelectedField.Value, out id)
                ? (int?)id : null;
            }
            set
            {
                if (SelectedField != null)
                    SelectedField.Value = value.HasValue ? value.Value.ToString() : "";
            }
        }

        private void SetEditMode(bool editing)
        {
            Panel details = MenuControl<Panel>("pnlViewItem");
            if (details != null) details.Visible = !editing;
            pnlEditItem.Visible = editing;
        }

        private int CurrentMenuPage
        {
            get { return ViewState["CurrentMenuPage"] == null ? 0 : (int)ViewState["CurrentMenuPage"]; }
            set { ViewState["CurrentMenuPage"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ManagerIsLoggedIn()) return;
            if (!IsPostBack)
            {
                LoadManagerHeader();
                LoadCategoryFilter();
                LoadMenu();
            }
            else if (PendingMenuItemID.HasValue)
            {
                // Preserve the required-recipe workflow across UpdatePanel postbacks.
                SelectedMenuItemID = PendingMenuItemID.Value;
            }
        }

        // Find newly added controls without manual designer.cs edits.
        private T FindPageControl<T>(Control parent, string id) where T : Control
        {
            if (parent == null) return null;
            if (parent.ID == id && parent is T) return (T)parent;
            foreach (Control child in parent.Controls)
            {
                T match = FindPageControl<T>(child, id);
                if (match != null) return match;
            }
            return null;
        }

        private T MenuControl<T>(string id) where T : Control
        {
            return FindPageControl<T>(this, id);
        }

        private bool ManagerIsLoggedIn()
        {
            if (Session["UserID"] == null || Session["Role"] == null ||
            !string.Equals(Convert.ToString(Session["Role"]), "Manager", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
                return false;
            }
            return true;
        }

        private void LoadManagerHeader()
        {
            string firstName = Convert.ToString(Session["FirstName"]) ?? "";
            string surname = Convert.ToString(Session["Surname"]) ?? "";
            string fullName = (firstName + " " + surname).Trim();
            lblTopManagerName.Text = Server.HtmlEncode(string.IsNullOrWhiteSpace(fullName) ? "Manager" : fullName);
            lblTopManagerRole.Text = "Manager";
            lblTopManagerInitials.Text = (firstName.Length > 0 ? firstName.Substring(0, 1) : "") +
            (surname.Length > 0 ? surname.Substring(0, 1) : "");
            if (string.IsNullOrWhiteSpace(lblTopManagerInitials.Text)) lblTopManagerInitials.Text = "M";
            lblTopManagerInitials.Text = lblTopManagerInitials.Text.ToUpperInvariant();
        }

        private void LoadCategoryFilter()
        {
            string selected = ddlCategory.SelectedValue;
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem("All Categories", ""));
            foreach (string category in menuService.GetCategories())
                ddlCategory.Items.Add(new ListItem(category, category));
            if (ddlCategory.Items.FindByValue(selected) != null)
                ddlCategory.SelectedValue = selected;
        }

        private void LoadMenu()
        {
            try
            {
                // All values come from MenuService / SQL Server.
                List<MenuItemDetails> allItems = menuService.GetMenuItems();
                IEnumerable<MenuItemDetails> filtered = allItems;
                string search = (txtSearch.Text ?? "").Trim();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    filtered = filtered.Where(item =>
                    item.MenuItemID.ToString().IndexOf(search.TrimStart('#'), StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (item.MenuItemName ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (item.Category ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                if (!string.IsNullOrWhiteSpace(ddlCategory.SelectedValue))
                    filtered = filtered.Where(item => string.Equals(item.Category, ddlCategory.SelectedValue, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(ddlStatus.SelectedValue))
                    filtered = filtered.Where(item => string.Equals(item.StockStatus, ddlStatus.SelectedValue, StringComparison.OrdinalIgnoreCase));

                List<MenuItemDetails> matched = filtered.ToList();
                int totalPages = Math.Max(1, (matched.Count + PageSize - 1) / PageSize);
                CurrentMenuPage = Math.Max(0, Math.Min(CurrentMenuPage, totalPages - 1));
                List<MenuItemDetails> visibleItems = matched.Skip(CurrentMenuPage * PageSize).Take(PageSize).ToList();

                rptMenuItems.DataSource = visibleItems;
                rptMenuItems.DataBind();

                Panel empty = MenuControl<Panel>("pnlNoMenuItems");
                if (empty != null) empty.Visible = matched.Count == 0;

                LinkButton previous = MenuControl<LinkButton>("lnkPreviousMenu");
                LinkButton next = MenuControl<LinkButton>("lnkNextMenu");
                Label pageLabel = MenuControl<Label>("lblMenuPage");
                if (previous != null) previous.Enabled = CurrentMenuPage > 0;
                if (next != null) next.Enabled = CurrentMenuPage < totalPages - 1;
                if (pageLabel != null) pageLabel.Text = "Page " + (CurrentMenuPage + 1) + " of " + totalPages;

                int start = matched.Count == 0 ? 0 : CurrentMenuPage * PageSize + 1;
                int end = Math.Min(matched.Count, (CurrentMenuPage + 1) * PageSize);
                lblShowingItems.Text = "Showing " + start + "–" + end + " of " + matched.Count + " matching items";

                lblTotalItems.Text = allItems.Count.ToString();
                lblAvailable.Text = allItems.Count(item => item.StockStatus == "Available").ToString();
                lblUnavailable.Text = allItems.Count(item => item.StockStatus == "Unavailable").ToString();
                lblCategoryCount.Text = allItems.Select(item => item.Category)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase).Count().ToString();

                List<MenuItemDetails> lowStockItems = allItems.Where(item => item.StockStatus == "Low Stock")
                .OrderBy(item => item.AvailableQuantity).Take(4).ToList();
                rptLowStock.DataSource = lowStockItems;
                rptLowStock.DataBind();
                Label lowStockEmpty = MenuControl<Label>("lblNoLowStock");
                if (lowStockEmpty != null) lowStockEmpty.Visible = lowStockItems.Count == 0;

                rptCategories.DataSource = allItems.GroupBy(item => item.Category)
                .Select(group => new { Category = group.Key, ItemCount = group.Count() })
                .OrderBy(group => group.Category).ToList();
                rptCategories.DataBind();

                // Unlike the old layout, no item is auto-selected on page load.
                // The table fills the page until the user clicks View.
                if (!SelectedMenuItemID.HasValue ||
                !matched.Any(item => item.MenuItemID == SelectedMenuItemID.Value))
                {
                    SelectedMenuItemID = null;
                    pnlSelectedItem.Visible = false;
                    SetEditMode(false);
                }
                else
                {
                    LoadSelectedItem(SelectedMenuItemID.Value);
                }
            }
            catch (Exception)
            {
                ShowMessage("Unable to load menu items. Check the SQL Server connection.", "danger");
            }
        }

        private void LoadSelectedItem(int menuItemID)
        {
            MenuItemDetails item = menuService.GetMenuItemByID(menuItemID);
            if (item == null) { pnlSelectedItem.Visible = false; return; }
            pnlSelectedItem.Visible = true;
            lblSelectedName.Text = Server.HtmlEncode(item.MenuItemName);
            lblSelectedCategory.Text = Server.HtmlEncode(item.Category);
            lblSelectedPrice.Text = "R" + item.SellingPrice.ToString("N2");
            lblSelectedCost.Text = "R" + item.CostToMake.ToString("N2");
            lblSelectedPreparation.Text = item.PreparationTime + " minutes";
            lblSelectedQuantity.Text = item.AvailableQuantity.ToString();
            lblSelectedStatus.Text = Server.HtmlEncode(item.StockStatus);
            lblSelectedStatus.CssClass = GetStatusCssClass(item.StockStatus);
            lblSelectedEmoji.Text = GetCategoryEmoji(item.Category);
            Label idLabel = MenuControl<Label>("lblSelectedItemID");
            if (idLabel != null) idLabel.Text = item.MenuItemID.ToString();
            // ============================================================
            // LOAD RECIPE INGREDIENTS
            // ============================================================

            var recipeIngredients =
            menuService.GetRecipeIngredients(menuItemID);

            Repeater recipeRepeater =
            MenuControl<Repeater>("rptSelectedRecipe");

            Label emptyRecipeLabel =
            MenuControl<Label>("lblRecipeEmpty");

            // Display ingredients from SQL Server
            recipeRepeater.DataSource = recipeIngredients;
            recipeRepeater.DataBind();

            // Show message if no ingredients are assigned
            emptyRecipeLabel.Visible =
            recipeIngredients.Rows.Count == 0;
        }

        private void ShowMessage(string message, string kind)
        {
            lblMessage.CssClass = "alert alert-" + kind + " d-block";
            lblMessage.Text = Server.HtmlEncode(message);
        }

        private void ClearMessage()
        {
            lblMessage.Text = "";
            lblMessage.CssClass = "d-none";
        }

        protected void SelectMenuItem_Command(object sender, CommandEventArgs e)
        {
            if (PendingMenuItemID.HasValue)
            {
                OpenRecipeEditor(PendingMenuItemID.Value, true);
                ShowMessage("Complete or cancel the pending recipe before selecting another menu item.", "warning");
                return;
            }
            int id;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id)) return;
            SelectedMenuItemID = id;
            SetEditMode(false);
            ClearMessage();
            LoadSelectedItem(id);
        }

        protected void BtnSearch_Click(object sender, EventArgs e) { if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before changing the menu listing.", "warning"); return; } ResetListing(); }
        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e) { if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before changing the menu listing.", "warning"); return; } ResetListing(); }
        protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e) { if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before changing the menu listing.", "warning"); return; } ResetListing(); }

        private void ResetListing()
        {
            CurrentMenuPage = 0;
            SelectedMenuItemID = null;
            SetEditMode(false);
            pnlSelectedItem.Visible = false;
            ClearMessage();
            LoadMenu();
        }

        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before refreshing.", "warning"); return; }
            txtSearch.Text = "";
            ddlCategory.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ResetListing();
        }

        protected void PreviousMenu_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before changing pages.", "warning"); return; }
            if (CurrentMenuPage > 0) CurrentMenuPage--;
            SelectedMenuItemID = null;
            SetEditMode(false);
            LoadMenu();
        }

        protected void NextMenu_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue) { OpenRecipeEditor(PendingMenuItemID.Value, true); ShowMessage("Complete or cancel the pending recipe before changing pages.", "warning"); return; }
            CurrentMenuPage++;
            SelectedMenuItemID = null;
            SetEditMode(false);
            LoadMenu();
        }


        // ============================================================
        // OPEN ADD MENU ITEM
        // ============================================================

        protected void BtnAddNewItem_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue)
            {
                OpenRecipeEditor(PendingMenuItemID.Value, true);
                ShowMessage("Complete or cancel the pending recipe before adding another menu item.", "warning");
                return;
            }
            MenuControl<TextBox>("txtNewName").Text = "";
            MenuControl<TextBox>("txtNewPrice").Text = "";
            MenuControl<TextBox>("txtNewCost").Text = "";
            MenuControl<TextBox>("txtNewCategory").Text = "";
            MenuControl<TextBox>("txtNewPreparation").Text = "";

            // Hide the selected item and open the Add form
            SetEditMode(false);
            pnlSelectedItem.Visible = false;
            MenuControl<Panel>("pnlAddItem").Visible = true;

            // Opens the existing slide-out panel
            SelectedField.Value = "new";

            ClearMessage();
        }

        // ============================================================
        // SAVE NEW MENU ITEM
        // ============================================================

        protected void BtnSaveNew_Click(object sender, EventArgs e)
        {
            TextBox name = MenuControl<TextBox>("txtNewName");
            TextBox priceText = MenuControl<TextBox>("txtNewPrice");
            TextBox costText = MenuControl<TextBox>("txtNewCost");
            TextBox category = MenuControl<TextBox>("txtNewCategory");
            TextBox prepText = MenuControl<TextBox>("txtNewPreparation");

            decimal price, cost;
            int preparation;
            string itemName = (name.Text ?? "").Trim();
            string itemCategory = (category.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(itemName) || !Regex.IsMatch(itemName, @"^[\p{L} ]+$") ||
                string.IsNullOrWhiteSpace(itemCategory) ||
                !decimal.TryParse(priceText.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ||
                !decimal.TryParse(costText.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out cost) ||
                !int.TryParse(prepText.Text, out preparation) ||
                price <= 0 || cost <= 0 || preparation < 1 || preparation > 999)
            {
                ShowMessage("Enter a valid name (letters and spaces), category, positive selling/cost prices, and preparation time between 1 and 999 minutes. Use a dot for decimal prices.", "warning");
                return;
            }

            if (IsDuplicateMenuItemName(itemName))
            {
                ShowMessage("A menu item with this name already exists. Please use a different name.", "warning");
                return;
            }

            try
            {
                int newID;
                string result = menuService.AddMenuItem(itemName, price, cost, itemCategory, preparation, out newID);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    ShowMessage(result, "warning");
                    return;
                }
                if (newID <= 0)
                {
                    ShowMessage("The menu item could not be created. Please try again.", "danger");
                    return;
                }

                // Save temporarily to obtain its ID, then require a recipe before completion.
                PendingMenuItemID = newID;
                OpenRecipeEditor(newID, true);
                ShowMessage("Menu item created as pending. Add at least one recipe ingredient and finish the recipe to complete it.", "warning");
            }
            catch (Exception)
            {
                ShowMessage("Unable to create the menu item. Check the database connection.", "danger");
            }
        }

        protected void BtnCancelNew_Click(object sender, EventArgs e)
        {
            MenuControl<Panel>("pnlAddItem").Visible = false;
            SelectedField.Value = "";
            pnlSelectedItem.Visible = false;
            ClearMessage();
        }

        // ============================================================
        // OPEN MANAGE RECIPE
        // ============================================================

        protected void BtnManageRecipe_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Please select a menu item first.", "warning");
                return;
            }
            try
            {
                OpenRecipeEditor(SelectedMenuItemID.Value, false);
            }
            catch (Exception)
            {
                ShowMessage("Unable to load ingredients. Check the database connection.", "danger");
            }
        }

        protected void BtnSaveRecipeIngredient_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Select a menu item before adding recipe ingredients.", "warning");
                return;
            }

            DropDownList ingredient = MenuControl<DropDownList>("ddlRecipeIngredient");
            TextBox quantityText = MenuControl<TextBox>("txtRecipeQuantity");
            int ingredientID;
            decimal quantity;
            if (!int.TryParse(ingredient.SelectedValue, out ingredientID) || ingredientID <= 0 ||
                !decimal.TryParse(quantityText.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out quantity) || quantity <= 0)
            {
                ShowMessage("Select an ingredient and enter a quantity greater than zero.", "warning");
                return;
            }

            try
            {
                // RecipeTable stores the ingredient quantity required for one menu item.
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
IF EXISTS (SELECT 1 FROM RecipeTable WHERE MenuItemID = @MenuItemID AND IngredientID = @IngredientID)
    UPDATE RecipeTable SET QuantityNeeded = @QuantityNeeded
    WHERE MenuItemID = @MenuItemID AND IngredientID = @IngredientID;
ELSE
    INSERT INTO RecipeTable (MenuItemID, IngredientID, QuantityNeeded)
    VALUES (@MenuItemID, @IngredientID, @QuantityNeeded);";
                    command.Parameters.Add("@MenuItemID", SqlDbType.Int).Value = SelectedMenuItemID.Value;
                    command.Parameters.Add("@IngredientID", SqlDbType.Int).Value = ingredientID;
                    SqlParameter quantityParameter = command.Parameters.Add("@QuantityNeeded", SqlDbType.Decimal);
                    quantityParameter.Precision = 18;
                    quantityParameter.Scale = 3;
                    quantityParameter.Value = quantity;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                quantityText.Text = "";
                ingredient.SelectedIndex = 0;
                LoadSelectedItem(SelectedMenuItemID.Value);
                // Keep the recipe editor open so the manager can add multiple ingredients.
                MenuControl<Panel>("pnlViewItem").Visible = false;
                MenuControl<Panel>("pnlManageRecipe").Visible = true;
                pnlSelectedItem.Visible = true;
                ShowMessage("Ingredient added to the recipe. Add another ingredient or finish the recipe.", "success");
            }
            catch (Exception)
            {
                ShowMessage("Unable to save this recipe ingredient. Verify the RecipeTable column names and database connection.", "danger");
            }
        }

        protected void BtnFinishRecipe_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Select a menu item first.", "warning");
                return;
            }

            if (PendingMenuItemID.HasValue)
            {
                CompletePendingMenuItem();
                return;
            }

            if (!HasRecipe(SelectedMenuItemID.Value))
            {
                ShowMessage("This menu item still has no ingredients. Add at least one ingredient before finishing.", "warning");
                return;
            }

            MenuControl<Panel>("pnlManageRecipe").Visible = false;
            MenuControl<Panel>("pnlViewItem").Visible = true;
            LoadSelectedItem(SelectedMenuItemID.Value);
            ShowMessage("Recipe saved successfully.", "success");
        }

        protected void BtnCancelRecipe_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue)
            {
                try
                {
                    DeletePendingMenuItem();
                    SelectedMenuItemID = null;
                    MenuControl<Panel>("pnlManageRecipe").Visible = false;
                    pnlSelectedItem.Visible = false;
                    LoadMenu();
                    ShowMessage("The menu item was removed because its recipe was cancelled.", "warning");
                }
                catch (Exception)
                {
                    ShowMessage("The pending menu item could not be removed. Please try again.", "danger");
                }
                return;
            }

            MenuControl<Panel>("pnlManageRecipe").Visible = false;
            SetEditMode(false);
            pnlSelectedItem.Visible = true;
            ClearMessage();
        }

        protected void BtnEditSelected_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Please select a menu item first.", "warning");
                return;
            }
            try
            {
                int id = SelectedMenuItemID.Value;
                MenuItemDetails item = menuService.GetMenuItemByID(id);
                if (item == null) { ShowMessage("Menu item could not be found.", "warning"); return; }
                txtEditName.Text = item.MenuItemName;
                txtEditPrice.Text = item.SellingPrice.ToString("0.00", CultureInfo.InvariantCulture);
                txtEditCost.Text = item.CostToMake.ToString("0.00", CultureInfo.InvariantCulture);
                txtEditCategory.Text = item.Category;
                txtEditPreparation.Text = item.PreparationTime.ToString();
                SetEditMode(true);
                ClearMessage();
            }
            catch (Exception) { ShowMessage("Unable to open this item for editing.", "danger"); }
        }

        protected void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Please select a menu item first.", "warning");
                return;
            }
            decimal price, cost;
            int prep;
            if (string.IsNullOrWhiteSpace(txtEditName.Text) || string.IsNullOrWhiteSpace(txtEditCategory.Text) ||
            !decimal.TryParse(txtEditPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ||
            !decimal.TryParse(txtEditCost.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out cost) ||
            !int.TryParse(txtEditPreparation.Text, out prep) || price <= 0 || cost <= 0 || prep < 1 || prep > 999 ||
            !Regex.IsMatch((txtEditName.Text ?? "").Trim(), @"^[\p{L} ]+$"))
            {
                ShowMessage("Enter valid item details. Use a dot for decimal prices, for example 49.99.", "warning");
                return;
            }
            try
            {
                int id = SelectedMenuItemID.Value;
                if (IsDuplicateMenuItemName(txtEditName.Text.Trim(), id))
                {
                    ShowMessage("Another menu item with this name already exists. Please use a different name.", "warning");
                    return;
                }
                if (!HasRecipe(id))
                {
                    ShowMessage("This menu item has no recipe. Add at least one ingredient before updating it.", "warning");
                    OpenRecipeEditor(id, false);
                    return;
                }
                string result = menuService.UpdateMenuItem(id, txtEditName.Text.Trim(), price,
                cost, txtEditCategory.Text.Trim(), prep);
                if (!string.IsNullOrWhiteSpace(result)) { ShowMessage(result, "warning"); return; }
                SetEditMode(false);
                LoadCategoryFilter();
                // Show the updated record even if the category or name changed.
                txtSearch.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlStatus.SelectedIndex = 0;
                List<MenuItemDetails> refreshed = menuService.GetMenuItems();
                int index = refreshed.FindIndex(x => x.MenuItemID == id);
                CurrentMenuPage = index < 0 ? 0 : index / PageSize;
                SelectedMenuItemID = id;
                LoadMenu();
                ShowMessage("Menu item updated successfully.", "success");
            }
            catch (Exception) { ShowMessage("Unable to update the menu item. Check the SQL connection.", "danger"); }
        }

        protected void BtnCancelEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            ClearMessage();
        }

        protected void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (!SelectedMenuItemID.HasValue)
            {
                ShowMessage("Please select a menu item first.", "warning");
                return;
            }
            try
            {
                int id = SelectedMenuItemID.Value;
                // MenuService checks references in both order item tables.
                string result = menuService.DeleteMenuItem(id);
                if (!string.IsNullOrWhiteSpace(result)) { ShowMessage(result, "warning"); return; }
                SelectedMenuItemID = null;
                SetEditMode(false);
                LoadCategoryFilter();
                LoadMenu();
                ShowMessage("Menu item deleted successfully.", "success");
            }
            catch (Exception) { ShowMessage("Unable to delete the menu item. It may still be referenced.", "danger"); }
        }

        public string GetStatusCssClass(string status)
        {
            if (string.Equals(status, "Available", StringComparison.OrdinalIgnoreCase))
                return "manager-menu-status status-available";
            if (string.Equals(status, "Low Stock", StringComparison.OrdinalIgnoreCase))
                return "manager-menu-status status-low-stock";
            return "manager-menu-status status-unavailable";
        }

        public string GetCategoryEmoji(string category)
        {
            string value = (category ?? "").ToLowerInvariant();
            if (value.Contains("drink")) return "🥤";
            if (value.Contains("beverage") || value.Contains("coffee")) return "☕";
            if (value.Contains("burger")) return "🍔";
            if (value.Contains("wing")) return "🍗";
            if (value.Contains("side")) return "🍟";
            if (value.Contains("combo")) return "🍱";
            return "🍽";
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            if (PendingMenuItemID.HasValue)
            {
                try { DeletePendingMenuItem(); } catch { }
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }
    }
}