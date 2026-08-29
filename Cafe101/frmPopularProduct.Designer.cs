namespace Cafe101
{
    partial class frmPopularProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.cardTotalProducts = new System.Windows.Forms.Panel();
            this.lblTotalProductsValue = new System.Windows.Forms.Label();
            this.lblTotalProductsLabel = new System.Windows.Forms.Label();
            this.cardTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSalesLabel = new System.Windows.Forms.Label();
            this.cardTopSeller = new System.Windows.Forms.Panel();
            this.lblTopSellerValue = new System.Windows.Forms.Label();
            this.lblTopSellerLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuItemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topSellingItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.panelBestSellers = new System.Windows.Forms.Panel();
            this.lblBestSellersTitle = new System.Windows.Forms.Label();
            this.panelGold = new System.Windows.Forms.Panel();
            this.lblGoldMedal = new System.Windows.Forms.Label();
            this.lblGoldItem = new System.Windows.Forms.Label();
            this.txtGoldItem = new System.Windows.Forms.TextBox();
            this.panelSilver = new System.Windows.Forms.Panel();
            this.lblSilverMedal = new System.Windows.Forms.Label();
            this.lblSilverItem = new System.Windows.Forms.Label();
            this.txtSilverItem = new System.Windows.Forms.TextBox();
            this.panelBronze = new System.Windows.Forms.Panel();
            this.lblBronzeMedal = new System.Windows.Forms.Label();
            this.lblBronzeItem = new System.Windows.Forms.Label();
            this.txtBronzeItem = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.topSellingItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.topSellingItemTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TopSellingItemTableAdapter();
            this.topSellingItemTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.TopSellingItemTableAdapter();
            this.menuItemsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuItemsTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.MenuItemsTableTableAdapter();
            this.topSellingItemBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelStats.SuspendLayout();
            this.cardTotalProducts.SuspendLayout();
            this.cardTotalSales.SuspendLayout();
            this.cardTopSeller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            this.panelBestSellers.SuspendLayout();
            this.panelGold.SuspendLayout();
            this.panelSilver.SuspendLayout();
            this.panelBronze.SuspendLayout();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource2)).BeginInit();
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
            this.panelHeader.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cafe101.Properties.Resources.Logo_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(20, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(100, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(364, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Popular Products Report";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelStats.Controls.Add(this.cardTotalProducts);
            this.panelStats.Controls.Add(this.cardTotalSales);
            this.panelStats.Controls.Add(this.cardTopSeller);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 74);
            this.panelStats.Margin = new System.Windows.Forms.Padding(4);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.panelStats.Size = new System.Drawing.Size(1924, 98);
            this.panelStats.TabIndex = 14;
            // 
            // cardTotalProducts
            // 
            this.cardTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardTotalProducts.Controls.Add(this.lblTotalProductsValue);
            this.cardTotalProducts.Controls.Add(this.lblTotalProductsLabel);
            this.cardTotalProducts.Location = new System.Drawing.Point(27, 12);
            this.cardTotalProducts.Margin = new System.Windows.Forms.Padding(4);
            this.cardTotalProducts.Name = "cardTotalProducts";
            this.cardTotalProducts.Size = new System.Drawing.Size(240, 74);
            this.cardTotalProducts.TabIndex = 0;
            // 
            // lblTotalProductsValue
            // 
            this.lblTotalProductsValue.AutoSize = true;
            this.lblTotalProductsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalProductsValue.Location = new System.Drawing.Point(16, 6);
            this.lblTotalProductsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProductsValue.Name = "lblTotalProductsValue";
            this.lblTotalProductsValue.Size = new System.Drawing.Size(40, 46);
            this.lblTotalProductsValue.TabIndex = 1;
            this.lblTotalProductsValue.Text = "0";
            // 
            // lblTotalProductsLabel
            // 
            this.lblTotalProductsLabel.AutoSize = true;
            this.lblTotalProductsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalProductsLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalProductsLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTotalProductsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProductsLabel.Name = "lblTotalProductsLabel";
            this.lblTotalProductsLabel.Size = new System.Drawing.Size(103, 20);
            this.lblTotalProductsLabel.TabIndex = 0;
            this.lblTotalProductsLabel.Text = "Total Products";
            // 
            // cardTotalSales
            // 
            this.cardTotalSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardTotalSales.Controls.Add(this.lblTotalSalesValue);
            this.cardTotalSales.Controls.Add(this.lblTotalSalesLabel);
            this.cardTotalSales.Location = new System.Drawing.Point(280, 12);
            this.cardTotalSales.Margin = new System.Windows.Forms.Padding(4);
            this.cardTotalSales.Name = "cardTotalSales";
            this.cardTotalSales.Size = new System.Drawing.Size(240, 74);
            this.cardTotalSales.TabIndex = 1;
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.AutoSize = true;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesValue.Location = new System.Drawing.Point(16, 6);
            this.lblTotalSalesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(40, 46);
            this.lblTotalSalesValue.TabIndex = 1;
            this.lblTotalSalesValue.Text = "0";
            // 
            // lblTotalSalesLabel
            // 
            this.lblTotalSalesLabel.AutoSize = true;
            this.lblTotalSalesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalSalesLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalSalesLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTotalSalesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalSalesLabel.Name = "lblTotalSalesLabel";
            this.lblTotalSalesLabel.Size = new System.Drawing.Size(80, 20);
            this.lblTotalSalesLabel.TabIndex = 0;
            this.lblTotalSalesLabel.Text = "Total Sales";
            // 
            // cardTopSeller
            // 
            this.cardTopSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.cardTopSeller.Controls.Add(this.lblTopSellerValue);
            this.cardTopSeller.Controls.Add(this.lblTopSellerLabel);
            this.cardTopSeller.Location = new System.Drawing.Point(533, 12);
            this.cardTopSeller.Margin = new System.Windows.Forms.Padding(4);
            this.cardTopSeller.Name = "cardTopSeller";
            this.cardTopSeller.Size = new System.Drawing.Size(267, 74);
            this.cardTopSeller.TabIndex = 2;
            // 
            // lblTopSellerValue
            // 
            this.lblTopSellerValue.AutoSize = true;
            this.lblTopSellerValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTopSellerValue.ForeColor = System.Drawing.Color.White;
            this.lblTopSellerValue.Location = new System.Drawing.Point(16, 6);
            this.lblTopSellerValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopSellerValue.Name = "lblTopSellerValue";
            this.lblTopSellerValue.Size = new System.Drawing.Size(28, 37);
            this.lblTopSellerValue.TabIndex = 1;
            this.lblTopSellerValue.Text = "-";
            // 
            // lblTopSellerLabel
            // 
            this.lblTopSellerLabel.AutoSize = true;
            this.lblTopSellerLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTopSellerLabel.ForeColor = System.Drawing.Color.White;
            this.lblTopSellerLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTopSellerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopSellerLabel.Name = "lblTopSellerLabel";
            this.lblTopSellerLabel.Size = new System.Drawing.Size(75, 20);
            this.lblTopSellerLabel.TabIndex = 0;
            this.lblTopSellerLabel.Text = "Top Seller";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuItemIDDataGridViewTextBoxColumn,
            this.menuItemNameDataGridViewTextBoxColumn,
            this.totalSoldDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.topSellingItemBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 172);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 615);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuItemIDDataGridViewTextBoxColumn
            // 
            this.menuItemIDDataGridViewTextBoxColumn.DataPropertyName = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.menuItemIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.menuItemIDDataGridViewTextBoxColumn.Name = "menuItemIDDataGridViewTextBoxColumn";
            this.menuItemIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuItemNameDataGridViewTextBoxColumn
            // 
            this.menuItemNameDataGridViewTextBoxColumn.DataPropertyName = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.menuItemNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.menuItemNameDataGridViewTextBoxColumn.Name = "menuItemNameDataGridViewTextBoxColumn";
            this.menuItemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalSoldDataGridViewTextBoxColumn
            // 
            this.totalSoldDataGridViewTextBoxColumn.DataPropertyName = "TotalSold";
            this.totalSoldDataGridViewTextBoxColumn.HeaderText = "Total Sold";
            this.totalSoldDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalSoldDataGridViewTextBoxColumn.Name = "totalSoldDataGridViewTextBoxColumn";
            this.totalSoldDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // topSellingItemBindingSource1
            // 
            this.topSellingItemBindingSource1.DataMember = "TopSellingItem";
            this.topSellingItemBindingSource1.DataSource = this.dsCafe101Hub;
            // 
            // dsCafe101Hub
            // 
            this.dsCafe101Hub.DataSetName = "dsCafe101Hub";
            this.dsCafe101Hub.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelBestSellers
            // 
            this.panelBestSellers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelBestSellers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBestSellers.Controls.Add(this.lblBestSellersTitle);
            this.panelBestSellers.Controls.Add(this.panelGold);
            this.panelBestSellers.Controls.Add(this.panelSilver);
            this.panelBestSellers.Controls.Add(this.panelBronze);
            this.panelBestSellers.Location = new System.Drawing.Point(1093, 172);
            this.panelBestSellers.Margin = new System.Windows.Forms.Padding(4);
            this.panelBestSellers.Name = "panelBestSellers";
            this.panelBestSellers.Size = new System.Drawing.Size(879, 406);
            this.panelBestSellers.TabIndex = 15;
            // 
            // lblBestSellersTitle
            // 
            this.lblBestSellersTitle.AutoSize = true;
            this.lblBestSellersTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBestSellersTitle.ForeColor = System.Drawing.Color.White;
            this.lblBestSellersTitle.Location = new System.Drawing.Point(20, 12);
            this.lblBestSellersTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBestSellersTitle.Name = "lblBestSellersTitle";
            this.lblBestSellersTitle.Size = new System.Drawing.Size(286, 37);
            this.lblBestSellersTitle.TabIndex = 0;
            this.lblBestSellersTitle.Text = "🏆 Top 3 Best Sellers";
            // 
            // panelGold
            // 
            this.panelGold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.panelGold.Controls.Add(this.lblGoldMedal);
            this.panelGold.Controls.Add(this.lblGoldItem);
            this.panelGold.Controls.Add(this.txtGoldItem);
            this.panelGold.Location = new System.Drawing.Point(27, 62);
            this.panelGold.Margin = new System.Windows.Forms.Padding(4);
            this.panelGold.Name = "panelGold";
            this.panelGold.Size = new System.Drawing.Size(827, 86);
            this.panelGold.TabIndex = 1;
            // 
            // lblGoldMedal
            // 
            this.lblGoldMedal.AutoSize = true;
            this.lblGoldMedal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblGoldMedal.Location = new System.Drawing.Point(13, 18);
            this.lblGoldMedal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGoldMedal.Name = "lblGoldMedal";
            this.lblGoldMedal.Size = new System.Drawing.Size(79, 54);
            this.lblGoldMedal.TabIndex = 0;
            this.lblGoldMedal.Text = "🥇";
            // 
            // lblGoldItem
            // 
            this.lblGoldItem.AutoSize = true;
            this.lblGoldItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGoldItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblGoldItem.Location = new System.Drawing.Point(120, 31);
            this.lblGoldItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGoldItem.Name = "lblGoldItem";
            this.lblGoldItem.Size = new System.Drawing.Size(126, 28);
            this.lblGoldItem.TabIndex = 1;
            this.lblGoldItem.Text = "Gold Status:";
            // 
            // txtGoldItem
            // 
            this.txtGoldItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtGoldItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGoldItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtGoldItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtGoldItem.Location = new System.Drawing.Point(260, 31);
            this.txtGoldItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtGoldItem.Name = "txtGoldItem";
            this.txtGoldItem.ReadOnly = true;
            this.txtGoldItem.Size = new System.Drawing.Size(533, 27);
            this.txtGoldItem.TabIndex = 2;
            this.txtGoldItem.Text = "-";
            // 
            // panelSilver
            // 
            this.panelSilver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelSilver.Controls.Add(this.lblSilverMedal);
            this.panelSilver.Controls.Add(this.lblSilverItem);
            this.panelSilver.Controls.Add(this.txtSilverItem);
            this.panelSilver.Location = new System.Drawing.Point(27, 160);
            this.panelSilver.Margin = new System.Windows.Forms.Padding(4);
            this.panelSilver.Name = "panelSilver";
            this.panelSilver.Size = new System.Drawing.Size(827, 86);
            this.panelSilver.TabIndex = 2;
            // 
            // lblSilverMedal
            // 
            this.lblSilverMedal.AutoSize = true;
            this.lblSilverMedal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSilverMedal.Location = new System.Drawing.Point(13, 18);
            this.lblSilverMedal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSilverMedal.Name = "lblSilverMedal";
            this.lblSilverMedal.Size = new System.Drawing.Size(79, 54);
            this.lblSilverMedal.TabIndex = 0;
            this.lblSilverMedal.Text = "🥈";
            // 
            // lblSilverItem
            // 
            this.lblSilverItem.AutoSize = true;
            this.lblSilverItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSilverItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSilverItem.Location = new System.Drawing.Point(120, 31);
            this.lblSilverItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSilverItem.Name = "lblSilverItem";
            this.lblSilverItem.Size = new System.Drawing.Size(135, 28);
            this.lblSilverItem.TabIndex = 1;
            this.lblSilverItem.Text = "Silver Status:";
            // 
            // txtSilverItem
            // 
            this.txtSilverItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtSilverItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSilverItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSilverItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtSilverItem.Location = new System.Drawing.Point(279, 31);
            this.txtSilverItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSilverItem.Name = "txtSilverItem";
            this.txtSilverItem.ReadOnly = true;
            this.txtSilverItem.Size = new System.Drawing.Size(533, 27);
            this.txtSilverItem.TabIndex = 2;
            this.txtSilverItem.Text = "-";
            // 
            // panelBronze
            // 
            this.panelBronze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(127)))), ((int)(((byte)(50)))));
            this.panelBronze.Controls.Add(this.lblBronzeMedal);
            this.panelBronze.Controls.Add(this.lblBronzeItem);
            this.panelBronze.Controls.Add(this.txtBronzeItem);
            this.panelBronze.Location = new System.Drawing.Point(27, 258);
            this.panelBronze.Margin = new System.Windows.Forms.Padding(4);
            this.panelBronze.Name = "panelBronze";
            this.panelBronze.Size = new System.Drawing.Size(827, 86);
            this.panelBronze.TabIndex = 3;
            // 
            // lblBronzeMedal
            // 
            this.lblBronzeMedal.AutoSize = true;
            this.lblBronzeMedal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBronzeMedal.Location = new System.Drawing.Point(13, 18);
            this.lblBronzeMedal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBronzeMedal.Name = "lblBronzeMedal";
            this.lblBronzeMedal.Size = new System.Drawing.Size(79, 54);
            this.lblBronzeMedal.TabIndex = 0;
            this.lblBronzeMedal.Text = "🥉";
            // 
            // lblBronzeItem
            // 
            this.lblBronzeItem.AutoSize = true;
            this.lblBronzeItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBronzeItem.ForeColor = System.Drawing.Color.White;
            this.lblBronzeItem.Location = new System.Drawing.Point(120, 31);
            this.lblBronzeItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBronzeItem.Name = "lblBronzeItem";
            this.lblBronzeItem.Size = new System.Drawing.Size(148, 28);
            this.lblBronzeItem.TabIndex = 1;
            this.lblBronzeItem.Text = "Bronze Status:";
            // 
            // txtBronzeItem
            // 
            this.txtBronzeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(127)))), ((int)(((byte)(50)))));
            this.txtBronzeItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBronzeItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtBronzeItem.ForeColor = System.Drawing.Color.White;
            this.txtBronzeItem.Location = new System.Drawing.Point(279, 31);
            this.txtBronzeItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtBronzeItem.Name = "txtBronzeItem";
            this.txtBronzeItem.ReadOnly = true;
            this.txtBronzeItem.Size = new System.Drawing.Size(533, 27);
            this.txtBronzeItem.TabIndex = 2;
            this.txtBronzeItem.Text = "-";
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button2.Location = new System.Drawing.Point(243, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Check Stock";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button3.Location = new System.Drawing.Point(135, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 37);
            this.button3.TabIndex = 11;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.button4.Location = new System.Drawing.Point(27, 15);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 37);
            this.button4.TabIndex = 12;
            this.button4.Text = "Help";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelActions.Controls.Add(this.button4);
            this.panelActions.Controls.Add(this.button3);
            this.panelActions.Controls.Add(this.button2);
            this.panelActions.Controls.Add(this.button1);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 788);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1924, 71);
            this.panelActions.TabIndex = 16;
            // 
            // topSellingItemBindingSource
            // 
            this.topSellingItemBindingSource.DataMember = "TopSellingItem";
            this.topSellingItemBindingSource.DataSource = this.dsCafe101Test;
            // 
            // dsCafe101Test
            // 
            this.dsCafe101Test.DataSetName = "dsCafe101Test";
            this.dsCafe101Test.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // topSellingItemTableAdapter
            // 
            this.topSellingItemTableAdapter.ClearBeforeFill = true;
            // 
            // topSellingItemTableAdapter1
            // 
            this.topSellingItemTableAdapter1.ClearBeforeFill = true;
            // 
            // menuItemsTableBindingSource
            // 
            this.menuItemsTableBindingSource.DataMember = "MenuItemsTable";
            this.menuItemsTableBindingSource.DataSource = this.dsCafe101Hub;
            // 
            // menuItemsTableTableAdapter
            // 
            this.menuItemsTableTableAdapter.ClearBeforeFill = true;
            // 
            // topSellingItemBindingSource2
            // 
            this.topSellingItemBindingSource2.DataMember = "TopSellingItem";
            this.topSellingItemBindingSource2.DataSource = this.dsCafe101Hub;
            // 
            // frmPopularProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1924, 859);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelBestSellers);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPopularProduct";
            this.Text = "Popular Product";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPopularProduct_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.cardTotalProducts.ResumeLayout(false);
            this.cardTotalProducts.PerformLayout();
            this.cardTotalSales.ResumeLayout(false);
            this.cardTotalSales.PerformLayout();
            this.cardTopSeller.ResumeLayout(false);
            this.cardTopSeller.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            this.panelBestSellers.ResumeLayout(false);
            this.panelBestSellers.PerformLayout();
            this.panelGold.ResumeLayout(false);
            this.panelGold.PerformLayout();
            this.panelSilver.ResumeLayout(false);
            this.panelSilver.PerformLayout();
            this.panelBronze.ResumeLayout(false);
            this.panelBronze.PerformLayout();
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // ORIGINAL COMPONENTS - All kept the same
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource topSellingItemBindingSource;
        private dsCafe101TestTableAdapters.TopSellingItemTableAdapter topSellingItemTableAdapter;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource topSellingItemBindingSource1;
        private dsCafe101HubTableAdapters.TopSellingItemTableAdapter topSellingItemTableAdapter1;
        private System.Windows.Forms.BindingSource menuItemsTableBindingSource;
        private dsCafe101HubTableAdapters.MenuItemsTableTableAdapter menuItemsTableTableAdapter;
        private System.Windows.Forms.BindingSource topSellingItemBindingSource2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSoldDataGridViewTextBoxColumn;

        // NEW COMPONENTS
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardTotalProducts;
        private System.Windows.Forms.Label lblTotalProductsValue;
        private System.Windows.Forms.Label lblTotalProductsLabel;
        private System.Windows.Forms.Panel cardTotalSales;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Label lblTotalSalesLabel;
        private System.Windows.Forms.Panel cardTopSeller;
        private System.Windows.Forms.Label lblTopSellerValue;
        private System.Windows.Forms.Label lblTopSellerLabel;
        private System.Windows.Forms.Panel panelBestSellers;
        private System.Windows.Forms.Label lblBestSellersTitle;
        private System.Windows.Forms.Panel panelGold;
        private System.Windows.Forms.Label lblGoldMedal;
        private System.Windows.Forms.Label lblGoldItem;
        private System.Windows.Forms.TextBox txtGoldItem;
        private System.Windows.Forms.Panel panelSilver;
        private System.Windows.Forms.Label lblSilverMedal;
        private System.Windows.Forms.Label lblSilverItem;
        private System.Windows.Forms.TextBox txtSilverItem;
        private System.Windows.Forms.Panel panelBronze;
        private System.Windows.Forms.Label lblBronzeMedal;
        private System.Windows.Forms.Label lblBronzeItem;
        private System.Windows.Forms.TextBox txtBronzeItem;
        private System.Windows.Forms.Panel panelActions;
    }
}