using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmPopularProduct : Form
    {
        public frmPopularProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmPopularProduct_Load(object sender, EventArgs e)
        {
            try
            {
                this.topSellingItemTableAdapter1.FillByTopSellingItem(this.dsCafe101Hub.TopSellingItem);

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 0)
                {
                    textBox1.Text = dsCafe101Hub.TopSellingItem.Rows[0]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 1)
                {
                    textBox2.Text = dsCafe101Hub.TopSellingItem.Rows[1]["MenuItemName"].ToString();
                }

                if (dsCafe101Hub.TopSellingItem.Rows.Count > 2)
                {
                    textBox3.Text = dsCafe101Hub.TopSellingItem.Rows[2]["MenuItemName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading popular products:\n" + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }
    }
}
