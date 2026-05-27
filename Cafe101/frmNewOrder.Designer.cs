namespace Cafe101
{
    partial class frmNewOrder
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
            this.lblSearchCust = new System.Windows.Forms.Label();
            this.txtSearchedCust = new System.Windows.Forms.TextBox();
            this.btnSearchCust = new System.Windows.Forms.Button();
            this.lblCustName = new System.Windows.Forms.Label();
            this.txtSearchedName = new System.Windows.Forms.TextBox();
            this.lblSearchItems = new System.Windows.Forms.Label();
            this.textItemSearch = new System.Windows.Forms.TextBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.MenuItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.btnDecreaseQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.menuItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsCafe101BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.orderTableAdapter = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.menuItemsTableAdapter1 = new Cafe101.dsCafe101TableAdapters.MenuItemsTableAdapter();
            this.customerTableAdapter1 = new Cafe101.dsCafe101TableAdapters.CustomerTableAdapter();
            this.orderTableAdapter1 = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.itemOrderTableAdapter1 = new Cafe101.dsCafe101TableAdapters.ItemOrderTableAdapter();
            this.recipeItemTableAdapter1 = new Cafe101.dsCafe101TableAdapters.RecipeItemTableAdapter();
            this.ingredientTableAdapter1 = new Cafe101.dsCafe101TableAdapters.IngredientTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchCust
            // 
            this.lblSearchCust.AutoSize = true;
            this.lblSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSearchCust.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchCust.Location = new System.Drawing.Point(71, 41);
            this.lblSearchCust.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchCust.Name = "lblSearchCust";
            this.lblSearchCust.Size = new System.Drawing.Size(130, 13);
            this.lblSearchCust.TabIndex = 0;
            this.lblSearchCust.Text = "SEARCH CUSTOMER";
            // 
            // txtSearchedCust
            // 
            this.txtSearchedCust.Location = new System.Drawing.Point(243, 38);
            this.txtSearchedCust.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearchedCust.Name = "txtSearchedCust";
            this.txtSearchedCust.Size = new System.Drawing.Size(204, 20);
            this.txtSearchedCust.TabIndex = 1;
            // 
            // btnSearchCust
            // 
            this.btnSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCust.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearchCust.Location = new System.Drawing.Point(487, 31);
            this.btnSearchCust.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchCust.Name = "btnSearchCust";
            this.btnSearchCust.Size = new System.Drawing.Size(88, 30);
            this.btnSearchCust.TabIndex = 2;
            this.btnSearchCust.Text = "SEARCH";
            this.btnSearchCust.UseVisualStyleBackColor = true;
            this.btnSearchCust.Click += new System.EventHandler(this.btnSearchCust_Click);
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCustName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCustName.Location = new System.Drawing.Point(662, 41);
            this.lblCustName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(42, 13);
            this.lblCustName.TabIndex = 3;
            this.lblCustName.Text = "NAME";
            // 
            // txtSearchedName
            // 
            this.txtSearchedName.Location = new System.Drawing.Point(747, 38);
            this.txtSearchedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearchedName.Name = "txtSearchedName";
            this.txtSearchedName.Size = new System.Drawing.Size(195, 20);
            this.txtSearchedName.TabIndex = 4;
            // 
            // lblSearchItems
            // 
            this.lblSearchItems.AutoSize = true;
            this.lblSearchItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchItems.Location = new System.Drawing.Point(227, 110);
            this.lblSearchItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchItems.Name = "lblSearchItems";
            this.lblSearchItems.Size = new System.Drawing.Size(143, 13);
            this.lblSearchItems.TabIndex = 5;
            this.lblSearchItems.Text = "SEARCH MENU ITEM : ";
            // 
            // textItemSearch
            // 
            this.textItemSearch.Location = new System.Drawing.Point(404, 107);
            this.textItemSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textItemSearch.Name = "textItemSearch";
            this.textItemSearch.Size = new System.Drawing.Size(199, 20);
            this.textItemSearch.TabIndex = 6;
            this.textItemSearch.TextChanged += new System.EventHandler(this.textItemSearch_TextChanged);
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearchItem.Location = new System.Drawing.Point(656, 99);
            this.btnSearchItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(88, 33);
            this.btnSearchItem.TabIndex = 7;
            this.btnSearchItem.Text = "SEARCH";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddToCart.Location = new System.Drawing.Point(416, 347);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(187, 28);
            this.btnAddToCart.TabIndex = 10;
            this.btnAddToCart.Text = "ADD TO CART";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.AutoGenerateColumns = false;
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuItemNameDataGridViewTextBoxColumn,
            this.MenuItemID,
            this.priceDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.prepTimeDataGridViewTextBoxColumn,
            this.ItemQty});
            this.dgvMenuItems.DataSource = this.menuItemsBindingSource;
            this.dgvMenuItems.Location = new System.Drawing.Point(178, 148);
            this.dgvMenuItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(690, 181);
            this.dgvMenuItems.TabIndex = 11;
            // 
            // MenuItemID
            // 
            this.MenuItemID.DataPropertyName = "MenuItemID";
            this.MenuItemID.HeaderText = "Item ID";
            this.MenuItemID.Name = "MenuItemID";
            this.MenuItemID.ReadOnly = true;
            // 
            // ItemQty
            // 
            this.ItemQty.HeaderText = "Quantity";
            this.ItemQty.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ItemQty.Name = "ItemQty";
            this.ItemQty.ReadOnly = true;
            // 
            // menuItemsBindingSource
            // 
            this.menuItemsBindingSource.DataMember = "MenuItems";
            this.menuItemsBindingSource.DataSource = this.dsCafe101BindingSource;
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(178, 401);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(702, 158);
            this.dgvCart.TabIndex = 12;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalPrice.Location = new System.Drawing.Point(337, 656);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(47, 13);
            this.lblTotalPrice.TabIndex = 13;
            this.lblTotalPrice.Text = "TOTAL";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmount.Location = new System.Drawing.Point(469, 656);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(45, 13);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "R 0.00";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOrder.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirmOrder.Location = new System.Drawing.Point(566, 651);
            this.btnConfirmOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(191, 28);
            this.btnConfirmOrder.TabIndex = 15;
            this.btnConfirmOrder.Text = "CONFIRM ORDER";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // btnDecreaseQuantity
            // 
            this.btnDecreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseQuantity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDecreaseQuantity.Location = new System.Drawing.Point(243, 581);
            this.btnDecreaseQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            this.btnDecreaseQuantity.Size = new System.Drawing.Size(242, 28);
            this.btnDecreaseQuantity.TabIndex = 16;
            this.btnDecreaseQuantity.Text = "DECREASE QUANTITY";
            this.btnDecreaseQuantity.UseVisualStyleBackColor = true;
            this.btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRemoveItem.Location = new System.Drawing.Point(614, 581);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(187, 28);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "REMOVE ITEM";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click_1);
            // 
            // menuItemNameDataGridViewTextBoxColumn
            // 
            this.menuItemNameDataGridViewTextBoxColumn.DataPropertyName = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.menuItemNameDataGridViewTextBoxColumn.Name = "menuItemNameDataGridViewTextBoxColumn";
            this.menuItemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prepTimeDataGridViewTextBoxColumn
            // 
            this.prepTimeDataGridViewTextBoxColumn.DataPropertyName = "PrepTime";
            this.prepTimeDataGridViewTextBoxColumn.HeaderText = "PrepTime";
            this.prepTimeDataGridViewTextBoxColumn.Name = "prepTimeDataGridViewTextBoxColumn";
            this.prepTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsCafe101BindingSource
            // 
            this.dsCafe101BindingSource.DataSource = this.dsCafe101;
            this.dsCafe101BindingSource.Position = 0;
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // menuItemsTableAdapter1
            // 
            this.menuItemsTableAdapter1.ClearBeforeFill = true;
            // 
            // customerTableAdapter1
            // 
            this.customerTableAdapter1.ClearBeforeFill = true;
            // 
            // orderTableAdapter1
            // 
            this.orderTableAdapter1.ClearBeforeFill = true;
            // 
            // itemOrderTableAdapter1
            // 
            this.itemOrderTableAdapter1.ClearBeforeFill = true;
            // 
            // recipeItemTableAdapter1
            // 
            this.recipeItemTableAdapter1.ClearBeforeFill = true;
            // 
            // ingredientTableAdapter1
            // 
            this.ingredientTableAdapter1.ClearBeforeFill = true;
            // 
            // frmNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1066, 691);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnDecreaseQuantity);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.dgvMenuItems);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnSearchItem);
            this.Controls.Add(this.textItemSearch);
            this.Controls.Add(this.lblSearchItems);
            this.Controls.Add(this.txtSearchedName);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.btnSearchCust);
            this.Controls.Add(this.txtSearchedCust);
            this.Controls.Add(this.lblSearchCust);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmNewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.frmNewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchCust;
        private System.Windows.Forms.TextBox txtSearchedCust;
        private System.Windows.Forms.Button btnSearchCust;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox txtSearchedName;
        private System.Windows.Forms.Label lblSearchItems;
        private System.Windows.Forms.TextBox textItemSearch;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvMenuItems;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.BindingSource dsCafe101BindingSource;
        private dsCafe101 dsCafe101;
        private System.Windows.Forms.BindingSource menuItemsBindingSource;
        private dsCafe101TableAdapters.OrderTableAdapter orderTableAdapter;
        private dsCafe101TableAdapters.MenuItemsTableAdapter menuItemsTableAdapter1;
        private dsCafe101TableAdapters.CustomerTableAdapter customerTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemQty;
        private System.Windows.Forms.Button btnDecreaseQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private dsCafe101TableAdapters.OrderTableAdapter orderTableAdapter1;
        private dsCafe101TableAdapters.ItemOrderTableAdapter itemOrderTableAdapter1;
        private dsCafe101TableAdapters.RecipeItemTableAdapter recipeItemTableAdapter1;
        private dsCafe101TableAdapters.IngredientTableAdapter ingredientTableAdapter1;
    }
}