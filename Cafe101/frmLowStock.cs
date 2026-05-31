using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Cafe101
{
    public partial class frmLowStock : Form
    {
        public frmLowStock()
        {
            InitializeComponent();
        }
        private PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void frmLowStock_Load(object sender, EventArgs e)
        {
            int count = 0;

            try
            {
                this.testIngredientTableAdapter.Fill(this.dsCafe101Test.TestIngredient);

                var ingredients = dsCafe101Test.TestIngredient.AsEnumerable();

                var lowStock = ingredients.Where(r =>
                {
                    double qty = Convert.ToDouble(r["QuantityOnHand"]);
                    double restock = Convert.ToDouble(r["RestockLevel"]);

                    return qty < restock;
                }).ToList(); // IMPORTANT

                count = lowStock.Count; // SAFE MANUAL COUNT

                dataGridView1.DataSource = lowStock.Any()
                    ? lowStock.CopyToDataTable()
                    : null;

                textBox1.Text = count.ToString();

                SetupGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock items:\n\n" + ex.Message);
            }
        }
        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Columns.Contains("IngredientID"))
                dataGridView1.Columns["IngredientID"].Visible = false;
        }

        private void btnPrintLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                printRowIndex = 0;

                printDocument.PrintPage -= PrintPageHandler;
                printDocument.PrintPage += PrintPageHandler;

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDocument;
                preview.Width = 1000;
                preview.Height = 700;

                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print error:\n\n" + ex.Message);
            }
        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font font = new Font("Arial", 10);

                int x = 50;
                int y = 50;
                int lineHeight = 25;

                // HEADER
                e.Graphics.DrawString("LOW STOCK REPORT", titleFont, Brushes.Black, x, y);
                y += 40;

                // COLUMN HEADERS
                e.Graphics.DrawString("Ingredient", font, Brushes.Black, x, y);
                e.Graphics.DrawString("Qty", font, Brushes.Black, x + 250, y);
                e.Graphics.DrawString("Restock Level", font, Brushes.Black, x + 350, y);

                y += 30;

                // PRINT ROWS
                while (printRowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[printRowIndex];

                    if (!row.IsNewRow)
                    {
                        string name = row.Cells[1].Value?.ToString();
                        string qty = row.Cells[2].Value?.ToString();
                        string restock = row.Cells[3].Value?.ToString();

                        e.Graphics.DrawString(name, font, Brushes.Black, x, y);
                        e.Graphics.DrawString(qty, font, Brushes.Black, x + 250, y);
                        e.Graphics.DrawString(restock, font, Brushes.Black, x + 350, y);

                        y += lineHeight;
                    }

                    printRowIndex++;

                    // PAGE BREAK
                    if (y > 700)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
                printRowIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print error:\n\n" + ex.Message);
            }
        }
    }
}
