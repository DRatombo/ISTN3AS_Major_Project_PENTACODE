using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using RestaurantSystem;

namespace Cafe101
{
    internal static class Program
    {
        // ADD THIS - Static reference to the floating chatbot
        public static FloatingChatbot floatingChatbot;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ADD THIS - Create and show the floating chatbot BEFORE running the main form
            floatingChatbot = new FloatingChatbot();
            floatingChatbot.Show();

            // Run the main form
            Application.Run(new frmLogin());
            // Application.Run(new frmMain());
            //Application.Run(new frmCheckout());
            //Application.Run(new frmManageMenuItems());
            //Application.Run(new frmPopularProduct()); 
            //Application.Run(new frmNewOrder());
            //Application.Run(new frmAddCustomer());  
        }
    }
}