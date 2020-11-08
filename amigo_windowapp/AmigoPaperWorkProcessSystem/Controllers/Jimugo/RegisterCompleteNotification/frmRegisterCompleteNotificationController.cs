using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers.RegisterCompleteNotification
{
    class frmRegisterCompleteNotificationController
    {
        #region GetCompanyCodeList
        public DataTable GetScreenData(string COMPANY_NO_BOX, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetScreenDataNotificatoinSending
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX);
            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region Notification Preview
        public DataTable PreviewFunction(string COMPANY_NAME, string COMPANY_NO_BOX, string REQ_SEQ,string EDI_ACCOUNT)
        {
            string url = Properties.Settings.Default.PreviewNotification;
            return WebUtility.Post(url, COMPANY_NAME, COMPANY_NO_BOX, REQ_SEQ, EDI_ACCOUNT);

        }
        #endregion
    }
}
