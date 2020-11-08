using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    #region BOL_InvoiceInfo
    public class BOL_INVOICE_INFO
    {
        #region private

        private string _COMPANY_NO_BOX;
        private string _TRANSACTION_TYPE;
        private string _YEAR_MONTH;
        private DateTime? _INVOICE_DATE;
        private string _BILL_HONORIFIC;
        private decimal _BILL_AMOUNT;
        private decimal _BILL_TAX;
        private decimal _BILL_PRICE;
        private DateTime? _BILL_PAYMENT_DATE;
        private DateTime? _STATUS_PRINT;
        private string _STATUS_MEMO;
        private DateTime? _STATUS_SEND;
        private char _STATUS_MAIL_DATE;
        private DateTime? _STATUS_ACC_RECEIVABLE_DATE;
        private DateTime? _STATUS_INVOCE_COPY_DATE;
        private DateTime? _STATUS_ACTUAL_MDB_UPDATE;
        private string _STATUS_ACTUAL_DEPOSIT_YYMM;
        private string _STATUS_ACTUAL_DEPOSIT_DATE;
        private string _STATUS_CASH_FORECAST_MM;
        private string _STATUS_PLAN_DEPOSIT_YYMM;
        private DateTime? _STATUS_PAY_NOTICE_DATE;
        private int _TYPE_OF_ALLOCATION;
        private decimal _ALLOCATION_TOTAL_AMOUNT;
        private int _DUNNING_COUNT;
        private DateTime? _DUNNING_DATE;
        private DateTime? _ANSWER_DATE;
        private DateTime? _PAYMENT_DUE_DATE;
        private string _ANSWER_MEMO;
        private char _NCS_CUSTOMER_CODE;
        private string _BILL_SUPPLIER_NAME;
        private string _BILL_SUPPLIER_NAME_READING;
        private string _BILL_COMPANY_NAME;
        private string _BILL_DEPARTMENT_IN_CHARGE;
        private string _BILL_CONTACT_NAME;
        private string _BILL_POSTAL_CODE;
        private string _BILL_ADDRESS;
        private string _BILL_ADDRESS_2;
        private string _BILL_DEPOSIT_RULES;
        private decimal _BILL_TRANSFER_FEE;
        private decimal _BILL_EXPENSES;
        private int _PLAN_SERVER;
        private int _PLAN_SERVER_LIGHT;
        private int _PLAN_BROWSER_AUTO;
        private int _PLAN_BROWSER;
        private int _PLAN_AMIGO_CAI;
        private int _PLAN_AMIGO_BIZ;
        private int _PLAN_ADD_BOX_SERVER;
        private int _PLAN_ADD_BOX_BROWSER;
        private int _PLAN_OP_FLAT;
        private int _PLAN_OP_SSL;
        private int _PLAN_OP_BASIC_SERVICE;
        private int _PLAN_OP_ADD_SERVICE;
        private int _PLAN_OP_SOCIOS;
        private DateTime? _ALLOCATED_COMPLETION_DATE;

        #endregion

        #region Encapsulation

        public string COMPANY_NO_BOX { get { return _COMPANY_NO_BOX; } set { _COMPANY_NO_BOX = value; } }
        public string TRANSACTION_TYPE { get { return _TRANSACTION_TYPE; } set { _TRANSACTION_TYPE = value; } }
        public string YEAR_MONTH { get { return _YEAR_MONTH; } set { _YEAR_MONTH = value; } }
        public DateTime? INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
        public string BILL_HONORIFIC { get { return _BILL_HONORIFIC; } set { _BILL_HONORIFIC = value; } }
        public decimal BILL_AMOUNT { get { return _BILL_AMOUNT; } set { _BILL_AMOUNT = value; } }
        public decimal BILL_TAX { get { return _BILL_TAX; } set { _BILL_TAX = value; } }
        public decimal BILL_PRICE { get { return _BILL_PRICE; } set { _BILL_PRICE = value; } }
        public DateTime? BILL_PAYMENT_DATE { get { return _BILL_PAYMENT_DATE; } set { _BILL_PAYMENT_DATE = value; } }
        public DateTime? STATUS_PRINT { get { return _STATUS_PRINT; } set { _STATUS_PRINT = value; } }
        public string STATUS_MEMO { get { return _STATUS_MEMO; } set { _STATUS_MEMO = value; } }
        public DateTime? STATUS_SEND { get { return _STATUS_SEND; } set { _STATUS_SEND = value; } }
        public char STATUS_MAIL_DATE { get { return _STATUS_MAIL_DATE; } set { _STATUS_MAIL_DATE = value; } }
        public DateTime? STATUS_ACC_RECEIVABLE_DATE { get { return _STATUS_ACC_RECEIVABLE_DATE; } set { _STATUS_ACC_RECEIVABLE_DATE = value; } }
        public DateTime? STATUS_INVOCE_COPY_DATE { get { return _STATUS_INVOCE_COPY_DATE; } set { _STATUS_INVOCE_COPY_DATE = value; } }
        public DateTime? STATUS_ACTUAL_MDB_UPDATE { get { return _STATUS_ACTUAL_MDB_UPDATE; } set { _STATUS_ACTUAL_MDB_UPDATE = value; } }
        public string STATUS_ACTUAL_DEPOSIT_YYMM { get { return _STATUS_ACTUAL_DEPOSIT_YYMM; } set { _STATUS_ACTUAL_DEPOSIT_YYMM = value; } }
        public string STATUS_ACTUAL_DEPOSIT_DATE { get { return _STATUS_ACTUAL_DEPOSIT_DATE; } set { _STATUS_ACTUAL_DEPOSIT_DATE = value; } }
        public string STATUS_CASH_FORECAST_MM { get { return _STATUS_CASH_FORECAST_MM; } set { _STATUS_CASH_FORECAST_MM = value; } }
        public string STATUS_PLAN_DEPOSIT_YYMM { get { return _STATUS_PLAN_DEPOSIT_YYMM; } set { _STATUS_PLAN_DEPOSIT_YYMM = value; } }
        public DateTime? STATUS_PAY_NOTICE_DATE { get { return _STATUS_PAY_NOTICE_DATE; } set { _STATUS_PAY_NOTICE_DATE = value; } }
        public int TYPE_OF_ALLOCATION { get { return _TYPE_OF_ALLOCATION; } set { _TYPE_OF_ALLOCATION = value; } }
        public decimal ALLOCATION_TOTAL_AMOUNT { get { return _ALLOCATION_TOTAL_AMOUNT; } set { _ALLOCATION_TOTAL_AMOUNT = value; } }
        public int DUNNING_COUNT { get { return _DUNNING_COUNT; } set { _DUNNING_COUNT = value; } }
        public DateTime? DUNNING_DATE { get { return _DUNNING_DATE; } set { _DUNNING_DATE = value; } }
        public DateTime? ANSWER_DATE { get { return _ANSWER_DATE; } set { _ANSWER_DATE = value; } }
        public DateTime? PAYMENT_DUE_DATE { get { return _PAYMENT_DUE_DATE; } set { _PAYMENT_DUE_DATE = value; } }
        public string ANSWER_MEMO { get { return _ANSWER_MEMO; } set { _ANSWER_MEMO = value; } }
        public string BILL_SUPPLIER_NAME { get { return _BILL_SUPPLIER_NAME; } set { _BILL_SUPPLIER_NAME = value; } }
        public string BILL_SUPPLIER_NAME_READING { get { return _BILL_SUPPLIER_NAME_READING; } set { _BILL_SUPPLIER_NAME_READING = value; } }
        public string BILL_COMPANY_NAME { get { return _BILL_COMPANY_NAME; } set { _BILL_COMPANY_NAME = value; } }
        public string BILL_DEPARTMENT_IN_CHARGE { get { return _BILL_DEPARTMENT_IN_CHARGE; } set { _BILL_DEPARTMENT_IN_CHARGE = value; } }
        public string BILL_CONTACT_NAME { get { return _BILL_CONTACT_NAME; } set { _BILL_CONTACT_NAME = value; } }
        public string BILL_POSTAL_CODE { get { return _BILL_POSTAL_CODE; } set { _BILL_POSTAL_CODE = value; } }
        public string BILL_ADDRESS { get { return _BILL_ADDRESS; } set { _BILL_ADDRESS = value; } }
        public string BILL_ADDRESS_2 { get { return _BILL_ADDRESS_2; } set { _BILL_ADDRESS_2 = value; } }
        public char NCS_CUSTOMER_CODE { get { return _NCS_CUSTOMER_CODE; } set { _NCS_CUSTOMER_CODE = value; } }
        public string BILL_DEPOSIT_RULES { get { return _BILL_DEPOSIT_RULES; } set { _BILL_DEPOSIT_RULES = value; } }
        public decimal BILL_TRANSFER_FEE { get { return _BILL_TRANSFER_FEE; } set { _BILL_TRANSFER_FEE = value; } }
        public decimal BILL_EXPENSES { get { return _BILL_EXPENSES; } set { _BILL_EXPENSES = value; } }
        public int PLAN_SERVER { get { return _PLAN_SERVER; } set { _PLAN_SERVER = value; } }
        public int PLAN_SERVER_LIGHT { get { return _PLAN_SERVER_LIGHT; } set { _PLAN_SERVER_LIGHT = value; } }
        public int PLAN_BROWSER_AUTO { get { return _PLAN_BROWSER_AUTO; } set { _PLAN_BROWSER_AUTO = value; } }
        public int PLAN_BROWSER { get { return _PLAN_BROWSER; } set { _PLAN_BROWSER = value; } }
        public int PLAN_AMIGO_CAI { get { return _PLAN_AMIGO_CAI; } set { _PLAN_AMIGO_CAI = value; } }
        public int PLAN_AMIGO_BIZ { get { return _PLAN_AMIGO_BIZ; } set { _PLAN_AMIGO_BIZ = value; } }
        public int PLAN_ADD_BOX_SERVER { get { return _PLAN_ADD_BOX_SERVER; } set { _PLAN_ADD_BOX_SERVER = value; } }
        public int PLAN_ADD_BOX_BROWSER { get { return _PLAN_ADD_BOX_BROWSER; } set { _PLAN_ADD_BOX_BROWSER = value; } }
        public int PLAN_OP_FLAT { get { return _PLAN_OP_FLAT; } set { _PLAN_OP_FLAT = value; } }
        public int PLAN_OP_SSL { get { return _PLAN_OP_SSL; } set { _PLAN_OP_SSL = value; } }
        public int PLAN_OP_BASIC_SERVICE { get { return _PLAN_OP_BASIC_SERVICE; } set { _PLAN_OP_BASIC_SERVICE = value; } }
        public int PLAN_OP_ADD_SERVICE { get { return _PLAN_OP_ADD_SERVICE; } set { _PLAN_OP_ADD_SERVICE = value; } }
        public int PLAN_OP_SOCIOS { get { return _PLAN_OP_SOCIOS; } set { _PLAN_OP_SOCIOS = value; } }

        public DateTime? ALLOCATED_COMPLETION_DATE { get { return _ALLOCATED_COMPLETION_DATE; } set { _ALLOCATED_COMPLETION_DATE = value; } }

        #endregion

        #region Constructors

        public BOL_INVOICE_INFO()
        {
            _TRANSACTION_TYPE = "";
            _COMPANY_NO_BOX = "";
            _YEAR_MONTH = "";
            _INVOICE_DATE = null;
            _NCS_CUSTOMER_CODE = '\0';
            _BILL_SUPPLIER_NAME = "";
            _BILL_SUPPLIER_NAME_READING = "";
            _BILL_COMPANY_NAME = "";
            _BILL_DEPARTMENT_IN_CHARGE = "";
            _BILL_CONTACT_NAME = "";
            _BILL_HONORIFIC = "";
            _BILL_POSTAL_CODE = "";
            _BILL_ADDRESS = "";
            _BILL_ADDRESS_2 = "";
            _PLAN_SERVER = 0;
            _PLAN_SERVER_LIGHT = 0;
            _PLAN_BROWSER_AUTO = 0;
            _PLAN_BROWSER = 0;
            _PLAN_AMIGO_CAI = 0;
            _PLAN_AMIGO_BIZ = 0;
            _PLAN_ADD_BOX_SERVER = 0;
            _PLAN_ADD_BOX_BROWSER = 0;
            _PLAN_OP_FLAT = 0;
            _PLAN_OP_SSL = 0;
            _PLAN_OP_BASIC_SERVICE = 0;
            _PLAN_OP_ADD_SERVICE = 0;
            _PLAN_OP_SOCIOS = 0;
            _BILL_DEPOSIT_RULES = "";
            _BILL_AMOUNT = 0;
            _BILL_TAX = 0;
            _BILL_PRICE = 0;
            _BILL_TRANSFER_FEE = 0;
            _BILL_EXPENSES = 0;
            _BILL_PAYMENT_DATE = null;
            _STATUS_PRINT = null;
            _STATUS_MEMO = "";
            _STATUS_SEND = null;
            _STATUS_MAIL_DATE = '\0';
            _STATUS_ACC_RECEIVABLE_DATE = null;
            _STATUS_INVOCE_COPY_DATE = null;
            _STATUS_ACTUAL_MDB_UPDATE = null;
            _STATUS_ACTUAL_DEPOSIT_YYMM = "";
            _STATUS_ACTUAL_DEPOSIT_DATE = null;
            _STATUS_CASH_FORECAST_MM = "";
            _STATUS_PLAN_DEPOSIT_YYMM = "";
            _STATUS_PAY_NOTICE_DATE = null;
            _TYPE_OF_ALLOCATION = 0;
            _ALLOCATION_TOTAL_AMOUNT = 0;
            _DUNNING_COUNT = 0;
            _DUNNING_DATE = null;
            _ANSWER_DATE = null;
            _PAYMENT_DUE_DATE = null;
            _ANSWER_MEMO = "";
            ALLOCATED_COMPLETION_DATE = null;
        }

        #endregion
    }
    #endregion
}
