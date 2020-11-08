using System;
using System.Data;
using System.Data.SqlClient;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region RESERVE_INFO
    public class RESERVE_INFO
    {
        #region Constructor 
        public RESERVE_INFO(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into RESERVE_INFO (SEQ_NO,BILLING_CODE,PAYMENT_DAY,TYPE_OF_ALLOCATION,RESERVE_AMOUNT, DIFF_ALLOCATION_AMOUNT)VALUES(@SEQ_NO,@BILLING_CODE,@PAYMENT_DAY,@TYPE_OF_ALLOCATION,@RESERVE_AMOUNT,@DIFF_ALLOCATION_AMOUNT)";
        string strGetReservceInfoByBillingCode = "SELECT SEQ_NO FROM RESERVE_INFO WHERE BILLING_CODE = @BILLING_CODE";
        string strGetBillingCodeBySEQNO = "SELECT BILLING_CODE FROM RESERVE_INFO WHERE SEQ_NO = @SEQ_NO";
        string strRemove = "DELETE RESERVE_INFO WHERE BILLING_CODE = @BILLING_CODE AND SEQ_NO=@SEQ_NO";
        #endregion        

        #region insert

        public void insert(BOL_RESERVE_INFO B_RESERVCE,out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", B_RESERVCE.SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILLING_CODE", B_RESERVCE.BILLING_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", B_RESERVCE.PAYMENT_DAY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_RESERVCE.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESERVE_AMOUNT", B_RESERVCE.RESERVE_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DIFF_ALLOCATION_AMOUNT", B_RESERVCE.DIFF_ALLOCATION_AMOUNT));
            
            oMaster.ExcuteQuery(6, out strMessage);            
        }
        #endregion

        #region GetReservceInfoByBillingCode
        public DataTable GetReservceInfoByBillingCode(string BILLING_CODE)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetReservceInfoByBillingCode);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILLING_CODE", BILLING_CODE));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetCompanyNoBoxBySEQNO
        public DataTable GetCompanyNoBoxBySEQNO(int SEQID, out string strMsg)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetBillingCodeBySEQNO);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", SEQID));
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region removeReserve
        public string removeReserve(int SEQ_NO, string BILLING_CODE)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strRemove);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILLING_CODE", BILLING_CODE));
            oMaster.ExcuteQuery(3, out strMessage);
            return strMessage;
        }
        #endregion

    }
    #endregion    
}
