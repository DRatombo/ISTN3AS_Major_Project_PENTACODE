using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using global::Cafe101.Data;

namespace Cafe101.Web
{
    public partial class ManageRecipes : System.Web.UI.Page
    {
        protected string ManagerDisplayName
        {
            get
            {
                string name =
                    (Convert.ToString(Session["FirstName"]).Trim() + " " +
                     Convert.ToString(Session["Surname"]).Trim()).Trim();

                return name.Length == 0 ? "Manager" : name;
            }
        }

        protected string ManagerInitials
        {
            get
            {
                string first = Convert.ToString(Session["FirstName"]).Trim();
                string last = Convert.ToString(Session["Surname"]).Trim();

                string initials =
                    (first.Length > 0 ? first.Substring(0, 1) : "") +
                    (last.Length > 0 ? last.Substring(0, 1) : "");

                return initials.Length == 0
                    ? "M"
                    : initials.ToUpperInvariant();
            }
        }

        private bool HasSelection
        {
            get { return ViewState["RecipeMenuID"] != null; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // Protect the page before button events can run.
            if (Session["UserID"] == null ||
                !string.Equals(
                    Convert.ToString(Session["Role"]),
                    "Manager",
                    StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshPage(true);
            }
        }

        private void ShowMessage(string message, bool error)
        {
            lblRecipeMessage.Text =
                System.Web.HttpUtility.HtmlEncode(message);

            lblRecipeMessage.CssClass = error
                ? "d-block mb-3 text-danger"
                : "d-block mb-3 text-success";
        }

        private DataTable ReadTable(string sql, string search = null)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (search != null)
                {
                    command.Parameters.Add(
                        "@Search", SqlDbType.NVarChar, 202
                    ).Value = "%" + search + "%";
                }

                DataTable table = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }

                return table;
            }
        }

        private void LoadDropdowns()
        {
            // Store database IDs as values and display readable names.
            ddlRecipeMenuItem.DataSource = ReadTable(@"
                SELECT MenuItemID, MenuItemName
                FROM dbo.MenuItemsTable
                ORDER BY MenuItemName;");

            ddlRecipeMenuItem.DataValueField = "MenuItemID";
            ddlRecipeMenuItem.DataTextField = "MenuItemName";
            ddlRecipeMenuItem.DataBind();
            ddlRecipeMenuItem.Items.Insert(
                0, new ListItem("Select a menu item", ""));

            ddlRecipeIngredient.DataSource = ReadTable(@"
                SELECT IngredientID, Description
                FROM dbo.IngredientTable
                ORDER BY Description;");

            ddlRecipeIngredient.DataValueField = "IngredientID";
            ddlRecipeIngredient.DataTextField = "Description";
            ddlRecipeIngredient.DataBind();
            ddlRecipeIngredient.Items.Insert(
                0, new ListItem("Select an ingredient", ""));
        }

        private void LoadRecipes()
        {
            gvRecipes.SelectedIndex = -1;

            gvRecipes.DataSource = ReadTable(@"
                SELECT
                    r.MenuItemID,
                    r.IngredientID,
                    m.MenuItemName,
                    i.Description AS IngredientName,
                    r.QuantityNeeded
                FROM dbo.RecipeTable r
                INNER JOIN dbo.MenuItemsTable m
                    ON m.MenuItemID = r.MenuItemID
                INNER JOIN dbo.IngredientTable i
                    ON i.IngredientID = r.IngredientID
                WHERE m.MenuItemName LIKE @Search
                   OR i.Description LIKE @Search
                ORDER BY m.MenuItemName, i.Description;",
                txtRecipeSearch.Text.Trim());

            gvRecipes.DataBind();
        }

        private void ClearSelection()
        {
            ViewState.Remove("RecipeMenuID");
            ViewState.Remove("RecipeIngredientID");

            ddlRecipeMenuItem.Enabled = true;
            ddlRecipeIngredient.Enabled = true;

            if (ddlRecipeMenuItem.Items.Count > 0)
                ddlRecipeMenuItem.SelectedIndex = 0;

            if (ddlRecipeIngredient.Items.Count > 0)
                ddlRecipeIngredient.SelectedIndex = 0;

            txtRecipeQuantity.Text = "1";
            lblRecipeSelection.Text = "New recipe ingredient";

            btnAddRecipe.Enabled = true;
            btnUpdateRecipe.Enabled = false;
            btnRemoveRecipe.Enabled = false;

            gvRecipes.SelectedIndex = -1;
        }

        private void RefreshPage(bool reloadDropdowns)
        {
            lblRecipeMessage.Text = "";

            try
            {
                if (reloadDropdowns)
                    LoadDropdowns();

                ClearSelection();
                LoadRecipes();
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        private void ReportError(Exception ex)
        {
            System.Diagnostics.Trace.TraceError(
                "Recipe operation failed: {0}", ex);

            ShowMessage(
                "The recipe operation could not be completed. Please try again.",
                true);
        }

        protected void gvRecipes_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            try
            {
                int menuID = Convert.ToInt32(
                    gvRecipes.SelectedDataKey.Values["MenuItemID"]);

                int ingredientID = Convert.ToInt32(
                    gvRecipes.SelectedDataKey.Values["IngredientID"]);

                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                using (SqlCommand command = new SqlCommand(@"
                    SELECT QuantityNeeded
                    FROM dbo.RecipeTable
                    WHERE MenuItemID = @MenuID
                      AND IngredientID = @IngredientID;", connection))
                {
                    command.Parameters.Add("@MenuID", SqlDbType.Int).Value =
                        menuID;

                    command.Parameters.Add("@IngredientID", SqlDbType.Int).Value =
                        ingredientID;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException(
                                "This recipe row no longer exists.");

                        string quantity =
                            Convert.ToString(
                                reader["QuantityNeeded"],
                                System.Globalization.CultureInfo.InvariantCulture);

                        // A menu/ingredient pair must identify exactly one row.
                        if (reader.Read())
                            throw new InvalidOperationException(
                                "Duplicate recipe rows exist for this ingredient.");

                        if (ddlRecipeMenuItem.Items.FindByValue(
                                menuID.ToString()) == null ||
                            ddlRecipeIngredient.Items.FindByValue(
                                ingredientID.ToString()) == null)
                        {
                            throw new InvalidOperationException(
                                "Refresh the dropdown lists before editing.");
                        }

                        ddlRecipeMenuItem.SelectedValue = menuID.ToString();
                        ddlRecipeIngredient.SelectedValue = ingredientID.ToString();
                        txtRecipeQuantity.Text = quantity;
                    }
                }

                ViewState["RecipeMenuID"] = menuID;
                ViewState["RecipeIngredientID"] = ingredientID;

                // Update changes quantity only; the selected pair stays fixed.
                ddlRecipeMenuItem.Enabled = false;
                ddlRecipeIngredient.Enabled = false;

                btnAddRecipe.Enabled = false;
                btnUpdateRecipe.Enabled = true;
                btnRemoveRecipe.Enabled = true;

                lblRecipeSelection.Text = "Editing selected recipe ingredient";
                ShowMessage("Recipe ingredient selected.", false);
            }
            catch (InvalidOperationException ex)
            {
                ClearSelection();
                ShowMessage(ex.Message, true);
            }
            catch (Exception ex)
            {
                ClearSelection();
                ReportError(ex);
            }
        }

        private void SaveRecipe(string operation)
        {
            int menuID;
            int ingredientID;
            int quantity = 0;

            if (operation == "add")
            {
                if (HasSelection)
                {
                    ShowMessage("Clear the form before adding an ingredient.", true);
                    return;
                }

                if (!int.TryParse(ddlRecipeMenuItem.SelectedValue, out menuID) ||
                    !int.TryParse(ddlRecipeIngredient.SelectedValue, out ingredientID))
                {
                    ShowMessage("Select a menu item and ingredient.", true);
                    return;
                }
            }
            else
            {
                if (!HasSelection)
                {
                    ShowMessage("Select a recipe row first.", true);
                    return;
                }

                menuID = (int)ViewState["RecipeMenuID"];
                ingredientID = (int)ViewState["RecipeIngredientID"];
            }

            if (operation != "remove" &&
                (!int.TryParse(txtRecipeQuantity.Text, out quantity) ||
                 quantity <= 0))
            {
                ShowMessage(
                    "Quantity needed must be a whole number greater than zero.",
                    true);
                return;
            }

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction transaction =
                        connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        // Prevent duplicate pairs and changes to ambiguous rows.
                        using (SqlCommand check = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM dbo.RecipeTable WITH (UPDLOCK, HOLDLOCK)
                            WHERE MenuItemID = @MenuID
                              AND IngredientID = @IngredientID;",
                            connection, transaction))
                        {
                            check.Parameters.Add("@MenuID", SqlDbType.Int).Value =
                                menuID;

                            check.Parameters.Add(
                                "@IngredientID", SqlDbType.Int).Value = ingredientID;

                            int count = Convert.ToInt32(check.ExecuteScalar());

                            if (operation == "add" && count != 0)
                                throw new InvalidOperationException(
                                    "This ingredient is already in the recipe. Select its row to update the quantity.");

                            if (operation != "add" && count != 1)
                                throw new InvalidOperationException(
                                    "The selected recipe row is missing or duplicated. Refresh the list.");
                        }

                        string sql;

                        if (operation == "add")
                        {
                            sql = @"
                                INSERT INTO dbo.RecipeTable
                                    (MenuItemID, IngredientID,
                                     QuantityNeeded, Description)
                                VALUES
                                    (@MenuID, @IngredientID,
                                     @Quantity, @Description);";
                        }
                        else if (operation == "update")
                        {
                            sql = @"
                                UPDATE dbo.RecipeTable
                                SET QuantityNeeded = @Quantity
                                WHERE MenuItemID = @MenuID
                                  AND IngredientID = @IngredientID;";
                        }
                        else
                        {
                            sql = @"
                                DELETE FROM dbo.RecipeTable
                                WHERE MenuItemID = @MenuID
                                  AND IngredientID = @IngredientID;";
                        }

                        using (SqlCommand command =
                            new SqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.Add("@MenuID", SqlDbType.Int).Value =
                                menuID;

                            command.Parameters.Add(
                                "@IngredientID", SqlDbType.Int).Value = ingredientID;

                            if (operation != "remove")
                            {
                                command.Parameters.Add(
                                    "@Quantity", SqlDbType.Int).Value = quantity;
                            }

                            if (operation == "add")
                            {
                                // Use the ingredient's current database description.
                                using (SqlCommand descriptionCommand =
                                    new SqlCommand(@"
                                        SELECT Description
                                        FROM dbo.IngredientTable
                                        WHERE IngredientID = @IngredientID;",
                                        connection, transaction))
                                {
                                    descriptionCommand.Parameters.Add(
                                        "@IngredientID", SqlDbType.Int).Value =
                                            ingredientID;

                                    object description =
                                        descriptionCommand.ExecuteScalar();

                                    if (description == null)
                                        throw new InvalidOperationException(
                                            "This ingredient no longer exists.");

                                    command.Parameters.Add(
                                        "@Description", SqlDbType.VarChar, 50
                                    ).Value = description;
                                }
                            }

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                ShowMessage(ex.Message, true);
                return;
            }
            catch (Exception ex)
            {
                ReportError(ex);
                return;
            }

            ClearSelection();

            try
            {
                txtRecipeSearch.Text = "";
                LoadRecipes();

                ShowMessage(
                    operation == "add" ? "Ingredient added to the recipe." :
                    operation == "update" ? "Recipe quantity updated." :
                    "Ingredient removed from the recipe.",
                    false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "Recipe refresh failed after saving: {0}", ex);

                ShowMessage(
                    "The change was saved, but the list could not be refreshed.",
                    true);
            }
        }

        protected void btnAddRecipe_Click(object sender, EventArgs e)
        {
            SaveRecipe("add");
        }

        protected void btnUpdateRecipe_Click(object sender, EventArgs e)
        {
            SaveRecipe("update");
        }

        protected void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            SaveRecipe("remove");
        }

        protected void btnRecipeSearch_Click(object sender, EventArgs e)
        {
            RefreshPage(false);
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtRecipeSearch.Text = "";
            RefreshPage(false);
        }

        protected void btnRefreshRecipes_Click(object sender, EventArgs e)
        {
            RefreshPage(true);
        }

        protected void btnNewRecipe_Click(object sender, EventArgs e)
        {
            ClearSelection();
            lblRecipeMessage.Text = "";
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }
    }
}