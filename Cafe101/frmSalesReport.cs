using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmSalesReport : Form
    {
        private PrintDocument printDoc = new PrintDocument();
        private int printRowIndex = 0;
        private int pageNumber = 0;

        public frmSalesReport()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            printDoc.PrintPage += PrintDoc_PrintPage;

            // Wire up date pickers
            dateTimePicker1.ValueChanged += DateFilters_ValueChanged;
            dateTimePicker2.ValueChanged += DateFilters_ValueChanged;

            // Auto-refresh on activation
            this.Activated += (s, e) => ApplyDateFilter();

            // Set default date range (last 7 days)
            SetDefaultDateRange();
        }

        #region Date Logic Helper Methods

        /// <summary>
        /// Sets the default date range to the last 7 days
        /// </summary>
        private void SetDefaultDateRange()
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-7);
            dateTimePicker2.Value = DateTime.Today;
        }

        /// <summary>
        /// Gets the start of the day (00:00:00) for the From Date
        /// </summary>
        private DateTime GetStartOfDay(DateTime date)
        {
            return date.Date; // 00:00:00
        }

        /// <summary>
        /// Gets the end of the day (23:59:59) for the To Date
        /// </summary>
        private DateTime GetEndOfDay(DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1); // 23:59:59
        }

        /// <summary>
        /// Validates the date range selection
        /// </summary>
        private bool ValidateDateRange(DateTime fromDate, DateTime toDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check 1: From Date cannot be in the future
            if (fromDate > DateTime.Today)
            {
                errorMessage = "The 'From Date' cannot be in the future.";
                return false;
            }

            // Check 2: To Date cannot be in the future
            if (toDate > DateTime.Today)
            {
                errorMessage = "The 'To Date' cannot be in the future.";
                return false;
            }

            // Check 3: From Date cannot be after To Date
            if (fromDate > toDate)
            {
                errorMessage = "The 'From Date' cannot be later than the 'To Date'.";
                return false;
            }

            // Check 4: Date range should be at least 1 day (24 hours)
            TimeSpan range = toDate - fromDate;
            if (range.TotalHours < 24)
            {
                errorMessage = "Please select a date range of at least 24 hours.\n\n" +
                               "This ensures you capture a full day of sales data.";
                return false;
            }

            // Check 5: Date range should not exceed 90 days (performance)
            if (range.TotalDays > 90)
            {
                errorMessage = "Please select a date range of 90 days or less.\n\n" +
                               "Larger date ranges may impact performance.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Applies the date filter with proper start/end of day handling
        /// </summary>
        private void ApplyDateFilter()
        {
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;

            // Validate the date range
            if (!ValidateDateRange(fromDate, toDate, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reset to valid values
                if (fromDate > DateTime.Today) dateTimePicker1.Value = DateTime.Today.AddDays(-7);
                if (toDate > DateTime.Today) dateTimePicker2.Value = DateTime.Today;
                if (fromDate > toDate) dateTimePicker2.Value = fromDate;

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Get proper start and end times
                DateTime startDate = GetStartOfDay(fromDate);
                DateTime endDate = GetEndOfDay(toDate);

                // Clear the existing data first
                this.dsCafe101Hub.OrderTable.Clear();

                // Call the adapter with the properly formatted dates
                this.orderTableTableAdapter.FillByDateRange(
                    this.dsCafe101Hub.OrderTable,
                    startDate,
                    endDate
                );

                // Refresh all UI elements
                UpdateStatistics();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying date filter:\n\n{ex.Message}",
                    "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Form Events

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;

            SetupGrid();
            ApplyDateFilter(); // Load data with default range
        }

        private void DateFilters_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }

        #endregion

        #region Button Events

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ApplyDateFilter();
            MessageBox.Show("Sales data refreshed successfully!",
                "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].Cells[0].Value?.ToString()?.Contains("No orders") == true))
            {
                MessageBox.Show("No data available to print. Please select a valid date range with orders.",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                printRowIndex = 0;
                pageNumber = 0;

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = printDoc;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to generate print preview:\n\n{ex.Message}",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void today_Click(object sender, EventArgs e)
        {
           /* try
            {
                // CORRECT: Set From Date to Today at 00:00 and To Date to Today at 23:59
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today; // Will be converted to 23:59 in ApplyDateFilter
                ApplyDateFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading today's orders:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
           frmTodaysOrders today = new frmTodaysOrders();
           today.Show();
          // today.Hide();

        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void btnTodayOrders_Click(object sender, EventArgs e)
        {
            today_Click(sender, e);
        }

        #endregion

        #region Data Methods

        private void UpdateStatistics()
        {
            try
            {
                var orders = dsCafe101Hub.OrderTable.AsEnumerable();

                // Filter only completed orders for statistics
                var completedOrders = orders.Where(r =>
                {
                    string status = r["OrderStatus"].ToString().Trim();
                    return status.Equals("Complete", StringComparison.OrdinalIgnoreCase) ||
                           status.Equals("Completed", StringComparison.OrdinalIgnoreCase);
                });

                // Total Orders
                int totalOrders = completedOrders.Count();
                lblTotalOrdersValue.Text = totalOrders.ToString();

                // Total Revenue
                decimal totalRevenue = completedOrders.Any()
                    ? completedOrders.Sum(r => Convert.ToDecimal(r["TotalAmountDue"]))
                    : 0;
                lblTotalRevenueValue.Text = totalRevenue.ToString("C2");
                txtRevenue.Text = totalRevenue.ToString("C2");

                // Average Order Value
                decimal avgOrder = totalOrders > 0 ? totalRevenue / totalOrders : 0;
                lblAvgOrderValue.Text = avgOrder.ToString("C2");

                // Handle empty state - don't clear rows directly
                if (totalOrders == 0)
                {
                    lblTotalOrdersValue.Text = "0";
                    lblTotalRevenueValue.Text = "R0.00";
                    lblAvgOrderValue.Text = "R0.00";
                    txtRevenue.Text = "R0.00";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Statistics error: {ex.Message}");
            }
        }

        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Format currency column
            if (dataGridView1.Columns.Contains("TotalAmountDue"))
            {
                dataGridView1.Columns["TotalAmountDue"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["TotalAmountDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        #endregion

        #region Print Methods

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            pageNumber++;

            // --- Typography & Styling Rules ---
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

            // Header
            e.Graphics.DrawString("Cafe101", companyFont, textBrush, marginLeft, currentY);

            string pageStr = $"Page {pageNumber}";
            SizeF pageSize = e.Graphics.MeasureString(pageStr, addressFont);
            e.Graphics.DrawString(pageStr, addressFont, textBrush, marginRight - pageSize.Width, currentY + 8);

            currentY += 40;

            string addressLine1 = "University of KwaZulu-Natal (UKZN)";
            string addressLine2 = "Westville Campus, Durban, KwaZulu-Natal, South Africa";
            e.Graphics.DrawString(addressLine1, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 20;
            e.Graphics.DrawString(addressLine2, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 30;

            e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
            currentY += 25;

            e.Graphics.DrawString("FINANCIAL MANAGEMENT: SALES REVENUE REPORT", titleFont, textBrush, marginLeft, currentY);
            currentY += 30;

            string rangeStr = $"Reporting Range: {dateTimePicker1.Value:yyyy-MM-dd} to {dateTimePicker2.Value:yyyy-MM-dd}";
            e.Graphics.DrawString(rangeStr, addressFont, Brushes.DimGray, marginLeft, currentY);

            string dateStr = $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";
            SizeF dateSize = e.Graphics.MeasureString(dateStr, addressFont);
            e.Graphics.DrawString(dateStr, addressFont, Brushes.DimGray, marginRight - dateSize.Width, currentY);

            currentY += 45;

            // Table
            int rowHeight = 28;
            var visibleColumns = dataGridView1.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();

            if (visibleColumns.Count == 0) return;

            int cellWidth = printableWidth / visibleColumns.Count;

            int currentX = marginLeft;
            foreach (var column in visibleColumns)
            {
                Rectangle headerRect = new Rectangle(currentX, currentY, cellWidth, rowHeight);
                e.Graphics.FillRectangle(headerBgBrush, headerRect);
                e.Graphics.DrawRectangle(linePen, headerRect);
                e.Graphics.DrawString(column.HeaderText, headerFont, textBrush, headerRect,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                currentX += cellWidth;
            }

            currentY += rowHeight;

            // Check if there are actual rows to print (skip the "No orders" message row)
            int actualRowCount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value?.ToString()?.Contains("No orders") != true)
                {
                    actualRowCount++;
                }
            }

            if (actualRowCount == 0)
            {
                // Print a message indicating no data
                e.Graphics.DrawString("No order data available for the selected date range.",
                    cellFont, textBrush, marginLeft, currentY);
                e.HasMorePages = false;
                return;
            }

            while (printRowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[printRowIndex];

                if (row.IsNewRow || row.Cells[0].Value?.ToString()?.Contains("No orders") == true)
                {
                    printRowIndex++;
                    continue;
                }

                if (currentY + rowHeight > marginBottom - 80)
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
                    if (row.Cells[column.Index].Value is DateTime dtValue)
                        value = dtValue.ToString("yyyy-MM-dd");
                    else if (column.Name == "TotalAmountDue" && row.Cells[column.Index].Value != null)
                    {
                        if (decimal.TryParse(value, out decimal amount))
                            value = amount.ToString("C2");
                    }

                    e.Graphics.DrawString(value, cellFont, textBrush, cellRect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                    currentX += cellWidth;
                }

                currentY += rowHeight;
                printRowIndex++;
            }

            // Footer
            if (printRowIndex >= dataGridView1.Rows.Count)
            {
                currentY += 35;
                e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
                currentY += 20;

                string finalRevenue = string.IsNullOrWhiteSpace(txtRevenue.Text) ? "R0.00" : txtRevenue.Text;
                e.Graphics.DrawString($"Cumulative Total Revenue (Completed Orders Only): {finalRevenue}",
                    headerFont, textBrush, marginLeft, currentY);

                string confidentialityNotice = "\n\nCafe101 Internal Operational Management Record.";
                SizeF noticeSize = e.Graphics.MeasureString(confidentialityNotice, footerFont);
                e.Graphics.DrawString(confidentialityNotice, footerFont, Brushes.DarkGray,
                    marginRight - noticeSize.Width, currentY);

                e.HasMorePages = false;
            }
        }

        #endregion

        // Legacy event handlers kept for compatibility
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void lblFilterTitle_Click(object sender, EventArgs e)
        {

        }
    }
}