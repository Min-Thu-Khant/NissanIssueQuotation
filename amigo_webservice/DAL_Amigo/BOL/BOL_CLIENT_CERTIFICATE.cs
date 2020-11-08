using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    public class BOL_CLIENT_CERTIFICATE
    {
        private string _CLIENT_CERTIFICATE_NO;
        private int _FY;
        private string _PASSWORD;
        private DateTime? _EXPIRATION_DATE;
        private string _COMPANY_NO_BOX;
        private DateTime? _DISTRIBUTION_DATE;
        private string _CREATED_AT;
        private string _CREATED_BY;
        private string _UPDATED_AT;
        private string _UPDATED_BY;
        private string _UPDATED_AT_RAW;

        public string CLIENT_CERTIFICATE_NO { get { return _CLIENT_CERTIFICATE_NO; } set { _CLIENT_CERTIFICATE_NO = value; } }
        public int FY { get { return _FY; } set { _FY = value; } }
        public string PASSWORD { get { return _PASSWORD; } set { _PASSWORD = value; } }
        public DateTime? EXPIRATION_DATE { get { return _EXPIRATION_DATE; } set { _EXPIRATION_DATE = value; } }
        public string COMPANY_NO_BOX { get { return _COMPANY_NO_BOX; } set { _COMPANY_NO_BOX = value; } }
        public DateTime? DISTRIBUTION_DATE { get { return _DISTRIBUTION_DATE; } set { _DISTRIBUTION_DATE = value; } }
        public String CREATED_AT { get { return _CREATED_AT; } set { _CREATED_AT = value; } }
        public String CREATED_BY { get { return _CREATED_BY; } set { _CREATED_BY = value; } }
        public String UPDATED_AT { get { return _UPDATED_AT; } set { _UPDATED_AT = value; } }
        public String UPDATED_BY { get { return _UPDATED_BY; } set { _UPDATED_BY = value; } }
        public string UPDATED_AT_RAW { get { return _UPDATED_AT_RAW; } set { _UPDATED_AT_RAW = value; } }
    }
}
