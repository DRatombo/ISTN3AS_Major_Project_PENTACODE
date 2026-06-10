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
                this.Close();
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
    }
}