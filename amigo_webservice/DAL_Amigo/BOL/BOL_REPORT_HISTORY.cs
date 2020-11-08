using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{
    public class BOL_REPORT_HISTORY
    {
        public string COMPANY_NO_BOX { get; set; }
        public int REQ_SEQ { get; set; }
        public int REPORT_TYPE { get; set; }
        public int REPORT_HISTORY_SEQ { get; set; }
        public DateTime? OUTPUT_AT { get; set; }
        public string OUTPUT_BY { get; set; }
        public string OUTPUT_FILE { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string CREATED_AT { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_BY { get; set; }
    }
}
