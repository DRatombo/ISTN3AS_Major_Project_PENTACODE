using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe101
{
    public static class SessionManager
    {
        public static string FirstName { get; set; }
        public static string Surname { get; set; }
        public static string Role { get; set; }
        public static string Email { get; set; }
        public static DateTime LoginTime { get; set; }

        public static int EmployeeID { get; set; }

        public static void Clear()
        {
            FirstName = null;
            Surname = null;
            Role = null;
            Email = null;
            EmployeeID = 0;
            LoginTime = DateTime.MinValue;
        }

        public static bool IsLoggedIn()
        {
            return EmployeeID != 0 && LoginTime != DateTime.MinValue;
        }
    }
}
