using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class REQ_ADDRESS
    {
        #region Declares
        public string strConnectionString;
        string strMessage;

        string strGetPDFData1 = @"select CONTACT_NAME AS SERVICE_CONTACT_NAME,
                                  MAIL_ADDRESS AS SERVICE_MAIL_ADDRESS,
                                  PHONE_NUMBER AS SERVICE_PHONE_NUMBER 
                                  from REQ_ADDRESS
                                  where COMPANY_NO_BOX= @COMPANY_NO_BOX
                                  AND REQ_SEQ= @REQ_SEQ
                                  AND TYPE=3";

        string strGetPDFData2 = @"select MAIL_ADDRESS AS ERROR_MAIL_ADDRESS
                                  from REQ_ADDRESS
                                  where COMPANY_NO_BOX= @COMPANY_NO_BOX
                                  AND REQ_SEQ= @REQ_SEQ
                                  AND TYPE=4";
        #region Application Approval
        string strGetServiceDeskPopUp = @"SELECT 
                                        ROW_NUMBER() OVER (ORDER BY CONTACT_NAME, MAIL_ADDRESS,PHONE_NUMBER) NO,
                                        CONTACT_NAME,
                                        MAIL_ADDRESS,
                                        PHONE_NUMBER
                                        FROM REQ_ADDRESS
                                        WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                        AND REQ_SEQ = @REQ_SEQ
                                        AND TYPE = 3
                                        ORDER BY CONTACT_NAME, MAIL_ADDRESS,PHONE_NUMBER";
        string strGetErrorNotiPopUp = @"SELECT
                                    ROW_NUMBER() OVER (ORDER BY MAIL_ADDRESS) NO,
                                    MAIL_ADDRESS
                                    FROM REQ_ADDRESS
                                    WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                    AND REQ_SEQ = @REQ_SEQ
                                    AND TYPE = 4
                                    ORDER BY
                                    MAIL_ADDRESS";
        string strGetUsageChargeBreakDownPopUp = @"SELECT 
                                                ROW_NUMBER() OVER (ORDER BY DISPLAY_ORDER) NO,
                                                TBL.CONTRACT_NAME, 
                                                SUM(TBL.INITIAL_UNIT_PRICE) INITIAL_UNIT_PRICE,
                                                SUM(TBL.INITIAL_QUANTITY) INITIAL_QUANTITY,
                                                SUM(TBL.INITIAL_AMOUNT) INITIAL_AMOUNT,
                                                SUM(TBL.MONTHLY_UNIT_PRICE) MONTHLY_UNIT_PRICE,
                                                SUM(TBL.MONTHLY_QUANTITY) MONTHLY_QUANTITY,
                                                SUM(TBL.MONTHLY_AMOUNT) MONTHLY_AMOUNT,
                                                SUM(TBL.YEAR_UNIT_PRICE) YEAR_UNIT_PRICE,
                                                SUM(TBL.YEAR_QUANTITY) YEAR_QUANTITY,
                                                SUM(TBL.YEAR_AMOUNT) YEAR_AMOUNT
                                                FROM (
                                                SELECT
                                                REQ_USAGE_FEE.CONTRACT_CODE,
                                                REQ_USAGE_FEE.CONTRACT_NAME,
                                                CASE
	                                                WHEN REQ_USAGE_FEE.TYPE = 1 THEN REQ_USAGE_FEE.UNIT_PRICE 
	                                                ELSE 0
                                                END INITIAL_UNIT_PRICE,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 1 THEN REQ_USAGE_FEE.QUANTITY 
	                                                ELSE 0
                                                END INITIAL_QUANTITY,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 1 THEN REQ_USAGE_FEE.AMOUNT 
	                                                ELSE 0
                                                END INITIAL_AMOUNT,
                                                CASE
	                                                WHEN REQ_USAGE_FEE.TYPE = 2 THEN REQ_USAGE_FEE.UNIT_PRICE 
	                                                ELSE 0
                                                END MONTHLY_UNIT_PRICE,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 2 THEN REQ_USAGE_FEE.QUANTITY 
	                                                ELSE 0
                                                END MONTHLY_QUANTITY,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 2 THEN REQ_USAGE_FEE.AMOUNT 
	                                                ELSE 0
                                                END MONTHLY_AMOUNT,
                                                CASE
	                                                WHEN REQ_USAGE_FEE.TYPE = 3 THEN REQ_USAGE_FEE.UNIT_PRICE 
	                                                ELSE 0
                                                END YEAR_UNIT_PRICE,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 3 THEN REQ_USAGE_FEE.QUANTITY 
	                                                ELSE 0
                                                END YEAR_QUANTITY,
                                                CASE 
	                                                WHEN REQ_USAGE_FEE.TYPE = 3 THEN REQ_USAGE_FEE.AMOUNT 
	                                                ELSE 0
                                                END YEAR_AMOUNT,
                                                USAGE_FEE_MASTER.DISPLAY_ORDER
                                                FROM REQ_USAGE_FEE
                                                LEFT JOIN
                                                (SELECT
                                                CONTRACT_CODE, 
                                                DISPLAY_ORDER,
                                                ROW_NUMBER() OVER(PARTITION BY CONTRACT_CODE ORDER BY CONTRACT_CODE, ADOPTION_DATE DESC) num
                                                FROM USAGE_FEE_MASTER
                                                WHERE ADOPTION_DATE <= GETDATE()) USAGE_FEE_MASTER
                                                ON REQ_USAGE_FEE.CONTRACT_CODE = USAGE_FEE_MASTER.CONTRACT_CODE
                                                WHERE COMPANY_NO_BOX=@COMPANY_NO_BOX
                                                AND REQ_SEQ = @REQ_SEQ
                                                AND num = 1) TBL
                                                GROUP BY TBL.CONTRACT_CODE, TBL.CONTRACT_NAME, TBL.DISPLAY_ORDER";
        #endregion
        #endregion

        #region Constructors
        public REQ_ADDRESS(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region GetPDFData1
        public System.Data.DataTable GetPDFData1(string COMPANY_NO_BOX,string REQ_SEQ, out string strMsg)

        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPDFData1);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", 3));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetPDFData2
        public System.Data.DataTable GetPDFData2(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPDFData2);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", 4));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Application Approval
        #region GetServiceDeskPopUp
        public System.Data.DataTable GetServiceDeskPopUp(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetServiceDeskPopUp);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetErrorNotificationPopUp
        public System.Data.DataTable GetErrorNotificationPopUp(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetErrorNotiPopUp);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetUsageChargeBreakDownPopUp
        public System.Data.DataTable GetUsageChargeBreakDownPopUp(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetUsageChargeBreakDownPopUp);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion
        #endregion
    }
}
