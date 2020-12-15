using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using AmigoPaperWorkProcessSystem.Forms.Jimugo;
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
    public partial class frmInvoiceList : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "";

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colEFFECTIVE_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10, Min=8},
            new Validate{ Name = "colCONTRACT_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10, Min=8},
            new Validate{ Name = "colSPECIAL_NOTES_1", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_2", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_3", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_4", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colNCS_CUSTOMER_CODE", Type = Utility.DataType.FULL_WIDTH, Edit=true, Require=false, Max=6 },
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_1", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_1", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_2", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_2", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_3", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_3", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_4", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_4", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BILLING_INTERVAL", Type = Utility.DataType.TEXT, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_DEPOSIT_RULES", Type = Utility.DataType.TEXT, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_TRANSFER_FEE", Type = Utility.DataType.MINIMUM_TRANSFER_FEE, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_EXPENSES", Type = Utility.DataType.MINIMUM_EXPENSE, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colCOMPANY_NAME_CHANGED_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colPREVIOUS_COMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 80},
            new Validate{ Name = "colOBOEGAKI_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10}
        };

        private string[] dummyColumns = {
            "No",
            "COMPANY_NO_BOX",
            "COMPANY_NAME",
            "KEY_SOURCE_MONTHLY_USAGE_FEE",
            "SUPPLIER_INITIAL_EXPENSE",
            "SUPPLIER_MONTHLY_USAGE_FEE",
            "BROWSING_INITIAL_EXPENSE",
            "YEARLY_USAGE_FEE",
            "POSTAL_MAIL",
            "WEB",
            "Email",
            "CREDIT_CARD",
            "OTHER",
            "Key_source_Monthly_usage_fee_REQ_SEQ",
            "Supplier_Initial_expense_REQ_SEQ",
            "Supplier_Monthly_usage_fee_REQ_SEQ",
            "Production_information_browsing_Initial_expense_REQ_SEQ",
            "View_production_information_Annual_usage_fee_REQ_SEQ",
         };

        private string[] alignBottoms = {
               "colKEY_SOURCE_MONTHLY_USAGE_FEE",
               "coLSUPPLIER_INITIAL_EXPENSE",
               "colSUPPLIER_MONTHLY_USAGE_FEE",
               "colBROWSING_INITIAL_EXPENSE",
               "colYEARLY_USAGE_FEE",

               "coLPOSTAL_MAIL",
               "colWEB",
               "coLEmail",
               "colCREDIT_CARD",
               "colOTHER"
        };

        #endregion

        #region Properties

        private decimal _keySourceTotal = 0;
        public decimal keySourceTotal
        {
            get { return _keySourceTotal; }
            set { _keySourceTotal = value; }
        }

        private decimal _SupplierExpenseTotal =0;
        public decimal SupplierExpenseTotal
        {
            get { return _SupplierExpenseTotal; }
            set { _SupplierExpenseTotal = value; }
        }

        private decimal _SupplierMonthlyUsageFeeTotal = 0;
        public decimal SupplierMonthlyUsageFeeTotal
        {
            get { return _SupplierMonthlyUsageFeeTotal; }
            set { _SupplierMonthlyUsageFeeTotal = value; }
        }

        private decimal _SupplierBrowsingInitialExpenseTotal = 0;
        public decimal SupplierBrowsingInitialExpenseTotal
        {
            get { return _SupplierBrowsingInitialExpenseTotal; }
            set { _SupplierBrowsingInitialExpenseTotal = value; }
        }

        private decimal _YearlyUsageFeeTotal = 0;
        public decimal YearlyUsageFeeTotal
        {
            get { return _YearlyUsageFeeTotal; }
            set { _YearlyUsageFeeTotal = value; }
        }

        private decimal _InvoiceAmountTotal = 0;
        public decimal InvoiceAmountTotal
        {
            get { return _InvoiceAmountTotal; }
            set { _InvoiceAmountTotal = value; }
        }

        private decimal _PostalMailTotal = 0;
        public decimal PostalMailTotal
        {
            get { return _PostalMailTotal; }
            set { _PostalMailTotal = value; }
        }

        private decimal _EmailTotal = 0;
        public decimal EmailTotal
        {
            get { return _EmailTotal; }
            set { _EmailTotal = value; }
        }

        private decimal _WebTotal = 0;
        public decimal WebTotal
        {
            get { return _WebTotal; }
            set { _WebTotal = value; }
        }

        private decimal _CreditCardTotal = 0;
        public decimal CreditCardTotal
        {
            get { return _CreditCardTotal; }
            set { _CreditCardTotal = value; }
        }

        private decimal _OtherTotal = 0;
        public decimal OtherTotal
        {
            get { return _OtherTotal; }
            set { _OtherTotal = value; }
        }

        #endregion

        #region Constructors
        public frmInvoiceList()
        {
            InitializeComponent();
        }

        public frmInvoiceList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }

        #endregion

        #region AlignBottomHeaders
        private void AlignBottomHeaders()
        {
            foreach (string item in alignBottoms)
            {
                dgvList.Columns[item].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            }
        }
        #endregion

        #region FormLoad
        private void FrmInvoiceList_Load(object sender, EventArgs e)
        {

            //set title
            lblMenu.Text = programName;
            this.Text = "[" + programID + "] " + programName;

            txtBilling_Date.Text = DateTime.Now.ToString("yyyy/MM");

            //utility
            uIUtility = new UIUtility(dgvList, null, null, null, dummyColumns);
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
            //SetDefaultColumnWidths(); //adjust checkbox sizes
            uIUtility.DummyTable(150);// add dummy table to merge columns
            uIUtility.DisableAutoSort();//disable autosort
            PopulateDropdowns();

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
            dgvList.Columns["colCOMPANY_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            AlignBottomHeaders();

            uIUtility.MetaData.Offset = 0;
            try
            {
                uIUtility.MetaData.Limit = int.Parse(cboLimit.SelectedValue.ToString());

            }
            catch (Exception)
            {
                uIUtility.MetaData.Limit = 0;
            }
        }
        #endregion

        #region DrawGradHeader
        public void dataGridHeaders()
        {
            String H1 = (25160).ToString();
            String H2 = (25160).ToString();
            String H3 = (25160).ToString();
            String H4 = (25160).ToString();
            String H5 = (25160).ToString();


            //int sum = 0;
            //for (int i = 0; i < dgvList.Rows.Count; ++i)
            //{
            //    sum += Convert.ToInt32(dgvList.Rows[i].Cells[5].Value);
            //    //dataGridView1.SelectedCells[0].Value.ToString()
            //}

            dgvList.Columns["colNO"].HeaderText = "No";
            dgvList.Columns["coLCOMPANY_NO_BOX"].HeaderText = "会社番号+BOX";
            dgvList.Columns["colCOMPANY_NAME"].HeaderText = "会社名";
            //dgvList.Columns["colKEY_SOURCE_MONTHLY_USAGE_FEE"].HeaderText = sum.ToString();
            dgvList.Columns["coLSUPPLIER_INITIAL_EXPENSE"].HeaderText = H2;
            dgvList.Columns["colSUPPLIER_MONTHLY_USAGE_FEE"].HeaderText = H3;
            dgvList.Columns["colBROWSING_INITIAL_EXPENSE"].HeaderText = H4;
            dgvList.Columns["colYEARLY_USAGE_FEE"].HeaderText = H5;

            dgvList.Columns[8].HeaderText = "会社名";
            dgvList.Columns[9].HeaderText = "会社名";
            dgvList.Columns[10].HeaderText = "会社名";
            dgvList.Columns[11].HeaderText = "会社名";
            dgvList.Columns[12].HeaderText = "会社名";
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Second_Column_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }

        private void Add_Monthly_Usage_Fee_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Initial_Expense_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Yearly_Usage_Fee_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_PostalMail_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_WEB_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Email_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_CreditCard_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Other_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }


        private void Add_Third_Column_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }

        private void Add_Company_Name_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Invoice_Amount_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Invoice_Amount_Total_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Invoice_Method_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Key_Source_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Supplier_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void Add_Production_Information_Browsing_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row, int extra_merge, StringAlignment halign, StringAlignment valign)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row, extra_merge, halign, valign);
        }
        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Company_Name_Header(e, 2, 1, "会社名", 4, 0, 2, StringAlignment.Center, StringAlignment.Center);

            Add_Invoice_Amount_Header(e, 3, 1, "請求金額", 4, 0, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Invoice_Amount_Total_Header(e, 4, 4, string.Format("{0:#,0}", InvoiceAmountTotal), 4, 0, 0, StringAlignment.Far, StringAlignment.Center);
            

            //Third ColumnMerge
            Add_Key_Source_Header(e, 3, 1, "要元", 4, 1, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Monthly_Usage_Fee_Header(e, 3, 1, "月額利用料", 4, 2, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Monthly_Usage_Fee_Header(e, 3, 1, string.Format("{0:#,0}", keySourceTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far); //"123,123"

            Add_Supplier_Header(e, 4, 2, "サプライヤ", 4, 1, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Initial_Expense_Header(e, 4, 1, "初期費用", 4, 2, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Initial_Expense_Header(e, 4, 1, string.Format("{0:#,0}", SupplierExpenseTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_Monthly_Usage_Fee_Header(e, 5, 1, "月額利用料", 4, 2, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Monthly_Usage_Fee_Header(e, 5, 1, string.Format("{0:#,0}", SupplierMonthlyUsageFeeTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);

            Add_Production_Information_Browsing_Header(e, 6, 2, "生産情報閲覧", 4, 1, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Initial_Expense_Header(e, 6, 1, "初期費用", 4, 2, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Initial_Expense_Header(e, 6, 1, string.Format("{0:#,0}", SupplierBrowsingInitialExpenseTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_Yearly_Usage_Fee_Header(e, 7, 1, "年額利用料", 4, 2, 0, StringAlignment.Center, StringAlignment.Center);
            Add_Yearly_Usage_Fee_Header(e, 7, 1, string.Format("{0:#,0}", YearlyUsageFeeTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);

            Add_Invoice_Method_Header(e, 8, 5, "請求方法", 4, 0, 0, StringAlignment.Center, StringAlignment.Center);
            Add_PostalMail_Header(e, 8, 1, "郵送", 4, 1, 1, StringAlignment.Center, StringAlignment.Center);
            Add_PostalMail_Header(e, 8, 1, string.Format("{0:#,0}", PostalMailTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_WEB_Header(e, 9, 1, "WEB", 4, 1, 1, StringAlignment.Center, StringAlignment.Center);
            Add_WEB_Header(e, 9, 1, string.Format("{0:#,0}", WebTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_Email_Header(e, 10, 1, "Email", 4, 1, 1, StringAlignment.Center, StringAlignment.Center);
            Add_Email_Header(e, 10, 1, string.Format("{0:#,0}", EmailTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_CreditCard_Header(e, 11, 1, "クレカ", 4, 1, 1, StringAlignment.Center, StringAlignment.Center);
            Add_CreditCard_Header(e, 11, 1, string.Format("{0:#,0}", CreditCardTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
            Add_Other_Header(e, 12, 1, "その他", 4, 1, 1, StringAlignment.Center, StringAlignment.Center);
            Add_Other_Header(e, 12, 1, string.Format("{0:#,0}", OtherTotal), 4, 3, 0, StringAlignment.Far, StringAlignment.Far);
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

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
        }
        #endregion

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            uIUtility.MetaData.Offset = 0;
            try
            {
                uIUtility.MetaData.Limit = int.Parse(cboLimit.SelectedValue.ToString());

            }
            catch (Exception)
            {
                uIUtility.MetaData.Limit = 0;
            }
            try
            {
                    BindGrid();
            }
            catch (Exception)
            {
            }
            //BindGrid();
            //dataGridHeaders();
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtBilling_Date.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 6))
                {
                    return;
                }
                //assign search keywords
                DateTime YEAR_MONTH = Convert.ToDateTime(txtBilling_Date.Text);
                String strYearMonth = YEAR_MONTH.ToString("yyyyMM");
                
                //assign search keywords
                frmInvoiceListController oController = new frmInvoiceListController();
                DataSet ds = oController.GetInvoiceList(strYearMonth, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData); //need to add more parameter
                DataTable dtList = ds.Tables[0];
                DataTable dtTotal = ds.Tables[1];

                InvoiceAmountTotal = 0;
                keySourceTotal = 0;
                SupplierMonthlyUsageFeeTotal = 0;
                SupplierExpenseTotal = 0;
                SupplierBrowsingInitialExpenseTotal = 0;
                YearlyUsageFeeTotal = 0;
                PostalMailTotal = 0;
                WebTotal = 0;
                EmailTotal = 0;
                CreditCardTotal = 0;
                OtherTotal = 0;

                foreach (DataRow row in dtTotal.Rows)
                {
                    keySourceTotal += Convert.ToDecimal(row["KEY_SOURCE_MONTHLY_USAGE_FEE"].ToString());
                    SupplierExpenseTotal += Convert.ToDecimal(row["SUPPLIER_INITIAL_EXPENSE"].ToString());
                    SupplierMonthlyUsageFeeTotal += Convert.ToDecimal(row["SUPPLIER_MONTHLY_USAGE_FEE"].ToString());
                    SupplierBrowsingInitialExpenseTotal += Convert.ToDecimal(row["BROWSING_INITIAL_EXPENSE"].ToString());
                    YearlyUsageFeeTotal += Convert.ToDecimal(row["YEARLY_USAGE_FEE"].ToString());
                    InvoiceAmountTotal = keySourceTotal + SupplierExpenseTotal + SupplierMonthlyUsageFeeTotal + SupplierBrowsingInitialExpenseTotal + YearlyUsageFeeTotal;

                    if (row["POSTAL_MAIL"].ToString() == "●")
                    {
                        PostalMailTotal++;
                    }
                    if (row["WEB"].ToString() == "●")
                    {
                        WebTotal++;
                    }
                    if (row["Email"].ToString() == "●")
                    {
                        EmailTotal++;
                    }
                    if (row["CREDIT_CARD"].ToString() == "●")
                    {
                        CreditCardTotal++;
                    }
                    if (row["OTHER"].ToString() == "●")
                    {
                        OtherTotal++;
                    }

                }

                //dgvList.Columns["colCOMPANY_NAME"].HeaderText = "請求金額計";
                //dgvList.Columns["colKEY_SOURCE_MONTHLY_USAGE_FEE"].HeaderText = keySourceTotal.ToString();
                //dgvList.Columns["coLSUPPLIER_INITIAL_EXPENSE"].HeaderText = SupplierExpenseTotal.ToString();
                //dgvList.Columns["colSUPPLIER_MONTHLY_USAGE_FEE"].HeaderText = SupplierMonthlyUsageFeeTotal.ToString();
                //dgvList.Columns["colBROWSING_INITIAL_EXPENSE"].HeaderText = SupplierBrowsingInitialExpenseTotal.ToString();
                //dgvList.Columns["colYEARLY_USAGE_FEE"].HeaderText = YearlyUsageFeeTotal.ToString();

                //dgvList.Columns["coLEmail"].HeaderText = EmailTotal.ToString(); //coLEmail
                //dgvList.Columns["coLPOSTAL_MAIL"].HeaderText = PostalMailTotal.ToString(); //coLEmail
                //dgvList.Columns["colWEB"].HeaderText = WebTotal.ToString(); //coLEmail
                //dgvList.Columns["colCREDIT_CARD"].HeaderText = CreditCardTotal.ToString(); //coLEmail
                //dgvList.Columns["colOTHER"].HeaderText = OtherTotal.ToString(); //coLEmail

                if (dtList.Rows.Count > 0)
                {
                    uIUtility.dtList = dtList;
                    dgvList.DataSource = uIUtility.dtList;
                    uIUtility.dtOrigin = uIUtility.dtList.Copy();

                    //pagination
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }
                else
                {
                    //clear data except headers
                    uIUtility.ClearDataGrid();
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }

                uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
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
        #endregion

        #region CreateCSVButton
        private void BtnCreateCSVFile_Click(object sender, EventArgs e)
        {
            if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtBilling_Date.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 6))
            {
                return;
            }
            try
            {
                SaveFileDialog saveCSV = new SaveFileDialog();
                saveCSV.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
                DateTime yearMonth = Convert.ToDateTime(txtBilling_Date.Text);
                String YEAR_MONTH = yearMonth.ToString("yyyyMM");
                saveCSV.FileName = "NCS" + YEAR_MONTH + "-" + System.DateTime.Now.ToString("yyyyMMddHHmmss");

                frmInvoiceListController oController = new frmInvoiceListController();
                DataTable dt = oController.GetInvoiceListForCSVCreate(txtBilling_Date.Text);

                try
                {
                    string return_message = "";
                    return_message = dt.Rows[0]["Error Message"].ToString();
                    if (!string.IsNullOrEmpty(return_message))
                    {
                        MetroMessageBox.Show(this, "\n" + return_message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {
                    //Exporting to Excel
                    if (dt.Rows.Count > 0)
                    {
                        if (saveCSV.ShowDialog() == DialogResult.OK) // save as dialog
                        {
                            Utility.WriteToCsvFile(dt, saveCSV.FileName);
                            //MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.CSVDownloaded, "CSV Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + Messages.ComparisonResultDetail.NoRecordToDownload, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
        #endregion

        #region ButtonCreateInvoiceData
        private void BtnCreateInvoiceData_Click(object sender, EventArgs e)
        {
            if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtBilling_Date.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 6))
            {
                return;
            }
            string status = "0";
            frmInvoiceListController oController = new frmInvoiceListController();
            DataTable dt = oController.CreateInvoiceData(txtBilling_Date.Text,status);

            string return_message = "";
            string count = "";
            string strMsg = "";
            try
            {
                return_message = dt.Rows[0]["Error Message"].ToString();
                count = dt.Rows[0]["Count"].ToString();
            }
            catch (Exception)
            {

            }

            if (!string.IsNullOrEmpty(return_message) && count == "1")
            {
                var confirmResult = MetroMessageBox.Show(this, "\n" + return_message, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.OK)
                {
                    status = "1";
                    //send to web service
                    frmInvoiceListController controller = new frmInvoiceListController();
                    DataTable dtResult = oController.CreateInvoiceData(txtBilling_Date.Text,status);

                    
                    try
                    {
                        strMsg = dtResult.Rows[0]["Error Message"].ToString();
                        count = dtResult.Rows[0]["Count"].ToString();
                        //messageInfo = dtResult.Rows[0]["Message Info"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    if (!string.IsNullOrEmpty(strMsg) && !string.IsNullOrEmpty(count))
                    {
                        if(count == "2")
                        {
                            MetroMessageBox.Show(this, "\n" + strMsg, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }

                        if (count == "0")
                        {
                            MetroMessageBox.Show(this, "\n" + strMsg, "Fail", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    }

                }
            }
            else
            {
                if(count == "2")
                {
                    MetroMessageBox.Show(this, "\n" + return_message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                if (count == "0")
                {
                    MetroMessageBox.Show(this, "\n" + return_message, "Fail", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                
            }
        }
        #endregion

        #region CellContentClickEvent
        private void DgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Key_source_Monthly_usage_fee_REQ_SEQ = 0;
            int Supplier_Initial_expense_REQ_SEQ = 0;
            int Supplier_Monthly_usage_fee_REQ_SEQ = 0;
            int Production_information_browsing_Initial_expense_REQ_SEQ = 0;
            int View_production_information_Annual_usage_fee_REQ_SEQ = 0;
            string COMPANY_NO_BOX = "";
            string colName = dgvList.Columns[e.ColumnIndex].Name;

            try
            {
                COMPANY_NO_BOX = dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
            int REQ_SEQ;

            if (!string.IsNullOrEmpty(COMPANY_NO_BOX) && colName == "coLCOMPANY_NO_BOX")
            {
                if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["Key_source_Monthly_usage_fee_REQ_SEQ"].Value.ToString()))
                {
                    Key_source_Monthly_usage_fee_REQ_SEQ = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["Key_source_Monthly_usage_fee_REQ_SEQ"].Value.ToString());

                }

                if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["Supplier_Initial_expense_REQ_SEQ"].Value.ToString()))
                {
                    Supplier_Initial_expense_REQ_SEQ = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["Supplier_Initial_expense_REQ_SEQ"].Value.ToString());
                }

                if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["Supplier_Monthly_usage_fee_REQ_SEQ"].Value.ToString()))
                {
                    Supplier_Monthly_usage_fee_REQ_SEQ = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["Supplier_Monthly_usage_fee_REQ_SEQ"].Value.ToString());
                }

                if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["Production_information_browsing_Initial_expense_REQ_SEQ"].Value.ToString()))
                {
                    Production_information_browsing_Initial_expense_REQ_SEQ = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["Production_information_browsing_Initial_expense_REQ_SEQ"].Value.ToString());
                }

                if (!String.IsNullOrEmpty(dgvList.Rows[e.RowIndex].Cells["View_production_information_Annual_usage_fee_REQ_SEQ"].Value.ToString()))
                {
                    View_production_information_Annual_usage_fee_REQ_SEQ = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["View_production_information_Annual_usage_fee_REQ_SEQ"].Value.ToString());
                }

                var anArray = new int[] { Key_source_Monthly_usage_fee_REQ_SEQ, Supplier_Initial_expense_REQ_SEQ, Supplier_Monthly_usage_fee_REQ_SEQ, Production_information_browsing_Initial_expense_REQ_SEQ, View_production_information_Annual_usage_fee_REQ_SEQ };
                REQ_SEQ = anArray.Max();

                //string value = Convert.ToString(row.Cells["colBREAK_DOWN"].Value);
                //if (value != null)
                //{
                frmCustomerMasterPopup frm = new frmCustomerMasterPopup(
                COMPANY_NO_BOX,
                REQ_SEQ.ToString()
                    );

                frm.Show();

                //    //if (frm.Close()==true)
                //    //{
                //    //    row.Cells["colORDER_DATE"].Value = frm.ORDER_DATE;
                //    //    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                //    //    frm.Dispose();
                //    //}
                //}
            }

        }
        #endregion

        #region DifferentButton
        private void BtnDifferent_Click(object sender, EventArgs e)
        {
            if (!CheckUtility.SearchConditionCheck(this, lblDate.LabelText, txtBilling_Date.Text.Trim(), true, Utility.DataType.YEARMONTH, 7, 6))
            {
                return;
            }
            FrmMonthlySaleAggregationList frm = new FrmMonthlySaleAggregationList("CTG010", "月次売上集計", txtBilling_Date.Text.Trim());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        #endregion

        #region NextButton
        private void BtnNext_Click(object sender, EventArgs e)
        {
                uIUtility.MetaData.Offset += int.Parse(cboLimit.SelectedValue.ToString());
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

        #region FirstButton
        private void BtnFirst_Click(object sender, EventArgs e)
        {
                uIUtility.MetaData.Offset = 0;
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
    }
}
