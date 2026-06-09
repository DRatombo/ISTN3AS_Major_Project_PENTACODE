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
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 10);

            Pen gridPen = Pens.Black;

            int startX = 50;
            int startY = 50;
            int rowHeight = 30;
            int cellWidth = 180;

            int x = startX;
            int y = startY;

            // Report Title
            e.Graphics.DrawString("LOW STOCK REPORT", titleFont, Brushes.Black, x, y);

            y += 50;

            // Print Column Headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (!column.Visible)
                    continue;

                Rectangle rect = new Rectangle(x, y, cellWidth, rowHeight);

                e.Graphics.DrawRectangle(gridPen, rect);

                e.Graphics.DrawString(
                    column.HeaderText,
                    headerFont,
                    Brushes.Black,
                    rect,
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                x += cellWidth;
            }

            y += rowHeight;

            // Print Data Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                x = startX;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!dataGridView1.Columns[cell.ColumnIndex].Visible)
                        continue;

                    Rectangle rect = new Rectangle(x, y, cellWidth, rowHeight);

                    e.Graphics.DrawRectangle(gridPen, rect);

                    string value = cell.Value?.ToString() ?? "";

                    e.Graphics.DrawString(
                        value,
                        cellFont,
                        Brushes.Black,
                        rect,
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });

                    x += cellWidth;
                }

                y += rowHeight;

                // Simple page break
                if (y > e.MarginBounds.Bottom - rowHeight)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // Low Stock Count at Bottom
            y += 20;

            e.Graphics.DrawString(
                "Total Low Stock Items: " + textBox1.Text,
                headerFont,
                Brushes.Black,
                startX,
                y);

            e.HasMorePages = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
