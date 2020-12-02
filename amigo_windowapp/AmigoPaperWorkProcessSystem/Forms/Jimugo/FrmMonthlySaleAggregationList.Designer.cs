
namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    partial class FrmMonthlySaleAggregationList
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売上 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金予定 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金実績 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売上2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金予定2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金実績2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.売上3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金予定3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入金実績3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNextMonthDiff = new System.Windows.Forms.Button();
            this.btnPreMonthDiff = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pTitle = new System.Windows.Forms.Panel();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new AmigoPaperWorkProcessSystem.UserControls.DisplayItemLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TotalAmount,
            this.売上,
            this.入金予定,
            this.入金実績,
            this.売上2,
            this.入金予定2,
            this.入金実績2,
            this.売上3,
            this.入金予定3,
            this.入金実績3});
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(16, 165);
            this.dgvList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 62;
            this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.Size = new System.Drawing.Size(1250, 429);
            this.dgvList.TabIndex = 43;
            this.dgvList.TabStop = false;
            this.dgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvList_CellFormatting);
            this.dgvList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvList_ColumnWidthChanged);
            this.dgvList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvList_Scroll);
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.DgvList_Paint);
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalAmount.HeaderText = "";
            this.TotalAmount.MinimumWidth = 8;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalAmount.Width = 150;
            // 
            // 売上
            // 
            this.売上.DataPropertyName = "ReduceSales";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.売上.DefaultCellStyle = dataGridViewCellStyle2;
            this.売上.HeaderText = "売上";
            this.売上.MinimumWidth = 8;
            this.売上.Name = "売上";
            this.売上.ReadOnly = true;
            this.売上.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.売上.Width = 150;
            // 
            // 入金予定
            // 
            this.入金予定.DataPropertyName = "ReducePlanDeposit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.入金予定.DefaultCellStyle = dataGridViewCellStyle3;
            this.入金予定.HeaderText = "入金予定";
            this.入金予定.MinimumWidth = 8;
            this.入金予定.Name = "入金予定";
            this.入金予定.ReadOnly = true;
            this.入金予定.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金予定.Width = 150;
            // 
            // 入金実績
            // 
            this.入金実績.DataPropertyName = "ReduceAcutualDeposit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.入金実績.DefaultCellStyle = dataGridViewCellStyle4;
            this.入金実績.HeaderText = "入金実績";
            this.入金実績.MinimumWidth = 8;
            this.入金実績.Name = "入金実績";
            this.入金実績.ReadOnly = true;
            this.入金実績.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金実績.Width = 150;
            // 
            // 売上2
            // 
            this.売上2.DataPropertyName = "CurrentSales";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.売上2.DefaultCellStyle = dataGridViewCellStyle5;
            this.売上2.HeaderText = "売上";
            this.売上2.MinimumWidth = 8;
            this.売上2.Name = "売上2";
            this.売上2.ReadOnly = true;
            this.売上2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.売上2.Width = 150;
            // 
            // 入金予定2
            // 
            this.入金予定2.DataPropertyName = "CureentPlanDeposit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.入金予定2.DefaultCellStyle = dataGridViewCellStyle6;
            this.入金予定2.HeaderText = "入金予定";
            this.入金予定2.MinimumWidth = 8;
            this.入金予定2.Name = "入金予定2";
            this.入金予定2.ReadOnly = true;
            this.入金予定2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金予定2.Width = 150;
            // 
            // 入金実績2
            // 
            this.入金実績2.DataPropertyName = "CurrentAcutualDeposit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.入金実績2.DefaultCellStyle = dataGridViewCellStyle7;
            this.入金実績2.HeaderText = "入金実績";
            this.入金実績2.MinimumWidth = 8;
            this.入金実績2.Name = "入金実績2";
            this.入金実績2.ReadOnly = true;
            this.入金実績2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金実績2.Width = 150;
            // 
            // 売上3
            // 
            this.売上3.DataPropertyName = "PlusSales";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.売上3.DefaultCellStyle = dataGridViewCellStyle8;
            this.売上3.HeaderText = "売上";
            this.売上3.MinimumWidth = 8;
            this.売上3.Name = "売上3";
            this.売上3.ReadOnly = true;
            this.売上3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.売上3.Width = 150;
            // 
            // 入金予定3
            // 
            this.入金予定3.DataPropertyName = "PlusPlanDeposit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.入金予定3.DefaultCellStyle = dataGridViewCellStyle9;
            this.入金予定3.HeaderText = "入金予定";
            this.入金予定3.MinimumWidth = 8;
            this.入金予定3.Name = "入金予定3";
            this.入金予定3.ReadOnly = true;
            this.入金予定3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金予定3.Width = 150;
            // 
            // 入金実績3
            // 
            this.入金実績3.DataPropertyName = "PlusAcutualDeposit";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.入金実績3.DefaultCellStyle = dataGridViewCellStyle10;
            this.入金実績3.HeaderText = "入金実績";
            this.入金実績3.MinimumWidth = 8;
            this.入金実績3.Name = "入金実績3";
            this.入金実績3.ReadOnly = true;
            this.入金実績3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.入金実績3.Width = 150;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(16, 11);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(193, 32);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Jimugo - Menu";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(355, 71);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNextMonthDiff
            // 
            this.btnNextMonthDiff.Location = new System.Drawing.Point(242, 71);
            this.btnNextMonthDiff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNextMonthDiff.Name = "btnNextMonthDiff";
            this.btnNextMonthDiff.Size = new System.Drawing.Size(100, 30);
            this.btnNextMonthDiff.TabIndex = 4;
            this.btnNextMonthDiff.Text = "次月売上比較";
            this.btnNextMonthDiff.UseVisualStyleBackColor = true;
            this.btnNextMonthDiff.Click += new System.EventHandler(this.btnNextMonthDiff_Click);
            // 
            // btnPreMonthDiff
            // 
            this.btnPreMonthDiff.Location = new System.Drawing.Point(130, 71);
            this.btnPreMonthDiff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreMonthDiff.Name = "btnPreMonthDiff";
            this.btnPreMonthDiff.Size = new System.Drawing.Size(100, 30);
            this.btnPreMonthDiff.TabIndex = 3;
            this.btnPreMonthDiff.Text = "前月売上比較";
            this.btnPreMonthDiff.UseVisualStyleBackColor = true;
            this.btnPreMonthDiff.Click += new System.EventHandler(this.btnPreMonthDiff_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 71);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "集計";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pTitle
            // 
            this.pTitle.Controls.Add(this.lblMenu);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pTitle.Name = "pTitle";
            this.pTitle.Size = new System.Drawing.Size(1284, 50);
            this.pTitle.TabIndex = 25;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(76, 120);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(77, 28);
            this.txtDate.TabIndex = 45;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDate.LabelText = "締め年月";
            this.lblDate.Location = new System.Drawing.Point(17, 120);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(60, 21);
            this.lblDate.TabIndex = 44;
            // 
            // FrmMonthlySaleAggregationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNextMonthDiff);
            this.Controls.Add(this.btnPreMonthDiff);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pTitle);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMonthlySaleAggregationList";
            this.Load += new System.EventHandler(this.FrmMonthlySaleAggregationList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNextMonthDiff;
        private System.Windows.Forms.Button btnPreMonthDiff;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pTitle;
        private UserControls.DisplayItemLabel lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金予定;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金実績;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金予定2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金実績2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 売上3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金予定3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入金実績3;
    }
}