using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    #region BOL_RESERVCE_INFO
    public class BOL_RESERVE_INFO
    {
        #region private

        private int _SEQ_NO;
        private string _BILLING_CODE;
        private DateTime? _PAYMENT_DAY;
        private int _TYPE_OF_ALLOCATION;
        private decimal _RESERVE_AMOUNT;
        private decimal _DIFF_ALLOCATION_AMOUNT;

        #endregion

        #region Encapsulation

        public int SEQ_NO { get { return _SEQ_NO; } set { _SEQ_NO = value; } }
        public string BILLING_CODE { get { return _BILLING_CODE; } set { _BILLING_CODE = value; } }
        public DateTime? PAYMENT_DAY { get { return _PAYMENT_DAY; } set { _PAYMENT_DAY = value; } }
        public int TYPE_OF_ALLOCATION { get { return _TYPE_OF_ALLOCATION; } set { _TYPE_OF_ALLOCATION = value; } }
        public decimal RESERVE_AMOUNT { get { return _RESERVE_AMOUNT; } set { _RESERVE_AMOUNT = value; } }
        public decimal DIFF_ALLOCATION_AMOUNT { get { return _DIFF_ALLOCATION_AMOUNT; } set { _DIFF_ALLOCATION_AMOUNT = value; } }

        #endregion

        #region Constructors

        public BOL_RESERVE_INFO()
        {
            _SEQ_NO = 0;
            _BILLING_CODE = "";
            _PAYMENT_DAY = null;
            _TYPE_OF_ALLOCATION = 0;
            _RESERVE_AMOUNT = 0;
            _DIFF_ALLOCATION_AMOUNT = 0;
        }

        #endregion
    }
    #endregion
}
