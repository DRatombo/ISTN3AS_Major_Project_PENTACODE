using Cafe101.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class EmployeeManagementService
    {
        // ============================================================
        // GET ALL EMPLOYEES
        // ============================================================

        public List<EmployeeAccountDetails> GetAllEmployees()
        {
            List<EmployeeAccountDetails> employees =
                new List<EmployeeAccountDetails>();


            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        EmployeeID,
                        Role,
                        FirstName,
                        Surname,
                        Address,
                        Email,
                        EmployeeStatus,
                        HireDate
                    FROM EmployeeTable
                    ORDER BY FirstName, Surname;";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeAccountDetails employee =
                                new EmployeeAccountDetails
                                {
                                    EmployeeID =
                                        Convert.ToInt32(
                                            reader["EmployeeID"]),

                                    Role =
                                        reader["Role"] == DBNull.Value
                                        ? ""
                                        : reader["Role"].ToString(),

                                    FirstName =
                                        reader["FirstName"] == DBNull.Value
                                        ? ""
                                        : reader["FirstName"].ToString(),

                                    Surname =
                                        reader["Surname"] == DBNull.Value
                                        ? ""
                                        : reader["Surname"].ToString(),

                                    Address =
                                        reader["Address"] == DBNull.Value
                                        ? ""
                                        : reader["Address"].ToString(),

                                    Email =
                                        reader["Email"] == DBNull.Value
                                        ? ""
                                        : reader["Email"].ToString(),

                                    EmployeeStatus =
                                        reader["EmployeeStatus"] == DBNull.Value
                                        ? "Active"
                                        : reader["EmployeeStatus"].ToString(),

                                    HireDate =
                                        reader["HireDate"] == DBNull.Value
                                        ? (DateTime?)null
                                        : Convert.ToDateTime(
                                            reader["HireDate"])
                                };


                            employees.Add(employee);
                        }
                    }
                }
            }


            return employees;
        }


        // ============================================================
        // GET ONE EMPLOYEE
        // ============================================================

        public EmployeeAccountDetails GetEmployeeByID(
            int employeeID)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        EmployeeID,
                        Role,
                        FirstName,
                        Surname,
                        Address,
                        Email,
                        EmployeeStatus,
                        HireDate
                    FROM EmployeeTable
                    WHERE EmployeeID = @EmployeeID;";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
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

                            Role =
                                reader["Role"] == DBNull.Value
                                ? ""
                                : reader["Role"].ToString(),

                            FirstName =
                                reader["FirstName"] == DBNull.Value
                                ? ""
                                : reader["FirstName"].ToString(),

                            Surname =
                                reader["Surname"] == DBNull.Value
                                ? ""
                                : reader["Surname"].ToString(),

                            Address =
                                reader["Address"] == DBNull.Value
                                ? ""
                                : reader["Address"].ToString(),

                            Email =
                                reader["Email"] == DBNull.Value
                                ? ""
                                : reader["Email"].ToString(),

                            EmployeeStatus =
                                reader["EmployeeStatus"] == DBNull.Value
                                ? "Active"
                                : reader["EmployeeStatus"].ToString(),

                            HireDate =
                                reader["HireDate"] == DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["HireDate"])
                        };
                    }
                }
            }
        }


        // ============================================================
        // UPDATE EMPLOYEE STATUS
        // ============================================================

        public string UpdateEmployeeStatus(
            int employeeID,
            string newStatus,
            int loggedInManagerID)
        {
            if (employeeID == loggedInManagerID &&
                newStatus.Equals(
                    "Inactive",
                    StringComparison.OrdinalIgnoreCase))
            {
                return
                    "You cannot deactivate your own manager account.";
            }


            if (!newStatus.Equals(
                    "Active",
                    StringComparison.OrdinalIgnoreCase)
                &&
                !newStatus.Equals(
                    "Inactive",
                    StringComparison.OrdinalIgnoreCase))
            {
                return
                    "Invalid employee status.";
            }


            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    UPDATE EmployeeTable
                    SET EmployeeStatus = @EmployeeStatus
                    WHERE EmployeeID = @EmployeeID;";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "@EmployeeStatus",
                        SqlDbType.VarChar,
                        20)
                        .Value = newStatus;


                    command.Parameters.Add(
                        "@EmployeeID",
                        SqlDbType.Int)
                        .Value = employeeID;


                    connection.Open();


                    int affectedRows =
                        command.ExecuteNonQuery();


                    if (affectedRows == 0)
                    {
                        return
                            "The selected employee could not be found.";
                    }
                }
            }


            return "";
        }
    }
}