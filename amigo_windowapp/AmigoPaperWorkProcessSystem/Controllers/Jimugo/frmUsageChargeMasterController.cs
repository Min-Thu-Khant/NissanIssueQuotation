using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmUsageChargeMasterController
    {
        #region GetUsageChargeMaster
        public DataTable GetUsageChargeMaster(string CONTRACT_CODE, string CONTRACT_NAME, int OFFSET, int LIMIT, out Meta MetaData)
        {
            string url = Properties.Settings.Default.GetUsageChargeMaster
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@CONTRACT_CODE", CONTRACT_CODE)
                                                    .Replace("@CONTRACT_NAME", CONTRACT_NAME);

            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region SubmitUsageFeeMaster
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateUsageChargeMaster;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion
    }
}
