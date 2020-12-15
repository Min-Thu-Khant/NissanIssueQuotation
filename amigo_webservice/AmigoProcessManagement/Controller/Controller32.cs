using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class Controller32
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor 
        public Controller32()
        {
            response = new Response();
        }
        #endregion

        #region GetAmigoDetailByRunDate
        public Response GetAmigoDetailByRunDate(string dtmID)
        {
            try
            {
                RECEIPT_DETAILS oRecpt = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DataTable dt = oRecpt.GetAmigoDetailByRunDate(dtmID, out strMessage);
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;

                    //add column for BILL_COMPANY_NAME
                    dt.Columns.Add("BILL_COMPANY_NAME", typeof(System.String));

                    CUSTOMER_MASTER oCustomer = new CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
                    DataTable dtCustomer = oCustomer.getBillBankAccounts();

                    for (int i = 0; i < dt.Rows.Count; i++)//loop through Amigo Detail
                    {
                        //Customer Name from Receipt Detail
                        string CustomerName = dt.Rows[i]["CUSTOMER_NAME"] == null ? "" : dt.Rows[i]["CUSTOMER_NAME"].ToString();

                        //Bill Company Name from Customer Master
                        //Search with Customer Name
                        DataRow result = dtCustomer
                                        .AsEnumerable()
                                        .Where(myRow => (
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-1") == null ? null :myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-1").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-2") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-2").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-3") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-3").Trim()) == CustomerName ||
                                                        (myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-4") == null ? null : myRow.Field<string>("BILL_BANK_ACCOUNT_NAME-4").Trim()) == CustomerName) && 
                                                         myRow.Field<DateTime>("EFFECTIVE_DATE") < DateTime.Now)
                                        .OrderByDescending(s => s.Field<DateTime>("EFFECTIVE_DATE")).ThenByDescending(s=> s.Field<int>("REQ_SEQ"))
                                        .FirstOrDefault();

                        if (result != null)
                        {
                            //append BILL COMPANY NAME
                            dt.Rows[i]["BILL_COMPANY_NAME"] = result["BILL_COMPANY_NAME"].ToString();
                        }

                    }
                        
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
                response.Data = Utility.Utility_Component.DtToJSon(dt, "32Result");
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

        #region ConvertAmigoToNoAmigo
        public Response ConvertAmigoToNoAmigo(string strData)
        {
            try
            {
                string strMessage = "";
                DataTable dtAmigo = Utility.Utility_Component.JsonToDt(strData);
                for (int i = 0; i < dtAmigo.Rows.Count; i++)
                {
                    int intSEQNO = int.Parse(dtAmigo.Rows[i]["SEQNO"] == null ? "0" : dtAmigo.Rows[i]["SEQNO"].ToString());
                    RECEIPT_DETAILS_NON_AMIGO oRecpNonAmigo = new RECEIPT_DETAILS_NON_AMIGO(Properties.Settings.Default.MyConnection);
                    RECEIPT_DETAILS oRecpAmigo = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);

                    oRecpNonAmigo.ConvertFromAmigoToNonAmigo(intSEQNO, out strMessage);
                    if (strMessage == "")
                    {
                        oRecpAmigo.removeAmigo(intSEQNO, out strMessage);
                    }
                }

                if (strMessage != "")
                {
                    response.Status = 0;
                    response.Message = strMessage;
                }
                else
                {
                    response.Status = 1;
                    response.Message = "Successfully converted.";
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