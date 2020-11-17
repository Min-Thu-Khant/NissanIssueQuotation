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

    }
}
