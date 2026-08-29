using Cafe101.Data;
using System;
using System.Data.SqlClient;

namespace Cafe101.Logic
{
    public class CustomerAccountService
    {
        // ============================================================
        // GET CUSTOMER DETAILS
        // ============================================================

        public CustomerAccountDetails GetCustomerByID(
            int customerID)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT CustomerID,
                           FirstName,
                           Surname,
                           Address,
                           Email,
                           PhoneNumber,
                           Status
                    FROM CustomerTable
                    WHERE CustomerID = @CustomerID";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@CustomerID",
                        customerID);


                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }


                        CustomerAccountDetails customer =
                            new CustomerAccountDetails();


                        customer.CustomerID =
                            Convert.ToInt32(
                                reader["CustomerID"]);


                        customer.FirstName =
                            reader["FirstName"]
                            .ToString();


                        customer.Surname =
                            reader["Surname"]
                            .ToString();


                        customer.Address =
                            reader["Address"]
                            .ToString();


                        customer.Email =
                            reader["Email"]
                            .ToString();


                        customer.PhoneNumber =
                            reader["PhoneNumber"]
                            .ToString();


                        customer.Status =
                            reader["Status"]
                            .ToString();


                        return customer;
                    }
                }
            }
        }



        // ============================================================
        // UPDATE CUSTOMER DETAILS
        // ============================================================

        public bool UpdateCustomer(
            int customerID,
            string firstName,
            string surname,
            string phoneNumber,
            string address,
            string email)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    UPDATE CustomerTable

                    SET FirstName = @FirstName,
                        Surname = @Surname,
                        PhoneNumber = @PhoneNumber,
                        Address = @Address,
                        Email = @Email

                    WHERE CustomerID = @CustomerID";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@FirstName",
                        firstName);


                    command.Parameters.AddWithValue(
                        "@Surname",
                        surname);


                    command.Parameters.AddWithValue(
                        "@PhoneNumber",
                        phoneNumber);


                    command.Parameters.AddWithValue(
                        "@Address",
                        address);


                    command.Parameters.AddWithValue(
                        "@Email",
                        email);


                    command.Parameters.AddWithValue(
                        "@CustomerID",
                        customerID);


                    connection.Open();


                    int rowsAffected =
                        command.ExecuteNonQuery();


                    return rowsAffected > 0;
                }
            }
        }
    }
}