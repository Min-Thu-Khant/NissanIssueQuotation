using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_REQ_USAGE_FEE
    public class BOL_REQ_USAGE_FEE
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

        private string _CONTRACT_CODE;
        public string CONTRACT_CODE
        {
            get { return _CONTRACT_CODE; }
            set { _CONTRACT_CODE = value; }
        }

        private string _CONSTRACT_NAME;
        public string CONSTRACT_NAME
        {
            get { return _CONSTRACT_NAME; }
            set { _CONSTRACT_NAME = value; }
        }

        private decimal _INITIAL_COST;
        public decimal INITIAL_COST
        {
            get { return _INITIAL_COST; }
            set { _INITIAL_COST = value; }
        }

        private decimal _MONTHLY_COST;
        public decimal MONTHLY_COST
        {
            get { return _MONTHLY_COST; }
            set { _MONTHLY_COST = value; }
        }

        private int _QUANTITY;
        public int QUANTITY
        {
            get { return _QUANTITY; }
            set { _QUANTITY = value; }
        }

        private decimal _UNIT_PRICE;
        public decimal UNIT_PRICE
        {
            get { return _UNIT_PRICE; }
            set { _UNIT_PRICE = value; }
        }

        private decimal _AMOUNT;
        public decimal AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }

        private decimal _TYPE;
        public decimal TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
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
