using System;
using System.Data.SqlClient;

namespace Cafe101
{
    public class DBConnection
    {
        private static string connectionString =
            "Data Source=146.230.177.46;Initial Catalog = GroupWst22; User ID = GroupWst22; Password=n38mc;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
