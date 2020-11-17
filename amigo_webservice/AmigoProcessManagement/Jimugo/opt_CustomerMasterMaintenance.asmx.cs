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
    /// Summary description for opt_CustomerMasterMaintenance
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_CustomerMasterMaintenance : System.Web.Services.WebService
    {

        #region GetCustomerMasterList
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetMaintenance(string COMPANY_NO_BOX,string COMPANY_NAME,string COMPANY_NAME_READING,string EDI_ACCOUNT,string MAIL_ADDRESS,string CONTRACTOR,string INVOICE,string SERVICE_DESK,string NOTIFICATION_DESTINATION,int OFFSET = 0, int LIMIT = 30)
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
                Controller.ControllerCustomerMasterMaintenance customerMaintenance = new Controller.ControllerCustomerMasterMaintenance();
                MetaResponse response = customerMaintenance.getMaintenanceList(COMPANY_NO_BOX,COMPANY_NAME,COMPANY_NAME_READING,EDI_ACCOUNT,MAIL_ADDRESS,CONTRACTOR,INVOICE,SERVICE_DESK,NOTIFICATION_DESTINATION,OFFSET, LIMIT);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region UpadteCustomerMaster
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void Update(string List)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "") // need to change
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }

            else
            {
                Controller.ControllerCustomerMasterMaintenance orderRegister = new Controller.ControllerCustomerMasterMaintenance(authHeader);
                MetaResponse response = orderRegister.UpdateCustomerMasterMaintenances(List);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region GetPopupScreenData
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetPopupScreenData(string COMPANY_NO_BOX, string REQ_SEQ)
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
                Controller.ControllerCustomerMasterMaintenance customerMaintenance = new Controller.ControllerCustomerMasterMaintenance();
                MetaResponse response = customerMaintenance.getBreakDownScreenData(COMPANY_NO_BOX, REQ_SEQ);
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
