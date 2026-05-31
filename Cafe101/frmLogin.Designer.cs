namespace Cafe101
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pBHelp = new System.Windows.Forms.PictureBox();
            this.lblEmailMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pBLogin = new System.Windows.Forms.PictureBox();
            this.cashierTableAdapter1 = new Cafe101.dsLoginTableAdapters.CashierTableAdapter();
            this.dsLogin1 = new Cafe101.dsLogin();
            this.testEmployeeTableAdapter1 = new Cafe101.dsCafe101TestTableAdapters.TestEmployeeTableAdapter();
            this.dsCafe101Test1 = new Cafe101.dsCafe101Test();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLogin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.txtHelp);
            this.splitContainer1.Panel1.Controls.Add(this.btnHelp);
            this.splitContainer1.Panel1.Controls.Add(this.pBHelp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.btnExit);
            this.splitContainer1.Panel2.Controls.Add(this.lblEmailMsg);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel2.Controls.Add(this.lblPassword);
            this.splitContainer1.Panel2.Controls.Add(this.lblUsername);
            this.splitContainer1.Panel2.Controls.Add(this.btnLogin);
            this.splitContainer1.Panel2.Controls.Add(this.pBLogin);
            this.splitContainer1.Size = new System.Drawing.Size(1285, 788);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.Location = new System.Drawing.Point(252, 733);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 44);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(12, 12);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.Size = new System.Drawing.Size(398, 716);
            this.txtHelp.TabIndex = 11;
            this.txtHelp.Text = resources.GetString("txtHelp.Text");
            this.txtHelp.TextChanged += new System.EventHandler(this.txtHelp_TextChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHelp.BackColor = System.Drawing.SystemColors.Control;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnHelp.Location = new System.Drawing.Point(0, 742);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(147, 44);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.button2_Click);
            // 
            // pBHelp
            // 
            this.pBHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBHelp.Image = global::Cafe101.Properties.Resources.Logo_jpg;
            this.pBHelp.Location = new System.Drawing.Point(0, 0);
            this.pBHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBHelp.Name = "pBHelp";
            this.pBHelp.Size = new System.Drawing.Size(427, 788);
            this.pBHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBHelp.TabIndex = 0;
            this.pBHelp.TabStop = false;
            this.pBHelp.Click += new System.EventHandler(this.pBHelp_Click);
            // 
            // lblEmailMsg
            // 
            this.lblEmailMsg.AutoSize = true;
            this.lblEmailMsg.Location = new System.Drawing.Point(560, 373);
            this.lblEmailMsg.Name = "lblEmailMsg";
            this.lblEmailMsg.Size = new System.Drawing.Size(0, 16);
            this.lblEmailMsg.TabIndex = 9;
            this.lblEmailMsg.Click += new System.EventHandler(this.lblEmailMsg_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Cafe101.Properties.Resources.Show_password;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(563, 655);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 42);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Show password.jpg");
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(261, 655);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(279, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Transparent;
            this.txtEmail.Location = new System.Drawing.Point(261, 579);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(279, 30);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPassword.Location = new System.Drawing.Point(107, 655);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(106, 24);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblUsername.Location = new System.Drawing.Point(107, 585);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 24);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Email:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogin.Location = new System.Drawing.Point(318, 733);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(147, 44);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login ";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pBLogin
            // 
            this.pBLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBLogin.Image = global::Cafe101.Properties.Resources.Login_jpg;
            this.pBLogin.Location = new System.Drawing.Point(0, 0);
            this.pBLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBLogin.Name = "pBLogin";
            this.pBLogin.Size = new System.Drawing.Size(856, 788);
            this.pBLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLogin.TabIndex = 6;
            this.pBLogin.TabStop = false;
            this.pBLogin.Click += new System.EventHandler(this.pBLogin_Click);
            // 
            // cashierTableAdapter1
            // 
            this.cashierTableAdapter1.ClearBeforeFill = true;
            // 
            // dsLogin1
            // 
            this.dsLogin1.DataSetName = "dsLogin";
            this.dsLogin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testEmployeeTableAdapter1
            // 
            this.testEmployeeTableAdapter1.ClearBeforeFill = true;
            // 
            // dsCafe101Test1
            // 
            this.dsCafe101Test1.DataSetName = "dsCafe101Test";
            this.dsCafe101Test1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExit.Location = new System.Drawing.Point(697, 733);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(147, 44);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 788);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLogin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101Test1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pBHelp;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pBLogin;
        private dsLoginTableAdapters.CashierTableAdapter cashierTableAdapter1;
        private dsLogin dsLogin1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblEmailMsg;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.Button btnClose;
        private dsCafe101TestTableAdapters.TestEmployeeTableAdapter testEmployeeTableAdapter1;
        private dsCafe101Test dsCafe101Test1;
        private System.Windows.Forms.Button btnExit;
    }
}

