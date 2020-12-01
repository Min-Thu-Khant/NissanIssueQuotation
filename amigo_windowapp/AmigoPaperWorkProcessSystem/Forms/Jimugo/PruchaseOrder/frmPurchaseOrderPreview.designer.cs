namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frmPurchaseOrderPreview
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
            this.txtSystemRegisterDeadline = new System.Windows.Forms.TextBox();
            this.txtSystemEffectiveDate = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtStartUseDate = new System.Windows.Forms.TextBox();
            this.txtREQ_TYPE = new System.Windows.Forms.TextBox();
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblSystemEffectiveDate = new System.Windows.Forms.Label();
            this.lblSystemRegisterDeadline = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.lblREQ_TYPE = new System.Windows.Forms.Label();
            this.lblStartUseDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pdfDocViewer = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSystemRegisterDeadline
            // 
            this.txtSystemRegisterDeadline.Location = new System.Drawing.Point(768, 110);
            this.txtSystemRegisterDeadline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemRegisterDeadline.Name = "txtSystemRegisterDeadline";
            this.txtSystemRegisterDeadline.Size = new System.Drawing.Size(152, 25);
            this.txtSystemRegisterDeadline.TabIndex = 30;
            this.txtSystemRegisterDeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSystemEffectiveDate
            // 
            this.txtSystemEffectiveDate.Location = new System.Drawing.Point(419, 110);
            this.txtSystemEffectiveDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemEffectiveDate.Name = "txtSystemEffectiveDate";
            this.txtSystemEffectiveDate.Size = new System.Drawing.Size(152, 25);
            this.txtSystemEffectiveDate.TabIndex = 28;
            this.txtSystemEffectiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(103, 110);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(152, 25);
            this.txtOrderDate.TabIndex = 27;
            this.txtOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(141, 59);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(19, 59);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "登録";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // txtStartUseDate
            // 
            this.txtStartUseDate.Enabled = false;
            this.txtStartUseDate.Location = new System.Drawing.Point(768, 149);
            this.txtStartUseDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStartUseDate.Name = "txtStartUseDate";
            this.txtStartUseDate.ReadOnly = true;
            this.txtStartUseDate.Size = new System.Drawing.Size(152, 25);
            this.txtStartUseDate.TabIndex = 36;
            this.txtStartUseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtREQ_TYPE
            // 
            this.txtREQ_TYPE.Enabled = false;
            this.txtREQ_TYPE.Location = new System.Drawing.Point(419, 150);
            this.txtREQ_TYPE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtREQ_TYPE.Name = "txtREQ_TYPE";
            this.txtREQ_TYPE.Size = new System.Drawing.Size(83, 25);
            this.txtREQ_TYPE.TabIndex = 34;
            this.txtREQ_TYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Enabled = false;
            this.txtTransactionType.Location = new System.Drawing.Point(103, 151);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.ReadOnly = true;
            this.txtTransactionType.Size = new System.Drawing.Size(83, 25);
            this.txtTransactionType.TabIndex = 33;
            this.txtTransactionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDate.Location = new System.Drawing.Point(19, 110);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(85, 21);
            this.lblOrderDate.TabIndex = 55;
            this.lblOrderDate.Text = "注文日";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSystemEffectiveDate
            // 
            this.lblSystemEffectiveDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSystemEffectiveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSystemEffectiveDate.Location = new System.Drawing.Point(324, 110);
            this.lblSystemEffectiveDate.Name = "lblSystemEffectiveDate";
            this.lblSystemEffectiveDate.Size = new System.Drawing.Size(96, 21);
            this.lblSystemEffectiveDate.TabIndex = 56;
            this.lblSystemEffectiveDate.Text = "システム有効日";
            this.lblSystemEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSystemRegisterDeadline
            // 
            this.lblSystemRegisterDeadline.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSystemRegisterDeadline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSystemRegisterDeadline.Location = new System.Drawing.Point(642, 110);
            this.lblSystemRegisterDeadline.Name = "lblSystemRegisterDeadline";
            this.lblSystemRegisterDeadline.Size = new System.Drawing.Size(127, 21);
            this.lblSystemRegisterDeadline.TabIndex = 57;
            this.lblSystemRegisterDeadline.Text = "システム登録期限";
            this.lblSystemRegisterDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTransactionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionType.Location = new System.Drawing.Point(19, 151);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(85, 21);
            this.lblTransactionType.TabIndex = 58;
            this.lblTransactionType.Text = "取引区分";
            this.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblREQ_TYPE
            // 
            this.lblREQ_TYPE.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblREQ_TYPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblREQ_TYPE.Location = new System.Drawing.Point(324, 150);
            this.lblREQ_TYPE.Name = "lblREQ_TYPE";
            this.lblREQ_TYPE.Size = new System.Drawing.Size(96, 21);
            this.lblREQ_TYPE.TabIndex = 59;
            this.lblREQ_TYPE.Text = "申請区分";
            this.lblREQ_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartUseDate
            // 
            this.lblStartUseDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStartUseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartUseDate.Location = new System.Drawing.Point(642, 149);
            this.lblStartUseDate.Name = "lblStartUseDate";
            this.lblStartUseDate.Size = new System.Drawing.Size(127, 21);
            this.lblStartUseDate.TabIndex = 60;
            this.lblStartUseDate.Text = "利用開始年月日";
            this.lblStartUseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "プレビュー";
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 44);
            this.pTitle.TabIndex = 62;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(19, 11);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(100, 27);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "プレビュー";
            // 
            // pdfDocViewer
            // 
            this.pdfDocViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfDocViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfDocViewer.Location = new System.Drawing.Point(19, 218);
            this.pdfDocViewer.MultiPagesThreshold = 60;
            this.pdfDocViewer.Name = "pdfDocViewer";
            this.pdfDocViewer.Size = new System.Drawing.Size(1243, 370);
            this.pdfDocViewer.TabIndex = 63;
            this.pdfDocViewer.Threshold = 60;
            this.pdfDocViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // frmPurchaseOrderPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.pdfDocViewer);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStartUseDate);
            this.Controls.Add(this.lblREQ_TYPE);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblSystemRegisterDeadline);
            this.Controls.Add(this.lblSystemEffectiveDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtStartUseDate);
            this.Controls.Add(this.txtREQ_TYPE);
            this.Controls.Add(this.txtTransactionType);
            this.Controls.Add(this.txtSystemRegisterDeadline);
            this.Controls.Add(this.txtSystemEffectiveDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRegister);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1300, 640);
            this.Name = "frmPurchaseOrderPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrderRegistrationPreview_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegisterPreview_Load);
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSystemRegisterDeadline;
        private System.Windows.Forms.TextBox txtSystemEffectiveDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtStartUseDate;
        private System.Windows.Forms.TextBox txtREQ_TYPE;
        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblSystemEffectiveDate;
        private System.Windows.Forms.Label lblSystemRegisterDeadline;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblREQ_TYPE;
        private System.Windows.Forms.Label lblStartUseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocViewer;
    }
}