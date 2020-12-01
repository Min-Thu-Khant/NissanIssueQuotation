using AmigoPaperWorkProcessSystem.Core;
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
        public DataTable GetMonthlySaleAggregationList(string strDate,out Meta MetaData)
        {

            string url = Properties.Settings.Default.getMonthlySaleAggregationlist
                                                    .Replace("@YEARMOHTH", strDate);
                                                   
            return WebUtility.Get(url, out MetaData);
        }
        #endregion
    }
}
