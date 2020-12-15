namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frmInvoiceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUnCheck = new System.Windows.Forms.Button();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblcurrentPage = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnCreateCSVFile = new System.Windows.Forms.Button();
            this.btnCreateInvoiceData = new System.Windows.Forms.Button();
            this.btnDifferent = new System.Windows.Forms.Button();
            this.cboLimit = new System.Windows.Forms.ComboBox();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtBilling_Date = new System.Windows.Forms.TextBox();
            this.lblDate = new AmigoPaperWorkProcessSystem.UserControls.DisplayItemLabel();
            this.displayItemLabel1 = new AmigoPaperWorkProcessSystem.UserControls.DisplayItemLabel();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coLCOMPANY_NO_BOX = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCOMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coLSUPPLIER_INITIAL_EXPENSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSUPPLIER_MONTHLY_USAGE_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBROWSING_INITIAL_EXPENSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYEARLY_USAGE_FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coLPOSTAL_MAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWEB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coLEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCREDIT_CARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOTHER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key_source_Monthly_usage_fee_REQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Initial_expense_REQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Monthly_usage_fee_REQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Production_information_browsing_Initial_expense_REQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_production_information_Annual_usage_fee_REQ_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblTotalRecords);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.btnUnCheck);
            this.panel1.Controls.Add(this.lblTotalPages);
            this.panel1.Controls.Add(this.lblcurrentPage);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Location = new System.Drawing.Point(16, 204);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 34);
            this.panel1.TabIndex = 124;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(3, 11);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(0, 18);
            this.lblTotalRecords.TabIndex = 36;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheck.BackgroundImage")));
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Location = new System.Drawing.Point(819, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(30, 28);
            this.btnCheck.TabIndex = 33;
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnCheck.BackgroundImage")));
            this.btnUnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUnCheck.FlatAppearance.BorderSize = 0;
            this.btnUnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnCheck.Location = new System.Drawing.Point(857, 3);
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.Size = new System.Drawing.Size(30, 28);
            this.btnUnCheck.TabIndex = 32;
            this.btnUnCheck.UseVisualStyleBackColor = true;
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(1092, 11);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(17, 18);
            this.lblTotalPages.TabIndex = 31;
            this.lblTotalPages.Text = "0";
            // 
            // lblcurrentPage
            // 
            this.lblcurrentPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblcurrentPage.AutoSize = true;
            this.lblcurrentPage.Location = new System.Drawing.Point(997, 11);
            this.lblcurrentPage.Name = "lblcurrentPage";
            this.lblcurrentPage.Size = new System.Drawing.Size(17, 18);
            this.lblcurrentPage.TabIndex = 30;
            this.lblcurrentPage.Text = "0";
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLast.BackgroundImage = global::AmigoPaperWorkProcessSystem.Properties.Resources.next_icon;
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(1190, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(35, 28);
            this.btnLast.TabIndex = 28;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1044, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Of";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.BackgroundImage = global::AmigoPaperWorkProcessSystem.Properties.Resources.right_arrow;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(1148, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 28);
            this.btnNext.TabIndex = 26;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFirst.BackgroundImage = global::AmigoPaperWorkProcessSystem.Properties.Resources.previous_icon;
            this.btnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(906, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(35, 28);
            this.btnFirst.TabIndex = 29;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrev.BackgroundImage = global::AmigoPaperWorkProcessSystem.Properties.Resources.left_arrow;
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(948, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 28);
            this.btnPrev.TabIndex = 27;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // btnCreateCSVFile
            // 
            this.btnCreateCSVFile.Location = new System.Drawing.Point(381, 81);
            this.btnCreateCSVFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreateCSVFile.Name = "btnCreateCSVFile";
            this.btnCreateCSVFile.Size = new System.Drawing.Size(119, 30);
            this.btnCreateCSVFile.TabIndex = 117;
            this.btnCreateCSVFile.Text = "CSVファイル作成";
            this.btnCreateCSVFile.UseVisualStyleBackColor = true;
            this.btnCreateCSVFile.Click += new System.EventHandler(this.BtnCreateCSVFile_Click);
            // 
            // btnCreateInvoiceData
            // 
            this.btnCreateInvoiceData.Location = new System.Drawing.Point(240, 81);
            this.btnCreateInvoiceData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreateInvoiceData.Name = "btnCreateInvoiceData";
            this.btnCreateInvoiceData.Size = new System.Drawing.Size(129, 30);
            this.btnCreateInvoiceData.TabIndex = 116;
            this.btnCreateInvoiceData.Text = "請求データ作成";
            this.btnCreateInvoiceData.UseVisualStyleBackColor = true;
            this.btnCreateInvoiceData.Click += new System.EventHandler(this.BtnCreateInvoiceData_Click);
            // 
            // btnDifferent
            // 
            this.btnDifferent.Location = new System.Drawing.Point(129, 81);
            this.btnDifferent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDifferent.Name = "btnDifferent";
            this.btnDifferent.Size = new System.Drawing.Size(100, 30);
            this.btnDifferent.TabIndex = 115;
            this.btnDifferent.Text = "差異";
            this.btnDifferent.UseVisualStyleBackColor = true;
            this.btnDifferent.Click += new System.EventHandler(this.BtnDifferent_Click);
            // 
            // cboLimit
            // 
            this.cboLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimit.FormattingEnabled = true;
            this.cboLimit.Location = new System.Drawing.Point(92, 166);
            this.cboLimit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboLimit.Name = "cboLimit";
            this.cboLimit.Size = new System.Drawing.Size(139, 26);
            this.cboLimit.TabIndex = 121;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1279, 50);
            this.pTitle.TabIndex = 113;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(12, 9);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(160, 27);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Jimugo - Menu";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(16, 81);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.coLCOMPANY_NO_BOX,
            this.colCOMPANY_NAME,
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE,
            this.coLSUPPLIER_INITIAL_EXPENSE,
            this.colSUPPLIER_MONTHLY_USAGE_FEE,
            this.colBROWSING_INITIAL_EXPENSE,
            this.colYEARLY_USAGE_FEE,
            this.coLPOSTAL_MAIL,
            this.colWEB,
            this.coLEmail,
            this.colCREDIT_CARD,
            this.colOTHER,
            this.Key_source_Monthly_usage_fee_REQ_SEQ,
            this.Supplier_Initial_expense_REQ_SEQ,
            this.Supplier_Monthly_usage_fee_REQ_SEQ,
            this.Production_information_browsing_Initial_expense_REQ_SEQ,
            this.View_production_information_Annual_usage_fee_REQ_SEQ});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(16, 242);
            this.dgvList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(1243, 398);
            this.dgvList.TabIndex = 122;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvList_CellContentClick);
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // txtBilling_Date
            // 
            this.txtBilling_Date.Location = new System.Drawing.Point(102, 126);
            this.txtBilling_Date.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBilling_Date.Name = "txtBilling_Date";
            this.txtBilling_Date.Size = new System.Drawing.Size(139, 25);
            this.txtBilling_Date.TabIndex = 125;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDate.LabelText = "請求年月";
            this.lblDate.Location = new System.Drawing.Point(18, 126);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(84, 22);
            this.lblDate.TabIndex = 130;
            // 
            // displayItemLabel1
            // 
            this.displayItemLabel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.displayItemLabel1.LabelText = "表示件数";
            this.displayItemLabel1.Location = new System.Drawing.Point(17, 166);
            this.displayItemLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.displayItemLabel1.Name = "displayItemLabel1";
            this.displayItemLabel1.Size = new System.Drawing.Size(75, 22);
            this.displayItemLabel1.TabIndex = 129;
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "No";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle14;
            this.colNo.Frozen = true;
            this.colNo.HeaderText = "NO";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // coLCOMPANY_NO_BOX
            // 
            this.coLCOMPANY_NO_BOX.DataPropertyName = "COMPANY_NO_BOX";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.coLCOMPANY_NO_BOX.DefaultCellStyle = dataGridViewCellStyle15;
            this.coLCOMPANY_NO_BOX.HeaderText = "会社番号+BOX";
            this.coLCOMPANY_NO_BOX.Name = "coLCOMPANY_NO_BOX";
            this.coLCOMPANY_NO_BOX.ReadOnly = true;
            this.coLCOMPANY_NO_BOX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coLCOMPANY_NO_BOX.Width = 170;
            // 
            // colCOMPANY_NAME
            // 
            this.colCOMPANY_NAME.DataPropertyName = "COMPANY_NAME";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCOMPANY_NAME.DefaultCellStyle = dataGridViewCellStyle16;
            this.colCOMPANY_NAME.HeaderText = "請求金額計";
            this.colCOMPANY_NAME.Name = "colCOMPANY_NAME";
            this.colCOMPANY_NAME.ReadOnly = true;
            this.colCOMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCOMPANY_NAME.Width = 200;
            // 
            // colKEY_SOURCE_MONTHLY_USAGE_FEE
            // 
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.DataPropertyName = "KEY_SOURCE_MONTHLY_USAGE_FEE";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.DefaultCellStyle = dataGridViewCellStyle17;
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.HeaderText = "月額利用料";
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.Name = "colKEY_SOURCE_MONTHLY_USAGE_FEE";
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.ReadOnly = true;
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colKEY_SOURCE_MONTHLY_USAGE_FEE.Width = 120;
            // 
            // coLSUPPLIER_INITIAL_EXPENSE
            // 
            this.coLSUPPLIER_INITIAL_EXPENSE.DataPropertyName = "SUPPLIER_INITIAL_EXPENSE";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            this.coLSUPPLIER_INITIAL_EXPENSE.DefaultCellStyle = dataGridViewCellStyle18;
            this.coLSUPPLIER_INITIAL_EXPENSE.HeaderText = "初期費用";
            this.coLSUPPLIER_INITIAL_EXPENSE.Name = "coLSUPPLIER_INITIAL_EXPENSE";
            this.coLSUPPLIER_INITIAL_EXPENSE.ReadOnly = true;
            this.coLSUPPLIER_INITIAL_EXPENSE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coLSUPPLIER_INITIAL_EXPENSE.Width = 120;
            // 
            // colSUPPLIER_MONTHLY_USAGE_FEE
            // 
            this.colSUPPLIER_MONTHLY_USAGE_FEE.DataPropertyName = "SUPPLIER_MONTHLY_USAGE_FEE";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            this.colSUPPLIER_MONTHLY_USAGE_FEE.DefaultCellStyle = dataGridViewCellStyle19;
            this.colSUPPLIER_MONTHLY_USAGE_FEE.HeaderText = "月額利用料";
            this.colSUPPLIER_MONTHLY_USAGE_FEE.Name = "colSUPPLIER_MONTHLY_USAGE_FEE";
            this.colSUPPLIER_MONTHLY_USAGE_FEE.ReadOnly = true;
            this.colSUPPLIER_MONTHLY_USAGE_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSUPPLIER_MONTHLY_USAGE_FEE.Width = 120;
            // 
            // colBROWSING_INITIAL_EXPENSE
            // 
            this.colBROWSING_INITIAL_EXPENSE.DataPropertyName = "BROWSING_INITIAL_EXPENSE";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            this.colBROWSING_INITIAL_EXPENSE.DefaultCellStyle = dataGridViewCellStyle20;
            this.colBROWSING_INITIAL_EXPENSE.HeaderText = "初期費用";
            this.colBROWSING_INITIAL_EXPENSE.Name = "colBROWSING_INITIAL_EXPENSE";
            this.colBROWSING_INITIAL_EXPENSE.ReadOnly = true;
            this.colBROWSING_INITIAL_EXPENSE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBROWSING_INITIAL_EXPENSE.Width = 120;
            // 
            // colYEARLY_USAGE_FEE
            // 
            this.colYEARLY_USAGE_FEE.DataPropertyName = "YEARLY_USAGE_FEE";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            this.colYEARLY_USAGE_FEE.DefaultCellStyle = dataGridViewCellStyle21;
            this.colYEARLY_USAGE_FEE.HeaderText = "年額利用料";
            this.colYEARLY_USAGE_FEE.Name = "colYEARLY_USAGE_FEE";
            this.colYEARLY_USAGE_FEE.ReadOnly = true;
            this.colYEARLY_USAGE_FEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colYEARLY_USAGE_FEE.Width = 120;
            // 
            // coLPOSTAL_MAIL
            // 
            this.coLPOSTAL_MAIL.DataPropertyName = "POSTAL_MAIL";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.coLPOSTAL_MAIL.DefaultCellStyle = dataGridViewCellStyle22;
            this.coLPOSTAL_MAIL.HeaderText = "郵送";
            this.coLPOSTAL_MAIL.Name = "coLPOSTAL_MAIL";
            this.coLPOSTAL_MAIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colWEB
            // 
            this.colWEB.DataPropertyName = "WEB";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colWEB.DefaultCellStyle = dataGridViewCellStyle23;
            this.colWEB.HeaderText = "WEB";
            this.colWEB.Name = "colWEB";
            this.colWEB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // coLEmail
            // 
            this.coLEmail.DataPropertyName = "Email";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.coLEmail.DefaultCellStyle = dataGridViewCellStyle24;
            this.coLEmail.HeaderText = "Email";
            this.coLEmail.Name = "coLEmail";
            // 
            // colCREDIT_CARD
            // 
            this.colCREDIT_CARD.DataPropertyName = "CREDIT_CARD";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCREDIT_CARD.DefaultCellStyle = dataGridViewCellStyle25;
            this.colCREDIT_CARD.HeaderText = "クレカ";
            this.colCREDIT_CARD.Name = "colCREDIT_CARD";
            // 
            // colOTHER
            // 
            this.colOTHER.DataPropertyName = "OTHER";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOTHER.DefaultCellStyle = dataGridViewCellStyle26;
            this.colOTHER.HeaderText = "その他";
            this.colOTHER.Name = "colOTHER";
            // 
            // Key_source_Monthly_usage_fee_REQ_SEQ
            // 
            this.Key_source_Monthly_usage_fee_REQ_SEQ.DataPropertyName = "Key_source_Monthly_usage_fee_REQ_SEQ";
            this.Key_source_Monthly_usage_fee_REQ_SEQ.HeaderText = "Key_source_Monthly_usage_fee_REQ_SEQ";
            this.Key_source_Monthly_usage_fee_REQ_SEQ.Name = "Key_source_Monthly_usage_fee_REQ_SEQ";
            this.Key_source_Monthly_usage_fee_REQ_SEQ.Visible = false;
            // 
            // Supplier_Initial_expense_REQ_SEQ
            // 
            this.Supplier_Initial_expense_REQ_SEQ.DataPropertyName = "Supplier_Initial_expense_REQ_SEQ";
            this.Supplier_Initial_expense_REQ_SEQ.HeaderText = "Supplier_Initial_expense_REQ_SEQ";
            this.Supplier_Initial_expense_REQ_SEQ.Name = "Supplier_Initial_expense_REQ_SEQ";
            this.Supplier_Initial_expense_REQ_SEQ.Visible = false;
            // 
            // Supplier_Monthly_usage_fee_REQ_SEQ
            // 
            this.Supplier_Monthly_usage_fee_REQ_SEQ.DataPropertyName = "Supplier_Monthly_usage_fee_REQ_SEQ";
            this.Supplier_Monthly_usage_fee_REQ_SEQ.HeaderText = "Supplier_Monthly_usage_fee_REQ_SEQ";
            this.Supplier_Monthly_usage_fee_REQ_SEQ.Name = "Supplier_Monthly_usage_fee_REQ_SEQ";
            this.Supplier_Monthly_usage_fee_REQ_SEQ.Visible = false;
            // 
            // Production_information_browsing_Initial_expense_REQ_SEQ
            // 
            this.Production_information_browsing_Initial_expense_REQ_SEQ.DataPropertyName = "Production_information_browsing_Initial_expense_REQ_SEQ";
            this.Production_information_browsing_Initial_expense_REQ_SEQ.HeaderText = "Production_information_browsing_Initial_expense_REQ_SEQ";
            this.Production_information_browsing_Initial_expense_REQ_SEQ.Name = "Production_information_browsing_Initial_expense_REQ_SEQ";
            this.Production_information_browsing_Initial_expense_REQ_SEQ.Visible = false;
            // 
            // View_production_information_Annual_usage_fee_REQ_SEQ
            // 
            this.View_production_information_Annual_usage_fee_REQ_SEQ.DataPropertyName = "View_production_information_Annual_usage_fee_REQ_SEQ";
            this.View_production_information_Annual_usage_fee_REQ_SEQ.HeaderText = "View_production_information_Annual_usage_fee_REQ_SEQ";
            this.View_production_information_Annual_usage_fee_REQ_SEQ.Name = "View_production_information_Annual_usage_fee_REQ_SEQ";
            this.View_production_information_Annual_usage_fee_REQ_SEQ.Visible = false;
            // 
            // frmInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 652);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCreateCSVFile);
            this.Controls.Add(this.btnCreateInvoiceData);
            this.Controls.Add(this.btnDifferent);
            this.Controls.Add(this.displayItemLabel1);
            this.Controls.Add(this.cboLimit);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtBilling_Date);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInvoiceList";
            this.Text = "frmInvoiceList";
            this.Load += new System.EventHandler(this.FrmInvoiceList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUnCheck;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblcurrentPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnCreateCSVFile;
        private System.Windows.Forms.Button btnCreateInvoiceData;
        private System.Windows.Forms.Button btnDifferent;
        private UserControls.DisplayItemLabel displayItemLabel1;
        private System.Windows.Forms.ComboBox cboLimit;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtBilling_Date;
        private UserControls.DisplayItemLabel lblDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewLinkColumn coLCOMPANY_NO_BOX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKEY_SOURCE_MONTHLY_USAGE_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn coLSUPPLIER_INITIAL_EXPENSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSUPPLIER_MONTHLY_USAGE_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBROWSING_INITIAL_EXPENSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYEARLY_USAGE_FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn coLPOSTAL_MAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWEB;
        private System.Windows.Forms.DataGridViewTextBoxColumn coLEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCREDIT_CARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOTHER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key_source_Monthly_usage_fee_REQ_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Initial_expense_REQ_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Monthly_usage_fee_REQ_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Production_information_browsing_Initial_expense_REQ_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn View_production_information_Annual_usage_fee_REQ_SEQ;
    }
}