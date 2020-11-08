using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL_AmigoProcess;
using System.Data;
using System.Web.Script.Services;
using AmigoProcessManagement.Utility;
using Newtonsoft.Json;

namespace AmigoProcessManagement
{
    /// <summary>
    /// Summary description for opt_3A
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_38 : System.Web.Services.WebService
    {
        #region getCustomerList
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void getCustomerList(string COMPANY_NAME, string COMPANY_NAME_READING, string BILL_COMPANY_NAME, string COMPANY_NO_BOX,string ACCOUNT_NAME)
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
                Controller.Controller38 o38 = new Controller.Controller38();
                Response response = o38.GetCustomerList(COMPANY_NAME, COMPANY_NAME_READING, BILL_COMPANY_NAME, COMPANY_NO_BOX, ACCOUNT_NAME);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region UpdateCustomer
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public void UpdateCustomer(string Customers)
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
                Controller.Controller38 o38 = new Controller.Controller38();
                Response response = o38.UpdateCustomer(Customers);
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
