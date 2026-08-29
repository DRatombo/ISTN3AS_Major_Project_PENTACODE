using Cafe101.Data;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Cafe101.Logic
{
    public class CustomerProfileService
    {
        // ============================================================
        // GET CUSTOMER PROFILE
        // ============================================================

        public CustomerProfile GetCustomerProfile(int customerID)
        {
            CustomerProfile profile =
                new CustomerProfile();

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT CustomerID,
                               FirstName,
                               Surname,
                               PhoneNumber,
                               Address,
                               Email,
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
                                profile.Success = false;
                                profile.Message =
                                    "Customer profile could not be found.";

                                return profile;
                            }

                            profile.CustomerID =
                                Convert.ToInt32(
                                    reader["CustomerID"]);

                            profile.FirstName =
                                reader["FirstName"].ToString();

                            profile.Surname =
                                reader["Surname"].ToString();

                            profile.PhoneNumber =
                                reader["PhoneNumber"].ToString();

                            profile.Email =
                                reader["Email"].ToString();

                            profile.Status =
                                reader["Status"].ToString();

                            string fullAddress =
                                reader["Address"].ToString();

                            SplitAddress(
                                fullAddress,
                                profile);

                            profile.Success = true;

                            return profile;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                profile.Success = false;
                profile.Message =
                    "Profile could not be loaded: " +
                    ex.Message;

                return profile;
            }
        }


        // ============================================================
        // UPDATE CUSTOMER PROFILE
        // ============================================================

        public CustomerProfile UpdateCustomerProfile(
            int customerID,
            string firstName,
            string surname,
            string phoneNumber,
            string streetAddress,
            string suburb,
            string city,
            string email)
        {
            CustomerProfile result =
                new CustomerProfile();

            firstName =
                (firstName ?? "").Trim();

            surname =
                (surname ?? "").Trim();

            phoneNumber =
                (phoneNumber ?? "").Trim();

            streetAddress =
                (streetAddress ?? "").Trim();

            suburb =
                (suburb ?? "").Trim();

            city =
                (city ?? "").Trim();

            email =
                (email ?? "").Trim();


            // ----------------------------
            // First name
            // ----------------------------

            if (string.IsNullOrWhiteSpace(firstName))
            {
                result.Message =
                    "First name is required.";

                return result;
            }

            if (!Regex.IsMatch(
                firstName,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "First name may only contain letters, spaces, apostrophes and hyphens.";

                return result;
            }


            // ----------------------------
            // Surname
            // ----------------------------

            if (string.IsNullOrWhiteSpace(surname))
            {
                result.Message =
                    "Surname is required.";

                return result;
            }

            if (!Regex.IsMatch(
                surname,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Surname may only contain letters, spaces, apostrophes and hyphens.";

                return result;
            }


            // ----------------------------
            // Phone
            // ----------------------------

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                result.Message =
                    "Phone number is required.";

                return result;
            }

            if (!Regex.IsMatch(
                phoneNumber,
                @"^0[6-8]\d{8}$"))
            {
                result.Message =
                    "Enter a valid 10-digit South African mobile number starting with 06, 07 or 08.";

                return result;
            }


            // ----------------------------
            // Address
            // ----------------------------

            if (string.IsNullOrWhiteSpace(streetAddress))
            {
                result.Message =
                    "Street address is required.";

                return result;
            }

            if (!Regex.IsMatch(
                streetAddress,
                @"^[A-Za-z0-9\s,'./#-]+$"))
            {
                result.Message =
                    "Street address contains invalid characters.";

                return result;
            }


            if (string.IsNullOrWhiteSpace(suburb))
            {
                result.Message =
                    "Suburb is required.";

                return result;
            }

            if (!Regex.IsMatch(
                suburb,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Suburb may only contain letters, spaces, apostrophes and hyphens.";

                return result;
            }


            if (string.IsNullOrWhiteSpace(city))
            {
                result.Message =
                    "City is required.";

                return result;
            }

            if (!Regex.IsMatch(
                city,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "City may only contain letters, spaces, apostrophes and hyphens.";

                return result;
            }


            // ----------------------------
            // Email
            // ----------------------------

            if (string.IsNullOrWhiteSpace(email))
            {
                result.Message =
                    "Email address is required.";

                return result;
            }

            if (!Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                result.Message =
                    "Please enter a valid email address.";

                return result;
            }


            try
            {
                if (EmailUsedByAnotherCustomer(
                    customerID,
                    email))
                {
                    result.Message =
                        "Another customer account already uses this email address.";

                    return result;
                }

                if (PhoneUsedByAnotherCustomer(
                    customerID,
                    phoneNumber))
                {
                    result.Message =
                        "Another customer account already uses this phone number.";

                    return result;
                }


                string fullAddress =
                    streetAddress + ", " +
                    suburb + ", " +
                    city;


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
                            fullAddress);

                        command.Parameters.AddWithValue(
                            "@Email",
                            email);

                        command.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        connection.Open();

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            result.Message =
                                "Customer profile could not be updated.";

                            return result;
                        }
                    }
                }


                result.Success = true;
                result.CustomerID = customerID;
                result.FirstName = firstName;
                result.Surname = surname;
                result.PhoneNumber = phoneNumber;
                result.StreetAddress = streetAddress;
                result.Suburb = suburb;
                result.City = city;
                result.Email = email;

                result.Message =
                    "Profile updated successfully.";

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message =
                    "Profile could not be updated: " +
                    ex.Message;

                return result;
            }
        }


        // ============================================================
        // DUPLICATE EMAIL
        // ============================================================

        private bool EmailUsedByAnotherCustomer(
            int customerID,
            string email)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM CustomerTable
                    WHERE LOWER(Email) = LOWER(@Email)
                    AND CustomerID <> @CustomerID";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@Email",
                        email);

                    command.Parameters.AddWithValue(
                        "@CustomerID",
                        customerID);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        // ============================================================
        // DUPLICATE PHONE
        // ============================================================

        private bool PhoneUsedByAnotherCustomer(
            int customerID,
            string phoneNumber)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM CustomerTable
                    WHERE PhoneNumber = @PhoneNumber
                    AND CustomerID <> @CustomerID";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@PhoneNumber",
                        phoneNumber);

                    command.Parameters.AddWithValue(
                        "@CustomerID",
                        customerID);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        // ============================================================
        // ADDRESS SPLIT
        // ============================================================

        private void SplitAddress(
            string fullAddress,
            CustomerProfile profile)
        {
            if (string.IsNullOrWhiteSpace(fullAddress))
            {
                profile.StreetAddress = "";
                profile.Suburb = "";
                profile.City = "";

                return;
            }

            string[] parts =
                fullAddress.Split(
                    new char[] { ',' },
                    3);

            profile.StreetAddress =
                parts.Length > 0
                ? parts[0].Trim()
                : "";

            profile.Suburb =
                parts.Length > 1
                ? parts[1].Trim()
                : "";

            profile.City =
                parts.Length > 2
                ? parts[2].Trim()
                : "";
        }
    }
}