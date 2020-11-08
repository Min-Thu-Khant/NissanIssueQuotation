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
    class frmIssuQuotationPreviewController
    {
        #region SendMailNotification
        public DataTable SendMailNotification(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.SendQuotationMail;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion
    }
}
