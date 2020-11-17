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

        #region ApproveCancel
        public MetaResponse ApproveCancel(string COMPANY_NO_BOX, string List)
        {

            try
            {
                DataSet ds = new DataSet();
                DataTable Listing = Utility_Component.JsonToDt(List);
                DataRow row;
                row = Listing.Rows[0];

                string msg = "";
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DAL_REQUEST_DETAIL.ApproveCancel(COMPANY_NO_BOX, row["REQ_SEQ"].ToString(), CURRENT_USER, CURRENT_DATETIME, out msg);
                if (string.IsNullOrEmpty(msg))
                {
                    response.Status = 1;
                    row["UPDATED_AT"] = UPDATED_AT_DATETIME;
                    row["UPDATED_AT_RAW"] = CURRENT_DATETIME;
                    row["UPDATED_BY"] = CURRENT_USER;
                    row["UPDATE_MESSAGE"] = string.Format(Messages.Jimugo.I000ZZ016, "承認解除");
                    Listing.TableName = "LISTING";
                    ds.Tables.Add(Listing.Copy());
                }
                else
                {
                    response.Status = 0;
                    row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
                    Listing.TableName = "LISTING";
                    ds.Tables.Add(Listing.Copy());
                }
                response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval");
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

        #region Approve
        public MetaResponse Approve(string COMPANY_NO_BOX, int REQ_TYPE, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, string List)
        {

            try
            {
                DataSet ds = new DataSet();
                DataTable Listing = Utility_Component.JsonToDt(List);
                DataRow row;
                row = Listing.Rows[0];
                string EMIAL_SENDING_TARGET_FLG = row["MAIL_SENDING_TARGET_FLG"].ToString().Trim();
                int TRANSACTION_TYPE = int.Parse(row["TRANSACTION_TYPE"].ToString().Trim());
                DateTime START_USE_DATE = Convert.ToDateTime(row["START_USE_DATE"].ToString().Trim());

                using (TransactionScope dbTxn = new TransactionScope())
                {
                    #region Approve
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    oREQUEST_DETAIL.COMPANY_NO_BOX = COMPANY_NO_BOX;
                    oREQUEST_DETAIL.REQ_STATUS = 2;
                    if (REQ_TYPE == 1 || REQ_TYPE == 9 || (REQ_TYPE == 2 && !string.IsNullOrEmpty(CHANGED_ITEMS.Trim())))
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
                    oREQUEST_DETAIL.REQ_SEQ =int.Parse(row["REQ_SEQ"].ToString());

                    if (EMIAL_SENDING_TARGET_FLG == "*")
                    {
                        oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 1;
                    }
                    else
                    {
                        oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 0;
                    }
                    oREQUEST_DETAIL.UPDATED_AT = row["UPDATED_AT_RAW"].ToString();

                    string msg = "";
                    REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);

                    DAL_REQUEST_DETAIL.Approve(oREQUEST_DETAIL, CURRENT_USER, CURRENT_DATETIME, out msg);
                   
                    if (!string.IsNullOrEmpty(msg))
                    {
                        response.Status = 0;
                        row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
                        Listing.TableName = "LISTING";
                        ds.Tables.Add(Listing.Copy());
                        response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval");
                        timer.Stop();
                        response.Meta.Duration = timer.Elapsed.TotalSeconds;
                        return response;
                    }
                    #endregion

                    if (EMIAL_SENDING_TARGET_FLG == "*")
                    {
                        DataTable LatestCustomer = new DataTable();
                        CUSTOMER_MASTER DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
                        if (REQ_TYPE == 2 || REQ_TYPE == 9)
                        {
                            LatestCustomer =  DAL_CUSTOMER_MASTER.GetTopCustomerByKeys(oREQUEST_DETAIL.COMPANY_NO_BOX, TRANSACTION_TYPE, START_USE_DATE, out msg);

                        }

                        #region CONDUCT NEW CUSTOMER MASTER
                        BOL_CUSTOMER_MASTER oCUSTOMER_MASTER = new BOL_CUSTOMER_MASTER();
                        oCUSTOMER_MASTER.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oCUSTOMER_MASTER.TRANSACTION_TYPE = TRANSACTION_TYPE;
                        oCUSTOMER_MASTER.EFFECTIVE_DATE = START_USE_DATE;
                        oCUSTOMER_MASTER.REQ_SEQ = oREQUEST_DETAIL.REQ_SEQ;
                        oCUSTOMER_MASTER.UPDATE_CONTENT = REQ_TYPE;

                        if (LatestCustomer.Rows.Count > 0 && REQ_TYPE !=1)
                        {
                            oCUSTOMER_MASTER = Cast_CUSTOMER_MASTER(LatestCustomer.Rows[0]);
                        }

                        DAL_CUSTOMER_MASTER.Insert(oCUSTOMER_MASTER, CURRENT_DATETIME, CURRENT_USER, out msg);

                        if (!string.IsNullOrEmpty(msg))
                        {
                            response.Status = 0;
                            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
                            Listing.TableName = "LISTING";
                            ds.Tables.Add(Listing.Copy());
                            response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval");
                            timer.Stop();
                            response.Meta.Duration = timer.Elapsed.TotalSeconds;
                            return response;
                        }

                        #endregion

                        #region Insert Browsing CUSTOMER MASTER
                        BOL_CUSTOMER_MASTER oCUSTOMER_MASTER_BROWSING = new BOL_CUSTOMER_MASTER();
                        oCUSTOMER_MASTER_BROWSING = Cast_CUSTOMER_MASTER(LatestCustomer.Rows[0]);
                        oCUSTOMER_MASTER_BROWSING.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oCUSTOMER_MASTER_BROWSING.TRANSACTION_TYPE = TRANSACTION_TYPE;
                        DateTime FINAL_DATE;
                        if (Utility_Component.IsFirstYearMonthGreater(oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE, START_USE_DATE))
                        {
                            FINAL_DATE = Convert.ToDateTime(START_USE_DATE.Year + "/" + oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE.Month + "/" + oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE.Date);
                        }
                        else
                        {
                            FINAL_DATE = Convert.ToDateTime((START_USE_DATE.Year + 1) + "/" + oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE.Month + "/" + oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE.Date);
                        }
                        oCUSTOMER_MASTER_BROWSING.EFFECTIVE_DATE = FINAL_DATE;
                        oCUSTOMER_MASTER_BROWSING.REQ_SEQ = oREQUEST_DETAIL.REQ_SEQ;
                        oCUSTOMER_MASTER_BROWSING.UPDATE_CONTENT = REQ_TYPE;

                        DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
                        DAL_CUSTOMER_MASTER.Insert(oCUSTOMER_MASTER_BROWSING, CURRENT_DATETIME, CURRENT_USER, out msg);

                        if (!string.IsNullOrEmpty(msg))
                        {
                            response.Status = 0;
                            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
                            Listing.TableName = "LISTING";
                            ds.Tables.Add(Listing.Copy());
                            response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval");
                            timer.Stop();
                            response.Meta.Duration = timer.Elapsed.TotalSeconds;
                            return response;
                        }
                        #endregion

                    }

                    response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval");
                    timer.Stop();
                    response.Meta.Duration = timer.Elapsed.TotalSeconds;
                    return response;
                }
                
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region CastToBOL_CUSTOMER_MASTER
        private BOL_CUSTOMER_MASTER Cast_CUSTOMER_MASTER(DataRow row)
        {
            BOL_CUSTOMER_MASTER oCUSTOMER_MASTER = new BOL_CUSTOMER_MASTER();

            oCUSTOMER_MASTER.CONTRACT_DATE = Utility_Component.dtColumnToDateTime(row["CONTRACT_DATE"].ToString());
            oCUSTOMER_MASTER.SPECIAL_NOTES_1 = row["SPECIAL_NOTES_1"].ToString();
            oCUSTOMER_MASTER.SPECIAL_NOTES_2 = row["SPECIAL_NOTES_2"].ToString();
            oCUSTOMER_MASTER.SPECIAL_NOTES_3 = row["SPECIAL_NOTES_3"].ToString();
            oCUSTOMER_MASTER.SPECIAL_NOTES_4 = row["SPECIAL_NOTES_4"].ToString();
            oCUSTOMER_MASTER.NCS_CUSTOMER_CODE = row["NCS_CUSTOMER_CODE"].ToString();
            oCUSTOMER_MASTER.BILL_BILLING_INTERVAL = Utility_Component.dtColumnToInt(row["BILL_BILLING_INTERVAL"].ToString());
            oCUSTOMER_MASTER.BILL_DEPOSIT_RULES = Utility_Component.dtColumnToInt(row["BILL_DEPOSIT_RULES"].ToString());
            oCUSTOMER_MASTER.BILL_TRANSFER_FEE = Utility_Component.dtColumnToDecimal(row["BILL_TRANSFER_FEE"].ToString());
            oCUSTOMER_MASTER.BILL_EXPENSES = Utility_Component.dtColumnToDecimal(row["BILL_EXPENSES"].ToString());
            oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE = Utility_Component.dtColumnToDateTime(row["COMPANY_NAME_CHANGED_DATE"].ToString());
            oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME = row["PREVIOUS_COMPANY_NAME"].ToString();
            oCUSTOMER_MASTER.OBOEGAKI_DATE = Utility_Component.dtColumnToDateTime(row["OBOEGAKI_DATE"].ToString());
            return oCUSTOMER_MASTER;
        }
        #endregion

        #region Disapprove
        public MetaResponse Disapprove(string COMPANY_NO_BOX, int REQ_TYPE, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, bool SEND_FROM_SERVER, string List)
        {

            try
            {
                DataSet ds = new DataSet();
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
                oREQUEST_DETAIL.REQ_SEQ = int.Parse(row["REQ_SEQ"].ToString());
                oREQUEST_DETAIL.UPDATED_AT = row["UPDATED_AT_RAW"].ToString();
                oREQUEST_DETAIL.COMPANY_NO_BOX = COMPANY_NO_BOX;

                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DAL_REQUEST_DETAIL.Disapprove(oREQUEST_DETAIL, CURRENT_USER, CURRENT_DATETIME, out msg);

                if (string.IsNullOrEmpty(msg))
                {
                    DataTable dtMail = new DataTable();
                    bool success = DisapproveSendMail(row["COMPANY_NAME"].ToString(), row["INPUT_PERSON"].ToString(), row["INPUT_PERSON_EMAIL_ADDRESS"].ToString(), SEND_FROM_SERVER, out dtMail);

                    if (success)
                    {
                        response.Status = 1;
                        row["UPDATED_AT"] = UPDATED_AT_DATETIME;
                        row["UPDATED_AT_RAW"] = CURRENT_DATETIME;
                        row["UPDATED_BY"] = CURRENT_USER;
                        row["UPDATE_MESSAGE"] = string.Format( Messages.Jimugo.I000ZZ016, "否認");
                        Listing.TableName = "LISTING";
                        ds.Tables.Add(Listing.Copy());
                        dtMail.TableName = "MAIL";
                        ds.Tables.Add(dtMail.Copy());
                    }
                }
                else
                {
                    response.Status = 0;
                    row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
                    Listing.TableName = "LISTING";
                    ds.Tables.Add(Listing.Copy());
                }
                
                response.Data = Utility.Utility_Component.DsToJSon(ds, "Approval"); 
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

        #region DisapproveSendMail
        private bool DisapproveSendMail(string COMPANY_NAME, string INPUT_PERSON, string INPUT_PERSON_EMAIL_ADDRESS, bool SEND_FROM_SERVER, out DataTable template)
        {
            DataTable message = new DataTable();
            message.Columns.Add("Error Message");
            message.Columns.Add("Message");
            message.Columns.Add("SendMail");
            message.Columns.Add("EmailAddressCC");
            message.Columns.Add("TemplateString");
            message.Columns.Add("SubjectString");
            
            //get config object for CTS030
            BOL_CONFIG config = new BOL_CONFIG("CTS030", con);

            
            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NAME },
                        { "${inputPerson}", INPUT_PERSON},
                    };

            //prepare for mail header
            string template_base_name = "CTS030_ApprovalOfApplicationToSupplierDenied";
            string subject = config.getStringValue("emailSubject.supplier.denied"); 
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
                dtRow["TemplateString"] = body.Replace("${companyName}", COMPANY_NAME).Replace("${inputPerson}", INPUT_PERSON);
                dtRow["SubjectString"] = subject;
                message.Rows.Add(dtRow);
                template = message;
                return true;
            }

        }
        #endregion

        #region SendMailToMaintenance
        private bool SendMailToMaintenance(string COMPANY_NO_BOX, string INPUT_PERSON, string INPUT_PERSON_EMAIL_ADDRESS, out DataTable template)
        {
            DataTable message = new DataTable();
            message.Columns.Add("Error Message");
            message.Columns.Add("Message");
            message.Columns.Add("SendMail");
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
            string subject = config.getStringValue("emailSubject.supplier.denied");
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
            //send mail
            return Utility.Mail.sendMail(INPUT_PERSON_EMAIL_ADDRESS, cc, subject, body, map);


        }
        #endregion

    }
}