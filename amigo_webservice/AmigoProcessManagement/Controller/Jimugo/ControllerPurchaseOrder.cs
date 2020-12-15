using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerPurchaseOrder
    {
        #region Declare
        MetaResponse response;
        Stopwatch timer;
        string UPDATED_AT_DATETIME;
        string CURRENT_DATETIME;
        string CURRENT_USER;
        string con = Properties.Settings.Default.MyConnection;
        DateTime TEMP = DateTime.Now;
        DataTable PARAMETERS;
        private static DataTable BodyMessage;
        #endregion

        #region Constructor
        public ControllerPurchaseOrder()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
            BodyMessage = new DataTable();
            BodyMessage.Columns.Add("Message");
            BodyMessage.Columns.Add("Error Message");
            BodyMessage.Columns.Add("UPDATED_AT");
            BodyMessage.Columns.Add("UPDATED_AT_RAW");
        }

        public ControllerPurchaseOrder(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region InitialData
        public MetaResponse getInitialData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            try
            {
                string msg = "";
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dt = DAL_REQUEST_DETAIL.Search(COMPANY_NO_BOX, REQ_SEQ, out msg);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Initial Data");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                }
                else
                {
                    if (msg == "")
                    {
                        response.Status = 1;
                        response.Message = "There is no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = msg;

                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region GetParameterByName
        private string GetParameterByKey(string key)
        {
            return PARAMETERS.Rows[0][key].ToString();
        }
        #endregion

        #region CastToBOL_REQUEST_DETAILI
        private BOL_REQUEST_DETAIL Cast_REQUEST_DETAIL()
        {
            BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
            oREQUEST_DETAIL.ORDER_DATE = Utility_Component.dtColumnToDateTime(GetParameterByKey("ORDER_DATE"));
            oREQUEST_DETAIL.SYSTEM_EFFECTIVE_DATE = Utility_Component.dtColumnToDateTime(GetParameterByKey("SYSTEM_EFFECTIVE_DATE"));
            oREQUEST_DETAIL.SYSTEM_REGIST_DEADLINE = Utility_Component.dtColumnToDateTime(GetParameterByKey("SYSTEM_REGISTER_DEADLINE"));
            oREQUEST_DETAIL.COMPANY_NO_BOX = GetParameterByKey("COMPANY_NO_BOX");
            oREQUEST_DETAIL.REQ_SEQ = Utility_Component.dtColumnToInt(GetParameterByKey("REQ_SEQ"));
            return oREQUEST_DETAIL;
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

        #region PrepareAndSendMail
        private bool PrepareAndSendMail()
        {
            //get config object for CTS050
            BOL_CONFIG config = new BOL_CONFIG("CTS050", con);

            BOL_CONFIG system_conf = new BOL_CONFIG("SYSTEM", con);

            //prepare for mail mapping
            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyNoBox}", GetParameterByKey("COMPANY_NO_BOX") },
                        { "${companyName}", GetParameterByKey("COMPANY_NAME")},
                        { "${userId}", CURRENT_USER},
                        { "${systemRegistDeadline}", GetParameterByKey("SYSTEM_REGISTER_DEADLINE")},
                        { "${changedItem}", GetParameterByKey("AMIGO_COOPERATION_CHENGED_ITEMS") }
                    };

            //prepare for mail header
            string template_base_name = "CTS050_SystemRegistrationReq";
            string to = system_conf.getStringValue("mail.send.to.l2");
            string cc = system_conf.getStringValue("mail.send.to.sales");
            string subject = config.getStringValue("emailSubject.systemRegistrationReq");
            string file_path, body;
            try
            {
                //read email template
                file_path = HttpContext.Current.Server.MapPath("~/Templates/Mail/" + template_base_name + ".txt");
                body = System.IO.File.ReadAllText(file_path);
            }
            catch (Exception)
            {
                return false;
            }

            //send mail
            return Utility.Mail.sendMail(to, cc, subject, body, map);
        }
        #endregion

        #region Save File
        private void SaveFile(System.Web.HttpPostedFile file, string destination, string filename, out string msg)
        {
            try
            {
                file.SaveAs(destination + "/" + filename);
                msg = "";
            }
            catch (Exception ex)
            {
                msg = ex.Message + "/n" + ex.StackTrace;
            }
            
        }
        #endregion

        public MetaResponse SubmitOrderRegister(string list, System.Web.HttpPostedFile file)
        {
            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    string msg = "";
                    //set global PARAMETERS
                    PARAMETERS = Utility.Utility_Component.JsonToDt(list);

                    #region Update REQUEST_DETAIL
                    //cast to REQUEST DETAIL OBJECT
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    oREQUEST_DETAIL = Cast_REQUEST_DETAIL();
                    oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 1;

                    REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                    DAL_REQUEST_DETAIL.Update(oREQUEST_DETAIL, CURRENT_DATETIME, CURRENT_USER, out msg);

                    //rollback if not success
                    if (!String.IsNullOrEmpty(msg))
                    {
                        dbTxn.Dispose();
                        return ResponseUtility.ReturnFailMessage(response, timer, BodyMessage);
                    }
                    #endregion

                    #region Insert CUSTOMER MASTER
                    //COUNT IN CUSTOMER MASTER
                    string COMPANY_NAME = GetParameterByKey("COMPANY_NAME");
                    string COMPANY_NO_BOX = GetParameterByKey("COMPANY_NO_BOX");
                    string CONTRACT_PLAN = GetParameterByKey("CONTRACT_PLAN");
                    int TRANSACTION_TYPE = int.Parse(GetParameterByKey("TRANSACTION_TYPE"));
                    int REQ_SEQ = int.Parse(GetParameterByKey("REQ_SEQ"));
                    int REQ_TYPE = int.Parse(GetParameterByKey("REQ_TYPE"));
                    DateTime START_USE_DATE = DateTime.Parse(GetParameterByKey("START_USE_DATE"));

                    CUSTOMER_MASTER DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
                    int customer_count = DAL_CUSTOMER_MASTER.getCustomerCountByKeys(COMPANY_NO_BOX, TRANSACTION_TYPE, START_USE_DATE, REQ_SEQ, out msg);

                    if (customer_count == 0) //if customer not found
                    {
                        DataTable LatestCustomer = new DataTable();
                        BOL_CUSTOMER_MASTER oCUSTOMER_MASTER = new BOL_CUSTOMER_MASTER();

                        if (REQ_TYPE == 2)
                        {
                            LatestCustomer = DAL_CUSTOMER_MASTER.GetTopCustomerByKeys(COMPANY_NO_BOX, TRANSACTION_TYPE, START_USE_DATE, out msg);

                            if (LatestCustomer.Rows.Count > 0)
                            {
                                oCUSTOMER_MASTER = Cast_CUSTOMER_MASTER(LatestCustomer.Rows[0]);
                                oCUSTOMER_MASTER.UPDATE_CONTENT = 3;
                            }
                            else //Need another message?
                            {
                                dbTxn.Dispose();
                                return ResponseUtility.ReturnFailMessage(response, timer, BodyMessage);
                            }
                            
                        }
                        if (REQ_TYPE == 1) 
                        {
                            oCUSTOMER_MASTER.UPDATE_CONTENT = 1;
                        }
                        //insert info form screen
                        oCUSTOMER_MASTER.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oCUSTOMER_MASTER.TRANSACTION_TYPE = TRANSACTION_TYPE;
                        oCUSTOMER_MASTER.EFFECTIVE_DATE = START_USE_DATE;
                        oCUSTOMER_MASTER.REQ_SEQ = REQ_SEQ;

                        DAL_CUSTOMER_MASTER.Insert(oCUSTOMER_MASTER, CURRENT_DATETIME, CURRENT_USER, out msg);

                        //rollback if not success
                        if (!String.IsNullOrEmpty(msg))
                        {
                            dbTxn.Dispose();
                            return ResponseUtility.ReturnFailMessage(response, timer, BodyMessage);
                        }

                        #region Insert Browsing supplier CUSTOMER MASTER
                        BOL_CUSTOMER_MASTER oBROWSING_SUPPLIER = new BOL_CUSTOMER_MASTER();
                       

                        if (CONTRACT_PLAN == "PRODUCT" && REQ_TYPE == 2)
                        {
                            DateTime NEW_EFFECTIVE_DATE = Convert.ToDateTime(DAL_CUSTOMER_MASTER.GetEffectiveDateForNewApplyingTime(oREQUEST_DETAIL.COMPANY_NO_BOX, TRANSACTION_TYPE, START_USE_DATE, out msg));
                            if ((NEW_EFFECTIVE_DATE.Month + NEW_EFFECTIVE_DATE.Day) != (START_USE_DATE.Month + START_USE_DATE.Day))
                            {
                                oBROWSING_SUPPLIER = Cast_CUSTOMER_MASTER(LatestCustomer.Rows[0]);
                                oBROWSING_SUPPLIER.COMPANY_NO_BOX = COMPANY_NO_BOX;
                                oBROWSING_SUPPLIER.TRANSACTION_TYPE = TRANSACTION_TYPE;
                                oBROWSING_SUPPLIER.EFFECTIVE_DATE = Convert.ToDateTime(START_USE_DATE.Year + "/" + NEW_EFFECTIVE_DATE.Month + "/" + NEW_EFFECTIVE_DATE.Day);
                                oBROWSING_SUPPLIER.UPDATE_CONTENT = 3;
                                oBROWSING_SUPPLIER.REQ_SEQ = REQ_SEQ;
                                DAL_CUSTOMER_MASTER.Insert(oBROWSING_SUPPLIER, CURRENT_DATETIME, CURRENT_USER, out msg);
                            }

                            //rollback if not success
                            if (!String.IsNullOrEmpty(msg))
                            {
                                dbTxn.Dispose();
                                return ResponseUtility.ReturnFailMessage(response, timer, BodyMessage);
                            }

                        }
                        #endregion
                    }
                    #endregion

                    #region Insert REPORT_HISTORY
                    //Insert Report_History
                    BOL_REPORT_HISTORY oREPORT_HISTORY = new BOL_REPORT_HISTORY();
                    oREPORT_HISTORY.COMPANY_NO_BOX = COMPANY_NO_BOX;
                    oREPORT_HISTORY.REQ_SEQ = REQ_SEQ;
                    oREPORT_HISTORY.REPORT_TYPE = 4;

                    REPORT_HISTORY DAL_REPORT_HISTORY = new REPORT_HISTORY(con);
                    int HISTORY_SEQ = DAL_REPORT_HISTORY.GetReportHistorySEQ(COMPANY_NO_BOX, oREPORT_HISTORY.REPORT_TYPE, oREPORT_HISTORY.REQ_SEQ, out msg);

                    //rollback if not success
                    if (!String.IsNullOrEmpty(msg))
                    {
                        dbTxn.Dispose();
                        return ResponseUtility.ReturnFailMessage(response, timer, BodyMessage);
                    }

                    oREPORT_HISTORY.REPORT_HISTORY_SEQ = HISTORY_SEQ;
                    oREPORT_HISTORY.OUTPUT_AT = Utility_Component.dtColumnToDateTime(DateTime.Now.ToString());
                    oREPORT_HISTORY.OUTPUT_FILE = COMPANY_NO_BOX + "-1-" + REQ_SEQ + "_注文書_" + COMPANY_NAME + "様.pdf";
                    oREPORT_HISTORY.EMAIL_ADDRESS = null;

                    DAL_REPORT_HISTORY.Insert(oREPORT_HISTORY, CURRENT_DATETIME, CURRENT_USER, out msg);

                    //rollback if not success
                    if (!String.IsNullOrEmpty(msg))
                    {
                        dbTxn.Dispose();
                        return ResponseUtility.MailSendingFail(response, timer, BodyMessage);
                    }
                    #endregion

                    #region Save File
                    //get destination path form config table
                    BOL_CONFIG config = new BOL_CONFIG("CTS050", con);
                    string destination = config.getStringValue("fileSavePath.purchaseOrder");
                    SaveFile(file, destination, oREPORT_HISTORY.OUTPUT_FILE, out msg);

                    if (!string.IsNullOrEmpty(msg))
                    {
                        dbTxn.Dispose();
                        response.Status = 0;
                        timer.Stop();
                        response.Meta.Duration = timer.Elapsed.TotalSeconds;
                        response.Message = "File Path Not Found";
                        //add in body message
                        DataRow row = BodyMessage.NewRow();
                        row["Error Message"] = "File Path Not Found";
                        BodyMessage.Rows.Add(row);
                        response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
                        return response;
                    }
                    #endregion

                    #region SendMail
                    bool mailSuccess = PrepareAndSendMail();

                    if (!mailSuccess)
                    {
                        dbTxn.Dispose();
                        return ResponseUtility.MailSendingFail(response, timer, BodyMessage);
                    }
                    #endregion

                    //all process success
                    dbTxn.Complete();
                    response.Status = 1;
                    response.Message = string.Format(Utility.Messages.Jimugo.I000ZZ016, "注文登録");
                    DataRow dr = BodyMessage.NewRow();
                    dr["Message"] = response.Message;
                    dr["UPDATED_AT"] = UPDATED_AT_DATETIME;
                    dr["UPDATED_AT_RAW"] = CURRENT_DATETIME;
                    BodyMessage.Rows.Add(dr);
                    response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
                    timer.Stop();
                    response.Meta.Duration = timer.Elapsed.TotalSeconds;
                    return response;
                }
                catch (Exception ex)
                {
                    dbTxn.Dispose();
                    ResponseUtility.GetUnexpectedResponse(response, timer, ex);
                    //add in body message
                    DataRow dr = BodyMessage.NewRow();
                    dr["Error Message"] = "something went wrong.";
                    BodyMessage.Rows.Add(dr);
                    response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
                    return response;
                }
            }
        }
    }
}