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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyNoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEDIAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNotificationDate = new System.Windows.Forms.TextBox();
            this.chkInitialQuot = new System.Windows.Forms.CheckBox();
            this.chkMonthlyQuote = new System.Windows.Forms.CheckBox();
            this.chkProductionInfo = new System.Windows.Forms.CheckBox();
            this.chkOrderForm = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuotationStartDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuotationExpireDay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInitialSpecialDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMonthlySpecialDiscount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDestinationMail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPeriodFrom = new System.Windows.Forms.TextBox();
            this.txtPeriodTo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbParent = new System.Windows.Forms.TabControl();
            this.tbInitialRemark = new System.Windows.Forms.TabPage();
            this.txtInitialRemark = new System.Windows.Forms.TextBox();
            this.tbMonthlyRemark = new System.Windows.Forms.TabPage();
            this.txtMonthlyRemark = new System.Windows.Forms.TextBox();
            this.tbProductionInfoRemark = new System.Windows.Forms.TabPage();
            this.txtProductionInfoRemark = new System.Windows.Forms.TextBox();
            this.tbOrderRemark = new System.Windows.Forms.TabPage();
            this.txtOrderRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
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
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(14, 10);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(162, 32);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "XXXXXXXXX";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(15, 63);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 30);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "プレビュー\r\n";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "会社番号+BOX";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Enabled = false;
            this.txtCompanyNoBox.Location = new System.Drawing.Point(116, 108);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.Size = new System.Drawing.Size(130, 21);
            this.txtCompanyNoBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(275, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "EDIアカウント";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEDIAccount
            // 
            this.txtEDIAccount.Enabled = false;
            this.txtEDIAccount.Location = new System.Drawing.Point(355, 109);
            this.txtEDIAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEDIAccount.Name = "txtEDIAccount";
            this.txtEDIAccount.Size = new System.Drawing.Size(130, 21);
            this.txtEDIAccount.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(513, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "会社名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Location = new System.Drawing.Point(613, 109);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(130, 21);
            this.txtCompanyName.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(16, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "見積書発行日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Enabled = false;
            this.txtIssueDate.Location = new System.Drawing.Point(116, 148);
            this.txtIssueDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Size = new System.Drawing.Size(130, 21);
            this.txtIssueDate.TabIndex = 24;
            this.txtIssueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(275, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 27;
            this.label5.Text = "注文日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.Location = new System.Drawing.Point(355, 148);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(130, 21);
            this.txtOrderDate.TabIndex = 26;
            this.txtOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(513, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 29;
            this.label6.Text = "登録完了通知日";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotificationDate
            // 
            this.txtNotificationDate.Enabled = false;
            this.txtNotificationDate.Location = new System.Drawing.Point(613, 149);
            this.txtNotificationDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotificationDate.Name = "txtNotificationDate";
            this.txtNotificationDate.Size = new System.Drawing.Size(130, 21);
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
            this.chkInitialQuot.Size = new System.Drawing.Size(81, 18);
            this.chkInitialQuot.TabIndex = 30;
            this.chkInitialQuot.Text = "初期見積書";
            this.chkInitialQuot.UseVisualStyleBackColor = true;
            this.chkInitialQuot.CheckedChanged += new System.EventHandler(this.chkType_CheckedChanged);
            // 
            // chkMonthlyQuote
            // 
            this.chkMonthlyQuote.AutoSize = true;
            this.chkMonthlyQuote.Checked = true;
            this.chkMonthlyQuote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonthlyQuote.Location = new System.Drawing.Point(136, 191);
            this.chkMonthlyQuote.Name = "chkMonthlyQuote";
            this.chkMonthlyQuote.Size = new System.Drawing.Size(81, 18);
            this.chkMonthlyQuote.TabIndex = 31;
            this.chkMonthlyQuote.Text = "月額見積書";
            this.chkMonthlyQuote.UseVisualStyleBackColor = true;
            this.chkMonthlyQuote.CheckedChanged += new System.EventHandler(this.chkType_CheckedChanged);
            // 
            // chkProductionInfo
            // 
            this.chkProductionInfo.AutoSize = true;
            this.chkProductionInfo.Checked = true;
            this.chkProductionInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProductionInfo.Location = new System.Drawing.Point(255, 191);
            this.chkProductionInfo.Name = "chkProductionInfo";
            this.chkProductionInfo.Size = new System.Drawing.Size(92, 18);
            this.chkProductionInfo.TabIndex = 32;
            this.chkProductionInfo.Text = "生産情報閲覧";
            this.chkProductionInfo.UseVisualStyleBackColor = true;
            this.chkProductionInfo.CheckedChanged += new System.EventHandler(this.chkType_CheckedChanged);
            // 
            // chkOrderForm
            // 
            this.chkOrderForm.AutoSize = true;
            this.chkOrderForm.Checked = true;
            this.chkOrderForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrderForm.Location = new System.Drawing.Point(387, 191);
            this.chkOrderForm.Name = "chkOrderForm";
            this.chkOrderForm.Size = new System.Drawing.Size(59, 18);
            this.chkOrderForm.TabIndex = 33;
            this.chkOrderForm.Text = "注文書";
            this.chkOrderForm.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(771, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 21);
            this.label7.TabIndex = 35;
            this.label7.Text = "見積開始日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationStartDate
            // 
            this.txtQuotationStartDate.Location = new System.Drawing.Point(871, 189);
            this.txtQuotationStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuotationStartDate.Name = "txtQuotationStartDate";
            this.txtQuotationStartDate.Size = new System.Drawing.Size(130, 21);
            this.txtQuotationStartDate.TabIndex = 34;
            this.txtQuotationStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(1026, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 21);
            this.label8.TabIndex = 37;
            this.label8.Text = "見積有効期限(日)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationExpireDay
            // 
            this.txtQuotationExpireDay.Location = new System.Drawing.Point(1126, 189);
            this.txtQuotationExpireDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuotationExpireDay.Name = "txtQuotationExpireDay";
            this.txtQuotationExpireDay.Size = new System.Drawing.Size(130, 21);
            this.txtQuotationExpireDay.TabIndex = 36;
            this.txtQuotationExpireDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(16, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 39;
            this.label9.Text = "特別値引き額(初期)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInitialSpecialDiscount
            // 
            this.txtInitialSpecialDiscount.Location = new System.Drawing.Point(124, 231);
            this.txtInitialSpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInitialSpecialDiscount.Name = "txtInitialSpecialDiscount";
            this.txtInitialSpecialDiscount.Size = new System.Drawing.Size(122, 21);
            this.txtInitialSpecialDiscount.TabIndex = 38;
            this.txtInitialSpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(275, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 21);
            this.label10.TabIndex = 41;
            this.label10.Text = "特別値引き額(月額)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonthlySpecialDiscount
            // 
            this.txtMonthlySpecialDiscount.Location = new System.Drawing.Point(383, 231);
            this.txtMonthlySpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonthlySpecialDiscount.Name = "txtMonthlySpecialDiscount";
            this.txtMonthlySpecialDiscount.Size = new System.Drawing.Size(102, 21);
            this.txtMonthlySpecialDiscount.TabIndex = 40;
            this.txtMonthlySpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(16, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 21);
            this.label11.TabIndex = 43;
            this.label11.Text = "送付先メールアドレス";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestinationMail
            // 
            this.txtDestinationMail.Location = new System.Drawing.Point(124, 273);
            this.txtDestinationMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDestinationMail.Name = "txtDestinationMail";
            this.txtDestinationMail.Size = new System.Drawing.Size(361, 21);
            this.txtDestinationMail.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(16, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 21);
            this.label12.TabIndex = 45;
            this.label12.Text = "クライアント証明書の期間";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPeriodFrom
            // 
            this.txtPeriodFrom.Location = new System.Drawing.Point(145, 316);
            this.txtPeriodFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodFrom.Name = "txtPeriodFrom";
            this.txtPeriodFrom.Size = new System.Drawing.Size(150, 21);
            this.txtPeriodFrom.TabIndex = 44;
            this.txtPeriodFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPeriodTo
            // 
            this.txtPeriodTo.Location = new System.Drawing.Point(335, 316);
            this.txtPeriodTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodTo.Name = "txtPeriodTo";
            this.txtPeriodTo.Size = new System.Drawing.Size(150, 21);
            this.txtPeriodTo.TabIndex = 46;
            this.txtPeriodTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(307, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 14);
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
            this.tbParent.TabIndex = 48;
            // 
            // tbInitialRemark
            // 
            this.tbInitialRemark.Controls.Add(this.txtInitialRemark);
            this.tbInitialRemark.Location = new System.Drawing.Point(4, 23);
            this.tbInitialRemark.Name = "tbInitialRemark";
            this.tbInitialRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbInitialRemark.Size = new System.Drawing.Size(1251, 278);
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
            this.txtInitialRemark.Size = new System.Drawing.Size(1245, 272);
            this.txtInitialRemark.TabIndex = 0;
            // 
            // tbMonthlyRemark
            // 
            this.tbMonthlyRemark.Controls.Add(this.txtMonthlyRemark);
            this.tbMonthlyRemark.Location = new System.Drawing.Point(4, 23);
            this.tbMonthlyRemark.Name = "tbMonthlyRemark";
            this.tbMonthlyRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbMonthlyRemark.Size = new System.Drawing.Size(1251, 278);
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
            this.txtMonthlyRemark.Size = new System.Drawing.Size(1245, 272);
            this.txtMonthlyRemark.TabIndex = 1;
            // 
            // tbProductionInfoRemark
            // 
            this.tbProductionInfoRemark.Controls.Add(this.txtProductionInfoRemark);
            this.tbProductionInfoRemark.Location = new System.Drawing.Point(4, 23);
            this.tbProductionInfoRemark.Name = "tbProductionInfoRemark";
            this.tbProductionInfoRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbProductionInfoRemark.Size = new System.Drawing.Size(1251, 278);
            this.tbProductionInfoRemark.TabIndex = 2;
            this.tbProductionInfoRemark.Text = "注文書の備考";
            this.tbProductionInfoRemark.UseVisualStyleBackColor = true;
            // 
            // txtProductionInfoRemark
            // 
            this.txtProductionInfoRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductionInfoRemark.Location = new System.Drawing.Point(3, 3);
            this.txtProductionInfoRemark.Multiline = true;
            this.txtProductionInfoRemark.Name = "txtProductionInfoRemark";
            this.txtProductionInfoRemark.Size = new System.Drawing.Size(1245, 272);
            this.txtProductionInfoRemark.TabIndex = 0;
            // 
            // tbOrderRemark
            // 
            this.tbOrderRemark.Controls.Add(this.txtOrderRemark);
            this.tbOrderRemark.Location = new System.Drawing.Point(4, 23);
            this.tbOrderRemark.Name = "tbOrderRemark";
            this.tbOrderRemark.Padding = new System.Windows.Forms.Padding(3);
            this.tbOrderRemark.Size = new System.Drawing.Size(1251, 278);
            this.tbOrderRemark.TabIndex = 3;
            this.tbOrderRemark.Text = "初期見積書(生産)の備考";
            this.tbOrderRemark.UseVisualStyleBackColor = true;
            // 
            // txtOrderRemark
            // 
            this.txtOrderRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderRemark.Location = new System.Drawing.Point(3, 3);
            this.txtOrderRemark.Multiline = true;
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Size = new System.Drawing.Size(1245, 272);
            this.txtOrderRemark.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(513, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 21);
            this.label14.TabIndex = 50;
            this.label14.Text = "消費税(%)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(613, 189);
            this.txtTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(130, 21);
            this.txtTax.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(513, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 21);
            this.label15.TabIndex = 52;
            this.label15.Text = "特別値引き額(年額)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYearlySpecialDiscount
            // 
            this.txtYearlySpecialDiscount.Location = new System.Drawing.Point(621, 231);
            this.txtYearlySpecialDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYearlySpecialDiscount.Name = "txtYearlySpecialDiscount";
            this.txtYearlySpecialDiscount.Size = new System.Drawing.Size(102, 21);
            this.txtYearlySpecialDiscount.TabIndex = 51;
            this.txtYearlySpecialDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmIssueQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtYearlySpecialDiscount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.tbParent);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPeriodTo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPeriodFrom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDestinationMail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMonthlySpecialDiscount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtInitialSpecialDiscount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuotationExpireDay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQuotationStartDate);
            this.Controls.Add(this.chkOrderForm);
            this.Controls.Add(this.chkProductionInfo);
            this.Controls.Add(this.chkMonthlyQuote);
            this.Controls.Add(this.chkInitialQuot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNotificationDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEDIAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompanyNoBox);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1300, 720);
            this.Name = "frmIssueQuotation";
            this.Text = "frmIssueQuotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyNoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEDIAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotificationDate;
        private System.Windows.Forms.CheckBox chkInitialQuot;
        private System.Windows.Forms.CheckBox chkMonthlyQuote;
        private System.Windows.Forms.CheckBox chkProductionInfo;
        private System.Windows.Forms.CheckBox chkOrderForm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuotationStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuotationExpireDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInitialSpecialDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMonthlySpecialDiscount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDestinationMail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPeriodFrom;
        private System.Windows.Forms.TextBox txtPeriodTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tbParent;
        private System.Windows.Forms.TabPage tbInitialRemark;
        private System.Windows.Forms.TabPage tbMonthlyRemark;
        private System.Windows.Forms.TabPage tbProductionInfoRemark;
        private System.Windows.Forms.TabPage tbOrderRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtInitialRemark;
        private System.Windows.Forms.TextBox txtMonthlyRemark;
        private System.Windows.Forms.TextBox txtProductionInfoRemark;
        private System.Windows.Forms.TextBox txtOrderRemark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtYearlySpecialDiscount;
    }
}