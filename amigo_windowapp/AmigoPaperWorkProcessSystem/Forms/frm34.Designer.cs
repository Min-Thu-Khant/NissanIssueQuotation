namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm34
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFromDate = new MetroFramework.Controls.MetroTextBox();
            this.txtToDate = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btnCheckTheResult = new MetroFramework.Controls.MetroButton();
            this.btnComparisnResultDetail = new MetroFramework.Controls.MetroButton();
            this.btnCheckUnmatchedInvoice = new MetroFramework.Controls.MetroButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btn3B = new MetroFramework.Controls.MetroButton();
            this.tmr3B = new System.Windows.Forms.Timer(this.components);
            this.colDateTimeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAllocationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAllocationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMismatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
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
            this.txtFromDate.Location = new System.Drawing.Point(30, 93);
            this.txtFromDate.MaxLength = 32767;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.PasswordChar = '\0';
            this.txtFromDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFromDate.SelectedText = "";
            this.txtFromDate.SelectionLength = 0;
            this.txtFromDate.SelectionStart = 0;
            this.txtFromDate.ShortcutsEnabled = true;
            this.txtFromDate.Size = new System.Drawing.Size(185, 21);
            this.txtFromDate.TabIndex = 3;
            this.txtFromDate.UseSelectable = true;
            this.txtFromDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFromDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.txtToDate.Location = new System.Drawing.Point(245, 93);
            this.txtToDate.MaxLength = 32767;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.PasswordChar = '\0';
            this.txtToDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToDate.SelectedText = "";
            this.txtToDate.SelectionLength = 0;
            this.txtToDate.SelectionStart = 0;
            this.txtToDate.ShortcutsEnabled = true;
            this.txtToDate.Size = new System.Drawing.Size(185, 21);
            this.txtToDate.TabIndex = 4;
            this.txtToDate.UseSelectable = true;
            this.txtToDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtToDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(30, 73);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "引当日(FROM)";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(245, 73);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "引当日(TO)";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(221, 95);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(18, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "~";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1222, 49);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 26);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click_1);
            // 
            // btnCheckTheResult
            // 
            this.btnCheckTheResult.Location = new System.Drawing.Point(454, 90);
            this.btnCheckTheResult.Name = "btnCheckTheResult";
            this.btnCheckTheResult.Size = new System.Drawing.Size(143, 26);
            this.btnCheckTheResult.TabIndex = 5;
            this.btnCheckTheResult.Text = "結果確認";
            this.btnCheckTheResult.UseSelectable = true;
            this.btnCheckTheResult.Click += new System.EventHandler(this.BtnCheckTheResult_Click);
            // 
            // btnComparisnResultDetail
            // 
            this.btnComparisnResultDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComparisnResultDetail.Location = new System.Drawing.Point(816, 90);
            this.btnComparisnResultDetail.Name = "btnComparisnResultDetail";
            this.btnComparisnResultDetail.Size = new System.Drawing.Size(143, 26);
            this.btnComparisnResultDetail.TabIndex = 6;
            this.btnComparisnResultDetail.Text = "照合結果明細";
            this.btnComparisnResultDetail.UseSelectable = true;
            this.btnComparisnResultDetail.Click += new System.EventHandler(this.BtnComparisnResultDetail_Click);
            // 
            // btnCheckUnmatchedInvoice
            // 
            this.btnCheckUnmatchedInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUnmatchedInvoice.Location = new System.Drawing.Point(979, 90);
            this.btnCheckUnmatchedInvoice.Name = "btnCheckUnmatchedInvoice";
            this.btnCheckUnmatchedInvoice.Size = new System.Drawing.Size(143, 26);
            this.btnCheckUnmatchedInvoice.TabIndex = 7;
            this.btnCheckUnmatchedInvoice.Text = "請求不一致明細";
            this.btnCheckUnmatchedInvoice.UseSelectable = true;
            this.btnCheckUnmatchedInvoice.Click += new System.EventHandler(this.BtnCheckUnmatchedInvoice_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTimeID,
            this.colTransferDate,
            this.colTransferTime,
            this.colAllocationDate,
            this.colAllocationTime,
            this.colMatch,
            this.colMismatch});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(17, 134);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1266, 469);
            this.dgvList.TabIndex = 9;
            this.dgvList.TabStop = false;
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // btn3B
            // 
            this.btn3B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3B.Location = new System.Drawing.Point(1140, 90);
            this.btn3B.Name = "btn3B";
            this.btn3B.Size = new System.Drawing.Size(143, 26);
            this.btn3B.TabIndex = 8;
            this.btn3B.Text = "3-B. 突合せ処理起動";
            this.btn3B.UseSelectable = true;
            this.btn3B.Click += new System.EventHandler(this.Btn3B_Click);
            // 
            // tmr3B
            // 
            this.tmr3B.Interval = 10000;
            this.tmr3B.Tick += new System.EventHandler(this.Tmr3B_Tick);
            // 
            // colDateTimeID
            // 
            this.colDateTimeID.DataPropertyName = "DateTimeID";
            this.colDateTimeID.HeaderText = "DateTimeID";
            this.colDateTimeID.Name = "colDateTimeID";
            this.colDateTimeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDateTimeID.Visible = false;
            // 
            // colTransferDate
            // 
            this.colTransferDate.DataPropertyName = "PaymenDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTransferDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTransferDate.FillWeight = 200F;
            this.colTransferDate.HeaderText = "振替処理日";
            this.colTransferDate.Name = "colTransferDate";
            this.colTransferDate.ReadOnly = true;
            this.colTransferDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransferTime
            // 
            this.colTransferTime.DataPropertyName = "PaymentTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTransferTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTransferTime.HeaderText = "転送処理時間";
            this.colTransferTime.Name = "colTransferTime";
            this.colTransferTime.ReadOnly = true;
            this.colTransferTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAllocationDate
            // 
            this.colAllocationDate.DataPropertyName = "RunDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colAllocationDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAllocationDate.FillWeight = 200F;
            this.colAllocationDate.HeaderText = "配分処理日";
            this.colAllocationDate.Name = "colAllocationDate";
            this.colAllocationDate.ReadOnly = true;
            this.colAllocationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAllocationTime
            // 
            this.colAllocationTime.DataPropertyName = "RunTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAllocationTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAllocationTime.HeaderText = "割り振り処理時間";
            this.colAllocationTime.Name = "colAllocationTime";
            this.colAllocationTime.ReadOnly = true;
            this.colAllocationTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMatch
            // 
            this.colMatch.DataPropertyName = "COUNT_Allocated";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colMatch.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMatch.HeaderText = "請求書一致件数";
            this.colMatch.Name = "colMatch";
            this.colMatch.ReadOnly = true;
            this.colMatch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMismatch
            // 
            this.colMismatch.DataPropertyName = "COUNT_NotAllocated";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.colMismatch.DefaultCellStyle = dataGridViewCellStyle6;
            this.colMismatch.FillWeight = 130F;
            this.colMismatch.HeaderText = "請求書不一致件数";
            this.colMismatch.Name = "colMismatch";
            this.colMismatch.ReadOnly = true;
            this.colMismatch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frm34
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.btn3B);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnCheckUnmatchedInvoice);
            this.Controls.Add(this.btnComparisnResultDetail);
            this.Controls.Add(this.btnCheckTheResult);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.txtFromDate);
            this.Name = "frm34";
            this.Padding = new System.Windows.Forms.Padding(20, 55, 20, 18);
            this.Resizable = false;
            this.Text = "3-4. 照合結果確認";
            this.Load += new System.EventHandler(this.Frm34_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox txtFromDate;
        private MetroFramework.Controls.MetroTextBox txtToDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroButton btnCheckTheResult;
        private MetroFramework.Controls.MetroButton btnComparisnResultDetail;
        private MetroFramework.Controls.MetroButton btnCheckUnmatchedInvoice;
        private System.Windows.Forms.DataGridView dgvList;
        private MetroFramework.Controls.MetroButton btn3B;
        private System.Windows.Forms.Timer tmr3B;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTimeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAllocationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAllocationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMismatch;
    }
}