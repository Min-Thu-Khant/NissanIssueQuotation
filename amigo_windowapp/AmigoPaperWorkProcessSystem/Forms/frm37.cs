using AmigoPapaerWorkProcessSystem.Core;
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
    public partial class frm37 : MetroFramework.Forms.MetroForm
    {
        private class SearchConditions
        {

            public int BILLING_CLASSIFICATION { get; set; }
            public string FROM_BILLING_DATE { get; set; }

            public string TO_BILLING_DATE { get; set; }

            public string FROM_SECHEDULE_PAYMENT { get; set; }

            public string TO_SECHEDULE_PAYMENT { get; set; }

            public string FROM_DEPOSIT_RECORD_DATE { get; set; }

            public string TO_DEPOSIT_RECORD_DATE { get; set; }

            public int DEPOSIT_RULE { get; set; }

            public int WITH_OR_WITHOUT_PAYMENT { get; set; }

            public string BILLING_COMPANY_NAME { get; set; }

            public bool IsAllEmpty()
            {
                if (string.IsNullOrEmpty(FROM_BILLING_DATE) && string.IsNullOrEmpty(FROM_SECHEDULE_PAYMENT) && string.IsNullOrEmpty(FROM_DEPOSIT_RECORD_DATE) && string.IsNullOrEmpty(BILLING_COMPANY_NAME))
                {
                    return true;
                }
                return false;
            }
        }

        #region Declare
        bool valid_edit = true;
        bool search_or_back = false;
        SearchConditions conditions;
        #endregion

        #region Constructor
        public frm37()
        {
            InitializeComponent();

            setOptimalDimentions();

            conditions = new SearchConditions();
        }
        #endregion

        #region FormLoad
        private void Frm37_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;


            DummyTable();// add dummy table to merge columns

            //populate combox
            PopulateComboValues();

            //select All
            cboBillingClassification.SelectedIndex = 0;

            //default yearmonth to deposit RecordDate
            txtDepositRecordDateFrom.Text = DateTime.Now.ToString("yyyy/MM/dd");

            Utility.DoubleBuffered(dgvList, true);
        }
        #endregion

        #region PopulateComboValues
        private void PopulateComboValues()
        {
            BillingClassifictionCombo();
            DepositRuleCombo();
            WithOrWithoutPaymentCombo();

        }
        #endregion


        #region BillingClassifictionCombo
        private void BillingClassifictionCombo()
        {
            cboBillingClassification.DisplayMember = "Text";
            cboBillingClassification.ValueMember = "Value";

            var items = new[] {
                 new { Text = "全て", Value = "0" },
                new { Text = "要元", Value = "12" },
                new { Text = "初期", Value = "21" },
                new { Text = "月額", Value = "22" },
                new { Text = "生産情報閲覧", Value = "32" },
            };

            cboBillingClassification.DataSource = items;
        }
        #endregion

        #region DepositRuleCombo
        private void DepositRuleCombo()
        {
            cboDepositRule.DisplayMember = "Text";
            cboDepositRule.ValueMember = "Value";

            var items = new[] {
                 new { Text = "全て", Value = "-1" },
                 new { Text = "当月", Value = "1" },
                 new { Text = "翌月", Value = "0" },
                 new { Text = "翌々月", Value = "2" },
                 new { Text = "当月以外", Value = "-2" }
            };

            cboDepositRule.DataSource = items;
        }
        #endregion

        #region WithOrWithoutPaymentCombo
        private void WithOrWithoutPaymentCombo()
        {
            cboWithOrWithoutPayment.DisplayMember = "Text";
            cboWithOrWithoutPayment.ValueMember = "Value";

            var items = new[] {
                 new { Text = "全て", Value = "-1" },
                 new { Text = "入金あり", Value = "1" },
                 new { Text = "入金なし", Value = "0" }
            };

            cboWithOrWithoutPayment.DataSource = items;
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
            search_or_back = true;
            this.Close();
        }

        #endregion

        #region GetConditions
        private void GetConditions()
        {
            conditions.BILLING_CLASSIFICATION = int.Parse((cboBillingClassification.SelectedItem as dynamic).Value);
            conditions.FROM_BILLING_DATE = txtBillingDateFrom.Text.Trim();
            conditions.TO_BILLING_DATE = txtBillingDateTo.Text.Trim();
            conditions.FROM_SECHEDULE_PAYMENT = txtSchedulePaymentFrom.Text.Trim();
            conditions.TO_SECHEDULE_PAYMENT = txtSchedulePaymentTo.Text.Trim();
            conditions.FROM_DEPOSIT_RECORD_DATE = txtDepositRecordDateFrom.Text.Trim();
            conditions.TO_DEPOSIT_RECORD_DATE = txtDepositRecordDateTo.Text.Trim();
            conditions.BILLING_COMPANY_NAME = txtBillingCompanyName.Text.Trim();
            conditions.WITH_OR_WITHOUT_PAYMENT = int.Parse((cboWithOrWithoutPayment.SelectedItem as dynamic).Value);
            conditions.DEPOSIT_RULE = int.Parse((cboDepositRule.SelectedItem as dynamic).Value);
        }
        #endregion

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            search_or_back = true;
            bool status = CheckInput(); // validate text boxes
            if (status)
            {
                BindGrid();
                //検索のタイミングで、更新系ボタンを活性化
                updateBtnEnabled(true);
            }
            search_or_back = false;
        }
        #endregion

        #region CheckTotalLabels
        private void UpdateTotalLebels()
        {
            int row_count = dgvList.Rows.Count;
            if (row_count <= 0)
            {
                //hide labels
                txtToalResult.Hide();
                txtTotalBillAmount.Hide();
                lblTotalBillAmount.Hide();
                txtTotalBillPrice.Hide();
                lblTotalBillPrice.Hide();
                lblTotalResult.Hide();
            }
            else
            {
                int totalBillPrice = 0;
                int totalBillAmount = 0;

                //calculate total
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    totalBillPrice += int.Parse(dgvList.Rows[i].Cells["BILL_PRICE"].Value.ToString());
                    totalBillAmount += int.Parse(dgvList.Rows[i].Cells["BILL_AMOUNT"].Value.ToString());
                }

                txtTotalBillPrice.Text = String.Format("{0:#,##0}", totalBillPrice);
                txtTotalBillAmount.Text = String.Format("{0:#,##0}", totalBillAmount);
                txtToalResult.Text = row_count.ToString();

                //show labels
                txtToalResult.Show();
                txtTotalBillAmount.Show();
                lblTotalBillAmount.Show();
                txtTotalBillPrice.Show();
                lblTotalBillPrice.Show();
                lblTotalResult.Show();
            }
        }
        #endregion
        #region BindGrid
        private void BindGrid()
        {
            try
            {
                Controllers.frm37Controller oController = new Controllers.frm37Controller();
                DataTable dtSearch = oController.GetDataForGrid(conditions.BILLING_CLASSIFICATION,
                                                                 conditions.FROM_BILLING_DATE,
                                                                 conditions.TO_BILLING_DATE,
                                                                 conditions.FROM_SECHEDULE_PAYMENT,
                                                                 conditions.TO_SECHEDULE_PAYMENT,
                                                                 conditions.FROM_DEPOSIT_RECORD_DATE,
                                                                 conditions.TO_DEPOSIT_RECORD_DATE,
                                                                 conditions.DEPOSIT_RULE,
                                                                 conditions.WITH_OR_WITHOUT_PAYMENT,
                                                                 conditions.BILLING_COMPANY_NAME);
                if (dtSearch.Rows.Count > 0)
                {
                    dgvList.DataSource = dtSearch;
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
                //update total labels
                UpdateTotalLebels();
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

        #region RegisterButton
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow() == false)  //if no row selected
            {
                MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STATUS_ACTUAL_MDB_UPDATE");
                dt.Columns.Add("STATUS_ACC_RECEIVABLE_DATE");
                dt.Columns.Add("STATUS_CASH_FORECAST_MM");
                dt.Columns.Add("STATUS_PLAN_DEPOSIT_YYMM");
                dt.Columns.Add("DUNNING_COUNT");
                dt.Columns.Add("DUNNING_DATE");
                dt.Columns.Add("ANSWER_DATE");
                dt.Columns.Add("PAYMENT_DUE_DATE");
                dt.Columns.Add("ANSWER_MEMO");
                dt.Columns.Add("COMPANY_NO_BOX");
                dt.Columns.Add("YEAR_MONTH");

                try
                {
                    string strCashForecast = "";
                    string strPlanDeposit = "";
                    int intDunningCount = 0;
                    string strCompanyNoBox = "";
                    string strYearMonth = "";
                    DateTime? DunnigDate, AnswerDate, strPaymentDueDate, StatusActualMDBUpdate, StatusAccReceivableDate;
                    string strAnswerMemo = "";

                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                        if (value == true)
                        {
                            strCashForecast = dgvList.Rows[i].Cells["STATUS_CASH_FORECAST_MM"].Value.ToString();
                            strPlanDeposit = dgvList.Rows[i].Cells["STATUS_PLAN_DEPOSIT_YYMM"].Value.ToString();
                            strCompanyNoBox = dgvList.Rows[i].Cells["COMPANY_NO_BOX"].Value.ToString();
                            strYearMonth = dgvList.Rows[i].Cells["YEAR_MONTH"].Value.ToString();
                            intDunningCount = int.Parse(dgvList.Rows[i].Cells["DUNNING_COUNT"].Value.ToString() == "" ? "0" : dgvList.Rows[i].Cells["DUNNING_COUNT"].Value.ToString());

                            //STATUS_ACTUAL_MDB_UPDATE
                            if (dgvList.Rows[i].Cells["STATUS_ACTUAL_MDB_UPDATE"].Value.ToString().Trim() != "")
                            {
                                try
                                {
                                    StatusActualMDBUpdate = DateTime.ParseExact(dgvList.Rows[i].Cells["STATUS_ACTUAL_MDB_UPDATE"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        StatusActualMDBUpdate = DateTime.ParseExact(dgvList.Rows[i].Cells["STATUS_ACTUAL_MDB_UPDATE"].Value.ToString(), "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                StatusActualMDBUpdate = null;
                            }

                            //STATUS_ACC_RECEIVABLE_DATE
                            if (dgvList.Rows[i].Cells["STATUS_ACC_RECEIVABLE_DATE"].Value.ToString().Trim() != "")
                            {
                                try
                                {
                                    StatusAccReceivableDate = DateTime.ParseExact(dgvList.Rows[i].Cells["STATUS_ACC_RECEIVABLE_DATE"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        StatusAccReceivableDate = DateTime.ParseExact(dgvList.Rows[i].Cells["STATUS_ACC_RECEIVABLE_DATE"].Value.ToString(), "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                StatusAccReceivableDate = null;
                            }

                            //DUNNING_DATE
                            if (dgvList.Rows[i].Cells["DUNNING_DATE"].Value.ToString().Trim() != "")
                            {
                                try
                                {
                                    DunnigDate = DateTime.ParseExact(dgvList.Rows[i].Cells["DUNNING_DATE"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        DunnigDate = DateTime.ParseExact(dgvList.Rows[i].Cells["DUNNING_DATE"].Value.ToString(), "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                DunnigDate = null;
                            }

                            //ANSWER_DATE
                            if (dgvList.Rows[i].Cells["ANSWER_DATE"].Value.ToString().Trim() != "")
                            {
                                try
                                {
                                    AnswerDate = DateTime.ParseExact(dgvList.Rows[i].Cells["ANSWER_DATE"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        AnswerDate = DateTime.ParseExact(dgvList.Rows[i].Cells["ANSWER_DATE"].Value.ToString(), "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                            }
                            else
                            {
                                AnswerDate = null;
                            }

                            //PAYMENT_DUE_DATE
                            if (dgvList.Rows[i].Cells["PAYMENT_DUE_DATE"].Value.ToString().Trim() != "")
                            {

                                try
                                {
                                    strPaymentDueDate = DateTime.ParseExact(dgvList.Rows[i].Cells["PAYMENT_DUE_DATE"].Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        strPaymentDueDate = DateTime.ParseExact(dgvList.Rows[i].Cells["PAYMENT_DUE_DATE"].Value.ToString(), "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    }
                                    catch (Exception)
                                    {
                                        MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                strPaymentDueDate = null;
                            }

                            strAnswerMemo = dgvList.Rows[i].Cells["ANSWER_MEMO"].Value.ToString();

                            DataRow dr = dt.NewRow();
                            dr["COMPANY_NO_BOX"] = strCompanyNoBox;
                            dr["YEAR_MONTH"] = strYearMonth;
                            dr["STATUS_ACTUAL_MDB_UPDATE"] = StatusActualMDBUpdate != null ? StatusActualMDBUpdate.Value.ToString("yyyyMMdd") : null;
                            dr["STATUS_ACC_RECEIVABLE_DATE"] = StatusAccReceivableDate != null ? StatusAccReceivableDate.Value.ToString("yyyyMMdd") : null;
                            dr["STATUS_CASH_FORECAST_MM"] = strCashForecast;
                            dr["STATUS_PLAN_DEPOSIT_YYMM"] = strPlanDeposit;
                            dr["DUNNING_COUNT"] = intDunningCount;
                            dr["DUNNING_DATE"] = DunnigDate != null ? DunnigDate.Value.ToString("yyyyMMdd") : null;
                            dr["ANSWER_DATE"] = AnswerDate != null ? AnswerDate.Value.ToString("yyyyMMdd") : null;
                            dr["PAYMENT_DUE_DATE"] = strPaymentDueDate != null ? strPaymentDueDate.Value.ToString("yyyyMMdd") : null;
                            dr["ANSWER_MEMO"] = strAnswerMemo == "" ? null : strAnswerMemo;
                            dt.Rows.Add(dr);
                        }
                    }

                    Controllers.frm37Controller oController = new Controllers.frm37Controller();
                    DataTable result = oController.UpdateInvoice(dt);

                    btnSearch.PerformClick();
                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.RecordUpdated, "Records Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dt.Columns.Add("BILL_SUPPLIER_NAME");
            dt.Columns.Add("YEAR_MONTH");
            dt.Columns.Add("BILLING_CODE");
            dt.Columns.Add("BILL_AMOUNT");
            dt.Columns.Add("BILL_TAX");
            dt.Columns.Add("BILL_PRICE");
            dt.Columns.Add("BILL_PAYMENT_DATE");
            dt.Columns.Add("STATUS_ACTUAL_MDB_UPDATE");
            dt.Columns.Add("STATUS_ACC_RECEIVABLE_DATE");
            dt.Columns.Add("STATUS_CASH_FORECAST_MM");
            dt.Columns.Add("STATUS_PLAN_DEPOSIT_YYMM");
            dt.Columns.Add("DEPOSIT_DATE");
            dt.Columns.Add("RESERVE_AMOUNT_1");
            dt.Columns.Add("RESERVE_AMOUNT_2");
            dt.Columns.Add("INSUFFICIENT_AMOUNT_OF_RESERVE");
            dt.Columns.Add("DUNNING_COUNT");
            dt.Columns.Add("DUNNING_DATE");
            dt.Columns.Add("ANSWER_DATE");
            dt.Columns.Add("PAYMENT_DUE_DATE");
            dt.Columns.Add("ANSWER_MEMO");
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("INVOICE_ALLOCATED_COMPLETION_DATE");
            dt.Columns.Add("RECEIPT_ALLOCATED_COMPLETION_DATE");
            dt.Columns.Add("SEQ_NO");
            dt.Columns.Add("RECEIPT_TYPE_OF_ALLOCATION");
            dt.Columns.Add("INVOICE_TYPE_OF_ALLOCATION");

            dgvList.DataSource = dt;
            ResetHeader();
        }
        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Bill_Information_Header(e, 2, 7, "請求情報");
            Add_CashFlow_Header(e, 9, 4, "資金繰り");
            Add_TransferInformation_Header(e, 13, 4, "振込情報");
            Add_DunningManagement_Header(e, 17, 5, "督促管理");
        }

        private void Add_Bill_Information_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_CashFlow_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_TransferInformation_Header(PaintEventArgs e, int index, int count, string text)
        {
            Merge_Header(e, index, count, text);
        }

        private void Add_DunningManagement_Header(PaintEventArgs e, int index, int count, string text)
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
                int yOffset = 3;

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

        #region SchedulePaymentOutputButton
        private void BtnSechedulePaymentOutput_Click(object sender, EventArgs e)
        {
            bool status = CheckInput();// validate text boxes
            if (status)
            {
                SaveFileDialog saveCSV = new SaveFileDialog();
                saveCSV.Filter = "Excel file (*.xlsx)|*.xlsx| (*.xls)|*.xls| (*.xlsm)|*.xlsm| All Files (*.*)|*.*";
                saveCSV.FileName = "Amigo入金リスト";
                try
                {
                    Controllers.frm37Controller oController = new Controllers.frm37Controller();
                    DataTable dt = oController.getSchedule_Payment(conditions.BILLING_CLASSIFICATION,
                                                                 conditions.FROM_BILLING_DATE,
                                                                 conditions.TO_BILLING_DATE,
                                                                 conditions.FROM_SECHEDULE_PAYMENT,
                                                                 conditions.TO_SECHEDULE_PAYMENT,
                                                                 conditions.FROM_DEPOSIT_RECORD_DATE,
                                                                 conditions.TO_DEPOSIT_RECORD_DATE,
                                                                 conditions.DEPOSIT_RULE,
                                                                 conditions.WITH_OR_WITHOUT_PAYMENT,
                                                                 conditions.BILLING_COMPANY_NAME);

                    if (dt.Rows.Count > 0)
                    {
                        if (saveCSV.ShowDialog() == DialogResult.OK) // save as dialog
                        {

                            //summary 
                            var sum_BILL_AMOUNT = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x.Field<double>("BILL_AMOUNT")));
                            var sum_BILL_TAX = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x.Field<double>("BILL_TAX")));
                            var sum_BILL_PRICE = dt.AsEnumerable().Sum(x => Convert.ToDecimal(x.Field<double>("BILL_PRICE")));
                            string year_month = dt.Rows[0][0].ToString().Replace("-", "");

                            DataRow dr = dt.NewRow();
                            dr["INVOICE_NO"] = "合計金額";
                            dr["BILL_AMOUNT"] = sum_BILL_AMOUNT.ToString();
                            dr["BILL_TAX"] = sum_BILL_TAX.ToString();
                            dr["BILL_PRICE"] = sum_BILL_PRICE.ToString();
                            dt.Rows.Add(dr);

                            //change column names
                            dt.Columns["INVOICE_NO"].ColumnName = "請求書番号";
                            dt.Columns["INVOICE_DATE"].ColumnName = "請求書日付";
                            dt.Columns["NCS_CUSTOMER_CODE"].ColumnName = "取引先ｺｰﾄﾞ";
                            dt.Columns["BILL_SUPPLIER_NAME"].ColumnName = "請求先会社名";
                            dt.Columns["BILL_SUPPLIER_NAME_READING"].ColumnName = "ﾖﾐｶﾞﾅ";
                            dt.Columns["Product_name"].ColumnName = "品名";
                            dt.Columns["BILL_AMOUNT"].ColumnName = "請求金額";
                            dt.Columns["BILL_TAX"].ColumnName = "消費税";
                            dt.Columns["BILL_PRICE"].ColumnName = "合計";
                            dt.Columns["PLAN_DEPOSIT_DATE"].ColumnName = "入金予定日";
                            dt.Columns["STATUS_ACTUAL_DEPOSIT_DATE"].ColumnName = "入金実績日";
                            dt.Columns.Remove("YEAR_MONTH");
                            dt.Columns["Remark"].ColumnName = "備考";
                            //Exporting to Excel
                            Utility.SchedulePaymentExcel(dt, saveCSV.FileName, "Amigo入金リスト", year_month.Trim(), "Amigo入金リスト");
                            MetroMessageBox.Show(this, "\n" + "Amigo入金リスト " + Messages.ResultOfDepositDatePlan.ExcelDownloaded, "Excel Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoRecordToDownload, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region AccountReceivableOutputButton
        private void BtnAccountReceivableOutput_Click(object sender, EventArgs e)
        {
            DownloadAccountReceivableData("売掛金リスト");
        }
        #endregion

        #region ThisMonthDepositButton
        private void BtnThisMonthDeposit_Click(object sender, EventArgs e)
        {
            DownloadAccountReceivableData("当月入金出力");
        }
        #endregion

        #region DownloadAccountReceivableData
        private void DownloadAccountReceivableData(string filename)
        {
            bool status = CheckInput();// validate text boxes
            if (status)
            {
                SaveFileDialog saveCSV = new SaveFileDialog();
                saveCSV.Filter = "Excel file (*.xlsx)|*.xlsx| (*.xls)|*.xls| (*.xlsm)|*.xlsm| All Files (*.*)|*.*";
                saveCSV.FileName = filename;
                try
                {
                    Controllers.frm37Controller oController = new Controllers.frm37Controller();
                    DataTable dt = oController.GetAccountReceivable(conditions.BILLING_CLASSIFICATION,
                                                                 conditions.FROM_BILLING_DATE,
                                                                 conditions.TO_BILLING_DATE,
                                                                 conditions.FROM_SECHEDULE_PAYMENT,
                                                                 conditions.TO_SECHEDULE_PAYMENT,
                                                                 conditions.FROM_DEPOSIT_RECORD_DATE,
                                                                 conditions.TO_DEPOSIT_RECORD_DATE,
                                                                 conditions.DEPOSIT_RULE,
                                                                 conditions.WITH_OR_WITHOUT_PAYMENT,
                                                                 conditions.BILLING_COMPANY_NAME);

                    if (dt.Rows.Count > 0)
                    {
                        if (saveCSV.ShowDialog() == DialogResult.OK) // save as dialog
                        {
                            //change column names
                            dt.Columns["ORDER_NO"].ColumnName = "ｵｰﾀﾞｰNo";
                            dt.Columns["NCS_CUSTOMER_CODE"].ColumnName = "取引先ｺｰﾄﾞ";
                            dt.Columns["INVOICE"].ColumnName = "請求書";
                            dt.Columns["INVOICE_DATE"].ColumnName = "請求書日付";
                            dt.Columns["RangeData"].ColumnName = "範囲";
                            dt.Columns["Division"].ColumnName = "区分";
                            dt.Columns["STATUS_PLAN_DEPOSIT_DATE"].ColumnName = "入金予定日";
                            dt.Columns["ACTUAL_DEPOSIT_DATE"].ColumnName = "入金実績日";
                            dt.Columns["BILL_AMOUNT"].ColumnName = "入金額";
                            dt.Columns["BILL_TAX"].ColumnName = "消費税";
                            dt.Columns["PROPERTY_NAME"].ColumnName = "物件名称";
                            dt.Columns["TRANSFER_DATA"].ColumnName = "振替";
                            dt.Columns["Responsible"].ColumnName = "担当";
                            dt.Columns["Hanging"].ColumnName = "掛け";
                            dt.Columns["RegistrationDate"].ColumnName = "登録日";
                            dt.Columns["Humor"].ColumnName = "口種";
                            dt.Columns["Change_date"].ColumnName = "変更日";
                            dt.Columns["tax_rate"].ColumnName = "税率";


                            //Exporting to Excel
                            Utility.AccountReceivableExcel(dt, saveCSV.FileName, filename);
                            MetroMessageBox.Show(this, "\n" + filename + " " + Messages.ResultOfDepositDatePlan.ExcelDownloaded, "Excel Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoRecordToDownload, "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region CheckInputValidations
        private bool DateCheck(string value, bool fulldate)
        {
            if (!String.IsNullOrEmpty(value)) //if not empty validate
            {
           
                if (fulldate)
                {
                    if (!CheckUtility.DateFormatCheck(value)) //yyyy/MM/dd format
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.InvalidDateFormat, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    if (!CheckUtility.YearMonthCheck(value)) //yyyy/MM
                    {
                        if (!CheckUtility.YearCheck(value)) //yyyy
                        {
                            MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.YearMonthFormat, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }

            }
            return true;
        }
        #region DatePairCheck
        private bool DatePairCheck(string from, string to, bool fulldate)
        {
            //validate from date
            if (DateCheck(from, fulldate))
            {
                if (!string.IsNullOrEmpty(to))
                {
                    if (DateCheck(to, fulldate)) //validate to date
                    {
                        // validate From To 
                        if (!CheckUtility.DateRationalCheck(from , to))
                        {
                            MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.InvalidDateFromAndTo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        #endregion
        private bool CheckInput()
        {
            //get value from inputs
            GetConditions();

            //SECHEDULE_PAYMENT
            if (!DatePairCheck(conditions.FROM_SECHEDULE_PAYMENT, conditions.TO_SECHEDULE_PAYMENT, false))
            {
                return false;
            }

            //BILLING_DATE
            if (!DatePairCheck(conditions.FROM_BILLING_DATE, conditions.TO_BILLING_DATE, false))
            {
                return false;
            }

            //DEPOSIT_RECORD_DATE
            if (!DatePairCheck(conditions.FROM_DEPOSIT_RECORD_DATE, conditions.TO_DEPOSIT_RECORD_DATE, true))
            {
                return false;
            }


            if (conditions.IsAllEmpty())
            {
                MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoSearchConditions, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region CellEndEditEnd
        private void DgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            valid_edit = true;
        }
        #endregion

        #region CellEditErrorHandle
        private void DgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            valid_edit = true;
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.ColumnIndex == dgvList.Columns["STATUS_CASH_FORECAST_MM"].Index)//STATUS_CASH_FORECAST_MM
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 2)) // data length check
                {
                    valid_edit = false;
                }
                else
                {
                    try
                    {
                        int status_cash_forecast_mm = int.Parse(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()); //check if it is number

                        if (!(status_cash_forecast_mm >= 1 && status_cash_forecast_mm <= 12)) //check if it is between 1 to 12
                        {
                            valid_edit = false;
                        }
                    }
                    catch (Exception)
                    {
                        if (!string.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()))
                        {
                            valid_edit = false;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == dgvList.Columns["STATUS_PLAN_DEPOSIT_YYMM"].Index)//STATUS_PLAN_DEPOSIT_YYMM
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 4))//STATUS_PLAN_DEPOSIT_YYMM data length check
                {
                    valid_edit = false;
                }
                else
                {
                    try
                    {
                        int sttus_plan_deposit_yymm = int.Parse(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()); //check if it is number
                    }
                    catch (Exception)
                    {
                        if (!string.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()))
                        {
                            valid_edit = false;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == dgvList.Columns["DUNNING_DATE"].Index || // DUNNING_DATE
                     e.ColumnIndex == dgvList.Columns["ANSWER_DATE"].Index || //ANSWER_DATE
                     e.ColumnIndex == dgvList.Columns["PAYMENT_DUE_DATE"].Index || //PAYMENT_DUE_DATE
                     e.ColumnIndex == dgvList.Columns["STATUS_ACTUAL_MDB_UPDATE"].Index || //STATUS_ACTUAL_MDB_UPDATE
                     e.ColumnIndex == dgvList.Columns["STATUS_ACC_RECEIVABLE_DATE"].Index //STATUS_ACC_RECEIVABLE_DATE
                     ) 
            {
                if (dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "") // if cell is not empty
                {
                    valid_edit = CheckUtility.DateFormatCheck(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
                }
            }
            else if (e.ColumnIndex == dgvList.Columns["ANSWER_MEMO"].Index)//MEMO
            {
                if (!Utility.CheckDataLength(dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), 50))// Memo data length
                {
                    valid_edit = false;
                }
            }

            if (valid_edit == false && search_or_back == false) //return to edit mode if search or back click event is not fired
            {
                MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.InvalidGridData, "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                dgvList.EndEdit();
                valid_edit = true;
                return;
            };
        }
        #endregion

        #region HandleDataTypeError
        private void DgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.InvalidGridData, "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        #endregion

        #region AdjustCheckBoxOnResize
        private void Frm37_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Columns["colCheck"].Width = 25;
        }
        #endregion

        #region CellColorWhenAllocatedCompletionDateIsNull
        private void DgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvList.Rows[e.RowIndex].Cells["INVOICE_ALLOCATED_COMPLETION_DATE"].Value.ToString() == "")
                {
                    e.CellStyle.BackColor = Color.Pink;
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region CheckOption
        private void CheckOption(bool value)
        {
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                row.Cells["colCheck"].Value = value;
            }
        }
        #endregion

        #region CheckAll
        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            CheckOption(true);
        }

        #endregion

        #region UncheckAll
        private void BtnUncheckAll_Click(object sender, EventArgs e)
        {
            CheckOption(false);
        }
        #endregion

        #region CheckSelectedRow
        private bool CheckSelectedRow()
        {
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

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

        private int CheckMultiRowSelected()
        {
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
            return status;
        }
        #endregion

        #region UpdateDateColumn
        private void UpdateDateColumn(string columnName)
        {
            
            string date = txtRegDate.Text;
            //validate from date
            if (!string.IsNullOrEmpty(date))
            {
                if (!DateCheck(txtRegDate.Text,true))
                {
                    return;
                }
            }

            if (CheckSelectedRow() == false) //if no row selected
            {
                MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    bool value = bool.Parse(dgvList[0, i].Value == null ? "false" : dgvList[0, i].Value.ToString());
                    if (value == true)
                    {
                        dgvList.Rows[i].Cells[columnName].Value =  date;
                    }
                }
            }
        }
        #endregion

        private void BtnDepositUpdate_Click(object sender, EventArgs e)
        {
            UpdateDateColumn("STATUS_ACTUAL_MDB_UPDATE");
        }

        private void BtnReceivableUpdate_Click(object sender, EventArgs e)
        {
            UpdateDateColumn("STATUS_ACC_RECEIVABLE_DATE");
        }

        private void BtnManualAllocation_Click(object sender, EventArgs e)
        {
            try
            {
                int status = CheckMultiRowSelected();
                if (status == 0)  //if no row selected
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (status == 2)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.MultipleRowSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManualAllocation();
                }
            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnManualAllocateComplete_Click(object sender, EventArgs e)
        {
            AllocationComplete(true);
        }

        private void AllocationComplete(bool allocate)
        {
            try
            {
                int status = CheckMultiRowSelected();
                if (status == 0)  //if no row selected
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.NoSelectedRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (status == 2)
                {
                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.MultipleRowSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataGridViewRow row in dgvList.Rows)
                    {
                        if (row.Cells["colCheck"].Value == null ? false : bool.Parse(row.Cells["colCheck"].Value.ToString()))
                        {
                            string receipt_allocation_date = Convert.ToString(row.Cells["RECEIPT_DETAILS_ALLOCATED_COMPLETION_DATE"].Value);
                            string invoice_allocation_date = Convert.ToString(row.Cells["INVOICE_ALLOCATED_COMPLETION_DATE"].Value);
                            int seq_no = string.IsNullOrEmpty(Convert.ToString(row.Cells["SEQ_NO"].Value)) ? 0 : int.Parse(Convert.ToString(row.Cells["SEQ_NO"].Value));
                            string receipt_type_of_allocation = Convert.ToString(row.Cells["RECEIPT_TYPE_OF_ALLOCATION"].Value);
                            string invoice_type_of_allocation = Convert.ToString(row.Cells["INVOICE_TYPE_OF_ALLOCATION"].Value);
                            string company_no_box = Convert.ToString(row.Cells["COMPANY_NO_BOX"].Value);
                            string year_month = Convert.ToString(row.Cells["YEAR_MONTH"].Value);

                            Controllers.frm37Controller oController = new Controllers.frm37Controller();
                            DataTable result;

                            if (allocate)
                            {
                                if (string.IsNullOrEmpty(receipt_allocation_date) || string.IsNullOrEmpty(invoice_allocation_date))
                                {

                                    oController.ManualAlloactionCompletion(receipt_allocation_date, invoice_allocation_date, seq_no, company_no_box, year_month, true);
                                    BindGrid();
                                }
                                else
                                {
                                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.CannotBeAllocated, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if ((!string.IsNullOrEmpty(receipt_allocation_date)) && (receipt_type_of_allocation == "3") || 
                                    (!string.IsNullOrEmpty(invoice_allocation_date)) && (invoice_type_of_allocation == "3"))
                                {
                                    result = oController.ManualAlloactionCompletion(receipt_allocation_date, invoice_allocation_date, seq_no, company_no_box, year_month, false);
                                    BindGrid();
                                }
                                else
                                {
                                    MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.CannotBeCanceled, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManualAllocation()
        {
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Cells["colCheck"].Value == null ? false : bool.Parse(row.Cells["colCheck"].Value.ToString()))
                {
                    string invoice_allocation_date = row.Cells["INVOICE_ALLOCATED_COMPLETION_DATE"].Value.ToString().Trim();
                    string receipt_allocation_date = row.Cells["RECEIPT_DETAILS_ALLOCATED_COMPLETION_DATE"].Value.ToString().Trim();

                    if (string.IsNullOrEmpty(invoice_allocation_date) && string.IsNullOrEmpty(receipt_allocation_date)) //if both are not null
                    {
                        string seq_no = row.Cells["SEQ_NO"].Value.ToString().Trim();
                        string company_no_box = row.Cells["COMPANY_NO_BOX"].Value.ToString().Trim();
                        string year_month = row.Cells["YEAR_MONTH"].Value.ToString();

                        Controllers.frm37Controller oController = new Controllers.frm37Controller();
                        DataTable result = oController.ManualAlloaction(company_no_box, year_month);
                        if (result.Rows.Count <= 0)
                        {
                            MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.CannotbeManuallyAllocated, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            BindGrid();
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ResultOfDepositDatePlan.CannotbeManuallyAllocated, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnManualCancelAllocate_Click(object sender, EventArgs e)
        {
            AllocationComplete(false);
        }

        private void DgvList_Sorted(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                //ソートが行われた場合、更新系ボタンは非活性とする
                updateBtnEnabled(false);
            }
        }

        private void updateBtnEnabled(bool enbaled)
        {
            btnRegister.Enabled = enbaled;
            btnDepositUpdate.Enabled = enbaled;
            btnReceivableUpdate.Enabled = enbaled;
            btnManualAllocation.Enabled = enbaled;
            btnManualAllocateComplete.Enabled = enbaled;
            btnManualCancelAllocate.Enabled = enbaled;
        }
    }

}
