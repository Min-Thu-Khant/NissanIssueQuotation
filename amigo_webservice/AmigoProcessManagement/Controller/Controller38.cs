using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL_AmigoProcess.DAL;
using DAL_AmigoProcess.BOL;
using AmigoProcessManagement.Utility;
using System.Globalization;
using System.Transactions;

namespace AmigoProcessManagement.Controller
{
    public class Controller38
    {
        #region Declare
        private Response response;
        string con = Properties.Settings.Default.MyConnection;
        string CURRENT_DATETIME;
        string CURRENT_USER;
        DateTime TEMP = DateTime.Now;
        #endregion

        #region Constructor
        public Controller38()
        {
            response = new Response();
            //UPDATED_AT
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public Controller38(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region GetCustomerList
        public Response GetCustomerList(string COMPANY_NAME, string COMPANY_NAME_READING, string BILL_COMPANY_NAME, string COMPANY_NO_BOX, string ACCOUNT_NAME)
        {
            try
            {
                CUSTOMER_MASTER oCustomer = new CUSTOMER_MASTER(con);
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
            using (TransactionScope dbTxn = new TransactionScope())
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
                            B_Customer.COMPANY_NO_BOX = (dgvList.Rows[i]["COMPANY_NO_BOX"] != null ? dgvList.Rows[i]["COMPANY_NO_BOX"].ToString() : "");
                            B_Customer.TRANSACTION_TYPE = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["TRANSACTION_TYPE"] != null ? dgvList.Rows[i]["TRANSACTION_TYPE"].ToString() : ""));
                            B_Customer.NCS_CUSTOMER_CODE = (dgvList.Rows[i]["NCS_CUSTOMER_CODE"] != null ? dgvList.Rows[i]["NCS_CUSTOMER_CODE"].ToString() : "");
                            B_Customer.EFFECTIVE_DATE = DateTime.Parse(dgvList.Rows[i]["EFFECTIVE_DATE"] != null ? dgvList.Rows[i]["EFFECTIVE_DATE"].ToString() : "");
                            B_Customer.BILL_BILLING_INTERVAL = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["BILL_BILLING_INTERVAL"] != null ? dgvList.Rows[i]["BILL_BILLING_INTERVAL"].ToString() : ""));
                            B_Customer.BILL_DEPOSIT_RULES = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["BILL_DEPOSIT_RULES"] != null ? dgvList.Rows[i]["BILL_DEPOSIT_RULES"].ToString() : ""));
                            B_Customer.BILL_TRANSFER_FEE = Utility.Utility_Component.dtColumnToDecimal((dgvList.Rows[i]["BILL_TRANSFER_FEE"] != null ? dgvList.Rows[i]["BILL_TRANSFER_FEE"].ToString() : ""));
                            B_Customer.BILL_EXPENSES = Utility.Utility_Component.dtColumnToDecimal(dgvList.Rows[i]["BILL_EXPENSES"] != null ? dgvList.Rows[i]["BILL_EXPENSES"].ToString() : "");
                            B_Customer.REQ_SEQ = Utility.Utility_Component.dtColumnToInt((dgvList.Rows[i]["REQ_SEQ"] != null ? dgvList.Rows[i]["REQ_SEQ"].ToString() : ""));
                            B_Customer.UPDATED_AT = CURRENT_DATETIME;
                            B_Customer.UPDATED_BY = CURRENT_USER;
                            CUSTOMER_MASTER DAL_Customer = new CUSTOMER_MASTER(con);
                            DAL_Customer.Update(B_Customer, out strMessage);

                            if (!string.IsNullOrEmpty(strMessage))
                            {
                                break;
                            }

                            BOL_BANK_ACCOUNT_MASTER B_BankAccounts = new BOL_BANK_ACCOUNT_MASTER();
                            B_BankAccounts.COMPANY_NO_BOX = B_Customer.COMPANY_NO_BOX;
                            B_BankAccounts.REQ_SEQ = B_Customer.REQ_SEQ;
                            B_BankAccounts.BILL_BANK_ACCOUNT_NAME_1 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-1"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-1"].ToString() : "");
                            B_BankAccounts.BILL_BANK_ACCOUNT_NAME_2 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-2"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-2"].ToString() : "");
                            B_BankAccounts.BILL_BANK_ACCOUNT_NAME_3 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-3"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-3"].ToString() : "");
                            B_BankAccounts.BILL_BANK_ACCOUNT_NAME_4 = (dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-4"] != null ? dgvList.Rows[i]["BILL_BANK_ACCOUNT_NAME-4"].ToString() : "");
                            B_BankAccounts.UPDATED_AT = CURRENT_DATETIME;
                            B_BankAccounts.UPDATED_BY = CURRENT_USER;

                            BANK_ACCOUNT_MASTER DAL_BankAccount = new BANK_ACCOUNT_MASTER(con);
                            DAL_BankAccount.Update(B_BankAccounts, out strMessage);

                            if (!string.IsNullOrEmpty(strMessage))
                            {
                                break;
                            }

                        }
                    }

                    if (string.IsNullOrEmpty(strMessage))
                    {
                        dbTxn.Complete();
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
                    dbTxn.Dispose();
                    response.Status = 0;
                    response.Message = ex.Message + "\n" + ex.StackTrace;
                    return response;
                }
            }
        }
        #endregion

    }
}