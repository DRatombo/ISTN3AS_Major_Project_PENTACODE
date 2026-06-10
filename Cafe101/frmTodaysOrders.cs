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
    }
}