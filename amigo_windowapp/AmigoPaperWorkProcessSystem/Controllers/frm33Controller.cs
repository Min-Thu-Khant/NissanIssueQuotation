using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using AmigoPaperWorkProcessSystem.Core;
using System.Net.Http;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    public class frm33Controller
    {
        #region Constructor
        public frm33Controller()
        {

        }
        #endregion

        #region NonAmigo_BankTR
        public DataTable NonAmigo_BankTR(string strDTMID)
        {
            string url = Properties.Settings.Default.NonAmigo_BankTR.Replace("@DTMID", strDTMID);

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

        #region ConvertNonAmigoToAmigo
        public dynamic ConvertNonAmigoToAmigo(DataTable dtToTranser)
        {
            string url = Properties.Settings.Default.NonAmigoToAmigo;

            //convert list to json object
            String json = JsonConvert.SerializeObject(new { strData = dtToTranser });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { strData = json});

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
                Utility.WriteErrorLog(result.Message.ToString(),null, true);
            }
            return result;
        }
        #endregion

    }
}
