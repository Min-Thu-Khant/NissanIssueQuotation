using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem._3B.Controllers
{
    class _3BController
    {
        #region Do3B
        public async Task<int> ExecuteBatchProcess()
        {
            try
            {

                //call method
                var client = new HttpClient();
                var obj = new { Id = Utility.Id, Password = Utility.Password };
                var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = client.GetAsync(Properties.Settings.Default.MatchInvoices);

                string content = response.Result.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);

                //log error message
                if (result.Status == 0)
                {
                    Utility.WriteErrorLog(result.Message.ToString(),null,true);
                }

                return result.Status;

                
            }
            catch (System.TimeoutException) //server timeout
            {
                MessageBox.Show(Messages.General.ServerTimeOut);
                Utility.ExitApp();
                return 0;
            }
            catch (System.Net.WebException) // connection problem
            {
                MessageBox.Show(Messages.General.NoConnection);
                Utility.ExitApp();
                return 0;
            }
            catch (Exception) //general exception
            {
                return 0;
            }
        }
        #endregion
    }
}
