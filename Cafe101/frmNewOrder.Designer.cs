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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ItemQty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MenuItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testMenuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101TestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.menuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.btnDecreaseQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.orderTableAdapter = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.menuItemsTableAdapter1 = new Cafe101.dsCafe101TableAdapters.MenuItemsTableAdapter();
            this.customerTableAdapter1 = new Cafe101.dsCafe101TableAdapters.CustomerTableAdapter();
            this.orderTableAdapter1 = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.itemOrderTableAdapter1 = new Cafe101.dsCafe101TableAdapters.ItemOrderTableAdapter();
            this.recipeItemTableAdapter1 = new Cafe101.dsCafe101TableAdapters.RecipeItemTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testCustomerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.testCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalChangeDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEventTime = new System.Windows.Forms.DateTimePicker();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.lblEventTime = new System.Windows.Forms.Label();
            this.btnClearCustName = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.testCustomerTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestCustomerTableAdapter();
            this.testMenuItemsTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestMenuItemsTableAdapter();
            this.testOrderTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestOrderTableAdapter();
            this.testOrderItemTableAdapter1 = new Cafe101.dsCafe101TestTableAdapters.TestOrderItemTableAdapter();
            this.testRecipeTableAdapter1 = new Cafe101.dsCafe101TestTableAdapters.TestRecipeTableAdapter();
            this.testIngredientTableAdapter1 = new Cafe101.dsCafe101TestTableAdapters.TestIngredientTableAdapter();
            this.btnAddNewCust = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MenuItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreparationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuItemsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.CustomerTableTableAdapter();
            this.menuItemsTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.MenuItemsTableTableAdapter();
            this.orderItemTableTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.OrderItemTableTableAdapter();
            this.recipeTableTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.RecipeTableTableAdapter();
            this.orderTableTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.OrderTableTableAdapter();
            this.ingredientTableTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.IngredientTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testMenuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101TestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCustomerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOrderBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchCust
            // 
            this.lblSearchCust.AutoSize = true;
            this.lblSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCust.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchCust.Location = new System.Drawing.Point(81, 39);
            this.lblSearchCust.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchCust.Name = "lblSearchCust";
            this.lblSearchCust.Size = new System.Drawing.Size(145, 18);
            this.lblSearchCust.TabIndex = 0;
            this.lblSearchCust.Text = "Search Customer:";
            // 
            // txtSearchedCust
            // 
            this.txtSearchedCust.Location = new System.Drawing.Point(253, 40);
            this.txtSearchedCust.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearchedCust.Name = "txtSearchedCust";
            this.txtSearchedCust.Size = new System.Drawing.Size(204, 20);
            this.txtSearchedCust.TabIndex = 1;
            this.txtSearchedCust.TextChanged += new System.EventHandler(this.txtSearchedCust_TextChanged);
            // 
            // btnSearchCust
            // 
            this.btnSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCust.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearchCust.Location = new System.Drawing.Point(497, 33);
            this.btnSearchCust.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchCust.Name = "btnSearchCust";
            this.btnSearchCust.Size = new System.Drawing.Size(88, 30);
            this.btnSearchCust.TabIndex = 2;
            this.btnSearchCust.Text = "Search";
            this.btnSearchCust.UseVisualStyleBackColor = true;
            this.btnSearchCust.Click += new System.EventHandler(this.btnSearchCust_Click);
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCustName.Location = new System.Drawing.Point(193, 94);
            this.lblCustName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(136, 18);
            this.lblCustName.TabIndex = 3;
            this.lblCustName.Text = "Customer Name:";
            // 
            // txtSearchedName
            // 
            this.txtSearchedName.Location = new System.Drawing.Point(351, 95);
            this.txtSearchedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearchedName.Name = "txtSearchedName";
            this.txtSearchedName.Size = new System.Drawing.Size(195, 20);
            this.txtSearchedName.TabIndex = 4;
            // 
            // lblSearchItems
            // 
            this.lblSearchItems.AutoSize = true;
            this.lblSearchItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchItems.Location = new System.Drawing.Point(153, 39);
            this.lblSearchItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchItems.Name = "lblSearchItems";
            this.lblSearchItems.Size = new System.Drawing.Size(149, 18);
            this.lblSearchItems.TabIndex = 5;
            this.lblSearchItems.Text = "Search Menu Item:";
            // 
            // textItemSearch
            // 
            this.textItemSearch.Location = new System.Drawing.Point(345, 37);
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
            this.btnSearchItem.Location = new System.Drawing.Point(603, 29);
            this.btnSearchItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(88, 33);
            this.btnSearchItem.TabIndex = 7;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddToCart.Location = new System.Drawing.Point(359, 333);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(187, 28);
            this.btnAddToCart.TabIndex = 10;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMenuItems.AutoGenerateColumns = false;
            this.dgvMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(48)))));
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemQty,
            this.MenuItemID,
            this.MenuItemName,
            this.sellingPrice,
            this.Category,
            this.PreparationTime});
            this.dgvMenuItems.DataSource = this.menuItemsTableBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenuItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMenuItems.Location = new System.Drawing.Point(22, 97);
            this.dgvMenuItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuItems.Size = new System.Drawing.Size(894, 210);
            this.dgvMenuItems.TabIndex = 11;
            this.dgvMenuItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuItems_CellContentClick);
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
            // MenuItemID
            // 
            this.MenuItemID.DataPropertyName = "MenuItemID";
            this.MenuItemID.HeaderText = "Menu Item ID";
            this.MenuItemID.Name = "MenuItemID";
            this.MenuItemID.ReadOnly = true;
            // 
            // testMenuItemsBindingSource
            // 
            this.testMenuItemsBindingSource.DataMember = "TestMenuItems";
            this.testMenuItemsBindingSource.DataSource = this.dsCafe101TestBindingSource;
            // 
            // dsCafe101TestBindingSource
            // 
            this.dsCafe101TestBindingSource.DataSource = this.dsCafe101Test;
            this.dsCafe101TestBindingSource.Position = 0;
            // 
            // dsCafe101Test
            // 
            this.dsCafe101Test.DataSetName = "dsCafe101Test";
            this.dsCafe101Test.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuItemsBindingSource
            // 
            this.menuItemsBindingSource.DataMember = "MenuItems";
            this.menuItemsBindingSource.DataSource = this.dsCafe101BindingSource;
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
            // dgvCart
            // 
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(48)))));
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.Location = new System.Drawing.Point(17, 39);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(656, 230);
            this.dgvCart.TabIndex = 12;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalPrice.Location = new System.Drawing.Point(455, 305);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(60, 18);
            this.lblTotalPrice.TabIndex = 13;
            this.lblTotalPrice.Text = "TOTAL";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmount.Location = new System.Drawing.Point(587, 305);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(57, 18);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "R 0.00";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOrder.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfirmOrder.Location = new System.Drawing.Point(258, 599);
            this.btnConfirmOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(191, 28);
            this.btnConfirmOrder.TabIndex = 15;
            this.btnConfirmOrder.Text = "Confirm Order";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // btnDecreaseQuantity
            // 
            this.btnDecreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseQuantity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDecreaseQuantity.Location = new System.Drawing.Point(101, 357);
            this.btnDecreaseQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            this.btnDecreaseQuantity.Size = new System.Drawing.Size(242, 28);
            this.btnDecreaseQuantity.TabIndex = 16;
            this.btnDecreaseQuantity.Text = "Decrease Quantity";
            this.btnDecreaseQuantity.UseVisualStyleBackColor = true;
            this.btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRemoveItem.Location = new System.Drawing.Point(415, 357);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(187, 28);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click_1);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cafe101.Properties.Resources.Logo_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(1551, 840);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.AutoGenerateColumns = false;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(21)))), ((int)(((byte)(48)))));
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.Surname,
            this.addressDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.CustomerID});
            this.dgvCustomers.DataSource = this.customerTableBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomers.Location = new System.Drawing.Point(84, 141);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(855, 319);
            this.dgvCustomers.TabIndex = 19;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.FillWeight = 0.8712624F;
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            // 
            // testCustomerBindingSource1
            // 
            this.testCustomerBindingSource1.DataMember = "TestCustomer";
            this.testCustomerBindingSource1.DataSource = this.dsCafe101TestBindingSource;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBack.Location = new System.Drawing.Point(1196, 896);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 28);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // testCustomerBindingSource
            // 
            this.testCustomerBindingSource.DataMember = "TestCustomer";
            this.testCustomerBindingSource.DataSource = this.dsCafe101TestBindingSource;
            // 
            // testOrderBindingSource
            // 
            this.testOrderBindingSource.DataMember = "TestOrder";
            this.testOrderBindingSource.DataSource = this.dsCafe101TestBindingSource;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIDDataGridViewTextBoxColumn1
            // 
            this.customerIDDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn1.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn1.Name = "customerIDDataGridViewTextBoxColumn1";
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            // 
            // orderDateTimeDataGridViewTextBoxColumn
            // 
            this.orderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.HeaderText = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.Name = "orderDateTimeDataGridViewTextBoxColumn";
            // 
            // eventDateDataGridViewTextBoxColumn
            // 
            this.eventDateDataGridViewTextBoxColumn.DataPropertyName = "EventDate";
            this.eventDateDataGridViewTextBoxColumn.HeaderText = "EventDate";
            this.eventDateDataGridViewTextBoxColumn.Name = "eventDateDataGridViewTextBoxColumn";
            // 
            // eventTimeDataGridViewTextBoxColumn
            // 
            this.eventTimeDataGridViewTextBoxColumn.DataPropertyName = "EventTime";
            this.eventTimeDataGridViewTextBoxColumn.HeaderText = "EventTime";
            this.eventTimeDataGridViewTextBoxColumn.Name = "eventTimeDataGridViewTextBoxColumn";
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            // 
            // totalAmountDueDataGridViewTextBoxColumn
            // 
            this.totalAmountDueDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.HeaderText = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.Name = "totalAmountDueDataGridViewTextBoxColumn";
            // 
            // totalChangeDueDataGridViewTextBoxColumn
            // 
            this.totalChangeDueDataGridViewTextBoxColumn.DataPropertyName = "TotalChangeDue";
            this.totalChangeDueDataGridViewTextBoxColumn.HeaderText = "TotalChangeDue";
            this.totalChangeDueDataGridViewTextBoxColumn.Name = "totalChangeDueDataGridViewTextBoxColumn";
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "Regular",
            "Event"});
            this.cmbOrderType.Location = new System.Drawing.Point(358, 423);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(204, 21);
            this.cmbOrderType.TabIndex = 21;
            this.cmbOrderType.SelectedIndexChanged += new System.EventHandler(this.cmbOrderType_SelectedIndexChanged);
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOrderType.Location = new System.Drawing.Point(140, 422);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(149, 18);
            this.lblOrderType.TabIndex = 22;
            this.lblOrderType.Text = "Select Order Type:";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(358, 480);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEventDate.TabIndex = 23;
            // 
            // dtpEventTime
            // 
            this.dtpEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEventTime.Location = new System.Drawing.Point(362, 536);
            this.dtpEventTime.Name = "dtpEventTime";
            this.dtpEventTime.ShowUpDown = true;
            this.dtpEventTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEventTime.TabIndex = 24;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEventDate.Location = new System.Drawing.Point(192, 480);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(95, 18);
            this.lblEventDate.TabIndex = 25;
            this.lblEventDate.Text = "Event Date:";
            // 
            // lblEventTime
            // 
            this.lblEventTime.AutoSize = true;
            this.lblEventTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEventTime.Location = new System.Drawing.Point(192, 536);
            this.lblEventTime.Name = "lblEventTime";
            this.lblEventTime.Size = new System.Drawing.Size(97, 18);
            this.lblEventTime.TabIndex = 26;
            this.lblEventTime.Text = "Event Time:";
            // 
            // btnClearCustName
            // 
            this.btnClearCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCustName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClearCustName.Location = new System.Drawing.Point(570, 94);
            this.btnClearCustName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearCustName.Name = "btnClearCustName";
            this.btnClearCustName.Size = new System.Drawing.Size(88, 24);
            this.btnClearCustName.TabIndex = 27;
            this.btnClearCustName.Text = "Clear";
            this.btnClearCustName.UseVisualStyleBackColor = true;
            this.btnClearCustName.Click += new System.EventHandler(this.btnClearCustName_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnHelp.Location = new System.Drawing.Point(1345, 897);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 28);
            this.btnHelp.TabIndex = 28;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // testCustomerTableAdapter
            // 
            this.testCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // testMenuItemsTableAdapter
            // 
            this.testMenuItemsTableAdapter.ClearBeforeFill = true;
            // 
            // testOrderTableAdapter
            // 
            this.testOrderTableAdapter.ClearBeforeFill = true;
            // 
            // testOrderItemTableAdapter1
            // 
            this.testOrderItemTableAdapter1.ClearBeforeFill = true;
            // 
            // testRecipeTableAdapter1
            // 
            this.testRecipeTableAdapter1.ClearBeforeFill = true;
            // 
            // testIngredientTableAdapter1
            // 
            this.testIngredientTableAdapter1.ClearBeforeFill = true;
            // 
            // btnAddNewCust
            // 
            this.btnAddNewCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCust.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddNewCust.Location = new System.Drawing.Point(643, 33);
            this.btnAddNewCust.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddNewCust.Name = "btnAddNewCust";
            this.btnAddNewCust.Size = new System.Drawing.Size(198, 30);
            this.btnAddNewCust.TabIndex = 29;
            this.btnAddNewCust.Text = "Add New Customer";
            this.btnAddNewCust.UseVisualStyleBackColor = true;
            this.btnAddNewCust.Click += new System.EventHandler(this.btnAddNewCust_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnSearchCust);
            this.groupBox1.Controls.Add(this.lblSearchCust);
            this.groupBox1.Controls.Add(this.btnAddNewCust);
            this.groupBox1.Controls.Add(this.txtSearchedCust);
            this.groupBox1.Controls.Add(this.btnClearCustName);
            this.groupBox1.Controls.Add(this.txtSearchedName);
            this.groupBox1.Controls.Add(this.lblCustName);
            this.groupBox1.Controls.Add(this.dgvCustomers);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(28, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 496);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STEP 1: SELECT A CUSTOMER";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.dgvMenuItems);
            this.groupBox2.Controls.Add(this.textItemSearch);
            this.groupBox2.Controls.Add(this.lblSearchItems);
            this.groupBox2.Controls.Add(this.btnSearchItem);
            this.groupBox2.Controls.Add(this.btnAddToCart);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(28, 554);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(974, 398);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STEP 2: SELECT MENU ITEMS AND ADD TO CART";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.dgvCart);
            this.groupBox3.Controls.Add(this.btnRemoveItem);
            this.groupBox3.Controls.Add(this.lblTotalPrice);
            this.groupBox3.Controls.Add(this.lblAmount);
            this.groupBox3.Controls.Add(this.lblEventTime);
            this.groupBox3.Controls.Add(this.btnConfirmOrder);
            this.groupBox3.Controls.Add(this.lblEventDate);
            this.groupBox3.Controls.Add(this.btnDecreaseQuantity);
            this.groupBox3.Controls.Add(this.dtpEventTime);
            this.groupBox3.Controls.Add(this.dtpEventDate);
            this.groupBox3.Controls.Add(this.lblOrderType);
            this.groupBox3.Controls.Add(this.cmbOrderType);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Location = new System.Drawing.Point(1029, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 665);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "STEP 3: CONFIRM YOUR CART AND PLACE YOUR ORDER";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // MenuItemName
            // 
            this.MenuItemName.DataPropertyName = "MenuItemName";
            this.MenuItemName.HeaderText = "Item Name";
            this.MenuItemName.Name = "MenuItemName";
            // 
            // sellingPrice
            // 
            this.sellingPrice.DataPropertyName = "SellingPrice";
            this.sellingPrice.HeaderText = "Selling Price";
            this.sellingPrice.Name = "sellingPrice";
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // PreparationTime
            // 
            this.PreparationTime.DataPropertyName = "PreparationTime";
            this.PreparationTime.HeaderText = "Preparation Time";
            this.PreparationTime.Name = "PreparationTime";
            // 
            // menuItemsTableBindingSource
            // 
            this.menuItemsTableBindingSource.DataMember = "MenuItemsTable";
            this.menuItemsTableBindingSource.DataSource = this.dsCafe101Hub;
            // 
            // dsCafe101Hub
            // 
            this.dsCafe101Hub.DataSetName = "dsCafe101Hub";
            this.dsCafe101Hub.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.FillWeight = 12.48717F;
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 150;
            // 
            // Surname
            // 
            this.Surname.DataPropertyName = "Surname";
            this.Surname.FillWeight = 52.18124F;
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.Width = 150;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.FillWeight = 431.4721F;
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.Width = 210;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.FillWeight = 2.988253F;
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 170;
            // 
            // customerTableBindingSource
            // 
            this.customerTableBindingSource.DataMember = "CustomerTable";
            this.customerTableBindingSource.DataSource = this.dsCafe101Hub;
            // 
            // customerTableTableAdapter
            // 
            this.customerTableTableAdapter.ClearBeforeFill = true;
            // 
            // menuItemsTableTableAdapter
            // 
            this.menuItemsTableTableAdapter.ClearBeforeFill = true;
            // 
            // orderItemTableTableAdapter1
            // 
            this.orderItemTableTableAdapter1.ClearBeforeFill = true;
            // 
            // recipeTableTableAdapter1
            // 
            this.recipeTableTableAdapter1.ClearBeforeFill = true;
            // 
            // orderTableTableAdapter1
            // 
            this.orderTableTableAdapter1.ClearBeforeFill = true;
            // 
            // ingredientTableTableAdapter1
            // 
            this.ingredientTableTableAdapter1.ClearBeforeFill = true;
            // 
            // frmNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1733, 999);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmNewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testMenuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101TestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCustomerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOrderBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableBindingSource)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnDecreaseQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private dsCafe101TableAdapters.OrderTableAdapter orderTableAdapter1;
        private dsCafe101TableAdapters.ItemOrderTableAdapter itemOrderTableAdapter1;
        private dsCafe101TableAdapters.RecipeItemTableAdapter recipeItemTableAdapter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.BindingSource dsCafe101TestBindingSource;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource testCustomerBindingSource;
        private dsCafe101TestTableAdapters.TestCustomerTableAdapter testCustomerTableAdapter;
        private System.Windows.Forms.BindingSource testMenuItemsBindingSource;
        private dsCafe101TestTableAdapters.TestMenuItemsTableAdapter testMenuItemsTableAdapter;
        private System.Windows.Forms.BindingSource testOrderBindingSource;
        private dsCafe101TestTableAdapters.TestOrderTableAdapter testOrderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalChangeDueDataGridViewTextBoxColumn;
        private dsCafe101TestTableAdapters.TestOrderItemTableAdapter testOrderItemTableAdapter1;
        private dsCafe101TestTableAdapters.TestRecipeTableAdapter testRecipeTableAdapter1;
        private dsCafe101TestTableAdapters.TestIngredientTableAdapter testIngredientTableAdapter1;
        private System.Windows.Forms.BindingSource testCustomerBindingSource1;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.DateTimePicker dtpEventTime;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.Label lblEventTime;
        private System.Windows.Forms.Button btnClearCustName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreparationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAddNewCust;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource customerTableBindingSource;
        private dsCafe101HubTableAdapters.CustomerTableTableAdapter customerTableTableAdapter;
        private System.Windows.Forms.BindingSource menuItemsTableBindingSource;
        private dsCafe101HubTableAdapters.MenuItemsTableTableAdapter menuItemsTableTableAdapter;
        private dsCafe101HubTableAdapters.OrderItemTableTableAdapter orderItemTableTableAdapter1;
        private dsCafe101HubTableAdapters.RecipeTableTableAdapter recipeTableTableAdapter1;
        private dsCafe101HubTableAdapters.OrderTableTableAdapter orderTableTableAdapter1;
        private dsCafe101HubTableAdapters.IngredientTableTableAdapter ingredientTableTableAdapter1;
    }
}