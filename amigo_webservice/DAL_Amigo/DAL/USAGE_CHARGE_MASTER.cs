
using DAL_AmigoProcess;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class USAGE_CHARGE_MASTER
    {
        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;

        string strUsageFeeMaster = @"SELECT ROW_NUMBER() OVER(ORDER BY DISPLAY_ORDER ASC) AS No,
                                        ' ' as CK,
                                        '' as MK,
                                        (CASE FEE_STRUCTURE 
                                        WHEN 'BASIC' THEN N'基本契約' 
                                        WHEN 'OPTION' THEN N'オプション' 
                                        WHEN 'SD' THEN N'サービスデスク' 
                                        END) FEE_STRUCTURE,
                                        CONTRACT_CODE,
                                        CONTRACT_NAME,
                                        CONVERT(VARCHAR,CONTRACT_QTY) CONTRACT_QTY,
                                        CONTRACT_UNIT,
                                        FORMAT(ADOPTION_DATE, 'yyyy/MM/dd') AS ADOPTION_DATE,
                                        INITIAL_COST,
                                        CONVERT(int,MONTHLY_COST) MONTHLY_COST,
                                        (CASE INPUT_TYPE 
                                        WHEN '1' THEN N'選択' 
                                        WHEN '2' THEN N'数量' 
                                        END) INPUT_TYPE,
                                        CONVERT(VARCHAR,NUMBER_DEFAULT) NUMBER_DEFAULT,
                                        MEMO,   
                                        CONVERT(VARCHAR,DISPLAY_ORDER) DISPLAY_ORDER,
                                        UPDATED_AT,
                                        UPDATED_BY,
                                        '' AS UPDATE_MESSAGE,
                                        ROW_NUMBER() OVER(ORDER BY CONTRACT_CODE ASC) AS ROW_ID,
                                        UPDATED_AT AS UPDATED_AT_RAW
                                        from USAGE_FEE_MASTER 
                                        WHERE CONTRACT_CODE LIKE '%' + @CONTRACT_CODE + '%'
                                           AND CONTRACT_NAME LIKE '%' + @CONTRACT_NAME + '%'
                                        ORDER BY No,DISPLAY_ORDER ASC OFFSET @OFFSET ROWS FETCH NEXT @LIMIT ROWS ONLY";


        string strUsageFeeMasterTotal = @"SELECT COUNT(CONTRACT_CODE) 
                                           FROM USAGE_FEE_MASTER
                                           WHERE CONTRACT_CODE LIKE '%' + @CONTRACT_CODE + '%'
                                           AND CONTRACT_NAME LIKE '%' + @CONTRACT_NAME + '%'";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT(CONTRACT_CODE) AS COUNT
                                                FROM USAGE_FEE_MASTER
                                                WHERE CONTRACT_CODE = @CONTRACT_CODE AND FORMAT(ADOPTION_DATE,'yyyy/MM/dd') =FORMAT(@ADOPTION_DATE, 'yyyy/MM/dd')
                                                AND UPDATED_AT @UPDATED_AT";

        string strPKKeyCheck = @"SELECT COUNT(CONTRACT_CODE) AS COUNT
                                                FROM USAGE_FEE_MASTER
                                                WHERE CONTRACT_CODE = @CONTRACT_CODE AND ADOPTION_DATE =@ADOPTION_DATE";


        string strDelete = @"DELETE FROM USAGE_FEE_MASTER 
                             WHERE CONTRACT_CODE = @CONTRACT_CODE AND ADOPTION_DATE=@ADOPTION_DATE AND UPDATED_AT = '@UPDATED_AT' ";

        string strInsert = @"INSERT INTO [USAGE_FEE_MASTER]
                           ([FEE_STRUCTURE]
                           ,[CONTRACT_CODE]
                           ,[ADOPTION_DATE]
                           ,[CONTRACT_NAME]
                           ,[CONTRACT_QTY]
                           ,[CONTRACT_UNIT]
                           ,[INITIAL_COST]
                           ,[MONTHLY_COST]
                           ,[INPUT_TYPE]
                           ,[NUMBER_DEFAULT]
                           ,[MEMO]
                           ,[DISPLAY_ORDER]
                           ,[CREATED_AT]
                           ,[CREATED_BY]
                           ,[UPDATED_AT]
                           ,[UPDATED_BY])
                     VALUES
                           (@FEE_STRUCTURE,
                            @CONTRACT_CODE,
                            @ADOPTION_DATE,
                            @CONTRACT_NAME,
                            @CONTRACT_QTY,
                            @CONTRACT_UNIT,
                            @INITIAL_COST,
                            @MONTHLY_COST,
                            @INPUT_TYPE,
                            @NUMBER_DEFAULT, 
                            @MEMO,
                            @DISPLAY_ORDER,
                            @CURRENT_DATETIME,
                            @CURRENT_USER,
                            @CURRENT_DATETIME,
                            @CURRENT_USER)";

        string strUpdate = @"UPDATE [USAGE_FEE_MASTER]
                               SET [FEE_STRUCTURE] = @FEE_STRUCTURE,
                                   [CONTRACT_NAME] = @CONTRACT_NAME,
                                   [CONTRACT_QTY]= @CONTRACT_QTY,
                                   [CONTRACT_UNIT] = @CONTRACT_UNIT,
                                   [INITIAL_COST]=@INITIAL_COST,
                                   [MONTHLY_COST]=@MONTHLY_COST,
                                   [INPUT_TYPE]=@INPUT_TYPE,
                                   [NUMBER_DEFAULT]=@NUMBER_DEFAULT,
                                   [MEMO]=@MEMO,
                                   [DISPLAY_ORDER]=@DISPLAY_ORDER,
                                   [UPDATED_AT]= @CURRENT_DATETIME,
                                   [UPDATED_BY]=@CURRENT_USER
                             WHERE [CONTRACT_CODE] = @CONTRACT_CODE
                             AND [ADOPTION_DATE] = @ADOPTION_DATE
                             AND [UPDATED_AT] @UPDATED_AT";

        #endregion

        #region Constructors

        public USAGE_CHARGE_MASTER(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region GetUsageFeeMasterList
        public DataTable GetUsageFeeMasterList(string CONTRACT_CODE, string CONTRACT_NAME, int OFFSET, int LIMIT, out string strMsg, out int total)
        {
            //total
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUsageFeeMasterTotal);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_NAME", CONTRACT_NAME));
            oMaster.ExcuteQuery(4, out strMsg);
            total = int.Parse(oMaster.dtExcuted.Rows[0][0].ToString());

            //result
            oMaster = new ConnectionMaster(strConnectionString, strUsageFeeMaster);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_NAME", CONTRACT_NAME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@OFFSET", OFFSET));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@LIMIT", LIMIT));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER, out string strMsg)
        {
            strSearchWithKeyAndUpdated_at = StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oUSAGE_FEE_MASTER.UPDATED_AT_RAW);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oUSAGE_FEE_MASTER.CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE", oUSAGE_FEE_MASTER.ADOPTION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oUSAGE_FEE_MASTER.UPDATED_AT_RAW != null ? oUSAGE_FEE_MASTER.UPDATED_AT_RAW : (object)DBNull.Value));
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
        public bool PKKeyCheck(BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER, out string strMsg)
        {

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strPKKeyCheck);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oUSAGE_FEE_MASTER.CONTRACT_CODE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE", oUSAGE_FEE_MASTER.ADOPTION_DATE));
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
        public void Insert(BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FEE_STRUCTURE", oUSAGE_FEE_MASTER.FEE_STRUCTURE != null ? oUSAGE_FEE_MASTER.FEE_STRUCTURE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oUSAGE_FEE_MASTER.CONTRACT_CODE.Trim()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE", oUSAGE_FEE_MASTER.ADOPTION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_NAME", oUSAGE_FEE_MASTER.CONTRACT_NAME != null ? oUSAGE_FEE_MASTER.CONTRACT_NAME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_QTY", oUSAGE_FEE_MASTER.CONTRACT_QTY != null ? oUSAGE_FEE_MASTER.CONTRACT_QTY : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_UNIT", oUSAGE_FEE_MASTER.CONTRACT_UNIT != null ? oUSAGE_FEE_MASTER.CONTRACT_UNIT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@INITIAL_COST", oUSAGE_FEE_MASTER.INITIAL_COST != null ? oUSAGE_FEE_MASTER.INITIAL_COST : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MONTHLY_COST", oUSAGE_FEE_MASTER.MONTHLY_COST != null ? oUSAGE_FEE_MASTER.MONTHLY_COST : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@INPUT_TYPE", oUSAGE_FEE_MASTER.INPUT_TYPE != null ? oUSAGE_FEE_MASTER.INPUT_TYPE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NUMBER_DEFAULT", oUSAGE_FEE_MASTER.NUMBER_DEFAULT != null ? oUSAGE_FEE_MASTER.NUMBER_DEFAULT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MEMO", oUSAGE_FEE_MASTER.MEMO != null ? oUSAGE_FEE_MASTER.MEMO : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISPLAY_ORDER", oUSAGE_FEE_MASTER.DISPLAY_ORDER != null ? oUSAGE_FEE_MASTER.DISPLAY_ORDER : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.ExcuteQuery(1, out strMsg);
        }
        #endregion

        #region Update
        public void Update(BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            strUpdate = StringUtil.handleNullStringDate(strUpdate, "@UPDATED_AT", oUSAGE_FEE_MASTER.UPDATED_AT_RAW.ToString().Trim());


            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdate);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@FEE_STRUCTURE", oUSAGE_FEE_MASTER.FEE_STRUCTURE != null ? oUSAGE_FEE_MASTER.FEE_STRUCTURE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_NAME", oUSAGE_FEE_MASTER.CONTRACT_NAME != null ? oUSAGE_FEE_MASTER.CONTRACT_NAME : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_QTY", oUSAGE_FEE_MASTER.CONTRACT_QTY != null ? oUSAGE_FEE_MASTER.CONTRACT_QTY : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_UNIT", oUSAGE_FEE_MASTER.CONTRACT_UNIT != null ? oUSAGE_FEE_MASTER.CONTRACT_UNIT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@INITIAL_COST", oUSAGE_FEE_MASTER.INITIAL_COST != null ? oUSAGE_FEE_MASTER.INITIAL_COST : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MONTHLY_COST", oUSAGE_FEE_MASTER.MONTHLY_COST != null ? oUSAGE_FEE_MASTER.MONTHLY_COST : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@INPUT_TYPE", oUSAGE_FEE_MASTER.INPUT_TYPE != null ? oUSAGE_FEE_MASTER.INPUT_TYPE : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@NUMBER_DEFAULT", oUSAGE_FEE_MASTER.NUMBER_DEFAULT != null ? oUSAGE_FEE_MASTER.NUMBER_DEFAULT : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@MEMO", oUSAGE_FEE_MASTER.MEMO != null ? oUSAGE_FEE_MASTER.MEMO : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@DISPLAY_ORDER", oUSAGE_FEE_MASTER.DISPLAY_ORDER != null ? oUSAGE_FEE_MASTER.DISPLAY_ORDER : (object)DBNull.Value));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oUSAGE_FEE_MASTER.CONTRACT_CODE.Trim()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE", oUSAGE_FEE_MASTER.ADOPTION_DATE));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oUSAGE_FEE_MASTER.UPDATED_AT_RAW != null ? oUSAGE_FEE_MASTER.UPDATED_AT_RAW : (object)DBNull.Value));

            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion

        #region Delete
        public void Delete(BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER, out String strMsg)
        {
            if (oUSAGE_FEE_MASTER.UPDATED_AT_RAW != null)
            {
                strDelete = strDelete.Replace("@UPDATED_AT", oUSAGE_FEE_MASTER.UPDATED_AT_RAW.ToString().Trim());
            }
            else
            {
                strDelete = strDelete.Replace("=@UPDATED_AT", "IS NULL");
            }

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strDelete);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CONTRACT_CODE", oUSAGE_FEE_MASTER.CONTRACT_CODE.Trim()));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ADOPTION_DATE", oUSAGE_FEE_MASTER.ADOPTION_DATE));
            oMaster.ExcuteQuery(3, out strMsg);
        }
        #endregion
    }
}
