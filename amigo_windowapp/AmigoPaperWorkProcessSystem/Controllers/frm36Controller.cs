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
    public class frm36Controller
    {
        #region Constructor
        public frm36Controller()
        { }
        #endregion

        #region GetUnmatchInvoice
        public DataTable GetUnmatchInvoice(DateTime dtmFromDate, DateTime dtmToDate)
        {
            string url = Properties.Settings.Default.GetUnmatchInvoice.Replace("@FromDate", dtmFromDate.ToString("yyyyMMdd")).Replace("@ToDate", dtmToDate.ToString("yyyyMMdd"));

            //Encode credentials
            var client = new HttpClient();
            var obj = new { Id = Utility.Id, Password = Utility.Password };
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

        #region RefundProcess
        public bool RefundProcess(DataTable dtData)
        {
            string url = Properties.Settings.Default.RefundProcess;
            //convert list to json object
            String json = JsonConvert.SerializeObject(new { strData = dtData });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { strData = json });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Encode credentials
            var client = new HttpClient();
            var obj = new { Id = Utility.Id, Password = Utility.Password };
            var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = client.PostAsync(url, data);

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
