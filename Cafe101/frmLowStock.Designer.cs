namespace Cafe101
{
    partial class frmLowStock
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOnHandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restockLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.testIngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.testIngredientTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TestIngredientTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.testIngredientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.testIngredientBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPrintLowStock = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ingredientTableTableAdapter = new Cafe101.dsCafe101HubTableAdapters.IngredientTableTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(979, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.quantityOnHandDataGridViewTextBoxColumn,
            this.restockLevelDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ingredientTableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(745, 757);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // quantityOnHandDataGridViewTextBoxColumn
            // 
            this.quantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand";
            this.quantityOnHandDataGridViewTextBoxColumn.HeaderText = "QuantityOnHand";
            this.quantityOnHandDataGridViewTextBoxColumn.Name = "quantityOnHandDataGridViewTextBoxColumn";
            // 
            // restockLevelDataGridViewTextBoxColumn
            // 
            this.restockLevelDataGridViewTextBoxColumn.DataPropertyName = "RestockLevel";
            this.restockLevelDataGridViewTextBoxColumn.HeaderText = "RestockLevel";
            this.restockLevelDataGridViewTextBoxColumn.Name = "restockLevelDataGridViewTextBoxColumn";
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "CostPrice";
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
            // testIngredientTableAdapter
            // 
            this.testIngredientTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1012, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "These Are All The Items Below Restock Level!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(1012, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Items you need to restock:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(1326, 177);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // btnPrintLowStock
            // 
            this.btnPrintLowStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintLowStock.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrintLowStock.Location = new System.Drawing.Point(1162, 606);
            this.btnPrintLowStock.Name = "btnPrintLowStock";
            this.btnPrintLowStock.Size = new System.Drawing.Size(128, 30);
            this.btnPrintLowStock.TabIndex = 8;
            this.btnPrintLowStock.Text = "Print Low Stock";
            this.btnPrintLowStock.UseVisualStyleBackColor = true;
            this.btnPrintLowStock.Click += new System.EventHandler(this.btnPrintLowStock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 785);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Analysis";
            // 
            // ingredientTableTableAdapter
            // 
            this.ingredientTableTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(1326, 606);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "Restock Ingredients";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmLowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1802, 785);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrintLowStock);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmLowStock";
            this.Text = "Low Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLowStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testIngredientBindingSource2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource testIngredientBindingSource;
        private dsCafe101TestTableAdapters.TestIngredientTableAdapter testIngredientTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource testIngredientBindingSource1;
        private System.Windows.Forms.BindingSource testIngredientBindingSource2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnPrintLowStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOnHandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restockLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource ingredientTableBindingSource;
        private dsCafe101HubTableAdapters.IngredientTableTableAdapter ingredientTableTableAdapter;
        private System.Windows.Forms.Button button2;
    }
}