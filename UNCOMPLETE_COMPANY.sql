CREATE VIEW [UNCOMPLETE_COMPANY]
AS

SELECT RCP.SEQ_NO,CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX
FROM 
(SELECT * FROM RECEIPT_DETAILS
WHERE ALLOCATED_COMPLETION_DATE IS NULL
AND RUN_RESULT = 1 AND [DEPOSIT_AMOUNT] > ISNULL([ALLOCATED_MONEY],0))RCP
LEFT JOIN 
CUSTOMER_MASTER_VIEW
ON 
(
TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-1])) = TRIM(CONVERT(nvarchar(50),RCP.CUSTOMER_NAME))
OR
TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-2])) = TRIM(CONVERT(nvarchar(50),RCP.CUSTOMER_NAME))
OR
TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-3])) = TRIM(CONVERT(nvarchar(50),RCP.CUSTOMER_NAME))
OR
TRIM(CONVERT(nvarchar(50),CUSTOMER_MASTER_VIEW.[BILL_BANK_ACCOUNT_NAME-4])) = TRIM(CONVERT(nvarchar(50),RCP.CUSTOMER_NAME))
)
WHERE ISNULL(CUSTOMER_MASTER_VIEW.COMPANY_NO_BOX,'') <> ''
