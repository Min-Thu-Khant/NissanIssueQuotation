using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    public class frm35Controller
    {
        #region Constructor
        public frm35Controller()
        { }
        #endregion

        #region GetMatchInvoice
        public DataTable GetMatchInvoice(DateTime dtmFromDate, DateTime dtmToDate, bool isNoReserved)
        {
            string url = Properties.Settings.Default.GetMatchInvoice.Replace("@FromDate", dtmFromDate.ToString("yyyyMMdd")).Replace("@ToDate", dtmToDate.ToString("yyyyMMdd")).Replace("@NoReserved", isNoReserved.ToString());

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

        #region CancelAllocation
        public bool CancelAllocation(DataTable dtData)
        {
            string url = Properties.Settings.Default.CancelAllocation;

            //convert list to json object
            String json = JsonConvert.SerializeObject(new { strData = dtData });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { strData = json });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Encode credentials
            var client = new HttpClient();
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

        #region getAccountingCSV
        public DataTable getAccountingCSV(DateTime dtmFromDate, DateTime dtmToDate)
        {
            string url = Properties.Settings.Default.Get35_AccountingCSV.Replace("@FromDate", dtmFromDate.ToString("yyyyMMdd")).Replace("@ToDate", dtmToDate.ToString("yyyyMMdd"));

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
    }
}
