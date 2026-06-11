using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing; // Required for print document rendering
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmTodaysOrders : Form
    {
        // Print engine objects and row tracking for multi-page layouts
        private PrintDocument printDoc = new PrintDocument();
        private PrintPreviewDialog printPreview = new PrintPreviewDialog();
        private int currentPrintRow = 0;

        public frmTodaysOrders()
        {
            InitializeComponent();

            // Link the printing event handler to the print document object
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        private void frmTodaysOrders_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadTodaysOrders();
        }

        private void LoadTodaysOrders()
        {
            orderDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            orderDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            try
            {
                string query = @"SELECT 
                    o.OrderID AS [Order #],
                    ISNULL(c.FirstName + ' ' + c.Surname, 'Unknown') AS [Customer],
                    o.OrderDatetime AS [Date & Time],
                    o.TotalAmountDue AS [Total (R)],
                    o.PaymentMethod AS [Payment],
                    o.OrderStatus AS [Status]
                 FROM [OrderTable] o
                 LEFT JOIN CustomerTable c ON o.CustomerID = c.CustomerID
                 ORDER BY o.OrderDatetime DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    orderDataGridView.AutoGenerateColumns = true;
                    orderDataGridView.DataSource = null;
                    orderDataGridView.DataSource = dt;
                    orderDataGridView.Refresh();
                    orderDataGridView.RowTemplate.Height = 30;
                    orderDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    orderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    orderDataGridView.AllowUserToAddRows = false;
                    orderDataGridView.ReadOnly = true;
                    numOrders.Text = "Date: " + DateTime.Now.ToString("dd MMM yyyy") +
                                     "     Total Orders: " + dt.Rows.Count;

                    // Calculate total revenue and output to textBox1
                    decimal totalRevenue = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Total (R)"] != DBNull.Value)
                        {
                            totalRevenue += Convert.ToDecimal(row["Total (R)"]);
                        }
                    }
                    textBox1.Text = "R " + totalRevenue.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTodaysOrders();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- IMPLEMENTED: button1 triggers the print report window ---
        private void button1_Click(object sender, EventArgs e)
        {
            // Safeguard against printing empty records
            if (orderDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There are no order records available to print today.", "Print Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Always reset the print row counter before starting the print process
            currentPrintRow = 0;

            // Set up and display the print preview container window
            printPreview.Document = printDoc;
            printPreview.WindowState = FormWindowState.Maximized;
            printPreview.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // The document layout formatting block 
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Report fonts setup
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font sectionFont = new Font("Arial", 11, FontStyle.Bold);
            Font dataFont = new Font("Arial", 10, FontStyle.Regular);
            Font footerFont = new Font("Arial", 11, FontStyle.Bold);

            int startX = 40;
            int startY = 50;
            int offset = 0;

            // Report Header Title
            e.Graphics.DrawString("CAFE 101", titleFont, Brushes.Black, startX, startY + offset);
            offset += 35;
            e.Graphics.DrawString("TODAY'S ORDERS BUSINESS REPORT", sectionFont, Brushes.Black, startX, startY + offset);
            offset += 20;
            e.Graphics.DrawString("Generated: " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"), dataFont, Brushes.DimGray, startX, startY + offset);
            offset += 30;

            // Header line break rule
            e.Graphics.DrawLine(Pens.Black, startX, startY + offset, e.PageBounds.Width - startX, startY + offset);
            offset += 15;

            // Table Column layout alignment markers (Structured to fit an A4 sheet layout)
            int colOrderNo = startX;
            int colCustomer = startX + 80;
            int colDateTime = startX + 250;
            int colTotal = startX + 430;
            int colPayment = startX + 540;
            int colStatus = startX + 640;

            // Render Table Columns Headers
            e.Graphics.DrawString("Order #", sectionFont, Brushes.Black, colOrderNo, startY + offset);
            e.Graphics.DrawString("Customer", sectionFont, Brushes.Black, colCustomer, startY + offset);
            e.Graphics.DrawString("Date & Time", sectionFont, Brushes.Black, colDateTime, startY + offset);
            e.Graphics.DrawString("Total", sectionFont, Brushes.Black, colTotal, startY + offset);
            e.Graphics.DrawString("Payment", sectionFont, Brushes.Black, colPayment, startY + offset);
            e.Graphics.DrawString("Status", sectionFont, Brushes.Black, colStatus, startY + offset);

            offset += 25;
            e.Graphics.DrawLine(Pens.LightGray, startX, startY + offset, e.PageBounds.Width - startX, startY + offset);
            offset += 10;

            // Print each row inside the data grid grid view dynamically
            while (currentPrintRow < orderDataGridView.Rows.Count)
            {
                DataGridViewRow row = orderDataGridView.Rows[currentPrintRow];

                string orderId = row.Cells["Order #"].Value?.ToString() ?? "";
                string customer = row.Cells["Customer"].Value?.ToString() ?? "";
                string dateTime = row.Cells["Date & Time"].Value?.ToString() ?? "";

                decimal rawTotal = row.Cells["Total (R)"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Total (R)"].Value) : 0;
                string total = "R " + rawTotal.ToString("N2");

                string payment = row.Cells["Payment"].Value?.ToString() ?? "";
                string status = row.Cells["Status"].Value?.ToString() ?? "";

                // Print individual row details
                e.Graphics.DrawString(orderId, dataFont, Brushes.Black, colOrderNo, startY + offset);
                e.Graphics.DrawString(customer, dataFont, Brushes.Black, colCustomer, startY + offset);
                e.Graphics.DrawString(dateTime, dataFont, Brushes.Black, colDateTime, startY + offset);
                e.Graphics.DrawString(total, dataFont, Brushes.Black, colTotal, startY + offset);
                e.Graphics.DrawString(payment, dataFont, Brushes.Black, colPayment, startY + offset);
                e.Graphics.DrawString(status, dataFont, Brushes.Black, colStatus, startY + offset);

                offset += 24;
                currentPrintRow++;

                // Trigger a page spillover if lines run too close to the bottom paper border
                if (startY + offset > e.PageBounds.Height - 80)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // Print document summaries (Only on the last page of the report)
            e.HasMorePages = false;
            offset += 10;
            e.Graphics.DrawLine(Pens.Black, startX, startY + offset, e.PageBounds.Width - startX, startY + offset);
            offset += 15;

            e.Graphics.DrawString("Total Orders Summary: " + orderDataGridView.Rows.Count, footerFont, Brushes.Black, startX, startY + offset);
            e.Graphics.DrawString("Total Revenue Summary: " + textBox1.Text, footerFont, Brushes.Black, colTotal - 60, startY + offset);
        }
    }
}
