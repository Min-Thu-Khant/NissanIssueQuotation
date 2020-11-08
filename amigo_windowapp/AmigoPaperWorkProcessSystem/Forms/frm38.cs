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
    public partial class frm38 : MetroFramework.Forms.MetroForm
    {
        #region Declare
        bool valid_edit = true;
        bool search_or_back = false;
        #endregion

        #region Constructor
        public frm38()
        {
            InitializeComponent();

            setOptimalDimentions();
        }
        #region ConstructorFrom33
        public frm38(string customer_name)
            : this()
        {
            txtAccountName.Text = customer_name;

            setOptimalDimentions();
        }

        #endregion
        #endregion

        #region BackButton
        private void BtnBack_Click(object sender, EventArgs e)
        {
            search_or_back = true;
            this.Close();
        }
        #endregion

        #region FormLoad
        private void Frm38_Load(object sender, EventArgs e)
        {
            //theme style
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            DummyTable();// add dummy table to merge columns

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
        private void BindGrid()
        {
            string strCompanyName = txtCompanyName.Text.Trim();
            string strBillToCompanyName = txtBillToCompanyName.Text.Trim();
            string strAccountName = txtAccountName.Text.Trim();
            string strCompanyNameNumberBox = txtCompanyNumberBox.Text.Trim();
            string strCompanyNameReading = txtCompanyNameReading.Text.Trim();
            DataTable dt = new DataTable();
            Controllers.frm38Controller oController = new Controllers.frm38Controller();

            try
            {
                DataTable dtCustomerMaster = oController.getCustomerList(strCompanyName, strBillToCompanyName, strAccountName, strCompanyNameNumberBox, strCompanyNameReading, Utility.Id, Utility.Password);
                if (dtCustomerMaster.Rows.Count > 0)
                {
                  
                    dgvList.DataSource = dtCustomerMaster;
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

        #region SearchButton
        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            search_or_back = true;
            if (txtCompanyName.Text.Trim()!="" || txtBillToCompanyName.Text.Trim() != "" || txtAccountName.Text.Trim() != "" || txtCompanyNumberBox.Text.Trim() != "" || txtCompanyNameReading.Text.Trim() != "")
            {
                BindGrid();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.UpdateCUSTOMER_MASTER.NoSearchConditions, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            search_or_back = false;
        }

        #endregion

        #region dgvList_CellEndEdit
        private void DgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            valid_edit = true;
        }
        #endregion

        #region DataTypeErrorHandle
        private void DgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           return;
        }
        #endregion

        #region CellEditErrorHandle
        private void DgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //validate bank account uniqueness
            if (!IsBankAccountUnique(e))
            {
                return;
            }

            valid_edit = true;
            if (e.ColumnIndex == 4)
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 48) ) //bank account 1
                {
                    valid_edit = false;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 48))//bank account 2
                {
                    valid_edit = false;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 48))//bank account 3
                {
                    valid_edit = false;
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 48))//bank account 4
                {
                    valid_edit = false;
                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 6))// ncs customer code
                {
                    valid_edit = false;
                }
            }
            else if (e.ColumnIndex == 11 || e.ColumnIndex == 12)
            {
                try
                {
                    decimal value = decimal.Parse(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (value < -922337203685477 || value > 922337203685477) // max number of money data type
                    {
                        valid_edit = false;
                    }
                }
                catch (Exception)
                {
                    valid_edit = false;
                }
            }
            if (valid_edit == false && search_or_back == false) //return to edit mode if search or back click event is not fired
            {
                MetroMessageBox.Show(this, "\n" + Messages.UpdateCUSTOMER_MASTER.InvalidGridData, "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                dgvList.EndEdit();
                valid_edit = true;
                return;
            };
        }
        #endregion

        #region CheckSelectedRow
        private bool checkSelectedRow()
        {
            bool found = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells["colCheck"].Value == null ? false : bool.Parse(row.Cells["colCheck"].Value.ToString()))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        #endregion

        #region ChangeButton
        private void BtnChange_Click_1(object sender, EventArgs e)
        {
            DataTable dt = getFormat_UpdateCustomer();
            if (this.checkSelectedRow())
            {
                try
                {
                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        bool status = dgvList.Rows[i].Cells["colCheck"].Value == null ? false : bool.Parse(dgvList.Rows[i].Cells["colCheck"].Value.ToString());
                        string strBillingInterval = dgvList.Rows[i].Cells["colBILL_BILLING_INTERVAL"].Value.ToString();
                        string strBillingDepositRules = dgvList.Rows[i].Cells["colBILL_DEPOSIT_RULES"].Value.ToString();

                        if (status == true)
                        {
                            if (strBillingInterval != "" && strBillingDepositRules != "")
                            {
                                #region BillingInterval
                                int intBilllingInterval = 0;
                                if (strBillingInterval == "月額") intBilllingInterval = 1;
                                else if (strBillingInterval == "四半期") intBilllingInterval = 2;
                                else if (strBillingInterval == "半期") intBilllingInterval = 3;
                                else if (strBillingInterval == "年額") intBilllingInterval = 4;
                                else intBilllingInterval = int.Parse(strBillingInterval);
                                #endregion

                                #region BillingDepositRules
                                int intBillingDepositRules = 0; 
                                if (strBillingDepositRules == "翌月") intBillingDepositRules = 0;
                                else if (strBillingDepositRules == "当月") intBillingDepositRules = 1;
                                else if (strBillingDepositRules == "翌々月月頭") intBillingDepositRules = 2;
                                else intBillingDepositRules = int.Parse(strBillingDepositRules);
                                #endregion

                                DataRow dr = dt.NewRow();
                                dr["BILL_BANK_ACCOUNT_NAME-1"] = dgvList.Rows[i].Cells["colBILL_BANK_ACCOUNT_NAME_1"].Value.ToString().Trim();
                                dr["BILL_BANK_ACCOUNT_NAME-2"] = dgvList.Rows[i].Cells["colBILL_BANK_ACCOUNT_NAME_2"].Value.ToString().Trim();
                                dr["BILL_BANK_ACCOUNT_NAME-3"] = dgvList.Rows[i].Cells["colBILL_BANK_ACCOUNT_NAME_3"].Value.ToString().Trim();
                                dr["BILL_BANK_ACCOUNT_NAME-4"] = dgvList.Rows[i].Cells["colBILL_BANK_ACCOUNT_NAME_4"].Value.ToString().Trim();
                                dr["BILL_BILLING_INTERVAL"] = intBilllingInterval;
                                dr["BILL_DEPOSIT_RULES"] = intBillingDepositRules;
                                dr["BILL_TRANSFER_FEE"] = decimal.Parse(dgvList.Rows[i].Cells["colBILL_TRANSFER_FEE"].Value.ToString());
                                dr["BILL_EXPENSES"] = decimal.Parse(dgvList.Rows[i].Cells["colBILL_EXPENSES"].Value.ToString());
                                dr["UPDATE_DATE"] = DateTime.Now;
                                dr["UPDATER_CODE"] = Utility.Id;
                                dr["COMPANY_NO_BOX"] = dgvList.Rows[i].Cells["colCOMPANY_NO_BOX"].Value.ToString().Trim();
                                dr["TRANSACTION_TYPE"] = dgvList.Rows[i].Cells["colTRANSACTION_TYPE"].Value.ToString().Trim();
                                dr["EFFECTIVE_DATE"] = dgvList.Rows[i].Cells["colEFFECTIVE_DATE"].Value.ToString().Trim();
                                dr["NCS_CUSTOMER_CODE"] = dgvList.Rows[i].Cells["colNCS_CUSTOMER_CODE"].Value.ToString().Trim();
                                dt.Rows.Add(dr);

                            }
                        }
                    }

                    Controllers.frm38Controller o38 = new Controllers.frm38Controller();
                
                    bool statuss = o38.UpdateCustomer(dt);

                    if (statuss)
                    {
                        BindGrid();
                        MetroMessageBox.Show(this, "\n" + Messages.UpdateCUSTOMER_MASTER.RecordUpdated, "Record updated", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.UpdateCUSTOMER_MASTER.NoSelectedRow, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region getFormat_UpdateCustomer
        protected DataTable getFormat_UpdateCustomer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-1");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-2");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-3");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-4");
            dt.Columns.Add("BILL_BILLING_INTERVAL");
            dt.Columns.Add("BILL_DEPOSIT_RULES");
            dt.Columns.Add("BILL_TRANSFER_FEE");
            dt.Columns.Add("BILL_EXPENSES");
            dt.Columns.Add("UPDATE_DATE");
            dt.Columns.Add("UPDATER_CODE");
            dt.Columns.Add("TRANSACTION_TYPE");
            dt.Columns.Add("EFFECTIVE_DATE");
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("NCS_CUSTOMER_CODE");
            return dt;
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
            dt.Columns.Add("COMPANY_NAME");
            dt.Columns.Add("BILL_COMPANY_NAME");
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-1");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-2");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-3");
            dt.Columns.Add("BILL_BANK_ACCOUNT_NAME-4");
            dt.Columns.Add("NCS_CUSTOMER_CODE");
            dt.Columns.Add("BILL_BILLING_INTERVAL");
            dt.Columns.Add("BILL_DEPOSIT_RULES");
            dt.Columns.Add("BILL_TRANSFER_FEE");
            dt.Columns.Add("BILL_EXPENSES");
            dt.Columns.Add("TRANSACTION_TYPE");
            dt.Columns.Add("EFFECTIVE_DATE");

            dgvList.DataSource = dt;
            ResetHeader();
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

        private void Add_1st_Month_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_2nd_Month_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_3rd_Month_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_4th_Month_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_1st_Month_Header(e, 4, 1, "1口目");
            Add_2nd_Month_Header(e, 5, 1, "2口目");
            Add_3rd_Month_Header(e, 6, 1, "3口目");
            Add_4th_Month_Header(e, 7, 1, "4口目");
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

        #region AdjustCheckBoxOnResize
        private void Frm38_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion

        #region IsBankAccountUnique
        private bool IsBankAccountUnique(DataGridViewCellValidatingEventArgs e)
        {
            List<string> accounts = new List<string>();
            if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_1"].Value.ToString().Trim()))
            {
                accounts.Add(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_1"].Value.ToString().Trim());
            }
            if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_2"].Value.ToString().Trim()))
            {
                accounts.Add(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_2"].Value.ToString().Trim());
            }

            if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_3"].Value.ToString().Trim()))
            {
                accounts.Add(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_3"].Value.ToString().Trim());
            }

            if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_4"].Value.ToString().Trim()))
            {
                accounts.Add(dgvList.Rows[e.RowIndex].Cells["colBILL_BANK_ACCOUNT_NAME_4"].Value.ToString().Trim());
            }

            //check if list count and unique count
            if (accounts.Distinct().Count() != accounts.Count())
            {
                MetroMessageBox.Show(this, "\n" + Messages.UpdateCUSTOMER_MASTER.BankAccountNotUnique, "Data Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                dgvList.EndEdit();
                valid_edit = true;
                return false;
            }
            return true;
        }
        #endregion
    }

}
