using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUtility = AmigoPaperWorkProcessSystem.Core.WebUtility;

namespace AmigoPaperWorkProcessSystem.Controllers
{
    public class frm37Controller
    {
        #region Constructor
        public frm37Controller()
        { }
        #endregion

        #region GetDataForGrid
        public DataTable GetDataForGrid(int TRANSACTION_TYPE, 
                                        string FROM_YEAR_MONTH, 
                                        string TO_YEAR_MONTH,
                                        string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                        string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                        string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                        string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                        int DEPOSIT_RULE,
                                        int WITH_OR_WITHOUT_PAYMENT,
                                        string BILL_SUPPLIER_NAME)
        {
            string url = Properties.Settings.Default.GetDataForGrid37
                .Replace("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString())
                .Replace("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? "" : FROM_YEAR_MONTH)
                .Replace("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? "" : TO_YEAR_MONTH)
                .Replace("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : FROM_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : TO_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" :FROM_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" :TO_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@DEPOSIT_RULE", DEPOSIT_RULE.ToString())
                .Replace("@WITH_OR_WITHOUT_PAYMENT", WITH_OR_WITHOUT_PAYMENT.ToString())
                .Replace("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME);

            return WebUtility.Get(url);
        }
        #endregion

        #region UpdateInvoice
        public DataTable UpdateInvoice(DataTable list)
        {
            string url = Properties.Settings.Default.UpdateInvoice;

            return WebUtility.Post(url, list);
        }
        #endregion

        #region SchedulePayment
        public DataTable getSchedule_Payment(int TRANSACTION_TYPE,
                                        string FROM_YEAR_MONTH,
                                        string TO_YEAR_MONTH,
                                        string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                        string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                        string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                        string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                        int DEPOSIT_RULE,
                                        int WITH_OR_WITHOUT_PAYMENT,
                                        string BILL_SUPPLIER_NAME)
        {
            string url = Properties.Settings.Default.Schedule_Payment
                .Replace("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString())
                .Replace("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? "" : FROM_YEAR_MONTH)
                .Replace("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? "" : TO_YEAR_MONTH)
                .Replace("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : FROM_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : TO_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" : FROM_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" : TO_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@DEPOSIT_RULE", DEPOSIT_RULE.ToString())
                .Replace("@WITH_OR_WITHOUT_PAYMENT", WITH_OR_WITHOUT_PAYMENT.ToString())
                .Replace("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME);

            return WebUtility.Get(url);
        }
        #endregion

        #region GetAccountReceivable
        public DataTable GetAccountReceivable(int TRANSACTION_TYPE,
                                        string FROM_YEAR_MONTH,
                                        string TO_YEAR_MONTH,
                                        string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                        string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                        string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                        string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                        int DEPOSIT_RULE,
                                        int WITH_OR_WITHOUT_PAYMENT,
                                        string BILL_SUPPLIER_NAME)
        {
            string url = Properties.Settings.Default.Account_Receivable
                .Replace("@TRANSACTION_TYPE", TRANSACTION_TYPE.ToString())
                .Replace("@FROM_YEAR_MONTH", FROM_YEAR_MONTH == "" ? "" : FROM_YEAR_MONTH)
                .Replace("@TO_YEAR_MONTH", TO_YEAR_MONTH == "" ? "" : TO_YEAR_MONTH)
                .Replace("@FROM_STATUS_PLAN_DEPOSIT_YYMM", FROM_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : FROM_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@TO_STATUS_PLAN_DEPOSIT_YYMM", TO_STATUS_PLAN_DEPOSIT_YYMM == "" ? "" : TO_STATUS_PLAN_DEPOSIT_YYMM)
                .Replace("@FROM_STATUS_ACTUAL_DEPOSIT_DATE", FROM_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" : FROM_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@TO_STATUS_ACTUAL_DEPOSIT_DATE", TO_STATUS_ACTUAL_DEPOSIT_DATE == "" ? "" : TO_STATUS_ACTUAL_DEPOSIT_DATE)
                .Replace("@DEPOSIT_RULE", DEPOSIT_RULE.ToString())
                .Replace("@WITH_OR_WITHOUT_PAYMENT", WITH_OR_WITHOUT_PAYMENT.ToString())
                .Replace("@BILL_SUPPLIER_NAME", BILL_SUPPLIER_NAME);

            return WebUtility.Get(url);
        }
        #endregion

        #region ManualAlloaction
        public DataTable ManualAlloaction(string COMPANY_NO_BOX, string YEAR_MONTH)
        {
            string url = Properties.Settings.Default.ManualAllocation
                .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX).Replace("@YEAR_MONTH", YEAR_MONTH);    

            return WebUtility.Get(url);
        }
        #endregion

        #region ManualAlloactionCompletion
        public DataTable ManualAlloactionCompletion(string RECEIPT_ALLOCATION_DATE, string INVOICE_ALLOCATION_DATE, int SEQ_NO, string COMPANY_NO_BOX, string YEAR_MONTH, bool ALLOCATE)
        {
            string url = Properties.Settings.Default.ManualAllocationComplete
                .Replace("@ALLOCATE", ALLOCATE.ToString())
                .Replace("@SEQ_NO", SEQ_NO.ToString())
                .Replace("@COMPANY_NO_BOX", COMPANY_NO_BOX.Trim())
                .Replace("@YEAR_MONTH", YEAR_MONTH.Trim())
                .Replace("@RECEIPT_ALLOCATION_DATE", RECEIPT_ALLOCATION_DATE.Trim())
                .Replace("@INVOICE_ALLOCATION_DATE", INVOICE_ALLOCATION_DATE.Trim());

            return WebUtility.Get(url);
        }
        #endregion
    }
}
