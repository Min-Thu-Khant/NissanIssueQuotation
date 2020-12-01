using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmCustomerMasterPopup : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string COMPANY_NO_BOX = ""; //AJ-0001-01
        private string REQ_SEQ = "";  //1

        private string[] dummyColumns = {
            "colNo",
            "colCONTRACT_CODE",
            "colCONTRACT_NAME",
            "colINITIAL_UNIT_PRICE",
            "colINITIAL_QUANTITY",
            "colINITIAL_AMOUNT",
            "colMONTHLY_UNIT_PRICE",
            "colMONTHLY_QUANTITY",
            "colMONTHLY_AMOUNT",
            "colYEAR_UNIT_PRICE",
            "colYEAR_QUANTITY",
            "colYEAR_AMOUNT"
        };
        #endregion

        #region Constructors
        public frmCustomerMasterPopup()
        {
            InitializeComponent();
        }

        public frmCustomerMasterPopup(string COMPANY_NO_BOX, string REQ_SEQ ) : this()
        {
            this.COMPANY_NO_BOX = COMPANY_NO_BOX;
            this.REQ_SEQ = REQ_SEQ;
        }
        #endregion

        #region FormLoad
        private void FrmCustomerMasterPopup_Load(object sender, EventArgs e)
        {
            SetDefaultColumnWidths();

            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.dgvList1.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList1.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.WindowState = FormWindowState.Maximized;
            this.dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgvList.AllowUserToResizeRows = false;

            uIUtility = new UIUtility(dgvList1,null,null,null,dummyColumns);
            uIUtility.DummyTable(60);// add dummy table to merge columns

            BindGrid();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            //uIUtility.ResetCheckBoxSize();
            dgvList1.Columns["colNO"].Width = 35;
            dgvList1.Columns["colCONTRACT_CODE"].Width = 148;
            dgvList1.Columns["colCONTRACT_CONTENT"].Width = 148;
            dgvList1.Columns["colUNIT_PRICE"].Width = 102;
            dgvList1.Columns["colQUANTITY"].Width = 102;
            dgvList1.Columns["colTOTAL"].Width = 102;
            dgvList1.Columns["colUnitPrice1"].Width = 102;
            dgvList1.Columns["colQuantity1"].Width = 102;
            dgvList1.Columns["colTOTAL1"].Width = 102;
            dgvList1.Columns["colUnitPrice2"].Width = 102;
            dgvList1.Columns["colQuantity2"].Width = 102;
            dgvList1.Columns["colTOTAL2"].Width = 102;
        }
        #endregion

        #region DrawColumnHeaders

        private void Initial_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList1);
            dgvList1.Columns["colUNIT_PRICE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colQUANTITY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colTOTAL"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void Monthly_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList1);
            dgvList1.Columns["colUnitPrice1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colQuantity1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colTotal1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void Year_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList1);
            dgvList1.Columns["colUnitPrice2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colQuantity2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList1.Columns["colTotal2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void DgvList1_Paint(object sender, PaintEventArgs e)
        {
            Initial_Header(e, 3, 3, "初期費用");
            Monthly_Header(e, 6, 3, "月額利用料");
            Year_Header(e, 9, 3, "年額利用料");
        }
        
        private void DgvList1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //to trigger repaint 
            this.dgvList1.Invalidate();
        }

        private void DgvList1_Scroll(object sender, ScrollEventArgs e)
        {
            //to trigger repaint 
            //only update on HorizontalScroll Scroll
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.dgvList1.Invalidate();
            }
        }

        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                frmCustomerMasterMaintenanceController oController = new frmCustomerMasterMaintenanceController();
                DataSet ds = oController.GetPopupScreenData(COMPANY_NO_BOX, REQ_SEQ);
                
                
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];

                lblCompanyNoBox.Text = COMPANY_NO_BOX;
                dgvList.DataSource = dt1;
                dgvList1.DataSource = dt2;
                dgvList.ScrollBars = ScrollBars.None;
            }
            catch (System.TimeoutException ex)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException ex)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CellFormatting
        private void DgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dgvList.Rows[1].DefaultCellStyle.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region OkButton
        private void BtnModify_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
