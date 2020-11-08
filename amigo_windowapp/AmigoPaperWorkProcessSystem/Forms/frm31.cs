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
    public partial class frm31 : MetroFramework.Forms.MetroForm
    {

        #region Declare
        DateTime fromDate;
        DateTime toDate;
        #endregion

        #region Constructor 
        public frm31()
        {
            InitializeComponent();

            setOptimalDimentions();
        }
        #endregion

        #region FormLoad
        private void Frm31_Load(object sender, EventArgs e)
        {
            //theme style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            DummyTable(); // add dummy table to merge columns
            txtFromDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

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

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
             fromDate = new DateTime();
             toDate = new DateTime();

            //check if both date are empty
            if (txtFromDate.Text.Trim() == "" && txtToDate.Text.Trim() == "")
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.RequireImportDate, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.InvalidFromAndTo, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtFromDate.Text == "" && toDate != new DateTime()) //check if only to date is inserted 
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.RequireImportDateFrom, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Controllers.frm31Controller oController = new Controllers.frm31Controller();
            
                DataTable dtBankTrList = oController.getBankTrList(from, to);
                if (dtBankTrList.Rows.Count > 0)
                {
                    dgvList.DataSource = dtBankTrList;
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

        #region DrawColumnHeaders
        private void ResetHeader()
        {
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.ColumnHeadersHeight = 40;
            this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.dgvList.Columns[0].Width = 25;
        }

        private void DummyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DateTimeID");
            dt.Columns.Add("AmigoCount");
            dt.Columns.Add("NonAmigoCount");
            dt.Columns.Add("ActualRunDate");
            dt.Columns.Add("PAYMENT_DAY");
            dt.Columns.Add("RunDate");
            dt.Columns.Add("RunTime");

            dgvList.DataSource = dt;
            ResetHeader();
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Amigo_Header(e, 2, 1, "Amigo");
            Add_Non_Amigo_Header(e, 3, 1, "Amigo外");
        }

        private void Add_Amigo_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_Non_Amigo_Header(PaintEventArgs e, int index, int count, string text)
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

        private int GetXLocation( int index)
        {
            int column_widths = 0;

            for (int i = 0; i <= index ; i++)
            {
                column_widths += dgvList.Columns[i].Width;
            }

            // return X index after adding datagrid's X value
            return column_widths + dgvList.Location.X;
        }

        #endregion

        #region CheckAmigoDataButton
        private void BtnCheckAmigoData_Click(object sender, EventArgs e)
        {
            openAnotherForm("3-2");
        }
        #endregion

        #region CheckNonAmigoDataButton
        private void BtnNoneAmigoCheckData_Click(object sender, EventArgs e)
        {
            openAnotherForm("3-3");
        }
        #endregion

        #region CheckTheResultButton
        private void BtnChecktheResult_Click(object sender, EventArgs e)
        {
            openAnotherForm("3-4");
        }
        #endregion

        #region OpenAnotherForm
        private void openAnotherForm(string form)
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
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 2) //if multirow selected
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.MultipleRowSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //open another form and pass parameter
                string strDateTimeID, strDate, strTime, strCount;
                if (form == "3-2") //if 3-2 form
                {
                    strCount = dgvList.Rows[foundindex].Cells["colAmigodata"].Value.ToString();
                    if (strCount != "0")
                    {
                        strDateTimeID = dgvList.Rows[foundindex].Cells["colDateTimeID"].Value.ToString();
                        strDate = dgvList.Rows[foundindex].Cells["colDate"].Value.ToString();
                        strTime = dgvList.Rows[foundindex].Cells["colTime"].Value.ToString();

                        this.Hide();
                        frm32 frm = new frm32(strDateTimeID, strDate, strTime, strCount);
                        frm.ShowDialog();
                        this.Show();
                        BindGrid(fromDate, toDate);
                        this.BringToFront();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.DataWithZeroValueSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }else if (form == "3-3") // 3-3 form
                {
                    strCount = dgvList.Rows[foundindex].Cells["colNonAmigodata"].Value.ToString();

                    if (strCount != "0")
                    {
                        strDateTimeID = dgvList.Rows[foundindex].Cells["colDateTimeID"].Value.ToString();
                        strDate = dgvList.Rows[foundindex].Cells["colDate"].Value.ToString();
                        strTime = dgvList.Rows[foundindex].Cells["colTime"].Value.ToString();

                        this.Hide();
                        frm33 frm = new frm33(strDateTimeID, strDate, strTime, strCount);
                        frm.ShowDialog();
                        this.Show();
                        BindGrid(fromDate, toDate);
                        this.BringToFront();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.DataWithZeroValueSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    strCount = dgvList.Rows[foundindex].Cells["colAmigodata"].Value.ToString();
                    if (strCount != "0")
                    {
                        string payment_day;
                        try
                        {
                            payment_day = DateTime.ParseExact(dgvList.Rows[foundindex].Cells["colPayment"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                        }
                        catch (Exception)
                        {
                            payment_day = DateTime.Now.ToString("yyyy/MM/dd");
                        }
                        this.Hide();
                        if (payment_day == new DateTime().ToString())
                        {
                            frm34 frm = new frm34(DateTime.Now.ToString("yyyy/MM/dd"));
                            frm.ShowDialog();
                        }
                        else
                        {
                            frm34 frm = new frm34(payment_day); //rundate time also
                            frm.ShowDialog();
                        }
                        this.Show();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfBankTransferInformationResult.DataWithZeroValueSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        #endregion

        #region AdjustCheckBoxOnResize
        private void Frm31_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion
    }
}
