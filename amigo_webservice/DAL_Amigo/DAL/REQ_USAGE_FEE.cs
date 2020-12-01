using DAL_AmigoProcess.BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class REQ_USAGE_FEE
    {
        #region ConnectionSetUp
        public string strConnectionString;
        string strMessage;

        String strGetPopupData = @"SELECT 
                                    ROW_NUMBER() OVER(ORDER BY DISPLAY_ORDER) No,
                                    CONTRACT_CODE,
                                    CONTRACT_NAME,
                                    SUM(INITIAL_UNIT_PRICE) AS INITIAL_UNIT_PRICE,
                                    SUM(INITIAL_QUANTITY) AS INITIAL_QUANTITY,
                                    SUM(INITIAL_AMOUNT) AS INITIAL_AMOUNT,
                                    SUM(MONTHLY_UNIT_PRICE) AS MONTHLY_UNIT_PRICE,
                                    SUM(MONTHLY_QUANTITY) AS MONTHLY_QUANTITY,
                                    SUM(MONTHLY_AMOUNT) AS MONTHLY_AMOUNT,
                                    SUM(YEAR_UNIT_PRICE) AS YEAR_UNIT_PRICE,
                                    SUM(YEAR_QUANTITY) AS YEAR_QUANTITY,
                                    SUM(YEAR_AMOUNT) AS YEAR_AMOUNT
                                    FROM
                                    (SELECT USAGE_FEE_MASTER.DISPLAY_ORDER,
                                    REQ_USAGE_FEE.CONTRACT_CODE,
                                    CONTRACT_NAME,
                                    (CASE TYPE WHEN 1 THEN UNIT_PRICE ELSE 0 END) INITIAL_UNIT_PRICE,
                                    (CASE TYPE WHEN 1 THEN QUANTITY ELSE 0 END) INITIAL_QUANTITY,
                                    (CASE TYPE WHEN 1 THEN AMOUNT ELSE 0 END) INITIAL_AMOUNT,
                                    (CASE TYPE WHEN 2 THEN UNIT_PRICE ELSE 0 END) MONTHLY_UNIT_PRICE,
                                    (CASE TYPE WHEN 2 THEN QUANTITY ELSE 0 END) MONTHLY_QUANTITY,
                                    (CASE TYPE WHEN 2 THEN AMOUNT ELSE 0 END) MONTHLY_AMOUNT,
                                    (CASE TYPE WHEN 3 THEN UNIT_PRICE ELSE 0 END) YEAR_UNIT_PRICE,
                                    (CASE TYPE WHEN 3 THEN QUANTITY ELSE 0 END) YEAR_QUANTITY,
                                    (CASE TYPE WHEN 3 THEN AMOUNT ELSE 0 END) YEAR_AMOUNT
                                    FROM REQ_USAGE_FEE , (SELECT CONTRACT_CODE,
                                    DISPLAY_ORDER,
                                    ROW_NUMBER() OVER(PARTITION BY CONTRACT_CODE ORDER BY CONTRACT_CODE, ADOPTION_DATE DESC) num
                                    FROM USAGE_FEE_MASTER
                                    WHERE ADOPTION_DATE <= GETDATE()) AS USAGE_FEE_MASTER
                                    WHERE REQ_USAGE_FEE.CONTRACT_CODE = USAGE_FEE_MASTER.CONTRACT_CODE
                                    AND num=1
                                    AND COMPANY_NO_BOX = @COMPANY_NO_BOX
                                    AND REQ_SEQ = @REQ_SEQ) AS TBL
                                    GROUP BY CONTRACT_CODE,CONTRACT_NAME,DISPLAY_ORDER";

        string strUpdate = @"UPDATE [REQ_USAGE_FEE]
                               SET [UNIT_PRICE] = @UNIT_PRICE
                                  ,[AMOUNT] = @AMOUNT
                                  ,[UPDATED_AT] = @UPDATED_AT
                                  ,[UPDATED_BY] = @UPDATED_BY
                             WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX 
                             AND REQ_SEQ = @REQ_SEQ
                             AND CONTRACT_CODE = @CONTRACT_CODE
                             AND TYPE = @TYPE";

        string strGetUpdatedat = @"SELECT UPDATED_AT FROM [REQ_USAGE_FEE] 
                                    WHERE COMPANY_NO_BOX = @COMPANY_NO_BOX 
                                    AND REQ_SEQ = @REQ_SEQ
                                    AND CONTRACT_CODE = @CONTRACT_CODE
                                    AND TYPE = @TYPE
                                    AND UPDATED_AT < @FILE_CREATED";
        #endregion

        #region Constructors
        public REQ_USAGE_FEE(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region getPopupScreenData
        public DataTable getPopUpScreenData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPopupData);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            //date = DateTime.Now.ToString("yyyy-mm-dd");
            //oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE",date));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion

        #region Update
        public void Update(BOL_REQ_USAGE_FEE oREQ_USAGE_FEE, out string strMessage)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UNIT_PRICE", oREQ_USAGE_FEE.UNIT_PRICE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AMOUNT", oREQ_USAGE_FEE.AMOUNT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oREQ_USAGE_FEE.UPDATED_AT));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_BY", oREQ_USAGE_FEE.UPDATED_BY));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQ_USAGE_FEE.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQ_USAGE_FEE.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oREQ_USAGE_FEE.CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", oREQ_USAGE_FEE.TYPE));
            oMaster.ExcuteQuery(6, out strMessage);
        }
        #endregion

        #region CanUpdate
        public bool CanUpdate(BOL_REQ_USAGE_FEE oREQ_USAGE_FEE, string FILE_CREATED, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetUpdatedat);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", oREQ_USAGE_FEE.COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", oREQ_USAGE_FEE.REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oREQ_USAGE_FEE.CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", oREQ_USAGE_FEE.TYPE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FILE_CREATED", FILE_CREATED));
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
    }
}
