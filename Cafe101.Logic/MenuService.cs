using Cafe101.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class MenuService
    {
        // ============================================================
        // GET ALL MENU ITEMS
        // ============================================================

        public List<MenuItemDetails> GetMenuItems()
        {
            List<MenuItemDetails> menuItems =
                new List<MenuItemDetails>();


            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        m.MenuItemID,
                        m.MenuItemName,
                        m.SellingPrice,
                        m.CostToMake,
                        m.Category,
                        m.PreparationTime,

                        ISNULL
                        (
                            (
                                SELECT MIN
                                (
                                    CAST
                                    (
                                        i.QuantityOnHand /
                                        NULLIF(r.QuantityNeeded, 0)
                                        AS INT
                                    )
                                )
                                FROM RecipeTable r
                                INNER JOIN IngredientTable i
                                    ON r.IngredientID =
                                       i.IngredientID
                                WHERE r.MenuItemID =
                                      m.MenuItemID
                            ),
                            0
                        ) AS AvailableQuantity,

                        CASE

                            WHEN NOT EXISTS
                            (
                                SELECT 1
                                FROM RecipeTable r
                                WHERE r.MenuItemID =
                                      m.MenuItemID
                            )
                            THEN 'Unavailable'

                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM RecipeTable r
                                INNER JOIN IngredientTable i
                                    ON r.IngredientID =
                                       i.IngredientID
                                WHERE r.MenuItemID =
                                      m.MenuItemID
                                  AND i.QuantityOnHand <
                                      r.QuantityNeeded
                            )
                            THEN 'Unavailable'

                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM RecipeTable r
                                INNER JOIN IngredientTable i
                                    ON r.IngredientID =
                                       i.IngredientID
                                WHERE r.MenuItemID =
                                      m.MenuItemID
                                  AND i.QuantityOnHand <=
                                      i.RestockLevel
                            )
                            THEN 'Low Stock'

                            ELSE 'Available'

                        END AS StockStatus,

                        ISNULL
                        (
                            (
                                SELECT SUM(oi.QuantityOrdered)
                                FROM OrderItemTable oi
                                WHERE oi.MenuItemID =
                                      m.MenuItemID
                            ),
                            0
                        ) AS QuantitySold

                    FROM MenuItemsTable m

                    ORDER BY
                        m.MenuItemName;";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItemDetails item =
                                new MenuItemDetails
                                {
                                    MenuItemID =
                                        Convert.ToInt32(
                                            reader["MenuItemID"]),

                                    MenuItemName =
                                        reader["MenuItemName"]
                                        .ToString(),

                                    SellingPrice =
                                        Convert.ToDecimal(
                                            reader["SellingPrice"]),

                                    CostToMake =
                                        Convert.ToDecimal(
                                            reader["CostToMake"]),

                                    Category =
                                        reader["Category"]
                                        .ToString(),

                                    PreparationTime =
                                        Convert.ToInt32(
                                            reader["PreparationTime"]),

                                    AvailableQuantity =
                                        Convert.ToInt32(
                                            reader["AvailableQuantity"]),

                                    StockStatus =
                                        reader["StockStatus"]
                                        .ToString(),

                                    QuantitySold =
                                        Convert.ToInt32(
                                            reader["QuantitySold"])
                                };


                            menuItems.Add(item);
                        }
                    }
                }
            }


            return menuItems;
        }


        // ============================================================
        // GET ONE MENU ITEM
        // ============================================================

        public MenuItemDetails GetMenuItemByID(
            int menuItemID)
        {
            List<MenuItemDetails> items =
                GetMenuItems();


            return items.Find(
                item =>
                    item.MenuItemID ==
                    menuItemID);
        }


        // ============================================================
        // GET CATEGORIES
        // ============================================================

        public List<string> GetCategories()
        {
            List<string> categories =
                new List<string>();


            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT DISTINCT Category
                    FROM MenuItemsTable
                    WHERE Category IS NOT NULL
                      AND LTRIM(RTRIM(Category)) <> ''
                    ORDER BY Category;";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(
                                reader["Category"]
                                .ToString());
                        }
                    }
                }
            }


            return categories;
        }


        // ============================================================
        // UPDATE MENU ITEM
        // ============================================================

        public string UpdateMenuItem(
            int menuItemID,
            string itemName,
            decimal sellingPrice,
            decimal costToMake,
            string category,
            int preparationTime)
        {
            if (menuItemID <= 0 ||
                string.IsNullOrWhiteSpace(itemName) ||
                string.IsNullOrWhiteSpace(category))
            {
                return "Please enter valid menu item details.";
            }

            if (sellingPrice <= 0 || costToMake < 0 || preparationTime < 0)
            {
                return "Please enter valid prices and preparation time.";
            }

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    UPDATE MenuItemsTable
                    SET MenuItemName = @MenuItemName,
                        SellingPrice = @SellingPrice,
                        CostToMake = @CostToMake,
                        Category = @Category,
                        PreparationTime = @PreparationTime
                    WHERE MenuItemID = @MenuItemID;";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MenuItemID", menuItemID);
                    command.Parameters.AddWithValue("@MenuItemName", itemName.Trim());
                    command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                    command.Parameters.AddWithValue("@CostToMake", costToMake);
                    command.Parameters.AddWithValue("@Category", category.Trim());
                    command.Parameters.AddWithValue("@PreparationTime", preparationTime);

                    connection.Open();

                    int rows = command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        return "Menu item could not be found.";
                    }
                }
            }

            return "";
        }


        // ============================================================
        // DELETE MENU ITEM
        //
        // Will only delete an item that has never been used
        // in an order.
        // ============================================================

        public string DeleteMenuItem(
            int menuItemID)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();


                using (SqlTransaction transaction =
                    connection.BeginTransaction())
                {
                    try
                    {
                        string checkSql = @"
                         SELECT
                         (SELECT COUNT(*)
                         FROM OrderItemTable
                            WHERE MenuItemID = @MenuItemID)
                          +
                          (SELECT COUNT(*)
                         FROM ItemOrder
                          WHERE MenuItemID = @MenuItemID);";


                        using (SqlCommand checkCommand =
                            new SqlCommand(
                                checkSql,
                                connection,
                                transaction))
                        {
                            checkCommand.Parameters.Add(
                                "@MenuItemID",
                                SqlDbType.Int)
                                .Value =
                                menuItemID;


                            int usedInOrders =
                                Convert.ToInt32(
                                    checkCommand
                                    .ExecuteScalar());


                            if (usedInOrders > 0)
                            {
                                transaction.Rollback();

                                return
                                    "This menu item cannot be deleted because it already appears in customer orders.";
                            }
                        }


                        string deleteRecipeSql = @"
                            DELETE FROM RecipeTable
                            WHERE MenuItemID =
                                  @MenuItemID;";


                        using (SqlCommand recipeCommand =
                            new SqlCommand(
                                deleteRecipeSql,
                                connection,
                                transaction))
                        {
                            recipeCommand.Parameters.Add(
                                "@MenuItemID",
                                SqlDbType.Int)
                                .Value =
                                menuItemID;


                            recipeCommand.ExecuteNonQuery();
                        }


                        string deleteMenuSql = @"
                            DELETE FROM MenuItemsTable
                            WHERE MenuItemID =
                                  @MenuItemID;";


                        using (SqlCommand menuCommand =
                            new SqlCommand(
                                deleteMenuSql,
                                connection,
                                transaction))
                        {
                            menuCommand.Parameters.Add(
                                "@MenuItemID",
                                SqlDbType.Int)
                                .Value =
                                menuItemID;


                            int affectedRows =
                                menuCommand
                                .ExecuteNonQuery();


                            if (affectedRows == 0)
                            {
                                transaction.Rollback();

                                return
                                    "The selected menu item could not be found.";
                            }
                        }


                        transaction.Commit();

                        return "";
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        // ============================================================
        // ADD NEW MENU ITEM
        // ============================================================

        public string AddMenuItem(
            string itemName,
            decimal sellingPrice,
            decimal costToMake,
            string category,
            int preparationTime,
            out int newMenuItemID)
        {
            newMenuItemID = 0;

            if (string.IsNullOrWhiteSpace(itemName) ||
                string.IsNullOrWhiteSpace(category) ||
                sellingPrice <= 0 ||
                costToMake < 0 ||
                preparationTime < 0)
            {
                return "Please enter valid menu item details.";
            }

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
            INSERT INTO MenuItemsTable
            (
                MenuItemName,
                SellingPrice,
                CostToMake,
                Category,
                PreparationTime
            )
            OUTPUT INSERTED.MenuItemID
            VALUES
            (
                @MenuItemName,
                @SellingPrice,
                @CostToMake,
                @Category,
                @PreparationTime
            );";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@MenuItemName", itemName.Trim());

                    command.Parameters.AddWithValue(
                        "@SellingPrice", sellingPrice);

                    command.Parameters.AddWithValue(
                        "@CostToMake", costToMake);

                    command.Parameters.AddWithValue(
                        "@Category", category.Trim());

                    command.Parameters.AddWithValue(
                        "@PreparationTime", preparationTime);

                    connection.Open();

                    newMenuItemID = Convert.ToInt32(
                        command.ExecuteScalar());

                    return "";
                }
            }
        }
        // ============================================================
        // GET INGREDIENTS FOR A MENU ITEM
        // ============================================================

        public DataTable GetRecipeIngredients(int menuItemID)
        {
            DataTable ingredients = new DataTable();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
            SELECT
                r.IngredientID,
                i.Description AS IngredientName,
                r.QuantityNeeded,
                i.QuantityOnHand
            FROM RecipeTable r
            INNER JOIN IngredientTable i
                ON r.IngredientID = i.IngredientID
            WHERE r.MenuItemID = @MenuItemID
            ORDER BY i.Description;";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "@MenuItemID", SqlDbType.Int).Value =
                        menuItemID;

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(ingredients);
                    }
                }
            }

            return ingredients;
        }
        // ============================================================
        // GET ALL INGREDIENTS
        // ============================================================

        public DataTable GetAllIngredients()
        {
            DataTable ingredients = new DataTable();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
            SELECT
                IngredientID,
                Description,
                QuantityOnHand
            FROM IngredientTable
            ORDER BY Description;";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(ingredients);
                    }
                }
            }

            return ingredients;
        }
    }

}