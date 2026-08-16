using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Cafe101.Data
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["Cafe101Db"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}