using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    public class BOL_CUSTOMER_MASTER
    {
        public BOL_CUSTOMER_MASTER()
        {

        }
        public string COMPANY_NO_BOX { get; set; }
        public int TRANSACTION_TYPE { get; set; }
        public DateTime EFFECTIVE_DATE { get; set; }
        public int REQ_SEQ { get; set; }
        public int UPDATE_CONTENT { get; set; }
        public DateTime? CONTRACT_DATE { get; set; }
        public string SPECIAL_NOTES_1 { get; set; }
        public string SPECIAL_NOTES_2 { get; set; }
        public string SPECIAL_NOTES_3 { get; set; }
        public string SPECIAL_NOTES_4 { get; set; }
        public string NCS_CUSTOMER_CODE { get; set; }
        public int? BILL_BILLING_INTERVAL { get; set; }
        public int? BILL_DEPOSIT_RULES { get; set; }
        public decimal? BILL_TRANSFER_FEE { get; set; }
        public decimal? BILL_EXPENSES { get; set; }
        public DateTime? COMPANY_NAME_CHANGED_DATE { get; set; }
        public string PREVIOUS_COMPANY_NAME { get; set; }
        public DateTime? OBOEGAKI_DATE { get; set; }
        public DateTime? ORG_EFFECTIVE_DATE { get; set; }
        
        public string CREATED_AT { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        public string UPDATED_BY { get; set; }
    }
}
