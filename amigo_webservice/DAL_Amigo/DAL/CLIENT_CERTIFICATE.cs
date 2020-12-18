using DAL_AmigoProcess;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class CLIENT_CERTIFICATE
    {
        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;

        string strClientCertificateList = @"SELECT
	                                        ROW_NUMBER() OVER(ORDER BY A.FY ASC, A.CLIENT_CERTIFICATE_NO ASC) AS No,
                                            ' ' as CK,
                                            '' as MK,
                                            A.FY
                                            , A.CLIENT_CERTIFICATE_NO
                                            , A.PASSWORD
                                            , FORMAT(A.EXPIRATION_DATE, 'yyyy/MM/dd HH:mm') AS EXPIRATION_DATE
                                            , A.COMPANY_NO_BOX
                                            , B.COMPANY_NAME
                                            , B.CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS
                                            , FORMAT(A.DISTRIBUTION_DATE, 'yyyy/MM/dd HH:mm') AS DISTRIBUTION_DATE
                                            , A.UPDATED_AT
                                            , A.UPDATED_BY
	                                        , '' AS UPDATE_MESSAGE,
                                            ROW_NUMBER() OVER(ORDER BY A.COMPANY_NO_BOX  ASC) AS ROW_ID,
                                            UPDATED_AT AS UPDATED_AT_RAW,
                                            '' AS MK_ORIGIN
                                            FROM
                                            CLIENT_CERTIFICATE AS A 
                                            LEFT JOIN ( 
                                            SELECT
                                            T1.COMPANY_NO_BOX
                                            , T1.COMPANY_NAME
                                            , T1.CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS
                                            FROM
                                            REQUEST_DETAIL T1 
                                            INNER JOIN ( 
                                                        SELECT COMPANY_NO_BOX
                                                        , MAX(REQ_SEQ) as REQ_SEQ 
                                                        FROM REQUEST_DETAIL 
                                                        GROUP BY COMPANY_NO_BOX
                                                        ) T2 
                                            ON T1.COMPANY_NO_BOX = T2.COMPANY_NO_BOX 
                                            AND T1.REQ_SEQ = T2.REQ_SEQ 
                                            WHERE REQ_STATUS = 2 ) B 
                                            ON B.COMPANY_NO_BOX = A.COMPANY_NO_BOX 
		                                    WHERE ISNULL(A.FY,'') LIKE '%' + @FY + '%'
                                            AND ISNULL(A.COMPANY_NO_BOX,'') LIKE '%' + @COMPANY_NO_BOX + '%'
                                            AND ISNULL(A.CLIENT_CERTIFICATE_NO,'') LIKE '%' + @CLIENT_CERTIFICATE_NO + '%'
                                            @DISTRIBUTION_DATE
                                            ORDER BY A.FY ASC, A.CLIENT_CERTIFICATE_NO ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";

        string strClientCertificateListTotal = @"SELECT
	                                            COUNT(A.CLIENT_CERTIFICATE_NO)
                                                FROM
                                                CLIENT_CERTIFICATE AS A 
                                                LEFT JOIN ( 
                                                SELECT
                                                    T1.COMPANY_NO_BOX
                                                    , T1.COMPANY_NAME
                                                    , T1.CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS 
                                                from
                                                REQUEST_DETAIL T1 
                                                INNER JOIN ( 
                                                            SELECT
                                                            COMPANY_NO_BOX
                                                            , MAX(REQ_SEQ) as REQ_SEQ 
                                                            FROM
                                                            REQUEST_DETAIL 
                                                            GROUP BY
                                                            COMPANY_NO_BOX
                                                            ) T2 
                                                ON T1.COMPANY_NO_BOX = T2.COMPANY_NO_BOX 
                                                AND T1.REQ_SEQ = T2.REQ_SEQ 
                                                WHERE
                                                REQ_STATUS = 2
                                                ) B 
                                                ON B.COMPANY_NO_BOX = A.COMPANY_NO_BOX 
		                                        WHERE ISNULL(A.FY,'') LIKE '%' + @FY + '%'
                                                AND ISNULL(A.COMPANY_NO_BOX,'') LIKE '%' + @COMPANY_NO_BOX + '%'
                                                AND ISNULL(A.CLIENT_CERTIFICATE_NO,'') LIKE '%' + @CLIENT_CERTIFICATE_NO + '%'
                                                @DISTRIBUTION_DATE";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT(CLIENT_CERTIFICATE_NO) AS COUNT
                                                FROM CLIENT_CERTIFICATE 
                                                WHERE CLIENT_CERTIFICATE_NO = @CLIENT_CERTIFICATE_NO
                                                AND UPDATED_AT @UPDATED_AT";

        string strPKKeyCheck = @"SELECT COUNT(CLIENT_CERTIFICATE_NO) AS COUNT
                                                FROM CLIENT_CERTIFICATE
                                                WHERE CLIENT_CERTIFICATE_NO = @CLIENT_CERTIFICATE_NO";

        string strDelete = @"DELETE FROM CLIENT_CERTIFICATE 
                             WHERE CLIENT_CERTIFICATE_NO = @CLIENT_CERTIFICATE_NO AND UPDATED_AT @UPDATED_AT";

        string strInsert = @"INSERT INTO [CLIENT_CERTIFICATE]
                           ([FY]
                           ,[CLIENT_CERTIFICATE_NO]
                           ,[PASSWORD]
                           ,[EXPIRATION_DATE]
                           ,[COMPANY_NO_BOX]
                           ,[DISTRIBUTION_DATE]
                           ,[CREATED_AT]
                           ,[CREATED_BY]
                           ,[UPDATED_AT]
                           ,[UPDATED_BY])
                     VALUES
                           (@FY,
                            @CLIENT_CERTIFICATE_NO,
                            @PASSWORD,
                            @EXPIRATION_DATE,
                            @COMPANY_NO_BOX,
                            @DISTRIBUTION_DATE,
                            @CURRENT_DATETIME,
                            @CURRENT_USER, 
                            @CURRENT_DATETIME,
                            @CURRENT_USER )";

        string strUpdate = @"UPDATE [CLIENT_CERTIFICATE]
                               SET [PASSWORD] = @PASSWORD,
                                   [EXPIRATION_DATE] = @EXPIRATION_DATE,
                                   [COMPANY_NO_BOX] = @COMPANY_NO_BOX,
                                   [UPDATED_AT] = @CURRENT_DATETIME,
                                   [UPDATED_BY] = @CURRENT_USER
                             WHERE [CLIENT_CERTIFICATE_NO] = @CLIENT_CERTIFICATE_NO
                             AND [UPDATED_AT] @UPDATED_AT";

        string strEmailButtonUpdate = @"UPDATE [CLIENT_CERTIFICATE]
                                        SET [DISTRIBUTION_DATE] = @DISTRIBUTION_DATE,
                                        [UPDATED_AT] = @CURRENT_DATETIME,
                                        [UPDATED_BY] = @CURRENT_USER
                                        WHERE [CLIENT_CERTIFICATE_NO] = @CLIENT_CERTIFICATE_NO
                                        AND [UPDATED_AT] @UPDATED_AT";

        string strGetClientCertificateNo = @"SELECT TOP 1 CLIENT_CERTIFICATE_NO
                                                FROM CLIENT_CERTIFICATE
                                                WHERE ISNULL(COMPANY_NO_BOX,'') = ''
                                                AND FY = @FY
                                                ORDER BY CLIENT_CERTIFICATE_NO ASC";

        string strUpdateWithClientCertificateNO = @"UPDATE [CLIENT_CERTIFICATE]
                                                    SET [COMPANY_NO_BOX] = @COMPANY_NO_BOX,
                                                    [UPDATED_AT] = @UPDATED_AT,
                                                    [UPDATED_BY] = @UPDATED_BY
                                                    WHERE [CLIENT_CERTIFICATE_NO] = @CLIENT_CERTIFICATE_NO";
        #endregion

        #region Constructors

        public CLIENT_CERTIFICATE(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region GetClientCertificateList
        public System.Data.DataTable GetClientCertrificateList(string FY, string COMPANY_NO_BOX, string CLIENT_CERTIFICATE_NO, string DISTRIBUTION_STATUS, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            if (DISTRIBUTION_STATUS != null)
            {
                if (DISTRIBUTION_STATUS == "全て")
                {
                    strClientCertificateList = strClientCertificateList.Replace("@DISTRIBUTION_DATE", " ");
                    strClientCertificateListTotal = strClientCertificateListTotal.Replace("@DISTRIBUTION_DATE", "");
                }
                if (DISTRIBUTION_STATUS == "未送信")
                {
                    strClientCertificateList = strClientCertificateList.Replace("@DISTRIBUTION_DATE", "AND A.DISTRIBUTION_DATE IS NUll");
                    strClientCertificateListTotal = strClientCertificateListTotal.Replace("@DISTRIBUTION_DATE", "AND A.DISTRIBUTION_DATE IS NUll");
                }
                if (DISTRIBUTION_STATUS == "送信済")
                {
                    strClientCertificateList = strClientCertificateList.Replace("@DISTRIBUTION_DATE", "AND A.DISTRIBUTION_DATE IS NOT NUll");
                    strClientCertificateListTotal = strClientCertificateListTotal.Replace("@DISTRIBUTION_DATE", "AND A.DISTRIBUTION_DATE IS NOT NUll");
                }
            }


            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strClientCertificateListTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FY", FY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", CLIENT_CERTIFICATE_NO));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            oMaster = new ConnectionMaster(strConnectionString, strClientCertificateList);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FY", FY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, out string strMsg)
        {
            strSearchWithKeyAndUpdated_at = StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW);


            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW != null ? oCLIENT_CERTIFICATE.UPDATED_AT_RAW : (object)DBNull.Value));

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

            if (count <= 0) //check 
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region PKKeyCheck
        public bool PKKeyCheck(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, out string strMsg)
        {

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strPKKeyCheck);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
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

            if (count > 0) //check 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Insert
        public void Insert(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FY", oCLIENT_CERTIFICATE.FY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD", oCLIENT_CERTIFICATE.PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EXPIRATION_DATE", oCLIENT_CERTIFICATE.EXPIRATION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCLIENT_CERTIFICATE.COMPANY_NO_BOX != null ? oCLIENT_CERTIFICATE.COMPANY_NO_BOX : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISTRIBUTION_DATE", oCLIENT_CERTIFICATE.DISTRIBUTION_DATE != null ? oCLIENT_CERTIFICATE.DISTRIBUTION_DATE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion

        #region Update
        public void Update(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            strUpdate = StringUtil.handleNullStringDate(strUpdate, "@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASSWORD", oCLIENT_CERTIFICATE.PASSWORD));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@EXPIRATION_DATE", oCLIENT_CERTIFICATE.EXPIRATION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oCLIENT_CERTIFICATE.COMPANY_NO_BOX != null ? oCLIENT_CERTIFICATE.COMPANY_NO_BOX : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW != null ? oCLIENT_CERTIFICATE.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region Delete
        public void Delete(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE, out String strMsg)
        {
            strDelete = StringUtil.handleNullStringDate(strDelete, "@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDelete);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW != null ? oCLIENT_CERTIFICATE.UPDATED_AT_RAW : (object)DBNull.Value));

            oMaster.ExcuteQuery(3, out strMsg);
        }
        #endregion

        #region Email Button Update
        public void EmailButtonUpdate(BOL_CLIENT_CERTIFICATE oCLIENT_CERTIFICATE,string UPDATED_AT_DATETIME, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            strEmailButtonUpdate = StringUtil.handleNullStringDate(strEmailButtonUpdate, "@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strEmailButtonUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISTRIBUTION_DATE", UPDATED_AT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", oCLIENT_CERTIFICATE.CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oCLIENT_CERTIFICATE.UPDATED_AT_RAW != null ? oCLIENT_CERTIFICATE.UPDATED_AT_RAW : (object)DBNull.Value));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region RegisterCompleteNotificationScreen
        public string GetClientCertificateNo(string FY, out string strMsg)
        {

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetClientCertificateNo);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FY", FY));

            oMaster.ExcuteQuery(4, out strMsg);

            string certificateNo;
            try
            {
                certificateNo = oMaster.dtExcuted.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                certificateNo = null;
            }
            return certificateNo;
        }
        #endregion

        #region UpdateWithClientCertificateNo
        public void UpdateWithClientCertificateNO(string CLIENT_CERTIFICATE_NO, string COMPANY_NO_BOX, string LOGIN_ID, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateWithClientCertificateNO); 
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CLIENT_CERTIFICATE_NO", CLIENT_CERTIFICATE_NO));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", (DateTime.Now).ToString("yyyyMMddHHmmss")));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", LOGIN_ID));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion
    }
}
