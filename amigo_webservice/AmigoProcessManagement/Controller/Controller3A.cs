using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.BOL;
using AmigoProcessManagement.Utility;
using System.Transactions;

namespace AmigoProcessManagement.Controller
{
    public class Controller3A
    {
        #region Declare
        public DataTable dtUploadData;
        public List<BOL_RECEIPT_DETAILS> lstAmigo;
        public List<BOL_RECEIPT_DETAILS_NON_AMIGO> lstNonAmigo;
        public DataTable dtCustomer;
        private string _UploadData;
        private string file_name;
        private Response response;
        #endregion

        #region Constructor
        public Controller3A(string File_name, string UploadData)
        {
            _UploadData = UploadData;
            file_name = File_name;
            lstAmigo = new List<BOL_RECEIPT_DETAILS>();
            lstNonAmigo = new List<BOL_RECEIPT_DETAILS_NON_AMIGO>();
            response = new Response();
        }
        #endregion

        #region do3A_BatchProcess
         
        public Response do3A_BatchProcess()
        {

            using (TransactionScope dbTxn = new TransactionScope())
            {
                try
                {
                    convertDataToDataTable(_UploadData);
                    seperateAmigo_NonAmigo();
                    string strMessage = "";
                    for (int i = 0; i < lstAmigo.Count; i++)
                    {
                        strMessage = "";
                        RECEIPT_DETAILS oDetail = new RECEIPT_DETAILS(Properties.Settings.Default.MyConnection);
                        if (oDetail.GetDataByDuplicateKeys(lstAmigo[i], out strMessage).Rows.Count <= 0)
                        {
                            oDetail.insert(lstAmigo[i], out strMessage);
                        }
                    }

                    for (int i = 0; i < lstNonAmigo.Count; i++)
                    {
                        strMessage = "";
                        RECEIPT_DETAILS_NON_AMIGO oDetail = new RECEIPT_DETAILS_NON_AMIGO(Properties.Settings.Default.MyConnection);
                        if (oDetail.GetDataByDuplicateKeys(lstNonAmigo[i], out strMessage).Rows.Count<=0)
                        {
                            oDetail.insert(lstNonAmigo[i], out strMessage);
                        }
                       
                    }
                    if (strMessage =="")
                    {
                        dbTxn.Complete();
                        response.Status = 1;
                    }
                    else
                    {
                        dbTxn.Dispose();
                        response.Status = 0;
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    response.Status = 0;
                    response.Message = ex.Message + "\n" + ex.StackTrace;
                    dbTxn.Dispose();
                    return response;
                }
            }            
        }
        #endregion

        #region seperateAmigo_NonAmigo
        protected void seperateAmigo_NonAmigo()
        {
            CUSTOMER_MASTER oCust = new CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
            string run_date = DateTime.Now.ToString();
            DataTable dtCustomer = oCust.getBillBankAccounts();
            for (int i = 0; i < dtUploadData.Rows.Count; i++)
            {
                string strCustomerName = (dtUploadData.Rows[i]["CUSTOMER_NAME"]!=null ? dtUploadData.Rows[i]["CUSTOMER_NAME"].ToString().Trim() : "");
                var query = dtCustomer.AsEnumerable().Where
                           (r => (r.Field<string>("BILL_BANK_ACCOUNT_NAME-1") == null ? "" : r.Field<string>("BILL_BANK_ACCOUNT_NAME-1").Trim()) == strCustomerName
                           || (r.Field<string>("BILL_BANK_ACCOUNT_NAME-2") == null ? "" : r.Field<string>("BILL_BANK_ACCOUNT_NAME-2").Trim()) == strCustomerName
                           || (r.Field<string>("BILL_BANK_ACCOUNT_NAME-3") == null ? "" : r.Field<string>("BILL_BANK_ACCOUNT_NAME-3").Trim()) == strCustomerName
                           || (r.Field<string>("BILL_BANK_ACCOUNT_NAME-4") == null ? "" : r.Field<string>("BILL_BANK_ACCOUNT_NAME-4").Trim()) == strCustomerName
                           );
                if (query.Any()) //Amigo
                {
                    BOL_RECEIPT_DETAILS oReceipt = new BOL_RECEIPT_DETAILS();

                    oReceipt.DATA_CLASS = 1;
                    oReceipt.RECORD_CLASS = (dtUploadData.Rows[i]["RECORD_CLASS"] != null ? dtUploadData.Rows[i]["RECORD_CLASS"].ToString() : "");
                    oReceipt.TRANSACTION_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["TRANSACTION_DATE"] != null ? dtUploadData.Rows[i]["TRANSACTION_DATE"].ToString() : "");
                    oReceipt.TRANSACTION_CONTACT_NAME = (dtUploadData.Rows[i]["TRANSACTION_CONTACT_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_CONTACT_NAME"].ToString() : "");
                    oReceipt.TRANSACTION_BANKS_NAME = (dtUploadData.Rows[i]["TRANSACTION_BANKS_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_BANKS_NAME"].ToString() : "");
                    oReceipt.TRANSACTION_BRANCH_NAME = (dtUploadData.Rows[i]["TRANSACTION_BRANCH_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_BRANCH_NAME"].ToString() : "");
                    oReceipt.TRANSACTION_ACCOUNT_NO_CLASS = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO_CLASS"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO_CLASS"].ToString() : "");
                    oReceipt.TRANSACTION_ACCOUNT_TYPE = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_TYPE"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_TYPE"].ToString() : "");
                    oReceipt.TRANSACTION_ACCOUNT_NO = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO"].ToString() : "");
                    oReceipt.RESEND_INDICATION = (dtUploadData.Rows[i]["RESEND_INDICATION"] != null ? dtUploadData.Rows[i]["RESEND_INDICATION"].ToString() : "");
                    oReceipt.TRANSACTION_NAME = (dtUploadData.Rows[i]["TRANSACTION_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_NAME"].ToString() : "");
                    oReceipt.TRANSACTION_NO = (dtUploadData.Rows[i]["TRANSACTION_NO"] != null ? dtUploadData.Rows[i]["TRANSACTION_NO"].ToString() : "");
                    oReceipt.TRANSACTION_DETAIL_CLASS = (dtUploadData.Rows[i]["TRANSACTION_DETAIL_CLASS"] != null ? dtUploadData.Rows[i]["TRANSACTION_DETAIL_CLASS"].ToString() : "");
                    oReceipt.HANDLING_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["HANDLING_DATE"] != null ? dtUploadData.Rows[i]["HANDLING_DATE"].ToString() : "");
                    oReceipt.DEPOSIT_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["DEPOSIT_DATE"] != null ? dtUploadData.Rows[i]["DEPOSIT_DATE"].ToString() : "");
                    oReceipt.DEPOSIT_AMOUNT = Utility_Component.dtColumnToDecimal(dtUploadData.Rows[i]["DEPOSIT_AMOUNT"] != null ? dtUploadData.Rows[i]["DEPOSIT_AMOUNT"].ToString() : "");
                    oReceipt.CHECK_CLASS = (dtUploadData.Rows[i]["CHECK_CLASS"] != null ? dtUploadData.Rows[i]["CHECK_CLASS"].ToString() : "");
                    oReceipt.CUSTOMER_NAME = (dtUploadData.Rows[i]["CUSTOMER_NAME"] != null ? dtUploadData.Rows[i]["CUSTOMER_NAME"].ToString() : "");
                    oReceipt.COLLECTION_NO_SHEETS = Utility_Component.dtColumnToInt(dtUploadData.Rows[i]["COLLECTION_NO_SHEETS"] != null ? dtUploadData.Rows[i]["COLLECTION_NO_SHEETS"].ToString() : "");
                    oReceipt.COLLECTION_NO = (dtUploadData.Rows[i]["COLLECTION_NO"] != null ? dtUploadData.Rows[i]["COLLECTION_NO"].ToString() : "");
                    oReceipt.CUSTOMER_NO = (dtUploadData.Rows[i]["CUSTOMER_NO"] != null ? dtUploadData.Rows[i]["CUSTOMER_NO"].ToString() : "");
                    oReceipt.BANK_NAME = (dtUploadData.Rows[i]["BANK_NAME"] != null ? dtUploadData.Rows[i]["BANK_NAME"].ToString() : "");
                    oReceipt.BRANCH_NAME = (dtUploadData.Rows[i]["BRANCH_NAME"] != null ? dtUploadData.Rows[i]["BRANCH_NAME"].ToString() : "");
                    oReceipt.TRANSACTION_FILE_NAME = (dtUploadData.Rows[i]["TRANSACTION_FILE_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_FILE_NAME"].ToString() : "");
                    oReceipt.TRANSFER_MESSAGE = (dtUploadData.Rows[i]["TRANSFER_MESSAGE"] != null ? dtUploadData.Rows[i]["TRANSFER_MESSAGE"].ToString() : "");
                    oReceipt.NOTE = (dtUploadData.Rows[i]["NOTE"] != null ? dtUploadData.Rows[i]["NOTE"].ToString() : "");
                    oReceipt.NUMBER = (!String.IsNullOrEmpty(dtUploadData.Rows[i]["NUMBER"].ToString()) ? int.Parse(dtUploadData.Rows[i]["NUMBER"].ToString()) : 0);
                    oReceipt.RUN_DATE_TIME = run_date;
                    oReceipt.RUN_RESULT = 1;
                    oReceipt.DATA_MOVEMENT_INFORMATION = "";
                    oReceipt.PAYMENT_DAY = null;
                    oReceipt.TYPE_OF_ALLOCATION = 0;
                    oReceipt.ALLOCATED_QUANTITY = 0;
                    oReceipt.ALLOCATED_MONEY = 0;
                    oReceipt.ALLOCATED_COMPLETION_DATE = null;

                    lstAmigo.Add(oReceipt);
                }
                else //Non Amigo
                {
                    BOL_RECEIPT_DETAILS_NON_AMIGO oReceipt_NonAmigo = new BOL_RECEIPT_DETAILS_NON_AMIGO();
                    oReceipt_NonAmigo.DATA_CLASS = 1;
                    oReceipt_NonAmigo.RECORD_CLASS = (dtUploadData.Rows[i]["RECORD_CLASS"] != null ? dtUploadData.Rows[i]["RECORD_CLASS"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["TRANSACTION_DATE"] != null ? dtUploadData.Rows[i]["TRANSACTION_DATE"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_CONTACT_NAME = (dtUploadData.Rows[i]["TRANSACTION_CONTACT_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_CONTACT_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_BANKS_NAME = (dtUploadData.Rows[i]["TRANSACTION_BANKS_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_BANKS_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_BRANCH_NAME = (dtUploadData.Rows[i]["TRANSACTION_BRANCH_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_BRANCH_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_ACCOUNT_NO_CLASS = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO_CLASS"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO_CLASS"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_ACCOUNT_TYPE = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_TYPE"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_TYPE"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_ACCOUNT_NO = (dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO"] != null ? dtUploadData.Rows[i]["TRANSACTION_ACCOUNT_NO"].ToString() : "");
                    oReceipt_NonAmigo.RESEND_INDICATION = (dtUploadData.Rows[i]["RESEND_INDICATION"] != null ? dtUploadData.Rows[i]["RESEND_INDICATION"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_NAME = (dtUploadData.Rows[i]["TRANSACTION_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_NO = (dtUploadData.Rows[i]["TRANSACTION_NO"] != null ? dtUploadData.Rows[i]["TRANSACTION_NO"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_DETAIL_CLASS = (dtUploadData.Rows[i]["TRANSACTION_DETAIL_CLASS"] != null ? dtUploadData.Rows[i]["TRANSACTION_DETAIL_CLASS"].ToString() : "");
                    oReceipt_NonAmigo.HANDLING_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["HANDLING_DATE"] != null ? dtUploadData.Rows[i]["HANDLING_DATE"].ToString() : "");
                    oReceipt_NonAmigo.DEPOSIT_DATE = Utility_Component.dtColumnToDateTime(dtUploadData.Rows[i]["DEPOSIT_DATE"] != null ? dtUploadData.Rows[i]["DEPOSIT_DATE"].ToString() : "");
                    oReceipt_NonAmigo.DEPOSIT_AMOUNT = Utility_Component.dtColumnToDecimal(dtUploadData.Rows[i]["DEPOSIT_AMOUNT"] != null ? dtUploadData.Rows[i]["DEPOSIT_AMOUNT"].ToString() : "");
                    oReceipt_NonAmigo.CHECK_CLASS = (dtUploadData.Rows[i]["CHECK_CLASS"] != null ? dtUploadData.Rows[i]["CHECK_CLASS"].ToString() : "");
                    oReceipt_NonAmigo.CUSTOMER_NAME = (dtUploadData.Rows[i]["CUSTOMER_NAME"] != null ? dtUploadData.Rows[i]["CUSTOMER_NAME"].ToString() : "");
                    oReceipt_NonAmigo.COLLECTION_NO_SHEETS = Utility_Component.dtColumnToInt(dtUploadData.Rows[i]["COLLECTION_NO_SHEETS"] != null ? dtUploadData.Rows[i]["COLLECTION_NO_SHEETS"].ToString() : "");
                    oReceipt_NonAmigo.COLLECTION_NO = (dtUploadData.Rows[i]["COLLECTION_NO"] != null ? dtUploadData.Rows[i]["COLLECTION_NO"].ToString() : "");
                    oReceipt_NonAmigo.CUSTOMER_NO = (dtUploadData.Rows[i]["CUSTOMER_NO"] != null ? dtUploadData.Rows[i]["CUSTOMER_NO"].ToString() : "");
                    oReceipt_NonAmigo.BANK_NAME = (dtUploadData.Rows[i]["BANK_NAME"] != null ? dtUploadData.Rows[i]["BANK_NAME"].ToString() : "");
                    oReceipt_NonAmigo.BRANCH_NAME = (dtUploadData.Rows[i]["BRANCH_NAME"] != null ? dtUploadData.Rows[i]["BRANCH_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSACTION_FILE_NAME = (dtUploadData.Rows[i]["TRANSACTION_FILE_NAME"] != null ? dtUploadData.Rows[i]["TRANSACTION_FILE_NAME"].ToString() : "");
                    oReceipt_NonAmigo.TRANSFER_MESSAGE = (dtUploadData.Rows[i]["TRANSFER_MESSAGE"] != null ? dtUploadData.Rows[i]["TRANSFER_MESSAGE"].ToString() : "");
                    oReceipt_NonAmigo.NOTE = (dtUploadData.Rows[i]["NOTE"] != null ? dtUploadData.Rows[i]["NOTE"].ToString() : "");
                    oReceipt_NonAmigo.NUMBER = (!String.IsNullOrEmpty(dtUploadData.Rows[i]["NUMBER"].ToString()) ? int.Parse(dtUploadData.Rows[i]["NUMBER"].ToString()) : 0);

                    oReceipt_NonAmigo.RUN_DATE_TIME = run_date;
                    oReceipt_NonAmigo.RUN_RESULT = 99;
                    oReceipt_NonAmigo.DATA_MOVEMENT_INFORMATION = "";
                    oReceipt_NonAmigo.PAYMENT_DAY = null;
                    oReceipt_NonAmigo.TYPE_OF_ALLOCATION = 0;
                    oReceipt_NonAmigo.ALLOCATED_QUANTITY = 0;
                    oReceipt_NonAmigo.ALLOCATED_MONEY = 0;
                    oReceipt_NonAmigo.ALLOCATED_COMPLETION_DATE = null;
                    lstNonAmigo.Add(oReceipt_NonAmigo);
                }               
            }
        }
        #endregion

        #region convertDataToDataTable
        private void convertDataToDataTable(string strUploadData)
        {
            string strReplaceFormat = strUploadData.Replace("],[", "];[");
            string[] strRows = strReplaceFormat.Split(';');
            DataTable dt = dtFormat();
            for (int i = 0; i < strRows.Length; i++)
            {
                string[] strColumns = cleanRow(strRows[i]).Split(',');
                if (strColumns.Length > 26)
                {
                    if (checkRowValidation(strColumns[0], strColumns[12], strColumns[10]))
                    {
                        DataRow dr = dt.NewRow();
                        dr["DATA_CLASS"] = "1";
                        dr["RECORD_CLASS"] = strColumns[0];
                        dr["TRANSACTION_DATE"] = getDateData(strColumns[1], strColumns[2], strColumns[3], strColumns[4]);
                        dr["TRANSACTION_CONTACT_NAME"] = strColumns[5];
                        dr["TRANSACTION_BANKS_NAME"] = strColumns[6];
                        dr["TRANSACTION_BRANCH_NAME"] = strColumns[7];
                        dr["TRANSACTION_ACCOUNT_NO_CLASS"] = strColumns[8];
                        dr["TRANSACTION_ACCOUNT_TYPE"] = strColumns[9];
                        dr["TRANSACTION_ACCOUNT_NO"] = strColumns[10];
                        dr["RESEND_INDICATION"] = strColumns[11];
                        dr["TRANSACTION_NAME"] = strColumns[12];
                        dr["TRANSACTION_NO"] = strColumns[13];
                        dr["TRANSACTION_DETAIL_CLASS"] = strColumns[14];
                        dr["HANDLING_DATE"] = getDateData(strColumns[15], strColumns[16], "0", "0"); //strColumns[15] + strColumns[16];
                        dr["DEPOSIT_DATE"] = getDateData(strColumns[17], strColumns[18], "0", "0"); //strColumns[17] + strColumns[18];
                        dr["DEPOSIT_AMOUNT"] = strColumns[19];
                        dr["CHECK_CLASS"] = strColumns[20];
                        dr["CUSTOMER_NAME"] = strColumns[21];
                        dr["COLLECTION_NO_SHEETS"] = strColumns[22];
                        dr["COLLECTION_NO"] = strColumns[23];
                        dr["CUSTOMER_NO"] = strColumns[24];
                        dr["BANK_NAME"] = strColumns[25];
                        dr["BRANCH_NAME"] = strColumns[26];
                        dr["TRANSFER_MESSAGE"] = strColumns[27];
                        dr["NOTE"] = strColumns[28];
                        dr["NUMBER"] = strColumns[29];

                        dr["TRANSACTION_FILE_NAME"] = file_name;
                        dr["RUN_DATE_TIME"] = "";
                        dr["RUN_RESULT"] = "";
                        dr["DATA_MOVEMENT_INFORMATION"] = "";
                        dr["PAYMENT_DAY"] = "";
                        dr["TYPE_OF_ALLOCATION"] = "";
                        dr["ALLOCATED_QUANTITY"] = "";
                        dr["ALLOCATED_MONEY"] = "";
                        dr["ALLOCATED_COMPLETION_DATE"] = "";
                        dt.Rows.Add(dr);
                    }
                }
            }

            dtUploadData = dt;
        }
        #endregion

        #region cleanRow
        private string cleanRow(string strRowData)
        {
            return strRowData.Replace(@"\", "").Replace("[", "").Replace("]", "").Replace("\"","");
        }
        #endregion

        #region getDateData
        private DateTime getDateData(string strMonth,string day,string hour, string minute)
        {
            int intMonth = 0;
            int.TryParse(strMonth, out intMonth);
            int intYear = DateTime.Now.Year;
            int intDay = 0;
            int.TryParse(day, out intDay);
            int intHR = 0;
            int.TryParse(hour, out intHR);
            int intMin = 0;
            int.TryParse(minute, out intMin);
            if (intMonth > DateTime.Now.Month)
            {
                intYear = (DateTime.Now.Year - 1);
            }
            DateTime dtm = new DateTime(intYear,intMonth,intDay,intHR,intMin,0);
            return dtm;
        }
        #endregion

        #region checkRowValidation
        private bool checkRowValidation(string strRecordNumber, string strTxnName, string strAccountNumber)
        {
            bool blRtn = true;
            if (strRecordNumber != "明細")
            {
                blRtn = false;
            }

            if (strTxnName != "振込")
            {
                blRtn = false;
            }

            if (!(strAccountNumber == "0483038" || strAccountNumber == "0009369"))
            {
                blRtn = false;
            }
            return blRtn;
        }
        #endregion

        #region dtFormat
        private DataTable dtFormat()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DATA_CLASS");
            dt.Columns.Add("RECORD_CLASS");
            dt.Columns.Add("TRANSACTION_DATE");
            dt.Columns.Add("TRANSACTION_CONTACT_NAME");
            dt.Columns.Add("TRANSACTION_BANKS_NAME");
            dt.Columns.Add("TRANSACTION_BRANCH_NAME");
            dt.Columns.Add("TRANSACTION_ACCOUNT_NO_CLASS");
            dt.Columns.Add("TRANSACTION_ACCOUNT_TYPE");
            dt.Columns.Add("TRANSACTION_ACCOUNT_NO");
            dt.Columns.Add("RESEND_INDICATION");
            dt.Columns.Add("TRANSACTION_NAME");
            dt.Columns.Add("TRANSACTION_NO");
            dt.Columns.Add("TRANSACTION_DETAIL_CLASS");
            dt.Columns.Add("HANDLING_DATE");
            dt.Columns.Add("DEPOSIT_DATE");
            dt.Columns.Add("DEPOSIT_AMOUNT");
            dt.Columns.Add("CHECK_CLASS");
            dt.Columns.Add("CUSTOMER_NAME");
            dt.Columns.Add("COLLECTION_NO_SHEETS");
            dt.Columns.Add("COLLECTION_NO");
            dt.Columns.Add("CUSTOMER_NO");
            dt.Columns.Add("BANK_NAME");
            dt.Columns.Add("BRANCH_NAME");
            dt.Columns.Add("TRANSFER_MESSAGE");
            dt.Columns.Add("NOTE");
            dt.Columns.Add("NUMBER");
            dt.Columns.Add("TRANSACTION_FILE_NAME");
            dt.Columns.Add("RUN_DATE_TIME");
            dt.Columns.Add("RUN_RESULT");
            dt.Columns.Add("DATA_MOVEMENT_INFORMATION");
            dt.Columns.Add("PAYMENT_DAY");
            dt.Columns.Add("TYPE_OF_ALLOCATION");
            dt.Columns.Add("ALLOCATED_QUANTITY");
            dt.Columns.Add("ALLOCATED_MONEY");
            dt.Columns.Add("ALLOCATED_COMPLETION_DATE");
            return dt;
        }
        #endregion       
    }
}