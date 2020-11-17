namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation
{
    partial class frmIssueQuotationPrevew
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
            this.btnCreateMail = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbQuoteType = new System.Windows.Forms.TabControl();
            this.tbInitial = new System.Windows.Forms.TabPage();
            this.pdfInitialQuote = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.tbMonthly = new System.Windows.Forms.TabPage();
            this.pdfMonthlyQuote = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.tbOrderForm = new System.Windows.Forms.TabPage();
            this.pdfOrderForm = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.tbQuoteType.SuspendLayout();
            this.tbInitial.SuspendLayout();
            this.tbMonthly.SuspendLayout();
            this.tbOrderForm.SuspendLayout();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateMail
            // 
            this.btnCreateMail.Location = new System.Drawing.Point(13, 65);
            this.btnCreateMail.Name = "btnCreateMail";
            this.btnCreateMail.Size = new System.Drawing.Size(100, 30);
            this.btnCreateMail.TabIndex = 4;
            this.btnCreateMail.Text = "メール作成\r\n";
            this.btnCreateMail.UseVisualStyleBackColor = true;
            this.btnCreateMail.Click += new System.EventHandler(this.btnCreateMail_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(124, 65);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "戻る\r\n";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // tbQuoteType
            // 
            this.tbQuoteType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuoteType.Controls.Add(this.tbInitial);
            this.tbQuoteType.Controls.Add(this.tbMonthly);
            this.tbQuoteType.Controls.Add(this.tbOrderForm);
            this.tbQuoteType.Location = new System.Drawing.Point(10, 115);
            this.tbQuoteType.Name = "tbQuoteType";
            this.tbQuoteType.SelectedIndex = 0;
            this.tbQuoteType.Size = new System.Drawing.Size(1262, 474);
            this.tbQuoteType.TabIndex = 6;
            // 
            // tbInitial
            // 
            this.tbInitial.Controls.Add(this.pdfInitialQuote);
            this.tbInitial.Location = new System.Drawing.Point(4, 23);
            this.tbInitial.Name = "tbInitial";
            this.tbInitial.Padding = new System.Windows.Forms.Padding(3);
            this.tbInitial.Size = new System.Drawing.Size(1254, 447);
            this.tbInitial.TabIndex = 0;
            this.tbInitial.Text = "初期見積書";
            this.tbInitial.UseVisualStyleBackColor = true;
            // 
            // pdfInitialQuote
            // 
            this.pdfInitialQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfInitialQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfInitialQuote.Location = new System.Drawing.Point(3, 3);
            this.pdfInitialQuote.Margin = new System.Windows.Forms.Padding(2);
            this.pdfInitialQuote.MultiPagesThreshold = 60;
            this.pdfInitialQuote.Name = "pdfInitialQuote";
            this.pdfInitialQuote.Size = new System.Drawing.Size(1248, 441);
            this.pdfInitialQuote.TabIndex = 0;
            this.pdfInitialQuote.Threshold = 60;
            this.pdfInitialQuote.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // tbMonthly
            // 
            this.tbMonthly.Controls.Add(this.pdfMonthlyQuote);
            this.tbMonthly.Location = new System.Drawing.Point(4, 23);
            this.tbMonthly.Name = "tbMonthly";
            this.tbMonthly.Padding = new System.Windows.Forms.Padding(3);
            this.tbMonthly.Size = new System.Drawing.Size(1254, 447);
            this.tbMonthly.TabIndex = 1;
            this.tbMonthly.Text = "月額見積書";
            this.tbMonthly.UseVisualStyleBackColor = true;
            // 
            // pdfMonthlyQuote
            // 
            this.pdfMonthlyQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfMonthlyQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfMonthlyQuote.Location = new System.Drawing.Point(3, 3);
            this.pdfMonthlyQuote.Margin = new System.Windows.Forms.Padding(2);
            this.pdfMonthlyQuote.MultiPagesThreshold = 60;
            this.pdfMonthlyQuote.Name = "pdfMonthlyQuote";
            this.pdfMonthlyQuote.Size = new System.Drawing.Size(1248, 441);
            this.pdfMonthlyQuote.TabIndex = 0;
            this.pdfMonthlyQuote.Text = "pdfMonthlyQuote";
            this.pdfMonthlyQuote.Threshold = 60;
            this.pdfMonthlyQuote.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // tbOrderForm
            // 
            this.tbOrderForm.Controls.Add(this.pdfOrderForm);
            this.tbOrderForm.Location = new System.Drawing.Point(4, 23);
            this.tbOrderForm.Name = "tbOrderForm";
            this.tbOrderForm.Padding = new System.Windows.Forms.Padding(3);
            this.tbOrderForm.Size = new System.Drawing.Size(1254, 447);
            this.tbOrderForm.TabIndex = 2;
            this.tbOrderForm.Text = "注文書";
            this.tbOrderForm.UseVisualStyleBackColor = true;
            // 
            // pdfOrderForm
            // 
            this.pdfOrderForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfOrderForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfOrderForm.Location = new System.Drawing.Point(3, 3);
            this.pdfOrderForm.Margin = new System.Windows.Forms.Padding(2);
            this.pdfOrderForm.MultiPagesThreshold = 60;
            this.pdfOrderForm.Name = "pdfOrderForm";
            this.pdfOrderForm.Size = new System.Drawing.Size(1248, 441);
            this.pdfOrderForm.TabIndex = 0;
            this.pdfOrderForm.Text = "pdfOrderForm";
            this.pdfOrderForm.Threshold = 60;
            this.pdfOrderForm.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 51);
            this.pTitle.TabIndex = 8;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(14, 10);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(78, 21);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "プレビュー";
            // 
            // frmIssueQuotationPrevew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.tbQuoteType);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCreateMail);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1300, 640);
            this.Name = "frmIssueQuotationPrevew";
            this.Text = "[CTS040] 見積書発行画面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPreviewScreen_FormClosing);
            this.Load += new System.EventHandler(this.FrmPreviewScreen_Load);
            this.tbQuoteType.ResumeLayout(false);
            this.tbInitial.ResumeLayout(false);
            this.tbMonthly.ResumeLayout(false);
            this.tbOrderForm.ResumeLayout(false);
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreateMail;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabControl tbQuoteType;
        private System.Windows.Forms.TabPage tbInitial;
        private System.Windows.Forms.TabPage tbMonthly;
        private System.Windows.Forms.TabPage tbOrderForm;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfInitialQuote;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfMonthlyQuote;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfOrderForm;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
    }
}