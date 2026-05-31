using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Drawing;             // For Graphics, Bitmap, Font
using System.Drawing.Printing;    // For PrintDocument
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // For the Chart control

namespace Cafe101
{
    public partial class frmSalesReport : Form
    {
        public frmSalesReport()
        {
            InitializeComponent();
        }
        // Store the data for printing
        private DataTable reportData;

        // Store the chart image
        private Bitmap chartBitmap;

        // PrintDocument instance
        private PrintDocument printDoc = new PrintDocument();

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Test.TestOrder' table. You can move, or remove it, as needed.
            this.testOrderTableAdapter.Fill(this.dsCafe101Test.TestOrder);

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;

                // Load filtered records
                this.testOrderTableAdapter.FillByDateRange(
                    this.dsCafe101Test.TestOrder,
                    fromDate,
                    toDate
                );

               

                // Calculate total revenue
                decimal totalRevenue = 0;

                foreach (DataRow row in dsCafe101Test.TestOrder.Rows)
                {
                    if (row["TotalAmountDue"] != DBNull.Value)
                    {
                        totalRevenue += Convert.ToDecimal(row["TotalAmountDue"]);
                    }
                }

                // Display in textbox
                textBox1.Text = totalRevenue.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }
    }
}
