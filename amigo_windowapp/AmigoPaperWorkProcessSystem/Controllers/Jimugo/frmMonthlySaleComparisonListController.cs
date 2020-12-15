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
    class frmMonthlySaleComparisonListController
    {
        #region GetMonthlySaleComparisonList
        public DataTable GetMonthlySaleComparisonList(string strDate1, string strDate2, int OFFSET, int LIMIT, out Meta MetaData)
        {


            string url = Properties.Settings.Default.getMonthlySaleComparisonlist
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@strYYYMM1", strDate1)
                                                    .Replace("@strYYMM2", strDate2);
            return WebUtility.Get(url, out MetaData);

        }
        #endregion
    }
}
