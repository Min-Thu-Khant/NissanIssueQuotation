using DAL_AmigoProcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.DAL
{
    public class MENU_MASTER
    {
        #region ConnectionSetUp

        public string strConnectionString;
        string strGetTreeMenu = @"SELECT CATEGORY_MASTER.CATEGORY_ID, CATEGORY_MASTER.CATEGORY_NAME, MENU_MASTER.PROGRAM_ID, MENU_MASTER.PROGRAM_NAME, MENU_MASTER.PROGRAM_NAME FROM CATEGORY_MASTER LEFT JOIN MENU_MASTER 
                            ON MENU_MASTER.CATEGORY_ID = CATEGORY_MASTER.CATEGORY_ID
                            ORDER BY CATEGORY_MASTER.DISPLAY_ORDER, MENU_MASTER.DISPLAY_ORDER";

        #endregion

        #region Constructors
        public MENU_MASTER(string con)
        {
            strConnectionString = con;
        }
        #endregion

        #region GetTreeMenu
        public DataTable getTreeMenu(out string strMessage)
        {
            ConnectionMaster oMaster = new ConnectionMaster(strConnectionString, strGetTreeMenu);
            oMaster.ExcuteQuery(4, out strMessage);
            return oMaster.dtExcuted;
        }
        #endregion
    }
}
