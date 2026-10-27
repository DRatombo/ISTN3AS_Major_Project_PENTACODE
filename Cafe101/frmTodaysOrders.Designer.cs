namespace Cafe101
{
    partial class frmTodaysOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.cardTotalOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblTotalOrdersLabel = new System.Windows.Forms.Label();
            this.cardTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenueLabel = new System.Windows.Forms.Label();
            this.cardAverageOrder = new System.Windows.Forms.Panel();
            this.lblAverageOrderValue = new System.Windows.Forms.Label();
            this.lblAverageOrderLabel = new System.Windows.Forms.Label();
            this.numOrders = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.orderDataGridView = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalChangeDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.orderTableAdapter = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.tableAdapterManager = new Cafe101.dsCafe101TableAdapters.TableAdapterManager();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelStats.SuspendLayout();
            this.cardTotalOrders.SuspendLayout();
            this.cardTotalRevenue.SuspendLayout();
            this.cardAverageOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1723, 70);
            this.panelHeader.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cafe101.Properties.Resources.Logo_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(20, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(80, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Today\'s Orders";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelStats.Controls.Add(this.cardTotalOrders);
            this.panelStats.Controls.Add(this.cardTotalRevenue);
            this.panelStats.Controls.Add(this.cardAverageOrder);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelStats.Size = new System.Drawing.Size(1723, 80);
            this.panelStats.TabIndex = 12;
            // 
            // cardTotalOrders
            // 
            this.cardTotalOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardTotalOrders.Controls.Add(this.lblTotalOrdersValue);
            this.cardTotalOrders.Controls.Add(this.lblTotalOrdersLabel);
            this.cardTotalOrders.Location = new System.Drawing.Point(20, 10);
            this.cardTotalOrders.Name = "cardTotalOrders";
            this.cardTotalOrders.Size = new System.Drawing.Size(160, 60);
            this.cardTotalOrders.TabIndex = 0;
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.AutoSize = true;
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(10, 0);
            this.lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(40, 46);
            this.lblTotalOrdersValue.TabIndex = 1;
            this.lblTotalOrdersValue.Text = "0";
            // 
            // lblTotalOrdersLabel
            // 
            this.lblTotalOrdersLabel.AutoSize = true;
            this.lblTotalOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalOrdersLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrdersLabel.Location = new System.Drawing.Point(12, 42);
            this.lblTotalOrdersLabel.Name = "lblTotalOrdersLabel";
            this.lblTotalOrdersLabel.Size = new System.Drawing.Size(90, 20);
            this.lblTotalOrdersLabel.TabIndex = 0;
            this.lblTotalOrdersLabel.Text = "Total Orders";
            // 
            // cardTotalRevenue
            // 
            this.cardTotalRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardTotalRevenue.Controls.Add(this.lblTotalRevenueValue);
            this.cardTotalRevenue.Controls.Add(this.lblTotalRevenueLabel);
            this.cardTotalRevenue.Location = new System.Drawing.Point(190, 10);
            this.cardTotalRevenue.Name = "cardTotalRevenue";
            this.cardTotalRevenue.Size = new System.Drawing.Size(180, 60);
            this.cardTotalRevenue.TabIndex = 1;
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.AutoSize = true;
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(8, 0);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(111, 46);
            this.lblTotalRevenueValue.TabIndex = 1;
            this.lblTotalRevenueValue.Text = "R0.00";
            this.lblTotalRevenueValue.Click += new System.EventHandler(this.lblTotalRevenueValue_Click);
            // 
            // lblTotalRevenueLabel
            // 
            this.lblTotalRevenueLabel.AutoSize = true;
            this.lblTotalRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRevenueLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenueLabel.Location = new System.Drawing.Point(12, 42);
            this.lblTotalRevenueLabel.Name = "lblTotalRevenueLabel";
            this.lblTotalRevenueLabel.Size = new System.Drawing.Size(102, 20);
            this.lblTotalRevenueLabel.TabIndex = 0;
            this.lblTotalRevenueLabel.Text = "Total Revenue";
            // 
            // cardAverageOrder
            // 
            this.cardAverageOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.cardAverageOrder.Controls.Add(this.lblAverageOrderValue);
            this.cardAverageOrder.Controls.Add(this.lblAverageOrderLabel);
            this.cardAverageOrder.Location = new System.Drawing.Point(380, 10);
            this.cardAverageOrder.Name = "cardAverageOrder";
            this.cardAverageOrder.Size = new System.Drawing.Size(180, 60);
            this.cardAverageOrder.TabIndex = 2;
            // 
            // lblAverageOrderValue
            // 
            this.lblAverageOrderValue.AutoSize = true;
            this.lblAverageOrderValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAverageOrderValue.ForeColor = System.Drawing.Color.White;
            this.lblAverageOrderValue.Location = new System.Drawing.Point(3, 0);
            this.lblAverageOrderValue.Name = "lblAverageOrderValue";
            this.lblAverageOrderValue.Size = new System.Drawing.Size(111, 46);
            this.lblAverageOrderValue.TabIndex = 1;
            this.lblAverageOrderValue.Text = "R0.00";
            // 
            // lblAverageOrderLabel
            // 
            this.lblAverageOrderLabel.AutoSize = true;
            this.lblAverageOrderLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAverageOrderLabel.ForeColor = System.Drawing.Color.White;
            this.lblAverageOrderLabel.Location = new System.Drawing.Point(12, 42);
            this.lblAverageOrderLabel.Name = "lblAverageOrderLabel";
            this.lblAverageOrderLabel.Size = new System.Drawing.Size(106, 20);
            this.lblAverageOrderLabel.TabIndex = 0;
            this.lblAverageOrderLabel.Text = "Average Order";
            // 
            // numOrders
            // 
            this.numOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numOrders.AutoSize = true;
            this.numOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.numOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numOrders.Location = new System.Drawing.Point(687, 780);
            this.numOrders.Name = "numOrders";
            this.numOrders.Size = new System.Drawing.Size(353, 28);
            this.numOrders.TabIndex = 6;
            this.numOrders.Text = "Date: 31 Aug 2026    Total Orders: 0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(687, 805);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Revenue :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.textBox1.Location = new System.Drawing.Point(781, 803);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 32);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "R 0.00";
            // 
            // orderDataGridView
            // 
            this.orderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDataGridView.AutoGenerateColumns = false;
            this.orderDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.cashierIDDataGridViewTextBoxColumn,
            this.orderDateTimeDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn,
            this.totalAmountDueDataGridViewTextBoxColumn,
            this.totalChangeDueDataGridViewTextBoxColumn,
            this.deliveryCostDataGridViewTextBoxColumn});
            this.orderDataGridView.DataSource = this.orderBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderDataGridView.Location = new System.Drawing.Point(0, 150);
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.ReadOnly = true;
            this.orderDataGridView.RowHeadersWidth = 51;
            this.orderDataGridView.RowTemplate.Height = 24;
            this.orderDataGridView.Size = new System.Drawing.Size(1723, 620);
            this.orderDataGridView.TabIndex = 2;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "Order #";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // cashierIDDataGridViewTextBoxColumn
            // 
            this.cashierIDDataGridViewTextBoxColumn.DataPropertyName = "CashierID";
            this.cashierIDDataGridViewTextBoxColumn.HeaderText = "Cashier";
            this.cashierIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cashierIDDataGridViewTextBoxColumn.Name = "cashierIDDataGridViewTextBoxColumn";
            this.cashierIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashierIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderDateTimeDataGridViewTextBoxColumn
            // 
            this.orderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.HeaderText = "Date & Time";
            this.orderDateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDateTimeDataGridViewTextBoxColumn.Name = "orderDateTimeDataGridViewTextBoxColumn";
            this.orderDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderDateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.orderStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            this.orderStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "Payment";
            this.paymentMethodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentMethodDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalAmountDueDataGridViewTextBoxColumn
            // 
            this.totalAmountDueDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.HeaderText = "Total (R)";
            this.totalAmountDueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalAmountDueDataGridViewTextBoxColumn.Name = "totalAmountDueDataGridViewTextBoxColumn";
            this.totalAmountDueDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalAmountDueDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalChangeDueDataGridViewTextBoxColumn
            // 
            this.totalChangeDueDataGridViewTextBoxColumn.DataPropertyName = "TotalChangeDue";
            this.totalChangeDueDataGridViewTextBoxColumn.HeaderText = "Change";
            this.totalChangeDueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalChangeDueDataGridViewTextBoxColumn.Name = "totalChangeDueDataGridViewTextBoxColumn";
            this.totalChangeDueDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalChangeDueDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryCostDataGridViewTextBoxColumn
            // 
            this.deliveryCostDataGridViewTextBoxColumn.DataPropertyName = "DeliveryCost";
            this.deliveryCostDataGridViewTextBoxColumn.HeaderText = "Delivery";
            this.deliveryCostDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryCostDataGridViewTextBoxColumn.Name = "deliveryCostDataGridViewTextBoxColumn";
            this.deliveryCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryCostDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.dsCafe101;
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Controls.Add(this.btnClose);
            this.panelActions.Controls.Add(this.btnPrint);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 850);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1723, 70);
            this.panelActions.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnRefresh.Location = new System.Drawing.Point(20, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnClose.Location = new System.Drawing.Point(1553, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnPrint.Location = new System.Drawing.Point(1393, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 40);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CashierTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.IngredientTableAdapter = null;
            this.tableAdapterManager.ItemOrderTableAdapter = null;
            this.tableAdapterManager.MenuItemsTableAdapter = null;
            this.tableAdapterManager.OrderTableAdapter = this.orderTableAdapter;
            this.tableAdapterManager.RecipeItemTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Cafe101.dsCafe101TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmTodaysOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1723, 920);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.orderDataGridView);
            this.Controls.Add(this.numOrders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmTodaysOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Orders";
            this.Load += new System.EventHandler(this.frmTodaysOrders_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.cardTotalOrders.ResumeLayout(false);
            this.cardTotalOrders.PerformLayout();
            this.cardTotalRevenue.ResumeLayout(false);
            this.cardTotalRevenue.PerformLayout();
            this.cardAverageOrder.ResumeLayout(false);
            this.cardAverageOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Data Components
        private dsCafe101 dsCafe101;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private dsCafe101TableAdapters.OrderTableAdapter orderTableAdapter;
        private dsCafe101TableAdapters.TableAdapterManager tableAdapterManager;

        // Original UI Components (Preserved)
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label numOrders;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;

        // Original DataGridView Columns
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalChangeDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryCostDataGridViewTextBoxColumn;

        // New UI Components
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.Label lblTotalOrdersLabel;
        private System.Windows.Forms.Panel cardTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblTotalRevenueLabel;
        private System.Windows.Forms.Panel cardAverageOrder;
        private System.Windows.Forms.Label lblAverageOrderValue;
        private System.Windows.Forms.Label lblAverageOrderLabel;
        private System.Windows.Forms.Panel panelActions;
    }
}