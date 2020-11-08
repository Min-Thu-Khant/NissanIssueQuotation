using System.Data;
using System.Data.SqlClient;

namespace DAL_AmigoProcess
{
    public class ConnectionMaster
    {
        /*
         * Command Type
         * 1 :: Insert
         * 2 :: Update
         * 3 :: Delete
         * 4 :: Retrieve
         */

        public SqlConnection objConnection;
        public string strConnectionString;
        public string strCommand;
        public DataTable dtExcuted;
        public int intRtnID;
        public SqlCommand crudCommand;

        #region ConnectionMaster
        public ConnectionMaster(string strConnection, string strParaCommand)
        {
            objConnection = new SqlConnection(strConnection);
            strConnectionString = strConnection;
            dtExcuted = new DataTable();
            intRtnID = 0;
            crudCommand = new SqlCommand();            
            crudCommand.CommandText = strParaCommand;
            crudCommand.Connection = objConnection;
        }
        #endregion

        #region ExecuteQuery
        public void ExcuteQuery(int CommandType, out string strMessage)
        {
            strMessage = "";
            if (CommandType == 4)
            {
                retrive(out strMessage);
            }
            else if (CommandType == 5)
            {
                retriveStoredProcedure(out strMessage);
            }
            else
            {
                switch (CommandType)
                {
                    case 1:
                        executeScalar(out strMessage);
                        break;
                    case 2:
                        executeNonQuery(out strMessage);
                        break;
                    case 3:
                        executeNonQuery(out strMessage);
                        break;
                   
                }
            }
        }
        #endregion

        #region executeNoneQuery
        protected void executeNonQuery(out string strMessage)
        {
            strMessage = "";
            try
            {
                crudCommand.Connection.Open();
                crudCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                crudCommand.Connection.Close();
            }
        }
        #endregion

        #region executeScalar
        protected void executeScalar(out string strMessage)
        {
            strMessage = "";
            try
            {
                crudCommand.CommandText = crudCommand.CommandText + ";SELECT SCOPE_IDENTITY();";
                crudCommand.Connection.Open();

                intRtnID = int.Parse(crudCommand.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                crudCommand.Connection.Close();
            }
        }
        #endregion

        #region retrive
        protected void retrive(out string strMessage)
        {
            dtExcuted = new DataTable();
            SqlDataAdapter oadpt = new SqlDataAdapter(crudCommand);
            try
            {
                crudCommand.Connection.Open();
                oadpt.Fill(dtExcuted);
                strMessage = "";
            }
            catch (SqlException ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                crudCommand.Connection.Close();
            }

        }
        #endregion 
     
        #region retriveStoredProcedure
        protected void retriveStoredProcedure(out string strMessage)
        {
            dtExcuted = new DataTable();
            //SqlDataAdapter oadpt = new SqlDataAdapter(crudCommand);
            SqlDataAdapter oadpt = new SqlDataAdapter(crudCommand);
            try
            {
                crudCommand.Connection.Open();
                crudCommand.CommandType = CommandType.StoredProcedure;
                oadpt.Fill(dtExcuted);
                strMessage = "";
            }
            catch (SqlException ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                crudCommand.Connection.Close();
            }

        }
        #endregion 

        #region bulkCopy
        public void bulkCopy(string strTableName, DataTable dt)
        {
            using (objConnection)
            {
                using (SqlBulkCopy bc = new SqlBulkCopy(objConnection))
                {
                    bc.BatchSize = 10000;
                    bc.NotifyAfter = 5000;
                    //bc.SqlRowsCopied +=(sender, eventArgs) =>  
                    //{  
                    //      lblProgRpt.Text += eventArgs.RowsCopied + " loaded...." 
                    //      + "<br/>";  
                    //      lblMsg.Text = "In " + bc.BulkCopyTimeout +
                    //       " Sec " + eventArgs.RowsCopied + "
                    //      Copied.";  
                    //};  

                    bc.DestinationTableName = strTableName;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        bc.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }
                    objConnection.Open();
                    bc.WriteToServer(dt);
                }
            }
        }
        #endregion
    }
}
