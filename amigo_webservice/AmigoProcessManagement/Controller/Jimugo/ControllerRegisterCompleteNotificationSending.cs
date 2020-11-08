using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Transactions;
using System.Web;
using Ionic.Zip;
using ZipFile = Ionic.Zip.ZipFile;
using DAL_AmigoProcess.BOL;
using System.Diagnostics;

namespace AmigoProcessManagement.Controller
{
    public class ControllerRegisterCompleteNotificationSending
    {
        #region Declare
        private string Login_ID;
        string COMPANY_NO_BOX;
        string REQ_SEQ;
        string QUOTATION_DATE;
        string ORDER_DATE;
        string COMPLETION_NOTIFICATION_DATE;
        string COMPANY_NAME;
        string EMAIL_ADDRESS;
        string DOWNLOAD_LINK;
        string FILENAME;
        Stopwatch timer;
        //string EDI_ACCOUNT;
        int status ;

        string MARK1, CONTRACT_PLAN, BOX_SIZE, PLAN_AMIGO_CAI, PLAN_AMIGO_BIZ, OP_FLAT, CONTRACT_CSP, OP_CLIENT, OP_BASIC_SEVICE;
        string SFTP, HTTPS, JNX_URL, IPSEC, TP, AMIGO_COMPANY_NAME, INTERNET_URL, EDI_ACCOUNT, ADM_USER_ID, ADM_PASSWORD, ATDL_USER_ID, ATDL_USER_PASSWORD;
        string SSHGW_USER_ID, SSHGW_PUBLIC_KEY, CAI_SERVER_IP_ADDRESS, SSH_USER, PRIVATE_KEY, AMIGO_IP, PASSWORD, CLIENT_CERTIFICATE_NO, SUPPORT_NAME, SUPPORT_MAIL_ADDRESS, SUPPORT_PHONE_NUMBER;


        MetaResponse response;
        REQUEST_ID DAL_REQUEST_ID;
        REQUEST_DETAIL DAL_REQUEST_DETAIL;
        REPORT_HISTORY DAL_REPORT_HISTORY;
        CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE;
        REQ_ADDRESS DAL_REQ_ADDRESS;
        string con = Properties.Settings.Default.MyConnection;
        #endregion

        #region Constructor
        public ControllerRegisterCompleteNotificationSending()
        {
            response = new MetaResponse();
            DAL_REQUEST_ID = new REQUEST_ID(con);
            DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            DAL_REPORT_HISTORY = new REPORT_HISTORY(con);
            DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);
            DAL_REQ_ADDRESS = new REQ_ADDRESS(con);
            timer = new Stopwatch();
            timer.Start();

        }
        #endregion

        #region GetRegisterCompleteNotificationList
        public MetaResponse Search(string COMPANY_NO_BOX)
        {
            try
            {
                string strMessage = "";
                DataTable dt = DAL_REQUEST_ID.GetScreenData(COMPANY_NO_BOX, out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "RegisterCompleteNotification List");
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

        #region PreviewFunction
        public MetaResponse NotiSendingPreview(string COMPANY_NAME,string COMPANY_NO_BOX, string REQ_SEQ,string EDI_ACCOUNT, string authHeader)
        {
            try
            {
                Login_ID = Utility_Component.DecodeAuthHeader(authHeader)[0] == null ? null : Utility_Component.DecodeAuthHeader(authHeader)[0];

                //int status;
                //message for pop up
                DataTable messagecode = new DataTable();
                messagecode.Columns.Add("Message");
                DataRow dr = messagecode.NewRow();

                string strMessage = "";
                //get config object for CTS060
                BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
                string FY = config.getStringValue("client.certificate.FY");

                int clientCertificateDiff = DAL_REQUEST_DETAIL.GetClientCertificateDiff(COMPANY_NO_BOX, REQ_SEQ, FY, out strMessage);
                status = 1;
                for(int i=0; clientCertificateDiff > i; i++)
                {
                    if (clientCertificateDiff != 0)
                    {
                        #region SearchClientCertificateNo
                        string clientCertificateNo = DAL_CLIENT_CERTIFICATE.GetClientCertificateNo(FY, out strMessage);
                        if (clientCertificateNo != null) 
                        {
                            #region UpdateWithClientCertificateNo
                            status = UpdateWithClientCertificateNO(clientCertificateNo, COMPANY_NO_BOX, Login_ID, strMessage);
                            #endregion
                        }
                        else
                        {
                            response.Status = 0;
                            response.Message = Utility.Messages.Jimugo.E000WB004;
                            dr["Message"] = Utility.Messages.Jimugo.E000WB004;
                            messagecode.Rows.Add(dr);
                            response.Data = Utility_Component.DtToJSon(messagecode, "Message");
                            return response;
                        }
                        #endregion
                    }
                    else
                    {
                        status = 1;
                    }
                }

                if (status == 1) 
                {
                    #region GetPDFData

                    DataTable dtPDFData = DAL_REQUEST_DETAIL.GetPDFData(COMPANY_NO_BOX, REQ_SEQ, out strMessage);

                    DataTable dtPDFData1 = DAL_REQ_ADDRESS.GetPDFData1(COMPANY_NO_BOX, REQ_SEQ, out strMessage);

                    DataTable dtPDFData2 = DAL_REQ_ADDRESS.GetPDFData2(COMPANY_NO_BOX, REQ_SEQ, out strMessage);

                    string req_seq = REQ_SEQ.Length != 1 ? REQ_SEQ : "0" + REQ_SEQ;

                    string saveFileName = COMPANY_NO_BOX + "-" + "3" + "-" + req_seq + "_完了通知書(" + EDI_ACCOUNT.Replace("@","") + ")_" + COMPANY_NAME + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                    response = getPDF(COMPANY_NO_BOX,COMPANY_NAME, dtPDFData, dtPDFData1, dtPDFData2, saveFileName);

                    #endregion
                }
                else
                {
                    response.Status = 0;
                    response.Message = Utility.Messages.Jimugo.I000WB001;
                    dr["Message"] = Utility.Messages.Jimugo.I000WB001;
                    messagecode.Rows.Add(dr);
                    response.Data = Utility_Component.DtToJSon(messagecode, "Message");
                    return response;
                }

                return response; //process 3 successful

            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }

        #endregion

        #region ModifyWithClientCertificateNo
        private int UpdateWithClientCertificateNO(string CLIENT_CERTIFICATE_NO, string COMPANY_NO_BOX, string LoginID,string strMsg)
        {
            int status;
            //string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                DAL_CLIENT_CERTIFICATE.UpdateWithClientCertificateNO(CLIENT_CERTIFICATE_NO, COMPANY_NO_BOX, LoginID, out strMsg);
                dbTxn.Complete();
                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {   
                    status = 1;
                    response.Message = Utility.Messages.Jimugo.I000WB001;
                }
                else //failed
                {
                    status = 0;
                    response.Message = Utility.Messages.Jimugo.E000WB005;
                }
            }
            return status;
        }
        #endregion

        #region SendMailCreate
        public MetaResponse SendMailCreate(string list, string authHeader )  //add more parameter
        {
            #region Parameters
            //message for pop up
            DataTable messagecode = new DataTable();
            messagecode.Columns.Add("Error Message");
            DataRow dr = messagecode.NewRow();

            DataTable dtParameter = Utility.Utility_Component.JsonToDt(list);

            COMPANY_NO_BOX = dtParameter.Rows[0]["COMPANY_NO_BOX"].ToString();
            REQ_SEQ = dtParameter.Rows[0]["REQ_SEQ"].ToString();
            QUOTATION_DATE = dtParameter.Rows[0]["QUOTATION_DATE"].ToString();
            ORDER_DATE = dtParameter.Rows[0]["ORDER_DATE"].ToString();
            COMPLETION_NOTIFICATION_DATE = dtParameter.Rows[0]["COMPLETION_NOTIFICATION_DATE"].ToString();
            COMPANY_NAME = dtParameter.Rows[0]["COMPANY_NAME"].ToString();
            EMAIL_ADDRESS = dtParameter.Rows[0]["EMAIL_ADDRESS"].ToString();
            EDI_ACCOUNT = dtParameter.Rows[0]["EDI_ACCOUNT"].ToString();
            FILENAME = dtParameter.Rows[0]["DOWNLOAD_LINK"].ToString();
            #endregion
            string msg = "";


            Login_ID = Utility_Component.DecodeAuthHeader(authHeader)[0] == null ? null : Utility_Component.DecodeAuthHeader(authHeader)[0];

            try
            {
                using (TransactionScope dbtnx = new TransactionScope())
                {
                    DateTime dtNow = DateTime.Now;
                    string conmletion_noti_date = dtNow.ToString("yyyy/MM/dd");
                    string update_at = dtNow.ToString("yyyyMMddHHmmss");

                    #region Update RequestDetail For CompleteNotificationSending
                    DAL_REQUEST_DETAIL.SendMailUpdate(COMPLETION_NOTIFICATION_DATE, COMPANY_NO_BOX, REQ_SEQ, update_at, Login_ID, out msg);
                    #endregion

                    if (String.IsNullOrEmpty(msg))
                    {
                        #region InsertReportHistroy
                        DateTime now = DateTime.Now;
                        string output_at = dtNow.ToString("yyyy/MM/dd HH:mm");
                        string date = now.ToString("yyyyMMddHHmmss");

                        string req_seq = REQ_SEQ.Length != 1 ? REQ_SEQ : "0" + REQ_SEQ;

                        string outputFile = COMPANY_NO_BOX + "-" + "3" + "-" + req_seq + "_完了通知書(" + EDI_ACCOUNT.Replace("@", "") + ")_" + COMPANY_NAME + ".pdf";
                        string msgText = outputFile;

                        int REPORTHISTORY_SEQ = DAL_REPORT_HISTORY.GetReportHistorySEQ(COMPANY_NO_BOX, 5, out msg);

                        if (string.IsNullOrEmpty(msg))
                        {
                            DAL_REPORT_HISTORY.InsertNotiSending(COMPANY_NO_BOX, REQ_SEQ, REPORTHISTORY_SEQ, outputFile, EMAIL_ADDRESS, Login_ID, output_at, date, out msg);

                            if (string.IsNullOrEmpty(msg))
                            {

                                BOL_CONFIG config = new BOL_CONFIG("CTS060", con);
                                BOL_CONFIG config1 = new BOL_CONFIG("SYSTEM", con);

                                string temPath = config1.getStringValue("temp.dir");
                                temPath = HttpContext.Current.Server.MapPath("/" + temPath + "/" + FILENAME);

                                string pdfSavePath = config.getStringValue("fileSavePath.completionNotice");
                                pdfSavePath = HttpContext.Current.Server.MapPath("~/" + pdfSavePath + "/" + outputFile);

                                //CopyAndMove File
                                int res = MovePdfFile(temPath, pdfSavePath);

                                if (res == 1)
                                {
                                    //BOL_CONFIG config1 = new BOL_CONFIG("SYSTEM", con);
                                    string zipStorageFolder = "/" + config1.getStringValue("temp.dir") + "/" + outputFile.Replace(".pdf", ".zip");

                                    string PASSWORD = config.getStringValue("password.Attachment");

                                    //Create ZipFile With Password
                                    string zipDownloadLink = ZipGenerator(temPath, PASSWORD, zipStorageFolder);

                                    if (zipDownloadLink != null)
                                    {
                                        #region SendMail
                                        String emailAddressCC = config.getStringValue("emailAddress.cc");
                                        string tempString = PrepareAndSendMail(COMPANY_NAME, PASSWORD);

                                        if (tempString != null)
                                        {
                                            string subjectString = config.getStringValue("emailSubject.notice");
                                            DataTable result = new DataTable();
                                            result.Clear();
                                            result.Columns.Add("ZipDownloadLink");
                                            result.Columns.Add("EmailAddressCC");
                                            result.Columns.Add("TemplateString");
                                            result.Columns.Add("SubjectString");

                                            DataRow dtRow = result.NewRow();
                                            dtRow["ZipDownloadLink"] = zipDownloadLink;
                                            dtRow["EmailAddressCC"] = emailAddressCC;
                                            dtRow["TemplateString"] = tempString;
                                            dtRow["SubjectString"] = subjectString.Replace("${companyName}", COMPANY_NAME);

                                            result.Rows.Add(dtRow);
                                            dbtnx.Complete();
                                            response.Data = Utility.Utility_Component.DtToJSon(result, "pdfData");
                                            response.Status = 1;
                                            return response;
                                        }
                                        else
                                        {
                                            return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB018);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB007);
                                    }
                                }
                                else
                                {
                                    return ResponseUtility.ReturnFailMessage(response, timer, messagecode, String.Format(Utility.Messages.Jimugo.E000WB001, msgText));
                                }

                            }
                            else
                            {
                                return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB003);
                            }
                        }
                        else
                        {
                            return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB002);
                        }
                        
                        #endregion
                    }
                    else
                    {
                        return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB002);
                    }

                    //return response;
                }
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region PDF Create
        public MetaResponse getPDF(string COMPANY_NO_BOX, String COMPANY_NAME,DataTable dt,DataTable dt1,DataTable dt2, String fileName)
        {
            #region Declare
            int i = 10;
            string fullName;
            string emailAddress;
            string phoneNo;

            #endregion

            BOL_CONFIG conf= new BOL_CONFIG("CTS060", con);
            String templateStorageFolder = conf.getStringValue("template.Path.CompletionNotification");
           
            string file_path = HttpContext.Current.Server.MapPath( "~/"+templateStorageFolder + "/CompletionNotice_Template.xlsx");
            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            Worksheet sheet = workbook.Worksheets[0];

                MARK1 = dt.Rows[0]["MAKER1"].ToString();
                CONTRACT_PLAN = dt.Rows[0]["CONTRACT_PLAN"].ToString();
                BOX_SIZE = dt.Rows[0]["BOX_SIZE"].ToString();
                PLAN_AMIGO_CAI = dt.Rows[0]["PLAN_AMIGO_CAI"].ToString();
                PLAN_AMIGO_BIZ = dt.Rows[0]["PLAN_AMIGO_BIZ"].ToString();
                OP_FLAT = dt.Rows[0]["OP_FLAT"].ToString();
                CONTRACT_CSP = dt.Rows[0]["CONTRACT_CSP"].ToString();
                OP_CLIENT = dt.Rows[0]["OP_CLIENT"].ToString();
                OP_BASIC_SEVICE = dt.Rows[0]["OP_SERVICE"].ToString();
                SFTP = dt.Rows[0]["A"].ToString();
                HTTPS = dt.Rows[0]["B"].ToString();
                JNX_URL = dt.Rows[0]["C"].ToString();
                IPSEC = dt.Rows[0]["D"].ToString();
                TP = dt.Rows[0]["E"].ToString();
                AMIGO_COMPANY_NAME = dt.Rows[0]["F"].ToString();
                INTERNET_URL = dt.Rows[0]["G"].ToString();
                EDI_ACCOUNT = dt.Rows[0]["EDI_ACCOUNT"].ToString();
                ADM_USER_ID = dt.Rows[0]["ADM_USER_ID"].ToString();
                ADM_PASSWORD = dt.Rows[0]["ADM_PASSWORD"].ToString();
                ATDL_USER_ID = dt.Rows[0]["ATDL_USER_ID"].ToString();
                ATDL_USER_PASSWORD = dt.Rows[0]["ATDL_PASSWORD"].ToString();
                SSHGW_USER_ID = dt.Rows[0]["SSHGW_USER_ID"].ToString();
                SSHGW_PUBLIC_KEY = dt.Rows[0]["SSHGW_PUBLIC_KEY"].ToString();
                CAI_SERVER_IP_ADDRESS = dt.Rows[0]["CAI_SERVER_IP_ADDRESS"].ToString();
                SSH_USER = dt.Rows[0]["K"].ToString();
                PRIVATE_KEY = dt.Rows[0]["L"].ToString();
                AMIGO_IP = dt.Rows[0]["NETWORK"].ToString();
                PASSWORD = dt.Rows[0]["PASSWORD"].ToString();
                CLIENT_CERTIFICATE_NO = dt.Rows[0]["CLIENT_CERTIFICATE_NO"].ToString();
                SUPPORT_NAME = dt.Rows[0]["H"].ToString();
                SUPPORT_MAIL_ADDRESS = dt.Rows[0]["I"].ToString();
                SUPPORT_PHONE_NUMBER = dt.Rows[0]["J"].ToString();

            sheet.Range["F3"].Text = COMPANY_NAME;
            sheet.Range["F4"].Text = CONTRACT_PLAN;
            sheet.Range["B7"].Text = BOX_SIZE;
            sheet.Range["E7"].Text = PLAN_AMIGO_CAI;
            sheet.Range["H7"].Text = PLAN_AMIGO_BIZ;
            sheet.Range["K7"].Text = OP_FLAT;
            sheet.Range["N7"].Text = CONTRACT_CSP;
            sheet.Range["Q7"].Text = OP_CLIENT;
            sheet.Range["T7"].Text = OP_BASIC_SEVICE;

            int totalRows = dt1.Rows.Count;
            int extraRows = totalRows - 10 < 0 ? 0 : totalRows - 10;

            //int extraRows = 5;
            if (extraRows > 0)
            {
                int firstColumn = 2;
                int lastColumn = 24;
                int firstRow = 11;
                int lastRow = 11 + extraRows;
                //rows count
                int copyRows = lastRow - firstRow;

                //insert rows count
                sheet.InsertRow(lastRow + 1, copyRows);
                CellRange originDataRang = sheet.Range[firstRow, firstColumn, lastRow, lastColumn];
                CellRange targetDataRang = sheet.Range[lastRow + 1, firstColumn, lastRow + 1, lastColumn];
                sheet.Copy(originDataRang, targetDataRang, true);

            }
            //int extraRows = 5;

            #region ClientCertificateNo Add
            string[] clientCertificate = CLIENT_CERTIFICATE_NO.Split(',');
            int extraRowCount;
            if ( (clientCertificate.Length) %2 == 0)
            {
                extraRowCount = (clientCertificate.Length / 2) - 1;
            }
            else
            {
                extraRowCount = (clientCertificate.Length / 2) ;
            }

            if (extraRowCount > 0)
            {
                int firstColumn = 7;
                int lastColumn = 24;
                int firstRow = 52 + extraRows;
                int lastRow = 52 + extraRows + extraRowCount;
                //rows count
                int copyRows = lastRow - firstRow;

                //insert rows count
                sheet.InsertRow(lastRow + 1, copyRows);
                CellRange originDataRang = sheet.Range[firstRow, firstColumn, lastRow, lastColumn];
                CellRange targetDataRang = sheet.Range[lastRow + 1, firstColumn, lastRow + 1, lastColumn];
                sheet.Copy(originDataRang, targetDataRang, true);
            }


            int b = 0;
            for (int x = 0; x < (extraRowCount+1) ; x++)
            {
                string certificates = "";
                for ( int a=0 ; a < 2; a++)
                {
                    try
                    {
                        certificates += clientCertificate[b] + ", ";
                        b++;
                    }
                    catch (Exception)
                    {

                    }
                }
                //b += 2;
                sheet.Range["G" + (53 + extraRows + x)].Text = certificates;
            }
            #endregion

            foreach (DataRow row in dt1.Rows)
            {
                fullName = "B" + i;
                emailAddress = "F" + i;
                phoneNo = "U" + i;
                sheet.Range["U" + i + ":" + "X" + i].Merge();
                sheet.Range[fullName].Text = row["SERVICE_CONTACT_NAME"].ToString();
                sheet.Range[emailAddress].Text = row["SERVICE_MAIL_ADDRESS"].ToString();
                sheet.Range[phoneNo].Text = row["SERVICE_PHONE_NUMBER"].ToString();
                i++;
            }

            sheet.Range["G"+(33+extraRows)].Text = COMPANY_NO_BOX == null ? "" : COMPANY_NO_BOX; //need to change
            sheet.Range["G"+(34+extraRows )].Text = EDI_ACCOUNT;
            sheet.Range["I"+(35 + extraRows)].Text = ADM_USER_ID;
            sheet.Range["R"+(35+extraRows)].Text = ADM_PASSWORD;
            sheet.Range["I"+(36 + extraRows)].Text = ATDL_USER_ID;
            sheet.Range["R"+(36 + extraRows)].Text = ATDL_USER_PASSWORD;

            sheet.Range["G"+(39 + extraRows)].Text = SSHGW_USER_ID;
            sheet.Range["G"+(40 + extraRows)].Text = SSHGW_PUBLIC_KEY;
            sheet.Range["G"+(41 + extraRows)].Text = CAI_SERVER_IP_ADDRESS;

            int z = 42 + extraRows;
            foreach (DataRow row in dt2.Rows)
            {
                sheet.Range["G"+z].Text = row["ERROR_MAIL_ADDRESS"].ToString();
                z++;
            }

            sheet.Range["G"+(47 + extraRows)].Text = SSH_USER;
            sheet.Range["G"+(48 + extraRows)].Text = PRIVATE_KEY;
            sheet.Range["G"+(49 + extraRows)].Text = AMIGO_IP;

            sheet.Range["G"+(52 + extraRows)].Text = PASSWORD;
            //sheet.Range["G"+(53 + extraRows)].Text = CLIENT_CERTIFICATE_NO;

            sheet.Range["B"+(56 + extraRows+ extraRowCount)].Text = SUPPORT_NAME;
            sheet.Range["G"+(56 + extraRows+ extraRowCount)].Text = SUPPORT_MAIL_ADDRESS;
            sheet.Range["P"+(56 + extraRows+ extraRowCount)].Text = SUPPORT_PHONE_NUMBER;

            sheet.Range["I"+(22 + extraRows)].Text = SFTP;
            sheet.Range["I"+(23 + extraRows)].Text = HTTPS;
            sheet.Range["I"+(25 + extraRows)].Text = JNX_URL;
            sheet.Range["I"+(26 + extraRows)].Text = IPSEC;
            sheet.Range["I"+(27 + extraRows)].Text = TP;
            sheet.Range["I"+(28 + extraRows)].Text = AMIGO_COMPANY_NAME;
            sheet.Range["I"+(30 + extraRows)].Text = INTERNET_URL;

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = "/"+tempStorageFolder +"/"+ fileName;

            //Save excel file to pdf file.  
            string DownloadLink = HttpContext.Current.Server.MapPath("~"+savePath); 
            workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF); 

            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("MessageCode");
            DataRow dr = result.NewRow();
            dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
            dr["MessageCode"] = "I000WB001";
            result.Rows.Add(dr);

            response.Data = Utility.Utility_Component.DtToJSon(result, "pdfData");
            response.Status = 1;
            return response;

        }


        #endregion

        #region ZipCreateWithPassword
        public string ZipGenerator(string fileName,string PASSWORD,string ZIP_STORAGEFOLDER_PATH)
        {
            string result;
            try
            {
                //var files = Directory.GetFiles(@"D:\Git\Phase-2-test\amigo_webservice\AmigoProcessManagement\App_Data");

                //string something = HttpContext.Current.Server.;

                //something = something;

                string SaveFilePath = HttpContext.Current.Server.MapPath(ZIP_STORAGEFOLDER_PATH); //"~/App_Data/Ouput/output.pdf"


                using (var zip = new ZipFile())
                {
                    zip.Password = PASSWORD;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.AddFile(fileName, "");
                    zip.Save(SaveFilePath);
                }

                return result = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + ZIP_STORAGEFOLDER_PATH;
            }
            catch (Exception)
            {
                return result = null;

            }
            

        }
        #endregion

        #region MovePDFFIle
        private int MovePdfFile(string temPath, string pdfSavePath)
        {
            int status;
            try
            {
                #region CopyAndMove File
                // Create a new FileInfo object.    
                FileInfo fInfo = new FileInfo(temPath);
                //check if already exist.  
                FileInfo destinationInfo = new FileInfo(pdfSavePath);
                if (File.Exists(destinationInfo.FullName))
                {
                    destinationInfo.Delete();
                }
                fInfo.CopyTo(pdfSavePath);
                #endregion
                status = 1;
                return status;
            }
            catch (Exception)
            {
                status = 0;
                return 0;
                throw;
            }
            

        }
        #endregion

        #region PrepareAndSendMail
        private string PrepareAndSendMail(string COMPANY_NAME,string PASSWORD )
        {
            try
            {
                //get config object for CTS010
                BOL_CONFIG config = new BOL_CONFIG("CTS060", con);

                Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NAME },
                        { "${password}", PASSWORD}
                    };

                //prepare for mail header
                string template_base_name = "CTS060_CompletionNoticePW";

                //read email template
                string file_path = HttpContext.Current.Server.MapPath("~/Templates/Mail/" + template_base_name + ".txt");
                string body = System.IO.File.ReadAllText(file_path);

                string tempString = Utility.Mail.MapMailPlaceHolders(body, map);

                return tempString;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }
        #endregion

    }

}
