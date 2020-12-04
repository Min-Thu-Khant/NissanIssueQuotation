using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmMonthlySaleComparisonList : Form
    {
        #region Declare
        private UIUtility uIUtility;
        public string checkState;
        public string strYearMonth;


        private string[] dummyColumns = { };
        private string[] alignBottoms = {
            "No",
            "TYPE",
            "BILL_SUPPLIER_NAME",
            "UPDATE_CONTENT",
            "DIFF",
            "Server",
            "SERVERRIGHT",
            "BROWSERAUTO",
            "BROWSER",
            "PRODUCT",
            "PLAN_AMIGO_CAI",
            "PLAN_AMIGO_BIZ",
            "OP_BOX_SERVER",
            "OP_BOX_BROWSER",
            "OP_FLAT",
            "OP_CLIENT",
            "OP_BASIC_SERVICE",
            "OP_ADD_SERVICE",


        };
        private string[] cellFormating = {
            "TYPE",
            "DIFF",
            "Server",
            "SERVERRIGHT",
            "BROWSERAUTO",
            "BROWSER",
            "PRODUCT",
            "PLAN_AMIGO_CAI",
            "PLAN_AMIGO_BIZ",
            "OP_BOX_SERVER",
            "OP_BOX_BROWSER",
            "OP_FLAT",
            "OP_CLIENT",
            "OP_BASIC_SERVICE",
            "OP_ADD_SERVICE",


        };

        #endregion

        #region Properties
        public string programID { get; set; }
        public string programName { get; set; }

        #endregion

        #region Constructors
        public frmMonthlySaleComparisonList()
        {
            InitializeComponent();
        }

        public frmMonthlySaleComparisonList(string programID, string programName) : this()
        {

            this.programID = programID;
            this.programName = programName;

        }

        public frmMonthlySaleComparisonList(string programID, string programName, string checkState, string strYearMonth) : this()
        {

            this.programID = programID;
            this.programName = programName;
            this.checkState = checkState;
            this.strYearMonth = strYearMonth;
        }
        #endregion

        #region FormLoad
        private void frmMonthlySaleComparisonList_Load(object sender, EventArgs e)
        {

            lblMenu.Text = programName;
            this.Text = "[" + programID + "] " + programName;
            txtDate.Text = strYearMonth;

            //utility
            uIUtility = new UIUtility(dgvList, null, null, null, dummyColumns);
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
            AlignBottomHeaders();
            //uIUtility.ResetCheckBoxSize();//adjust checkbox sizes
            uIUtility.DummyTable(100);// add dummy table to merge columns
            PopulateDropdowns();
            uIUtility.MetaData.Offset = 0;
            uIUtility.MetaData.Limit = int.Parse(cboLimit.SelectedValue.ToString());

            //Theme
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

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                string strYYYYMM1, strYYYYMM2;
                DateTime dtDate = Convert.ToDateTime(txtDate.Text.Trim());
                string strDifference = "";
                if (checkState == "Previous")
                {
                    strYYYYMM1 = dtDate.ToString("yyMM");
                    strYYYYMM2 = dtDate.AddMonths(-1).ToString("yyMM");
                    strDifference = dtDate.AddMonths(-1).ToString("yyyyMM");
                }
                else
                {
                    strYYYYMM1 = dtDate.AddMonths(1).ToString("yyMM");
                    strYYYYMM2 = dtDate.ToString("yyMM");
                    strDifference = dtDate.AddMonths(1).ToString("yyyyMM");
                }
                lbldifference.Text = "次月売上比較：" + strDifference + "分差異";

                frmMonthlySaleComparisonListController oController = new frmMonthlySaleComparisonListController();

                DataTable dt = oController.GetMonthlySaleComparisonList(strYYYYMM1, strYYYYMM2, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
                if (dt.Rows.Count > 0)
                {
                    uIUtility.dtList = dt;
                    dgvList.DataSource = uIUtility.dtList;


                    //pagination
                    uIUtility.CalculatePaginationNew(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }
                else
                {
                    //clear data except headers
                    uIUtility.ClearDataGrid();
                    uIUtility.CalculatePaginationNew(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }

                uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);

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

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
        }

        #endregion

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Vertical text from column 0, or adjust below, if first column(s) to be skipped
            if (e.RowIndex == -1 && e.ColumnIndex >= 5)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Gray, 10, 2);
                e.Graphics.ResetTransform();
                e.Handled = true;


            }


        }
        #region AlignBottomHeaders
        private void AlignBottomHeaders()
        {
            foreach (string item in alignBottoms)
            {
                dgvList.Columns[item].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
        }
        #endregion
        #region CellFormating
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvList.Rows)
            {

                foreach (string item in cellFormating)
                {
                    if (!string.IsNullOrEmpty(row.Cells[item].Value.ToString()))
                    {
                        if (item == "TYPE")
                        {
                            if (row.Cells[item].Value.ToString() == "初期費" || row.Cells[item].Value.ToString() == "生産情報閲覧(初期費)")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            if (Convert.ToDecimal(row.Cells[item].Value) < 0)
                            {
                                row.Cells[item].Style.ForeColor = Color.Red;
                            }
                            if (item != "DIFF")
                            {
                                if (Convert.ToDecimal(row.Cells[item].Value) == 0)
                                {
                                    row.Cells[item].Value = "";
                                }
                            }

                        }

                    }

                }

            }



        }
        #endregion

        #region FirstButton
        private void BtnFirst_Click(object sender, EventArgs e)
        {

            uIUtility.MetaData.Offset = 0;
            BindGrid();

        }
        #endregion

        #region LastButton
        private void BtnLast_Click(object sender, EventArgs e)
        {

            uIUtility.MetaData.Offset = (int.Parse(lblTotalPages.Text.Replace("Pages", "").Trim()) - 1) * int.Parse(cboLimit.SelectedValue.ToString());
            BindGrid();


        }
        #endregion

        #region NextButton
        private void BtnNext_Click(object sender, EventArgs e)
        {

            uIUtility.MetaData.Offset += int.Parse(cboLimit.SelectedValue.ToString());
            BindGrid();

        }
        #endregion

        #region PreviousButton
        private void BtnPrev_Click(object sender, EventArgs e)
        {

            uIUtility.MetaData.Offset -= int.Parse(cboLimit.SelectedValue.ToString());
            BindGrid();

        }
        #endregion
        #region Back Button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
