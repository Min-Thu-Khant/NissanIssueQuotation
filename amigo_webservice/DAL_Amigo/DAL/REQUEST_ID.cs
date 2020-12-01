using System;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region REQUEST_ID
    public class REQUEST_ID
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strCompanyCodeList   = @"SELECT ROW_NUMBER() OVER(ORDER BY COMPANY_NO_BOX ASC) AS No,                              
                                        ' ' as CK,
                                        ' ' as MK,
                                        COMPANY_NO_BOX,
                                        (CASE AUTO_INDEX_ID 
                                        WHEN 'CNSUP' THEN N'サプライヤ' 
                                        WHEN 'CNMAKER' THEN N'要元' 
                                        WHEN 'CNSOCIOS' THEN N'socios' 
                                        END)AUTO_INDEX_ID,
                                        COMPANY_NAME,
                                        PASSWORD,
                                        FORMAT(PASSWORD_SET_DATE, 'yyyy/MM/dd HH:mm') PASSWORD_SET_DATE,
                                        FORMAT(PASSWORD_EXPIRATION_DATE, 'yyyy/MM/dd HH:mm') PASSWORD_EXPIRATION_DATE,
                                        EMAIL_ADDRESS,
                                        FORMAT(EMAIL_SEND_DATE, 'yyyy/MM/dd HH:mm') EMAIL_SEND_DATE,
                                        CONVERT(VARCHAR,LOGIN_FAIL_COUNT) LOGIN_FAIL_COUNT,
                                        SESSION_ID,
                                        FORMAT(LAST_ACCESS_DATE, 'yyyy/MM/dd HH:mm') LAST_ACCESS_DATE,
										FORMAT(LAST_FAIL_DATE, 'yyyy/MM/dd HH:mm') LAST_FAIL_DATE,
                                        GD_CODE,
                                        DISABLED_FLG,
                                        MEMO,
                                        UPDATED_AT,
                                        UPDATED_BY,
                                        '' AS UPDATE_MESSAGE,
                                        SOCIOS_USER_FLG,
                                        COMPANY_BOX,
										COMPANY_NO,
                                        ROW_NUMBER() OVER(ORDER BY COMPANY_NO_BOX ASC) AS ROW_ID,
                                        UPDATED_AT AS UPDATED_AT_RAW
                                        FROM REQUEST_ID
                                        WHERE ISNULL(COMPANY_NO_BOX,'') LIKE '%' + @COMPANY_NO_BOX + '%'
                                        AND ISNULL(COMPANY_NAME,'') LIKE '%' + @COMPANY_NAME + '%'
                                        AND ISNULL(EMAIL_ADDRESS,'') LIKE '%' + @EMAIL_ADDRESS + '%'
                                        ORDER BY COMPANY_NO_BOX ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";

        string strCompanyCodeListTotal = @"SELECT COUNT(COMPANY_NO_BOX) 
                                           FROM REQUEST_ID
                                           WHERE COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
                                           AND COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
                                           AND EMAIL_ADDRESS LIKE '%' + @EMAIL_ADDRESS + '%'";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT(COMPANY_NO_BOX) AS COUNT
                                                FROM REQUEST_ID 
                                                WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                                AND UPDATED_AT @UPDATED_AT";

        string strDelete = @"DELETE FROM REQUEST_ID 
                             WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX";

        string strInsert = @"INSERT INTO [REQUEST_ID]
                           ([COMPANY_NO_BOX]
                           ,[AUTO_INDEX_ID]
                           ,[COMPANY_NAME]
                           ,[PASSWORD]
                           ,[PASSWORD_HASHED]
                           ,[PASSWORD_SET_DATE]
                           ,[PASSWORD_EXPIRATION_DATE]
                           ,[EMAIL_ADDRESS]
                           ,[EMAIL_SEND_DATE]
                           ,[LOGIN_FAIL_COUNT]
                           ,[SESSION_ID]
                           ,[LAST_ACCESS_DATE]
                           ,[LAST_FAIL_DATE]
                           ,[GD]
                           ,[GD_CODE]
                           ,[DISABLED_FLG]
                           ,[MEMO]
                           ,[SOCIOS_USER_FLG]
                           ,[COMPANY_NO]
                           ,[COMPANY_BOX]
                           ,[LOGIN_TYPE]
                           ,[MENU_PATTERN_ID]
                           ,[CREATED_AT]
                           ,[CREATED_BY]
                           ,[UPDATED_AT]
                           ,[UPDATED_BY])
                     VALUES
                           (@COMPANY_NO_BOX,
                            @AUTO_INDEX_ID,
                            @COMPANY_NAME,
                            @PASSWORD,
                            @PASSWORD_HASHED,
                            @PASSWORD_SET_DATE,
                            @PASSWORD_EXPIRATION_DATE,
                            @EMAIL_ADDRESS,
                            @EMAIL_SEND_DATE, 
                            @LOGIN_FAIL_COUNT,
                            @SESSION_ID,
                            @LAST_ACCESS_DATE,
                            @LAST_FAIL_DATE, 
                            @GD, 
                            @GD_CODE,
                            @DISABLED_FLG,
                            @MEMO, 
                            @SOCIOS_USER_FLG,
                            @COMPANY_NO,
                            @COMPANY_BOX,
                            NULL,
                            1,
                            @CURRENT_DATETIME,
                            @CURRENT_USER,
                            @CURRENT_DATETIME,
                            @CURRENT_USER)";

        string strUpdate = @"UPDATE [REQUEST_ID]
                               SET [COMPANY_NAME] = @COMPANY_NAME,
                                   [PASSWORD] = @PASSWORD,
                                   [PASSWORD_SET_DATE] = @PASSWORD_SET_DATE,
                                   [PASSWORD_EXPIRATION_DATE] = @PASSWORD_EXPIRATION_DATE,
                                   [EMAIL_ADDRESS] = @EMAIL_ADDRESS,
                                   [LOGIN_FAIL_COUNT] = @LOGIN_FAIL_COUNT,
                                   [GD] = @GD,
                                   [GD_CODE] = @GD_CODE,
                                   [DISABLED_FLG] = @DISABLED_FLG, 
                                   [MEMO] = @MEMO,
                                   [UPDATED_AT] = @CURRENT_DATETIME,
                                   [UPDATED_BY] = @CURRENT_USER
                             WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX 
                             AND [UPDATED_AT] @UPDATED_AT";
        string strUpdateMailDate = @"UPDATE [REQUEST_ID]
                               SET [EMAIL_SEND_DATE] = @EMAIL_SEND_DATE,
                                   [UPDATED_AT] = @CURRENT_DATETIME,
                                   [UPDATED_BY] = @CURRENT_USER
                             WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX 
                             AND [UPDATED_AT] @UPDATED_AT";

        string strUsageInformationRegistrationList = @"SELECT ROW_NUMBER() OVER(ORDER BY EDI_ACCOUNT.COMPANY_NO_BOX ASC) AS No,
                                                    ' ' as CK,
                                                    ' ' as MK,
                                                    EDI_ACCOUNT.EDI_ACCOUNT,
                                                    REQUEST_ID.COMPANY_NO_BOX,
                                                    REQUEST_DETAIL.COMPANY_NAME,
                                                    REQUEST_ID.GD_CODE,
                                                    EDI_ACCOUNT.CONSIGN_FLG,
                                                    EDI_ACCOUNT.LOGIN_TYPE,
                                                    EDI_ACCOUNT.MAKER1,
                                                    EDI_ACCOUNT.MAKER2,
                                                    EDI_ACCOUNT.MAKER3,
                                                    EDI_ACCOUNT.MAKER4,
                                                    EDI_ACCOUNT.MAKER5,
                                                    EDI_ACCOUNT.MAKER6,
                                                    EDI_ACCOUNT.MAKER7,
                                                    EDI_ACCOUNT.MAKER8,
                                                    EDI_ACCOUNT.MAKER9,
                                                    EDI_ACCOUNT.MAKER10,
                                                    REQUEST_DETAIL.BOX_SIZE,
													CASE REQUEST_DETAIL.CONTRACT_PLAN
														WHEN 'SERVER' THEN 'F'
														WHEN 'SERVERRIGHT' THEN 'L'
														WHEN 'BROWSERAUTO' THEN 'C'
													END AS SERVER_CONNECTION_TYPE,
                                                    REQUEST_DETAIL.CAI_SERVER_IP_ADDRESS,
                                                    REQUEST_DETAIL.PLAN_AMIGO_BIZ,
                                                    REQUEST_DETAIL.PLAN_AMIGO_CAI,
                                                    ADD1.MAIL_ADDRESS AS MAIL_ADDRESS1,
													ADD2.MAIL_ADDRESS AS MAIL_ADDRESS2,
													ADD3.MAIL_ADDRESS AS MAIL_ADDRESS3,
                                                    EDI_ACCOUNT.ADM_USER_ID,
                                                    EDI_ACCOUNT.ADM_PASSWORD,
                                                    EDI_ACCOUNT.ATDL_USER_ID,
                                                    EDI_ACCOUNT.ATDL_PASSWORD,
                                                    EDI_ACCOUNT.SSHGW_USER_ID,
                                                    EDI_ACCOUNT.SSHGW_PUBLIC_KEY,
                                                    EDI_ACCOUNT.UPDATED_AT,
                                                    EDI_ACCOUNT.UPDATED_BY,
                                                    '' AS UPDATE_MESSAGE,
                                                    EDI_ACCOUNT.UPDATED_AT AS UPDATED_AT_RAW,
                                                    ROW_NUMBER() OVER(ORDER BY EDI_ACCOUNT.COMPANY_NO_BOX ASC) AS ROW_ID
                                                    FROM REQUEST_ID
                                                    LEFT JOIN 
	                                                    (SELECT REQUEST_DETAIL.* FROM REQUEST_DETAIL RIGHT JOIN (SELECT MAX(REQ_SEQ ) AS REQ_SEQ, COMPANY_NO_BOX 
	                                                    FROM REQUEST_DETAIL GROUP BY COMPANY_NO_BOX) MAX ON MAX.COMPANY_NO_BOX=REQUEST_DETAIL.COMPANY_NO_BOX AND MAX.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ) AS REQUEST_DETAIL
	                                                    ON REQUEST_DETAIL.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                                    LEFT JOIN 
	                                                    EDI_ACCOUNT
	                                                    ON REQUEST_ID.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                                    LEFT JOIN REQ_ADDRESS ADD1 
	                                                    ON ADD1.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                    AND ADD1.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														AND ADD1.REQ_ADDRESS_SEQ = 1
	                                                    AND ADD1.TYPE = 4
													LEFT JOIN REQ_ADDRESS ADD2 
	                                                    ON ADD2.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                    AND ADD2.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														AND ADD2.REQ_ADDRESS_SEQ = 2
	                                                    AND ADD2.TYPE = 4
													LEFT JOIN REQ_ADDRESS ADD3 
	                                                    ON ADD3.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                    AND ADD3.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														AND ADD3.REQ_ADDRESS_SEQ = 3
	                                                    AND ADD3.TYPE = 4
                                                    WHERE 
	                                                    REQUEST_ID.COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
	                                                    AND REQUEST_DETAIL.COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
	                                                    AND EDI_ACCOUNT.EDI_ACCOUNT LIKE '%' + @EDI_ACCOUNT + '%'
                                                    ORDER BY COMPANY_NO_BOX ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";

        string strUsageInformationRegistrationListTotal = @"SELECT COUNT(EDI_ACCOUNT.COMPANY_NO_BOX) COMPANY_NO_BOX
                                                            FROM REQUEST_ID
                                                            LEFT JOIN 
	                                                            (SELECT REQUEST_DETAIL.* FROM REQUEST_DETAIL RIGHT JOIN (SELECT MAX(REQ_SEQ ) AS REQ_SEQ, COMPANY_NO_BOX 
	                                                            FROM REQUEST_DETAIL GROUP BY COMPANY_NO_BOX) MAX ON MAX.COMPANY_NO_BOX=REQUEST_DETAIL.COMPANY_NO_BOX AND MAX.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ) AS REQUEST_DETAIL
	                                                            ON REQUEST_DETAIL.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                                            LEFT JOIN 
	                                                            EDI_ACCOUNT
	                                                            ON REQUEST_ID.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                                            LEFT JOIN REQ_ADDRESS ADD1 
	                                                            ON ADD1.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                            AND ADD1.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														        AND ADD1.REQ_ADDRESS_SEQ = 1
	                                                            AND ADD1.TYPE = 4
													        LEFT JOIN REQ_ADDRESS ADD2 
	                                                            ON ADD2.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                            AND ADD2.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														        AND ADD2.REQ_ADDRESS_SEQ = 2
	                                                            AND ADD2.TYPE = 4
													        LEFT JOIN REQ_ADDRESS ADD3 
	                                                            ON ADD3.COMPANY_NO_BOX = REQUEST_DETAIL.COMPANY_NO_BOX
	                                                            AND ADD3.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ
														        AND ADD3.REQ_ADDRESS_SEQ = 3
	                                                            AND ADD3.TYPE = 4
                                                            WHERE 
	                                                            REQUEST_ID.COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
	                                                            AND REQUEST_DETAIL.COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
	                                                            AND EDI_ACCOUNT.EDI_ACCOUNT LIKE '%' + @EDI_ACCOUNT + '%'
                                                            ORDER BY COMPANY_NO_BOX ASC";

        string strScreenData = @"SELECT REQUEST_ID.COMPANY_NO_BOX,EDI_ACCOUNT.EDI_ACCOUNT,EMAIL_ADDRESS 
                                FROM REQUEST_ID,EDI_ACCOUNT
                                WHERE REQUEST_ID.COMPANY_NO_BOX=EDI_ACCOUNT.COMPANY_NO_BOX
                                AND REQUEST_ID.COMPANY_NO_BOX=@COMPANY_NO_BOX";
        string strGetMaxCompanyBox = @"SELECT MAX(COMPANY_BOX) +1 AS BOX FROM REQUEST_ID WHERE COMPANY_NO = @COMPANY_NO";
        #endregion

        #region Usage Application 

        string strUpdateForUsageApplication = @"UPDATE [REQUEST_ID]
                                                SET [GD] = @GD,
                                                [UPDATED_BY] = @CURRENT_USER,
                                                [UPDATED_AT] = @CURRENT_DATETIME
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                                                ";
                                                //AND[UPDATED_AT] @UPDATED_AT

        string strSearchWithKeyForConfirmationRequest = @"SELECT COUNT([COMPANY_NO_BOX]) AS COUNT
                                                FROM [REQUEST_ID]
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX";

        string strUpdateForConfirmationRequest = @"UPDATE [REQUEST_ID]
                                                SET [GD] = @GD,
                                                [UPDATED_AT] = @CURRENT_DATETIME,
                                                [UPDATED_BY] = @CURRENT_USER
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX";

        string strGetGDCode = @"SELECT GD_CODE
                                FROM [REQUEST_ID]
                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX";


        #endregion

        #region Constructors

        public REQUEST_ID(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region GetCompanyCodeList
        public DataTable GetCompanyCodeList(string COMPANY_NO_BOX, string COMPANY_NAME, string EMAIL, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCompanyCodeListTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", EMAIL));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            oMaster = new ConnectionMaster(strConnectionString, strCompanyCodeList);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", EMAIL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetCompanyCodeList
        public int GetMaxCompanyBox(string COMPANY_NO, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetMaxCompanyBox);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO", COMPANY_NO));
            oMaster.ExcuteQuery(4, out strMsg);
            if (oMaster.dtExcuted.Rows.Count > 0)
            {
                return int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_REQUEST_ID oREQUEST_ID, out string strMsg)
        {
            //handle Null value at where conditions
            strSearchWithKeyAndUpdated_at = Utility.StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW != null ? oREQUEST_ID.UPDATED_AT_RAW : (object)DBNull.Value));
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

            if (count <=0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Delete
        public void Delete(BOL_REQUEST_ID oREQUEST_ID, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDelete);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.ExcuteQuery(3, out strMsg);
        }
        #endregion

        #region Insert
        public void Insert(BOL_REQUEST_ID oREQUEST_ID, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX_ID", oREQUEST_ID.AUTO_INDEX_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", oREQUEST_ID.COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD", oREQUEST_ID.PASSWORD != null ? oREQUEST_ID.PASSWORD : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD_HASHED", oREQUEST_ID.PASSWORD_HASHED != null ? oREQUEST_ID.PASSWORD_HASHED : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD_SET_DATE", oREQUEST_ID.PASSWORD_SET_DATE != null ? Convert.ToDateTime(oREQUEST_ID.PASSWORD_SET_DATE): (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD_EXPIRATION_DATE", oREQUEST_ID.PASSWORD_EXPIRATION_DATE != null ? Convert.ToDateTime(oREQUEST_ID.PASSWORD_EXPIRATION_DATE) : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", oREQUEST_ID.EMAIL_ADDRESS !=null ? oREQUEST_ID.EMAIL_ADDRESS : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_SEND_DATE", oREQUEST_ID.EMAIL_SEND_DATE != null ? Convert.ToDateTime(oREQUEST_ID.EMAIL_SEND_DATE) : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LOGIN_FAIL_COUNT", oREQUEST_ID.LOGIN_FAIL_COUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SESSION_ID", oREQUEST_ID.SESSION_ID !=null ? oREQUEST_ID.SESSION_ID : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LAST_ACCESS_DATE", oREQUEST_ID.LAST_ACCESS_DATE !=null ? oREQUEST_ID.LAST_ACCESS_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LAST_FAIL_DATE", oREQUEST_ID.LAST_FAIL_DATE !=null ? oREQUEST_ID.LAST_FAIL_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", oREQUEST_ID.GD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD_CODE", oREQUEST_ID.GD_CODE != null ? oREQUEST_ID.GD_CODE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISABLED_FLG", oREQUEST_ID.DISABLED_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MEMO", oREQUEST_ID.MEMO !=null ? oREQUEST_ID.MEMO : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SOCIOS_USER_FLG", oREQUEST_ID.SOCIOS_USER_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO", oREQUEST_ID.COMPANY_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_BOX", oREQUEST_ID.COMPANY_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(6, out strMsg);
        }
        #endregion

        #region Update
        public void Update(BOL_REQUEST_ID oREQUEST_ID, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdate = Utility.StringUtil.handleNullStringDate(strUpdate, "@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW);

            //updated at

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", oREQUEST_ID.COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD", oREQUEST_ID.PASSWORD != null ? oREQUEST_ID.PASSWORD : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD_SET_DATE", oREQUEST_ID.PASSWORD_SET_DATE != null ? Convert.ToDateTime(oREQUEST_ID.PASSWORD_SET_DATE) : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD_EXPIRATION_DATE",oREQUEST_ID.PASSWORD_EXPIRATION_DATE != null ? Convert.ToDateTime(oREQUEST_ID.PASSWORD_EXPIRATION_DATE) : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", oREQUEST_ID.EMAIL_ADDRESS !=null ? oREQUEST_ID.EMAIL_ADDRESS : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LOGIN_FAIL_COUNT", oREQUEST_ID.LOGIN_FAIL_COUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", oREQUEST_ID.GD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD_CODE", oREQUEST_ID.GD_CODE != null ? oREQUEST_ID.GD_CODE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISABLED_FLG", oREQUEST_ID.DISABLED_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MEMO", oREQUEST_ID.MEMO != null ? oREQUEST_ID.MEMO : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW != null ? oREQUEST_ID.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region UpdateMailDate
        public void UpdateMailDate(BOL_REQUEST_ID oREQUEST_ID, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdateMailDate = Utility.StringUtil.handleNullStringDate(strUpdateMailDate, "@UPDATED_AT", oREQUEST_ID.UPDATED_AT);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateMailDate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_SEND_DATE", oREQUEST_ID.EMAIL_SEND_DATE != null ? Convert.ToDateTime(oREQUEST_ID.EMAIL_SEND_DATE).ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW != null ? oREQUEST_ID.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region GetUsageInformationRegistrationList
        public DataTable GetUsageInformationRegistrationList(string COMPANY_NO_BOX, string COMPANY_NAME, string EDI_ACCOUNT, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUsageInformationRegistrationListTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            oMaster = new ConnectionMaster(strConnectionString, strUsageInformationRegistrationList);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Update For Usage ApplicationList Screen
        public void UpdateUsageApplication(BOL_REQUEST_ID oREQUEST_ID, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ////handle Null value at where conditions
            //strUpdateForUsageApplication = Utility.StringUtil.handleNullStringDate(strUpdateForUsageApplication, "@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForUsageApplication);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", oREQUEST_ID.GD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            //oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_ID.UPDATED_AT_RAW != null ? oREQUEST_ID.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdatedConfirmationRequest(BOL_REQUEST_ID oREQUEST_ID, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyForConfirmationRequest);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));
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

        #region ConfirmationRequest For ApplicationList Screen
        public void GDConfirmationRequestUpdate(BOL_REQUEST_ID oREQUEST_ID, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForConfirmationRequest);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", oREQUEST_ID.GD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_ID.COMPANY_NO_BOX));

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region GetGDCode For Usage Application
        public string GetGDCode(string COMPANY_NO_BOX, out string strMsg)
        {
            string GDCode;
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetGDCode);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.ExcuteQuery(4, out strMsg);
            GDCode = oMaster.dtExcuted.Rows[0][0].ToString();
            return GDCode;
        }
        #endregion
        #endregion

        #region GetScreenData For RegisterCompleteNotificationSending Screen
        public DataTable GetScreenData(string COMPANY_NO_BOX, out string strMsg)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strScreenData);
            //result
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

    }

}
