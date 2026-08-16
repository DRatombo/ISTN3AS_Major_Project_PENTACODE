using System;
using System.Data.SqlClient;
using Cafe101.Data;

namespace Cafe101.Logic
{
    public static class DatabaseTestService
    {
        public static bool TestConnection()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                return connection.State == System.Data.ConnectionState.Open;
            }
        }
    }
}