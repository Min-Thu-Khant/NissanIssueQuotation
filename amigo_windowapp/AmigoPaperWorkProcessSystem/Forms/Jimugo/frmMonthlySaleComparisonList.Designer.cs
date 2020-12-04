
namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class frmMonthlySaleComparisonList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFirst = new System.Windows.Forms.Button();
            this.displayItemLabel1 = new AmigoPaperWorkProcessSystem.UserControls.DisplayItemLabel();
            this.lblClear = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblcurrentPage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.cboLimit = new System.Windows.Forms.ComboBox();
            this.lblCompanyNoBox = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lbldifference = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATE_CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIFF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERVERRIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BROWSERAUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BROWSER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_AMIGO_CAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLAN_AMIGO_BIZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_BOX_SERVER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_BOX_BROWSER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_FLAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_CLIENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_BASIC_SERVICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_ADD_SERVICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
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
            // displayItemLabel1
            // 
            this.displayItemLabel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.displayItemLabel1.LabelText = " 表示件数";
            this.displayItemLabel1.Location = new System.Drawing.Point(18, 185);
            this.displayItemLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.displayItemLabel1.Name = "displayItemLabel1";
            this.displayItemLabel1.Size = new System.Drawing.Size(77, 22);
            this.displayItemLabel1.TabIndex = 45;
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClear.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblClear.Location = new System.Drawing.Point(259, 189);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(127, 22);
            this.lblClear.TabIndex = 44;
            this.lblClear.Text = "検索条件のクリア";
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblTotalRecords);
            this.panel1.Controls.Add(this.lblTotalPages);
            this.panel1.Controls.Add(this.lblcurrentPage);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Location = new System.Drawing.Point(17, 234);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 34);
            this.panel1.TabIndex = 42;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(3, 11);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(0, 22);
            this.lblTotalRecords.TabIndex = 36;
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(1102, 10);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(21, 22);
            this.lblTotalPages.TabIndex = 31;
            this.lblTotalPages.Text = "0";
            // 
            // lblcurrentPage
            // 
            this.lblcurrentPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblcurrentPage.AutoSize = true;
            this.lblcurrentPage.Location = new System.Drawing.Point(1013, 10);
            this.lblcurrentPage.Name = "lblcurrentPage";
            this.lblcurrentPage.Size = new System.Drawing.Size(21, 22);
            this.lblcurrentPage.TabIndex = 30;
            this.lblcurrentPage.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1061, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 22);
            this.label6.TabIndex = 25;
            this.label6.Text = "Of";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(16, 11);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(159, 32);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "XXXXXXXX";
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
            this.No,
            this.Type,
            this.BILL_SUPPLIER_NAME,
            this.UPDATE_CONTENT,
            this.DIFF,
            this.Server,
            this.SERVERRIGHT,
            this.BROWSERAUTO,
            this.BROWSER,
            this.PRODUCT,
            this.PLAN_AMIGO_CAI,
            this.PLAN_AMIGO_BIZ,
            this.OP_BOX_SERVER,
            this.OP_BOX_BROWSER,
            this.OP_FLAT,
            this.OP_CLIENT,
            this.OP_BASIC_SERVICE,
            this.OP_ADD_SERVICE});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(17, 272);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 62;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(1250, 293);
            this.dgvList.TabIndex = 43;
            this.dgvList.TabStop = false;
            this.dgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvList_CellFormatting);
            this.dgvList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvList_CellPainting);
            // 
            // cboLimit
            // 
            this.cboLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimit.FormattingEnabled = true;
            this.cboLimit.Location = new System.Drawing.Point(94, 185);
            this.cboLimit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLimit.Name = "cboLimit";
            this.cboLimit.Size = new System.Drawing.Size(155, 30);
            this.cboLimit.TabIndex = 41;
            // 
            // lblCompanyNoBox
            // 
            this.lblCompanyNoBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompanyNoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompanyNoBox.Location = new System.Drawing.Point(18, 110);
            this.lblCompanyNoBox.Name = "lblCompanyNoBox";
            this.lblCompanyNoBox.Size = new System.Drawing.Size(112, 21);
            this.lblCompanyNoBox.TabIndex = 36;
            this.lblCompanyNoBox.Text = "締め年月";
            this.lblCompanyNoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(129, 110);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(80, 28);
            this.txtDate.TabIndex = 35;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(17, 68);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 50);
            this.pTitle.TabIndex = 25;
            // 
            // lbldifference
            // 
            this.lbldifference.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbldifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldifference.Location = new System.Drawing.Point(18, 145);
            this.lbldifference.Name = "lbldifference";
            this.lbldifference.Size = new System.Drawing.Size(231, 21);
            this.lbldifference.TabIndex = 46;
            this.lbldifference.Text = "Diffence";
            this.lbldifference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 8;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 40;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.Frozen = true;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 150;
            // 
            // BILL_SUPPLIER_NAME
            // 
            this.BILL_SUPPLIER_NAME.DataPropertyName = "BILL_SUPPLIER_NAME";
            this.BILL_SUPPLIER_NAME.Frozen = true;
            this.BILL_SUPPLIER_NAME.HeaderText = "Supplier name";
            this.BILL_SUPPLIER_NAME.MinimumWidth = 8;
            this.BILL_SUPPLIER_NAME.Name = "BILL_SUPPLIER_NAME";
            this.BILL_SUPPLIER_NAME.ReadOnly = true;
            this.BILL_SUPPLIER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BILL_SUPPLIER_NAME.Width = 250;
            // 
            // UPDATE_CONTENT
            // 
            this.UPDATE_CONTENT.DataPropertyName = "UPDATE_CONTENT";
            this.UPDATE_CONTENT.Frozen = true;
            this.UPDATE_CONTENT.HeaderText = "Contents";
            this.UPDATE_CONTENT.MinimumWidth = 8;
            this.UPDATE_CONTENT.Name = "UPDATE_CONTENT";
            this.UPDATE_CONTENT.ReadOnly = true;
            this.UPDATE_CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UPDATE_CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UPDATE_CONTENT.Width = 150;
            // 
            // DIFF
            // 
            this.DIFF.DataPropertyName = "DIFF";
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle64.Format = "N0";
            this.DIFF.DefaultCellStyle = dataGridViewCellStyle64;
            this.DIFF.Frozen = true;
            this.DIFF.HeaderText = "Difference";
            this.DIFF.MinimumWidth = 8;
            this.DIFF.Name = "DIFF";
            this.DIFF.ReadOnly = true;
            this.DIFF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DIFF.Width = 150;
            // 
            // Server
            // 
            this.Server.DataPropertyName = "SERVER";
            this.Server.HeaderText = "サーバー";
            this.Server.MinimumWidth = 8;
            this.Server.Name = "Server";
            this.Server.ReadOnly = true;
            this.Server.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Server.Width = 40;
            // 
            // SERVERRIGHT
            // 
            this.SERVERRIGHT.DataPropertyName = "SERVERRIGHT";
            this.SERVERRIGHT.HeaderText = "サーバーライト";
            this.SERVERRIGHT.MinimumWidth = 8;
            this.SERVERRIGHT.Name = "SERVERRIGHT";
            this.SERVERRIGHT.ReadOnly = true;
            this.SERVERRIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SERVERRIGHT.Width = 40;
            // 
            // BROWSERAUTO
            // 
            this.BROWSERAUTO.DataPropertyName = "BROWSERAUTO";
            this.BROWSERAUTO.HeaderText = "ブラウザ自動";
            this.BROWSERAUTO.MinimumWidth = 8;
            this.BROWSERAUTO.Name = "BROWSERAUTO";
            this.BROWSERAUTO.ReadOnly = true;
            this.BROWSERAUTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BROWSERAUTO.Width = 40;
            // 
            // BROWSER
            // 
            this.BROWSER.DataPropertyName = "BROWSER";
            this.BROWSER.HeaderText = "ブラウザ";
            this.BROWSER.MinimumWidth = 8;
            this.BROWSER.Name = "BROWSER";
            this.BROWSER.ReadOnly = true;
            this.BROWSER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BROWSER.Width = 40;
            // 
            // PRODUCT
            // 
            this.PRODUCT.DataPropertyName = "PRODUCT";
            this.PRODUCT.HeaderText = "生産情報閲覧";
            this.PRODUCT.MinimumWidth = 8;
            this.PRODUCT.Name = "PRODUCT";
            this.PRODUCT.ReadOnly = true;
            this.PRODUCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRODUCT.Width = 40;
            // 
            // PLAN_AMIGO_CAI
            // 
            this.PLAN_AMIGO_CAI.DataPropertyName = "PLAN_AMIGO_CAI";
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.PLAN_AMIGO_CAI.DefaultCellStyle = dataGridViewCellStyle65;
            this.PLAN_AMIGO_CAI.HeaderText = "Amigo-CAI権限";
            this.PLAN_AMIGO_CAI.MinimumWidth = 8;
            this.PLAN_AMIGO_CAI.Name = "PLAN_AMIGO_CAI";
            this.PLAN_AMIGO_CAI.ReadOnly = true;
            this.PLAN_AMIGO_CAI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_AMIGO_CAI.Width = 40;
            // 
            // PLAN_AMIGO_BIZ
            // 
            this.PLAN_AMIGO_BIZ.DataPropertyName = "PLAN_AMIGO_BIZ";
            dataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.PLAN_AMIGO_BIZ.DefaultCellStyle = dataGridViewCellStyle66;
            this.PLAN_AMIGO_BIZ.HeaderText = "Amigo-BiZ権限";
            this.PLAN_AMIGO_BIZ.MinimumWidth = 8;
            this.PLAN_AMIGO_BIZ.Name = "PLAN_AMIGO_BIZ";
            this.PLAN_AMIGO_BIZ.ReadOnly = true;
            this.PLAN_AMIGO_BIZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLAN_AMIGO_BIZ.Width = 40;
            // 
            // OP_BOX_SERVER
            // 
            this.OP_BOX_SERVER.DataPropertyName = "OP_BOX_SERVER";
            dataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_BOX_SERVER.DefaultCellStyle = dataGridViewCellStyle67;
            this.OP_BOX_SERVER.HeaderText = "拡張BOX サーバー";
            this.OP_BOX_SERVER.MinimumWidth = 8;
            this.OP_BOX_SERVER.Name = "OP_BOX_SERVER";
            this.OP_BOX_SERVER.ReadOnly = true;
            this.OP_BOX_SERVER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_BOX_SERVER.Width = 40;
            // 
            // OP_BOX_BROWSER
            // 
            this.OP_BOX_BROWSER.DataPropertyName = "OP_BOX_BROWSER";
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_BOX_BROWSER.DefaultCellStyle = dataGridViewCellStyle68;
            this.OP_BOX_BROWSER.HeaderText = "拡張BOX ブラウザ";
            this.OP_BOX_BROWSER.MinimumWidth = 8;
            this.OP_BOX_BROWSER.Name = "OP_BOX_BROWSER";
            this.OP_BOX_BROWSER.ReadOnly = true;
            this.OP_BOX_BROWSER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_BOX_BROWSER.Width = 40;
            // 
            // OP_FLAT
            // 
            this.OP_FLAT.DataPropertyName = "OP_FLAT";
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_FLAT.DefaultCellStyle = dataGridViewCellStyle69;
            this.OP_FLAT.HeaderText = "FLAT変換";
            this.OP_FLAT.MinimumWidth = 8;
            this.OP_FLAT.Name = "OP_FLAT";
            this.OP_FLAT.ReadOnly = true;
            this.OP_FLAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_FLAT.Width = 40;
            // 
            // OP_CLIENT
            // 
            this.OP_CLIENT.DataPropertyName = "OP_CLIENT";
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_CLIENT.DefaultCellStyle = dataGridViewCellStyle70;
            this.OP_CLIENT.HeaderText = "クライアント証明";
            this.OP_CLIENT.MinimumWidth = 8;
            this.OP_CLIENT.Name = "OP_CLIENT";
            this.OP_CLIENT.ReadOnly = true;
            this.OP_CLIENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_CLIENT.Width = 40;
            // 
            // OP_BASIC_SERVICE
            // 
            this.OP_BASIC_SERVICE.DataPropertyName = "OP_BASIC_SERVICE";
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_BASIC_SERVICE.DefaultCellStyle = dataGridViewCellStyle71;
            this.OP_BASIC_SERVICE.HeaderText = "サービスデスク基本";
            this.OP_BASIC_SERVICE.MinimumWidth = 8;
            this.OP_BASIC_SERVICE.Name = "OP_BASIC_SERVICE";
            this.OP_BASIC_SERVICE.ReadOnly = true;
            this.OP_BASIC_SERVICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_BASIC_SERVICE.Width = 40;
            // 
            // OP_ADD_SERVICE
            // 
            this.OP_ADD_SERVICE.DataPropertyName = "OP_ADD_SERVICE";
            dataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.OP_ADD_SERVICE.DefaultCellStyle = dataGridViewCellStyle72;
            this.OP_ADD_SERVICE.HeaderText = "サービスデスク追加";
            this.OP_ADD_SERVICE.MinimumWidth = 8;
            this.OP_ADD_SERVICE.Name = "OP_ADD_SERVICE";
            this.OP_ADD_SERVICE.ReadOnly = true;
            this.OP_ADD_SERVICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OP_ADD_SERVICE.Width = 40;
            // 
            // frmMonthlySaleComparisonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 619);
            this.Controls.Add(this.lbldifference);
            this.Controls.Add(this.displayItemLabel1);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.cboLimit);
            this.Controls.Add(this.lblCompanyNoBox);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1300, 640);
            this.Name = "frmMonthlySaleComparisonList";
            this.Text = "frmMonthlySaleComparisonList";
            this.Load += new System.EventHandler(this.frmMonthlySaleComparisonList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFirst;
        private UserControls.DisplayItemLabel displayItemLabel1;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblcurrentPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ComboBox cboLimit;
        private System.Windows.Forms.Label lblCompanyNoBox;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lbldifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDATE_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Server;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERVERRIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BROWSERAUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BROWSER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_AMIGO_CAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_AMIGO_BIZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_BOX_SERVER;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_BOX_BROWSER;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_FLAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_CLIENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_BASIC_SERVICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_ADD_SERVICE;
    }
}