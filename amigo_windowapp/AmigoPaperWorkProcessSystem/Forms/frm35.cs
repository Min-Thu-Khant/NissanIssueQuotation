using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frm35 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        DateTime fromDate;
        DateTime toDate;
        string parameterFromDate="";
        string parameterToDate = "";
        DataTable dtCheckResult;
        #endregion

        #region Constructor
        public frm35()
        {
            InitializeComponent();

            setOptimalDimentions();
        }

        public frm35(string _fromDate, string _toDate)
           : this()
        {
            parameterFromDate = _fromDate;
            parameterToDate = _toDate;

            setOptimalDimentions();
        }
        #endregion

        #region BackButton
        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FormLoad
        private void Frm35_Load(object sender, EventArgs e)
        {
            //theme style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            DummyTable(); // add dummy table to merge columns

            txtFromDate.Text = parameterFromDate;
            txtToDate.Text = parameterToDate;

            //comes from menu
            if (txtFromDate.Text == "")
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }

            Utility.DoubleBuffered(dgvList, true);
        }
        #endregion

        #region setOptimalDimentions
        private void setOptimalDimentions()
        {
            this.Size = Properties.Settings.Default.DefaultDimentions;
        }
        #endregion

        #region DrawColumHeaders
        private void ResetHeader()
        {
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.ColumnHeadersHeight = 40;
            this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCheck"].Width = 25;

        }

        private void DummyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CUSTOMER_NAME_SHOW");
            dt.Columns.Add("DEPOSIT_AMOUNT_SHOW");
            dt.Columns.Add("BILL_TRANSFER_FEE");
            dt.Columns.Add("BILL_SUPPLIER_NAME");
            dt.Columns.Add("BILLING_MONTH");
            dt.Columns.Add("BILLING_CODE");
            dt.Columns.Add("BILL_PRICE");
            dt.Columns.Add("RESERVE_AMOUNT");
            dt.Columns.Add("DIFF_ALLOCATION_AMOUNT");
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("YEAR_MONTH");
            dt.Columns.Add("SEQ_NO");
            dt.Columns.Add("RESERVE_ID");
            dgvList.DataSource = dt;
            ResetHeader();
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_BnakTransferInfo_Header(e, 1, 2, "銀行振込情報");
            Add_Various_Expenses_Header(e, 3, 1, "諸経費");
            Add_InvoiceInformation_Header(e, 4, 4, "請求書情報");
            Add_Allocation_Header(e, 8, 2, "引当結果");
        }

        private void Add_BnakTransferInfo_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_Various_Expenses_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_InvoiceInformation_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_Allocation_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Merge_Header(PaintEventArgs e, int index, int count, string text)
        {
            try
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset = -5;
                int widthOffset = -2;
                int xOffset = 1;
                int yOffset = 4;

                //Index of Header column from where the merging will start.
                int columnIndex = index;

                //Number of Header columns to be merged.
                int columnCount = count;

                //Get the position of the Header Cell.
                Rectangle headerCellRectangle = dgvList.GetCellDisplayRectangle(columnIndex, -1, true);

                //X coordinate  of the merged Header Column.
                int xCord = headerCellRectangle.Location.X + xOffset;

                //Y coordinate  of the merged Header Column.
                int yCord = headerCellRectangle.Location.Y + yOffset;

                //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
                int all_column_width = 0;
                for (int i = 0; i < columnCount; i++)
                {
                    all_column_width += dgvList.Columns[columnIndex + i].Width;
                }
                int mergedHeaderWidth = all_column_width + widthOffset;

                //Generate the merged Header Column Rectangle.
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, (headerCellRectangle.Height/2) + heightOffset);

                //draw rectangle border
                Pen pen = new Pen(Color.Silver, 1);
                e.Graphics.DrawRectangle(pen, mergedHeaderRect);

                ////Draw the merged Header Column Rectangle.
                Brush brush = new SolidBrush(Color.FromArgb(64, 64, 64));
                e.Graphics.FillRectangle(brush, mergedHeaderRect);

                //Draw the merged Header Column Text.
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(text, dgvList.ColumnHeadersDefaultCellStyle.Font, Brushes.Silver, mergedHeaderRect, format);

            }
            catch (Exception) 
            {
            }
        }

        private void DgvList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //to trigger repaint 
            this.dgvList.Invalidate();
        }

        private void DgvList_Scroll(object sender, ScrollEventArgs e)
        {
            //to trigger repaint 
            this.dgvList.Invalidate();
        }

        #endregion

        #region ChecktheResultButton
        private void BtnCheckTheResult_Click(object sender, EventArgs e)
        {
            bool status = CheckInput(); // valicate text boxes
            if (status)
            {
                BindGrid(fromDate, toDate);
            }
        }
        #endregion

        #region BindGrid
        private void BindGrid(DateTime from, DateTime to)
        {
            try
            {
                Controllers.frm35Controller oController = new Controllers.frm35Controller();
                dtCheckResult = oController.GetMatchInvoice(fromDate, toDate, chkNoReserved.Checked);
                if (dtCheckResult.Rows.Count > 0)
                {
                    dgvList.DataSource = dtCheckResult;
                    this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    this.dgvList.ColumnHeadersHeight = 40;
                    this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    this.dgvList.Columns[0].Width = 25;
                }
                else
                {
                    //clear data except headers
                    var empty = dgvList.DataSource as DataTable;
                    try
                    {
                        empty.Rows.Clear();
                    }
                    catch (Exception)//handle null result on first search
                    {

                    }
                    dgvList.DataSource = empty;
                }
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

        #region CancelAllocationButton
        private void BtnCancelAllocation_Click(object sender, EventArgs e)
        {
            #region CheckSelectedRow
            int status = 0;
            int index = 0;
            int foundindex = 0;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells["colCheck"].Value == null ? false : bool.Parse(row.Cells["colCheck"].Value.ToString()))
                {
                    if (status >= 1) //if already found
                    {

                        status = 2;
                    }
                    else //first selected
                    {
                        status = 1;
                        foundindex = index;
                    }
                }
                index++;
            }
            #endregion

            if (status == 0) //if no row selected
            {
                MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SEQ_NO");
                    dt.Columns.Add("COMPANY_NO_BOX");
                    dt.Columns.Add("YEAR_MONTH");

                    string strCompanyNoBox = "";
                    int intseqno = 0;
                    string strYearMonth = "";

                    for (int i = 0; i < dgvList.Rows.Count; i++) //get selected items
                    {
                        bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                        if (value == true)
                        {
                            strCompanyNoBox = dgvList.Rows[i].Cells["COMPANY_NO_BOX"].Value.ToString();
                            intseqno = int.Parse(dgvList.Rows[i].Cells["SEQ_NO"].Value.ToString());
                            strYearMonth = dgvList.Rows[i].Cells["YEAR_MONTH"].Value.ToString();

                            DataRow dr = dt.NewRow();
                            dr["SEQ_NO"] = intseqno;
                            dr["COMPANY_NO_BOX"] = strCompanyNoBox;
                            dr["YEAR_MONTH"] = strYearMonth;
                            dt.Rows.Add(dr);
                        }
                    }

                    Controllers.frm35Controller oController = new Controllers.frm35Controller();
                    bool success = oController.CancelAllocation(dt);
                    if (success)
                    {
                        btnCheckTheResult.PerformClick();
                        MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.StatusUpdatedToCancel, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.TimeoutException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.WebException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(ex.Message, ex, false);
                    MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region CSVExportButton
        private void BtnCSV_Click(object sender, EventArgs e)
        {
            bool status = CheckInput(); // validate text boxes
            if (status)
            {
                try
                {
                    SaveFileDialog saveCSV = new SaveFileDialog();
                    saveCSV.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
                    saveCSV.FileName = System.DateTime.Now.ToString("yyyyMMddHHmmss");

                    DataTable dt = GetCSVData(fromDate, toDate);

                    //Exporting to Excel
                    if (dt.Rows.Count > 0)
                    {
                        if (saveCSV.ShowDialog() == DialogResult.OK) // save as dialog
                        {
                            Utility.WriteToCsvFile(dt, saveCSV.FileName);
                            MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.CSVDownloaded, "CSV Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.NoRecordToDownload, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (System.TimeoutException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.WebException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(ex.Message, ex, false);
                    MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        #endregion

        #region CSVExport
        private DataTable GetCSVData(DateTime from, DateTime to)
        {
            Controllers.frm35Controller o35 = new Controllers.frm35Controller();
            DataTable dt = o35.getAccountingCSV(from, to);
            return dt;
        }
        #endregion

        #region CheckInputValidations
        private bool CheckInput()
        {
            fromDate = new DateTime();
            toDate = new DateTime();

            //check if both date are empty
            if (txtFromDate.Text.Trim() == "" && txtToDate.Text.Trim() == "")
            {
                MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.RequireDate, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if not empty validate
            try
            {
                if (txtFromDate.Text.Trim() != "")
                {
                    fromDate = DateTime.ParseExact(txtFromDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
            }
            catch (Exception)
            {
                try
                {
                    fromDate = DateTime.ParseExact(txtFromDate.Text, "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.InvalidDateFormat, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            //if not empty validate
            try
            {
                if (txtToDate.Text.Trim() != "")
                {
                    toDate = DateTime.ParseExact(txtToDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
            }
            catch (Exception)
            {
                try
                {
                    toDate = DateTime.ParseExact(txtToDate.Text, "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.InvalidDateFormat, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //check if todate is greater than fromdate
            if (fromDate.Date > toDate.Date)
            {
                if (toDate.Date != new DateTime())
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.InvalidDateFromAndTo, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (txtFromDate.Text=="" && toDate != new DateTime()) //check if only to date is inserted 
            {
                MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.RequireDateFrom, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region AdjustCheckBoxOnResize
        private void DgvList_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = txtCompanyName.Text.Trim();
            DataTable tblFiltered = new DataTable();

            try
            {
                tblFiltered = dtCheckResult.Select("BILL_SUPPLIER_NAME LIKE '%' + '" + key + "' + '%'").CopyToDataTable();
            }
            catch (Exception)//in case of no search result
            {

            }

            if (tblFiltered.Rows.Count > 0)
            {
                dgvList.DataSource = tblFiltered;
                ResetHeader();
            }
            else
            {
                //clear data except headers
                var empty = dgvList.DataSource as DataTable;
                try
                {
                    empty.Rows.Clear();

                }
                catch (Exception)//handle null result on first search
                {

                }
                dgvList.DataSource = empty;
            }
        }

    }
}
