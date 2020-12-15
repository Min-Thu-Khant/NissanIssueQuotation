namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm35
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCheckTheResult = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtToDate = new MetroFramework.Controls.MetroTextBox();
            this.txtFromDate = new MetroFramework.Controls.MetroTextBox();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.btnCancelAllocation = new MetroFramework.Controls.MetroButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtCompanyName = new MetroFramework.Controls.MetroTextBox();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.chkNoReserved = new System.Windows.Forms.CheckBox();
            this.colBankAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmtofMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBillAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReserveAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANY_NO_BOX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YEAR_MONTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESERVE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckTheResult
            // 
            this.btnCheckTheResult.Location = new System.Drawing.Point(468, 91);
            this.btnCheckTheResult.Name = "btnCheckTheResult";
            this.btnCheckTheResult.Size = new System.Drawing.Size(143, 26);
            this.btnCheckTheResult.TabIndex = 4;
            this.btnCheckTheResult.Text = "結果確認";
            this.btnCheckTheResult.UseSelectable = true;
            this.btnCheckTheResult.Click += new System.EventHandler(this.BtnCheckTheResult_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(184, 96);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(18, 19);
            this.metroLabel3.TabIndex = 613;
            this.metroLabel3.Text = "~";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(208, 74);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 612;
            this.metroLabel2.Text = "引当日(TO)";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(25, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 611;
            this.metroLabel1.Text = "引当日(FROM)";
            // 
            // txtToDate
            // 
            // 
            // 
            // 
            this.txtToDate.CustomButton.Image = null;
            this.txtToDate.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.txtToDate.CustomButton.Name = "";
            this.txtToDate.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtToDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToDate.CustomButton.TabIndex = 1;
            this.txtToDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtToDate.CustomButton.UseSelectable = true;
            this.txtToDate.CustomButton.Visible = false;
            this.txtToDate.Lines = new string[0];
            this.txtToDate.Location = new System.Drawing.Point(208, 94);
            this.txtToDate.MaxLength = 32767;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.PasswordChar = '\0';
            this.txtToDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToDate.SelectedText = "";
            this.txtToDate.SelectionLength = 0;
            this.txtToDate.SelectionStart = 0;
            this.txtToDate.ShortcutsEnabled = true;
            this.txtToDate.Size = new System.Drawing.Size(155, 21);
            this.txtToDate.TabIndex = 2;
            this.txtToDate.UseSelectable = true;
            this.txtToDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtToDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtFromDate
            // 
            // 
            // 
            // 
            this.txtFromDate.CustomButton.Image = null;
            this.txtFromDate.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.txtFromDate.CustomButton.Name = "";
            this.txtFromDate.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtFromDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFromDate.CustomButton.TabIndex = 1;
            this.txtFromDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFromDate.CustomButton.UseSelectable = true;
            this.txtFromDate.CustomButton.Visible = false;
            this.txtFromDate.Lines = new string[0];
            this.txtFromDate.Location = new System.Drawing.Point(25, 94);
            this.txtFromDate.MaxLength = 32767;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.PasswordChar = '\0';
            this.txtFromDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFromDate.SelectedText = "";
            this.txtFromDate.SelectionLength = 0;
            this.txtFromDate.SelectionStart = 0;
            this.txtFromDate.ShortcutsEnabled = true;
            this.txtFromDate.Size = new System.Drawing.Size(155, 21);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.UseSelectable = true;
            this.txtFromDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFromDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1220, 52);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 26);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click_1);
            // 
            // btnCSV
            // 
            this.btnCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCSV.Location = new System.Drawing.Point(979, 91);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(143, 26);
            this.btnCSV.TabIndex = 7;
            this.btnCSV.Text = "経理CSV出力";
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.BtnCSV_Click);
            // 
            // btnCancelAllocation
            // 
            this.btnCancelAllocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAllocation.Location = new System.Drawing.Point(1138, 91);
            this.btnCancelAllocation.Name = "btnCancelAllocation";
            this.btnCancelAllocation.Size = new System.Drawing.Size(143, 26);
            this.btnCancelAllocation.TabIndex = 8;
            this.btnCancelAllocation.Text = "引当キャンセル";
            this.btnCancelAllocation.UseSelectable = true;
            this.btnCancelAllocation.Click += new System.EventHandler(this.BtnCancelAllocation_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBankAcc,
            this.colAmtofMoney,
            this.colFee,
            this.colCheck,
            this.colCustomer,
            this.colMonth,
            this.colInvoiceNo,
            this.colBillAmt,
            this.colReserveAmt,
            this.colDifference,
            this.SEQ_NO,
            this.COMPANY_NO_BOX,
            this.YEAR_MONTH,
            this.RESERVE_ID});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(20, 130);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1261, 474);
            this.dgvList.TabIndex = 6;
            this.dgvList.TabStop = false;
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.SizeChanged += new System.EventHandler(this.DgvList_SizeChanged);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(632, 74);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(86, 19);
            this.metroLabel4.TabIndex = 615;
            this.metroLabel4.Text = "取引先会社 :";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCompanyName.CustomButton.Image = null;
            this.txtCompanyName.CustomButton.Location = new System.Drawing.Point(151, 1);
            this.txtCompanyName.CustomButton.Name = "";
            this.txtCompanyName.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtCompanyName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCompanyName.CustomButton.TabIndex = 1;
            this.txtCompanyName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCompanyName.CustomButton.UseSelectable = true;
            this.txtCompanyName.CustomButton.Visible = false;
            this.txtCompanyName.Lines = new string[0];
            this.txtCompanyName.Location = new System.Drawing.Point(632, 94);
            this.txtCompanyName.MaxLength = 32767;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.PasswordChar = '\0';
            this.txtCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCompanyName.SelectedText = "";
            this.txtCompanyName.SelectionLength = 0;
            this.txtCompanyName.SelectionStart = 0;
            this.txtCompanyName.ShortcutsEnabled = true;
            this.txtCompanyName.Size = new System.Drawing.Size(171, 21);
            this.txtCompanyName.TabIndex = 5;
            this.txtCompanyName.UseSelectable = true;
            this.txtCompanyName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCompanyName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(821, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 26);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(366, 74);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(102, 19);
            this.metroLabel5.TabIndex = 617;
            this.metroLabel5.Text = "引当未完了のみ";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkNoReserved
            // 
            this.chkNoReserved.AutoSize = true;
            this.chkNoReserved.Location = new System.Drawing.Point(411, 97);
            this.chkNoReserved.Name = "chkNoReserved";
            this.chkNoReserved.Size = new System.Drawing.Size(15, 14);
            this.chkNoReserved.TabIndex = 3;
            this.chkNoReserved.UseVisualStyleBackColor = true;
            // 
            // colBankAcc
            // 
            this.colBankAcc.DataPropertyName = "CUSTOMER_NAME_SHOW";
            this.colBankAcc.FillWeight = 150F;
            this.colBankAcc.HeaderText = "銀行口座名";
            this.colBankAcc.Name = "colBankAcc";
            this.colBankAcc.ReadOnly = true;
            this.colBankAcc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAmtofMoney
            // 
            this.colAmtofMoney.DataPropertyName = "DEPOSIT_AMOUNT_SHOW";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colAmtofMoney.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmtofMoney.FillWeight = 150F;
            this.colAmtofMoney.HeaderText = "振込金額";
            this.colAmtofMoney.Name = "colAmtofMoney";
            this.colAmtofMoney.ReadOnly = true;
            this.colAmtofMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFee
            // 
            this.colFee.DataPropertyName = "BILL_TRANSFER_FEE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colFee.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFee.HeaderText = "振込手数料";
            this.colFee.Name = "colFee";
            this.colFee.ReadOnly = true;
            this.colFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "BILL_SUPPLIER_NAME";
            this.colCustomer.HeaderText = "取引先会社名";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMonth
            // 
            this.colMonth.DataPropertyName = "BILLING_MONTH";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMonth.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMonth.HeaderText = "請求月";
            this.colMonth.Name = "colMonth";
            this.colMonth.ReadOnly = true;
            this.colMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "BILLING_CODE";
            this.colInvoiceNo.HeaderText = "請求書№";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            this.colInvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBillAmt
            // 
            this.colBillAmt.DataPropertyName = "BILL_PRICE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colBillAmt.DefaultCellStyle = dataGridViewCellStyle4;
            this.colBillAmt.HeaderText = "請求金額";
            this.colBillAmt.Name = "colBillAmt";
            this.colBillAmt.ReadOnly = true;
            this.colBillAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colReserveAmt
            // 
            this.colReserveAmt.DataPropertyName = "RESERVE_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colReserveAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.colReserveAmt.HeaderText = "引当金額";
            this.colReserveAmt.Name = "colReserveAmt";
            this.colReserveAmt.ReadOnly = true;
            this.colReserveAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDifference
            // 
            this.colDifference.DataPropertyName = "DIFF_ALLOCATION_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.colDifference.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDifference.HeaderText = "差異";
            this.colDifference.Name = "colDifference";
            this.colDifference.ReadOnly = true;
            this.colDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SEQ_NO
            // 
            this.SEQ_NO.DataPropertyName = "SEQ_NO";
            this.SEQ_NO.HeaderText = "SEQ_NO";
            this.SEQ_NO.Name = "SEQ_NO";
            this.SEQ_NO.ReadOnly = true;
            this.SEQ_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SEQ_NO.Visible = false;
            // 
            // COMPANY_NO_BOX
            // 
            this.COMPANY_NO_BOX.DataPropertyName = "COMPANY_NO_BOX";
            this.COMPANY_NO_BOX.HeaderText = "COMPANY_NO_BOX";
            this.COMPANY_NO_BOX.Name = "COMPANY_NO_BOX";
            this.COMPANY_NO_BOX.ReadOnly = true;
            this.COMPANY_NO_BOX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COMPANY_NO_BOX.Visible = false;
            // 
            // YEAR_MONTH
            // 
            this.YEAR_MONTH.DataPropertyName = "YEAR_MONTH";
            this.YEAR_MONTH.HeaderText = "YEAR_MONTH";
            this.YEAR_MONTH.Name = "YEAR_MONTH";
            this.YEAR_MONTH.ReadOnly = true;
            this.YEAR_MONTH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YEAR_MONTH.Visible = false;
            // 
            // RESERVE_ID
            // 
            this.RESERVE_ID.DataPropertyName = "RESERVE_ID";
            this.RESERVE_ID.HeaderText = "RESERVE_ID";
            this.RESERVE_ID.Name = "RESERVE_ID";
            this.RESERVE_ID.ReadOnly = true;
            this.RESERVE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RESERVE_ID.Visible = false;
            // 
            // frm35
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.chkNoReserved);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnCancelAllocation);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCheckTheResult);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.txtFromDate);
            this.Name = "frm35";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 18);
            this.Resizable = false;
            this.Text = "3-5. 照合結果明細";
            this.Load += new System.EventHandler(this.Frm35_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnCheckTheResult;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtToDate;
        private MetroFramework.Controls.MetroTextBox txtFromDate;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroButton btnCancelAllocation;
        private System.Windows.Forms.DataGridView dgvList;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtCompanyName;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.CheckBox chkNoReserved;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmtofMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBillAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReserveAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY_NO_BOX;
        private System.Windows.Forms.DataGridViewTextBoxColumn YEAR_MONTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESERVE_ID;
    }
}