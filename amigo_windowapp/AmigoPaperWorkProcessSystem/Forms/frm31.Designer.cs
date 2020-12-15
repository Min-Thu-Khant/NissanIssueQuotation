namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm31
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btn3B = new MetroFramework.Controls.MetroButton();
            this.btnChecktheResult = new MetroFramework.Controls.MetroButton();
            this.btnCheckAmigoData = new MetroFramework.Controls.MetroButton();
            this.btnNoneAmigoCheckData = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtFromDate = new MetroFramework.Controls.MetroTextBox();
            this.txtToDate = new MetroFramework.Controls.MetroTextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tmr3B = new System.Windows.Forms.Timer(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmigodata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNonAmigodata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatching = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTimeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 596;
            this.label3.Text = "~";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(445, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(178, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1208, 52);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 26);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btn3B
            // 
            this.btn3B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3B.Location = new System.Drawing.Point(1092, 123);
            this.btn3B.Name = "btn3B";
            this.btn3B.Size = new System.Drawing.Size(191, 26);
            this.btn3B.TabIndex = 6;
            this.btn3B.Text = "請求書突合処理起動";
            this.btn3B.UseSelectable = true;
            this.btn3B.Click += new System.EventHandler(this.Btn3B_Click);
            // 
            // btnChecktheResult
            // 
            this.btnChecktheResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChecktheResult.Location = new System.Drawing.Point(1092, 87);
            this.btnChecktheResult.Name = "btnChecktheResult";
            this.btnChecktheResult.Size = new System.Drawing.Size(191, 26);
            this.btnChecktheResult.TabIndex = 4;
            this.btnChecktheResult.Text = "突合結果確認";
            this.btnChecktheResult.UseSelectable = true;
            this.btnChecktheResult.Click += new System.EventHandler(this.BtnChecktheResult_Click);
            // 
            // btnCheckAmigoData
            // 
            this.btnCheckAmigoData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAmigoData.Location = new System.Drawing.Point(893, 88);
            this.btnCheckAmigoData.Name = "btnCheckAmigoData";
            this.btnCheckAmigoData.Size = new System.Drawing.Size(191, 26);
            this.btnCheckAmigoData.TabIndex = 3;
            this.btnCheckAmigoData.Text = "Amigoデータ確認";
            this.btnCheckAmigoData.UseSelectable = true;
            this.btnCheckAmigoData.Click += new System.EventHandler(this.BtnCheckAmigoData_Click);
            // 
            // btnNoneAmigoCheckData
            // 
            this.btnNoneAmigoCheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoneAmigoCheckData.Location = new System.Drawing.Point(893, 123);
            this.btnNoneAmigoCheckData.Name = "btnNoneAmigoCheckData";
            this.btnNoneAmigoCheckData.Size = new System.Drawing.Size(191, 26);
            this.btnNoneAmigoCheckData.TabIndex = 5;
            this.btnNoneAmigoCheckData.Text = "Amigo外データ確認";
            this.btnNoneAmigoCheckData.UseSelectable = true;
            this.btnNoneAmigoCheckData.Click += new System.EventHandler(this.BtnNoneAmigoCheckData_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(28, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(87, 15);
            this.metroLabel1.TabIndex = 603;
            this.metroLabel1.Text = "取込日(FROM)";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(235, 69);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 15);
            this.metroLabel2.TabIndex = 604;
            this.metroLabel2.Text = "取込日(TO)";
            // 
            // txtFromDate
            // 
            // 
            // 
            // 
            this.txtFromDate.CustomButton.Image = null;
            this.txtFromDate.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtFromDate.CustomButton.Name = "";
            this.txtFromDate.CustomButton.Size = new System.Drawing.Size(19, 18);
            this.txtFromDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFromDate.CustomButton.TabIndex = 1;
            this.txtFromDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFromDate.CustomButton.UseSelectable = true;
            this.txtFromDate.CustomButton.Visible = false;
            this.txtFromDate.Lines = new string[0];
            this.txtFromDate.Location = new System.Drawing.Point(28, 89);
            this.txtFromDate.MaxLength = 32767;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.PasswordChar = '\0';
            this.txtFromDate.PromptText = "YYYY/MM/DD";
            this.txtFromDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFromDate.SelectedText = "";
            this.txtFromDate.SelectionLength = 0;
            this.txtFromDate.SelectionStart = 0;
            this.txtFromDate.ShortcutsEnabled = true;
            this.txtFromDate.Size = new System.Drawing.Size(191, 21);
            this.txtFromDate.TabIndex = 0;
            this.txtFromDate.UseSelectable = true;
            this.txtFromDate.WaterMark = "YYYY/MM/DD";
            this.txtFromDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFromDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtToDate
            // 
            // 
            // 
            // 
            this.txtToDate.CustomButton.Image = null;
            this.txtToDate.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtToDate.CustomButton.Name = "";
            this.txtToDate.CustomButton.Size = new System.Drawing.Size(19, 18);
            this.txtToDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToDate.CustomButton.TabIndex = 1;
            this.txtToDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtToDate.CustomButton.UseSelectable = true;
            this.txtToDate.CustomButton.Visible = false;
            this.txtToDate.Lines = new string[0];
            this.txtToDate.Location = new System.Drawing.Point(235, 89);
            this.txtToDate.MaxLength = 32767;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.PasswordChar = '\0';
            this.txtToDate.PromptText = "YYYY/MM/DD";
            this.txtToDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToDate.SelectedText = "";
            this.txtToDate.SelectionLength = 0;
            this.txtToDate.SelectionStart = 0;
            this.txtToDate.ShortcutsEnabled = true;
            this.txtToDate.Size = new System.Drawing.Size(191, 21);
            this.txtToDate.TabIndex = 1;
            this.txtToDate.UseSelectable = true;
            this.txtToDate.WaterMark = "YYYY/MM/DD";
            this.txtToDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtToDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.colCheck,
            this.colDate,
            this.colTime,
            this.colAmigodata,
            this.colNonAmigodata,
            this.colMatching,
            this.colPayment,
            this.colDateTimeID});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(18, 165);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1265, 438);
            this.dgvList.TabIndex = 8;
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // tmr3B
            // 
            this.tmr3B.Interval = 10000;
            this.tmr3B.Tick += new System.EventHandler(this.Tmr3B_Tick);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "RunDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDate.HeaderText = "取込日";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "RunTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTime.HeaderText = "時間";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAmigodata
            // 
            this.colAmigodata.DataPropertyName = "AmigoCount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colAmigodata.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAmigodata.FillWeight = 200F;
            this.colAmigodata.HeaderText = "入金データ件数";
            this.colAmigodata.Name = "colAmigodata";
            this.colAmigodata.ReadOnly = true;
            this.colAmigodata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNonAmigodata
            // 
            this.colNonAmigodata.DataPropertyName = "NonAmigoCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colNonAmigodata.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNonAmigodata.FillWeight = 220F;
            this.colNonAmigodata.HeaderText = "入金データ件数";
            this.colNonAmigodata.Name = "colNonAmigodata";
            this.colNonAmigodata.ReadOnly = true;
            this.colNonAmigodata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMatching
            // 
            this.colMatching.DataPropertyName = "ActualRunDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMatching.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMatching.FillWeight = 200F;
            this.colMatching.HeaderText = "突合わせ処理実績日";
            this.colMatching.Name = "colMatching";
            this.colMatching.ReadOnly = true;
            this.colMatching.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPayment
            // 
            this.colPayment.DataPropertyName = "PAYMENT_DAY";
            this.colPayment.HeaderText = "PAYMENT DAY";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            this.colPayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPayment.Visible = false;
            // 
            // colDateTimeID
            // 
            this.colDateTimeID.DataPropertyName = "DateTimeID";
            this.colDateTimeID.HeaderText = "DateTimeID";
            this.colDateTimeID.Name = "colDateTimeID";
            this.colDateTimeID.ReadOnly = true;
            this.colDateTimeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDateTimeID.Visible = false;
            // 
            // frm31
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCheckAmigoData);
            this.Controls.Add(this.btnNoneAmigoCheckData);
            this.Controls.Add(this.btnChecktheResult);
            this.Controls.Add(this.btn3B);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm31";
            this.Padding = new System.Windows.Forms.Padding(20, 55, 20, 18);
            this.Resizable = false;
            this.Text = "3-1.銀行振込情報取込結果確認\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n";
            this.Load += new System.EventHandler(this.Frm31_Load);
            this.SizeChanged += new System.EventHandler(this.Frm31_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroButton btn3B;
        private MetroFramework.Controls.MetroButton btnChecktheResult;
        private MetroFramework.Controls.MetroButton btnCheckAmigoData;
        private MetroFramework.Controls.MetroButton btnNoneAmigoCheckData;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtFromDate;
        private MetroFramework.Controls.MetroTextBox txtToDate;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Timer tmr3B;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmigodata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNonAmigodata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatching;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTimeID;
    }
}