using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe101;           // or your project's namespace
///using RestaurantSystem; // if frmManageRecipes is in a different namespace

namespace Cafe101
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
           
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewOrder newOrder = new frmNewOrder();
            //newOrder.ShowDialog();
            newOrder.Show();
            this.Hide();    
        }

        private void mnuMenuItems_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageMenuItems)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageMenuItems frmMenu = new frmManageMenuItems();
           // frmMenu.MdiParent = this;
            frmMenu.Show();
        }

        private void mnuIngredients_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageIngredients)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageIngredients frmIng = new frmManageIngredients();
         //   frmIng.MdiParent = this;
            frmIng.Show();
        }

        private void mnuRecipes_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageRecipes)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageRecipes frmRecipe = new frmManageRecipes();
           // frmRecipe.MdiParent = this;
            frmRecipe.Show();
        }

        private void mnuCashiers_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageEmployees)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageEmployees frmEmp = new frmManageEmployees();
          //  frmEmp.MdiParent = this;
            frmEmp.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SafeLogout();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageCustomers frmCust = new frmManageCustomers();
            frmCust.ShowDialog();
           // frmCust.Show();
           // this.Hide();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReport frmReport = new frmSalesReport();
            //frmReport.ShowDialog();
            frmReport.Show();
            this.Hide();
        }

        private void popularityAnalyticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPopularProduct frmAnalytics = new frmPopularProduct(); 
            frmAnalytics.ShowDialog();
            
        }

        private void lowStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLowStock stock = new frmLowStock();  
            //stock.ShowDialog();
            stock.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"{SessionManager.Role}: {SessionManager.FirstName} {SessionManager.Surname}";
            lblDateTime.Text = SessionManager.LoginTime.ToString("dd MMM yyyy  HH:mm");
            txtHelp.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
        "Are you sure you want to exit?",
        "Exit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SafeLogout();
                Application.Exit();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            txtHelp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHelp.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SafeLogout()
        {
            try
            {
                if (SessionManager.EmployeeID == 0)
                    return;

                if (SessionManager.LoginTime.Year < 2000)
                    return; // prevents invalid dates

                DateTime logoutTime = DateTime.Now;

                TimeSpan duration = logoutTime - SessionManager.LoginTime;

                string durationStr =
                    $"{duration.Hours}h {duration.Minutes}m {duration.Seconds}s";

                this.loginHistoryTableTableAdapter1.UpdateLogout(
                    logoutTime,
                    durationStr,
                    SessionManager.EmployeeID,
                    SessionManager.LoginTime
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Logout error: " + ex.Message);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                SafeLogout();
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageCustomers frmCust = new frmManageCustomers();      
            frmCust.Show();
            this.Hide();
        }
    }
}
