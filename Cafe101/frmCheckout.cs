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

                ((frmNewOrder)this.Owner).ResetOrder();
                ((frmNewOrder)this.Owner).Close();

                this.Close();

                frmReceipt formR = new frmReceipt(_orderID, _orderTotal, amountTendered, change, paymentMethod);
                formR.Show();
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

        private void button1_Click(object sender, EventArgs e)
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