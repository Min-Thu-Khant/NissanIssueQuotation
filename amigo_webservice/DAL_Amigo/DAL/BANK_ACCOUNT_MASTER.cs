using System;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region BANK_ACCOUNT_MASTER
    public class BANK_ACCOUNT_MASTER
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strUpdate = @"UPDATE [BANK_ACCOUNT_MASTER]
                               SET [BILL_BANK_ACCOUNT_NAME-1] = @BILL_BANK_ACCOUNT_NAME_1
                                  ,[BILL_BANK_ACCOUNT_NAME-2] = @BILL_BANK_ACCOUNT_NAME_2
                                  ,[BILL_BANK_ACCOUNT_NAME-3] = @BILL_BANK_ACCOUNT_NAME_3
                                  ,[BILL_BANK_ACCOUNT_NAME-4] = @BILL_BANK_ACCOUNT_NAME_4
                                  ,[UPDATED_AT] = @UPDATED_AT
                                  ,[UPDATED_BY] = @UPDATED_BY
                                WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX AND REQ_SEQ=@REQ_SEQ";

        string strAlreadyUpdate = @"SELECT COUNT(COMPANY_NO_BOX) AS COUNT
                                    FROM BANK_ACCOUNT_MASTER
                                    WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                    AND REQ_SEQ = @REQ_SEQ";

        string strBankAccountMasterUpdate = @"UPDATE [BANK_ACCOUNT_MASTER]
                               SET [BILL_BANK_ACCOUNT_NAME-1] = @BILL_BANK_ACCOUNT_NAME_1,
                                   [BILL_BANK_ACCOUNT_NAME-2] = @BILL_BANK_ACCOUNT_NAME_2,
                                   [BILL_BANK_ACCOUNT_NAME-3] = @BILL_BANK_ACCOUNT_NAME_3,
                                   [BILL_BANK_ACCOUNT_NAME-4] = @BILL_BANK_ACCOUNT_NAME_4,
                                   [BILL_BANK_ACCOUNT_NUMBER-1]=@BILL_BANK_ACCOUNT_NUMBER_1,
                                   [BILL_BANK_ACCOUNT_NUMBER-2]=@BILL_BANK_ACCOUNT_NUMBER_2,
                                   [BILL_BANK_ACCOUNT_NUMBER-3]=@BILL_BANK_ACCOUNT_NUMBER_3,
                                   [BILL_BANK_ACCOUNT_NUMBER-4]=@BILL_BANK_ACCOUNT_NUMBER_4,
                                   [UPDATED_AT]= @CURRENT_DATETIME,
                                   [UPDATED_BY]=@CURRENT_USER
                             WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                             AND [REQ_SEQ] = @REQ_SEQ";
        #endregion

        #region Constructors

        public BANK_ACCOUNT_MASTER(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region Update
        public void Update(BOL_BANK_ACCOUNT_MASTER BANK_ACCOUNT, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", BANK_ACCOUNT.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", BANK_ACCOUNT.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_1", BANK_ACCOUNT.BILL_BANK_ACCOUNT_NAME_1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_2", BANK_ACCOUNT.BILL_BANK_ACCOUNT_NAME_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_3", BANK_ACCOUNT.BILL_BANK_ACCOUNT_NAME_3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_4", BANK_ACCOUNT.BILL_BANK_ACCOUNT_NAME_4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", BANK_ACCOUNT.UPDATED_AT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", BANK_ACCOUNT.UPDATED_BY));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region IsAlreadyUsed
        public bool IsAlreadyUpdated(BOL_BANK_ACCOUNT_MASTER oBANK_ACCOUNT_MASTER, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strAlreadyUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oBANK_ACCOUNT_MASTER.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oBANK_ACCOUNT_MASTER.REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);

            int count;
            try
            {
                count = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                count = 0;
            }

            if (count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CustomerMasterMaintenanceUpdate
        public void BankAccountMasterUpdate(BOL_BANK_ACCOUNT_MASTER oCUSTOMER_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strBankAccountMasterUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCUSTOMER_MASTER.COMPANY_NO_BOX != null ? oCUSTOMER_MASTER.COMPANY_NO_BOX : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oCUSTOMER_MASTER.REQ_SEQ.ToString() != null ? oCUSTOMER_MASTER.REQ_SEQ : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_1", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_1 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_1 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_2", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_2 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_2 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_3", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_3 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_3 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_4", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_4 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NAME_4 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_1", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_1 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_1 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_2", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_2 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_2 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_3", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_3 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_3 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NUMBER_4", oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_4 != null ? oCUSTOMER_MASTER.BILL_BANK_ACCOUNT_NUMBER_4 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion
    }
    #endregion

}
