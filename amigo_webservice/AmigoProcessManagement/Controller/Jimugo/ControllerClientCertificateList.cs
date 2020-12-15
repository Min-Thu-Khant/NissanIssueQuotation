using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerClientCertificateList
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
        public ControllerClientCertificateList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerClientCertificateList(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }

        #endregion

        #region Get ClientCertificatList
        public MetaResponse getClientCertificateList(string FY, string COMPANY_NO_BOX, string CLIENT_CERTIFICATE_NO, string DISTRIBUTION_STATUS, int OFFSET, int LIMIT)
        {
            try
            {

                string strMessage = "";
                int TOTAL = 0;
                CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);
                DataTable dt = DAL_CLIENT_CERTIFICATE.GetClientCertrificateList(FY, COMPANY_NO_BOX, CLIENT_CERTIFICATE_NO, DISTRIBUTION_STATUS, OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "ClientCertificateList");
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

        #region UpdateClientCertificateList
        public MetaResponse UpdateClientCertificateList(string ClientCertificateList, string authHeader)
        {
            try
            {
                DataTable dgvList = Utility.Utility_Component.JsonToDt(ClientCertificateList);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE = new BOL_CLIENT_CERTIFICATE();
                    oCLIENT_CERTIFICATE = Cast_CLIENT_CERTIFICATE(dgvList.Rows[i]);

                    //assign login ID

                    switch (dgvList.Rows[i]["MK"].ToString())
                    {
                        case "I":
                            HandleInsert(oCLIENT_CERTIFICATE, "I", dgvList.Rows[i]);
                            break;
                        case "C":
                            HandleInsert(oCLIENT_CERTIFICATE, "C", dgvList.Rows[i]);
                            break;
                        case "M":
                            HandleModify(oCLIENT_CERTIFICATE, "M", dgvList.Rows[i]);
                            break;
                        case "D":
                            HandleDelete(oCLIENT_CERTIFICATE, dgvList.Rows[i]);
                            break;
                        default:
                            break;
                    }
                }

                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "CompanyCodeList Update");
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }


        }
        #endregion

        #region HandleInsert
        private void HandleInsert(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, string OPERATION, DataRow row)
        {
            string strMsg = "";
            CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);
            using (TransactionScope dbTxn = new TransactionScope())
            {
                if (!DAL_CLIENT_CERTIFICATE.PKKeyCheck(oCLIENT_CERTIFICATE, out strMsg)) // IF updated_at is not already modified
                {
                    //delete the record
                    DAL_CLIENT_CERTIFICATE.Insert(oCLIENT_CERTIFICATE, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                }
                else
                {
                    ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ028, oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
                    return;
                }

                //return message and MK value
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
        }
        #endregion

        #region HandleModify
        private void HandleModify(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, string OPERATION, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);
                //check condition
                if (!DAL_CLIENT_CERTIFICATE.IsAlreadyUpdated(oCLIENT_CERTIFICATE, out strMsg)) // IF updated_at is not already modified
                {
                    //MODIFY the record
                    DAL_CLIENT_CERTIFICATE.Update(oCLIENT_CERTIFICATE, CURRENT_DATETIME, CURRENT_USER, out strMsg);
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
                    dbTxn.Complete();
                    ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }
            }
        }
        #endregion

        #region HandleDelete
        private void HandleDelete(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);
                if (!DAL_CLIENT_CERTIFICATE.IsAlreadyUpdated(oCLIENT_CERTIFICATE, out strMsg)) // IF updated_at is not already modified
                {
                    //delete the record
                    DAL_CLIENT_CERTIFICATE.Delete(oCLIENT_CERTIFICATE, out strMsg);
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
                    response.Status = 1;
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

        #region IsRecordModified
        //private bool IsRecordModified(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, out string strMsg)
        //{
        //    //search by key and check if is same
        //    return DAL_CLIENT_CERTIFICATE.IsAlreadyUpdated(oCLIENT_CERTIFICATE, out strMsg);
        //}
        #endregion

        #region CastToBOL_CLIENT_CERTIFICATE
        private BOL_CLIENT_CERTIFICATE Cast_CLIENT_CERTIFICATE(DataRow row)
        {
            BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE = new BOL_CLIENT_CERTIFICATE();
            oCLIENT_CERTIFICATE.FY = Utility_Component.dtColumnToInt(row["FY"].ToString());
            oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO = row["CLIENT_CERTIFICATE_NO"].ToString();
            oCLIENT_CERTIFICATE.PASSWORD = row["PASSWORD"].ToString();
            oCLIENT_CERTIFICATE.EXPIRATION_DATE = Utility_Component.dtColumnToDateTime(row["EXPIRATION_DATE"].ToString());
            oCLIENT_CERTIFICATE.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
            oCLIENT_CERTIFICATE.DISTRIBUTION_DATE = Utility_Component.dtColumnToDateTime(row["DISTRIBUTION_DATE"].ToString());
            oCLIENT_CERTIFICATE.UPDATED_AT = row["UPDATED_AT"].ToString().Length >= 1 ? row["UPDATED_AT"].ToString() : null;
            oCLIENT_CERTIFICATE.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString() == "" ? null : row["UPDATED_AT_RAW"].ToString();
            oCLIENT_CERTIFICATE.UPDATED_BY = row["UPDATED_BY"].ToString().Length >= 1 ? row["UPDATED_BY"].ToString() : null;

            return oCLIENT_CERTIFICATE;
        }
        #endregion

        #region CastToBOL_REQUEST_DETAIL
        private BOL_REQUEST_DETAIL Cast_REQUEST_DETAIL(DataRow row)
        {
            BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
            oREQUEST_DETAIL.CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS = row["CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS"].ToString();
            oREQUEST_DETAIL.COMPANY_NAME = row["COMPANY_NAME"].ToString();
            return oREQUEST_DETAIL;
        }
        #endregion

        #region Send_Mail
        public MetaResponse SendMail(string ClientCertificateList)
        {
            try
            {
                string strMsg = "";
                ArrayList company_no_boxs = new ArrayList();

                DataTable dgvList = Utility.Utility_Component.JsonToDt(ClientCertificateList);

                List<string> l_SentMail = new List<string>();

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    DataRow dr = dgvList.Rows[i];
                    string l_COMPANY_NO_BOX = dr["COMPANY_NO_BOX"].ToString();
                    if (l_SentMail.Where(x => x == l_COMPANY_NO_BOX).ToList().Count <= 0 && !string.IsNullOrEmpty(dgvList.Rows[i]["DISTRIBUTION_DATE"].ToString()))
                    {
                        l_SentMail.Add(l_COMPANY_NO_BOX);

                        BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE = new BOL_CLIENT_CERTIFICATE();

                        oCLIENT_CERTIFICATE = Cast_CLIENT_CERTIFICATE(dr);  //check method
                        BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                        oREQUEST_DETAIL = Cast_REQUEST_DETAIL(dr);


                        CLIENT_CERTIFICATE DAL_CLIENT_CERTIFICATE = new CLIENT_CERTIFICATE(con);

                        DataTable dt = DAL_CLIENT_CERTIFICATE.GetCompanyNoBoxData(oCLIENT_CERTIFICATE.COMPANY_NO_BOX, out strMsg);


                        bool mailSuccess = PrepareAndSendMail(dt, oCLIENT_CERTIFICATE.COMPANY_NO_BOX, oREQUEST_DETAIL.COMPANY_NAME, oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO, oREQUEST_DETAIL.CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS, oCLIENT_CERTIFICATE.EXPIRATION_DATE, oCLIENT_CERTIFICATE.PASSWORD, oCLIENT_CERTIFICATE.FY);

                        if (mailSuccess)
                        {
                            //update email sent date
                            DAL_CLIENT_CERTIFICATE.EmailButtonUpdate(oCLIENT_CERTIFICATE, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER, out strMsg);

                            if (String.IsNullOrEmpty(strMsg))
                            {
                                //success
                                ResponseUtility.ReturnMailSuccessMessage(dr,UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                            }
                            else
                            {
                                //already use in another process
                                ResponseUtility.ReturnFailMessage(dr);
                            }
                        }
                        else
                        {
                            //fail message
                            ResponseUtility.MailSendingFail(dr);
                        }
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
        private bool PrepareAndSendMail(DataTable companyNoBoxData, string COMPANY_NO_BOX, string COMPANY_NAME, string CLIENT_CERTIFICATE_NO, string CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS, DateTime? EXPIRATION_DATE, string PASSWORD, int FY)
        {
            //get config object for CTS010
            BOL_CONFIG config = new BOL_CONFIG("CTS080", con);

            string documentFilePath = config.getStringValue("email.attached.doc.filePath");
            string path = config.getStringValue("email.attached.client.filePath");
            string clientFilePath = path + @"\" + FY.ToString();

            Dictionary<string, string> filePaths = new Dictionary<string, string>() {
                { "Document", documentFilePath },
                { "Certificate", clientFilePath}
            };

            List<string> CERTIFICATES = new List<string>();

            foreach (DataRow item in companyNoBoxData.Rows)
            {
                if (string.IsNullOrEmpty(CLIENT_CERTIFICATE_NO))
                {
                    CLIENT_CERTIFICATE_NO += item["CLIENT_CERTIFICATE_NO"].ToString();
                }
                else
                {
                    CLIENT_CERTIFICATE_NO += "\n" + item["CLIENT_CERTIFICATE_NO"].ToString();
                }
                CERTIFICATES.Add(item["CLIENT_CERTIFICATE_NO"].ToString());
            }

            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NAME },
                        { "${clientCertificate}", CLIENT_CERTIFICATE_NO},
                        { "${expirationDate}", EXPIRATION_DATE.ToString()},
                        { "${password}",  PASSWORD},
                    };

            //prepare for mail header
            string template_base_name = "CTS080_ClientCertificate";
            string subject = config.getStringValue("emailSubject.client"); //come from config table
            String distributionAddressCC = config.getStringValue("emailAddress.cc");

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
            return Utility.Mail.sendClientCertificateMail(CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS, distributionAddressCC, subject, body, map, filePaths, CERTIFICATES);
        }
        #endregion

        #region string to binary Data
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        #endregion
    }
}