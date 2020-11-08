using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_CONFIG
    public class BOL_CONFIG
    {
        #region Declare
        DataTable dt;
        #endregion

        #region Constructor
        public BOL_CONFIG(string PROGRAM_ID, string CONNECTION)
        {
            string strMSG = "";
            CONFIG_TBL CONFIG = new CONFIG_TBL(CONNECTION);
            dt = CONFIG.GetConfigByProgramID(PROGRAM_ID, out strMSG);

        }
        #endregion

        public DataRow getValueByKey(string key)
        {
            // search index from Original Table
            return dt.Select("CONFIG_KEY = '" + key + "'")[0];

        }

        public string getStringValue(string key)
        {
            string value = "";
            try
            {
                value = getValueByKey(key)["STRING_VALUE1"].ToString();
            }
            catch (Exception)
            {

            }
            return value;
        }

        public int getIntValue(string key)
        {
            int value = 0;
            try
            {
                value = int.Parse(getValueByKey(key)["INTEGER_VALUE1"].ToString());
            }
            catch (Exception)
            {

            }
            return value;
        }
    }
    #endregion

}
