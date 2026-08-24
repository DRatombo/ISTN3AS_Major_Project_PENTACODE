using Cafe101.Data;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Cafe101.Logic
{
    public class EmployeeProfileService
    {
        // ============================================================
        // GET EMPLOYEE PROFILE
        // ============================================================

        public EmployeeProfile GetEmployeeProfile(
            int employeeID)
        {
            EmployeeProfile profile =
                new EmployeeProfile();

            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT EmployeeID,
                               FirstName,
                               Surname,
                               Email,
                               PhoneNumber,
                               Address,
                               Role,
                               Status
                        FROM EmployeeTable
                        WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command =
                        new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@EmployeeID",
                            employeeID);

                        connection.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                profile.Success = false;

                                profile.Message =
                                    "Employee profile could not be found.";

                                return profile;
                            }


                            profile.EmployeeID =
                                Convert.ToInt32(
                                    reader["EmployeeID"]);

                            profile.FirstName =
                                reader["FirstName"]
                                .ToString();

                            profile.Surname =
                                reader["Surname"]
                                .ToString();

                            profile.Email =
                                reader["Email"]
                                .ToString();

                            profile.PhoneNumber =
                                reader["PhoneNumber"]
                                .ToString();

                            profile.Address =
                                reader["Address"]
                                .ToString();

                            profile.Role =
                                reader["Role"]
                                .ToString();

                            profile.Status =
                                reader["Status"]
                                .ToString();

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
                    "Employee profile could not be loaded: " +
                    ex.Message;

                return profile;
            }
        }


        // ============================================================
        // UPDATE EMPLOYEE PROFILE
        // ============================================================

        public EmployeeProfile UpdateEmployeeProfile(
            int employeeID,
            string firstName,
            string surname,
            string phoneNumber,
            string address,
            string email)
        {
            EmployeeProfile result =
                new EmployeeProfile();

            firstName =
                (firstName ?? "").Trim();

            surname =
                (surname ?? "").Trim();

            phoneNumber =
                (phoneNumber ?? "").Trim();

            address =
                (address ?? "").Trim();

            email =
                (email ?? "").Trim();


            // ----------------------------
            // First Name
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

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                if (!Regex.IsMatch(
                    phoneNumber,
                    @"^0[6-8]\d{8}$"))
                {
                    result.Message =
                        "Enter a valid 10-digit South African mobile number.";

                    return result;
                }
            }


            // ----------------------------
            // Address
            // ----------------------------

            if (!string.IsNullOrWhiteSpace(address))
            {
                if (!Regex.IsMatch(
                    address,
                    @"^[A-Za-z0-9\s,'./#-]+$"))
                {
                    result.Message =
                        "Address contains invalid characters.";

                    return result;
                }
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
                if (EmailUsedByAnotherEmployee(
                    employeeID,
                    email))
                {
                    result.Message =
                        "Another employee already uses this email address.";

                    return result;
                }


                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        UPDATE EmployeeTable
                        SET FirstName = @FirstName,
                            Surname = @Surname,
                            PhoneNumber = @PhoneNumber,
                            Address = @Address,
                            Email = @Email
                        WHERE EmployeeID = @EmployeeID";

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
                            "@EmployeeID",
                            employeeID);

                        connection.Open();

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            result.Message =
                                "Employee profile could not be updated.";

                            return result;
                        }
                    }
                }


                result.Success = true;

                result.EmployeeID =
                    employeeID;

                result.FirstName =
                    firstName;

                result.Surname =
                    surname;

                result.PhoneNumber =
                    phoneNumber;

                result.Address =
                    address;

                result.Email =
                    email;

                result.Message =
                    "Profile updated successfully.";

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message =
                    "Employee profile could not be updated: " +
                    ex.Message;

                return result;
            }
        }


        // ============================================================
        // DUPLICATE EMAIL CHECK
        // ============================================================

        private bool EmailUsedByAnotherEmployee(
            int employeeID,
            string email)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM EmployeeTable
                    WHERE LOWER(Email) = LOWER(@Email)
                    AND EmployeeID <> @EmployeeID";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@Email",
                        email);

                    command.Parameters.AddWithValue(
                        "@EmployeeID",
                        employeeID);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }
    }
}