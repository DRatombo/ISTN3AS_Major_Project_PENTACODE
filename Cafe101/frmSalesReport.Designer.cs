namespace Cafe101
{
    partial class frmSalesReport
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
            this.cardTotalOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblTotalOrdersLabel = new System.Windows.Forms.Label();
            this.cardTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenueLabel = new System.Windows.Forms.Label();
            this.cardAvgOrder = new System.Windows.Forms.Panel();
            this.lblAvgOrderValue = new System.Windows.Forms.Label();
            this.lblAvgOrderLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.panelDateFilter = new System.Windows.Forms.Panel();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblDateNote = new System.Windows.Forms.Label();
            this.btnTodayOrders = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.panelRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.testOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.testOrderTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestOrderTableAdapter();
            this.orderTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.OrderTableTableAdapter();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelStats.SuspendLayout();
            this.cardTotalOrders.SuspendLayout();
            this.cardTotalRevenue.SuspendLayout();
            this.cardAvgOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            this.panelDateFilter.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
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
            this.panelHeader.TabIndex = 15;
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
            this.lblTitle.Size = new System.Drawing.Size(194, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sales Report";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelStats.Controls.Add(this.cardTotalOrders);
            this.panelStats.Controls.Add(this.cardTotalRevenue);
            this.panelStats.Controls.Add(this.cardAvgOrder);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 74);
            this.panelStats.Margin = new System.Windows.Forms.Padding(4);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.panelStats.Size = new System.Drawing.Size(1924, 98);
            this.panelStats.TabIndex = 16;
            // 
            // cardTotalOrders
            // 
            this.cardTotalOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardTotalOrders.Controls.Add(this.lblTotalOrdersValue);
            this.cardTotalOrders.Controls.Add(this.lblTotalOrdersLabel);
            this.cardTotalOrders.Location = new System.Drawing.Point(27, 12);
            this.cardTotalOrders.Margin = new System.Windows.Forms.Padding(4);
            this.cardTotalOrders.Name = "cardTotalOrders";
            this.cardTotalOrders.Size = new System.Drawing.Size(213, 74);
            this.cardTotalOrders.TabIndex = 0;
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.AutoSize = true;
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(16, 6);
            this.lblTotalOrdersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lblTotalOrdersLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTotalOrdersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.cardTotalRevenue.Location = new System.Drawing.Point(253, 12);
            this.cardTotalRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.cardTotalRevenue.Name = "cardTotalRevenue";
            this.cardTotalRevenue.Size = new System.Drawing.Size(240, 74);
            this.cardTotalRevenue.TabIndex = 1;
            // 
            // lblTotalRevenueValue
            // 
            this.lblTotalRevenueValue.AutoSize = true;
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(16, 6);
            this.lblTotalRevenueValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(111, 46);
            this.lblTotalRevenueValue.TabIndex = 1;
            this.lblTotalRevenueValue.Text = "R0.00";
            // 
            // lblTotalRevenueLabel
            // 
            this.lblTotalRevenueLabel.AutoSize = true;
            this.lblTotalRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRevenueLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenueLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTotalRevenueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRevenueLabel.Name = "lblTotalRevenueLabel";
            this.lblTotalRevenueLabel.Size = new System.Drawing.Size(102, 20);
            this.lblTotalRevenueLabel.TabIndex = 0;
            this.lblTotalRevenueLabel.Text = "Total Revenue";
            // 
            // cardAvgOrder
            // 
            this.cardAvgOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.cardAvgOrder.Controls.Add(this.lblAvgOrderValue);
            this.cardAvgOrder.Controls.Add(this.lblAvgOrderLabel);
            this.cardAvgOrder.Location = new System.Drawing.Point(507, 12);
            this.cardAvgOrder.Margin = new System.Windows.Forms.Padding(4);
            this.cardAvgOrder.Name = "cardAvgOrder";
            this.cardAvgOrder.Size = new System.Drawing.Size(240, 74);
            this.cardAvgOrder.TabIndex = 2;
            // 
            // lblAvgOrderValue
            // 
            this.lblAvgOrderValue.AutoSize = true;
            this.lblAvgOrderValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAvgOrderValue.ForeColor = System.Drawing.Color.White;
            this.lblAvgOrderValue.Location = new System.Drawing.Point(16, 6);
            this.lblAvgOrderValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvgOrderValue.Name = "lblAvgOrderValue";
            this.lblAvgOrderValue.Size = new System.Drawing.Size(111, 46);
            this.lblAvgOrderValue.TabIndex = 1;
            this.lblAvgOrderValue.Text = "R0.00";
            // 
            // lblAvgOrderLabel
            // 
            this.lblAvgOrderLabel.AutoSize = true;
            this.lblAvgOrderLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvgOrderLabel.ForeColor = System.Drawing.Color.White;
            this.lblAvgOrderLabel.Location = new System.Drawing.Point(16, 52);
            this.lblAvgOrderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvgOrderLabel.Name = "lblAvgOrderLabel";
            this.lblAvgOrderLabel.Size = new System.Drawing.Size(106, 20);
            this.lblAvgOrderLabel.TabIndex = 0;
            this.lblAvgOrderLabel.Text = "Average Order";
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
            this.orderIDDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.orderDateTimeDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.totalAmountDueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.orderTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 172);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1133, 615);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "Order ID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Employee ID";
            this.employeeIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Order Type";
            this.orderTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderDateTimeDataGridViewTextBoxColumn
            // 
            this.orderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.HeaderText = "Date & Time";
            this.orderDateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDateTimeDataGridViewTextBoxColumn.Name = "orderDateTimeDataGridViewTextBoxColumn";
            this.orderDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.orderStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            this.orderStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalAmountDueDataGridViewTextBoxColumn
            // 
            this.totalAmountDueDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.totalAmountDueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalAmountDueDataGridViewTextBoxColumn.Name = "totalAmountDueDataGridViewTextBoxColumn";
            this.totalAmountDueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderTableBindingSource
            // 
            this.orderTableBindingSource.DataMember = "OrderTable";
            this.orderTableBindingSource.DataSource = this.dsCafe101Hub;
            // 
            // dsCafe101Hub
            // 
            this.dsCafe101Hub.DataSetName = "dsCafe101Hub";
            this.dsCafe101Hub.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelDateFilter
            // 
            this.panelDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelDateFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDateFilter.Controls.Add(this.lblFilterTitle);
            this.panelDateFilter.Controls.Add(this.lblFromDate);
            this.panelDateFilter.Controls.Add(this.dateTimePicker1);
            this.panelDateFilter.Controls.Add(this.lblToDate);
            this.panelDateFilter.Controls.Add(this.dateTimePicker2);
            this.panelDateFilter.Controls.Add(this.lblDateNote);
            this.panelDateFilter.Controls.Add(this.btnTodayOrders);
            this.panelDateFilter.Controls.Add(this.btnPrintReport);
            this.panelDateFilter.Location = new System.Drawing.Point(1160, 172);
            this.panelDateFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelDateFilter.Name = "panelDateFilter";
            this.panelDateFilter.Size = new System.Drawing.Size(759, 406);
            this.panelDateFilter.TabIndex = 17;
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.White;
            this.lblFilterTitle.Location = new System.Drawing.Point(4, 3);
            this.lblFilterTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(258, 32);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "📅 Report Date Filter";
            this.lblFilterTitle.Click += new System.EventHandler(this.lblFilterTitle_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFromDate.ForeColor = System.Drawing.Color.White;
            this.lblFromDate.Location = new System.Drawing.Point(20, 74);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(108, 28);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 105);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(332, 32);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblToDate.ForeColor = System.Drawing.Color.White;
            this.lblToDate.Location = new System.Drawing.Point(20, 154);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(82, 28);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To Date:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(27, 185);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(332, 32);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // lblDateNote
            // 
            this.lblDateNote.AutoSize = true;
            this.lblDateNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblDateNote.Location = new System.Drawing.Point(23, 234);
            this.lblDateNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateNote.Name = "lblDateNote";
            this.lblDateNote.Size = new System.Drawing.Size(423, 20);
            this.lblDateNote.TabIndex = 5;
            this.lblDateNote.Text = "⚠️ Note: Each day begins at 00:00. Pick dates > 24 hours apart";
            // 
            // btnTodayOrders
            // 
            this.btnTodayOrders.BackColor = System.Drawing.Color.White;
            this.btnTodayOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodayOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnTodayOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnTodayOrders.Location = new System.Drawing.Point(27, 271);
            this.btnTodayOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnTodayOrders.Name = "btnTodayOrders";
            this.btnTodayOrders.Size = new System.Drawing.Size(213, 49);
            this.btnTodayOrders.TabIndex = 6;
            this.btnTodayOrders.Text = "Today\'s Orders";
            this.btnTodayOrders.UseVisualStyleBackColor = false;
            this.btnTodayOrders.Click += new System.EventHandler(this.today_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.White;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.btnPrintReport.Location = new System.Drawing.Point(253, 271);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(213, 49);
            this.btnPrintReport.TabIndex = 7;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelRevenue
            // 
            this.panelRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRevenue.Controls.Add(this.lblRevenueTitle);
            this.panelRevenue.Controls.Add(this.txtRevenue);
            this.panelRevenue.Location = new System.Drawing.Point(1160, 591);
            this.panelRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(759, 98);
            this.panelRevenue.TabIndex = 18;
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblRevenueTitle.Location = new System.Drawing.Point(20, 12);
            this.lblRevenueTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(180, 28);
            this.lblRevenueTitle.TabIndex = 9;
            this.lblRevenueTitle.Text = "💰 Total Revenue";
            // 
            // txtRevenue
            // 
            this.txtRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRevenue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.txtRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.txtRevenue.Location = new System.Drawing.Point(27, 43);
            this.txtRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.ReadOnly = true;
            this.txtRevenue.Size = new System.Drawing.Size(333, 54);
            this.txtRevenue.TabIndex = 10;
            this.txtRevenue.Text = "R0.00";
            this.txtRevenue.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.button2.Location = new System.Drawing.Point(27, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelActions.Controls.Add(this.button2);
            this.panelActions.Controls.Add(this.button1);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 788);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1924, 71);
            this.panelActions.TabIndex = 19;
            // 
            // testOrderBindingSource
            // 
            this.testOrderBindingSource.DataMember = "TestOrder";
            this.testOrderBindingSource.DataSource = this.dsCafe101Test;
            // 
            // dsCafe101Test
            // 
            this.dsCafe101Test.DataSetName = "dsCafe101Test";
            this.dsCafe101Test.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testOrderTableAdapter
            // 
            this.testOrderTableAdapter.ClearBeforeFill = true;
            // 
            // orderTableTableAdapter
            // 
            this.orderTableTableAdapter.ClearBeforeFill = true;
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1924, 859);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelRevenue);
            this.Controls.Add(this.panelDateFilter);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSalesReport";
            this.Text = "Sales Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.cardTotalOrders.ResumeLayout(false);
            this.cardTotalOrders.PerformLayout();
            this.cardTotalRevenue.ResumeLayout(false);
            this.cardTotalRevenue.PerformLayout();
            this.cardAvgOrder.ResumeLayout(false);
            this.cardAvgOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            this.panelDateFilter.ResumeLayout(false);
            this.panelDateFilter.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // ORIGINAL COMPONENTS - All kept the same
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource testOrderBindingSource;
        private dsCafe101TestTableAdapters.TestOrderTableAdapter testOrderTableAdapter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource orderTableBindingSource;
        private dsCafe101HubTableAdapters.OrderTableTableAdapter orderTableTableAdapter;
        private System.Windows.Forms.Button today;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDueDataGridViewTextBoxColumn;

        // NEW COMPONENTS
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersValue;
        private System.Windows.Forms.Label lblTotalOrdersLabel;
        private System.Windows.Forms.Panel cardTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblTotalRevenueLabel;
        private System.Windows.Forms.Panel cardAvgOrder;
        private System.Windows.Forms.Label lblAvgOrderValue;
        private System.Windows.Forms.Label lblAvgOrderLabel;
        private System.Windows.Forms.Panel panelDateFilter;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblDateNote;
        private System.Windows.Forms.Button btnTodayOrders;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Panel panelRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.TextBox txtRevenue;
        private System.Windows.Forms.Panel panelActions;
    }
}