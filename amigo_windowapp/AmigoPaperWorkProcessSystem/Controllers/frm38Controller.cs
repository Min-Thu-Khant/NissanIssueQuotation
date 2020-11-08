using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System.Net.Http;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    public class frm38Controller
    {
        #region Constructor
        public frm38Controller()
        { 
        
        }
        #endregion

        #region GetCustomerList

        public DataTable getCustomerList(string COMPANY_NAME, string BILL_COMPANY_NAME, string ACCOUNT_NAME, string COMPANY_NO_BOX, string COMPANY_NAME_READING, string strUserName, string strPassword)
        {
            string url = Properties.Settings.Default.CustomerList.Replace("@ACCOUNT_NAME", ACCOUNT_NAME).Replace("@COMPANY_NAME", COMPANY_NAME).Replace("@COMPANY_READING", COMPANY_NAME_READING).Replace("@BILL_COMPANY_NAME", BILL_COMPANY_NAME).Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX); 
            
            //Encode credentials
            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = client.GetAsync(url);
           
            //call methods
            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }

            string data = result.Data;
            DataTable dt = Utility.JsonToDt(data);
            return dt;

        }
        #endregion

        #region UpdateCustomer
        public bool UpdateCustomer(DataTable dtUpdateCustomerList)
        {

            //convert list to json object
            String json = JsonConvert.SerializeObject( new { Customers = dtUpdateCustomerList });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { Customers = json});

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Encode credentials
            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = client.PostAsync(Properties.Settings.Default.CustomerUpdate, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }
            return result.Status;
        }
        #endregion
    }
}
