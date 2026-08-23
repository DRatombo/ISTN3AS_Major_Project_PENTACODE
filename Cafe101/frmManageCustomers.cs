using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Cmp;

namespace Cafe101
{
    public partial class frmManageCustomers : Form
    {
        private int selectedCustomerID = 0;
        private Label lblFirstNameStatus;
        private Label lblSurnameStatus;
        private Label lblEmailStatus;
        private Label lblAddressStatus;
        private Label lblPasswordStatus;
        private DataTable originalCustomerData;
        private Timer searchTimer;

        public frmManageCustomers()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            CreateStatusLabels();
            AttachValidationEvents();
            SetupDataGridView();
            SetupSearchTimer();
        }

        private void SetupDataGridView()
        {
            // Make DataGridView fill the form horizontally
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Auto-size columns to fill the available space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // DYNAMIC SEARCH WITH TIMER
        // ============================================================
        private void SetupSearchTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 300; // 300ms delay before searching
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                if (originalCustomerData == null) return;

                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    // Show all data
                    dataGridView1.DataSource = originalCustomerData;
                    dataGridView1.Refresh();
                }
                else
                {
                    // Filter the data using DataView
                    DataView dv = originalCustomerData.DefaultView;
                    dv.RowFilter = $"FirstName LIKE '%{searchTerm}%' OR Surname LIKE '%{searchTerm}%' OR Email LIKE '%{searchTerm}%'";
                    dataGridView1.DataSource = dv;
                    dataGridView1.Refresh();
                }

                // Hide CustomerID column if it exists
                if (dataGridView1.Columns.Contains("CustomerID"))
                {
                    dataGridView1.Columns["CustomerID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Silent fail for search
                System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
            }
        }

        private void CreateStatusLabels()
        {
            // First Name Status - directly underneath the textbox with more gap
            lblFirstNameStatus = new Label();
            lblFirstNameStatus.AutoSize = true;
            lblFirstNameStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirstNameStatus.ForeColor = Color.Black;
            lblFirstNameStatus.Location = new Point(txtFirstName.Location.X, txtFirstName.Location.Y + txtFirstName.Height + 20);
            lblFirstNameStatus.Name = "lblFirstNameStatus";
            lblFirstNameStatus.Size = new Size(20, 15);
            lblFirstNameStatus.Text = "";
            lblFirstNameStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblFirstNameStatus.TabIndex = 100;
            this.Controls.Add(lblFirstNameStatus);

            // Surname Status - directly underneath the textbox with more gap
            lblSurnameStatus = new Label();
            lblSurnameStatus.AutoSize = true;
            lblSurnameStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSurnameStatus.ForeColor = Color.Black;
            lblSurnameStatus.Location = new Point(txtSurname.Location.X, txtSurname.Location.Y + txtSurname.Height + 20);
            lblSurnameStatus.Name = "lblSurnameStatus";
            lblSurnameStatus.Size = new Size(20, 15);
            lblSurnameStatus.Text = "";
            lblSurnameStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblSurnameStatus.TabIndex = 101;
            this.Controls.Add(lblSurnameStatus);

            // Email Status - directly underneath the textbox with more gap
            lblEmailStatus = new Label();
            lblEmailStatus.AutoSize = true;
            lblEmailStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmailStatus.ForeColor = Color.Black;
            lblEmailStatus.Location = new Point(txtEmail.Location.X, txtEmail.Location.Y + txtEmail.Height + 20);
            lblEmailStatus.Name = "lblEmailStatus";
            lblEmailStatus.Size = new Size(20, 15);
            lblEmailStatus.Text = "";
            lblEmailStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblEmailStatus.TabIndex = 102;
            this.Controls.Add(lblEmailStatus);

            // Address Status - directly underneath the textbox with more gap
            lblAddressStatus = new Label();
            lblAddressStatus.AutoSize = true;
            lblAddressStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddressStatus.ForeColor = Color.Black;
            lblAddressStatus.Location = new Point(txtAddress.Location.X, txtAddress.Location.Y + txtAddress.Height + 20);
            lblAddressStatus.Name = "lblAddressStatus";
            lblAddressStatus.Size = new Size(20, 15);
            lblAddressStatus.Text = "";
            lblAddressStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblAddressStatus.TabIndex = 103;
            this.Controls.Add(lblAddressStatus);

            // Password Status - directly underneath the textbox with more gap
            lblPasswordStatus = new Label();
            lblPasswordStatus.AutoSize = true;
            lblPasswordStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPasswordStatus.ForeColor = Color.Black;
            lblPasswordStatus.Location = new Point(txtPassword.Location.X, txtPassword.Location.Y + txtPassword.Height + 20);
            lblPasswordStatus.Name = "lblPasswordStatus";
            lblPasswordStatus.Size = new Size(20, 15);
            lblPasswordStatus.Text = "";
            lblPasswordStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblPasswordStatus.TabIndex = 104;
            this.Controls.Add(lblPasswordStatus);

            // Bring status labels to front
            lblFirstNameStatus.BringToFront();
            lblSurnameStatus.BringToFront();
            lblEmailStatus.BringToFront();
            lblAddressStatus.BringToFront();
            lblPasswordStatus.BringToFront();
        }

        private void AttachValidationEvents()
        {
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            txtSurname.TextChanged += txtSurname_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtAddress.TextChanged += txtAddress_TextChanged;
        }

        // ============================================================
        // VALIDATION METHODS
        // ============================================================

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidateFirstName();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            ValidateSurname();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateAddress();
        }

        private bool ValidateFirstName()
        {
            string value = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                lblFirstNameStatus.Text = "⚠️ Required";
                lblFirstNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    txtFirstName.BackColor = Color.FromArgb(255, 220, 220);
                    lblFirstNameStatus.Text = "⚠️ Letters only";
                    lblFirstNameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            txtFirstName.BackColor = Color.FromArgb(220, 245, 220);
            lblFirstNameStatus.Text = "✓";
            lblFirstNameStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateSurname()
        {
            string value = txtSurname.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                lblSurnameStatus.Text = "⚠️ Required";
                lblSurnameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    txtSurname.BackColor = Color.FromArgb(255, 220, 220);
                    lblSurnameStatus.Text = "⚠️ Letters only";
                    lblSurnameStatus.ForeColor = Color.FromArgb(255, 80, 80);
                    return false;
                }
            }

            txtSurname.BackColor = Color.FromArgb(220, 245, 220);
            lblSurnameStatus.Text = "✓";
            lblSurnameStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Required";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            int atIndex = email.IndexOf('@');
            if (atIndex < 1)
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Missing '@'";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            int dotIndex = email.IndexOf('.', atIndex);
            if (dotIndex < atIndex + 2 || dotIndex >= email.Length - 1)
            {
                txtEmail.BackColor = Color.FromArgb(255, 220, 220);
                lblEmailStatus.Text = "⚠️ Invalid domain";
                lblEmailStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtEmail.BackColor = Color.FromArgb(220, 245, 220);
            lblEmailStatus.Text = "✓";
            lblEmailStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidatePassword()
        {
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordStatus.Text = "⚠️ Required";
                lblPasswordStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (password.Length < 4)
            {
                txtPassword.BackColor = Color.FromArgb(255, 220, 220);
                lblPasswordStatus.Text = "⚠️ Min 4 chars";
                lblPasswordStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtPassword.BackColor = Color.FromArgb(220, 245, 220);
            lblPasswordStatus.Text = "✓";
            lblPasswordStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool ValidateAddress()
        {
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(address))
            {
                txtAddress.BackColor = Color.FromArgb(255, 220, 220);
                lblAddressStatus.Text = "⚠️ Required";
                lblAddressStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            bool hasDigit = false;
            foreach (char c in address)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                    break;
                }
            }

            int commaCount = 0;
            foreach (char c in address)
            {
                if (c == ',') commaCount++;
            }

            if (!hasDigit)
            {
                txtAddress.BackColor = Color.FromArgb(255, 220, 220);
                lblAddressStatus.Text = "⚠️ Missing number";
                lblAddressStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            if (commaCount < 2)
            {
                txtAddress.BackColor = Color.FromArgb(255, 220, 220);
                lblAddressStatus.Text = "⚠️ Need commas";
                lblAddressStatus.ForeColor = Color.FromArgb(255, 80, 80);
                return false;
            }

            txtAddress.BackColor = Color.FromArgb(220, 245, 220);
            lblAddressStatus.Text = "✓";
            lblAddressStatus.ForeColor = Color.FromArgb(50, 180, 100);
            return true;
        }

        private bool IsFormValid()
        {
            return ValidateFirstName() && ValidateSurname() && ValidateEmail() && ValidatePassword() && ValidateAddress();
        }

        // ============================================================
        // END OF VALIDATION METHODS
        // ============================================================

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsCafe101Hub.EnforceConstraints = false;
                this.customerTableTableAdapter.Fill(this.dsCafe101Hub.CustomerTable);

                // Store the original data for searching
                originalCustomerData = dsCafe101Hub.CustomerTable;

                dsCafe101Hub.CustomerTable.PasswordColumn.DefaultValue = "1234";

                if (dataGridView1.Columns.Contains("CustomerID"))
                {
                    dataGridView1.Columns["CustomerID"].ReadOnly = true;
                    dataGridView1.Columns["CustomerID"].Visible = false;
                }

                // Initialize Status ComboBox
                cmbStatus.SelectedIndex = 0;

                // Attach search event
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error:\n" + ex.Message);
            }
        }

        // ============================================================
        // DYNAMIC SEARCH - UPDATED
        // ============================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Restart the timer on each keystroke
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ClearFields();
            RefreshData();
            // Show the grid again
            dataGridView1.Visible = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                dsCafe101Hub.CustomerTable.Clear();
                customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);
                originalCustomerData = dsCafe101Hub.CustomerTable;
                dataGridView1.DataSource = originalCustomerData;
                dataGridView1.Visible = true;
                ClearFields();
                selectedCustomerID = 0;
                MessageBox.Show("Data refreshed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Refresh Error:\n" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the highlighted fields before adding.\n\nAddress must follow format: street number, suburb, city\n(e.g., 46 Lion Road, Amanzimtoti, Durban)",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create new row
                DataRow newRow = dsCafe101Hub.CustomerTable.NewRow();
                newRow["FirstName"] = txtFirstName.Text;
                newRow["Surname"] = txtSurname.Text;
                newRow["Email"] = txtEmail.Text;
                newRow["Address"] = txtAddress.Text;
                newRow["Password"] = txtPassword.Text;
                newRow["Status"] = cmbStatus.SelectedItem?.ToString() ?? "Active";

                dsCafe101Hub.CustomerTable.Rows.Add(newRow);

                // Update database
                customerTableTableAdapter.Update(dsCafe101Hub.CustomerTable);

                MessageBox.Show("Customer added successfully.");
                RefreshData();
                ClearFields();
                // Show the grid again
                dataGridView1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error:\n" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomerID <= 0)
                {
                    MessageBox.Show("Please select a customer to update.");
                    return;
                }

                if (!IsFormValid())
                {
                    MessageBox.Show("Please correct the highlighted fields before updating.\n\nAddress must follow format: street number, suburb, city\n(e.g., 46 Lion Road, Amanzimtoti, Durban)",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to update this customer?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Find and update the row
                    DataRow[] rows = dsCafe101Hub.CustomerTable.Select($"CustomerID = {selectedCustomerID}");
                    if (rows.Length > 0)
                    {
                        rows[0]["FirstName"] = txtFirstName.Text;
                        rows[0]["Surname"] = txtSurname.Text;
                        rows[0]["Email"] = txtEmail.Text;
                        rows[0]["Address"] = txtAddress.Text;
                        rows[0]["Password"] = txtPassword.Text;
                        rows[0]["Status"] = cmbStatus.SelectedItem?.ToString() ?? "Active";

                        customerTableTableAdapter.Update(dsCafe101Hub.CustomerTable);
                        MessageBox.Show("Customer updated successfully.");
                        RefreshData();
                        ClearFields();
                        selectedCustomerID = 0;
                        // Show the grid again
                        dataGridView1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error:\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomerID <= 0)
                {
                    MessageBox.Show("Please select a customer to delete.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    MessageBox.Show("Please select a customer first.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    customerTableTableAdapter.DeleteByID(selectedCustomerID);
                    customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);
                    originalCustomerData = dsCafe101Hub.CustomerTable;
                    MessageBox.Show("Customer deleted successfully.");
                    RefreshData();
                    ClearFields();
                    selectedCustomerID = 0;
                    // Show the grid again
                    dataGridView1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error:\n" + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Customer Management Guide:\n\n" +
                "• Double-click a row to load customer details\n" +
                "• Add: Create a new customer\n" +
                "• Update: Modify selected customer\n" +
                "• Delete: Remove selected customer\n" +
                "• Refresh: Reload all data\n" +
                "• Search: Filter customers by name\n\n" +
                "VALIDATION RULES:\n" +
                "• First Name: Letters only, required\n" +
                "• Surname: Letters only, required\n" +
                "• Email: Must be valid format (name@domain.com)\n" +
                "• Password: Minimum 4 characters\n" +
                "• Address: Must include street number and commas\n" +
                "  Format: number street, suburb, city",
                "Help",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ============================================================
        // UPDATED: Hide DGV when customer is selected
        // ============================================================
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedCustomerID = Convert.ToInt32(row.Cells[0].Value);
                txtFirstName.Text = row.Cells[1].Value?.ToString() ?? "";
                txtSurname.Text = row.Cells[2].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells[3].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells[4].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells[5].Value?.ToString() ?? "";

                string status = row.Cells[6].Value?.ToString() ?? "Active";
                cmbStatus.SelectedItem = status;

                // ============================================================
                // HIDE THE DATA GRID VIEW WHEN A CUSTOMER IS SELECTED
                // ============================================================
                dataGridView1.Visible = false;

                // Clear search text to avoid confusion
                txtSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selection Error:\n" + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cmbStatus.SelectedIndex = 0;
            selectedCustomerID = 0;

            // Reset validation status
            txtFirstName.BackColor = Color.White;
            txtSurname.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            txtAddress.BackColor = Color.White;
            lblFirstNameStatus.Text = "";
            lblSurnameStatus.Text = "";
            lblEmailStatus.Text = "";
            lblPasswordStatus.Text = "";
            lblAddressStatus.Text = "";
        }

        private void RefreshData()
        {
            try
            {
                customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);
                originalCustomerData = dsCafe101Hub.CustomerTable;
                dataGridView1.DataSource = originalCustomerData;
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Refresh Error:\n" + ex.Message);
            }
        }

        public void RefreshCustomers()
        {
            customerTableTableAdapter.Fill(dsCafe101Hub.CustomerTable);
            originalCustomerData = dsCafe101Hub.CustomerTable;
            dataGridView1.DataSource = originalCustomerData;
            dataGridView1.Refresh();
            dataGridView1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID <= 0)
            {
                MessageBox.Show("Please select a customer first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Reset password for " + txtFirstName.Text + " " + txtSurname.Text + "?\n\nPassword will be reset to: temp123",
                "Confirm Password Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string newPassword = "temp123";

                    // Find and update the row
                    DataRow[] rows = dsCafe101Hub.CustomerTable.Select($"CustomerID = {selectedCustomerID}");
                    if (rows.Length > 0)
                    {
                        rows[0]["Password"] = newPassword;
                        customerTableTableAdapter.Update(dsCafe101Hub.CustomerTable);

                        MessageBox.Show($"Password has been reset to '{newPassword}'.\n\nPlease inform the customer to change their password upon next login.",
                            "Password Reset Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        txtPassword.Text = newPassword;
                        ValidatePassword();

                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Password reset failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}