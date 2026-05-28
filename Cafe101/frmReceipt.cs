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
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
