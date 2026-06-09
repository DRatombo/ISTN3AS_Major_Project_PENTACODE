namespace Cafe101
{
    partial class frmReceipt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.orderIDTxt = new System.Windows.Forms.TextBox();
            this.dateTxt = new System.Windows.Forms.TextBox();
            this.cashierTxt = new System.Windows.Forms.TextBox();
            this.payTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.totTxt = new System.Windows.Forms.TextBox();
            this.amountTxt = new System.Windows.Forms.TextBox();
            this.changeTxt = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.custTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(60, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order ID : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cashier :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(236, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Payment Method : ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Amount : ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amount Paid : ";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 560);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Change : ";
            // 
            // orderIDTxt
            // 
            this.orderIDTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.orderIDTxt.Location = new System.Drawing.Point(241, 90);
            this.orderIDTxt.Name = "orderIDTxt";
            this.orderIDTxt.ReadOnly = true;
            this.orderIDTxt.Size = new System.Drawing.Size(500, 22);
            this.orderIDTxt.TabIndex = 8;
            // 
            // dateTxt
            // 
            this.dateTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTxt.Location = new System.Drawing.Point(241, 147);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.ReadOnly = true;
            this.dateTxt.Size = new System.Drawing.Size(183, 22);
            this.dateTxt.TabIndex = 9;
            // 
            // cashierTxt
            // 
            this.cashierTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cashierTxt.Location = new System.Drawing.Point(241, 277);
            this.cashierTxt.Name = "cashierTxt";
            this.cashierTxt.ReadOnly = true;
            this.cashierTxt.Size = new System.Drawing.Size(183, 22);
            this.cashierTxt.TabIndex = 10;
            // 
            // payTxt
            // 
            this.payTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.payTxt.Location = new System.Drawing.Point(435, 352);
            this.payTxt.Name = "payTxt";
            this.payTxt.ReadOnly = true;
            this.payTxt.Size = new System.Drawing.Size(183, 22);
            this.payTxt.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(319, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "PAYMENT RECEIPT";
            // 
            // totTxt
            // 
            this.totTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totTxt.Location = new System.Drawing.Point(241, 406);
            this.totTxt.Name = "totTxt";
            this.totTxt.ReadOnly = true;
            this.totTxt.Size = new System.Drawing.Size(183, 22);
            this.totTxt.TabIndex = 14;
            // 
            // amountTxt
            // 
            this.amountTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.amountTxt.Location = new System.Drawing.Point(241, 487);
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.ReadOnly = true;
            this.amountTxt.Size = new System.Drawing.Size(183, 22);
            this.amountTxt.TabIndex = 15;
            // 
            // changeTxt
            // 
            this.changeTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changeTxt.Location = new System.Drawing.Point(241, 564);
            this.changeTxt.Name = "changeTxt";
            this.changeTxt.ReadOnly = true;
            this.changeTxt.Size = new System.Drawing.Size(183, 22);
            this.changeTxt.TabIndex = 16;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(84)))), ((int)(((byte)(241)))));
            this.btnClose.Location = new System.Drawing.Point(343, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 33);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // custTxt
            // 
            this.custTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.custTxt.Location = new System.Drawing.Point(241, 211);
            this.custTxt.Name = "custTxt";
            this.custTxt.ReadOnly = true;
            this.custTxt.Size = new System.Drawing.Size(183, 22);
            this.custTxt.TabIndex = 11;
            this.custTxt.TextChanged += new System.EventHandler(this.custTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer : ";
            // 
            // frmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(780, 738);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.changeTxt);
            this.Controls.Add(this.amountTxt);
            this.Controls.Add(this.totTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.payTxt);
            this.Controls.Add(this.custTxt);
            this.Controls.Add(this.cashierTxt);
            this.Controls.Add(this.dateTxt);
            this.Controls.Add(this.orderIDTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmReceipt";
            this.Text = "frmReceipt";
            this.Load += new System.EventHandler(this.frmReceipt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox orderIDTxt;
        private System.Windows.Forms.TextBox dateTxt;
        private System.Windows.Forms.TextBox cashierTxt;
        private System.Windows.Forms.TextBox payTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox totTxt;
        private System.Windows.Forms.TextBox amountTxt;
        private System.Windows.Forms.TextBox changeTxt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox custTxt;
        private System.Windows.Forms.Label label3;
    }
}