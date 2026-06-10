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

            // Centralized Event Subscription: Keeps memory footprint minimal
            printDocument.PrintPage += PrintPageHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmLowStock_Load(object sender, EventArgs e)
        {
            int count = 0;

            try
            {
                // Removed duplicate Fill call to streamline system database connection execution
                this.ingredientTableTableAdapter.Fill(this.dsCafe101Hub.IngredientTable);

                var ingredients = dsCafe101Hub.IngredientTable.AsEnumerable();

                var lowStock = ingredients.Where(r =>
                {
                    double qty = Convert.ToDouble(r["QuantityOnHand"]);
                    double restock = Convert.ToDouble(r["RestockLevel"]);

                    return qty < restock;
                }).ToList();

                count = lowStock.Count;

                dataGridView1.DataSource = lowStock.Any()
                    ? lowStock.CopyToDataTable()
                    : null;

                textBox1.Text = count.ToString();

                SetupGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock items:\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnPrintLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset tracking markers before the runtime print execution layout loop kicks off
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
                MessageBox.Show("Print engine initialization error:\n\n" + ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            string totalItemsCount = string.IsNullOrWhiteSpace(textBox1.Text) ? "0" : textBox1.Text;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event hook placeholder
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event hook placeholder
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmManageIngredients manageIngredientsForm = new frmManageIngredients();
            manageIngredientsForm.Show();
            this.Hide();
        }
    }
}
