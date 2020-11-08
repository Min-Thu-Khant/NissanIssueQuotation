using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    #region BOL_RECEIPT_DETAILS
    public class BOL_RECEIPT_DETAILS
    {
        #region private

        private int _SEQ_NO;
        private int _DATA_CLASS;
        private string _RECORD_CLASS;
        private DateTime? _TRANSACTION_DATE;
        private string _TRANSACTION_CONTACT_NAME;
        private string _TRANSACTION_BANKS_NAME;
        private string _TRANSACTION_BRANCH_NAME;
        private string _TRANSACTION_ACCOUNT_NO_CLASS;
        private string _TRANSACTION_ACCOUNT_TYPE;
        private string _TRANSACTION_ACCOUNT_NO;
        private string _RESEND_INDICATION;
        private string _TRANSACTION_NAME;
        private string _TRANSACTION_NO;
        private string _TRANSACTION_DETAIL_CLASS;
        private DateTime? _HANDLING_DATE;
        private DateTime? _DEPOSIT_DATE;
        private decimal _DEPOSIT_AMOUNT;
        private string _CHECK_CLASS;
        private string _CUSTOMER_NAME;
        private int _COLLECTION_NO_SHEETS;
        private string _COLLECTION_NO;
        private string _CUSTOMER_NO;
        private string _BANK_NAME;
        private string _BRANCH_NAME;
        private string _TRANSFER_MESSAGE;
        private string _NOTE;
        private int _NUMBER;
        private string _TRANSACTION_FILE_NAME;
        private string _RUN_DATE_TIME;
        private int _RUN_RESULT;
        private string _DATA_MOVEMENT_INFORMATION;
        private DateTime? _PAYMENT_DAY;
        private int _TYPE_OF_ALLOCATION;
        private int _ALLOCATED_QUANTITY;
        private decimal _ALLOCATED_MONEY;
        private DateTime? _ALLOCATED_COMPLETION_DATE;

        #endregion

        #region Encapsulation

        public int SEQ_NO { get { return _SEQ_NO; } set { _SEQ_NO = value; } }
        public int DATA_CLASS { get { return _DATA_CLASS; } set { _DATA_CLASS = value; } }
        public string RECORD_CLASS { get { return _RECORD_CLASS; } set { _RECORD_CLASS = value; } }
        public DateTime? TRANSACTION_DATE { get { return _TRANSACTION_DATE; } set { _TRANSACTION_DATE = value; } }
        public string TRANSACTION_CONTACT_NAME { get { return _TRANSACTION_CONTACT_NAME; } set { _TRANSACTION_CONTACT_NAME = value; } }
        public string TRANSACTION_BANKS_NAME { get { return _TRANSACTION_BANKS_NAME; } set { _TRANSACTION_BANKS_NAME = value; } }
        public string TRANSACTION_BRANCH_NAME { get { return _TRANSACTION_BRANCH_NAME; } set { _TRANSACTION_BRANCH_NAME = value; } }
        public string TRANSACTION_ACCOUNT_NO_CLASS { get { return _TRANSACTION_ACCOUNT_NO_CLASS; } set { _TRANSACTION_ACCOUNT_NO_CLASS = value; } }
        public string TRANSACTION_ACCOUNT_TYPE { get { return _TRANSACTION_ACCOUNT_TYPE; } set { _TRANSACTION_ACCOUNT_TYPE = value; } }
        public string TRANSACTION_ACCOUNT_NO { get { return _TRANSACTION_ACCOUNT_NO; } set { _TRANSACTION_ACCOUNT_NO = value; } }
        public string RESEND_INDICATION { get { return _RESEND_INDICATION; } set { _RESEND_INDICATION = value; } }
        public string TRANSACTION_NAME { get { return _TRANSACTION_NAME; } set { _TRANSACTION_NAME = value; } }
        public string TRANSACTION_NO { get { return _TRANSACTION_NO; } set { _TRANSACTION_NO = value; } }
        public string TRANSACTION_DETAIL_CLASS { get { return _TRANSACTION_DETAIL_CLASS; } set { _TRANSACTION_DETAIL_CLASS = value; } }
        public DateTime? HANDLING_DATE { get { return _HANDLING_DATE; } set { _HANDLING_DATE = value; } }
        public DateTime? DEPOSIT_DATE { get { return _DEPOSIT_DATE; } set { _DEPOSIT_DATE = value; } }
        public decimal DEPOSIT_AMOUNT { get { return _DEPOSIT_AMOUNT; } set { _DEPOSIT_AMOUNT = value; } }
        public string CHECK_CLASS { get { return _CHECK_CLASS; } set { _CHECK_CLASS = value; } }
        public string CUSTOMER_NAME { get { return _CUSTOMER_NAME; } set { _CUSTOMER_NAME = value; } }
        public int COLLECTION_NO_SHEETS { get { return _COLLECTION_NO_SHEETS; } set { _COLLECTION_NO_SHEETS = value; } }
        public string COLLECTION_NO { get { return _COLLECTION_NO; } set { _COLLECTION_NO = value; } }
        public string CUSTOMER_NO { get { return _CUSTOMER_NO; } set { _CUSTOMER_NO = value; } }
        public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
        public string BRANCH_NAME { get { return _BRANCH_NAME; } set { _BRANCH_NAME = value; } }
        public string TRANSFER_MESSAGE { get { return _TRANSFER_MESSAGE; } set { _TRANSFER_MESSAGE = value; } }
        public string NOTE { get { return _NOTE; } set { _NOTE = value; } }
        public int NUMBER { get { return _NUMBER; } set { _NUMBER = value; } }
        public string TRANSACTION_FILE_NAME { get { return _TRANSACTION_FILE_NAME; } set { _TRANSACTION_FILE_NAME = value; } }
        public string RUN_DATE_TIME { get { return _RUN_DATE_TIME; } set { _RUN_DATE_TIME = value; } }
        public int RUN_RESULT { get { return _RUN_RESULT; } set { _RUN_RESULT = value; } }
        public string DATA_MOVEMENT_INFORMATION { get { return _DATA_MOVEMENT_INFORMATION; } set { _DATA_MOVEMENT_INFORMATION = value; } }
        public DateTime? PAYMENT_DAY { get { return _PAYMENT_DAY; } set { _PAYMENT_DAY = value; } }
        public int TYPE_OF_ALLOCATION { get { return _TYPE_OF_ALLOCATION; } set { _TYPE_OF_ALLOCATION = value; } }
        public int ALLOCATED_QUANTITY { get { return _ALLOCATED_QUANTITY; } set { _ALLOCATED_QUANTITY = value; } }
        public decimal ALLOCATED_MONEY { get { return _ALLOCATED_MONEY; } set { _ALLOCATED_MONEY = value; } }
        public DateTime? ALLOCATED_COMPLETION_DATE { get { return _ALLOCATED_COMPLETION_DATE; } set { _ALLOCATED_COMPLETION_DATE = value; } }

        #endregion

        #region Constructors

        public BOL_RECEIPT_DETAILS()
        {
            _SEQ_NO = 0;
            _DATA_CLASS = 0;
            _RECORD_CLASS = "";
            _TRANSACTION_DATE = null;
            _TRANSACTION_CONTACT_NAME = "";
            _TRANSACTION_BANKS_NAME = "";
            _TRANSACTION_BRANCH_NAME = "";
            _TRANSACTION_ACCOUNT_NO_CLASS = "";
            _TRANSACTION_ACCOUNT_TYPE = "";
            _TRANSACTION_ACCOUNT_NO = "";
            _RESEND_INDICATION = "";
            _TRANSACTION_NAME = "";
            _TRANSACTION_NO = "";
            _TRANSACTION_DETAIL_CLASS = "";
            _HANDLING_DATE = null;
            _DEPOSIT_DATE = null;
            _DEPOSIT_AMOUNT = 0;
            _CHECK_CLASS = "";
            _CUSTOMER_NAME = "";
            _COLLECTION_NO_SHEETS = 0;
            _COLLECTION_NO = "";
            _CUSTOMER_NO = "";
            _BANK_NAME = "";
            _BRANCH_NAME = "";
            _TRANSFER_MESSAGE = "";
            _NOTE = "";
            _NUMBER = 0;
            _TRANSACTION_FILE_NAME = "";
            _RUN_DATE_TIME = null;
            _RUN_RESULT = 0;
            _DATA_MOVEMENT_INFORMATION = "";
            _PAYMENT_DAY = null;
            _TYPE_OF_ALLOCATION = 0;
            _ALLOCATED_QUANTITY = 0;
            _ALLOCATED_MONEY = 0;
            _ALLOCATED_COMPLETION_DATE = null;
        }

        #endregion
    }
    #endregion
}
