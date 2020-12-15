namespace AmigoPaperWorkProcessSystem.Forms.OrderRegistration
{
    partial class frmPurchaseOrder
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.txtCompleteNotificationDate = new System.Windows.Forms.TextBox();
            this.txtSystemRegisterDeadline = new System.Windows.Forms.TextBox();
            this.txtSystemEffectiveDate = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtQuotationIssueDate = new System.Windows.Forms.TextBox();
            this.txtEDIAccount = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyNoBox = new System.Windows.Forms.TextBox();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuotationIssueDate = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblSystemEffectiveDate = new System.Windows.Forms.Label();
            this.lblSystemRegisterDeadline = new System.Windows.Forms.Label();
            this.lblCompleteNotificationDate = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.txtREQ_TYPE = new System.Windows.Forms.TextBox();
            this.lblREQ_TYPE = new System.Windows.Forms.Label();
            this.lblStartUseDate = new System.Windows.Forms.Label();
            this.txtStartUseDate = new System.Windows.Forms.TextBox();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(22, 62);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(117, 32);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "プレビュー";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // txtCompleteNotificationDate
            // 
            this.txtCompleteNotificationDate.Enabled = false;
            this.txtCompleteNotificationDate.Location = new System.Drawing.Point(115, 192);
            this.txtCompleteNotificationDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompleteNotificationDate.Name = "txtCompleteNotificationDate";
            this.txtCompleteNotificationDate.ReadOnly = true;
            this.txtCompleteNotificationDate.Size = new System.Drawing.Size(170, 25);
            this.txtCompleteNotificationDate.TabIndex = 13;
            this.txtCompleteNotificationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSystemRegisterDeadline
            // 
            this.txtSystemRegisterDeadline.Location = new System.Drawing.Point(993, 151);
            this.txtSystemRegisterDeadline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemRegisterDeadline.Name = "txtSystemRegisterDeadline";
            this.txtSystemRegisterDeadline.Size = new System.Drawing.Size(168, 25);
            this.txtSystemRegisterDeadline.TabIndex = 12;
            this.txtSystemRegisterDeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSystemEffectiveDate
            // 
            this.txtSystemEffectiveDate.Location = new System.Drawing.Point(687, 151);
            this.txtSystemEffectiveDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemEffectiveDate.Name = "txtSystemEffectiveDate";
            this.txtSystemEffectiveDate.Size = new System.Drawing.Size(170, 25);
            this.txtSystemEffectiveDate.TabIndex = 11;
            this.txtSystemEffectiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(391, 151);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(170, 25);
            this.txtOrderDate.TabIndex = 10;
            this.txtOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQuotationIssueDate
            // 
            this.txtQuotationIssueDate.Enabled = false;
            this.txtQuotationIssueDate.Location = new System.Drawing.Point(115, 151);
            this.txtQuotationIssueDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuotationIssueDate.Name = "txtQuotationIssueDate";
            this.txtQuotationIssueDate.ReadOnly = true;
            this.txtQuotationIssueDate.Size = new System.Drawing.Size(170, 25);
            this.txtQuotationIssueDate.TabIndex = 9;
            this.txtQuotationIssueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEDIAccount
            // 
            this.txtEDIAccount.Enabled = false;
            this.txtEDIAccount.Location = new System.Drawing.Point(687, 111);
            this.txtEDIAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEDIAccount.Name = "txtEDIAccount";
            this.txtEDIAccount.ReadOnly = true;
            this.txtEDIAccount.Size = new System.Drawing.Size(168, 25);
            this.txtEDIAccount.TabIndex = 4;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Location = new System.Drawing.Point(391, 111);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(170, 25);
            this.txtCompanyName.TabIndex = 3;
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Enabled = false;
            this.txtCompanyNoBox.Location = new System.Drawing.Point(115, 111);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.ReadOnly = true;
            this.txtCompanyNoBox.Size = new System.Drawing.Size(170, 25);
            this.txtCompanyNoBox.TabIndex = 2;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1282, 44);
            this.pTitle.TabIndex = 52;
            // 
            // lblMenu
            // 
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(12, 9);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(142, 28);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Jimugo - Menu";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(22, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 21);
            this.label9.TabIndex = 53;
            this.label9.Text = "会社番号+BOX";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(326, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 54;
            this.label3.Text = "会社名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(599, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 55;
            this.label1.Text = "EDIアカウント";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuotationIssueDate
            // 
            this.lblQuotationIssueDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblQuotationIssueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuotationIssueDate.Location = new System.Drawing.Point(22, 151);
            this.lblQuotationIssueDate.Name = "lblQuotationIssueDate";
            this.lblQuotationIssueDate.Size = new System.Drawing.Size(94, 21);
            this.lblQuotationIssueDate.TabIndex = 56;
            this.lblQuotationIssueDate.Text = "見積書発行日";
            this.lblQuotationIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDate.Location = new System.Drawing.Point(326, 151);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(67, 21);
            this.lblOrderDate.TabIndex = 57;
            this.lblOrderDate.Text = "注文日";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemEffectiveDate
            // 
            this.lblSystemEffectiveDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSystemEffectiveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSystemEffectiveDate.Location = new System.Drawing.Point(599, 151);
            this.lblSystemEffectiveDate.Name = "lblSystemEffectiveDate";
            this.lblSystemEffectiveDate.Size = new System.Drawing.Size(89, 21);
            this.lblSystemEffectiveDate.TabIndex = 58;
            this.lblSystemEffectiveDate.Text = "システム有効日";
            this.lblSystemEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemRegisterDeadline
            // 
            this.lblSystemRegisterDeadline.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSystemRegisterDeadline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSystemRegisterDeadline.Location = new System.Drawing.Point(892, 151);
            this.lblSystemRegisterDeadline.Name = "lblSystemRegisterDeadline";
            this.lblSystemRegisterDeadline.Size = new System.Drawing.Size(102, 21);
            this.lblSystemRegisterDeadline.TabIndex = 59;
            this.lblSystemRegisterDeadline.Text = "システム登録期限";
            this.lblSystemRegisterDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleteNotificationDate
            // 
            this.lblCompleteNotificationDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCompleteNotificationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleteNotificationDate.Location = new System.Drawing.Point(22, 192);
            this.lblCompleteNotificationDate.Name = "lblCompleteNotificationDate";
            this.lblCompleteNotificationDate.Size = new System.Drawing.Size(94, 21);
            this.lblCompleteNotificationDate.TabIndex = 60;
            this.lblCompleteNotificationDate.Text = "登録完了通知日";
            this.lblCompleteNotificationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTransactionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionType.Location = new System.Drawing.Point(327, 191);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(67, 21);
            this.lblTransactionType.TabIndex = 61;
            this.lblTransactionType.Text = "取引区分";
            this.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Enabled = false;
            this.txtTransactionType.Location = new System.Drawing.Point(391, 191);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.ReadOnly = true;
            this.txtTransactionType.Size = new System.Drawing.Size(83, 25);
            this.txtTransactionType.TabIndex = 14;
            this.txtTransactionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtREQ_TYPE
            // 
            this.txtREQ_TYPE.Enabled = false;
            this.txtREQ_TYPE.Location = new System.Drawing.Point(665, 192);
            this.txtREQ_TYPE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtREQ_TYPE.Name = "txtREQ_TYPE";
            this.txtREQ_TYPE.ReadOnly = true;
            this.txtREQ_TYPE.Size = new System.Drawing.Size(83, 25);
            this.txtREQ_TYPE.TabIndex = 15;
            this.txtREQ_TYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblREQ_TYPE
            // 
            this.lblREQ_TYPE.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblREQ_TYPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblREQ_TYPE.Location = new System.Drawing.Point(599, 192);
            this.lblREQ_TYPE.Name = "lblREQ_TYPE";
            this.lblREQ_TYPE.Size = new System.Drawing.Size(67, 21);
            this.lblREQ_TYPE.TabIndex = 63;
            this.lblREQ_TYPE.Text = "申請区分";
            this.lblREQ_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartUseDate
            // 
            this.lblStartUseDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStartUseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartUseDate.Location = new System.Drawing.Point(892, 192);
            this.lblStartUseDate.Name = "lblStartUseDate";
            this.lblStartUseDate.Size = new System.Drawing.Size(102, 21);
            this.lblStartUseDate.TabIndex = 66;
            this.lblStartUseDate.Text = "利用開始年月日";
            this.lblStartUseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartUseDate
            // 
            this.txtStartUseDate.Enabled = false;
            this.txtStartUseDate.Location = new System.Drawing.Point(993, 192);
            this.txtStartUseDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStartUseDate.Name = "txtStartUseDate";
            this.txtStartUseDate.ReadOnly = true;
            this.txtStartUseDate.Size = new System.Drawing.Size(168, 25);
            this.txtStartUseDate.TabIndex = 16;
            this.txtStartUseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 233);
            this.Controls.Add(this.lblStartUseDate);
            this.Controls.Add(this.txtStartUseDate);
            this.Controls.Add(this.txtREQ_TYPE);
            this.Controls.Add(this.lblREQ_TYPE);
            this.Controls.Add(this.txtTransactionType);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblCompleteNotificationDate);
            this.Controls.Add(this.lblSystemRegisterDeadline);
            this.Controls.Add(this.lblSystemEffectiveDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblQuotationIssueDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtCompleteNotificationDate);
            this.Controls.Add(this.txtSystemRegisterDeadline);
            this.Controls.Add(this.txtSystemEffectiveDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtQuotationIssueDate);
            this.Controls.Add(this.txtEDIAccount);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtCompanyNoBox);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 280);
            this.MinimumSize = new System.Drawing.Size(1300, 280);
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrderRegistration_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrderRegistration_Load);
            this.pTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox txtCompleteNotificationDate;
        private System.Windows.Forms.TextBox txtSystemRegisterDeadline;
        private System.Windows.Forms.TextBox txtSystemEffectiveDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtQuotationIssueDate;
        private System.Windows.Forms.TextBox txtEDIAccount;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyNoBox;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuotationIssueDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblSystemEffectiveDate;
        private System.Windows.Forms.Label lblSystemRegisterDeadline;
        private System.Windows.Forms.Label lblCompleteNotificationDate;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.TextBox txtREQ_TYPE;
        private System.Windows.Forms.Label lblREQ_TYPE;
        private System.Windows.Forms.Label lblStartUseDate;
        private System.Windows.Forms.TextBox txtStartUseDate;
    }
}