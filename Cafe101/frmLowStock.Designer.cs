namespace Cafe101
{
    partial class frmLowStock
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.cardTotalItems = new System.Windows.Forms.Panel();
            this.lblTotalItemsValue = new System.Windows.Forms.Label();
            this.lblTotalItemsLabel = new System.Windows.Forms.Label();
            this.cardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockLabel = new System.Windows.Forms.Label();
            this.cardCritical = new System.Windows.Forms.Panel();
            this.lblCriticalValue = new System.Windows.Forms.Label();
            this.lblCriticalLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOnHandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restockLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPrintLowStock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ingredientTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.IngredientTableTableAdapter();
            this.testIngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.testIngredientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.testIngredientBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.testIngredientTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestIngredientTableAdapter();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelStats.SuspendLayout();
            this.cardTotalItems.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardCritical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1924, 74);
            this.panelHeader.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cafe101.Properties.Resources.Logo_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(80, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Low Stock Management";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelStats.Controls.Add(this.cardTotalItems);
            this.panelStats.Controls.Add(this.cardLowStock);
            this.panelStats.Controls.Add(this.cardCritical);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 74);
            this.panelStats.Margin = new System.Windows.Forms.Padding(4);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.panelStats.Size = new System.Drawing.Size(1924, 111);
            this.panelStats.TabIndex = 13;
            // 
            // cardTotalItems
            // 
            this.cardTotalItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardTotalItems.Controls.Add(this.lblTotalItemsValue);
            this.cardTotalItems.Controls.Add(this.lblTotalItemsLabel);
            this.cardTotalItems.Location = new System.Drawing.Point(27, 12);
            this.cardTotalItems.Margin = new System.Windows.Forms.Padding(4);
            this.cardTotalItems.Name = "cardTotalItems";
            this.cardTotalItems.Size = new System.Drawing.Size(200, 86);
            this.cardTotalItems.TabIndex = 0;
            // 
            // lblTotalItemsValue
            // 
            this.lblTotalItemsValue.AutoSize = true;
            this.lblTotalItemsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalItemsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalItemsValue.Location = new System.Drawing.Point(20, 10);
            this.lblTotalItemsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalItemsValue.Name = "lblTotalItemsValue";
            this.lblTotalItemsValue.Size = new System.Drawing.Size(40, 46);
            this.lblTotalItemsValue.TabIndex = 1;
            this.lblTotalItemsValue.Text = "0";
            // 
            // lblTotalItemsLabel
            // 
            this.lblTotalItemsLabel.AutoSize = true;
            this.lblTotalItemsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalItemsLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalItemsLabel.Location = new System.Drawing.Point(20, 55);
            this.lblTotalItemsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalItemsLabel.Name = "lblTotalItemsLabel";
            this.lblTotalItemsLabel.Size = new System.Drawing.Size(82, 20);
            this.lblTotalItemsLabel.TabIndex = 0;
            this.lblTotalItemsLabel.Text = "Total Items";
            // 
            // cardLowStock
            // 
            this.cardLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.cardLowStock.Controls.Add(this.lblLowStockValue);
            this.cardLowStock.Controls.Add(this.lblLowStockLabel);
            this.cardLowStock.Location = new System.Drawing.Point(240, 12);
            this.cardLowStock.Margin = new System.Windows.Forms.Padding(4);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Size = new System.Drawing.Size(200, 86);
            this.cardLowStock.TabIndex = 1;
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.White;
            this.lblLowStockValue.Location = new System.Drawing.Point(20, 10);
            this.lblLowStockValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(40, 46);
            this.lblLowStockValue.TabIndex = 1;
            this.lblLowStockValue.Text = "0";
            // 
            // lblLowStockLabel
            // 
            this.lblLowStockLabel.AutoSize = true;
            this.lblLowStockLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLowStockLabel.ForeColor = System.Drawing.Color.White;
            this.lblLowStockLabel.Location = new System.Drawing.Point(20, 55);
            this.lblLowStockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockLabel.Name = "lblLowStockLabel";
            this.lblLowStockLabel.Size = new System.Drawing.Size(105, 20);
            this.lblLowStockLabel.TabIndex = 0;
            this.lblLowStockLabel.Text = "Below Restock";
            // 
            // cardCritical
            // 
            this.cardCritical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.cardCritical.Controls.Add(this.lblCriticalValue);
            this.cardCritical.Controls.Add(this.lblCriticalLabel);
            this.cardCritical.Location = new System.Drawing.Point(453, 12);
            this.cardCritical.Margin = new System.Windows.Forms.Padding(4);
            this.cardCritical.Name = "cardCritical";
            this.cardCritical.Size = new System.Drawing.Size(200, 86);
            this.cardCritical.TabIndex = 2;
            // 
            // lblCriticalValue
            // 
            this.lblCriticalValue.AutoSize = true;
            this.lblCriticalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCriticalValue.ForeColor = System.Drawing.Color.White;
            this.lblCriticalValue.Location = new System.Drawing.Point(20, 10);
            this.lblCriticalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriticalValue.Name = "lblCriticalValue";
            this.lblCriticalValue.Size = new System.Drawing.Size(40, 46);
            this.lblCriticalValue.TabIndex = 1;
            this.lblCriticalValue.Text = "0";
            // 
            // lblCriticalLabel
            // 
            this.lblCriticalLabel.AutoSize = true;
            this.lblCriticalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCriticalLabel.ForeColor = System.Drawing.Color.White;
            this.lblCriticalLabel.Location = new System.Drawing.Point(20, 55);
            this.lblCriticalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCriticalLabel.Name = "lblCriticalLabel";
            this.lblCriticalLabel.Size = new System.Drawing.Size(100, 20);
            this.lblCriticalLabel.TabIndex = 0;
            this.lblCriticalLabel.Text = "Critical (Zero)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.quantityOnHandDataGridViewTextBoxColumn,
            this.restockLevelDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ingredientTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 185);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1924, 607);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Ingredient";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // quantityOnHandDataGridViewTextBoxColumn
            // 
            this.quantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand";
            this.quantityOnHandDataGridViewTextBoxColumn.HeaderText = "On Hand";
            this.quantityOnHandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityOnHandDataGridViewTextBoxColumn.Name = "quantityOnHandDataGridViewTextBoxColumn";
            // 
            // restockLevelDataGridViewTextBoxColumn
            // 
            this.restockLevelDataGridViewTextBoxColumn.DataPropertyName = "RestockLevel";
            this.restockLevelDataGridViewTextBoxColumn.HeaderText = "Restock Level";
            this.restockLevelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.restockLevelDataGridViewTextBoxColumn.Name = "restockLevelDataGridViewTextBoxColumn";
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "Cost Price";
            this.costPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            // 
            // ingredientTableBindingSource
            // 
            this.ingredientTableBindingSource.DataMember = "IngredientTable";
            this.ingredientTableBindingSource.DataSource = this.dsCafe101Hub;
            // 
            // dsCafe101Hub
            // 
            this.dsCafe101Hub.DataSetName = "dsCafe101Hub";
            this.dsCafe101Hub.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Controls.Add(this.button2);
            this.panelActions.Controls.Add(this.btnPrintLowStock);
            this.panelActions.Controls.Add(this.button1);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 892);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1924, 74);
            this.panelActions.TabIndex = 15;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnRefresh.Location = new System.Drawing.Point(20, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 37);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button2.Location = new System.Drawing.Point(145, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Restock All";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPrintLowStock
            // 
            this.btnPrintLowStock.BackColor = System.Drawing.Color.White;
            this.btnPrintLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPrintLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnPrintLowStock.Location = new System.Drawing.Point(265, 15);
            this.btnPrintLowStock.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintLowStock.Name = "btnPrintLowStock";
            this.btnPrintLowStock.Size = new System.Drawing.Size(170, 37);
            this.btnPrintLowStock.TabIndex = 8;
            this.btnPrintLowStock.Text = "Print Report";
            this.btnPrintLowStock.UseVisualStyleBackColor = false;
            this.btnPrintLowStock.Click += new System.EventHandler(this.btnPrintLowStock_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button1.Location = new System.Drawing.Point(1811, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ingredientTableTableAdapter
            // 
            this.ingredientTableTableAdapter.ClearBeforeFill = true;
            // 
            // testIngredientBindingSource
            // 
            this.testIngredientBindingSource.DataMember = "TestIngredient";
            this.testIngredientBindingSource.DataSource = this.dsCafe101Test;
            // 
            // dsCafe101Test
            // 
            this.dsCafe101Test.DataSetName = "dsCafe101Test";
            this.dsCafe101Test.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testIngredientBindingSource1
            // 
            this.testIngredientBindingSource1.DataMember = "TestIngredient";
            this.testIngredientBindingSource1.DataSource = this.dsCafe101Test;
            // 
            // testIngredientBindingSource2
            // 
            this.testIngredientBindingSource2.DataMember = "TestIngredient";
            this.testIngredientBindingSource2.DataSource = this.dsCafe101Test;
            // 
            // testIngredientTableAdapter
            // 
            this.testIngredientTableAdapter.ClearBeforeFill = true;
            // 
            // frmLowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1924, 966);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLowStock";
            this.Text = "Low Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLowStock_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.cardTotalItems.ResumeLayout(false);
            this.cardTotalItems.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardCritical.ResumeLayout(false);
            this.cardCritical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // ORIGINAL COMPONENTS - All kept the same
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource testIngredientBindingSource;
        private dsCafe101TestTableAdapters.TestIngredientTableAdapter testIngredientTableAdapter;
        private System.Windows.Forms.BindingSource testIngredientBindingSource1;
        private System.Windows.Forms.BindingSource testIngredientBindingSource2;
        private System.Windows.Forms.Button btnPrintLowStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOnHandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restockLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource ingredientTableBindingSource;
        private dsCafe101HubTableAdapters.IngredientTableTableAdapter ingredientTableTableAdapter;
        private System.Windows.Forms.Button button2;

        // NEW COMPONENTS
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardTotalItems;
        private System.Windows.Forms.Label lblTotalItemsValue;
        private System.Windows.Forms.Label lblTotalItemsLabel;
        private System.Windows.Forms.Panel cardLowStock;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Label lblLowStockLabel;
        private System.Windows.Forms.Panel cardCritical;
        private System.Windows.Forms.Label lblCriticalValue;
        private System.Windows.Forms.Label lblCriticalLabel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}