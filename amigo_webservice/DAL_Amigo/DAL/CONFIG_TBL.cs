using System.Data.SqlClient;
using System.Data;

namespace DAL_AmigoProcess.DAL
{
    #region CONFIG_TBL
    public class CONFIG_TBL
    {        
        #region ConnectionSetUp

        public string strConnectionString;

        string strGetConfigByProgramID = "SELECT* FROM CONFIG_TBL WHERE PROGRAM_ID = @PROGRAM_ID";        
        #endregion

        #region Constructors

        public CONFIG_TBL(string con)
        {            
            strConnectionString = con;
        }

        #endregion

        #region GetConfigByProgramID
        public DataTable GetConfigByProgramID(string PROGRAM_ID, out string strMsg)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetConfigByProgramID);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PROGRAM_ID", PROGRAM_ID));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion


    }
    #endregion

}
