using DAL_AmigoProcess.BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class REPORT_HISTORY
    {
        #region ConnectionSetUp

        public string strConnectionString;
        
        string strInsert = @"INSERT INTO [REPORT_HISTORY]
                           ([COMPANY_NO_BOX]
                           ,[REQ_SEQ]
                           ,[REPORT_TYPE]
                           ,[REPORT_HISTORY_SEQ]
                           ,[OUTPUT_AT]
                           ,[OUTPUT_BY]
                           ,[OUTPUT_FILE]
                           ,[EMAIL_ADDRESS]
                           ,[CREATED_AT]
                           ,[CREATED_BY]
                           ,[UPDATED_AT]
                           ,[UPDATED_BY])
                     VALUES
                           (@COMPANY_NO_BOX,
                            @REQ_SEQ,
                            @REPORT_TYPE,
                            @REPORT_HISTORY_SEQ,
                            @OUTPUT_AT,
                            @CURRENT_USER,
                            @OUTPUT_FILE,
                            @EMAIL_ADDRESS, 
                            @CURRENT_DATETIME,
                            @CURRENT_USER,
                            @CURRENT_DATETIME,
                            @CURRENT_USER )";

        string strMaxReportType = @"SELECT MAX(REPORT_TYPE) as REPORT_TYPE
                                                FROM REPORT_HISTORY";

        string strGetReportHistorySEQByCompanyNoBox = @"SELECT MAX(ISNULL(REPORT_HISTORY_SEQ,0)) REPORT_HISTORY_SEQ
                                                        FROM REPORT_HISTORY
                                                        WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX
                                                        AND REPORT_TYPE = @REPORT_TYPE
                                                        AND REQ_SEQ = @REQ_SEQ
                                                        GROUP BY COMPANY_NO_BOX,REQ_SEQ,REPORT_TYPE";

        string strInsertNotiSending = @"INSERT INTO [REPORT_HISTORY]
                           ([COMPANY_NO_BOX]
                           ,[REQ_SEQ]
                           ,[REPORT_TYPE]
                           ,[REPORT_HISTORY_SEQ]
                           ,[OUTPUT_AT]
                           ,[OUTPUT_BY]
                           ,[OUTPUT_FILE]
                           ,[EMAIL_ADDRESS]
                           ,[CREATED_AT]
                           ,[CREATED_BY]
                           ,[UPDATED_AT]
                           ,[UPDATED_BY])
                     VALUES
                           (@COMPANY_NO_BOX,
                            @REQ_SEQ,
                            @REPORT_TYPE,
                            @REPORT_HISTORY_SEQ,
                            @OUTPUT_AT,
                            @OUTPUT_BY,
                            @OUTPUT_FILE,
                            @EMAIL_ADDRESS, 
                            @CREATED_AT,
                            @CREATED_BY,
                            @UPDATED_AT,
                            @UPDATED_BY )";
        #endregion

        #region Constructors

        public REPORT_HISTORY(string con)
        {
            strConnectionString = con;
        }

        #endregion

        #region Insert
        public void Insert(BOL_REPORT_HISTORY oREPORT_HISTORY, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREPORT_HISTORY.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREPORT_HISTORY.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REPORT_TYPE", oREPORT_HISTORY.REPORT_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REPORT_HISTORY_SEQ", oREPORT_HISTORY.REPORT_HISTORY_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OUTPUT_AT", oREPORT_HISTORY.OUTPUT_AT != null ? oREPORT_HISTORY.OUTPUT_AT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OUTPUT_FILE", oREPORT_HISTORY.OUTPUT_FILE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", oREPORT_HISTORY.EMAIL_ADDRESS !=null ? oREPORT_HISTORY.EMAIL_ADDRESS : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
           
            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion

        #region GetReportHistorySeq
        public int GetReportHistorySEQ(string COMPANY_NO_BOX, int REPORT_TYPE, int REQ_SEQ, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetReportHistorySEQByCompanyNoBox);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REPORT_TYPE", REPORT_TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.ExcuteQuery(4, out strMsg);
            int REPORT_HISTORY_SEQ = 0;
            try
            {
                int.TryParse(oMaster.dtExcuted.Rows[0][0].ToString(), out REPORT_HISTORY_SEQ);
            }
            catch (Exception)
            {

            }
            return REPORT_HISTORY_SEQ + 1;
        }

        #endregion

        #region GetReportType
        public int getMaxReportType(out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strMaxReportType);
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

        #region InsertRegisterCompleteNotificationSending
        public void InsertNotiSending(string COMPANY_NO_BOX, int REQ_SEQ, int REPORT_HISTORY_SEQ, string OUTPUT_FILE, string EMAIL_ADDRESS, string LoginID, string OUTPUT_AT, string DATE, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsertNotiSending);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REPORT_TYPE", 05));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REPORT_HISTORY_SEQ", REPORT_HISTORY_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OUTPUT_AT", OUTPUT_AT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OUTPUT_BY", LoginID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OUTPUT_FILE", OUTPUT_FILE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", EMAIL_ADDRESS));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CREATED_AT", DATE)); ;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CREATED_BY", LoginID)); ;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", DATE)); ;
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", LoginID));

            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion
    }
}
