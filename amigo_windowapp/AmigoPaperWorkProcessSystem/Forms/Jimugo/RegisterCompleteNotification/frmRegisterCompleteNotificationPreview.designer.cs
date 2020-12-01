namespace AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification
{
    partial class frmRegisterCompleteNotificationPreview
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
            this.pdfDocumentThumbnail1 = new Spire.PdfViewer.Forms.PdfThumbnails.PdfDocumentThumbnail();
            this.pdfDocumentViewer = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateMail
            // 
            this.btnCreateMail.Location = new System.Drawing.Point(27, 78);
            this.btnCreateMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateMail.Name = "btnCreateMail";
            this.btnCreateMail.Size = new System.Drawing.Size(133, 37);
            this.btnCreateMail.TabIndex = 114;
            this.btnCreateMail.Text = "メール作成";
            this.btnCreateMail.UseVisualStyleBackColor = true;
            this.btnCreateMail.Click += new System.EventHandler(this.BtnCreateMail_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(188, 78);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(133, 37);
            this.btnBack.TabIndex = 115;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // pdfDocumentThumbnail1
            // 
            this.pdfDocumentThumbnail1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pdfDocumentThumbnail1.Location = new System.Drawing.Point(461, 231);
            this.pdfDocumentThumbnail1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pdfDocumentThumbnail1.Name = "pdfDocumentThumbnail1";
            this.pdfDocumentThumbnail1.Size = new System.Drawing.Size(20, 20);
            this.pdfDocumentThumbnail1.TabIndex = 117;
            this.pdfDocumentThumbnail1.Viewer = null;
            this.pdfDocumentThumbnail1.ZoomPercent = 8;
            // 
            // pdfDocumentViewer
            // 
            this.pdfDocumentViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfDocumentViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfDocumentViewer.Location = new System.Drawing.Point(27, 138);
            this.pdfDocumentViewer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pdfDocumentViewer.MultiPagesThreshold = 60;
            this.pdfDocumentViewer.Name = "pdfDocumentViewer";
            this.pdfDocumentViewer.Size = new System.Drawing.Size(1664, 786);
            this.pdfDocumentViewer.TabIndex = 118;
            this.pdfDocumentViewer.Text = "pdfDocumentViewer1";
            this.pdfDocumentViewer.Threshold = 60;
            this.pdfDocumentViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1712, 54);
            this.pTitle.TabIndex = 119;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(25, 14);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(100, 27);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "プレビュー";
            // 
            // frmRegisterCompleteNotificationPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 937);
            this.Controls.Add(this.pTitle);
            this.Controls.Add(this.pdfDocumentViewer);
            this.Controls.Add(this.pdfDocumentThumbnail1);
            this.Controls.Add(this.btnCreateMail);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1727, 974);
            this.Name = "frmRegisterCompleteNotificationPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPreviewScreen_FormClosing);
            this.Load += new System.EventHandler(this.FrmPreviewScreen_Load);
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateMail;
        private System.Windows.Forms.Button btnBack;
        private Spire.PdfViewer.Forms.PdfThumbnails.PdfDocumentThumbnail pdfDocumentThumbnail1;
        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocumentViewer;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
    }
}