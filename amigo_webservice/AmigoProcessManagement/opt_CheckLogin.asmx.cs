using AmigoProcessManagement.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace AmigoProcessManagement
{
    /// <summary>
    /// Summary description for CheckLogIn
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_CheckLogin : System.Web.Services.WebService
    {
        #region CheckAuth
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void CheckAuth(string UserName, string Password)
        {
            Controller.ControllerCheckIn oCheck = new Controller.ControllerCheckIn();
            Response response = oCheck.CheckLogIn(UserName, Password);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(JsonConvert.SerializeObject(response));
            Context.Response.End();
        }
        #endregion
    }
}
