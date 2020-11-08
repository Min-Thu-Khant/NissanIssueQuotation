using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System.Data;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmClientCertificateListController
    {
        #region GetClientCertificateList
        public DataTable GetClientCertificateList(string FY, string COMPANY_NO_BOX, string CLIENT_CERTIFICATE_NO, string DISTRIBUTION_STATUS, int OFFSET, int LIMIT, out Meta MetaData)
        {
            string url = Properties.Settings.Default.GetClientCertificateList
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@FY", FY)
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@CLIENT_CERTIFICATE_NO", CLIENT_CERTIFICATE_NO)
                                                    .Replace("@DISTRIBUTION_STATUS", DISTRIBUTION_STATUS);
            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region SubmitClientCertificateList
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateClientCertificateList;
            return WebUtility.Post(url, list, out MetaData);
        }
        #endregion

        #region SendMail
        public DataTable SendMail(DataTable list)
        {
            string url = Properties.Settings.Default.SendMailClientCertificate;
            return WebUtility.Post(url, list);
        }
        #endregion
    }
}
