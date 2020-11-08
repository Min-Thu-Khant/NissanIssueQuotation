using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class Controller37
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public Controller37()
        {
            response = new Response();
        }
        #endregion

        #region GetDataGridfor37
        public Response GetDataGridfor37(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME
            )
        {
            try
            {
                INVOICE_INFO oINV = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                string strMessage = "";

                string from_yearMonth = Utility_Component.GetYearMonth(FROM_YEAR_MONTH, true);
                string to_yearMonth = Utility_Component.GetYearMonth(TO_YEAR_MONTH, false);

                string from_statusPlanYYMM = Utility_Component.GetYearMonth(FROM_STATUS_PLAN_DEPOSIT_YYMM, true);
                string to_statusPlanYYMM = Utility_Component.GetYearMonth(TO_STATUS_PLAN_DEPOSIT_YYMM, false);

                string from_statusPlanDate = Utility_Component.GetFullDate(FROM_STATUS_ACTUAL_DEPOSIT_DATE);
                string to_statusPlanDate = Utility_Component.GetFullDate(TO_STATUS_ACTUAL_DEPOSIT_DATE);

                DataTable dt = oINV.GetDataForGrid37(TRANSACTION_TYPE,
                                                        from_yearMonth, to_yearMonth,
                                                        from_statusPlanYYMM, to_statusPlanYYMM,
                                                        from_statusPlanDate, to_statusPlanDate,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME, out strMessage);

                response.Data = Utility.Utility_Component.DtToJSon(dt, "31Result");
                if (dt.Rows.Count > 0)
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
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region UpdateInvoice_37
        public Response UpdateInvoice_37(string strData)
        {
            try
            {
                DataTable dt = Utility.Utility_Component.JsonToDt(strData);
                string strError = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string STATUS_CASH_FORECAST_MM = (dt.Rows[i]["STATUS_CASH_FORECAST_MM"] == null ? "" : dt.Rows[i]["STATUS_CASH_FORECAST_MM"].ToString());
                    string STATUS_PLAN_DEPOSIT_YYMM = (dt.Rows[i]["STATUS_PLAN_DEPOSIT_YYMM"] == null ? "" : dt.Rows[i]["STATUS_PLAN_DEPOSIT_YYMM"].ToString());
                    string STATUS_ACTUAL_MDB_UPDATE = (dt.Rows[i]["STATUS_ACTUAL_MDB_UPDATE"] == null ? "" : dt.Rows[i]["STATUS_ACTUAL_MDB_UPDATE"].ToString());
                    string STATUS_ACC_RECEIVABLE_DATE = (dt.Rows[i]["STATUS_ACC_RECEIVABLE_DATE"] == null ? "" : dt.Rows[i]["STATUS_ACC_RECEIVABLE_DATE"].ToString());
                    string DUNNING_DATE = (dt.Rows[i]["DUNNING_DATE"] == null ? null : dt.Rows[i]["DUNNING_DATE"].ToString());
                    string ANSWER_DATE = (dt.Rows[i]["ANSWER_DATE"] == null ? null : dt.Rows[i]["ANSWER_DATE"].ToString());
                    string PAYMENT_DUE_DATE = (dt.Rows[i]["PAYMENT_DUE_DATE"] == null ? null : dt.Rows[i]["PAYMENT_DUE_DATE"].ToString());
                    string ANSWER_MEMO = (dt.Rows[i]["ANSWER_MEMO"] == null ? "" : dt.Rows[i]["ANSWER_MEMO"].ToString());
                    string COMPANY_NO_BOX = dt.Rows[i]["COMPANY_NO_BOX"].ToString();
                    string YEAR_MONTH = dt.Rows[i]["YEAR_MONTH"].ToString();
                    int DUNNING_COUNT = int.Parse(dt.Rows[i]["DUNNING_COUNT"] == null ? "0" : dt.Rows[i]["DUNNING_COUNT"].ToString());

                    DateTime? dtm_DUNNING_DATE, dtm_ANSWER_DATE, dtm_PAYMENT_DUE_DATE, dtm_STATUS_ACC_RECEIVABLE_DATE, dtm_STATUS_ACTUAL_MDB_UPDATE;
                    try
                    {
                        dtm_DUNNING_DATE = DateTime.ParseExact(DUNNING_DATE, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        dtm_DUNNING_DATE = null;
                    }

                    try
                    {
                        dtm_ANSWER_DATE = DateTime.ParseExact(ANSWER_DATE, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        dtm_ANSWER_DATE = null;
                    }

                    try
                    {
                        dtm_PAYMENT_DUE_DATE = DateTime.ParseExact(PAYMENT_DUE_DATE, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        dtm_PAYMENT_DUE_DATE = null;
                    }

                    try
                    {
                        dtm_STATUS_ACTUAL_MDB_UPDATE = DateTime.ParseExact(STATUS_ACTUAL_MDB_UPDATE, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        dtm_STATUS_ACTUAL_MDB_UPDATE = null;
                    }

                    try
                    {
                        dtm_STATUS_ACC_RECEIVABLE_DATE = DateTime.ParseExact(STATUS_ACC_RECEIVABLE_DATE, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        dtm_STATUS_ACC_RECEIVABLE_DATE = null;
                    }
                   
                    INVOICE_INFO oINV = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                    BOL_INVOICE_INFO oINFO = new BOL_INVOICE_INFO();



                    oINFO.STATUS_CASH_FORECAST_MM = STATUS_CASH_FORECAST_MM;
                    oINFO.STATUS_PLAN_DEPOSIT_YYMM = STATUS_PLAN_DEPOSIT_YYMM;
                    oINFO.STATUS_ACC_RECEIVABLE_DATE = dtm_STATUS_ACC_RECEIVABLE_DATE;
                    oINFO.STATUS_ACTUAL_MDB_UPDATE = dtm_STATUS_ACTUAL_MDB_UPDATE;
                    oINFO.DUNNING_DATE = dtm_DUNNING_DATE;
                    oINFO.ANSWER_DATE = dtm_ANSWER_DATE;
                    oINFO.ANSWER_MEMO = ANSWER_MEMO;
                    oINFO.PAYMENT_DUE_DATE = dtm_PAYMENT_DUE_DATE;
                    oINFO.COMPANY_NO_BOX = COMPANY_NO_BOX;
                    oINFO.YEAR_MONTH = YEAR_MONTH;
                    string strMessage = "";
                    if (!oINV.CheckIfItIsOrigin(oINFO.COMPANY_NO_BOX, oINFO.YEAR_MONTH, oINFO.DUNNING_DATE, out strMessage))
                    {
                        oINFO.DUNNING_COUNT = DUNNING_COUNT + 1;
                    }
                    else
                    {
                        oINFO.DUNNING_COUNT = DUNNING_COUNT;
                    }
                    oINV.UpdateInvoiceFor37(oINFO, out strMessage);
                    strError = strError + strMessage;
                }

                if (strError == "")
                {
                    response.Status = 1;
                    response.Message = "Success.";
                }
                else
                {
                    response.Status = 0;
                    response.Message = strError;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region GetAccount_Receivable
        public Response GetAccount_Receivable(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME)
        {
            try
            {
                INVOICE_INFO oINV = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                string strMessage = "";

                string from_yearMonth = Utility_Component.GetYearMonth(FROM_YEAR_MONTH, true);
                string to_yearMonth = Utility_Component.GetYearMonth(TO_YEAR_MONTH, false);

                string from_statusPlanYYMM = Utility_Component.GetYearMonth(FROM_STATUS_PLAN_DEPOSIT_YYMM, true);
                string to_statusPlanYYMM = Utility_Component.GetYearMonth(TO_STATUS_PLAN_DEPOSIT_YYMM, false);

                string from_statusPlanDate = Utility_Component.GetFullDate(FROM_STATUS_ACTUAL_DEPOSIT_DATE);
                string to_statusPlanDate = Utility_Component.GetFullDate(TO_STATUS_ACTUAL_DEPOSIT_DATE);


                DataTable dt = oINV.getDataForAccount_Receivable(
                                                        TRANSACTION_TYPE,
                                                        from_yearMonth, to_yearMonth,
                                                        from_statusPlanYYMM, to_statusPlanYYMM,
                                                        from_statusPlanDate, to_statusPlanDate,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME,
                                                        out strMessage);

                response.Data = Utility.Utility_Component.DtToJSon(dt, "Account Receivable");

                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                    response.Message = "Success.";

                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There has no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region GetScheduled_Payment
        public Response GetScheduled_Payment(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME)
        {
            try
            {
                INVOICE_INFO oINV = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                string strMessage = "";

                string from_yearMonth = Utility_Component.GetYearMonth(FROM_YEAR_MONTH, true);
                string to_yearMonth = Utility_Component.GetYearMonth(TO_YEAR_MONTH, false);

                string from_statusPlanYYMM = Utility_Component.GetYearMonth(FROM_STATUS_PLAN_DEPOSIT_YYMM, true);
                string to_statusPlanYYMM = Utility_Component.GetYearMonth(TO_STATUS_PLAN_DEPOSIT_YYMM, false);

                string from_statusPlanDate = Utility_Component.GetFullDate(FROM_STATUS_ACTUAL_DEPOSIT_DATE);
                string to_statusPlanDate = Utility_Component.GetFullDate(TO_STATUS_ACTUAL_DEPOSIT_DATE);

                DataTable dt = oINV.getDataForScheduled_Payment(
                                                        TRANSACTION_TYPE,
                                                        from_yearMonth, to_yearMonth,
                                                        from_statusPlanYYMM, to_statusPlanYYMM,
                                                        from_statusPlanDate, to_statusPlanDate,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME,
                                                        out strMessage
                    );

                response.Data = Utility.Utility_Component.DtToJSon(dt, "Scheduled Payment");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                    response.Message = "Success";
                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There has no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region AllocationManualCompletion
        public Response AllocationManualCompletion(bool ALLOCATE, int SEQ_NO, string COMPANY_NO_BOX, string YEAR_MONTH, string RECEIPT_ALLOCATION_DATE, string INVOICE_ALLOCATION_DATE)
        {
            DateTime run_date = DateTime.Now;
            string strMessage = "";

            using (TransactionScope dbtnx = new TransactionScope())
            {
                try
                {
                    RECEIPT_DETAILS oRCP = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                    INVOICE_INFO oInv = new INVOICE_INFO(Properties.Settings.Default.MyConnection);

                    if (ALLOCATE)
                    {
                        if (string.IsNullOrEmpty(RECEIPT_ALLOCATION_DATE))
                        {
                            oRCP.UpdateAllocation(SEQ_NO, 3, run_date, out strMessage);
                        }
                        
                        if (string.IsNullOrEmpty(strMessage) && string.IsNullOrEmpty(INVOICE_ALLOCATION_DATE))
                        {
                            oInv.UpdateAllocation(COMPANY_NO_BOX, YEAR_MONTH, 3, run_date, out strMessage);
                        }

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(RECEIPT_ALLOCATION_DATE))
                        {
                            oRCP.UpdateAllocation(SEQ_NO, 1, null, out strMessage);
                        }

                        if (string.IsNullOrEmpty(strMessage) && !string.IsNullOrEmpty(INVOICE_ALLOCATION_DATE))
                        {
                            oInv.UpdateAllocation(COMPANY_NO_BOX, YEAR_MONTH, 1, null, out strMessage);
                        }

                    }

                    if (!string.IsNullOrEmpty(strMessage))
                    {
                        response.Status = 0;
                    }
                    else
                    {
                        dbtnx.Complete();
                        response.Status = 1;
                    }
                    response.Message = strMessage;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Status = 0;
                    response.Message = ex.Message + "\n" + ex.StackTrace;
                    return response;
                }
                    
            }
        }
        #endregion

    }
}