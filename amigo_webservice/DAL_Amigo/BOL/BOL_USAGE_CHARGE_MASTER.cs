using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    public class BOL_USAGE_CHARGE_MASTER
    {

        #region Private
        private string _CONTRACT_CODE;
        private DateTime? _ADOPTION_DATE;
        private string _FEE_STRUCTURE;
        private string _CONTRACT_NAME;
        private int? _CONTRACT_QTY;
        private string _CONTRACT_UNIT;
        private Decimal? _INITIAL_COST;
        private Decimal? _MONTHLY_COST;
        private int? _INPUT_TYPE;
        private int? _NUMBER_DEFAULT;
        private string _MEMO;
        private int? _DISPLAY_ORDER;
        private string _CREATED_AT;
        private string _CREATED_BY;
        private string _UPDATED_AT;
        private string _UPDATED_AT_RAW;
        private string _UPDATED_BY;
        #endregion

        #region Encapsulation
        public string CONTRACT_CODE { get { return _CONTRACT_CODE; } set { _CONTRACT_CODE = value; } }
        public DateTime? ADOPTION_DATE { get { return _ADOPTION_DATE; } set { _ADOPTION_DATE = value; } }
        public string FEE_STRUCTURE { get { return _FEE_STRUCTURE; } set { _FEE_STRUCTURE = value; } }
        public string CONTRACT_NAME { get { return _CONTRACT_NAME; } set { _CONTRACT_NAME = value; } }
        public int? CONTRACT_QTY { get { return _CONTRACT_QTY; } set { _CONTRACT_QTY = value; } }
        public string CONTRACT_UNIT { get { return _CONTRACT_UNIT; } set { _CONTRACT_UNIT = value; } }
        public Decimal? INITIAL_COST { get { return _INITIAL_COST; } set { _INITIAL_COST = value; } }
        public Decimal? MONTHLY_COST { get { return _MONTHLY_COST; } set { _MONTHLY_COST = value; } }
        public int? INPUT_TYPE { get { return _INPUT_TYPE; } set { _INPUT_TYPE = value; } }
        public int? NUMBER_DEFAULT { get { return _NUMBER_DEFAULT; } set { _NUMBER_DEFAULT = value; } }
        public string MEMO { get { return _MEMO; } set { _MEMO = value; } }
        public int? DISPLAY_ORDER { get { return _DISPLAY_ORDER; } set { _DISPLAY_ORDER = value; } }
        public string CREATED_AT { get { return _CREATED_AT; } set { _CREATED_AT = value; } }
        public string CREATED_BY { get { return _CREATED_BY; } set { _CREATED_BY = value; } }
        public string UPDATED_AT { get { return _UPDATED_AT; } set { _UPDATED_AT = value; } }
        public string UPDATED_AT_RAW { get { return _UPDATED_AT_RAW; } set { _UPDATED_AT_RAW = value; } }
        public string UPDATED_BY { get { return _UPDATED_BY; } set { _UPDATED_BY = value; } }
        #endregion

    }
}
