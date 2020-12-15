namespace AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification
{
    partial class frmRegisterCompleteNotification
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClientCertificate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuotationIssueDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDestinationMailAddress = new System.Windows.Forms.Label();
            this.txtDestinationMailAddress = new System.Windows.Forms.TextBox();
            this.txtCompanyNoBox = new System.Windows.Forms.TextBox();
            this.txtEDIAccount = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtRegisterCompleteNotificationDate = new System.Windows.Forms.TextBox();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(318, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 122;
            this.label2.Text = "EDIアカウント";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(17, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 121;
            this.label3.Text = "会社番号+BOX ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(17, 69);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 30);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "プレビュー";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btnClientCertificate
            // 
            this.btnClientCertificate.Location = new System.Drawing.Point(138, 69);
            this.btnClientCertificate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClientCertificate.Name = "btnClientCertificate";
            this.btnClientCertificate.Size = new System.Drawing.Size(100, 30);
            this.btnClientCertificate.TabIndex = 2;
            this.btnClientCertificate.Text = "クライアント証明書";
            this.btnClientCertificate.UseVisualStyleBackColor = true;
            this.btnClientCertificate.Click += new System.EventHandler(this.BtnClientCertificate_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(318, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 126;
            this.label1.Text = "注文日";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(16, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 125;
            this.label4.Text = "見積書発行日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationIssueDate
            // 
            this.txtQuotationIssueDate.Location = new System.Drawing.Point(116, 165);
            this.txtQuotationIssueDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuotationIssueDate.Name = "txtQuotationIssueDate";
            this.txtQuotationIssueDate.ReadOnly = true;
            this.txtQuotationIssueDate.Size = new System.Drawing.Size(166, 25);
            this.txtQuotationIssueDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(602, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 21);
            this.label5.TabIndex = 130;
            this.label5.Text = "登録完了通知日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(602, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 21);
            this.label6.TabIndex = 129;
            this.label6.Text = "会社名";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationMailAddress
            // 
            this.lblDestinationMailAddress.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDestinationMailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDestinationMailAddress.Location = new System.Drawing.Point(16, 209);
            this.lblDestinationMailAddress.Name = "lblDestinationMailAddress";
            this.lblDestinationMailAddress.Size = new System.Drawing.Size(101, 21);
            this.lblDestinationMailAddress.TabIndex = 133;
            this.lblDestinationMailAddress.Text = "送付先メールアドレス";
            this.lblDestinationMailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestinationMailAddress
            // 
            this.txtDestinationMailAddress.Location = new System.Drawing.Point(116, 209);
            this.txtDestinationMailAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDestinationMailAddress.Name = "txtDestinationMailAddress";
            this.txtDestinationMailAddress.Size = new System.Drawing.Size(451, 25);
            this.txtDestinationMailAddress.TabIndex = 3;
            // 
            // txtCompanyNoBox
            // 
            this.txtCompanyNoBox.Location = new System.Drawing.Point(116, 123);
            this.txtCompanyNoBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyNoBox.Name = "txtCompanyNoBox";
            this.txtCompanyNoBox.ReadOnly = true;
            this.txtCompanyNoBox.Size = new System.Drawing.Size(166, 25);
            this.txtCompanyNoBox.TabIndex = 4;
            // 
            // txtEDIAccount
            // 
            this.txtEDIAccount.Location = new System.Drawing.Point(401, 122);
            this.txtEDIAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEDIAccount.Name = "txtEDIAccount";
            this.txtEDIAccount.ReadOnly = true;
            this.txtEDIAccount.Size = new System.Drawing.Size(166, 25);
            this.txtEDIAccount.TabIndex = 5;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(401, 165);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(166, 25);
            this.txtOrderDate.TabIndex = 8;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(700, 122);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(166, 25);
            this.txtCompanyName.TabIndex = 6;
            // 
            // txtRegisterCompleteNotificationDate
            // 
            this.txtRegisterCompleteNotificationDate.Location = new System.Drawing.Point(700, 165);
            this.txtRegisterCompleteNotificationDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRegisterCompleteNotificationDate.Name = "txtRegisterCompleteNotificationDate";
            this.txtRegisterCompleteNotificationDate.ReadOnly = true;
            this.txtRegisterCompleteNotificationDate.Size = new System.Drawing.Size(166, 25);
            this.txtRegisterCompleteNotificationDate.TabIndex = 9;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1282, 50);
            this.pTitle.TabIndex = 139;
            // 
            // lblMenu
            // 
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(16, 11);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(275, 34);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Jimugo - Menu";
            // 
            // frmRegisterCompleteNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 253);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.txtRegisterCompleteNotificationDate);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtEDIAccount);
            this.Controls.Add(this.txtCompanyNoBox);
            this.Controls.Add(this.lblDestinationMailAddress);
            this.Controls.Add(this.txtDestinationMailAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuotationIssueDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnClientCertificate);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 300);
            this.MinimizeBox = false;
            this.Name = "frmRegisterCompleteNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegisterCompleteNotification_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegisterCompleteNotification_Load);
            this.pTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClientCertificate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuotationIssueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDestinationMailAddress;
        private System.Windows.Forms.TextBox txtDestinationMailAddress;
        private System.Windows.Forms.TextBox txtCompanyNoBox;
        private System.Windows.Forms.TextBox txtEDIAccount;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtRegisterCompleteNotificationDate;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
    }
}