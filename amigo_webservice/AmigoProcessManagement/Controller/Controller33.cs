using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class Controller33
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public Controller33()
        {
            response = new Response();
        }
        #endregion

        #region GetAmigoDetailByRunDate
        public Response GetNonAmigoDetailByRunDate(string dtmID)
        {
            try
            {
                RECEIPT_DETAILS_NON_AMIGO oRecpt = new RECEIPT_DETAILS_NON_AMIGO(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DataTable dt = oRecpt.GetNonAmigoDetailByRunDate(dtmID, out strMessage);
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
                        response.Message =  "There has no data to display.";
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

        #region ConvertAmigoToNoAmigo
        public Response ConvertNonAmigoToAmigo(string strData)
        {
            try
            {
                string strMessage = "";
                int fail_count = 0;
                DataTable dtConvert = Utility.Utility_Component.JsonToDt(strData);
                response.Status = 1;
                for (int i = 0; i < dtConvert.Rows.Count; i++)
                {
                    DAL_AmigoProcess.DAL.RECEIPT_DETAILS_NON_AMIGO oRecpNonAmigo = new DAL_AmigoProcess.DAL.RECEIPT_DETAILS_NON_AMIGO(Properties.Settings.Default.MyConnection);
                    DAL_AmigoProcess.DAL.RECEIPT_DETAILS oRecpAmigo = new DAL_AmigoProcess.DAL.RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                    int intSEQNO = int.Parse(dtConvert.Rows[i]["SEQNO"] == null ? "0" : dtConvert.Rows[i]["SEQNO"].ToString());
                    string bankAccountName = dtConvert.Rows[i]["bankAccountName"] == null ? "0" : dtConvert.Rows[i]["bankAccountName"].ToString();

                    //search with bankAccountName
                    DAL_AmigoProcess.DAL.CUSTOMER_MASTER oCustomer = new DAL_AmigoProcess.DAL.CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
                    DataTable dt = oCustomer.SearchByBankAccountName(bankAccountName);

                    if (dt.Rows.Count > 0)
                    {
                        oRecpAmigo.ConvertFromNonAmigoToAmigo(intSEQNO, out strMessage);
                        if (strMessage == "")
                        {
                            oRecpNonAmigo.removeNonAmigo(intSEQNO, out strMessage);
                        }

                        if (strMessage != "")
                        {
                            response.Status = 0;
                            response.Message = strMessage;
                        }

                    }
                    else
                    {
                        fail_count++;
                        response.Status = 0;
                    }
                }
                response.Message = fail_count.ToString();
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
