using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region INVOICE INFO
    public class INVOICE_INFO
    {
        #region Constructor
        public INVOICE_INFO(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into INVOICE_INFO(TRANSACTION_TYPE,COMPANY_NO_BOX,YEAR_MONTH,INVOICE_DATE,NCS_CUSTOMER_CODE,BILL_SUPPLIER_NAME,BILL_SUPPLIER_NAME_READING,BILL_COMPANY_NAME,BILL_DEPARTMENT_IN_CHARGE,
                            BILL_CONTACT_NAME,BILL_HONORIFIC,BILL_POSTAL_CODE,BILL_ADDRESS,[BILL_ADDRESS-2],PLAN_SERVER,PLAN_SERVER_LIGHT,PLAN_BROWSER_AUTO,PLAN_BROWSER,PLAN_AMIGO_CAI,PLAN_AMIGO_BIZ,PLAN_ADD_BOX_SERVER,
                            PLAN_ADD_BOX_BROWSER,PLAN_OP_FLAT,PLAN_OP_SSL,PLAN_OP_BASIC_SERVICE,PLAN_OP_ADD_SERVICE,PLAN_OP_SOCIOS,BILL_DEPOSIT_RULES,BILL_AMOUNT,BILL_TAX,BILL_PRICE,BILL_TRANSFER_FEE,BILL_EXPENSES,
                            BILL_PAYMENT_DATE,STATUS_PRINT,STATUS_MEMO,STATUS_SEND,STATUS_MAIL_DATE,STATUS_ACC_RECEIVABLE_DATE,STATUS_INVOCE_COPY_DATE,STATUS_ACTUAL_MDB_UPDATE,STATUS_ACTUAL_DEPOSIT_YYMM,STATUS_ACTUAL_DEPOSIT_DATE,
                            STATUS_CASH_FORECAST_MM,STATUS_PLAN_DEPOSIT_YYMM,STATUS_PAY_NOTICE_DATE,TYPE_OF_ALLOCATION,ALLOCATION_TOTAL_AMOUNT,DUNNING_COUNT,DUNNING_DATE,ANSWER_DATE,PAYMENT_DUE_DATE,ANSWER_MEMO,ALLOCATED_COMPLETION_DATE)
                            VALUES(@TRANSACTION_TYPE,@COMPANY_NO_BOX,@YEAR_MONTH,@INVOICE_DATE,@NCS_CUSTOMER_CODE,@BILL_SUPPLIER_NAME,@BILL_SUPPLIER_NAME_READING,@BILL_COMPANY_NAME,@BILL_DEPARTMENT_IN_CHARGE,
                            @BILL_CONTACT_NAME,@BILL_HONORIFIC,@BILL_POSTAL_CODE,@BILL_ADDRESS,@BILL_ADDRESS_2,@PLAN_SERVER,@PLAN_SERVER_LIGHT,@PLAN_BROWSER_AUTO,@PLAN_BROWSER,@PLAN_AMIGO_CAI,@PLAN_AMIGO_BIZ,@PLAN_ADD_BOX_SERVER,
                            @PLAN_ADD_BOX_BROWSER,@PLAN_OP_FLAT,@PLAN_OP_SSL,@PLAN_OP_BASIC_SERVICE,@PLAN_OP_ADD_SERVICE,@PLAN_OP_SOCIOS,@BILL_DEPOSIT_RULES,@BILL_AMOUNT,@BILL_TAX,@BILL_PRICE,@BILL_TRANSFER_FEE,@BILL_EXPENSES,
                            @BILL_PAYMENT_DATE,@STATUS_PRINT,@STATUS_MEMO,@STATUS_SEND,@STATUS_MAIL_DATE,@STATUS_ACC_RECEIVABLE_DATE,@STATUS_INVOCE_COPY_DATE,@STATUS_ACTUAL_MDB_UPDATE,@STATUS_ACTUAL_DEPOSIT_YYMM,@STATUS_ACTUAL_DEPOSIT_DATE,
                            @STATUS_CASH_FORECAST_MM,@STATUS_PLAN_DEPOSIT_YYMM,@STATUS_PAY_NOTICE_DATE,@TYPE_OF_ALLOCATION,@ALLOCATION_TOTAL_AMOUNT,@DUNNING_COUNT,@DUNNING_DATE,@ANSWER_DATE,@PAYMENT_DUE_DATE,@ANSWER_MEMO,@ALLOCATED_COMPLETION_DATE)";

        string strGetInvoiceByCustomer = @"SELECT COMPANY_NO_BOX,YEAR_MONTH,INVOICE_DATE,
                                        BILL_PRICE,ALLOCATION_TOTAL_AMOUNT,BILL_TRANSFER_FEE,BILL_EXPENSES,
                                        ISNULL(BILL_PRICE,0) - ISNULL(ALLOCATION_TOTAL_AMOUNT,0) + 
                                        ISNULL(BILL_TRANSFER_FEE,0) - ISNULL(BILL_TRANSFER_FEE,0) ToPayAmount
                                        FROM INVOICE_INFO
                                        WHERE 
                                        TRIM(CONVERT(nvarchar(50),COMPANY_NO_BOX))
                                        IN
                                        (@COMPANY_NO_BOX)
                                        AND ALLOCATED_COMPLETION_DATE IS NULL
                                        AND STATUS_PLAN_DEPOSIT_YYMM <= FORMAT(GETDATE(),'yyMM')
                                        ORDER BY YEAR_MONTH";

        string strGetInvoiceByCustomerManualAllocate = @"SELECT COMPANY_NO_BOX,YEAR_MONTH,INVOICE_DATE,
                                                        BILL_PRICE,ALLOCATION_TOTAL_AMOUNT,BILL_TRANSFER_FEE,BILL_EXPENSES,
                                                        ISNULL(BILL_PRICE,0) - ISNULL(ALLOCATION_TOTAL_AMOUNT,0) + 
                                                        ISNULL(BILL_TRANSFER_FEE,0) - ISNULL(BILL_TRANSFER_FEE,0) ToPayAmount
                                                        FROM INVOICE_INFO
                                                        WHERE 
                                                        TRIM(CONVERT(nvarchar(50),COMPANY_NO_BOX))
                                                        IN
                                                        (@COMPANY_NO_BOX)
                                                        AND ALLOCATED_COMPLETION_DATE IS NULL
                                                        ORDER BY YEAR_MONTH";

        string strUpdateInvoice = @"UPDATE INVOICE_INFO
                                    SET ALLOCATED_COMPLETION_DATE = @ALLOCATED_COMPLETION_DATE,
                                    ALLOCATION_TOTAL_AMOUNT = @ALLOCATION_TOTAL_AMOUNT,
                                    TYPE_OF_ALLOCATION = @TYPE_OF_ALLOCATION,
                                    STATUS_ACTUAL_DEPOSIT_YYMM = @STATUS_ACTUAL_DEPOSIT_YYMM,
                                    STATUS_ACTUAL_DEPOSIT_DATE = @STATUS_ACTUAL_DEPOSIT_DATE
                                    WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX AND YEAR_MONTH=@YEAR_MONTH ";
        string strUpdateForCancel = @"UPDATE INVOICE_INFO
                                    SET ALLOCATION_TOTAL_AMOUNT = 0,
                                    TYPE_OF_ALLOCATION = 0,
                                    ALLOCATED_COMPLETION_DATE = NULL,
                                    STATUS_ACTUAL_DEPOSIT_YYMM=NULL,
                                    STATUS_ACTUAL_DEPOSIT_DATE=NULL
                                    WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX AND YEAR_MONTH=@YEAR_MONTH";
        string strGetDataForGrid37 = @"SELECT
                                    INVOICE_INFO.BILL_SUPPLIER_NAME,INVOICE_INFO.YEAR_MONTH,
                                    INVOICE_INFO.COMPANY_NO_BOX + INVOICE_INFO.YEAR_MONTH BILLING_CODE,INVOICE_INFO.BILL_AMOUNT,INVOICE_INFO.BILL_TAX ,
                                    INVOICE_INFO.BILL_PRICE,FORMAT(INVOICE_INFO.BILL_PAYMENT_DATE, 'yyyy/MM/dd') BILL_PAYMENT_DATE , 
                                    FORMAT(INVOICE_INFO.STATUS_ACTUAL_MDB_UPDATE, 'yyyy/MM/dd') STATUS_ACTUAL_MDB_UPDATE,
									FORMAT(INVOICE_INFO.STATUS_ACC_RECEIVABLE_DATE, 'yyyy/MM/dd') STATUS_ACC_RECEIVABLE_DATE,
									ISNULL(INVOICE_INFO.STATUS_CASH_FORECAST_MM,'') STATUS_CASH_FORECAST_MM,
                                    INVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM,
                                    FORMAT (RECEIPT_DETAILS.DEPOSIT_DATE, 'yyyy/MM/dd') DEPOSIT_DATE,RESERVE_INFO.RESERVE_AMOUNT RESERVE_AMOUNT_1,RESERVE_INFO.RESERVE_AMOUNT RESERVE_AMOUNT_2,
                                    RESERVE_INFO.DIFF_ALLOCATION_AMOUNT INSUFFICIENT_AMOUNT_OF_RESERVE,
                                    INVOICE_INFO.DUNNING_COUNT,FORMAT(INVOICE_INFO.DUNNING_DATE, 'yyyy/MM/dd') DUNNING_DATE,
                                    FORMAT(INVOICE_INFO.ANSWER_DATE, 'yyyy/MM/dd') ANSWER_DATE,FORMAT(INVOICE_INFO.PAYMENT_DUE_DATE, 'yyyy/MM/dd') PAYMENT_DUE_DATE,ISNULL(INVOICE_INFO.ANSWER_MEMO,'') ANSWER_MEMO, INVOICE_INFO.COMPANY_NO_BOX, 
                                    INVOICE_INFO.ALLOCATED_COMPLETION_DATE INVOICE_ALLOCATED_COMPLETION_DATE, RECEIPT_DETAILS.ALLOCATED_COMPLETION_DATE RECEIPT_ALLOCATED_COMPLETION_DATE, RECEIPT_DETAILS.SEQ_NO , RECEIPT_DETAILS.TYPE_OF_ALLOCATION RECEIPT_TYPE_OF_ALLOCATION, INVOICE_INFO.TYPE_OF_ALLOCATION INVOICE_TYPE_OF_ALLOCATION
                                    FROM INVOICE_INFO
                                    LEFT JOIN RESERVE_INFO
                                    ON RESERVE_INFO.BILLING_CODE = (INVOICE_INFO.COMPANY_NO_BOX + INVOICE_INFO.YEAR_MONTH)
                                    LEFT JOIN RECEIPT_DETAILS
                                    ON RECEIPT_DETAILS.SEQ_NO = RESERVE_INFO.SEQ_NO
                                    WHERE ISNULL(INVOICE_INFO.TRANSACTION_TYPE,0)  = (CASE WHEN @TRANSACTION_TYPE =0 THEN ISNULL(TRANSACTION_TYPE,0) ELSE @TRANSACTION_TYPE END)
                                    AND (
										CASE WHEN LEN(INVOICE_INFO.YEAR_MONTH) = 7 THEN
											RIGHT(LEFT(INVOICE_INFO.YEAR_MONTH, 5), 4)
										ELSE
											RIGHT(INVOICE_INFO.YEAR_MONTH,6)
										END BETWEEN @FROM_YEAR_MONTH AND @TO_YEAR_MONTH
									)
                                    AND (ISNULL(INVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM,0) BETWEEN @FROM_STATUS_PLAN_DEPOSIT_YYMM AND @TO_STATUS_PLAN_DEPOSIT_YYMM)
                                    AND (ISNULL(FORMAT(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'yyyyMMdd'),0) BETWEEN @FROM_STATUS_ACTUAL_DEPOSIT_DATE AND @TO_STATUS_ACTUAL_DEPOSIT_DATE )
                                    AND ISNULL(INVOICE_INFO.BILL_SUPPLIER_NAME,'') LIKE '%' + @BILL_SUPPLIER_NAME + '%'
                                    AND ISNULL(INVOICE_INFO.BILL_DEPOSIT_RULES,'') @CBO_BILL_DEPOSIT_RULES
									AND ISNULL(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'') @CBO_STATUS_ACTUAL_DEPOSIT_DATE
                                    ORDER BY INVOICE_INFO.YEAR_MONTH,INVOICE_INFO.COMPANY_NO_BOX, RESERVE_INFO.RESERVE_ID
                                    ";
        string strAccount_Receivable = @"SELECT '' ORDER_NO,NCS_CUSTOMER_CODE, N'要' INVOICE, FORMAT(INVOICE_DATE, 'yyyy/MM/dd') INVOICE_DATE,N'部分' RangeData,
                                        (CASE WHEN BILL_SUPPLIER_NAME = N'日産車体株式会社' THEN N'当座' ELSE N'普通' END) Division,
										(CASE WHEN ISNULL(STATUS_PLAN_DEPOSIT_YYMM,'') <> '' THEN 
											FORMAT(dbo.fn_LastBusinessDayOfMonth(CONVERT(DATETIME, STATUS_PLAN_DEPOSIT_YYMM + '01')), 'yyyy/MM/dd')
										END )STATUS_PLAN_DEPOSIT_DATE,
                                        '' ACTUAL_DEPOSIT_DATE,BILL_AMOUNT,BILL_TAX,
                                        (CASE TRANSACTION_TYPE WHEN 12 THEN N'Amigo要元利用料' + ' 20' + Stuff(REPLACE(YEAR_MONTH,'-',''),Len(REPLACE(YEAR_MONTH,'-',''))-1,0,'/') 
                                        WHEN 21 THEN N'Amigo初期費用' 
                                        WHEN 22 THEN N'Amigo月額' + Stuff(REPLACE(YEAR_MONTH,'-',''),3,0,'/')
                                        WHEN 32 THEN N'Amigo生産情報閲覧' + Stuff(REPLACE(YEAR_MONTH,'-',''),3,0,'/') ELSE ''END) PROPERTY_NAME,
                                        N'無' TRANSFER_DATA,
                                        '' Responsible, FORMAT(GETDATE(), 'yyyy/MM') Hanging, FORMAT(GETDATE(), 'yyyy/MM/dd') RegistrationDate, '' Humor, '' Change_date,'' tax_rate
                                        FROM INVOICE_INFO
                                       WHERE ISNULL(INVOICE_INFO.TRANSACTION_TYPE,0)  = (CASE WHEN @TRANSACTION_TYPE =0 THEN ISNULL(TRANSACTION_TYPE,0) ELSE @TRANSACTION_TYPE END)
                                       AND (
										    CASE WHEN LEN(INVOICE_INFO.YEAR_MONTH) = 7 THEN
											    RIGHT(LEFT(INVOICE_INFO.YEAR_MONTH, 5), 4)
										    ELSE
											    RIGHT(INVOICE_INFO.YEAR_MONTH,6)
										    END BETWEEN @FROM_YEAR_MONTH AND @TO_YEAR_MONTH
									    )
                                        AND (ISNULL(INVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM,0) BETWEEN @FROM_STATUS_PLAN_DEPOSIT_YYMM AND @TO_STATUS_PLAN_DEPOSIT_YYMM)
                                        AND (ISNULL(FORMAT(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'yyyyMMdd'),0) BETWEEN @FROM_STATUS_ACTUAL_DEPOSIT_DATE AND @TO_STATUS_ACTUAL_DEPOSIT_DATE )
                                        AND ISNULL(INVOICE_INFO.BILL_SUPPLIER_NAME,'') LIKE '%' + @BILL_SUPPLIER_NAME + '%'
                                        AND ISNULL(INVOICE_INFO.BILL_DEPOSIT_RULES,'') @CBO_BILL_DEPOSIT_RULES
									    AND ISNULL(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'') @CBO_STATUS_ACTUAL_DEPOSIT_DATE
                                        ORDER BY BILL_PAYMENT_DATE, NCS_CUSTOMER_CODE";
        string strScheduled_Payment = @"SELECT YEAR_MONTH, COMPANY_NO_BOX+YEAR_MONTH INVOICE_NO,FORMAT(INVOICE_DATE, 'yyyy/MM/dd') INVOICE_DATE,
                                        NCS_CUSTOMER_CODE,BILL_SUPPLIER_NAME,BILL_SUPPLIER_NAME_READING,
                                        N'Amigo月額' +　' ' + Stuff(REPLACE(YEAR_MONTH,'-',''),3,0,'/') Product_name,
                                        BILL_AMOUNT,BILL_TAX,BILL_PRICE,
                                        (CASE WHEN ISNULL(STATUS_PLAN_DEPOSIT_YYMM,'') = '' THEN '' ELSE  
                                        (CASE WHEN LEN(STATUS_PLAN_DEPOSIT_YYMM) = 4 THEN
                                        FORMAT(dbo.fn_LastBusinessDayOfMonth(CONVERT(DATETIME, STATUS_PLAN_DEPOSIT_YYMM + '01')), 'yyyy/MM/dd')
                                        ELSE '' END)
                                        END) PLAN_DEPOSIT_DATE, 
										(CASE WHEN ISNULL(ALLOCATED_COMPLETION_DATE,'') = '' THEN NULL ELSE FORMAT(STATUS_ACTUAL_DEPOSIT_DATE, 'yyyy/MM/dd')  END) STATUS_ACTUAL_DEPOSIT_DATE, 
										'' Remark FROM INVOICE_INFO  
                                        WHERE ISNULL(INVOICE_INFO.TRANSACTION_TYPE,0)  = (CASE WHEN @TRANSACTION_TYPE =0 THEN ISNULL(TRANSACTION_TYPE,0) ELSE @TRANSACTION_TYPE END)
                                        AND (
										    CASE WHEN LEN(INVOICE_INFO.YEAR_MONTH) = 7 THEN
											    RIGHT(LEFT(INVOICE_INFO.YEAR_MONTH, 5), 4)
										    ELSE
											    RIGHT(INVOICE_INFO.YEAR_MONTH,6)
										    END BETWEEN @FROM_YEAR_MONTH AND @TO_YEAR_MONTH
									    )
                                        AND (ISNULL(INVOICE_INFO.STATUS_PLAN_DEPOSIT_YYMM,0) BETWEEN @FROM_STATUS_PLAN_DEPOSIT_YYMM AND @TO_STATUS_PLAN_DEPOSIT_YYMM)
                                        AND (ISNULL(FORMAT(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'yyyyMMdd'),0) BETWEEN @FROM_STATUS_ACTUAL_DEPOSIT_DATE AND @TO_STATUS_ACTUAL_DEPOSIT_DATE )
                                        AND ISNULL(INVOICE_INFO.BILL_SUPPLIER_NAME,'') LIKE '%' + @BILL_SUPPLIER_NAME + '%'
                                        AND ISNULL(INVOICE_INFO.BILL_DEPOSIT_RULES,'') @CBO_BILL_DEPOSIT_RULES
									    AND ISNULL(INVOICE_INFO.STATUS_ACTUAL_DEPOSIT_DATE,'') @CBO_STATUS_ACTUAL_DEPOSIT_DATE
                                        ORDER BY STATUS_ACTUAL_DEPOSIT_DATE, COMPANY_NO_BOX, YEAR_MONTH";
        string strUpdateInvoiceFor37 = @"UPDATE INVOICE_INFO
                                        SET STATUS_CASH_FORECAST_MM=@STATUS_CASH_FORECAST_MM,
                                        STATUS_PLAN_DEPOSIT_YYMM=@STATUS_PLAN_DEPOSIT_YYMM,
                                        DUNNING_COUNT=@DUNNING_COUNT,DUNNING_DATE=@DUNNING_DATE,
                                        ANSWER_DATE=@ANSWER_DATE,
                                        PAYMENT_DUE_DATE=@PAYMENT_DUE_DATE,
                                        ANSWER_MEMO=@ANSWER_MEMO,
                                        STATUS_ACTUAL_MDB_UPDATE=@STATUS_ACTUAL_MDB_UPDATE,
                                        STATUS_ACC_RECEIVABLE_DATE=@STATUS_ACC_RECEIVABLE_DATE
                                        WHERE  COMPANY_NO_BOX=@COMPANY_NO_BOX AND YEAR_MONTH=@YEAR_MONTH";
        string strCheckOriginal = @"SELECT YEAR_MONTH, COMPANY_NO_BOX FROM INVOICE_INFO
                                          WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX AND
                                          YEAR_MONTH = @YEAR_MONTH AND
	                                      DUNNING_DATE @DUNNING_DATE";

        string strUpdateAllocation = @"UPDATE INVOICE_INFO
                                    SET ALLOCATED_COMPLETION_DATE = @ALLOCATED_COMPLETION_DATE,
                                    TYPE_OF_ALLOCATION = @TYPE_OF_ALLOCATION
                                    WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                    AND YEAR_MONTH = @YEAR_MONTH";
        string strMonthlySaleAggregationSale = @"SELECT SUM(MAKER_AMOUNT) AS MAKER_AMOUNT_TTL,SUM(SUPPLIER_INTIAL_AMOUNT) AS SUPPLIER_INTIAL_AMOUNT_TTL,SUM(SUPPLIER_MONTHLY_AMOUNT) AS SUPPLIER_MONTHLY_AMOUNT_TTL,SUM(PRODUCT_AMOUNT) AS PRODUCT_AMOUNT_TTL
                                             FROM
                                            (SELECT
                                            (CASE WHEN TRANSACTION_TYPE='12' THEN BILL_AMOUNT ELSE 0 END) MAKER_AMOUNT,
                                            (CASE WHEN TRANSACTION_TYPE='21' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_INTIAL_AMOUNT,
                                            (CASE WHEN TRANSACTION_TYPE='22' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_MONTHLY_AMOUNT,
                                            (CASE WHEN TRANSACTION_TYPE='32' THEN BILL_AMOUNT ELSE 0 END) PRODUCT_AMOUNT
                                            FROM INVOICE_INFO WHERE SUBSTRING([YEAR_MONTH],2,4) =@YEARMOHTH and TRANSACTION_TYPE in (12,21,22,32)
                                            UNION ALL
                                            SELECT 
                                            (CASE WHEN Ref.BILL_TYPE = '12' THEN Ref.INITIAL_COST - Ref.INITIAL_COST_DISCOUNTS +  Ref.MONTHLY_COST - Ref.MONTHLY_COST_DISCOUNTS ELSE 0 END) MAKER_AMOUNT,
                                            (CASE WHEN Ref.BILL_TYPE = '22' AND FORMAT(DATEADD(month,1,REQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE),'yyMM') = @YEARMOHTH THEN Ref.INITIAL_COST-Ref.INITIAL_COST_DISCOUNTS ELSE 0 END)SUPPLIER_INTIAL_AMOUNT,
                                            (CASE WHEN Ref.BILL_TYPE = '22' THEN  Ref.MONTHLY_COST-Ref.MONTHLY_COST_DISCOUNTS ELSE 0 END) SUPPLIER_MONTHLY_AMOUNT,
                                            (CASE WHEN Ref.BILL_TYPE = '32'
		                                            THEN CASE WHEN FORMAT(DATEADD(month,1,REQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE),'yyMM')=@YEARMOHTH
					                                            THEN Ref.INITIAL_COST-Ref.INITIAL_COST_DISCOUNTS + Ref.YEAR_COST-Ref.YEAR_COST_DISCOUNTS
					                                            ELSE 0 END
                                            ELSE 
	                                            CASE WHEN SUBSTRING(FORMAT(Ref.EFFECTIVE_DATE,'yyMM'),3,2) = SUBSTRING(@YEARMOHTH,3,2)
	                                            THEN Ref.YEAR_COST - Ref.YEAR_COST_DISCOUNTS ELSE 0 END
                                            END ) PRODUCT_AMOUNT
                                            FROM REQUEST_DETAIL,
                                            (
                                            SELECT *,ROW_NUMBER() OVER(PARTITION BY COMPANY_NO_BOX ORDER BY COMPANY_NO_BOX, EFFECTIVE_DATE DESC, REQ_SEQ DESC) num
                                            FROM CUSTOMER_MASTER_VIEW
                                            where FORMAT([EFFECTIVE_DATE],'yyMM') <= @YEARMOHTH
                                            AND BILL_TYPE IN (12,22,32)
                                            AND NOT EXISTS ( SELECT * FROM INVOICE_INFO where CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = COMPANY_NO_BOX and FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE,'yyMM') <= SUBSTRING(YEAR_MONTH,2,4) AND SUBSTRING(YEAR_MONTH,2,4) = @YEARMOHTH )
                                            ) AS Ref

                                            WHERE REQUEST_DETAIL.COMPANY_NO_BOX=Ref.COMPANY_NO_BOX
                                            AND REQUEST_DETAIL.REQ_SEQ=Ref.REQ_SEQ
                                            AND Ref.num = 1
                                            AND Ref.UPDATE_CONTENT IN (1,3)
                                            ) TBL";


        string strMonthlySaleAggregationPlanDeposit = @"SELECT SUM(MAKER_AMOUNT) AS MAKER_AMOUNT_TTL,SUM(SUPPLIER_INTIAL_AMOUNT) AS SUPPLIER_INTIAL_AMOUNT_TTL,SUM(SUPPLIER_MONTHLY_AMOUNT) AS SUPPLIER_MONTHLY_AMOUNT_TTL,SUM(PRODUCT_AMOUNT) AS PRODUCT_AMOUNT_TTL
                                                        FROM
                                                        (SELECT
                                                        (CASE WHEN TRANSACTION_TYPE='12' THEN BILL_AMOUNT ELSE 0 END) MAKER_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='21' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_INTIAL_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='22' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_MONTHLY_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='32' THEN BILL_AMOUNT ELSE 0 END) PRODUCT_AMOUNT
                                                        FROM INVOICE_INFO WHERE STATUS_PLAN_DEPOSIT_YYMM=@YEARMOHTH and TRANSACTION_TYPE in (12,21,22,32)
                                                        UNION ALL
                                                        SELECT 
                                                        (CASE WHEN Ref.TRANSACTION_TYPE = '12' THEN Ref.INITIAL_COST - Ref.INITIAL_COST_DISCOUNTS +  Ref.MONTHLY_COST - Ref.MONTHLY_COST_DISCOUNTS ELSE 0 END) MAKER_AMOUNT,
                                                        (CASE WHEN FORMAT(DATEADD(MONTH,1,REQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE),'yyMM') = @YEARMOHTH THEN Ref.INITIAL_COST-Ref.INITIAL_COST_DISCOUNTS ELSE 0 END)SUPPLIER_INTIAL_AMOUNT,
                                                        (CASE WHEN Ref.TRANSACTION_TYPE = '22' THEN  Ref.MONTHLY_COST-Ref.MONTHLY_COST_DISCOUNTS ELSE 0 END) SUPPLIER_MONTHLY_AMOUNT,
                                                        (CASE WHEN Ref.TRANSACTION_TYPE = '32'
		                                                        THEN CASE WHEN FORMAT(DATEADD(MONTH,1,REQUEST_DETAIL.COMPLETION_NOTIFICATION_DATE),'yyMM')=@YEARMOHTH
					                                                        THEN Ref.INITIAL_COST-Ref.INITIAL_COST_DISCOUNTS + Ref.YEAR_COST-Ref.YEAR_COST_DISCOUNTS
					                                                        ELSE 0 END
                                                        ELSE 
	                                                        CASE WHEN substring(format(Ref.EFFECTIVE_DATE,'yyMM'),3,2) = SUBSTRING(@YEARMOHTH,3,2)
	                                                        THEN Ref.YEAR_COST - Ref.YEAR_COST_DISCOUNTS ELSE 0 END
                                                        END ) PRODUCT_AMOUNT
                                                        FROM REQUEST_DETAIL,
                                                        (
                                                        SELECT *,ROW_NUMBER() OVER(PARTITION BY COMPANY_NO_BOX ORDER BY COMPANY_NO_BOX, EFFECTIVE_DATE DESC, REQ_SEQ DESC) num
                                                        FROM CUSTOMER_MASTER_VIEW
                                                        WHERE format([EFFECTIVE_DATE],'yyMM') <= @YEARMOHTH
                                                        AND BILL_DEPOSIT_RULES=1
                                                        AND BILL_TYPE in(12,22,32)
                                                        AND NOT EXISTS ( SELECT * FROM INVOICE_INFO WHERE CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX = COMPANY_NO_BOX AND FORMAT(CUSTOMER_MASTER_VIEW.EFFECTIVE_DATE,'yyMM') <= SUBSTRING(YEAR_MONTH,2,4) AND SUBSTRING(YEAR_MONTH,2,4) = @YEARMOHTH )
                                                        ) AS Ref

                                                        WHERE REQUEST_DETAIL.COMPANY_NO_BOX=Ref.COMPANY_NO_BOX
                                                        AND REQUEST_DETAIL.REQ_SEQ=Ref.REQ_SEQ
                                                        AND Ref.num = 1
                                                        AND Ref.UPDATE_CONTENT in (1,3)
                                                        ) TBL";

        string strMonthlySaleAggregationActualDeposit = @"SELECT SUM(MAKER_AMOUNT) AS MAKER_AMOUNT_TTL,SUM(SUPPLIER_INTIAL_AMOUNT) AS SUPPLIER_INTIAL_AMOUNT_TTL,SUM(SUPPLIER_MONTHLY_AMOUNT) AS SUPPLIER_MONTHLY_AMOUNT_TTL,SUM(PRODUCT_AMOUNT) AS PRODUCT_AMOUNT_TTL
                                                        FROM
                                                        (SELECT
                                                        (CASE WHEN TRANSACTION_TYPE='12' THEN BILL_AMOUNT ELSE 0 END) MAKER_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='21' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_INTIAL_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='22' THEN BILL_AMOUNT ELSE 0 END) SUPPLIER_MONTHLY_AMOUNT,
                                                        (CASE WHEN TRANSACTION_TYPE='32' THEN BILL_AMOUNT ELSE 0 END) PRODUCT_AMOUNT
                                                        FROM INVOICE_INFO WHERE ALLOCATED_COMPLETION_DATE IS NOT NULL and  STATUS_ACTUAL_DEPOSIT_YYMM = @YEARMOHTH AND TRANSACTION_TYPE in (12,21,22,32)
                                                        )TB";

        #endregion        

        #region insert

        public void insert(BOL_INVOICE_INFO B_InvoiceInfo, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", B_InvoiceInfo.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", B_InvoiceInfo.TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", B_InvoiceInfo.YEAR_MONTH));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@INVOICE_DATE", B_InvoiceInfo.INVOICE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_HONORIFIC", B_InvoiceInfo.BILL_HONORIFIC));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_AMOUNT", B_InvoiceInfo.BILL_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TAX", B_InvoiceInfo.BILL_TAX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_PRICE", B_InvoiceInfo.BILL_PRICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_PAYMENT_DATE", B_InvoiceInfo.BILL_PAYMENT_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_PRINT", B_InvoiceInfo.STATUS_PRINT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_MEMO", B_InvoiceInfo.STATUS_MEMO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_SEND", B_InvoiceInfo.STATUS_SEND));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_MAIL_DATE", B_InvoiceInfo.STATUS_MAIL_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACC_RECEIVABLE_DATE", B_InvoiceInfo.STATUS_ACC_RECEIVABLE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_INVOCE_COPY_DATE", B_InvoiceInfo.STATUS_INVOCE_COPY_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_MDB_UPDATE", B_InvoiceInfo.STATUS_ACTUAL_MDB_UPDATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_DEPOSIT_YYMM", B_InvoiceInfo.STATUS_ACTUAL_DEPOSIT_YYMM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_DEPOSIT_DATE", B_InvoiceInfo.STATUS_ACTUAL_DEPOSIT_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_CASH_FORECAST_MM", B_InvoiceInfo.STATUS_CASH_FORECAST_MM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_PLAN_DEPOSIT_YYMM", B_InvoiceInfo.STATUS_PLAN_DEPOSIT_YYMM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_PAY_NOTICE_DATE", B_InvoiceInfo.STATUS_PAY_NOTICE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_InvoiceInfo.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATION_TOTAL_AMOUNT", B_InvoiceInfo.ALLOCATION_TOTAL_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DUNNING_COUNT", B_InvoiceInfo.DUNNING_COUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DUNNING_DATE", B_InvoiceInfo.DUNNING_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ANSWER_DATE", B_InvoiceInfo.ANSWER_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DUE_DATE", B_InvoiceInfo.PAYMENT_DUE_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ANSWER_MEMO", B_InvoiceInfo.ANSWER_MEMO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", B_InvoiceInfo.TRANSACTION_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME", B_InvoiceInfo.BILL_SUPPLIER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME_READING", B_InvoiceInfo.BILL_SUPPLIER_NAME_READING));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_COMPANY_NAME", B_InvoiceInfo.BILL_COMPANY_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPARTMENT_IN_CHARGE", B_InvoiceInfo.BILL_DEPARTMENT_IN_CHARGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_CONTACT_NAME", B_InvoiceInfo.BILL_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_POSTAL_CODE", B_InvoiceInfo.BILL_POSTAL_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_ADDRESS", B_InvoiceInfo.BILL_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_ADDRESS_2", B_InvoiceInfo.BILL_ADDRESS_2));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NCS_CUSTOMER_CODE", B_InvoiceInfo.NCS_CUSTOMER_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_DEPOSIT_RULES", B_InvoiceInfo.BILL_DEPOSIT_RULES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_TRANSFER_FEE", B_InvoiceInfo.BILL_TRANSFER_FEE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_EXPENSES", B_InvoiceInfo.BILL_EXPENSES));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_SERVER", B_InvoiceInfo.PLAN_SERVER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_SERVER_LIGHT", B_InvoiceInfo.PLAN_SERVER_LIGHT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_BROWSER_AUTO", B_InvoiceInfo.PLAN_BROWSER_AUTO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_BROWSER", B_InvoiceInfo.PLAN_BROWSER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_AMIGO_CAI", B_InvoiceInfo.PLAN_AMIGO_CAI));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_AMIGO_BIZ", B_InvoiceInfo.PLAN_AMIGO_BIZ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_ADD_BOX_SERVER", B_InvoiceInfo.PLAN_ADD_BOX_SERVER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_ADD_BOX_BROWSER", B_InvoiceInfo.PLAN_ADD_BOX_BROWSER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_FLAT", B_InvoiceInfo.PLAN_OP_FLAT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_SSL", B_InvoiceInfo.PLAN_OP_SSL));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_BASIC_SERVICE", B_InvoiceInfo.PLAN_OP_BASIC_SERVICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_ADD_SERVICE", B_InvoiceInfo.PLAN_OP_ADD_SERVICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PLAN_OP_SOCIOS", B_InvoiceInfo.PLAN_OP_SOCIOS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", B_InvoiceInfo.ALLOCATED_COMPLETION_DATE != null ? B_InvoiceInfo.ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.ExcuteQuery(1, out strMessage);
            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

        #region getInvoiceByCustomer
        public DataTable getInvoiceByCustomer(string COMPANY_NO_BOX_S)
        {
            string strQuery = strGetInvoiceByCustomer.Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX_S);
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strQuery);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getInvoiceByCustomerManualAllocate
        public DataTable getInvoiceByCustomerManualAllocate(string COMPANY_NO_BOX_S)
        {
            string strQuery = strGetInvoiceByCustomerManualAllocate.Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX_S);
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strQuery);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region UpdateInvoice
        public void UpdateInvoice_Info(BOL_INVOICE_INFO B_InvoiceInfo, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateInvoice);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATION_TOTAL_AMOUNT", B_InvoiceInfo.ALLOCATION_TOTAL_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", B_InvoiceInfo.ALLOCATED_COMPLETION_DATE != null ? B_InvoiceInfo.ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_InvoiceInfo.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_DEPOSIT_YYMM", B_InvoiceInfo.STATUS_ACTUAL_DEPOSIT_YYMM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_DEPOSIT_DATE", B_InvoiceInfo.STATUS_ACTUAL_DEPOSIT_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", B_InvoiceInfo.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", B_InvoiceInfo.YEAR_MONTH));
            oMaster.ExcuteQuery(2, out strMessage);
        }
        #endregion

        #region UpdateInvoiceForCancel
        public void UpdateInvoiceForCancel(string COMPANY_NO_BOX, string YEAR_MONTH, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateForCancel);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", YEAR_MONTH));
            oMaster.ExcuteQuery(2, out strMessage);
        }
        #endregion

        #region CheckIfItIsOriginal
        public bool CheckIfItIsOrigin(string COMPANY_NO_BOX, string YEAR_MONTH, DateTime? DUNNING_DATE, out string strMessage)
        {
            strMessage = "";
            if (DUNNING_DATE != null)
            {
                strCheckOriginal = strCheckOriginal.Replace("@DUNNING_DATE", "='" + Convert.ToDateTime(DUNNING_DATE).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                strCheckOriginal = strCheckOriginal.Replace("@DUNNING_DATE", "IS NULL");
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCheckOriginal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", YEAR_MONTH));

            oMaster.ExcuteQuery(4, out strMessage);
            if (oMaster.dtExcuted.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region UpdateInvoiceFor37
        public void UpdateInvoiceFor37(BOL_INVOICE_INFO B_InvoiceInfo, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateInvoiceFor37);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_CASH_FORECAST_MM", B_InvoiceInfo.STATUS_CASH_FORECAST_MM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_PLAN_DEPOSIT_YYMM", B_InvoiceInfo.STATUS_PLAN_DEPOSIT_YYMM));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACTUAL_MDB_UPDATE", (B_InvoiceInfo.STATUS_ACTUAL_MDB_UPDATE != null ? Convert.ToDateTime(B_InvoiceInfo.STATUS_ACTUAL_MDB_UPDATE).ToString("yyyy-MM-dd") : (object)DBNull.Value)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@STATUS_ACC_RECEIVABLE_DATE", (B_InvoiceInfo.STATUS_ACC_RECEIVABLE_DATE != null ? Convert.ToDateTime(B_InvoiceInfo.STATUS_ACC_RECEIVABLE_DATE).ToString("yyyy-MM-dd") : (object)DBNull.Value)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DUNNING_COUNT", B_InvoiceInfo.DUNNING_COUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DUNNING_DATE", (B_InvoiceInfo.DUNNING_DATE != null ? Convert.ToDateTime(B_InvoiceInfo.DUNNING_DATE).ToString("yyyy-MM-dd") : (object)DBNull.Value)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ANSWER_DATE", (B_InvoiceInfo.ANSWER_DATE != null ? Convert.ToDateTime(B_InvoiceInfo.ANSWER_DATE).ToString("yyyy-MM-dd") : (object)DBNull.Value)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DUE_DATE", (B_InvoiceInfo.PAYMENT_DUE_DATE != null ? Convert.ToDateTime(B_InvoiceInfo.PAYMENT_DUE_DATE).ToString("yyyy-MM-dd") : (object)DBNull.Value)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ANSWER_MEMO", B_InvoiceInfo.ANSWER_MEMO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", B_InvoiceInfo.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", B_InvoiceInfo.YEAR_MONTH));
            oMaster.ExcuteQuery(2, out strMessage);
        }
        #endregion

        #region getDataFor37
        public DataTable GetDataForGrid37(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME,
                                out string strMSG)
        {
            string strQuery = strGetDataForGrid37.Replace("@CBO_BILL_DEPOSIT_RULES", CheckDepositRule(DEPOSIT_RULE)).Replace("@CBO_STATUS_ACTUAL_DEPOSIT_DATE", CheckWithOrWithoutPayment(WITH_OR_WITHOUT_PAYMENT));
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strQuery);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? 0 : int.Parse(FROM_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? 10000 : int.Parse(TO_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? 0 : int.Parse(FROM_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? 10000 : int.Parse(TO_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 0 : int.Parse(FROM_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 100000000 : int.Parse(TO_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME));
            oMaster.ExcuteQuery(4, out strMSG);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getDataForAccount_Receivable
        public DataTable getDataForAccount_Receivable(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME,
                                out string strMSG)
        {
            string strQuery = strAccount_Receivable.Replace("@CBO_BILL_DEPOSIT_RULES", CheckDepositRule(DEPOSIT_RULE)).Replace("@CBO_STATUS_ACTUAL_DEPOSIT_DATE", CheckWithOrWithoutPayment(WITH_OR_WITHOUT_PAYMENT));
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strQuery);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? 0 : int.Parse(FROM_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? 10000 : int.Parse(TO_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? 0 : int.Parse(FROM_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? 10000 : int.Parse(TO_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 0 : int.Parse(FROM_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 100000000 : int.Parse(TO_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME));
            oMaster.ExcuteQuery(4, out strMSG);
            return oMaster.dtExcuted;
        }
        #endregion

        #region getDataForScheduled_Payment
        public DataTable getDataForScheduled_Payment(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME,
                                out string strMSG
            )
        {
            string strQuery = strScheduled_Payment.Replace("@CBO_BILL_DEPOSIT_RULES", CheckDepositRule(DEPOSIT_RULE)).Replace("@CBO_STATUS_ACTUAL_DEPOSIT_DATE", CheckWithOrWithoutPayment(WITH_OR_WITHOUT_PAYMENT));
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strQuery);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? 0 : int.Parse(FROM_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? 10000 : int.Parse(TO_YEAR_MONTH)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? 0 : int.Parse(FROM_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? 10000 : int.Parse(TO_STATUS_PLAN_DEPOSIT_YYMM)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 0 : int.Parse(FROM_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? 100000000 : int.Parse(TO_STATUS_ACTUAL_DEPOSIT_DATE)));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME));
            oMaster.ExcuteQuery(4, out strMSG);
            return oMaster.dtExcuted;
        }
        #endregion

        #region CheckDepositRule
        public string CheckDepositRule(string value)
        {
            switch (value)
            {
                case "-1":
                    return " LIKE '%%'";
                case "0":
                    return " = '0'";
                case "1":
                    return " = '1'";
                case "2":
                    return " = '2'";
                case "-2":
                    return " <> '1'";
                default:
                    return "";
            }
        }
        #endregion

        #region CheckDepositRule
        public string CheckWithOrWithoutPayment(string value)
        {
            switch (value)
            {
                case "-1":
                    return " LIKE '%%'";
                case "1":
                    return " <> ''";
                case "0":
                    return " = ''";
                default:
                    return "";
            }
        }
        #endregion

        #region UpdateAllocation
        public void UpdateAllocation(string COMPANY_NO_BOX, string YEAR_MONTH, int TYPE_OF_ALLOCATION, DateTime? ALLOCATED_COMPLETION_DATE, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateAllocation);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEAR_MONTH", YEAR_MONTH));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", ALLOCATED_COMPLETION_DATE != null ? ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", TYPE_OF_ALLOCATION));
            oMaster.ExcuteQuery(2, out strMessage);
        }

        #endregion

        #region GetMonthlySaleAggregationSaleList
        public System.Data.DataTable GetMonthlySaleAggregationSaleList(string strDate, out string strMsg)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMonthlySaleAggregationSale);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEARMOHTH", strDate));
            oMaster.ExcuteQuery(4, out strMsg);
            // total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());
            //result
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetMonthlySaleAggregationPlanDepositList
        public System.Data.DataTable GetMonthlySaleAggregationPlanDepositList(string strDate, out string strMsg)
        {

            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMonthlySaleAggregationPlanDeposit);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEARMOHTH", strDate));

            oMaster.ExcuteQuery(4, out strMsg);
            // total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());
            //result
            
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetMonthlySaleAggregationActualDepositList
        public System.Data.DataTable GetMonthlySaleAggregationActualDepositList(string strDate, out string strMsg)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMonthlySaleAggregationActualDeposit);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@YEARMOHTH", strDate));
            oMaster.ExcuteQuery(4, out strMsg);
            // total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());
            //result
            return oMaster.dtExcuted;
        }
        #endregion

    }
    #endregion


}
