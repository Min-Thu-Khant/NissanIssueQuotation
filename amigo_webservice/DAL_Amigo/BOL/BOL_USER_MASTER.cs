using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    #region BOL_USER_MASTER
    public class BOL_USER_MASTER
    {
        #region private
        private string _ID;
        private string _PASS;
        #endregion

        #region Encapsulation

        public string ID { get { return _ID; } set { _ID = value; } }
        public string PASS { get { return _PASS; } set { _PASS = value; } }

        #endregion

        #region Constructors

        public BOL_USER_MASTER()
        {
            _ID = "";
            _PASS = "";
        }

        #endregion
    }
    #endregion
}
