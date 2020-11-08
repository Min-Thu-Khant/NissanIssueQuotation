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
        public DataTable PreviewFunction(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate, string expireDate, string strRemark, string strFromCertificate, string strToCertificate, string strExporType, string strFileHeader, string strContractPlan, decimal decDiscount)
        {
            string url = Properties.Settings.Default.PreviewQuotation;
            return WebUtility.PostQuotation(url, COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt, startDate, expireDate, strRemark, strFromCertificate, strToCertificate, strExporType, strFileHeader, strContractPlan, decDiscount);
        }
        #endregion

    }
}
