using System;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region REQUEST_DETAIL
    public class REQUEST_DETAIL
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strGetInitialData = @"SELECT
                                    REQUEST_DETAIL.COMPANY_NO_BOX, REQUEST_DETAIL.REQ_SEQ,
                                    EDI_ACCOUNT.EDI_ACCOUNT,
                                    FORMAT(REQUEST_DETAIL.START_USE_DATE, 'yyyy/MM/dd') START_USE_DATE,
                                    REQUEST_DETAIL.INPUT_PERSON,
                                    REQUEST_ID.EMAIL_ADDRESS, REQUEST_DETAIL.CONTRACT_PLAN
                                    FROM REQUEST_DETAIL
                                    LEFT JOIN EDI_ACCOUNT
                                    ON REQUEST_DETAIL.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                    INNER JOIN REQUEST_ID
                                    ON REQUEST_DETAIL.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                    WHERE REQUEST_DETAIL.COMPANY_NO_BOX = @COMPANY_NO_BOX
                                    AND REQUEST_DETAIL.REQ_SEQ = @REQ_SEQ";

        string strUpdateIndex = @"UPDATE [AUTO_INDEX]
                                   SET [AUTO_INDEX] = @AUTO_INDEX,
                                       [UPDATED_AT] = @UPDATED_AT,
                                       [UPDATED_BY] = @UPDATED_BY
                                  WHERE [AUTO_INDEX_ID] = @AUTO_INDEX_ID";
        string strGetQuotationData = @"SELECT REQ.COMPANY_NO_BOX,UM.CONTRACT_CODE,UM.FEE_STRUCTURE,UM.CONTRACT_NAME,UM.CONTRACT_QTY,UM.INITIAL_COST,UM.MONTHLY_COST,
                                    ISNULL(REQ.QUANTITY,0) QUANTITY,Req.Type,
                                    ISNULL(UM.INITIAL_COST,0) * ISNULL(REQ.QUANTITY,0) INITIAL_EXPENSE,
                                    ISNULL(UM.MONTHLY_COST,0) * ISNULL(REQ.QUANTITY,0) MONTHLY_USAGE_FEE,
                                    REQ.UPDATED_AT, UM.UPDATED_AT,REQ.CONTRACT_UNIT
                                    FROM REQ_USAGE_FEE REQ 
                                    LEFT JOIN 
                                    (SELECT CONTRACT_CODE,ADOPTION_DATE,FEE_STRUCTURE,CONTRACT_NAME,CONTRACT_QTY,CONTRACT_UNIT,INITIAL_COST,DISPLAY_ORDER,UPDATED_AT,
                                    MONTHLY_COST,
                                    ROW_NUMBER() OVER(PARTITION BY CONTRACT_CODE ORDER BY CONTRACT_CODE, ADOPTION_DATE DESC) num
                                    FROM USAGE_FEE_MASTER
                                    WHERE CONVERT(varchar(10),ADOPTION_DATE,112) <= CONVERT(varchar(10),GETDATE(),112)
                                    ) UM 
                                    ON UM.CONTRACT_CODE = REQ.CONTRACT_CODE
                                    WHERE REQ.COMPANY_NO_BOX = '@COMPANY_NO_BOX'
                                    AND REQ.REQ_SEQ = @REQ_SEQ
                                    @Extra_Condition
                                    ORDER BY REQ.Type, UM.DISPLAY_ORDER";
        


        #region Purchase Order
        string strUpdateForOrderRegister = @"UPDATE [REQUEST_DETAIL]
                               SET [ORDER_DATE] = @ORDER_DATE,
                                   [SYSTEM_EFFECTIVE_DATE] = @SYSTEM_EFFECTIVE_DATE,
                                   [SYSTEM_REGIST_DEADLINE] = @SYSTEM_REGIST_DEADLINE,
                                   [UPDATED_AT]=@CURRENT_DATETIME,
                                   [UPDATED_BY]=@CURRENT_USER
                             WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                             AND [REQ_SEQ] = @REQ_SEQ";

        string strSearch = @"SELECT 
                            REQUEST_DETAIL.TRANSACTION_TYPE,
                            REQUEST_DETAIL.REQ_TYPE,
                            FORMAT(REQUEST_DETAIL.START_USE_DATE, 'yyyy/MM/dd') START_USE_DATE,
                            REQUEST_DETAIL.AMIGO_COOPERATION_CHENGED_ITEMS,
                            REQUEST_DETAIL.CONTRACT_PLAN,
                            EDI_ACCOUNT.EDI_ACCOUNT,
                            EDI_ACCOUNT.COMPANY_NO_BOX,
                            REQUEST_DETAIL.REQ_SEQ
                            FROM REQUEST_DETAIL,EDI_ACCOUNT
                            WHERE REQUEST_DETAIL.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                            AND REQUEST_DETAIL.COMPANY_NO_BOX= @COMPANY_NO_BOX
                            AND REQUEST_DETAIL.REQ_SEQ= @REQ_SEQ";
        #endregion
        string strSearchWithCompanyNoBox = @"SELECT COMPANY_NO_BOX FROM REQUEST_DETAIL WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX";

        #region Applicatoin Cancel
        string strGetRequestDetailListTotal = @"DECLARE
                                            @var_REQ_DATE_FROM DATETIME2 = '@REQ_DATE_FROM', 
                                            @var_REQ_DATE_TO DATETIME2 = '@REQ_DATE_TO',
                                            @var_QUOTATION_DATE_FROM DATETIME2 = '@QUOTATION_DATE_FROM', 
                                            @var_QUOTATION_DATE_TO DATETIME2 = '@QUOTATION_DATE_TO',
                                            @var_ORDER_DATE_FROM DATETIME2 = '@ORDER_DATE_FROM', 
                                            @var_ORDER_DATE_TO DATETIME2 = '@ORDER_DATE_TO' 
                                            SELECT COUNT(REQUEST_DETAIL.COMPANY_NO_BOX)
                                           from REQUEST_DETAIL,REQUEST_ID
                                           WHERE REQUEST_DETAIL.COMPANY_NO_BOX=REQUEST_ID.COMPANY_NO_BOX
                                           AND REQUEST_DETAIL.COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
                                           AND REQUEST_DETAIL.COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
                                           AND REQUEST_DETAIL.CLOSE_FLG LIKE '%' + @CLOSE_FLG + '%'
                                           AND REQUEST_ID.GD LIKE '%' + @GD + '%'
                                           AND REQUEST_DETAIL.REQ_STATUS LIKE '%' + @REQ_STATUS + '%'
                                           @REQ_DATE_FromCondition
                                           @REQ_DATE_ToCondition
                                           @QUOTATION_DATE_FromCondition
                                           @QUOTATION_DATE_ToCondition
                                           @ORDER_DATE_FromCondition
                                           @ORDER_DATE_ToCondition
                                           AND REQUEST_DETAIL.SYSTEM_SETTING_STATUS LIKE '%' + @SYSTEM_SETTING_STATUS + '%'";


        string strGetRequestDetailList = @"DECLARE 
                                            @var_REQ_DATE_FROM DATETIME2 = '@REQ_DATE_FROM', 
                                            @var_REQ_DATE_TO DATETIME2 = '@REQ_DATE_TO',
                                            @var_QUOTATION_DATE_FROM DATETIME2 = '@QUOTATION_DATE_FROM', 
                                            @var_QUOTATION_DATE_TO DATETIME2 = '@QUOTATION_DATE_TO',
                                            @var_ORDER_DATE_FROM DATETIME2 = '@ORDER_DATE_FROM', 
                                            @var_ORDER_DATE_TO DATETIME2 = '@ORDER_DATE_TO' 

                                            SELECT ROW_NUMBER() OVER(ORDER BY REQUEST_DETAIL.CLOSE_FLG, REQUEST_DETAIL.REQ_DATE ASC) AS No,
	                                        ' ' as CK,
	                                        ' ' as MK,
                                            REQUEST_DETAIL.COMPANY_NO_BOX,
	                                        REQUEST_DETAIL.REQ_SEQ,
                                            REQUEST_DETAIL.COMPANY_NAME,
                                            CLOSE_FLG,
                                            CASE REQUEST_ID.GD 
		                                        WHEN '0' THEN N'無し' 
		                                        WHEN '1' THEN N'確認依頼中' 
		                                        WHEN '2' THEN N'確認済み' 
		                                        WHEN '9' THEN N'未確認' 
                                            END GD,
                                            CASE REQUEST_DETAIL.REQ_TYPE
		                                        WHEN 1 THEN N'新規'
		                                        WHEN 2 THEN N'変更'
		                                        WHEN 9 THEN N'解約'
	                                        END REQ_TYPE,
                                            CASE REQUEST_DETAIL.REQ_STATUS
		                                        WHEN 0 THEN N'仮登録(保存)'
		                                        WHEN 1 THEN N'申請中'
		                                        WHEN 2 THEN N'承認済'
		                                        WHEN 3 THEN N'否認'
		                                        WHEN 9 THEN N'申請取消'
	                                        END REQ_STATUS,
                                            FORMAT(REQ_DATE,'yyyy/MM/dd HH:mm') REQ_DATE,
											CASE 
												WHEN  REQUEST_DETAIL.REQ_STATUS = 2 OR REQUEST_DETAIL.REQ_STATUS = 9 THEN 
													CASE WHEN ISNULL(REQUEST_DETAIL.QUOTATION_DATE, '') <> '' THEN FORMAT(QUOTATION_DATE,'yyyy/MM/dd')
													ELSE '*'
												END
												ELSE ''
											END QUOTATION_DATE,
											CASE 
												WHEN REQUEST_DETAIL.REQ_STATUS = 2 OR REQUEST_DETAIL.REQ_STATUS = 9 THEN 
													CASE WHEN ISNULL(REQUEST_DETAIL.QUOTATION_DATE, '') <> '' THEN 
														CASE WHEN ISNULL(REQUEST_DETAIL.ORDER_DATE,'') <> '' THEN FORMAT(ORDER_DATE,'yyyy/MM/dd')
														ELSE '*'
														END
													ELSE ''
													END
												ELSE ''
											END ORDER_DATE,
                                            FORMAT(SYSTEM_EFFECTIVE_DATE,'yyyy/MM/dd HH:mm') SYSTEM_EFFECTIVE_DATE,
											CASE 
												WHEN  REQUEST_DETAIL.REQ_STATUS = 2 OR REQUEST_DETAIL.REQ_STATUS = 9 THEN 
												 CASE SYSTEM_SETTING_STATUS
													WHEN 0 THEN ''
													WHEN 1 THEN N'依頼中'
													WHEN 2 THEN N'設定済み'
													END 
												ELSE ''
											END SYSTEM_SETTING_STATUS,
										   CASE 
												WHEN  REQUEST_DETAIL.REQ_STATUS = 2 OR REQUEST_DETAIL.REQ_STATUS = 9 THEN 
													CASE WHEN ISNULL(REQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE, '') <> '' THEN FORMAT(COMPLETION_NOTIFICATION_DATE,'yyyy/MM/dd') 
												END
											END
                                             COMPLETION_NOTIFICATION_DATE,
                                            NML_CODE_NISSAN,
                                            NML_CODE_NS,
                                            NML_CODE_JATCO,
                                            NML_CODE_AK,
                                            NML_CODE_NK,
                                            DISABLED_FLG,
	                                        REQUEST_DETAIL.UPDATED_AT,
                                            REQUEST_ID.UPDATED_AT REQUEST_ID_UPDATED_AT,
	                                        REQUEST_DETAIL.UPDATED_BY,
                                            '' AS UPDATE_MESSAGE,
                                            REQUEST_DETAIL.UPDATED_AT UPDATED_AT_RAW,
                                            ROW_NUMBER() OVER(ORDER BY REQUEST_DETAIL.CLOSE_FLG, REQUEST_DETAIL.REQ_DATE ASC) AS ROW_ID
                                           FROM REQUEST_DETAIL,REQUEST_ID
                                           WHERE REQUEST_DETAIL.COMPANY_NO_BOX=REQUEST_ID.COMPANY_NO_BOX
                                           AND REQUEST_DETAIL.COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
                                           AND REQUEST_DETAIL.COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
                                           AND REQUEST_DETAIL.CLOSE_FLG LIKE '%' + @CLOSE_FLG + '%'
                                           AND REQUEST_ID.GD LIKE '%' + @GD + '%'
                                           AND REQUEST_DETAIL.REQ_STATUS LIKE '%' + @REQ_STATUS + '%'
                                           @REQ_DATE_FromCondition
                                           @REQ_DATE_ToCondition
                                           @QUOTATION_DATE_FromCondition
                                           @QUOTATION_DATE_ToCondition
                                           @ORDER_DATE_FromCondition
                                           @ORDER_DATE_ToCondition
                                           AND REQUEST_DETAIL.SYSTEM_SETTING_STATUS LIKE '%' + @SYSTEM_SETTING_STATUS + '%'
                                           ORDER BY REQUEST_DETAIL.CLOSE_FLG, REQUEST_DETAIL.REQ_DATE ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY
                                           ";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT([COMPANY_NO_BOX]) AS COUNT
                                                FROM [REQUEST_DETAIL]
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                                                AND [REQ_SEQ] = @REQ_SEQ
                                                AND [UPDATED_AT] @UPDATED_AT";

        string strUpdateForUsageApplication = @"UPDATE [REQUEST_DETAIL]
                                                SET 
                                                [CLOSE_FLG] = @CLOSE_FLG,
                                                [UPDATED_BY] = @CURRENT_USER,
                                                [UPDATED_AT] = @CURRENT_DATETIME
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                                                AND [REQ_SEQ] = @REQ_SEQ
                                                AND [UPDATED_AT] @UPDATED_AT";

  

        string strUpdateForApplicationCancel = @"UPDATE [REQUEST_DETAIL]
                                                SET [REQ_STATUS] = @REQ_STATUS,
                                                [UPDATED_AT] = @CURRENT_DATETIME,
                                                [UPDATED_BY] = @CURRENT_USER
                                                WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                                                AND [REQ_SEQ] = @REQ_SEQ
                                                AND [UPDATED_AT] @UPDATED_AT";
        string strGetSubProgramLists = @"SELECT PROGRAM_ID, PROGRAM_NAME FROM MENU_MASTER WHERE PROGRAM_ID IN ('CTS030', 'CTS040', 'CTS050', 'CTS070', 'CTS060');";

        string strGetClientCertificateDiff = @"SELECT OP_CLIENT-CLIENT_CERTIFICATE.CLIENT_CERTIFICATE_COUNT AS CLIENT_CERTIFICATE_DIFF
                                                    FROM  REQUEST_DETAIL
                                                JOIN 
                                                    (select count(CLIENT_CERTIFICATE.COMPANY_NO_BOX) as CLIENT_CERTIFICATE_COUNT,COMPANY_NO_BOX
                                                        from CLIENT_CERTIFICATE
                                                        where CLIENT_CERTIFICATE.FY=@FY
                                                        GROUP BY COMPANY_NO_BOX
                                                        ) AS CLIENT_CERTIFICATE
                                                ON REQUEST_DETAIL.COMPANY_NO_BOX = CLIENT_CERTIFICATE.COMPANY_NO_BOX
                                                WHERE  REQUEST_DETAIL.COMPANY_NO_BOX = @COMPANY_NO_BOX
                                                AND REQUEST_DETAIL.REQ_SEQ=@REQ_SEQ";

        string strGetPdfData = @"select TOP 1 EDI_ACCOUNT.MAKER1,REQUEST_DETAIL.CONTRACT_PLAN,
                                REQUEST_DETAIL.BOX_SIZE, REQUEST_DETAIL.PLAN_AMIGO_CAI,
                                REQUEST_DETAIL.PLAN_AMIGO_BIZ, REQUEST_DETAIL.OP_FLAT, REQUEST_DETAIL.CONTRACT_CSP,OP_CLIENT,
                                OP_BASIC_SERVICE+OP_ADD_SERVICE AS OP_SERVICE,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.sftp' AND CONFIG_SEQ= 1) as A,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.https' AND CONFIG_SEQ= 1) as B,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.url.jnx' AND CONFIG_SEQ= 1) as C,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.ipsec' AND CONFIG_SEQ= 1) as D,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.tpno' AND CONFIG_SEQ= 1) as E,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.corp' AND CONFIG_SEQ= 1) as F,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.url.internet' AND CONFIG_SEQ= 1) as G,
                                EDI_ACCOUNT.EDI_ACCOUNT, EDI_ACCOUNT.ADM_USER_ID,
                                EDI_ACCOUNT.ADM_PASSWORD, EDI_ACCOUNT.ATDL_USER_ID,
                                EDI_ACCOUNT.ATDL_PASSWORD, EDI_ACCOUNT.SSHGW_USER_ID,
                                EDI_ACCOUNT.SSHGW_PUBLIC_KEY, CAI_SERVER_IP_ADDRESS, CLIENT_CERTIFICATE.PASSWORD,
                                (SELECT STUFF((SELECT ', ' +
                                CLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO
                                FROM CLIENT_CERTIFICATE
                                WHERE CLIENT_CERTIFICATE.COMPANY_NO_BOX = CLIENT1.COMPANY_NO_BOX
                                FOR XML PATH('')), 1, 2, '') as CLIENT_CERTIFICATE_NO
                                FROM CLIENT_CERTIFICATE CLIENT1
                                WHERE CLIENT1.COMPANY_NO_BOX = @COMPANY_NO_BOX
                                GROUP BY COMPANY_NO_BOX) CLIENT_CERTIFICATE_NO ,
                                CAI_NETWORK,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.ssh.user' AND CONFIG_SEQ= 1) as K,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.private.key' AND CONFIG_SEQ= 1) as L,
                                CASE	
	                                WHEN REQUEST_DETAIL.CAI_NETWORK =1 THEN 
		                            (select STRING_VALUE1 as M from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.ip.address.internet' AND CONFIG_SEQ= 1)
	                            ELSE
		                            (select STRING_VALUE1 as N from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.ip.address.jnx' AND CONFIG_SEQ= 1)
                                END NETWORK,
                                CLIENT_CERTIFICATE.PASSWORD, CLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.support.name' AND CONFIG_SEQ= 1) as H,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.support.mail' AND CONFIG_SEQ= 1) as I,
                                (select STRING_VALUE1 from CONFIG_TBL where PROGRAM_ID='SYSTEM' AND CONFIG_KEY='amigo.support.tel' AND CONFIG_SEQ= 1) as J
                                FROM REQUEST_DETAIL
                                JOIN
                                EDI_ACCOUNT
                                on REQUEST_DETAIL.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                JOIN
                                CLIENT_CERTIFICATE
                                ON REQUEST_DETAIL.COMPANY_NO_BOX = CLIENT_CERTIFICATE.COMPANY_NO_BOX
                                WHERE REQUEST_DETAIL.COMPANY_NO_BOX = @COMPANY_NO_BOX
                                AND REQUEST_DETAIL.REQ_SEQ = @REQ_SEQ";

        string strSendMailUpdate = @"UPDATE [REQUEST_DETAIL]
                                    SET COMPLETION_NOTIFICATION_DATE = @COMPLETION_NOTIFICATION_DATE,
                                    [UPDATED_AT] = @UPDATED_AT,
                                    [UPDATED_BY] = @UPDATED_BY
                                    WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
							        AND [REQ_SEQ]= @REQ_SEQ";
        #endregion
        #endregion

        #region Constructors

        public REQUEST_DETAIL(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region GetAutoIndex
        public DataTable GetInitialData(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetInitialData);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region IsAlreadyUsed
        public bool IsAlreadyUsed(string COMPANY_NO_BOX, out string strMsg)
        {
           
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithCompanyNoBox);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.ExcuteQuery(4, out strMsg);

            int count = oMaster.dtExcuted.Rows.Count;

            if (count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion

        #region Update
        public void Update(BOL_AUTO_INDEX oAUTO_INDEX, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateIndex);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX_ID", oAUTO_INDEX.AUTO_INDEX_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX", oAUTO_INDEX.AUTO_INDEX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oAUTO_INDEX.UPDATED_AT != null ? oAUTO_INDEX.UPDATED_AT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", oAUTO_INDEX.UPDATED_BY != null ? oAUTO_INDEX.UPDATED_BY : (object)DBNull.Value));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region Purchase Order
        #region Search
        public System.Data.DataTable Search(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearch);
            oMaster = new ConnectionMaster(strConnectionString, strSearch);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Update From OrdreRegisterPreview
        public void Update(BOL_REQUEST_DETAIL oREQUEST_DETAIL, string CURRENT_TIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForOrderRegister);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ORDER_DATE", oREQUEST_DETAIL.ORDER_DATE != null ? oREQUEST_DETAIL.ORDER_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SYSTEM_EFFECTIVE_DATE", oREQUEST_DETAIL.SYSTEM_EFFECTIVE_DATE != null ? oREQUEST_DETAIL.SYSTEM_EFFECTIVE_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SYSTEM_REGIST_DEADLINE", oREQUEST_DETAIL.SYSTEM_REGIST_DEADLINE != null ? oREQUEST_DETAIL.SYSTEM_REGIST_DEADLINE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_TIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_DETAIL.COMPANY_NO_BOX != null ? oREQUEST_DETAIL.COMPANY_NO_BOX : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQUEST_DETAIL.REQ_SEQ != 0 ? oREQUEST_DETAIL.REQ_SEQ : (object)DBNull.Value));

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region UsageApplication

        #region GetRequestDetailList for Usage Application
        public System.Data.DataTable GetRequestDetailList(string COMPANY_NO_BOX, string COMPANY_NAME, string CLOSE_FLAG, string GD, string REQ_STATUS, string REQ_DATE_FROM, string REQ_DATE_TO, string QUOTATION_DATE_FROM, string QUOTATION_DATE_TO, string ORDER_DATE_FROM, string ORDER_DATE_TO, string SYSTEM_SETTING_STATUS, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            string flag = "";
            if (CLOSE_FLAG.Trim() == "処理中")
            {
                flag = " ";
            }
            if (CLOSE_FLAG.Trim() == "クローズ")
            {
                flag = "*";
            }


            //total
            //setup from to conditions
            //REQ_DATE
            strGetRequestDetailListTotal = SetupSearchDateCondition(REQ_DATE_FROM, REQ_DATE_TO, "REQ_DATE", strGetRequestDetailListTotal);

            //QUOTATION_DATE
            strGetRequestDetailListTotal = SetupSearchDateCondition(QUOTATION_DATE_FROM, QUOTATION_DATE_TO, "QUOTATION_DATE", strGetRequestDetailListTotal);

            //ORDER_DATE
            strGetRequestDetailListTotal = SetupSearchDateCondition(ORDER_DATE_FROM, ORDER_DATE_TO, "ORDER_DATE", strGetRequestDetailListTotal);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetRequestDetailListTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLOSE_FLG", flag));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", GD.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_STATUS", REQ_STATUS.ToString())); ;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SYSTEM_SETTING_STATUS", SYSTEM_SETTING_STATUS.ToString()));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            //setup from to conditions
            //REQ_DATE
            strGetRequestDetailList = SetupSearchDateCondition(REQ_DATE_FROM, REQ_DATE_TO, "REQ_DATE", strGetRequestDetailList);

            //QUOTATION_DATE
            strGetRequestDetailList = SetupSearchDateCondition(QUOTATION_DATE_FROM, QUOTATION_DATE_TO, "QUOTATION_DATE", strGetRequestDetailList);

            //ORDER_DATE
            strGetRequestDetailList = SetupSearchDateCondition(ORDER_DATE_FROM, ORDER_DATE_TO, "ORDER_DATE", strGetRequestDetailList);

            oMaster = new ConnectionMaster(strConnectionString, strGetRequestDetailList);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLOSE_FLG", flag));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@GD", GD.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_STATUS", REQ_STATUS.ToString()));;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SYSTEM_SETTING_STATUS", SYSTEM_SETTING_STATUS.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region SetupSearchDateCondition
        private string SetupSearchDateCondition(string from, string to, string key, string query)
        {
            if (!string.IsNullOrEmpty(from))
            {
                query = query.Replace("@"+ key + "_FromCondition", "AND CONVERT(varchar(10),REQUEST_DETAIL." + key + ",112) >= CONVERT(varchar(10), @var_" + key + "_FROM, 112)").Replace("@" + key + "_FROM", from);
            }
            else
            {
                query = query.Replace("@" + key + "_FromCondition", "").Replace("@" +key + "_FROM", DateTime.Now.ToString("yyyy/MM/dd")); 
            }

            if (!string.IsNullOrEmpty(to))
            {
                query = query.Replace("@" + key + "_ToCondition", "AND CONVERT(varchar(10)," + key + ",112) <= CONVERT(varchar(10), @var_" + key + "_TO ,112) ").Replace("@" + key + "_TO", to);
            }
            else
            {
                query = query.Replace("@" + key + "_ToCondition", "").Replace("@" + key + "_ToVariable", "").Replace("@" + key + "_TO", DateTime.Now.ToString("yyyy/MM/dd")); ;
            }

            return query;
        }

        #endregion

        #region GetSubProgramLists
        public System.Data.DataTable GetSubProgramLists(out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearch);
            oMaster = new ConnectionMaster(strConnectionString, strGetSubProgramLists);
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_REQUEST_DETAIL oREQUEST_DETAIL, out string strMsg)
        {
            //handle Null value at where conditions
            strSearchWithKeyAndUpdated_at = Utility.StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_DETAIL.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQUEST_DETAIL.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW != null ? oREQUEST_DETAIL.UPDATED_AT_RAW : (object)DBNull.Value));
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

        #region Modify for Usage Application
        public void UpdateUsageApplication(BOL_REQUEST_DETAIL oREQUEST_DETAIL, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdateForUsageApplication = Utility.StringUtil.handleNullStringDate(strUpdateForUsageApplication, "@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForUsageApplication);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLOSE_FLG", oREQUEST_DETAIL.CLOSE_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_DETAIL.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQUEST_DETAIL.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW != null ? oREQUEST_DETAIL.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region UpdateApplicationCancel For UsageApplication
        public void ApplicationCancelUpdate(BOL_REQUEST_DETAIL oREQUEST_DETAIL, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdateForApplicationCancel = Utility.StringUtil.handleNullStringDate(strUpdateForApplicationCancel, "@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForApplicationCancel);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_STATUS", 9));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQUEST_DETAIL.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQUEST_DETAIL.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQUEST_DETAIL.UPDATED_AT_RAW != null ? oREQUEST_DETAIL.UPDATED_AT_RAW : (object)DBNull.Value));
            

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion


        #endregion

        #region GetClientCertificateDiffenent
        public int GetClientCertificateDiff(string COMPANY_NO_BOX, string REQ_SEQ, string FY, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetClientCertificateDiff);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FY", FY));
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

            return count;
        }
        #endregion

        #region GetPdfList
        public System.Data.DataTable GetPDFData(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPdfData);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #endregion

        #region MailCreateUpdate
        public void SendMailUpdate(string COMPLETION_NOTIFICATION_DATE, string COMPANY_NO_BOX, string REQ_SEQ, string UPDATED_AT, string LOGIN_ID, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSendMailUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPLETION_NOTIFICATION_DATE", COMPLETION_NOTIFICATION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", UPDATED_AT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", LOGIN_ID));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region GetQuotationData
        public DataTable GetQuotationData(string COMPANY_NO_BOX, string REQ_SEQ,string strExtraCondition, out string strMsg)
        {
            string strMessage = "";
            string strValue = strGetQuotationData.Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX).Replace("@REQ_SEQ", REQ_SEQ.ToString());
            strValue = strValue.Replace("@Extra_Condition", strExtraCondition);
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strValue);
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion
    }
    #endregion

}
