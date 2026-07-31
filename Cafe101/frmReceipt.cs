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

//

namespace Cafe101
{
    public partial class frmReceipt : Form
    {
        private int _orderID;
        private decimal _orderTotal;
        private decimal _amountPaid;
        private decimal _change;
        private string _paymentMethod;

        private DataTable _orderItems;


        // Printing objects for receipt rendering
        private PrintDocument printDoc = new PrintDocument();
        private PrintPreviewDialog printPreview = new PrintPreviewDialog();

        public frmReceipt(int orderID, decimal orderTotal, decimal amountPaid, decimal change, string paymentMethod)
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            _orderID = orderID;
            _orderTotal = orderTotal;
            _amountPaid = amountPaid;
            _change = change;
            _paymentMethod = paymentMethod;

            // Wire up the print page rendering layout event
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            /*orderIDTxt.Text = _orderID.ToString();
            dateTxt.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            payTxt.Text = _paymentMethod;
            totTxt.Text = "R " + _orderTotal.ToString("0.00");
            amountTxt.Text = "R " + _amountPaid.ToString("0.00");
            changeTxt.Text = _paymentMethod == "Card" ? "N/A" : "R " + _change.ToString("0.00");

            LoadCustomerAndCashier();
            LoadOrderItems();*/
            PopulateReceiptData();
        }

        // NEW: public so frmCheckout can call it without showing this form
        public void PopulateReceiptData()
        {
            orderIDTxt.Text = _orderID.ToString();
            dateTxt.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            payTxt.Text = _paymentMethod;
            totTxt.Text = "R " + _orderTotal.ToString("0.00");
            amountTxt.Text = "R " + _amountPaid.ToString("0.00");
            changeTxt.Text = _paymentMethod == "Card" ? "N/A" : "R " + _change.ToString("0.00");

            LoadCustomerAndCashier();
            LoadOrderItems();
        }

        private void LoadCustomerAndCashier()
        {
            try
            {
                string query = @"SELECT 
                    c.FirstName + ' ' + c.Surname AS CustomerName,
                    e.FirstName + ' ' + e.Surname AS CashierName
                 FROM [OrderTable] o
                 JOIN CustomerTable c ON o.CustomerID = c.CustomerID
                 JOIN EmployeeTable e ON o.EmployeeID = e.EmployeeID
                 WHERE o.OrderID = @orderID";

                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderID", _orderID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        custTxt.Text = reader["CustomerName"].ToString();
                        cashierTxt.Text = reader["CashierName"].ToString();
                    }
                    else
                    {
                        custTxt.Text = "No data found for OrderID: " + _orderID;
                        cashierTxt.Text = "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Full error: " + ex.Message + "\n\nOrderID being used: " + _orderID,
                    "Debug Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                custTxt.Text = "Error";
                cashierTxt.Text = "Error";
            }
        }

        private void LoadOrderItems()
        {
            _orderItems = new DataTable();
            string query = @"SELECT 
                        m.MenuItemName,
                        io.QuantityOrdered,
                        m.SellingPrice,
                        io.Subtotal
                     FROM ItemOrder io
                     JOIN MenuItemsTable m ON io.MenuItemID = m.MenuItemID
                     WHERE io.OrderID = @orderID";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@orderID", _orderID);
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(_orderItems);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Close();
        }

        private void custTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Kept clean for alternative layout triggers if needed
        }

        // --- UPDATED: button1 serves as your core print action wrapped safely in a try-catch block ---
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Prepare document assignment links
                printPreview.Document = printDoc;
                printPreview.WindowState = FormWindowState.Maximized;

                // Fire preview window wrapper safely
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                // Intercept hardware device runtime exceptions safely
                MessageBox.Show("An error occurred while attempting to open the print engine:\n" + ex.Message,
                    "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ShowPrintPreview()
        {
            printPreview.Document = printDoc;
            printPreview.WindowState = FormWindowState.Maximized;
            printPreview.ShowDialog();
        }
        // --- Core receipt printing engine mapping all text fields ---
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Courier New", 14, FontStyle.Bold);
                Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
                Font regularFont = new Font("Courier New", 10, FontStyle.Regular);
                Font smallFont = new Font("Courier New", 9, FontStyle.Regular);

                int startX = 20;
                int startY = 20;
                int offset = 0;
                int lineWidth = 40;

                // Header
                e.Graphics.DrawString("CAFE 101", titleFont, Brushes.Black, startX + 70, startY + offset);
                offset += 25;
                e.Graphics.DrawString("CUSTOMER TRANSACTION RECEIPT", boldFont, Brushes.Black, startX + 15, startY + offset);
                offset += 18;
                e.Graphics.DrawString("479 Varsity Road, Durban, KZN", smallFont, Brushes.Black, startX + 25, startY + offset);
                offset += 15;
                e.Graphics.DrawString("Tel: 031 896 0230 | VAT No: 4123456789", smallFont, Brushes.Black, startX, startY + offset);
                offset += 15;
                e.Graphics.DrawString(new string('-', lineWidth), regularFont, Brushes.Black, startX, startY + offset);
                offset += 15;

                // Order + Cashier + Customer info
                e.Graphics.DrawString("Order ID:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(orderIDTxt.Text, regularFont, Brushes.Black, startX + 130, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Date & Time:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(dateTxt.Text, regularFont, Brushes.Black, startX + 130, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Cashier:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(cashierTxt.Text, regularFont, Brushes.Black, startX + 130, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Customer:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(custTxt.Text, regularFont, Brushes.Black, startX + 130, startY + offset);
                offset += 20;

                e.Graphics.DrawString(new string('-', lineWidth), regularFont, Brushes.Black, startX, startY + offset);
                offset += 18;

                // Itemized list header
                e.Graphics.DrawString("Item", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString("Qty", boldFont, Brushes.Black, startX + 190, startY + offset);
                e.Graphics.DrawString("Price", boldFont, Brushes.Black, startX + 230, startY + offset);
                e.Graphics.DrawString("Subtotal", boldFont, Brushes.Black, startX + 290, startY + offset);
                offset += 16;
                e.Graphics.DrawString(new string('-', lineWidth), regularFont, Brushes.Black, startX, startY + offset);
                offset += 16;

                // Itemized rows
                if (_orderItems != null)
                {
                    foreach (DataRow row in _orderItems.Rows)
                    {
                        string name = row["MenuItemName"].ToString();
                        if (name.Length > 22) name = name.Substring(0, 22);

                        string qty = Convert.ToInt32(Convert.ToDecimal(row["QuantityOrdered"])).ToString();
                        string price = "R" + Convert.ToDecimal(row["SellingPrice"]).ToString("0.00");
                        string subtotal = "R" + Convert.ToDecimal(row["Subtotal"]).ToString("0.00");

                        e.Graphics.DrawString(name, smallFont, Brushes.Black, startX, startY + offset);
                        e.Graphics.DrawString(qty, smallFont, Brushes.Black, startX + 190, startY + offset);
                        e.Graphics.DrawString(price, smallFont, Brushes.Black, startX + 230, startY + offset);
                        e.Graphics.DrawString(subtotal, smallFont, Brushes.Black, startX + 290, startY + offset);
                        offset += 16;
                    }
                }

                offset += 5;
                e.Graphics.DrawString(new string('-', lineWidth), regularFont, Brushes.Black, startX, startY + offset);
                offset += 18;

                // Financial Summary
                e.Graphics.DrawString("Payment Method:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(payTxt.Text, regularFont, Brushes.Black, startX + 150, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Total Amount:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(totTxt.Text, boldFont, Brushes.Black, startX + 150, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Amount Paid:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(amountTxt.Text, regularFont, Brushes.Black, startX + 150, startY + offset);
                offset += 18;

                e.Graphics.DrawString("Change Due:", boldFont, Brushes.Black, startX, startY + offset);
                e.Graphics.DrawString(changeTxt.Text, boldFont, Brushes.Black, startX + 150, startY + offset);
                offset += 25;

                // Footer
                e.Graphics.DrawString(new string('-', lineWidth), regularFont, Brushes.Black, startX, startY + offset);
                offset += 15;
                e.Graphics.DrawString("Thank you for dining at Cafe 101!", boldFont, Brushes.Black, startX + 5, startY + offset);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while rendering the receipt content layout:\n" + ex.Message,
                    "Rendering Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
