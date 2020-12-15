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
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.ControllerIssueQuotation issueQuotation = new Controller.ControllerIssueQuotation(authHeader);
                MetaResponse response = issueQuotation.getIntitialData(COMPANY_NO_BOX, REQ_SEQ);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }

        }
        #endregion

        #region PreviewProcess
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void DoPreview(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, decimal TaxAmt,
            string startDate, string expireDate, string strPeroidFrom, string strPeroidTo, string strExportInfo,
            string strContractPlan, string INITIAL_REMARK, string MONTHLY_REMARK, string PI_REMARK, string ORDER_REMARK)
        {

            // get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.ControllerIssueQuotation previewQuote = new Controller.ControllerIssueQuotation();
                MetaResponse response = previewQuote.DoPreview(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, startDate, expireDate, strPeroidFrom, strPeroidTo, strExportInfo, strContractPlan, INITIAL_REMARK, MONTHLY_REMARK, PI_REMARK, ORDER_REMARK);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region QuotationMailCreate
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void QuotationMailCreate(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, string CONSUMPTION_TAX, string INITIAL_SPECIAL_DISCOUNTS, string MONTHLY_SPECIAL_DISCOUNTS, string YEARLY_SPECIAL_DISCOUNT,string EMAIL_ADDRESS, string INPUT_PERSON, string ExportInfo, string CONTRACT_PLAN, string CREATED_TIME, string strPeroidFrom, string strPeroidTo)
        {
            //// get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.ControllerIssueQuotation issueQuotation = new Controller.ControllerIssueQuotation(authHeader);
                MetaResponse response = issueQuotation.QuotationMailCreate(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, CONSUMPTION_TAX, INITIAL_SPECIAL_DISCOUNTS, MONTHLY_SPECIAL_DISCOUNTS, YEARLY_SPECIAL_DISCOUNT,EMAIL_ADDRESS, INPUT_PERSON, ExportInfo, CONTRACT_PLAN, CREATED_TIME, strPeroidFrom, strPeroidTo);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

    }
}
