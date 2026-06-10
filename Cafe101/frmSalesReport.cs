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

        // Safe structural variables for multi-page document pagination tracking
        private int printRowIndex = 0;
        private int pageNumber = 0;

        public frmSalesReport()
        {
            InitializeComponent();

            // Centralized Event Subscription to protect memory lifecycle
            printDoc.PrintPage += PrintDoc_PrintPage;

            // Wire up both date pickers to refresh data automatically when their values change
            dateTimePicker1.ValueChanged += DateFilters_ValueChanged;
            dateTimePicker2.ValueChanged += DateFilters_ValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            // Set standard format configuration rules for input elements to hide time structures
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;

            SetupGrid();

            // Initial data pull on view load sequence after grid has setup
            RefreshReportData();
        }

        /// <summary>
        /// Centralized auto-refresh routine that computes totals and populates data components
        /// </summary>
        private void RefreshReportData()
        {
            if (this.orderTableTableAdapter == null || this.dsCafe101Hub?.OrderTable == null || textBox1 == null)
            {
                return;
            }

            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;

                // 1. Fetch filtered data from Database Table Adapter straight into the dataset
                this.orderTableTableAdapter.FillByDateRange(
                    this.dsCafe101Hub.OrderTable,
                    fromDate,
                    toDate
                );

                DataTable orderTable = this.dsCafe101Hub.OrderTable;
                DataColumn statusColumn = null;
                DataColumn amountColumn = null;

                foreach (DataColumn col in orderTable.Columns)
                {
                    if (col.ColumnName.Equals("OrderStatus", StringComparison.OrdinalIgnoreCase))
                        statusColumn = col;
                    if (col.ColumnName.Equals("TotalAmountDue", StringComparison.OrdinalIgnoreCase))
                        amountColumn = col;
                }

                if (statusColumn == null || amountColumn == null)
                {
                    MessageBox.Show("Unable to load sales data details. The system layout appears to have changed. Please contact your system administrator.",
                                    "System Link Interrupted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalRevenue = 0;
                int totalRowsFound = orderTable.Rows.Count;
                int matchedRowsCount = 0;
                string sampleStatusValue = "NONE FOUND";

                // 2. Compute loops calculation
                foreach (DataRow row in orderTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    if (row[amountColumn] != DBNull.Value)
                    {
                        string status = row[statusColumn]?.ToString() ?? "";

                        // Grab a sample of whatever text is actually inside your column to help us diagnose
                        if (!string.IsNullOrWhiteSpace(status))
                        {
                            sampleStatusValue = status;
                        }

                        // Check for BOTH "Complete" and "Completed" to be safe
                        if (status.Trim().Equals("Complete", StringComparison.OrdinalIgnoreCase) ||
                            status.Trim().Equals("Completed", StringComparison.OrdinalIgnoreCase))
                        {
                            totalRevenue += Convert.ToDecimal(row[amountColumn]);
                            matchedRowsCount++;
                        }
                    }
                }

                // 3. Update UI parameter text output
                textBox1.Text = totalRevenue.ToString("N2");
                textBox1.Refresh();

                // 4. DIAGNOSTIC SAFEGUARD: If records exist but none matched our text criteria, tell us why!
                if (totalRowsFound > 0 && matchedRowsCount == 0)
                {
                    MessageBox.Show($"Diagnostic check: Found {totalRowsFound} total records in this date range, but 0 were added to revenue.\n\n" +
                                    $"Your database contains the status value: \"{sampleStatusValue}\"\n\n" +
                                    $"Expected value: \"Complete\" or \"Completed\"",
                                    "Status Value Mismatch Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not refresh the report layout. Please check your network connection to the database hub and try again.",
                                "Data Sync Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Automatic trigger linked to changes made on either DatePicker UI tool
        private void DateFilters_ValueChanged(object sender, EventArgs e)
        {
            RefreshReportData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshReportData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset structural loops tracking positions prior to rendering pages
                printRowIndex = 0;
                pageNumber = 0;

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = printDoc;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to generate the document print window. Please ensure a default printer is configured on this workstation.",
                                "Printer Connection Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

           
            // 1. PROFESSIONAL BRANDING HEADER
           
            e.Graphics.DrawString("Cafe101", companyFont, textBrush, marginLeft, currentY);

            string pageStr = $"Page {pageNumber}";
            SizeF pageSize = e.Graphics.MeasureString(pageStr, addressFont);
            e.Graphics.DrawString(pageStr, addressFont, textBrush, marginRight - pageSize.Width, currentY + 8);

            currentY += 40; // Spacing cushion to prevent header overlaps

            string addressLine1 = "University of KwaZulu-Natal (UKZN)";
            string addressLine2 = "Westville Campus, Durban, KwaZulu-Natal, South Africa";
            e.Graphics.DrawString(addressLine1, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 20;
            e.Graphics.DrawString(addressLine2, addressFont, Brushes.Gray, marginLeft, currentY);
            currentY += 30;

            e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
            currentY += 25;

            // Document Title
            e.Graphics.DrawString("FINANCIAL MANAGEMENT: SALES REVENUE REPORT", titleFont, textBrush, marginLeft, currentY);
            currentY += 30;

            // Clean Document Range Subtitle (Pure Dates formatted to exclude time stamps)
            string rangeStr = $"Reporting Range: {dateTimePicker1.Value:yyyy-MM-dd} to {dateTimePicker2.Value:yyyy-MM-dd}";
            e.Graphics.DrawString(rangeStr, addressFont, Brushes.DimGray, marginLeft, currentY);

            // Production Time Stamp
            string dateStr = $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";
            SizeF dateSize = e.Graphics.MeasureString(dateStr, addressFont);
            e.Graphics.DrawString(dateStr, addressFont, Brushes.DimGray, marginRight - dateSize.Width, currentY);

            currentY += 45; // Spacing block separation above table header layout

            // =================================================================
            // 2. TABLE CALCULATION & COLUMNS
            // =================================================================
            int rowHeight = 28;

            var visibleColumns = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                      .Where(c => c.Visible)
                                                      .ToList();

            if (visibleColumns.Count == 0) return;

            int cellWidth = printableWidth / visibleColumns.Count;

            // Draw Column Headers
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
            // 3. DATA ROWS PAGINATION ENGINE
            // =================================================================
            while (printRowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[printRowIndex];

                if (row.IsNewRow)
                {
                    printRowIndex++;
                    continue;
                }

                // Check page height space bounds constraints to prevent footer text collisions
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

                    // Formats cell to display Date strings accurately without time details
                    string value = row.Cells[column.Index].Value?.ToString() ?? "";
                    if (row.Cells[column.Index].Value is DateTime dtValue)
                    {
                        value = dtValue.ToString("yyyy-MM-dd");
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
            // 4. REPORT SUMMARY FOOTER (ONLY RENDERED ON FINAL PAGE)
            // =================================================================
            currentY += 35;

            e.Graphics.DrawLine(linePen, marginLeft, currentY, marginRight, currentY);
            currentY += 20;

            string finalRevenue = string.IsNullOrWhiteSpace(textBox1.Text) ? "0.00" : textBox1.Text;
            e.Graphics.DrawString(
                $"Cumulative Total Revenue (Completed Orders Only): R {finalRevenue}",
                headerFont,
                textBrush,
                marginLeft,
                currentY);

            string confidentialityNotice = "\n\nCafe101 Internal Operational Management Record.";
            SizeF noticeSize = e.Graphics.MeasureString(confidentialityNotice, footerFont);
            e.Graphics.DrawString(confidentialityNotice, footerFont, Brushes.DarkGray, marginRight - noticeSize.Width, currentY);

            e.HasMorePages = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}