using Cafe101;           // or your project's namespace
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///using RestaurantSystem; // if frmManageRecipes is in a different namespace

namespace Cafe101
{
    public partial class frmMain : Form
    {
        private Panel pnlHelpDash = null;
        private bool helpVisibleDash = false;
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
           

            
            switch (SessionManager.Role)
            {
                case "Cashier":
                    mnuAnalytics.Visible = false;  
                    mnuManagement.Visible = false; 
                    break;


            }
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
            if (helpVisibleDash)
            {
                pnlHelpDash.Visible = false;
                helpVisibleDash = false;
                btnHelp.Text = "? Help";
                return;
            }

            string stepTitle = "📖 Cafe101 Main Dashboard Guide";
            string stepDetail =
                "Once logged in, use the navigation tabs at the top of the screen to access all the core features of the Cafe101 system.\r\n\r\n" +

                "─────────────────────── The Navigation Tabs ───────────────────────\r\n\r\n" +

                " Orders\r\n" +
                "• New customers can be added into the system before placing an order — regular customers continue as normal.\r\n" +
                "• Select the items a customer would like to order directly from the menu list.\r\n" +
                "• Add or remove items as needed before confirming the order.\r\n" +
                "• Process the customer's payment directly through the same interface once the order is finalised.\r\n\r\n" +

                " Analytics\r\n" +
                "• View sales reports that show how much revenue and profit the business is generating.\r\n" +
                "• See business projections to understand future performance trends over time.\r\n" +
                "• All data is displayed using charts and graphs to make it easy to read and understand at a glance.\r\n" +
                "• This tab is primarily used by management to make informed business decisions.\r\n\r\n" +

                " Management\r\n" +
                "• Add new employees to the system.\r\n" +
                "• Add new ingredients to the menu with their relevent details.\r\n" +
                "• Add new menu items or recipes to the system at any time.\r\n" +
                "• View existing menu items and all their associated details.\r\n" +
                "• Update information such as prices, ingredients, or descriptions.\r\n" +
                "• Remove menu items or recipes that are no longer being offered.\r\n" +
                "• Each operation opens its own dedicated interface, making it easy to focus on one task at a time.\r\n\r\n" +   

                " Logout\r\n" +
                "• Use this option to return to the login screen so that another user can log in.\r\n\r\n" +

                " Note: Some tabs may be hidden depending on your assigned role (Cashier or Manager).";

            if (pnlHelpDash == null)
            {
                pnlHelpDash = new Panel();
                pnlHelpDash.Size = new System.Drawing.Size(1650, 800);
                pnlHelpDash.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelpDash.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelpDash);
                pnlHelpDash.BringToFront();
            }

            pnlHelpDash.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(1620, 40);

            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 13);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(10, 60);
            lblDetail.Size = new System.Drawing.Size(1620, 690);

            Button btnCloseHelp = new Button();
            btnCloseHelp.Text = "✕ Close";
            btnCloseHelp.Size = new System.Drawing.Size(120, 35);
            btnCloseHelp.Location = new System.Drawing.Point(1260, 750);
            btnCloseHelp.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnCloseHelp.ForeColor = System.Drawing.Color.White;
            btnCloseHelp.FlatStyle = FlatStyle.Flat;
            btnCloseHelp.Click += (s, ev) =>
            {
                pnlHelpDash.Visible = false;
                helpVisibleDash = false;
                btnHelp.Text = "? Help";
            };

            pnlHelpDash.Controls.Add(lblTitle);
            pnlHelpDash.Controls.Add(lblDetail);
            pnlHelpDash.Controls.Add(btnCloseHelp);
            pnlHelpDash.Location = new System.Drawing.Point(0, 30);

            pnlHelpDash.Visible = true;
            helpVisibleDash = true;
            btnHelp.Text = "? Help (ON)";
        }
       

        

        private void button1_Click(object sender, EventArgs e)
        {
            
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
