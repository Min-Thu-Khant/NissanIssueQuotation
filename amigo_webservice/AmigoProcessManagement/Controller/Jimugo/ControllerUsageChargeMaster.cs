using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerUsageChargeMaster
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
        public ControllerUsageChargeMaster()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }
        public ControllerUsageChargeMaster(string authHeader):this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region GetUsageFeeMasterList
        public MetaResponse getUsageFeeMasterList(string CONSTRACT_CODE, string CONSTRACT_NAME, int OFFSET, int LIMIT)
        {
            try
            {
                string strMessage = "";
                int TOTAL = 0;
                USAGE_CHARGE_MASTER DAL_USAGE_CHARGE_MASTER = new USAGE_CHARGE_MASTER(con);
                DataTable dt = DAL_USAGE_CHARGE_MASTER.GetUsageFeeMasterList(CONSTRACT_CODE, CONSTRACT_NAME, OFFSET, LIMIT, out strMessage, out TOTAL);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "UsageFeeMaster");
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
                response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
                return response;
            }
            catch (Exception)
            {
                response.Status = 0;
                response.Message = " Unexpected error occour.";
                return response;
            }
        }
        #endregion

        #region UpdateUsageFeeMasterList
        public MetaResponse UpdateUsageFeeMasterList(string ClientCertificateList)
        {
  
            DataTable dgvList = Utility.Utility_Component.JsonToDt(ClientCertificateList);

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                BOL_USAGE_CHARGE_MASTER oUSAGE_CHARGE_MASTER = new BOL_USAGE_CHARGE_MASTER();
                oUSAGE_CHARGE_MASTER = Cast_USAGE_CHARGE_MASTER(dgvList.Rows[i]);

                switch (dgvList.Rows[i]["MK"].ToString())
                {
                    case "I":
                        HandleInsert(oUSAGE_CHARGE_MASTER, "I", dgvList.Rows[i]);
                        break;
                    case "C":
                        HandleInsert(oUSAGE_CHARGE_MASTER, "C", dgvList.Rows[i]);
                        break;
                    case "M":
                        HandleModify(oUSAGE_CHARGE_MASTER, "M", dgvList.Rows[i]);
                        break;
                    case "D":
                        HandleDelete(oUSAGE_CHARGE_MASTER, dgvList.Rows[i]);
                        break;
                    default:
                        break;
                }
            }

            response.Data = Utility.Utility_Component.DtToJSon(dgvList, "UsageChargeMaster Update");
            timer.Stop();
            response.Meta.Duration = timer.Elapsed.TotalMilliseconds;
            return response;
        }
        #endregion

        #region HandleInsert
        private void HandleInsert(BOL_USAGE_CHARGE_MASTER oUSAGE_CHARGE_MASTER, string OPERATION, DataRow row)
        {
            string strMsg = "";
            USAGE_CHARGE_MASTER DAL_USAGE_CHARGE_MASTER = new USAGE_CHARGE_MASTER(con);
            using (TransactionScope dbTxn = new TransactionScope())
            {
                if (!DAL_USAGE_CHARGE_MASTER.PKKeyCheck(oUSAGE_CHARGE_MASTER, out strMsg)) // IF updated_at is not already modified
                {
                    //delete the record
                    DAL_USAGE_CHARGE_MASTER.Insert(oUSAGE_CHARGE_MASTER, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                }
                else
                {
                    ResponseUtility.ReturnFailMessage(row, String.Format(Utility.Messages.Jimugo.E000ZZ028, "契約コードと採用日の組み合わせ"));
                    return;
                }

                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    dbTxn.Complete();
                    ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }
            }
        }
        #endregion

        #region HandleModify
        private void HandleModify(BOL_USAGE_CHARGE_MASTER oUSAGE_CHARGE_MASTER, string OPERATION, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                USAGE_CHARGE_MASTER DAL_USAGE_CHARGE_MASTER = new USAGE_CHARGE_MASTER(con);
                //check condition
                if (!DAL_USAGE_CHARGE_MASTER.IsAlreadyUpdated(oUSAGE_CHARGE_MASTER, out strMsg)) // IF updated_at is not already modified
                {
                    DAL_USAGE_CHARGE_MASTER.Update(oUSAGE_CHARGE_MASTER, CURRENT_DATETIME, CURRENT_USER, out strMsg);
                }
                else
                {
                    //already use in another process
                    ResponseUtility.ReturnFailMessage(row);
                    return;
                }

                //return message and MK value
                if (String.IsNullOrEmpty(strMsg)) //success
                {
                    dbTxn.Complete();
                    ResponseUtility.ReturnSuccessMessage(row, UPDATED_AT_DATETIME, CURRENT_DATETIME, CURRENT_USER);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }
            }
        }
        #endregion

        #region HandleDelete
        private void HandleDelete(BOL_USAGE_CHARGE_MASTER oUSAGE_CHARGE_MASTER, DataRow row)
        {
            string strMsg = "";
            using (TransactionScope dbTxn = new TransactionScope())
            {
                USAGE_CHARGE_MASTER DAL_USAGE_CHARGE_MASTER = new USAGE_CHARGE_MASTER(con);
                if (!DAL_USAGE_CHARGE_MASTER.IsAlreadyUpdated(oUSAGE_CHARGE_MASTER, out strMsg)) // IF updated_at is not already modified
                {
                    //delete the record
                    DAL_USAGE_CHARGE_MASTER.Delete(oUSAGE_CHARGE_MASTER, out strMsg);
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
                    ResponseUtility.ReturnDeleteSuccessMessage(row);
                }
                else //failed
                {
                    ResponseUtility.ReturnFailMessage(row);
                }
            }
        }
        #endregion

        #region CastToBOL_USAGE_FEE_MASTER
        private BOL_USAGE_CHARGE_MASTER Cast_USAGE_CHARGE_MASTER(DataRow row)
        {
            BOL_USAGE_CHARGE_MASTER oUSAGE_FEE_MASTER = new BOL_USAGE_CHARGE_MASTER();
            string fee_master = row["FEE_STRUCTURE"].ToString().Trim();
            switch (fee_master)
            {
                case "基本契約":
                    oUSAGE_FEE_MASTER.FEE_STRUCTURE = "BASIC";
                    break;
                case "オプション":
                    oUSAGE_FEE_MASTER.FEE_STRUCTURE = "OPTION";
                    break;
                case "サービスデスク":
                    oUSAGE_FEE_MASTER.FEE_STRUCTURE = "SD";
                    break;
                default:
                    oUSAGE_FEE_MASTER.FEE_STRUCTURE = null;
                    break;
            }
            //oUSAGE_FEE_MASTER.FEE_STRUCTURE = row["FEE_STRUCTURE"].ToString();
            oUSAGE_FEE_MASTER.CONTRACT_CODE = row["CONTRACT_CODE"].ToString().Trim();
            oUSAGE_FEE_MASTER.CONTRACT_NAME = row["CONTRACT_NAME"].ToString().Trim();
            oUSAGE_FEE_MASTER.CONTRACT_QTY = Utility_Component.dtColumnToInt(row["CONTRACT_QTY"].ToString().Trim());
            oUSAGE_FEE_MASTER.CONTRACT_UNIT = row["CONTRACT_UNIT"].ToString().Trim();
            oUSAGE_FEE_MASTER.ADOPTION_DATE = Utility_Component.dtColumnToDateTime(row["ADOPTION_DATE"].ToString().Trim());
            oUSAGE_FEE_MASTER.INITIAL_COST = Utility_Component.dtColumnToDecimal(row["INITIAL_COST"].ToString().Trim());
            oUSAGE_FEE_MASTER.MONTHLY_COST = Utility_Component.dtColumnToDecimal(row["MONTHLY_COST"].ToString().Trim());

            string input_type = row["INPUT_TYPE"].ToString();
            switch (input_type)
            {
                case "選択":
                    oUSAGE_FEE_MASTER.INPUT_TYPE = 1;
                    break;
                case "数量":
                    oUSAGE_FEE_MASTER.INPUT_TYPE = 2;
                    break;
                default:
                    oUSAGE_FEE_MASTER.INPUT_TYPE = null;
                    break;
            }

            //oUSAGE_FEE_MASTER.INPUT_TYPE = Utility_Component.dtColumnToInt(row["INPUT_TYPE"].ToString());
            oUSAGE_FEE_MASTER.NUMBER_DEFAULT = Utility_Component.dtColumnToInt(row["NUMBER_DEFAULT"].ToString());
            oUSAGE_FEE_MASTER.MEMO = row["MEMO"].ToString();
            oUSAGE_FEE_MASTER.DISPLAY_ORDER = Utility_Component.dtColumnToInt(row["DISPLAY_ORDER"].ToString());
            oUSAGE_FEE_MASTER.UPDATED_AT = row["UPDATED_AT"].ToString().Length >= 1 ? row["UPDATED_AT"].ToString() : null;
            oUSAGE_FEE_MASTER.UPDATED_AT_RAW = row["UPDATED_AT_RAW"].ToString() == "" ? null : row["UPDATED_AT_RAW"].ToString();
            oUSAGE_FEE_MASTER.UPDATED_BY = row["UPDATED_BY"].ToString().Length >= 1 ? row["UPDATED_BY"].ToString() : null;

            return oUSAGE_FEE_MASTER;
        }
        #endregion
    }
}