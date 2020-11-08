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
    class frmUsageInfoRegistrationListController
    {
        #region GetUsageInfoRegistrationList
        public DataTable GetUsageInfoRegistrationList(string COMPANY_NO_BOX, string COMPANY_NAME, string EDI_ACCOUNT, int OFFSET, int LIMIT, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetUsageRegList
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@COMPANY_NAME", COMPANY_NAME)
                                                    .Replace("@EDI_ACCOUNT", EDI_ACCOUNT);
            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region GetEDICandidates
        public DataTable GetEDICandidates()
        {
            string url = Properties.Settings.Default.GetEDICandidates;
            return WebUtility.Get(url);
        }
        #endregion

        #region GetEDIAccountDetail
        public DataTable GetEDIAccountDetail(string COMPANY_NO_BOX)
        {
            string url = Properties.Settings.Default.GetEDIAccountDetail.Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX);
            return WebUtility.Get(url);
        }
        #endregion


        #region SubmitUsageRegistrationList
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateUsageRegList;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion

        #region SettingComplete
        public DataTable SettingComplete(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.SettingCompleteMail;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion

    }
}
