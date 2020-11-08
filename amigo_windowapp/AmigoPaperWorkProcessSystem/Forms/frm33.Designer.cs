namespace AmigoPaperWorkProcessSystem.Forms
{
    partial class frm33
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNoOfDeposit = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btnCreateCustomer = new MetroFramework.Controls.MetroButton();
            this.btnMoveToAmigo = new MetroFramework.Controls.MetroButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoOfDeposit
            // 
            this.lblNoOfDeposit.AutoSize = true;
            this.lblNoOfDeposit.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblNoOfDeposit.Location = new System.Drawing.Point(497, 86);
            this.lblNoOfDeposit.Name = "lblNoOfDeposit";
            this.lblNoOfDeposit.Size = new System.Drawing.Size(0, 0);
            this.lblNoOfDeposit.TabIndex = 15;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(419, 86);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(72, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "入金件数 :";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTime.Location = new System.Drawing.Point(306, 86);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 0);
            this.lblTime.TabIndex = 13;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(228, 86);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "取込時間 :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(99, 86);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 0);
            this.lblDate.TabIndex = 11;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(35, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(58, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "取込日 :";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1221, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 28);
            this.btnBack.TabIndex = 606;
            this.btnBack.Text = "戻る";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click_1);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCustomer.Location = new System.Drawing.Point(940, 82);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(167, 28);
            this.btnCreateCustomer.TabIndex = 607;
            this.btnCreateCustomer.Text = "顧客マスタ口座登録";
            this.btnCreateCustomer.UseSelectable = true;
            this.btnCreateCustomer.Click += new System.EventHandler(this.BtnCreateCustomer_Click);
            // 
            // btnMoveToAmigo
            // 
            this.btnMoveToAmigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveToAmigo.Location = new System.Drawing.Point(1115, 82);
            this.btnMoveToAmigo.Name = "btnMoveToAmigo";
            this.btnMoveToAmigo.Size = new System.Drawing.Size(167, 28);
            this.btnMoveToAmigo.TabIndex = 608;
            this.btnMoveToAmigo.Text = "Amigoデータ移動";
            this.btnMoveToAmigo.UseSelectable = true;
            this.btnMoveToAmigo.Click += new System.EventHandler(this.BtnMoveToAmigo_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colNo,
            this.CUSTOMER_NAME,
            this.colAmt});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(20, 129);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 10;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1262, 524);
            this.dgvList.TabIndex = 609;
            this.dgvList.TabStop = false;
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "SEQ_NO";
            this.colNo.HeaderText = "Sequence No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Visible = false;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "銀行口座名";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            // 
            // colAmt
            // 
            this.colAmt.DataPropertyName = "DEPOSIT_AMOUNT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colAmt.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmt.HeaderText = "振込金額";
            this.colAmt.Name = "colAmt";
            this.colAmt.ReadOnly = true;
            // 
            // frm33
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 670);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnMoveToAmigo);
            this.Controls.Add(this.btnCreateCustomer);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblNoOfDeposit);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frm33";
            this.Resizable = false;
            this.Text = "3-3. Amigo外データ確認";
            this.Load += new System.EventHandler(this.Frm33_Load);
            this.SizeChanged += new System.EventHandler(this.Frm33_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblNoOfDeposit;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel lblTime;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroButton btnCreateCustomer;
        private MetroFramework.Controls.MetroButton btnMoveToAmigo;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt;
    }
}