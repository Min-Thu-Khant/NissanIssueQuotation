namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm38
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.txtCompanyName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtBillToCompanyName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtAccountName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtCompanyNumberBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtCompanyNameReading = new MetroFramework.Controls.MetroTextBox();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnChange = new MetroFramework.Controls.MetroButton();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCOMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_COMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOMPANY_NO_BOX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_BANK_ACCOUNT_NAME_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_BANK_ACCOUNT_NAME_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_BANK_ACCOUNT_NAME_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_BANK_ACCOUNT_NAME_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNCS_CUSTOMER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_BILLING_INTERVAL = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBILL_DEPOSIT_RULES = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBILL_TRANSFER_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBILL_EXPENSES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEFFECTIVE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTRANSACTION_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colREQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colCOMPANY_NAME,
            this.colBILL_COMPANY_NAME,
            this.colCOMPANY_NO_BOX,
            this.colBILL_BANK_ACCOUNT_NAME_1,
            this.colBILL_BANK_ACCOUNT_NAME_2,
            this.colBILL_BANK_ACCOUNT_NAME_3,
            this.colBILL_BANK_ACCOUNT_NAME_4,
            this.colNCS_CUSTOMER_CODE,
            this.colBILL_BILLING_INTERVAL,
            this.colBILL_DEPOSIT_RULES,
            this.colBILL_TRANSFER_FEE,
            this.colBILL_EXPENSES,
            this.colEFFECTIVE_DATE,
            this.colTRANSACTION_TYPE,
            this.colREQ_SEQ});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(17, 159);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.Size = new System.Drawing.Size(1268, 492);
            this.dgvList.TabIndex = 12;
            this.dgvList.TabStop = false;
            this.dgvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvList_CellEndEdit);
            this.dgvList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvList_CellValidating);
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvList_DataError);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.CausesValidation = false;
            this.btnBack.Location = new System.Drawing.Point(1206, 61);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 28);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtCompanyName
            // 
            // 
            // 
            // 
            this.txtCompanyName.CustomButton.Image = null;
            this.txtCompanyName.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtCompanyName.CustomButton.Name = "";
            this.txtCompanyName.CustomButton.Size = new System.Drawing.Size(21, 23);
            this.txtCompanyName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCompanyName.CustomButton.TabIndex = 1;
            this.txtCompanyName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCompanyName.CustomButton.UseSelectable = true;
            this.txtCompanyName.CustomButton.Visible = false;
            this.txtCompanyName.Lines = new string[0];
            this.txtCompanyName.Location = new System.Drawing.Point(23, 114);
            this.txtCompanyName.MaxLength = 32767;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.PasswordChar = '\0';
            this.txtCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCompanyName.SelectedText = "";
            this.txtCompanyName.SelectionLength = 0;
            this.txtCompanyName.SelectionStart = 0;
            this.txtCompanyName.ShortcutsEnabled = true;
            this.txtCompanyName.Size = new System.Drawing.Size(149, 23);
            this.txtCompanyName.TabIndex = 5;
            this.txtCompanyName.UseSelectable = true;
            this.txtCompanyName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCompanyName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "会社名";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(182, 89);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(90, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "会社名フリガナ";
            // 
            // txtBillToCompanyName
            // 
            // 
            // 
            // 
            this.txtBillToCompanyName.CustomButton.Image = null;
            this.txtBillToCompanyName.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtBillToCompanyName.CustomButton.Name = "";
            this.txtBillToCompanyName.CustomButton.Size = new System.Drawing.Size(21, 23);
            this.txtBillToCompanyName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBillToCompanyName.CustomButton.TabIndex = 1;
            this.txtBillToCompanyName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBillToCompanyName.CustomButton.UseSelectable = true;
            this.txtBillToCompanyName.CustomButton.Visible = false;
            this.txtBillToCompanyName.Lines = new string[0];
            this.txtBillToCompanyName.Location = new System.Drawing.Point(340, 114);
            this.txtBillToCompanyName.MaxLength = 32767;
            this.txtBillToCompanyName.Name = "txtBillToCompanyName";
            this.txtBillToCompanyName.PasswordChar = '\0';
            this.txtBillToCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBillToCompanyName.SelectedText = "";
            this.txtBillToCompanyName.SelectionLength = 0;
            this.txtBillToCompanyName.SelectionStart = 0;
            this.txtBillToCompanyName.ShortcutsEnabled = true;
            this.txtBillToCompanyName.Size = new System.Drawing.Size(148, 23);
            this.txtBillToCompanyName.TabIndex = 7;
            this.txtBillToCompanyName.UseSelectable = true;
            this.txtBillToCompanyName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBillToCompanyName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(340, 89);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(99, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "請求先_会社名";
            // 
            // txtAccountName
            // 
            // 
            // 
            // 
            this.txtAccountName.CustomButton.Image = null;
            this.txtAccountName.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtAccountName.CustomButton.Name = "";
            this.txtAccountName.CustomButton.Size = new System.Drawing.Size(21, 23);
            this.txtAccountName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountName.CustomButton.TabIndex = 1;
            this.txtAccountName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountName.CustomButton.UseSelectable = true;
            this.txtAccountName.CustomButton.Visible = false;
            this.txtAccountName.Lines = new string[0];
            this.txtAccountName.Location = new System.Drawing.Point(656, 114);
            this.txtAccountName.MaxLength = 32767;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.PasswordChar = '\0';
            this.txtAccountName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountName.SelectedText = "";
            this.txtAccountName.SelectionLength = 0;
            this.txtAccountName.SelectionStart = 0;
            this.txtAccountName.ShortcutsEnabled = true;
            this.txtAccountName.Size = new System.Drawing.Size(148, 23);
            this.txtAccountName.TabIndex = 9;
            this.txtAccountName.UseSelectable = true;
            this.txtAccountName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(498, 89);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(106, 19);
            this.metroLabel4.TabIndex = 12;
            this.metroLabel4.Text = "会社番号＋BOX";
            // 
            // txtCompanyNumberBox
            // 
            // 
            // 
            // 
            this.txtCompanyNumberBox.CustomButton.Image = null;
            this.txtCompanyNumberBox.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtCompanyNumberBox.CustomButton.Name = "";
            this.txtCompanyNumberBox.CustomButton.Size = new System.Drawing.Size(21, 23);
            this.txtCompanyNumberBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCompanyNumberBox.CustomButton.TabIndex = 1;
            this.txtCompanyNumberBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCompanyNumberBox.CustomButton.UseSelectable = true;
            this.txtCompanyNumberBox.CustomButton.Visible = false;
            this.txtCompanyNumberBox.Lines = new string[0];
            this.txtCompanyNumberBox.Location = new System.Drawing.Point(498, 114);
            this.txtCompanyNumberBox.MaxLength = 32767;
            this.txtCompanyNumberBox.Name = "txtCompanyNumberBox";
            this.txtCompanyNumberBox.PasswordChar = '\0';
            this.txtCompanyNumberBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCompanyNumberBox.SelectedText = "";
            this.txtCompanyNumberBox.SelectionLength = 0;
            this.txtCompanyNumberBox.SelectionStart = 0;
            this.txtCompanyNumberBox.ShortcutsEnabled = true;
            this.txtCompanyNumberBox.Size = new System.Drawing.Size(148, 23);
            this.txtCompanyNumberBox.TabIndex = 8;
            this.txtCompanyNumberBox.UseSelectable = true;
            this.txtCompanyNumberBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCompanyNumberBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(656, 89);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "口座名";
            // 
            // txtCompanyNameReading
            // 
            // 
            // 
            // 
            this.txtCompanyNameReading.CustomButton.Image = null;
            this.txtCompanyNameReading.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtCompanyNameReading.CustomButton.Name = "";
            this.txtCompanyNameReading.CustomButton.Size = new System.Drawing.Size(21, 23);
            this.txtCompanyNameReading.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCompanyNameReading.CustomButton.TabIndex = 1;
            this.txtCompanyNameReading.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCompanyNameReading.CustomButton.UseSelectable = true;
            this.txtCompanyNameReading.CustomButton.Visible = false;
            this.txtCompanyNameReading.Lines = new string[0];
            this.txtCompanyNameReading.Location = new System.Drawing.Point(182, 114);
            this.txtCompanyNameReading.MaxLength = 32767;
            this.txtCompanyNameReading.Name = "txtCompanyNameReading";
            this.txtCompanyNameReading.PasswordChar = '\0';
            this.txtCompanyNameReading.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCompanyNameReading.SelectedText = "";
            this.txtCompanyNameReading.SelectionLength = 0;
            this.txtCompanyNameReading.SelectionStart = 0;
            this.txtCompanyNameReading.ShortcutsEnabled = true;
            this.txtCompanyNameReading.Size = new System.Drawing.Size(148, 23);
            this.txtCompanyNameReading.TabIndex = 6;
            this.txtCompanyNameReading.UseSelectable = true;
            this.txtCompanyNameReading.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCompanyNameReading.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearch
            // 
            this.btnSearch.CausesValidation = false;
            this.btnSearch.Location = new System.Drawing.Point(820, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 28);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click_1);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(973, 112);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(138, 28);
            this.btnChange.TabIndex = 11;
            this.btnChange.Text = "変更";
            this.btnChange.UseSelectable = true;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click_1);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colCOMPANY_NAME
            // 
            this.colCOMPANY_NAME.DataPropertyName = "COMPANY_NAME";
            this.colCOMPANY_NAME.HeaderText = "会社名";
            this.colCOMPANY_NAME.Name = "colCOMPANY_NAME";
            this.colCOMPANY_NAME.ReadOnly = true;
            this.colCOMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_COMPANY_NAME
            // 
            this.colBILL_COMPANY_NAME.DataPropertyName = "BILL_COMPANY_NAME";
            this.colBILL_COMPANY_NAME.HeaderText = "請求先＿会社名";
            this.colBILL_COMPANY_NAME.Name = "colBILL_COMPANY_NAME";
            this.colBILL_COMPANY_NAME.ReadOnly = true;
            this.colBILL_COMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCOMPANY_NO_BOX
            // 
            this.colCOMPANY_NO_BOX.DataPropertyName = "COMPANY_NO_BOX";
            this.colCOMPANY_NO_BOX.HeaderText = "会社番号＋BOX";
            this.colCOMPANY_NO_BOX.Name = "colCOMPANY_NO_BOX";
            this.colCOMPANY_NO_BOX.ReadOnly = true;
            this.colCOMPANY_NO_BOX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_BANK_ACCOUNT_NAME_1
            // 
            this.colBILL_BANK_ACCOUNT_NAME_1.DataPropertyName = "BILL_BANK_ACCOUNT_NAME-1";
            this.colBILL_BANK_ACCOUNT_NAME_1.HeaderText = "銀行口座名1";
            this.colBILL_BANK_ACCOUNT_NAME_1.Name = "colBILL_BANK_ACCOUNT_NAME_1";
            this.colBILL_BANK_ACCOUNT_NAME_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_BANK_ACCOUNT_NAME_2
            // 
            this.colBILL_BANK_ACCOUNT_NAME_2.DataPropertyName = "BILL_BANK_ACCOUNT_NAME-2";
            this.colBILL_BANK_ACCOUNT_NAME_2.HeaderText = "銀行口座名2";
            this.colBILL_BANK_ACCOUNT_NAME_2.Name = "colBILL_BANK_ACCOUNT_NAME_2";
            this.colBILL_BANK_ACCOUNT_NAME_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_BANK_ACCOUNT_NAME_3
            // 
            this.colBILL_BANK_ACCOUNT_NAME_3.DataPropertyName = "BILL_BANK_ACCOUNT_NAME-3";
            this.colBILL_BANK_ACCOUNT_NAME_3.HeaderText = "銀行口座名3";
            this.colBILL_BANK_ACCOUNT_NAME_3.Name = "colBILL_BANK_ACCOUNT_NAME_3";
            this.colBILL_BANK_ACCOUNT_NAME_3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_BANK_ACCOUNT_NAME_4
            // 
            this.colBILL_BANK_ACCOUNT_NAME_4.DataPropertyName = "BILL_BANK_ACCOUNT_NAME-4";
            this.colBILL_BANK_ACCOUNT_NAME_4.HeaderText = "銀行口座名4";
            this.colBILL_BANK_ACCOUNT_NAME_4.Name = "colBILL_BANK_ACCOUNT_NAME_4";
            this.colBILL_BANK_ACCOUNT_NAME_4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNCS_CUSTOMER_CODE
            // 
            this.colNCS_CUSTOMER_CODE.DataPropertyName = "NCS_CUSTOMER_CODE";
            this.colNCS_CUSTOMER_CODE.HeaderText = "経理取引先コード";
            this.colNCS_CUSTOMER_CODE.Name = "colNCS_CUSTOMER_CODE";
            this.colNCS_CUSTOMER_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_BILLING_INTERVAL
            // 
            this.colBILL_BILLING_INTERVAL.DataPropertyName = "BILL_BILLING_INTERVAL";
            this.colBILL_BILLING_INTERVAL.HeaderText = "年額月額区分";
            this.colBILL_BILLING_INTERVAL.Items.AddRange(new object[] {
            "月額",
            "四半期",
            "半期",
            "年額"});
            this.colBILL_BILLING_INTERVAL.Name = "colBILL_BILLING_INTERVAL";
            this.colBILL_BILLING_INTERVAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colBILL_DEPOSIT_RULES
            // 
            this.colBILL_DEPOSIT_RULES.DataPropertyName = "BILL_DEPOSIT_RULES";
            this.colBILL_DEPOSIT_RULES.HeaderText = "入金時期";
            this.colBILL_DEPOSIT_RULES.Items.AddRange(new object[] {
            "翌月",
            "当月",
            "翌々月月頭"});
            this.colBILL_DEPOSIT_RULES.Name = "colBILL_DEPOSIT_RULES";
            this.colBILL_DEPOSIT_RULES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colBILL_TRANSFER_FEE
            // 
            this.colBILL_TRANSFER_FEE.DataPropertyName = "BILL_TRANSFER_FEE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colBILL_TRANSFER_FEE.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBILL_TRANSFER_FEE.HeaderText = "銀行振込手数料";
            this.colBILL_TRANSFER_FEE.Name = "colBILL_TRANSFER_FEE";
            this.colBILL_TRANSFER_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBILL_EXPENSES
            // 
            this.colBILL_EXPENSES.DataPropertyName = "BILL_EXPENSES";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colBILL_EXPENSES.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBILL_EXPENSES.HeaderText = "諸経費";
            this.colBILL_EXPENSES.Name = "colBILL_EXPENSES";
            this.colBILL_EXPENSES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEFFECTIVE_DATE
            // 
            this.colEFFECTIVE_DATE.DataPropertyName = "EFFECTIVE_DATE";
            this.colEFFECTIVE_DATE.HeaderText = "EFFECTIVE_DATE";
            this.colEFFECTIVE_DATE.Name = "colEFFECTIVE_DATE";
            this.colEFFECTIVE_DATE.ReadOnly = true;
            this.colEFFECTIVE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEFFECTIVE_DATE.Visible = false;
            // 
            // colTRANSACTION_TYPE
            // 
            this.colTRANSACTION_TYPE.DataPropertyName = "TRANSACTION_TYPE";
            this.colTRANSACTION_TYPE.HeaderText = "TRANSACTION_TYPE";
            this.colTRANSACTION_TYPE.Name = "colTRANSACTION_TYPE";
            this.colTRANSACTION_TYPE.ReadOnly = true;
            this.colTRANSACTION_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTRANSACTION_TYPE.Visible = false;
            // 
            // colREQ_SEQ
            // 
            this.colREQ_SEQ.DataPropertyName = "REQ_SEQ";
            this.colREQ_SEQ.HeaderText = "REQ_SEQ";
            this.colREQ_SEQ.Name = "colREQ_SEQ";
            this.colREQ_SEQ.Visible = false;
            // 
            // frm38
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 670);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtCompanyNameReading);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtCompanyNumberBox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtBillToCompanyName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.btnBack);
            this.Name = "frm38";
            this.Padding = new System.Windows.Forms.Padding(20, 65, 20, 20);
            this.Resizable = false;
            this.Text = "3-8. 顧客マスタ口座登録";
            this.Load += new System.EventHandler(this.Frm38_Load);
            this.SizeChanged += new System.EventHandler(this.Frm38_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvList;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroTextBox txtCompanyName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtBillToCompanyName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtAccountName;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtCompanyNumberBox;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtCompanyNameReading;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnChange;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_COMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NO_BOX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_BANK_ACCOUNT_NAME_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_BANK_ACCOUNT_NAME_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_BANK_ACCOUNT_NAME_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_BANK_ACCOUNT_NAME_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNCS_CUSTOMER_CODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBILL_BILLING_INTERVAL;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBILL_DEPOSIT_RULES;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_TRANSFER_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBILL_EXPENSES;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEFFECTIVE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTRANSACTION_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colREQ_SEQ;
    }
}