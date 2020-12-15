namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm36
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
            this.btnCheckTheResult = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtToDate = new MetroFramework.Controls.MetroTextBox();
            this.txtFromDate = new MetroFramework.Controls.MetroTextBox();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btnRefund = new MetroFramework.Controls.MetroButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SEQ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPOSIT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_COMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_CONTACT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_PHONE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_MAIL_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckTheResult
            // 
            this.btnCheckTheResult.Location = new System.Drawing.Point(448, 98);
            this.btnCheckTheResult.Name = "btnCheckTheResult";
            this.btnCheckTheResult.Size = new System.Drawing.Size(143, 26);
            this.btnCheckTheResult.TabIndex = 3;
            this.btnCheckTheResult.Text = "結果確認";
            this.btnCheckTheResult.UseSelectable = true;
            this.btnCheckTheResult.Click += new System.EventHandler(this.BtnCheckTheResult_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(216, 102);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(18, 19);
            this.metroLabel3.TabIndex = 619;
            this.metroLabel3.Text = "~";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(240, 80);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 618;
            this.metroLabel2.Text = "引当日(TO)";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(25, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 617;
            this.metroLabel1.Text = "引当日(FROM)";
            // 
            // txtToDate
            // 
            // 
            // 
            // 
            this.txtToDate.CustomButton.Image = null;
            this.txtToDate.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtToDate.CustomButton.Name = "";
            this.txtToDate.CustomButton.Size = new System.Drawing.Size(19, 18);
            this.txtToDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToDate.CustomButton.TabIndex = 1;
            this.txtToDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtToDate.CustomButton.UseSelectable = true;
            this.txtToDate.CustomButton.Visible = false;
            this.txtToDate.Lines = new string[0];
            this.txtToDate.Location = new System.Drawing.Point(240, 101);
            this.txtToDate.MaxLength = 32767;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.PasswordChar = '\0';
            this.txtToDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToDate.SelectedText = "";
            this.txtToDate.SelectionLength = 0;
            this.txtToDate.SelectionStart = 0;
            this.txtToDate.ShortcutsEnabled = true;
            this.txtToDate.Size = new System.Drawing.Size(185, 21);
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
            this.txtFromDate.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtFromDate.CustomButton.Name = "";
            this.txtFromDate.CustomButton.Size = new System.Drawing.Size(19, 18);
            this.txtFromDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFromDate.CustomButton.TabIndex = 1;
            this.txtFromDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFromDate.CustomButton.UseSelectable = true;
            this.txtFromDate.CustomButton.Visible = false;
            this.txtFromDate.Lines = new string[0];
            this.txtFromDate.Location = new System.Drawing.Point(25, 101);
            this.txtFromDate.MaxLength = 32767;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.PasswordChar = '\0';
            this.txtFromDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFromDate.SelectedText = "";
            this.txtFromDate.SelectionLength = 0;
            this.txtFromDate.SelectionStart = 0;
            this.txtFromDate.ShortcutsEnabled = true;
            this.txtFromDate.Size = new System.Drawing.Size(185, 21);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.UseSelectable = true;
            this.txtFromDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFromDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1219, 56);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 26);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefund.Location = new System.Drawing.Point(1155, 98);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(125, 26);
            this.btnRefund.TabIndex = 4;
            this.btnRefund.Text = "返金処理";
            this.btnRefund.UseSelectable = true;
            this.btnRefund.Click += new System.EventHandler(this.BtnRefund_Click);
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
            this.colCheck,
            this.SEQ_NO,
            this.DateTimeID,
            this.CUSTOMER_NAME,
            this.DEPOSIT_AMOUNT,
            this.BILL_COMPANY_NAME,
            this.BILL_CONTACT_NAME,
            this.BILL_PHONE_NUMBER,
            this.BILL_MAIL_ADDRESS});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(25, 142);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1255, 459);
            this.dgvList.TabIndex = 5;
            this.dgvList.TabStop = false;
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint_1);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // SEQ_NO
            // 
            this.SEQ_NO.DataPropertyName = "SEQ_NO";
            this.SEQ_NO.HeaderText = "SEQ_NO";
            this.SEQ_NO.Name = "SEQ_NO";
            this.SEQ_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SEQ_NO.Visible = false;
            // 
            // DateTimeID
            // 
            this.DateTimeID.DataPropertyName = "DateTimeID";
            this.DateTimeID.HeaderText = "DateTimeID";
            this.DateTimeID.Name = "DateTimeID";
            this.DateTimeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateTimeID.Visible = false;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "銀行口座名";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DEPOSIT_AMOUNT
            // 
            this.DEPOSIT_AMOUNT.DataPropertyName = "DEPOSIT_AMOUNT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.DEPOSIT_AMOUNT.DefaultCellStyle = dataGridViewCellStyle1;
            this.DEPOSIT_AMOUNT.HeaderText = "振込金額";
            this.DEPOSIT_AMOUNT.Name = "DEPOSIT_AMOUNT";
            this.DEPOSIT_AMOUNT.ReadOnly = true;
            this.DEPOSIT_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BILL_COMPANY_NAME
            // 
            this.BILL_COMPANY_NAME.DataPropertyName = "BILL_COMPANY_NAME";
            this.BILL_COMPANY_NAME.HeaderText = "取引先会社名";
            this.BILL_COMPANY_NAME.Name = "BILL_COMPANY_NAME";
            this.BILL_COMPANY_NAME.ReadOnly = true;
            this.BILL_COMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BILL_CONTACT_NAME
            // 
            this.BILL_CONTACT_NAME.DataPropertyName = "BILL_CONTACT_NAME";
            this.BILL_CONTACT_NAME.HeaderText = "請求担当者";
            this.BILL_CONTACT_NAME.Name = "BILL_CONTACT_NAME";
            this.BILL_CONTACT_NAME.ReadOnly = true;
            this.BILL_CONTACT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BILL_PHONE_NUMBER
            // 
            this.BILL_PHONE_NUMBER.DataPropertyName = "BILL_PHONE_NUMBER";
            this.BILL_PHONE_NUMBER.HeaderText = "電話";
            this.BILL_PHONE_NUMBER.Name = "BILL_PHONE_NUMBER";
            this.BILL_PHONE_NUMBER.ReadOnly = true;
            this.BILL_PHONE_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BILL_MAIL_ADDRESS
            // 
            this.BILL_MAIL_ADDRESS.DataPropertyName = "BILL_MAIL_ADDRESS";
            this.BILL_MAIL_ADDRESS.HeaderText = "メール";
            this.BILL_MAIL_ADDRESS.Name = "BILL_MAIL_ADDRESS";
            this.BILL_MAIL_ADDRESS.ReadOnly = true;
            this.BILL_MAIL_ADDRESS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frm36
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCheckTheResult);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.txtFromDate);
            this.Name = "frm36";
            this.Padding = new System.Windows.Forms.Padding(20, 55, 20, 18);
            this.Resizable = false;
            this.Text = "3-6. 請求書不一致確認\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n";
            this.Load += new System.EventHandler(this.Frm36_Load);
            this.SizeChanged += new System.EventHandler(this.Frm36_SizeChanged);
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
        private MetroFramework.Controls.MetroButton btnRefund;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPOSIT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_COMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_CONTACT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_PHONE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_MAIL_ADDRESS;
    }
}