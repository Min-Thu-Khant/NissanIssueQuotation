using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using Newtonsoft.Json;
using System.Data;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmApplicationApprovalController
    {
        #region GetInitialData
        public DataSet GetInitialData(string COMPANY_NO_BOX, string REQ_SEQ, string REQ_STATUS, string REQ_TYPE)
        {

            string url = Properties.Settings.Default.ApplicationApproval_GetInitialData;
            //convert list to json object
            string json = JsonConvert.SerializeObject(new
            {
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_SEQ = REQ_SEQ,
                REQ_STATUS = REQ_STATUS,
                REQ_TYPE = REQ_TYPE
            });

            return  WebUtility.Post(url, json, true);
        }
        #endregion

        #region Approve
        public DataSet Approve(string COMPANY_NO_BOX, string REQ_TYPE, string REQ_TYPE_RAW, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, string LIST)
        {

            string url = Properties.Settings.Default.ApplicationApproval_Approve;
            //convert list to json object
            string json = JsonConvert.SerializeObject(new
            {
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_TYPE = REQ_TYPE,
                REQ_TYPE_RAW = REQ_TYPE_RAW,
                CHANGED_ITEMS = CHANGED_ITEMS,
                SYSTEM_EFFECTIVE_DATE = SYSTEM_EFFECTIVE_DATE,
                SYSTEM_REGIST_DEADLINE = SYSTEM_REGIST_DEADLINE,
                LIST = LIST
            });

            return WebUtility.Post(url, json, true);
        }
        #endregion

        #region Disapprove
        public DataSet Disapprove(string COMPANY_NO_BOX,string REQ_TYPE, string CHANGED_ITEMS, string SYSTEM_EFFECTIVE_DATE, string SYSTEM_REGIST_DEADLINE, string LIST)
        {

            string url = Properties.Settings.Default.ApplicationApproval_Disapprove;
            //convert list to json object
            string json = JsonConvert.SerializeObject(new
            {
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_TYPE = REQ_TYPE,
                CHANGED_ITEMS = CHANGED_ITEMS,
                SYSTEM_EFFECTIVE_DATE = SYSTEM_EFFECTIVE_DATE,
                SYSTEM_REGIST_DEADLINE = SYSTEM_REGIST_DEADLINE,
                LIST = LIST
            });

            return WebUtility.Post(url, json, true);
        }
        #endregion

        #region ApproveCancel
        public DataSet ApproveCancel(string COMPANY_NO_BOX, string REQ_SEQ, string LIST)
        {

            string url = Properties.Settings.Default.ApplicationApproval_ApproveCancel;
            //convert list to json object
            string json = JsonConvert.SerializeObject(new
            {
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_SEQ = REQ_SEQ,
                LIST = LIST
            });

            return WebUtility.Post(url, json, true);
        }
        #endregion
    }
}
