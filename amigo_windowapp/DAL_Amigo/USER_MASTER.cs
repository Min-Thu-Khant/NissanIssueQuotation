using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace DAL_AmigoProcess
{
    #region USER MASTER
    public class USER_MASTER
    {
        #region private

        private string _ID;
        private string _PASS;
        #endregion

        #region Encapsulation

        public string ID { get { return _ID; } set { _ID = value; } }
        public string PASS { get { return _PASS; } set { _PASS = value; } }

        #endregion

        #region ConnectionSetUp

        public string strConnectionString;
        string strMessage;
        string strInsert = @"Insert into USER_MASTER (ID,PASS)VALUES(@ID,@PASS)";

        #endregion

        #region Constructors

        public USER_MASTER(string con)
        {

            _ID = "";
            _PASS = "";
            strConnectionString = con;
            strMessage = "";
        }

        #endregion

        #region insert

        public void insert(out string strMessage)
        {
            int intRtn = 0;
            strMessage = "";
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strInsert);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@ID", _ID));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@PASS", _PASS));

            //_M01 = oMaster.intRtnID;
            //  return intRtn;
        }

        #endregion

    }
    #endregion
}
