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
    public partial class frmTodaysOrders : Form
    {
        public frmTodaysOrders()
        {
            InitializeComponent();
        }

        private void frmTodaysOrders_Load(object sender, EventArgs e)
        {
            LoadTodaysOrders();
        }

        private void LoadTodaysOrders()
        {
            try
            {
                string query = @"SELECT 
                    o.OrderID,
                    c.FirstName + ' ' + c.Surname AS Customer,
                    o.OrderDatetime,
                    o.TotalAmountDue,
                    o.PaymentMethod,
                    o.OrderStatus
                 FROM [Order] o
                 JOIN Customer c ON o.CustomerID = c.CustomerID
                 WHERE CAST(o.OrderDatetime AS DATE) = CAST(GETDATE() AS DATE)
                 ORDER BY o.OrderDatetime DESC";

                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    orderDataGridView.DataSource = dt;
                }

                // Show total count
                numOrders.Text = "Date: " + DateTime.Now.ToString("dd MMM yyyy") +
                               "     Total Orders: " + orderDataGridView.Rows.Count;
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
    }
}
