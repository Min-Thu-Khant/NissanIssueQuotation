using System;
using System.Data.SqlClient;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region EDI_ACCOUNT
    public class EDI_ACCOUNT
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strInsert = @"INSERT INTO EDI_ACCOUNT
                            (EDI_ACCOUNT
                            ,COMPANY_NO_BOX
                            ,CONSIGN_FLG
                            ,LOGIN_TYPE
                            ,MAKER1
                            ,MAKER2
                            ,MAKER3
                            ,MAKER4
                            ,MAKER5
                            ,MAKER6
                            ,MAKER7
                            ,MAKER8
                            ,MAKER9
                            ,MAKER10
                            ,ADM_USER_ID
                            ,ADM_PASSWORD
                            ,ADM_PASSWORD_HASHED
                            ,ATDL_USER_ID
                            ,ATDL_PASSWORD
                            ,ATDL_PASSWORD_HASHED
                            ,SSHGW_USER_ID
                            ,SSHGW_PUBLIC_KEY
                            ,CREATED_AT
                            ,CREATED_BY
                            ,UPDATED_AT
                            ,UPDATED_BY)
                        VALUES
                            (@EDI_ACCOUNT
                            ,@COMPANY_NO_BOX
                            ,@CONSIGN_FLG
                            ,@LOGIN_TYPE
                            ,@MAKER1
                            ,@MAKER2
                            ,@MAKER3
                            ,@MAKER4
                            ,@MAKER5
                            ,@MAKER6
                            ,@MAKER7
                            ,@MAKER8
                            ,@MAKER9
                            ,@MAKER10
                            ,@ADM_USER_ID
                            ,@ADM_PASSWORD
                            ,@ADM_PASSWORD_HASHED
                            ,@ATDL_USER_ID
                            ,@ATDL_PASSWORD
                            ,@ATDL_PASSWORD_HASHED
                            ,@SSHGW_USER_ID
                            ,@SSHGW_PUBLIC_KEY
                            ,@CURRENT_TIME
                            ,@CURRENT_USER
                            ,@CURRENT_TIME
                            ,@CURRENT_USER)";

        string strDelete = @"DELETE FROM EDI_ACCOUNT 
                             WHERE EDI_ACCOUNT = @EDI_ACCOUNT
                             AND UPDATED_AT @UPDATED_AT";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT(EDI_ACCOUNT) AS COUNT
                                                FROM EDI_ACCOUNT 
                                                WHERE EDI_ACCOUNT = @EDI_ACCOUNT
                                                AND UPDATED_AT @UPDATED_AT";
        string strUpdate = @"UPDATE EDI_ACCOUNT
                            SET CONSIGN_FLG = @CONSIGN_FLG
                                ,LOGIN_TYPE = @LOGIN_TYPE
                                ,MAKER1 = @MAKER1
                                ,MAKER2 = @MAKER2
	                            ,MAKER3 = @MAKER3
	                            ,MAKER4 = @MAKER4
	                            ,MAKER5 = @MAKER5
	                            ,MAKER6 = @MAKER6
	                            ,MAKER7 = @MAKER7
	                            ,MAKER8 = @MAKER8
	                            ,MAKER9 = @MAKER9
	                            ,MAKER10 = @MAKER10
                                ,ADM_USER_ID = @ADM_USER_ID
                                ,ADM_PASSWORD = @ADM_PASSWORD
                                ,ADM_PASSWORD_HASHED = @ADM_PASSWORD_HASHED
                                ,ATDL_USER_ID = @ATDL_USER_ID
                                ,ATDL_PASSWORD = @ATDL_PASSWORD
                                ,ATDL_PASSWORD_HASHED = @ATDL_PASSWORD_HASHED
                                ,SSHGW_USER_ID = @SSHGW_USER_ID
                                ,SSHGW_PUBLIC_KEY = @SSHGW_PUBLIC_KEY
                                ,UPDATED_AT = @CURRENT_DATETIME
                                ,UPDATED_BY = @CURRENT_USER
                             WHERE EDI_ACCOUNT=@EDI_ACCOUNT
                             AND UPDATED_AT @UPDATED_AT";

        string strGetRecordByCompanyNoBox = @"SELECT COUNT(COMPANY_NO_BOX) FROM EDI_ACCOUNT WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX";
        string strGetRecordByEDIAccount = @"SELECT COUNT(EDI_ACCOUNT) FROM EDI_ACCOUNT WHERE EDI_ACCOUNT = @EDI_ACCOUNT";

        #endregion

        #region Constructors

        public EDI_ACCOUNT(string con)
        {            
            strConnectionString = con;

        }

        #endregion

        #region Insert
        public void Insert(BOL_EDI_ACCOUNT oEDI_ACCOUNT, string CURRENT_TIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_ACCOUNT.EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oEDI_ACCOUNT.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONSIGN_FLG", oEDI_ACCOUNT.CONSIGN_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LOGIN_TYPE", oEDI_ACCOUNT.LOGIN_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER1", oEDI_ACCOUNT.MAKER1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER2", oEDI_ACCOUNT.MAKER2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER3", oEDI_ACCOUNT.MAKER3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER4", oEDI_ACCOUNT.MAKER4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER5", oEDI_ACCOUNT.MAKER5));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER6", oEDI_ACCOUNT.MAKER6));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER7", oEDI_ACCOUNT.MAKER7));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER8", oEDI_ACCOUNT.MAKER8));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER9", oEDI_ACCOUNT.MAKER9));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER10", oEDI_ACCOUNT.MAKER10));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_USER_ID", oEDI_ACCOUNT.ADM_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_PASSWORD", oEDI_ACCOUNT.ADM_PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_PASSWORD_HASHED", oEDI_ACCOUNT.ADM_PASSWORD_HASHED));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_USER_ID", oEDI_ACCOUNT.ATDL_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_PASSWORD", oEDI_ACCOUNT.ATDL_PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_PASSWORD_HASHED", oEDI_ACCOUNT.ATDL_PASSWORD_HASHED));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SSHGW_USER_ID", oEDI_ACCOUNT.SSHGW_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SSHGW_PUBLIC_KEY", oEDI_ACCOUNT.SSHGW_PUBLIC_KEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_TIME", CURRENT_TIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(6, out strMsg);
        }
        #endregion

        #region Delete
        public void Delete(BOL_EDI_ACCOUNT oEDI_ACCOUNT, out String strMsg)
        {
            //handle Null value at where conditions
            strDelete = Utility.StringUtil.handleNullStringDate(strDelete, "@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDelete);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_ACCOUNT.EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT_RAW));
            oMaster.ExcuteQuery(3, out strMsg);
        }

        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_EDI_ACCOUNT oEDI_ACCOUNT, out string strMsg)
        {
            //handle Null value at where conditions
            strSearchWithKeyAndUpdated_at = Utility.StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_ACCOUNT.EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT_RAW));
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

        #region Update
        public void Update(BOL_EDI_ACCOUNT oEDI_ACCOUNT, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdate = Utility.StringUtil.handleNullStringDate(strUpdate, "@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONSIGN_FLG", oEDI_ACCOUNT.CONSIGN_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LOGIN_TYPE", oEDI_ACCOUNT.LOGIN_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER1", oEDI_ACCOUNT.MAKER1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER2", oEDI_ACCOUNT.MAKER2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER3", oEDI_ACCOUNT.MAKER3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER4", oEDI_ACCOUNT.MAKER4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER5", oEDI_ACCOUNT.MAKER5));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER6", oEDI_ACCOUNT.MAKER6));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER7", oEDI_ACCOUNT.MAKER7));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER8", oEDI_ACCOUNT.MAKER8));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER9", oEDI_ACCOUNT.MAKER9));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MAKER10", oEDI_ACCOUNT.MAKER10));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_USER_ID", oEDI_ACCOUNT.ADM_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_PASSWORD", oEDI_ACCOUNT.ADM_PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADM_PASSWORD_HASHED", oEDI_ACCOUNT.ADM_PASSWORD_HASHED));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_USER_ID", oEDI_ACCOUNT.ATDL_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_PASSWORD", oEDI_ACCOUNT.ATDL_PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ATDL_PASSWORD_HASHED", oEDI_ACCOUNT.ATDL_PASSWORD_HASHED));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SSHGW_USER_ID", oEDI_ACCOUNT.SSHGW_USER_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SSHGW_PUBLIC_KEY", oEDI_ACCOUNT.SSHGW_PUBLIC_KEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oEDI_ACCOUNT.UPDATED_AT_RAW != null ? oEDI_ACCOUNT.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_ACCOUNT.EDI_ACCOUNT));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region IsCompanyNoBoxAlreadyRegistered
        public bool IsCompanyNoBoxAlreadyRegistered(string COMPANY_NO_BOX, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetRecordByCompanyNoBox);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
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

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region IsEDIAccountAlreadyRegistered
        public bool IsEDIAccountAlreadyRegistered(string EDI_ACCOUNT, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetRecordByEDIAccount);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
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

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

    }
    #endregion

}
