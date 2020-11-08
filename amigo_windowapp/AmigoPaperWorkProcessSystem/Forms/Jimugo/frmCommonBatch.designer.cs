namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class frmCommonBatch
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
            this.components = new System.ComponentModel.Container();
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnRun = new MetroFramework.Controls.MetroButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrBatch = new System.Windows.Forms.Timer(this.components);
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(534, 51);
            this.pTitle.TabIndex = 1;
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
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(19, 71);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(87, 25);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "実行";
            this.btnRun.UseSelectable = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(149, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "xxxxxx";
            this.lblStatus.Visible = false;
            // 
            // tmrBatch
            // 
            this.tmrBatch.Interval = 10000;
            this.tmrBatch.Tick += new System.EventHandler(this.TmrBatch_Tick);
            // 
            // frmCommonBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 111);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 150);
            this.Name = "frmCommonBatch";
            this.Load += new System.EventHandler(this.FrmCommonBatch_Load);
            this.pTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private MetroFramework.Controls.MetroButton btnRun;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrBatch;
    }
}