namespace RestaurantSystem
{
    partial class frmManageRecipes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblMenuItem = new System.Windows.Forms.Label();
            this.cboMenuItems = new System.Windows.Forms.ComboBox();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.cboIngredients = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtDisplayUnit = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToRecipe = new System.Windows.Forms.Button();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnRefreshRecipe = new System.Windows.Forms.Button();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.recipeItemTableAdapter = new Cafe101.dsCafe101TableAdapters.RecipeItemTableAdapter();
            this.recipeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientTableAdapter = new Cafe101.dsCafe101TableAdapters.IngredientTableAdapter();
            this.recipeItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuItemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proportionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlTop, 0, 0);
            this.tblMain.Controls.Add(this.dgvRecipe, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(12);
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(792, 460);
            this.tblMain.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.ColumnCount = 6;
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnlTop.Controls.Add(this.lblMenuItem, 0, 0);
            this.pnlTop.Controls.Add(this.cboMenuItems, 1, 0);
            this.pnlTop.Controls.Add(this.lblIngredient, 0, 1);
            this.pnlTop.Controls.Add(this.cboIngredients, 1, 1);
            this.pnlTop.Controls.Add(this.lblUnit, 2, 1);
            this.pnlTop.Controls.Add(this.txtDisplayUnit, 3, 1);
            this.pnlTop.Controls.Add(this.lblQuantity, 4, 1);
            this.pnlTop.Controls.Add(this.numQuantity, 5, 1);
            this.pnlTop.Controls.Add(this.btnAddToRecipe, 3, 0);
            this.pnlTop.Controls.Add(this.btnRemoveLink, 4, 0);
            this.pnlTop.Controls.Add(this.btnRefreshRecipe, 5, 0);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.RowCount = 2;
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.Size = new System.Drawing.Size(762, 105);
            this.pnlTop.TabIndex = 0;
            // 
            // lblMenuItem
            // 
            this.lblMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMenuItem.AutoSize = true;
            this.lblMenuItem.ForeColor = System.Drawing.Color.White;
            this.lblMenuItem.Location = new System.Drawing.Point(6, 6);
            this.lblMenuItem.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMenuItem.Name = "lblMenuItem";
            this.lblMenuItem.Size = new System.Drawing.Size(50, 40);
            this.lblMenuItem.TabIndex = 0;
            this.lblMenuItem.Text = "Menu Item:";
            // 
            // cboMenuItems
            // 
            this.cboMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMenuItems.BackColor = System.Drawing.Color.White;
            this.cboMenuItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenuItems.ForeColor = System.Drawing.Color.Black;
            this.cboMenuItems.FormattingEnabled = true;
            this.cboMenuItems.Location = new System.Drawing.Point(86, 12);
            this.cboMenuItems.Margin = new System.Windows.Forms.Padding(6);
            this.cboMenuItems.Name = "cboMenuItems";
            this.cboMenuItems.Size = new System.Drawing.Size(203, 28);
            this.cboMenuItems.TabIndex = 1;
            this.cboMenuItems.SelectedIndexChanged += new System.EventHandler(this.cboMenuItems_SelectedIndexChanged);
            // 
            // lblIngredient
            // 
            this.lblIngredient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIngredient.AutoSize = true;
            this.lblIngredient.ForeColor = System.Drawing.Color.White;
            this.lblIngredient.Location = new System.Drawing.Point(6, 58);
            this.lblIngredient.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(64, 40);
            this.lblIngredient.TabIndex = 2;
            this.lblIngredient.Text = "Ingredient:";
            // 
            // cboIngredients
            // 
            this.cboIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIngredients.BackColor = System.Drawing.Color.White;
            this.cboIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIngredients.ForeColor = System.Drawing.Color.Black;
            this.cboIngredients.FormattingEnabled = true;
            this.cboIngredients.Location = new System.Drawing.Point(86, 64);
            this.cboIngredients.Margin = new System.Windows.Forms.Padding(6);
            this.cboIngredients.Name = "cboIngredients";
            this.cboIngredients.Size = new System.Drawing.Size(203, 28);
            this.cboIngredients.TabIndex = 3;
            this.cboIngredients.SelectedIndexChanged += new System.EventHandler(this.cboIngredients_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnit.AutoSize = true;
            this.lblUnit.ForeColor = System.Drawing.Color.White;
            this.lblUnit.Location = new System.Drawing.Point(301, 68);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(39, 20);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit:";
            this.lblUnit.Click += new System.EventHandler(this.lblUnit_Click);
            // 
            // txtDisplayUnit
            // 
            this.txtDisplayUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDisplayUnit.BackColor = System.Drawing.Color.White;
            this.txtDisplayUnit.ForeColor = System.Drawing.Color.Black;
            this.txtDisplayUnit.Location = new System.Drawing.Point(391, 65);
            this.txtDisplayUnit.Margin = new System.Windows.Forms.Padding(6);
            this.txtDisplayUnit.Name = "txtDisplayUnit";
            this.txtDisplayUnit.ReadOnly = true;
            this.txtDisplayUnit.Size = new System.Drawing.Size(88, 27);
            this.txtDisplayUnit.TabIndex = 5;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(510, 68);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(68, 20);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numQuantity.BackColor = System.Drawing.Color.White;
            this.numQuantity.DecimalPlaces = 2;
            this.numQuantity.ForeColor = System.Drawing.Color.Black;
            this.numQuantity.Location = new System.Drawing.Point(623, 65);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.numQuantity.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(70, 27);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.ThousandsSeparator = true;
            // 
            // btnAddToRecipe
            // 
            this.btnAddToRecipe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddToRecipe.AutoSize = true;
            this.btnAddToRecipe.BackColor = System.Drawing.Color.White;
            this.btnAddToRecipe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddToRecipe.FlatAppearance.BorderSize = 2;
            this.btnAddToRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToRecipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddToRecipe.Location = new System.Drawing.Point(391, 9);
            this.btnAddToRecipe.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddToRecipe.Name = "btnAddToRecipe";
            this.btnAddToRecipe.Size = new System.Drawing.Size(107, 34);
            this.btnAddToRecipe.TabIndex = 8;
            this.btnAddToRecipe.Text = "Add ";
            this.btnAddToRecipe.UseVisualStyleBackColor = false;
            this.btnAddToRecipe.Click += new System.EventHandler(this.btnAddToRecipe_Click);
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveLink.AutoSize = true;
            this.btnRemoveLink.BackColor = System.Drawing.Color.White;
            this.btnRemoveLink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRemoveLink.FlatAppearance.BorderSize = 2;
            this.btnRemoveLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRemoveLink.Location = new System.Drawing.Point(516, 9);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(88, 34);
            this.btnRemoveLink.TabIndex = 9;
            this.btnRemoveLink.Text = "Remove";
            this.btnRemoveLink.UseVisualStyleBackColor = false;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnRefreshRecipe
            // 
            this.btnRefreshRecipe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefreshRecipe.AutoSize = true;
            this.btnRefreshRecipe.BackColor = System.Drawing.Color.White;
            this.btnRefreshRecipe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefreshRecipe.FlatAppearance.BorderSize = 2;
            this.btnRefreshRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRecipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefreshRecipe.Location = new System.Drawing.Point(653, 9);
            this.btnRefreshRecipe.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefreshRecipe.Name = "btnRefreshRecipe";
            this.btnRefreshRecipe.Size = new System.Drawing.Size(72, 34);
            this.btnRefreshRecipe.TabIndex = 10;
            this.btnRefreshRecipe.Text = "Refresh";
            this.btnRefreshRecipe.UseVisualStyleBackColor = false;
            this.btnRefreshRecipe.Click += new System.EventHandler(this.btnRefreshRecipe_Click);
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToAddRows = false;
            this.dgvRecipe.AllowUserToDeleteRows = false;
            this.dgvRecipe.AutoGenerateColumns = false;
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuItemIDDataGridViewTextBoxColumn,
            this.ingredientIDDataGridViewTextBoxColumn,
            this.proportionDataGridViewTextBoxColumn});
            this.dgvRecipe.DataSource = this.recipeItemBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecipe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipe.EnableHeadersVisualStyles = false;
            this.dgvRecipe.GridColor = System.Drawing.Color.DarkGray;
            this.dgvRecipe.Location = new System.Drawing.Point(15, 135);
            this.dgvRecipe.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.dgvRecipe.MultiSelect = false;
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersWidth = 51;
            this.dgvRecipe.RowTemplate.Height = 24;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.Size = new System.Drawing.Size(762, 301);
            this.dgvRecipe.TabIndex = 1;
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recipeItemTableAdapter
            // 
            this.recipeItemTableAdapter.ClearBeforeFill = true;
            // 
            // recipeItemBindingSource
            // 
            this.recipeItemBindingSource.DataMember = "RecipeItem";
            this.recipeItemBindingSource.DataSource = this.dsCafe101;
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataMember = "Ingredient";
            this.ingredientBindingSource.DataSource = this.dsCafe101;
            // 
            // ingredientTableAdapter
            // 
            this.ingredientTableAdapter.ClearBeforeFill = true;
            // 
            // recipeItemBindingSource1
            // 
            this.recipeItemBindingSource1.DataMember = "RecipeItem";
            this.recipeItemBindingSource1.DataSource = this.dsCafe101;
            // 
            // menuItemIDDataGridViewTextBoxColumn
            // 
            this.menuItemIDDataGridViewTextBoxColumn.DataPropertyName = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.HeaderText = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.menuItemIDDataGridViewTextBoxColumn.Name = "menuItemIDDataGridViewTextBoxColumn";
            this.menuItemIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ingredientIDDataGridViewTextBoxColumn
            // 
            this.ingredientIDDataGridViewTextBoxColumn.DataPropertyName = "IngredientID";
            this.ingredientIDDataGridViewTextBoxColumn.HeaderText = "IngredientID";
            this.ingredientIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ingredientIDDataGridViewTextBoxColumn.Name = "ingredientIDDataGridViewTextBoxColumn";
            this.ingredientIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proportionDataGridViewTextBoxColumn
            // 
            this.proportionDataGridViewTextBoxColumn.DataPropertyName = "Proportion";
            this.proportionDataGridViewTextBoxColumn.HeaderText = "Proportion";
            this.proportionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.proportionDataGridViewTextBoxColumn.Name = "proportionDataGridViewTextBoxColumn";
            this.proportionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmManageRecipes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(792, 460);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "frmManageRecipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Recipes";
            this.Load += new System.EventHandler(this.frmManageRecipes_Load);
            this.tblMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel pnlTop;
        private System.Windows.Forms.Label lblMenuItem;
        private System.Windows.Forms.ComboBox cboMenuItems;
        private System.Windows.Forms.Label lblIngredient;
        private System.Windows.Forms.ComboBox cboIngredients;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtDisplayUnit;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddToRecipe;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnRefreshRecipe;
        private System.Windows.Forms.DataGridView dgvRecipe;
        private Cafe101.dsCafe101 dsCafe101;
        private Cafe101.dsCafe101TableAdapters.RecipeItemTableAdapter recipeItemTableAdapter;
        private System.Windows.Forms.BindingSource recipeItemBindingSource;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private Cafe101.dsCafe101TableAdapters.IngredientTableAdapter ingredientTableAdapter;
        private System.Windows.Forms.BindingSource recipeItemBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proportionDataGridViewTextBoxColumn;
    }
}