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
    /// Summary description for opt_PurchaseOrder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_PurchaseOrder : System.Web.Services.WebService
    {
        #region Search
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Search(string COMPANY_NO_BOX, string REQ_SEQ)
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
                Controller.ControllerPurchaseOrder purchaseOrder = new Controller.ControllerPurchaseOrder();
                MetaResponse response = purchaseOrder.getInitialData(COMPANY_NO_BOX, REQ_SEQ);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region SubmitOrder

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void SubmitOrderRegister()
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            //uploaded file
            var File = httpContext.Request.Files[0];

            //list
            string List = httpContext.Request.Form.GetValues("List").First();
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
                Controller.ControllerPurchaseOrder purchaseOrder = new Controller.ControllerPurchaseOrder(authHeader);
                MetaResponse response = purchaseOrder.SubmitOrderRegister(List, File);
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
