namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frmMenu
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
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.txtPwd = new MetroFramework.Controls.MetroTextBox();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn3_1 = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn3_6 = new MetroFramework.Controls.MetroButton();
            this.btn3_5 = new MetroFramework.Controls.MetroButton();
            this.btn3_4 = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn3_7 = new MetroFramework.Controls.MetroButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn3_8 = new MetroFramework.Controls.MetroButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.prgStatus = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.btn3_B = new MetroFramework.Controls.MetroButton();
            this.btn3_A = new MetroFramework.Controls.MetroButton();
            this.tmr3A = new System.Windows.Forms.Timer(this.components);
            this.tmr3B = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(209, 2);
            this.txtID.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(38, 88);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.PromptText = "Please Enter User ID";
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(235, 28);
            this.txtID.TabIndex = 1;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMark = "Please Enter User ID";
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.txtPwd.CustomButton.Image = null;
            this.txtPwd.CustomButton.Location = new System.Drawing.Point(209, 2);
            this.txtPwd.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.CustomButton.Name = "";
            this.txtPwd.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPwd.CustomButton.TabIndex = 1;
            this.txtPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPwd.CustomButton.UseSelectable = true;
            this.txtPwd.CustomButton.Visible = false;
            this.txtPwd.Lines = new string[0];
            this.txtPwd.Location = new System.Drawing.Point(287, 88);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.MaxLength = 32767;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.PromptText = "Please Enter Password";
            this.txtPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPwd.SelectedText = "";
            this.txtPwd.SelectionLength = 0;
            this.txtPwd.SelectionStart = 0;
            this.txtPwd.ShortcutsEnabled = true;
            this.txtPwd.Size = new System.Drawing.Size(235, 28);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.UseSelectable = true;
            this.txtPwd.WaterMark = "Please Enter Password";
            this.txtPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.Location = new System.Drawing.Point(556, 88);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 28);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(686, 88);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1926, 17);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "戻る";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btn3_1);
            this.groupBox1.Location = new System.Drawing.Point(22, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 245);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "振込情報確認";
            // 
            // btn3_1
            // 
            this.btn3_1.Location = new System.Drawing.Point(49, 52);
            this.btn3_1.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_1.Name = "btn3_1";
            this.btn3_1.Size = new System.Drawing.Size(300, 36);
            this.btn3_1.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_1.TabIndex = 6;
            this.btn3_1.Text = "3-1. 銀行振込情報取込結果確認";
            this.btn3_1.UseSelectable = true;
            this.btn3_1.Click += new System.EventHandler(this.Btn3_1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btn3_6);
            this.groupBox2.Controls.Add(this.btn3_5);
            this.groupBox2.Controls.Add(this.btn3_4);
            this.groupBox2.Location = new System.Drawing.Point(452, 153);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(400, 245);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "引当情報確認";
            // 
            // btn3_6
            // 
            this.btn3_6.Location = new System.Drawing.Point(54, 162);
            this.btn3_6.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_6.Name = "btn3_6";
            this.btn3_6.Size = new System.Drawing.Size(300, 36);
            this.btn3_6.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_6.TabIndex = 11;
            this.btn3_6.Text = "3-6. 請求書不一致確認";
            this.btn3_6.UseSelectable = true;
            this.btn3_6.Click += new System.EventHandler(this.Btn3_6_Click);
            // 
            // btn3_5
            // 
            this.btn3_5.Location = new System.Drawing.Point(54, 107);
            this.btn3_5.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_5.Name = "btn3_5";
            this.btn3_5.Size = new System.Drawing.Size(300, 36);
            this.btn3_5.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_5.TabIndex = 10;
            this.btn3_5.Text = "3-5. 照合結果明細";
            this.btn3_5.UseSelectable = true;
            this.btn3_5.Click += new System.EventHandler(this.Btn3_5_Click);
            // 
            // btn3_4
            // 
            this.btn3_4.Location = new System.Drawing.Point(54, 52);
            this.btn3_4.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_4.Name = "btn3_4";
            this.btn3_4.Size = new System.Drawing.Size(296, 36);
            this.btn3_4.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_4.TabIndex = 9;
            this.btn3_4.Text = "3-4. 照合結果確認";
            this.btn3_4.UseSelectable = true;
            this.btn3_4.Click += new System.EventHandler(this.Btn3_4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btn3_7);
            this.groupBox3.Location = new System.Drawing.Point(879, 153);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(400, 245);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入金予定";
            // 
            // btn3_7
            // 
            this.btn3_7.Location = new System.Drawing.Point(52, 52);
            this.btn3_7.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_7.Name = "btn3_7";
            this.btn3_7.Size = new System.Drawing.Size(300, 36);
            this.btn3_7.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_7.TabIndex = 12;
            this.btn3_7.Text = "3-7. 入金予定実績";
            this.btn3_7.UseSelectable = true;
            this.btn3_7.Click += new System.EventHandler(this.Btn3_7_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.btn3_8);
            this.groupBox4.Location = new System.Drawing.Point(22, 426);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(400, 180);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "諸元管理";
            // 
            // btn3_8
            // 
            this.btn3_8.Location = new System.Drawing.Point(49, 52);
            this.btn3_8.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_8.Name = "btn3_8";
            this.btn3_8.Size = new System.Drawing.Size(300, 36);
            this.btn3_8.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_8.TabIndex = 13;
            this.btn3_8.Text = "3-8. 顧客マスタ口座登録";
            this.btn3_8.UseSelectable = true;
            this.btn3_8.Click += new System.EventHandler(this.Btn3_8_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.prgStatus);
            this.groupBox5.Controls.Add(this.lblStatus);
            this.groupBox5.Controls.Add(this.btn3_B);
            this.groupBox5.Controls.Add(this.btn3_A);
            this.groupBox5.Location = new System.Drawing.Point(452, 426);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(827, 180);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "バッチ処理起動";
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(437, 52);
            this.prgStatus.Margin = new System.Windows.Forms.Padding(4);
            this.prgStatus.Maximum = 100;
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(40, 37);
            this.prgStatus.Speed = 3F;
            this.prgStatus.Style = MetroFramework.MetroColorStyle.Green;
            this.prgStatus.TabIndex = 4;
            this.prgStatus.UseSelectable = true;
            this.prgStatus.Value = 24;
            this.prgStatus.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(485, 58);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(213, 19);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "2020/02/04 15:35 バッチ処理起動中";
            this.lblStatus.Visible = false;
            // 
            // btn3_B
            // 
            this.btn3_B.Location = new System.Drawing.Point(54, 107);
            this.btn3_B.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_B.Name = "btn3_B";
            this.btn3_B.Size = new System.Drawing.Size(300, 36);
            this.btn3_B.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_B.TabIndex = 15;
            this.btn3_B.Text = "3-B. 突合せ処理起動";
            this.btn3_B.UseSelectable = true;
            this.btn3_B.Click += new System.EventHandler(this.Btn3_B_Click);
            // 
            // btn3_A
            // 
            this.btn3_A.Location = new System.Drawing.Point(54, 52);
            this.btn3_A.Margin = new System.Windows.Forms.Padding(4);
            this.btn3_A.Name = "btn3_A";
            this.btn3_A.Size = new System.Drawing.Size(300, 36);
            this.btn3_A.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btn3_A.TabIndex = 14;
            this.btn3_A.Text = "3-A. 銀行振込情報取込処理起動";
            this.btn3_A.UseSelectable = true;
            this.btn3_A.Click += new System.EventHandler(this.Btn3_A_Click);
            // 
            // tmr3A
            // 
            this.tmr3A.Interval = 10000;
            this.tmr3A.Tick += new System.EventHandler(this.Tmr3A_Tick);
            // 
            // tmr3B
            // 
            this.tmr3B.Interval = 10000;
            this.tmr3B.Tick += new System.EventHandler(this.Tmr3B_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1300, 640);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(12, 12);
            this.Name = "frmMenu";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "3. 入金処理メニュー";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroTextBox txtPwd;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btn3_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton btn3_6;
        private MetroFramework.Controls.MetroButton btn3_5;
        private MetroFramework.Controls.MetroButton btn3_4;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroButton btn3_7;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroButton btn3_8;
        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroButton btn3_B;
        private MetroFramework.Controls.MetroButton btn3_A;
        private MetroFramework.Controls.MetroProgressSpinner prgStatus;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.Timer tmr3A;
        private System.Windows.Forms.Timer tmr3B;
    }
}