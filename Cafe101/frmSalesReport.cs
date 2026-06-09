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
using System;
using System.Data;
using System.Drawing;             // For Graphics, Bitmap, Font
using System.Drawing.Printing;    // For PrintDocument
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // For the Chart control

namespace Cafe101
{
    public partial class frmSalesReport : Form
    {
        public frmSalesReport()
        {
            InitializeComponent();
        }
       
        private PrintDocument printDoc = new PrintDocument();

        // Variables for printing
        private int currentRow = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Hub.OrderTable' table. You can move, or remove it, as needed.
            this.orderTableTableAdapter.Fill(this.dsCafe101Hub.OrderTable);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                printDoc.PrintPage -= PrintDoc_PrintPage; // avoid duplicate handlers
                printDoc.PrintPage += PrintDoc_PrintPage;

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDoc;

                preview.WindowState = FormWindowState.Maximized;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing Error: " + ex.Message);
            }
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 10);
            Pen gridPen = Pens.Black;

            int startX = 50;
            int startY = 50;
            int rowHeight = 30;
            int cellWidth = 120;

            int x = startX;
            int y = startY;

            // Report Title
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            e.Graphics.DrawString("Sales Report", titleFont, Brushes.Black, x, y);

            y += 50;

            // Print Column Headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                Rectangle rect = new Rectangle(x, y, cellWidth, rowHeight);

                e.Graphics.DrawRectangle(gridPen, rect);
                e.Graphics.DrawString(
                    column.HeaderText,
                    printFont,
                    Brushes.Black,
                    rect,
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                x += cellWidth;
            }

            y += rowHeight;

            // Print Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                x = startX;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    Rectangle rect = new Rectangle(x, y, cellWidth, rowHeight);

                    e.Graphics.DrawRectangle(gridPen, rect);

                    string value = cell.Value?.ToString() ?? "";

                    e.Graphics.DrawString(
                        value,
                        printFont,
                        Brushes.Black,
                        rect,
                        new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });

                    x += cellWidth;
                }

                y += rowHeight;
            }

            // Print Total Revenue
            y += 20;

            Font totalFont = new Font("Arial", 12, FontStyle.Bold);

            e.Graphics.DrawString(
                "Total Revenue: R " + textBox1.Text,
                totalFont,
                Brushes.Black,
                startX,
                y);

            e.HasMorePages = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;

                // Load filtered records
                this.orderTableTableAdapter.FillByDateRange(
                    this.dsCafe101Hub.OrderTable,
                    fromDate,
                    toDate
                );

               

                // Calculate total revenue
                decimal totalRevenue = 0;

                foreach (DataRow row in dsCafe101Hub.OrderTable.Rows)
                {
                    if (row["TotalAmountDue"] != DBNull.Value)
                    {
                        totalRevenue += Convert.ToDecimal(row["TotalAmountDue"]);
                    }
                }

                // Display in textbox
                textBox1.Text = totalRevenue.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }
    }
}
