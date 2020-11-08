using AmigoProcessManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Transactions;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.ViewModels;
using DAL_AmigoProcess.BOL;

namespace AmigoProcessManagement.Controller
{
    public class ControllerUsageInfoRegistrationList
    {
        #region Declare
        MetaResponse response;
        Stopwatch timer;
        string con = Properties.Settings.Default.MyConnection;
        String UPDATED_AT_DATETIME;
        string CURRENT_DATETIME;
        string CURRENT_USER;
        #endregion

        #region Constructor
        public ControllerUsageInfoRegistrationList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            
            //UPDATED_AT
            DateTime temp = DateTime.Now;
            UPDATED_AT_DATETIME = temp.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = temp.ToString("yyyyMMddHHmmss");
        }

        public ControllerUsageInfoRegistrationList(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }

        #endregion

        #region getUsageInformationRegistrationList
        public MetaResponse getUsageInformationRegistrationList(string COMPANY_NO_BOX, string COMPANY_NAME, string EDI_ACCOUNT, int OFFSET, int LIMIT)
        {

            try
            {
                string strMessage = "";
                int TOTAL = 0;
                REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);
                DataTable dt = DAL_REQUEST_ID.GetUsageInformationRegistrationList(COMPANY_NO_BOX, COMPANY_NAME, EDI_ACCOUNT, OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "UsageInfo Registration List");
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
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region UpdateUsageRegistrationList
        public MetaResponse UpdateUsageRegistrationList(string UsageInfoRegList)
        {
            try
            {
                DataTable dgvList = Utility.Utility_Component.JsonToDt(UsageInfoRegList);
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    //CAST usage info registration list into view model
                    USAGE_INFO_REGISTRATION oUSAGE_INFO_REG = CAST_TO_USAGE_INFO_REGISTRATION(dgvList.Rows[i]);

                    switch (dgvList.Rows[i]["MK"].ToString())
                    {
                        case "I":
                            HandleInsert(oUSAGE_INFO_REG, "I", dgvList.Rows[i]);
                            break;
                        case "C":
                            HandleInsert(oUSAGE_INFO_REG, "C", dgvList.Rows[i]);
                            break;
                        case "M":
                            HandleModify(oUSAGE_INFO_REG, dgvList.Rows[i]);
                            break;
                        case "D":
                            HandleDelete(oUSAGE_INFO_REG, dgvList.Rows[i]);
                            break;
                    default:
                            break;
                    }
                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "Usage Application Registration Update"); ;
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

        #region CastToViewModel
        private USAGE_INFO_REGISTRATION CAST_TO_USAGE_INFO_REGISTRATION(DataRow row)
        {
            USAGE_INFO_REGISTRATION oUsageInfoReg = new USAGE_INFO_REGISTRATION();
            oUsageInfoReg.EDI_ACCOUNT = row["EDI_ACCOUNT"].ToString().Replace("@","");
            oUsageInfoReg.COMPNAY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
            oUsageInfoReg.COMPANY_NAME = row["COMPANY_NAME"].ToString();
            oUsageInfoReg.GD_CODE = row["GD_CODE"].ToString();
            oUsageInfoReg.CONSIGN_FLG = row["CONSIGN_FLG"].ToString();
            oUsageInfoReg.LOGIN_TYPE = row["LOGIN_TYPE"].ToString();
            oUsageInfoReg.MAKER1 = row["MAKER1"].ToString();
            oUsageInfoReg.MAKER2 = row["MAKER2"].ToString();
            oUsageInfoReg.MAKER3 = row["MAKER3"].ToString();
            oUsageInfoReg.MAKER4 = row["MAKER4"].ToString();
            oUsageInfoReg.MAKER5 = row["MAKER5"].ToString();
            oUsageInfoReg.MAKER6 = row["MAKER6"].ToString();
            oUsageInfoReg.MAKER7 = row["MAKER7"].ToString();
            oUsageInfoReg.MAKER8 = row["MAKER8"].ToString();
            oUsageInfoReg.MAKER9 = row["MAKER9"].ToString();
            oUsageInfoReg.MAKER10 = row["MAKER10"].ToString();
            //BOX_SIZE
            if (String.IsNullOrEmpty(row["BOX_SIZE"].ToString()))
            {
                oUsageInfoReg.BOX_SIZE = null;
            }
            else
            {
                int extended_box = 0;
                int.TryParse(row["BOX_SIZE"].ToString(), out extended_box);
                oUsageInfoReg.BOX_SIZE = extended_box;
            }
            
            //oUsageInfoReg.SERVER_CONNECTION = row["SERVER_CONNECTION"].ToString();

            //plan amigo BIZ
            if (String.IsNullOrEmpty(row["PLAN_AMIGO_BIZ"].ToString()))
            {
                oUsageInfoReg.PLAN_AMIGO_BIZ = null;
            }
            else
            {
                int plan_amigo_biz = 0;
                int.TryParse(row["PLAN_AMIGO_BIZ"].ToString(), out plan_amigo_biz);
                oUsageInfoReg.PLAN_AMIGO_BIZ = plan_amigo_biz;
            }

            //plan amigo CAI
            if (String.IsNullOrEmpty(row["PLAN_AMIGO_CAI"].ToString()))
            {
                oUsageInfoReg.PLAN_AMIGO_CAI = null;
            }
            else
            {
                int plan_amigo_cai = 0;
                int.TryParse(row["PLAN_AMIGO_CAI"].ToString(), out plan_amigo_cai);
                oUsageInfoReg.PLAN_AMIGO_CAI = plan_amigo_cai;
            }
            oUsageInfoReg.MAIL_ADDRESS1 = row["MAIL_ADDRESS1"].ToString();
            oUsageInfoReg.MAIL_ADDRESS2 = row["MAIL_ADDRESS2"].ToString();
            oUsageInfoReg.MAIL_ADDRESS3 = row["MAIL_ADDRESS3"].ToString();
            oUsageInfoReg.ADM_USER_ID = row["ADM_USER_ID"].ToString();
            oUsageInfoReg.ADM_PASSWORD = row["ADM_PASSWORD"].ToString();
            oUsageInfoReg.ATDL_USER_ID = row["ATDL_USER_ID"].ToString();
            oUsageInfoReg.ATDL_PASSWORD = row["ATDL_PASSWORD"].ToString();
            oUsageInfoReg.SSHGW_USER_ID = row["SSHGW_USER_ID"].ToString();
            oUsageInfoReg.SSHGW_PUBLIC_KEY = row["SSHGW_PUBLIC_KEY"].ToString();
            oUsageInfoReg.UPDATED_AT = row["UPDATED_AT"].ToString();
            oUsageInfoReg.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString();

            return oUsageInfoReg;
        }
        #endregion

        #region SettingCompleteMail
        public MetaResponse SettingCompleteMail(string UsageInfoRegList, string authHeader)
        {
            try
            {
                DataTable dgvList = Utility.Utility_Component.JsonToDt(UsageInfoRegList);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    USAGE_INFO_REGISTRATION oUSAGE_INFO_REG = new USAGE_INFO_REGISTRATION();
                    oUSAGE_INFO_REG = CAST_TO_USAGE_INFO_REGISTRATION(dgvList.Rows[i]);

                    bool mailSuccess = PrepareAndSendMail(oUSAGE_INFO_REG);

                    if (mailSuccess)
                    {
                        ResponseUtility.ReturnMailSuccessMessage(dgvList.Rows[i]);
              
                    }
                    else
                    {
                        ResponseUtility.MailSendingFail(dgvList.Rows[i]);
                    }
                }

                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "Mail status"); ;
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
        private bool PrepareAndSendMail(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG)
        {
            //get config object for CTS010
            BOL_CONFIG config = new BOL_CONFIG("CTS070", con);
            BOL_CONFIG systemConfig = new BOL_CONFIG("SYSTEM", con);

            //prepare for mail mapping

            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyNoBox}", oUSAGE_INFO_REG.COMPNAY_NO_BOX },
                        { "${ediAccount}", oUSAGE_INFO_REG.EDI_ACCOUNT },
                        { "${userId}", CURRENT_USER}
                    };

            //prepare for mail header
            string template_base_name = "CTS070_RegOfUsageInfo";
            string subject = config.getStringValue("emailSubject.notice"); //come from config table

            string SendingAddress = systemConfig.getStringValue("mail.send.to.sales");
            string SendingAddressCCs = config.getStringValue("emailAddress.cc");
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
            return Utility.Mail.sendMail(SendingAddress, SendingAddressCCs, subject, body, map);
        }
        #endregion


        #region HandleInsert
        private void HandleInsert(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG, string OPERATION, DataRow row)
        {

            string strMsg = "";

            //Search in EDI_CANDICATE
            BOL_EDI_CANDIDATE oEDI_CANDIDATE = new BOL_EDI_CANDIDATE();

            EDI_CANDIDATE DAL_EDI_CANDICATE = new EDI_CANDIDATE(con);
            DataTable dtUseFLG = DAL_EDI_CANDICATE.GetUseFLG(oUSAGE_INFO_REG.EDI_ACCOUNT, out strMsg);

            using (TransactionScope dbTxn = new TransactionScope())
            {

                //Prepare EDI CANDIDATE 
                oEDI_CANDIDATE = GetEDI_CANDIDATE(oUSAGE_INFO_REG);


                if (dtUseFLG.Rows.Count == 0)
                {
                    //Insert AS USED
                    DAL_EDI_CANDICATE.Insert(oEDI_CANDIDATE, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                }
                else
                {
                    if (dtUseFLG.Rows[0]["USED_FLG"].ToString() == "*") //if record is already used
                    {
                        ResponseUtility.ReturnFailMessage(row, Utility.Messages.Jimugo.E000WB013);
                        return;
                    }
                    else
                    {
                        //set used flage
                        oEDI_CANDIDATE.USED_FLG = "*";
                        //Update as USED
                        DAL_EDI_CANDICATE.Update(oEDI_CANDIDATE,CURRENT_DATETIME, CURRENT_USER, out strMsg);
                    }
                }

                EDI_ACCOUNT DAL_EDI_ACCOUNT = new EDI_ACCOUNT(con);
                BOL_EDI_ACCOUNT oEDI_ACCOUNT = GetEDI_ACCOUNT(oUSAGE_INFO_REG);

                if (DAL_EDI_ACCOUNT.IsCompanyNoBoxAlreadyRegistered(oEDI_ACCOUNT.COMPANY_NO_BOX, out strMsg))
                {
                    ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ039, "COMPANY NO BOX"));
                    return;
                    
                }

                if (DAL_EDI_ACCOUNT.IsEDIAccountAlreadyRegistered(oEDI_ACCOUNT.EDI_ACCOUNT, out strMsg))
                {
                    ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ039, "EDI ACCOUNT"));
                    return;
                }

                DAL_EDI_ACCOUNT.Insert(oEDI_ACCOUNT, CURRENT_DATETIME, CURRENT_USER, out strMsg);

                #region ASSIGN_MK_VALUE_AND_MESSAGES

                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    dbTxn.Complete();
                    ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }


            }
            #endregion
        }
        #endregion

        #region HandleDelete
        private void HandleDelete(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                //GET EDI ACCOUNT OBJECT
                BOL_EDI_ACCOUNT oEDI_ACCOUNT = GetEDI_ACCOUNT(oUSAGE_INFO_REG);

                EDI_ACCOUNT DAL_EDI_ACCOUNT = new EDI_ACCOUNT(con);

                if (!DAL_EDI_ACCOUNT.IsAlreadyUpdated(oEDI_ACCOUNT, out strMsg)) // IF updated_at is not already modified
                {

                    //delete the record
                    DAL_EDI_ACCOUNT.Delete(oEDI_ACCOUNT, out strMsg);
                   
                }
                else
                {
                    dbTxn.Dispose();
                    ResponseUtility.ReturnFailMessage(row);
                    return;
                }

                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    dbTxn.Complete();
                    ResponseUtility.ReturnDeleteSuccessMessage(row);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }
            }

        }

        #endregion

        #region HandleModify
        private void HandleModify(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG, DataRow row)
        {
            string strMsg = "";

            //Get EDI_ACCOUNT object
            BOL_EDI_ACCOUNT oEDI_ACCOUNT = GetEDI_ACCOUNT(oUSAGE_INFO_REG);
            
            EDI_ACCOUNT DAL_EDI_ACCOUNT = new EDI_ACCOUNT(con);
            if (!DAL_EDI_ACCOUNT.IsAlreadyUpdated(oEDI_ACCOUNT, out strMsg)) // If updated_at is not already modified
            {
                //insert the record
                DAL_EDI_ACCOUNT.Update(oEDI_ACCOUNT, CURRENT_DATETIME, CURRENT_USER, out strMsg);
            }
            else
            {
                //already use in another process
                ResponseUtility.ReturnFailMessage(row);
                return;
            }

            //return message and MK value
            if (String.IsNullOrEmpty(strMsg)) //success
            {
                ResponseUtility.ReturnSuccessMessage(row,UPDATED_AT_DATETIME,CURRENT_DATETIME,CURRENT_USER);
            }
            else //failed
            {
                ResponseUtility.ReturnFailMessage(row);
            }

        }
        #endregion

        #region GetEDI_CANDIDATE
        private BOL_EDI_CANDIDATE GetEDI_CANDIDATE(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG)
        {
            BOL_EDI_CANDIDATE oEDI_CANDIDATE = new BOL_EDI_CANDIDATE();

            oEDI_CANDIDATE.EDI_ACCOUNT = oUSAGE_INFO_REG.EDI_ACCOUNT;
            oEDI_CANDIDATE.USED_FLG = "*";
            oEDI_CANDIDATE.CREATED_BY = oUSAGE_INFO_REG.UPDATED_BY;
            oEDI_CANDIDATE.UPDATED_BY = oUSAGE_INFO_REG.UPDATED_BY;

            return oEDI_CANDIDATE;
        }
        #endregion

        #region GetEDI_ACCOUNT
        private BOL_EDI_ACCOUNT GetEDI_ACCOUNT(USAGE_INFO_REGISTRATION oUSAGE_INFO_REG)
        {
            BOL_EDI_ACCOUNT oEDI_ACCOUNT = new BOL_EDI_ACCOUNT();

            oEDI_ACCOUNT.EDI_ACCOUNT = oUSAGE_INFO_REG.EDI_ACCOUNT;
            oEDI_ACCOUNT.COMPANY_NO_BOX = oUSAGE_INFO_REG.COMPNAY_NO_BOX;
            oEDI_ACCOUNT.CONSIGN_FLG = oUSAGE_INFO_REG.CONSIGN_FLG;
            oEDI_ACCOUNT.LOGIN_TYPE = oUSAGE_INFO_REG.LOGIN_TYPE;
            oEDI_ACCOUNT.MAKER1 = oUSAGE_INFO_REG.MAKER1;
            oEDI_ACCOUNT.MAKER2 = oUSAGE_INFO_REG.MAKER2;
            oEDI_ACCOUNT.MAKER3 = oUSAGE_INFO_REG.MAKER3;
            oEDI_ACCOUNT.MAKER4 = oUSAGE_INFO_REG.MAKER4;
            oEDI_ACCOUNT.MAKER5 = oUSAGE_INFO_REG.MAKER5;
            oEDI_ACCOUNT.MAKER6 = oUSAGE_INFO_REG.MAKER6;
            oEDI_ACCOUNT.MAKER7 = oUSAGE_INFO_REG.MAKER7;
            oEDI_ACCOUNT.MAKER8 = oUSAGE_INFO_REG.MAKER8;
            oEDI_ACCOUNT.MAKER9 = oUSAGE_INFO_REG.MAKER9;
            oEDI_ACCOUNT.MAKER10 = oUSAGE_INFO_REG.MAKER10;
            oEDI_ACCOUNT.ADM_USER_ID = oUSAGE_INFO_REG.ADM_USER_ID;
            oEDI_ACCOUNT.ADM_PASSWORD = oUSAGE_INFO_REG.ADM_PASSWORD;
            oEDI_ACCOUNT.ADM_PASSWORD_HASHED = Crypto.HashPassword(oEDI_ACCOUNT.ADM_PASSWORD);
            oEDI_ACCOUNT.ATDL_USER_ID = oUSAGE_INFO_REG.ATDL_USER_ID;
            oEDI_ACCOUNT.ATDL_PASSWORD = oUSAGE_INFO_REG.ATDL_PASSWORD;
            oEDI_ACCOUNT.ATDL_PASSWORD_HASHED = Crypto.HashPassword(oEDI_ACCOUNT.ATDL_PASSWORD);
            oEDI_ACCOUNT.SSHGW_USER_ID = oUSAGE_INFO_REG.SSHGW_USER_ID;
            oEDI_ACCOUNT.SSHGW_PUBLIC_KEY = oUSAGE_INFO_REG.SSHGW_PUBLIC_KEY;
            oEDI_ACCOUNT.CREATED_AT = oUSAGE_INFO_REG.UPDATED_BY;
            oEDI_ACCOUNT.UPDATED_AT = oUSAGE_INFO_REG.UPDATED_AT;
            oEDI_ACCOUNT.UPDATED_AT_RAW = oUSAGE_INFO_REG.UPDATED_AT_RAW;
            oEDI_ACCOUNT.UPDATED_BY = oUSAGE_INFO_REG.UPDATED_BY;

            return oEDI_ACCOUNT;
        }
        #endregion
    }
}