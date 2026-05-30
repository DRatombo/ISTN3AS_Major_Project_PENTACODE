namespace Cafe101
{
    partial class frmManageMenuItems
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.menuItemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.grpMenuItemDetails = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblSelling = new System.Windows.Forms.Label();
            this.numSellingPrice = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new System.Windows.Forms.Label();
            this.numCostPrice = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPrep = new System.Windows.Forms.Label();
            this.txtPrepTime = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuItemsTableAdapter = new Cafe101.dsCafe101TableAdapters.MenuItemsTableAdapter();
            this.btnBack = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            this.grpMenuItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.dgvMenuItems, 0, 0);
            this.tblMain.Controls.Add(this.grpMenuItemDetails, 0, 1);
            this.tblMain.Controls.Add(this.pnlButtons, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(12);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(12);
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(1258, 543);
            this.tblMain.TabIndex = 0;
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.AllowUserToAddRows = false;
            this.dgvMenuItems.AllowUserToDeleteRows = false;
            this.dgvMenuItems.AutoGenerateColumns = false;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenuItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuItemIDDataGridViewTextBoxColumn,
            this.menuItemNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.prepTimeDataGridViewTextBoxColumn});
            this.dgvMenuItems.DataSource = this.menuItemsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenuItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuItems.EnableHeadersVisualStyles = false;
            this.dgvMenuItems.GridColor = System.Drawing.Color.DarkGray;
            this.dgvMenuItems.Location = new System.Drawing.Point(15, 15);
            this.dgvMenuItems.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.dgvMenuItems.MultiSelect = false;
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.ReadOnly = true;
            this.dgvMenuItems.RowHeadersWidth = 51;
            this.dgvMenuItems.RowTemplate.Height = 24;
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(1228, 244);
            this.dgvMenuItems.TabIndex = 0;
            this.dgvMenuItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuItems_CellClick);
            // 
            // menuItemIDDataGridViewTextBoxColumn
            // 
            this.menuItemIDDataGridViewTextBoxColumn.DataPropertyName = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.HeaderText = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.menuItemIDDataGridViewTextBoxColumn.Name = "menuItemIDDataGridViewTextBoxColumn";
            this.menuItemIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuItemNameDataGridViewTextBoxColumn
            // 
            this.menuItemNameDataGridViewTextBoxColumn.DataPropertyName = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.HeaderText = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.menuItemNameDataGridViewTextBoxColumn.Name = "menuItemNameDataGridViewTextBoxColumn";
            this.menuItemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "CostPrice";
            this.costPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prepTimeDataGridViewTextBoxColumn
            // 
            this.prepTimeDataGridViewTextBoxColumn.DataPropertyName = "PrepTime";
            this.prepTimeDataGridViewTextBoxColumn.HeaderText = "PrepTime";
            this.prepTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prepTimeDataGridViewTextBoxColumn.Name = "prepTimeDataGridViewTextBoxColumn";
            this.prepTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuItemsBindingSource
            // 
            this.menuItemsBindingSource.DataMember = "MenuItems";
            this.menuItemsBindingSource.DataSource = this.dsCafe101;
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpMenuItemDetails
            // 
            this.grpMenuItemDetails.BackColor = System.Drawing.Color.Transparent;
            this.grpMenuItemDetails.Controls.Add(this.lblName);
            this.grpMenuItemDetails.Controls.Add(this.txtItemName);
            this.grpMenuItemDetails.Controls.Add(this.lblSelling);
            this.grpMenuItemDetails.Controls.Add(this.numSellingPrice);
            this.grpMenuItemDetails.Controls.Add(this.lblCost);
            this.grpMenuItemDetails.Controls.Add(this.numCostPrice);
            this.grpMenuItemDetails.Controls.Add(this.lblCategory);
            this.grpMenuItemDetails.Controls.Add(this.cboCategory);
            this.grpMenuItemDetails.Controls.Add(this.lblPrep);
            this.grpMenuItemDetails.Controls.Add(this.txtPrepTime);
            this.grpMenuItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMenuItemDetails.Location = new System.Drawing.Point(15, 274);
            this.grpMenuItemDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.grpMenuItemDetails.Name = "grpMenuItemDetails";
            this.grpMenuItemDetails.Padding = new System.Windows.Forms.Padding(12);
            this.grpMenuItemDetails.Size = new System.Drawing.Size(1228, 192);
            this.grpMenuItemDetails.TabIndex = 1;
            this.grpMenuItemDetails.TabStop = false;
            this.grpMenuItemDetails.Text = "Menu Item Details";
            this.grpMenuItemDetails.Enter += new System.EventHandler(this.grpMenuItemDetails_Enter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(16, 20);
            this.lblName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.ForeColor = System.Drawing.Color.Black;
            this.txtItemName.Location = new System.Drawing.Point(120, 18);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(6);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(420, 27);
            this.txtItemName.TabIndex = 1;
            // 
            // lblSelling
            // 
            this.lblSelling.AutoSize = true;
            this.lblSelling.ForeColor = System.Drawing.Color.White;
            this.lblSelling.Location = new System.Drawing.Point(16, 60);
            this.lblSelling.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSelling.Name = "lblSelling";
            this.lblSelling.Size = new System.Drawing.Size(93, 20);
            this.lblSelling.TabIndex = 2;
            this.lblSelling.Text = "Selling Price:";
            // 
            // numSellingPrice
            // 
            this.numSellingPrice.BackColor = System.Drawing.Color.White;
            this.numSellingPrice.DecimalPlaces = 2;
            this.numSellingPrice.ForeColor = System.Drawing.Color.Black;
            this.numSellingPrice.Location = new System.Drawing.Point(120, 58);
            this.numSellingPrice.Margin = new System.Windows.Forms.Padding(6);
            this.numSellingPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numSellingPrice.Name = "numSellingPrice";
            this.numSellingPrice.Size = new System.Drawing.Size(120, 27);
            this.numSellingPrice.TabIndex = 3;
            this.numSellingPrice.ThousandsSeparator = true;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.ForeColor = System.Drawing.Color.White;
            this.lblCost.Location = new System.Drawing.Point(280, 60);
            this.lblCost.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(77, 20);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Cost Price:";
            // 
            // numCostPrice
            // 
            this.numCostPrice.BackColor = System.Drawing.Color.White;
            this.numCostPrice.DecimalPlaces = 2;
            this.numCostPrice.ForeColor = System.Drawing.Color.Black;
            this.numCostPrice.Location = new System.Drawing.Point(360, 58);
            this.numCostPrice.Margin = new System.Windows.Forms.Padding(6);
            this.numCostPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCostPrice.Name = "numCostPrice";
            this.numCostPrice.Size = new System.Drawing.Size(120, 27);
            this.numCostPrice.TabIndex = 5;
            this.numCostPrice.ThousandsSeparator = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(16, 100);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(72, 20);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.White;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.ForeColor = System.Drawing.Color.Black;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Burger",
            "Wings",
            "Sides",
            "Drinks",
            "Combo"});
            this.cboCategory.Location = new System.Drawing.Point(120, 96);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 28);
            this.cboCategory.TabIndex = 7;
            // 
            // lblPrep
            // 
            this.lblPrep.AutoSize = true;
            this.lblPrep.ForeColor = System.Drawing.Color.White;
            this.lblPrep.Location = new System.Drawing.Point(16, 142);
            this.lblPrep.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrep.Name = "lblPrep";
            this.lblPrep.Size = new System.Drawing.Size(79, 20);
            this.lblPrep.TabIndex = 8;
            this.lblPrep.Text = "Prep Time:";
            // 
            // txtPrepTime
            // 
            this.txtPrepTime.BackColor = System.Drawing.Color.White;
            this.txtPrepTime.ForeColor = System.Drawing.Color.Black;
            this.txtPrepTime.Location = new System.Drawing.Point(120, 142);
            this.txtPrepTime.Margin = new System.Windows.Forms.Padding(6);
            this.txtPrepTime.Name = "txtPrepTime";
            this.txtPrepTime.Size = new System.Drawing.Size(120, 27);
            this.txtPrepTime.TabIndex = 9;
            this.txtPrepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnDeactivate);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnBack);
            this.pnlButtons.Location = new System.Drawing.Point(375, 484);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(508, 44);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.Location = new System.Drawing.Point(314, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 34);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.AutoSize = true;
            this.btnDeactivate.BackColor = System.Drawing.Color.White;
            this.btnDeactivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnDeactivate.FlatAppearance.BorderSize = 2;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnDeactivate.Location = new System.Drawing.Point(106, 6);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(96, 34);
            this.btnDeactivate.TabIndex = 2;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdate.Location = new System.Drawing.Point(214, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 34);
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
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAdd.Location = new System.Drawing.Point(6, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuItemsTableAdapter
            // 
            this.menuItemsTableAdapter.ClearBeforeFill = true;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.Location = new System.Drawing.Point(414, 6);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmManageMenuItems
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1258, 543);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 480);
            this.Name = "frmManageMenuItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Menu Items";
            this.Load += new System.EventHandler(this.frmManageMenuItems_Load);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            this.grpMenuItemDetails.ResumeLayout(false);
            this.grpMenuItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.DataGridView dgvMenuItems;
        private System.Windows.Forms.GroupBox grpMenuItemDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblSelling;
        private System.Windows.Forms.NumericUpDown numSellingPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown numCostPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrep;
        private System.Windows.Forms.TextBox txtPrepTime;
        private dsCafe101 dsCafe101;
        private System.Windows.Forms.BindingSource menuItemsBindingSource;
        private dsCafe101TableAdapters.MenuItemsTableAdapter menuItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
    }
}