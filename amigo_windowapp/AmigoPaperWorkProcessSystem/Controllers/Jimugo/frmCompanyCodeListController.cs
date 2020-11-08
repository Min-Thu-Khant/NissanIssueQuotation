using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System.Data;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmCompanyCodeListController
    {
        #region GetCompanyCodeList
        public DataTable GetCompanyCodeList(string COMPANY_NO_BOX, string COMPANY_NAME, string EMAIL, int OFFSET, int LIMIT, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetCompanyCodeList
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@COMPANY_NAME", COMPANY_NAME)
                                                    .Replace("@EMAIL", EMAIL);
           return  WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region SubmitCompanyCodeList
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
                string url = Properties.Settings.Default.UpdateCompanyCodeList;
            return WebUtility.Post(url, list, out MetaData);
            
        }
        #endregion

        #region GetPassword
        public DataTable GetPassword()
        {
            string url = Properties.Settings.Default.GetPassword;
            return WebUtility.Get(url);
        }
        #endregion

        #region SendMail
        public async Task<DataTable> SendMail(DataTable list)
        {
            string url = Properties.Settings.Default.SendMail;
            return WebUtility.Post(url, list);
        }
        #endregion
    }
}
