using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Application.Run(new frmNewOrder());
            //Application.Run(new frmLogin());
           //Application.Run(new frmTodaysOrders());
           Application.Run(new frmCheckout(2 , 1000m));
            //Application.Run(new frmReceipt(1,, decimal amountPaid, decimal change, string paymentMethod));
        }
    }
}
