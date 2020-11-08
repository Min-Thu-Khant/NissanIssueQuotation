using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers.PurchaseOrder
{
    class frmPruchaseOrderController
    {
        #region SearchOrderRegistration
        public DataTable GetSearchItem(string COMPANY_NO_BOX, string REQ_SEQ, out Meta MetaData)
        {
            string url = Properties.Settings.Default.GetPurchaseOrdertem
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX.ToString())
                                                    .Replace("@REQ_SEQ", REQ_SEQ.ToString());

            return WebUtility.Get(url, out MetaData);
        }
        #endregion
    }
}
