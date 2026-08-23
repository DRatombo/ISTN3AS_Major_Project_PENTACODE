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
        private Panel pnlHelp = null;
        private bool helpVisible = false;

        public frmPopularProduct()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Auto-refresh on activation
            this.Activated += (s, e) => LoadPopularProducts();
        }

        #region Button Events

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLowStock lowStock = new frmLowStock();
            lowStock.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToggleHelpPanel();
        }

        #endregion

        #region Form Events

        private void frmPopularProduct_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                LoadPopularProducts();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Data Methods

        private void LoadPopularProducts()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                this.topSellingItemTableAdapter1.FillByTopSellingItem(this.dsCafe101Hub.TopSellingItem);

                UpdateStatistics();
                PopulateBestSellers();
                SetupGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading popular products:\n\n{ex.Message}",
                    "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set default empty state
                txtGoldItem.Text = "Error Loading";
                txtSilverItem.Text = "Error Loading";
                txtBronzeItem.Text = "Error Loading";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.menuItemsTableTableAdapter.Fill(this.dsCafe101Hub.MenuItemsTable);
                this.topSellingItemTableAdapter1.FillByTopSellingItem(this.dsCafe101Hub.TopSellingItem);

                UpdateStatistics();
                PopulateBestSellers();
                dataGridView1.Refresh();

                MessageBox.Show("Leaderboard data refreshed successfully!",
                    "System Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to sync fresh data:\n\n{ex.Message}",
                    "Database Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                var products = dsCafe101Hub.TopSellingItem.AsEnumerable();

                // Total Products
                int totalProducts = products.Count();
                lblTotalProductsValue.Text = totalProducts.ToString();

                // Total Sales
                int totalSales = products.Any() ? products.Sum(r => Convert.ToInt32(r["TotalSold"])) : 0;
                lblTotalSalesValue.Text = totalSales.ToString("N0");

                // Top Seller
                if (products.Any())
                {
                    string topSeller = products.First()["MenuItemName"].ToString();
                    lblTopSellerValue.Text = topSeller;
                }
                else
                {
                    lblTopSellerValue.Text = "No Data";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Stats error: {ex.Message}");
                lblTopSellerValue.Text = "Error";
            }
        }

        private void PopulateBestSellers()
        {
            try
            {
                var products = dsCafe101Hub.TopSellingItem.AsEnumerable();
                int productCount = products.Count();

                // Gold (1st)
                txtGoldItem.Text = productCount > 0
                    ? products.First()["MenuItemName"].ToString()
                    : "No Data";

                // Silver (2nd)
                txtSilverItem.Text = productCount > 1
                    ? products.ElementAt(1)["MenuItemName"].ToString()
                    : "No Data";

                // Bronze (3rd)
                txtBronzeItem.Text = productCount > 2
                    ? products.ElementAt(2)["MenuItemName"].ToString()
                    : "No Data";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Best Sellers error: {ex.Message}");
                txtGoldItem.Text = "Error";
                txtSilverItem.Text = "Error";
                txtBronzeItem.Text = "Error";
            }
        }

        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hide MenuItemID column if exists
            if (dataGridView1.Columns.Contains("MenuItemID"))
            {
                dataGridView1.Columns["MenuItemID"].Visible = false;
            }
        }

        #endregion

        #region Help Panel Methods

        private void ToggleHelpPanel()
        {
            // 1. If help panel is already open, toggle it off cleanly
            if (helpVisible)
            {
                if (pnlHelp != null)
                {
                    pnlHelp.Visible = false;
                }
                helpVisible = false;
                button4.Text = "Help";
                return;
            }

            ShowHelpPanel();
        }

        private void ShowHelpPanel()
        {
            // --- Detect Current State & Build Context-Aware Content ---
            string stepTitle = "📊 Analytics Guide";
            string stepDetail = "";

            // Context Check A: Is the database list completely empty?
            if (dataGridView1.Rows.Count == 0)
            {
                stepTitle = "⚠️ No Data Found";
                stepDetail =
                    "The system cannot find any item sales records to display.\r\n\r\n" +
                    "• Click the REFRESH button to re-establish " +
                    "  a secure link with the database backend.\r\n\r\n" +
                    "• If this is a new shift or new store database setup, " +
                    "  the grid will remain blank until orders are processed " +
                    "  in the active point-of-sale system.";
            }
            // Context Check B: Normal Operation State (Data is on screen)
            else
            {
                // Dynamically fetch the top selling item
                string currentGoldItem = txtGoldItem.Text;
                if (string.IsNullOrEmpty(currentGoldItem) || currentGoldItem == "No Data")
                    currentGoldItem = "None";

                stepTitle = "💡 Leaderboard Guide";
                stepDetail =
                    $"Current Leader: {currentGoldItem} ✔\r\n\r\n" +
                    "How to use this management dashboard:\r\n\r\n" +
                    "• MASTER LEDGER (Left):\r\n" +
                    "  Lists all menu items sorted by all-time volume performance. " +
                    "  Columns show ID, Name, and Total Units Sold.\r\n\r\n" +
                    "• REFRESH:\r\n" +
                    "  Updates counts instantly if orders are placed at the registers.\r\n\r\n" +
                    "• CHECK STOCK:\r\n" +
                    "  Launches the inventory hub module to compare these " +
                    "  high-volume trends against actual warehouse quantities.\r\n\r\n" +
                    "• STATISTICS (Top):\r\n" +
                    "  Shows total products, total sales, and the #1 selling item.";
            }

            // 2. Initialize the physical panel container if it doesn't exist yet
            if (pnlHelp == null)
            {
                pnlHelp = new Panel
                {
                    Size = new Size(330, 380),
                    BackColor = Color.FromArgb(44, 62, 80),
                    BorderStyle = BorderStyle.FixedSingle
                };
                this.Controls.Add(pnlHelp);
            }

            // 3. Wipe out old labels to refresh layout
            pnlHelp.Controls.Clear();

            // 4. Construct Header Component
            Label lblTitle = new Label
            {
                Text = stepTitle,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                Size = new Size(310, 30)
            };

            // 5. Construct Descriptive Detail Component
            Label lblDetail = new Label
            {
                Text = stepDetail,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.LightGray,
                Location = new Point(10, 45),
                Size = new Size(305, 290)
            };

            // 6. Construct Close Action Trigger
            Button btnClose = new Button
            {
                Text = "✕ Close",
                Size = new Size(100, 30),
                Location = new Point(215, 340),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                button4.Text = "Help";
            };

            // 7. Mount layout structures into the container hierarchy
            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            // 8. Dock position calculations (Positions panel above button4)
            pnlHelp.Location = new Point(
                button4.Left - 100,
                button4.Top - pnlHelp.Height - 10
            );

            // 9. Display the panel to the user
            pnlHelp.Visible = true;
            pnlHelp.BringToFront();
            helpVisible = true;
            button4.Text = "Help (ON)";
        }

        #endregion

        // Legacy event handlers kept for compatibility
        private void label1_Click(object sender, EventArgs e) { }
    }
}