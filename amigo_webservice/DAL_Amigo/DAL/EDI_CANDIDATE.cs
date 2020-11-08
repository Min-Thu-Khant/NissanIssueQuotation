using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region EDI_CANDIDATE
    public class EDI_CANDIDATE
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strGetCandicates = @"SELECT EDI_ACCOUNT 
                                    FROM EDI_CANDIDATE
                                    WHERE USED_FLG = ' '";

        string strExtractEDIAutoInfo = @"SELECT
                                        REQUEST_ID.COMPANY_NAME,
                                        REQUEST_ID.GD_CODE,
                                        RIGHT(REQUEST_ID.GD_CODE,4) as CONTRACT_MAKER1,
                                        CASE REQUEST_DETAIL.CONTRACT_PLAN
											WHEN 'SERVER' THEN 'F'
											WHEN 'SERVERRIGHT' THEN 'L'
											WHEN 'BROWSERAUTO' THEN 'C'
										END AS SERVER_CONNECTION_TYPE,
                                        REQUEST_ID.COMPANY_NO_BOX
                                        FROM REQUEST_ID
                                        LEFT JOIN 
	                                        (SELECT REQUEST_DETAIL.* FROM REQUEST_DETAIL 
	                                        RIGHT JOIN
	                                        (SELECT MAX(REQ_SEQ) AS REQ_SEQ, COMPANY_NO_BOX FROM REQUEST_DETAIL GROUP BY COMPANY_NO_BOX) MAX 
	                                        ON REQUEST_DETAIL.COMPANY_NO_BOX = MAX.COMPANY_NO_BOX
	                                        AND MAX.REQ_SEQ = REQUEST_DETAIL.REQ_SEQ) AS REQUEST_DETAIL
	                                        ON REQUEST_DETAIL.COMPANY_NO_BOX = REQUEST_ID.COMPANY_NO_BOX
                                        WHERE REQUEST_ID.COMPANY_NO_BOX LIKE '%' + @COMPANY_NO_BOX + '%'";

        string strGetUseFLG = @"SELECT USED_FLG FROM EDI_CANDIDATE
                                WHERE EDI_ACCOUNT = @EDI_ACCOUNT";

        string strInsert = @"INSERT INTO EDI_CANDIDATE
                                   (EDI_ACCOUNT
                                   ,USED_FLG
                                   ,CREATED_AT
                                   ,CREATED_BY
                                   ,UPDATED_AT
                                   ,UPDATED_BY)
                             VALUES
                                   (@EDI_ACCOUNT
                                   ,@USED_FLG
                                   ,@CURRENT_DATETIME
                                   ,@CURRENT_USER
                                   ,@CURRENT_DATETIME
                                   ,@CURRENT_USER)";
        string strUpdate = @"UPDATE EDI_CANDIDATE
                               SET USED_FLG = @USED_FLG,
                                   UPDATED_AT = @CURRENT_DATETIME,
                                   UPDATED_BY = @CURRENT_USER
                             WHERE EDI_ACCOUNT = @EDI_ACCOUNT";
        #endregion

        #region Constructors

        public EDI_CANDIDATE(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region GetCandicates
        public DataTable GetCandicates(out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetCandicates);
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region ExtractEDIAutoInfo
        public DataTable ExtractEDIAutoInfo(string COMPANY_NO_BOX, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strExtractEDIAutoInfo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetUsageFLG
        public DataTable GetUseFLG(string EDI_ACCOUNT, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetUseFLG);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", EDI_ACCOUNT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Insert
        public void Insert(BOL_EDI_CANDIDATE oEDI_CANDIDATE, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_CANDIDATE.EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@USED_FLG", oEDI_CANDIDATE.USED_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.ExcuteQuery(6, out strMsg);
        }
        #endregion

        #region Update
        public void Update(BOL_EDI_CANDIDATE oEDI_CANDIDATE, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EDI_ACCOUNT", oEDI_CANDIDATE.EDI_ACCOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@USED_FLG", oEDI_CANDIDATE.USED_FLG));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

    }
    #endregion

}
