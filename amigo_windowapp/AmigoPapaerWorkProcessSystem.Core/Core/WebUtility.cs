using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Core
{
    public class WebUtility
    {
        #region AuthHeader
        private static HttpClient makeAuthHeader()
        {
            // Encode credentials
            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return client;
        }
        #endregion

        #region GetMethod
        public static DataTable Get(string url, out Meta MetaData)
        {
            HttpClient client = makeAuthHeader();
            var response = client.GetAsync(url);

            //call methods
            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }
            MetaData = JsonConvert.DeserializeObject<Meta>(JsonConvert.SerializeObject(result.Meta));
            string data = result.Data;
            DataTable dt = Utility.JsonToDt(data);
            return dt;
        }

        public static DataTable Get(string url)
        {
            HttpClient client = makeAuthHeader();
            var response = client.GetAsync(url);

            //call methods
            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null,true);
            }

            string data = result.Data;
            DataTable dt = Utility.JsonToDt(data);
            return dt;
        }

        public async static Task<bool> Download(string url, string destination)
        {
            try
            {
                HttpClient client = makeAuthHeader();
                var response = client.GetAsync(url);
                byte[] content = response.Result.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(destination, content);
                return true;
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog("Download Failed", ex, true);
                return false;
            }


        }

        #region GetFileNamefromURL
        public static string GetFileNamefromURL(string url)
        {
            int last_index_of_slash = url.LastIndexOf("/") + 1;
            string filename = url.Substring(last_index_of_slash, url.Length - last_index_of_slash);
            return filename;
        }
        #endregion
        #endregion

        #region PostMethod
        public static DataTable Post(string url, DataTable list, out Meta MetaData)
        {
            //convert list to json object
            String json = JsonConvert.SerializeObject(new { List = list });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { List = json });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(),null, true);
            }

            //prepare return data
            MetaData = JsonConvert.DeserializeObject<Meta>(JsonConvert.SerializeObject(result.Meta));
            string returnData = result.Data;
            DataTable dt = Utility.JsonToDt(returnData);

            return dt;
        }


        public static DataTable Post(string url, DataTable list)
        {
            //convert list to json object
            String json = JsonConvert.SerializeObject(new { List = list });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { List = json });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(),null, true);
            }

            //prepare return data
            string returnData = result.Data;
            DataTable dt = Utility.JsonToDt(returnData);

            return dt;
        }

        public static DataTable PostWithFile(string url, DataTable list, string filepath, string extension)
        {
            //create multipart form data
            MultipartFormDataContent form = new MultipartFormDataContent();

            //read file
            var stream = new FileStream(filepath, FileMode.Open);
            StreamContent file = new StreamContent(stream);
            file.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "File",
                FileName = "Temp." + extension
            };
            form.Add(file);

            //convert list to json object
            String json = JsonConvert.SerializeObject(new { List = list });

            //prepare to Post
            //json = JsonConvert.SerializeObject(new { List = json });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            form.Add(data, "List");


            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, form);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }

            //prepare return data
            string returnData = result.Data;
            DataTable dt = Utility.JsonToDt(returnData);

            return dt;
        }
        public static DataTable Post(string url, string COMPANY_NAME, string COMPANY_NO_BOX, string REQ_SEQ, string EDI_ACCOUNT)
        {

            //convert list to json object
            String json = JsonConvert.SerializeObject(new { COMPANY_NAME = COMPANY_NAME, COMPANY_NO_BOX = COMPANY_NO_BOX, REQ_SEQ = REQ_SEQ, EDI_ACCOUNT = EDI_ACCOUNT });

            //prepare to Post
            json = JsonConvert.SerializeObject(new { COMPANY_NAME = COMPANY_NAME, COMPANY_NO_BOX = COMPANY_NO_BOX, REQ_SEQ = REQ_SEQ, EDI_ACCOUNT = EDI_ACCOUNT });

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(),null, true);
            }

            ////prepare return data
            string returnData = result.Data;
            DataTable dt = Utility.JsonToDt(returnData);

            return dt;
        }

        public static DataTable Post(string url, string json)
        {

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }

            ////prepare return data
            //MetaData = JsonConvert.DeserializeObject<Meta>(JsonConvert.SerializeObject(result.Meta));
            string returnData = result.Data;
            DataTable dt = Utility.JsonToDt(returnData);

            return dt;
        }

        public static DataSet Post(string url)
        {
            HttpClient client = makeAuthHeader();
            var response = client.GetAsync(url);

            //call methods
            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }
            string strData = result.Data;
            DataSet dataSet = (DataSet)JsonConvert.DeserializeObject<DataSet>(strData);
            return dataSet;
        }

        public static DataSet Post(string url, out Meta MetaData)
        {
            HttpClient client = makeAuthHeader();
            var response = client.GetAsync(url);

            //call methods
            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }
            string strData = result.Data;

            //prepare return data
            MetaData = JsonConvert.DeserializeObject<Meta>(JsonConvert.SerializeObject(result.Meta));

            DataSet dataSet = (DataSet)JsonConvert.DeserializeObject<DataSet>(strData);
            return dataSet;
        }

        public static DataSet Post(string url, string json, bool dataset)
        {

            //encode content
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = makeAuthHeader();

            var response = client.PostAsync(url, data);

            string content = response.Result.Content.ReadAsStringAsync().Result;

            dynamic result = JsonConvert.DeserializeObject(content);

            //log error message
            if (result.Status == 0)
            {
                Utility.WriteErrorLog(result.Message.ToString(), null, true);
            }

            ////prepare return data
            string strData = result.Data;
            DataSet dataSet = (DataSet)JsonConvert.DeserializeObject<DataSet>(strData);
            return dataSet;
        }

        #endregion
    }
}
