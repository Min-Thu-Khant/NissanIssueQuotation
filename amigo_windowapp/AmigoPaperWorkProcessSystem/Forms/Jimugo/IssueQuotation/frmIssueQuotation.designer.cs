namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation
{
    partial class frmIssueQuotation
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
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblCompanNoBox = new System.Windows.Forms.Label();
            this.txtCompanyNoBox = new System.Windows.Forms.TextBox();
            this.lblEDIAccount = new System.Windows.Forms.Label();
            this.txtEDIAccount = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lblNotificationDate = new System.Windows.Forms.Label();
            this.txtNotificationDate = new System.Windows.Forms.TextBox();
            this.chkInitialQuot = new System.Windows.Forms.CheckBox();
            this.chkMonthlyQuote = new System.Windows.Forms.CheckBox();
            this.chkProductionInfo = new System.Windows.Forms.CheckBox();
            this.chkOrderForm = new System.Windows.Forms.CheckBox();
            this.lblQuotationStartDate = new System.Windows.Forms.Label();
            this.txtQuotationStartDate = new System.Windows.Forms.TextBox();
            this.lblQuotationExpireDay = new System.Windows.Forms.Label();
            this.txtQuotationExpireDay = new System.Windows.Forms.TextBox();
            this.lblInitialSpecialDiscount = new System.Windows.Forms.Label();
            this.txtInitialSpecialDiscount = new System.Windows.Forms.TextBox();
            this.lblMonthlySpecialDiscount = new System.Windows.Forms.Label();
            this.txtMonthlySpecialDiscount = new System.Windows.Forms.TextBox();
            this.lblDestinationEmail = new System.Windows.Forms.Label();
            this.txtDestinationMail = new System.Windows.Forms.TextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtPeriodFrom = new System.Windows.Forms.TextBox();
            this.txtPeriodTo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbParent = new System.Windows.Forms.TabControl();
            this.tbInitialRemark = new System.Windows.Forms.TabPage();
            this.txtInitialRemark = new System.Windows.Forms.TextBox();
            this.tbMonthlyRemark = new System.Windows.Forms.TabPage();
            this.txtMonthlyRemark = new System.Windows.Forms.TextBox();
            this.tbProductionInfoRemark = new System.Windows.Forms.TabPage();
            this.txtOrderRemark = new System.Windows.Forms.TextBox();
            this.tbOrderRemark = new System.Windows.Forms.TabPage();
            this.txtProductionInfoRemark = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblYearlySpecialDiscount = new System.Windows.Forms.Label();
            this.txtYearlySpecialDiscount = new System.Windows.Forms.TextBox();
            this.pTitle.SuspendLayout();
            this.tbParent.SuspendLayout();
            this.tbInitialRemark.SuspendLayout();
            this.tbMonthlyRemark.SuspendLayout();
            this.tbProductionInfoRemark.SuspendLayout();
            this.tbOrderRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 50);
            this.pTitle.TabIndex = 2;
            // 
            // lblMenu
            // 
            this.lblMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(14, 10);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(1258, 32);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "XXXXXXXXX";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(15, 63);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 30);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "プレビュー\r\n";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // lblCompanNoBox
            // 
            this.lblCompanNoBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompanNoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompanNoBox.Location = new System.Drawing.Point(16, 108);
            this.lblCompanNoBox.Name = "lblCompanNoBox";
            this.lblCompanNoBox.Size = new System.Drawing.Size(101, 21);
            this.lblCompanNoBox.TabIndex = 19;
            this.lblCompanNoBox.Text = "会社番号+BOX";
            this.lblCompanNoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Enabled = false;
            this.txtCompanyNoBox.Location = new System.Drawing.Point(116, 108);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.Size = new System.Drawing.Size(130, 25);
            this.txtCompanyNoBox.TabIndex = 18;
            // 
            // lblEDIAccount
            // 
            this.lblEDIAccount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblEDIAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEDIAccount.Location = new System.Drawing.Point(275, 109);
            this.lblEDIAccount.Name = "lblEDIAccount";
            this.lblEDIAccount.Size = new System.Drawing.Size(81, 21);
            this.lblEDIAccount.TabIndex = 21;
            this.lblEDIAccount.Text = "EDIアカウント";
            this.lblEDIAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEDIAccount
            // 
            this.txtEDIAccount.Enabled = false;
            this.txtEDIAccount.Location = new System.Drawing.Point(355, 109);
            this.txtEDIAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEDIAccount.Name = "txtEDIAccount";
            this.txtEDIAccount.Size = new System.Drawing.Size(130, 25);
            this.txtEDIAccount.TabIndex = 20;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompanyName.Location = new System.Drawing.Point(513, 109);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(101, 21);
            this.lblCompanyName.TabIndex = 23;
            this.lblCompanyName.Text = "会社名";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Location = new System.Drawing.Point(613, 109);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(130, 25);
            this.txtCompanyName.TabIndex = 22;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblIssueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIssueDate.Location = new System.Drawing.Point(16, 148);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(101, 21);
            this.lblIssueDate.TabIndex = 25;
            this.lblIssueDate.Text = "見積書発行日";
            this.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Enabled = false;
            this.txtIssueDate.Location = new System.Drawing.Point(116, 148);
            this.txtIssueDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Size = new System.Drawing.Size(130, 25);
            this.txtIssueDate.TabIndex = 24;
            this.txtIssueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDate.Location = new System.Drawing.Point(275, 148);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(81, 21);
            this.lblOrderDate.TabIndex = 27;
            this.lblOrderDate.Text = "注文日";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.Location = new System.Drawing.Point(355, 148);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(130, 25);
            this.txtOrderDate.TabIndex = 26;
            this.txtOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNotificationDate
            // 
            this.lblNotificationDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNotificationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotificationDate.Location = new System.Drawing.Point(513, 149);
            this.lblNotificationDate.Name = "lblNotificationDate";
            this.lblNotificationDate.Size = new System.Drawing.Size(101, 21);
            this.lblNotificationDate.TabIndex = 29;
            this.lblNotificationDate.Text = "登録完了通知日";
            this.lblNotificationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotificationDate
            // 
            this.txtNotificationDate.Enabled = false;
            this.txtNotificationDate.Location = new System.Drawing.Point(613, 149);
            this.txtNotificationDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotificationDate.Name = "txtNotificationDate";
            this.txtNotificationDate.Size = new System.Drawing.Size(130, 25);
            this.txtNotificationDate.TabIndex = 28;
            this.txtNotificationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkInitialQuot
            // 
            this.chkInitialQuot.AutoSize = true;
            this.chkInitialQuot.Checked = true;
            this.chkInitialQuot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInitialQuot.Location = new System.Drawing.Point(16, 191);
            this.chkInitialQuot.Name = "chkInitialQuot";
            this.chkInitialQuot.Size = new System.Drawing.Size(100, 22);
            this.chkInitialQuot.TabIndex = 2;
            this.chkInitialQuot.Text = "初期見積書";
            this.chkInitialQuot.UseVisualStyleBackColor = true;
            // 
            // chkMonthlyQuote
            // 
            this.chkMonthlyQuote.AutoSize = true;
            this.chkMonthlyQuote.Checked = true;
            this.chkMonthlyQuote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonthlyQuote.Location = new System.Drawing.Point(136, 191);
            this.chkMonthlyQuote.Name = "chkMonthlyQuote";
            this.chkMonthlyQuote.Size = new System.Drawing.Size(100, 22);
            this.chkMonthlyQuote.TabIndex = 3;
            this.chkMonthlyQuote.Text = "月額見積書";
            this.chkMonthlyQuote.UseVisualStyleBackColor = true;
            // 
            // chkProductionInfo
            // 
            this.chkProductionInfo.AutoSize = true;
            this.chkProductionInfo.Checked = true;
            this.chkProductionInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProductionInfo.Location = new System.Drawing.Point(255, 191);
            this.chkProductionInfo.Name = "chkProductionInfo";
            this.chkProductionInfo.Size = new System.Drawing.Size(114, 22);
            this.chkProductionInfo.TabIndex = 4;
            this.chkProductionInfo.Text = "生産情報閲覧";
            this.chkProductionInfo.UseVisualStyleBackColor = true;
            // 
            // chkOrderForm
            // 
            this.chkOrderForm.AutoSize = true;
            this.chkOrderForm.Checked = true;
            this.chkOrderForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrderForm.Location = new System.Drawing.Point(387, 191);
            this.chkOrderForm.Name = "chkOrderForm";
            this.chkOrderForm.Size = new System.Drawing.Size(72, 22);
            this.chkOrderForm.TabIndex = 5;
            this.chkOrderForm.Text = "注文書";
            this.chkOrderForm.UseVisualStyleBackColor = true;
            // 
            // lblQuotationStartDate
            // 
            this.lblQuotationStartDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblQuotationStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuotationStartDate.Location = new System.Drawing.Point(771, 189);
            this.lblQuotationStartDate.Name = "lblQuotationStartDate";
            this.lblQuotationStartDate.Size = new System.Drawing.Size(101, 21);
            this.lblQuotationStartDate.TabIndex = 35;
            this.lblQuotationStartDate.Text = "見積開始日";
            this.lblQuotationStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationStartDate
            // 
            this.txtQuotationStartDate.Location = new System.Drawing.Point(871, 189);
            this.txtQuotationStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuotationStartDate.Name = "txtQuotationStartDate";
            this.txtQuotationStartDate.Size = new System.Drawing.Size(130, 25);
            this.txtQuotationStartDate.TabIndex = 6;
            this.txtQuotationStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblQuotationExpireDay
            // 
            this.lblQuotationExpireDay.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblQuotationExpireDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuotationExpireDay.Location = new System.Drawing.Point(1026, 189);
            this.lblQuotationExpireDay.Name = "lblQuotationExpireDay";
            this.lblQuotationExpireDay.Size = new System.Drawing.Size(101, 21);
            this.lblQuotationExpireDay.TabIndex = 37;
            this.lblQuotationExpireDay.Text = "見積有効期限(日)";
            this.lblQuotationExpireDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationExpireDay
            // 
            this.txtQuotationExpireDay.Location = new System.Drawing.Point(1126, 189);
            this.txtQuotationExpireDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuotationExpireDay.Name = "txtQuotationExpireDay";
            this.txtQuotationExpireDay.Size = new System.Drawing.Size(130, 25);
            this.txtQuotationExpireDay.TabIndex = 7;
            this.txtQuotationExpireDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInitialSpecialDiscount
            // 
            this.lblInitialSpecialDiscount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInitialSpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInitialSpecialDiscount.Location = new System.Drawing.Point(16, 231);
            this.lblInitialSpecialDiscount.Name = "lblInitialSpecialDiscount";
            this.lblInitialSpecialDiscount.Size = new System.Drawing.Size(109, 21);
            this.lblInitialSpecialDiscount.TabIndex = 39;
            this.lblInitialSpecialDiscount.Text = "特別値引き額(初期)";
            this.lblInitialSpecialDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInitialSpecialDiscount
            // 
            this.txtInitialSpecialDiscount.Location = new System.Drawing.Point(124, 231);
            this.txtInitialSpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInitialSpecialDiscount.Name = "txtInitialSpecialDiscount";
            this.txtInitialSpecialDiscount.Size = new System.Drawing.Size(122, 25);
            this.txtInitialSpecialDiscount.TabIndex = 8;
            this.txtInitialSpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonthlySpecialDiscount
            // 
            this.lblMonthlySpecialDiscount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMonthlySpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonthlySpecialDiscount.Location = new System.Drawing.Point(275, 231);
            this.lblMonthlySpecialDiscount.Name = "lblMonthlySpecialDiscount";
            this.lblMonthlySpecialDiscount.Size = new System.Drawing.Size(109, 21);
            this.lblMonthlySpecialDiscount.TabIndex = 41;
            this.lblMonthlySpecialDiscount.Text = "特別値引き額(月額)";
            this.lblMonthlySpecialDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonthlySpecialDiscount
            // 
            this.txtMonthlySpecialDiscount.Location = new System.Drawing.Point(383, 231);
            this.txtMonthlySpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonthlySpecialDiscount.Name = "txtMonthlySpecialDiscount";
            this.txtMonthlySpecialDiscount.Size = new System.Drawing.Size(102, 25);
            this.txtMonthlySpecialDiscount.TabIndex = 9;
            this.txtMonthlySpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDestinationEmail
            // 
            this.lblDestinationEmail.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDestinationEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDestinationEmail.Location = new System.Drawing.Point(16, 273);
            this.lblDestinationEmail.Name = "lblDestinationEmail";
            this.lblDestinationEmail.Size = new System.Drawing.Size(109, 21);
            this.lblDestinationEmail.TabIndex = 43;
            this.lblDestinationEmail.Text = "送付先メールアドレス";
            this.lblDestinationEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestinationMail
            // 
            this.txtDestinationMail.Location = new System.Drawing.Point(124, 273);
            this.txtDestinationMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDestinationMail.Name = "txtDestinationMail";
            this.txtDestinationMail.Size = new System.Drawing.Size(361, 25);
            this.txtDestinationMail.TabIndex = 11;
            // 
            // lblPeriod
            // 
            this.lblPeriod.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeriod.Location = new System.Drawing.Point(16, 316);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(130, 21);
            this.lblPeriod.TabIndex = 45;
            this.lblPeriod.Text = "クライアント証明書の期間";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPeriodFrom
            // 
            this.txtPeriodFrom.Location = new System.Drawing.Point(145, 316);
            this.txtPeriodFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodFrom.Name = "txtPeriodFrom";
            this.txtPeriodFrom.Size = new System.Drawing.Size(150, 25);
            this.txtPeriodFrom.TabIndex = 13;
            this.txtPeriodFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPeriodTo
            // 
            this.txtPeriodTo.Location = new System.Drawing.Point(335, 316);
            this.txtPeriodTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodTo.Name = "txtPeriodTo";
            this.txtPeriodTo.Size = new System.Drawing.Size(150, 25);
            this.txtPeriodTo.TabIndex = 14;
            this.txtPeriodTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(307, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 18);
            this.label13.TabIndex = 47;
            this.label13.Text = "~";
            // 
            // tbParent
            // 
            this.tbParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbParent.Controls.Add(this.tbInitialRemark);
            this.tbParent.Controls.Add(this.tbMonthlyRemark);
            this.tbParent.Controls.Add(this.tbProductionInfoRemark);
            this.tbParent.Controls.Add(this.tbOrderRemark);
            this.tbParent.Location = new System.Drawing.Point(16, 364);
            this.tbParent.Name = "tbParent";
            this.tbParent.SelectedIndex = 0;
            this.tbParent.Size = new System.Drawing.Size(1259, 305);
            this.tbParent.TabIndex = 15;
            // 
            // tbInitialRemark
            // 
            this.tbInitialRemark.Controls.Add(this.txtInitialRemark);
            this.tbInitialRemark.Location = new System.Drawing.Point(4, 27);
            this.tbInitialRemark.Name = "tbInitialRemark";
            this.tbInitialRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbInitialRemark.Size = new System.Drawing.Size(1251, 274);
            this.tbInitialRemark.TabIndex = 0;
            this.tbInitialRemark.Text = "初期見積書の備考";
            this.tbInitialRemark.UseVisualStyleBackColor = true;
            // 
            // txtInitialRemark
            // 
            this.txtInitialRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInitialRemark.Location = new System.Drawing.Point(3, 3);
            this.txtInitialRemark.Multiline = true;
            this.txtInitialRemark.Name = "txtInitialRemark";
            this.txtInitialRemark.Size = new System.Drawing.Size(1245, 268);
            this.txtInitialRemark.TabIndex = 16;
            // 
            // tbMonthlyRemark
            // 
            this.tbMonthlyRemark.Controls.Add(this.txtMonthlyRemark);
            this.tbMonthlyRemark.Location = new System.Drawing.Point(4, 27);
            this.tbMonthlyRemark.Name = "tbMonthlyRemark";
            this.tbMonthlyRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbMonthlyRemark.Size = new System.Drawing.Size(1251, 274);
            this.tbMonthlyRemark.TabIndex = 1;
            this.tbMonthlyRemark.Text = "月額見積書の備考";
            this.tbMonthlyRemark.UseVisualStyleBackColor = true;
            // 
            // txtMonthlyRemark
            // 
            this.txtMonthlyRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonthlyRemark.Location = new System.Drawing.Point(3, 3);
            this.txtMonthlyRemark.Multiline = true;
            this.txtMonthlyRemark.Name = "txtMonthlyRemark";
            this.txtMonthlyRemark.Size = new System.Drawing.Size(1245, 268);
            this.txtMonthlyRemark.TabIndex = 1;
            // 
            // tbProductionInfoRemark
            // 
            this.tbProductionInfoRemark.Controls.Add(this.txtOrderRemark);
            this.tbProductionInfoRemark.Location = new System.Drawing.Point(4, 27);
            this.tbProductionInfoRemark.Name = "tbProductionInfoRemark";
            this.tbProductionInfoRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbProductionInfoRemark.Size = new System.Drawing.Size(1251, 274);
            this.tbProductionInfoRemark.TabIndex = 2;
            this.tbProductionInfoRemark.Text = "注文書の備考";
            this.tbProductionInfoRemark.UseVisualStyleBackColor = true;
            // 
            // txtOrderRemark
            // 
            this.txtOrderRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderRemark.Location = new System.Drawing.Point(3, 3);
            this.txtOrderRemark.Multiline = true;
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Size = new System.Drawing.Size(1245, 268);
            this.txtOrderRemark.TabIndex = 0;
            // 
            // tbOrderRemark
            // 
            this.tbOrderRemark.Controls.Add(this.txtProductionInfoRemark);
            this.tbOrderRemark.Location = new System.Drawing.Point(4, 27);
            this.tbOrderRemark.Name = "tbOrderRemark";
            this.tbOrderRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbOrderRemark.Size = new System.Drawing.Size(1251, 274);
            this.tbOrderRemark.TabIndex = 3;
            this.tbOrderRemark.Text = "初期見積書(生産)の備考";
            this.tbOrderRemark.UseVisualStyleBackColor = true;
            // 
            // txtProductionInfoRemark
            // 
            this.txtProductionInfoRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductionInfoRemark.Location = new System.Drawing.Point(3, 3);
            this.txtProductionInfoRemark.Multiline = true;
            this.txtProductionInfoRemark.Name = "txtProductionInfoRemark";
            this.txtProductionInfoRemark.Size = new System.Drawing.Size(1245, 268);
            this.txtProductionInfoRemark.TabIndex = 0;
            // 
            // lblTax
            // 
            this.lblTax.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTax.Location = new System.Drawing.Point(513, 189);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(101, 21);
            this.lblTax.TabIndex = 50;
            this.lblTax.Text = "消費税(%)";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(613, 189);
            this.txtTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(130, 25);
            this.txtTax.TabIndex = 16;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblYearlySpecialDiscount
            // 
            this.lblYearlySpecialDiscount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblYearlySpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYearlySpecialDiscount.Location = new System.Drawing.Point(513, 231);
            this.lblYearlySpecialDiscount.Name = "lblYearlySpecialDiscount";
            this.lblYearlySpecialDiscount.Size = new System.Drawing.Size(109, 21);
            this.lblYearlySpecialDiscount.TabIndex = 52;
            this.lblYearlySpecialDiscount.Text = "特別値引き額(年額)";
            this.lblYearlySpecialDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYearlySpecialDiscount
            // 
            this.txtYearlySpecialDiscount.Location = new System.Drawing.Point(621, 231);
            this.txtYearlySpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYearlySpecialDiscount.Name = "txtYearlySpecialDiscount";
            this.txtYearlySpecialDiscount.Size = new System.Drawing.Size(102, 25);
            this.txtYearlySpecialDiscount.TabIndex = 10;
            this.txtYearlySpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmIssueQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.lblYearlySpecialDiscount);
            this.Controls.Add(this.txtYearlySpecialDiscount);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.tbParent);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPeriodTo);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.txtPeriodFrom);
            this.Controls.Add(this.lblDestinationEmail);
            this.Controls.Add(this.txtDestinationMail);
            this.Controls.Add(this.lblMonthlySpecialDiscount);
            this.Controls.Add(this.txtMonthlySpecialDiscount);
            this.Controls.Add(this.lblInitialSpecialDiscount);
            this.Controls.Add(this.txtInitialSpecialDiscount);
            this.Controls.Add(this.lblQuotationExpireDay);
            this.Controls.Add(this.txtQuotationExpireDay);
            this.Controls.Add(this.lblQuotationStartDate);
            this.Controls.Add(this.txtQuotationStartDate);
            this.Controls.Add(this.chkOrderForm);
            this.Controls.Add(this.chkProductionInfo);
            this.Controls.Add(this.chkMonthlyQuote);
            this.Controls.Add(this.chkInitialQuot);
            this.Controls.Add(this.lblNotificationDate);
            this.Controls.Add(this.txtNotificationDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblEDIAccount);
            this.Controls.Add(this.txtEDIAccount);
            this.Controls.Add(this.lblCompanNoBox);
            this.Controls.Add(this.txtCompanyNoBox);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1300, 720);
            this.Name = "frmIssueQuotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIssueQuotation_FormClosing);
            this.Load += new System.EventHandler(this.FrmIssueQuotation_Load);
            this.pTitle.ResumeLayout(false);
            this.tbParent.ResumeLayout(false);
            this.tbInitialRemark.ResumeLayout(false);
            this.tbInitialRemark.PerformLayout();
            this.tbMonthlyRemark.ResumeLayout(false);
            this.tbMonthlyRemark.PerformLayout();
            this.tbProductionInfoRemark.ResumeLayout(false);
            this.tbProductionInfoRemark.PerformLayout();
            this.tbOrderRemark.ResumeLayout(false);
            this.tbOrderRemark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblCompanNoBox;
        private System.Windows.Forms.TextBox txtCompanyNoBox;
        private System.Windows.Forms.Label lblEDIAccount;
        private System.Windows.Forms.TextBox txtEDIAccount;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblNotificationDate;
        private System.Windows.Forms.TextBox txtNotificationDate;
        private System.Windows.Forms.CheckBox chkInitialQuot;
        private System.Windows.Forms.CheckBox chkMonthlyQuote;
        private System.Windows.Forms.CheckBox chkProductionInfo;
        private System.Windows.Forms.CheckBox chkOrderForm;
        private System.Windows.Forms.Label lblQuotationStartDate;
        private System.Windows.Forms.TextBox txtQuotationStartDate;
        private System.Windows.Forms.Label lblQuotationExpireDay;
        private System.Windows.Forms.TextBox txtQuotationExpireDay;
        private System.Windows.Forms.Label lblInitialSpecialDiscount;
        private System.Windows.Forms.TextBox txtInitialSpecialDiscount;
        private System.Windows.Forms.Label lblMonthlySpecialDiscount;
        private System.Windows.Forms.TextBox txtMonthlySpecialDiscount;
        private System.Windows.Forms.Label lblDestinationEmail;
        private System.Windows.Forms.TextBox txtDestinationMail;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtPeriodFrom;
        private System.Windows.Forms.TextBox txtPeriodTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tbParent;
        private System.Windows.Forms.TabPage tbInitialRemark;
        private System.Windows.Forms.TabPage tbMonthlyRemark;
        private System.Windows.Forms.TabPage tbProductionInfoRemark;
        private System.Windows.Forms.TabPage tbOrderRemark;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtInitialRemark;
        private System.Windows.Forms.TextBox txtMonthlyRemark;
        private System.Windows.Forms.TextBox txtOrderRemark;
        private System.Windows.Forms.TextBox txtProductionInfoRemark;
        private System.Windows.Forms.Label lblYearlySpecialDiscount;
        private System.Windows.Forms.TextBox txtYearlySpecialDiscount;
    }
}