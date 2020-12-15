using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    class frmIssueQuotationController
    {
        #region GetInititalData
        public DataTable GetInitialData(string COMPANY_NO_BOX, string REQ_SEQ, out Meta MetaData)
        {

            string url = Properties.Settings.Default.GetIssueQuotationInitialData
                                                    .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX)
                                                    .Replace("@REQ_SEQ", REQ_SEQ);
            return WebUtility.Get(url, out MetaData);
        }
        #endregion

        #region QuotationPreview
        public DataTable PreviewFunction(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string startDate, string expireDay, string strPeroidFrom, string strPeroidTo,
            string strExportInfo, string strContractPlan, string INITIAL_REMARK, string MONTHLY_REMARK, string PI_REMARK, string ORDER_REMARK)
        {
            string url = Properties.Settings.Default.PreviewQuotation;
            //convert list to json object
            String json = JsonConvert.SerializeObject(new
            {
                COMPANY_NAME = COMPANY_NAME,
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_SEQ = REQ_SEQ,
                TaxAmt = TaxAmt,
                startDate = startDate,
                expireDate = expireDay,
                strPeroidFrom = strPeroidFrom,
                strPeroidTo = strPeroidTo,
                strExportInfo = strExportInfo,
                strContractPlan = strContractPlan,
                INITIAL_REMARK = INITIAL_REMARK,
                MONTHLY_REMARK = MONTHLY_REMARK,
                PI_REMARK = PI_REMARK,
                ORDER_REMARK = ORDER_REMARK
            });

            return WebUtility.Post(url, json);
        }
        #endregion

    }
}
