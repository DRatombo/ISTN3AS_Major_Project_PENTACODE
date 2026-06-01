using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmReceipt : Form
    {
        private int _orderID;
        private decimal _orderTotal;
        private decimal _amountPaid;
        private decimal _change;
        private string _paymentMethod;

        public frmReceipt(int orderID, decimal orderTotal, decimal amountPaid, decimal change, string paymentMethod)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _orderID = orderID;
            _orderTotal = orderTotal;
            _amountPaid = amountPaid;
            _change = change;
            _paymentMethod = paymentMethod;
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            orderIDTxt.Text = _orderID.ToString();
            dateTxt.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            payTxt.Text = _paymentMethod;
            totTxt.Text = "R " + _orderTotal.ToString("0.00");
            amountTxt.Text = "R " + _amountPaid.ToString("0.00");
            changeTxt.Text = _paymentMethod == "Card" ? "N/A" : "R " + _change.ToString("0.00");

            LoadCustomerAndCashier();
        }

        private void LoadCustomerAndCashier()
        {
            try
            {
                string query = @"SELECT 
                            c.FirstName + ' ' + c.Surname AS CustomerName,
                            e.FirstName + ' ' + e.Surname AS CashierName
                         FROM [TestOrder] o
                         JOIN TestCustomer c ON o.CustomerID = c.CustomerID
                         JOIN TestEmployee e ON o.EmployeeID = e.EmployeeID
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void custTxt_TextChanged(object sender, EventArgs e)
        {
        }
    }
}