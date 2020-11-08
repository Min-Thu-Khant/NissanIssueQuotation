using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_AUTO_INDEX
    public class BOL_AUTO_INDEX
    {
        #region private
        private string _AUTO_INDEX_ID;
        private int _AUTO_INDEX;
        private string _CREATED_AT;
        private string _CREATED_BY;
        private string _UPDATED_AT;
        private string _UPDATED_BY;

        #endregion

        #region Encapsulation

        public string AUTO_INDEX_ID { get { return _AUTO_INDEX_ID; } set { _AUTO_INDEX_ID = value; } }
        public int AUTO_INDEX { get { return _AUTO_INDEX; } set { _AUTO_INDEX = value; } }
        public string CREATED_AT { get { return _CREATED_AT; } set { _CREATED_AT = value; } }
        public string CREATED_BY { get { return _CREATED_BY; } set { _CREATED_BY = value; } }
        public string UPDATED_AT { get { return _UPDATED_AT; } set { _UPDATED_AT = value; } }
        public string UPDATED_BY { get { return _UPDATED_BY; } set { _UPDATED_BY = value; } }

        #endregion
    }
    #endregion

}
