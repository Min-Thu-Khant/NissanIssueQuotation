using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region RECEIPT DETAILS
    public class RECEIPT_DETAILS
    {

        #region Constructor
        public RECEIPT_DETAILS(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into RECEIPT_DETAILS (DATA_CLASS,RECORD_CLASS,TRANSACTION_DATE,TRANSACTION_CONTACT_NAME,TRANSACTION_BANKS_NAME,TRANSACTION_BRANCH_NAME,
                            TRANSACTION_ACCOUNT_NO_CLASS,TRANSACTION_ACCOUNT_TYPE,TRANSACTION_ACCOUNT_NO,RESEND_INDICATION,TRANSACTION_NAME,TRANSACTION_NO,TRANSACTION_DETAIL_CLASS,
                            HANDLING_DATE,DEPOSIT_DATE,DEPOSIT_AMOUNT,CHECK_CLASS,CUSTOMER_NAME,COLLECTION_NO_SHEETS,COLLECTION_NO,CUSTOMER_NO,BANK_NAME,BRANCH_NAME,TRANSFER_MESSAGE,
                            NOTE,NUMBER,TRANSACTION_FILE_NAME,RUN_DATE_TIME,RUN_RESULT,DATA_MOVEMENT_INFORMATION,PAYMENT_DAY,TYPE_OF_ALLOCATION,ALLOCATED_QUANTITY,ALLOCATED_MONEY,ALLOCATED_COMPLETION_DATE)
                            VALUES(@DATA_CLASS,@RECORD_CLASS,@TRANSACTION_DATE,@TRANSACTION_CONTACT_NAME,@TRANSACTION_BANKS_NAME,@TRANSACTION_BRANCH_NAME,@TRANSACTION_ACCOUNT_NO_CLASS,
                            @TRANSACTION_ACCOUNT_TYPE,@TRANSACTION_ACCOUNT_NO,@RESEND_INDICATION,@TRANSACTION_NAME,@TRANSACTION_NO,@TRANSACTION_DETAIL_CLASS,@HANDLING_DATE,@DEPOSIT_DATE,
                            @DEPOSIT_AMOUNT,@CHECK_CLASS,@CUSTOMER_NAME,@COLLECTION_NO_SHEETS,@COLLECTION_NO,@CUSTOMER_NO,@BANK_NAME,@BRANCH_NAME,@TRANSFER_MESSAGE,@NOTE,@NUMBER,
                            @TRANSACTION_FILE_NAME,@RUN_DATE_TIME,@RUN_RESULT,@DATA_MOVEMENT_INFORMATION,@PAYMENT_DAY,@TYPE_OF_ALLOCATION,@ALLOCATED_QUANTITY,@ALLOCATED_MONEY,@ALLOCATED_COMPLETION_DATE)";
       
        string strGetUncompleteReceiptDetail = @"SELECT DISTINCT a.SEQ_NO, RCP.CUSTOMER_NAME,RCP.DEPOSIT_AMOUNT,RCP.ALLOCATED_MONEY,RCP.ALLOCATED_QUANTITY,
                                                 RCP.DEPOSIT_DATE, COMPANIES = 
                                                STUFF((SELECT ', ''' + COMPANY_NO_BOX + ''''
                                                           FROM UNCOMPLETE_COMPANY b 
                                                           WHERE a.SEQ_NO = b.SEQ_NO
                                                          FOR XML PATH('')), 1, 2, '')
                                                FROM UNCOMPLETE_COMPANY a
                                                LEFT JOIN RECEIPT_DETAILS RCP
                                                ON RCP.SEQ_NO = a.SEQ_NO";

        string strUpdateReceipt_Detail = @"UPDATE [RECEIPT_DETAILS]
                                            SET ALLOCATED_MONEY = @ALLOCATED_MONEY,
                                            PAYMENT_DAY=@PAYMENT_DAY,
                                            ALLOCATED_COMPLETION_DATE = @ALLOCATED_COMPLETION_DATE,
                                            ALLOCATED_QUANTITY = @ALLOCATED_QUANTITY,
                                            TYPE_OF_ALLOCATION = @TYPE_OF_ALLOCATION
                                            WHERE SEQ_NO = @SEQ_NO";
        string str_Update_Payment_Day = @"UPDATE [RECEIPT_DETAILS]
                                            SET 
                                            PAYMENT_DAY = @PAYMENT_DAY
                                            WHERE SEQ_NO = @SEQ_NO";
        string strGetDateFor31_Grid = @"DECLARE @FromDate DATETIME2 = '@ParaFrom' @ToVariable
                                        SELECT Amigo.DateTimeID,
                                        SUM(CASE WHEN AmigoType = 1 THEN Amigo.Amigo  ELSE 0 END)AmigoCount, --NonAmigo.NonAmigo NonAmigoCount,
                                        SUM(CASE WHEN AmigoType = 2 THEN Amigo.Amigo ELSE 0 END) NonAmigoCount,
                                        Max(CASE
                                            WHEN FORMAT (Amigo.PAYMENT_DAY, 'yyyy/MM/dd') = null THEN ''
                                            ELSE FORMAT (Amigo.PAYMENT_DAY, 'yyyy/MM/dd')
                                        END) AS ActualRunDate,
                                        FORMAT (Max(Amigo.PAYMENT_DAY), 'yyyy/MM/dd') PAYMENT_DAY,
                                        CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(Amigo.DateTimeID+ '00',13,0,':'),11,0,':'),9,0,' ')),111) RunDate,
                                        SUBSTRING(CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(Amigo.DateTimeID+ '00',13,0,':'),11,0,':'),9,0,' ')),108),1,5) RunTime
                                        FROM
                                        (SELECT FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,COUNT(SEQ_NO) Amigo,MAX(ALLOCATED_COMPLETION_DATE) ALLOCATED_COMPLETION_DATE,PAYMENT_DAY, 1 As AmigoType
                                        FROM RECEIPT_DETAILS WHERE Run_Result = 1
                                        AND CONVERT(varchar(10),RUN_DATE_TIME,112) >= CONVERT(varchar(10),@FromDate,112)
                                        @ToCondition
                                        GROUP BY FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm'), PAYMENT_DAY
                                        UNION
                                        SELECT FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,COUNT(SEQ_NO) NonAmigo,MAX(ALLOCATED_COMPLETION_DATE) ALLOCATED_COMPLETION_DATE,PAYMENT_DAY, 2 As AmigoType
                                        FROM RECEIPT_DETAILS_NON_AMIGO WHERE Run_Result = 99
                                        AND CONVERT(varchar(10),RUN_DATE_TIME,112) >= CONVERT(varchar(10),@FromDate,112)
                                        @ToCondition
                                        GROUP BY FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm'),PAYMENT_DAY)Amigo
                                        GROUP BY Amigo.DateTimeID
                                        ORDER BY RunDate, RunTime ASC";
        string strGetAmigoDetailByRunDate_32 = @"SELECT Amigo.SEQ_NO,Amigo.CUSTOMER_NAME,Amigo.DEPOSIT_AMOUNT
                                                FROM (SELECT *,FORMAT(RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID
                                                FROM RECEIPT_DETAILS WHERE Run_Result = 1 AND FORMAT(RUN_DATE_TIME, 'yyyyMMddHHmm')= @DTMID) Amigo
                                                ORDER BY Amigo.CUSTOMER_NAME ASC    
                                            ";
        string strConvertFromNonAmigoToAmigo = @"INSERT INTO RECEIPT_DETAILS
                                                SELECT [DATA_CLASS],[RECORD_CLASS],[TRANSACTION_DATE],[TRANSACTION_CONTACT_NAME],[TRANSACTION_BANKS_NAME],[TRANSACTION_BRANCH_NAME],[TRANSACTION_ACCOUNT_NO_CLASS]
                                                      ,[TRANSACTION_ACCOUNT_TYPE],[TRANSACTION_ACCOUNT_NO],[RESEND_INDICATION],[TRANSACTION_NAME],[TRANSACTION_NO],[TRANSACTION_DETAIL_CLASS],[HANDLING_DATE]
                                                      ,[DEPOSIT_DATE],[DEPOSIT_AMOUNT],[CHECK_CLASS],[CUSTOMER_NAME],[COLLECTION_NO_SHEETS],[COLLECTION_NO],[CUSTOMER_NO],[BANK_NAME],[BRANCH_NAME],[TRANSFER_MESSAGE]
                                                      ,[NOTE],[NUMBER],[TRANSACTION_FILE_NAME],[RUN_DATE_TIME],1,[DATA_MOVEMENT_INFORMATION],[PAYMENT_DAY],[TYPE_OF_ALLOCATION],[ALLOCATED_QUANTITY],[ALLOCATED_MONEY]
                                                      ,[ALLOCATED_COMPLETION_DATE] 
                                                FROM [RECEIPT_DETAILS_NON_AMIGO]
                                                WHERE [SEQ_NO] = @SeqNo";
        string strDeleteAmigo = @"DELETE RECEIPT_DETAILS WHERE [SEQ_NO] = @SeqNo";

        string strGetDateFor34_Grid = @"DECLARE @FromDate DATETIME2 = '@ParaFrom' @ToVariable
                                        SELECT DateTimeID, PaymentDate,PaymentTime,RunDate,RunTime, MAX(COUNT_Allocated) COUNT_Allocated, MAX(COUNT_NotAllocated) COUNT_NotAllocated FROM (
                                        SELECT Allocated.DateTimeID, Allocated.PaymentDate,Allocated.PaymentTime,
                                        Allocated.RunDate,Allocated.RunTime,
                                        ISNULL(Allocated.COUNT_Allocated,0) COUNT_Allocated,
                                        ISNULL(NotAllocated.COUNT_NotAllocated,0) COUNT_NotAllocated
                                        FROM
                                        (SELECT FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,
                                        SUM(Allocated) COUNT_Allocated,
                                        MAX(ALLOCATED_COMPLETION_DATE) ALLOCATED_COMPLETION_DATE,
                                        CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm')+ '00',13,0,':'),11,0,':'),9,0,' ')),111) RunDate,
                                        SUBSTRING(CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm')+ '00',13,0,':'),11,0,':'),9,0,' ')),108),1,5) RunTime,
                                        CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(PAYMENTDATEID + '00',13,0,':'),11,0,':'),9,0,' ')),111) PaymentDate,
                                        SUBSTRING(CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(PAYMENTDATEID + '00',13,0,':'),11,0,':'),9,0,' ')),108),1,5) PaymentTime,PAYMENTDATEID
                                        FROM
                                        (
                                        SELECT COUNT(SEQ_NO) Allocated,SEQ_NO,FORMAT (PAYMENT_DAY, 'yyyyMMddHHmm') AS PAYMENTDATEID FROM RESERVE_INFO
                                        WHERE CONVERT(varchar(10),PAYMENT_DAY,112) >= CONVERT(varchar(10),@FromDate,112)
                                        @ToCondition
                                        GROUP BY SEQ_NO,FORMAT (PAYMENT_DAY, 'yyyyMMddHHmm'))RI
                                        LEFT JOIN
                                        (
                                        SELECT *
                                        FROM RECEIPT_DETAILS
                                        ) RD
                                        ON RI.SEQ_NO = RD.SEQ_NO
                                        WHERE ISNULL(RI.SEQ_NO,0) <> 0
                                        GROUP BY FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm'),PAYMENTDATEID
                                        )Allocated
                                        LEFT JOIN
                                        (
                                        SELECT FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,COUNT(SEQ_NO) COUNT_NotAllocated,
                                        FORMAT (Payment_Day, 'yyyyMMddHHmm') Payment_Day
                                        FROM
                                        (SELECT *
                                        FROM RECEIPT_DETAILS
                                        WHERE ALLOCATED_QUANTITY = 0
                                        AND PAYMENT_DAY IS NOT NULL
                                        AND RUN_RESULT=1)TMP
                                        GROUP BY FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm'),FORMAT (Payment_Day, 'yyyyMMddHHmm')
                                        ) NotAllocated
                                        ON NotAllocated.DateTimeID = Allocated.DateTimeID AND Allocated.PAYMENTDATEID = NotAllocated.Payment_Day
                                        WHERE ISNULL(Allocated.DateTimeID,'') <> ''
                                        UNION
                                        SELECT FORMAT (RECEIPT_DETAILS.RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,
                                        CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RECEIPT_DETAILS.PAYMENT_DAY, 'yyyyMMddHHmm') + '00',13,0,':'),11,0,':'),9,0,' ')),111) PaymentDate,
                                        SUBSTRING(CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RECEIPT_DETAILS.PAYMENT_DAY, 'yyyyMMddHHmm') + '00',13,0,':'),11,0,':'),9,0,' ')),108),1,5) PaymentTime,
                                        CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RECEIPT_DETAILS.RUN_DATE_TIME, 'yyyyMMddHHmm')+ '00',13,0,':'),11,0,':'),9,0,' ')),111) RunDate,
                                        SUBSTRING(CONVERT(varchar(10),CONVERT(DateTime,STUFF(STUFF(STUFF(FORMAT (RECEIPT_DETAILS.RUN_DATE_TIME, 'yyyyMMddHHmm')+ '00',13,0,':'),11,0,':'),9,0,' ')),108),1,5) RunTime,
                                        0 as COUNT_Allocated, count(RECEIPT_DETAILS.SEQ_NO) as COUNT_NotAllocated
                                        FROM RECEIPT_DETAILS
                                        WHERE ALLOCATED_QUANTITY = 0
                                        AND PAYMENT_DAY IS NOT NULL
                                        AND RUN_RESULT=1
                                        GROUP BY RECEIPT_DETAILS.RUN_DATE_TIME, RECEIPT_DETAILS.PAYMENT_DAY
                                        ) AS RESULT 
                                        GROUP BY PaymentDate, PaymentTime, DateTimeID, RunDate, RunTime
                                        ORDER BY PaymentDate, PaymentTime, RunDate, RunTime ASC";
        string strGetMatchInv_35 = @"DECLARE @FromDate DATETIME2 = '@ParaFrom' @ToVariable
                                    SELECT ISNULL((case when row_number() over (partition by CUSTOMER_NAME,RD.SEQ_NO order by (select RESERVE_ID)) = 1
                                    then CUSTOMER_NAME
                                    end),'') as CUSTOMER_NAME_SHOW,
                                    ISNULL((case when row_number() over (partition by RD.SEQ_NO order by (select NULL)) = 1
                                    then CONVERT(MONEY,RD.DEPOSIT_AMOUNT)end),'') as DEPOSIT_AMOUNT_SHOW,
                                    INV.BILL_TRANSFER_FEE,INV.BILL_SUPPLIER_NAME,FORMAT(INV.INVOICE_DATE,'yyyy/MM') BILLING_MONTH,RS.BILLING_CODE,INV.BILL_PRICE,RS.RESERVE_AMOUNT,
                                    DIFF_ALLOCATION_AMOUNT,
                                    INV.COMPANY_NO_BOX,INV.YEAR_MONTH,RD.SEQ_NO,RS.RESERVE_ID
                                    FROM
                                    (SELECT *
                                    FROM RECEIPT_DETAILS
                                    WHERE Run_Result = 1
                                    --FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') = @DateTimeID
                                    @NoReserved
                                    )RD
                                    LEFT JOIN
                                    (SELECT *
                                    FROM RESERVE_INFO
                                    ) RS
                                    ON RS.SEQ_NO = RD.SEQ_NO
                                    LEFT JOIN INVOICE_INFO INV
                                    ON RS.BILLING_CODE = (INV.COMPANY_NO_BOX + INV.YEAR_MONTH)
                                    WHERE ISNULL(RS.SEQ_NO,0) <> 0 AND ISNULL(INV.COMPANY_NO_BOX,'') <> ''
                                    AND CONVERT(varchar(10),RS.PAYMENT_DAY,112) >= CONVERT(varchar(10),@FromDate,112)
                                    @ToCondition
                                    ORDER BY CUSTOMER_NAME,RESERVE_ID
                                    ";

        string strUNMATCHINV_36 = @"DECLARE @FromDate DATETIME2 = '@ParaFrom' @ToVariable
                                    SELECT SEQ_NO,FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') AS DateTimeID,CUSTOMER_NAME,DEPOSIT_AMOUNT
                                    FROM
                                    (SELECT *
                                    FROM RECEIPT_DETAILS
                                    WHERE
                                    --FORMAT (RUN_DATE_TIME, 'yyyyMMddHHmm') = @DateTimeID
                                    CONVERT(varchar(10),PAYMENT_DAY,112) >= CONVERT(varchar(10),@FromDate,112)
                                    @ToCondition
                                    AND ALLOCATED_QUANTITY=0
                                    AND RUN_RESULT =1
                                    )RCP
                                    ORDER BY CUSTOMER_NAME ASC
                                    ";
        string strCancelAllocation = @"UPDATE RECEIPT_DETAILS
                                    SET ALLOCATED_QUANTITY = 0,
                                    ALLOCATED_MONEY = 0,
                                    ALLOCATED_COMPLETION_DATE = NULL,
                                    TYPE_OF_ALLOCATION = 0
                                    WHERE SEQ_NO = @SEQ_NO";

        string strUpdateAllocation = @"UPDATE RECEIPT_DETAILS
                                    SET ALLOCATED_COMPLETION_DATE = @ALLOCATED_COMPLETION_DATE,
                                    TYPE_OF_ALLOCATION = @TYPE_OF_ALLOCATION
                                    WHERE SEQ_NO = @SEQ_NO";

        string strRefundAllocation = @"UPDATE [RECEIPT_DETAILS]
                                    SET RUN_RESULT = 31
                                    WHERE SEQ_NO = @SEQ_NO";
        string strAccountingCSV = @"DECLARE @FromDate DATETIME2 = '@ParaFrom' @ToVariable
                                    SELECT FORMAT (INV.INVOICE_DATE, 'yyyy/MM/dd') INVOICE_DATE ,INV.NCS_CUSTOMER_CODE,INV.BILL_PRICE, FORMAT (RS.PAYMENT_DAY, 'yyyy/MM/dd') PAYMENT_DAY
                                    FROM 
                                    (SELECT * FROM RECEIPT_DETAILS 
                                    WHERE Run_Result = 1  
                                    AND ALLOCATED_QUANTITY > 0
                                    AND CONVERT(varchar(10),PAYMENT_DAY,112) >= CONVERT(varchar(10),@FromDate,112)
                                    @ToCondition
                                    )RD
                                    LEFT JOIN 
                                    (SELECT *,sum(RESERVE_AMOUNT) over(partition by SEQ_NO order by BILLING_CODE DESC rows unbounded preceding) RunValue 
                                    FROM RESERVE_INFO
                                    WHERE CONVERT(varchar(10),PAYMENT_DAY,112) >= CONVERT(varchar(10),@FromDate,112)
                                    @ToCondition
                                    ) RS
                                    ON RS.SEQ_NO = RD.SEQ_NO
                                    LEFT JOIN INVOICE_INFO INV
                                    ON RS.BILLING_CODE = (INV.COMPANY_NO_BOX + INV.YEAR_MONTH)
                                    WHERE ISNULL(RS.SEQ_NO,0) <> 0 AND ISNULL(INV.COMPANY_NO_BOX,'') <> ''";

        string strGetDataBySEQID = "SELECT * FROM RECEIPT_DETAILS WHERE SEQ_NO=@SEQNO";

        string strGetDuplicatedRecord = @"DECLARE @HANDLINGDATE DATETIME2 = @HANDLE_DATE  , @TRANSACTIONDATE DATETIME2 = @TRANSACTION_DATE 
                                          SELECT* FROM RECEIPT_DETAILS WHERE 
                                          HANDLING_DATE=@HANDLINGDATE AND 
                                          DEPOSIT_AMOUNT=@DEPOSIT_AMOUNT AND 
                                          BANK_NAME =@BANK_NAME AND 
                                          BRANCH_NAME =@BRANCH_NAME AND 
                                          CUSTOMER_NAME=@CUSTOMER_NAME AND
                                          TRANSACTION_DATE=@TRANSACTIONDATE AND
                                          TRANSACTION_NO = @TRANSACTION_NO";

        #endregion

        #region GetDataByDuplicateKeys
        public DataTable GetDataByDuplicateKeys(BOL_RECEIPT_DETAILS obj, out string strMsg)
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
        public void insert(BOL_RECEIPT_DETAILS B_Receipt, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            //oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", _SEQ_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_CLASS", B_Receipt.DATA_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RECORD_CLASS", B_Receipt.RECORD_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DATE", B_Receipt.TRANSACTION_DATE != null ? B_Receipt.TRANSACTION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_CONTACT_NAME", B_Receipt.TRANSACTION_CONTACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BANKS_NAME", B_Receipt.TRANSACTION_BANKS_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_BRANCH_NAME", B_Receipt.TRANSACTION_BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO_CLASS", B_Receipt.TRANSACTION_ACCOUNT_NO_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_TYPE", B_Receipt.TRANSACTION_ACCOUNT_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_ACCOUNT_NO", B_Receipt.TRANSACTION_ACCOUNT_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RESEND_INDICATION", B_Receipt.RESEND_INDICATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NAME", B_Receipt.TRANSACTION_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_NO", B_Receipt.TRANSACTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_DETAIL_CLASS", B_Receipt.TRANSACTION_DETAIL_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@HANDLING_DATE", B_Receipt.HANDLING_DATE != null ? B_Receipt.HANDLING_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_DATE", B_Receipt.DEPOSIT_DATE != null ? B_Receipt.DEPOSIT_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DEPOSIT_AMOUNT", B_Receipt.DEPOSIT_AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CHECK_CLASS", B_Receipt.CHECK_CLASS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NAME ", B_Receipt.CUSTOMER_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO_SHEETS", B_Receipt.COLLECTION_NO_SHEETS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COLLECTION_NO", B_Receipt.COLLECTION_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CUSTOMER_NO", B_Receipt.CUSTOMER_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BANK_NAME", B_Receipt.BANK_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@BRANCH_NAME", B_Receipt.BRANCH_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSFER_MESSAGE", B_Receipt.TRANSFER_MESSAGE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NOTE", B_Receipt.NOTE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NUMBER", B_Receipt.NUMBER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TRANSACTION_FILE_NAME", B_Receipt.TRANSACTION_FILE_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_DATE_TIME", B_Receipt.RUN_DATE_TIME != null ? B_Receipt.RUN_DATE_TIME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@RUN_RESULT", B_Receipt.RUN_RESULT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DATA_MOVEMENT_INFORMATION", B_Receipt.DATA_MOVEMENT_INFORMATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", B_Receipt.PAYMENT_DAY != null ? B_Receipt.PAYMENT_DAY : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_Receipt.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_QUANTITY", B_Receipt.ALLOCATED_QUANTITY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_MONEY", B_Receipt.ALLOCATED_MONEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", B_Receipt.ALLOCATED_COMPLETION_DATE != null ? B_Receipt.ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.ExcuteQuery(1, out strMessage);

            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

        #region getUncompleteReceiptDetail 
        public DataTable getUncompleteReceiptDetail()
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetUncompleteReceiptDetail);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region UpdateReceipt_Detail
        public void UpdateReceipt_Detail(BOL_RECEIPT_DETAILS B_Receipt,out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateReceipt_Detail); 
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_MONEY", B_Receipt.ALLOCATED_MONEY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", B_Receipt.TYPE_OF_ALLOCATION));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", B_Receipt.PAYMENT_DAY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", B_Receipt.ALLOCATED_COMPLETION_DATE != null ? B_Receipt.ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_QUANTITY", B_Receipt.ALLOCATED_QUANTITY));            
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", B_Receipt.SEQ_NO));
            oMaster.ExcuteQuery(2, out strMessage);
            String some = strMessage;
        }
        #endregion

        #region UpdatePaymentDay
        public void UpdatePaymentDay(BOL_RECEIPT_DETAILS B_Receipt, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, str_Update_Payment_Day);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PAYMENT_DAY", B_Receipt.PAYMENT_DAY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", B_Receipt.SEQ_NO));
            oMaster.ExcuteQuery(2, out strMessage);
            string some = strMessage;
        }
        #endregion

        #region GetDateFor31_Grid
        public DataTable GetDateFor31_Grid(DateTime dtmFrom,DateTime dtmTo, out string strMsg)
        {

            if (dtmTo != new DateTime())
            {
                strGetDateFor31_Grid = strGetDateFor31_Grid.Replace("@ToCondition", "AND CONVERT(varchar(10),RUN_DATE_TIME,112) <= CONVERT(varchar(10),@TODate ,112) ").Replace("@ToVariable", ", @TODate DATETIME2 = '" + dtmTo.ToString() + "'").Replace("@ParaFrom", dtmFrom.ToString());
            }
            else
            {
                strGetDateFor31_Grid = strGetDateFor31_Grid.Replace("@ToCondition", "").Replace("@ToVariable", "").Replace("@ParaFrom", dtmFrom.ToString());
            }
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetDateFor31_Grid);
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetDateFor34_Grid
        public DataTable GetDateFor34_Grid(DateTime dtmFrom, DateTime dtmTo, out string strMsg)
        {
            if (dtmTo != new DateTime())
            {
                strGetDateFor34_Grid = strGetDateFor34_Grid.Replace("@ToCondition", "AND CONVERT(varchar(10),PAYMENT_DAY,112) <= CONVERT(varchar(10),@TODate ,112) ").Replace("@ToVariable", ", @TODate DATETIME2 = '" + dtmTo.ToString() + "'").Replace("@ParaFrom", dtmFrom.ToString());
            }
            else
            {
                strGetDateFor34_Grid = strGetDateFor34_Grid.Replace("@ToCondition", "").Replace("@ToVariable", "").Replace("@ParaFrom", dtmFrom.ToString());
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetDateFor34_Grid);
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetDateFor36_Grid
        public DataTable GetDateFor36_Grid(DateTime dtmFrom, DateTime dtmTo, out string strMsg)
        {
            if (dtmTo != new DateTime())
            {
                strUNMATCHINV_36 = strUNMATCHINV_36.Replace("@ToCondition", "AND CONVERT(varchar(10),PAYMENT_DAY,112) <= CONVERT(varchar(10),@TODate, 112) ").Replace("@ToVariable", ", @TODate DATETIME2 = '" + dtmTo.ToString() + "'").Replace("@ParaFrom", dtmFrom.ToString());
            }
            else
            {
                strUNMATCHINV_36 = strUNMATCHINV_36.Replace("@ToCondition", "").Replace("@ToVariable", "").Replace("@ParaFrom", dtmFrom.ToString());
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUNMATCHINV_36);
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetDateFor35_Grid
        public DataTable GetDateFor35_Grid(DateTime dtmFrom, DateTime dtmTo, bool isNoReserved, out string strMsg)
        {
            if (dtmTo != new DateTime())
            {
                strGetMatchInv_35 = strGetMatchInv_35.Replace("@ToCondition", "AND CONVERT(varchar(10),RS.PAYMENT_DAY,112) <= CONVERT(varchar(10),@TODate, 112) ").Replace("@ToVariable", ", @TODate DATETIME2 = '" + dtmTo.ToString() + "'").Replace("@ParaFrom", dtmFrom.ToString());
            }
            else
            {
                strGetMatchInv_35 = strGetMatchInv_35.Replace("@ToCondition", "").Replace("@ToVariable", "").Replace("@ParaFrom", dtmFrom.ToString());
            }

            if (isNoReserved)
            {
                strGetMatchInv_35 = strGetMatchInv_35.Replace("@NoReserved", "AND (PAYMENT_DAY IS NOT NULL AND ALLOCATED_COMPLETION_DATE IS NULL)");
            }
            else
            {
                strGetMatchInv_35 = strGetMatchInv_35.Replace("@NoReserved", "");
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetMatchInv_35);
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetAmigoDetailByRunDate
        public DataTable GetAmigoDetailByRunDate(string strDTMID, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetAmigoDetailByRunDate_32);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DTMID", strDTMID));
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        } 
        #endregion

        #region ConvertFromNonAmigoToAmigo
        public void ConvertFromNonAmigoToAmigo(int inSEQNo, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strConvertFromNonAmigoToAmigo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SeqNo", inSEQNo));
            oMaster.ExcuteQuery(1, out strMessage);
            strMsg = strMessage;
        }
        #endregion

        #region removeAmigo
        public void removeAmigo(int inSEQNo, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDeleteAmigo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SeqNo", inSEQNo));
            oMaster.ExcuteQuery(3, out strMessage);
        }
        #endregion

        #region CancelAllocation
        public void CancelAllocation(int SEQID, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCancelAllocation);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", SEQID));
            oMaster.ExcuteQuery(2, out strMessage);
        }

        #endregion

        #region UpdateAllocation
        public void UpdateAllocation(int SEQID, int TYPE_OF_ALLOCATION, DateTime? ALLOCATED_COMPLETION_DATE, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateAllocation);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", SEQID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ALLOCATED_COMPLETION_DATE", ALLOCATED_COMPLETION_DATE != null ? ALLOCATED_COMPLETION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE_OF_ALLOCATION", TYPE_OF_ALLOCATION));
            oMaster.ExcuteQuery(2, out strMessage);
        }

        #endregion


        #region RefundUpdate
        public string RefundUpdate(int SEQID)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strRefundAllocation);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQ_NO", SEQID));
            oMaster.ExcuteQuery(2, out strMessage);
            return strMessage;
        }

        #endregion

        #region Get35_AccountingCSV
        public DataTable Get35_AccountingCSV(DateTime dtmFrom, DateTime dtmTo, out string strMsg)
        {
            if (dtmTo != new DateTime())
            {
                strAccountingCSV = strAccountingCSV.Replace("@ToCondition", "AND CONVERT(varchar(10),PAYMENT_DAY,112) <= CONVERT(varchar(10),@TODate, 112) ").Replace("@ToVariable", ", @TODate DATETIME2 = '" + dtmTo.ToString() + "'").Replace("@ParaFrom", dtmFrom.ToString());
            }
            else
            {
                strAccountingCSV = strAccountingCSV.Replace("@ToCondition", "").Replace("@ToVariable", "").Replace("@ParaFrom", dtmFrom.ToString());
            }
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strAccountingCSV);
           
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetDataBySEQID
        public DataTable GetDataBySEQID(int intSEQID, out string strMsg)
        {

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetDataBySEQID);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@SEQNO", intSEQID));
            oMaster.ExcuteQuery(4, out strMessage);
            strMsg = strMessage;
            return oMaster.dtExcuted;
        }
        #endregion

    }
    #endregion    
}
