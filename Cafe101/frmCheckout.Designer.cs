namespace Cafe101
{
    partial class frmCheckout
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
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.orderIDTxt = new System.Windows.Forms.TextBox();
            this.totalTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.txtAmountTendered = new System.Windows.Forms.TextBox();
            this.changeTextBox = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAmountMes = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrderID
            // 
            this.lblOrderID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrderID.Location = new System.Drawing.Point(293, 144);
            this.lblOrderID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(78, 20);
            this.lblOrderID.TabIndex = 0;
            this.lblOrderID.Text = "Order ID :";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrderTotal.Location = new System.Drawing.Point(293, 183);
            this.lblOrderTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(100, 20);
            this.lblOrderTotal.TabIndex = 1;
            this.lblOrderTotal.Text = "Order Total : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(293, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount Tendered :";
            // 
            // lblChange
            // 
            this.lblChange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblChange.Location = new System.Drawing.Point(293, 374);
            this.lblChange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(73, 20);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change :";
            // 
            // orderIDTxt
            // 
            this.orderIDTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.orderIDTxt.Location = new System.Drawing.Point(465, 144);
            this.orderIDTxt.Margin = new System.Windows.Forms.Padding(2);
            this.orderIDTxt.Name = "orderIDTxt";
            this.orderIDTxt.ReadOnly = true;
            this.orderIDTxt.Size = new System.Drawing.Size(138, 20);
            this.orderIDTxt.TabIndex = 5;
            // 
            // totalTxt
            // 
            this.totalTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalTxt.Location = new System.Drawing.Point(465, 186);
            this.totalTxt.Margin = new System.Windows.Forms.Padding(2);
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.ReadOnly = true;
            this.totalTxt.Size = new System.Drawing.Size(138, 20);
            this.totalTxt.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rbCard);
            this.groupBox1.Controls.Add(this.rbCash);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(297, 218);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(478, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Method";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(263, 37);
            this.rbCard.Margin = new System.Windows.Forms.Padding(2);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(51, 19);
            this.rbCard.TabIndex = 1;
            this.rbCard.TabStop = true;
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            this.rbCard.CheckedChanged += new System.EventHandler(this.rbCard_CheckedChanged);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(87, 37);
            this.rbCash.Margin = new System.Windows.Forms.Padding(2);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(53, 19);
            this.rbCash.TabIndex = 0;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.TextChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // txtAmountTendered
            // 
            this.txtAmountTendered.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAmountTendered.Location = new System.Drawing.Point(465, 322);
            this.txtAmountTendered.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.Size = new System.Drawing.Size(138, 20);
            this.txtAmountTendered.TabIndex = 8;
            this.txtAmountTendered.TextChanged += new System.EventHandler(this.txtAmountTendered_TextChanged);
            // 
            // changeTextBox
            // 
            this.changeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changeTextBox.Location = new System.Drawing.Point(465, 378);
            this.changeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.changeTextBox.Name = "changeTextBox";
            this.changeTextBox.ReadOnly = true;
            this.changeTextBox.Size = new System.Drawing.Size(138, 20);
            this.changeTextBox.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnCancel.Location = new System.Drawing.Point(468, 456);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel Payment";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(409, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "CHECKOUT YOUR ORDER";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnConfirm.Location = new System.Drawing.Point(198, 456);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 33);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm Payment";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(400, 715);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "TODAY\'S ORDERS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAmountMes
            // 
            this.lblAmountMes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAmountMes.AutoSize = true;
            this.lblAmountMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountMes.Location = new System.Drawing.Point(465, 346);
            this.lblAmountMes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmountMes.Name = "lblAmountMes";
            this.lblAmountMes.Size = new System.Drawing.Size(0, 15);
            this.lblAmountMes.TabIndex = 15;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHelp.BackColor = System.Drawing.Color.White;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnHelp.Location = new System.Drawing.Point(772, 456);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(136, 33);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1337, 705);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblAmountMes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.changeTextBox);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.totalTxt);
            this.Controls.Add(this.orderIDTxt);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.lblOrderID);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCheckout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion  

        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox orderIDTxt;
        private System.Windows.Forms.TextBox totalTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.TextBox txtAmountTendered;
        private System.Windows.Forms.TextBox changeTextBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAmountMes;
        private System.Windows.Forms.Button btnHelp;
    }
}