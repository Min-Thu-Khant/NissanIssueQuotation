using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using AmigoProcessManagement.Utility;
using System.Diagnostics;
using System.Transactions;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class ControllerApplicationApproval
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
        public ControllerApplicationApproval()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerApplicationApproval(string authHeader) :this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion


        #region getInitialData
        public MetaResponse getInitialData(string COMPANY_NO_BOX, string REQ_SEQ, int REQ_STATUS, int REQ_TYPE)
        {

            try
            {
                DataSet ds = new DataSet();
               
                string strMessage = "";
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dtList = DAL_REQUEST_DETAIL.GetInitialDataForApproval(COMPANY_NO_BOX, REQ_SEQ, REQ_STATUS, REQ_TYPE, out strMessage);
                dtList.TableName = "LISTING";
                ds.Tables.Add(dtList);
                if (dtList.Rows.Count > 0)
                {
                    response.Status = 1;
                    //SERVICE DESK POP UP
                    REQ_ADDRESS DAL_REQ_ADDRESS = new REQ_ADDRESS(con);
                    string _REQ_SEQ = dtList.Rows[0]["REQ_SEQ"].ToString().Trim();
                    if (REQ_TYPE == 9)
                    {
                        
                        DataTable SERVICE_DESK_CURRENT = DAL_REQ_ADDRESS.GetServiceDeskPopUp(COMPANY_NO_BOX, _REQ_SEQ, out strMessage);
                        SERVICE_DESK_CURRENT.TableName = "SERVICE_DESK_CURRENT";
                        ds.Tables.Add(SERVICE_DESK_CURRENT);
                    }
                    DataTable SERVICE_DESK_NEW = DAL_REQ_ADDRESS.GetServiceDeskPopUp(COMPANY_NO_BOX, REQ_SEQ, out strMessage);
                    SERVICE_DESK_NEW.TableName = "SERVICE_DESK_CHANGE";
                    ds.Tables.Add(SERVICE_DESK_NEW);

                    //ERROR NOTI POP UP
                    if (REQ_TYPE == 9)
                    {
                        DataTable ERROR_NOTI_CURRENT = DAL_REQ_ADDRESS.GetErrorNotificationPopUp(COMPANY_NO_BOX, _REQ_SEQ, out strMessage);
                        ERROR_NOTI_CURRENT.TableName = "ERROR_NOTI_CURRENT";
                        ds.Tables.Add(ERROR_NOTI_CURRENT);
                    }
                    DataTable ERROR_NOTI_NEW = DAL_REQ_ADDRESS.GetErrorNotificationPopUp(COMPANY_NO_BOX, REQ_SEQ, out strMessage);
                    ERROR_NOTI_NEW.TableName = "ERROR_NOTI_CHANGE";
                    ds.Tables.Add(ERROR_NOTI_NEW);

                    //BREAK DOWN
                    if (REQ_TYPE == 9)
                    {
                        DataTable BREAKDOWN_CURRENT = DAL_REQ_ADDRESS.GetUsageChargeBreakDownPopUp(COMPANY_NO_BOX, _REQ_SEQ, out strMessage);
                        BREAKDOWN_CURRENT.TableName = "BREAKDOWN_CURRENT";
                        ds.Tables.Add(BREAKDOWN_CURRENT);
                    }
                    DataTable BREAKDOWN_NEW = DAL_REQ_ADDRESS.GetUsageChargeBreakDownPopUp(COMPANY_NO_BOX, REQ_SEQ, out strMessage);
                    BREAKDOWN_NEW.TableName = "BREAKDOWN_CHANGE";
                    ds.Tables.Add(BREAKDOWN_NEW);
                }
                else
                {
                    if (string.IsNullOrEmpty(strMessage))
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
                response.Data = Utility.Utility_Component.DsToJSon(ds, "INITIAL DATA");
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

    }
}