namespace DAL_AmigoProcess.BOL
{

    #region BOL_EDI_CANDIDATE
    public class BOL_EDI_CANDIDATE
    {
        private string _EDI_ACCOUNT;
        public string EDI_ACCOUNT
        {
            get { return _EDI_ACCOUNT; }
            set { _EDI_ACCOUNT = value; }
        }

        private string _USED_FLG;
        public string USED_FLG
        {
            get { return _USED_FLG; }
            set { _USED_FLG = value; }
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

        private string _UPDATED_BY;
        public string UPDATED_BY
        {
            get { return _UPDATED_BY; }
            set { _UPDATED_BY = value; }
        }

    }
    #endregion

}
