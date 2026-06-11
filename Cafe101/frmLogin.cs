            using Cafe101.dsCafe101HubTableAdapters;
            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data;
            using System.Drawing;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using System.Windows.Forms;

            namespace Cafe101
            {
                public partial class frmLogin : Form
                {
                    // Added dataset instance and table adapter that point to dsCafe101Hub.EmployeeTable
                    private dsCafe101Hub dsCafe101Hub1 = new dsCafe101Hub();
                    private EmployeeTableTableAdapter employeeTableAdapter1 = new EmployeeTableTableAdapter();
                    private Panel pnlHelp = null;
                    private bool helpVisible = false;
        public frmLogin()
                    {
                        InitializeComponent();
                        //this.DoubleBuffered = true;
                    }
                    private bool ValidateEmail()
                    {
                        string email = txtEmail.Text;

                        if (string.IsNullOrWhiteSpace(email))
                        {
                            txtEmail.BackColor = Color.Red;
                            lblEmailMsg.Text = "Required";
                            return false;
                        }

                        bool found = false;

                        // Use the instance of dsCafe101Hub
                        foreach (DataRow row in dsCafe101Hub1.EmployeeTable.Rows)
                        {
                            if (row["Email"].ToString() == email)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            txtEmail.BackColor = Color.LightGreen;
                            lblEmailMsg.Text = "";
                            return true;
                        }
                        else
                        {
                            txtEmail.BackColor = Color.Red;
                            lblEmailMsg.Text = "Email not found";
                            return false;
                        }
                    }
                    private bool ValidatePassword()
                    {
                        string email = txtEmail.Text;
                        string password = txtPassword.Text;

                        bool found = false;

                        // Validate against EmployeeTable on dsCafe101Hub (use the same data source)
                        foreach (DataRow row in dsCafe101Hub1.EmployeeTable.Rows)
                        {
                            if (row["Email"].ToString() == email &&
                                row["Password"].ToString() == password)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            txtPassword.BackColor = Color.LightGreen;
                            return true;
                        }
                        else
                        {
                            txtPassword.BackColor = Color.Red;
                            return false;
                        }
                    }

                    private void btnLogin_Click(object sender, EventArgs e)
                    {

            // this.testEmployeeTableAdapter1.Fill(this.dsCafe101Test1.TestEmployee);
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            bool isValid = false;

            // cashierTableAdapter1.Fill(dsLogin1.Cashier);

            // Use the instance dataset that contains EmployeeTable
            foreach (DataRow row in dsCafe101Hub1.EmployeeTable.Rows)
            {
                if (row["Email"].ToString() == Email && Email.Contains("@cafe101.com") && row["Password"].ToString() == Password && Password.Length == 8)
                {
                    isValid = true;
                    SessionManager.EmployeeID = Convert.ToInt32(row["EmployeeID"]);
                    SessionManager.FirstName = row["FirstName"].ToString();
                    SessionManager.Surname = row["Surname"].ToString();
                    SessionManager.Role = row["Role"].ToString();
                    SessionManager.Email = row["Email"].ToString();
                    SessionManager.LoginTime = DateTime.Now;
                    this.loginHistoryTableTableAdapter1.InsertLogin(SessionManager.EmployeeID, SessionManager.FirstName, SessionManager.Role, SessionManager.LoginTime, SessionManager.LoginTime, "0h 0m 0s");

                }
            }
            if (isValid)
            {
                frmMain mainMenu = new frmMain();
                mainMenu.Show();
                this.Hide(); 

               // frmMain mainMenu = new frmMain();
               // this.Hide();
               // mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
                txtEmail.Clear();
                txtPassword.Clear();
            }
        }

                    private void button1_Click(object sender, EventArgs e)
                    {
                        txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                    }

                    private void txtUsername_TextChanged(object sender, EventArgs e)
                    {
                        ValidateEmail();
                    }

                    private void txtPassword_TextChanged(object sender, EventArgs e)
                    {
                        ValidatePassword();
                    }

                    private void button2_Click(object sender, EventArgs e)
                    {
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
                return;
            }

            string stepTitle = "📖 Cafe101 Login Guide";
            string stepDetail =
                "─── Getting Started ───\r\n\r\n" +

                "📍 Step 1 — Enter Your Email\r\n" +
                "• Type your work email in the Email field.\r\n" +
                "• Must use the Cafe101 domain:\r\n" +
                "  e.g. yourname@cafe101.com\r\n" +
                "• Gmail / Outlook / Yahoo not accepted.\r\n\r\n" +

                "📍 Step 2 — Enter Your Password\r\n" +
                "• Type your password in the Password field.\r\n" +
                "• Must be at least 8 characters long.\r\n" +
                "• Fewer than 8 characters = login blocked.\r\n\r\n" +

                "📍 Step 3 — Show / Hide Password\r\n" +
                "• Password is hidden by default (••••••••).\r\n" +
                "• Click 👁 Show Password to reveal it.\r\n" +
                "• Click again to hide it.\r\n\r\n" +

                "📍 Step 4 — Click Login\r\n" +
                "• Both fields must be filled correctly.\r\n" +
                "• You'll be taken to the main dashboard.\r\n\r\n" +

                "💡 Contact your manager if you don't\r\n" +
                "   have login credentials yet.";

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(483, 807);  // taller for more content
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(20, 40, 100);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            pnlHelp.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(460, 30);

            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 13);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(10, 42);
            lblDetail.Size = new System.Drawing.Size(460, 700);  // expanded to fit all steps

            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 28);
            btnClose.Location = new System.Drawing.Point(370, 765);  // pushed down to match new height
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
            };

            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            pnlHelp.Location = new System.Drawing.Point(
                pBHelp.Left,
                pBHelp.Top);

            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "? Help (ON)";

        }

                    private void frmLogin_Load(object sender, EventArgs e)
                    {
                        

                        txtPassword.UseSystemPasswordChar = true;

                        // Fill the EmployeeTable on dsCafe101Hub so the form uses that as its data source
                        try
                        {
                            this.employeeTableAdapter1.ClearBeforeFill = true;
                            this.employeeTableAdapter1.Fill(this.dsCafe101Hub1.EmployeeTable);
                        }
                        catch (Exception ex)
                        {
                            // If there is a data access error, show a concise message and allow developer debugging
                            MessageBox.Show("Failed to load employee data: " + ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Keep existing test dataset fill if other logic depends on it (optional)
                        // this.testEmployeeTableAdapter1.Fill(this.dsCafe101Test1.TestEmployee);
                    }

                    private void frmLogin_Resize(object sender, EventArgs e)
                    {
            
                    }
        

                    private void btnClose_Click(object sender, EventArgs e)
                    {
                       
                    }

                    private void pBLogin_Click(object sender, EventArgs e)
                    {

                    }

                    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
                    {

                    }

                    private void pBHelp_Click(object sender, EventArgs e)
                    {

                    }

                    private void lblEmailMsg_Click(object sender, EventArgs e)
                    {

                    }

                    private void lblPassword_Click(object sender, EventArgs e)
                    {

                    }

                    private void lblUsername_Click(object sender, EventArgs e)
                    {

                    }

                    private void txtHelp_TextChanged(object sender, EventArgs e)
                    {

                    }

                    private void btnExit_Click(object sender, EventArgs e)
                    {
                     DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?",
                     "Exit",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!SessionManager.IsLoggedIn())
            {
                Application.Exit();
                return;
            }

            SessionManager.Clear();
            Application.Exit();
        }
        // Add this method to the frmLogin class to resolve CS1061.
        // Adjust the implementation as needed to match your actual LoginHistoryTableAdapter and dataset.

                     private void LoginHistoryTableInsert(int employeeId, string firstName, string role, DateTime loginTime, DateTime logoutTime, string status)
                    
                    {
                        // You may need to use your actual LoginHistoryTableAdapter and dataset here.
                        // Example implementation (replace with your actual adapter and table if different):
                        // Assuming you have a LoginHistoryTableAdapter and dsCafe101Hub.LoginHistoryTable

                        // Uncomment and adjust the following lines if you have a LoginHistoryTableAdapter:
                        // var loginHistoryTableAdapter = new LoginHistoryTableAdapter();
                        // loginHistoryTableAdapter.Insert(employeeId, firstName, role, loginTime, logoutTime, status);

                        // If you do not have a LoginHistoryTableAdapter, you need to add one to your dataset.
                        // For now, this is a placeholder to avoid the CS1061 error.
                    }
                }
            }
