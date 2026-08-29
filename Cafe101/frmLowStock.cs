using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Cafe101
{
    public partial class frmLowStock : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;
        private int pageNumber = 0;

        public frmLowStock()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            printDocument.PrintPage += PrintPageHandler;

            // Auto-refresh on activation
            this.Activated += (s, e) => LoadLowStockData();
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
            frmManageIngredients manageIngredientsForm = new frmManageIngredients();
            manageIngredientsForm.Show();
            this.Hide();
        }

        private void btnPrintLowStock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print. Please refresh the data first.",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                printRowIndex = 0;
                pageNumber = 0;

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = printDocument;
                    preview.Width = 1000;
                    preview.Height = 700;
                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print engine initialization error:\n\n{ex.Message}",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Refresh button click handler
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLowStockData();
            MessageBox.Show("Data refreshed successfully!",
                "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Form Events

        private void frmLowStock_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                LoadLowStockData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Data Methods

        private void LoadLowStockData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ingredientTableTableAdapter.Fill(this.dsCafe101Hub.IngredientTable);

                var ingredients = dsCafe101Hub.IngredientTable.AsEnumerable();

                var lowStock = ingredients.Where(r =>
                {
                    double qty = Convert.ToDouble(r["QuantityOnHand"]);
                    double restock = Convert.ToDouble(r["RestockLevel"]);
                    return qty < restock;
                }).ToList();

                int count = lowStock.Count;

                dataGridView1.DataSource = lowStock.Any()
                    ? lowStock.CopyToDataTable()
                    : null;

                // Update the label with the count (using lblLowStockValue instead of textBox1)
                if (lblLowStockValue != null)
                {
                    lblLowStockValue.Text = count.ToString();
                }

                UpdateStatistics();
                SetupGrid();

                // Handle empty state
                if (!lowStock.Any())
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[0].Cells[0].Value = "No low stock items found";
                    dataGridView1.Rows[0].Cells[0].Style.ForeColor = Color.LightGray;
                    dataGridView1.Rows[0].Cells[0].Style.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                    dataGridView1.Rows[0].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock items:\n\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var ingredients = dsCafe101Hub.IngredientTable.AsEnumerable();

                // Total items
                int totalItems = ingredients.Count();
                if (lblTotalItemsValue != null)
                    lblTotalItemsValue.Text = totalItems.ToString();

                // Below restock level (Low Stock)
                int belowRestock = ingredients.Count(r =>
                    Convert.ToDouble(r["QuantityOnHand"]) < Convert.ToDouble(r["RestockLevel"]));
                if (lblLowStockValue != null)
                    lblLowStockValue.Text = belowRestock.ToString();

                // Critical (Zero stock)
                int critical = ingredients.Count(r =>
                    Convert.ToDouble(r["QuantityOnHand"]) == 0);
                if (lblCriticalValue != null)
                    lblCriticalValue.Text = critical.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Stats error: {ex.Message}");
            }
        }

        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Columns.Contains("IngredientID"))
                dataGridView1.Columns["IngredientID"].Visible = false;

            // Format currency column
            if (dataGridView1.Columns.Contains("CostPrice"))
            {
                dataGridView1.Columns["CostPrice"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        #endregion

        #region Print Methods

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            pageNumber++;

            // --- Typography & Styling Layout Rules ---
            Font companyFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font addressFont = new Font("Segoe UI", 9, FontStyle.Regular);
            Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font cellFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font footerFont = new Font("Segoe UI", 9, FontStyle.Italic);

            Brush textBrush = Brushes.Black;
            Brush headerBgBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            Pen linePen = new Pen(Color.DimGray, 1f);
            Pen gridPen = new Pen(Color.LightGray, 0.75f);

            int marginLeft = e.MarginBounds.Left;
            int marginTop = e.MarginBounds.Top;
            int marginRight = e.MarginBounds.Right;
            int marginBottom = e.MarginBounds.Bottom;
            int printableWidth = e.MarginBounds.Width;

            int currentY = marginTop;

            // =================================================================
            // 1. BRANDING HEADER (CAFE101 DETAILS)
            // =================================================================
            e.Graphics.DrawString("Cafe101", companyFont, textBrush, marginLeft, currentY);

            string pageStr = $"Page {pageNumber}";
            SizeF pageSize = e.Graphics.MeasureString(pageStr, addressFont);
            e.Graphics.DrawString(pageStr, addressFont, textBrush, marginRight - pageSize.Width, currentY + 8);

            currentY += 30;

            string addressLine1 = "University of KwaZulu-Natal (UKZN)";
            string addressLine2 = "Westville Campus, Durban, KwaZulu-Natal, South Africa";
            e.Graphics.DrawString(addressLine1, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 16;
            e.Graphics.DrawString(addressLine2, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 25;

            e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
            currentY += 20;

            e.Graphics.DrawString("INVENTORY CONTROL: LOW STOCK REPORT", titleFont, textBrush, marginLeft, currentY);

            string dateStr = $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";
            SizeF dateSize = e.Graphics.MeasureString(dateStr, addressFont);
            e.Graphics.DrawString(dateStr, addressFont, Brushes.DimGray, marginRight - dateSize.Width, currentY + 4);

            currentY += 40;

            // =================================================================
            // 2. DATA GRID STRUCTURAL CALCULATIONS
            // =================================================================
            int rowHeight = 28;

            var visibleColumns = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                      .Where(c => c.Visible)
                                                      .ToList();

            if (visibleColumns.Count == 0) return;

            int cellWidth = printableWidth / visibleColumns.Count;

            // Print Header Track Block
            int currentX = marginLeft;
            foreach (var column in visibleColumns)
            {
                Rectangle headerRect = new Rectangle(currentX, currentY, cellWidth, rowHeight);

                e.Graphics.FillRectangle(headerBgBrush, headerRect);
                e.Graphics.DrawRectangle(linePen, headerRect);

                e.Graphics.DrawString(
                    column.HeaderText,
                    headerFont,
                    textBrush,
                    headerRect,
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                currentX += cellWidth;
            }

            currentY += rowHeight;

            // =================================================================
            // 3. PAGINATION STREAM LOOP
            // =================================================================
            while (printRowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[printRowIndex];

                if (row.IsNewRow)
                {
                    printRowIndex++;
                    continue;
                }

                // Check page height space bounds constraints
                if (currentY + rowHeight > marginBottom - 40)
                {
                    e.HasMorePages = true;
                    return;
                }

                currentX = marginLeft;

                foreach (var column in visibleColumns)
                {
                    Rectangle cellRect = new Rectangle(currentX, currentY, cellWidth, rowHeight);
                    e.Graphics.DrawRectangle(gridPen, cellRect);

                    string value = row.Cells[column.Index].Value?.ToString() ?? "";

                    // Format currency
                    if (column.Name == "CostPrice" && !string.IsNullOrEmpty(value))
                    {
                        if (decimal.TryParse(value, out decimal cost))
                        {
                            value = cost.ToString("C2");
                        }
                    }

                    e.Graphics.DrawString(
                        value,
                        cellFont,
                        textBrush,
                        cellRect,
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });

                    currentX += cellWidth;
                }

                currentY += rowHeight;
                printRowIndex++;
            }

            // =================================================================
            // 4. REPORT RUNTIME SUMMARY FOOTER
            // =================================================================
            currentY += 25;

            e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
            currentY += 10;

            string totalItemsCount = lblLowStockValue != null ? lblLowStockValue.Text : "0";
            e.Graphics.DrawString(
                $"Total Low Stock Line Items Identified: {totalItemsCount}",
                headerFont,
                textBrush,
                marginLeft,
                currentY);

            string confidentialityNotice = "\n\nCafe101 Internal Operational Management Record.";
            SizeF noticeSize = e.Graphics.MeasureString(confidentialityNotice, footerFont);
            e.Graphics.DrawString(confidentialityNotice, footerFont, Brushes.DarkGray, marginRight - noticeSize.Width, currentY);

            e.HasMorePages = false;
        }

        #endregion

        // Legacy event handlers kept for compatibility
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}