namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class frmCompanyCodeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyCodeList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pTitle = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.txtCompanyNoBox = new System.Windows.Forms.TextBox();
            this.lblCompanyNoBox = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboLimit = new System.Windows.Forms.ComboBox();
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblClear = new System.Windows.Forms.Label();
            this.displayItemLabel1 = new AmigoPaperWorkProcessSystem.UserControls.DisplayItemLabel();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOMPANY_NO_BOX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUTO_INDEX_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCOMPANY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPASSWORD_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPASSWORD_SET_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPASSWORD_EXPIRATION_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEMAIL_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEMAIL_SEND_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLOGIN_FAIL_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSESSION_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLAST_ACCESS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLAST_FAIL_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGD_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDISABLED_FLG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUPDATED_AT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUPDATED_BY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUPDATE_MESSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSOCIOS_USER_FLG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopyCompanyNoBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOMPANY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOMPANY_BOX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROW_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATED_AT_RAW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(16, 11);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(98, 21);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "XXXXXXXX";
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 50);
            this.pTitle.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 64);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(130, 64);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 30);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "修正";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(242, 64);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 30);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "行挿入";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(355, 64);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 30);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "BOX行増成";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 64);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(578, 64);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(688, 64);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "更新";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(799, 64);
            this.btnGeneratePassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(114, 30);
            this.btnGeneratePassword.TabIndex = 9;
            this.btnGeneratePassword.Text = "パスワード自動設定";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.BtnGeneratePassword_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(924, 64);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(100, 30);
            this.btnSendMail.TabIndex = 10;
            this.btnSendMail.Text = "メール送信";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.BtnSendMail_Click);
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Location = new System.Drawing.Point(129, 114);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.Size = new System.Drawing.Size(120, 21);
            this.txtCompanyNoBox.TabIndex = 12;
            // 
            // lblCompanyNoBox
            // 
            this.lblCompanyNoBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompanyNoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompanyNoBox.Location = new System.Drawing.Point(18, 114);
            this.lblCompanyNoBox.Name = "lblCompanyNoBox";
            this.lblCompanyNoBox.Size = new System.Drawing.Size(112, 21);
            this.lblCompanyNoBox.TabIndex = 12;
            this.lblCompanyNoBox.Text = "会社番号＋BOX";
            this.lblCompanyNoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompanyName.Location = new System.Drawing.Point(263, 114);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(77, 21);
            this.lblCompanyName.TabIndex = 15;
            this.lblCompanyName.Text = "会社名";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(339, 114);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(156, 21);
            this.txtCompanyName.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmail.Location = new System.Drawing.Point(512, 114);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(77, 21);
            this.lblEmail.TabIndex = 17;
            this.lblEmail.Text = "メールアドレス";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(588, 114);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 21);
            this.txtEmail.TabIndex = 16;
            // 
            // cboLimit
            // 
            this.cboLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimit.FormattingEnabled = true;
            this.cboLimit.Location = new System.Drawing.Point(94, 156);
            this.cboLimit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLimit.Name = "cboLimit";
            this.cboLimit.Size = new System.Drawing.Size(155, 22);
            this.cboLimit.TabIndex = 20;
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
            this.panel1.Location = new System.Drawing.Point(16, 196);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 34);
            this.panel1.TabIndex = 21;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(3, 11);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(0, 14);
            this.lblTotalRecords.TabIndex = 36;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheck.BackgroundImage")));
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Location = new System.Drawing.Point(822, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(30, 28);
            this.btnCheck.TabIndex = 32;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnCheck.BackgroundImage")));
            this.btnUnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUnCheck.FlatAppearance.BorderSize = 0;
            this.btnUnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnCheck.Location = new System.Drawing.Point(859, 3);
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.Size = new System.Drawing.Size(30, 28);
            this.btnUnCheck.TabIndex = 33;
            this.btnUnCheck.UseVisualStyleBackColor = true;
            this.btnUnCheck.Click += new System.EventHandler(this.BtnUnCheck_Click);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(1102, 10);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(14, 14);
            this.lblTotalPages.TabIndex = 31;
            this.lblTotalPages.Text = "0";
            // 
            // lblcurrentPage
            // 
            this.lblcurrentPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblcurrentPage.AutoSize = true;
            this.lblcurrentPage.Location = new System.Drawing.Point(1013, 10);
            this.lblcurrentPage.Name = "lblcurrentPage";
            this.lblcurrentPage.Size = new System.Drawing.Size(14, 14);
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
            this.btnLast.Location = new System.Drawing.Point(1197, 3);
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
            this.label6.Location = new System.Drawing.Point(1061, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 14);
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
            this.btnNext.Location = new System.Drawing.Point(1155, 3);
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
            this.btnFirst.Location = new System.Drawing.Point(908, 3);
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
            this.btnPrev.Location = new System.Drawing.Point(950, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 28);
            this.btnPrev.TabIndex = 27;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
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
            this.colCK,
            this.colMK,
            this.colCOMPANY_NO_BOX,
            this.colAUTO_INDEX_ID,
            this.colCOMPANY_NAME,
            this.colPASSWORD_,
            this.colPASSWORD_SET_DATE,
            this.colPASSWORD_EXPIRATION_DATE,
            this.colEMAIL_ADDRESS,
            this.colEMAIL_SEND_DATE,
            this.colLOGIN_FAIL_COUNT,
            this.colSESSION_ID,
            this.colLAST_ACCESS_DATE,
            this.colLAST_FAIL_DATE,
            this.colGD_CODE,
            this.colDISABLED_FLG,
            this.colMEMO,
            this.colUPDATED_AT,
            this.colUPDATED_BY,
            this.colUPDATE_MESSAGE,
            this.colSOCIOS_USER_FLG,
            this.colCopyCompanyNoBox,
            this.colCOMPANY_NO,
            this.colCOMPANY_BOX,
            this.ROW_ID,
            this.UPDATED_AT_RAW});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(16, 234);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(1250, 353);
            this.dgvList.TabIndex = 22;
            this.dgvList.TabStop = false;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvList_CellValueChanged);
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvList_DataError);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClear.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblClear.Location = new System.Drawing.Point(259, 160);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(82, 14);
            this.lblClear.TabIndex = 23;
            this.lblClear.Text = "検索条件のクリア";
            this.lblClear.Click += new System.EventHandler(this.LblClear_Click);
            // 
            // displayItemLabel1
            // 
            this.displayItemLabel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.displayItemLabel1.LabelText = " 表示件数";
            this.displayItemLabel1.Location = new System.Drawing.Point(18, 156);
            this.displayItemLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.displayItemLabel1.Name = "displayItemLabel1";
            this.displayItemLabel1.Size = new System.Drawing.Size(77, 22);
            this.displayItemLabel1.TabIndex = 24;
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "NO";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNo.Frozen = true;
            this.colNo.HeaderText = "NO";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCK
            // 
            this.colCK.DataPropertyName = "CK";
            this.colCK.FalseValue = " ";
            this.colCK.Frozen = true;
            this.colCK.HeaderText = "CK";
            this.colCK.Name = "colCK";
            this.colCK.TrueValue = "True";
            // 
            // colMK
            // 
            this.colMK.DataPropertyName = "MK";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMK.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMK.Frozen = true;
            this.colMK.HeaderText = "MK";
            this.colMK.Name = "colMK";
            this.colMK.ReadOnly = true;
            this.colMK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCOMPANY_NO_BOX
            // 
            this.colCOMPANY_NO_BOX.DataPropertyName = "COMPANY_NO_BOX";
            this.colCOMPANY_NO_BOX.Frozen = true;
            this.colCOMPANY_NO_BOX.HeaderText = "会社番号＋BOX";
            this.colCOMPANY_NO_BOX.Name = "colCOMPANY_NO_BOX";
            this.colCOMPANY_NO_BOX.ReadOnly = true;
            this.colCOMPANY_NO_BOX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCOMPANY_NO_BOX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCOMPANY_NO_BOX.Width = 110;
            // 
            // colAUTO_INDEX_ID
            // 
            this.colAUTO_INDEX_ID.DataPropertyName = "AUTO_INDEX_ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAUTO_INDEX_ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAUTO_INDEX_ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAUTO_INDEX_ID.Frozen = true;
            this.colAUTO_INDEX_ID.HeaderText = "種別";
            this.colAUTO_INDEX_ID.Items.AddRange(new object[] {
            "サプライヤ",
            "要元",
            "socios"});
            this.colAUTO_INDEX_ID.Name = "colAUTO_INDEX_ID";
            this.colAUTO_INDEX_ID.ReadOnly = true;
            this.colAUTO_INDEX_ID.Width = 70;
            // 
            // colCOMPANY_NAME
            // 
            this.colCOMPANY_NAME.DataPropertyName = "COMPANY_NAME";
            this.colCOMPANY_NAME.Frozen = true;
            this.colCOMPANY_NAME.HeaderText = "会社名";
            this.colCOMPANY_NAME.Name = "colCOMPANY_NAME";
            this.colCOMPANY_NAME.ReadOnly = true;
            this.colCOMPANY_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCOMPANY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCOMPANY_NAME.Width = 150;
            // 
            // colPASSWORD_
            // 
            this.colPASSWORD_.DataPropertyName = "PASSWORD";
            this.colPASSWORD_.HeaderText = "パスワード";
            this.colPASSWORD_.Name = "colPASSWORD_";
            this.colPASSWORD_.ReadOnly = true;
            this.colPASSWORD_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPASSWORD_SET_DATE
            // 
            this.colPASSWORD_SET_DATE.DataPropertyName = "PASSWORD_SET_DATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPASSWORD_SET_DATE.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPASSWORD_SET_DATE.HeaderText = "設定日時";
            this.colPASSWORD_SET_DATE.Name = "colPASSWORD_SET_DATE";
            this.colPASSWORD_SET_DATE.ReadOnly = true;
            this.colPASSWORD_SET_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPASSWORD_SET_DATE.Width = 145;
            // 
            // colPASSWORD_EXPIRATION_DATE
            // 
            this.colPASSWORD_EXPIRATION_DATE.DataPropertyName = "PASSWORD_EXPIRATION_DATE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPASSWORD_EXPIRATION_DATE.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPASSWORD_EXPIRATION_DATE.HeaderText = "有効期限";
            this.colPASSWORD_EXPIRATION_DATE.Name = "colPASSWORD_EXPIRATION_DATE";
            this.colPASSWORD_EXPIRATION_DATE.ReadOnly = true;
            this.colPASSWORD_EXPIRATION_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPASSWORD_EXPIRATION_DATE.Width = 145;
            // 
            // colEMAIL_ADDRESS
            // 
            this.colEMAIL_ADDRESS.DataPropertyName = "EMAIL_ADDRESS";
            this.colEMAIL_ADDRESS.HeaderText = "メールアドレス";
            this.colEMAIL_ADDRESS.Name = "colEMAIL_ADDRESS";
            this.colEMAIL_ADDRESS.ReadOnly = true;
            this.colEMAIL_ADDRESS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEMAIL_ADDRESS.Width = 200;
            // 
            // colEMAIL_SEND_DATE
            // 
            this.colEMAIL_SEND_DATE.DataPropertyName = "EMAIL_SEND_DATE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEMAIL_SEND_DATE.DefaultCellStyle = dataGridViewCellStyle6;
            this.colEMAIL_SEND_DATE.HeaderText = "メール送信日時";
            this.colEMAIL_SEND_DATE.Name = "colEMAIL_SEND_DATE";
            this.colEMAIL_SEND_DATE.ReadOnly = true;
            this.colEMAIL_SEND_DATE.Width = 145;
            // 
            // colLOGIN_FAIL_COUNT
            // 
            this.colLOGIN_FAIL_COUNT.DataPropertyName = "LOGIN_FAIL_COUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = null;
            this.colLOGIN_FAIL_COUNT.DefaultCellStyle = dataGridViewCellStyle7;
            this.colLOGIN_FAIL_COUNT.HeaderText = "失敗回数";
            this.colLOGIN_FAIL_COUNT.Name = "colLOGIN_FAIL_COUNT";
            this.colLOGIN_FAIL_COUNT.ReadOnly = true;
            this.colLOGIN_FAIL_COUNT.Width = 75;
            // 
            // colSESSION_ID
            // 
            this.colSESSION_ID.DataPropertyName = "SESSION_ID";
            this.colSESSION_ID.HeaderText = " セッションID";
            this.colSESSION_ID.Name = "colSESSION_ID";
            this.colSESSION_ID.ReadOnly = true;
            // 
            // colLAST_ACCESS_DATE
            // 
            this.colLAST_ACCESS_DATE.DataPropertyName = "LAST_ACCESS_DATE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLAST_ACCESS_DATE.DefaultCellStyle = dataGridViewCellStyle8;
            this.colLAST_ACCESS_DATE.HeaderText = "最終アクセス日時";
            this.colLAST_ACCESS_DATE.Name = "colLAST_ACCESS_DATE";
            this.colLAST_ACCESS_DATE.ReadOnly = true;
            this.colLAST_ACCESS_DATE.Width = 145;
            // 
            // colLAST_FAIL_DATE
            // 
            this.colLAST_FAIL_DATE.DataPropertyName = "LAST_FAIL_DATE";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = null;
            this.colLAST_FAIL_DATE.DefaultCellStyle = dataGridViewCellStyle9;
            this.colLAST_FAIL_DATE.HeaderText = "最終ログイン失敗日時";
            this.colLAST_FAIL_DATE.Name = "colLAST_FAIL_DATE";
            this.colLAST_FAIL_DATE.ReadOnly = true;
            this.colLAST_FAIL_DATE.Width = 145;
            // 
            // colGD_CODE
            // 
            this.colGD_CODE.DataPropertyName = "GD_CODE";
            this.colGD_CODE.HeaderText = "GDコード";
            this.colGD_CODE.Name = "colGD_CODE";
            this.colGD_CODE.ReadOnly = true;
            this.colGD_CODE.Width = 80;
            // 
            // colDISABLED_FLG
            // 
            this.colDISABLED_FLG.DataPropertyName = "DISABLED_FLG";
            this.colDISABLED_FLG.FalseValue = " ";
            this.colDISABLED_FLG.HeaderText = "休止";
            this.colDISABLED_FLG.Name = "colDISABLED_FLG";
            this.colDISABLED_FLG.ReadOnly = true;
            this.colDISABLED_FLG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDISABLED_FLG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDISABLED_FLG.TrueValue = "*";
            // 
            // colMEMO
            // 
            this.colMEMO.DataPropertyName = "MEMO";
            this.colMEMO.HeaderText = "備考";
            this.colMEMO.Name = "colMEMO";
            this.colMEMO.ReadOnly = true;
            this.colMEMO.Width = 200;
            // 
            // colUPDATED_AT
            // 
            this.colUPDATED_AT.DataPropertyName = "UPDATED_AT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "MM/dd/yyyy HH:mm:ss";
            dataGridViewCellStyle10.NullValue = null;
            this.colUPDATED_AT.DefaultCellStyle = dataGridViewCellStyle10;
            this.colUPDATED_AT.HeaderText = "更新日時";
            this.colUPDATED_AT.Name = "colUPDATED_AT";
            this.colUPDATED_AT.ReadOnly = true;
            this.colUPDATED_AT.Width = 145;
            // 
            // colUPDATED_BY
            // 
            this.colUPDATED_BY.DataPropertyName = "UPDATED_BY";
            this.colUPDATED_BY.HeaderText = "更新ユーザーID";
            this.colUPDATED_BY.Name = "colUPDATED_BY";
            this.colUPDATED_BY.ReadOnly = true;
            this.colUPDATED_BY.Width = 120;
            // 
            // colUPDATE_MESSAGE
            // 
            this.colUPDATE_MESSAGE.DataPropertyName = "UPDATE_MESSAGE";
            this.colUPDATE_MESSAGE.HeaderText = "更新メッセージ";
            this.colUPDATE_MESSAGE.Name = "colUPDATE_MESSAGE";
            this.colUPDATE_MESSAGE.ReadOnly = true;
            this.colUPDATE_MESSAGE.Width = 350;
            // 
            // colSOCIOS_USER_FLG
            // 
            this.colSOCIOS_USER_FLG.DataPropertyName = "SOCIOS_USER_FLG";
            this.colSOCIOS_USER_FLG.HeaderText = "SOCIOS_USER_FLG";
            this.colSOCIOS_USER_FLG.Name = "colSOCIOS_USER_FLG";
            this.colSOCIOS_USER_FLG.ReadOnly = true;
            this.colSOCIOS_USER_FLG.Visible = false;
            // 
            // colCopyCompanyNoBox
            // 
            this.colCopyCompanyNoBox.DataPropertyName = "COPY_COMPANY_NO_BOX";
            this.colCopyCompanyNoBox.HeaderText = "コピー元会社番号+BOX";
            this.colCopyCompanyNoBox.Name = "colCopyCompanyNoBox";
            this.colCopyCompanyNoBox.ReadOnly = true;
            this.colCopyCompanyNoBox.Visible = false;
            // 
            // colCOMPANY_NO
            // 
            this.colCOMPANY_NO.DataPropertyName = "COMPANY_NO";
            this.colCOMPANY_NO.HeaderText = "COMPANY_NO";
            this.colCOMPANY_NO.Name = "colCOMPANY_NO";
            this.colCOMPANY_NO.ReadOnly = true;
            this.colCOMPANY_NO.Visible = false;
            // 
            // colCOMPANY_BOX
            // 
            this.colCOMPANY_BOX.DataPropertyName = "COMPANY_BOX";
            this.colCOMPANY_BOX.HeaderText = "COMPANY_BOX";
            this.colCOMPANY_BOX.Name = "colCOMPANY_BOX";
            this.colCOMPANY_BOX.Visible = false;
            // 
            // ROW_ID
            // 
            this.ROW_ID.DataPropertyName = "ROW_ID";
            this.ROW_ID.HeaderText = "ROW_ID";
            this.ROW_ID.Name = "ROW_ID";
            this.ROW_ID.Visible = false;
            // 
            // UPDATED_AT_RAW
            // 
            this.UPDATED_AT_RAW.DataPropertyName = "UPDATED_AT_RAW";
            this.UPDATED_AT_RAW.HeaderText = "UPDATED_AT_RAW";
            this.UPDATED_AT_RAW.Name = "UPDATED_AT_RAW";
            this.UPDATED_AT_RAW.Visible = false;
            // 
            // frmCompanyCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.displayItemLabel1);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboLimit);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompanyNoBox);
            this.Controls.Add(this.txtCompanyNoBox);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1300, 640);
            this.Name = "frmCompanyCodeList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            this.SizeChanged += new System.EventHandler(this.FrmCustomerList_SizeChanged);
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.TextBox txtCompanyNoBox;
        private System.Windows.Forms.Label lblCompanyNoBox;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboLimit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblcurrentPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUnCheck;
        private System.Windows.Forms.Label lblTotalRecords;
        private UserControls.DisplayItemLabel displayItemLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NO_BOX;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAUTO_INDEX_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPASSWORD_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPASSWORD_SET_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPASSWORD_EXPIRATION_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEMAIL_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEMAIL_SEND_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLOGIN_FAIL_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSESSION_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLAST_ACCESS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLAST_FAIL_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGD_CODE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDISABLED_FLG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUPDATED_AT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUPDATED_BY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUPDATE_MESSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSOCIOS_USER_FLG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopyCompanyNoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOMPANY_BOX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROW_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDATED_AT_RAW;
    }
}