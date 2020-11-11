using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers
{ 
    class frmIssuQuotationPreviewController
    {
        #region GetQuotationMail
        public DataTable GetQuotationMail(string COMPANY_NO_BOX, string REQ_SEQ, string CONSUMPTION_TAX, string INITIAL_SPECIAL_DISCOUNTS, string MONTHLY_SPECIAL_DISCOUNTS, string YEARLY_SPECIAL_DISCOUNT, 
                                          string INPUT_PERSON, string ExportInfo, string CONTRACT_PLAN, string CREATED_TIME)
        {
            string url = Properties.Settings.Default.QuotationMailCreate;
            //convert list to json object
            String json = JsonConvert.SerializeObject(new
            {
                COMPANY_NO_BOX = COMPANY_NO_BOX,
                REQ_SEQ = REQ_SEQ,
                CONSUMPTION_TAX = string.IsNullOrEmpty(CONSUMPTION_TAX) ? "0": CONSUMPTION_TAX,
                INITIAL_SPECIAL_DISCOUNTS = string.IsNullOrEmpty(INITIAL_SPECIAL_DISCOUNTS) ? "0" : INITIAL_SPECIAL_DISCOUNTS,
                MONTHLY_SPECIAL_DISCOUNTS = string.IsNullOrEmpty(MONTHLY_SPECIAL_DISCOUNTS) ? "0" : MONTHLY_SPECIAL_DISCOUNTS,
                YEARLY_SPECIAL_DISCOUNT = string.IsNullOrEmpty(YEARLY_SPECIAL_DISCOUNT) ? "0" : YEARLY_SPECIAL_DISCOUNT,
                INPUT_PERSON = INPUT_PERSON,
                ExportInfo = ExportInfo,
                CONTRACT_PLAN = CONTRACT_PLAN.Trim(),
                CREATED_TIME = CREATED_TIME
            });
            return WebUtility.Post(url, json);

        }
        #endregion
    }
}
