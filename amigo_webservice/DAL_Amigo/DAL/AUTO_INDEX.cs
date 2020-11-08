using System;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region AUTO_INDEX
    public class AUTO_INDEX
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strGetAutoIndex = @"SELECT [AUTO_INDEX_ID]
                                        ,[AUTO_INDEX]
                                        ,[CREATED_AT]
                                        ,[CREATED_BY]
                                        ,[UPDATED_AT]
                                        ,[UPDATED_BY]
                                    FROM [AUTO_INDEX]
                                   WHERE [AUTO_INDEX_ID] = @AUTO_INDEX_ID";

        string strUpdateIndex = @"UPDATE [AUTO_INDEX]
                                   SET [AUTO_INDEX] = @AUTO_INDEX,
                                       [UPDATED_AT] = @CURRENT_DATETIME,
                                       [UPDATED_BY] = @CURRENT_USER
                                  WHERE [AUTO_INDEX_ID] = @AUTO_INDEX_ID
                                  AND [UPDATED_AT] @UPDATED_AT";

        string strSearchWithKeyAndUpdated_at = @"SELECT COUNT([AUTO_INDEX_ID]) AS COUNT
                                                FROM [AUTO_INDEX]
                                                WHERE [AUTO_INDEX_ID] = @AUTO_INDEX_ID
                                                AND UPDATED_AT @UPDATED_AT";
        #endregion

        #region Constructors

        public AUTO_INDEX(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region GetAutoIndex
        public DataTable GetByAutoIndexID(string AUTO_INDEX_ID, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetAutoIndex);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX_ID", AUTO_INDEX_ID));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region IsAlreadyUpdated
        public bool IsAlreadyUpdated(BOL_AUTO_INDEX oAUTO_INDEX, out string strMsg)
        {
            //handle Null value at where conditions
            strSearchWithKeyAndUpdated_at = Utility.StringUtil.handleNullStringDate(strSearchWithKeyAndUpdated_at, "@UPDATED_AT", oAUTO_INDEX.UPDATED_AT);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strSearchWithKeyAndUpdated_at);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX_ID", oAUTO_INDEX.AUTO_INDEX_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oAUTO_INDEX.UPDATED_AT != null ? oAUTO_INDEX.UPDATED_AT : (object)DBNull.Value));
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

            if (count <=0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion


        #region Update
        public void Update(BOL_AUTO_INDEX oAUTO_INDEX, string CURRENT_DATETIME, string CURRENT_USER, out String strMsg)
        {
            //handle Null value at where conditions
            strUpdateIndex = Utility.StringUtil.handleNullStringDate(strUpdateIndex, "@UPDATED_AT", oAUTO_INDEX.UPDATED_AT);

            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strUpdateIndex);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX_ID", oAUTO_INDEX.AUTO_INDEX_ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@AUTO_INDEX", oAUTO_INDEX.AUTO_INDEX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_DATETIME", CURRENT_DATETIME));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@CURRENT_USER", CURRENT_USER));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@UPDATED_AT", oAUTO_INDEX.UPDATED_AT != null ? oAUTO_INDEX.UPDATED_AT : (object)DBNull.Value));
            oMaster.ExcuteQuery(2, out strMsg);
        }
        #endregion
    }
    #endregion

}
