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
    public class frmUsageApplicationListController
    {
        #region GetApplicationList
        public DataTable GetApplicationList(string COMPANY_NO_BOX,string COMPANY_NAME,string CLOSE_FLG,string GD,string REQUEST_STATUS,string REQ_DATE_FROM,string REQ_DATE_TO,string QUOTATION_DATE_FROM,string QUOTATION_DATE_TO,string ORDER_DATE_FROM,string ORDER_DATE_TO,string SYSTEM_SETTRING_STATUS, int OFFSET, int LIMIT, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetUsageApplicationList
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString())
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@COMPANY_NAME", COMPANY_NAME)
                                                    .Replace("@CLOSE_FLG", CLOSE_FLG)
                                                    .Replace("@GD", GD)
                                                    .Replace("@REQUEST_STATUS", REQUEST_STATUS)
                                                    .Replace("@REQ_DATE_FROM", REQ_DATE_FROM)
                                                    .Replace("@REQ_DATE_TO", REQ_DATE_TO)
                                                    .Replace("@QUOTATION_DATE_FROM", QUOTATION_DATE_FROM)
                                                    .Replace("@QUOTATION_DATE_TO", QUOTATION_DATE_TO)
                                                    .Replace("@ORDER_DATE_FROM", ORDER_DATE_FROM)
                                                    .Replace("@ORDER_DATE_TO", ORDER_DATE_TO)
                                                    .Replace("@SYSTEM_SETTING_STATUS", SYSTEM_SETTRING_STATUS);
            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region GetApplicationList
        public DataTable getSubProgramList()
        {

            string url = Properties.Settings.Default.GetSubProgramLists;
            return WebUtility.Get(url);
        }
        #endregion

        #region SubmitUsageApplicationList
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateUsageApplicationList;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion

        #region SubmitApplicationCancel
        public DataTable SubmitApplicationCancel(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateApplicationCancel;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion

        #region SubmitConfirmationRequest
        public DataTable SubmitConfirmationRequest(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateConfirmationRequest;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion

        #region SubmitConfirmationComplete
        public DataTable SubmitConfirmationComplete(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateConfirmationComplete;
            return WebUtility.Post(url, list, out MetaData);

        }
        #endregion
    }
}
