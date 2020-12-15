using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;
using System.Diagnostics;
using System.Transactions;
using DAL_AmigoProcess.BOL;

namespace AmigoProcessManagement.Controller
{
    public class ControllerCustomerMasterMaintenance
    {
        #region Declare
        MetaResponse response;
        Stopwatch timer;
        string con = Properties.Settings.Default.MyConnection;
        String UPDATED_AT_DATETIME;
        string CURRENT_DATETIME;
        string CURRENT_USER;
        DateTime TEMP = DateTime.Now;
        #endregion

        #region Constructor
        public ControllerCustomerMasterMaintenance()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerCustomerMasterMaintenance(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region getCustomerMasterList
        public MetaResponse getMaintenanceList(string COMPANY_NO_BOX, string COMPANY_NAME, string COMPANY_NAME_READING, string EDI_ACCOUNT,string MAIL_ADDRESS,string CONTRACTOR,string INVOICE,string SERVICE_DESK,string NOTIFICATION_DESTINATION, int OFFSET, int LIMIT)
        {
            try
            {
                string strMessage = "";
                int TOTAL = 0;
                CUSTOMER_MASTER DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
                DataTable dt = DAL_CUSTOMER_MASTER.getMaintenanceList( COMPANY_NO_BOX, COMPANY_NAME, COMPANY_NAME_READING, EDI_ACCOUNT,MAIL_ADDRESS,CONTRACTOR,INVOICE,SERVICE_DESK,NOTIFICATION_DESTINATION,OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Maintenance List");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There is no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }

                }
                response.Meta.Offset = OFFSET;
                response.Meta.Limit = LIMIT;
                response.Meta.Total = TOTAL;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                response.Message = ex.Message + "/n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

        #region UpdateCustomerMasterMaintenances
        public MetaResponse UpdateCustomerMasterMaintenances(string ClientCertificateList)
        {

            DataTable dgvList = Utility.Utility_Component.JsonToDt(ClientCertificateList);

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                BOL_CUSTOMER_MASTER oCUSTOMER_MMASTER = new BOL_CUSTOMER_MASTER();
                BOL_BANK_ACCOUNT_MASTER oBANK_ACCOUNT_MASTER = new BOL_BANK_ACCOUNT_MASTER();
                oCUSTOMER_MMASTER = Cast_CUSTOMER_MASTER(dgvList.Rows[i]);
                oBANK_ACCOUNT_MASTER = Cast_BANK_ACCOUNT_MASTER(dgvList.Rows[i]);

                switch (dgvList.Rows[i]["MK"].ToString())
                {
                    case "M":
                        HandleModify(oCUSTOMER_MMASTER,oBANK_ACCOUNT_MASTER, "M", dgvList.Rows[i]);
                        break;
                    default:
                        break;
                }
            }

            response.Data = Utility.Utility_Component.DtToJSon(dgvList, "CustomerMaster Update");
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
            return response;
        }
        #endregion

        #region HandleModify
        private void HandleModify(BOL_CUSTOMER_MASTER oCUSTOMER_MASTER,BOL_BANK_ACCOUNT_MASTER oBANK_ACCOUNT_MASTER, string OPERATION, DataRow row)
        {
            string strMsg = "";
            CUSTOMER_MASTER DAL_CUSTOMER_MASTER = new CUSTOMER_MASTER(con);
            
                using (TransactionScope dbTxn = new TransactionScope())
                {
                    
                    //check condition
                    if (!DAL_CUSTOMER_MASTER.IsAlreadyUpdate(oCUSTOMER_MASTER, out strMsg)) // IF updated_at is not already modified
                    {
                        DAL_CUSTOMER_MASTER.CustomerMasterUpdate(oCUSTOMER_MASTER, CURRENT_DATETIME, CURRENT_USER, out strMsg);

                        if (!string.IsNullOrEmpty(strMsg))
                        {
                            dbTxn.Dispose();
                            ResponseUtility.ReturnFailMessage(row);
                            return;
                        }
                    }
                    else
                    {
                        //already use in another process
                        dbTxn.Dispose();
                        ResponseUtility.ReturnFailMessage(row);
                        return;
                    }

                    #region UPDATE BANK_ACCOUNT_MASTER
                    BANK_ACCOUNT_MASTER DAL_BANK_ACCOUNT_MASTER = new BANK_ACCOUNT_MASTER(con);
                    if (!DAL_BANK_ACCOUNT_MASTER.IsAlreadyUpdated(oBANK_ACCOUNT_MASTER, out strMsg)) // If updated_at is not already modified
                    {
                        //insert the record
                        DAL_BANK_ACCOUNT_MASTER.BankAccountMasterUpdate(oBANK_ACCOUNT_MASTER, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                    }
                    else
                    {
                        dbTxn.Dispose();
                        ResponseUtility.ReturnFailMessage(row);
                        return;
                    }

                    //return message and MK value
                    if (String.IsNullOrEmpty(strMsg)) //success
                    {
                        dbTxn.Complete();
                        string S = Convert.ToDateTime(oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE).ToString("yyyy/MM/dd");
                        row["EFFECTIVE_DATE"] = Convert.ToDateTime(oCUSTOMER_MASTER.EFFECTIVE_DATE).ToString("yyyy/MM/dd");
                        row["ORG_EFFECTIVE_DATE"] = Convert.ToDateTime(oCUSTOMER_MASTER.EFFECTIVE_DATE).ToString("yyyy/MM/dd");
                        ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                    }
                    else //failed
                    {
                        dbTxn.Dispose();
                        ResponseUtility.ReturnFailMessage(row);
                    }
                    #endregion
                }

        }
        #endregion

        #region CastToBOL_CUSTOMER_MASTER
        private BOL_CUSTOMER_MASTER Cast_CUSTOMER_MASTER(DataRow row)
        {
            BOL_CUSTOMER_MASTER oCUSTOMER_MASTER = new BOL_CUSTOMER_MASTER();
            
            oCUSTOMER_MASTER.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString().Trim();

            string transaction_type = row["TRANSACTION_TYPE"].ToString().Trim();
            switch (transaction_type)
            {
                case "要元":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 1;
                    break;
                case "サプライヤ":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 2;
                    break;
                case "納代":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 3;
                    break;
                case "生産情報閲覧":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 4;
                    break;
                case "SI":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 11;
                    break;
                case "SOL":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 12;
                    break;
                case "その他":
                    oCUSTOMER_MASTER.TRANSACTION_TYPE = 19;
                    break;
            }
            oCUSTOMER_MASTER.EFFECTIVE_DATE = (DateTime)Utility_Component.dtColumnToDateTime(row["EFFECTIVE_DATE"].ToString().Trim());
            oCUSTOMER_MASTER.ORG_EFFECTIVE_DATE= Utility_Component.dtColumnToDateTime(row["ORG_EFFECTIVE_DATE"].ToString().Trim());
            oCUSTOMER_MASTER.CONTRACT_DATE = Utility_Component.dtColumnToDateTime(row["CONTRACT_DATE"].ToString().Trim());
            oCUSTOMER_MASTER.SPECIAL_NOTES_1 = row["SPECIAL_NOTES_1"].ToString().Trim();
            oCUSTOMER_MASTER.SPECIAL_NOTES_2 = row["SPECIAL_NOTES_2"].ToString().Trim();
            oCUSTOMER_MASTER.SPECIAL_NOTES_3 = row["SPECIAL_NOTES_3"].ToString().Trim();
            oCUSTOMER_MASTER.SPECIAL_NOTES_4 = row["SPECIAL_NOTES_4"].ToString().Trim();
            oCUSTOMER_MASTER.NCS_CUSTOMER_CODE = row["NCS_CUSTOMER_CODE"].ToString().Trim();

            string billingInterval = row["BILL_BILLING_INTERVAL"].ToString();
            switch (billingInterval)
            {
                case "月額":
                    oCUSTOMER_MASTER.BILL_BILLING_INTERVAL = 1;
                    break;
                case "四半期":
                    oCUSTOMER_MASTER.BILL_BILLING_INTERVAL = 2;
                    break;
                case "半期":
                    oCUSTOMER_MASTER.BILL_BILLING_INTERVAL = 3;
                    break;
                case "年額":
                    oCUSTOMER_MASTER.BILL_BILLING_INTERVAL = 4;
                    break;
            }

            string deposit_Rules = row["BILL_DEPOSIT_RULES"].ToString();
            switch (deposit_Rules)
            {
                case "翌月":
                    oCUSTOMER_MASTER.BILL_DEPOSIT_RULES = 0;
                    break;
                case "当月":
                    oCUSTOMER_MASTER.BILL_DEPOSIT_RULES = 1;
                    break;
                case "翌々月月頭":
                    oCUSTOMER_MASTER.BILL_DEPOSIT_RULES = 2;
                    break;
            }

            oCUSTOMER_MASTER.BILL_TRANSFER_FEE = Utility_Component.dtColumnToDecimal(row["BILL_TRANSFER_FEE"].ToString());
            oCUSTOMER_MASTER.BILL_EXPENSES = Utility_Component.dtColumnToDecimal(row["BILL_EXPENSES"].ToString());
            oCUSTOMER_MASTER.COMPANY_NAME_CHANGED_DATE = Utility_Component.dtColumnToDateTime(row["COMPANY_NAME_CHANGED_DATE"].ToString());
            oCUSTOMER_MASTER.PREVIOUS_COMPANY_NAME = row["PREVIOUS_COMPANY_NAME"].ToString();
            oCUSTOMER_MASTER.OBOEGAKI_DATE = Utility_Component.dtColumnToDateTime(row["OBOEGAKI_DATE"].ToString());
            oCUSTOMER_MASTER.UPDATED_AT = row["UPDATED_AT"].ToString().Length >= 1 ? row["UPDATED_AT"].ToString() : null;
            oCUSTOMER_MASTER.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString() == "" ? null : row["UPDATED_AT_RAW"].ToString();
            oCUSTOMER_MASTER.UPDATED_BY = row["UPDATED_BY"].ToString().Length >= 1 ? row["UPDATED_BY"].ToString() : null;
            oCUSTOMER_MASTER.REQ_SEQ = Utility_Component.dtColumnToInt(row["REQ_SEQ"].ToString());
            return oCUSTOMER_MASTER;
        }
        #endregion

        #region CastToBOL_BANK_ACCOUNT_MASTER
        private BOL_BANK_ACCOUNT_MASTER Cast_BANK_ACCOUNT_MASTER(DataRow row)
        {
            BOL_BANK_ACCOUNT_MASTER oBANK_ACCOUNT_MASTER = new BOL_BANK_ACCOUNT_MASTER();

            oBANK_ACCOUNT_MASTER.COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.REQ_SEQ = Utility_Component.dtColumnToInt(row["REQ_SEQ"].ToString().Trim());
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NAME_1 = row["BILL_BANK_ACCOUNT_NAME-1"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NAME_2 = row["BILL_BANK_ACCOUNT_NAME-2"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NAME_3 = row["BILL_BANK_ACCOUNT_NAME-3"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NAME_4 = row["BILL_BANK_ACCOUNT_NAME-4"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NUMBER_1 = row["BILL_BANK_ACCOUNT_NUMBER-1"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NUMBER_2 = row["BILL_BANK_ACCOUNT_NUMBER-2"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NUMBER_3 = row["BILL_BANK_ACCOUNT_NUMBER-3"].ToString().Trim();
            oBANK_ACCOUNT_MASTER.BILL_BANK_ACCOUNT_NUMBER_4 = row["BILL_BANK_ACCOUNT_NUMBER-4"].ToString();
            oBANK_ACCOUNT_MASTER.UPDATED_AT = row["UPDATED_AT"].ToString().Length >= 1 ? row["UPDATED_AT"].ToString() : null;
            oBANK_ACCOUNT_MASTER.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString() == "" ? null : row["UPDATED_AT_RAW"].ToString();
            oBANK_ACCOUNT_MASTER.UPDATED_BY = row["UPDATED_BY"].ToString().Length >= 1 ? row["UPDATED_BY"].ToString() : null;
            return oBANK_ACCOUNT_MASTER;
        }
        #endregion

        #region GetBreakDownScreenData
        public MetaResponse getBreakDownScreenData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            try
            {
                string strMessage = "";
                int TOTAL = 0;
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dt = DAL_REQUEST_DETAIL.getBreakDownScreenData(COMPANY_NO_BOX,REQ_SEQ, out strMessage);

                DataTable dtREQUEST_DETAIL = new DataTable();
                dtREQUEST_DETAIL.Columns.Add("COST", typeof(decimal));
                dtREQUEST_DETAIL.Columns.Add("DISCOUNT", typeof(decimal));
                dtREQUEST_DETAIL.Columns.Add("DIFFERENT", typeof(decimal));

                REQ_USAGE_FEE DAL_REQ_USAGE_FEE = new REQ_USAGE_FEE(con);
                DataTable dtUSAGE_FEE_MASTER = DAL_REQ_USAGE_FEE.getPopUpScreenData(COMPANY_NO_BOX, REQ_SEQ);

                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtREQUEST_DETAIL.NewRow();
                        newRow["COST"] = row["INITIAL_COST"];
                        newRow["DISCOUNT"] = row["MONTHLY_COST"];
                        newRow["DIFFERENT"] = row["YEAR_COST"];
                        dtREQUEST_DETAIL.Rows.Add(newRow);

                        DataRow newRow1 = dtREQUEST_DETAIL.NewRow();
                        string initial = row["INITIAL_COST_DISCOUNTS"].ToString();
                        string monthly = row["MONTHLY_COST_DISCOUNTS"].ToString();
                        string year = row["YEAR_COST_DISCOUNTS"].ToString();
                        if(initial != "0")
                        {
                            newRow1["COST"] = "-" + row["INITIAL_COST_DISCOUNTS"];

                        }
                        else
                        {
                            newRow1["COST"] = row["INITIAL_COST_DISCOUNTS"];
                        }

                        if (monthly != "0")
                        {
                            newRow1["DISCOUNT"] = "-" + row["MONTHLY_COST_DISCOUNTS"];
                        }
                        else
                        {
                            newRow1["DISCOUNT"] = row["MONTHLY_COST_DISCOUNTS"];
                        }

                        if (year != "0")
                        {
                            newRow1["DIFFERENT"] = "-" + row["YEAR_COST_DISCOUNTS"];
                        }
                        else
                        {
                            newRow1["DIFFERENT"] = row["YEAR_COST_DISCOUNTS"];
                        }
                        dtREQUEST_DETAIL.Rows.Add(newRow1);

                        DataRow newRow2 = dtREQUEST_DETAIL.NewRow();
                        newRow2["COST"] = row["INITIAL_COST_DIFF"];
                        newRow2["DISCOUNT"] = row["MONTHLY_COST_DIFF"];
                        newRow2["DIFFERENT"] = row["YEAR_COST_DIFF"];
                        dtREQUEST_DETAIL.Rows.Add(newRow2);
                    }

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    DataRow newRow = dtREQUEST_DETAIL.NewRow();
                    //    newRow["COST"] = row["INITIAL_COST"];
                    //    newRow["DISCOUNT"] = row["INITIAL_COST_DISCOUNTS"];
                    //    newRow["DIFFERENT"] = row["INITIAL_COST_DIFF"];
                    //    dtREQUEST_DETAIL.Rows.Add(newRow);

                    //    DataRow newRow1 = dtREQUEST_DETAIL.NewRow();
                    //    newRow1["COST"] = row["MONTHLY_COST"];
                    //    newRow1["DISCOUNT"] = row["MONTHLY_COST_DISCOUNTS"];
                    //    newRow1["DIFFERENT"] = row["MONTHLY_COST_DIFF"];
                    //    dtREQUEST_DETAIL.Rows.Add(newRow1);

                    //    DataRow newRow2 = dtREQUEST_DETAIL.NewRow();
                    //    newRow2["COST"] = row["YEAR_COST"];
                    //    newRow2["DISCOUNT"] = row["YEAR_COST_DISCOUNTS"];
                    //    newRow2["DIFFERENT"] = row["YEAR_COST_DIFF"];
                    //    dtREQUEST_DETAIL.Rows.Add(newRow2);
                    //}
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dtREQUEST_DETAIL);
                ds.Tables.Add(dtUSAGE_FEE_MASTER);

                response.Data = Utility.Utility_Component.DsToJSon(ds, "Maintenance List");

                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There is no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }

                }
                response.Meta.Total = TOTAL;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                response.Message = ex.Message + "/n" + ex.StackTrace;
                return response;
            }
        }
        #endregion

    }
}