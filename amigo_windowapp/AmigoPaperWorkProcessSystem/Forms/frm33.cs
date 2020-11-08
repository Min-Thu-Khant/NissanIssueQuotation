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
    public partial class frm33 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        string strDateTimeID = "";
        #endregion

        #region Constructor
        public frm33()
        {
            InitializeComponent();

            setOptimalDimentions();
        }
        

        #region ConstructorFrom31
        public frm33(string _strdatetimeid, string _strdate, string _strtime, string _strcount)
            : this()
        {
            strDateTimeID = _strdatetimeid;
            lblDate.Text = _strdate;
            lblTime.Text = _strtime;
            lblNoOfDeposit.Text = _strcount;

            setOptimalDimentions();

        }
        #endregion
        #endregion

        #region FormLoad
        private void Frm33_Load(object sender, EventArgs e)
        {
            //them style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            DummyTable(); // add dummy table to merge columns

            if (strDateTimeID != "")
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
        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region BindGrid
        private void BindGrid(string strdatetimeid)
        {
            try
            {
                Controllers.frm33Controller oController = new Controllers.frm33Controller();
                DataTable dtNonAmigoData = oController.NonAmigo_BankTR(strDateTimeID);
                if (dtNonAmigoData.Rows.Count > 0)
                {
                    dgvList.DataSource = dtNonAmigoData;
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

        #region MoveToAmigo
        private void BtnMoveToAmigo_Click(object sender, EventArgs e)
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
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfNonAmigo.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int intseqno = 0;
                    string strbankno = "";
                    int selectedcount = 0;
                    Controllers.frm33Controller oController = new Controllers.frm33Controller();

                    DataTable dtConvertNonAmigoAmigo = new DataTable();
                    dtConvertNonAmigoAmigo.Columns.Add("SEQNO");
                    dtConvertNonAmigoAmigo.Columns.Add("bankAccountName");

                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                        if (value == true)
                        {
                            intseqno = dgvList.Rows[i].Cells["colNo"].Value.ToString() == "" ? 0 : int.Parse(dgvList.Rows[i].Cells["colNo"].Value.ToString());
                            strbankno = dgvList.Rows[i].Cells["CUSTOMER_NAME"].Value.ToString();

                            DataRow dr = dtConvertNonAmigoAmigo.NewRow();
                            dr["SEQNO"] = intseqno;
                            dr["bankAccountName"] = strbankno;
                            dtConvertNonAmigoAmigo.Rows.Add(dr);
                            selectedcount++;
                        }
                    }

                    dynamic result = oController.ConvertNonAmigoToAmigo(dtConvertNonAmigoAmigo);
                    if (result.Status == "1") // success
                    {
                        BindGrid(strDateTimeID);
                        MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfNonAmigo.MovedToAmigo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                    }
                    else
                    {
                        if (result.Message !=0) // no customer found
                        {
                            if (result.Message > 1 || dtConvertNonAmigoAmigo.Rows.Count>1) //multi case
                            {
                                string msg = Messages.ConfirmationOfNonAmigo.CustomerNotFoundMultiCase;
                                msg = msg.Insert(3, " " + selectedcount.ToString() + " ");
                                string failed = result.Message;
                                msg = msg.Insert(0, (selectedcount - int.Parse(failed)) + " ");
                                MetroMessageBox.Show(this, "\n" + msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                BindGrid(strDateTimeID);
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfNonAmigo.CustomerNotFound, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                    MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Move Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvList.DataSource = dt;
            ResetHeader();
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_CustomerName_Header(e, 2, 1, "銀行データ");
        }

        private void Add_CustomerName_Header(PaintEventArgs e, int index, int count, string text)
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

        #region CreateCustomer
        private void BtnCreateCustomer_Click(object sender, EventArgs e)
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
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfNonAmigo.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (status == 2) //if multirow selected
            {
                MetroMessageBox.Show(this, "\n" + Messages.ConfirmationOfNonAmigo.MultipleRowSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                string customer_name = dgvList.Rows[foundindex].Cells["CUSTOMER_NAME"].Value.ToString().Trim();
                frm38 frm = new frm38(customer_name);
                frm.ShowDialog();
                this.Show();
            }
        }
        #endregion

        #region AdjustCheckBoxOnResize
        private void Frm33_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion
    }
}
