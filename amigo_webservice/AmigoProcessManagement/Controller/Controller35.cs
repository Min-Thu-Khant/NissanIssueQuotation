using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class Controller35
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public Controller35()
        {
            response = new Response();
        }
        #endregion

        #region GetDataGridfor35
        public Response GetDataGridfor35(string strFrom, string stringTo, bool isNoReserved)
        {
            try
            {
                RECEIPT_DETAILS oRecpt = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DateTime dtmFrom = DateTime.ParseExact(strFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateTime dtmTo = DateTime.ParseExact(stringTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                DataTable dt = oRecpt.GetDateFor35_Grid(dtmFrom, dtmTo, isNoReserved, out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "35Result");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
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

        #region CancelAllocation
        public Response CancelAllocation(string strData)
        {
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    string strReturnMsg = "";
                    string strMSG = "";
                    DataTable dtData = AmigoProcessManagement.Utility.Utility_Component.JsonToDt(strData);

                    if (dtData.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            int GRID_SEQ_NO = AmigoProcessManagement.Utility.Utility_Component.dtColumnToInt((dtData.Rows[i]["SEQ_NO"] == null ? "" : dtData.Rows[i]["SEQ_NO"].ToString()));
                            string GRID_COMPANY_NO_BOX = dtData.Rows[i]["COMPANY_NO_BOX"] == null ? "" : dtData.Rows[i]["COMPANY_NO_BOX"].ToString();
                            string GRID_YEAR_MONTH = dtData.Rows[i]["YEAR_MONTH"] == null ? "" : dtData.Rows[i]["YEAR_MONTH"].ToString();
                            string GRID_BILLING_CODE = GRID_COMPANY_NO_BOX + GRID_YEAR_MONTH;

                            //getAllocatedAmount
                            RESERVE_INFO oRI = new RESERVE_INFO(Properties.Settings.Default.MyConnection);
                            DataTable dt = oRI.GetReservceInfoByBillingCode(GRID_BILLING_CODE);
                            if (dt.Rows.Count > 0)
                            {
                                for (int  j= 0; j < dt.Rows.Count ; j++)
                                {
                                    //UpdateReceiptDetail
                                    RECEIPT_DETAILS oRecep = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                                    int RESERVE_SEQ_NO = int.Parse(dt.Rows[j][0].ToString());
                                    oRecep.CancelAllocation(RESERVE_SEQ_NO, out strMSG);
                                    strReturnMsg = strMSG;

                                    //GET COMPANY_NO_BOX from Reserve By SEQ_N0
                                    DataTable BILLING_CODES = oRI.GetCompanyNoBoxBySEQNO(RESERVE_SEQ_NO, out strMSG);

                                    for (int k = 0; k < BILLING_CODES.Rows.Count; k++)
                                    {
                                        string MATCHED_BILLING_CODE = BILLING_CODES.Rows[k][0].ToString();
                                        //UpdateInvoiceInfo
                                        INVOICE_INFO oINV = new INVOICE_INFO(Properties.Settings.Default.MyConnection);
                                        oINV.UpdateInvoiceForCancel(MATCHED_BILLING_CODE.Substring(0, 10), MATCHED_BILLING_CODE.Substring(10, 5), out strMSG);
                                        strReturnMsg = strReturnMsg + strMSG;
                                        //DeleteReserveInfo
                                        strMSG = oRI.removeReserve(RESERVE_SEQ_NO,MATCHED_BILLING_CODE);
                                        strReturnMsg = strReturnMsg + strMSG;
                                    }
                                }
                            }

                            if (strReturnMsg != "")
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        strReturnMsg = "Data Error.";
                    }


                    if (strReturnMsg != "")
                    {
                        dbTxn.Dispose(); //rollback
                        response.Status = 0;
                    }
                    else
                    {
                        dbTxn.Complete(); //commit operation
                        response.Status = 1;
                    }

                    response.Message = strReturnMsg;
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

        #region Get35_AccountingCSV
        public Response Get35_AccountingCSV(string strFrom, string stringTo)
        {
            try
            {
                RECEIPT_DETAILS oRecpt = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DateTime dtmFrom = DateTime.ParseExact(strFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateTime dtmTo = DateTime.ParseExact(stringTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                DataTable dt = oRecpt.Get35_AccountingCSV(dtmFrom, dtmTo, out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "36Result");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
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
    }
}