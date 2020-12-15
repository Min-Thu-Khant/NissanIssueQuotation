using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerInvoiceList
    {
        #region Declare
        MetaResponse response;
        Stopwatch timer;
        string con = Properties.Settings.Default.MyConnection;
        String UPDATED_AT_DATETIME;
        string CURRENT_DATETIME;
        string CURRENT_USER;
        DateTime TEMP = DateTime.Now;
        #endregion

        #region Constructor
        public ControllerInvoiceList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerInvoiceList(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region getRequestDetailList
        public MetaResponse getInvoiceList(String BILLING_DATE, int OFFSET, int LIMIT)
        {
            try
            {
                string strMessage = "";
                int TOTAL = 0;
                string checkGetOrCreate = "GET";

                #region Declare
                decimal Key_source_Monthly_usage_fee_REQ_SEQ = 0;
                decimal Key_source_Monthly_usage_fee = 0;
                decimal Key_source_Monthly_usage_fee_DISCOUNTED = 0;
                decimal Key_source_Monthly_usage_fee_TAX = 0;
                decimal Key_source_Monthly_usage_fee_INCLUDING_TAX = 0;

                decimal Supplier_Initial_expense_REQ_SEQ = 0;
                decimal Supplier_Initial_expense = 0;
                decimal Supplier_Initial_expense_DISCOUNTED = 0;
                decimal Supplier_Initial_expense_TAX = 0;
                decimal Supplier_Initial_expense_INCLUDING_TAX = 0;

                decimal Supplier_Monthly_usage_fee_REQ_SEQ = 0;
                decimal supplier_Monthly_usage_fee = 0;
                decimal Supplier_Monthly_usage_fee_DISCOUNTED = 0;
                decimal Supplier_Monthly_usage_fee_TAX = 0;
                decimal Supplier_Monthly_usage_fee_INCLUDING_TAX = 0;

                decimal Production_information_browsing_Initial_expense_REQ_SEQ = 0;
                decimal Production_information_browsing_Initial_expense = 0;
                decimal Production_information_browsing_Initial_expense_DISCOUNTED = 0;
                decimal Production_information_browsing_Initial_expense_TAX;
                decimal Production_information_browsing_Initial_expense_INCLUDING_TAX = 0;

                decimal View_production_information_Annual_usage_fee_REQ_SEQ = 0;
                decimal Viewing_production_information_Annual_usage_fee = 0;
                decimal View_production_information_Annual_usage_fee_DISCOUNTED = 0;
                decimal View_production_information_Annual_usage_fee_TAX = 0;
                decimal View_production_information_Annual_usage_fee_INCLUDING_TAX = 0;
                #endregion

                INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);
                DataTable dt = DAL_INVOICE_INFO.GetInvoiceList(BILLING_DATE, OFFSET, LIMIT, checkGetOrCreate, out strMessage, out TOTAL);

                DataTable dtAll = DAL_INVOICE_INFO.GetInvoiceListTotal(BILLING_DATE ,out strMessage);

                #region Create Datatable
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("No");
                dtResult.Columns.Add("COMPANY_NO_BOX");
                dtResult.Columns.Add("COMPANY_NAME");
                dtResult.Columns.Add("KEY_SOURCE_MONTHLY_USAGE_FEE", typeof(decimal));
                dtResult.Columns.Add("SUPPLIER_INITIAL_EXPENSE", typeof(decimal));
                dtResult.Columns.Add("SUPPLIER_MONTHLY_USAGE_FEE", typeof(decimal));
                dtResult.Columns.Add("BROWSING_INITIAL_EXPENSE", typeof(decimal));
                dtResult.Columns.Add("YEARLY_USAGE_FEE", typeof(decimal));
                dtResult.Columns.Add("POSTAL_MAIL");
                dtResult.Columns.Add("WEB");
                dtResult.Columns.Add("Email");
                dtResult.Columns.Add("CREDIT_CARD");
                dtResult.Columns.Add("OTHER");
                dtResult.Columns.Add("Key_source_Monthly_usage_fee_REQ_SEQ");
                dtResult.Columns.Add("Supplier_Initial_expense_REQ_SEQ");
                dtResult.Columns.Add("Supplier_Monthly_usage_fee_REQ_SEQ");
                dtResult.Columns.Add("Production_information_browsing_Initial_expense_REQ_SEQ");
                dtResult.Columns.Add("View_production_information_Annual_usage_fee_REQ_SEQ");
                #endregion

                #region Create Datatable ForTotal
                DataTable dtTotal = new DataTable();
                dtTotal.Columns.Add("KEY_SOURCE_MONTHLY_USAGE_FEE", typeof(decimal));
                dtTotal.Columns.Add("SUPPLIER_INITIAL_EXPENSE", typeof(decimal));
                dtTotal.Columns.Add("SUPPLIER_MONTHLY_USAGE_FEE", typeof(decimal));
                dtTotal.Columns.Add("BROWSING_INITIAL_EXPENSE", typeof(decimal));
                dtTotal.Columns.Add("YEARLY_USAGE_FEE", typeof(decimal));
                dtTotal.Columns.Add("POSTAL_MAIL");
                dtTotal.Columns.Add("WEB");
                dtTotal.Columns.Add("Email");
                dtTotal.Columns.Add("CREDIT_CARD");
                dtTotal.Columns.Add("OTHER");
                #endregion

                foreach (DataRow row in dt.Rows)
                {
                   
                    #region SetValue To DataTable
                    DataRow newRow = dtResult.NewRow();
                    newRow["No"] = row["No"];
                    newRow["COMPANY_NO_BOX"] = row["COMPANY_NO_BOX"];
                    newRow["COMPANY_NAME"] = row["COMPANY_NAME"];

                    Key_source_Monthly_usage_fee_REQ_SEQ = NullOrEmpty(row["Key_source_Monthly_usage_fee_REQ_SEQ"].ToString());
                    Key_source_Monthly_usage_fee = NullOrEmpty(row["Key_source_Monthly_usage_fee"].ToString());
                    Key_source_Monthly_usage_fee_DISCOUNTED = NullOrEmpty(row["Key_source_Monthly_usage_fee_DISCOUNTED"].ToString());
                    Key_source_Monthly_usage_fee_TAX = NullOrEmpty(row["Key_source_Monthly_usage_fee_TAX"].ToString());
                    Key_source_Monthly_usage_fee_INCLUDING_TAX = NullOrEmpty(row["Key_source_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                    Supplier_Initial_expense_REQ_SEQ = NullOrEmpty(row["Supplier_Initial_expense_REQ_SEQ"].ToString());
                    Supplier_Initial_expense = NullOrEmpty(row["Supplier_Initial_expense"].ToString());
                    Supplier_Initial_expense_DISCOUNTED = NullOrEmpty(row["Supplier_Initial_expense_DISCOUNTED"].ToString());
                    Supplier_Initial_expense_TAX = NullOrEmpty(row["Supplier_Initial_expense_TAX"].ToString());
                    Supplier_Initial_expense_INCLUDING_TAX = NullOrEmpty(row["Supplier_Initial_expense_INCLUDING_TAX"].ToString());

                    Supplier_Monthly_usage_fee_REQ_SEQ = NullOrEmpty(row["Supplier_Monthly_usage_fee_REQ_SEQ"].ToString());
                    supplier_Monthly_usage_fee = NullOrEmpty(row["Supplier_Monthly_usage_fee"].ToString());
                    Supplier_Monthly_usage_fee_DISCOUNTED = NullOrEmpty(row["Supplier_Monthly_usage_fee_DISCOUNTED"].ToString());
                    Supplier_Monthly_usage_fee_TAX = NullOrEmpty(row["Supplier_Monthly_usage_fee_TAX"].ToString());
                    Supplier_Monthly_usage_fee_INCLUDING_TAX = NullOrEmpty(row["Supplier_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                    Production_information_browsing_Initial_expense_REQ_SEQ = NullOrEmpty(row["Production_information_browsing_Initial_expense_REQ_SEQ"].ToString());
                    Production_information_browsing_Initial_expense = NullOrEmpty(row["Production_information_browsing_Initial_expense"].ToString());
                    Production_information_browsing_Initial_expense_DISCOUNTED = NullOrEmpty(row["Production_information_browsing_Initial_expense_DISCOUNTED"].ToString());
                    Production_information_browsing_Initial_expense_TAX = NullOrEmpty(row["Production_information_browsing_Initial_expense_TAX"].ToString());
                    Production_information_browsing_Initial_expense_INCLUDING_TAX = NullOrEmpty(row["Production_information_browsing_Initial_expense_INCLUDING_TAX"].ToString());

                    View_production_information_Annual_usage_fee_REQ_SEQ = NullOrEmpty(row["View_production_information_Annual_usage_fee_REQ_SEQ"].ToString());
                    Viewing_production_information_Annual_usage_fee = NullOrEmpty(row["Viewing_production_information_Annual_usage_fee"].ToString());
                    View_production_information_Annual_usage_fee_DISCOUNTED = NullOrEmpty(row["View_production_information_Annual_usage_fee_DISCOUNTED"].ToString());
                    View_production_information_Annual_usage_fee_TAX = NullOrEmpty(row["View_production_information_Annual_usage_fee_TAX"].ToString());
                    View_production_information_Annual_usage_fee_INCLUDING_TAX = NullOrEmpty(row["View_production_information_Annual_usage_fee_INCLUDING_TAX"].ToString());

                    decimal usageFee = Key_source_Monthly_usage_fee_REQ_SEQ + Key_source_Monthly_usage_fee + Key_source_Monthly_usage_fee_DISCOUNTED + Key_source_Monthly_usage_fee_TAX + Key_source_Monthly_usage_fee_INCLUDING_TAX;
                    newRow["KEY_SOURCE_MONTHLY_USAGE_FEE"] = usageFee;

                    decimal supplierInitialExpense = Supplier_Initial_expense_REQ_SEQ + Supplier_Initial_expense + Supplier_Initial_expense_DISCOUNTED + Supplier_Initial_expense_TAX + Supplier_Initial_expense_INCLUDING_TAX;
                    newRow["SUPPLIER_INITIAL_EXPENSE"] = supplierInitialExpense;

                    decimal supplierMonthlyUsageFee = Supplier_Monthly_usage_fee_REQ_SEQ + supplier_Monthly_usage_fee + Supplier_Monthly_usage_fee_DISCOUNTED + Supplier_Monthly_usage_fee_TAX + Supplier_Monthly_usage_fee_INCLUDING_TAX;
                    newRow["SUPPLIER_MONTHLY_USAGE_FEE"] = supplierMonthlyUsageFee;

                    decimal browsingInitialExpense = Production_information_browsing_Initial_expense_REQ_SEQ + Production_information_browsing_Initial_expense + Production_information_browsing_Initial_expense_DISCOUNTED + Production_information_browsing_Initial_expense_TAX + Production_information_browsing_Initial_expense_INCLUDING_TAX;
                    newRow["BROWSING_INITIAL_EXPENSE"] = browsingInitialExpense;

                    decimal yearlyUsageFee = View_production_information_Annual_usage_fee_REQ_SEQ + Viewing_production_information_Annual_usage_fee + View_production_information_Annual_usage_fee_DISCOUNTED + View_production_information_Annual_usage_fee_TAX + View_production_information_Annual_usage_fee_INCLUDING_TAX;
                    newRow["YEARLY_USAGE_FEE"] = yearlyUsageFee;


                    //newRow["INVOICE_METHOD"] = row["BILL_METHOD"];
                    string invoiceMethod = row["BILL_METHOD"].ToString();
                    if(invoiceMethod.Length == 5)
                    {
                        if (invoiceMethod.Substring(0, 1) == "1")
                        {
                            newRow["POSTAL_MAIL"] = "●";
                        }
                        if (invoiceMethod.Substring(1, 1) == "1")
                        {
                            newRow["WEB"] = "●";
                        }
                        if (invoiceMethod.Substring(2, 1) == "1")
                        {
                            newRow["Email"] = "●";
                        }
                        if (invoiceMethod.Substring(3, 1) == "1")
                        {
                            newRow["CREDIT_CARD"] = "●";
                        }
                        if (invoiceMethod.Substring(4, 1) == "1")
                        {
                            newRow["OTHER"] = "●";
                        }
                    }
                    newRow["Key_source_Monthly_usage_fee_REQ_SEQ"] = row["Key_source_Monthly_usage_fee_REQ_SEQ"];
                    newRow["Supplier_Initial_expense_REQ_SEQ"] = row["Supplier_Initial_expense_REQ_SEQ"];
                    newRow["Supplier_Monthly_usage_fee_REQ_SEQ"] = row["Supplier_Monthly_usage_fee_REQ_SEQ"];
                    newRow["Production_information_browsing_Initial_expense_REQ_SEQ"] = row["Production_information_browsing_Initial_expense_REQ_SEQ"];
                    newRow["View_production_information_Annual_usage_fee_REQ_SEQ"] = row["View_production_information_Annual_usage_fee_REQ_SEQ"];
                    dtResult.Rows.Add(newRow);
                    #endregion
                }


                foreach (DataRow row in dtAll.Rows)
                {
                    #region Declare
                    Key_source_Monthly_usage_fee_REQ_SEQ =0;
                    Key_source_Monthly_usage_fee =0;
                    Key_source_Monthly_usage_fee_DISCOUNTED = 0;
                    Key_source_Monthly_usage_fee_TAX = 0;
                    Key_source_Monthly_usage_fee_INCLUDING_TAX = 0;

                    Supplier_Initial_expense_REQ_SEQ = 0;
                    Supplier_Initial_expense = 0;
                    Supplier_Initial_expense_DISCOUNTED = 0;
                    Supplier_Initial_expense_TAX = 0;
                    Supplier_Initial_expense_INCLUDING_TAX = 0;

                    Supplier_Monthly_usage_fee_REQ_SEQ = 0;
                    supplier_Monthly_usage_fee = 0;
                    Supplier_Monthly_usage_fee_DISCOUNTED = 0;
                    Supplier_Monthly_usage_fee_TAX = 0;
                    Supplier_Monthly_usage_fee_INCLUDING_TAX = 0;

                    Production_information_browsing_Initial_expense_REQ_SEQ = 0;
                    Production_information_browsing_Initial_expense = 0;
                    Production_information_browsing_Initial_expense_DISCOUNTED = 0;
                    Production_information_browsing_Initial_expense_TAX = 0;
                    Production_information_browsing_Initial_expense_INCLUDING_TAX = 0;

                    View_production_information_Annual_usage_fee_REQ_SEQ = 0;
                    Viewing_production_information_Annual_usage_fee = 0;
                    View_production_information_Annual_usage_fee_DISCOUNTED = 0;
                    View_production_information_Annual_usage_fee_TAX = 0;
                    View_production_information_Annual_usage_fee_INCLUDING_TAX = 0;
                    #endregion

                    #region SetValue to DataTable
                    DataRow newRow = dtTotal.NewRow();

                    Key_source_Monthly_usage_fee_REQ_SEQ = NullOrEmpty(row["Key_source_Monthly_usage_fee_REQ_SEQ"].ToString());
                    Key_source_Monthly_usage_fee = NullOrEmpty(row["Key_source_Monthly_usage_fee"].ToString());
                    Key_source_Monthly_usage_fee_DISCOUNTED = NullOrEmpty(row["Key_source_Monthly_usage_fee_DISCOUNTED"].ToString());
                    Key_source_Monthly_usage_fee_TAX = NullOrEmpty(row["Key_source_Monthly_usage_fee_TAX"].ToString());
                    Key_source_Monthly_usage_fee_INCLUDING_TAX = NullOrEmpty(row["Key_source_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                    Supplier_Initial_expense_REQ_SEQ = NullOrEmpty(row["Supplier_Initial_expense_REQ_SEQ"].ToString());
                    Supplier_Initial_expense = NullOrEmpty(row["Supplier_Initial_expense"].ToString());
                    Supplier_Initial_expense_DISCOUNTED = NullOrEmpty(row["Supplier_Initial_expense_DISCOUNTED"].ToString());
                    Supplier_Initial_expense_TAX = NullOrEmpty(row["Supplier_Initial_expense_TAX"].ToString());
                    Supplier_Initial_expense_INCLUDING_TAX = NullOrEmpty(row["Supplier_Initial_expense_INCLUDING_TAX"].ToString());

                    Supplier_Monthly_usage_fee_REQ_SEQ = NullOrEmpty(row["Supplier_Monthly_usage_fee_REQ_SEQ"].ToString());
                    supplier_Monthly_usage_fee = NullOrEmpty(row["Supplier_Monthly_usage_fee"].ToString());
                    Supplier_Monthly_usage_fee_DISCOUNTED = NullOrEmpty(row["Supplier_Monthly_usage_fee_DISCOUNTED"].ToString());
                    Supplier_Monthly_usage_fee_TAX = NullOrEmpty(row["Supplier_Monthly_usage_fee_TAX"].ToString());
                    Supplier_Monthly_usage_fee_INCLUDING_TAX = NullOrEmpty(row["Supplier_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                    Production_information_browsing_Initial_expense_REQ_SEQ = NullOrEmpty(row["Production_information_browsing_Initial_expense_REQ_SEQ"].ToString());
                    Production_information_browsing_Initial_expense = NullOrEmpty(row["Production_information_browsing_Initial_expense"].ToString());
                    Production_information_browsing_Initial_expense_DISCOUNTED = NullOrEmpty(row["Production_information_browsing_Initial_expense_DISCOUNTED"].ToString());
                    Production_information_browsing_Initial_expense_TAX = NullOrEmpty(row["Production_information_browsing_Initial_expense_TAX"].ToString());
                    Production_information_browsing_Initial_expense_INCLUDING_TAX = NullOrEmpty(row["Production_information_browsing_Initial_expense_INCLUDING_TAX"].ToString());

                    View_production_information_Annual_usage_fee_REQ_SEQ = NullOrEmpty(row["View_production_information_Annual_usage_fee_REQ_SEQ"].ToString());
                    Viewing_production_information_Annual_usage_fee = NullOrEmpty(row["Viewing_production_information_Annual_usage_fee"].ToString());
                    View_production_information_Annual_usage_fee_DISCOUNTED = NullOrEmpty(row["View_production_information_Annual_usage_fee_DISCOUNTED"].ToString());
                    View_production_information_Annual_usage_fee_TAX = NullOrEmpty(row["View_production_information_Annual_usage_fee_TAX"].ToString());
                    View_production_information_Annual_usage_fee_INCLUDING_TAX = NullOrEmpty(row["View_production_information_Annual_usage_fee_INCLUDING_TAX"].ToString());

                    decimal usageFee = Key_source_Monthly_usage_fee_REQ_SEQ + Key_source_Monthly_usage_fee + Key_source_Monthly_usage_fee_DISCOUNTED + Key_source_Monthly_usage_fee_TAX + Key_source_Monthly_usage_fee_INCLUDING_TAX;
                    newRow["KEY_SOURCE_MONTHLY_USAGE_FEE"] = usageFee;

                    decimal supplierInitialExpense = Supplier_Initial_expense_REQ_SEQ + Supplier_Initial_expense + Supplier_Initial_expense_DISCOUNTED + Supplier_Initial_expense_TAX + Supplier_Initial_expense_INCLUDING_TAX;
                    newRow["SUPPLIER_INITIAL_EXPENSE"] = supplierInitialExpense;

                    decimal supplierMonthlyUsageFee = Supplier_Monthly_usage_fee_REQ_SEQ + supplier_Monthly_usage_fee + Supplier_Monthly_usage_fee_DISCOUNTED + Supplier_Monthly_usage_fee_TAX + Supplier_Monthly_usage_fee_INCLUDING_TAX;
                    newRow["SUPPLIER_MONTHLY_USAGE_FEE"] = supplierMonthlyUsageFee;

                    decimal browsingInitialExpense = Production_information_browsing_Initial_expense_REQ_SEQ + Production_information_browsing_Initial_expense + Production_information_browsing_Initial_expense_DISCOUNTED + Production_information_browsing_Initial_expense_TAX + Production_information_browsing_Initial_expense_INCLUDING_TAX;
                    newRow["BROWSING_INITIAL_EXPENSE"] = browsingInitialExpense;

                    decimal yearlyUsageFee = View_production_information_Annual_usage_fee_REQ_SEQ + Viewing_production_information_Annual_usage_fee + View_production_information_Annual_usage_fee_DISCOUNTED + View_production_information_Annual_usage_fee_TAX + View_production_information_Annual_usage_fee_INCLUDING_TAX;
                    newRow["YEARLY_USAGE_FEE"] = yearlyUsageFee;


                    //newRow["INVOICE_METHOD"] = row["BILL_METHOD"];
                    string invoiceMethod = row["BILL_METHOD"].ToString();
                    if (invoiceMethod.Length == 5)
                    {
                        if (invoiceMethod.Substring(0, 1) == "1")
                        {
                            newRow["POSTAL_MAIL"] = "●";
                        }
                        if (invoiceMethod.Substring(1, 1) == "1")
                        {
                            newRow["WEB"] = "●";
                        }
                        if (invoiceMethod.Substring(2, 1) == "1")
                        {
                            newRow["Email"] = "●";
                        }
                        if (invoiceMethod.Substring(3, 1) == "1")
                        {
                            newRow["CREDIT_CARD"] = "●";
                        }
                        if (invoiceMethod.Substring(4, 1) == "1")
                        {
                            newRow["OTHER"] = "●";
                        }
                    }
                   
                    dtTotal.Rows.Add(newRow);
                    #endregion
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dtResult);
                ds.Tables.Add(dtTotal);

                response.Data = Utility.Utility_Component.DsToJSon(ds, "UsageApplicatioList");
                if (dtResult.Rows.Count > 0)
                {
                    response.Status = 1;
                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There is no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }
                }
                response.Meta.Offset = OFFSET;
                response.Meta.Limit = LIMIT;
                response.Meta.Total = TOTAL;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region EmptyOrNULLCheck
        public decimal NullOrEmpty(string strCheck)
        {
            decimal result =0;
            if (!string.IsNullOrEmpty(strCheck))
            {
                result = Convert.ToDecimal(strCheck);
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region CheckAlreadyCreated
        public MetaResponse CheckAlreadyCreated(string BILLING_DATE ,string status)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("Count");
            result.Columns.Add("Error Message");
            int count = 0;
            string checkStatus = "";
            string strMsg = "";
            INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);

            DateTime date = Convert.ToDateTime(BILLING_DATE);
            String YEAR_MONTH = date.ToString("yyMM");
            if(status.Trim() == "0")
            {
                count = DAL_INVOICE_INFO.IsAlreadyCreated(YEAR_MONTH, out strMsg);
            }

            //need to change logic
            if (count == 0)
            {
                //Call Create InvoiceData Method
                checkStatus=CreateInvoiceData(BILLING_DATE, status);

                if(checkStatus == "3")
                {
                    DataRow dr = result.NewRow();
                    dr["Count"] = 0;
                    dr["Error Message"] = Utility.Messages.Jimugo.E000WC001; //E000WC001
                    result.Rows.Add(dr);

                    response.Data = Utility.Utility_Component.DtToJSon(result, "Return Message");
                }

                if(checkStatus == "0") // Delete Fail
                {
                    DataRow dr = result.NewRow();
                    dr["Count"] = 0;
                    dr["Error Message"] = Utility.Messages.Jimugo.E000WC003; //E000WC003
                    result.Rows.Add(dr);

                    response.Data = Utility.Utility_Component.DtToJSon(result, "Return Message");
                }
                
                else if(checkStatus == "2") //Insert Fail
                {
                    DataRow dr = result.NewRow();
                    dr["Count"] = 0;
                    dr["Error Message"] = Utility.Messages.Jimugo.E000WC005; //E000WC005
                    result.Rows.Add(dr);
                }
                else if (checkStatus.Length > 2) //Insert Success
                {
                    string[] authorsList = checkStatus.Split(',');
                    DataRow dr = result.NewRow();
                    dr["Count"] = 2;
                    dr["error message"] = string.Format(Utility.Messages.Jimugo.I000WC002, authorsList[1]); //i000wc002  
                    result.Rows.Add(dr);
                }

                //return response;
            }
            else
            {
                DataRow dr = result.NewRow();
                dr["Count"] = 1;
                dr["Error Message"] = Utility.Messages.Jimugo.I000WC001; //I000WC001
                result.Rows.Add(dr);
            }

            response.Data = Utility.Utility_Component.DtToJSon(result, "Return Message");

            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
            return response;
        }
        #endregion

        #region CreateInvoiceData
        public string CreateInvoiceData(string BILLING_DATE, string status)
        {
            string errorStatus = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    int OFFSET = 0;
                    int LIMIT = 0;
                    String strMessage = "";
                    int TOTAL;
                    int countForInsert = 0;
                    string checkGetOrCreate = "CREATE";
                    DateTime yearMonth = Convert.ToDateTime(BILLING_DATE);
                    String YEAR_MONTH = yearMonth.ToString("yyyyMM");

                    if (InvoiceAllocationAmountCheck(BILLING_DATE))
                    {
                        errorStatus = "3";
                        return errorStatus;
                    }

                    if (status == "1")
                    {
                        //delete Existing Invoice List
                        bool checkDelete = HandleDelete(BILLING_DATE);
                        if (!checkDelete)
                        {
                            errorStatus = "0";
                            return errorStatus;
                        }
                    }

                    //Select Invoice Data
                    INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);
                    DataTable dt = DAL_INVOICE_INFO.GetInvoiceList(YEAR_MONTH, OFFSET, LIMIT, checkGetOrCreate, out strMessage, out TOTAL);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decimal Key_source_Monthly_usage_fee_REQ_SEQ = 0;
                        decimal Supplier_Initial_expense_REQ_SEQ = 0;
                        decimal Supplier_Monthly_usage_fee_REQ_SEQ = 0;
                        decimal Production_information_browsing_Initial_expense_REQ_SEQ = 0;
                        decimal View_production_information_Annual_usage_fee_REQ_SEQ = 0;

                        DataRow row = dt.Rows[i];

                        if (!string.IsNullOrEmpty(row["Key_source_Monthly_usage_fee"].ToString()))
                        {
                            Key_source_Monthly_usage_fee_REQ_SEQ = Convert.ToDecimal(row["Key_source_Monthly_usage_fee"].ToString());
                        }

                        if (!string.IsNullOrEmpty(row["Supplier_Initial_expense"].ToString()))
                        {
                            Supplier_Initial_expense_REQ_SEQ = Convert.ToDecimal(row["Supplier_Initial_expense"].ToString());
                        }

                        if (!string.IsNullOrEmpty(row["Supplier_Monthly_usage_fee"].ToString()))
                        {
                            Supplier_Monthly_usage_fee_REQ_SEQ = Convert.ToDecimal(row["Supplier_Monthly_usage_fee"].ToString());
                        }

                        if (!string.IsNullOrEmpty(row["Production_information_browsing_Initial_expense"].ToString()))
                        {
                            Production_information_browsing_Initial_expense_REQ_SEQ = Convert.ToDecimal(row["Production_information_browsing_Initial_expense"].ToString());
                        }

                        if (!string.IsNullOrEmpty(row["Viewing_production_information_Annual_usage_fee"].ToString()))
                        {
                            View_production_information_Annual_usage_fee_REQ_SEQ = Convert.ToDecimal(row["Viewing_production_information_Annual_usage_fee"].ToString());
                        }

                        BOL_INVOICE_INFO oINVOICE_INFO = new BOL_INVOICE_INFO();
                        
                        #region Set value in Model
                        oINVOICE_INFO.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();

                        oINVOICE_INFO.INVOICE_DATE = DateTime.Now;  
                        oINVOICE_INFO.NCS_CUSTOMER_CODE = row["NCS_CUSTOMER_CODE"].ToString();
                        oINVOICE_INFO.BILL_SUPPLIER_NAME = row["BILL_COMPANY_NAME"].ToString();
                        oINVOICE_INFO.BILL_SUPPLIER_NAME_READING = row["COMPANY_NAME_READING"].ToString();
                        oINVOICE_INFO.BILL_COMPANY_NAME = row["COMPANY_NAME"].ToString();
                        oINVOICE_INFO.BILL_DEPARTMENT_IN_CHARGE = row["BILL_DEPARTMENT_IN_CHARGE"].ToString();
                        oINVOICE_INFO.BILL_CONTACT_NAME = row["BILL_CONTACT_NAME"].ToString();
                        oINVOICE_INFO.BILL_HONORIFIC = "様";
                        oINVOICE_INFO.BILL_POSTAL_CODE = row["BILL_POSTAL_CODE"].ToString();
                        oINVOICE_INFO.BILL_ADDRESS = row["BILL_ADDRESS"].ToString();
                        oINVOICE_INFO.BILL_ADDRESS_2 = row["BILL_ADDRESS_BUILDING"].ToString();

                        string CONTRACT_PLAN = row["CONTRACT_PLAN"].ToString();
                        if (CONTRACT_PLAN == "SERVER")
                        {
                            oINVOICE_INFO.PLAN_SERVER = 1;
                            oINVOICE_INFO.PLAN_SERVER_LIGHT = 0;
                            oINVOICE_INFO.PLAN_BROWSER_AUTO = 0;
                            oINVOICE_INFO.PLAN_BROWSER = 0;
                        }
                        if (CONTRACT_PLAN == "SERVERRIGHT")
                        {
                            oINVOICE_INFO.PLAN_SERVER = 0;
                            oINVOICE_INFO.PLAN_SERVER_LIGHT = 1;
                            oINVOICE_INFO.PLAN_BROWSER_AUTO = 0;
                            oINVOICE_INFO.PLAN_BROWSER = 0;
                        }
                        if (CONTRACT_PLAN == "BROWSERAUTO")
                        {
                            oINVOICE_INFO.PLAN_SERVER = 0;
                            oINVOICE_INFO.PLAN_SERVER_LIGHT = 0;
                            oINVOICE_INFO.PLAN_BROWSER_AUTO = 1;
                            oINVOICE_INFO.PLAN_BROWSER = 0;
                        }
                        if (CONTRACT_PLAN == "BROWSER")
                        {
                            oINVOICE_INFO.PLAN_SERVER = 0;
                            oINVOICE_INFO.PLAN_SERVER_LIGHT = 0;
                            oINVOICE_INFO.PLAN_BROWSER_AUTO = 0;
                            oINVOICE_INFO.PLAN_BROWSER = 1;
                        }
                        if (CONTRACT_PLAN == "PRODUCT")
                        {
                            oINVOICE_INFO.PLAN_SERVER = 0;
                            oINVOICE_INFO.PLAN_SERVER_LIGHT = 0;
                            oINVOICE_INFO.PLAN_BROWSER_AUTO = 0;
                            oINVOICE_INFO.PLAN_BROWSER = 0;
                        }


                        oINVOICE_INFO.PLAN_AMIGO_CAI = Utility_Component.dtColumnToInt(row["OP_AMIGO_CAI"].ToString());
                        oINVOICE_INFO.PLAN_AMIGO_BIZ = Utility_Component.dtColumnToInt(row["OP_AMIGO_BIZ"].ToString());
                        oINVOICE_INFO.PLAN_ADD_BOX_SERVER = Utility_Component.dtColumnToInt(row["OP_BOX_SERVER"].ToString());
                        oINVOICE_INFO.PLAN_ADD_BOX_BROWSER = Utility_Component.dtColumnToInt(row["OP_BOX_BROWSER"].ToString());
                        oINVOICE_INFO.PLAN_OP_FLAT = Utility_Component.dtColumnToInt(row["OP_FLAT"].ToString());
                        oINVOICE_INFO.PLAN_OP_SSL = Utility_Component.dtColumnToInt(row["OP_CLIENT"].ToString());
                        oINVOICE_INFO.PLAN_OP_BASIC_SERVICE = Utility_Component.dtColumnToInt(row["OP_BASIC_SERVICE"].ToString());
                        oINVOICE_INFO.PLAN_OP_ADD_SERVICE = Utility_Component.dtColumnToInt(row["OP_ADD_SERVICE"].ToString());

                        if (row["SOCIOS_USER_FLG"].ToString() == " ")
                        {
                            oINVOICE_INFO.PLAN_OP_SOCIOS = 0;
                        }
                        if (row["SOCIOS_USER_FLG"].ToString() == "*")
                        {
                            oINVOICE_INFO.PLAN_OP_SOCIOS = 1;
                        }
                        oINVOICE_INFO.BILL_DEPOSIT_RULES = row["BILL_DEPOSIT_RULES"].ToString();

                        oINVOICE_INFO.BILL_TRANSFER_FEE = Utility_Component.dtColumnToDecimal(row["BILL_TRANSFER_FEE"].ToString());
                        oINVOICE_INFO.BILL_EXPENSES = Utility_Component.dtColumnToDecimal(row["BILL_EXPENSES"].ToString());

                        DateTime date = Convert.ToDateTime(BILLING_DATE);
                        var lastDateOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)).ToString("dd");
                        var lastDay = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)).DayOfWeek;
                        var BILL_DATE = BILLING_DATE + "/" + lastDateOfMonth;
                        DateTime PaymentDay = Convert.ToDateTime(BILL_DATE);
                        string strPaymentDay = "";
                        if (lastDay.ToString() == "Saturday")
                        {
                            strPaymentDay = PaymentDay.AddDays(-1).ToString();
                        }
                        if (lastDay.ToString() == "Sunday")
                        {
                            strPaymentDay = PaymentDay.AddDays(-2).ToString();
                        }
                        if (lastDay.ToString() != "Saturday" && lastDay.ToString() != "Sunday")
                        {
                            strPaymentDay = PaymentDay.ToString();
                        }

                        oINVOICE_INFO.BILL_PAYMENT_DATE = Utility_Component.dtColumnToDateTime(strPaymentDay);
                        oINVOICE_INFO.STATUS_PRINT = null;
                        oINVOICE_INFO.STATUS_MEMO = null;
                        oINVOICE_INFO.STATUS_SEND = null;
                        oINVOICE_INFO.STATUS_MAIL_DATE = null;  //declare check
                        oINVOICE_INFO.STATUS_ACC_RECEIVABLE_DATE = null;
                        oINVOICE_INFO.STATUS_INVOCE_COPY_DATE = null;
                        oINVOICE_INFO.STATUS_ACTUAL_MDB_UPDATE = null;
                        oINVOICE_INFO.STATUS_ACTUAL_DEPOSIT_YYMM = null;
                        oINVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE = null;
                        oINVOICE_INFO.STATUS_CASH_FORECAST_MM = null;

                        //need to change set value
                        string depositRuleCheck = row["BILL_DEPOSIT_RULES"].ToString();
                        if (depositRuleCheck == "0")
                        {
                            oINVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM = date.AddMonths(1).ToString("yyMM");
                        }
                        if (depositRuleCheck == "1")
                        {
                            oINVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM = date.ToString("yyMM");

                        }
                        if (depositRuleCheck == "2")
                        {
                            oINVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM = date.AddMonths(2).ToString("yyMM");
                        }

                        //oINVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM = row["BILL_SUPPLIER_NAME"].ToString();
                        oINVOICE_INFO.STATUS_PAY_NOTICE_DATE = null;
                        oINVOICE_INFO.TYPE_OF_ALLOCATION = 0;
                        oINVOICE_INFO.ALLOCATION_TOTAL_AMOUNT = 0;
                        oINVOICE_INFO.ALLOCATED_COMPLETION_DATE = null;
                        oINVOICE_INFO.DUNNING_COUNT = 0;
                        oINVOICE_INFO.DUNNING_DATE = null;
                        oINVOICE_INFO.ANSWER_DATE = null;
                        oINVOICE_INFO.PAYMENT_DUE_DATE = null;
                        oINVOICE_INFO.ANSWER_MEMO = null;
                        oINVOICE_INFO.SPECIAL_NOTES_1 = null;
                        oINVOICE_INFO.SPECIAL_NOTES_2 = null;
                        oINVOICE_INFO.SPECIAL_NOTES_3 = null;
                        oINVOICE_INFO.SPECIAL_NOTES_4 = null;

                        #endregion

                        if (Key_source_Monthly_usage_fee_REQ_SEQ > 0)
                        {
                            string TRANSACTION_TYPE = "12";
                            oINVOICE_INFO.TRANSACTION_TYPE = TRANSACTION_TYPE;
                            oINVOICE_INFO.YEAR_MONTH = "-" + yearMonth.ToString("yyMM");
                            oINVOICE_INFO.BILL_AMOUNT = Utility_Component.dtColumnToDecimal(row["Key_source_Monthly_usage_fee"].ToString());
                            oINVOICE_INFO.BILL_TAX = Utility_Component.dtColumnToDecimal(row["Key_source_Monthly_usage_fee_TAX"].ToString());
                            oINVOICE_INFO.BILL_PRICE = Utility_Component.dtColumnToDecimal(row["Key_source_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                            //Insert InvoiceData
                            DAL_INVOICE_INFO.InsertInvoiceInfo(oINVOICE_INFO, out strMessage);
                            countForInsert++;
                        }

                        if (Supplier_Initial_expense_REQ_SEQ > 0)
                        {
                            string TRANSACTION_TYPE = "21";
                            oINVOICE_INFO.TRANSACTION_TYPE = TRANSACTION_TYPE;
                            oINVOICE_INFO.YEAR_MONTH = "-" + yearMonth.ToString("yyMM") + "IC";
                            oINVOICE_INFO.BILL_AMOUNT = Utility_Component.dtColumnToDecimal(row["Supplier_Initial_expense"].ToString());
                            oINVOICE_INFO.BILL_TAX = Utility_Component.dtColumnToDecimal(row["Supplier_Initial_expense_TAX"].ToString());
                            oINVOICE_INFO.BILL_PRICE = Utility_Component.dtColumnToDecimal(row["Supplier_Initial_expense_INCLUDING_TAX"].ToString());

                            //Insert InvoiceData
                            DAL_INVOICE_INFO.InsertInvoiceInfo(oINVOICE_INFO, out strMessage);
                            countForInsert++;
                        }

                        if (Supplier_Monthly_usage_fee_REQ_SEQ > 0)
                        {
                            string TRANSACTION_TYPE = "22";
                            oINVOICE_INFO.TRANSACTION_TYPE = TRANSACTION_TYPE;
                            oINVOICE_INFO.YEAR_MONTH = "-" + yearMonth.ToString("yyMM");
                            oINVOICE_INFO.BILL_AMOUNT = Utility_Component.dtColumnToDecimal(row["Supplier_Monthly_usage_fee"].ToString());
                            oINVOICE_INFO.BILL_TAX = Utility_Component.dtColumnToDecimal(row["Supplier_Monthly_usage_fee_TAX"].ToString());
                            oINVOICE_INFO.BILL_PRICE = Utility_Component.dtColumnToDecimal(row["Supplier_Monthly_usage_fee_INCLUDING_TAX"].ToString());

                            //Insert InvoiceData
                            DAL_INVOICE_INFO.InsertInvoiceInfo(oINVOICE_INFO, out strMessage);
                            countForInsert++;
                        }

                        if (Production_information_browsing_Initial_expense_REQ_SEQ > 0 || View_production_information_Annual_usage_fee_REQ_SEQ > 0)
                        {
                            string TRANSACTION_TYPE = "32";
                            oINVOICE_INFO.TRANSACTION_TYPE = TRANSACTION_TYPE;
                            oINVOICE_INFO.YEAR_MONTH = "-" + yearMonth.ToString("yyMM");
                            oINVOICE_INFO.BILL_AMOUNT = Utility_Component.dtColumnToDecimal(row["Production_information_browsing_Initial_expense"].ToString()) + Utility_Component.dtColumnToDecimal(row["Viewing_production_information_Annual_usage_fee"].ToString());
                            oINVOICE_INFO.BILL_TAX = Utility_Component.dtColumnToDecimal(row["Production_information_browsing_Initial_expense_TAX"].ToString()) + Utility_Component.dtColumnToDecimal(row["View_production_information_Annual_usage_fee_TAX"].ToString());
                            oINVOICE_INFO.BILL_PRICE = Utility_Component.dtColumnToDecimal(row["Production_information_browsing_Initial_expense_INCLUDING_TAX"].ToString()) + Utility_Component.dtColumnToDecimal(row["View_production_information_Annual_usage_fee_INCLUDING_TAX"].ToString());

                            //Insert InvoiceData
                            DAL_INVOICE_INFO.InsertInvoiceInfo(oINVOICE_INFO, out strMessage);
                            countForInsert++;
                        }
                    }

                    if (string.IsNullOrEmpty(strMessage) && countForInsert>0)
                    {
                        errorStatus = "1," + countForInsert;
                        dbTxn.Complete();
                        
                    }
                    else
                    {
                        errorStatus = "2";
                    }

                }
                catch (Exception ex)
                {
                    errorStatus = "2";
                }
            }
            return errorStatus;

        }
        #endregion

        #region InvoiceAllocationAmountCheck
        private bool InvoiceAllocationAmountCheck(string BILLING_DATE)
        {
            string strMsg = "";
            int count = 0;
            
            INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);

            DateTime yearMonth = Convert.ToDateTime(BILLING_DATE);
            String YEAR_MONTH = yearMonth.ToString("yyMM");

            //Check Invoice Allocation
            count = DAL_INVOICE_INFO.InvoiceAllocationAmountCheck(YEAR_MONTH, out strMsg);
            //return message and MK value
            if (String.IsNullOrEmpty(strMsg) && count >0) //success
            {
                return true;
            }
            else //failed
            {
                return false;
            }
        }
        #endregion

        #region HandleDelete
        private bool HandleDelete(string BILLING_DATE)
        {
            string strMsg = "";
            //using (TransactionScope dbTxn = new TransactionScope())
            //{
                INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);

                DateTime yearMonth = Convert.ToDateTime(BILLING_DATE);
                String YEAR_MONTH = yearMonth.ToString("yyMM");

                //delete the record
                DAL_INVOICE_INFO.DeleteInvoiceInfoByYearMonth(YEAR_MONTH, out strMsg);
                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    return true;
                }
                else //failed
                {
                    return false;
                }
            //}
        }
        #endregion

        #region CreateCSVFile
        public MetaResponse CreateCSVFile(string BILLING_DATE)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("Check");
            result.Columns.Add("Error Message");

            string strMessage="";
            int status;
            INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);

            DateTime yearMonth = Convert.ToDateTime(BILLING_DATE);
            String YEAR_MONTH = yearMonth.ToString("yyMM");

            DataTable dt = DAL_INVOICE_INFO.GetCSVList(YEAR_MONTH, out strMessage);

            if (String.IsNullOrEmpty(strMessage) && dt.Rows.Count >0)
            {
                #region UpdateInvoiceInfo
                status = HandleModify(YEAR_MONTH);

                if(status == 1)
                {
                    response.Data = Utility.Utility_Component.DtToJSon(dt, "InvoiceInfoList");
                }
                else
                {
                    DataRow dr = result.NewRow();
                    //dr["Count"] = count;
                    dr["Error Message"] = Utility.Messages.Jimugo.E000WA001; //E000WC004
                    result.Rows.Add(dr);

                    response.Data = Utility.Utility_Component.DtToJSon(result, "Return Message");
                }
                #endregion
            }
            else
            {
                DataRow dr = result.NewRow();
                dr["Error Message"] = Utility.Messages.Jimugo.E000WC002; //E000WC002
                result.Rows.Add(dr);

                response.Data = Utility.Utility_Component.DtToJSon(result, "Return Message");
            }
            
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
            return response;
        }
        #endregion

        #region UpdateInvoiceInfo
        private int HandleModify(string YEAR_MONTH)
        {
            string strMsg = "";
            int status = 0;
            using (TransactionScope dbTxn = new TransactionScope())
            {
                INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);
                //check condition
                if (!DAL_INVOICE_INFO.IsAlreadyUpdatedForCSVCreate(YEAR_MONTH, out strMsg)) // IF updated_at is not already modified
                {
                    //MODIFY the record
                    DAL_INVOICE_INFO.Update(YEAR_MONTH, CURRENT_DATETIME, out strMsg);
                }
                else
                {
                    return status;
                }

                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    dbTxn.Complete();
                    return status = 1;
                }
                else //failed
                {
                    return status;
                }
            }
        }
        #endregion
    }
}