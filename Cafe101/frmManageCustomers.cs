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
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
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
            // TODO: This line of code loads data into the 'dsCafe101Hub.CustomerTable' table. You can move, or remove it, as needed.
            this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);
            try
            {
                this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);

                dsCafe101Hub.CustomerTable.PasswordColumn.DefaultValue = "1234";

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
            customerTableTableAdapter.FillByCustName(dsCafe101Hub.CustomerTable, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                dataGridView1.EndEdit();

                // Auto-fill password for new or empty rows
                foreach (DataRow row in dsCafe101Hub.CustomerTable.Rows)
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

                customerTableTableAdapter.Update(dsCafe101Hub.CustomerTable);
                customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private DataRow selectedRow;
        private int selectedCustomerID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedCustomerID = Convert.ToInt32(row.Cells[0].Value);

                txtName.Text = row.Cells[1].Value?.ToString();
                txtSurname.Text = row.Cells[2].Value?.ToString();
                txtAddress.Text = row.Cells[3].Value?.ToString();
                txtEmail.Text = row.Cells[4].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selection Error:\n" + ex.Message);
            }
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
               customerTableTableAdapter.DeleteByID(selectedCustomerID);

                customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);

                MessageBox.Show("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error:\n" + ex.Message);
            }
        }
    }
}
