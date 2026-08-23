using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//NEW
using System.IO;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Cafe101
{
    public partial class frmCheckout : Form
    {
        private int _orderID;
        private decimal _orderTotal;
        private Panel pnlHelp;
        private bool helpVisible = false;

        public frmCheckout(int orderID, decimal orderTotal)
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            _orderID = orderID;
            _orderTotal = orderTotal;

            orderIDTxt.Text = orderID.ToString();
            totalTxt.Text = "R " + orderTotal.ToString("0.00");
            changeTextBox.Text = "R 0.00";
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------
        // VALIDATION
        // ---------------------------------------------------------------
        private bool ValidateAmountTendered()
        {
            if (!rbCash.Checked) return true;

            if (string.IsNullOrWhiteSpace(txtAmountTendered.Text))
            {
                txtAmountTendered.BackColor = Color.FromArgb(255, 220, 220);
                lblAmountMes.Text = "⚠ Required";
                lblAmountMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (!decimal.TryParse(txtAmountTendered.Text, out decimal amount))
            {
                txtAmountTendered.BackColor = Color.FromArgb(255, 220, 220);
                lblAmountMes.Text = "⚠ Numbers only";
                lblAmountMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (amount <= 0)
            {
                txtAmountTendered.BackColor = Color.FromArgb(255, 220, 220);
                lblAmountMes.Text = "⚠ Must be greater than 0";
                lblAmountMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (amount < _orderTotal)
            {
                txtAmountTendered.BackColor = Color.FromArgb(255, 220, 220);
                lblAmountMes.Text = "⚠ Amount too low";
                lblAmountMes.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtAmountTendered.BackColor = Color.FromArgb(220, 245, 220);
            lblAmountMes.Text = "✓";
            lblAmountMes.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        // ---------------------------------------------------------------
        // CASH SELECTED
        // ---------------------------------------------------------------
        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                label4.Visible = true;
                txtAmountTendered.Visible = true;
                lblChange.Visible = true;
                changeTextBox.Visible = true;
                lblAmountMes.Visible = true;
                txtAmountTendered.Enabled = true;
                txtAmountTendered.Text = "";
                changeTextBox.Text = "R 0.00";
                lblAmountMes.Text = "";
                txtAmountTendered.Focus();
            }
            else
            {
                label4.Visible = false;
                txtAmountTendered.Visible = false;
                lblChange.Visible = false;
                changeTextBox.Visible = false;
                lblAmountMes.Visible = false;
                txtAmountTendered.Enabled = false;
                txtAmountTendered.Text = "";
            }
        }

        private void rbCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCard.Checked)
            {
                label4.Visible = false;
                txtAmountTendered.Visible = false;
                lblChange.Visible = false;
                changeTextBox.Visible = false;
                lblAmountMes.Visible = false;
                txtAmountTendered.Enabled = false;
                txtAmountTendered.Text = "";
            }
            else
            {
                label4.Visible = true;
                txtAmountTendered.Visible = true;
                lblChange.Visible = true;
                changeTextBox.Visible = true;
                lblAmountMes.Visible = true;
                txtAmountTendered.Enabled = true;
                changeTextBox.Text = "R 0.00";
                lblAmountMes.Text = "";
            }
        }

        // ---------------------------------------------------------------
        // LIVE VALIDATION
        // ---------------------------------------------------------------
        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmountTendered.Text, out decimal amount))
            {
                decimal change = amount - _orderTotal;
                changeTextBox.Text = change >= 0 ? "R " + change.ToString("0.00") : "Insufficient";
            }
            else
            {
                changeTextBox.Text = "R 0.00";
            }

            ValidateAmountTendered();
        }

        // ---------------------------------------------------------------
        // CONFIRM PAYMENT BUTTON
        // ---------------------------------------------------------------
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!rbCash.Checked && !rbCard.Checked)
            {
                MessageBox.Show("Please select a payment method (Cash or Card).",
                    "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbCash.Checked && !ValidateAmountTendered())
            {
                txtAmountTendered.Focus();
                return;
            }

            decimal amountTendered = 0;
            decimal change = 0;

            if (rbCash.Checked)
            {
                decimal.TryParse(txtAmountTendered.Text, out amountTendered);
                change = amountTendered - _orderTotal;
            }
            else if (rbCard.Checked)
            {
                amountTendered = _orderTotal;
                change = 0;
            }

            string paymentMethod = rbCash.Checked ? "Cash" : "Card";

            try
            {
                string query = @"UPDATE [OrderTable] 
                                 SET PaymentMethod = @method, 
                                     TotalChangeDue = @change, 
                                     OrderStatus = 'Completed' 
                                 WHERE OrderID = @orderID";

                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@method", paymentMethod);
                    cmd.Parameters.AddWithValue("@change", change);
                    cmd.Parameters.AddWithValue("@orderID", _orderID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                if (rbCard.Checked)
                {
                    MessageBox.Show(
                        "Card payment approved!\n\n" +
                        "Order #: " + _orderID + "\n" +
                        "Total:   R " + _orderTotal.ToString("0.00") + "\n" +
                        "Payment: Card (Approved)",
                        "Payment Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Payment confirmed!\n\n" +
                        "Order #: " + _orderID + "\n" +
                        "Total:   R " + _orderTotal.ToString("0.00") + "\n" +
                        "Paid:    R " + amountTendered.ToString("0.00") + "\n" +
                        "Change:  R " + change.ToString("0.00"),
                        "Payment Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                //NEW 3
                SendReceiptEmail(_orderID, _orderTotal, amountTendered, change, paymentMethod);

                //NEW 2
                // Create receipt object but NEVER show the form
                frmReceipt formR = new frmReceipt(_orderID, _orderTotal, amountTendered, change, paymentMethod);
                formR.PopulateReceiptData();          // necessary because form is never shown
                
                formR.ShowPrintPreview();             // opens Print Preview (modal)

                // This code only runs AFTER the user closes the Print Preview
                formR.Dispose();

                // Clean up previous screens
                if (this.Owner != null)
                {
                    ((frmNewOrder)this.Owner).ResetOrder();
                    this.Owner.Close();
                }
                this.Close();

                // Go to Main
                frmMain mainForm = new frmMain();
                mainForm.Show();


                /*((frmNewOrder)this.Owner).ResetOrder();
                ((frmNewOrder)this.Owner).Close();

                this.Close();

                frmReceipt formR = new frmReceipt(_orderID, _orderTotal, amountTendered, change, paymentMethod);
                formR.Show();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        // CANCEL BUTTON
        // ---------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this payment?",
                "Cancel Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (this.Owner != null)
                {
                    this.Owner.Show();
                }

                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        /* private void button1_Click(object sender, EventArgs e)
         {
             frmTodaysOrders orders = new frmTodaysOrders();
             orders.Show();
         }

         private void label1_Click(object sender, EventArgs e)
         {
         }

         private void button1_Click_1(object sender, EventArgs e)
         {
             frmTodaysOrders orders = new frmTodaysOrders();
             orders.Show();
         }

         /* private void btnHelp_Click(object sender, EventArgs e)
          {

          }*/

        // ---------------------------------------------------------------
        // GET CUSTOMER EMAIL FROM DATABASE
        // ---------------------------------------------------------------
        private string GetCustomerEmail(int orderID)
        {
            string email = null;
            string query = @"SELECT c.Email
                     FROM [OrderTable] o
                     JOIN CustomerTable c ON o.CustomerID = c.CustomerID
                     WHERE o.OrderID = @orderID";

            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    email = result.ToString().Trim();
            }
            return email;
        }

        // ---------------------------------------------------------------
        // CREATE PDF RECEIPT + SEND EMAIL
        // ---------------------------------------------------------------
        // ---------------------------------------------------------------
        // CREATE PDF RECEIPT + SEND EMAIL  (FIXED)
        // ---------------------------------------------------------------
        private void SendReceiptEmail(int orderID, decimal orderTotal, decimal amountPaid,
                                      decimal change, string paymentMethod)
        {
            string customerEmail = GetCustomerEmail(orderID);

            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                return; // No email on file – skip silently
            }

            string pdfPath = Path.Combine(Path.GetTempPath(),
                $"Receipt_{orderID}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            string customerName = "";
            string cashierName = "";
            DataTable items = new DataTable();

            // Load customer, cashier and items
            string queryInfo = @"SELECT
                            c.FirstName + ' ' + c.Surname AS CustomerName,
                            e.FirstName + ' ' + e.Surname AS CashierName
                         FROM [OrderTable] o
                         JOIN CustomerTable c ON o.CustomerID = c.CustomerID
                         JOIN EmployeeTable e ON o.EmployeeID = e.EmployeeID
                         WHERE o.OrderID = @orderID";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryInfo, conn))
                {
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerName = reader["CustomerName"].ToString();
                            cashierName = reader["CashierName"].ToString();
                        }
                    }
                }

                string queryItems = @"SELECT
                                m.MenuItemName,
                                io.QuantityOrdered,
                                m.SellingPrice,
                                io.Subtotal
                             FROM ItemOrder io
                             JOIN MenuItemsTable m ON io.MenuItemID = m.MenuItemID
                             WHERE io.OrderID = @orderID";

                using (SqlCommand cmd = new SqlCommand(queryItems, conn))
                {
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(items);
                    }
                }
            }

            // ===== Generate PDF =====
            using (iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40, 40, 40, 40))
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();

                // Fully qualified fonts to avoid conflict with System.Drawing.Font
                iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.COURIER_BOLD, 14);
                iTextSharp.text.Font boldFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.COURIER_BOLD, 10);
                iTextSharp.text.Font normalFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.COURIER, 10);
                iTextSharp.text.Font smallFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.COURIER, 9);

                doc.Add(new iTextSharp.text.Paragraph("CAFE 101", titleFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                doc.Add(new iTextSharp.text.Paragraph("CUSTOMER TRANSACTION RECEIPT", boldFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                doc.Add(new iTextSharp.text.Paragraph("479 Varsity Road, Durban, KZN", smallFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                doc.Add(new iTextSharp.text.Paragraph("Tel: 031 896 0230 | VAT No: 4123456789", smallFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                doc.Add(new iTextSharp.text.Paragraph("----------------------------------------"));

                doc.Add(new iTextSharp.text.Paragraph($"Order ID:          {orderID}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph($"Date & Time:       {DateTime.Now:dd MMM yyyy HH:mm}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph($"Cashier:           {cashierName}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph($"Customer:          {customerName}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph("----------------------------------------"));

                doc.Add(new iTextSharp.text.Paragraph("Item                      Qty    Price     Subtotal", boldFont));
                doc.Add(new iTextSharp.text.Paragraph("----------------------------------------"));

                foreach (DataRow row in items.Rows)
                {
                    string name = row["MenuItemName"].ToString();
                    if (name.Length > 22) name = name.Substring(0, 22);

                    string line = string.Format("{0,-24} {1,3}  R{2,7:0.00}  R{3,7:0.00}",
                        name,
                        Convert.ToInt32(Convert.ToDecimal(row["QuantityOrdered"])),
                        Convert.ToDecimal(row["SellingPrice"]),
                        Convert.ToDecimal(row["Subtotal"]));

                    doc.Add(new iTextSharp.text.Paragraph(line, smallFont));
                }

                doc.Add(new iTextSharp.text.Paragraph("----------------------------------------"));
                doc.Add(new iTextSharp.text.Paragraph($"Payment Method:    {paymentMethod}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph($"Total Amount:      R {orderTotal:0.00}", boldFont));
                doc.Add(new iTextSharp.text.Paragraph($"Amount Paid:       R {amountPaid:0.00}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph(
                    $"Change Due:        {(paymentMethod == "Card" ? "N/A" : "R " + change.ToString("0.00"))}", normalFont));
                doc.Add(new iTextSharp.text.Paragraph("----------------------------------------"));
                doc.Add(new iTextSharp.text.Paragraph("Thank you for dining at Cafe 101!", boldFont)
                { Alignment = iTextSharp.text.Element.ALIGN_CENTER });

                doc.Close();
            }

            // ===== Send the email =====
            try
            {
                string fromEmail = "mayisesnakhokonke7@gmail.com";
                string appPassword = "nkwl wept pruf ljyk";   // ← change to a NEW app password!

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail, "Cafe 101");
                    mail.To.Add(customerEmail);
                    mail.Subject = $"Cafe 101 Receipt – Order #{orderID}";
                    mail.Body = "Thank you for dining at Cafe 101.\n\nPlease find your receipt attached.";
                    mail.Attachments.Add(new Attachment(pdfPath));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                        smtp.Send(mail);
                    }
                }

                try { File.Delete(pdfPath); } catch { }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Payment was successful, but the receipt email could not be sent from this device.",
                    "Receipt Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (helpVisible)
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
                return;
            }

            string stepTitle;
            string stepDetail;

            if (!rbCash.Checked && !rbCard.Checked)
            {
                // Step 1 — No payment method selected
                stepTitle = "📋 Checkout Guide — Step 1 of 3";
                stepDetail =
                    "FORM OVERVIEW\r\n" +
                    "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                    "This form processes payment for the\r\n" +
                    "selected order before issuing a receipt.\r\n\r\n" +

                    "ORDER ID\r\n" +
                    "  The unique number assigned to this\r\n" +
                    "  order. Read-only — for reference only.\r\n\r\n" +

                    "ORDER TOTAL\r\n" +
                    "  The full amount owed by the customer.\r\n" +
                    "  Calculated from the order items.\r\n\r\n" +

                    "PAYMENT METHOD  ← You are here\r\n" +
                    "  • Cash  — Customer pays with notes/coins.\r\n" +
                    "             You will enter the amount given\r\n" +
                    "             and change is auto-calculated.\r\n" +
                    "  • Card  — Customer pays by debit/credit.\r\n" +
                    "             No change required. Payment is\r\n" +
                    "             assumed approved immediately.\r\n\r\n" +

                    "💡 Select Cash or Card to proceed.";
            }
            else if (rbCash.Checked && string.IsNullOrWhiteSpace(txtAmountTendered.Text))
            {
                // Step 2 — Cash selected, no amount entered
                stepTitle = "📋 Checkout Guide — Step 2 of 3";
                stepDetail =
                    "Payment Method: Cash ✔\r\n" +
                    "Order Total: " + totalTxt.Text + "\r\n" +
                    "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n\r\n" +

                    "AMOUNT TENDERED  ← You are here\r\n" +
                    "  Enter the cash amount the customer\r\n" +
                    "  hands over. Rules:\r\n" +
                    "  • Numbers only (e.g. 250 or 250.50)\r\n" +
                    "  • Must be greater than zero\r\n" +
                    "  • Must cover the full order total\r\n" +
                    "  • Field turns green ✔ when valid\r\n" +
                    "  • Field turns red ⚠ when invalid\r\n\r\n" +

                    "CHANGE\r\n" +
                    "  Updates automatically as you type.\r\n" +
                    "  Shows the exact amount to hand back.\r\n" +
                    "  Displays 'Insufficient' if the amount\r\n" +
                    "  entered does not cover the total.\r\n\r\n" +

                    "💡 Enter the cash amount to proceed.";
            }
            else
            {
                // Step 3 — Ready to confirm
                string method = rbCard.Checked ? "Card" : "Cash";
                stepTitle = "📋 Checkout Guide — Step 3 of 3";
                stepDetail =
                    "Payment Method: " + method + " ✔\r\n" +
                    "Order Total: " + totalTxt.Text + "\r\n" +       
                    (rbCash.Checked ? "  |  Change: " + changeTextBox.Text : "") + "\r\n" +
                    "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n\r\n" +

                    "CONFIRM PAYMENT  ← Action required\r\n" +
                    "  Finalises and records the payment.\r\n" +
                    "  This will:\r\n" +
                    "  • Save the payment method to the order\r\n" +
                    "  • Mark the order status as Completed\r\n" +
                    "  • Automatically open the receipt\r\n" +
                    "  • Reset the order screen for next order\r\n\r\n" +

                    "CANCEL PAYMENT\r\n" +
                    "  Cancels this checkout session and\r\n" +
                    "  returns you to the New Order screen.\r\n" +
                    "  The order will NOT be marked complete.\r\n\r\n" +

                    "TODAY'S ORDERS\r\n" +
                    "  Opens a read-only list of all orders\r\n" +
                    "  processed today. Use for reference\r\n" +
                    "  without affecting the current checkout.\r\n\r\n" +

                    "💡 Press Confirm Payment when ready.";
            }

            if (pnlHelp == null)
            {
                pnlHelp = new Panel();
                pnlHelp.Size = new System.Drawing.Size(345, 420);
                pnlHelp.BackColor = System.Drawing.Color.FromArgb(15, 30, 80);
                pnlHelp.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlHelp);
                pnlHelp.BringToFront();
            }

            pnlHelp.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = stepTitle;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(12, 10);
            lblTitle.Size = new System.Drawing.Size(320, 22);

            Label lblDivider = new Label();
            lblDivider.Text = "";
            lblDivider.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            lblDivider.Location = new System.Drawing.Point(12, 36);
            lblDivider.Size = new System.Drawing.Size(318, 2);

            Label lblDetail = new Label();
            lblDetail.Text = stepDetail;
            lblDetail.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            lblDetail.ForeColor = System.Drawing.Color.LightGray;
            lblDetail.Location = new System.Drawing.Point(12, 46);
            lblDetail.Size = new System.Drawing.Size(318, 330);

            Button btnClose = new Button();
            btnClose.Text = "✕ Close Help";
            btnClose.Size = new System.Drawing.Size(110, 28);
            btnClose.Location = new System.Drawing.Point(222, 383);
            btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) =>
            {
                pnlHelp.Visible = false;
                helpVisible = false;
                btnHelp.Text = "? Help";
            };

            pnlHelp.Controls.Add(lblTitle);
            pnlHelp.Controls.Add(lblDivider);
            pnlHelp.Controls.Add(lblDetail);
            pnlHelp.Controls.Add(btnClose);

            pnlHelp.Location = new System.Drawing.Point(
                btnHelp.Left - pnlHelp.Width + btnHelp.Width,
                btnHelp.Top - pnlHelp.Height - 5);

            pnlHelp.Visible = true;
            helpVisible = true;
            btnHelp.Text = "? Help (ON)";
        }
    }
}