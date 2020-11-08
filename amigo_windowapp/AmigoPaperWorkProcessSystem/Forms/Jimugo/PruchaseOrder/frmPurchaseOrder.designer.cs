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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.txtREQ_TYPE = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.btnPreview.TabIndex = 51;
            this.btnPreview.Text = "プレビュー";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // txtCompleteNotificationDate
            // 
            this.txtCompleteNotificationDate.Location = new System.Drawing.Point(115, 192);
            this.txtCompleteNotificationDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompleteNotificationDate.Name = "txtCompleteNotificationDate";
            this.txtCompleteNotificationDate.Size = new System.Drawing.Size(170, 21);
            this.txtCompleteNotificationDate.TabIndex = 49;
            // 
            // txtSystemRegisterDeadline
            // 
            this.txtSystemRegisterDeadline.Location = new System.Drawing.Point(993, 151);
            this.txtSystemRegisterDeadline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemRegisterDeadline.Name = "txtSystemRegisterDeadline";
            this.txtSystemRegisterDeadline.Size = new System.Drawing.Size(168, 21);
            this.txtSystemRegisterDeadline.TabIndex = 47;
            // 
            // txtSystemEffectiveDate
            // 
            this.txtSystemEffectiveDate.Location = new System.Drawing.Point(687, 151);
            this.txtSystemEffectiveDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemEffectiveDate.Name = "txtSystemEffectiveDate";
            this.txtSystemEffectiveDate.Size = new System.Drawing.Size(170, 21);
            this.txtSystemEffectiveDate.TabIndex = 45;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(391, 151);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(170, 21);
            this.txtOrderDate.TabIndex = 43;
            // 
            // txtQuotationIssueDate
            // 
            this.txtQuotationIssueDate.Enabled = false;
            this.txtQuotationIssueDate.Location = new System.Drawing.Point(115, 151);
            this.txtQuotationIssueDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuotationIssueDate.Name = "txtQuotationIssueDate";
            this.txtQuotationIssueDate.ReadOnly = true;
            this.txtQuotationIssueDate.Size = new System.Drawing.Size(170, 21);
            this.txtQuotationIssueDate.TabIndex = 41;
            // 
            // txtEDIAccount
            // 
            this.txtEDIAccount.Enabled = false;
            this.txtEDIAccount.Location = new System.Drawing.Point(687, 111);
            this.txtEDIAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEDIAccount.Name = "txtEDIAccount";
            this.txtEDIAccount.ReadOnly = true;
            this.txtEDIAccount.Size = new System.Drawing.Size(168, 21);
            this.txtEDIAccount.TabIndex = 39;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Location = new System.Drawing.Point(391, 111);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(170, 21);
            this.txtCompanyName.TabIndex = 37;
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Enabled = false;
            this.txtCompanyNoBox.Location = new System.Drawing.Point(115, 111);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.ReadOnly = true;
            this.txtCompanyNoBox.Size = new System.Drawing.Size(170, 21);
            this.txtCompanyNoBox.TabIndex = 35;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 44);
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(22, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 56;
            this.label2.Text = "見積書発行日";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(326, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "注文日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(599, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 58;
            this.label5.Text = "システム有効日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(892, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "システム登録期限";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(22, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 60;
            this.label7.Text = "登録完了通知日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(327, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 21);
            this.label8.TabIndex = 61;
            this.label8.Text = "取引区分";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Location = new System.Drawing.Point(391, 191);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.Size = new System.Drawing.Size(83, 21);
            this.txtTransactionType.TabIndex = 62;
            // 
            // txtREQ_TYPE
            // 
            this.txtREQ_TYPE.Location = new System.Drawing.Point(665, 192);
            this.txtREQ_TYPE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtREQ_TYPE.Name = "txtREQ_TYPE";
            this.txtREQ_TYPE.Size = new System.Drawing.Size(83, 21);
            this.txtREQ_TYPE.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(599, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 21);
            this.label10.TabIndex = 63;
            this.label10.Text = "申請区分";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(892, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 21);
            this.label11.TabIndex = 66;
            this.label11.Text = "利用開始年月日";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartUseDate
            // 
            this.txtStartUseDate.Location = new System.Drawing.Point(993, 192);
            this.txtStartUseDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStartUseDate.Name = "txtStartUseDate";
            this.txtStartUseDate.Size = new System.Drawing.Size(168, 21);
            this.txtStartUseDate.TabIndex = 65;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 241);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtStartUseDate);
            this.Controls.Add(this.txtREQ_TYPE);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTransactionType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.TextBox txtREQ_TYPE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStartUseDate;
    }
}