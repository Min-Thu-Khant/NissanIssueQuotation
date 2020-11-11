using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_REQUEST_DETAIL
    public class BOL_REQUEST_DETAIL
    {
        private string _COMPANY_NO_BOX;
        public string COMPANY_NO_BOX
        {
            get { return _COMPANY_NO_BOX; }
            set { _COMPANY_NO_BOX = value; }
        }

        private int _REQ_SEQ;
        public int REQ_SEQ
        {
            get { return _REQ_SEQ; }
            set { _REQ_SEQ = value; }
        }

        private string _COMPANY_NAME;
        public string COMPANY_NAME
        {
            get { return _COMPANY_NAME; }
            set { _COMPANY_NAME = value; }
        }

        private string _COMPANY_NAME_READING;
        public string COMPANY_NAME_READING
        {
            get { return _COMPANY_NAME_READING; }
            set { _COMPANY_NAME_READING = value; }
        }

        private DateTime? _REQ_DATE;
        public DateTime? REQ_DATE
        {
            get { return _REQ_DATE; }
            set { _REQ_DATE = value; }
        }

        private int _TRANSACTION_TYPE;
        public int TRANSACTION_TYPE
        {
            get { return _TRANSACTION_TYPE; }
            set { _TRANSACTION_TYPE = value; }
        }

        private int _REQ_TYPE;
        public int REQ_TYPE
        {
            get { return _REQ_TYPE; }
            set { _REQ_TYPE = value; }
        }

        private int _REQ_STATUS;
        public int REQ_STATUS
        {
            get { return _REQ_STATUS; }
            set { _REQ_STATUS = value; }
        }

        private DateTime _START_USE_DATE;
        public DateTime START_USE_DATE
        {
            get { return _START_USE_DATE; }
            set { _START_USE_DATE = value; }
        }

        private DateTime _INPUT_DATE;
        public DateTime INPUT_DATE
        {
            get { return _INPUT_DATE; }
            set { _INPUT_DATE = value; }
        }

        private string _INPUT_PERSON;
        public string INPUT_PERSON
        {
            get { return _INPUT_PERSON; }
            set { _INPUT_PERSON = value; }
        }

        private DateTime? _SYSTEM_REGIST_DEADLINE;
        public DateTime? SYSTEM_REGIST_DEADLINE
        {
            get { return _SYSTEM_REGIST_DEADLINE; }
            set { _SYSTEM_REGIST_DEADLINE = value; }
        }

        private string _NML_CODE_NISSAN;
        public string NML_CODE_NISSAN
        {
            get { return _NML_CODE_NISSAN; }
            set { _NML_CODE_NISSAN = value; }
        }

        private string _NML_CODE_NS;
        public string NML_CODE_NS
        {
            get { return _NML_CODE_NS; }
            set { _NML_CODE_NS = value; }
        }

        private string _NML_CODE_JATCO;
        public string NML_CODE_JATCO
        {
            get { return _NML_CODE_JATCO; }
            set { _NML_CODE_JATCO = value; }
        }

        private string _NML_CODE_AK;
        public string NML_CODE_AK
        {
            get { return _NML_CODE_AK; }
            set { _NML_CODE_AK = value; }
        }

        private string _NML_CODE_NK;
        public string NML_CODE_NK
        {
            get { return _NML_CODE_NK; }
            set { _NML_CODE_NK = value; }
        }

        private string _BILL_SUPPLIER_NAME;
        public string BILL_SUPPLIER_NAME
        {
            get { return _BILL_SUPPLIER_NAME; }
            set { _BILL_SUPPLIER_NAME = value; }
        }

        private string _BILL_SUPPLIER_NAME_READING;
        public string BILL_SUPPLIER_NAME_READING
        {
            get { return _BILL_SUPPLIER_NAME_READING; }
            set { _BILL_SUPPLIER_NAME_READING = value; }
        }

        private string _BILL_METHOD;
        public string BILL_METHOD
        {
            get { return _BILL_METHOD; }
            set { _BILL_METHOD = value; }
        }

        private string _DATA_CHANGE_BOX;
        public string DATA_CHANGE_BOX
        {
            get { return _DATA_CHANGE_BOX; }
            set { _DATA_CHANGE_BOX = value; }
        }

        private string _CAI_SERVER_IP_ADDRESS;
        public string CAI_SERVER_IP_ADDRESS
        {
            get { return _CAI_SERVER_IP_ADDRESS; }
            set { _CAI_SERVER_IP_ADDRESS = value; }
        }

        private int _CAI_NETWORK;
        public int CAI_NETWORK
        {
            get { return _CAI_NETWORK; }
            set { _CAI_NETWORK = value; }
        }

        private int _CONTRACT_CSP;
        public int CONTRACT_CSP
        {
            get { return _CONTRACT_CSP; }
            set { _CONTRACT_CSP = value; }
        }

        private string _CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS;
        public string CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS
        {
            get { return _CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS; }
            set { _CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS = value; }
        }

        private int _PLAN_AMIGO_CAI;
        public int PLAN_AMIGO_CAI
        {
            get { return _PLAN_AMIGO_CAI; }
            set { _PLAN_AMIGO_CAI = value; }
        }

        private string _PLAN_AMIGO_BIZ_USE;
        public string PLAN_AMIGO_BIZ_USE
        {
            get { return _PLAN_AMIGO_BIZ_USE; }
            set { _PLAN_AMIGO_BIZ_USE = value; }
        }

        private int _PLAN_AMIGO_BIZ;
        public int PLAN_AMIGO_BIZ
        {
            get { return _PLAN_AMIGO_BIZ; }
            set { _PLAN_AMIGO_BIZ = value; }
        }

        private int _EXTENDED_BOX;
        public int EXTENDED_BOX
        {
            get { return _EXTENDED_BOX; }
            set { _EXTENDED_BOX = value; }
        }

        private string _PDF_PRINT;
        public string PDF_PRINT
        {
            get { return _PDF_PRINT; }
            set { _PDF_PRINT = value; }
        }

        private decimal _INITIAL_COST;
        public decimal INITIAL_COST
        {
            get { return _INITIAL_COST; }
            set { _INITIAL_COST = value; }
        }

        private decimal _INITIAL_COST_DISCOUNTS;
        public decimal INITIAL_COST_DISCOUNTS
        {
            get { return _INITIAL_COST_DISCOUNTS; }
            set { _INITIAL_COST_DISCOUNTS = value; }
        }

        private decimal _INITIAL_COST_INCLUDING_TAX;
        public decimal INITIAL_COST_INCLUDING_TAX
        {
            get { return _INITIAL_COST_INCLUDING_TAX; }
            set { _INITIAL_COST_INCLUDING_TAX = value; }
        }

        private decimal _MONTHLY_COST;
        public decimal MONTHLY_COST
        {
            get { return _MONTHLY_COST; }
            set { _MONTHLY_COST = value; }
        }

        private decimal _MONTHLY_COST_DISCOUNTS;
        public decimal MONTHLY_COST_DISCOUNTS
        {
            get { return _MONTHLY_COST_DISCOUNTS; }
            set { _MONTHLY_COST_DISCOUNTS = value; }
        }

        private decimal _MONTHLY_COST_INCLUDING_TAX;
        public decimal MONTHLY_COST_INCLUDING_TAX
        {
            get { return _MONTHLY_COST_INCLUDING_TAX; }
            set { _MONTHLY_COST_INCLUDING_TAX = value; }
        }

        private decimal _YEAR_COST;
        public decimal YEAR_COST
        {
            get { return _YEAR_COST; }
            set { _YEAR_COST = value; }
        }

        private decimal _YEAR_COST_DISCOUNTS;
        public decimal YEAR_COST_DISCOUNTS
        {
            get { return _YEAR_COST_DISCOUNTS; }
            set { _YEAR_COST_DISCOUNTS = value; }
        }

        private decimal _YEAR_COST_INCLUDING_TAX;
        public decimal YEAR_COST_INCLUDING_TAX
        {
            get { return _YEAR_COST_INCLUDING_TAX; }
            set { _YEAR_COST_INCLUDING_TAX = value; }
        }

        private int _TAX;
        public int TAX
        {
            get { return _TAX; }
            set { _TAX = value; }
        }

        private string _MONTHLY_COST_APPLY_DATE;
        public string MONTHLY_COST_APPLY_DATE
        {
            get { return _MONTHLY_COST_APPLY_DATE; }
            set { _MONTHLY_COST_APPLY_DATE = value; }
        }

        private DateTime? _QUOTATION_DATE;
        public DateTime? QUOTATION_DATE
        {
            get { return _QUOTATION_DATE; }
            set { _QUOTATION_DATE = value; }
        }

        private DateTime? _ORDER_DATE;
        public DateTime? ORDER_DATE
        {
            get { return _ORDER_DATE; }
            set { _ORDER_DATE = value; }
        }

        private DateTime? _SYSTEM_EFFECTIVE_DATE;
        public DateTime? SYSTEM_EFFECTIVE_DATE
        {
            get { return _SYSTEM_EFFECTIVE_DATE; }
            set { _SYSTEM_EFFECTIVE_DATE = value; }
        }

        private int _SYSTEM_SETTING_STATUS;
        public int SYSTEM_SETTING_STATUS
        {
            get { return _SYSTEM_SETTING_STATUS; }
            set { _SYSTEM_SETTING_STATUS = value; }
        }

        private DateTime? _COMPLETION_NOTIFICATION_DATE;
        public DateTime? COMPLETION_NOTIFICATION_DATE
        {
            get { return _COMPLETION_NOTIFICATION_DATE; }
            set { _COMPLETION_NOTIFICATION_DATE = value; }
        }

        private int _AMIGO_COOPERATION;
        public int AMIGO_COOPERATION
        {
            get { return _AMIGO_COOPERATION; }
            set { _AMIGO_COOPERATION = value; }
        }

        private string _AMIGO_COOPERATION_CHENGED_ITEMS;
        public string AMIGO_COOPERATION_CHENGED_ITEMS
        {
            get { return _AMIGO_COOPERATION_CHENGED_ITEMS; }
            set { _AMIGO_COOPERATION_CHENGED_ITEMS = value; }
        }

        private string _CLOSE_FLG;
        public string CLOSE_FLG
        {
            get { return _CLOSE_FLG; }
            set { _CLOSE_FLG = value; }
        }

        private string _CREATED_AT;
        public string CREATED_AT
        {
            get { return _CREATED_AT; }
            set { _CREATED_AT = value; }
        }

        private string _CREATED_BY;
        public string CREATED_BY
        {
            get { return _CREATED_BY; }
            set { _CREATED_BY = value; }
        }

        private string _UPDATED_AT;
        public string UPDATED_AT
        {
            get { return _UPDATED_AT; }
            set { _UPDATED_AT = value; }
        }

        private string _UPDATED_AT_RAW;
        public string UPDATED_AT_RAW
        {
            get { return _UPDATED_AT_RAW; }
            set { _UPDATED_AT_RAW = value; }
        }

        private string _UPDATED_BY;
        public string UPDATED_BY
        {
            get { return _UPDATED_BY; }
            set { _UPDATED_BY = value; }
        }
    }
    #endregion

}
