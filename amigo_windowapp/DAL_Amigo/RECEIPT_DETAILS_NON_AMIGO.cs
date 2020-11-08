using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL_AmigoProcess
{
    #region RECEIPT DETAILS NON AMIGO
    public class RECEIPT_DETAILS_NON_AMIGO
    {
        #region private

        private int _SEQ_NO;
        private int _DATA_CLASS;
        private string _RECORD_CLASS;
        private DateTime _TRANSACTION_DATE;
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
        private DateTime _HANDLING_DATE;
        private DateTime _DEPOSIT_DATE;
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
        private DateTime _RUN_DATE_TIME;
        private int _RUN_RESULT;
        private string _DATA_MOVEMENT_INFORMATION;
        private DateTime _PAYMENT_DAY;
        private int _TYPE_OF_ALLOCATION;
        private int _ALLOCATED_QUANTITY;
        private decimal _ALLOCATED_MONEY;
        private DateTime _ALLOCATED_COMPLETION_DATE;

        #endregion

        #region Encapsulation

        public int SEQ_NO { get { return _SEQ_NO; } set { _SEQ_NO = value; } }
        public int DATA_CLASS { get { return _DATA_CLASS; } set { _DATA_CLASS = value; } }
        public string RECORD_CLASS { get { return _RECORD_CLASS; } set { _RECORD_CLASS = value; } }
        public DateTime TRANSACTION_DATE { get { return _TRANSACTION_DATE; } set { _TRANSACTION_DATE = value; } }
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
        public DateTime HANDLING_DATE { get { return _HANDLING_DATE; } set { _HANDLING_DATE = value; } }
        public DateTime DEPOSIT_DATE { get { return _DEPOSIT_DATE; } set { _DEPOSIT_DATE = value; } }
        public decimal DEPOSIT_AMOUNT { get { return _DEPOSIT_AMOUNT; } set { _DEPOSIT_AMOUNT = value; } }
        public string CHECK_CLASS { get { return _CHECK_CLASS; } set { _CHECK_CLASS = value; } }
        public string CUSTOMER_NAME { get { return _CUSTOMER_NAME; } set { _CUSTOMER_NAME = value; } }
        public int COLLECTION_NO_SHEETS { get { return _COLLECTION_NO_SHEETS; } set { _COLLECTION_NO_SHEETS = value; } }
        public string COLLECTION_NO { get { return COLLECTION_NO; } set { _COLLECTION_NO = value; } }
        public string CUSTOMER_NO { get { return _CUSTOMER_NO; } set { _CUSTOMER_NO = value; } }
        public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
        public string BRANCH_NAME { get { return _BRANCH_NAME; } set { _BRANCH_NAME = value; } }
        public string TRANSFER_MESSAGE { get { return _TRANSFER_MESSAGE; } set { _TRANSFER_MESSAGE = value; } }
        public string NOTE { get { return _NOTE; } set { _NOTE = value; } }
        public int NUMBER { get { return _NUMBER; } set { _NUMBER = value; } }
        public string TRANSACTION_FILE_NAME { get { return _TRANSACTION_FILE_NAME; } set { _TRANSACTION_FILE_NAME = value; } }
        public DateTime RUN_DATE_TIME { get { return _RUN_DATE_TIME; } set { _RUN_DATE_TIME = value; } }
        public int RUN_RESULT { get { return _RUN_RESULT; } set { _RUN_RESULT = value; } }
        public string DATA_MOVEMENT_INFORMATION { get { return _DATA_MOVEMENT_INFORMATION; } set { _DATA_MOVEMENT_INFORMATION = value; } }
        public DateTime PAYMENT_DAY { get { return _PAYMENT_DAY; } set { _PAYMENT_DAY = value; } }
        public int TYPE_OF_ALLOCATION { get { return _TYPE_OF_ALLOCATION; } set { _TYPE_OF_ALLOCATION = value; } }
        public int ALLOCATED_QUANTITY { get { return _ALLOCATED_QUANTITY; } set { _ALLOCATED_QUANTITY = value; } }
        public decimal ALLOCATED_MONEY { get { return _ALLOCATED_MONEY; } set { _ALLOCATED_MONEY = value; } }
        public DateTime ALLOCATED_COMPLETION_DATE { get { return _ALLOCATED_COMPLETION_DATE; } set { _ALLOCATED_COMPLETION_DATE = value; } }

        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into RECEIPT_DETAILS_NON_AMIGO (DATA_CLASS,RECORD_CLASS,TRANSACTION_DATE,TRANSACTION_CONTACT_NAME,TRANSACTION_BANKS_NAME,TRANSACTION_BRANCH_NAME,
TRANSACTION_ACCOUNT_NO_CLASS,TRANSACTION_ACCOUNT_TYPE,TRANSACTION_ACCOUNT_NO,RESEND_INDICATION,TRANSACTION_NAME,TRANSACTION_NO,TRANSACTION_DETAIL_CLASS,
HANDLING_DATE,DEPOSIT_DATE,DEPOSIT_AMOUNT,CHECK_CLASS,CUSTOMER_NAME,COLLECTION_NO_SHEETS,COLLECTION_NO,CUSTOMER_NO,BANK_NAME,BRANCH_NAME,TRANSFER_MESSAGE,
NOTE,NUMBER,TRANSACTION_FILE_NAME,RUN_DATE_TIME,RUN_RESULT,DATA_MOVEMENT_INFORMATION,PAYMENT_DAY,TYPE_OF_ALLOCATION,ALLOCATED_QUANTITY,ALLOCATED_MONEY,ALLOCATED_COMPLETION_DATE)
VALUES(@DATA_CLASS,@RECORD_CLASS,@TRANSACTION_DATE,@TRANSACTION_CONTACT_NAME,@TRANSACTION_BANKS_NAME,@TRANSACTION_BRANCH_NAME,@TRANSACTION_ACCOUNT_NO_CLASS,
@TRANSACTION_ACCOUNT_TYPE,@TRANSACTION_ACCOUNT_NO,@RESEND_INDICATION,@TRANSACTION_NAME,@TRANSACTION_NO,@TRANSACTION_DETAIL_CLASS,@HANDLING_DATE,@DEPOSIT_DATE,
@DEPOSIT_AMOUNT,@CHECK_CLASS,@CUSTOMER_NAME,@COLLECTION_NO_SHEETS,@COLLECTION_NO,@CUSTOMER_NO,@BANK_NAME,@BRANCH_NAME,@TRANSFER_MESSAGE,@NOTE,@NUMBER,
@TRANSACTION_FILE_NAME,@RUN_DATE_TIME,@RUN_RESULT,@DATA_MOVEMENT_INFORMATION,@PAYMENT_DAY,@TYPE_OF_ALLOCATION,@ALLOCATED_QUANTITY,@ALLOCATED_MONEY,@ALLOCATED_COMPLETION_DATE)";

        #endregion

        #region Constructors

        public RECEIPT_DETAILS_NON_AMIGO(string con)
        {
            _SEQ_NO = 0;
            _DATA_CLASS = 0;
            _RECORD_CLASS = "";
            _TRANSACTION_DATE = new DateTime(1900, 1, 1);
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
            _HANDLING_DATE = new DateTime(1900, 1, 1);
            _DEPOSIT_DATE = new DateTime(1900, 1, 1);
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
            _RUN_DATE_TIME = new DateTime(1900, 1, 1);
            _RUN_RESULT = 0;
            _DATA_MOVEMENT_INFORMATION = "";
            _PAYMENT_DAY = new DateTime(1900, 1, 1);
            _TYPE_OF_ALLOCATION = 0;
            _ALLOCATED_QUANTITY = 0;
            _ALLOCATED_MONEY = 0;
            _ALLOCATED_COMPLETION_DATE = new DateTime(1900, 1, 1);
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region insert

        public void insert(out string strMessage)
        {
            int intRtn = 0;
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            //oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", _SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_CLASS", _DATA_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RECORD_CLASS", _RECORD_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DATE", _TRANSACTION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_CONTACT_NAME", _TRANSACTION_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BANKS_NAME", _TRANSACTION_BANKS_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BRANCH_NAME", _TRANSACTION_BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO_CLASS", _TRANSACTION_ACCOUNT_NO_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_TYPE", _TRANSACTION_ACCOUNT_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO", _TRANSACTION_ACCOUNT_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESEND_INDICATION", _RESEND_INDICATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NAME", _TRANSACTION_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NO", _TRANSACTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DETAIL_CLASS", _TRANSACTION_DETAIL_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@HANDLING_DATE", _HANDLING_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_DATE", _DEPOSIT_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_AMOUNT", _DEPOSIT_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CHECK_CLASS", _CHECK_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NAME ", _CUSTOMER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO_SHEETS", _COLLECTION_NO_SHEETS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO", _COLLECTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NO", _CUSTOMER_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BANK_NAME", _BANK_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BRANCH_NAME", _BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSFER_MESSAGE", _TRANSFER_MESSAGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NOTE", _NOTE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NUMBER", _NUMBER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_FILE_NAME", _TRANSACTION_FILE_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_DATE_TIME", _RUN_DATE_TIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_RESULT", _RUN_RESULT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_MOVEMENT_INFORMATION", _DATA_MOVEMENT_INFORMATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", _PAYMENT_DAY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", _TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_QUANTITY", _ALLOCATED_QUANTITY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_MONEY", _ALLOCATED_MONEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", _ALLOCATED_COMPLETION_DATE));
            oMaster.ExcuteQuery(1, out strMessage);
            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

    }
    #endregion
}
