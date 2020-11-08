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
            this.txtREQ_SEQ = new System.Windows.Forms.TextBox();
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.txtSystemRegisterDeadline.Size = new System.Drawing.Size(152, 21);
            this.txtSystemRegisterDeadline.TabIndex = 30;
            // 
            // txtSystemEffectiveDate
            // 
            this.txtSystemEffectiveDate.Location = new System.Drawing.Point(419, 110);
            this.txtSystemEffectiveDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSystemEffectiveDate.Name = "txtSystemEffectiveDate";
            this.txtSystemEffectiveDate.Size = new System.Drawing.Size(152, 21);
            this.txtSystemEffectiveDate.TabIndex = 28;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(103, 110);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(152, 21);
            this.txtOrderDate.TabIndex = 27;
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
            this.txtStartUseDate.Location = new System.Drawing.Point(768, 149);
            this.txtStartUseDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStartUseDate.Name = "txtStartUseDate";
            this.txtStartUseDate.Size = new System.Drawing.Size(152, 21);
            this.txtStartUseDate.TabIndex = 36;
            // 
            // txtREQ_SEQ
            // 
            this.txtREQ_SEQ.Enabled = false;
            this.txtREQ_SEQ.Location = new System.Drawing.Point(419, 150);
            this.txtREQ_SEQ.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtREQ_SEQ.Name = "txtREQ_SEQ";
            this.txtREQ_SEQ.Size = new System.Drawing.Size(83, 21);
            this.txtREQ_SEQ.TabIndex = 34;
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Location = new System.Drawing.Point(103, 151);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.Size = new System.Drawing.Size(83, 21);
            this.txtTransactionType.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(19, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 55;
            this.label7.Text = "注文日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(324, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "システム有効日";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(642, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 57;
            this.label2.Text = "システム登録期限";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(19, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 58;
            this.label3.Text = "取引区分";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(324, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "取引区分";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(642, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 21);
            this.label5.TabIndex = 60;
            this.label5.Text = "利用開始年月日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
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
            this.lblMenu.Size = new System.Drawing.Size(168, 21);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "注文書プレビュー画面";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.pdfDocViewer);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStartUseDate);
            this.Controls.Add(this.txtREQ_SEQ);
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
        private System.Windows.Forms.TextBox txtREQ_SEQ;
        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocViewer;
    }
}