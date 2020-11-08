using AmigoPaperWorkProcessSystem.Core;
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

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frm32 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        string strDateTimeID = "";
        DataTable dtAmigoData;
        #endregion

        #region Constructor
        public frm32()
        {
            InitializeComponent();
            setOptimalDimentions();
        }

        #region ConstructorFrom31
        public frm32(string _strdatetimeid, string _strdate, string _strtime, string _strcount)
            : this()
        {
            strDateTimeID = _strdatetimeid;
            lblDate.Text = _strdate;
            lblTime.Text = _strtime;
            lblNoOfDeposit.Text = _strcount;
            
        }

        #endregion
        #endregion

        #region FormLoad
        private void Frm32_Load(object sender, EventArgs e)
        {
            //theme style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            DummyTable(); // add dummy table to merge columns
            if (strDateTimeID!="")
            {
               BindGrid(strDateTimeID);
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

        #region BindGrid
        private void BindGrid(string strdatetimeid)
        {
            try
            {
                Controllers.frm32Controller oController = new Controllers.frm32Controller();
                dtAmigoData = oController.getBankTrList(strdatetimeid);
                if (dtAmigoData.Rows.Count > 0)
                {
                    dgvList.DataSource = dtAmigoData;
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

                lblNoOfDeposit.Text = dgvList.Rows.Count.ToString();

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

        #region MoveToAmigoButton
        private void BtnMoveToNoAmigo_Click(object sender, EventArgs e)
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
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfAmigo.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int intseqno = 0;
                    Controllers.frm32Controller oController = new Controllers.frm32Controller();
                    DataTable dtConvertAmigoNonAmigo = new DataTable();
                    dtConvertAmigoNonAmigo.Columns.Add("SEQNO");

                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                        if (value == true)
                        {
                            intseqno = dgvList.Rows[i].Cells["colNo"].Value.ToString() == "" ? 0 : int.Parse(dgvList.Rows[i].Cells["colNo"].Value.ToString());
                            DataRow dr = dtConvertAmigoNonAmigo.NewRow();
                            dr["SEQNO"] = intseqno;
                            dtConvertAmigoNonAmigo.Rows.Add(dr);
                        }
                    }
                    bool success = oController.ConvertAmigoToNonAmigo(dtConvertAmigoNonAmigo);
                    if (success)
                    {
                        BindGrid(strDateTimeID);
                        MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfAmigo.MovedToNonAmigo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    catch (System.TimeoutException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Net.WebException)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DummyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SEQ_NO");
            dt.Columns.Add("CUSTOMER_NAME");
            dt.Columns.Add("DEPOSIT_AMOUNT");
            dt.Columns.Add("BILL_COMPANY_NAME");
            dgvList.DataSource = dt;
            ResetHeader();
        }


        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_CustomerName_Header(e, 2, 2, "銀行データ");
            Add_BillCompanyName_Header(e, 4, 1, "顧客マスタ");
        }

        private void Add_CustomerName_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_BillCompanyName_Header(PaintEventArgs e, int index, int count, string text)
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
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, (headerCellRectangle.Height / 2) + heightOffset);

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
        private void Frm32_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = txtCompanyName.Text.Trim();
            DataTable tblFiltered = new DataTable();

            try
            {
                tblFiltered = dtAmigoData.Select("BILL_COMPANY_NAME LIKE '%' + '" + key + "' + '%'").CopyToDataTable();
            }
            catch (Exception) //in case of no search result
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
        #endregion

    }
}
