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
    public class ControllerUsageApplicationList
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
        public ControllerUsageApplicationList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerUsageApplicationList(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region getRequestDetailList
        public MetaResponse getRequestDetailList(String COMPANY_NO_BOX, String COMPANY_NAME, String CLOSE_FLAG, String GD, String REQUEST_STATUS, String REQ_DATE_FROM, String REQ_DATE_TO, String QUOTATION_DATE_FROM, String QUOTATION_DATE_TO, String ORDER_DATE_FROM, String ORDER_DATE_TO, String SYSTEM_SETTING_STATUS, int OFFSET, int LIMIT)
        {
            try
            {
                string strMessage = "";
                int TOTAL = 0;
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dt = DAL_REQUEST_DETAIL.GetRequestDetailList(COMPANY_NO_BOX, COMPANY_NAME, CLOSE_FLAG, GD, REQUEST_STATUS, REQ_DATE_FROM, REQ_DATE_TO, QUOTATION_DATE_FROM, QUOTATION_DATE_TO, ORDER_DATE_FROM, ORDER_DATE_TO, SYSTEM_SETTING_STATUS, OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "UsageApplicatioList");
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

        #region GetSubProgramLists
        public MetaResponse GetSubProgramLists()
        {
            try
            {
                string msg = "";
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dt = DAL_REQUEST_DETAIL.GetSubProgramLists(out msg);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Usage Application : Sub Program Lists");
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

        #region UpdateRequestDetail
        public MetaResponse UpdateRequestDetail(string list)
        {
            try
            {
                DataTable dgvList = Utility.Utility_Component.JsonToDt(list);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    oREQUEST_DETAIL = Cast_REQUEST_DETAIL(dgvList.Rows[i]);
                    BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
                    oREQUEST_ID = Cast_REQUEST_ID(dgvList.Rows[i]);

                    switch (dgvList.Rows[i]["MK"].ToString())
                    {
                        case "M":
                            HandleModify(oREQUEST_DETAIL, oREQUEST_ID, dgvList.Rows[i]);
                            break;
                        default:
                            break;
                    }
                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "Application List Update"); ;
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

        #region HandleModify
        private void HandleModify(BOL_REQUEST_DETAIL oREQUEST_DETAIL, BOL_REQUEST_ID oREQUEST_ID, DataRow row)
        {
            string msg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                #region UPDATE REQUEST_DETSIL
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                if (!DAL_REQUEST_DETAIL.IsAlreadyUpdated(oREQUEST_DETAIL, out msg)) // If updated_at is not already modified
                {
                    //insert the record
                    DAL_REQUEST_DETAIL.UpdateUsageApplication(oREQUEST_DETAIL, CURRENT_DATETIME, CURRENT_USER, out msg);

                    if (!string.IsNullOrEmpty(msg))
                    {
                        dbTxn.Dispose();
                        ResponseUtility.ReturnFailMessage(row);
                        return;
                    }
                }
                else
                {
                    dbTxn.Dispose();
                    ResponseUtility.ReturnFailMessage(row);
                    return;
                }
                #endregion

                #region UPDATE REQUEST_ID
                REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);
             
                if (!DAL_REQUEST_ID.IsAlreadyUpdated(oREQUEST_ID, out msg)) // If updated_at is not already modified
                {
                    //insert the record
                    DAL_REQUEST_ID.UpdateUsageApplication(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out msg);
                }
                else
                {
                    dbTxn.Dispose();
                    ResponseUtility.ReturnFailMessage(row);
                    return;
                }

                //return message and MK value
                if (String.IsNullOrEmpty(msg)) //success
                {
                    dbTxn.Complete();
                    ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                }
                else //failed
                {
                    dbTxn.Dispose();
                    ResponseUtility.ReturnFailMessage(row);
                }
                #endregion
            }
        }
        #endregion
        
        #region UpdateApplicationCancel
        public MetaResponse UpdateApplicationCancel(string list)
        {
            try
            {
                string msg = "";
                DataTable dgvList = Utility.Utility_Component.JsonToDt(list);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    oREQUEST_DETAIL = Cast_REQUEST_DETAIL(dgvList.Rows[i]);

                    REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);

                    //already setting
                    if (oREQUEST_DETAIL.SYSTEM_SETTING_STATUS != 0)
                    {
                        ResponseUtility.ReturnFailMessage(dgvList.Rows[i], Messages.Jimugo.E000WB011);
                    }
                    else
                    {
                        if (!DAL_REQUEST_DETAIL.IsAlreadyUpdated(oREQUEST_DETAIL, out msg)) // If updated_at is not already modified
                        {
                            //insert the record
                            DAL_REQUEST_DETAIL.ApplicationCancelUpdate(oREQUEST_DETAIL, CURRENT_DATETIME, CURRENT_USER, out msg);

                            //return message and MK value
                            if (String.IsNullOrEmpty(msg)) //success
                            {
                                ResponseUtility.ReturnSuccessMessage(dgvList.Rows[i], UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER, string.Format(Utility.Messages.Jimugo.I000ZZ016, "申請取消"));
                            }
                            else //failed
                            {
                                ResponseUtility.ReturnFailMessage(dgvList.Rows[i]);
                            }
                        }
                        else
                        {
                            ResponseUtility.ReturnFailMessage(dgvList.Rows[i]);
                        }

                        
                    }
                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "Application Cancel "); ;
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

        #region GDConfirmationRequest
        public MetaResponse GDConfirmRequest(string list)
        {
            try
            {
                string msg = "";
                DataTable dgvList = Utility.Utility_Component.JsonToDt(list);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();

                    //cast into objects
                    oREQUEST_ID = Cast_REQUEST_ID(dgvList.Rows[i]);
                    oREQUEST_DETAIL = Cast_REQUEST_DETAIL(dgvList.Rows[i]);

                    //send mail
                    bool mailSuccess = PrepareAndSendMail(oREQUEST_DETAIL, true, null);

                    if (mailSuccess)
                    {
                        REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);
                        if (!DAL_REQUEST_ID.IsAlreadyUpdated(oREQUEST_ID, out msg))
                        {
                            //set GD to 1
                            oREQUEST_ID.GD = 1;

                            //insert the record
                            DAL_REQUEST_ID.GDConfirmationRequestUpdate(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out msg);

                            //return message and MK value
                            if (String.IsNullOrEmpty(msg)) //success
                            {
                                ResponseUtility.ReturnSuccessMessage(dgvList.Rows[i], UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER, string.Format(Utility.Messages.Jimugo.I000ZZ016, "GD確認依頼"));
                            }
                            else //failed
                            {
                                ResponseUtility.ReturnFailMessage(dgvList.Rows[i]);
                            }
                        }
                    }
                    else
                    {
                        ResponseUtility.MailSendingFail(dgvList.Rows[i]);
                    }

                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "GD Confirm Request"); ;
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

        #region GDConfirmaitionComplete
        public MetaResponse GDConfirmComplete(string list)
        {
            try
            {
                string msg = "";
                DataTable dgvList = Utility.Utility_Component.JsonToDt(list);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    //cast into objects
                    BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                    BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
                    oREQUEST_DETAIL = Cast_REQUEST_DETAIL(dgvList.Rows[i]);
                    oREQUEST_ID = Cast_REQUEST_ID(dgvList.Rows[i]);

                    //get GD code By COMPANY NO BOX
                    REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);
                    string GD_CODE = DAL_REQUEST_ID.GetGDCode(oREQUEST_ID.COMPANY_NO_BOX.ToString(), out msg);

                    if (string.IsNullOrEmpty(msg))
                    {
                        #region Send Mail
                        bool mailSuccess = PrepareAndSendMail(oREQUEST_DETAIL, false, GD_CODE);

                        if (mailSuccess) //success
                        {
                            ResponseUtility.ReturnSuccessMessage(dgvList.Rows[i], UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER, string.Format(Utility.Messages.Jimugo.I000ZZ016, "GD確認完了"));
                        }
                        else //failed
                        {
                            ResponseUtility.MailSendingFail(dgvList.Rows[i]);
                        }
                        #endregion
                    }
                    else
                    {
                        ResponseUtility.ReturnFailMessage(dgvList.Rows[i]);
                    }

                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "GD Confirmation Complete"); ;
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

        #region CastToBOL_REQUEST_DETAIL
        private BOL_REQUEST_DETAIL Cast_REQUEST_DETAIL(DataRow row)
        {
            BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();

            oREQUEST_DETAIL.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
            oREQUEST_DETAIL.REQ_SEQ = Utility_Component.dtColumnToInt(row["REQ_SEQ"].ToString());
            oREQUEST_DETAIL.COMPANY_NAME = row["COMPANY_NAME"].ToString();
            oREQUEST_DETAIL.CLOSE_FLG = row["CLOSE_FLG"].ToString();

            string str_REQ_TYPE = row["REQ_TYPE"].ToString();
            switch (str_REQ_TYPE)
            {
                case "新規":
                    oREQUEST_DETAIL.REQ_TYPE = 1;
                    break;
                case "変更":
                    oREQUEST_DETAIL.REQ_TYPE = 2;
                    break;
                case "解約":
                    oREQUEST_DETAIL.REQ_TYPE = 9;
                    break;
                default:
                    break;
            }
            
            string str_REQ_STATUS = row["REQ_STATUS"].ToString();
            switch (str_REQ_STATUS)
            {
                case "仮登録(保存":
                    oREQUEST_DETAIL.REQ_STATUS = 0;
                    break;
                case "申請中":
                    oREQUEST_DETAIL.REQ_STATUS = 1;
                    break;
                case "承認済":
                    oREQUEST_DETAIL.REQ_STATUS = 2;
                    break;
                case "否認":
                    oREQUEST_DETAIL.REQ_STATUS = 3;
                    break;
                case "申請取消":
                    oREQUEST_DETAIL.REQ_STATUS = 9;
                    break;
                default:
                    break;
            }
        
            oREQUEST_DETAIL.REQ_DATE = Utility_Component.dtColumnToDateTime(row["REQ_DATE"].ToString());
            oREQUEST_DETAIL.QUOTATION_DATE = Utility_Component.dtColumnToDateTime(row["QUOTATION_DATE"].ToString());
            oREQUEST_DETAIL.ORDER_DATE = Utility_Component.dtColumnToDateTime(row["ORDER_DATE"].ToString());
            oREQUEST_DETAIL.SYSTEM_EFFECTIVE_DATE = Utility_Component.dtColumnToDateTime(row["SYSTEM_EFFECTIVE_DATE"].ToString());

            string str_system_status = row["SYSTEM_SETTING_STATUS"].ToString();
            if (str_system_status == "依頼中")
            {
                oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 1;
            }else if (str_system_status == "設定済み")
            {
                oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 2;
            }
            else
            {
                oREQUEST_DETAIL.SYSTEM_SETTING_STATUS = 0;
            }
            oREQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE = Utility_Component.dtColumnToDateTime(row["COMPLETION_NOTIFICATION_DATE"].ToString());
            oREQUEST_DETAIL.NML_CODE_NISSAN = row["NML_CODE_NISSAN"].ToString();
            oREQUEST_DETAIL.NML_CODE_NS = row["NML_CODE_NS"].ToString();
            oREQUEST_DETAIL.NML_CODE_JATCO = row["NML_CODE_JATCO"].ToString();
            oREQUEST_DETAIL.NML_CODE_AK = row["NML_CODE_AK"].ToString();    
            oREQUEST_DETAIL.NML_CODE_NK = row["NML_CODE_NK"].ToString();
            oREQUEST_DETAIL.UPDATED_AT = row["UPDATED_AT"].ToString();
            oREQUEST_DETAIL.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString();

            return oREQUEST_DETAIL;
        }
        #endregion

        #region CastToBOL_REQUEST_ID
        private BOL_REQUEST_ID Cast_REQUEST_ID(DataRow row)
        {
            BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
            oREQUEST_ID.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
            string gd = row["GD"].ToString();
            switch (gd)
            {
                case "未確認":
                    oREQUEST_ID.GD = 0;
                    break;
                case "確認依頼中":
                    oREQUEST_ID.GD = 1;
                    break;
                case "確認済み":
                    oREQUEST_ID.GD = 2;
                    break;
                case "無し":
                    oREQUEST_ID.GD = 9;
                    break;
                
            }
            oREQUEST_ID.DISABLED_FLG = row["DISABLED_FLG"].ToString();
            oREQUEST_ID.UPDATED_AT = row["REQUEST_ID_UPDATED_AT"].ToString();
            oREQUEST_ID.UPDATED_AT_RAW = row["REQUEST_ID_UPDATED_AT"].ToString();
            return oREQUEST_ID;
        }
        #endregion

        #region PrepareAndSendMail
        private bool PrepareAndSendMail(BOL_REQUEST_DETAIL oREQUEST_DETAIL, bool REQUEST, string GD_CODE)
        {
            //prepare for mail parameters
            BOL_CONFIG config = new BOL_CONFIG("CTS020", con);
            string toAddress = REQUEST ? config.getStringValue("emailAddress.to.gdCheckReq") : config.getStringValue("emailAddress.to.gdChecked");
            string ccAddress = config.getStringValue("emailAddress.cc");
            string template_base_name = REQUEST ? "CTS020_GdCheckReq" : "CTS020_GdChecked";
            string subject = REQUEST ? config.getStringValue("emailSubject.gdCheckReq") : config.getStringValue("emailSubject.gdChecked");
            subject = subject.Replace("${companyName}", oREQUEST_DETAIL.COMPANY_NAME);
            Dictionary<string, string> map;

            //prepare for mail mapping
            if (REQUEST)
            {
                map = new Dictionary<string, string>() {
                        { "${nmlCodeNissan}", oREQUEST_DETAIL.NML_CODE_NISSAN },
                        { "${nmlCodeNs}", oREQUEST_DETAIL.NML_CODE_NS },
                        { "${nmlCodeJatco}", oREQUEST_DETAIL.NML_CODE_JATCO},
                        { "${nmlCodeAk}", oREQUEST_DETAIL.NML_CODE_AK},
                        { "${nmlCodeNk}", oREQUEST_DETAIL.NML_CODE_NK},
                        { "${companyNoBox}", oREQUEST_DETAIL.COMPANY_NO_BOX},
                        { "${companyName}", oREQUEST_DETAIL.COMPANY_NAME },
                        { "${userId}", CURRENT_USER }
                    };
            }
            else
            {
                map = new Dictionary<string, string>() {
                        { "${nmlCodeNissan}", oREQUEST_DETAIL.NML_CODE_NISSAN },
                        { "${nmlCodeNs}", oREQUEST_DETAIL.NML_CODE_NS },
                        { "${nmlCodeJatco}", oREQUEST_DETAIL.NML_CODE_JATCO},
                        { "${nmlCodeAk}", oREQUEST_DETAIL.NML_CODE_AK},
                        { "${nmlCodeNk}", oREQUEST_DETAIL.NML_CODE_NK},
                        { "${companyNoBox}", oREQUEST_DETAIL.COMPANY_NO_BOX},
                        { "${companyName}", oREQUEST_DETAIL.COMPANY_NAME },
                        { "${gdCode}", GD_CODE },
                        { "${userId}", CURRENT_USER }
                    };
            }
            

            //read email template
            string file_path = HttpContext.Current.Server.MapPath("~/Templates/Mail/" + template_base_name + ".txt");
            string body = System.IO.File.ReadAllText(file_path);

            //send mail
            return Utility.Mail.sendMail(toAddress, ccAddress, subject, body, map);
        }
        #endregion
    }
}