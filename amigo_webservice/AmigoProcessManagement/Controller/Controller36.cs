using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using AmigoProcessManagement.Utility;
using System.Transactions;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class Controller36
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public Controller36()
        {
            response = new Response();
        }
        #endregion

        #region GetDataGridfor36
        public Response GetDataGridfor36(string strFrom, string stringTo)
        {
            try
            {
                RECEIPT_DETAILS oRecpt = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DateTime dtmFrom = DateTime.ParseExact(strFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateTime dtmTo = DateTime.ParseExact(stringTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                DataTable dt = oRecpt.GetDateFor36_Grid(dtmFrom, dtmTo, out strMessage);
               
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;

                    //append columns to RECEIPT DETAIL Results
                    dt.Columns.Add("BILL_COMPANY_NAME", typeof(System.String));
                    dt.Columns.Add("BILL_CONTACT_NAME", typeof(System.String));
                    dt.Columns.Add("BILL_PHONE_NUMBER", typeof(System.String));
                    dt.Columns.Add("BILL_MAIL_ADDRESS", typeof(System.String));

                    //Get Data from CUSTOMER MASTER 
                    CUSTOMER_MASTER oCustomer = new CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
                    DataTable dtCustomer = oCustomer.getBillBankAccounts();

                    for (int i = 0; i < dt.Rows.Count; i++)//loop through Amigo Detail
                    {
                        string CustomerName = dt.Rows[i]["CUSTOMER_NAME"].ToString(); //Customer Name from Receipt Detail

                        //Search with Customer Name
                        DataRow result = dtCustomer
                                        .AsEnumerable()
                                        .Where(myRow => (
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-1") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-1").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-2") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-2").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-3") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-3").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-4") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-4").Trim()) == CustomerName) &&
                                                         myRow.Field<DateTime>("EFFECTIVE_DATE") < DateTime.Now)
                                        .OrderByDescending(s => s.Field<DateTime>("EFFECTIVE_DATE")).ThenByDescending(s => s.Field<int>("REQ_SEQ"))
                                        .FirstOrDefault();

                        if (result !=null )
                        {
                            //insert columns values from CUSTOMER MASTER to RECEIPT DETAIL Result
                            dt.Rows[i]["BILL_COMPANY_NAME"] = result["BILL_COMPANY_NAME"].ToString();
                            dt.Rows[i]["BILL_CONTACT_NAME"] = result["BILL_CONTACT_NAME"].ToString();
                            dt.Rows[i]["BILL_PHONE_NUMBER"] = result["BILL_PHONE_NUMBER"].ToString();
                            dt.Rows[i]["BILL_MAIL_ADDRESS"] = result["BILL_MAIL_ADDRESS"].ToString();
                        }
                    }
                    response.Data = Utility.Utility_Component.DtToJSon(dt, "36Result");
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
                response.Data = Utility.Utility_Component.DtToJSon(dt, "36Result");
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

        #region RefundProcess
        public Response RefundProcess(string strData)
        {
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    string strReturnMsg = "";
                    DataTable dtData = AmigoProcessManagement.Utility.Utility_Component.JsonToDt(strData);

                    if (dtData.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            int SEQ_NO = AmigoProcessManagement.Utility.Utility_Component.dtColumnToInt((dtData.Rows[i]["SEQ_NO"] == null ? "" : dtData.Rows[i]["SEQ_NO"].ToString()));
                            DAL_AmigoProcess.DAL.RECEIPT_DETAILS oRecpt = new DAL_AmigoProcess.DAL.RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                            strReturnMsg = oRecpt.RefundUpdate(SEQ_NO); //update refund status

                            if (strReturnMsg != "") //get DB error
                            { 
                                break;
                            }
                        }
                    }
                    else
                    {
                        response.Status = 0;
                        strReturnMsg = "Data Error.";
                    }


                    if (strReturnMsg!="")
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

    }
}