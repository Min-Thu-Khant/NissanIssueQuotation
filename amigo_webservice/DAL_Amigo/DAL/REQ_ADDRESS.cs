using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class REQ_ADDRESS
    {
        #region Declares
        public string strConnectionString;
        string strMessage;

        string strGetPDFData1 = @"select CONTACT_NAME AS SERVICE_CONTACT_NAME,
                                  MAIL_ADDRESS AS SERVICE_MAIL_ADDRESS,
                                  PHONE_NUMBER AS SERVICE_PHONE_NUMBER 
                                  from REQ_ADDRESS
                                  where COMPANY_NO_BOX= @COMPANY_NO_BOX
                                  AND REQ_SEQ= @REQ_SEQ
                                  AND TYPE=3";

        string strGetPDFData2 = @"select MAIL_ADDRESS AS ERROR_MAIL_ADDRESS
                                  from REQ_ADDRESS
                                  where COMPANY_NO_BOX= @COMPANY_NO_BOX
                                  AND REQ_SEQ= @REQ_SEQ
                                  AND TYPE=4";
        #endregion

        #region Constructors
        public REQ_ADDRESS(string con)
        {
            strConnectionString = con;
            strMessage = "";
        }
        #endregion

        #region GetPDFData1
        public System.Data.DataTable GetPDFData1(string COMPANY_NO_BOX,string REQ_SEQ, out string strMsg)

        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPDFData1);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", 3));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion

        #region GetPDFData2
        public System.Data.DataTable GetPDFData2(string COMPANY_NO_BOX, string REQ_SEQ, out string strMsg)
        {
            //result
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetPDFData2);
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@COMPANY_NO_BOX", COMPANY_NO_BOX));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@REQ_SEQ", REQ_SEQ));
            oMaster.crudCommand.Parameters.Add(new SqlParameter("@TYPE", 4));
            oMaster.ExcuteQuery(4, out strMsg);
            return oMaster.dtExcuted;
        }
        #endregion
    }
}
