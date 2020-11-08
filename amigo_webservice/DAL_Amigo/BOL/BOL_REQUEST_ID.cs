using System;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_REQUEST_ID
    public class BOL_REQUEST_ID
    {
        private string _COMPANY_NO_BOX;
        public string COMPANY_NO_BOX
        {
            get { return _COMPANY_NO_BOX; }
            set { _COMPANY_NO_BOX = value; }
        }

        private string _AUTO_INDEX_ID;
        public string AUTO_INDEX_ID
        {
            get { return _AUTO_INDEX_ID; }
            set { _AUTO_INDEX_ID = value; }
        }

        private string _COMPANY_NAME;
        public string COMPANY_NAME
        {
            get { return _COMPANY_NAME; }
            set { _COMPANY_NAME = value; }
        }

        private string _PASSWORD;
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }

        private string _PASSWORD_HASHED;
        public string PASSWORD_HASHED
        {
            get { return _PASSWORD_HASHED; }
            set { _PASSWORD_HASHED = value; }
        }

        private DateTime? _PASSWORD_SET_DATE;
        public DateTime? PASSWORD_SET_DATE
        {
            get { return _PASSWORD_SET_DATE; }
            set { _PASSWORD_SET_DATE = value; }
        }

        private DateTime? _PASSWORD_EXPIRATION_DATE;
        public DateTime? PASSWORD_EXPIRATION_DATE
        {
            get { return _PASSWORD_EXPIRATION_DATE; }
            set { _PASSWORD_EXPIRATION_DATE = value; }
        }

        private string _EMAIL_ADDRESS;
        public string EMAIL_ADDRESS
        {
            get { return _EMAIL_ADDRESS; }
            set { _EMAIL_ADDRESS = value; }
        }

        private DateTime? _EMAIL_SEND_DATE;
        public DateTime? EMAIL_SEND_DATE
        {
            get { return _EMAIL_SEND_DATE; }
            set { _EMAIL_SEND_DATE = value; }
        }

        private decimal _LOGIN_FAIL_COUNT;
        public decimal LOGIN_FAIL_COUNT
        {
            get { return _LOGIN_FAIL_COUNT; }
            set { _LOGIN_FAIL_COUNT = value; }
        }

        private string _SESSION_ID;
        public string SESSION_ID
        {
            get { return _SESSION_ID; }
            set { _SESSION_ID = value; }
        }

        private DateTime? _LAST_ACCESS_DATE;
        public DateTime? LAST_ACCESS_DATE
        {
            get { return _LAST_ACCESS_DATE; }
            set { _LAST_ACCESS_DATE = value; }
        }

        private DateTime? _LAST_FAIL_DATE;
        public DateTime? LAST_FAIL_DATE
        {
            get { return _LAST_FAIL_DATE; }
            set { _LAST_FAIL_DATE = value; }
        }

        private int _GD;
        public int GD
        {
            get { return _GD; }
            set { _GD = value; }
        }

        private string _GD_CODE;
        public string GD_CODE
        {
            get { return _GD_CODE; }
            set { _GD_CODE = value; }
        }

        private string _DISABLED_FLG;
        public string DISABLED_FLG
        {
            get { return _DISABLED_FLG; }
            set { _DISABLED_FLG = value; }
        }

        private string _MEMO;
        public string MEMO
        {
            get { return _MEMO; }
            set { _MEMO = value; }
        }

        private string _SOCIOS_USER_FLG;
        public string SOCIOS_USER_FLG
        {
            get { return _SOCIOS_USER_FLG; }
            set { _SOCIOS_USER_FLG = value; }
        }

        private string _COMPANY_NO;
        public string COMPANY_NO
        {
            get { return _COMPANY_NO; }
            set { _COMPANY_NO = value; }
        }

        private int _COMPANY_BOX;
        public int COMPANY_BOX
        {
            get { return _COMPANY_BOX; }
            set { _COMPANY_BOX = value; }
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
