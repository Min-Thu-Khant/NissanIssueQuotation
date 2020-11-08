using AmigoProcessManagement.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace AmigoProcessManagement
{
    /// <summary>
    /// Summary description for opt_3A
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class opt_37 : System.Web.Services.WebService
    {
        #region GetDataFor37
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDataFor37(int TRANSACTION_TYPE, 
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.Controller37 o37 = new Controller.Controller37();
                Response response = o37.GetDataGridfor37(TRANSACTION_TYPE, 
                                                        FROM_YEAR_MONTH, TO_YEAR_MONTH, 
                                                        FROM_STATUS_PLAN_DEPOSIT_YYMM, TO_STATUS_PLAN_DEPOSIT_YYMM, 
                                                        FROM_STATUS_ACTUAL_DEPOSIT_DATE, TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region UpdateInvoice

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void UpdateInvoice(string List)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.Controller37 o37 = new Controller.Controller37();
                Response response = o37.UpdateInvoice_37(List);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }

        #endregion

        #region AccountReceivableExport
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        
        public void Account_Receivable(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.Controller37 o37 = new Controller.Controller37();
                Response response = o37.GetAccount_Receivable(
                                                        TRANSACTION_TYPE,
                                                        FROM_YEAR_MONTH, TO_YEAR_MONTH,
                                                        FROM_STATUS_PLAN_DEPOSIT_YYMM, TO_STATUS_PLAN_DEPOSIT_YYMM,
                                                        FROM_STATUS_ACTUAL_DEPOSIT_DATE, TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region SecheduledPaymentExport
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Scheduled_Payment(
                                int TRANSACTION_TYPE,
                                string FROM_YEAR_MONTH,
                                string TO_YEAR_MONTH,
                                string FROM_STATUS_PLAN_DEPOSIT_YYMM,
                                string TO_STATUS_PLAN_DEPOSIT_YYMM,
                                string FROM_STATUS_ACTUAL_DEPOSIT_DATE,
                                string TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                string DEPOSIT_RULE,
                                string WITH_OR_WITHOUT_PAYMENT,
                                string BILL_SUPPLIER_NAME)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.Controller37 o37 = new Controller.Controller37();
                Response response = o37.GetScheduled_Payment(
                                                        TRANSACTION_TYPE,
                                                        FROM_YEAR_MONTH, TO_YEAR_MONTH,
                                                        FROM_STATUS_PLAN_DEPOSIT_YYMM, TO_STATUS_PLAN_DEPOSIT_YYMM,
                                                        FROM_STATUS_ACTUAL_DEPOSIT_DATE, TO_STATUS_ACTUAL_DEPOSIT_DATE,
                                                        DEPOSIT_RULE,
                                                        WITH_OR_WITHOUT_PAYMENT,
                                                        BILL_SUPPLIER_NAME);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }
        #endregion

        #region AllocationManualCompletion

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AllocationManualCompletion(bool ALLOCATE, int SEQ_NO, string COMPANY_NO_BOX, string YEAR_MONTH, string RECEIPT_ALLOCATION_DATE, string INVOICE_ALLOCATION_DATE)
        {
            //get Authorization header
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            Response auth = Controller.ControllerCheckIn.CheckLogIn_forProcess(authHeader);

            if (auth.Message != "")
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(auth));
                Context.Response.End();
            }
            else
            {
                Controller.Controller37 o37 = new Controller.Controller37();
                Response response = o37.AllocationManualCompletion(ALLOCATE, SEQ_NO, COMPANY_NO_BOX, YEAR_MONTH, RECEIPT_ALLOCATION_DATE, INVOICE_ALLOCATION_DATE);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(JsonConvert.SerializeObject(response));
                Context.Response.End();
            }
        }

        #endregion

    }
}
