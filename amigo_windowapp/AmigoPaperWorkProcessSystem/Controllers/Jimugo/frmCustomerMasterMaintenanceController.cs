using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System.Data;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmCustomerMasterMaintenanceController
    {
        #region GetCustomerMasterMaintenanceList
        public DataTable GetCustomerMasterMaintenanceList(string COMPANY_NO_BOX,string COMPANY_NAME,string COMPANY_NAME_READING,string EDI_ACCOUNT,string MAIL_ADDRESS,string CONTRACTOR,string INVOICE,string SERVICE_DESK,string NOTIFICATION_DESTINATION,int OFFSET, int LIMIT, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetCustomerMasterMaintenance
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX.ToString())
                                                    .Replace("@COMPANY_NAME", COMPANY_NAME.ToString())
                                                    .Replace("@NAME_READING", COMPANY_NAME_READING.ToString())
                                                    .Replace("@EDI_ACCOUNT", EDI_ACCOUNT.ToString())
                                                    .Replace("@MAIL_ADDRESS", MAIL_ADDRESS.ToString())
                                                    .Replace("@CONTRACTOR", CONTRACTOR.ToString())
                                                    .Replace("@INVOICE", INVOICE.ToString())
                                                    .Replace("@SERVICE_DESK", SERVICE_DESK.ToString())
                                                    .Replace("@NOTIFICATION_DESTINATION", NOTIFICATION_DESTINATION.ToString())
                                                    .Replace("@OFFSET", OFFSET.ToString())
                                                    .Replace("@LIMIT", LIMIT.ToString());
           return  WebUtility.Get(url, out MetaData);
        }
        #endregion

        //MAIL_ADDRESS=@MAIL_ADDRESS&CONTRACTOR=@CONTRACTOR,INVOICE=@INVOICE,SERVICE_DESK=@SERVICE_DESK,NOTIFICATION_DESTINATION=@NOTIFICATION_DESTINATION


        #region SubmitCustomerMaster
        public DataTable Submit(DataTable list, out Meta MetaData)
        {
            string url = Properties.Settings.Default.UpdateCustomerMasterList;
            return WebUtility.Post(url, list, out MetaData);
        }
        #endregion

        #region GetPopupScreenData
        public DataSet GetPopupScreenData(string COMPANY_NO_BOX,string REQ_SEQ)
        {

            string url = Properties.Settings.Default.GetPopupScreenData
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@REQ_SEQ", REQ_SEQ);
            
            return WebUtility.Post(url);
        }
        #endregion

    }
}
