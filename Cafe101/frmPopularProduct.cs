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
    public partial class frmPopularProduct : Form
    {
        public frmPopularProduct()
        {
            InitializeComponent();
        }
        private Panel pnlHelp = null;
        private bool helpVisible = false;
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmPopularProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Hub.MenuItemsTable' table. You can move, or remove it, as needed.
            this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
            try
            {
                this.topSellingItemTableAdapter1.FillByTopSellingItem(this.dsCafe101Hub.TopSellingItem);

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 0)
                {
                    textBox1.Text = dsCafe101Hub.TopSellingItem.Rows[0]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 1)
                {
                    textBox2.Text = dsCafe101Hub.TopSellingItem.Rows[1]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 2)
                {
                    textBox3.Text = dsCafe101Hub.TopSellingItem.Rows[2]["MenuItemName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading popular products:\n" + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLowStock lowStock = new frmLowStock();
            lowStock.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Re-run the queries to fetch the latest data from the database hub
                this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                this.topSellingItemTableAdapter1.FillByTopSellingItem(this.dsCafe101Hub.TopSellingItem);

                // 2. Clear out the textboxes first to prevent ghost data display
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                // 3. Re-populate the Top 3 Podium Cards with the newly fetched rows
                if (dsCafe101Hub.TopSellingItem.Rows.Count > 0)
                {
                    textBox1.Text = dsCafe101Hub.TopSellingItem.Rows[0]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 1)
                {
                    textBox2.Text = dsCafe101Hub.TopSellingItem.Rows[1]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 2)
                {
                    textBox3.Text = dsCafe101Hub.TopSellingItem.Rows[2]["MenuItemName"].ToString();
                }

                // 4. Force the DataGridView to re-render its UI layout immediately
                dataGridView1.Refresh();

                // 5. Provide a quiet status notification or message (Optional)
                MessageBox.Show("Leaderboard data refreshed successfully!", "System Update",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to sync fresh data from the hub backend:\n" + ex.Message,
                                "Database Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. If help panel is already open, toggle it off cleanly
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                button4.Text = "? Help";
                return;
            }

            // --- Detect Current State & Build Context-Aware Content ---
            string stepTitle = "📊 Chef's Analytics Guide";
            string stepDetail = "";

            // Context Check A: Is the database list completely empty?
            if (dataGridView1.Rows.Count == 0)
            {
                stepTitle = "⚠️ System Alert — No Data Found";
                stepDetail =
                    "The system cannot find any item sales records to display.\r\n\r\n" +
                    "• Click the REFRESH REPORT button to re-establish " +
                    "  a secure link with the database backend.\r\n\r\n" +
                    "• If this is a new shift or new store database setup, " +
                    "  the grid will remain blank until orders are processed " +
                    "  in the active point-of-sale system.";
            }
            // Context Check B: Normal Operation State (Data is on screen)
            else
            {
                // Dynamically fetch the top selling item from your dataset to make the help look highly integrated
                string currentGoldItem = textBox1.Text;
                if (string.IsNullOrEmpty(currentGoldItem)) currentGoldItem = "None";

                stepTitle = "💡 Leaderboard Navigation Guide";
                stepDetail =
                    "Current Leader: " + currentGoldItem + " ✔\r\n\r\n" +
                    "How to use this management dashboard:\r\n\r\n" +
                    "• MASTER LEDGER (Left):\r\n" +
                    "  Lists all menu items sorted by all-time volume performance. " +
                    "  Columns show Item ID, Name, and Total Units Sold.\r\n\r\n" +
                    "• REFRESH DATA:\r\n" +
                    "  Updates counts instantly if orders are placed at the cash registers.\r\n\r\n" +
                    "• VIEW LOW STOCK:\r\n" +
                    "  Launches the inventory hub module to compare these " +
                    "  high-volume trends against actual warehouse quantities.";
            }

            // 2. Initialize the physical panel container if it doesn't exist yet
            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(330, 350);
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(43, 50, 62); // Team's matching container color
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            // 3. Wipe out old labels to refresh layout canvas sizing
            pnlHelp.Controls.Clear();

            // 4. Construct Header Component
            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(10, 10);
            lblTitle.Size = new System.Drawing.Size(310, 25);

            // 5. Construct Descriptive Detail Component
            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 9);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(10, 42);
            lblDetail.Size = new System.Drawing.Size(305, 270);

            // 6. Construct Close Action Trigger
            Button btnClose = new Button();
            btnClose.Text = "✕ Close";
            btnClose.Size = new System.Drawing.Size(100, 28);
            btnClose.Location = new System.Drawing.Point(215, 312);
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 173, 181); // Team's uniform button teal accent color
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                button4.Text = "? Help";
            };

            // 7. Mount layout structures into the container hierarchy
            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            // 8. Dock position calculations (Positions panel directly ABOVE button4)
            pnlHelp.Location = new System.Drawing.Point(
                button4.Left,
                button4.Top - pnlHelp.Height - 5
            );

            // 9. Display the panel to the user layout thread
            pnlHelp.Visible = true;
            helpVisible = true;
            button4.Text = "? Help (ON)";
        }
    }
}
