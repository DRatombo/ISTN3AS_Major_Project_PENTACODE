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
            // TODO: This line of code loads data into the 'dsCafe101Test.TopSellingItem' table. You can move, or remove it, as needed.
            this.topSellingItemTableAdapter.FillByTopSellingItem(this.dsCafe101Test.TopSellingItem);

        }
    }
}
