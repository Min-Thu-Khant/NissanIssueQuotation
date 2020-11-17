﻿using System;
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

        #region Disapprove
        public MetaResponse Disapprove(string COMPANY_NO_BOX, string REQ_SEQ, int REQ_TYPE, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, bool SEND_FROM_SERVER, string List)
        {

            try
            {
                DataTable Listing = Utility_Component.JsonToDt(List);
                DataRow row;

                if (REQ_TYPE == 2)
                {
                    row = Listing.Rows[1];
                }
                else
                {
                    row = Listing.Rows[0];
                }

                string msg = "";
                BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                oREQUEST_DETAIL.REQ_STATUS = 3;
                if (REQ_TYPE == 1 || REQ_TYPE ==9 || (REQ_TYPE == 2 && !string.IsNullOrEmpty(CHANGED_ITEMS.Trim())))
                {
                    oREQUEST_DETAIL.AMIGO_COOPERATION = 1;
                }
                else
                {
                    oREQUEST_DETAIL.AMIGO_COOPERATION = 2;
                }

                oREQUEST_DETAIL.AMIGO_COOPERATION_CHENGED_ITEMS = CHANGED_ITEMS.Trim();
                oREQUEST_DETAIL.SYSTEM_EFFECTIVE_DATE = Convert.ToDateTime(SYSTEM_EFFECTIVE_DATE);
                oREQUEST_DETAIL.SYSTEM_REGIST_DEADLINE = Convert.ToDateTime(SYSTEM_REGIST_DEADLINE);

                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DAL_REQUEST_DETAIL.Disapprove(oREQUEST_DETAIL, CURRENT_USER, CURRENT_DATETIME, out msg);

                if (!string.IsNullOrEmpty(msg))
                {
                    if (SEND_FROM_SERVER)
                    {
                        //bool success = PrepareAndSendMail(COMPANY_NO_BOX, row["INPUT_PERSON"], row["INPUT_PERSON_EMAIL_ADDRESS"], SEND_FROM_SERVER);

                        //if (success)
                        //{
                        //    response.Status = 1;
                        //    ResponseUtility.ReturnSuccessMessage(row, "", CURRENT_DATETIME, CURRENT_USER);
                        //}
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    response.Status = 0;
                    ResponseUtility.ReturnFailMessage(row);
                }
                
                response.Data = Utility.Utility_Component.DtToJSon(Listing, "Approval List"); ;
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

        #region PrepareAndSendMail
        private bool PrepareAndSendMail(string COMPANY_NO_BOX, string INPUT_PERSON, string INPUT_PERSON_EMAIL_ADDRESS, bool SEND_FROM_SERVER, out DataTable template)
        {
            DataTable message = new DataTable();
            message.Columns.Add("Error Message");
            message.Columns.Add("Message");
            message.Columns.Add("EmailAddressCC");
            message.Columns.Add("TemplateString");
            message.Columns.Add("SubjectString");
            
            //get config object for CTS030
            BOL_CONFIG config = new BOL_CONFIG("CTS030", con);

            
            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NO_BOX },
                        { "${inputPerson}", INPUT_PERSON},
                    };

            //prepare for mail header
            string template_base_name = "CTS030_ApprovalOfApplicationToSupplierDenied";
            string subject = config.getStringValue("emailSubject.supplier.denied"); //come from config table
            string cc = config.getStringValue("emailAddress.cc");
            template = message;
            //read email template
            string body = "";
            try
            {
                string file_path = HttpContext.Current.Server.MapPath("~/Templates/Mail/" + template_base_name + ".txt");
                body = System.IO.File.ReadAllText(file_path);
            }
            catch (Exception)
            {
                return false;
            }
            if (SEND_FROM_SERVER)
            {
                //send mail
                return Utility.Mail.sendMail(INPUT_PERSON_EMAIL_ADDRESS, cc, subject, body, map);
            }
            else
            {
                message.Clear();
                DataRow dtRow = message.NewRow();
                dtRow["SendMail"] = INPUT_PERSON_EMAIL_ADDRESS;
                dtRow["EmailAddressCC"] = cc;
                dtRow["TemplateString"] = body.Replace("${companyName}", COMPANY_NO_BOX).Replace("${inputPerson}", INPUT_PERSON);
                dtRow["SubjectString"] = subject;
                message.Rows.Add(dtRow);
                template = message;
                return true;
            }

        }
        #endregion
    }
}