namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class frmCustomerMasterPopup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList1 = new System.Windows.Forms.DataGridView();
            this.colNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCONTRACT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCONTRACT_CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUNIT_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCompanyNoBox = new System.Windows.Forms.Label();
            this.lblYearCost = new System.Windows.Forms.Label();
            this.lblMonthlyCost = new System.Windows.Forms.Label();
            this.lblInitialCost = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colFirst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThird = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList1
            // 
            this.dgvList1.AllowUserToAddRows = false;
            this.dgvList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNO,
            this.colCONTRACT_CODE,
            this.colCONTRACT_CONTENT,
            this.colUNIT_PRICE,
            this.colQUANTITY,
            this.colTOTAL,
            this.colUnitPrice1,
            this.colQuantity1,
            this.colTotal1,
            this.colUnitPrice2,
            this.colQuantity2,
            this.colTotal2});
            this.dgvList1.EnableHeadersVisualStyles = false;
            this.dgvList1.Location = new System.Drawing.Point(19, 167);
            this.dgvList1.Margin = new System.Windows.Forms.Padding(2);
            this.dgvList1.Name = "dgvList1";
            this.dgvList1.RowHeadersVisible = false;
            this.dgvList1.RowTemplate.Height = 24;
            this.dgvList1.Size = new System.Drawing.Size(1245, 245);
            this.dgvList1.TabIndex = 41;
            this.dgvList1.VirtualMode = true;
            this.dgvList1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList1_ColumnWidthChanged);
            this.dgvList1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList1_Scroll);
            this.dgvList1.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList1_Paint);
            // 
            // colNO
            // 
            this.colNO.DataPropertyName = "No";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNO.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNO.HeaderText = "NO";
            this.colNO.Name = "colNO";
            this.colNO.Width = 50;
            // 
            // colCONTRACT_CODE
            // 
            this.colCONTRACT_CODE.DataPropertyName = "CONTRACT_CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCONTRACT_CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCONTRACT_CODE.HeaderText = "契約コード";
            this.colCONTRACT_CODE.Name = "colCONTRACT_CODE";
            this.colCONTRACT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCONTRACT_CODE.Width = 150;
            // 
            // colCONTRACT_CONTENT
            // 
            this.colCONTRACT_CONTENT.DataPropertyName = "CONTRACT_NAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCONTRACT_CONTENT.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCONTRACT_CONTENT.HeaderText = "契約内容 ";
            this.colCONTRACT_CONTENT.Name = "colCONTRACT_CONTENT";
            this.colCONTRACT_CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCONTRACT_CONTENT.Width = 150;
            // 
            // colUNIT_PRICE
            // 
            this.colUNIT_PRICE.DataPropertyName = "INITIAL_UNIT_PRICE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colUNIT_PRICE.DefaultCellStyle = dataGridViewCellStyle4;
            this.colUNIT_PRICE.HeaderText = "単価";
            this.colUNIT_PRICE.Name = "colUNIT_PRICE";
            this.colUNIT_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQUANTITY
            // 
            this.colQUANTITY.DataPropertyName = "INITIAL_QUANTITY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colQUANTITY.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQUANTITY.HeaderText = "数量";
            this.colQUANTITY.Name = "colQUANTITY";
            this.colQUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTOTAL
            // 
            this.colTOTAL.DataPropertyName = "INITIAL_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.colTOTAL.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTOTAL.HeaderText = "合計";
            this.colTOTAL.Name = "colTOTAL";
            this.colTOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUnitPrice1
            // 
            this.colUnitPrice1.DataPropertyName = "MONTHLY_UNIT_PRICE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.colUnitPrice1.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUnitPrice1.HeaderText = "単価";
            this.colUnitPrice1.Name = "colUnitPrice1";
            this.colUnitPrice1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQuantity1
            // 
            this.colQuantity1.DataPropertyName = "MONTHLY_QUANTITY";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.colQuantity1.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQuantity1.HeaderText = "数量";
            this.colQuantity1.Name = "colQuantity1";
            this.colQuantity1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal1
            // 
            this.colTotal1.DataPropertyName = "MONTHLY_AMOUNT";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.colTotal1.DefaultCellStyle = dataGridViewCellStyle9;
            this.colTotal1.HeaderText = "合計";
            this.colTotal1.Name = "colTotal1";
            this.colTotal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUnitPrice2
            // 
            this.colUnitPrice2.DataPropertyName = "YEAR_UNIT_PRICE";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.colUnitPrice2.DefaultCellStyle = dataGridViewCellStyle10;
            this.colUnitPrice2.HeaderText = "単価";
            this.colUnitPrice2.Name = "colUnitPrice2";
            this.colUnitPrice2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQuantity2
            // 
            this.colQuantity2.DataPropertyName = "YEAR_QUANTITY";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.colQuantity2.DefaultCellStyle = dataGridViewCellStyle11;
            this.colQuantity2.HeaderText = "数量";
            this.colQuantity2.Name = "colQuantity2";
            this.colQuantity2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal2
            // 
            this.colTotal2.DataPropertyName = "YEAR_AMOUNT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.colTotal2.DefaultCellStyle = dataGridViewCellStyle12;
            this.colTotal2.HeaderText = "合計";
            this.colTotal2.Name = "colTotal2";
            this.colTotal2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(424, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 40;
            this.label3.Text = "年額利用料";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(278, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 39;
            this.label2.Text = "月額利用料";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(131, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "初期費用";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompanyNoBox
            // 
            this.lblCompanyNoBox.BackColor = System.Drawing.SystemColors.Control;
            this.lblCompanyNoBox.Location = new System.Drawing.Point(19, 22);
            this.lblCompanyNoBox.Name = "lblCompanyNoBox";
            this.lblCompanyNoBox.Size = new System.Drawing.Size(111, 22);
            this.lblCompanyNoBox.TabIndex = 37;
            this.lblCompanyNoBox.Text = "lblCompanyNoBox";
            this.lblCompanyNoBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYearCost
            // 
            this.lblYearCost.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblYearCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYearCost.Location = new System.Drawing.Point(20, 125);
            this.lblYearCost.Name = "lblYearCost";
            this.lblYearCost.Size = new System.Drawing.Size(112, 24);
            this.lblYearCost.TabIndex = 36;
            this.lblYearCost.Text = "差額";
            this.lblYearCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthlyCost
            // 
            this.lblMonthlyCost.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMonthlyCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonthlyCost.Location = new System.Drawing.Point(20, 101);
            this.lblMonthlyCost.Name = "lblMonthlyCost";
            this.lblMonthlyCost.Size = new System.Drawing.Size(112, 24);
            this.lblMonthlyCost.TabIndex = 35;
            this.lblMonthlyCost.Text = "特別値引き";
            this.lblMonthlyCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInitialCost
            // 
            this.lblInitialCost.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInitialCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInitialCost.Location = new System.Drawing.Point(20, 77);
            this.lblInitialCost.Name = "lblInitialCost";
            this.lblInitialCost.Size = new System.Drawing.Size(112, 24);
            this.lblInitialCost.TabIndex = 34;
            this.lblInitialCost.Text = "税抜き額";
            this.lblInitialCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFirst,
            this.colSecond,
            this.colThird});
            this.dgvList.Location = new System.Drawing.Point(131, 53);
            this.dgvList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.Size = new System.Drawing.Size(440, 96);
            this.dgvList.TabIndex = 33;
            this.dgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvList_CellFormatting);
            // 
            // colFirst
            // 
            this.colFirst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFirst.DataPropertyName = "COST";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.colFirst.DefaultCellStyle = dataGridViewCellStyle13;
            this.colFirst.HeaderText = "First";
            this.colFirst.Name = "colFirst";
            this.colFirst.ReadOnly = true;
            this.colFirst.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSecond
            // 
            this.colSecond.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSecond.DataPropertyName = "DISCOUNT";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.colSecond.DefaultCellStyle = dataGridViewCellStyle14;
            this.colSecond.HeaderText = "Second";
            this.colSecond.Name = "colSecond";
            this.colSecond.ReadOnly = true;
            this.colSecond.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colThird
            // 
            this.colThird.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThird.DataPropertyName = "DIFFERENT";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            this.colThird.DefaultCellStyle = dataGridViewCellStyle15;
            this.colThird.HeaderText = "Third";
            this.colThird.Name = "colThird";
            this.colThird.ReadOnly = true;
            this.colThird.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnModify
            // 
            this.btnModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModify.AutoSize = true;
            this.btnModify.Location = new System.Drawing.Point(573, 423);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 30);
            this.btnModify.TabIndex = 42;
            this.btnModify.Text = "OK";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // frmCustomerMasterPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 461);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dgvList1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCompanyNoBox);
            this.Controls.Add(this.lblYearCost);
            this.Controls.Add(this.lblMonthlyCost);
            this.Controls.Add(this.lblInitialCost);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "frmCustomerMasterPopup";
            this.Text = "内訳";
            this.Load += new System.EventHandler(this.FrmCustomerMasterPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompanyNoBox;
        private System.Windows.Forms.Label lblYearCost;
        private System.Windows.Forms.Label lblMonthlyCost;
        private System.Windows.Forms.Label lblInitialCost;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecond;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThird;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCONTRACT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCONTRACT_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUNIT_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal2;
    }
}