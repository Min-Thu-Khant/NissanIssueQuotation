using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.BOL;
using AmigoProcessManagement.Utility;
using System.Globalization;

namespace AmigoProcessManagement.Controller
{
    public class Controller38
    {
        #region Declare
        private Response response;
        #endregion

        #region Constructor
        public Controller38()
        {
            response = new Response();
        }
        #endregion

        #region GetCustomerList
        public Response GetCustomerList(string COMPANY_NAME, string COMPANY_NAME_READING, string BILL_COMPANY_NAME, string COMPANY_NO_BOX, string ACCOUNT_NAME)
        {
            try
            {
                CUSTOMER_MASTER oCustomer = new CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
                DataTable dt = oCustomer.getGridViewData(COMPANY_NAME, COMPANY_NAME_READING, BILL_COMPANY_NAME, COMPANY_NO_BOX, ACCOUNT_NAME);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "CUSTOMER");
                response.Status = 1;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region UpdateCustomer
        public Response UpdateCustomer(string Customers)
        {
            try
            {
                string strMessage = "";
                DataTable dgvList = Utility.Utility_Component.JsonToDt(Customers);
                if (dgvList.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        BOL_CUSTOMER_MASTER B_Customer = new BOL_CUSTOMER_MASTER();
                        B_Customer.BILL_BANK_ACCOUNT_NAME_1 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-1"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-1"].ToString() : "");
                        B_Customer.BILL_BANK_ACCOUNT_NAME_2 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-2"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-2"].ToString() : "");
                        B_Customer.BILL_BANK_ACCOUNT_NAME_3 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-3"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-3"].ToString() : "");
                        B_Customer.BILL_BANK_ACCOUNT_NAME_4 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-4"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-4"].ToString() : "");
                        B_Customer.COMPANY_NO_BOX = (dgvList.Rows[i]["COMPANY_NO_BOX"] != null ? dgvList.Rows[i]["COMPANY_NO_BOX"].ToString() : "");
                        B_Customer.TRANSACTION_TYPE = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["TRANSACTION_TYPE"] != null ? dgvList.Rows[i]["TRANSACTION_TYPE"].ToString() : ""));
                        B_Customer.NCS_CUSTOMER_CODE = (dgvList.Rows[i]["NCS_CUSTOMER_CODE"] != null ? dgvList.Rows[i]["NCS_CUSTOMER_CODE"].ToString() : "");
                        B_Customer.EFFECTIVE_DATE = DateTime.Parse(dgvList.Rows[i]["EFFECTIVE_DATE"] != null ? dgvList.Rows[i]["EFFECTIVE_DATE"].ToString() : "");               
                        B_Customer.BILL_BILLING_INTERVAL = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["BILL_BILLING_INTERVAL"] != null ? dgvList.Rows[i]["BILL_BILLING_INTERVAL"].ToString() : ""));
                        B_Customer.BILL_DEPOSIT_RULES = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["BILL_DEPOSIT_RULES"] != null ? dgvList.Rows[i]["BILL_DEPOSIT_RULES"].ToString() : ""));
                        B_Customer.BILL_TRANSFER_FEE = Utility.Utility_Component.dtColumnToDecimal((dgvList.Rows[i]["BILL_TRANSFER_FEE"] != null ? dgvList.Rows[i]["BILL_TRANSFER_FEE"].ToString() : ""));
                        B_Customer.BILL_EXPENSES = Utility.Utility_Component.dtColumnToDecimal(dgvList.Rows[i]["BILL_EXPENSES"] != null ? dgvList.Rows[i]["BILL_EXPENSES"].ToString() : "");
                        B_Customer.UPDATE_DATE = DateTime.Now;
                        B_Customer.UPDATER_CODE = dgvList.Rows[i]["UPDATER_CODE"].ToString();
                        CUSTOMER_MASTER DAL_Customer = new CUSTOMER_MASTER(Properties.Settings.Default.MyConnection);
                        DAL_Customer.update(B_Customer, out strMessage);
                    }
                }

                if (strMessage == "")
                {
                    response.Status = 1;
                    response.Message = "Customer updated";

                }
                else
                {
                    response.Status = 0;
                    response.Message = strMessage;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message + "\n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

    }
}