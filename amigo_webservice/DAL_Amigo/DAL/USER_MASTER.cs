using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL_AmigoProcess.BOL;

namespace DAL_AmigoProcess.DAL
{
    #region USER MASTER
    public class USER_MASTER
    {        

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into USER_MASTER (ID,PASS)VALUES(@ID,@PASS)";
        string strCheckLogIN = @"SELECT * FROM USER_MASTER WHERE ID = @ID and PASS = @PASS";
        #endregion

        #region Constructors

        public USER_MASTER(string con)
        {           
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region insert

        public void insert(BOL_USER_MASTER B_User, out string strMessage)
        {
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ID", B_User.ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASS", B_User.PASS));

            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

        #region CheckLogIn
        public DataTable CheckLogIn(string UserName, string PASS)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strCheckLogIN);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ID", UserName));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASS", PASS));
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion
    }
    #endregion    
}
