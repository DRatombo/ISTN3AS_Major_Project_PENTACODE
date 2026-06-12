namespace Cafe101
{
    partial class frmManageIngredients
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.grpIngredientDetails = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescriptionStatus = new System.Windows.Forms.Label();
            this.lblQuantityInStock = new System.Windows.Forms.Label();
            this.numQuantityInStock = new System.Windows.Forms.NumericUpDown();
            this.lblRestockLevel = new System.Windows.Forms.Label();
            this.numRestockLevel = new System.Windows.Forms.NumericUpDown();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.numCostPrice = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.grpIngredientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlSearch, 0, 0);
            this.tblMain.Controls.Add(this.dgvIngredients, 0, 1);
            this.tblMain.Controls.Add(this.grpIngredientDetails, 0, 2);
            this.tblMain.Controls.Add(this.pnlButtons, 0, 3);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(12);
            this.tblMain.RowCount = 4;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.Size = new System.Drawing.Size(1000, 650);
            this.tblMain.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnClearSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(15, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(970, 44);
            this.pnlSearch.TabIndex = 4;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(10, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(80, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClearSearch.ForeColor = System.Drawing.Color.White;
            this.btnClearSearch.Location = new System.Drawing.Point(390, 9);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(70, 30);
            this.btnClearSearch.TabIndex = 3;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredients.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredients.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredients.EnableHeadersVisualStyles = false;
            this.dgvIngredients.GridColor = System.Drawing.Color.DarkGray;
            this.dgvIngredients.Location = new System.Drawing.Point(15, 65);
            this.dgvIngredients.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.dgvIngredients.MultiSelect = false;
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.RowHeadersWidth = 51;
            this.dgvIngredients.RowTemplate.Height = 24;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(970, 280);
            this.dgvIngredients.TabIndex = 0;
            this.dgvIngredients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredients_CellClick);
            // 
            // grpIngredientDetails
            // 
            this.grpIngredientDetails.BackColor = System.Drawing.Color.Transparent;
            this.grpIngredientDetails.Controls.Add(this.lblDescription);
            this.grpIngredientDetails.Controls.Add(this.txtDescription);
            this.grpIngredientDetails.Controls.Add(this.lblDescriptionStatus);
            this.grpIngredientDetails.Controls.Add(this.lblQuantityInStock);
            this.grpIngredientDetails.Controls.Add(this.numQuantityInStock);
            this.grpIngredientDetails.Controls.Add(this.lblRestockLevel);
            this.grpIngredientDetails.Controls.Add(this.numRestockLevel);
            this.grpIngredientDetails.Controls.Add(this.lblCostPrice);
            this.grpIngredientDetails.Controls.Add(this.numCostPrice);
            this.grpIngredientDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpIngredientDetails.ForeColor = System.Drawing.Color.White;
            this.grpIngredientDetails.Location = new System.Drawing.Point(15, 360);
            this.grpIngredientDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.grpIngredientDetails.Name = "grpIngredientDetails";
            this.grpIngredientDetails.Padding = new System.Windows.Forms.Padding(12);
            this.grpIngredientDetails.Size = new System.Drawing.Size(970, 220);
            this.grpIngredientDetails.TabIndex = 1;
            this.grpIngredientDetails.TabStop = false;
            this.grpIngredientDetails.Text = "Ingredient Details";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(16, 20);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 20);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(120, 18);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(6);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 27);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDescriptionStatus
            // 
            this.lblDescriptionStatus.AutoSize = true;
            this.lblDescriptionStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDescriptionStatus.ForeColor = System.Drawing.Color.White;
            this.lblDescriptionStatus.Location = new System.Drawing.Point(120, 48);
            this.lblDescriptionStatus.Name = "lblDescriptionStatus";
            this.lblDescriptionStatus.Size = new System.Drawing.Size(0, 20);
            this.lblDescriptionStatus.TabIndex = 14;
            // 
            // lblQuantityInStock
            // 
            this.lblQuantityInStock.AutoSize = true;
            this.lblQuantityInStock.ForeColor = System.Drawing.Color.White;
            this.lblQuantityInStock.Location = new System.Drawing.Point(16, 80);
            this.lblQuantityInStock.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuantityInStock.Name = "lblQuantityInStock";
            this.lblQuantityInStock.Size = new System.Drawing.Size(91, 20);
            this.lblQuantityInStock.TabIndex = 2;
            this.lblQuantityInStock.Text = "Qty In Stock:";
            // 
            // numQuantityInStock
            // 
            this.numQuantityInStock.BackColor = System.Drawing.Color.White;
            this.numQuantityInStock.DecimalPlaces = 2;
            this.numQuantityInStock.ForeColor = System.Drawing.Color.Black;
            this.numQuantityInStock.Location = new System.Drawing.Point(120, 78);
            this.numQuantityInStock.Margin = new System.Windows.Forms.Padding(6);
            this.numQuantityInStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numQuantityInStock.Name = "numQuantityInStock";
            this.numQuantityInStock.Size = new System.Drawing.Size(120, 27);
            this.numQuantityInStock.TabIndex = 3;
            this.numQuantityInStock.ThousandsSeparator = true;
            // 
            // lblRestockLevel
            // 
            this.lblRestockLevel.AutoSize = true;
            this.lblRestockLevel.ForeColor = System.Drawing.Color.White;
            this.lblRestockLevel.Location = new System.Drawing.Point(280, 80);
            this.lblRestockLevel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRestockLevel.Name = "lblRestockLevel";
            this.lblRestockLevel.Size = new System.Drawing.Size(101, 20);
            this.lblRestockLevel.TabIndex = 4;
            this.lblRestockLevel.Text = "Restock Level:";
            // 
            // numRestockLevel
            // 
            this.numRestockLevel.BackColor = System.Drawing.Color.White;
            this.numRestockLevel.DecimalPlaces = 2;
            this.numRestockLevel.ForeColor = System.Drawing.Color.Black;
            this.numRestockLevel.Location = new System.Drawing.Point(390, 78);
            this.numRestockLevel.Margin = new System.Windows.Forms.Padding(6);
            this.numRestockLevel.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numRestockLevel.Name = "numRestockLevel";
            this.numRestockLevel.Size = new System.Drawing.Size(120, 27);
            this.numRestockLevel.TabIndex = 5;
            this.numRestockLevel.ThousandsSeparator = true;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.ForeColor = System.Drawing.Color.White;
            this.lblCostPrice.Location = new System.Drawing.Point(520, 80);
            this.lblCostPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(77, 20);
            this.lblCostPrice.TabIndex = 6;
            this.lblCostPrice.Text = "Cost Price:";
            // 
            // numCostPrice
            // 
            this.numCostPrice.BackColor = System.Drawing.Color.White;
            this.numCostPrice.DecimalPlaces = 2;
            this.numCostPrice.ForeColor = System.Drawing.Color.Black;
            this.numCostPrice.Location = new System.Drawing.Point(600, 78);
            this.numCostPrice.Margin = new System.Windows.Forms.Padding(6);
            this.numCostPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numCostPrice.Name = "numCostPrice";
            this.numCostPrice.Size = new System.Drawing.Size(120, 27);
            this.numCostPrice.TabIndex = 7;
            this.numCostPrice.ThousandsSeparator = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.Controls.Add(this.btnBack);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnRemove);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnHelp);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(15, 595);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(970, 40);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.Location = new System.Drawing.Point(876, 6);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 38);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.Location = new System.Drawing.Point(768, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 38);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSize = true;
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRemove.FlatAppearance.BorderSize = 2;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRemove.Location = new System.Drawing.Point(655, 6);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 38);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdate.Location = new System.Drawing.Point(553, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 38);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAdd.Location = new System.Drawing.Point(431, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 38);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AutoSize = true;
            this.btnHelp.BackColor = System.Drawing.Color.White;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnHelp.FlatAppearance.BorderSize = 2;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnHelp.Location = new System.Drawing.Point(309, 6);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(110, 38);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "❓ Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click_1);
            // 
            // frmManageIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "frmManageIngredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Ingredients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageIngredients_Load);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.grpIngredientDetails.ResumeLayout(false);
            this.grpIngredientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.GroupBox grpIngredientDetails;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescriptionStatus;
        private System.Windows.Forms.Label lblQuantityInStock;
        private System.Windows.Forms.NumericUpDown numQuantityInStock;
        private System.Windows.Forms.Label lblRestockLevel;
        private System.Windows.Forms.NumericUpDown numRestockLevel;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.NumericUpDown numCostPrice;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHelp;
    }
}