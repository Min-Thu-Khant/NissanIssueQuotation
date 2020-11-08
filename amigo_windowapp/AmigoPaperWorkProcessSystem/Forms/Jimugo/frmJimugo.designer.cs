namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class frmJimugo
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
            this.pTitle = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.txtPwd = new MetroFramework.Controls.MetroTextBox();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(764, 50);
            this.pTitle.TabIndex = 0;
            // 
            // lblMenu
            // 
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(14, 10);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(162, 32);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Jimugo - Menu";
            // 
            // txtID
            // 
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(206, 2);
            this.txtID.CustomButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(15, 69);
            this.txtID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.PromptText = "Please Enter User ID";
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(234, 30);
            this.txtID.TabIndex = 5;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMark = "Please Enter User ID";
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPwd
            // 
            // 
            // 
            // 
            this.txtPwd.CustomButton.Image = null;
            this.txtPwd.CustomButton.Location = new System.Drawing.Point(206, 2);
            this.txtPwd.CustomButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPwd.CustomButton.Name = "";
            this.txtPwd.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPwd.CustomButton.TabIndex = 1;
            this.txtPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPwd.CustomButton.UseSelectable = true;
            this.txtPwd.CustomButton.Visible = false;
            this.txtPwd.Lines = new string[0];
            this.txtPwd.Location = new System.Drawing.Point(259, 69);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPwd.MaxLength = 32767;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.PromptText = "Please Enter Password";
            this.txtPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPwd.SelectedText = "";
            this.txtPwd.SelectionLength = 0;
            this.txtPwd.SelectionStart = 0;
            this.txtPwd.ShortcutsEnabled = true;
            this.txtPwd.Size = new System.Drawing.Size(234, 30);
            this.txtPwd.TabIndex = 6;
            this.txtPwd.UseSelectable = true;
            this.txtPwd.WaterMark = "Please Enter Password";
            this.txtPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(629, 69);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(503, 69);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(117, 30);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // trvMenu
            // 
            this.trvMenu.Location = new System.Drawing.Point(14, 116);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.Size = new System.Drawing.Size(731, 333);
            this.trvMenu.TabIndex = 9;
            this.trvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvMenu_NodeMouseDoubleClick);
            // 
            // frmJimugo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.trvMenu);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(780, 500);
            this.MinimumSize = new System.Drawing.Size(780, 500);
            this.Name = "frmJimugo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmJimugo_Load);
            this.pTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label lblMenu;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroTextBox txtPwd;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnLogin;
        private System.Windows.Forms.TreeView trvMenu;
    }
}