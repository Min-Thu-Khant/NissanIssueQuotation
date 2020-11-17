using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_AmigoProcess.BOL
{

    #region BOL_BANK_ACCOUNT_MASTER
    public class BOL_BANK_ACCOUNT_MASTER
    {
        public string COMPANY_NO_BOX { get; set; }
        public int REQ_SEQ { get; set; }
        public string BILL_BANK_ACCOUNT_NAME_1 {get;set;}
        public string BILL_BANK_ACCOUNT_NAME_2 {get;set;}
        public string BILL_BANK_ACCOUNT_NAME_3 {get;set;}
	    public string BILL_BANK_ACCOUNT_NAME_4 {get;set;}
	    public string BILL_BANK_ACCOUNT_NUMBER_1 {get;set;}
	    public string BILL_BANK_ACCOUNT_NUMBER_2 {get;set;}
	    public string BILL_BANK_ACCOUNT_NUMBER_3 {get;set;}
	    public string BILL_BANK_ACCOUNT_NUMBER_4 {get;set;}
	    public string CREATED_AT { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        public string UPDATED_BY { get; set; }
    }
    #endregion

}
