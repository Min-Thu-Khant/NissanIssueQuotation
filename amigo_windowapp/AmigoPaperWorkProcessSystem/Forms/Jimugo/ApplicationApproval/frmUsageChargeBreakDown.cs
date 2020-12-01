using AmigoPaperWorkProcessSystem.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.ApplicationApproval
{
    public partial class frmUsageChargeBreakDown : Form
    {
        #region Declare
        private DataTable dtCurrent;
        private DataTable dtChange;
        #endregion

        #region Constructor
        public frmUsageChargeBreakDown()
        {
            InitializeComponent();
        }

        public frmUsageChargeBreakDown(DataTable dtCurrent, DataTable dtChange): this()
        {
            this.dtCurrent = dtCurrent;
            this.dtChange = dtChange;
        }
        #endregion

        #region FormLoad
        private void FrmUsageChargeBreakDown_Load(object sender, EventArgs e)
        {
            //assign data
            this.dgvCurrent.DataSource = this.dtCurrent;
            this.dgvChange.DataSource = this.dtChange;

            //currrent total
            CalculateTotal(dgvCurrent, dgvCurrentTotal);

            //change total
            CalculateTotal(dgvChange, dgvChangeTotal);

            //adjust current table
            Utility.DoubleBuffered(dgvCurrent, true);
            AdjustTables(dgvCurrent, 40);
            dgvCurrent.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCurrent.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //adjust current total table
            AdjustTables(dgvCurrentTotal, 20);

            //adjust change table
            Utility.DoubleBuffered(dgvChange, true);
            AdjustTables(dgvChange, 40);
            dgvChange.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChange.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //adjust change total table
            AdjustTables(dgvChangeTotal, 20);

        }
        #endregion

        #region AdjustTables
        private void AdjustTables(DataGridView dgv, int width)
        {
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            dgv.ColumnHeadersHeight = width;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        #endregion

        #region CalculateTotal
        private void CalculateTotal(DataGridView dgv, DataGridView dgvTotal)
        {
            
            int current_initial = 0;
            int current_monthly = 0;
            int current_yearly = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                current_initial += int.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                current_monthly += int.Parse(dgv.Rows[i].Cells[7].Value.ToString());
                current_yearly += int.Parse(dgv.Rows[i].Cells[10].Value.ToString());
            }
            dgvTotal.Rows[0].Cells[0].Value = current_initial;
            dgvTotal.Rows[0].Cells[1].Value = current_monthly;
            dgvTotal.Rows[0].Cells[2].Value = current_yearly;
        }
        #endregion

        #region DrawColumnHeaders

        private void InitialCost_Header(PaintEventArgs e, object sender, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, (DataGridView)sender);
        }

        private void MonthlyUsage_Header(PaintEventArgs e, object sender, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, (DataGridView)sender);
        }
        private void YearlyUsage_Header(PaintEventArgs e, object sender, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, (DataGridView)sender);
        }

        private void DgvCurrent_Paint(object sender, PaintEventArgs e)
        {
            InitialCost_Header(e, sender, 2, 3, "初期費用");
            MonthlyUsage_Header(e, sender, 5, 3, "月額利用料");
            YearlyUsage_Header(e, sender, 8, 3, "年額利用料");
        }

        private void DgvList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //to trigger repaint 
            DataGridView dtg = (DataGridView)sender;
            dtg.Invalidate();
        }

        private void DgvList_Scroll(object sender, ScrollEventArgs e)
        {
            //to trigger repaint 
            //only update on HorizontalScroll Scroll
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                DataGridView dtg = (DataGridView)sender;
                dtg.Invalidate();
            }
        }

        #endregion

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
