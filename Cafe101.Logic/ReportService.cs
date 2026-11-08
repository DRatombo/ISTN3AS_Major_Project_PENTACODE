using Cafe101.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class ReportService
    {
        // ============================================================
        // HELPERS
        // ============================================================

        // One place for the date-range logic. {COL} is replaced with the date column.
        private static string DateFilter(string col)
        {
            return @"(
                @DateRange = 'AllTime'
                OR (@DateRange = 'Today' AND {COL} >= CAST(GETDATE() AS DATE) AND {COL} < DATEADD(DAY, 1, CAST(GETDATE() AS DATE)))
                OR (@DateRange = 'Yesterday' AND {COL} >= DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AND {COL} < CAST(GETDATE() AS DATE))
                OR (@DateRange = 'Last7Days' AND {COL} >= DATEADD(DAY, -7, GETDATE()) AND {COL} <= GETDATE())
                OR (@DateRange = 'Last30Days' AND {COL} >= DATEADD(DAY, -30, GETDATE()) AND {COL} <= GETDATE())
                OR (@DateRange = 'ThisMonth' AND {COL} >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND {COL} < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0))
                OR (@DateRange = 'PreviousMonth' AND {COL} >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0) AND {COL} < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
            )".Replace("{COL}", col);
        }

        // Runs a query that returns a label column and a number column.
        private ChartData RunChartQuery(string sql, string dateRange, string labelColumn, string valueColumn)
        {
            ChartData result = new ChartData();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@DateRange", SqlDbType.VarChar, 20).Value = dateRange;

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Labels.Add(reader[labelColumn].ToString());
                        result.Values.Add(Convert.ToDecimal(reader[valueColumn]));
                    }
                }
            }

            return result;
        }

        private static double? PercentChange(decimal before, decimal now)
        {
            if (before == 0) return null;
            return (double)Math.Round((now - before) / before * 100, 1);
        }

        // ============================================================
        // ALL-TIME SUMMARY
        // ============================================================
        public ReportSummary GetAllTimeSummary()
        {
            return GetSummaryByDateRange("AllTime");
        }

        // ============================================================
        // SUMMARY CARDS BY DATE RANGE
        // ============================================================
        public ReportSummary GetSummaryByDateRange(string dateRange)
        {
            ReportSummary summary = new ReportSummary();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        COUNT(*) AS CompletedOrders,
                        ISNULL(SUM(TotalAmountDue), 0) AS TotalRevenue,
                        ISNULL(AVG(TotalAmountDue), 0) AS AverageOrderValue
                    FROM OrderTable
                    WHERE OrderStatus = 'Completed'
                    AND " + DateFilter("OrderDateTime") + ";";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@DateRange", SqlDbType.VarChar, 20).Value = dateRange;

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            summary.CompletedOrders = Convert.ToInt32(reader["CompletedOrders"]);
                            summary.TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]);
                            summary.AverageOrderValue = Convert.ToDecimal(reader["AverageOrderValue"]);
                        }
                    }
                }
            }

            return summary;
        }

        // ============================================================
        // REVENUE TREND (by month for All Time, otherwise by day)
        // ============================================================
        public ChartData GetRevenueTrend(string dateRange)
        {
            string sql;

            if (dateRange == "AllTime")
            {
                sql = @"
                    SELECT
                        FORMAT(OrderDateTime, 'MMM yyyy') AS Label,
                        SUM(TotalAmountDue) AS Value
                    FROM OrderTable
                    WHERE OrderStatus = 'Completed'
                    AND " + DateFilter("OrderDateTime") + @"
                    GROUP BY FORMAT(OrderDateTime, 'MMM yyyy'), YEAR(OrderDateTime), MONTH(OrderDateTime)
                    ORDER BY YEAR(OrderDateTime), MONTH(OrderDateTime);";
            }
            else
            {
                sql = @"
                    SELECT
                        FORMAT(MIN(CAST(OrderDateTime AS DATE)), 'dd MMM') AS Label,
                        SUM(TotalAmountDue) AS Value
                    FROM OrderTable
                    WHERE OrderStatus = 'Completed'
                    AND " + DateFilter("OrderDateTime") + @"
                    GROUP BY CAST(OrderDateTime AS DATE)
                    ORDER BY CAST(OrderDateTime AS DATE);";
            }

            return RunChartQuery(sql, dateRange, "Label", "Value");
        }

        // ============================================================
        // SALES BY CATEGORY
        // ============================================================
        public ChartData GetSalesByCategory(string dateRange)
        {
            string sql = @"
                SELECT
                    m.Category AS Label,
                    SUM(oi.Subtotal) AS Value
                FROM OrderItemTable oi
                INNER JOIN OrderTable o ON o.OrderID = oi.OrderID
                INNER JOIN MenuItemsTable m ON m.MenuItemID = oi.MenuItemID
                WHERE o.OrderStatus = 'Completed'
                AND " + DateFilter("o.OrderDateTime") + @"
                GROUP BY m.Category
                ORDER BY Value DESC;";

            return RunChartQuery(sql, dateRange, "Label", "Value");
        }

        // ============================================================
        // STAFF PERFORMANCE (completed orders per employee)
        // ============================================================
        public ChartData GetStaffPerformance(string dateRange)
        {
            string sql = @"
                SELECT
                    e.FirstName + ' ' + e.Surname AS Label,
                    COUNT(*) AS Value
                FROM OrderTable o
                INNER JOIN EmployeeTable e ON e.EmployeeID = o.EmployeeID
                WHERE o.OrderStatus = 'Completed'
                AND " + DateFilter("o.OrderDateTime") + @"
                GROUP BY e.EmployeeID, e.FirstName, e.Surname
                ORDER BY Value DESC;";

            return RunChartQuery(sql, dateRange, "Label", "Value");
        }

        // ============================================================
        // POPULAR ITEMS (top 5 by quantity sold)
        // ============================================================
        public List<PopularItem> GetPopularItems(string dateRange)
        {
            List<PopularItem> items = new List<PopularItem>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT TOP 5
                        m.MenuItemName,
                        m.Category,
                        SUM(oi.QuantityOrdered) AS QtySold
                    FROM OrderItemTable oi
                    INNER JOIN OrderTable o ON o.OrderID = oi.OrderID
                    INNER JOIN MenuItemsTable m ON m.MenuItemID = oi.MenuItemID
                    WHERE o.OrderStatus = 'Completed'
                    AND " + DateFilter("o.OrderDateTime") + @"
                    GROUP BY m.MenuItemName, m.Category
                    ORDER BY QtySold DESC;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@DateRange", SqlDbType.VarChar, 20).Value = dateRange;

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new PopularItem
                            {
                                Name = reader["MenuItemName"].ToString(),
                                Category = reader["Category"].ToString(),
                                Quantity = Convert.ToInt32(reader["QtySold"])
                            });
                        }
                    }
                }
            }

            return items;
        }

        // ============================================================
        // LOW STOCK ALERTS (live, no date range)
        // ============================================================
        public List<LowStockItem> GetLowStock()
        {
            List<LowStockItem> items = new List<LowStockItem>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT TOP 8
                        Description,
                        QuantityOnHand,
                        CASE
                            WHEN QuantityOnHand <= RestockLevel * 0.25 THEN 'Critical'
                            WHEN QuantityOnHand <= RestockLevel * 0.50 THEN 'High'
                            WHEN QuantityOnHand <= RestockLevel * 0.75 THEN 'Medium'
                            ELSE 'Low'
                        END AS Severity
                    FROM IngredientTable
                    WHERE QuantityOnHand <= RestockLevel
                    ORDER BY CAST(QuantityOnHand AS FLOAT) / NULLIF(RestockLevel, 0) ASC;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new LowStockItem
                            {
                                Name = reader["Description"].ToString(),
                                Quantity = Convert.ToDecimal(reader["QuantityOnHand"]),
                                Unit = "",
                                Level = reader["Severity"].ToString()
                            });
                        }
                    }
                }
            }

            return items;
        }

        // ============================================================
        // DASHBOARD: TOP 4 CARDS
        // ============================================================
        public DashboardCards GetDashboardCards()
        {
            DashboardCards cards = new DashboardCards();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        (SELECT COUNT(*) FROM OrderTable
                         WHERE OrderDateTime >= CAST(GETDATE() AS DATE)
                           AND OrderDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))) AS OrdersToday,

                        (SELECT COUNT(*) FROM OrderTable
                         WHERE OrderDateTime >= DATEADD(DAY, -1, CAST(GETDATE() AS DATE))
                           AND OrderDateTime < CAST(GETDATE() AS DATE)) AS OrdersYesterday,

                        ISNULL((SELECT SUM(TotalAmountDue) FROM OrderTable
                         WHERE OrderStatus = 'Completed'
                           AND OrderDateTime >= CAST(GETDATE() AS DATE)
                           AND OrderDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))), 0) AS RevenueToday,

                        ISNULL((SELECT SUM(TotalAmountDue) FROM OrderTable
                         WHERE OrderStatus = 'Completed'
                           AND OrderDateTime >= DATEADD(DAY, -1, CAST(GETDATE() AS DATE))
                           AND OrderDateTime < CAST(GETDATE() AS DATE)), 0) AS RevenueYesterday,

                        (SELECT COUNT(*) FROM OrderTable WHERE OrderStatus = 'Pending') AS PendingOrders,

                        (SELECT COUNT(*) FROM IngredientTable WHERE QuantityOnHand <= RestockLevel) AS LowStockCount;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int ordersToday = Convert.ToInt32(reader["OrdersToday"]);
                            int ordersYesterday = Convert.ToInt32(reader["OrdersYesterday"]);
                            decimal revenueToday = Convert.ToDecimal(reader["RevenueToday"]);
                            decimal revenueYesterday = Convert.ToDecimal(reader["RevenueYesterday"]);

                            cards.OrdersToday = ordersToday;
                            cards.OrdersChange = PercentChange(ordersYesterday, ordersToday);
                            cards.RevenueToday = revenueToday;
                            cards.RevenueChange = PercentChange(revenueYesterday, revenueToday);
                            cards.PendingOrders = Convert.ToInt32(reader["PendingOrders"]);
                            cards.LowStockCount = Convert.ToInt32(reader["LowStockCount"]);
                        }
                    }
                }
            }

            return cards;
        }

        // ============================================================
        // DASHBOARD: RECENT ORDERS
        // ============================================================
        public List<RecentOrder> GetRecentOrders()
        {
            List<RecentOrder> orders = new List<RecentOrder>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT TOP 5
                        o.OrderID,
                        ISNULL(c.FirstName + ' ' + LEFT(c.Surname, 1) + '.', 'Walk-in') AS CustomerName,
                        ISNULL((SELECT SUM(oi.QuantityOrdered)
                                FROM OrderItemTable oi
                                WHERE oi.OrderID = o.OrderID), 0) AS ItemCount,
                        o.TotalAmountDue,
                        o.OrderStatus,
                        o.OrderDateTime
                    FROM OrderTable o
                    LEFT JOIN CustomerTable c ON c.CustomerID = o.CustomerID
                    ORDER BY o.OrderDateTime DESC;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime when = Convert.ToDateTime(reader["OrderDateTime"]);

                            orders.Add(new RecentOrder
                            {
                                OrderID = reader["OrderID"].ToString(),
                                Customer = reader["CustomerName"].ToString(),
                                Items = Convert.ToInt32(reader["ItemCount"]),
                                Total = "R" + Convert.ToDecimal(reader["TotalAmountDue"]).ToString("N2"),
                                Status = reader["OrderStatus"].ToString(),
                                Time = when.Date == DateTime.Today
                                    ? when.ToString("HH:mm")
                                    : when.ToString("dd MMM HH:mm")
                            });
                        }
                    }
                }
            }

            return orders;
        }

        // ============================================================
        // DASHBOARD: STAFF LIST
        // ============================================================
        public List<StaffRow> GetDashboardStaff()
        {
            List<StaffRow> staff = new List<StaffRow>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT TOP 6
                        FirstName + ' ' + LEFT(Surname, 1) + '.' AS Name,
                        Role,
                        EmployeeStatus
                    FROM EmployeeTable
                    ORDER BY CASE WHEN Role = 'Manager' THEN 0 ELSE 1 END, FirstName;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staff.Add(new StaffRow
                            {
                                Name = reader["Name"].ToString(),
                                Role = reader["Role"].ToString(),
                                Status = reader["EmployeeStatus"].ToString()
                            });
                        }
                    }
                }
            }

            return staff;
        }
    }   // <-- end of ReportService class

    // ============================================================
    // MODELS
    // ============================================================

    public class ReportSummary
    {
        public int CompletedOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class ChartData
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<decimal> Values { get; set; } = new List<decimal>();
    }

    public class PopularItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }

    public class LowStockItem
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string Level { get; set; }
    }

    public class DashboardCards
    {
        public int OrdersToday { get; set; }
        public double? OrdersChange { get; set; }
        public decimal RevenueToday { get; set; }
        public double? RevenueChange { get; set; }
        public int PendingOrders { get; set; }
        public int LowStockCount { get; set; }
    }

    public class RecentOrder
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public int Items { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
    }

    public class StaffRow
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}