﻿using AmigoPaperWorkProcessSystem.Controllers;
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
        private List<Validate> Insertable = new List<Validate>{
            new Validate{ Name = "colAUTO_INDEX_ID", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial ="サプライヤ", Max = 10, },
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = true, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = false, Require = false, Initial = "0", Max = 100, Min=0},
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "*" , Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.DATE_RANGE, Edit=true, Require = false, Max = 16, Min = 16 , Data1="colPASSWORD_SET_DATE", Data2="colPASSWORD_EXPIRATION_DATE"},
            new Validate{ Name = "colCOMPANY_NO", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 },
            new Validate{ Name = "colCOMPANY_BOX",Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 }
        };

        private List<Validate> Copyable = new List<Validate>{
            new Validate{ Name = "colAUTO_INDEX_ID", Type = Utility.DataType.TEXT, Edit = false, Require = false, Initial ="copy", Max = 10, },
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Initial ="copy", Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = true, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = false, Require = false, Initial = "0", Max = 100, Min=0 },
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Initial="copy", Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "*" , Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 },
            new Validate{ Name = "colCOMPANY_NO", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 },
            new Validate{ Name = "colCOMPANY_BOX",Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 }
        };

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = false, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true,Max = 100, Min=0},
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Initial="copy", Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=true, Require=false, Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 }
        };

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

        #region Back Button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Previous Month
        private void btnPreMonthDiff_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Next Month
        private void btnNextMonthDiff_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}