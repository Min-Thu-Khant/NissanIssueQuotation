using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerMonthlySaleComparisonList
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
        public ControllerMonthlySaleComparisonList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerMonthlySaleComparisonList(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }

        #endregion

        #region getMonthlySaleComparisonList
        public MetaResponse getMonthlySaleComparisonList(string strYYYMM1 , string strYYMM2, int OFFSET, int LIMIT)
        {
            try
            {

               
                string strMessage = "";
                int TOTAL = 0;
                CUSTOMER_MASTER DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
                DataTable dt = DAL_CUSTOMER_MASTER.getMonthlySaleComparisonList(strYYYMM1, strYYMM2, OFFSET, LIMIT, out strMessage, out TOTAL);
              
                response.Data = Utility.Utility_Component.DtToJSon(dt, "MonthlySaleComparisonList");
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
                response.Meta.Offset = OFFSET;
                response.Meta.Limit = LIMIT;
                response.Meta.Total = TOTAL;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
                return response;
            }
            catch (Exception)
            {
                response.Status = 0;
                response.Message = " Unexpected error occour.";
                return response;
            }
        }
        #endregion
    }
}