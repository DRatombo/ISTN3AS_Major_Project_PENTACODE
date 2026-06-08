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
            try
            {
                this.testCustomerTableAdapter.Fill(this.dsCafe101Test.TestCustomer);

                dsCafe101Test.TestCustomer.PasswordColumn.DefaultValue = "1234";

                if (dataGridView1.Columns.Contains("CustomerID"))
                {
                    dataGridView1.Columns["CustomerID"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error:\n" + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            testCustomerTableAdapter.FillBySearch(dsCafe101Test.TestCustomer,textBox1.Text );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                dataGridView1.EndEdit();

                // Auto-fill password for new or empty rows
                foreach (DataRow row in dsCafe101Test.TestCustomer.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        if (row["Password"] == DBNull.Value ||
                            string.IsNullOrWhiteSpace(row["Password"]?.ToString()))
                        {
                            row["Password"] = "1234";
                        }
                    }
                }

                testCustomerTableAdapter.Update(dsCafe101Test.TestCustomer);
                testCustomerTableAdapter.Fill(dsCafe101Test.TestCustomer);

                MessageBox.Show("Saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            frmAddCustomer frmAddCustomer = new frmAddCustomer();
            frmAddCustomer.ShowDialog();   

        }
    }
}
