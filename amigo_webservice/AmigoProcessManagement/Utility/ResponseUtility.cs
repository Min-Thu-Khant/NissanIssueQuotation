using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AmigoProcessManagement.Utility
{
    public class ResponseUtility
    {
        #region Return Success Message
        public static void ReturnSuccessMessage(DataRow row, string UPDATED_AT_DATETIME, string CURRENT_DATETIME, string CURRENT_USER)
        {
            row["UPDATED_AT"] = UPDATED_AT_DATETIME;
            row["UPDATED_AT_RAW"] = CURRENT_DATETIME;
            row["UPDATED_BY"] = CURRENT_USER;
            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ007;
            row["MK"] = "O";
        }

        public static void ReturnSuccessMessage(DataRow row, string UPDATED_AT_DATETIME, string CURRENT_DATETIME, string CURRENT_USER, string msg)
        {
            row["UPDATED_AT"] = UPDATED_AT_DATETIME;
            row["UPDATED_AT_RAW"] = CURRENT_DATETIME;
            row["UPDATED_BY"] = CURRENT_USER;
            row["UPDATE_MESSAGE"] = msg;
            row["MK"] = "O";
        }

        public static void ReturnMailSuccessMessage(DataRow row, string UPDATED_AT_DATETIME, string CURRENT_DATETIME, string CURRENT_USER)
        {
            row["UPDATED_AT"] = UPDATED_AT_DATETIME;
            row["UPDATED_AT_RAW"] = CURRENT_DATETIME;
            row["UPDATED_BY"] = CURRENT_USER;
            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ015;
            row["MK"] = "O";
        }

        #endregion

        #region Return Delete Success Message
        public static void ReturnDeleteSuccessMessage(DataRow row)
        {
            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ007;
            row["MK"] = "-";
        }
        #endregion

        #region Return Fail Message
        public static void ReturnFailMessage(DataRow row)
        {
            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.I000ZZ005;
            row["MK"] = "X";
        }

        public static void ReturnFailMessage(DataRow row, string msg)
        {
            row["UPDATE_MESSAGE"] = msg;
            row["MK"] = "X";
        }

        public static MetaResponse ReturnFailMessage(MetaResponse response, Stopwatch timer, DataTable BodyMessage)
        {
            response.Status = 0;
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalSeconds;
            response.Message = Utility.Messages.Jimugo.I000ZZ005;
            //add in body message
            DataRow dr = BodyMessage.NewRow();
            dr["Error Message"] = response.Message;
            BodyMessage.Rows.Add(dr);
            response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
            return response;
        }

        public static MetaResponse ReturnFailMessage(MetaResponse response, Stopwatch timer, DataTable BodyMessage, string msg)
        {
            response.Status = 0;
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalSeconds;
            response.Message = msg;
            //add in body message
            DataRow dr = BodyMessage.NewRow();
            dr["Error Message"] = response.Message;
            BodyMessage.Rows.Add(dr);
            response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
            return response;
        }

        #endregion

        #region GetStackMessage
        public static string GetStackMessage(Exception ex)
        {
            return ex.Message + "/n" + ex.StackTrace;
        }
        #endregion

        #region UnexpectedResponse
        public static MetaResponse GetUnexpectedResponse(MetaResponse response, Stopwatch timer, Exception ex)
        {
            response.Status = 0;
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalSeconds;
            response.Message = GetStackMessage(ex);
            return response;
        }
        #endregion

        #region Set Fail Mail Sending Process
        public static MetaResponse MailSendingFail(MetaResponse response, Stopwatch timer, DataTable BodyMessage)
        {
            response.Status = 0;
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalSeconds;
            response.Message = Utility.Messages.Jimugo.E000ZZ041;
            //add in body message
            DataRow dr = BodyMessage.NewRow();
            dr["Error Message"] = response.Message;
            BodyMessage.Rows.Add(dr);
            response.Data = Utility_Component.DtToJSon(BodyMessage, "Message");
            return response;
        }
        #endregion

        public static void MailSendingFail(DataRow row)
        {
            row["UPDATE_MESSAGE"] = Utility.Messages.Jimugo.E000ZZ041;
            row["MK"] = "X";
        }

    }
}