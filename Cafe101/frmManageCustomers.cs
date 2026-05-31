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
    public partial class frmManageCustomers : Form
    {
        public frmManageCustomers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BACK_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCafe101Test.TestCustomer' table. You can move, or remove it, as needed.
            this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            testCustomerTableAdapter.FillBySearch(dsCafe101Test.TestCustomer,textBox1.Text );
        }
    }
}
