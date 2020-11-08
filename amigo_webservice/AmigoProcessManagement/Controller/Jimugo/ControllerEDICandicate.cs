using System;
using System.Data;
using AmigoProcessManagement.Utility;
using System.Diagnostics;
using System.Transactions;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class ControllerEDICandicate
    {
        #region Declare
        MetaResponse response;
        Stopwatch timer;
        EDI_CANDIDATE DAL_EDI_CANDICATE;
        string con = Properties.Settings.Default.MyConnection;
        #endregion

        #region Constructor
        public ControllerEDICandicate()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            DAL_EDI_CANDICATE = new EDI_CANDIDATE(con);
        }
        #endregion

        #region GetCandicates
        public MetaResponse GetCandicates()
        {

            try
            {
                string strMessage = "";
                DataTable dt = DAL_EDI_CANDICATE.GetCandicates(out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Candicates");
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
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception)
            {
                response.Status = 0;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                response.Message = " Unexpected error occour.";
                return response;
            }
        }
        #endregion

        #region GetCandicates
        public MetaResponse ExtractEDIAutoInfo(string COMPANY_NO_BOX)
        {

            try
            {
                string strMessage = "";
                DataTable dt = DAL_EDI_CANDICATE.ExtractEDIAutoInfo(COMPANY_NO_BOX, out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Candicate Detail");
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
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception)
            {
                response.Status = 0;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                response.Message = " Unexpected error occour.";
                return response;
            }
        }
        #endregion

    }
}