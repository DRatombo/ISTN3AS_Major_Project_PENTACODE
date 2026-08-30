using Cafe101.Data;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Cafe101.Logic
{
    public class AuthenticationService
    {
        // ============================================================
        // SIGN IN
        // ============================================================

        public LoginResult SignIn(string email, string password)
        {
            LoginResult result = new LoginResult();

            email = (email ?? "").Trim();
            password = password ?? "";

            if (string.IsNullOrWhiteSpace(email))
            {
                result.Message =
                    "Email address is required. Please enter the email address linked to your Cafe101 account.";

                return result;
            }

            if (!IsValidEmail(email))
            {
                result.Message =
                    "Invalid email address. Please enter a valid email address, for example name@email.com.";

                return result;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                result.Message =
                    "Password is required. Please enter your Cafe101 account password.";

                return result;
            }

            try
            {
                // Check employees first
                LoginResult employeeResult =
                    CheckEmployee(email, password);

                if (employeeResult.Success)
                {
                    return employeeResult;
                }

                // Then check customers
                LoginResult customerResult =
                    CheckCustomer(email, password);

                if (customerResult.Success)
                {
                    return customerResult;
                }

                result.Message =
                    "The email address or password is incorrect. Please check your details and try again.";

                return result;
            }
            catch (SqlException ex)
            {
                // Temporary while testing
                result.Message =
                    "Database error while signing in: " +
                    ex.Message;

                return result;
            }
            catch (Exception ex)
            {
                // Temporary while testing
                result.Message =
                    "Unexpected sign-in error: " +
                    ex.Message;

                return result;
            }
        }


        // ============================================================
        // EMPLOYEE LOGIN
        // ============================================================

        private LoginResult CheckEmployee(
     string email,
     string password)
        {
            LoginResult result =
                new LoginResult();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
            SELECT
                EmployeeID,
                FirstName,
                Surname,
                Address,
                Email,
                Password,
                Role,
                EmployeeStatus,
                HireDate
            FROM EmployeeTable
            WHERE LOWER(Email) = LOWER(@Email);";


                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@Email",
                        email);


                    connection.Open();


                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return result;
                        }


                        // =========================================
                        // CHECK EMPLOYEE STATUS
                        // =========================================

                        string employeeStatus =
                            reader["EmployeeStatus"] == DBNull.Value
                            ? "Active"
                            : reader["EmployeeStatus"]
                                .ToString()
                                .Trim();


                        if (!employeeStatus.Equals(
                            "Active",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            result.Message =
                                "This Cafe101 employee account is currently inactive. Please contact a manager for assistance.";

                            return result;
                        }


                        // =========================================
                        // CHECK PASSWORD
                        // =========================================

                        string storedPassword =
                            reader["Password"]
                            .ToString();


                        if (storedPassword != password)
                        {
                            return result;
                        }


                        // =========================================
                        // LOGIN SUCCESS
                        // =========================================

                        result.Success =
                            true;


                        result.UserID =
                            Convert.ToInt32(
                                reader["EmployeeID"]);


                        result.UserType =
                            "Employee";


                        result.Role =
                            reader["Role"] == DBNull.Value
                            ? ""
                            : reader["Role"]
                                .ToString()
                                .Trim();


                        result.FirstName =
                            reader["FirstName"] == DBNull.Value
                            ? ""
                            : reader["FirstName"]
                                .ToString();


                        result.Surname =
                            reader["Surname"] == DBNull.Value
                            ? ""
                            : reader["Surname"]
                                .ToString();


                        result.Address =
                            reader["Address"] == DBNull.Value
                            ? ""
                            : reader["Address"]
                                .ToString();


                        result.Email =
                            reader["Email"] == DBNull.Value
                            ? ""
                            : reader["Email"]
                                .ToString();


                        result.Message =
                            "Sign in successful.";


                        return result;
                    }
                }
            }
        }

        // ============================================================
        // CUSTOMER LOGIN
        // ============================================================

        private LoginResult CheckCustomer(
            string email,
            string password)
        {
            LoginResult result =
                new LoginResult();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT CustomerID,
                           FirstName,
                           Surname,
                           Address,
                           Email,
                           Password,
                           Status,
                           PhoneNumber
                    FROM CustomerTable
                    WHERE LOWER(Email) = LOWER(@Email)";

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue(
                        "@Email",
                        email);

                    connection.Open();

                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return result;
                        }

                        string storedPassword =
                            reader["Password"]
                            .ToString();

                        string hashedEnteredPassword =
                            HashPassword(password);

                        /*
                         * New website customer accounts use SHA-256.
                         * Plain-text comparison is kept temporarily
                         * so older customer records still work.
                         */
                        bool passwordMatches =
                            storedPassword ==
                            hashedEnteredPassword
                            ||
                            storedPassword ==
                            password;

                        if (!passwordMatches)
                        {
                            return result;
                        }

                        string status =
                            reader["Status"]
                            .ToString()
                            .Trim();

                        if (!string.IsNullOrWhiteSpace(status)
                            &&
                            !status.Equals(
                                "Active",
                                StringComparison.OrdinalIgnoreCase))
                        {
                            result.Message =
                                "This Cafe101 customer account is currently inactive. Please contact Cafe101 for assistance.";

                            return result;
                        }

                        result.Success = true;

                        result.UserID =
                            Convert.ToInt32(
                                reader["CustomerID"]);

                        result.UserType =
                            "Customer";

                        result.Role =
                            "Customer";

                        result.FirstName =
                            reader["FirstName"].ToString();

                        result.Surname =
                            reader["Surname"].ToString();

                        result.Address =
                            reader["Address"].ToString();

                        result.Email =
                            reader["Email"].ToString();

                        result.PhoneNumber =
                            reader["PhoneNumber"].ToString();

                        result.Message =
                            "Sign in successful.";

                        return result;
                    }
                }
            }
        }


        // ============================================================
        // SIGN UP
        // ============================================================

        public SignUpResult SignUpCustomer(
            string firstName,
            string surname,
            string phoneNumber,
            string streetAddress,
            string suburb,
            string city,
            string email,
            string password,
            bool acceptedTerms)
        {
            SignUpResult result =
                new SignUpResult();

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

            password =
                password ?? "";


            // ========================================================
            // FIRST NAME VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(firstName))
            {
                result.Message =
                    "First name is required. Please enter your first name.";

                return result;
            }

            if (!Regex.IsMatch(
                firstName,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Invalid first name. Please use letters only. Spaces, apostrophes and hyphens are also allowed.";

                return result;
            }


            // ========================================================
            // SURNAME VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(surname))
            {
                result.Message =
                    "Surname is required. Please enter your surname.";

                return result;
            }

            if (!Regex.IsMatch(
                surname,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Invalid surname. Please use letters only. Spaces, apostrophes and hyphens are also allowed.";

                return result;
            }


            // ========================================================
            // PHONE NUMBER VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                result.Message =
                    "Phone number is required. Please enter a 10-digit South African mobile number, for example 0821234567.";

                return result;
            }

            if (!Regex.IsMatch(
                phoneNumber,
                @"^\d+$"))
            {
                result.Message =
                    "Invalid phone number. Please enter numbers only, with no letters, spaces or symbols. Example: 0821234567.";

                return result;
            }

            if (phoneNumber.Length != 10)
            {
                result.Message =
                    "Invalid phone number length. A South African mobile number must contain exactly 10 digits. Example: 0821234567.";

                return result;
            }

            if (!Regex.IsMatch(
                phoneNumber,
                @"^0[6-8]\d{8}$"))
            {
                result.Message =
                    "Invalid South African mobile number. The number must start with 06, 07 or 08 and contain exactly 10 digits.";

                return result;
            }


            // ========================================================
            // STREET ADDRESS VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(streetAddress))
            {
                result.Message =
                    "Street address is required. Please enter your street number and street name, for example 25 Jan Hofmeyr Road.";

                return result;
            }

            if (streetAddress.Length < 5)
            {
                result.Message =
                    "Street address is too short. Please enter a complete street address, for example 25 Jan Hofmeyr Road.";

                return result;
            }

            if (!Regex.IsMatch(
                streetAddress,
                @"^[A-Za-z0-9\s,'./#-]+$"))
            {
                result.Message =
                    "Invalid street address. Please use letters, numbers and normal address characters such as commas, hyphens, apostrophes, slashes or #.";

                return result;
            }

            // Require at least one letter
            if (!Regex.IsMatch(
                streetAddress,
                @"[A-Za-z]"))
            {
                result.Message =
                    "Invalid street address. Please include the street name as well as the street number.";

                return result;
            }


            // ========================================================
            // SUBURB VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(suburb))
            {
                result.Message =
                    "Suburb is required. Please enter your suburb, for example Westville.";

                return result;
            }

            if (!Regex.IsMatch(
                suburb,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Invalid suburb. Suburb names may contain letters, spaces, apostrophes and hyphens, but not numbers or other symbols.";

                return result;
            }


            // ========================================================
            // CITY VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(city))
            {
                result.Message =
                    "City is required. Please enter your city, for example Durban.";

                return result;
            }

            if (!Regex.IsMatch(
                city,
                @"^[A-Za-z\s'-]+$"))
            {
                result.Message =
                    "Invalid city. City names may contain letters, spaces, apostrophes and hyphens, but not numbers or other symbols.";

                return result;
            }


            // ========================================================
            // EMAIL VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(email))
            {
                result.Message =
                    "Email address is required. Please enter the email address you would like to use to sign in.";

                return result;
            }

            if (!IsValidEmail(email))
            {
                result.Message =
                    "Invalid email address. Please enter a complete email address, for example name@gmail.com.";

                return result;
            }


            // ========================================================
            // PASSWORD VALIDATION
            // ========================================================

            if (string.IsNullOrWhiteSpace(password))
            {
                result.Message =
                    "Password is required. Your password must be at least 8 characters long and include an uppercase letter, lowercase letter, number and special character.";

                return result;
            }

            if (password.Length < 8)
            {
                result.Message =
                    "Password is too short. Please use at least 8 characters.";

                return result;
            }

            if (!Regex.IsMatch(
                password,
                "[A-Z]"))
            {
                result.Message =
                    "Password must include at least one uppercase letter (A-Z).";

                return result;
            }

            if (!Regex.IsMatch(
                password,
                "[a-z]"))
            {
                result.Message =
                    "Password must include at least one lowercase letter (a-z).";

                return result;
            }

            if (!Regex.IsMatch(
                password,
                "[0-9]"))
            {
                result.Message =
                    "Password must include at least one number (0-9).";

                return result;
            }

            if (!Regex.IsMatch(
                password,
                @"[^A-Za-z0-9]"))
            {
                result.Message =
                    "Password must include at least one special character, such as !, @, # or $.";

                return result;
            }


            // ========================================================
            // TERMS
            // ========================================================

            if (!acceptedTerms)
            {
                result.Message =
                    "You must accept the Cafe101 Terms of Use and Privacy Statement before creating an account.";

                return result;
            }


            try
            {
                // ====================================================
                // DUPLICATE EMAIL CHECK
                // ====================================================

                if (EmailExists(email))
                {
                    result.Message =
                        "An account with this email address already exists. Please sign in using this email or register with another email address.";

                    return result;
                }


                // ====================================================
                // DUPLICATE PHONE CHECK
                // ====================================================

                if (PhoneExists(phoneNumber))
                {
                    result.Message =
                        "An account with this phone number already exists. Please use another phone number or sign in to your existing account.";

                    return result;
                }


                // ====================================================
                // PREPARE DATA
                // ====================================================

                string fullAddress =
                    streetAddress + ", " +
                    suburb + ", " +
                    city;

                string hashedPassword =
                    HashPassword(password);


                // ====================================================
                // INSERT CUSTOMER INTO DATABASE
                // ====================================================

                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        INSERT INTO CustomerTable
                        (
                            FirstName,
                            Surname,
                            Address,
                            Email,
                            Password,
                            Status,
                            PhoneNumber
                        )
                        VALUES
                        (
                            @FirstName,
                            @Surname,
                            @Address,
                            @Email,
                            @Password,
                            @Status,
                            @PhoneNumber
                        );

                        SELECT CAST(SCOPE_IDENTITY() AS INT);";


                    using (SqlCommand command =
                        new SqlCommand(
                            sql,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@FirstName",
                            firstName);

                        command.Parameters.AddWithValue(
                            "@Surname",
                            surname);

                        command.Parameters.AddWithValue(
                            "@Address",
                            fullAddress);

                        command.Parameters.AddWithValue(
                            "@Email",
                            email);

                        command.Parameters.AddWithValue(
                            "@Password",
                            hashedPassword);

                        command.Parameters.AddWithValue(
                            "@Status",
                            "Active");

                        command.Parameters.AddWithValue(
                            "@PhoneNumber",
                            phoneNumber);


                        connection.Open();

                        object insertedID =
                            command.ExecuteScalar();


                        if (insertedID == null ||
                            insertedID == DBNull.Value)
                        {
                            result.Message =
                                "Your account could not be created because the database did not return a customer ID. Please try again.";

                            return result;
                        }


                        int newCustomerID =
                            Convert.ToInt32(
                                insertedID);


                        result.Success =
                            true;

                        result.CustomerID =
                            newCustomerID;

                        result.Message =
                            "Your Cafe101 account has been created successfully.";

                        return result;
                    }
                }
            }


            // ========================================================
            // DATABASE ERRORS
            // ========================================================

            catch (SqlException ex)
            {
                /*
                 * TEMPORARY during development.
                 * This gives us the exact SQL error so we can fix
                 * database/schema problems.
                 *
                 * Before final submission/demo, replace this with
                 * a generic user-friendly message.
                 */

                result.Message =
                    "Database error: " +
                    ex.Message;

                return result;
            }

            catch (Exception ex)
            {
                // TEMPORARY during development
                result.Message =
                    "Unexpected error: " +
                    ex.Message;

                return result;
            }
        }


        // ============================================================
        // DUPLICATE EMAIL CHECK
        // ============================================================

        private bool EmailExists(string email)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM
                    (
                        SELECT Email
                        FROM CustomerTable
                        WHERE LOWER(Email) = LOWER(@Email)

                        UNION ALL

                        SELECT Email
                        FROM EmployeeTable
                        WHERE LOWER(Email) = LOWER(@Email)

                    ) AS ExistingAccounts";


                using (SqlCommand command =
                    new SqlCommand(
                        sql,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@Email",
                        email);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        // ============================================================
        // DUPLICATE PHONE CHECK
        // ============================================================

        private bool PhoneExists(string phoneNumber)
        {
            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*)
                    FROM CustomerTable
                    WHERE PhoneNumber = @PhoneNumber";


                using (SqlCommand command =
                    new SqlCommand(
                        sql,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@PhoneNumber",
                        phoneNumber);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        // ============================================================
        // EMAIL VALIDATION
        // ============================================================

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


        // ============================================================
        // PASSWORD HASHING
        // ============================================================

        private string HashPassword(string password)
        {
            using (SHA256 sha256 =
                SHA256.Create())
            {
                byte[] bytes =
                    sha256.ComputeHash(
                        Encoding.UTF8.GetBytes(
                            password));

                StringBuilder builder =
                    new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(
                        b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // ============================================================
        // GET CUSTOMER BY EMAIL (for Forgot Password)
        // ============================================================
        public CustomerInfo GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            string query = @"
        SELECT CustomerID, FirstName, Surname, Email, Status
        FROM CustomerTable
        WHERE Email = @Email"
            ;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email.Trim());
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CustomerInfo
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Email = reader["Email"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // ============================================================
        // UPDATE CUSTOMER PASSWORD
        // ============================================================
        public bool UpdateCustomerPassword(int customerId, string newPassword)
        {
            string query = @"
        UPDATE CustomerTable
        SET Password = @Password
        WHERE CustomerID = @CustomerID"
            ;

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public class CustomerInfo
        {
            public int CustomerID { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
        }
    }
}
