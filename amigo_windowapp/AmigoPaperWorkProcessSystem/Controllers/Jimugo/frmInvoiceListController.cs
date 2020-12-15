using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmInvoiceListController
    {
        #region GetInvoiceList
        public DataSet GetInvoiceList(string BILLING_DATE, int OFFSET, int LIMIT, out Meta MetaData)
        {
            string url = Properties.Settings.Default.GetInvoiceList
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@BILLING_DATE", BILLING_DATE);
            return WebUtility.Post(url, out MetaData);
        }
        #endregion

        #region CreateInvoiceData
        public DataTable CreateInvoiceData(string YEAR_MONTH,string STATUS)
        {
            string url = Properties.Settings.Default.CreateInvoiceData;
            //convert list to json object
            String json = JsonConvert.SerializeObject(new
            {
                BILLING_DATE = YEAR_MONTH,
                STATUS = STATUS
            });

            return WebUtility.Post(url, json);
        }
        #endregion

        #region GetInvoiceListForCSVCreate
        public DataTable GetInvoiceListForCSVCreate(string YEAR_MONTH)
        {
            string url = Properties.Settings.Default.GetInvoiceListForCSVCreate;
            //convert list to json object
            String json = JsonConvert.SerializeObject(new
            {
                YEAR_MONTH = YEAR_MONTH
            });

            return WebUtility.Post(url, json);
        }
        #endregion
    }
}


