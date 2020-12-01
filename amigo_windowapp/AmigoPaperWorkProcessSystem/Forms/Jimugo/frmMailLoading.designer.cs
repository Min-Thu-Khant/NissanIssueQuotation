namespace AmigoPaperWorkProcessSystem.Jimugo
{
    partial class frmMailLoading
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
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
<<<<<<< HEAD
            this.lblMessage = new System.Windows.Forms.Label();
=======
            this.lblMailMsg = new System.Windows.Forms.Label();
>>>>>>> 358b84bbf60ffb754b125476bf7c2d5a50d88e82
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(20, 18);
            this.metroProgressSpinner1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(45, 46);
            this.metroProgressSpinner1.Speed = 3F;
            this.metroProgressSpinner1.TabIndex = 0;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 35;
            // 
<<<<<<< HEAD
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(98, 31);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(132, 20);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "メール送信中です。\r\n";
=======
            // lblMailMsg
            // 
            this.lblMailMsg.AutoSize = true;
            this.lblMailMsg.Location = new System.Drawing.Point(65, 20);
            this.lblMailMsg.Name = "lblMailMsg";
            this.lblMailMsg.Size = new System.Drawing.Size(99, 13);
            this.lblMailMsg.TabIndex = 1;
            this.lblMailMsg.Text = "メール送信中です。\r\n";
>>>>>>> 358b84bbf60ffb754b125476bf7c2d5a50d88e82
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(255, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 52);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる\r\n";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 60);
            this.panel1.TabIndex = 3;
            // 
            // frmMailLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(372, 142);
            this.Controls.Add(this.panel1);
<<<<<<< HEAD
            this.Controls.Add(this.lblMessage);
=======
            this.Controls.Add(this.lblMailMsg);
>>>>>>> 358b84bbf60ffb754b125476bf7c2d5a50d88e82
            this.Controls.Add(this.metroProgressSpinner1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMailLoading";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMailLoading_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
<<<<<<< HEAD
        private System.Windows.Forms.Label lblMessage;
=======
        private System.Windows.Forms.Label lblMailMsg;
>>>>>>> 358b84bbf60ffb754b125476bf7c2d5a50d88e82
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}