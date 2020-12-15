using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.BOL;
using AmigoProcessManagement.Utility;
using System.Transactions;

namespace AmigoProcessManagement.Controller
{
    public class Controller3B
    {
        #region Declare
        List<BOL_RESERVE_INFO> lstReserveInfo;
        List<BOL_RECEIPT_DETAILS> lstReceiptDetail;
        List<BOL_INVOICE_INFO> lstInvoiceInfo;
        Response response;
        #endregion

        #region Constructor
        public Controller3B()
        {
            lstReserveInfo = new List<BOL_RESERVE_INFO>();
            lstReceiptDetail = new List<BOL_RECEIPT_DETAILS>();
            lstInvoiceInfo = new List<BOL_INVOICE_INFO>();
            response = new Response();
        }
        #endregion

        #region do3B_BatchProcess
        public Response do3B_BatchProcess()
        {
            DateTime run_date = DateTime.Now;
            string strMessage = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    RECEIPT_DETAILS oRCP = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                    DataTable dtReceiptDetail_Customer = oRCP.getUncompleteReceiptDetail();
                    for (int i = 0; i < dtReceiptDetail_Customer.Rows.Count; i++)
                    {
                        string COMPANY_NO_BOXES = (dtReceiptDetail_Customer.Rows[i]["COMPANIES"] == null ? "" : dtReceiptDetail_Customer.Rows[i]["COMPANIES"].ToString());
                        INVOICE_INFO oInv = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                        DataTable dtInvoice = oInv.getInvoiceByCustomer(COMPANY_NO_BOXES);

                        int SEQ_NO = 0;
                        int.TryParse((dtReceiptDetail_Customer.Rows[i]["SEQ_NO"] == null ? "" : dtReceiptDetail_Customer.Rows[i]["SEQ_NO"].ToString()), out SEQ_NO);

                        lstReserveInfo = new List<BOL_RESERVE_INFO>();
                        lstReceiptDetail = new List<BOL_RECEIPT_DETAILS>();
                        lstInvoiceInfo = new List<BOL_INVOICE_INFO>();
                        if (dtInvoice.Rows.Count > 0 )
                        {
                           
                            PrepareDataForUpdate(dtReceiptDetail_Customer.Rows[i], dtInvoice, run_date);
                        }

                        BOL_RECEIPT_DETAILS oRECEIPT_DETAILS = new BOL_RECEIPT_DETAILS();
                        oRECEIPT_DETAILS.PAYMENT_DAY = run_date;
                        oRECEIPT_DETAILS.SEQ_NO = SEQ_NO;
                        oRCP.UpdatePaymentDay(oRECEIPT_DETAILS, out strMessage);

                    }
                    dbTxn.Complete();
                    if (strMessage!="")
                    {
                        response.Status = 0;
                    }
                    else
                    {
                        response.Status = 1;
                    }
                    response.Message = strMessage;
                    return response;
                 }
                catch (Exception ex)
                {
                    response.Status = 0;
                    response.Message = ex.Message + "\n" + ex.StackTrace;
                    dbTxn.Dispose();
                    return response;
                }
        }
        }
        #endregion

        #region PrepareDataForUpdate
        private void PrepareDataForUpdate(DataRow dtReceiptDetail_Customer, DataTable dtBatch_Invoice, DateTime run_date)
        {
            decimal ALLOCATED_MONEY = 0;
            decimal.TryParse((dtReceiptDetail_Customer["ALLOCATED_MONEY"] == null ? "" : dtReceiptDetail_Customer["ALLOCATED_MONEY"].ToString()), out ALLOCATED_MONEY);
            decimal DEPOSIT_AMOUNT = 0;
            decimal.TryParse((dtReceiptDetail_Customer["DEPOSIT_AMOUNT"] == null ? "" : dtReceiptDetail_Customer["DEPOSIT_AMOUNT"].ToString()), out DEPOSIT_AMOUNT);

            decimal decAvailableAmount = DEPOSIT_AMOUNT - ALLOCATED_MONEY;
            int SEQ_NO = 0;
            int.TryParse((dtReceiptDetail_Customer["SEQ_NO"] == null ? "" : dtReceiptDetail_Customer["SEQ_NO"].ToString()), out SEQ_NO);
            DateTime DEPOSIT_DATE;
            DateTime.TryParse((dtReceiptDetail_Customer["DEPOSIT_AMOUNT"] == null ? "" : dtReceiptDetail_Customer["DEPOSIT_DATE"].ToString()), out DEPOSIT_DATE);

            int ALLOCATED_QUANTITY = 0;
            int.TryParse((dtReceiptDetail_Customer["ALLOCATED_QUANTITY"] == null ? "" : dtReceiptDetail_Customer["ALLOCATED_QUANTITY"].ToString()), out ALLOCATED_QUANTITY);

            decimal CalculateForType = 0;
            if (decAvailableAmount != 0)
            {
                BOL_RECEIPT_DETAILS oRECEIPT_DETAILS = new BOL_RECEIPT_DETAILS();
                oRECEIPT_DETAILS.ALLOCATED_QUANTITY = ALLOCATED_QUANTITY;
                oRECEIPT_DETAILS.ALLOCATED_MONEY = ALLOCATED_MONEY; //20201117_追加_ALLOCATED_MONEYを初期値でセット

                #region Prepare Invoice, Reserve Info and Receipt Detail
                for ( int i = 0; i < dtBatch_Invoice.Rows.Count; i++)
                {
                    //BILL PRICE
                    decimal BILL_PRICE = 0;
                    decimal.TryParse((dtBatch_Invoice.Rows[i]["BILL_PRICE"] == null ? "" : dtBatch_Invoice.Rows[i]["BILL_PRICE"].ToString()), out BILL_PRICE);

                    //ALLOCATATION TOTAL AMOUNT calculate
                    decimal ALLOCATION_TOTAL_AMOUNT = 0;
                    decimal.TryParse((dtBatch_Invoice.Rows[i]["ALLOCATION_TOTAL_AMOUNT"] == null ? "" : dtBatch_Invoice.Rows[i]["ALLOCATION_TOTAL_AMOUNT"].ToString()), out ALLOCATION_TOTAL_AMOUNT);

                    //BILL TRANSFER FEE
                    decimal BILL_TRANSFER_FEE = 0;
                    decimal.TryParse((dtBatch_Invoice.Rows[i]["BILL_TRANSFER_FEE"] == null ? "" : dtBatch_Invoice.Rows[i]["BILL_TRANSFER_FEE"].ToString()), out BILL_TRANSFER_FEE);

                    string strYear_Month = (dtBatch_Invoice.Rows[i]["YEAR_MONTH"] == null ? "" : dtBatch_Invoice.Rows[i]["YEAR_MONTH"].ToString());
                    string strCompanyNoBox = (dtBatch_Invoice.Rows[i]["COMPANY_NO_BOX"] == null ? "" : dtBatch_Invoice.Rows[i]["COMPANY_NO_BOX"].ToString());

                    CalculateForType = BILL_PRICE - ALLOCATION_TOTAL_AMOUNT + BILL_TRANSFER_FEE;
                    CalculateForType = (CalculateForType < 0 ? CalculateForType * -1 : CalculateForType);

                    BOL_RESERVE_INFO oRESERVE_INFO = new BOL_RESERVE_INFO();
                    BOL_INVOICE_INFO oInvoiceInfo = new BOL_INVOICE_INFO();

                    if (decAvailableAmount >= CalculateForType) //Type A
                    {
                        //Prepare Update For Invoice
                        oInvoiceInfo.ALLOCATION_TOTAL_AMOUNT = ALLOCATION_TOTAL_AMOUNT + CalculateForType;
                        oInvoiceInfo.ALLOCATED_COMPLETION_DATE = run_date;
                        oInvoiceInfo.YEAR_MONTH = strYear_Month;
                        oInvoiceInfo.COMPANY_NO_BOX = strCompanyNoBox;
                        oInvoiceInfo.TYPE_OF_ALLOCATION = 1;
                        oInvoiceInfo.STATUS_ACTUAL_DEPOSIT_YYMM = DEPOSIT_DATE.ToString("yyMM");
                        oInvoiceInfo.STATUS_ACTUAL_DEPOSIT_DATE = DEPOSIT_DATE.ToString("yyyy-MM-dd");
                        lstInvoiceInfo.Add(oInvoiceInfo);

                        //Prepare Insert For Reserve Info                          
                        oRESERVE_INFO.SEQ_NO = SEQ_NO;
                        oRESERVE_INFO.BILLING_CODE = strCompanyNoBox + strYear_Month;
                        oRESERVE_INFO.PAYMENT_DAY = run_date;
                        oRESERVE_INFO.TYPE_OF_ALLOCATION = 1;
                        oRESERVE_INFO.RESERVE_AMOUNT = CalculateForType;
                        oRESERVE_INFO.DIFF_ALLOCATION_AMOUNT = decAvailableAmount - CalculateForType;
                        lstReserveInfo.Add(oRESERVE_INFO);

                        //Prepare Update for receipt detail
                        oRECEIPT_DETAILS.ALLOCATED_MONEY += CalculateForType;
                        if (DEPOSIT_AMOUNT == oRECEIPT_DETAILS.ALLOCATED_MONEY)
                        {
                            oRECEIPT_DETAILS.ALLOCATED_COMPLETION_DATE = run_date;
                        }
                        oRECEIPT_DETAILS.SEQ_NO = SEQ_NO;
                        oRECEIPT_DETAILS.PAYMENT_DAY = run_date;
                        oRECEIPT_DETAILS.TYPE_OF_ALLOCATION = 1;
                        oRECEIPT_DETAILS.ALLOCATED_QUANTITY += 1;
                        lstReceiptDetail.Add(oRECEIPT_DETAILS);
                        decAvailableAmount = decAvailableAmount - CalculateForType;
                    }
                    else if (decAvailableAmount < CalculateForType) //Type B
                    {
                        //Prepare Update For Invoice Info
                        oInvoiceInfo.ALLOCATION_TOTAL_AMOUNT = ALLOCATION_TOTAL_AMOUNT + decAvailableAmount;
                        if (CalculateForType == 0)
                        {
                            oInvoiceInfo.ALLOCATED_COMPLETION_DATE = run_date;
                        }
                        oInvoiceInfo.YEAR_MONTH = strYear_Month;
                        oInvoiceInfo.COMPANY_NO_BOX = strCompanyNoBox;
                        oInvoiceInfo.TYPE_OF_ALLOCATION = 1;
                        oInvoiceInfo.STATUS_ACTUAL_DEPOSIT_YYMM = DEPOSIT_DATE.ToString("yyMM");
                        oInvoiceInfo.STATUS_ACTUAL_DEPOSIT_DATE = DEPOSIT_DATE.ToString("yyyy-MM-dd");
                        lstInvoiceInfo.Add(oInvoiceInfo);

                        //Prepare Insert For Reserve Info                   
                        oRESERVE_INFO.SEQ_NO = SEQ_NO;
                        oRESERVE_INFO.BILLING_CODE = strCompanyNoBox + strYear_Month;
                        oRESERVE_INFO.PAYMENT_DAY = run_date;
                        oRESERVE_INFO.TYPE_OF_ALLOCATION = 1;
                        oRESERVE_INFO.RESERVE_AMOUNT = decAvailableAmount;
                        oRESERVE_INFO.DIFF_ALLOCATION_AMOUNT = decAvailableAmount - CalculateForType;

                        lstReserveInfo.Add(oRESERVE_INFO);

                        //Prepare Update for Receipt Detail
                        oRECEIPT_DETAILS.ALLOCATED_COMPLETION_DATE = run_date;
                        oRECEIPT_DETAILS.ALLOCATED_MONEY = DEPOSIT_AMOUNT;
                        oRECEIPT_DETAILS.SEQ_NO = SEQ_NO;
                        oRECEIPT_DETAILS.PAYMENT_DAY = run_date;
                        oRECEIPT_DETAILS.TYPE_OF_ALLOCATION = 1;
                        oRECEIPT_DETAILS.ALLOCATED_QUANTITY += 1;
                        lstReceiptDetail.Add(oRECEIPT_DETAILS);
                        decAvailableAmount = decAvailableAmount - CalculateForType;
                    }
                    ALLOCATED_MONEY += oRECEIPT_DETAILS.ALLOCATED_MONEY;

                    if (oRECEIPT_DETAILS.ALLOCATED_COMPLETION_DATE != null)
                    {
                        break;
                    }

                }
                #endregion


                RECEIPT_DETAILS oRCP = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                INVOICE_INFO oInv = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                RESERVE_INFO oReseve = new RESERVE_INFO(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                for (int i = 0; i < lstReceiptDetail.Count; i++)
                {
                    oRCP.UpdateReceipt_Detail(lstReceiptDetail[i], out strMessage);
                }

                for (int i = 0; i < lstInvoiceInfo.Count; i++)
                {
                    oInv.UpdateInvoice_Info(lstInvoiceInfo[i], out strMessage);
                }

                for (int i = 0; i < lstReserveInfo.Count; i++)
                {

                    oReseve.insert(lstReserveInfo[i], out strMessage);
                }
            }
        }
        #endregion

        #region Allocation Manual
        public Response ManualAllocation(string COMPANY_NO_BOX, string YEAR_MONTH)
        {
            DateTime run_date = DateTime.Now;
            string strMessage = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    //to return matched SEQ_NO
                    DataTable Matched = new DataTable();
                    Matched.Columns.Add("Matched");

                    //GET uncompleted RECEIPT_DETAILS
                    RECEIPT_DETAILS oRCP = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                    DataTable dtReceiptDetail_Customer = oRCP.getUncompleteReceiptDetail();
                    for (int i = 0; i < dtReceiptDetail_Customer.Rows.Count; i++)
                    {
                        string COMPANY_NO_BOXES = (dtReceiptDetail_Customer.Rows[i]["COMPANIES"] == null ? "" : dtReceiptDetail_Customer.Rows[i]["COMPANIES"].ToString());
                        INVOICE_INFO oInv = new INVOICE_INFO(Properties.Settings.Default.MyConnection);

                        if (COMPANY_NO_BOXES.Contains(COMPANY_NO_BOX)) //IF there is matched COMPANY_NO_BOX
                        {
                            DataTable dtInvoice = oInv.getInvoiceByCustomerManualAllocate("'" + COMPANY_NO_BOX + "'", "'" + YEAR_MONTH + "'");

                            if (dtInvoice.Rows.Count > 0)
                            {
                                lstReserveInfo = new List<BOL_RESERVE_INFO>();
                                lstReceiptDetail = new List<BOL_RECEIPT_DETAILS>();
                                lstInvoiceInfo = new List<BOL_INVOICE_INFO>();

                                PrepareDataForUpdate(dtReceiptDetail_Customer.Rows[i], dtInvoice, run_date);
                                DataRow dr = Matched.NewRow();
                                dr["Matched"] = dtReceiptDetail_Customer.Rows[i]["SEQ_NO"];
                                Matched.Rows.Add(dr);
                            }
                        }
                    }
                    dbTxn.Complete();//commit changes

                    response.Data = Utility.Utility_Component.DtToJSon(Matched, "Matched");

                    if (strMessage != "")
                    {
                        response.Status = 0;
                    }
                    else
                    {
                        response.Status = 1;
                    }
                    response.Message = strMessage;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Status = 0;
                    response.Message = ex.Message + "\n" + ex.StackTrace;
                    dbTxn.Dispose();
                    return response;
                }
            }
        }
        #endregion
    }
}