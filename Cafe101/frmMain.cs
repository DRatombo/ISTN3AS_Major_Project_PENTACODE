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

            string stepTitle =
                  $"📖 Welcome {SessionManager.FirstName} - {SessionManager.Role} Dashboard Guide";
            string stepDetail = "";

            if (SessionManager.Role == "Cashier")
            {
                stepDetail =
                    "Welcome to Cafe101.\r\n\r\n" +

                    "As a Cashier, your main responsibility is processing customer orders quickly and accurately.\r\n\r\n" +

                    "──────────────────── Orders ────────────────────\r\n\r\n" +

                    "• Search for an existing customer or add a new customer.\r\n" +
                    "• Select menu items and quantities.\r\n" +
                    "• Review the cart before confirming the order.\r\n" +
                    "• Process payment and provide change where necessary.\r\n" +
                    "• Event orders can be scheduled for a future date and time.\r\n\r\n" +

                    "──────────────────── Customers ────────────────────\r\n\r\n" +

                    "• View customer information.\r\n" +
                    "• Add new customers when they are not already registered.\r\n" +
                    "• Update customer details if required.\r\n\r\n" +

                    "──────────────────── Logout ────────────────────\r\n\r\n" +

                    "• Logout when your shift ends.\r\n" +
                    "• This ensures accurate login history tracking.\r\n\r\n" +

                    "⚠ Cashiers cannot access Analytics or Management functions.";
            }
            else // Manager
            {
                stepDetail =
                    "Welcome to Cafe101.\r\n\r\n" +

                    "As a Manager, you have full access to operational and analytical functions of the system.\r\n\r\n" +

                    "──────────────────── Orders ────────────────────\r\n\r\n" +

                    "• Create and manage customer orders.\r\n" +
                    "• Process payments and review order information.\r\n\r\n" +

                    "──────────────────── Analytics ────────────────────\r\n\r\n" +

                    "• View sales reports and revenue trends.\r\n" +
                    "• Analyse popular products.\r\n" +
                    "• Monitor business performance using charts and reports.\r\n" +
                    "• Review low-stock warnings and inventory trends.\r\n\r\n" +

                    "──────────────────── Management ────────────────────\r\n\r\n" +

                    "• Manage employees and cashier accounts.\r\n" +
                    "• Manage ingredients and stock levels.\r\n" +
                    "• Create and update menu items.\r\n" +
                    "• Create and maintain recipes.\r\n" +
                    "• Manage customer records.\r\n\r\n" +

                    "──────────────────── Logout ────────────────────\r\n\r\n" +

                    "• Logout securely when finished using the system.";
            }

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
