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
    class FrmMonthlySaleAggregationController
    {
        #region GetMonthlySaleAggregationList
        public DataTable GetMonthlySaleAggregationList(string strDate)
        {

            string url = Properties.Settings.Default.getMonthlySaleAggregationlist;

            //convert list to json object
            String json = JsonConvert.SerializeObject(new
            {
                YEAR_MONTH = strDate
            });

            return WebUtility.Post(url, json);
        }
        #endregion
    }
}
