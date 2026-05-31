using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantSystem;

namespace Cafe101
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new frmLogin());
           // Application.Run(new frmMain());
            //Application.Run(new frmCheckout());
            //Application.Run(new frmManageMenuItems());
            //Application.Run(new frmPopularProduct()); 
        }
    }
}
