using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using AmigoPaperWorkProcessSystem.Jimugo;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class FrmMonthlySaleAggregationList : Form
    {

        #region Declare

        private string strPrivious;
        private string strCurrent;
        private string strNext;
        private UIUtility uIUtility;

        private string[] dummyColumns = {
            "TotalAmount",
            "ReduceSales",
            "ReducePlanDeposit",
            "ReduceAcutualDeposit",
            "CurrentSales",
            "CureentPlanDeposit",
            "CurrentAcutualDeposit",
            "PlusSales",
            "PlusPlanDeposit",
            "PlusAcutualDeposit"

        };

        private string[] alignBottoms = {
            "売上",
            "入金予定",
            "入金実績",
            "売上2",
            "入金予定2",
            "入金実績2",
            "売上3",
            "入金予定3",
            "入金実績3",

        };


        #endregion

        #region Properties
        public string programID { get; set; }
        public string programName { get; set; }
        #endregion


        #region Constructors
        public FrmMonthlySaleAggregationList()
        {
            InitializeComponent();
        }


        public FrmMonthlySaleAggregationList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }

        #endregion

        #region FormLoad
        private void FrmMonthlySaleAggregationList_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;
            this.Text = "[" + programID + "] " + programName;
            txtDate.Text = DateTime.Now.ToString("yyyy/MM");

            //utility
            uIUtility = new UIUtility(dgvList, null, null, null, dummyColumns);
            uIUtility.DummyTable();// add dummy table to merge columns
            AlignBottomHeaders();
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;
            try
            {

                this.Font = Properties.Settings.Default.jimugoFont;
            }
            catch (Exception)
            {
            }
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.WindowState = FormWindowState.Maximized;

            BindGrid();

        }
        #endregion

        #region Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                string strDate;
                strDate = txtDate.Text.Trim();
                if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtDate.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 7))
                {
                    return;
                }
                if (!string.IsNullOrEmpty(strDate))
                {
                    DateTime dtDate = new DateTime();
                    dtDate = Convert.ToDateTime(strDate);

                    string strDateReduce = dtDate.AddMonths(-1).ToString(" M ");
                    string strDateCurrent = dtDate.ToString(" M ");
                    string strDatePlus = dtDate.AddMonths(1).ToString(" M ");
                    strPrivious = strDateReduce.Trim() + "月";
                    strCurrent = strDateCurrent + "月";
                    strNext = strDatePlus + "月";
                }
                FrmMonthlySaleAggregationController oController = new FrmMonthlySaleAggregationController();
                Thread datathread = new Thread(new ThreadStart(ShowGridViewLoading));
                datathread.Start();
                //
                DataTable dt = oController.GetMonthlySaleAggregationList(strDate);
                if (dt.Rows.Count > 0)
                {
                    uIUtility.dtList = dt;
                    dgvList.DataSource = uIUtility.dtList;

                }
                else
                {
                    //clear data except headers
                    uIUtility.ClearDataGrid();
                }
                Thread.Sleep(1000);
                //close mail dialog
                datathread.Abort();

            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Privious_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }


        private void Add_Current_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Next_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Privious_Header(e, 1, 3, strPrivious);
            Add_Current_Header(e, 4, 3, strCurrent);
            Add_Next_Header(e, 7, 3, strNext);

        }

        private void DgvList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //to trigger repaint 
            this.dgvList.Invalidate();
        }

        private void DgvList_Scroll(object sender, ScrollEventArgs e)
        {
            //to trigger repaint 
            //only update on HorizontalScroll Scroll
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.dgvList.Invalidate();
            }
        }



        #endregion

        #region AlignBottomHeaders
        private void AlignBottomHeaders()
        {
            foreach (string item in alignBottoms)
            {
                dgvList.Columns[item].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
        }
        #endregion

        #region ShowGridViewLoading
        private void ShowGridViewLoading()
        {
            try
            {
                Application.Run(new frmMailLoading(JimugoMessages.I000ZZ023));
            }
            catch (ThreadAbortException)
            {

            }
        }
        #endregion

        #region CellFormatting
        private void DgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dgvList.Rows[4].DefaultCellStyle.BackColor = Color.DimGray;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Back Button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Previous Month
        private void btnPreMonthDiff_Click(object sender, EventArgs e)
        {
            if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtDate.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 7))
            {
                return;
            }
            frmMonthlySaleComparisonList frm = new frmMonthlySaleComparisonList("CTG020", "月次売上比較 Monthly sales comparison", "Previous", txtDate.Text.Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        #endregion

        #region Next Month
        private void btnNextMonthDiff_Click(object sender, EventArgs e)
        {
            if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtDate.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 7))
            {
                return;
            }
            frmMonthlySaleComparisonList frm = new frmMonthlySaleComparisonList("CTG020", "月次売上比較 Monthly sales comparison", "Next", txtDate.Text.Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        #endregion

    }
}
