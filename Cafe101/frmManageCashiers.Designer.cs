namespace RestaurantSystem
{
    partial class frmManageCashiers
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpCashierDetails = new System.Windows.Forms.GroupBox();
            this.tblDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pnlRight = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCashiers = new System.Windows.Forms.DataGridView();
            this.cashierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCafe101 = new Cafe101.dsCafe101();
            this.pnlRightButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdateCashier = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAddCashier = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cashierTableAdapter = new Cafe101.dsCafe101TableAdapters.CashierTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.tblMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCashierDetails.SuspendLayout();
            this.tblDetails.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).BeginInit();
            this.pnlRightButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tblMain.Controls.Add(this.pnlRight, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1075, 567);
            this.tblMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.grpCashierDetails);
            this.pnlLeft.Controls.Add(this.txtFullName);
            this.pnlLeft.Controls.Add(this.txtUsername);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(12);
            this.pnlLeft.Size = new System.Drawing.Size(414, 561);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpCashierDetails
            // 
            this.grpCashierDetails.Controls.Add(this.tblDetails);
            this.grpCashierDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCashierDetails.ForeColor = System.Drawing.Color.White;
            this.grpCashierDetails.Location = new System.Drawing.Point(12, 12);
            this.grpCashierDetails.Name = "grpCashierDetails";
            this.grpCashierDetails.Padding = new System.Windows.Forms.Padding(8);
            this.grpCashierDetails.Size = new System.Drawing.Size(390, 537);
            this.grpCashierDetails.TabIndex = 0;
            this.grpCashierDetails.TabStop = false;
            this.grpCashierDetails.Text = "Cashier Details";
            // 
            // tblDetails
            // 
            this.tblDetails.ColumnCount = 2;
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDetails.Controls.Add(this.lblFirstName, 0, 0);
            this.tblDetails.Controls.Add(this.txtFirstName, 1, 0);
            this.tblDetails.Controls.Add(this.lblSurname, 0, 1);
            this.tblDetails.Controls.Add(this.txtSurname, 1, 1);
            this.tblDetails.Controls.Add(this.lblEmail, 0, 2);
            this.tblDetails.Controls.Add(this.txtEmail, 1, 2);
            this.tblDetails.Controls.Add(this.lblAddress, 0, 3);
            this.tblDetails.Controls.Add(this.txtAddress, 1, 3);
            this.tblDetails.Controls.Add(this.lblPassword, 0, 4);
            this.tblDetails.Controls.Add(this.txtPassword, 1, 4);
            this.tblDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDetails.Location = new System.Drawing.Point(8, 28);
            this.tblDetails.Name = "tblDetails";
            this.tblDetails.Padding = new System.Windows.Forms.Padding(6);
            this.tblDetails.RowCount = 6;
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDetails.Size = new System.Drawing.Size(374, 501);
            this.tblDetails.TabIndex = 0;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(9, 6);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(114, 44);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(129, 9);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(236, 27);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblSurname
            // 
            this.lblSurname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurname.ForeColor = System.Drawing.Color.White;
            this.lblSurname.Location = new System.Drawing.Point(9, 50);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(114, 44);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Surname:";
            this.lblSurname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.White;
            this.txtSurname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSurname.ForeColor = System.Drawing.Color.Black;
            this.txtSurname.Location = new System.Drawing.Point(129, 53);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(236, 27);
            this.txtSurname.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(9, 94);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(114, 44);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(129, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(236, 27);
            this.txtEmail.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(9, 138);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(114, 44);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(129, 141);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(236, 27);
            this.txtAddress.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(9, 182);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(114, 44);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(129, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(236, 27);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(100, 27);
            this.txtFullName.TabIndex = 2;
            this.txtFullName.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(0, 0);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 27);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Visible = false;
            // 
            // pnlRight
            // 
            this.pnlRight.ColumnCount = 1;
            this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlRight.Controls.Add(this.dgvCashiers, 0, 0);
            this.pnlRight.Controls.Add(this.pnlRightButtons, 0, 1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(423, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.RowCount = 2;
            this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.pnlRight.Size = new System.Drawing.Size(649, 561);
            this.pnlRight.TabIndex = 1;
            // 
            // dgvCashiers
            // 
            this.dgvCashiers.AutoGenerateColumns = false;
            this.dgvCashiers.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cashierIDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.dgvCashiers.DataSource = this.cashierBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashiers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCashiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashiers.EnableHeadersVisualStyles = false;
            this.dgvCashiers.GridColor = System.Drawing.Color.White;
            this.dgvCashiers.Location = new System.Drawing.Point(3, 3);
            this.dgvCashiers.MultiSelect = false;
            this.dgvCashiers.Name = "dgvCashiers";
            this.dgvCashiers.ReadOnly = true;
            this.dgvCashiers.RowHeadersWidth = 51;
            this.dgvCashiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashiers.Size = new System.Drawing.Size(643, 491);
            this.dgvCashiers.TabIndex = 0;
            this.dgvCashiers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCashiers_CellClick);
            // 
            // cashierIDDataGridViewTextBoxColumn
            // 
            this.cashierIDDataGridViewTextBoxColumn.DataPropertyName = "CashierID";
            this.cashierIDDataGridViewTextBoxColumn.HeaderText = "CashierID";
            this.cashierIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cashierIDDataGridViewTextBoxColumn.Name = "cashierIDDataGridViewTextBoxColumn";
            this.cashierIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashierIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.surnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // cashierBindingSource
            // 
            this.cashierBindingSource.DataMember = "Cashier";
            this.cashierBindingSource.DataSource = this.dsCafe101;
            // 
            // dsCafe101
            // 
            this.dsCafe101.DataSetName = "dsCafe101";
            this.dsCafe101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlRightButtons
            // 
            this.pnlRightButtons.AutoSize = true;
            this.pnlRightButtons.Controls.Add(this.btnAddCashier);
            this.pnlRightButtons.Controls.Add(this.btnUpdateCashier);
            this.pnlRightButtons.Controls.Add(this.btnResetPassword);
            this.pnlRightButtons.Controls.Add(this.btnRefresh);
            this.pnlRightButtons.Controls.Add(this.button1);
            this.pnlRightButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightButtons.Location = new System.Drawing.Point(3, 500);
            this.pnlRightButtons.Name = "pnlRightButtons";
            this.pnlRightButtons.Padding = new System.Windows.Forms.Padding(6);
            this.pnlRightButtons.Size = new System.Drawing.Size(643, 58);
            this.pnlRightButtons.TabIndex = 1;
            // 
            // btnUpdateCashier
            // 
            this.btnUpdateCashier.AutoSize = true;
            this.btnUpdateCashier.BackColor = System.Drawing.Color.White;
            this.btnUpdateCashier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdateCashier.FlatAppearance.BorderSize = 2;
            this.btnUpdateCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnUpdateCashier.Location = new System.Drawing.Point(131, 9);
            this.btnUpdateCashier.Name = "btnUpdateCashier";
            this.btnUpdateCashier.Size = new System.Drawing.Size(116, 34);
            this.btnUpdateCashier.TabIndex = 1;
            this.btnUpdateCashier.Text = "Update";
            this.btnUpdateCashier.UseVisualStyleBackColor = false;
            this.btnUpdateCashier.Click += new System.EventHandler(this.btnUpdateCashier_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.AutoSize = true;
            this.btnResetPassword.BackColor = System.Drawing.Color.White;
            this.btnResetPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnResetPassword.FlatAppearance.BorderSize = 2;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnResetPassword.Location = new System.Drawing.Point(253, 9);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(141, 34);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnAddCashier
            // 
            this.btnAddCashier.AutoSize = true;
            this.btnAddCashier.BackColor = System.Drawing.Color.White;
            this.btnAddCashier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddCashier.FlatAppearance.BorderSize = 2;
            this.btnAddCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnAddCashier.Location = new System.Drawing.Point(9, 9);
            this.btnAddCashier.Name = "btnAddCashier";
            this.btnAddCashier.Size = new System.Drawing.Size(116, 37);
            this.btnAddCashier.TabIndex = 0;
            this.btnAddCashier.Text = "Add Cashier";
            this.btnAddCashier.UseVisualStyleBackColor = false;
            this.btnAddCashier.Click += new System.EventHandler(this.btnAddCashier_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.btnRefresh.Location = new System.Drawing.Point(400, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 37);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefreshCashiers_Click);
            // 
            // cashierTableAdapter
            // 
            this.cashierTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(520, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmManageCashiers
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1075, 567);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 480);
            this.Name = "frmManageCashiers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Cashiers";
            this.Load += new System.EventHandler(this.frmManageCashiers_Load);
            this.tblMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.grpCashierDetails.ResumeLayout(false);
            this.tblDetails.ResumeLayout(false);
            this.tblDetails.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCafe101)).EndInit();
            this.pnlRightButtons.ResumeLayout(false);
            this.pnlRightButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpCashierDetails;
        private System.Windows.Forms.TableLayoutPanel tblDetails;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;

        // legacy fields kept for compatibility with existing code-behind
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.TableLayoutPanel pnlRight;
        private System.Windows.Forms.FlowLayoutPanel pnlRightButtons;
        private System.Windows.Forms.Button btnAddCashier;
        private System.Windows.Forms.Button btnUpdateCashier;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.DataGridView dgvCashiers;
        private Cafe101.dsCafe101 dsCafe101;
        private System.Windows.Forms.BindingSource cashierBindingSource;
        private Cafe101.dsCafe101TableAdapters.CashierTableAdapter cashierTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
    }
}