using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    #region BOL_CUSTOMER_MASTER
    public class BOL_CUSTOMER_MASTER
    {
        #region private
        private string _COMPANY_NO_BOX;
        private int _TRANSACTION_TYPE;
        private DateTime? _EFFECTIVE_DATE;
        private int _UPDATE_CONTENT;
        private string _COMPANY_NAME;
        private string _COMPANY_NAME_READING;
        private DateTime? _ESTIMATED_SUBMISSION_DATE;
        private DateTime? _CONTRACT_DATE;
        private DateTime? _COMPLETION_NOTE_SENDING_DATE;
        private string _CONTRACTOR_DEPARTMENT_IN_CHARGE;
        private string _CONTRACTOR_CONTACT_NAME;
        private string _CONTRACTOR_CONTACT_NAME_READING;
        private char _CONTRACTOR_POSTAL_CODE;
        private string _CONTRACTOR_ADDRESS;
        private string _CONTRACTOR_ADDRESS_2;
        private string _CONTRACTOR_MAIL_ADDRESS;
        private string _CONTRACTOR_PHONE_NUMBER;
        private string _BILL_SUPPLIER_NAME;
        private string _BILL_SUPPLIER_NAME_READING;
        private char _BILL_COMPANY_NAME;
        private string _BILL_DEPARTMENT_IN_CHARGE;
        private string _BILL_CONTACT_NAME;
        private string _BILL_CONTACT_NAME_READING;
        private char _BILL_POSTAL_CODE;
        private string _BILL_ADDRESS;
        private string _BILL_ADDRESS_2;
        private string _BILL_MAIL_ADDRESS;
        private string _BILL_PHONE_NUMBER;
        private string _NCS_CUSTOMER_CODE;
        private string _BILL_BANK_ACCOUNT_NAME_1;
        private string _BILL_BANK_ACCOUNT_NAME_2;
        private string _BILL_BANK_ACCOUNT_NAME_3;
        private string _BILL_BANK_ACCOUNT_NAME_4;
        private char _BILL_BANK_ACCOUNT_NUMBER_1;
        private char _BILL_BANK_ACCOUNT_NUMBER_2;
        private char _BILL_BANK_ACCOUNT_NUMBER_3;
        private char _BILL_BANK_ACCOUNT_NUMBER_4;
        private int _BILL_BILLING_INTERVAL;
        private int _BILL_DEPOSIT_RULES;
        private decimal _BILL_TRANSFER_FEE;
        private decimal _BILL_EXPENSES;
        private int _PLAN_SERVER;
        private int _PLAN_SERVER_LIGHT;
        private int _PLAN_BROWSER_AUTO;
        private int _PLAN_BROWSER;
        private decimal _PLAN_INITIAL_COST;
        private decimal _PLAN_MONTHLY_COST;
        private int _PLAN_AMIGO_CAI;
        private int _PLAN_AMIGO_BIZ;
        private int _PLAN_ADD_BOX_SERVER;
        private int _PLAN_ADD_BOX_BROWSER;
        private int _PLAN_OP_FLAT;
        private int _PLAN_OP_SSL;
        private int _PLAN_OP_BASIC_SERVICE;
        private int _PLAN_OP_ADD_SERVICE;
        private int _PLAN_OP_SOCIOS;
        private string _PREVIOUS_COMPANY_NAME;
        private char _NML_CODE_NISSAN;
        private char _NML_CODE_NS;
        private char _NML_CODE_JATCO;
        private char _NML_CODE_AK;
        private char _NML_CODE_NK;
        private char _NML_CODE_OTHER;
        private DateTime? _UPDATE_DATE;
        private string _UPDATER_CODE;

        #endregion

        #region Encapsulation

        public string COMPANY_NO_BOX { get { return _COMPANY_NO_BOX; } set { _COMPANY_NO_BOX = value; } }
        public int TRANSACTION_TYPE { get { return _TRANSACTION_TYPE; } set { _TRANSACTION_TYPE = value; } }
        public DateTime? EFFECTIVE_DATE { get { return _EFFECTIVE_DATE; } set { _EFFECTIVE_DATE = value; } }
        public int UPDATE_CONTENT { get { return _UPDATE_CONTENT; } set { _UPDATE_CONTENT = value; } }
        public string COMPANY_NAME { get { return _COMPANY_NAME; } set { _COMPANY_NAME = value; } }
        public string COMPANY_NAME_READING { get { return _COMPANY_NAME_READING; } set { _COMPANY_NAME_READING = value; } }
        public DateTime? ESTIMATED_SUBMISSION_DATE { get { return _ESTIMATED_SUBMISSION_DATE; } set { _ESTIMATED_SUBMISSION_DATE = value; } }
        public DateTime? CONTRACT_DATE { get { return _CONTRACT_DATE; } set { _CONTRACT_DATE = value; } }
        public DateTime? COMPLETION_NOTE_SENDING_DATE { get { return _COMPLETION_NOTE_SENDING_DATE; } set { _COMPLETION_NOTE_SENDING_DATE = value; } }
        public string CONTRACTOR_DEPARTMENT_IN_CHARGE { get { return _CONTRACTOR_DEPARTMENT_IN_CHARGE; } set { _CONTRACTOR_DEPARTMENT_IN_CHARGE = value; } }
        public string CONTRACTOR_CONTACT_NAME { get { return _CONTRACTOR_CONTACT_NAME; } set { _CONTRACTOR_CONTACT_NAME = value; } }
        public string CONTRACTOR_CONTACT_NAME_READING { get { return _CONTRACTOR_CONTACT_NAME_READING; } set { _CONTRACTOR_CONTACT_NAME_READING = value; } }
        public char CONTRACTOR_POSTAL_CODE { get { return _CONTRACTOR_POSTAL_CODE; } set { _CONTRACTOR_POSTAL_CODE = value; } }
        public string CONTRACTOR_ADDRESS { get { return _CONTRACTOR_ADDRESS; } set { _CONTRACTOR_ADDRESS = value; } }
        public string CONTRACTOR_ADDRESS_2 { get { return _CONTRACTOR_ADDRESS_2; } set { _CONTRACTOR_ADDRESS_2 = value; } }
        public string CONTRACTOR_MAIL_ADDRESS { get { return _CONTRACTOR_MAIL_ADDRESS; } set { _CONTRACTOR_MAIL_ADDRESS = value; } }
        public string CONTRACTOR_PHONE_NUMBER { get { return _CONTRACTOR_PHONE_NUMBER; } set { _CONTRACTOR_PHONE_NUMBER = value; } }
        public string BILL_SUPPLIER_NAME { get { return _BILL_SUPPLIER_NAME; } set { _BILL_SUPPLIER_NAME = value; } }
        public string BILL_SUPPLIER_NAME_READING { get { return _BILL_SUPPLIER_NAME_READING; } set { _BILL_SUPPLIER_NAME_READING = value; } }
        public char BILL_COMPANY_NAME { get { return _BILL_COMPANY_NAME; } set { _BILL_COMPANY_NAME = value; } }
        public string BILL_DEPARTMENT_IN_CHARGE { get { return _BILL_DEPARTMENT_IN_CHARGE; } set { _BILL_DEPARTMENT_IN_CHARGE = value; } }
        public string BILL_CONTACT_NAME { get { return _BILL_CONTACT_NAME; } set { _BILL_CONTACT_NAME = value; } }
        public string BILL_CONTACT_NAME_READING { get { return _BILL_CONTACT_NAME_READING; } set { _BILL_CONTACT_NAME_READING = value; } }
        public char BILL_POSTAL_CODE { get { return _BILL_POSTAL_CODE; } set { _BILL_POSTAL_CODE = value; } }
        public string BILL_ADDRESS { get { return _BILL_ADDRESS; } set { _BILL_ADDRESS = value; } }
        public string BILL_ADDRESS_2 { get { return _BILL_ADDRESS_2; } set { _BILL_ADDRESS_2 = value; } }
        public string BILL_MAIL_ADDRESS { get { return _BILL_MAIL_ADDRESS; } set { _BILL_MAIL_ADDRESS = value; } }
        public string BILL_PHONE_NUMBER { get { return _BILL_PHONE_NUMBER; } set { _BILL_PHONE_NUMBER = value; } }
        public string NCS_CUSTOMER_CODE { get { return _NCS_CUSTOMER_CODE; } set { _NCS_CUSTOMER_CODE = value; } }
        public string BILL_BANK_ACCOUNT_NAME_1 { get { return _BILL_BANK_ACCOUNT_NAME_1; } set { _BILL_BANK_ACCOUNT_NAME_1 = value; } }
        public string BILL_BANK_ACCOUNT_NAME_2 { get { return _BILL_BANK_ACCOUNT_NAME_2; } set { _BILL_BANK_ACCOUNT_NAME_2 = value; } }
        public string BILL_BANK_ACCOUNT_NAME_3 { get { return _BILL_BANK_ACCOUNT_NAME_3; } set { _BILL_BANK_ACCOUNT_NAME_3 = value; } }
        public string BILL_BANK_ACCOUNT_NAME_4 { get { return _BILL_BANK_ACCOUNT_NAME_4; } set { _BILL_BANK_ACCOUNT_NAME_4 = value; } }
        public char BILL_BANK_ACCOUNT_NUMBER_1 { get { return _BILL_BANK_ACCOUNT_NUMBER_1; } set { _BILL_BANK_ACCOUNT_NUMBER_1 = value; } }
        public char BILL_BANK_ACCOUNT_NUMBER_2 { get { return _BILL_BANK_ACCOUNT_NUMBER_2; } set { _BILL_BANK_ACCOUNT_NUMBER_2 = value; } }
        public char BILL_BANK_ACCOUNT_NUMBER_3 { get { return _BILL_BANK_ACCOUNT_NUMBER_3; } set { _BILL_BANK_ACCOUNT_NUMBER_3 = value; } }
        public char BILL_BANK_ACCOUNT_NUMBER_4 { get { return _BILL_BANK_ACCOUNT_NUMBER_4; } set { _BILL_BANK_ACCOUNT_NUMBER_4 = value; } }
        public int BILL_BILLING_INTERVAL { get { return _BILL_BILLING_INTERVAL; } set { _BILL_BILLING_INTERVAL = value; } }
        public int BILL_DEPOSIT_RULES { get { return _BILL_DEPOSIT_RULES; } set { _BILL_DEPOSIT_RULES = value; } }
        public decimal BILL_TRANSFER_FEE { get { return _BILL_TRANSFER_FEE; } set { _BILL_TRANSFER_FEE = value; } }
        public decimal BILL_EXPENSES { get { return _BILL_EXPENSES; } set { _BILL_EXPENSES = value; } }
        public int PLAN_SERVER { get { return _PLAN_SERVER; } set { _PLAN_SERVER = value; } }
        public int PLAN_SERVER_LIGHT { get { return _PLAN_SERVER_LIGHT; } set { _PLAN_SERVER_LIGHT = value; } }
        public int PLAN_BROWSER_AUTO { get { return _PLAN_BROWSER_AUTO; } set { _PLAN_BROWSER_AUTO = value; } }
        public int PLAN_BROWSER { get { return _PLAN_BROWSER; } set { _PLAN_BROWSER = value; } }
        public decimal PLAN_INITIAL_COST { get { return _PLAN_INITIAL_COST; } set { _PLAN_INITIAL_COST = value; } }
        public decimal PLAN_MONTHLY_COST { get { return _PLAN_MONTHLY_COST; } set { _PLAN_MONTHLY_COST = value; } }
        public int PLAN_AMIGO_CAI { get { return _PLAN_AMIGO_CAI; } set { _PLAN_AMIGO_CAI = value; } }
        public int PLAN_AMIGO_BIZ { get { return _PLAN_AMIGO_BIZ; } set { _PLAN_AMIGO_BIZ = value; } }
        public int PLAN_ADD_BOX_SERVER { get { return _PLAN_ADD_BOX_SERVER; } set { _PLAN_ADD_BOX_SERVER = value; } }
        public int PLAN_ADD_BOX_BROWSER { get { return _PLAN_ADD_BOX_BROWSER; } set { _PLAN_ADD_BOX_BROWSER = value; } }
        public int PLAN_OP_FLAT { get { return _PLAN_OP_FLAT; } set { _PLAN_OP_FLAT = value; } }
        public int PLAN_OP_SSL { get { return _PLAN_OP_SSL; } set { _PLAN_OP_SSL = value; } }
        public int PLAN_OP_BASIC_SERVICE { get { return _PLAN_OP_BASIC_SERVICE; } set { _PLAN_OP_BASIC_SERVICE = value; } }
        public int PLAN_OP_ADD_SERVICE { get { return _PLAN_OP_ADD_SERVICE; } set { _PLAN_OP_ADD_SERVICE = value; } }
        public int PLAN_OP_SOCIOS { get { return _PLAN_OP_SOCIOS; } set { _PLAN_OP_SOCIOS = value; } }
        public string PREVIOUS_COMPANY_NAME { get { return _PREVIOUS_COMPANY_NAME; } set { _PREVIOUS_COMPANY_NAME = value; } }
        public char NML_CODE_NISSAN { get { return _NML_CODE_NISSAN; } set { _NML_CODE_NISSAN = value; } }
        public char NML_CODE_NS { get { return _NML_CODE_NS; } set { _NML_CODE_NS = value; } }
        public char NML_CODE_JATCO { get { return _NML_CODE_JATCO; } set { _NML_CODE_JATCO = value; } }
        public char NML_CODE_AK { get { return _NML_CODE_AK; } set { _NML_CODE_AK = value; } }
        public char NML_CODE_NK { get { return _NML_CODE_NK; } set { _NML_CODE_NK = value; } }
        public char NML_CODE_OTHER { get { return _NML_CODE_OTHER; } set { _NML_CODE_OTHER = value; } }
        public DateTime? UPDATE_DATE { get { return _UPDATE_DATE; } set { _UPDATE_DATE = value; } }
        public string UPDATER_CODE { get { return _UPDATER_CODE; } set { _UPDATER_CODE = value; } }

        #endregion

        #region Constructors

        public BOL_CUSTOMER_MASTER()
        {
            _COMPANY_NO_BOX = "";
            _TRANSACTION_TYPE = 0;
            _EFFECTIVE_DATE = null;
            _UPDATE_CONTENT = 0;
            _COMPANY_NAME = "";
            _COMPANY_NAME_READING = "";
            _ESTIMATED_SUBMISSION_DATE = null;
            _CONTRACT_DATE = null;
            _COMPLETION_NOTE_SENDING_DATE = null;
            _CONTRACTOR_DEPARTMENT_IN_CHARGE = "";
            _CONTRACTOR_CONTACT_NAME = "";
            _CONTRACTOR_CONTACT_NAME_READING = "";
            _CONTRACTOR_POSTAL_CODE = '\0';
            _CONTRACTOR_ADDRESS = "";
            _CONTRACTOR_ADDRESS_2 = "";
            _CONTRACTOR_MAIL_ADDRESS = "";
            _CONTRACTOR_PHONE_NUMBER = "";
            _BILL_SUPPLIER_NAME = "";
            _BILL_SUPPLIER_NAME_READING = "";
            _BILL_COMPANY_NAME = '\0';
            _BILL_DEPARTMENT_IN_CHARGE = "";
            _BILL_CONTACT_NAME = "";
            _BILL_CONTACT_NAME_READING = "";
            _BILL_POSTAL_CODE = '\0';
            _BILL_ADDRESS = "";
            _BILL_ADDRESS_2 = "";
            _BILL_MAIL_ADDRESS = "";
            _BILL_PHONE_NUMBER = "";
            _NCS_CUSTOMER_CODE = "";
            _BILL_BANK_ACCOUNT_NAME_1 = "";
            _BILL_BANK_ACCOUNT_NAME_2 = "";
            _BILL_BANK_ACCOUNT_NAME_3 = "";
            _BILL_BANK_ACCOUNT_NAME_4 = "";
            _BILL_BANK_ACCOUNT_NUMBER_1 = '\0';
            _BILL_BANK_ACCOUNT_NUMBER_2 = '\0';
            _BILL_BANK_ACCOUNT_NUMBER_3 = '\0';
            _BILL_BANK_ACCOUNT_NUMBER_4 = '\0';
            _BILL_BILLING_INTERVAL = 0;
            _BILL_DEPOSIT_RULES = 0;
            _BILL_TRANSFER_FEE = 0;
            _BILL_EXPENSES = 0;
            _PLAN_SERVER = 0;
            _PLAN_SERVER_LIGHT = 0;
            _PLAN_BROWSER_AUTO = 0;
            _PLAN_BROWSER = 0;
            _PLAN_INITIAL_COST = 0;
            _PLAN_MONTHLY_COST = 0;
            _PLAN_AMIGO_CAI = 0;
            _PLAN_AMIGO_BIZ = 0;
            _PLAN_ADD_BOX_SERVER = 0;
            _PLAN_ADD_BOX_BROWSER = 0;
            _PLAN_OP_FLAT = 0;
            _PLAN_OP_SSL = 0;
            _PLAN_OP_BASIC_SERVICE = 0;
            _PLAN_OP_ADD_SERVICE = 0;
            _PLAN_OP_SOCIOS = 0;
            _PREVIOUS_COMPANY_NAME = "";
            _NML_CODE_NISSAN = '\0';
            _NML_CODE_NS = '\0';
            _NML_CODE_JATCO = '\0';
            _NML_CODE_AK = '\0';
            _NML_CODE_NK = '\0';
            _NML_CODE_OTHER = '\0';
            _UPDATE_DATE = null;
            _UPDATER_CODE = "";
        }

        #endregion
    }
    #endregion
}
