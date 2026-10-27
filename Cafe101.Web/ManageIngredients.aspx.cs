using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using global::Cafe101.Data;

namespace Cafe101.Web
{
    public partial class ManageIngredients : System.Web.UI.Page
    {
        // Display the name saved during the current manager's sign-in.
        protected string ManagerDisplayName
        {
            get
            {
                string firstName =
                    Convert.ToString(Session["FirstName"]).Trim();

                string surname =
                    Convert.ToString(Session["Surname"]).Trim();

                string fullName = (firstName + " " + surname).Trim();

                return string.IsNullOrWhiteSpace(fullName)
                    ? "Manager"
                    : fullName;
            }
        }

        // Build the avatar initials from the signed-in manager's name.
        protected string ManagerInitials
        {
            get
            {
                string firstName =
                    Convert.ToString(Session["FirstName"]).Trim();

                string surname =
                    Convert.ToString(Session["Surname"]).Trim();

                string initials = "";

                if (firstName.Length > 0)
                {
                    initials += firstName.Substring(0, 1).ToUpperInvariant();
                }

                if (surname.Length > 0)
                {
                    initials += surname.Substring(0, 1).ToUpperInvariant();
                }

                return initials.Length == 0 ? "M" : initials;
            }
        }

        private int SelectedIngredientID
        {
            get
            {
                return ViewState["SelectedIngredientID"] == null
                    ? 0
                    : (int)ViewState["SelectedIngredientID"];
            }
            set
            {
                ViewState["SelectedIngredientID"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // Check access before any button event can run.
            bool isManager =
                Session["UserID"] != null &&
                string.Equals(
                    Convert.ToString(Session["Role"]),
                    "Manager",
                    StringComparison.OrdinalIgnoreCase);

            if (!isManager)
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
                LoadIngredients();
            }
        }

        private void ShowMessage(string message, bool isError)
        {
            lblIngredientMessage.Text =
                HttpUtility.HtmlEncode(message);

            lblIngredientMessage.CssClass = isError
                ? "d-block mb-3 text-danger"
                : "d-block mb-3 text-success";
        }

        private void ReportError(Exception ex)
        {
            System.Diagnostics.Trace.TraceError(
                "Ingredient management failed: {0}", ex);

            ShowMessage(
                "The operation could not be completed. Please try again.",
                true);
        }

        private void LoadIngredients()
        {
            // Keep database exceptions with the caller so a failed refresh
            // cannot be followed by a misleading success message.
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT IngredientID, Description,
                           QuantityOnHand, RestockLevel, CostPrice
                    FROM dbo.IngredientTable
                    WHERE Description LIKE @Search
                    ORDER BY Description;";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "@Search", SqlDbType.NVarChar, 202
                    ).Value =
                        "%" + txtIngredientSearch.Text.Trim() + "%";

                    DataTable table = new DataTable();

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }

                    gvIngredients.SelectedIndex = -1;
                    gvIngredients.DataSource = table;
                    gvIngredients.DataBind();
                }
            }
        }

        private void ClearForm()
        {
            SelectedIngredientID = 0;
            ViewState.Remove("OriginalQuantity");

            txtDescription.Text = "";
            txtQuantity.Text = "0";
            txtRestockLevel.Text = "0";
            txtCostPrice.Text = "0.00";

            lblSelectedIngredient.Text = "New ingredient";

            btnAddIngredient.Enabled = true;
            btnUpdateIngredient.Enabled = false;
            btnRemoveIngredient.Enabled = false;

            gvIngredients.SelectedIndex = -1;
        }

        private bool ReadForm(
            out string description,
            out int quantity,
            out int restock,
            out decimal cost)
        {
            description = txtDescription.Text.Trim();
            quantity = 0;
            restock = 0;
            cost = 0m;

            if (description.Length == 0 || description.Length > 50)
            {
                ShowMessage(
                    "Enter an ingredient description of 1 to 50 characters.",
                    true);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity) ||
                quantity < 0)
            {
                ShowMessage(
                    "Quantity in stock must be a whole number of zero or more.",
                    true);
                return false;
            }

            if (!int.TryParse(txtRestockLevel.Text, out restock) ||
                restock < 0)
            {
                ShowMessage(
                    "Restock level must be a whole number of zero or more.",
                    true);
                return false;
            }

            // HTML number inputs post decimals using a dot.
            if (!decimal.TryParse(
                    txtCostPrice.Text,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out cost) ||
                cost < 0m ||
                cost > 99999999.99m ||
                decimal.Round(cost, 2) != cost)
            {
                ShowMessage(
                    "Enter a cost from 0 to 99999999.99, with at most two decimal places.",
                    true);
                return false;
            }

            return true;
        }

        private void AddFormParameters(
            SqlCommand command,
            string description,
            int quantity,
            int restock,
            decimal cost)
        {
            command.Parameters.Add(
                "@Description", SqlDbType.VarChar, 50
            ).Value = description;

            command.Parameters.Add(
                "@Quantity", SqlDbType.Int
            ).Value = quantity;

            command.Parameters.Add(
                "@Restock", SqlDbType.Int
            ).Value = restock;

            SqlParameter price =
                command.Parameters.Add("@Cost", SqlDbType.Decimal);

            price.Precision = 10;
            price.Scale = 2;
            price.Value = cost;
        }

        protected void gvIngredients_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(
                    gvIngredients.SelectedDataKey.Value);

                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT IngredientID, Description,
                               QuantityOnHand, RestockLevel, CostPrice
                        FROM dbo.IngredientTable
                        WHERE IngredientID = @ID;";

                    using (SqlCommand command =
                        new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(
                            "@ID", SqlDbType.Int
                        ).Value = id;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ClearForm();
                                ShowMessage(
                                    "This ingredient no longer exists. Refresh the list.",
                                    true);
                                return;
                            }

                            SelectedIngredientID = id;

                            txtDescription.Text =
                                Convert.ToString(reader["Description"]);

                            txtQuantity.Text =
                                reader["QuantityOnHand"] == DBNull.Value
                                    ? "0"
                                    : Convert.ToInt32(
                                        reader["QuantityOnHand"]).ToString();

                            txtRestockLevel.Text =
                                reader["RestockLevel"] == DBNull.Value
                                    ? "0"
                                    : Convert.ToInt32(
                                        reader["RestockLevel"]).ToString();

                            decimal cost =
                                reader["CostPrice"] == DBNull.Value
                                    ? 0m
                                    : Convert.ToDecimal(reader["CostPrice"]);

                            txtCostPrice.Text =
                                cost.ToString(
                                    "0.00", CultureInfo.InvariantCulture);

                            // Remember the original stock, including a possible NULL.
                            ViewState["OriginalQuantity"] =
                                reader["QuantityOnHand"] == DBNull.Value
                                    ? ""
                                    : Convert.ToInt32(
                                        reader["QuantityOnHand"]).ToString(
                                            CultureInfo.InvariantCulture);
                        }
                    }
                }

                lblSelectedIngredient.Text =
                    "Editing ingredient #" + SelectedIngredientID;

                btnAddIngredient.Enabled = false;
                btnUpdateIngredient.Enabled = true;
                btnRemoveIngredient.Enabled = true;

                ShowMessage("Ingredient selected for editing.", false);
            }
            catch (Exception ex)
            {
                ClearForm();
                ReportError(ex);
            }
        }

        protected void btnAddIngredient_Click(
            object sender, EventArgs e)
        {
            if (SelectedIngredientID != 0)
            {
                ShowMessage("Clear the form before adding a new ingredient.", true);
                return;
            }

            string description;
            int quantity;
            int restock;
            decimal cost;

            if (!ReadForm(out description, out quantity, out restock, out cost))
                return;

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    // IngredientID is generated by SQL Server.
                    string sql = @"
                        INSERT INTO dbo.IngredientTable
                            (Description, QuantityOnHand, RestockLevel, CostPrice)
                        OUTPUT INSERTED.IngredientID
                        VALUES (@Description, @Quantity, @Restock, @Cost);";

                    using (SqlCommand command =
                        new SqlCommand(sql, connection))
                    {
                        AddFormParameters(
                            command, description, quantity, restock, cost);

                        connection.Open();
                        int id = Convert.ToInt32(command.ExecuteScalar());

                        ClearForm();
                        ShowMessage("Ingredient #" + id + " added.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
                return;
            }

            RefreshAfterSave();
        }

        protected void btnUpdateIngredient_Click(
            object sender, EventArgs e)
        {
            if (SelectedIngredientID == 0 ||
                ViewState["OriginalQuantity"] == null)
            {
                ShowMessage("Select an ingredient first.", true);
                return;
            }

            string description;
            int quantity;
            int restock;
            decimal cost;

            if (!ReadForm(out description, out quantity, out restock, out cost))
                return;

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    // Refuse the update if stock has changed since selection.
                    string sql = @"
                        UPDATE dbo.IngredientTable
                        SET Description = @Description,
                            QuantityOnHand = @Quantity,
                            RestockLevel = @Restock,
                            CostPrice = @Cost
                        WHERE IngredientID = @ID
                          AND (
                              QuantityOnHand = @OriginalQuantity
                              OR (QuantityOnHand IS NULL
                                  AND @OriginalQuantity IS NULL)
                          );";

                    using (SqlCommand command =
                        new SqlCommand(sql, connection))
                    {
                        AddFormParameters(
                            command, description, quantity, restock, cost);

                        command.Parameters.Add(
                            "@ID", SqlDbType.Int
                        ).Value = SelectedIngredientID;

                        string original =
                            Convert.ToString(ViewState["OriginalQuantity"]);

                        command.Parameters.Add(
                            "@OriginalQuantity", SqlDbType.Int
                        ).Value = original == ""
                            ? (object)DBNull.Value
                            : int.Parse(original, CultureInfo.InvariantCulture);

                        connection.Open();

                        if (command.ExecuteNonQuery() == 0)
                        {
                            ShowMessage(
                                "The ingredient was removed or its stock changed. Refresh and select it again before updating.",
                                true);
                            return;
                        }
                    }
                }

                ClearForm();
                ShowMessage("Ingredient updated.", false);
            }
            catch (Exception ex)
            {
                ReportError(ex);
                return;
            }

            RefreshAfterSave();
        }

        protected void btnRemoveIngredient_Click(
            object sender, EventArgs e)
        {
            if (SelectedIngredientID == 0)
            {
                ShowMessage("Select an ingredient first.", true);
                return;
            }

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Keep the recipe check and deletion in one transaction.
                    using (SqlTransaction transaction =
                        connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        string checkSql = @"
                            SELECT COUNT(*)
                            FROM dbo.RecipeTable WITH (UPDLOCK, HOLDLOCK)
                            WHERE IngredientID = @ID;";

                        using (SqlCommand check =
                            new SqlCommand(checkSql, connection, transaction))
                        {
                            check.Parameters.Add(
                                "@ID", SqlDbType.Int
                            ).Value = SelectedIngredientID;

                            if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                            {
                                transaction.Rollback();

                                ShowMessage(
                                    "This ingredient is used in a recipe and cannot be removed.",
                                    true);
                                return;
                            }
                        }

                        string deleteSql = @"
                            DELETE FROM dbo.IngredientTable
                            WHERE IngredientID = @ID;";

                        using (SqlCommand command =
                            new SqlCommand(deleteSql, connection, transaction))
                        {
                            command.Parameters.Add(
                                "@ID", SqlDbType.Int
                            ).Value = SelectedIngredientID;

                            int affected = command.ExecuteNonQuery();

                            transaction.Commit();

                            ClearForm();

                            ShowMessage(
                                affected > 0
                                    ? "Ingredient removed."
                                    : "This ingredient was already removed.",
                                affected == 0);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    ShowMessage(
                        "This ingredient is linked to other records and cannot be removed.",
                        true);
                }
                else
                {
                    ReportError(ex);
                }

                return;
            }
            catch (Exception ex)
            {
                ReportError(ex);
                return;
            }

            RefreshAfterSave();
        }

        private void RefreshAfterSave()
        {
            try
            {
                // Clear the filter so a newly added ingredient is visible.
                txtIngredientSearch.Text = "";
                LoadIngredients();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "Ingredient list refresh failed: {0}", ex);

                ShowMessage(
                    "The change was saved, but the list could not be refreshed. Click Refresh list.",
                    true);
            }
        }

        protected void btnIngredientSearch_Click(
            object sender, EventArgs e)
        {
            RefreshList();
        }

        protected void btnClearSearch_Click(
            object sender, EventArgs e)
        {
            txtIngredientSearch.Text = "";
            RefreshList();
        }

        protected void btnRefreshIngredients_Click(
            object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            ClearForm();
            lblIngredientMessage.Text = "";

            try
            {
                LoadIngredients();
            }
            catch (Exception ex)
            {
                gvIngredients.DataSource = null;
                gvIngredients.DataBind();

                ReportError(ex);
            }
        }

        protected void btnNewIngredient_Click(
            object sender, EventArgs e)
        {
            ClearForm();
            lblIngredientMessage.Text = "";
        }
    }
}