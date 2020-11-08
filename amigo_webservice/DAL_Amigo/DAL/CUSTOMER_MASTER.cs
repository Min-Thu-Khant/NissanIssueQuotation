using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region CUSTOMER MASTER
    public class CUSTOMER_MASTER
    {        
        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;

        string strGetData = "SELECT * FROM CUSTOMER_MASTER";

        string strUpdate = @"UPDATE CUSTOMER_MASTER SET 
                            [BILL_BANK_ACCOUNT_NAME-1] = @BILL_BANK_ACCOUNT_NAME_1,
                            [BILL_BANK_ACCOUNT_NAME-2] = @BILL_BANK_ACCOUNT_NAME_2,
                            [BILL_BANK_ACCOUNT_NAME-3] = @BILL_BANK_ACCOUNT_NAME_3,
                            [BILL_BANK_ACCOUNT_NAME-4] = @BILL_BANK_ACCOUNT_NAME_4,
                            BILL_BILLING_INTERVAL = @BILL_BILLING_INTERVAL,
                            BILL_DEPOSIT_RULES = @BILL_DEPOSIT_RULES,
                            BILL_TRANSFER_FEE = @BILL_TRANSFER_FEE,
                            BILL_EXPENSES = @BILL_EXPENSES,
                            UPDATE_DATE = @UPDATE_DATE,
                            UPDATER_CODE = @UPDATER_CODE,
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
                                        BILL_TRANSFER_FEE,BILL_EXPENSES, TRANSACTION_TYPE,  FORMAT(EFFECTIVE_DATE, 'yyyy/MM/dd') EFFECTIVE_DATE
                                        FROM
                                        CUSTOMER_MASTER
                                        WHERE COMPANY_NAME LIKE '%' + @COMPANY_NAME + '%'
                                        AND COMPANY_NAME_READING LIKE '%' + @COMPANY_NAME_READING + '%'
                                        AND BILL_COMPANY_NAME LIKE '%' + @BILL_COMPANY_NAME + '%'
                                        AND COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'
                                        AND ( 
                                        TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-1])) LIKE '%' + @ACCOUNT_NAME + '%' OR 
                                        TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-2])) LIKE '%' + @ACCOUNT_NAME + '%' OR
                                        TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-3])) LIKE '%' + @ACCOUNT_NAME + '%' OR
                                        TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-4])) LIKE '%' + @ACCOUNT_NAME + '%' )
                                        ORDER BY COMPANY_NO_BOX";

        string strSearchByBankAccountName = @"SELECT * from CUSTOMER_MASTER WHERE
			                                (TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-1])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-2])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-3])) = @BANK_ACCOUNT_NAME OR
			                                TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER.[BILL_BANK_ACCOUNT_NAME-4])) = @BANK_ACCOUNT_NAME) AND
                                            EFFECTIVE_DATE <= GETDATE()
                                            ORDER BY EFFECTIVE_DATE DESC";

        string strMaintenanceList = @"SELECT ROW_NUMBER() OVER(ORDER BY CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX ASC) AS No,
                                    ' ' as CK,
                                    ' ' as MK,
                                    CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX,
                                    CUSTOMER_MASTER_VIEW.TRANSACTION_TYPE,
                                    FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE, 'yyyy/MM/dd') EFFECTIVE_DATE,
                                    CUSTOMER_MASTER_VIEW.UPDATE_CONTENT,
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
                                    CUSTOMER_MASTER_VIEW.COMPANY_NAME,
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
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,0,1) = 1 THEN 'True'
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,0,1) = 0 THEN 'False'
                                    END BILL_METHOD1,
                                    CASE
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,1,1) = 1 THEN 'True'
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,1,1) = 0 THEN 'False'
                                    END BILL_METHOD2,
                                    CASE
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,2,1) = 1 THEN 'True'
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,2,1) = 0 THEN 'False'
                                    END BILL_METHOD3,
                                    CASE
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,4,1) = 1 THEN 'True'
	                                    WHEN SUBSTRING(CUSTOMER_MASTER_VIEW.BILL_METHOD,4,1) = 0 THEN 'False'
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
                                    CUSTOMER_MASTER_VIEW.BILL_BILLING_INTERVAL,
                                    CUSTOMER_MASTER_VIEW.BILL_TRANSFER_FEE,
                                    CUSTOMER_MASTER_VIEW.BILL_EXPENSES,
                                    CUSTOMER_MASTER_VIEW.PLAN_AMIGO_CAI,
                                    CUSTOMER_MASTER_VIEW.PLAN_AMIGO_BIZ,
                                    CUSTOMER_MASTER_VIEW.BOX_SIZE,
                                    CUSTOMER_MASTER_VIEW.INITIAL_COST - CUSTOMER_MASTER_VIEW.INITIAL_COST_DISCOUNTS AS INITIAL_COST,
                                    CUSTOMER_MASTER_VIEW.MONTHLY_COST - CUSTOMER_MASTER_VIEW.MONTHLY_COST_DISCOUNTS AS MONTHLY_COST,
                                    CUSTOMER_MASTER_VIEW.YEAR_COST - CUSTOMER_MASTER_VIEW.YEAR_COST_DISCOUNTS AS YEAR_COST,
                                    CUSTOMER_MASTER_VIEW.CONTRACT_PLAN,
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
                                    CUSTOMER_MASTER_VIEW.REQ_SEQ,
                                    FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE, 'yyyy/MM/dd') ORG_EFFECTIVE_DATE,
                                    REQUEST_ID.DISABLED_FLG";

       string strGetCustomerCountByKeys = @"SELECT COUNT(*) FROM CUSTOMER_MASTER1
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
                                            ORDER BY EFFECTIVE_DATE DESC";

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

        #endregion

        #region Constructors

        public CUSTOMER_MASTER(string con)
        {            
            strConnectionString = con;
            strMessage = "";
        }

        #endregion


        #region getData
        public DataTable getDataByAll()
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetData);
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
        public void update(BOL_CUSTOMER_MASTER B_Customer, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_1", B_Customer.BILL_BANK_ACCOUNT_NAME_1));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_2", B_Customer.BILL_BANK_ACCOUNT_NAME_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_3", B_Customer.BILL_BANK_ACCOUNT_NAME_3));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BANK_ACCOUNT_NAME_4", B_Customer.BILL_BANK_ACCOUNT_NAME_4));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_BILLING_INTERVAL", B_Customer.BILL_BILLING_INTERVAL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", B_Customer.BILL_DEPOSIT_RULES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", B_Customer.BILL_TRANSFER_FEE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", B_Customer.BILL_EXPENSES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATE_DATE", B_Customer.UPDATE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATER_CODE", B_Customer.UPDATER_CODE));
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
        public void Insert(BOL_CUSTOMER_MASTER_PHASE2 oCUSTOMER_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg) //BOL_CUSTOMER_MASTER oCUSTOMER_MASTER
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
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OBOEGAKI_DATE", oCUSTOMER_MASTER.OBOEGAKI_DATE != null ? oCUSTOMER_MASTER.UPDATED_BY : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));


            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion

    }
    #endregion

}
