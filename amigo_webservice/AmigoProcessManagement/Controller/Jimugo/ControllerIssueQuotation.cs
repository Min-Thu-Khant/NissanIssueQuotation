using System.Data;
using AmigoProcessManagement.Utility;
using System.Diagnostics;
using Spire.Xls;
using System.IO;
using System.Web;
using DAL_AmigoProcess.DAL;
using System;
using DAL_AmigoProcess.BOL;
using System.Collections.Generic;
using Ionic.Zip;
using System.Transactions;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Spire.Xls.Core.Spreadsheet.Shapes;
using NodaTime;

namespace AmigoProcessManagement.Controller
{
    public class ControllerIssueQuotation
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
        public ControllerIssueQuotation()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            UPDATED_AT_DATETIME = TEMP.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = TEMP.ToString("yyyyMMddHHmmss");
        }
        public ControllerIssueQuotation(string authHeader) : this()
        {
            CURRENT_USER = Utility_Component.DecodeAuthHeader(authHeader)[0];
        }
        #endregion

        #region getIntitialData
        public MetaResponse getIntitialData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            try
            {
                string strMessage = "";
                REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                DataTable dt = DAL_REQUEST_DETAIL.GetInitialData(COMPANY_NO_BOX, REQ_SEQ, out strMessage);

                response.Data = Utility.Utility_Component.DtToJSon(dt, "InitialData");
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

                timer.Stop();
                response.Meta.Duration = timer.Elapsed.TotalSeconds;
                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region PreviewFunction
        public MetaResponse DoPreview(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string startDate, string expireDate,
           string strPeroidFrom, string strPeroidTo, string strExportInfo, string strContractPlan, string INITIAL_REMARK, string MONTHLY_REMARK, string PI_REMARK, string ORDER_REMARK)
        {
            try
            {
                //message for pop up
                DataTable messagecode = new DataTable();
                messagecode.Columns.Add("Message");
                messagecode.Columns.Add("Error Message");
                DataRow dr = messagecode.NewRow();

                response = getPDF(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, startDate, expireDate, strPeroidFrom, strPeroidTo, strExportInfo, strContractPlan, INITIAL_REMARK, MONTHLY_REMARK, PI_REMARK, ORDER_REMARK);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }

        #endregion

        #region PDF Create
        public MetaResponse getPDF(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string startDate,
            string expireDate, string strPeroidFrom, string strPeroidTo, string strExportInfo, string strContractPlan,
            string INITIAL_REMARK, string MONTHLY_REMARK, string PI_REMARK, string ORDER_REMARK)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("ExportType");
            result.Columns.Add("FILENAME");
            result.Columns.Add("Created Time");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");

            DataTable dtExportInfo = Utility_Component.JsonToDt(strExportInfo);

            for (int i = 0; i < dtExportInfo.Rows.Count; i++)
            {
                string strExportType = dtExportInfo.Rows[i]["ExportType"] == null ? "" : dtExportInfo.Rows[i]["ExportType"].ToString();
                decimal decDiscount = (decimal)0;
                decimal.TryParse(dtExportInfo.Rows[i]["SpecialDiscount"] == null ? "0" : dtExportInfo.Rows[i]["SpecialDiscount"].ToString(), out decDiscount);
                DataTable single_result = new DataTable();

                switch (strExportType)
                {
                    case "1":
                        single_result = Preview_InitialQuotation(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, expireDate, INITIAL_REMARK, decDiscount, strContractPlan);
                        break;
                    case "2":
                        single_result = Preview_MonthlyQuotation(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, startDate, expireDate, MONTHLY_REMARK, decDiscount, strContractPlan);
                        break;
                    case "4":
                        single_result = Preview_PIBrowsing(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, startDate, expireDate, PI_REMARK, strPeroidFrom, strPeroidTo, decDiscount, strContractPlan);
                        break;
                    case "3":
                        single_result = Preview_OrderForm(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, TaxAmt, ORDER_REMARK, strPeroidFrom, strPeroidTo, decDiscount, strContractPlan);
                        break;
                }
                result.Rows.Add(strExportType,
                    single_result.Rows.Count > 0 ? single_result.Rows[0]["FILENAME"] : "",
                    CURRENT_DATETIME,
                    single_result.Rows.Count > 0 ? single_result.Rows[0]["Message"] : "",
                    single_result.Rows.Count > 0 ? single_result.Rows[0]["Error Message"] : "");
            }

            response.Data = Utility.Utility_Component.DtToJSon(result, "pdfData");
            response.Status = 1;
            return response;
        }

        #endregion

        #region Preview_InitialQuotation
        protected DataTable Preview_InitialQuotation(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string expireDate, string REMARK, decimal decDiscount, string CONTRACT_PLAN)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("FILENAME");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");

            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Initialquotation.Normal"));
            string strRPTTYPE = "1";
            string strSubject = "Amigo Cloud EDI 初期費用";
            string strExtraCondition = "WHERE subQ2.TYPE = 1";
            string FILENAME =  COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ + "_御見積書_" + COMPANY_NAME + "様_" + CURRENT_DATETIME;

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, CONTRACT_PLAN, strExtraCondition, out strMessage);
            //TYPE 1 CHECK
            var Type1 = from myRow in dt.AsEnumerable()
                        where myRow.Field<int>("TYPE") == 1
                        select myRow;

            if (Type1.Any())
            {
                DataTable dtBasic = new DataTable();
                DataTable dtOption = new DataTable();
                DataTable dtSD = new DataTable();

                var BASIC = from myRow in dt.AsEnumerable()
                            where myRow.Field<string>("FEE_STRUCTURE").Trim() == "BASIC"
                            select myRow;
                var OPTION = from myRow in dt.AsEnumerable()
                             where myRow.Field<string>("FEE_STRUCTURE").Trim() == "OPTION"
                             select myRow;
                var SD = from myRow in dt.AsEnumerable()
                         where myRow.Field<string>("FEE_STRUCTURE").Trim() == "SD"
                         select myRow;

                Worksheet sheet = workbook.Worksheets[0];
                int intHeaderStart = 28;
                int intItemStart = 29;
                decimal decTotal = 0;

                #region Header Information
                sheet.Range["J2"].Text = "No." + COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ;
                sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
                sheet.Range["A5"].Text = COMPANY_NAME + " 御中";

                sheet.Range["F11"].Text = strSubject;//4

                sheet.Range["F15"].Text = "発行日からＸＸ日間有効".Replace("ＸＸ", expireDate.ToString());//9
                #endregion

                #region Basic Large Header
                int intHeaderNumberSerial = 0;
                if (BASIC.Any())
                {
                    dtBasic = BASIC.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                    sheet.Range["F" + intHeaderStart.ToString()].Text = "初期費用";

                    for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        int intQuantity = int.Parse(dtBasic.Rows[itemIndex]["QUANTITY"] == null ? "" : dtBasic.Rows[itemIndex]["QUANTITY"].ToString());
                        decimal initial_cost = 0;
                        initial_cost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());

                        string strCombine = "";
                        if (!string.IsNullOrEmpty(strContractUnit))
                        {
                            strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString(): "") + strContractUnit + "]";
                        }

                        decTotal = decTotal + (initial_cost * intQuantity);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine;
                        sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        intHeaderStart++;
                    }
                    intItemStart = intItemStart + 2;
                    intHeaderStart = intHeaderStart + 2;
                }
                #endregion

                #region Option Large Header
                if (OPTION.Any())
                {
                    dtOption = OPTION.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "オプションプラン";
                    sheet.Range["F" + intHeaderStart.ToString()].Text = "初期費用";
                    for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        int intQuantity = int.Parse(dtOption.Rows[itemIndex]["QUANTITY"] == null ? "" : dtOption.Rows[itemIndex]["QUANTITY"].ToString());
                        decimal initial_cost = 0;
                        initial_cost = decimal.Parse(dtOption.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtOption.Rows[itemIndex]["INITIAL_COST"].ToString());
                        string strCombine = "";
                        if (!string.IsNullOrEmpty(strContractUnit))
                        {
                            strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                        }

                        decTotal = decTotal + (initial_cost * intQuantity);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine;
                        sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        intHeaderStart++;
                    }
                    intItemStart = intItemStart + 2;
                    intHeaderStart = intHeaderStart + 2;
                }
                #endregion

                #region SD Large Header
                if (SD.Any())
                {
                    dtSD = SD.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "サービスデスク";
                    sheet.Range["F" + intHeaderStart.ToString()].Text = "初期費用";
                    for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtSD.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtSD.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtSD.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtSD.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        int intQuantity = int.Parse(dtSD.Rows[itemIndex]["QUANTITY"] == null ? "" : dtSD.Rows[itemIndex]["QUANTITY"].ToString());
                        decimal initial_cost = 0;
                        initial_cost = decimal.Parse(dtSD.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtSD.Rows[itemIndex]["INITIAL_COST"].ToString());
                        string strCombine = "";
                        if (!string.IsNullOrEmpty(strContractUnit))
                        {
                            strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                        }

                        decTotal = decTotal + (initial_cost * intQuantity);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine;
                        sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        intHeaderStart++;
                    }
                    intItemStart = intItemStart + 2;
                    intHeaderStart = intHeaderStart + 2;
                }
                #endregion

                #region Special Discount
                if (decDiscount != 0)
                {
                    sheet.Range["B42"].Text = (intHeaderNumberSerial + 1).ToString();
                    sheet.Range["C42"].Text = "特別値引き";
                    sheet.Range["J42"].Text = decDiscount.ToString("N0");
                    sheet.Range["J42"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                }
                #endregion

                #region GrandTotal
                sheet.Range["J43"].Text = "¥" + (decTotal + decDiscount).ToString("N0");
                sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                #endregion

                #region Header Amount 
                decimal tax_amount = Utility_Component.RoundedDown((decTotal + decDiscount) * (TaxAmt * (decimal)0.01));
                decimal amount = decTotal + decDiscount;
                sheet.Range["F12"].Text = "¥" + amount.ToString("N0");
                sheet.Range["F13"].Text = "¥" + tax_amount.ToString("N0");
                sheet.Range["F14"].Text = "¥" + (amount + tax_amount).ToString("N0");//7
                sheet.Range["F12:F14"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                #endregion

                #region Remark
                XlsRectangleShape shape = sheet.RectangleShapes[4] as XlsRectangleShape;
                shape.Text += "\n" + REMARK;
                #endregion

                BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
                String tempStorageFolder = config.getStringValue("temp.dir");
                string savePath = tempStorageFolder + "/" + FILENAME + ".pdf";

                //Save excel file to pdf file.  
                workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);


                DataRow dr = result.NewRow();
                dr["FILENAME"] = FILENAME + ".pdf";
                result.Rows.Add(dr);
            }
            else
            {
                DataRow dr = result.NewRow();
                dr["Error Message"] = string.Format(Messages.Jimugo.E000WB034, "初期見積書");
                result.Rows.Add(dr);
            }

            return result;
        }
        #endregion

        #region Preview_MonthlyQuotation
        protected DataTable Preview_MonthlyQuotation(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string startDate, string expireDate, string REMARK, decimal decDiscount, string CONTRACT_PLAN)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("FILENAME");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");

            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Monthlyquotation.Normal"));
            string strRPTTYPE = "2";
            string strSubject = "Amigo Cloud EDI 月額利用料";
            string strExtraCondition = "WHERE subQ2.TYPE = 2 OR subQ2.TYPE IS NULL";
            string FILENAME = COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ + "_御見積書_" + COMPANY_NAME + "様_" + CURRENT_DATETIME;

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, CONTRACT_PLAN, strExtraCondition, out strMessage);
            DataTable dtBasic = new DataTable();
            DataTable dtOption = new DataTable();
            DataTable dtSD = new DataTable();

            var BASIC = from myRow in dt.AsEnumerable()
                        where myRow.Field<string>("FEE_STRUCTURE").Trim() == "BASIC"
                        select myRow;
            var OPTION = from myRow in dt.AsEnumerable()
                         where myRow.Field<string>("FEE_STRUCTURE").Trim() == "OPTION"
                         select myRow;
            var SD = from myRow in dt.AsEnumerable()
                     where myRow.Field<string>("FEE_STRUCTURE").Trim() == "SD"
                     select myRow;

            Worksheet sheet = workbook.Worksheets[0];
            int intHeaderStart = 28;
            int intItemStart = 29;
            decimal decTotal = 0;

            #region Header Information
            sheet.Range["J2"].Text = "No." + COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME + " 御中";

            sheet.Range["F11"].Text = strSubject;//4

            DateTime StartDate = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            sheet.Range["F15"].Text = StartDate.Year.ToString() + "年" + StartDate.Month.ToString("00") + "月" + StartDate.Day.ToString("00") + "日"; ;//8
            sheet.Range["F16"].Text = "'発行日からＸＸ日間有効".Replace("ＸＸ", expireDate.ToString());//9
            #endregion

            #region Basic Large Header
            int intHeaderNumberSerial = 0;
            if (BASIC.Any())
            {
                dtBasic = BASIC.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                sheet.Range["F" + intHeaderStart.ToString()].Text = "月額利用料"; 

                for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                {
                    string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    int intQuantity = int.Parse(dtBasic.Rows[itemIndex]["QUANTITY"] == null ? "" : dtBasic.Rows[itemIndex]["QUANTITY"].ToString());
                    decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_COST"].ToString());
                    string strCombine = "";
                    if (!string.IsNullOrEmpty(strContractUnit))
                    {
                        strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                    }

                    decTotal = decTotal + (decCost * intQuantity);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                    sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intQuantity).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intItemStart = intItemStart + 2;
                intHeaderStart = intHeaderStart + 2;
            }
            #endregion

            #region Option Large Header
            if (OPTION.Any())
            {
                dtOption = OPTION.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "オプションプラン";
                sheet.Range["F" + intHeaderStart.ToString()].Text = "月額利用料";
                for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                {
                    string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    string strContractUnit = (dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    int intQuantity = int.Parse(dtOption.Rows[itemIndex]["QUANTITY"] == null ? "" : dtOption.Rows[itemIndex]["QUANTITY"].ToString());
                    decimal decCost = decimal.Parse(dtOption.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtOption.Rows[itemIndex]["MONTHLY_COST"].ToString());
                    string strCombine = "";
                    if (!string.IsNullOrEmpty(strContractUnit))
                    {
                        strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                    }

                    decTotal = decTotal + (decCost * intQuantity);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                    sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intQuantity).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intItemStart = intItemStart + 2;
                intHeaderStart = intHeaderStart + 2;
            }
            #endregion

            #region SD Large Header
            if (SD.Any())
            {
                dtSD = SD.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "サービスデスク";
                sheet.Range["F" + intHeaderStart.ToString()].Text = "月額利用料";
                for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                {
                    string strItemText = dtSD.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    string strContractUnit = (dtSD.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtSD.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtSD.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    int intQuantity = int.Parse(dtSD.Rows[itemIndex]["QUANTITY"] == null ? "" : dtSD.Rows[itemIndex]["QUANTITY"].ToString());
                    decimal decCost = decimal.Parse(dtSD.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtSD.Rows[itemIndex]["MONTHLY_COST"].ToString());
                    string strCombine = "";
                    if (!string.IsNullOrEmpty(strContractUnit))
                    {
                        strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                    }
                    decTotal = decTotal + (decCost * intQuantity);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                    sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intQuantity).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intHeaderStart++;
            }
            #endregion

            #region Special Discount
            if (decDiscount != 0)
            {
                sheet.Range["B42"].Text = (intHeaderNumberSerial + 1).ToString();
                sheet.Range["C42"].Text = "特別値引き";
                sheet.Range["J42"].Text = decDiscount.ToString("N0");
                sheet.Range["J42"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            }
            #endregion

            #region GrandTotal
            sheet.Range["J43"].Text = "¥" + (decTotal + decDiscount).ToString("N0");
            sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Header Amount 
            decimal tax_amount = Utility_Component.RoundedDown((decTotal + decDiscount) * (TaxAmt * (decimal)0.01));
            decimal amount = decTotal + decDiscount;
            sheet.Range["F12"].Text = "¥" + amount.ToString("N0");
            sheet.Range["F13"].Text = "¥" + tax_amount.ToString("N0");
            sheet.Range["F14"].Text = "¥" + (amount + tax_amount).ToString("N0");//7
            sheet.Range["F12:F14"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Remark
            XlsRectangleShape shape = sheet.RectangleShapes[4] as XlsRectangleShape;
            shape.Text += "\n" + REMARK;
            #endregion

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = tempStorageFolder + "/" + FILENAME + ".pdf";

            //Save excel file to pdf file.  
            workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);


            DataRow dr = result.NewRow();
            dr["FILENAME"] = FILENAME + ".pdf";
            result.Rows.Add(dr);

            return result;
        }
        #endregion

        #region Preview_PIBrowsing
        protected DataTable Preview_PIBrowsing(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string startDate,
            string expireDate, string REMARK, string strPeroidFrom, string strPeroidTo, decimal decDiscount, string CONTRACT_PLAN)
        {
            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Initialquotation.Normal"));
            string strRPTTYPE = "1";
            string strSubject = "Amigo Cloud EDI 生産情報閲覧";
            string strExtraCondition = "WHERE subQ2.TYPE IN (1,3)";
            string FILENAME =  COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ + "_御見積書_" + COMPANY_NAME + "様_" + CURRENT_DATETIME;


            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, CONTRACT_PLAN, strExtraCondition, out strMessage);

            Worksheet sheet = workbook.Worksheets[0];
            int intHeaderStart = 28;
            int intItemStart = 29;
            decimal decTotal = 0;

            #region Header Information
            sheet.Range["J2"].Text = "No." + COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME;

            sheet.Range["F11"].Text = strSubject;//4

            DateTime StartDate = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            sheet.Range["F15"].Text = StartDate.Year.ToString() + "年" + StartDate.Month.ToString("00") + "月" + StartDate.Day.ToString("00") + "日"; ;//8
            sheet.Range["F16"].Text = "'発行日からＸＸ日間有効".Replace("ＸＸ", expireDate.ToString());//9
            #endregion

            #region Table
            int intHeaderNumberSerial = 0;
            if (dt.Rows.Count > 0)
            {
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = strSubject;

                var Type1 = from myRow in dt.AsEnumerable()
                            where myRow.Field<int?>("TYPE") == 1 && myRow.Field<string>("CONTRACT_CODE").Trim() != "PRODUCT"
                            select myRow;

                var Type3 = from myRow in dt.AsEnumerable()
                            where myRow.Field<int?>("TYPE") == 3 && myRow.Field<string>("CONTRACT_CODE").Trim() != "PRODUCT"
                            select myRow;
                intItemStart++;
                if (Type1.Any())
                {
                    DataTable dtType1 = Type1.CopyToDataTable();
                    sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                    intItemStart++;
                    for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                    {
                        decimal initial_cost = decimal.Parse(dtType1.Rows[itemIndex]["INITIAL_COST"] == null ? "0" : dtType1.Rows[itemIndex]["INITIAL_COST"].ToString());
                        decimal initial_expense = decimal.Parse(dtType1.Rows[itemIndex]["INITIAL_EXPENSE"] == null ? "0" : dtType1.Rows[itemIndex]["INITIAL_EXPENSE"].ToString());
                        string strItemText = dtType1.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtType1.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtType1.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtType1.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtType1.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtType1.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        int intQuantity = int.Parse(dtType1.Rows[itemIndex]["QUANTITY"] == null ? "" : dtType1.Rows[itemIndex]["QUANTITY"].ToString());
                        string strCombine = "";
                        if (!string.IsNullOrEmpty(strContractUnit))
                        {
                            strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                        }
                        decTotal = decTotal + initial_expense;
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                        sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = initial_expense.ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                    }
                }
                if (Type3.Any())
                {
                    intItemStart++;
                    DataTable dtType3 = Type3.CopyToDataTable();

                    DateTime dtmFromDate = DateTime.ParseExact(strPeroidFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                    DateTime dtmToDate = DateTime.ParseExact(strPeroidTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                    int intTotalMonth = CalcuateTotalMonths(dtmFromDate, dtmToDate);

                    sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                    intItemStart++;


                    for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                    {
                        
                        decimal monthly_cost = decimal.Parse(dtType3.Rows[itemIndex]["MONTHLY_COST"] == null ? "0" : dtType3.Rows[itemIndex]["MONTHLY_COST"].ToString());
                        decimal monthly_usage_fee = decimal.Parse(dtType3.Rows[itemIndex]["MONTHLY_USAGE_FEE"] == null ? "0" : dtType3.Rows[itemIndex]["MONTHLY_USAGE_FEE"].ToString());
                        string strItemText = dtType3.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtType3.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtType3.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtType3.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtType3.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtType3.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        int intQuantity = int.Parse(dtType3.Rows[itemIndex]["QUANTITY"] == null ? "" : dtType3.Rows[itemIndex]["QUANTITY"].ToString());
                        string strCombine = "";
                        if (!string.IsNullOrEmpty(strContractUnit))
                        {
                            strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                        }
                        decTotal = decTotal + (monthly_usage_fee * intTotalMonth);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                        sheet.Range["H" + intItemStart.ToString()].Text = intQuantity.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = monthly_cost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (monthly_usage_fee * intTotalMonth).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "～" + dtmToDate.ToString("yyyy/M/d");
                        intItemStart++;
                    }
                }
                intHeaderStart++;
            }
            #endregion

            #region Special Discount
            if (decDiscount != 0)
            {
                sheet.Range["B42"].Text = (intHeaderNumberSerial + 1).ToString();
                sheet.Range["C42"].Text = "特別値引き";
                sheet.Range["J42"].Text = decDiscount.ToString("N0");
                sheet.Range["J42"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            }
            #endregion

            #region GrandTotal
            sheet.Range["J43"].Text = "¥" + (decTotal + decDiscount).ToString("N0");
            sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Header Amount 
            decimal tax_amount = Utility_Component.RoundedDown((decTotal + decDiscount) * (TaxAmt * (decimal)0.01));
            decimal amount = decTotal + decDiscount;
            sheet.Range["F12"].Text = "¥" + amount.ToString("N0");
            sheet.Range["F13"].Text = "¥" + tax_amount.ToString("N0");
            sheet.Range["F14"].Text = "¥" + (amount + tax_amount).ToString("N0");//7
            sheet.Range["F12:F14"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Remark
            XlsRectangleShape shape = sheet.RectangleShapes[4] as XlsRectangleShape;
            shape.Text += "\n" + REMARK;
            #endregion

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = tempStorageFolder + "/" + FILENAME + ".pdf";

            //Save excel file to pdf file.  
            workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);


            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("FILENAME");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");
            DataRow dr = result.NewRow();
            dr["FILENAME"] = FILENAME + ".pdf";
            result.Rows.Add(dr);

            return result;
        }
        #endregion        

        #region Preview_OrderForm
        protected DataTable Preview_OrderForm(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, decimal TaxAmt, string REMARK, string strPeroidFrom, string strPeroidTo, decimal decDiscount, string CONTRACT_PLAN)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("FILENAME");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");

            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            string strSubject = CONTRACT_PLAN == "PRODUCT" ? "Amigo Cloud EDI 生産情報閲覧" : "Amigo Cloud EDI 初期費用";
            string strRPTTYPE = "1";
            string file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Purchaseorder.Normal"));
            string FILENAME = COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ + "_注文書_" + COMPANY_NAME + "様_" + CURRENT_DATETIME;
            string strExtraCondition = "WHERE subQ2.TYPE IN (1,3)";
            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, CONTRACT_PLAN, strExtraCondition, out strMessage);

            //TYPE 1 CHECK
            var Type_1 = from myRow in dt.AsEnumerable()
                         where myRow.Field<int>("TYPE") == 1
                         select myRow;

            if (Type_1.Any())
            {
                DataTable dtBasic = new DataTable();
                DataTable dtOption = new DataTable();
                DataTable dtSD = new DataTable();

                var BASIC = from myRow in dt.AsEnumerable()
                            where (myRow.Field<string>("FEE_STRUCTURE") == null ? "" : myRow.Field<string>("FEE_STRUCTURE").Trim()) == "BASIC"
                            select myRow;
                var OPTION = from myRow in dt.AsEnumerable()
                             where (myRow.Field<string>("FEE_STRUCTURE") == null ? "" : myRow.Field<string>("FEE_STRUCTURE").Trim()) == "OPTION"
                             select myRow;
                var SD = from myRow in dt.AsEnumerable()
                         where (myRow.Field<string>("FEE_STRUCTURE") == null ? "" : myRow.Field<string>("FEE_STRUCTURE").Trim()) == "SD"
                         select myRow;

                Worksheet sheet = workbook.Worksheets[0];
                int intHeaderStart = 23;
                int intItemStart = 24;
                decimal decTotal = 0;

                BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
                String tempStorageFolder = config.getStringValue("temp.dir");
                string savePath = tempStorageFolder + "/" + FILENAME + ".pdf";

                #region Header Information

                sheet.Range["E9"].Text = strSubject;//4

                #endregion

                if (CONTRACT_PLAN != "PRODUCT") // Initial Quotation
                {
                    #region Table Initial Data Put
                    #region Basic Large Header
                    int intHeaderNumberSerial = 0;
                    if (BASIC.Any())
                    {
                        dtBasic = BASIC.CopyToDataTable();
                        sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                        intHeaderNumberSerial++;
                        sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                        sheet.Range["G" + intHeaderStart.ToString()].Text = "初期費用";

                        for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                        {
                            string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                            int intQuantity = int.Parse(dtBasic.Rows[itemIndex]["QUANTITY"] == null ? "" : dtBasic.Rows[itemIndex]["QUANTITY"].ToString());
                            decimal initial_cost = 0;
                            initial_cost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                            string strCombine = "";
                            if (!string.IsNullOrEmpty(strContractUnit))
                            {
                                strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                            }

                            decTotal = decTotal + (initial_cost * intQuantity);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine;
                            sheet.Range["I" + intItemStart.ToString()].Text = intQuantity.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["K" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                            sheet.Range["K" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            intHeaderStart++;
                        }
                        intItemStart = intItemStart + 2;
                        intHeaderStart = intHeaderStart + 2;
                    }
                    #endregion

                    #region Option Large Header
                    if (OPTION.Any())
                    {
                        dtOption = OPTION.CopyToDataTable();
                        sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                        intHeaderNumberSerial++;
                        sheet.Range["C" + intHeaderStart.ToString()].Text = "オプションプラン";
                        sheet.Range["F" + intHeaderStart.ToString()].Text = "初期費用";
                        for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                        {
                            string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                            int intQuantity = int.Parse(dtOption.Rows[itemIndex]["QUANTITY"] == null ? "" : dtOption.Rows[itemIndex]["QUANTITY"].ToString());
                            decimal initial_cost = 0;
                            initial_cost = decimal.Parse(dtOption.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtOption.Rows[itemIndex]["INITIAL_COST"].ToString());
                            string strCombine = "";
                            if (!string.IsNullOrEmpty(strContractUnit))
                            {
                                strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                            }
                            decTotal = decTotal + (initial_cost * intQuantity);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine;
                            sheet.Range["I" + intItemStart.ToString()].Text = intQuantity.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["K" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                            sheet.Range["K" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            intHeaderStart++;
                        }
                        intItemStart = intItemStart + 2;
                        intHeaderStart = intHeaderStart + 2;
                    }
                    #endregion

                    #region SD Large Header
                    if (SD.Any())
                    {
                        dtSD = SD.CopyToDataTable();
                        sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                        intHeaderNumberSerial++;
                        sheet.Range["C" + intHeaderStart.ToString()].Text = "サービスデスク";
                        sheet.Range["F" + intHeaderStart.ToString()].Text = "初期費用";
                        for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                        {
                            string strItemText = dtSD.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtSD.Rows[itemIndex]["CONTRACT_UNIT"] == null ? null : dtSD.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtSD.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtSD.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                            int intQuantity = int.Parse(dtSD.Rows[itemIndex]["QUANTITY"] == null ? "" : dtSD.Rows[itemIndex]["QUANTITY"].ToString());
                            string strContractQTY = "";
                            decimal initial_cost = 0;
                            initial_cost = decimal.Parse(dtSD.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtSD.Rows[itemIndex]["INITIAL_COST"].ToString());
                            if (!string.IsNullOrEmpty(strContractUnit))
                            {
                                strContractUnit = " [契約単位 " + strContractUnit + "]";
                            }

                            if (intContractQTY > 1)
                            {
                                strContractQTY = " [契約数量 " + intContractQTY.ToString() + "]";
                            }
                            decTotal = decTotal + (initial_cost * intQuantity);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strContractQTY + strContractUnit; ;
                            sheet.Range["I" + intItemStart.ToString()].Text = intQuantity.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["K" + intItemStart.ToString()].Text = (initial_cost * intQuantity).ToString("N0");
                            sheet.Range["K" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            intHeaderStart++;
                        }
                        intItemStart = intItemStart + 2;
                        intHeaderStart = intHeaderStart + 2;
                    }
                    #endregion

                    #region Special Discount
                    if (decDiscount != 0)
                    {
                        sheet.Range["B42"].Text = (intHeaderNumberSerial + 1).ToString();
                        sheet.Range["C42"].Text = "特別値引き";
                        sheet.Range["K42"].Text = decDiscount.ToString("N0");
                        sheet.Range["K42"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    }
                    #endregion

                    #region GrandTotal
                    sheet.Range["K43"].Text = "¥" + (decTotal + decDiscount).ToString("N0");
                    sheet.Range["K43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    #endregion

                    #region Header Amount 
                    decimal tax_amount = Utility_Component.RoundedDown((decTotal + decDiscount) * (TaxAmt * (decimal)0.01));
                    decimal amount = decTotal + decDiscount;

                    sheet.Range["E10"].Text = "¥" + amount.ToString("N0"); //5
                    sheet.Range["E10"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["G10"].Text = "-";
                    sheet.Range["G10"].Style.HorizontalAlignment = HorizontalAlignType.Left;

                    sheet.Range["E11"].Text = "¥" + tax_amount.ToString("N0");//6
                    sheet.Range["G11"].Text = "-";
                    sheet.Range["G11"].Style.HorizontalAlignment = HorizontalAlignType.Left;

                    sheet.Range["E12"].Text = "¥" + (amount + tax_amount).ToString("N0");//7
                    sheet.Range["G12"].Text = "-";
                    sheet.Range["G12"].Style.HorizontalAlignment = HorizontalAlignType.Left;
                    #endregion

                    #region Remark
                    XlsRectangleShape shape = sheet.RectangleShapes[1] as XlsRectangleShape;
                    shape.Text += "\n" + REMARK;
                    #endregion

                    sheet.Range["K50"].Text = "No." + COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ;
                    #endregion

                    //Save excel file to pdf file.  
                    workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);


                    DataRow dr = result.NewRow();
                    dr["FILENAME"] = FILENAME + ".pdf";
                    result.Rows.Add(dr);
                }
                else if (CONTRACT_PLAN == "PRODUCT") //PIBrowsing
                {
                    #region Table PI Browsing Data Put
                    #region Table
                    int intHeaderNumberSerial = 0;
                    if (dt.Rows.Count > 0)
                    {
                        sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                        intHeaderNumberSerial++;
                        sheet.Range["C" + intHeaderStart.ToString()].Text = strSubject;

                        var Type1 = from myRow in dt.AsEnumerable()
                                    where myRow.Field<int>("TYPE") == 1 && myRow.Field<string>("CONTRACT_CODE").Trim() != "PRODUCT"
                                    select myRow;

                        var Type3 = from myRow in dt.AsEnumerable()
                                    where myRow.Field<int>("TYPE") == 3 && myRow.Field<string>("CONTRACT_CODE").Trim() != "PRODUCT"
                                    select myRow;
                        intItemStart++;
                        if (Type1.Any())
                        {
                            DataTable dtType1 = Type1.CopyToDataTable();
                            sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                            intItemStart++;
                            for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                            {
                                decimal initial_cost = decimal.Parse(dtType1.Rows[itemIndex]["INITIAL_COST"] == null ? "0" : dtType1.Rows[itemIndex]["INITIAL_COST"].ToString());
                                decimal initial_expense = decimal.Parse(dtType1.Rows[itemIndex]["INITIAL_EXPENSE"] == null ? "0" : dtType1.Rows[itemIndex]["INITIAL_EXPENSE"].ToString());
                                string strItemText = dtType1.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtType1.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                                string strContractUnit = (dtType1.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtType1.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                                int intContractQTY = int.Parse(dtType1.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtType1.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                                int intQuantity = int.Parse(dtType1.Rows[itemIndex]["QUANTITY"] == null ? "" : dtType1.Rows[itemIndex]["QUANTITY"].ToString());
                                string strCombine = "";
                                if (!string.IsNullOrEmpty(strContractUnit))
                                {
                                    strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                                }
                                decTotal = decTotal + initial_expense;
                                sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                                sheet.Range["I" + intItemStart.ToString()].Text = intQuantity.ToString();
                                sheet.Range["J" + intItemStart.ToString()].Text = initial_cost.ToString("N0");
                                sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                sheet.Range["K" + intItemStart.ToString()].Text = initial_expense.ToString("N0");
                                sheet.Range["K" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                intItemStart++;
                            }
                        }
                        if (Type3.Any())
                        {
                            intItemStart++;
                            DataTable dtType3 = Type3.CopyToDataTable();

                            DateTime dtmFromDate = DateTime.ParseExact(strPeroidFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                            DateTime dtmToDate = DateTime.ParseExact(strPeroidTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                            int intTotalMonth = CalcuateTotalMonths(dtmFromDate, dtmToDate);

                            sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                            intItemStart++;


                            for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                            {
                                decimal monthly_cost = decimal.Parse(dtType3.Rows[itemIndex]["MONTHLY_COST"] == null ? "0" : dtType3.Rows[itemIndex]["MONTHLY_COST"].ToString());
                                decimal monthly_usage_fee = decimal.Parse(dtType3.Rows[itemIndex]["MONTHLY_USAGE_FEE"] == null ? "0" : dtType3.Rows[itemIndex]["MONTHLY_USAGE_FEE"].ToString());
                                string strItemText = dtType3.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtType3.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                                string strContractUnit = (dtType3.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtType3.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                                int intContractQTY = int.Parse(dtType3.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtType3.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                                int intQuantity = int.Parse(dtType3.Rows[itemIndex]["QUANTITY"] == null ? "" : dtType3.Rows[itemIndex]["QUANTITY"].ToString());
                                string strCombine = "";
                                if (!string.IsNullOrEmpty(strContractUnit))
                                {
                                    strCombine = " [" + (intContractQTY > 1 ? intContractQTY.ToString() : "") + strContractUnit + "]";
                                }

                                decTotal = decTotal + (monthly_usage_fee * intTotalMonth);
                                sheet.Range["D" + intItemStart.ToString()].Text = strItemText + strCombine ;
                                sheet.Range["I" + intItemStart.ToString()].Text = intQuantity.ToString();
                                sheet.Range["J" + intItemStart.ToString()].Text = monthly_cost.ToString("N0");
                                sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                sheet.Range["K" + intItemStart.ToString()].Text = (monthly_usage_fee * intTotalMonth).ToString("N0");
                                sheet.Range["K" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                intItemStart++;
                                sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "～" + dtmToDate.ToString("yyyy/M/d");
                                intItemStart++;
                            }
                        }
                        intHeaderStart++;
                    }
                    #endregion

                    #region Special Discount
                    if (decDiscount != 0)
                    {
                        sheet.Range["B42"].Text = (intHeaderNumberSerial + 1).ToString();
                        sheet.Range["C42"].Text = "特別値引き";
                        sheet.Range["K42"].Text = decDiscount.ToString("N0");
                        sheet.Range["K42"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    }
                    #endregion

                    #region GrandTotal
                    sheet.Range["K43"].Text = "¥" + (decTotal + decDiscount).ToString("N0");
                    sheet.Range["K43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    #endregion

                    #region Header Amount 
                    decimal tax_amount = Utility_Component.RoundedDown((decTotal + decDiscount) * (TaxAmt * (decimal)0.01));
                    decimal amount = decTotal + decDiscount;
                    sheet.Range["E10"].Text = "¥" + amount.ToString("N0");
                    sheet.Range["E10"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["E11"].Text = "¥" + tax_amount.ToString("N0");//6
                    sheet.Range["E11"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["E12"].Text = "¥" + (amount + tax_amount).ToString("N0");//7
                    sheet.Range["E12"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    #endregion

                    #region Remark
                    XlsRectangleShape shape = sheet.RectangleShapes[1] as XlsRectangleShape;
                    shape.Text += "\n" + REMARK;
                    #endregion

                    sheet.Range["K50"].Text = "No." + COMPANY_NO_BOX + "-" + strRPTTYPE + "-" + REQ_SEQ;

                    #endregion

                    //Save excel file to pdf file.  
                    workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);

                    DataRow dr = result.NewRow();
                    dr["FILENAME"] = FILENAME + ".pdf";
                    result.Rows.Add(dr);
                }
            }
            else
            {
                DataRow dr = result.NewRow();
                dr["Error Message"] = string.Format(Messages.Jimugo.E000WB034, "初期見積書");
                result.Rows.Add(dr);
            }
            return result;
        }
        #endregion

        #region MailCreate
        public MetaResponse QuotationMailCreate(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, string CONSUMPTION_TAX, string INITIAL_SPECIAL_DISCOUNTS, string MONTHLY_SPECIAL_DISCOUNTS, string YEARLY_SPECIAL_DISCOUNT,string EMAIL_ADDRESS, string INPUT_PERSON, string ExportInfo, string CONTRACT_PLAN, string CREATED_TIME, string strPeroidFrom, string strPeroidTo)  
        {
            #region Parameters
            //message for pop up
            DataTable message = new DataTable();
            message.Columns.Add("Error Message");
            message.Columns.Add("Message");
            message.Columns.Add("EmailAddressCC");
            message.Columns.Add("TemplateString");
            message.Columns.Add("SubjectString");
            message.Columns.Add("UPDATED_AT");
            message.Columns.Add("UPDATED_AT_RAW");
            
            DataTable dtExportInfo = Utility_Component.JsonToDt(ExportInfo);
            #endregion
            string msg = "";

            try
            {
                BOL_REQUEST_DETAIL oREQUEST_DETAIL = new BOL_REQUEST_DETAIL();
                BOL_REPORT_HISTORY oREPORT_HISTORY = new BOL_REPORT_HISTORY();

                using (TransactionScope dbtnx = new TransactionScope())
                {

                    //Re execute 3-2 ②
                    REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
                    DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, CONTRACT_PLAN, "", out msg);

                    #region UPDATE REQUEST_DETAIL
                    oREQUEST_DETAIL.REQ_SEQ = Convert.ToInt32(REQ_SEQ);
                    oREQUEST_DETAIL.COMPANY_NO_BOX = COMPANY_NO_BOX;
                    oREQUEST_DETAIL.QUOTATION_DATE = TEMP;

                    oREQUEST_DETAIL.INITIAL_COST = dt.AsEnumerable()
                                                    .Where(r => r.Field<int?>("TYPE") == 1 && r.Field<int>("QUANTITY") > 0)
                                                    .Sum(r => r.Field<decimal>("INITIAL_EXPENSE"));

                    oREQUEST_DETAIL.INITIAL_COST_DISCOUNTS = Convert.ToDecimal(INITIAL_SPECIAL_DISCOUNTS);

                    decimal INITIAL_APPLYING_DISCOUNT_AMOUNT = oREQUEST_DETAIL.INITIAL_COST - oREQUEST_DETAIL.INITIAL_COST_DISCOUNTS;
                    oREQUEST_DETAIL.INITIAL_COST_INCLUDING_TAX = INITIAL_APPLYING_DISCOUNT_AMOUNT + (INITIAL_APPLYING_DISCOUNT_AMOUNT * (Convert.ToDecimal(CONSUMPTION_TAX) * (decimal)0.01));

                    oREQUEST_DETAIL.MONTHLY_COST = dt.AsEnumerable()
                                                    .Where(r => r.Field<int?>("TYPE") == 2)
                                                    .Sum(r => r.Field<decimal>("MONTHLY_USAGE_FEE"));
                    oREQUEST_DETAIL.MONTHLY_COST_DISCOUNTS = Convert.ToDecimal(MONTHLY_SPECIAL_DISCOUNTS);

                    decimal MONTHLY_APPLYING_DISCOUNT_AMOUNT = oREQUEST_DETAIL.MONTHLY_COST - oREQUEST_DETAIL.MONTHLY_COST_DISCOUNTS;
                    oREQUEST_DETAIL.MONTHLY_COST_INCLUDING_TAX = MONTHLY_APPLYING_DISCOUNT_AMOUNT + (MONTHLY_APPLYING_DISCOUNT_AMOUNT * (Convert.ToDecimal(CONSUMPTION_TAX) * (decimal)0.01));

                    decimal UNIT_PRICE = dt.AsEnumerable()
                                        .Where(r => r.Field<int?>("TYPE") == 3 && r.Field<int>("QUANTITY") > 0)
                                        .Sum(r => r.Field<decimal>("UNIT_PRICE"));
                    oREQUEST_DETAIL.YEAR_COST = UNIT_PRICE * 12;
                    oREQUEST_DETAIL.YEAR_COST_DISCOUNTS = Convert.ToDecimal(YEARLY_SPECIAL_DISCOUNT);

                    decimal YEARLY_APPLYING_DISCOUNT_AMOUNT = oREQUEST_DETAIL.YEAR_COST - oREQUEST_DETAIL.YEAR_COST_DISCOUNTS;
                    oREQUEST_DETAIL.YEAR_COST_INCLUDING_TAX = YEARLY_APPLYING_DISCOUNT_AMOUNT + (YEARLY_APPLYING_DISCOUNT_AMOUNT * (Convert.ToDecimal(CONSUMPTION_TAX) * (decimal)0.01));
                    oREQUEST_DETAIL.TAX = Convert.ToInt32(CONSUMPTION_TAX);
                    oREQUEST_DETAIL.UPDATED_AT_RAW = CURRENT_DATETIME;
                    oREQUEST_DETAIL.UPDATED_BY = CURRENT_USER;

                    bool willUpdateYearCost = false;
                    if (CONTRACT_PLAN == "PRODUCT" && UNIT_PRICE > 0)
                    {
                        willUpdateYearCost = true;
                    }
                    //UPDATE REQUEST_DETAIL
                    if (DAL_REQUEST_DETAIL.CanUpdate(COMPANY_NO_BOX, REQ_SEQ, CREATED_TIME, out msg))
                    {
                        DAL_REQUEST_DETAIL.UpdateQuotation(oREQUEST_DETAIL, dtExportInfo, willUpdateYearCost, out msg);
                        if (!string.IsNullOrEmpty(msg))
                        {
                            DataRow dr = message.NewRow();
                            dr["Error Message"] = Messages.Jimugo.E000WB002;
                            message.Rows.Add(dr);
                            response.Status = 0;
                            response.Data = Utility.Utility_Component.DtToJSon(message, "Error");
                            return response;
                        }
                    }
                    else
                    {
                        DataRow dr = message.NewRow();
                        dr["Error Message"] = string.Format(Messages.Jimugo.E000WB033, "利用申請見積テーブル");
                        message.Rows.Add(dr);
                        response.Status = 0;
                        response.Data = Utility.Utility_Component.DtToJSon(message, "Error");
                        return response;
                    }
                    #endregion

                    #region UPDATE REPORT_HISTORY
                    for (int i = 0; i < dtExportInfo.Rows.Count; i++)
                    {
                        int REPORT_TYPE = Convert.ToInt32(dtExportInfo.Rows[i]["ExportType"]);
                        string FILENAME = Convert.ToString(dtExportInfo.Rows[i]["FileName"]);
                        int last_index_of_underscore = FILENAME.LastIndexOf("_") + 1;
                        FILENAME = FILENAME.Substring(0, FILENAME.Length - (FILENAME.Length - last_index_of_underscore + 1)) + ".pdf";
                        REPORT_TYPE = REPORT_TYPE == 4 ? 1 : REPORT_TYPE;
                        REPORT_HISTORY DAL_REPORT_HISTORY = new REPORT_HISTORY(con);
                        oREPORT_HISTORY.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oREPORT_HISTORY.REQ_SEQ = Convert.ToInt32(REQ_SEQ);
                        oREPORT_HISTORY.REPORT_TYPE = REPORT_TYPE;
                        oREPORT_HISTORY.REPORT_HISTORY_SEQ = DAL_REPORT_HISTORY.GetReportHistorySEQ(COMPANY_NO_BOX, REPORT_TYPE, oREPORT_HISTORY.REQ_SEQ, out msg);
                        oREPORT_HISTORY.OUTPUT_AT = TEMP;
                        oREPORT_HISTORY.OUTPUT_FILE = FILENAME;
                        oREPORT_HISTORY.EMAIL_ADDRESS = EMAIL_ADDRESS;
                        oREPORT_HISTORY.OUTPUT_BY = CURRENT_USER;
                        oREPORT_HISTORY.CREATED_AT = CURRENT_DATETIME;
                        oREPORT_HISTORY.CREATED_BY = CURRENT_USER;
                        oREPORT_HISTORY.UPDATED_AT = CURRENT_DATETIME;
                        oREPORT_HISTORY.UPDATED_BY = CURRENT_USER;

                        DAL_REPORT_HISTORY.Insert(oREPORT_HISTORY, CURRENT_DATETIME, CURRENT_USER, out msg);

                        if (!string.IsNullOrEmpty(msg))
                        {
                            DataRow dr = message.NewRow();
                            dr["Error Message"] = Messages.Jimugo.E000WB003;
                            message.Rows.Add(dr);
                            response.Status = 0;
                            response.Data = Utility.Utility_Component.DtToJSon(message, "Error");
                            return response;
                        }

                    }
                    #endregion

                    #region UPDATE REQ_USAGE_FEE
                    var dtresult = dt.AsEnumerable().Where(r => r.Field<int>("QUANTITY") > 0).CopyToDataTable();
                    for (int i = 0; i < dtresult.Rows.Count; i++)
                    {
                        BOL_REQ_USAGE_FEE oREQ_USAGE_FEE = new BOL_REQ_USAGE_FEE();
                        REQ_USAGE_FEE DAL_REQ_USAGE_FEE = new REQ_USAGE_FEE(con);

                        oREQ_USAGE_FEE.COMPANY_NO_BOX = COMPANY_NO_BOX;
                        oREQ_USAGE_FEE.REQ_SEQ = Convert.ToInt32(REQ_SEQ);
                        oREQ_USAGE_FEE.TYPE = Convert.ToDecimal(dtresult.Rows[i]["TYPE"].ToString());
                        oREQ_USAGE_FEE.CONTRACT_CODE = Convert.ToString(dtresult.Rows[i]["CONTRACT_CODE"]).Trim();

                        if (oREQ_USAGE_FEE.TYPE == 1)
                        {
                            oREQ_USAGE_FEE.UNIT_PRICE = Convert.ToDecimal(dtresult.Rows[i]["INITIAL_COST"]);
                            oREQ_USAGE_FEE.AMOUNT = Convert.ToDecimal(dtresult.Rows[i]["INITIAL_EXPENSE"]);

                        } else if (oREQ_USAGE_FEE.TYPE == 2)
                        {
                            oREQ_USAGE_FEE.UNIT_PRICE = Convert.ToDecimal(dtresult.Rows[i]["MONTHLY_COST"]);
                            oREQ_USAGE_FEE.AMOUNT = Convert.ToDecimal(dtresult.Rows[i]["MONTHLY_USAGE_FEE"]);

                        }else if (oREQ_USAGE_FEE.TYPE == 3)
                        {
                            try
                            {
                                DateTime dtmFromDate = DateTime.ParseExact(strPeroidFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                                DateTime dtmToDate = DateTime.ParseExact(strPeroidTo, "yyyyMMdd", CultureInfo.InvariantCulture);
                                int totalMonths = CalcuateTotalMonths(dtmFromDate, dtmToDate);

                                Decimal MONTHLY_COST = Convert.ToDecimal(dtresult.Rows[i]["MONTHLY_COST"]);
                                oREQ_USAGE_FEE.UNIT_PRICE = MONTHLY_COST * totalMonths;
                                Decimal MONTHLY_USAGE_FEE = Convert.ToDecimal(dtresult.Rows[i]["MONTHLY_USAGE_FEE"]);
                                oREQ_USAGE_FEE.AMOUNT = MONTHLY_USAGE_FEE * totalMonths;
                            }
                            catch (Exception)
                            {
                                oREQ_USAGE_FEE.UNIT_PRICE = 0;
                                oREQ_USAGE_FEE.AMOUNT = 0;
                            }
                        }
                        oREQ_USAGE_FEE.UPDATED_AT = CURRENT_DATETIME;
                        oREQ_USAGE_FEE.UPDATED_BY = CURRENT_USER;
                       

                        if (DAL_REQ_USAGE_FEE.CanUpdate(oREQ_USAGE_FEE, CREATED_TIME, out msg))
                        {
                            DAL_REQ_USAGE_FEE.Update(oREQ_USAGE_FEE, out msg);

                            if (!string.IsNullOrEmpty(msg))
                            {
                                DataRow dr = message.NewRow();
                                dr["Error Message"] = Messages.Jimugo.E000WB017;
                                message.Rows.Add(dr);
                                response.Status = 0;
                                response.Data = Utility.Utility_Component.DtToJSon(message, "Error");
                                return response;
                            }
                        }
                        else
                        {
                            DataRow dr = message.NewRow();
                            dr["Error Message"] = string.Format(Messages.Jimugo.E000WB033, "利用料金マスタテーブル");
                            message.Rows.Add(dr);
                            response.Status = 0;
                            response.Data = Utility.Utility_Component.DtToJSon(message, "Error");
                            return response;
                        }

                    }
                    #endregion

                    #region MovePDF
                    //get config object for CTS040
                    BOL_CONFIG config = new BOL_CONFIG("CTS040", con);
                    BOL_CONFIG systemConfig = new BOL_CONFIG("SYSTEM", con);

                    for (int i = 0; i < dtExportInfo.Rows.Count; i++)
                    {
                        int REPORT_TYPE = Convert.ToInt32(dtExportInfo.Rows[i]["ExportType"]);
                        string TEMP_FILE_NAME = Convert.ToString(dtExportInfo.Rows[i]["FileName"]);
                        int last_index_of_underscore = TEMP_FILE_NAME.LastIndexOf("_") + 1;
                        string FILE_NAME = TEMP_FILE_NAME.Substring(0, TEMP_FILE_NAME.Length - (TEMP_FILE_NAME.Length - last_index_of_underscore + 1)) + ".pdf";
                        string destinationpath = "";
                        String tempPath = systemConfig.getStringValue("temp.dir");
                        if (REPORT_TYPE != 4) //NOT PI BROWSING
                        {
                            if (dtExportInfo.Rows[i]["ExportType"].ToString() == "3")
                            {
                                destinationpath = config.getStringValue("fileSavePath.send.purchaseOrder");
                            }
                            else
                            {
                                destinationpath = config.getStringValue("fileSavePath.send.initialQuote");
                            }
                            destinationpath =  destinationpath + "/" + FILE_NAME;
                            //move file
                            tempPath = tempPath + @"/" + TEMP_FILE_NAME;
                            if (!MoveTempPDF(tempPath, destinationpath))
                            {
                                DataRow dr = message.NewRow();
                                dr["Error Message"] = string.Format(Messages.Jimugo.E000WB001, FILE_NAME);
                                response.Status = 0;
                                message.Rows.Add(dr);
                                response.Data = Utility.Utility_Component.DtToJSon(message, "Error"); ;
                                return response;
                            }
                        }
                    }
                    #endregion

                    string template = PrepareMailTemplate(COMPANY_NAME, INPUT_PERSON);

                    message.Clear();
                    DataRow dtRow = message.NewRow();
                    dtRow["EmailAddressCC"] = config.getStringValue("emailAddress.cc");
                    dtRow["TemplateString"] = template;
                    dtRow["SubjectString"] = config.getStringValue("emailSubject.sendForms");
                    dtRow["UPDATED_AT"] = CURRENT_DATETIME;
                    dtRow["UPDATED_AT_RAW"] = UPDATED_AT_DATETIME;

                    message.Rows.Add(dtRow);
                    dbtnx.Complete();
                    timer.Stop();
                    response.Meta.Duration = timer.Elapsed.TotalSeconds;
                    response.Data = Utility.Utility_Component.DtToJSon(message, "Mail Template");
                    response.Status = 1;
                    return response;
                }
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region PrepareMailTemplate
        private string PrepareMailTemplate(string COMPANY_NAME, string CONTACT_NAME)
        {
            try
            {

                Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NAME },
                        { "${contactName}", CONTACT_NAME}
                    };

                //prepare for mail header
                string template_base_name = "CTS040_SendForms";

                //read email template
                string file_path = HttpContext.Current.Server.MapPath("~/Templates/Mail/" + template_base_name + ".txt");
                string body = System.IO.File.ReadAllText(file_path);

                string tempString = Utility.Mail.MapMailPlaceHolders(body, map);

                return tempString;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }
        #endregion

        #region MoveTempPDF
        private bool MoveTempPDF(string temPath, string destinationPath)
        {
            try
            {
                // Create a new FileInfo object.    
                FileInfo fInfo = new FileInfo(temPath);
                //check if already exist.  
                FileInfo destinationInfo = new FileInfo(destinationPath);
                if (File.Exists(destinationInfo.FullName))
                {
                    destinationInfo.Delete();
                }
                fInfo.CopyTo(destinationPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        #endregion

        #region CalculateTotalMonths
        private int CalcuateTotalMonths(DateTime from, DateTime to)
        {
            LocalDate start = new LocalDate(from.Year, from.Month, from.Day);
            LocalDate end = new LocalDate(to.Year, to.Month, to.Day);
            Period period = Period.Between(start, end);
            int intTotalMonth = period.Months;

            if (period.Days > 15)
            {
                intTotalMonth++;
            }

            if (period.Years > 0)
            {
                intTotalMonth += period.Years * 12;
            }
            return intTotalMonth;
        }
        #endregion
    }
}