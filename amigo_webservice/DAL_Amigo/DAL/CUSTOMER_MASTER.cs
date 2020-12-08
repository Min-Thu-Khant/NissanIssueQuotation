using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.Utility;

namespace DAL_AmigoProcess.DAL
{
    #region CUSTOMER MASTER
    public class CUSTOMER_MASTER
    {        
        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;

        string strGetBillBankAccounts = @"SELECT 
                                        [BILL_BANK_ACCOUNT_NAME-1],
                                        [BILL_BANK_ACCOUNT_NAME-2], 
                                        [BILL_BANK_ACCOUNT_NAME-3], 
                                        [BILL_BANK_ACCOUNT_NAME-4], 
                                        [BILL_COMPANY_NAME], 
                                        [BILL_CONTACT_NAME],
                                        [BILL_PHONE_NUMBER],
                                        [BILL_MAIL_ADDRESS],
                                        EFFECTIVE_DATE FROM CUSTOMER_MASTER_VIEW";

        string strUpdate = @"UPDATE CUSTOMER_MASTER SET 
                            BILL_BILLING_INTERVAL = @BILL_BILLING_INTERVAL,
                            BILL_DEPOSIT_RULES = @BILL_DEPOSIT_RULES,
                            BILL_TRANSFER_FEE = @BILL_TRANSFER_FEE,
                            BILL_EXPENSES = @BILL_EXPENSES,
                            UPDATED_AT = @UPDATED_AT,
                            UPDATED_BY = @UPDATED_BY,
                            NCS_CUSTOMER_CODE = @NCS_CUSTOMER_CODE
                            WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX AND TRANSACTION_TYPE = @TRANSACTION_TYPE AND FORMAT(EFFECTIVE_DATE, 'yyyyMMdd')=FORMAT(@EFFECTIVE_DATE, 'yyyyMMdd')";

        string strgetGridViewData = @"SELECT COMPANY_NAME, BILL_COMPANY_NAME, COMPANY_NO_BOX,
                                        TRIM([BILL_BANK_ACCOUNT_NAME-1]) [BILL_BANK_ACCOUNT_NAME-1],
                                        TRIM([BILL_BANK_ACCOUNT_NAME-2]) [BILL_BANK_ACCOUNT_NAME-2],
                                        TRIM([BILL_BANK_ACCOUNT_NAME-3]) [BILL_BANK_ACCOUNT_NAME-3],
                                        TRIM([BILL_BANK_ACCOUNT_NAME-4]) [BILL_BANK_ACCOUNT_NAME-4],
                                        NCS_CUSTOMER_CODE, 
                                        (case BILL_BILLING_INTERVAL when 1 then N'月額' when 2 then N'四半期' when 3 then N'半期' when 4 then N'年額' end)BILL_BILLING_INTERVAL,
                                        (case BILL_DEPOSIT_RULES when 0 then N'翌月' when 1 then N'当月' when 2 then N'翌々月月頭' end) BILL_DEPOSIT_RULES, 
                                        BILL_TRANSFER_FEE,BILL_EXPENSES, TRANSACTION_TYPE,  FORMAT(EFFECTIVE_DATE, 'yyyy/MM/dd') EFFECTIVE_DATE, REQ_SEQ
                                        FROM
                                        CUSTOMER_MASTER_VIEW
                                        WHERE ISNULL(COMPANY_NAME,'') LIKE '%' + @COMPANY_NAME + '%'
                                        AND ISNULL(COMPANY_NAME_READING,'') LIKE '%' + @COMPANY_NAME_READING + '%'
                                        AND ISNULL(BILL_COMPANY_NAME,'') LIKE '%' + @BILL_COMPANY_NAME + '%'
                                        AND ISNULL(COMPANY_NO_BOX,'') LIKE '%' + @COMPANY_NO_BOX + '%'
                                        AND ( 
                                        ISNULL(TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-1])),'') LIKE '%' + @ACCOUNT_NAME + '%' OR 
                                        ISNULL(TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-2])),'') LIKE '%' + @ACCOUNT_NAME + '%' OR
                                        ISNULL(TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-3])),'') LIKE '%' + @ACCOUNT_NAME + '%' OR
                                        ISNULL(TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-4])),'') LIKE '%' + @ACCOUNT_NAME + '%' )
                                        ORDER BY COMPANY_NO_BOX";

        string strSearchByBankAccountName = @"SELECT * from CUSTOMER_MASTER_VIEW WHERE
			                                (TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-1])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-2])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-3])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-4])) = @BANK_ACCOUNT_NAME) AND
                                            EFFECTIVE_DATE <= GETDATE()
                                            ORDER BY EFFECTIVE_DATE DESC";

        string strMaintenanceList = @"SELECT ROW_NUMBER() OVER(ORDER BY CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX ASC) AS No,
                                        ' ' as CK,
                                        ' ' as MK,
                                        CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX,
                                        (CASE CUSTOMER_MASTER_VIEW.TRANSACTION_TYPE 
                                        WHEN 1 THEN N'要元' 
                                        WHEN 2 THEN N'サプライヤ' 
                                        WHEN 3 THEN N'納代' 
										WHEN 4 THEN N'生産情報閲覧'
										WHEN 11 THEN N'SI'
										WHEN 12 THEN N'SOL'
										WHEN 19 THEN N'その他'
                                        END) TRANSACTION_TYPE,
                                        FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE, 'yyyy/MM/dd') EFFECTIVE_DATE,
                                        (CASE CUSTOMER_MASTER_VIEW.UPDATE_CONTENT 
                                        WHEN 1 THEN N'新規取引' 
                                        WHEN 2 THEN N'基本情報変更' 
                                        WHEN 3 THEN N'金額変更' 
										WHEN 99 THEN N'廃止'
                                        END) UPDATE_CONTENT,
                                        CUSTOMER_MASTER_VIEW.COMPANY_NAME,
                                        CUSTOMER_MASTER_VIEW.COMPANY_NAME_READING,
                                        FORMAT(CUSTOMER_MASTER_VIEW.QUOTATION_DATE, 'yyyy/MM/dd') QUOTATION_DATE,
                                        FORMAT(CUSTOMER_MASTER_VIEW.CONTRACT_DATE, 'yyyy/MM/dd') CONTRACT_DATE,
                                        FORMAT(CUSTOMER_MASTER_VIEW.COMPLETION_NOTIFICATION_DATE, 'yyyy/MM/dd') COMPLETION_NOTIFICATION_DATE,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_COMPANY_NAME,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_DEPARTMENT_IN_CHARGE,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_CONTACT_NAME,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_CONTACT_NAME_READING,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_POSTAL_CODE,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_ADDRESS,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_ADDRESS_BUILDING,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_MAIL_ADDRESS,
                                        CUSTOMER_MASTER_VIEW.CONTRACTOR_PHONE_NUMBER,
                                        CUSTOMER_MASTER_VIEW.BILL_SUPPLIER_NAME,
                                        CUSTOMER_MASTER_VIEW.BILL_SUPPLIER_NAME_READING,
                                        CUSTOMER_MASTER_VIEW.BILL_COMPANY_NAME,
                                        CUSTOMER_MASTER_VIEW.BILL_DEPARTMENT_IN_CHARGE,
                                        CUSTOMER_MASTER_VIEW.BILL_CONTACT_NAME,
                                        CUSTOMER_MASTER_VIEW.BILL_CONTACT_NAME_READING,
                                        CUSTOMER_MASTER_VIEW.BILL_POSTAL_CODE,
                                        CUSTOMER_MASTER_VIEW.BILL_ADDRESS,
                                        CUSTOMER_MASTER_VIEW.BILL_ADDRESS_BUILDING,
                                        CUSTOMER_MASTER_VIEW.BILL_MAIL_ADDRESS,
                                        CUSTOMER_MASTER_VIEW.BILL_PHONE_NUMBER,
                                        CUSTOMER_MASTER_VIEW.SPECIAL_NOTES_1,
                                        CUSTOMER_MASTER_VIEW.SPECIAL_NOTES_2,
                                        CUSTOMER_MASTER_VIEW.SPECIAL_NOTES_3,
                                        CUSTOMER_MASTER_VIEW.SPECIAL_NOTES_4,
                                        CUSTOMER_MASTER_VIEW.BILL_TYPE,
                                        CASE
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,1,1) = 1 THEN 'True'
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,1,1) = 0 THEN 'False'
										ELSE 'False'
                                        END BILL_METHOD1,
                                        CASE
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,2,1) = 1 THEN 'True'
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,2,1) = 0 THEN 'False'
										ELSE 'False'
                                        END BILL_METHOD2,
                                        CASE
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,3,1) = 1 THEN 'True'
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,3,1) = 0 THEN 'False'
										ELSE 'False'
                                        END BILL_METHOD3,
                                        CASE
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,5,1) = 1 THEN 'True'
                                        WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,5,1) = 0 THEN 'False'
										ELSE 'False'
                                        END BILL_METHOD4,
                                        CUSTOMER_MASTER_VIEW.NCS_CUSTOMER_CODE,
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-1],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NUMBER-1],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-2],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NUMBER-2],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-3],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NUMBER-3],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-4],
                                        CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NUMBER-4],
                                        (CASE CUSTOMER_MASTER_VIEW.BILL_BILLING_INTERVAL 
                                        WHEN 1 THEN N'月額' 
                                        WHEN 2 THEN N'四半期' 
                                        WHEN 3 THEN N'半期' 
										WHEN 4 THEN N'年額'
                                        END) BILL_BILLING_INTERVAL,
                                        (CASE CUSTOMER_MASTER_VIEW.BILL_DEPOSIT_RULES 
                                        WHEN 0 THEN N'翌月' 
                                        WHEN 1 THEN N'当月' 
                                        WHEN 2 THEN N'翌々月月頭' 
                                        END) BILL_DEPOSIT_RULES,
                                        CUSTOMER_MASTER_VIEW.BILL_TRANSFER_FEE,
                                        CUSTOMER_MASTER_VIEW.BILL_EXPENSES,
                                        CUSTOMER_MASTER_VIEW.PLAN_AMIGO_CAI,
                                        CUSTOMER_MASTER_VIEW.PLAN_AMIGO_BIZ,
                                        CUSTOMER_MASTER_VIEW.BOX_SIZE,
                                        CUSTOMER_MASTER_VIEW.INITIAL_COST - CUSTOMER_MASTER_VIEW.INITIAL_COST_DISCOUNTS AS INITIAL_COST,
                                        CUSTOMER_MASTER_VIEW.MONTHLY_COST - CUSTOMER_MASTER_VIEW.MONTHLY_COST_DISCOUNTS AS MONTHLY_COST,
                                        CUSTOMER_MASTER_VIEW.YEAR_COST - CUSTOMER_MASTER_VIEW.YEAR_COST_DISCOUNTS AS YEAR_COST,
										'*' as BREAK_DOWN,
                                        CASE TRIM(CUSTOMER_MASTER_VIEW.CONTRACT_PLAN)
										WHEN 'SERVER' THEN N'サーバー'
										WHEN 'SERVERRIGHT' THEN N'サーバーライト'
										WHEN 'BROWSERAUTO' THEN N'ブラウザ自動'
										WHEN 'BROWSER' THEN N'ブラウザ'
										WHEN 'PRODUCT' THEN N'生産情報閲覧'
										END CONTRACT_PLAN,
                                        CUSTOMER_MASTER_VIEW.OP_AMIGO_CAI,
                                        CUSTOMER_MASTER_VIEW.OP_AMIGO_BIZ,
                                        CUSTOMER_MASTER_VIEW.OP_BOX_SERVER,
                                        CUSTOMER_MASTER_VIEW.OP_BOX_BROWSER,
                                        CUSTOMER_MASTER_VIEW.OP_FLAT,
                                        CUSTOMER_MASTER_VIEW.OP_CLIENT,
                                        CUSTOMER_MASTER_VIEW.OP_BASIC_SERVICE,
                                        CUSTOMER_MASTER_VIEW.OP_ADD_SERVICE,
                                        CUSTOMER_MASTER_VIEW.SOCIOS_USER_FLG,
                                        FORMAT(CUSTOMER_MASTER_VIEW.COMPANY_NAME_CHANGED_DATE, 'yyyy/MM/dd') COMPANY_NAME_CHANGED_DATE,
                                        CUSTOMER_MASTER_VIEW.PREVIOUS_COMPANY_NAME,
                                        CUSTOMER_MASTER_VIEW.NML_CODE_NISSAN,
                                        CUSTOMER_MASTER_VIEW.NML_CODE_NS,
                                        CUSTOMER_MASTER_VIEW.NML_CODE_JATCO,
                                        CUSTOMER_MASTER_VIEW.NML_CODE_AK,
                                        CUSTOMER_MASTER_VIEW.NML_CODE_NK,
                                        FORMAT(CUSTOMER_MASTER_VIEW.OBOEGAKI_DATE, 'yyyy/MM/dd') OBOEGAKI_DATE,
                                        EDI_ACCOUNT.EDI_ACCOUNT,
                                        REQ_ADDRESS1.CONSTRACTOR_SERVICE_DESK_MAIL,
                                        REQ_ADDRESS2.SERVICE_ERROR_NOTIFICATION_MAIL,
                                        CUSTOMER_MASTER_VIEW.UPDATED_AT,
                                        CUSTOMER_MASTER_VIEW.UPDATED_BY,
                                        '' AS UPDATE_MESSAGE,
                                            CUSTOMER_MASTER_VIEW.UPDATED_AT UPDATED_AT_RAW,
                                            ROW_NUMBER() OVER(ORDER BY CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX ASC) AS ROW_ID,
                                        CUSTOMER_MASTER_VIEW.REQ_SEQ,
                                        FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE, 'yyyy/MM/dd') AS ORG_EFFECTIVE_DATE,
                                        REQUEST_ID.DISABLED_FLG
                                        FROM CUSTOMER_MASTER_VIEW
                                        LEFT JOIN REQUEST_ID
                                        ON CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                        LEFT JOIN EDI_ACCOUNT
                                        ON CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                        LEFT JOIN (SELECT
                                        COMPANY_NO_BOX, REQ_SEQ, TYPE,
                                        STUFF((SELECT ', ' +
                                        REQ_ADDRESS.MAIL_ADDRESS
                                        FROM REQ_ADDRESS
                                        WHERE REQ_ADDRESS.COMPANY_NO_BOX = REQ1.COMPANY_NO_BOX
                                        AND TYPE = 3
                                        FOR XML PATH('')), 1, 2, '') as CONSTRACTOR_SERVICE_DESK_MAIL
                                        FROM REQ_ADDRESS REQ1
                                        GROUP BY COMPANY_NO_BOX, REQ_SEQ, TYPE) REQ_ADDRESS1
                                        ON REQ_ADDRESS1.COMPANY_NO_BOX = CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX
                                        AND CUSTOMER_MASTER_VIEW.REQ_SEQ = REQ_ADDRESS1.REQ_SEQ
                                        AND REQ_ADDRESS1.TYPE = 3
                                        LEFT JOIN (SELECT
                                        COMPANY_NO_BOX, REQ_SEQ, TYPE,
                                        STUFF((SELECT ', ' +
                                        REQ_ADDRESS.MAIL_ADDRESS
                                        FROM REQ_ADDRESS
                                        WHERE REQ_ADDRESS.COMPANY_NO_BOX = REQ.COMPANY_NO_BOX
                                        AND TYPE = 4
                                        FOR XML PATH('')), 1, 2, '') as SERVICE_ERROR_NOTIFICATION_MAIL
                                        FROM REQ_ADDRESS REQ
                                        GROUP BY COMPANY_NO_BOX, REQ_SEQ, TYPE) REQ_ADDRESS2
                                        ON REQ_ADDRESS2.COMPANY_NO_BOX = CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX
                                        AND CUSTOMER_MASTER_VIEW.REQ_SEQ = REQ_ADDRESS2.REQ_SEQ
                                        AND REQ_ADDRESS2.TYPE = 4
                                        WHERE
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX, '') LIKE '%' + @COMPANY_NO_BOX + '%'
                                        AND
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NAME, '') LIKE '%' + @COMPANY_NAME + '%'
                                        AND
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NAME_READING, '') LIKE '%' + @COMPANY_NAME_READING + '%'
                                        AND
                                        ISNULL(EDI_ACCOUNT.EDI_ACCOUNT, '') LIKE '%' + @EDI_ACCOUNT + '%'
                                        AND
                                        (
                                        ISNULL(CUSTOMER_MASTER_VIEW.CONTRACTOR_MAIL_ADDRESS, '') LIKE '%' + '@CONTRACTOR_MAIL' + '%'
                                        OR
                                        ISNULL(CUSTOMER_MASTER_VIEW.BILL_MAIL_ADDRESS, '') LIKE '%' + '@BILL_MAIL' + '%'
                                        OR
                                        CONSTRACTOR_SERVICE_DESK_MAIL LIKE '%' + '@SERVICE_DESK_MAIL' + '%'
                                        OR
                                        SERVICE_ERROR_NOTIFICATION_MAIL LIKE '%' + '@ERROR_NOTIFICATION_MAIL' + '%'
                                        )
                                        ORDER BY CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX, CUSTOMER_MASTER_VIEW.TRANSACTION_TYPE ASC, EFFECTIVE_DATE DESC
                                        OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";

        string strGetCustomerCountByKeys = @"SELECT COUNT(*) FROM CUSTOMER_MASTER
                                            WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX
                                            AND TRANSACTION_TYPE=@TRANSACTION_TYPE
                                            AND EFFECTIVE_DATE=@EFFECTIVE_DATE";

        string strGetTopCustomerByKeys = @"SELECT TOP 1 CONTRACT_DATE,
                                            EFFECTIVE_DATE,
                                            SPECIAL_NOTES_1,
                                            SPECIAL_NOTES_2,
                                            SPECIAL_NOTES_3,
                                            SPECIAL_NOTES_4,
                                            NCS_CUSTOMER_CODE,
                                            BILL_BILLING_INTERVAL,
                                            BILL_DEPOSIT_RULES,
                                            BILL_TRANSFER_FEE,
                                            BILL_EXPENSES,
                                            COMPANY_NAME_CHANGED_DATE,
                                            PREVIOUS_COMPANY_NAME,
                                            OBOEGAKI_DATE
                                            FROM CUSTOMER_MASTER
                                            WHERE COMPANY_NO_BOX= @COMPANY_NO_BOX
                                            AND TRANSACTION_TYPE= @TRANSACTION_TYPE
                                            AND EFFECTIVE_DATE <= @EFFECTIVE_DATE
                                            ORDER BY EFFECTIVE_DATE, REQ_SEQ DESC";

        string strInsertCustomerMaster = @"INSERT INTO [CUSTOMER_MASTER]
                                           ([COMPANY_NO_BOX]
                                           ,[TRANSACTION_TYPE]
                                           ,[EFFECTIVE_DATE]
                                           ,[REQ_SEQ]
                                           ,[UPDATE_CONTENT]
                                           ,[CONTRACT_DATE]
                                           ,[SPECIAL_NOTES_1]
                                           ,[SPECIAL_NOTES_2]
                                           ,[SPECIAL_NOTES_3]
                                           ,[SPECIAL_NOTES_4]
                                           ,[NCS_CUSTOMER_CODE]
                                           ,[BILL_BILLING_INTERVAL]
                                           ,[BILL_DEPOSIT_RULES]
                                           ,[BILL_TRANSFER_FEE]
                                           ,[BILL_EXPENSES]
                                           ,[COMPANY_NAME_CHANGED_DATE]
                                           ,[PREVIOUS_COMPANY_NAME]
                                           ,[OBOEGAKI_DATE]
                                           ,[CREATED_AT]
                                           ,[CREATED_BY]
                                           ,[UPDATED_AT]
                                           ,[UPDATED_BY])
                                         VALUES
                                            (@COMPANY_NO_BOX,
                                            @TRANSACTION_TYPE,
                                            @EFFECTIVE_DATE,
                                            @REQ_SEQ,
                                            @UPDATE_CONTENT,
                                            @CONTRACT_DATE,
                                            @SPECIAL_NOTES_1,
                                            @SPECIAL_NOTES_2, 
                                            @SPECIAL_NOTES_3,
                                            @SPECIAL_NOTES_4,
                                            @NCS_CUSTOMER_CODE,
                                            @BILL_BILLING_INTERVAL,
                                            @BILL_DEPOSIT_RULES,
                                            @BILL_TRANSFER_FEE,
                                            @BILL_EXPENSES,
                                            @COMPANY_NAME_CHANGED_DATE,
                                            @PREVIOUS_COMPANY_NAME,
                                            @OBOEGAKI_DATE,
                                            @CURRENT_DATETIME,
                                            @CURRENT_USER,
                                            @CURRENT_DATETIME,
                                            @CURRENT_USER)";

        string strCustomerMasterTotal = @"SELECT COUNT(CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX)
                                        FROM CUSTOMER_MASTER_VIEW
                                        LEFT JOIN REQUEST_ID
                                        ON CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                        LEFT JOIN EDI_ACCOUNT
                                        ON CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = EDI_ACCOUNT.COMPANY_NO_BOX
                                        LEFT JOIN (SELECT
                                        COMPANY_NO_BOX, REQ_SEQ, TYPE,
                                        STUFF((SELECT ', ' +
                                        REQ_ADDRESS.MAIL_ADDRESS
                                        FROM REQ_ADDRESS
                                        WHERE REQ_ADDRESS.COMPANY_NO_BOX = REQ1.COMPANY_NO_BOX
                                        FOR XML PATH('')), 1, 2, '') as CONSTRACTOR_SERVICE_DESK_MAIL
                                        FROM REQ_ADDRESS REQ1
                                        GROUP BY COMPANY_NO_BOX, REQ_SEQ, TYPE) REQ_ADDRESS1
                                        ON REQ_ADDRESS1.COMPANY_NO_BOX = CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX
                                        AND CUSTOMER_MASTER_VIEW.REQ_SEQ = REQ_ADDRESS1.REQ_SEQ
                                        AND REQ_ADDRESS1.TYPE = 3
                                        LEFT JOIN (SELECT
                                        COMPANY_NO_BOX, REQ_SEQ, TYPE,
                                        STUFF((SELECT ', ' +
                                        REQ_ADDRESS.MAIL_ADDRESS
                                        FROM REQ_ADDRESS
                                        WHERE REQ_ADDRESS.COMPANY_NO_BOX = REQ.COMPANY_NO_BOX
                                        FOR XML PATH('')), 1, 2, '') as SERVICE_ERROR_NOTIFICATION_MAIL
                                        FROM REQ_ADDRESS REQ
                                        GROUP BY COMPANY_NO_BOX, REQ_SEQ, TYPE) REQ_ADDRESS2
                                        ON REQ_ADDRESS2.COMPANY_NO_BOX = CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX
                                        AND CUSTOMER_MASTER_VIEW.REQ_SEQ = REQ_ADDRESS2.REQ_SEQ
                                        AND REQ_ADDRESS2.TYPE = 4
                                        WHERE
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX, '') LIKE '%' + @COMPANY_NO_BOX + '%'
                                        AND
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NAME, '') LIKE '%' + @COMPANY_NAME + '%'
                                        AND
                                        ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NAME_READING, '') LIKE '%' + @COMPANY_NAME_READING + '%'
                                        AND
                                        ISNULL(EDI_ACCOUNT.EDI_ACCOUNT, '') LIKE '%' + @EDI_ACCOUNT + '%'
                                        AND
                                        (
                                        ISNULL(CUSTOMER_MASTER_VIEW.CONTRACTOR_MAIL_ADDRESS, '') LIKE '%' + '@CONTRACTOR_MAIL' + '%'
                                        OR
                                        ISNULL(CUSTOMER_MASTER_VIEW.BILL_MAIL_ADDRESS, '') LIKE '%' + '@BILL_MAIL' + '%'
                                        OR
                                        CONSTRACTOR_SERVICE_DESK_MAIL LIKE '%' + '@SERVICE_DESK_MAIL' + '%'
                                        OR
                                        SERVICE_ERROR_NOTIFICATION_MAIL LIKE '%' + '@ERROR_NOTIFICATION_MAIL' + '%'
                                        )";

        string strAlreadyUsed = @"SELECT COUNT(COMPANY_NO_BOX) AS COUNT
                                                FROM CUSTOMER_MASTER
                                                WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                                AND TRANSACTION_TYPE = @TRANSACTION_TYPE
                                                AND FORMAT(EFFECTIVE_DATE,'yyyy/MM/dd') = @EFFECTIVE_DATE";

        string strAlreadyUpdate = @"SELECT COUNT(COMPANY_NO_BOX) AS COUNT
                                                FROM CUSTOMER_MASTER
                                                WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                                AND TRANSACTION_TYPE = @TRANSACTION_TYPE
                                                AND FORMAT(EFFECTIVE_DATE,'yyyy/MM/dd') = @EFFECTIVE_DATE
                                                AND REQ_SEQ = @REQ_SEQ
                                                AND UPDATED_AT @UPDATED_AT";
        string strCustomerMasterUpdate = @"UPDATE [CUSTOMER_MASTER]
                                                    SET [EFFECTIVE_DATE] = @EFFECTIVE_DATE,
                                                    [CONTRACT_DATE] = @CONTRACT_DATE,
                                                    [SPECIAL_NOTES_1]= @SPECIAL_NOTES_1,
                                                    [SPECIAL_NOTES_2] = @SPECIAL_NOTES_2,
                                                    [SPECIAL_NOTES_3]=@SPECIAL_NOTES_3,
                                                    [SPECIAL_NOTES_4]=@SPECIAL_NOTES_4,
                                                    [NCS_CUSTOMER_CODE]=@NCS_CUSTOMER_CODE,
                                                    [BILL_BILLING_INTERVAL]=@BILL_BILLING_INTERVAL,
                                                    [BILL_DEPOSIT_RULES]=@BILL_DEPOSIT_RULES,
                                                    [BILL_TRANSFER_FEE]=@BILL_TRANSFER_FEE,
                                                    [BILL_EXPENSES]=@BILL_EXPENSES,
                                                    [COMPANY_NAME_CHANGED_DATE]=@COMPANY_NAME_CHANGED_DATE,
                                                    [PREVIOUS_COMPANY_NAME]=@PREVIOUS_COMPANY_NAME,
                                                    [OBOEGAKI_DATE]=@OBOEGAKI_DATE,
                                                    [UPDATED_AT]= @CURRENT_DATETIME,
                                                    [UPDATED_BY]= @CURRENT_USER
                                                    WHERE [COMPANY_NO_BOX] = @COMPANY_NO_BOX
                                                    AND [TRANSACTION_TYPE] = @TRANSACTION_TYPE
                                                    AND [EFFECTIVE_DATE] = @ORG_EFFECTIVE_DATE
                                                    AND [REQ_SEQ] = @REQ_SEQ
							                        AND [UPDATED_AT] @UPDATED_AT";

        string strMonthlySaleComparisonTotal = @"SELECT 
                                                COUNT(TBL.[TYPE])
                                                FROM
                                                (
                                                SELECT 
                                                TBL1.[TYPE] AS [TYPE], 
                                                TBL1.[BILL_SUPPLIER_NAME] AS [BILL_SUPPLIER_NAME],
                                                TBL1.[UPDATE_CONTENT],
                                                CASE WHEN TBL1.[TYPE] in (1) THEN TBL1.[INITIAL_COST]+TBL1.[MONTHLY_COST]-TBL2.[MONTHLY_COST]
                                                     WHEN TBL1.[TYPE] in (2,4) THEN TBL1.[INITIAL_COST]
                                                     WHEN TBL1.[TYPE] in (3) THEN TBL1.[MONTHLY_COST]-TBL2.[MONTHLY_COST]
                                                     WHEN TBL1.[TYPE] in (5) THEN TBL1.[YEAR_COST]-TBL2.[YEAR_COST]
                                                     ELSE 0
                                                END [DIFF],
                                                TBL1.[SERVER]-TBL2.[SERVER] AS [SERVER],
                                                TBL1.[SERVERRIGHT]-TBL2.[SERVERRIGHT] AS [SERVERRIGHT],
                                                TBL1.[BROWSERAUTO]-TBL2.[BROWSERAUTO] AS [BROWSERAUTO],
                                                TBL1.[BROWSER]-TBL2.[BROWSER] AS [BROWSER],
                                                TBL1.[PRODUCT]-TBL2.[PRODUCT] AS [PRODUCT],
                                                TBL1.[PLAN_AMIGO_CAI]-TBL2.[PLAN_AMIGO_CAI] AS [PLAN_AMIGO_CAI],
                                                TBL1.[PLAN_AMIGO_BIZ]-TBL2.[PLAN_AMIGO_BIZ] AS [PLAN_AMIGO_BIZ],
                                                TBL1.[OP_BOX_SERVER]-TBL2.[OP_BOX_SERVER] AS [OP_BOX_SERVER],
                                                TBL1.[OP_BOX_BROWSER]-TBL2.[OP_BOX_BROWSER] AS [OP_BOX_BROWSER],
                                                TBL1.[OP_FLAT]-TBL2.[OP_FLAT] AS [OP_FLAT],
                                                TBL1.[OP_CLIENT]-TBL2.[OP_CLIENT] AS [OP_CLIENT],
                                                TBL1.[OP_BASIC_SERVICE]-TBL2.[OP_BASIC_SERVICE] AS [OP_BASIC_SERVICE] ,
                                                TBL1.[OP_ADD_SERVICE]-TBL2.[OP_ADD_SERVICE] AS [OP_ADD_SERVICE],
                                                TBL1.[COMPANY_NO_BOX]
                                                FROM
                                                (SELECT
                                                A.[TYPE],
                                                A.[BILL_SUPPLIER_NAME],
                                                A.[UPDATE_CONTENT],
                                                A.[INITIAL_COST],
                                                A.[MONTHLY_COST],
                                                A.[YEAR_COST],
                                                A.[SERVER],
                                                A.[SERVERRIGHT],
                                                A.[BROWSERAUTO],
                                                A.[BROWSER],
                                                A.[PRODUCT],
                                                A.[PLAN_AMIGO_CAI],
                                                A.[PLAN_AMIGO_BIZ],
                                                A.[OP_BOX_SERVER],
                                                A.[OP_BOX_BROWSER],
                                                A.[OP_FLAT],
                                                A.[OP_CLIENT],
                                                A.[OP_BASIC_SERVICE],
                                                A.[OP_ADD_SERVICE],
                                                A.[COMPANY_NO_BOX],
                                                A.num
                                                FROM
                                                (SELECT　
                                                CASE BILL_TYPE WHEN '12' THEN '1'
                                                WHEN '22' THEN '3'
                                                WHEN '32' THEN '5'
                                                ELSE ''
                                                END [TYPE],
                                                BILL_SUPPLIER_NAME,
                                                UPDATE_CONTENT,
                                                CASE WHEN [UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE CASE WHEN format(DATEADD(month,1,[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                                THEN [INITIAL_COST]-[INITIAL_COST_DISCOUNTS]
                                                ELSE 0
                                                END
                                                END [INITIAL_COST],
                                                CASE WHEN [UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE [MONTHLY_COST]-[MONTHLY_COST_DISCOUNTS]
                                                END [MONTHLY_COST],
                                                CASE WHEN [UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE CASE WHEN format(DATEADD(month,1,[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                                THEN [YEAR_COST]-[YEAR_COST_DISCOUNTS]
                                                ELSE 0
                                                END
                                                END [YEAR_COST],
                                                CASE WHEN [CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                                CASE WHEN [CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                                CASE WHEN [CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                                CASE WHEN [CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                                CASE WHEN [CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                                [PLAN_AMIGO_CAI],
                                                [PLAN_AMIGO_BIZ],
                                                [OP_BOX_SERVER],
                                                [OP_BOX_BROWSER],
                                                [OP_FLAT],
                                                [OP_CLIENT],
                                                [OP_BASIC_SERVICE],
                                                [OP_ADD_SERVICE],
                                                [COMPANY_NO_BOX],
                                                ROW_NUMBER() OVER(PARTITION BY COMPANY_NO_BOX ORDER BY COMPANY_NO_BOX, EFFECTIVE_DATE DESC, REQ_SEQ DESC) num
                                                FROM CUSTOMER_MASTER_VIEW WHERE FORMAT(CUSTOMER_MASTER_VIEW.[EFFECTIVE_DATE],'yyMM') <=@YYMM_1 AND [BILL_TYPE] in(12,22,32)
                                                UNION ALL
                                                SELECT
                                                CASE CV.[BILL_TYPE] WHEN '22' THEN '2'
                                                WHEN '32' THEN '4'
                                                ELSE ''
                                                END [TYPE],
                                                CV.[BILL_SUPPLIER_NAME],
                                                CV.[UPDATE_CONTENT],
                                                CASE WHEN CV.[UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE CASE WHEN format(DATEADD(month,1,RD.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                                THEN CV.[INITIAL_COST]-CV.[INITIAL_COST_DISCOUNTS]
                                                ELSE 0
                                                END
                                                END [INITIAL_COST],
                                                CASE WHEN CV.[UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE CV.[MONTHLY_COST]-CV.[MONTHLY_COST_DISCOUNTS]
                                                END [MONTHLY_COST],
                                                CASE WHEN CV.[UPDATE_CONTENT] = 99
                                                THEN 0
                                                ELSE CASE WHEN FORMAT(DATEADD(month,1,RD.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                                THEN CV.[YEAR_COST]-CV.[YEAR_COST_DISCOUNTS]
                                                ELSE 0
                                                END
                                                END [YEAR_COST],
                                                CASE WHEN CV.[CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                                CASE WHEN CV.[CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                                CASE WHEN CV.[CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                                case WHEN CV.[CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                                case WHEN CV.[CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                                CV.[PLAN_AMIGO_CAI],
                                                CV.[PLAN_AMIGO_BIZ],
                                                CV.[OP_BOX_SERVER],
                                                CV.[OP_BOX_BROWSER],
                                                CV.[OP_FLAT],
                                                CV.[OP_CLIENT],
                                                CV.[OP_BASIC_SERVICE],
                                                CV.[OP_ADD_SERVICE],
                                                CV.[COMPANY_NO_BOX],
                                                ROW_NUMBER() OVER(PARTITION BY CV.[COMPANY_NO_BOX] ORDER BY CV.[COMPANY_NO_BOX], CV.[EFFECTIVE_DATE] DESC) num
                                                FROM CUSTOMER_MASTER_VIEW CV LEFT JOIN [REQUEST_DETAIL] RD ON CV.[COMPANY_NO_BOX] = RD.[COMPANY_NO_BOX] AND CV.[REQ_SEQ]=RD.[REQ_SEQ]
                                                WHERE FORMAT(CV.[EFFECTIVE_DATE],'yyMM') <= @YYMM_1
                                                AND CV.[BILL_TYPE] IN (22,32)
                                                ) A WHERE A.num = 1
                                                ) AS TBL1
                                                LEFT JOIN
                                                (
                                                SELECT
                                                B.INITIAL_COST,
                                                B.MONTHLY_COST,
                                                B.YEAR_COST,
                                                B.[SERVER],
                                                B.SERVERRIGHT,
                                                B.BROWSERAUTO,
                                                B.BROWSER,
                                                B.PRODUCT,
                                                B.PLAN_AMIGO_CAI,
                                                B.PLAN_AMIGO_BIZ,
                                                B.OP_BOX_SERVER,
                                                B.OP_BOX_BROWSER,
                                                B.OP_FLAT,
                                                B.OP_CLIENT,
                                                B.OP_BASIC_SERVICE,
                                                B.OP_ADD_SERVICE,
                                                B.[COMPANY_NO_BOX]
                                                FROM
                                                (
                                                SELECT
                                                CASE WHEN FORMAT(DATEADD(month,1,req.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_2
                                                THEN cust.[INITIAL_COST]-cust.[INITIAL_COST_DISCOUNTS]
                                                ELSE 0
                                                END [INITIAL_COST],
                                                cust.[MONTHLY_COST]-cust.[MONTHLY_COST_DISCOUNTS] AS [MONTHLY_COST],
                                                CASE WHEN FORMAT(DATEADD(month,1,req.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_2
                                                THEN cust.[YEAR_COST]-cust.[YEAR_COST_DISCOUNTS]
                                                ELSE 0
                                                END [YEAR_COST],
                                                CASE WHEN cust.[CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                                CASE WHEN cust.[CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                                CASE WHEN cust.[CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                                CASE WHEN cust.[CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                                CASE WHEN cust.[CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                                cust.[PLAN_AMIGO_CAI],
                                                cust.[PLAN_AMIGO_BIZ],
                                                cust.[OP_BOX_SERVER],
                                                cust.[OP_BOX_BROWSER],
                                                cust.[OP_FLAT],
                                                cust.[OP_CLIENT],
                                                cust.[OP_BASIC_SERVICE],
                                                cust.[OP_ADD_SERVICE],
                                                cust.[COMPANY_NO_BOX],
                                                ROW_NUMBER() OVER(PARTITION BY cust.[COMPANY_NO_BOX] ORDER BY cust.[COMPANY_NO_BOX], cust.[EFFECTIVE_DATE] DESC) num
                                                from CUSTOMER_MASTER_VIEW cust
                                                LEFT JOIN REQUEST_DETAIL req ON cust.COMPANY_NO_BOX = req.COMPANY_NO_BOX and cust.REQ_SEQ=req.REQ_SEQ
                                                WHERE FORMAT(cust.[EFFECTIVE_DATE],'yyMM') <= @YYMM_2 and cust.[BILL_TYPE] in(12,22,32)
                                                ) B WHERE B.num = 1
                                                ) AS TBL2
                                                ON TBL1.COMPANY_NO_BOX=TBL2.COMPANY_NO_BOX
                                                ) AS TBL
                                                WHERE
                                                TBL.[SERVER] <> 0 OR
                                                TBL.[SERVERRIGHT] <> 0 OR
                                                TBL.[BROWSERAUTO] <> 0 OR
                                                TBL.[BROWSER] <> 0 OR
                                                TBL.[PRODUCT] <> 0 OR
                                                TBL.[PLAN_AMIGO_CAI] <> 0 OR
                                                TBL.[PLAN_AMIGO_BIZ] <> 0 OR
                                                TBl.[OP_BOX_SERVER] <> 0 OR
                                                TBL.[OP_BOX_BROWSER] <> 0 OR
                                                TBL.[OP_FLAT] <> 0 OR
                                                TBL.[OP_CLIENT] <> 0 OR
                                                TBL.[OP_BASIC_SERVICE] <> 0 OR
                                                TBL.[OP_ADD_SERVICE] <> 0 ";

        string strMonthlySaleComparison = @"SELECT 
                                            ROW_NUMBER() OVER(ORDER BY TBL.[TYPE] ASC) AS No,
                                            CASE TBL.[TYPE] WHEN 1 THEN N'要元'
                                                            WHEN 2 THEN N'初期費'
				                                            WHEN 3 THEN N'月額利用料'
				                                            WHEN 4 THEN N'生産情報閲覧(初期費)'
				                                            WHEN 5 THEN N'生産情報閲覧'
                                            END [TYPE],
                                            TBL.[BILL_SUPPLIER_NAME],
                                            CASE TBL.[UPDATE_CONTENT] WHEN 1 THEN N'新規'
                                                                      WHEN 2 THEN N'更新'
						                                              WHEN 3 THEN N'更新'
						                                              WHEN 99 THEN N'解約'
                                            END [UPDATE_CONTENT],
                                            TBL.[DIFF],
                                            CONVERT(varchar(10),TBL.[SERVER]) AS [SERVER],
                                            CONVERT(varchar(10),TBL.[SERVERRIGHT]) AS [SERVERRIGHT],
                                            CONVERT(varchar(10),TBL.[BROWSERAUTO]) AS [BROWSERAUTO],
                                            CONVERT(varchar(10),TBL.[BROWSER]) AS [BROWSER],
                                            CONVERT(varchar(10),TBL.[PRODUCT]) AS [PRODUCT],
                                            CONVERT(varchar(10),TBL.[PLAN_AMIGO_CAI]) AS [PLAN_AMIGO_CAI],
                                            CONVERT(varchar(10),TBL.[PLAN_AMIGO_BIZ]) AS [PLAN_AMIGO_BIZ],
                                            CONVERT(varchar(10),TBL.[OP_BOX_SERVER]) AS [OP_BOX_SERVER],
                                            CONVERT(varchar(10),TBL.[OP_BOX_BROWSER]) AS [OP_BOX_BROWSER],
                                            CONVERT(varchar(10),TBL.[OP_FLAT]) AS [OP_FLAT],
                                            CONVERT(varchar(10),TBL.[OP_CLIENT]) AS [OP_CLIENT],
                                            CONVERT(varchar(10),TBL.[OP_BASIC_SERVICE]) AS [OP_BASIC_SERVICE],
                                            CONVERT(varchar(10),TBL.[OP_ADD_SERVICE]) AS [OP_ADD_SERVICE]
                                            FROM
                                            (
                                            SELECT 
                                            TBL1.[TYPE] AS [TYPE], 
                                            TBL1.[BILL_SUPPLIER_NAME] AS [BILL_SUPPLIER_NAME],
                                            TBL1.[UPDATE_CONTENT],
                                            CASE WHEN TBL1.[TYPE] in (1) THEN TBL1.[INITIAL_COST]+TBL1.[MONTHLY_COST]-TBL2.[MONTHLY_COST]
                                                 WHEN TBL1.[TYPE] in (2,4) THEN TBL1.[INITIAL_COST]
                                                 WHEN TBL1.[TYPE] in (3) THEN TBL1.[MONTHLY_COST]-TBL2.[MONTHLY_COST]
                                                 WHEN TBL1.[TYPE] in (5) THEN TBL1.[YEAR_COST]-TBL2.[YEAR_COST]
                                                 ELSE 0
                                            END [DIFF],
                                            TBL1.[SERVER]-TBL2.[SERVER] AS [SERVER],
                                            TBL1.[SERVERRIGHT]-TBL2.[SERVERRIGHT] AS [SERVERRIGHT],
                                            TBL1.[BROWSERAUTO]-TBL2.[BROWSERAUTO] AS [BROWSERAUTO],
                                            TBL1.[BROWSER]-TBL2.[BROWSER] AS [BROWSER],
                                            TBL1.[PRODUCT]-TBL2.[PRODUCT] AS [PRODUCT],
                                            TBL1.[PLAN_AMIGO_CAI]-TBL2.[PLAN_AMIGO_CAI] AS [PLAN_AMIGO_CAI],
                                            TBL1.[PLAN_AMIGO_BIZ]-TBL2.[PLAN_AMIGO_BIZ] AS [PLAN_AMIGO_BIZ],
                                            TBL1.[OP_BOX_SERVER]-TBL2.[OP_BOX_SERVER] AS [OP_BOX_SERVER],
                                            TBL1.[OP_BOX_BROWSER]-TBL2.[OP_BOX_BROWSER] AS [OP_BOX_BROWSER],
                                            TBL1.[OP_FLAT]-TBL2.[OP_FLAT] AS [OP_FLAT],
                                            TBL1.[OP_CLIENT]-TBL2.[OP_CLIENT] AS [OP_CLIENT],
                                            TBL1.[OP_BASIC_SERVICE]-TBL2.[OP_BASIC_SERVICE] AS [OP_BASIC_SERVICE] ,
                                            TBL1.[OP_ADD_SERVICE]-TBL2.[OP_ADD_SERVICE] AS [OP_ADD_SERVICE],
                                            TBL1.[COMPANY_NO_BOX]
                                            FROM
                                            (SELECT
                                            A.[TYPE],
                                            A.[BILL_SUPPLIER_NAME],
                                            A.[UPDATE_CONTENT],
                                            A.[INITIAL_COST],
                                            A.[MONTHLY_COST],
                                            A.[YEAR_COST],
                                            A.[SERVER],
                                            A.[SERVERRIGHT],
                                            A.[BROWSERAUTO],
                                            A.[BROWSER],
                                            A.[PRODUCT],
                                            A.[PLAN_AMIGO_CAI],
                                            A.[PLAN_AMIGO_BIZ],
                                            A.[OP_BOX_SERVER],
                                            A.[OP_BOX_BROWSER],
                                            A.[OP_FLAT],
                                            A.[OP_CLIENT],
                                            A.[OP_BASIC_SERVICE],
                                            A.[OP_ADD_SERVICE],
                                            A.[COMPANY_NO_BOX],
                                            A.num
                                            FROM
                                            (SELECT　
                                            CASE BILL_TYPE WHEN '12' THEN '1'
                                            WHEN '22' THEN '3'
                                            WHEN '32' THEN '5'
                                            ELSE ''
                                            END [TYPE],
                                            BILL_SUPPLIER_NAME,
                                            UPDATE_CONTENT,
                                            CASE WHEN [UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE CASE WHEN format(DATEADD(month,1,[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                            THEN [INITIAL_COST]-[INITIAL_COST_DISCOUNTS]
                                            ELSE 0
                                            END
                                            END [INITIAL_COST],
                                            CASE WHEN [UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE [MONTHLY_COST]-[MONTHLY_COST_DISCOUNTS]
                                            END [MONTHLY_COST],
                                            CASE WHEN [UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE CASE WHEN format(DATEADD(month,1,[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                            THEN [YEAR_COST]-[YEAR_COST_DISCOUNTS]
                                            ELSE 0
                                            END
                                            END [YEAR_COST],
                                            CASE WHEN [CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                            CASE WHEN [CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                            CASE WHEN [CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                            CASE WHEN [CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                            CASE WHEN [CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                            [PLAN_AMIGO_CAI],
                                            [PLAN_AMIGO_BIZ],
                                            [OP_BOX_SERVER],
                                            [OP_BOX_BROWSER],
                                            [OP_FLAT],
                                            [OP_CLIENT],
                                            [OP_BASIC_SERVICE],
                                            [OP_ADD_SERVICE],
                                            [COMPANY_NO_BOX],
                                            ROW_NUMBER() OVER(PARTITION BY COMPANY_NO_BOX ORDER BY COMPANY_NO_BOX, EFFECTIVE_DATE DESC, REQ_SEQ DESC) num
                                            FROM CUSTOMER_MASTER_VIEW WHERE FORMAT(CUSTOMER_MASTER_VIEW.[EFFECTIVE_DATE],'yyMM') <=@YYMM_1 AND [BILL_TYPE] in(12,22,32)
                                            UNION ALL
                                            SELECT
                                            CASE CV.[BILL_TYPE] WHEN '22' THEN '2'
                                            WHEN '32' THEN '4'
                                            ELSE ''
                                            END [TYPE],
                                            CV.[BILL_SUPPLIER_NAME],
                                            CV.[UPDATE_CONTENT],
                                            CASE WHEN CV.[UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE CASE WHEN format(DATEADD(month,1,RD.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                            THEN CV.[INITIAL_COST]-CV.[INITIAL_COST_DISCOUNTS]
                                            ELSE 0
                                            END
                                            END [INITIAL_COST],
                                            CASE WHEN CV.[UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE CV.[MONTHLY_COST]-CV.[MONTHLY_COST_DISCOUNTS]
                                            END [MONTHLY_COST],
                                            CASE WHEN CV.[UPDATE_CONTENT] = 99
                                            THEN 0
                                            ELSE CASE WHEN FORMAT(DATEADD(month,1,RD.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_1
                                            THEN CV.[YEAR_COST]-CV.[YEAR_COST_DISCOUNTS]
                                            ELSE 0
                                            END
                                            END [YEAR_COST],
                                            CASE WHEN CV.[CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                            CASE WHEN CV.[CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                            CASE WHEN CV.[CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                            case WHEN CV.[CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                            case WHEN CV.[CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                            CV.[PLAN_AMIGO_CAI],
                                            CV.[PLAN_AMIGO_BIZ],
                                            CV.[OP_BOX_SERVER],
                                            CV.[OP_BOX_BROWSER],
                                            CV.[OP_FLAT],
                                            CV.[OP_CLIENT],
                                            CV.[OP_BASIC_SERVICE],
                                            CV.[OP_ADD_SERVICE],
                                            CV.[COMPANY_NO_BOX],
                                            ROW_NUMBER() OVER(PARTITION BY CV.[COMPANY_NO_BOX] ORDER BY CV.[COMPANY_NO_BOX], CV.[EFFECTIVE_DATE] DESC,CV.REQ_SEQ DESC) num
                                            FROM CUSTOMER_MASTER_VIEW CV LEFT JOIN [REQUEST_DETAIL] RD ON CV.[COMPANY_NO_BOX] = RD.[COMPANY_NO_BOX] AND CV.[REQ_SEQ]=RD.[REQ_SEQ]
                                            WHERE FORMAT(CV.[EFFECTIVE_DATE],'yyMM') <= @YYMM_1
                                            AND CV.[BILL_TYPE] IN (22,32)
                                            ) A WHERE A.num = 1
                                            ) AS TBL1
                                            LEFT JOIN
                                            (
                                            SELECT
                                            B.INITIAL_COST,
                                            B.MONTHLY_COST,
                                            B.YEAR_COST,
                                            B.[SERVER],
                                            B.SERVERRIGHT,
                                            B.BROWSERAUTO,
                                            B.BROWSER,
                                            B.PRODUCT,
                                            B.PLAN_AMIGO_CAI,
                                            B.PLAN_AMIGO_BIZ,
                                            B.OP_BOX_SERVER,
                                            B.OP_BOX_BROWSER,
                                            B.OP_FLAT,
                                            B.OP_CLIENT,
                                            B.OP_BASIC_SERVICE,
                                            B.OP_ADD_SERVICE,
                                            B.[COMPANY_NO_BOX]
                                            FROM
                                            (
                                            SELECT
                                            CASE WHEN FORMAT(DATEADD(month,1,req.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_2
                                            THEN cust.[INITIAL_COST]-cust.[INITIAL_COST_DISCOUNTS]
                                            ELSE 0
                                            END [INITIAL_COST],
                                            cust.[MONTHLY_COST]-cust.[MONTHLY_COST_DISCOUNTS] AS [MONTHLY_COST],
                                            CASE WHEN FORMAT(DATEADD(month,1,req.[COMPLETION_NOTIFICATION_DATE]),'yyMM') = @YYMM_2
                                            THEN cust.[YEAR_COST]-cust.[YEAR_COST_DISCOUNTS]
                                            ELSE 0
                                            END [YEAR_COST],
                                            CASE WHEN cust.[CONTRACT_PLAN] = 'SERVER' THEN 1 ELSE 0 END [SERVER],
                                            CASE WHEN cust.[CONTRACT_PLAN] = 'SERVERRIGHT' THEN 1 ELSE 0 END [SERVERRIGHT],
                                            CASE WHEN cust.[CONTRACT_PLAN] = 'BROWSERAUTO' THEN 1 ELSE 0 END [BROWSERAUTO],
                                            CASE WHEN cust.[CONTRACT_PLAN] = 'BROWSER' THEN 1 ELSE 0 END [BROWSER],
                                            CASE WHEN cust.[CONTRACT_PLAN] = 'PRODUCT' THEN 1 ELSE 0 END [PRODUCT],
                                            cust.[PLAN_AMIGO_CAI],
                                            cust.[PLAN_AMIGO_BIZ],
                                            cust.[OP_BOX_SERVER],
                                            cust.[OP_BOX_BROWSER],
                                            cust.[OP_FLAT],
                                            cust.[OP_CLIENT],
                                            cust.[OP_BASIC_SERVICE],
                                            cust.[OP_ADD_SERVICE],
                                            cust.[COMPANY_NO_BOX],
                                            ROW_NUMBER() OVER(PARTITION BY cust.[COMPANY_NO_BOX] ORDER BY cust.[COMPANY_NO_BOX], cust.[EFFECTIVE_DATE] DESC) num
                                            from CUSTOMER_MASTER_VIEW cust
                                            LEFT JOIN REQUEST_DETAIL req ON cust.COMPANY_NO_BOX = req.COMPANY_NO_BOX and cust.REQ_SEQ=req.REQ_SEQ
                                            WHERE FORMAT(cust.[EFFECTIVE_DATE],'yyMM') <= @YYMM_2 and cust.[BILL_TYPE] in(12,22,32)
                                            ) B WHERE B.num = 1
                                            ) AS TBL2
                                            ON TBL1.COMPANY_NO_BOX=TBL2.COMPANY_NO_BOX
                                            ) AS TBL
                                            WHERE
                                            TBL.[SERVER] <> 0 OR
                                            TBL.[SERVERRIGHT] <> 0 OR
                                            TBL.[BROWSERAUTO] <> 0 OR
                                            TBL.[BROWSER] <> 0 OR
                                            TBL.[PRODUCT] <> 0 OR
                                            TBL.[PLAN_AMIGO_CAI] <> 0 OR
                                            TBL.[PLAN_AMIGO_BIZ] <> 0 OR
                                            TBl.[OP_BOX_SERVER] <> 0 OR
                                            TBL.[OP_BOX_BROWSER] <> 0 OR
                                            TBL.[OP_FLAT] <> 0 OR
                                            TBL.[OP_CLIENT] <> 0 OR
                                            TBL.[OP_BASIC_SERVICE] <> 0 OR
                                            TBL.[OP_ADD_SERVICE] <> 0 
                                            ORDER BY TBL.[TYPE],TBL.[UPDATE_CONTENT] ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";

        #region IsAlreadyUpdate
        public bool IsAlreadyUpdate(BOL_CUSTOMER_MASTER oCUSTOMER_MASTER, out string strMsg)
        {
            strAlreadyUpdate = StringUtil.handleNullStringDate(strAlreadyUpdate, "@UPDATED_AT", oCUSTOMER_MASTER.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strAlreadyUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCUSTOMER_MASTER.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", oCUSTOMER_MASTER.TRANSACTION_TYPE));
            string date = Convert.ToDateTime(oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE).ToString("yyyy/MM/dd");
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE != null ? Convert.ToDateTime(oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE).ToString("yyyy/MM/dd") : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCUSTOMER_MASTER.UPDATED_AT_RAW != null ? oCUSTOMER_MASTER.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oCUSTOMER_MASTER.REQ_SEQ.ToString() != null ? oCUSTOMER_MASTER.REQ_SEQ : (object)DBNull.Value));

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

        #endregion

        #region Constructors

        public CUSTOMER_MASTER(string con)
        {            
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region getData
        public DataTable getBillBankAccounts()
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetBillBankAccounts);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getGridViewData
        public DataTable getGridViewData(string COMPANY_NAME, string COMPANY_NAME_READING, string BILL_COMPANY_NAME, string COMPANY_NO_BOX, string ACCOUNT_NAME)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strgetGridViewData);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_READING", COMPANY_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_COMPANY_NAME", BILL_COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ACCOUNT_NAME", ACCOUNT_NAME));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getMaintenanceList

        public DataTable getMaintenanceList()
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMaintenanceList);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region SearchByBankAccountName
        public DataTable SearchByBankAccountName(string BANK_ACCOUNT_NAME)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchByBankAccountName);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BANK_ACCOUNT_NAME", BANK_ACCOUNT_NAME));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region update
        public void Update(BOL_CUSTOMER_MASTER B_Customer, out string strMessage)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", B_Customer.BILL_BILLING_INTERVAL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", B_Customer.BILL_DEPOSIT_RULES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", B_Customer.BILL_TRANSFER_FEE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", B_Customer.BILL_EXPENSES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", B_Customer.UPDATED_AT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", B_Customer.UPDATED_BY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", B_Customer.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", B_Customer.TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", B_Customer.NCS_CUSTOMER_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", B_Customer.EFFECTIVE_DATE));
            oMaster.ExcuteQuery(2, out strMessage);
        }

        #endregion

        #region GetCustomerCountByKeys

        public int getCustomerCountByKeys(string COMPANY_NO_BOX, int TRANSACTION_TYPE, DateTime EFFECTIVE_DATE, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetCustomerCountByKeys);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", EFFECTIVE_DATE));
            oMaster.ExcuteQuery(4, out strMsg);

            int count = 0;
            try
            {
                int.TryParse(oMaster.dtExcuted.Rows[0][0].ToString(), out count);
            }
            catch (Exception)
            { 
            }
            return count;
        }
        #endregion

        #region GetCustomerMasterList
        public System.Data.DataTable GetTopCustomerByKeys(string COMPANY_NO_BOX, int TRANSACTION_TYPE, DateTime START_USE_DATE, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetTopCustomerByKeys);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", START_USE_DATE));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Insert
        public void Insert(BOL_CUSTOMER_MASTER oCUSTOMER_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg) //BOL_CUSTOMER_MASTER oCUSTOMER_MASTER
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsertCustomerMaster);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCUSTOMER_MASTER.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", oCUSTOMER_MASTER.TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", oCUSTOMER_MASTER.EFFECTIVE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oCUSTOMER_MASTER.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATE_CONTENT", oCUSTOMER_MASTER.UPDATE_CONTENT != 0 ? oCUSTOMER_MASTER.UPDATE_CONTENT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_DATE", oCUSTOMER_MASTER.CONTRACT_DATE != null ? oCUSTOMER_MASTER.CONTRACT_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_1", oCUSTOMER_MASTER.SPECIAL_NOTES_1 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_1 : (object)DBNull.Value)); ;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_2", oCUSTOMER_MASTER.SPECIAL_NOTES_2 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_2 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_3", oCUSTOMER_MASTER.SPECIAL_NOTES_3 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_3 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_4", oCUSTOMER_MASTER.SPECIAL_NOTES_4 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_4 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", oCUSTOMER_MASTER.NCS_CUSTOMER_CODE != null ? oCUSTOMER_MASTER.NCS_CUSTOMER_CODE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", oCUSTOMER_MASTER.BILL_BILLING_INTERVAL != null ? oCUSTOMER_MASTER.BILL_BILLING_INTERVAL : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", oCUSTOMER_MASTER.BILL_DEPOSIT_RULES!= null ? oCUSTOMER_MASTER.BILL_DEPOSIT_RULES : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", oCUSTOMER_MASTER.BILL_TRANSFER_FEE != null ? oCUSTOMER_MASTER.BILL_TRANSFER_FEE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", oCUSTOMER_MASTER.BILL_EXPENSES!= null ? oCUSTOMER_MASTER.BILL_EXPENSES : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_CHANGED_DATE", oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE != null ? oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PREVIOUS_COMPANY_NAME", oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME != null ? oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OBOEGAKI_DATE", oCUSTOMER_MASTER.OBOEGAKI_DATE != null ? oCUSTOMER_MASTER.OBOEGAKI_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));


            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion

        #region getMaintenanceList
        public DataTable getMaintenanceList(string COMPANY_NO_BOX, string COMPANY_NAME, string COMPANY_NAME_READING, string EDI_ACCOUNT, string MAIL_ADDRESS, string CONTRACTOR, string INVOICE, string SERVICE_DESK, string NOTIFICATION_DESTINATION, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            if (CONTRACTOR.Trim() == "契約先")
            {
                strMaintenanceList = strMaintenanceList.Replace("@CONTRACTOR_MAIL", MAIL_ADDRESS);
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@CONTRACTOR_MAIL", MAIL_ADDRESS);
            }
            else
            {
                strMaintenanceList = strMaintenanceList.Replace("@CONTRACTOR_MAIL", "");
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@CONTRACTOR_MAIL", "");

            }

            if (INVOICE.Trim() == "請求書送付先")
            {
                strMaintenanceList = strMaintenanceList.Replace("@BILL_MAIL", MAIL_ADDRESS);
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@BILL_MAIL", MAIL_ADDRESS);
            }
            else
            {
                strMaintenanceList = strMaintenanceList.Replace("@BILL_MAIL", "");
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@BILL_MAIL", "");
            }

            if (SERVICE_DESK.Trim() == "サービスデスク")
            {
                strMaintenanceList = strMaintenanceList.Replace("@SERVICE_DESK_MAIL", MAIL_ADDRESS);
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@SERVICE_DESK_MAIL", MAIL_ADDRESS);

            }
            else
            {
                strMaintenanceList = strMaintenanceList.Replace("@SERVICE_DESK_MAIL", "");
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@SERVICE_DESK_MAIL", "");
            }

            if (NOTIFICATION_DESTINATION.Trim() == "エラー通知先")
            {
                strMaintenanceList = strMaintenanceList.Replace("@ERROR_NOTIFICATION_MAIL", MAIL_ADDRESS);
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@ERROR_NOTIFICATION_MAIL", MAIL_ADDRESS);

            }
            else
            {
                strMaintenanceList = strMaintenanceList.Replace("@ERROR_NOTIFICATION_MAIL", "");
                strCustomerMasterTotal = strCustomerMasterTotal.Replace("@ERROR_NOTIFICATION_MAIL", "");
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCustomerMasterTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_READING", COMPANY_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            oMaster = new ConnectionMaster(strConnectionString, strMaintenanceList);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME", COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_READING", COMPANY_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion


        #region CustomerMasterMaintenanceUpdate
        public void CustomerMasterUpdate(BOL_CUSTOMER_MASTER oCUSTOMER_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            strCustomerMasterUpdate = StringUtil.handleNullStringDate(strCustomerMasterUpdate, "@UPDATED_AT", oCUSTOMER_MASTER.UPDATED_AT_RAW.ToString().Trim());

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCustomerMasterUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCUSTOMER_MASTER.COMPANY_NO_BOX != null ? oCUSTOMER_MASTER.COMPANY_NO_BOX : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", oCUSTOMER_MASTER.TRANSACTION_TYPE.ToString() != null ? oCUSTOMER_MASTER.TRANSACTION_TYPE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EFFECTIVE_DATE", oCUSTOMER_MASTER.EFFECTIVE_DATE != null ? oCUSTOMER_MASTER.EFFECTIVE_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ORG_EFFECTIVE_DATE", oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE != null ? Convert.ToDateTime(oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE).ToString("yyyy/MM/dd") : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_DATE", oCUSTOMER_MASTER.CONTRACT_DATE != null ? oCUSTOMER_MASTER.CONTRACT_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_1", oCUSTOMER_MASTER.SPECIAL_NOTES_1 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_1 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_2", oCUSTOMER_MASTER.SPECIAL_NOTES_2 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_2 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_3", oCUSTOMER_MASTER.SPECIAL_NOTES_3 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_3 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SPECIAL_NOTES_4", oCUSTOMER_MASTER.SPECIAL_NOTES_4 != null ? oCUSTOMER_MASTER.SPECIAL_NOTES_4 : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", oCUSTOMER_MASTER.NCS_CUSTOMER_CODE != null ? oCUSTOMER_MASTER.NCS_CUSTOMER_CODE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", oCUSTOMER_MASTER.BILL_BILLING_INTERVAL != null ? oCUSTOMER_MASTER.BILL_BILLING_INTERVAL : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", oCUSTOMER_MASTER.BILL_DEPOSIT_RULES != null ? oCUSTOMER_MASTER.BILL_DEPOSIT_RULES : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", oCUSTOMER_MASTER.BILL_TRANSFER_FEE != null ? oCUSTOMER_MASTER.BILL_TRANSFER_FEE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", oCUSTOMER_MASTER.BILL_EXPENSES != null ? oCUSTOMER_MASTER.BILL_EXPENSES : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NAME_CHANGED_DATE", oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE != null ? oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PREVIOUS_COMPANY_NAME", oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME != null ? oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OBOEGAKI_DATE", oCUSTOMER_MASTER.OBOEGAKI_DATE != null ? oCUSTOMER_MASTER.OBOEGAKI_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCUSTOMER_MASTER.UPDATED_AT_RAW != null ? oCUSTOMER_MASTER.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oCUSTOMER_MASTER.REQ_SEQ.ToString() != null ? oCUSTOMER_MASTER.REQ_SEQ : (object)DBNull.Value));

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region getMonthlySaleComparisonList
        public DataTable getMonthlySaleComparisonList(string strYYYYMM1, string strYYYYMM2, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
           
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMonthlySaleComparisonTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YYMM_1", strYYYYMM1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YYMM_2", strYYYYMM2));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            oMaster = new ConnectionMaster(strConnectionString, strMonthlySaleComparison);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YYMM_1", strYYYYMM1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YYMM_2", strYYYYMM2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);

            return oMaster.dtExcuted;

        }
        #endregion

    }
    #endregion

}
