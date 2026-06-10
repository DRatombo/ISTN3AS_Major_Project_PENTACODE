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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderTableAdapter = new Cafe101.dsCafe101TableAdapters.OrderTableAdapter();
            this.tableAdapterManager = new Cafe101.dsCafe101TableAdapters.TableAdapterManager();
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.numOrders = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.dsCafe101;
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
            // orderDataGridView
            // 
            this.orderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDataGridView.AutoGenerateColumns = false;
            this.orderDataGridView.BackgroundColor = System.Drawing.Color.MidnightBlue;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.orderDataGridView.Location = new System.Drawing.Point(5, 5);
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.RowHeadersWidth = 51;
            this.orderDataGridView.RowTemplate.Height = 24;
            this.orderDataGridView.Size = new System.Drawing.Size(1097, 357);
            this.orderDataGridView.TabIndex = 2;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // cashierIDDataGridViewTextBoxColumn
            // 
            this.cashierIDDataGridViewTextBoxColumn.DataPropertyName = "CashierID";
            this.cashierIDDataGridViewTextBoxColumn.HeaderText = "CashierID";
            this.cashierIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cashierIDDataGridViewTextBoxColumn.Name = "cashierIDDataGridViewTextBoxColumn";
            this.cashierIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderDateTimeDataGridViewTextBoxColumn
            // 
            this.orderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.HeaderText = "OrderDateTime";
            this.orderDateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDateTimeDataGridViewTextBoxColumn.Name = "orderDateTimeDataGridViewTextBoxColumn";
            this.orderDateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            this.orderStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalAmountDueDataGridViewTextBoxColumn
            // 
            this.totalAmountDueDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.HeaderText = "TotalAmountDue";
            this.totalAmountDueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalAmountDueDataGridViewTextBoxColumn.Name = "totalAmountDueDataGridViewTextBoxColumn";
            this.totalAmountDueDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalChangeDueDataGridViewTextBoxColumn
            // 
            this.totalChangeDueDataGridViewTextBoxColumn.DataPropertyName = "TotalChangeDue";
            this.totalChangeDueDataGridViewTextBoxColumn.HeaderText = "TotalChangeDue";
            this.totalChangeDueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalChangeDueDataGridViewTextBoxColumn.Name = "totalChangeDueDataGridViewTextBoxColumn";
            this.totalChangeDueDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryCostDataGridViewTextBoxColumn
            // 
            this.deliveryCostDataGridViewTextBoxColumn.DataPropertyName = "DeliveryCost";
            this.deliveryCostDataGridViewTextBoxColumn.HeaderText = "DeliveryCost";
            this.deliveryCostDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryCostDataGridViewTextBoxColumn.Name = "deliveryCostDataGridViewTextBoxColumn";
            this.deliveryCostDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.Location = new System.Drawing.Point(296, 431);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 29);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Location = new System.Drawing.Point(517, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // numOrders
            // 
            this.numOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numOrders.AutoSize = true;
            this.numOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numOrders.Location = new System.Drawing.Point(259, 376);
            this.numOrders.Name = "numOrders";
            this.numOrders.Size = new System.Drawing.Size(144, 29);
            this.numOrders.TabIndex = 6;
            this.numOrders.Text = "orderCount";
            // 
            // frmTodaysOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1114, 568);
            this.Controls.Add(this.numOrders);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.orderDataGridView);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmTodaysOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTodaysOrders";
            this.Load += new System.EventHandler(this.frmTodaysOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private dsCafe101 dsCafe101;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private dsCafe101TableAdapters.OrderTableAdapter orderTableAdapter;
        private dsCafe101TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label numOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalChangeDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryCostDataGridViewTextBoxColumn;
    }
}