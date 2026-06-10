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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuItemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topSellingItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Hub = new Cafe101.dsCafe101Hub();
            this.topSellingItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101Test = new Cafe101.dsCafe101Test();
            this.topSellingItemTableAdapter = new Cafe101.dsCafe101TestTableAdapters.TopSellingItemTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.topSellingItemTableAdapter1 = new Cafe101.dsCafe101HubTableAdapters.TopSellingItemTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(701, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuItemIDDataGridViewTextBoxColumn,
            this.menuItemNameDataGridViewTextBoxColumn,
            this.totalSoldDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.topSellingItemBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(502, 713);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuItemIDDataGridViewTextBoxColumn
            // 
            this.menuItemIDDataGridViewTextBoxColumn.DataPropertyName = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.HeaderText = "MenuItemID";
            this.menuItemIDDataGridViewTextBoxColumn.Name = "menuItemIDDataGridViewTextBoxColumn";
            this.menuItemIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuItemNameDataGridViewTextBoxColumn
            // 
            this.menuItemNameDataGridViewTextBoxColumn.DataPropertyName = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.HeaderText = "MenuItemName";
            this.menuItemNameDataGridViewTextBoxColumn.Name = "menuItemNameDataGridViewTextBoxColumn";
            // 
            // totalSoldDataGridViewTextBoxColumn
            // 
            this.totalSoldDataGridViewTextBoxColumn.DataPropertyName = "TotalSold";
            this.totalSoldDataGridViewTextBoxColumn.HeaderText = "TotalSold";
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(771, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chef\'s Best Sellers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // topSellingItemTableAdapter1
            // 
            this.topSellingItemTableAdapter1.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gold Status Item:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(142, 133);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(5, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Silver Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(6, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bronze Status(3)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(701, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 208);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top 3 Best Sellers";
            // 
            // frmPopularProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1805, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "frmPopularProduct";
            this.Text = "Popular Product";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPopularProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Hub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSellingItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dsCafe101Test dsCafe101Test;
        private System.Windows.Forms.BindingSource topSellingItemBindingSource;
        private dsCafe101TestTableAdapters.TopSellingItemTableAdapter topSellingItemTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuItemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private dsCafe101Hub dsCafe101Hub;
        private System.Windows.Forms.BindingSource topSellingItemBindingSource1;
        private dsCafe101HubTableAdapters.TopSellingItemTableAdapter topSellingItemTableAdapter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}