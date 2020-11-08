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

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frm36 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        DateTime fromDate;
        DateTime toDate;
        string paraFromDate = "";
        string paraToDate = "";
        #endregion

        #region Constructor 
        public frm36()
        {
            InitializeComponent();

            setOptimalDimentions();
        }

        public frm36(string _fromDate, string _toDate)
           : this()
        {
            paraFromDate = _fromDate;
            paraToDate = _toDate;

            setOptimalDimentions();
        }
        #endregion

        #region FormLoad
        private void Frm36_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;
            txtFromDate.Text = paraFromDate;
            txtToDate.Text = paraToDate;

            DummyRecord();// add dummy table to merge columns

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

        #region BackButton
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region CheckTheResultButton
        private void BtnCheckTheResult_Click(object sender, EventArgs e)
        {
            fromDate = new DateTime();
            toDate = new DateTime();

            //check if both date are empty
            if (txtFromDate.Text.Trim() == "" && txtToDate.Text.Trim() == "")
            {
                MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.RequireDate, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    return;
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
                    return;
                }
            }

            //check if todate is greater than fromdate
            if (fromDate.Date > toDate.Date)
            {
                if (toDate.Date != new DateTime())
                {
                    MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.InvalidDateFromAndTo, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtFromDate.Text=="" && toDate != new DateTime()) //check if only to date is inserted 
            {
                MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.RequireDateFrom, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
                Controllers.frm36Controller oController = new Controllers.frm36Controller();
                DataTable dtCheckResult = oController.GetUnmatchInvoice(from, to);
                if (dtCheckResult.Rows.Count > 0)
                {
                    dgvList.DataSource = dtCheckResult;
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

        #region RefundButton
        private void BtnRefund_Click(object sender, EventArgs e)
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
                MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.ConfirmRefund, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("SEQ_NO");
                        int intseqno = 0;
                        for (int i = 0; i < dgvList.Rows.Count; i++) //get selected items
                        {
                            bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                            if (value == true)
                            {
                                intseqno = int.Parse(dgvList.Rows[i].Cells["SEQ_NO"].Value.ToString());
                                DataRow dr = dt.NewRow();
                                dr["SEQ_NO"] = intseqno;
                                dt.Rows.Add(dr);
                            }
                        }

                        Controllers.frm36Controller oController = new Controllers.frm36Controller();
                        bool success = oController.RefundProcess(dt);
                        if (success)
                        {
                            btnCheckTheResult.PerformClick();
                            MetroMessageBox.Show(this, "\n" + Messages.CheckUnmatchedInvoice.StatusUpdatedToRefund, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
        }
        #endregion

        #region DrawColumnHeaders
        private void ResetHeader()
        {
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.ColumnHeadersHeight = 40;
            this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCheck"].Width = 25;
        }

        private void DummyRecord()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SEQ_NO");
            dt.Columns.Add("DateTimeId");
            dt.Columns.Add("CUSTOMER_NAME");
            dt.Columns.Add("DEPOSIT_AMOUNT");
            dt.Columns.Add("BILL_COMPANY_NAME");
            dt.Columns.Add("BILL_CONTACT_NAME");
            dt.Columns.Add("BILL_PHONE_NUMBER");
            dt.Columns.Add("BILL_MAIL_ADDRESS");

            dgvList.DataSource = dt;
            ResetHeader();
        }

        private void DgvList_Paint_1(object sender, PaintEventArgs e)
        {
            Add_BnakTransferInfo_Header(e, 3, 2, "銀行振込情報");
            Add_TransferInformation_Header(e, 5, 4, "振込者情報");
        }

        private void Add_BnakTransferInfo_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_TransferInformation_Header(PaintEventArgs e, int index, int count, string text)
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
                int xOffset = 0;
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

        #region AdjustCheckBoxOnResize
        private void Frm36_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion
    }
}
