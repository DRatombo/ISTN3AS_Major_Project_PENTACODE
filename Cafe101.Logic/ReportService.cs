
using Cafe101.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class ReportService
    {
        // ============================================================
        // GET ALL-TIME SALES SUMMARY
        // ============================================================

        public ReportSummary GetAllTimeSummary()
        {
            ReportSummary summary = new ReportSummary();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        COUNT(*) AS CompletedOrders,
                        ISNULL(SUM(TotalAmountDue), 0) AS TotalRevenue,
                        ISNULL(AVG(TotalAmountDue), 0) AS AverageOrderValue
                    FROM OrderTable
                    WHERE OrderStatus = 'Completed';";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            summary.CompletedOrders =
                                Convert.ToInt32(reader["CompletedOrders"]);

                            summary.TotalRevenue =
                                Convert.ToDecimal(reader["TotalRevenue"]);

                            summary.AverageOrderValue =
                                Convert.ToDecimal(reader["AverageOrderValue"]);
                        }
                    }
                }
            }

            return summary;
        }

        // ============================================================
        // GET SALES SUMMARY BY DATE RANGE
        // ============================================================

        public ReportSummary GetSummaryByDateRange(string dateRange)
        {
            ReportSummary summary = new ReportSummary();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        COUNT(*) AS CompletedOrders,
                        ISNULL(SUM(TotalAmountDue), 0) AS TotalRevenue,
                        ISNULL(AVG(TotalAmountDue), 0) AS AverageOrderValue
                    FROM OrderTable
                    WHERE OrderStatus = 'Completed'
                    AND
                    (
                        @DateRange = 'AllTime'

                        OR (@DateRange = 'Today'
                            AND OrderDateTime >= CAST(GETDATE() AS DATE)
                            AND OrderDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE)))

                        OR (@DateRange = 'Yesterday'
                            AND OrderDateTime >= DATEADD(DAY, -1, CAST(GETDATE() AS DATE))
                            AND OrderDateTime < CAST(GETDATE() AS DATE))

                        OR (@DateRange = 'Last7Days'
                            AND OrderDateTime >= DATEADD(DAY, -7, GETDATE())
                            AND OrderDateTime <= GETDATE())

                        OR (@DateRange = 'Last30Days'
                            AND OrderDateTime >= DATEADD(DAY, -30, GETDATE())
                            AND OrderDateTime <= GETDATE())

                        OR (@DateRange = 'ThisMonth'
                            AND OrderDateTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)
                            AND OrderDateTime < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0))

                        OR (@DateRange = 'PreviousMonth'
                            AND OrderDateTime >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
                            AND OrderDateTime < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
                    );";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "@DateRange", SqlDbType.VarChar, 20
                    ).Value = dateRange;

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            summary.CompletedOrders =
                                Convert.ToInt32(reader["CompletedOrders"]);

                            summary.TotalRevenue =
                                Convert.ToDecimal(reader["TotalRevenue"]);

                            summary.AverageOrderValue =
                                Convert.ToDecimal(reader["AverageOrderValue"]);
                        }
                    }
                }
            }

            return summary;
        }

    }

    // ============================================================
    // REPORT SUMMARY MODEL
    // ============================================================

    public class ReportSummary
    {
        public int CompletedOrders { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal AverageOrderValue { get; set; }
    }
}
