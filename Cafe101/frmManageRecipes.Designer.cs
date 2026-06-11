namespace Cafe101
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

        private void InitializeComponent()
        {
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblMenuItem = new System.Windows.Forms.Label();
            this.cboMenuItems = new System.Windows.Forms.ComboBox();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.cboIngredients = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToRecipe = new System.Windows.Forms.Button();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnRefreshRecipe = new System.Windows.Forms.Button();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.tblMain.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlSearch, 0, 0);
            this.tblMain.Controls.Add(this.pnlTop, 0, 1);
            this.tblMain.Controls.Add(this.dgvRecipe, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(12);
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(792, 460);
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
            this.pnlSearch.Size = new System.Drawing.Size(762, 44);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(10, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(58, 19);
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
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
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
            // pnlTop
            // 
            this.pnlTop.ColumnCount = 6;
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnlTop.Controls.Add(this.btnBack, 5, 0);
            this.pnlTop.Controls.Add(this.lblMenuItem, 0, 0);
            this.pnlTop.Controls.Add(this.cboMenuItems, 1, 0);
            this.pnlTop.Controls.Add(this.lblIngredient, 0, 1);
            this.pnlTop.Controls.Add(this.cboIngredients, 1, 1);
            this.pnlTop.Controls.Add(this.lblQuantity, 4, 1);
            this.pnlTop.Controls.Add(this.numQuantity, 5, 1);
            this.pnlTop.Controls.Add(this.btnAddToRecipe, 2, 0);
            this.pnlTop.Controls.Add(this.btnRemoveLink, 3, 0);
            this.pnlTop.Controls.Add(this.btnRefreshRecipe, 4, 0);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(15, 65);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.RowCount = 2;
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTop.Size = new System.Drawing.Size(762, 105);
            this.pnlTop.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnBack.Location = new System.Drawing.Point(649, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblMenuItem
            // 
            this.lblMenuItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMenuItem.AutoSize = true;
            this.lblMenuItem.ForeColor = System.Drawing.Color.White;
            this.lblMenuItem.Location = new System.Drawing.Point(6, 18);
            this.lblMenuItem.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMenuItem.Name = "lblMenuItem";
            this.lblMenuItem.Size = new System.Drawing.Size(68, 15);
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
            this.cboMenuItems.Location = new System.Drawing.Point(86, 14);
            this.cboMenuItems.Margin = new System.Windows.Forms.Padding(6);
            this.cboMenuItems.Name = "cboMenuItems";
            this.cboMenuItems.Size = new System.Drawing.Size(193, 23);
            this.cboMenuItems.TabIndex = 1;
            // 
            // lblIngredient
            // 
            this.lblIngredient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIngredient.AutoSize = true;
            this.lblIngredient.ForeColor = System.Drawing.Color.White;
            this.lblIngredient.Location = new System.Drawing.Point(6, 71);
            this.lblIngredient.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(64, 15);
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
            this.cboIngredients.Location = new System.Drawing.Point(86, 67);
            this.cboIngredients.Margin = new System.Windows.Forms.Padding(6);
            this.cboIngredients.Name = "cboIngredients";
            this.cboIngredients.Size = new System.Drawing.Size(193, 23);
            this.cboIngredients.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(518, 71);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 15);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numQuantity.BackColor = System.Drawing.Color.White;
            this.numQuantity.DecimalPlaces = 2;
            this.numQuantity.ForeColor = System.Drawing.Color.Black;
            this.numQuantity.Location = new System.Drawing.Point(631, 67);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.numQuantity.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(70, 23);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.ThousandsSeparator = true;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddToRecipe
            // 
            this.btnAddToRecipe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddToRecipe.AutoSize = true;
            this.btnAddToRecipe.BackColor = System.Drawing.Color.White;
            this.btnAddToRecipe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddToRecipe.FlatAppearance.BorderSize = 2;
            this.btnAddToRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAddToRecipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddToRecipe.Location = new System.Drawing.Point(297, 9);
            this.btnAddToRecipe.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddToRecipe.Name = "btnAddToRecipe";
            this.btnAddToRecipe.Size = new System.Drawing.Size(88, 34);
            this.btnAddToRecipe.TabIndex = 8;
            this.btnAddToRecipe.Text = "Add";
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
            this.btnRemoveLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRemoveLink.Location = new System.Drawing.Point(411, 9);
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
            this.btnRefreshRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRefreshRecipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefreshRecipe.Location = new System.Drawing.Point(524, 9);
            this.btnRefreshRecipe.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefreshRecipe.Name = "btnRefreshRecipe";
            this.btnRefreshRecipe.Size = new System.Drawing.Size(88, 34);
            this.btnRefreshRecipe.TabIndex = 10;
            this.btnRefreshRecipe.Text = "Refresh";
            this.btnRefreshRecipe.UseVisualStyleBackColor = false;
            this.btnRefreshRecipe.Click += new System.EventHandler(this.btnRefreshRecipe_Click);
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToAddRows = false;
            this.dgvRecipe.AllowUserToDeleteRows = false;
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecipe.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipe.EnableHeadersVisualStyles = false;
            this.dgvRecipe.GridColor = System.Drawing.Color.DarkGray;
            this.dgvRecipe.Location = new System.Drawing.Point(15, 185);
            this.dgvRecipe.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.dgvRecipe.MultiSelect = false;
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersWidth = 51;
            this.dgvRecipe.RowTemplate.Height = 24;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.Size = new System.Drawing.Size(762, 251);
            this.dgvRecipe.TabIndex = 1;
            // 
            // frmManageRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(792, 460);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "frmManageRecipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Recipes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageRecipes_Load);
            this.tblMain.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            this.ResumeLayout(false);

        }

//#endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.TableLayoutPanel pnlTop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblMenuItem;
        private System.Windows.Forms.ComboBox cboMenuItems;
        private System.Windows.Forms.Label lblIngredient;
        private System.Windows.Forms.ComboBox cboIngredients;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddToRecipe;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnRefreshRecipe;
        private System.Windows.Forms.DataGridView dgvRecipe;
    }
}