using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AmigoProcessManagement.Controller
{
    public class ControllerMonthlySaleAggregation
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
        public ControllerMonthlySaleAggregation()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }

        public ControllerMonthlySaleAggregation(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }

        #endregion

        #region Get getMonthlySaleAggregationList
        public MetaResponse getMonthlySaleAggregationList(string strDate)
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList.Columns.Add("TotalAmount");
                dtList.Columns.Add("ReduceSales", typeof(decimal));
                dtList.Columns.Add("ReducePlanDeposit", typeof(decimal));
                dtList.Columns.Add("ReduceAcutualDeposit", typeof(decimal));

                dtList.Columns.Add("CurrentSales", typeof(decimal));
                dtList.Columns.Add("CureentPlanDeposit", typeof(decimal));
                dtList.Columns.Add("CurrentAcutualDeposit", typeof(decimal));

                dtList.Columns.Add("PlusSales", typeof(decimal));
                dtList.Columns.Add("PlusPlanDeposit", typeof(decimal));
                dtList.Columns.Add("PlusAcutualDeposit", typeof(decimal));

                dtList.Rows.Add("要        元", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                dtList.Rows.Add("初   期   費", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                dtList.Rows.Add("月額利用料", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                dtList.Rows.Add("生産情報閲覧", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                dtList.Rows.Add("計", "0", "0", "0", "0", "0", "0", "0", "0", "0");


                decimal totalAmount = 0;
                DateTime dtDate = new DateTime();
                dtDate = Convert.ToDateTime(strDate);

                string strDateReduce = dtDate.AddMonths(-1).ToString("yyMM");
                string strDateCurrent = dtDate.ToString("yyMM");
                string strDatePlus = dtDate.AddMonths(1).ToString("yyMM");

                string strMessage = "";
                //int TOTAL = 0;
                INVOICE_INFO DAL_INVOICE_INFO = new INVOICE_INFO(con);


                DataTable dtSaleReduce = DAL_INVOICE_INFO.GetMonthlySaleAggregationSaleList(strDateReduce, out strMessage);
                DataTable dtPlanDepositReduce = DAL_INVOICE_INFO.GetMonthlySaleAggregationPlanDepositList(strDateReduce, out strMessage);
                DataTable dtActualDepositReduce = DAL_INVOICE_INFO.GetMonthlySaleAggregationActualDepositList(strDateReduce, out strMessage);

                DataTable dtSaleCurrent = DAL_INVOICE_INFO.GetMonthlySaleAggregationSaleList(strDateCurrent, out strMessage);
                DataTable dtPlanDepositCurrent = DAL_INVOICE_INFO.GetMonthlySaleAggregationPlanDepositList(strDateCurrent, out strMessage);
                DataTable dtActualDepositCurrent = DAL_INVOICE_INFO.GetMonthlySaleAggregationActualDepositList(strDateCurrent, out strMessage);


                DataTable dtSalePlus = DAL_INVOICE_INFO.GetMonthlySaleAggregationSaleList(strDatePlus, out strMessage);
                DataTable dtPlanDepositPlus = DAL_INVOICE_INFO.GetMonthlySaleAggregationPlanDepositList(strDatePlus, out strMessage);
                DataTable dtActualDepositPlus = DAL_INVOICE_INFO.GetMonthlySaleAggregationActualDepositList(strDatePlus, out strMessage);



                // ReduceSales
                string strMAKER_AMOUNT_TTL = "";
                string strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                string strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                string strPRODUCT_AMOUNT_TTL = "";
                if (!string.IsNullOrEmpty(dtSaleReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtSaleReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtSaleReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtSaleReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtSaleReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["ReduceSales"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["ReduceSales"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["ReduceSales"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["ReduceSales"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["ReduceSales"] = totalAmount;
                // 

                // ReducePlanDeposit
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;
                if (!string.IsNullOrEmpty(dtPlanDepositReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtPlanDepositReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtPlanDepositReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtPlanDepositReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtPlanDepositReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);
                dtList.Rows[0]["ReducePlanDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["ReducePlanDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["ReducePlanDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["ReducePlanDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["ReducePlanDeposit"] = totalAmount;
                //

                // ReduceAcutualDeposit
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtActualDepositReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtActualDepositReduce.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtActualDepositReduce.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtActualDepositReduce.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtActualDepositReduce.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["ReduceAcutualDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["ReduceAcutualDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["ReduceAcutualDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["ReduceAcutualDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["ReduceAcutualDeposit"] = totalAmount;
                //

                //CurrentSales
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtSaleCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtSaleCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtSaleCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtSaleCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSaleCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtSaleCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["CurrentSales"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["CurrentSales"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["CurrentSales"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["CurrentSales"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["CurrentSales"] = totalAmount;

                //

                //CureentPlanDeposit
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtPlanDepositCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtPlanDepositCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtPlanDepositCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtPlanDepositCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtPlanDepositCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["CureentPlanDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["CureentPlanDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["CureentPlanDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["CureentPlanDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["CureentPlanDeposit"] = totalAmount;

                //

                //CurrentAcutualDeposit

                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtActualDepositCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtActualDepositCurrent.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtActualDepositCurrent.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtActualDepositCurrent.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtActualDepositCurrent.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["CurrentAcutualDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["CurrentAcutualDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["CurrentAcutualDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["CurrentAcutualDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["CurrentAcutualDeposit"] = totalAmount;

                // PlusSales
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtSalePlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtSalePlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSalePlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtSalePlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSalePlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtSalePlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtSalePlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtSalePlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["PlusSales"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["PlusSales"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["PlusSales"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["PlusSales"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["PlusSales"] = totalAmount;
                //

                // PlusPlanDeposit
                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtPlanDepositPlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtPlanDepositPlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositPlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtPlanDepositPlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositPlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtPlanDepositPlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtPlanDepositPlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtPlanDepositPlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["PlusPlanDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["PlusPlanDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["PlusPlanDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["PlusPlanDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["PlusPlanDeposit"] = totalAmount;

                //

                //PlusAcutualDeposit

                strMAKER_AMOUNT_TTL = "";
                strSUPPLIER_INTIAL_AMOUNT_TTL = "";
                strSUPPLIER_MONTHLY_AMOUNT_TTL = "";
                strPRODUCT_AMOUNT_TTL = "";
                totalAmount = 0;

                if (!string.IsNullOrEmpty(dtActualDepositPlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString()))
                {
                    strMAKER_AMOUNT_TTL = dtActualDepositPlus.Rows[0]["MAKER_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strMAKER_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositPlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = dtActualDepositPlus.Rows[0]["SUPPLIER_INTIAL_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_INTIAL_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositPlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString()))
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = dtActualDepositPlus.Rows[0]["SUPPLIER_MONTHLY_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strSUPPLIER_MONTHLY_AMOUNT_TTL = "0";
                }
                if (!string.IsNullOrEmpty(dtActualDepositPlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString()))
                {
                    strPRODUCT_AMOUNT_TTL = dtActualDepositPlus.Rows[0]["PRODUCT_AMOUNT_TTL"].ToString();
                }
                else
                {
                    strPRODUCT_AMOUNT_TTL = "0";
                }
                totalAmount = Convert.ToDecimal(strMAKER_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_INTIAL_AMOUNT_TTL) + Convert.ToDecimal(strSUPPLIER_MONTHLY_AMOUNT_TTL) + Convert.ToDecimal(strPRODUCT_AMOUNT_TTL);

                dtList.Rows[0]["PlusAcutualDeposit"] = strMAKER_AMOUNT_TTL;
                dtList.Rows[1]["PlusAcutualDeposit"] = strSUPPLIER_INTIAL_AMOUNT_TTL;
                dtList.Rows[2]["PlusAcutualDeposit"] = strSUPPLIER_MONTHLY_AMOUNT_TTL;
                dtList.Rows[3]["PlusAcutualDeposit"] = strPRODUCT_AMOUNT_TTL;
                dtList.Rows[4]["PlusAcutualDeposit"] = totalAmount;

                //





                response.Data = Utility.Utility_Component.DtToJSon(dtList, "MonthlySaleAggregationList");
                if (dtList.Rows.Count > 0)
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
                //response.Meta.Offset = OFFSET;
                //response.Meta.Limit = LIMIT;
                //response.Meta.Total = TOTAL;
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
    }
}