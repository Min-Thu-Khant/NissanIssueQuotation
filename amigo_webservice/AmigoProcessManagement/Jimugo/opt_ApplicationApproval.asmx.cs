using AmigoProcessManagement.Controller;
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
    /// Summary description for opt_ApplicationApproval
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_ApplicationApproval : System.Web.Services.WebService
    {

        #region GetInitialData
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetClientCertificateList(string COMPANY_NO_BOX, string REQ_SEQ, int REQ_STATUS, int REQ_TYPE)
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
                ControllerApplicationApproval approval = new Controller.ControllerApplicationApproval(authHeader);
                MetaResponse response = approval.getInitialData(COMPANY_NO_BOX, REQ_SEQ, REQ_STATUS, REQ_TYPE);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region Approve
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void Approve(string COMPANY_NO_BOX, int REQ_TYPE, string REQ_TYPE_RAW, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, string LIST)
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
                ControllerApplicationApproval approval = new Controller.ControllerApplicationApproval(authHeader);
                MetaResponse response = approval.Approve(COMPANY_NO_BOX, REQ_TYPE, REQ_TYPE_RAW, CHANGED_ITEMS, SYSTEM_EFFECTIVE_DATE, SYSTEM_REGIST_DEADLINE, LIST);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region Disapprove
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void Disapprove(string COMPANY_NO_BOX, int REQ_TYPE, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, string LIST)
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
                ControllerApplicationApproval approval = new Controller.ControllerApplicationApproval(authHeader);
                MetaResponse response = approval.Disapprove(COMPANY_NO_BOX, REQ_TYPE, CHANGED_ITEMS, SYSTEM_EFFECTIVE_DATE, SYSTEM_REGIST_DEADLINE, LIST);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region ApproveCancel
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void ApproveCancel(string COMPANY_NO_BOX, string REQ_SEQ, string LIST)
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
                ControllerApplicationApproval approval = new Controller.ControllerApplicationApproval(authHeader);
                MetaResponse response = approval.ApproveCancel(COMPANY_NO_BOX, REQ_SEQ, LIST);
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
