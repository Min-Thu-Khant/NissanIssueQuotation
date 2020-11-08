using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.BOL;
using AmigoProcessManagement.Utility;
using System.Text;
using Newtonsoft.Json;

namespace AmigoProcessManagement.Controller
{
    #region ControllerCheckIn
    public class ControllerCheckIn
    {
        #region Declare
        private Response response;
        #endregion

        #region Constructor
        public ControllerCheckIn()
        {
            response = new Response();
        }
        #endregion

        #region Login 
        public Response CheckLogIn(string strUserName, string strPass)
        {
            try
            {
                USER_MASTER oMaster = new USER_MASTER(Properties.Settings.Default.MyConnection);
                DataTable dtLogIn = oMaster.CheckLogIn(strUserName, strPass);
                if (dtLogIn.Rows.Count > 0)
                {
                    response.Status = 1;
                    response.Message = "";
                }
                else
                {
                    response.Status = 0;
                    response.Message = "Authentication requrie!";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region CheckCredentials
        public static Response CheckLogIn_forProcess(string authHeader)
        {
            try
            {
                //Decode Credentials
                string encodedCredential = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("US-ASCII");
                string decoded = encoding.GetString(Convert.FromBase64String(encodedCredential));
                var credential = decoded.Split(':');
                //authenticate
                Response response = new Response();
                USER_MASTER oMaster = new USER_MASTER(Properties.Settings.Default.MyConnection);
                DataTable dtLogIn = oMaster.CheckLogIn(credential[0], credential[1]);
                if (dtLogIn.Rows.Count > 0)
                {
                    response.Status = 1;
                    response.Message = "";
                }
                else
                {
                    response.Status = 0;
                    response.Message = "Authentication Required";
                }
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Message = ex.Message + "\n" + ex.StackTrace;
                response.Status = 0;
                return response;
            }
        }
        #endregion
    }
    #endregion
}