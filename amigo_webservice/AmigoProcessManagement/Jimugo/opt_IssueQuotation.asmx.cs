using AmigoProcessManagement.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace AmigoProcessManagement.Jimugo
{
    /// <summary>
    /// Summary description for opt_IssueQuotation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class opt_IssueQuotation : System.Web.Services.WebService
    {

        #region GetInitialData
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetInitialData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Controller.ControllerIssueQuotation issueQuotation = new Controller.ControllerIssueQuotation(authHeader);
            MetaResponse response = issueQuotation.getIntitialData(COMPANY_NO_BOX, REQ_SEQ);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(JsonConvert.SerializeObject(response));
            Context.Response.End();
            //get Authorization header
            //HttpContext httpContext = HttpContext.Current;
            //string authHeader = httpContext.Request.Headers["Authorization"];

            //Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            //if (auth.Message != "")
            //{
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(auth));
            //    Context.Response.End();
            //}
            //else
            //{
            //    Controller.ControllerIssueQuotation issueQuotation = new Controller.ControllerIssueQuotation(authHeader);
            //    MetaResponse response = issueQuotation.getIntitialData(COMPANY_NO_BOX, REQ_SEQ);
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(response));
            //    Context.Response.End();
            //}

        }
        #endregion


        #region PreviewProcess
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void DoPreview(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT,decimal TaxAmt,
            string startDate, string expireDate, string strRemark,string strFromCertificate,string strToCertificate, string strExporType,string strFileHeader,string strContractPlan, decimal decDiscount)
        {
            //get Authorization header  
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Controller.ControllerIssueQuotation previewQuote = new Controller.ControllerIssueQuotation();
            MetaResponse response = previewQuote.DoPreview(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT,TaxAmt,startDate,expireDate, strRemark, strFromCertificate,strToCertificate, authHeader, strExporType,strFileHeader, strContractPlan,decDiscount);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(JsonConvert.SerializeObject(response));
            Context.Response.End();

            //HttpContext httpContext = HttpContext.Current;
            //string authHeader = httpContext.Request.Headers["Authorization"];
            //Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            //if (auth.Message != "")
            //{
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(auth));
            //    Context.Response.End();
            //}
            //else
            //{
            //    Controller.ControllerRegisterCompleteNotificationSending completeNotificationSending = new Controller.ControllerRegisterCompleteNotificationSending();
            //    MetaResponse response = completeNotificationSending.NotiSendingPreview(COMPANY_NAME, COMPANY_NO_BOX, REQ_SEQ, EDI_ACCOUNT, authHeader);
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(response));
            //    Context.Response.End();
            //}
        }
        #endregion

        #region SendMail For Quotation
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void SendMailNotification(string List)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            Controller.ControllerIssueQuotation issueQuotation = new Controller.ControllerIssueQuotation(); 
            MetaResponse response = issueQuotation.SendMailCreate(List, authHeader);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(JsonConvert.SerializeObject(response));
            Context.Response.End();

            //Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            //if (auth.Message != "")
            //{
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(auth));
            //    Context.Response.End();
            //}
            //else
            //{
            //    Controller.ControllerRegisterCompleteNotificationSending completeNotiController = new Controller.ControllerRegisterCompleteNotificationSending();
            //    MetaResponse response = completeNotiController.SendMailCreate(List, authHeader);
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Flush();
            //    Context.Response.Write(JsonConvert.SerializeObject(response));
            //    Context.Response.End();
            //}
        }
        #endregion
    }
}
