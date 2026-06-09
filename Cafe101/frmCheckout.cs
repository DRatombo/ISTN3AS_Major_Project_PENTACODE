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

        //CASH SELECTED
        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            txtAmountTendered.Enabled = rbCash.Checked;
            txtAmountTendered.Text = "";
            changeTextBox.Text = rbCash.Checked ? "R 0.00" : "N/A";
            if (rbCash.Checked) txtAmountTendered.Focus();
        }

        private void rbCard_CheckedChanged(object sender, EventArgs e)
        {
            txtAmountTendered.Enabled = !rbCard.Checked;
            txtAmountTendered.Text = "";
            changeTextBox.Text = rbCard.Checked ? "N/A" : "R 0.00";
        }

        //CALCULATE CHANGE
        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmountTendered.Text, out decimal amount))
            {
                decimal change = amount - _orderTotal;
                if (change >= 0)
                    changeTextBox.Text = "R " + change.ToString("0.00");
                else
                    changeTextBox.Text = "Insufficient";
            }
            else
            {
                changeTextBox.Text = "R 0.00";
            }
        }
        //CONFIRM PAYMENT BUTTON
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Check payment method is selected
            if (!rbCash.Checked && !rbCard.Checked)
            {
                MessageBox.Show("Please select a payment method (Cash or Card).",
                    "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal amountTendered = 0;
            decimal change = 0;
            if (rbCash.Checked)
            {
                // Cash - validate amount entered
                if (!decimal.TryParse(txtAmountTendered.Text, out amountTendered))
                {
                    MessageBox.Show("Please enter a valid amount.",
                        "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (amountTendered < _orderTotal)
                {
                    MessageBox.Show("Amount tendered is less than the order total. Please enter a higher amount.",
                        "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                change = amountTendered - _orderTotal;
            }
            else if (rbCard.Checked)
            {
                // Card - assume payment always succeeds
                // Exact amount is charged, no change given
                amountTendered = _orderTotal;
                change = 0;
            }
            string paymentMethod = rbCash.Checked ? "Cash" : "Card";
            try
            {
                string query = @"UPDATE [TestOrder] 
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

                frmReceipt formR = new frmReceipt(_orderID, _orderTotal, amountTendered, change, paymentMethod);
                formR.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // CANCEL BUTTON
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