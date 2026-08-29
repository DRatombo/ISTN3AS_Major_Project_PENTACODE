using Cafe101.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class EmployeeAccountService
    {
        public EmployeeAccountDetails GetEmployeeByID(
            int employeeID)
        {
            const string query = @"
                SELECT
                    EmployeeID,
                    FirstName,
                    Surname,
                    Address,
                    Email,
                    Role
                FROM EmployeeTable
                WHERE EmployeeID = @EmployeeID";


            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@EmployeeID",
                        SqlDbType.Int)
                        .Value = employeeID;


                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }


                        return new EmployeeAccountDetails
                        {
                            EmployeeID =
                                Convert.ToInt32(
                                    reader["EmployeeID"]),

                            FirstName =
                                reader["FirstName"]
                                == DBNull.Value
                                ? ""
                                : reader["FirstName"]
                                    .ToString(),

                            Surname =
                                reader["Surname"]
                                == DBNull.Value
                                ? ""
                                : reader["Surname"]
                                    .ToString(),

                            Address =
                                reader["Address"]
                                == DBNull.Value
                                ? ""
                                : reader["Address"]
                                    .ToString(),

                            Email =
                                reader["Email"]
                                == DBNull.Value
                                ? ""
                                : reader["Email"]
                                    .ToString(),

                            Role =
                                reader["Role"]
                                == DBNull.Value
                                ? ""
                                : reader["Role"]
                                    .ToString()
                        };
                    }
                }
            }
        }
    }
}