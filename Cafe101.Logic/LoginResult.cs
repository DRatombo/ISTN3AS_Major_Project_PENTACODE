namespace Cafe101.Logic
{
    public class LoginResult
    {
        public bool Success { get; set; }

        public int UserID { get; set; }

        // Customer or Employee
        public string UserType { get; set; }

        // Customer, Manager, Cashier/Staff
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}