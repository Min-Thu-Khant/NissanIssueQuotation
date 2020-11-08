using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL_AmigoProcess
{
    #region CUSTOMER MASTER
    public class CUSTOMER_MASTER
    {
        #region private

        private char _COMPANY_NO_BOX;
        private int _TRANSACTION_TYPE;
        private DateTime _EFFECTIVE_DATE;
        private int _UPDATE_CONTENT;
        private string _COMPANY_NAME;
        private string _COMPANY_NAME_READING;
        private DateTime _ESTIMATED_SUBMISSION_DATE;
        private DateTime _CONTRACT_DATE;
        private DateTime _COMPLETION_NOTE_SENDING_DATE;
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
        private DateTime _UPDATE_DATE;
        private char _UPDATER_CODE;

        #endregion

        #region Encapsulation

        public char COMPANY_NO_BOX { get { return _COMPANY_NO_BOX; } set { _COMPANY_NO_BOX = value; } }
        public int TRANSACTION_TYPE { get { return _TRANSACTION_TYPE; } set { _TRANSACTION_TYPE = value; } }
        public DateTime EFFECTIVE_DATE { get { return _EFFECTIVE_DATE; } set { _EFFECTIVE_DATE = value; } }
        public int UPDATE_CONTENT { get { return _UPDATE_CONTENT; } set { _UPDATE_CONTENT = value; } }
        public string COMPANY_NAME { get { return _COMPANY_NAME; } set { _COMPANY_NAME = value; } }
        public string COMPANY_NAME_READING { get { return _COMPANY_NAME_READING; } set { _COMPANY_NAME_READING = value; } }
        public DateTime ESTIMATED_SUBMISSION_DATE { get { return _ESTIMATED_SUBMISSION_DATE; } set { _ESTIMATED_SUBMISSION_DATE = value; } }
        public DateTime CONTRACT_DATE { get { return _CONTRACT_DATE; } set { _CONTRACT_DATE = value; } }
        public DateTime COMPLETION_NOTE_SENDING_DATE { get { return _COMPLETION_NOTE_SENDING_DATE; } set { _COMPLETION_NOTE_SENDING_DATE = value; } }
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
        public DateTime UPDATE_DATE { get { return _UPDATE_DATE; } set { _UPDATE_DATE = value; } }
        public char UPDATER_CODE { get { return _UPDATER_CODE; } set { _UPDATER_CODE = value; } }

        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into CUSTOMER_MASTER(COMPANY_NO_BOX,TRANSACTION_TYPE,EFFECTIVE_DATE,UPDATE_CONTENT,COMPANY_NAME,COMPANY_NAME_READING,ESTIMATED_SUBMISSION_DATE,
                            CONTRACT_DATE,COMPLETION_NOTE_SENDING_DATE,CONTRACTOR_DEPARTMENT_IN_CHARGE,CONTRACTOR_CONTACT_NAME,CONTRACTOR_CONTACT_NAME_READING,CONTRACTOR_POSTAL_CODE,
                            CONTRACTOR_ADDRESS,CONTRACTOR_ADDRESS_2,CONTRACTOR_MAIL_ADDRESS,CONTRACTOR_PHONE_NUMBER,BILL_SUPPLIER_NAME,BILL_SUPPLIER_NAME_READING,BILL_COMPANY_NAME,
                            BILL_DEPARTMENT_IN_CHARGE,BILL_CONTACT_NAME,BILL_CONTACT_NAME_READING,BILL_POSTAL_CODE,BILL_ADDRESS,BILL_ADDRESS_2,BILL_MAIL_ADDRESS,BILL_PHONE_NUMBER,
                            NCS_CUSTOMER_CODE,BILL_BANK_ACCOUNT_NAME_1,BILL_BANK_ACCOUNT_NAME_2,BILL_BANK_ACCOUNT_NAME_3,BILL_BANK_ACCOUNT_NAME_4,BILL_BANK_ACCOUNT_NUMBER_1,
                            BILL_BANK_ACCOUNT_NUMBER_2,BILL_BANK_ACCOUNT_NUMBER_3,BILL_BANK_ACCOUNT_NUMBER_4,BILL_BILLING_INTERVAL,BILL_DEPOSIT_RULES,BILL_TRANSFER_FEE,BILL_EXPENSES,
                            PLAN_SERVER,PLAN_SERVER_LIGHT,PLAN_BROWSER_AUTO,PLAN_BROWSER,PLAN_INITIAL_COST,PLAN_MONTHLY_COST,PLAN_AMIGO_CAI,PLAN_AMIGO_BIZ,PLAN_ADD_BOX_SERVER,
                            PLAN_ADD_BOX_BROWSER,PLAN_OP_FLAT,PLAN_OP_SSL,PLAN_OP_BASIC_SERVICE,PLAN_OP_ADD_SERVICE,PLAN_OP_SOCIOS,PREVIOUS_COMPANY_NAME,NML_CODE_NISSAN,NML_CODE_NS,
                            NML_CODE_JATCO,NML_CODE_AK,NML_CODE_NK,NML_CODE_OTHER,UPDATE_DATE,UPDATER_CODE)VALUES(@COMPANY_NO_BOX,@TRANSACTION_TYPE,@EFFECTIVE_DATE,@UPDATE_CONTENT,@COMPANY_NAME,
                            @COMPANY_NAME_READING,@ESTIMATED_SUBMISSION_DATE,@CONTRACT_DATE,@COMPLETION_NOTE_SENDING_DATE,@CONTRACTOR_DEPARTMENT_IN_CHARGE,@CONTRACTOR_CONTACT_NAME,@CONTRACTOR_CONTACT_NAME_READING,
                            @CONTRACTOR_POSTAL_CODE,@CONTRACTOR_ADDRESS,@CONTRACTOR_ADDRESS_2,@CONTRACTOR_MAIL_ADDRESS,@CONTRACTOR_PHONE_NUMBER,@BILL_SUPPLIER_NAME,@BILL_SUPPLIER_NAME_READING,@BILL_COMPANY_NAME,
                            @BILL_DEPARTMENT_IN_CHARGE,@BILL_CONTACT_NAME,@BILL_CONTACT_NAME_READING,@BILL_POSTAL_CODE,@BILL_ADDRESS,@BILL_ADDRESS_2,@BILL_MAIL_ADDRESS,@BILL_PHONE_NUMBER,@NCS_CUSTOMER_CODE,
                            @BILL_BANK_ACCOUNT_NAME_1,@BILL_BANK_ACCOUNT_NAME_2,@BILL_BANK_ACCOUNT_NAME_3,@BILL_BANK_ACCOUNT_NAME_4,@BILL_BANK_ACCOUNT_NUMBER_1,@BILL_BANK_ACCOUNT_NUMBER_2,@BILL_BANK_ACCOUNT_NUMBER_3,
                            @BILL_BANK_ACCOUNT_NUMBER_4,@BILL_BILLING_INTERVAL,@BILL_DEPOSIT_RULES,@BILL_TRANSFER_FEE,@BILL_EXPENSES,@PLAN_SERVER,@PLAN_SERVER_LIGHT,@PLAN_BROWSER_AUTO,@PLAN_BROWSER,@PLAN_INITIAL_COST,
                            @PLAN_MONTHLY_COST,@PLAN_AMIGO_CAI,@PLAN_AMIGO_BIZ,@PLAN_ADD_BOX_SERVER,@PLAN_ADD_BOX_BROWSER,@PLAN_OP_FLAT,@PLAN_OP_SSL,@PLAN_OP_BASIC_SERVICE,@PLAN_OP_ADD_SERVICE,@PLAN_OP_SOCIOS,
                            @PREVIOUS_COMPANY_NAME,@NML_CODE_NISSAN,@NML_CODE_NS,@NML_CODE_JATCO,@NML_CODE_AK,@NML_CODE_NK,@NML_CODE_OTHER,@UPDATE_DATE,@UPDATER_CODE)";
        string strUpdate = @"UPDATE CUSTOMER_MASTER SET 
                            BILL_BANK_ACCOUNT_NAME_1 = @BILL_BANK_ACCOUNT_NAME_1,
                            BILL_BANK_ACCOUNT_NAME_2 = @BILL_BANK_ACCOUNT_NAME_2,
                            BILL_BANK_ACCOUNT_NAME_3 = @BILL_BANK_ACCOUNT_NAME_3,
                            BILL_BANK_ACCOUNT_NAME_4 = @BILL_BANK_ACCOUNT_NAME_4,
                            BILL_BILLING_INTERVAL = @BILL_BILLING_INTERVAL,
                            BILL_DEPOSIT_RULES = @BILL_DEPOSIT_RULES,
                            BILL_TRANSFER_FEE = @BILL_TRANSFER_FEE,
                            BILL_EXPENSES = @BILL_EXPENSES,
                            UPDATE_DATE = @UPDATE_DATE,
                            UPDATER_CODE = @UPDATER_CODE
                            WHERE NCS_CUSTOMER_CODE = @NCS_CUSTOMER_CODE ";
        string strGetData = "SELECT * FROM CUSTOMER_MASTER";
        string strgetGridViewData = @"SELECT COMPANY_NAME, BILL_COMPANY_NAME, COMPANY_NO_BOX,
                                        BILL_BANK_ACCOUNT_NAME_1, BILL_BANK_ACCOUNT_NUMBER_1,
                                        BILL_BANK_ACCOUNT_NAME_2, BILL_BANK_ACCOUNT_NUMBER_2,
                                        BILL_BANK_ACCOUNT_NAME_3, BILL_BANK_ACCOUNT_NUMBER_3,
                                        BILL_BANK_ACCOUNT_NAME_4, BILL_BANK_ACCOUNT_NUMBER_4,
                                        NCS_CUSTOMER_CODE, 
                                        (case BILL_BILLING_INTERVAL when 1 then 'Monthly' when 2 then 'Quarter' when 3 then 'Half Period' when 4 then 'Year' end)BILL_BILLING_INTERVAL,
                                        (case BILL_DEPOSIT_RULES when 0 then 'Next Month' when 1 then 'This Month' when 2 then 'Two Months After' end) BILL_DEPOSIT_RULES, 
                                        BILL_TRANSFER_FEE,BILL_EXPENSES
                                        FROM
                                        CUSTOMER_MASTER
                                        WHERE COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
                                        AND COMPANY_NAME_READING LIKE '%' + @COMPANY_NAME_READING + '%'
                                        AND BILL_COMPANY_NAME LIKE '%' + @BILL_COMPANY_NAME + '%'
                                        AND COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
                                        ORDER BY COMPANY_NO_BOX";
        #endregion

        #region Constructors

        public CUSTOMER_MASTER(string con)
        {
            _COMPANY_NO_BOX = '\0';
            _TRANSACTION_TYPE = 0;
            _EFFECTIVE_DATE = new DateTime(1900, 1, 1);
            _UPDATE_CONTENT = 0;
            _COMPANY_NAME = "";
            _COMPANY_NAME_READING = "";
            _ESTIMATED_SUBMISSION_DATE = new DateTime(1900, 1, 1);
            _CONTRACT_DATE = new DateTime(1900, 1, 1);
            _COMPLETION_NOTE_SENDING_DATE = new DateTime(1900, 1, 1);
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
            _UPDATE_DATE = new DateTime(1900, 1, 1);
            _UPDATER_CODE = '\0';
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
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", _COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", _TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", _EFFECTIVE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATE_CONTENT", _UPDATE_CONTENT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", _COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_READING", _COMPANY_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ESTIMATED_SUBMISSION_DATE", _ESTIMATED_SUBMISSION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_DATE", _CONTRACT_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPLETION_NOTE_SENDING_DATE", _COMPLETION_NOTE_SENDING_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_DEPARTMENT_IN_CHARGE", _CONTRACTOR_DEPARTMENT_IN_CHARGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_CONTACT_NAME", _CONTRACTOR_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_CONTACT_NAME_READING", _CONTRACTOR_CONTACT_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_POSTAL_CODE", _CONTRACTOR_POSTAL_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_ADDRESS", _CONTRACTOR_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_ADDRESS_2", _CONTRACTOR_ADDRESS_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_MAIL_ADDRESS", _CONTRACTOR_MAIL_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACTOR_PHONE_NUMBER", _CONTRACTOR_PHONE_NUMBER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME", _BILL_SUPPLIER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME_READING", _BILL_SUPPLIER_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_COMPANY_NAME", _BILL_COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPARTMENT_IN_CHARGE", _BILL_DEPARTMENT_IN_CHARGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_CONTACT_NAME", _BILL_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_CONTACT_NAME_READING", _BILL_CONTACT_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_POSTAL_CODE", _BILL_POSTAL_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_ADDRESS", _BILL_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_ADDRESS_2", _BILL_ADDRESS_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_MAIL_ADDRESS", _BILL_MAIL_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_PHONE_NUMBER", _BILL_PHONE_NUMBER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", _NCS_CUSTOMER_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_1", _BILL_BANK_ACCOUNT_NAME_1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ILL_BANK_ACCOUNT_NAME_2", _BILL_BANK_ACCOUNT_NAME_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_3", _BILL_BANK_ACCOUNT_NAME_3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_4", _BILL_BANK_ACCOUNT_NAME_4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_1", _BILL_BANK_ACCOUNT_NUMBER_1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_2", _BILL_BANK_ACCOUNT_NUMBER_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_3", _BILL_BANK_ACCOUNT_NUMBER_3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_4", _BILL_BANK_ACCOUNT_NUMBER_4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", _BILL_BILLING_INTERVAL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", _BILL_DEPOSIT_RULES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", _BILL_TRANSFER_FEE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", _BILL_EXPENSES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_SERVER", _PLAN_SERVER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_SERVER_LIGHT", _PLAN_SERVER_LIGHT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_BROWSER_AUTO", _PLAN_BROWSER_AUTO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_BROWSER", _PLAN_BROWSER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_INITIAL_COST", _PLAN_INITIAL_COST));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_MONTHLY_COST", _PLAN_MONTHLY_COST));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_AMIGO_CAI", _PLAN_AMIGO_CAI));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_AMIGO_BIZ", _PLAN_AMIGO_BIZ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_ADD_BOX_SERVER", _PLAN_ADD_BOX_SERVER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_ADD_BOX_BROWSER", _PLAN_ADD_BOX_BROWSER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_FLAT", _PLAN_OP_FLAT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_SSL", _PLAN_OP_SSL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_BASIC_SERVICE", _PLAN_OP_BASIC_SERVICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_ADD_SERVICE", _PLAN_OP_ADD_SERVICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_SOCIOS", _PLAN_OP_SOCIOS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PREVIOUS_COMPANY_NAME", _PREVIOUS_COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_NISSAN", _NML_CODE_NISSAN));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_NS", _NML_CODE_NS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_JATCO", _NML_CODE_JATCO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_AK", _NML_CODE_AK));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_NK", _NML_CODE_NK));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NML_CODE_OTHER", _NML_CODE_OTHER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATE_DATE", _UPDATE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATER_CODE", _UPDATER_CODE));
            oMaster.ExcuteQuery(1, out strMessage);
            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

        #region getData
        public DataTable getDataByAll()
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetData);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getGridViewData
        public DataTable getGridViewData(string COMPANY_NAME, string COMPANY_NAME_READING, string BILL_COMPANY_NAME, string COMPANY_NO_BOX)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strgetGridViewData);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_READING", COMPANY_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_COMPANY_NAME", BILL_COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region update
        public void update(out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_1", _BILL_BANK_ACCOUNT_NAME_1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_2", _BILL_BANK_ACCOUNT_NAME_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_3", _BILL_BANK_ACCOUNT_NAME_3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_4", _BILL_BANK_ACCOUNT_NAME_4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", _BILL_BILLING_INTERVAL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", _BILL_DEPOSIT_RULES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", _BILL_TRANSFER_FEE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", _BILL_EXPENSES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATE_DATE", _UPDATE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATER_CODE", _UPDATER_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", _NCS_CUSTOMER_CODE));
            oMaster.ExcuteQuery(2, out strMessage);
        }

        #endregion
    }
    #endregion
}
