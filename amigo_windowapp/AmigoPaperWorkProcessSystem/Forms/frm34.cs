using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frm34 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        DateTime fromDate;
        DateTime toDate;
        #endregion

        #region Constructor
        public frm34()
        {
            InitializeComponent();

            setOptimalDimentions();
        }

        #region ConstructorFrom31
        public frm34(string payment_day)
            : this()
        {
            txtFromDate.Text = payment_day;

            setOptimalDimentions();
        }
        #endregion
        #endregion

        #region FormLoad
        private void Frm34_Load(object sender, EventArgs e)
        {
            //theme style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;
            this.dgvList.Columns[0].Width = 25;

            DummyTable(); // add dummy table to merge columns

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

        #region BindGrid
        private void BindGrid(DateTime from, DateTime to)
        {
            try
            {
                Controllers.frm34Controller oController = new Controllers.frm34Controller();
                DataTable dtCheckResult = oController.ConfirmOfComparisonResult(from, to);
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

        #region BackButton
        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CheckResultButton
        private void BtnCheckTheResult_Click(object sender, EventArgs e)
        {
            fromDate = new DateTime();
            toDate = new DateTime();

            //check if both date are empty
            if (txtFromDate.Text.Trim() == "" && txtToDate.Text.Trim() == "")
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfComparisonResult.RequireDate, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfComparisonResult.InvalidDateFromAndTo, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtFromDate.Text=="" && toDate != new DateTime()) //check if only to date is inserted 
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfComparisonResult.RequireImportDateFrom, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BindGrid(fromDate, toDate);
            }
        }
        #endregion

        #region ComparisonResultDetailButton
        private void BtnComparisnResultDetail_Click(object sender, EventArgs e)
        {
            openAnotherForm("3-5");
        }
        #endregion

        #region CheckUnmatchedInvoiceButton
        private void BtnCheckUnmatchedInvoice_Click(object sender, EventArgs e)
        {
            openAnotherForm("3-6");
        }
        #endregion

        #region OpenAnotherForm
        private void openAnotherForm(string form)
        {
            if (form == "3-5")
            {
                this.Hide();
                frm35 frm = new frm35(txtFromDate.Text, txtToDate.Text);
                frm.ShowDialog();
                this.Show();
                btnCheckTheResult.PerformClick();
                this.BringToFront();
            }
            else
            {
                this.Hide();
                frm36 frm = new frm36(txtFromDate.Text, txtToDate.Text);
                frm.ShowDialog();
                this.Show();
                btnCheckTheResult.PerformClick();
                this.BringToFront();
            }
        }
        #endregion

        #region DrawColumnHeaders
        private void ResetHeader()
        {
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void DummyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DateTimeID");
            dt.Columns.Add("PaymenDate");
            dt.Columns.Add("PaymentTime");
            dt.Columns.Add("RunDate");
            dt.Columns.Add("RunTime");
            dt.Columns.Add("COUNT_Allocated");
            dt.Columns.Add("COUNT_NotAllocated");

            dgvList.DataSource = dt;
            ResetHeader();
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Allocation_Header(e, 3, 2, "振込処理日時");
            Add_Transfer_Header(e, 1, 2, "引当処理日時"); 
        }

        private void Add_Allocation_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_Transfer_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Merge_Header(PaintEventArgs e, int index, int count, string text)
        {
            try
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset =-1;
                int widthOffset = -1;
                int xOffset = 0;
                int yOffset = 0;

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
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

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

        #region 3B_Button
        private void Btn3B_Click(object sender, EventArgs e)
        {
            try
            {
                //check if batch process 3-B is already running
                bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3B");
                if (isRunning)
                {
                    MessageBox.Show(Messages.DepositConfirmationMenu.ProcessAlreadyRunning);
                }
                else
                {
                    btn3B.Enabled = false;
                    //start batch process exe
                    Process.Start(Application.StartupPath + "\\AmigoPaperWorkProcessSystem.3B.exe", Utility.Id + " " + Utility.Password);
                    //start timer to check process every 10 seconds
                    tmr3B.Start();

                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoProgramFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region 3BTimer
        private void Tmr3B_Tick(object sender, EventArgs e)
        {
            bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3B");
            if (!isRunning)
            {
                btn3B.Enabled = true;
                tmr3B.Stop();
            }
        }
        #endregion

    }
}
