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
    public class ControllerCompanyCodeList
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
        public ControllerCompanyCodeList()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerCompanyCodeList(string authHeader) :this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region getCompanyCodeList
        public MetaResponse getCompanyCodeList(string COMPANY_NO_BOX, string COMPANY_NAME, string EMAIL, int OFFSET, int LIMIT)
        {

            try
            {
                string strMessage = "";
                int TOTAL = 0;
                REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);
                DataTable dt = DAL_REQUEST_ID.GetCompanyCodeList(COMPANY_NO_BOX, COMPANY_NAME, EMAIL, OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "CompnayCodeList");
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

        #region UpdateCompanyCodeList
        public MetaResponse UpdateCompanyCodeList(string CompanyCodeList)
        {
            try
            {
                DataTable dgvList = Utility.Utility_Component.JsonToDt(CompanyCodeList);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
                    oREQUEST_ID = Cast_REQUEST_ID(dgvList.Rows[i]);

                    switch (dgvList.Rows[i]["MK"].ToString())
                    {
                        case "I":
                            HandleInsert(oREQUEST_ID, "I", dgvList.Rows[i]);
                            break;
                        case "C":
                            HandleInsert(oREQUEST_ID, "C", dgvList.Rows[i]);
                            break;
                        case "M":
                            HandleModify(oREQUEST_ID, dgvList.Rows[i]);
                            break;
                        case "D":
                            HandleDelete(oREQUEST_ID, dgvList.Rows[i]);
                            break;
                        default:
                            break;
                    }
                }
                response.Status = 1;
                response.Data = Utility.Utility_Component.DtToJSon(dgvList, "CompanyCodeList Update"); ;
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

        #region HandleDelete
        private void HandleDelete(BOL_REQUEST_ID oREQUEST_ID, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                //check if it is already registered in REQUEST_DETAIL
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);

                if (!DAL_REQUEST_ID.IsAlreadyUpdated(oREQUEST_ID, out strMsg)) // IF updated_at is not already modified
                {
                    if (!DAL_REQUEST_DETAIL.IsAlreadyUsed(oREQUEST_ID.COMPANY_NO_BOX, out strMsg))
                    {
                        //delete the record
                        DAL_REQUEST_ID.Delete(oREQUEST_ID, out strMsg);
                       
                    }
                    else //Already used
                    {
                        dbTxn.Dispose();
                        ResponseUtility.ReturnFailMessage(row, string.Format(Utility.Messages.Jimugo.E000ZZ033, oREQUEST_ID.COMPANY_NO_BOX));          
                        return;
                    }
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

        #region HandleInsert
        private void HandleInsert(BOL_REQUEST_ID oREQUEST_ID, string OPERATION, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);

                if (OPERATION == "I")
                {
                    #region Auto Index
                    //GET records of AUTO_INDEX TABLE
                    AUTO_INDEX DAL_AUTO_INDEX = new AUTO_INDEX(con);
                    DataTable result = DAL_AUTO_INDEX.GetByAutoIndexID(oREQUEST_ID.AUTO_INDEX_ID, out strMsg);


                    //parepare AUTO_INDEX object
                    BOL_AUTO_INDEX oAUTO_INDEX = new BOL_AUTO_INDEX();
                    oAUTO_INDEX = Cast_AUTO_INDEX(result.Rows[0]);
                    oAUTO_INDEX.AUTO_INDEX++;
                    #endregion

                    #region Insert Record

                    if (!DAL_AUTO_INDEX.IsAlreadyUpdated(oAUTO_INDEX, out strMsg)) // If AUTO INDEX is not already modified
                    {
                        //UPDATE AUTO INDEX
                        DAL_AUTO_INDEX.Update(oAUTO_INDEX, CURRENT_DATETIME, CURRENT_USER, out strMsg);

                        //generate COMPANY NO BOX
                        string COMPANY_NO = "AJ-" + oAUTO_INDEX.AUTO_INDEX.ToString().PadLeft(4, '0');
                        int COMPANY_BOX = 1;
                        string COMPANY_NO_BOX = COMPANY_NO + "-" + COMPANY_BOX.ToString().PadLeft(2, '0');

                        //assign COMPANY NO BOX
                        oREQUEST_ID.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oREQUEST_ID.COMPANY_NO = COMPANY_NO;
                        oREQUEST_ID.COMPANY_BOX = COMPANY_BOX;

                        //Update in datatable
                        row["COMPANY_NO_BOX"] = COMPANY_NO_BOX;
                        row["COMPANY_NO"] = COMPANY_NO;
                        row["COMPANY_BOX"] = COMPANY_BOX;


                        //generate hashed password
                        oREQUEST_ID.PASSWORD_HASHED = Crypto.HashPassword(oREQUEST_ID.PASSWORD);


                        //insert the record
                        oREQUEST_ID.GD = string.IsNullOrEmpty(oREQUEST_ID.GD_CODE) ? 0 : 2;
                        oREQUEST_ID.SOCIOS_USER_FLG = oREQUEST_ID.AUTO_INDEX_ID == "CNSOCIOS" ? "*" : " ";
                        DAL_REQUEST_ID.Insert(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out strMsg);

                        if (String.IsNullOrEmpty(strMsg)) //success
                        {

                            dbTxn.Complete();
                            ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                        }
                        else //failed
                        {
                            ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ028, COMPANY_NO_BOX));
                        }

                    }
                    else
                    {
                        ResponseUtility.ReturnFailMessage(row);
                        return;
                    }
                    #endregion
                }
                else
                {
                    #region Copy Record
                    //get max company number from REQUEST_ID
                    oREQUEST_ID.COMPANY_BOX = DAL_REQUEST_ID.GetMaxCompanyBox(oREQUEST_ID.COMPANY_NO, out strMsg);
                    string COMPANY_NO = oREQUEST_ID.COMPANY_NO;
                    int COMPANY_BOX = oREQUEST_ID.COMPANY_BOX;
                    string COMPANY_NO_BOX = COMPANY_NO + "-" + COMPANY_BOX.ToString().PadLeft(2, '0');

                    //Update in datatable
                    oREQUEST_ID.COMPANY_NO_BOX = COMPANY_NO_BOX;
                    row["COMPANY_NO_BOX"] = COMPANY_NO_BOX;
                    row["COMPANY_NO"] = COMPANY_NO;
                    row["COMPANY_BOX"] = COMPANY_BOX;

                    //generate hashed password
                    oREQUEST_ID.PASSWORD_HASHED = Crypto.HashPassword(oREQUEST_ID.PASSWORD);

                    //insert the record
                    oREQUEST_ID.GD = string.IsNullOrEmpty(oREQUEST_ID.GD_CODE) ? 0 : 2;
                    oREQUEST_ID.SOCIOS_USER_FLG = oREQUEST_ID.AUTO_INDEX_ID == "CNSOCIOS" ? "*" : " ";
                    DAL_REQUEST_ID.Insert(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                    

                    if (String.IsNullOrEmpty(strMsg)) //success
                    {
                        dbTxn.Complete();
                        ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                    }
                    else //failed
                    {
                        ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ028, COMPANY_NO_BOX));
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region HandleModify
        private void HandleModify(BOL_REQUEST_ID oREQUEST_ID, DataRow row)
        {
            string strMsg = "";
            REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);

            if (!DAL_REQUEST_ID.IsAlreadyUpdated(oREQUEST_ID, out strMsg)) // If updated_at is not already modified
            {
                //update the record
                oREQUEST_ID.GD = string.IsNullOrEmpty(oREQUEST_ID.GD_CODE) ? 0 : 2;
                oREQUEST_ID.PASSWORD_EXPIRATION_DATE = oREQUEST_ID.DISABLED_FLG == "*" ? null : oREQUEST_ID.PASSWORD_EXPIRATION_DATE;
                oREQUEST_ID.PASSWORD_SET_DATE = oREQUEST_ID.DISABLED_FLG == "*" ? null : oREQUEST_ID.PASSWORD_SET_DATE;
                DAL_REQUEST_ID.Update(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out strMsg);
            }
            else
            {
                ResponseUtility.ReturnFailMessage(row);
                return;
            }

            //return message and MK value
            if (String.IsNullOrEmpty(strMsg)) //success
            {
                ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
            }
            else //failed
            {
                ResponseUtility.MailSendingFail(row);
            }

        }
        #endregion

        #region CastToBOL_AUTO_INDEX
        private BOL_AUTO_INDEX Cast_AUTO_INDEX(DataRow row)
        {
            BOL_AUTO_INDEX oAUTO_INDEX = new BOL_AUTO_INDEX();
            oAUTO_INDEX.AUTO_INDEX_ID = row["AUTO_INDEX_ID"].ToString();
            oAUTO_INDEX.AUTO_INDEX = int.Parse(row["AUTO_INDEX"].ToString());
            oAUTO_INDEX.CREATED_AT = row["CREATED_AT"].ToString();
            oAUTO_INDEX.CREATED_BY = row["CREATED_BY"].ToString();
            oAUTO_INDEX.UPDATED_AT = row["UPDATED_AT"].ToString() == "" ? null : row["UPDATED_AT"].ToString();
            oAUTO_INDEX.UPDATED_BY = row["UPDATED_BY"].ToString();

            return oAUTO_INDEX;
        }
        #endregion

        #region CastToBOL_REQUEST_ID
        private BOL_REQUEST_ID Cast_REQUEST_ID(DataRow row)
        {
            BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
            oREQUEST_ID.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
            oREQUEST_ID.COMPANY_NAME = row["COMPANY_NAME"].ToString();
            oREQUEST_ID.PASSWORD = row["PASSWORD"].ToString();
            oREQUEST_ID.PASSWORD_SET_DATE = Utility_Component.dtColumnToDateTime(row["PASSWORD_SET_DATE"].ToString());
            oREQUEST_ID.PASSWORD_EXPIRATION_DATE = Utility_Component.dtColumnToDateTime(row["PASSWORD_EXPIRATION_DATE"].ToString());
            oREQUEST_ID.EMAIL_ADDRESS = row["EMAIL_ADDRESS"].ToString();
            oREQUEST_ID.EMAIL_SEND_DATE = Utility_Component.dtColumnToDateTime(row["EMAIL_SEND_DATE"].ToString());
            oREQUEST_ID.LOGIN_FAIL_COUNT = Utility_Component.dtColumnToInt(row["LOGIN_FAIL_COUNT"].ToString());
            oREQUEST_ID.SESSION_ID = row["SESSION_ID"].ToString();
            oREQUEST_ID.LAST_ACCESS_DATE = Utility_Component.dtColumnToDateTime(row["LAST_ACCESS_DATE"].ToString());
            oREQUEST_ID.LAST_FAIL_DATE = Utility_Component.dtColumnToDateTime(row["LAST_FAIL_DATE"].ToString());
            oREQUEST_ID.GD_CODE = row["GD_CODE"].ToString();
            oREQUEST_ID.DISABLED_FLG = row["DISABLED_FLG"].ToString();
            oREQUEST_ID.MEMO = row["MEMO"].ToString();
            oREQUEST_ID.UPDATED_AT = row["UPDATED_AT"].ToString() == "" ? null : row["UPDATED_AT"].ToString();
            oREQUEST_ID.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString() == "" ? null : row["UPDATED_AT_RAW"].ToString();
            oREQUEST_ID.UPDATED_BY = row["UPDATED_BY"].ToString();
            oREQUEST_ID.SOCIOS_USER_FLG = row["SOCIOS_USER_FLG"].ToString();
            oREQUEST_ID.COMPANY_BOX = Utility_Component.dtColumnToInt(row["COMPANY_BOX"].ToString());
            oREQUEST_ID.COMPANY_NO = row["COMPANY_NO"].ToString();
            string auto_index = row["AUTO_INDEX_ID"].ToString();
            switch (auto_index)
            {
                case "サプライヤ":
                    oREQUEST_ID.AUTO_INDEX_ID = "CNSUP";
                    break;
                case "要元":
                    oREQUEST_ID.AUTO_INDEX_ID = "CNMAKER";
                    break;
                case "socios":
                    oREQUEST_ID.AUTO_INDEX_ID = "CNSOCIOS";
                    break;
                default:
                    oREQUEST_ID.AUTO_INDEX_ID = null;
                    break;
            }

            return oREQUEST_ID;
        }
        #endregion

        #region GeneratePassword

        public MetaResponse GeneratePassword()
        {
            try
            {
                //generate raw password
                string raw_password = Crypto.GenerateRawPassword();

                #region PreparePasswordResultTable
                DataTable dt = new DataTable();
                dt.Columns.Add("PASSWORD");
                dt.Columns.Add("PASSWORD_SET_DATE");
                dt.Columns.Add("PASSWORD_EXPIRATION_DATE");
                #endregion

                //add row and data
                DateTime startDate = DateTime.Now;
                DateTime stopDate = DateTime.Today.AddDays(7).AddTicks(-1);

                DataRow dr = dt.NewRow();
                dr["PASSWORD"] = raw_password;
                dr["PASSWORD_SET_DATE"] = startDate.ToString("yyyy/MM/dd HH:mm");

                //get from config table
                dr["PASSWORD_EXPIRATION_DATE"] = stopDate.ToString("yyyy/MM/dd HH:mm"); 
                dt.Rows.Add(dr);

                response.Data = Utility.Utility_Component.DtToJSon(dt, "Password Generate");

                //return response 
                response.Status = 1;
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

        #region Send_Mail
        public MetaResponse SendMail(string CompanyCodeList)
        {
            try
            {
                string strMsg = "";
                DataTable dgvList = Utility.Utility_Component.JsonToDt(CompanyCodeList);

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    //cast to REQUEST_ID object
                    BOL_REQUEST_ID oREQUEST_ID = new BOL_REQUEST_ID();
                    oREQUEST_ID = Cast_REQUEST_ID(dgvList.Rows[i]);

                    REQUEST_ID DAL_REQUEST_ID = new REQUEST_ID(con);

                    if (!DAL_REQUEST_ID.IsAlreadyUpdated(oREQUEST_ID, out strMsg)) // If updated_at is not already modified
                    {
                        bool mailSuccess = PrepareAndSendMail(oREQUEST_ID);

                        if (mailSuccess)
                        {
                            //update email sent date
                            oREQUEST_ID.EMAIL_SEND_DATE = TEMP;
                            DAL_REQUEST_ID.UpdateMailDate(oREQUEST_ID, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                            if (String.IsNullOrEmpty(strMsg))
                            {
                                //success message
                                dgvList.Rows[i]["EMAIL_SEND_DATE"] = UPDATED_AT_DATETIME;
                                ResponseUtility.ReturnMailSuccessMessage(dgvList.Rows[i]);
                            }
                            else
                            {
                                //fail message
                                ResponseUtility.MailSendingFail(dgvList.Rows[i]);
                            }
                        }
                        else
                        {
                            ResponseUtility.MailSendingFail(dgvList.Rows[i]);
                        }
                    }
                    else
                    {
                        ResponseUtility.ReturnFailMessage(dgvList.Rows[i]);
                    }
                }
                response.Status = 1;
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
        private bool PrepareAndSendMail(BOL_REQUEST_ID oREQUEST_ID)
        {
            //get config object for CTS010
            BOL_CONFIG config = new BOL_CONFIG("CTS010", con);

            //prepare for mail mapping
            string expire_date = oREQUEST_ID.PASSWORD_EXPIRATION_DATE == null ? "" : ((DateTime)oREQUEST_ID.PASSWORD_EXPIRATION_DATE).ToString("yyyy/MM/dd HH:mm");

            Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", oREQUEST_ID.COMPANY_NAME },
                        { "${aventailUserName}", config.getStringValue("email.aventail.user.name")},// come from config table
                        { "${aventailPassword}", config.getStringValue("email.aventail.user.id")},// come from config table
                        { "${companyNoBox}", oREQUEST_ID.COMPANY_NO_BOX},
                        { "${password}", oREQUEST_ID.PASSWORD},
                        { "${limitDate}",  expire_date},
                        { "${updUserId}", CURRENT_USER }
                    };

            //prepare for mail header
            string template_base_name = "CTS010_CompanyCode"; 
            string subject = config.getStringValue("emailSubject.login.info");
            string cc = config.getStringValue("emailAddress.cc");

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
            return Utility.Mail.sendMail(oREQUEST_ID.EMAIL_ADDRESS, cc, subject, body, map);
        }
        #endregion

    }
}