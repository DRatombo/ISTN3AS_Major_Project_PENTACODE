using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe101
{
    public partial class frmManageIngredients : Form
    {
        public frmManageIngredients()
        {
            InitializeComponent();
        }

        private void frmManageIngredients_Load(object sender, EventArgs e)
        {
            LoadIngredients();
        }

        private void LoadIngredients()
        {
            // Column order: IngredientID, QuantityInStock, RestockLevel, Description, Units, CostPrice
            string query = "SELECT IngredientID, QuantityInStock, RestockLevel, Description, Units, CostPrice FROM Ingredient ORDER BY Description";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvIngredients.DataSource = dt;

                    // Hide ID column (index 0)
                    if (dgvIngredients.Columns.Count > 0)
                        dgvIngredients.Columns[0].Visible = false;

                    // Format numeric columns using indexes
                    if (dgvIngredients.Columns.Count > 1)
                        dgvIngredients.Columns[1].DefaultCellStyle.Format = "N2";  // QuantityInStock
                    if (dgvIngredients.Columns.Count > 2)
                        dgvIngredients.Columns[2].DefaultCellStyle.Format = "N2";  // RestockLevel
                    if (dgvIngredients.Columns.Count > 5)
                        dgvIngredients.Columns[5].DefaultCellStyle.Format = "C2";  // CostPrice

                    // Highlight low stock rows (QuantityInStock <= RestockLevel) using indexes
                    foreach (DataGridViewRow row in dgvIngredients.Rows)
                    {
                        if (row.IsNewRow) continue;
                        decimal qty = Convert.ToDecimal(row.Cells[1].Value);
                        decimal restock = Convert.ToDecimal(row.Cells[2].Value);
                        if (qty <= restock)
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading ingredients: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            txtDescription.Text = "";
            numQuantityInStock.Value = 0;
            numRestockLevel.Value = 0;
            txtUnits.Text = "";
            numCostPrice.Value = 0;
            btnUpdate.Tag = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter an ingredient description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Ingredient (QuantityInStock, RestockLevel, Description, Units, CostPrice)
                             VALUES (@qty, @restock, @desc, @units, @cost)";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@qty", numQuantityInStock.Value);
                    cmd.Parameters.AddWithValue("@restock", numRestockLevel.Value);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@units", txtUnits.Text.Trim());
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("Ingredient added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIngredients();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvIngredients.Rows[e.RowIndex];

            // Use column indexes (matching SELECT order)
            // Index 0: IngredientID, 1: QuantityInStock, 2: RestockLevel, 3: Description, 4: Units, 5: CostPrice
            txtDescription.Text = row.Cells[3].Value?.ToString() ?? "";
            txtUnits.Text = row.Cells[4].Value?.ToString() ?? "";
            numQuantityInStock.Value = Convert.ToDecimal(row.Cells[1].Value);
            numRestockLevel.Value = Convert.ToDecimal(row.Cells[2].Value);
            numCostPrice.Value = Convert.ToDecimal(row.Cells[5].Value);
            btnUpdate.Tag = row.Cells[0].Value;   // IngredientID
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an ingredient to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"UPDATE Ingredient
                             SET Description = @desc, QuantityInStock = @qty, RestockLevel = @restock, Units = @units, CostPrice = @cost
                             WHERE IngredientID = @id";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@qty", numQuantityInStock.Value);
                    cmd.Parameters.AddWithValue("@restock", numRestockLevel.Value);
                    cmd.Parameters.AddWithValue("@units", txtUnits.Text.Trim());
                    cmd.Parameters.AddWithValue("@cost", numCostPrice.Value);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Ingredient updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIngredients();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Tag == null)
            {
                MessageBox.Show("Select an ingredient to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Delete this ingredient? This cannot be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            string query = "DELETE FROM Ingredient WHERE IngredientID = @id";
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(btnUpdate.Tag));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Ingredient removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIngredients();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Remove failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIngredients();
            ClearFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmMain();
            form.Show();
            this.Close();
        }
    }
}