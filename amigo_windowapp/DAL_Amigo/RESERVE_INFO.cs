using System;
using System.Data.SqlClient;
namespace DAL_AmigoProcess
{

    #region RESERVE_INFO
    public class RESERVE_INFO
    {
        #region private

        private int _RESERVE_INFO_ID;
        private int _SEQ_NO;
        private string _BILLING_CODE;
        private DateTime _PAYMENT_DAY;
        private int _TYPE_OF_ALLOCATION;
        private decimal _RESERVE_AMOUNT;

        #endregion

        #region Encapsulation

        public int RESERVE_INFO_ID { get { return _RESERVE_INFO_ID; } set { _RESERVE_INFO_ID = value; } }
        public int SEQ_NO { get { return _SEQ_NO; } set { _SEQ_NO = value; } }
        public string BILLING_CODE { get { return _BILLING_CODE; } set { _BILLING_CODE = value; } }
        public DateTime PAYMENT_DAY { get { return _PAYMENT_DAY; } set { _PAYMENT_DAY = value; } }
        public int TYPE_OF_ALLOCATION { get { return _TYPE_OF_ALLOCATION; } set { _TYPE_OF_ALLOCATION = value; } }
        public decimal RESERVE_AMOUNT { get { return _RESERVE_AMOUNT; } set { _RESERVE_AMOUNT = value; } }

        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into RESERVE_INFO (RESERVE_INFO_ID,SEQ_NO,BILLING_CODE,PAYMENT_DAY,TYPE_OF_ALLOCATION,RESERVE_AMOUNT)VALUES(@RESERVE_INFO_ID,@SEQ_NO,@BILLING_CODE,@PAYMENT_DAY,@TYPE_OF_ALLOCATION,@RESERVE_AMOUNT)";

        #endregion

        #region Constructors

        public RESERVE_INFO(string con)
        {
            _SEQ_NO = 0;
            _RESERVE_INFO_ID = 0;
            _BILLING_CODE = "";
            _PAYMENT_DAY = new DateTime(1900, 1, 1);
            _TYPE_OF_ALLOCATION = 0;
            _RESERVE_AMOUNT = 0;
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
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", _SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESERVE_INFO_ID", _RESERVE_INFO_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILLING_CODE", _BILLING_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", _PAYMENT_DAY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", _TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESERVE_AMOUNT", _RESERVE_AMOUNT));
            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

    }
    #endregion
}
