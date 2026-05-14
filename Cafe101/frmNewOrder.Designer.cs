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
            this.lblSearchCust = new System.Windows.Forms.Label();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.btnSearchCust = new System.Windows.Forms.Button();
            this.lblCustName = new System.Windows.Forms.Label();
            this.txtSearchedName = new System.Windows.Forms.TextBox();
            this.lblSearchItems = new System.Windows.Forms.Label();
            this.textItemSearch = new System.Windows.Forms.TextBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvMenuItems = new System.Windows.Forms.DataGridView();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchCust
            // 
            this.lblSearchCust.AutoSize = true;
            this.lblSearchCust.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchCust.Location = new System.Drawing.Point(61, 41);
            this.lblSearchCust.Name = "lblSearchCust";
            this.lblSearchCust.Size = new System.Drawing.Size(115, 13);
            this.lblSearchCust.TabIndex = 0;
            this.lblSearchCust.Text = "SEARCH CUSTOMER";
            // 
            // txtCust
            // 
            this.txtCust.Location = new System.Drawing.Point(208, 38);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(175, 20);
            this.txtCust.TabIndex = 1;
            // 
            // btnSearchCust
            // 
            this.btnSearchCust.Location = new System.Drawing.Point(418, 36);
            this.btnSearchCust.Name = "btnSearchCust";
            this.btnSearchCust.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCust.TabIndex = 2;
            this.btnSearchCust.Text = "SEARCH";
            this.btnSearchCust.UseVisualStyleBackColor = true;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCustName.Location = new System.Drawing.Point(567, 41);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(38, 13);
            this.lblCustName.TabIndex = 3;
            this.lblCustName.Text = "NAME";
            // 
            // txtSearchedName
            // 
            this.txtSearchedName.Location = new System.Drawing.Point(640, 38);
            this.txtSearchedName.Name = "txtSearchedName";
            this.txtSearchedName.Size = new System.Drawing.Size(168, 20);
            this.txtSearchedName.TabIndex = 4;
            // 
            // lblSearchItems
            // 
            this.lblSearchItems.AutoSize = true;
            this.lblSearchItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchItems.Location = new System.Drawing.Point(195, 110);
            this.lblSearchItems.Name = "lblSearchItems";
            this.lblSearchItems.Size = new System.Drawing.Size(124, 13);
            this.lblSearchItems.TabIndex = 5;
            this.lblSearchItems.Text = "SEARCH MENU ITEM : ";
            // 
            // textItemSearch
            // 
            this.textItemSearch.Location = new System.Drawing.Point(346, 107);
            this.textItemSearch.Name = "textItemSearch";
            this.textItemSearch.Size = new System.Drawing.Size(171, 20);
            this.textItemSearch.TabIndex = 6;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Location = new System.Drawing.Point(577, 105);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(75, 23);
            this.btnSearchItem.TabIndex = 7;
            this.btnSearchItem.Text = "SEARCH";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(395, 346);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(98, 23);
            this.btnAddToCart.TabIndex = 10;
            this.btnAddToCart.Text = "ADD TO CART";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // dgvMenuItems
            // 
            this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuItems.Location = new System.Drawing.Point(153, 144);
            this.dgvMenuItems.Name = "dgvMenuItems";
            this.dgvMenuItems.Size = new System.Drawing.Size(591, 181);
            this.dgvMenuItems.TabIndex = 11;
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(153, 397);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(591, 158);
            this.dgvCart.TabIndex = 12;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalPrice.Location = new System.Drawing.Point(294, 594);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(42, 13);
            this.lblTotalPrice.TabIndex = 13;
            this.lblTotalPrice.Text = "TOTAL";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmount.Location = new System.Drawing.Point(407, 594);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(39, 13);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "R 0.00";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Location = new System.Drawing.Point(490, 589);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(129, 23);
            this.btnConfirmOrder.TabIndex = 15;
            this.btnConfirmOrder.Text = "CONFIRM ORDER";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            // 
            // frmNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(888, 650);
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
            this.Controls.Add(this.txtCust);
            this.Controls.Add(this.lblSearchCust);
            this.Name = "frmNewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.frmNewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchCust;
        private System.Windows.Forms.TextBox txtCust;
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
    }
}