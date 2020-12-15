using AmigoProcessManagement.Controller.Jimugo;
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
    /// Summary description for opt_FileServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_FileServices : System.Web.Services.WebService
    {

        #region GetTempFile
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetTempFile(string FILENAME)
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
                ControllerFiles fileService = new ControllerFiles();
                byte[] file = fileService.GetTempFile(FILENAME);
                Context.Response.Clear();
                Context.Response.ClearHeaders();
                Context.Response.ContentType = "application/pdf"; ;
                Context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + FILENAME + "\"");
                Context.Response.AddHeader("Content-Length", file.Length.ToString());
                Context.Response.OutputStream.Write(file, 0, file.Length);
                Context.Response.Flush();
                Context.Response.End();
            }
        }
        #endregion

        #region DeleteTempFile
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void DeleteTempFIle(string FILENAME)
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
                ControllerFiles fileService = new ControllerFiles();
                Response response = fileService.DeleteTempFile(FILENAME);
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
