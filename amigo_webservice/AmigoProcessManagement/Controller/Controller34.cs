using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class Controller34
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public Controller34()
        {
            response = new Response();
        }
        #endregion

        #region GetDataGridfor34
        public Response GetDataGridfor34(string strFrom, string stringTo)
        {
            try
            {
                DateTime dtmFrom = DateTime.ParseExact(strFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                DateTime dtmTo = DateTime.ParseExact(stringTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                RECEIPT_DETAILS oRecpt = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DataTable dt = oRecpt.GetDateFor34_Grid(dtmFrom, dtmTo, out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "34Result");
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