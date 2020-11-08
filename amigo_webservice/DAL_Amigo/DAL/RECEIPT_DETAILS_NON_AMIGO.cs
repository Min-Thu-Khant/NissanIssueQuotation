using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region RECEIPT DETAILS NON AMIGO
    public class RECEIPT_DETAILS_NON_AMIGO
    {

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

        string strConvertFromAmigoToNonAmigo = @"INSERT INTO RECEIPT_DETAILS_NON_AMIGO
                                                SELECT [DATA_CLASS],[RECORD_CLASS],[TRANSACTION_DATE],[TRANSACTION_CONTACT_NAME],[TRANSACTION_BANKS_NAME],[TRANSACTION_BRANCH_NAME],[TRANSACTION_ACCOUNT_NO_CLASS]
                                                      ,[TRANSACTION_ACCOUNT_TYPE],[TRANSACTION_ACCOUNT_NO],[RESEND_INDICATION],[TRANSACTION_NAME],[TRANSACTION_NO],[TRANSACTION_DETAIL_CLASS],[HANDLING_DATE]
                                                      ,[DEPOSIT_DATE],[DEPOSIT_AMOUNT],[CHECK_CLASS],[CUSTOMER_NAME],[COLLECTION_NO_SHEETS],[COLLECTION_NO],[CUSTOMER_NO],[BANK_NAME],[BRANCH_NAME],[TRANSFER_MESSAGE]
                                                      ,[NOTE],[NUMBER],[TRANSACTION_FILE_NAME],[RUN_DATE_TIME],99,[DATA_MOVEMENT_INFORMATION],[PAYMENT_DAY],[TYPE_OF_ALLOCATION],[ALLOCATED_QUANTITY],[ALLOCATED_MONEY]
                                                      ,[ALLOCATED_COMPLETION_DATE] 
                                                  FROM [RECEIPT_DETAILS]
                                                  WHERE [SEQ_NO] = @SeqNo";
        string strDeleteNonAmigo = @"DELETE RECEIPT_DETAILS_NON_AMIGO WHERE [SEQ_NO] = @SeqNo";

        string strGetNonAmigoDetailByRunDate_33 = @"SELECT SEQ_NO,CUSTOMER_NAME,DEPOSIT_AMOUNT
                                                    FROM (SELECT *,FORMAT(RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID
                                                    FROM RECEIPT_DETAILS_NON_AMIGO WHERE Run_Result = 99 AND FORMAT(RUN_DATE_TIME, 'yyyyMMddHHmm')= @DTMID) NonAmigo
                                                    ORDER BY CUSTOMER_NAME ASC
                                                   ";

        string strGetDuplicatedRecord = @"DECLARE @HANDLINGDATE DATETIME2 = @HANDLE_DATE  , @TRANSACTIONDATE DATETIME2 = @TRANSACTION_DATE 
                                          SELECT* FROM RECEIPT_DETAILS_NON_AMIGO WHERE 
                                          HANDLING_DATE=@HANDLINGDATE AND 
                                          DEPOSIT_AMOUNT=@DEPOSIT_AMOUNT AND 
                                          BANK_NAME =@BANK_NAME AND 
                                          BRANCH_NAME =@BRANCH_NAME AND 
                                          CUSTOMER_NAME=@CUSTOMER_NAME AND
                                          TRANSACTION_DATE=@TRANSACTIONDATE AND
                                          TRANSACTION_NO = @TRANSACTION_NO";

        #endregion

        #region Constructors

        public RECEIPT_DETAILS_NON_AMIGO(string con)
        {            
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region GetDataByDuplicateKeys
        public DataTable GetDataByDuplicateKeys(BOL_RECEIPT_DETAILS_NON_AMIGO obj, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetDuplicatedRecord);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@HANDLE_DATE", obj.HANDLING_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_AMOUNT", obj.DEPOSIT_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BANK_NAME", obj.BANK_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BRANCH_NAME", obj.BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", obj.CUSTOMER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DATE", obj.TRANSACTION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NO", obj.TRANSACTION_NO));
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region insert
        public void insert(BOL_RECEIPT_DETAILS_NON_AMIGO B_RECEIPT_DETAILS_NON_AMIGO, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            //oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", _SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_CLASS", B_RECEIPT_DETAILS_NON_AMIGO.DATA_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RECORD_CLASS", B_RECEIPT_DETAILS_NON_AMIGO.RECORD_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DATE", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_DATE != null ? B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_CONTACT_NAME", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BANKS_NAME", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_BANKS_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BRANCH_NAME", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO_CLASS", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_ACCOUNT_NO_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_TYPE", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_ACCOUNT_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_ACCOUNT_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESEND_INDICATION", B_RECEIPT_DETAILS_NON_AMIGO.RESEND_INDICATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NAME", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NO", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DETAIL_CLASS", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_DETAIL_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@HANDLING_DATE", B_RECEIPT_DETAILS_NON_AMIGO.HANDLING_DATE != null ? B_RECEIPT_DETAILS_NON_AMIGO.HANDLING_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_DATE", B_RECEIPT_DETAILS_NON_AMIGO.DEPOSIT_DATE != null ? B_RECEIPT_DETAILS_NON_AMIGO.DEPOSIT_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_AMOUNT", B_RECEIPT_DETAILS_NON_AMIGO.DEPOSIT_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CHECK_CLASS", B_RECEIPT_DETAILS_NON_AMIGO.CHECK_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NAME ", B_RECEIPT_DETAILS_NON_AMIGO.CUSTOMER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO_SHEETS", B_RECEIPT_DETAILS_NON_AMIGO.COLLECTION_NO_SHEETS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO", B_RECEIPT_DETAILS_NON_AMIGO.COLLECTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NO", B_RECEIPT_DETAILS_NON_AMIGO.CUSTOMER_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BANK_NAME", B_RECEIPT_DETAILS_NON_AMIGO.BANK_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BRANCH_NAME", B_RECEIPT_DETAILS_NON_AMIGO.BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSFER_MESSAGE", B_RECEIPT_DETAILS_NON_AMIGO.TRANSFER_MESSAGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NOTE", B_RECEIPT_DETAILS_NON_AMIGO.NOTE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NUMBER", B_RECEIPT_DETAILS_NON_AMIGO.NUMBER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_FILE_NAME", B_RECEIPT_DETAILS_NON_AMIGO.TRANSACTION_FILE_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_DATE_TIME", B_RECEIPT_DETAILS_NON_AMIGO.RUN_DATE_TIME != null ? B_RECEIPT_DETAILS_NON_AMIGO.RUN_DATE_TIME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_RESULT", B_RECEIPT_DETAILS_NON_AMIGO.RUN_RESULT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_MOVEMENT_INFORMATION", B_RECEIPT_DETAILS_NON_AMIGO.DATA_MOVEMENT_INFORMATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", B_RECEIPT_DETAILS_NON_AMIGO.PAYMENT_DAY != null ? B_RECEIPT_DETAILS_NON_AMIGO.PAYMENT_DAY : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_RECEIPT_DETAILS_NON_AMIGO.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_QUANTITY", B_RECEIPT_DETAILS_NON_AMIGO.ALLOCATED_QUANTITY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_MONEY", B_RECEIPT_DETAILS_NON_AMIGO.ALLOCATED_MONEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", B_RECEIPT_DETAILS_NON_AMIGO.ALLOCATED_COMPLETION_DATE != null ? B_RECEIPT_DETAILS_NON_AMIGO.ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            
            oMaster.ExcuteQuery(1, out strMessage);
            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

        #region GetNonAmigoDetailByRunDate
        public DataTable GetNonAmigoDetailByRunDate(string strDTMID, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetNonAmigoDetailByRunDate_33);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DTMID", strDTMID));
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region ConvertFromAmigoToNonAmigo
        public void ConvertFromAmigoToNonAmigo(int inSEQNo, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strConvertFromAmigoToNonAmigo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SeqNo", inSEQNo));
            oMaster.ExcuteQuery(1, out strMessage);
            strMsg = strMessage;
        }
        #endregion

        #region removeNonAmigo
        public void removeNonAmigo(int inSEQNo, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDeleteNonAmigo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SeqNo", inSEQNo));
            oMaster.ExcuteQuery(3, out strMessage);
        }
        #endregion
    }
    #endregion    
}
