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
    /// Summary description for opt_3A
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_32 : System.Web.Services.WebService
    {
        #region AmigoConfirmation
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ConfirmationOfTransfer_Amigo(string strDTMID)
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

                Controller.Controller32 o32 = new Controller.Controller32();
                Response response = o32.GetAmigoDetailByRunDate(strDTMID);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region ConvertToNonAmigo
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void ConvertAmigoToNonAmigo(string strData)
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
                Controller.Controller32 o32 = new Controller.Controller32();
                Response response = o32.ConvertAmigoToNoAmigo(strData);
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
