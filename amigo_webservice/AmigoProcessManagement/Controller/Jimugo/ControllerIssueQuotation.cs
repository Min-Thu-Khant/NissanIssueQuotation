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
        int Export_Type;

        private string Login_ID;
        string COMPANY_NO_BOX;
        string REQ_SEQ;
        string QUOTATION_DATE;
        string ORDER_DATE;
        string COMPLETION_NOTIFICATION_DATE;
        string COMPANY_NAME;
        string EMAIL_ADDRESS;
        string DOWNLOAD_LINK;
        string EDI_ACCOUNT;
        string FILENAME;

        REQUEST_ID DAL_REQUEST_ID;
        REQUEST_DETAIL DAL_REQUEST_DETAIL;
        REPORT_HISTORY DAL_REPORT_HISTORY;
        REQ_ADDRESS DAL_REQ_ADDRESS;
        #endregion

        #region Constructor
        public ControllerIssueQuotation()
        {
            timer = new Stopwatch();
            timer.Start();
            response = new MetaResponse();
            //UPDATED_AT
            DateTime temp = DateTime.Now;
            UPDATED_AT_DATETIME = temp.ToString("yyyy/MM/dd HH:mm");
            CURRENT_DATETIME = temp.ToString("yyyyMMddHHmmss");
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
        public MetaResponse DoPreview(string COMPANY_NO_BOX, string COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate, string expireDate, string Remark,
            string strFromCertificate, string strToCertificate, string authHeader, string strExportType, string strFileHeader, string strContractPlan, decimal decDiscount)
        {
            try
            {
                Login_ID = "";//Utility_Component.DecodeAuthHeader(authHeader)[0] == null ? null : Utility_Component.DecodeAuthHeader(authHeader)[0];

                //int status;
                //message for pop up
                DataTable messagecode = new DataTable();
                messagecode.Columns.Add("Message");
                messagecode.Columns.Add("Error Message");
                DataRow dr = messagecode.NewRow();

                string saveFileName = "";
                response = getPDF(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt, startDate, expireDate, Remark, strFromCertificate, strToCertificate, strExportType, saveFileName, strFileHeader, strContractPlan, decDiscount);



                return response; //process 3 successful

            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }

        #endregion

        #region PDF Create
        public MetaResponse getPDF(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate, string expireDate,
            string Remark, string strFromCertificate, string strToCertificate, string strExportType, String fileName, string strFileHeader, string strContractPlan, decimal decDiscount)
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");
            switch (strExportType)
            {
                case "1":
                    result = Preview_InitialQuotation(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt, startDate, expireDate, Remark, decDiscount, fileName, strFileHeader);
                    break;
                case "2":
                    result = Preview_MonthlyQuotation(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt, startDate, expireDate, Remark, decDiscount, fileName, strFileHeader);
                    break;
                case "3":
                    result = Preview_PIBrowsing(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt, startDate, expireDate, Remark, strFromCertificate, strToCertificate, decDiscount, fileName, strFileHeader);
                    break;
                case "4":
                    result = Preview_OrderForm(COMPANY_NO_BOX, COMPANY_NAME, REQ_SEQ, EDI_ACCOUNT, TaxAmt,
                        startDate, expireDate, Remark, strFromCertificate, strToCertificate, decDiscount, fileName, strFileHeader, strContractPlan);
                    break;
            }
            response.Data = Utility.Utility_Component.DtToJSon(result, "pdfData");
            response.Status = 1;
            return response;
        }

        #endregion

        #region Preview_InitialQuotation
        protected DataTable Preview_InitialQuotation(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate, string expireDate, string Remark, decimal decDiscount, String fileName, string strFileHeader)
        {
            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = "";// conf.getStringValue("template.Path.CompletionNotification");
            string strRPTTYPE = "";
            string strSubject = "";
            string strExtraCondition = "";

            file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Initialquotation.Normal"));
            FILENAME = strFileHeader + "_Quotation_" + COMPANY_NAME + "様_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            strSubject = "Initial quotation : Amigo Cloud EDI Initial expense";
            strExtraCondition = " AND REQ.Type=1 AND Quantity>0";
            strRPTTYPE = "1";

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, strExtraCondition, out strMessage);
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
            sheet.Range["J2"].Text = COMPANY_NO_BOX + strRPTTYPE + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME;

            sheet.Range["F11"].Text = strSubject;//4

            DateTime ExpireDate = DateTime.ParseExact(expireDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            sheet.Range["F15"].Text = "発行日からＸＸ日間有効 " + ExpireDate.ToString("yyyyMMdd");//9
            #endregion

            #region Basic Large Header
            int intHeaderNumberSerial = 0;
            if (BASIC.Any())
            {
                dtBasic = BASIC.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                {
                    string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());

                    if (intContractQTY > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intHeaderStart++;
            }
            #endregion

            #region Option Large Header
            if (OPTION.Any())
            {
                dtOption = OPTION.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                {
                    string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                    if (intContractUnit > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intHeaderStart++;
            }
            #endregion

            #region SD Large Header
            if (SD.Any())
            {
                dtSD = SD.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                {
                    string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                    if (intContractUnit > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
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
            sheet.Range["J43"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Header Amount 
            sheet.Range["G12"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["G13"].Text = ((decTotal + decDiscount) * (TaxAmt * (decimal)0.01)).ToString("N0");//6
            sheet.Range["G14"].Text = ((decTotal + decDiscount) + (decTotal * (TaxAmt * (decimal)0.01))).ToString("N0");//7
            #endregion

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = "/" + tempStorageFolder + "/" + FILENAME + ".pdf";

            //Save excel file to pdf file.  
            string DownloadLink = HttpContext.Current.Server.MapPath("~" + savePath);
            workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF);

            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");
            DataRow dr = result.NewRow();
            dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
            result.Rows.Add(dr);

            return result;
        }
        #endregion

        #region Preview_MonthlyQuotation
        protected DataTable Preview_MonthlyQuotation(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate, string expireDate, string Remark, decimal decDiscount, String fileName, string strFileHeader)
        {
            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = "";// conf.getStringValue("template.Path.CompletionNotification");
            string strRPTTYPE = "";
            string strSubject = "";
            string strExtraCondition = "";

            file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Monthlyquotation.Normal"));
            FILENAME = strFileHeader + "_Quotation_" + COMPANY_NAME + "様_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            strSubject = " Monthly quotation : Amigo Cloud EDI Monthly usage fee";
            strExtraCondition = " AND REQ.Type=2";
            strRPTTYPE = "2";

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, strExtraCondition, out strMessage);
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
            sheet.Range["J2"].Text = COMPANY_NO_BOX + strRPTTYPE + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME;

            sheet.Range["F11"].Text = strSubject;//4

            DateTime StartDate = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime ExpireDate = DateTime.ParseExact(expireDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            sheet.Range["F15"].Text = StartDate.Year.ToString() + "年" + StartDate.Month.ToString("00") + "月" + StartDate.Day.ToString("00") + "日"; ;//8
            sheet.Range["F16"].Text = "発行日からＸＸ日間有効 " + ExpireDate.ToString("yyyy-MM-dd");//9
            #endregion

            #region Basic Large Header
            int intHeaderNumberSerial = 0;
            if (BASIC.Any())
            {
                dtBasic = BASIC.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                {
                    string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"].ToString());

                    if (intContractQTY > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intHeaderStart++;
            }
            #endregion

            #region Option Large Header
            if (OPTION.Any())
            {
                dtOption = OPTION.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                {
                    string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"].ToString());
                    if (intContractUnit > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                    sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    intItemStart++;
                    intHeaderStart++;
                }
                intHeaderStart++;
            }
            #endregion

            #region SD Large Header
            if (SD.Any())
            {
                dtSD = SD.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                {
                    string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                    int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                    int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                    decimal decCost = 0;
                    decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_USAGE_FEE"].ToString());
                    if (intContractUnit > 0)
                    {
                        strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                    }
                    decTotal = decTotal + (decCost * intContractQTY);
                    sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                    sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                    sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                    sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                    sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
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
            sheet.Range["J43"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Header Amount 
            sheet.Range["G12"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["G13"].Text = ((decTotal + decDiscount) * (TaxAmt * (decimal)0.01)).ToString("N0");//6
            sheet.Range["G14"].Text = ((decTotal + decDiscount) + (decTotal * (TaxAmt * (decimal)0.01))).ToString("N0");//7
            #endregion

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = "/" + tempStorageFolder + "/" + FILENAME + ".pdf";

            //Save excel file to pdf file.  
            string DownloadLink = HttpContext.Current.Server.MapPath("~" + savePath);
            workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF);

            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");
            DataRow dr = result.NewRow();
            dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
            result.Rows.Add(dr);

            return result;
        }
        #endregion

        #region Preview_PIBrowsing
        protected DataTable Preview_PIBrowsing(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, string startDate,
            string expireDate, string Remark, string strFromCertificate, string strToCertificate, decimal decDiscount, String fileName, string strFileHeader)
        {
            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            String file_path = "";// conf.getStringValue("template.Path.CompletionNotification");
            string strRPTTYPE = "";
            string strSubject = "";
            string strExtraCondition = "";

            file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Initialquotation.Normal"));
            FILENAME = strFileHeader + "_Quotation_" + COMPANY_NAME + "様_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            strExtraCondition = " AND REQ.Type IN (1,3) AND Quantity>0";

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, strExtraCondition, out strMessage);
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
            sheet.Range["J2"].Text = COMPANY_NO_BOX + strRPTTYPE + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME;

            sheet.Range["F11"].Text = strSubject;//4

            DateTime StartDate = DateTime.ParseExact(startDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime ExpireDate = DateTime.ParseExact(expireDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            sheet.Range["F15"].Text = StartDate.Year.ToString() + "年" + StartDate.Month.ToString("00") + "月" + StartDate.Day.ToString("00") + "日"; ;//8
            sheet.Range["F16"].Text = "発行日からＸＸ日間有効 " + ExpireDate.ToString("yyyy-MM-dd");//9
            #endregion

            #region Basic Large Header
            int intHeaderNumberSerial = 0;
            if (BASIC.Any() || BASIC != null)
            {
                dtBasic = BASIC.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                var Type1 = from myRow in dtBasic.AsEnumerable()
                            where myRow.Field<int>("TYPE") == 1
                            select myRow;
                var Type3 = from myRow in dtBasic.AsEnumerable()
                            where myRow.Field<int>("TYPE") == 3
                            select myRow;
                intItemStart++;
                if (Type1.Any())
                {
                    DataTable dtType1 = Type1.CopyToDataTable();
                    sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                    intItemStart++;
                    for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                    {
                        decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                        if (intContractQTY > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                    }
                }
                if (Type3.Any())
                {
                    DataTable dtType3 = Type3.CopyToDataTable();
                    DateTime dtmFromDate = DateTime.ParseExact(strFromCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    DateTime dtmToDate = DateTime.ParseExact(strToCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);

                    int intTotalMonth = (int)((int)dtmToDate.Subtract(dtmFromDate).Days / (365.25 / 12));

                    sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                    intItemStart++;


                    for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                    {
                        decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_COST"].ToString());
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                        if (intContractQTY > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "~" + dtmToDate.ToString("yyyy/M/d");
                        intItemStart++;
                    }
                }
                intHeaderStart++;
            }
            #endregion

            #region Option Large Header
            if (OPTION.Any())
            {
                dtOption = OPTION.CopyToDataTable();
                sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                intHeaderNumberSerial++;
                sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                var Type1 = from myRow in dtOption.AsEnumerable()
                            where myRow.Field<int>("TYPE") == 1
                            select myRow;
                var Type3 = from myRow in dtOption.AsEnumerable()
                            where myRow.Field<int>("TYPE") == 3
                            select myRow;
                intItemStart++;
                if (Type1.Any())
                {
                    DataTable dtType1 = Type1.CopyToDataTable();
                    sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                    intItemStart++;
                    for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                    {
                        decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                        if (intContractQTY > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                    }
                }
                if (Type3.Any())
                {
                    DataTable dtType3 = Type3.CopyToDataTable();
                    DateTime dtmFromDate = DateTime.ParseExact(strFromCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    DateTime dtmToDate = DateTime.ParseExact(strToCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);

                    int intTotalMonth = (int)((int)dtmToDate.Subtract(dtmFromDate).Days / (365.25 / 12));

                    sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                    intItemStart++;


                    for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                    {
                        decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_COST"].ToString());
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                        if (intContractQTY > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "~" + dtmToDate.ToString("yyyy/M/d");
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
            sheet.Range["J43"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
            #endregion

            #region Header Amount 
            sheet.Range["G12"].Text = (decTotal + decDiscount).ToString("N0");
            sheet.Range["G13"].Text = ((decTotal + decDiscount) * (TaxAmt * (decimal)0.01)).ToString("N0");//6
            sheet.Range["G14"].Text = ((decTotal + decDiscount) + (decTotal * (TaxAmt * (decimal)0.01))).ToString("N0");//7
            #endregion

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = "/" + tempStorageFolder + "/" + FILENAME + ".pdf";

            //Save excel file to pdf file.  
            string DownloadLink = HttpContext.Current.Server.MapPath("~" + savePath);
            workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF);

            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");
            DataRow dr = result.NewRow();
            dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
            result.Rows.Add(dr);

            return result;
        }
        #endregion        

        #region Preview_OrderForm
        protected DataTable Preview_OrderForm(string COMPANY_NO_BOX, String COMPANY_NAME, string REQ_SEQ, string EDI_ACCOUNT, decimal TaxAmt, 
            string startDate, string expireDate, string Remark, string strFromCertificate, string strToCertificate, decimal decDiscount, String fileName, 
            string strFileHeader,string strContractPlan)
        {
            BOL_CONFIG conf = new BOL_CONFIG("CTS040", con);
            string strSubject = "";
            string file_path = HttpContext.Current.Server.MapPath("~/" + conf.getStringValue("template.Path.Purchaseorder.Normal"));
            string FILENAME = strFileHeader + "_Order form_" + COMPANY_NAME + "様_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string strExtraCondition = "";
            if (strContractPlan == "PRODUCT")
            {
                strExtraCondition = " AND REQ.Type=1 AND Quantity>0";
            }
            else if (strContractPlan != "PRODUCT")
            {
                strExtraCondition = " AND REQ.Type IN (1,3) AND Quantity>0";
            }

            FileInfo info = new FileInfo(file_path);
            Workbook workbook = new Workbook();
            //Load excel file  
            workbook.LoadFromFile(file_path);
            REQUEST_DETAIL DAL_REQUEST_DETAIL = new REQUEST_DETAIL(con);
            string strMessage = "";
            DataTable dt = DAL_REQUEST_DETAIL.GetQuotationData(COMPANY_NO_BOX, REQ_SEQ, strExtraCondition, out strMessage);
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
            int intHeaderStart = 23;
            int intItemStart = 24;
            decimal decTotal = 0;

            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("DownloadLink");
            result.Columns.Add("Message");
            result.Columns.Add("Error Message");

            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            string savePath = "/" + tempStorageFolder + "/" + FILENAME + ".pdf";

            #region Header Information
            sheet.Range["J2"].Text = COMPANY_NO_BOX + " " + REQ_SEQ;
            sheet.Range["J3"].Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString("00") + "月" + DateTime.Now.Day.ToString("00") + "日";
            sheet.Range["A5"].Text = COMPANY_NAME;

            sheet.Range["E9"].Text = strSubject;//4
           
            #endregion

            if (strContractPlan == "PRODUCT") // Initial Quotation
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

                    for (int itemIndex = 0; itemIndex < dtBasic.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        decimal decCost = 0;
                        decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());

                        if (intContractQTY > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        intHeaderStart++;
                    }
                    intHeaderStart++;
                }
                #endregion

                #region Option Large Header
                if (OPTION.Any())
                {
                    dtOption = OPTION.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                    for (int itemIndex = 0; itemIndex < dtOption.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        decimal decCost = 0;
                        decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                        if (intContractUnit > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N0");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N0");
                        sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        intItemStart++;
                        intHeaderStart++;
                    }
                    intHeaderStart++;
                }
                #endregion

                #region SD Large Header
                if (SD.Any())
                {
                    dtSD = SD.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";
                    for (int itemIndex = 0; itemIndex < dtSD.Rows.Count; itemIndex++)
                    {
                        string strItemText = dtOption.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                        int intContractUnit = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtOption.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                        int intContractQTY = int.Parse(dtOption.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtOption.Rows[itemIndex]["CONTRACT_QTY"].ToString());
                        decimal decCost = 0;
                        decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                        if (intContractUnit > 0)
                        {
                            strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "[契約単位" + intContractUnit.ToString() + "]";

                        }
                        decTotal = decTotal + (decCost * intContractQTY);
                        sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                        sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                        sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                        sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                        sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
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
                sheet.Range["J43"].Text = (decTotal + decDiscount).ToString("N0");
                sheet.Range["J43"].Style.HorizontalAlignment = HorizontalAlignType.Right;
                #endregion

                #region Header Amount 
                sheet.Range["E12"].Text = (decTotal + decDiscount).ToString("N0");
                sheet.Range["E13"].Text = ((decTotal + decDiscount) * (TaxAmt * (decimal)0.01)).ToString("N0");//6
                sheet.Range["E14"].Text = ((decTotal + decDiscount) + (decTotal * (TaxAmt * (decimal)0.01))).ToString("N0");//7
                #endregion
                #endregion

                //Save excel file to pdf file.  
                string DownloadLink = HttpContext.Current.Server.MapPath("~" + savePath);
                workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF);

                DataRow dr = result.NewRow();
                dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
                result.Rows.Add(dr);
            }
            else if (strContractPlan != "PRODUCT") //PIBrowsing
            {
                #region Table PI Browsing Data Put
                #region Basic Large Header
                int intHeaderNumberSerial = 0;
                if (BASIC.Any())
                {
                    dtBasic = BASIC.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                    var Type1 = from myRow in dtBasic.AsEnumerable()
                                where myRow.Field<int>("TYPE") == 1
                                select myRow;
                    var Type3 = from myRow in dtBasic.AsEnumerable()
                                where myRow.Field<int>("TYPE") == 3
                                select myRow;
                    intItemStart++;
                    if (Type1.Any())
                    {
                        DataTable dtType1 = Type1.CopyToDataTable();
                        sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                        intItemStart++;
                        for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                        {
                            decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                            string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                            if (intContractQTY > 0)
                            {
                                strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                            }
                            decTotal = decTotal + (decCost * intContractQTY);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                            sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            intHeaderStart++;
                        }
                    }
                    if (Type3.Any())
                    {
                        DataTable dtType3 = Type3.CopyToDataTable();
                        DateTime dtmFromDate = DateTime.ParseExact(strFromCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);
                        DateTime dtmToDate = DateTime.ParseExact(strToCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);

                        int intTotalMonth = (int)((int)dtmToDate.Subtract(dtmFromDate).Days / (365.25 / 12));

                        sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                        intItemStart++;


                        for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                        {
                            decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_COST"].ToString());
                            string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                            if (intContractQTY > 0)
                            {
                                strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                            }
                            decTotal = decTotal + (decCost * intContractQTY);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                            sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "~" + dtmToDate.ToString("yyyy/M/d");
                            intItemStart++;
                            intHeaderStart++;
                        }
                    }
                    intHeaderStart++;
                }
                #endregion

                #region Option Large Header
                if (OPTION.Any())
                {
                    dtOption = OPTION.CopyToDataTable();
                    sheet.Range["B" + intHeaderStart.ToString()].Text = (intHeaderNumberSerial + 1).ToString();
                    intHeaderNumberSerial++;
                    sheet.Range["C" + intHeaderStart.ToString()].Text = "基本契約プラン";

                    var Type1 = from myRow in dtOption.AsEnumerable()
                                where myRow.Field<int>("TYPE") == 1
                                select myRow;
                    var Type3 = from myRow in dtOption.AsEnumerable()
                                where myRow.Field<int>("TYPE") == 3
                                select myRow;
                    intItemStart++;
                    if (Type1.Any())
                    {
                        DataTable dtType1 = Type1.CopyToDataTable();
                        sheet.Range["C" + intItemStart.ToString()].Text = "初期費用";
                        intItemStart++;
                        for (int itemIndex = 0; itemIndex < dtType1.Rows.Count; itemIndex++)
                        {
                            decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["INITIAL_COST"] == null ? "" : dtBasic.Rows[itemIndex]["INITIAL_COST"].ToString());
                            string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                            if (intContractQTY > 0)
                            {
                                strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                            }
                            decTotal = decTotal + (decCost * intContractQTY);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                            sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            intHeaderStart++;
                        }
                    }
                    if (Type3.Any())
                    {
                        DataTable dtType3 = Type3.CopyToDataTable();
                        DateTime dtmFromDate = DateTime.ParseExact(strFromCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);
                        DateTime dtmToDate = DateTime.ParseExact(strToCertificate, "yyyyMMdd", CultureInfo.InvariantCulture);

                        int intTotalMonth = (int)((int)dtmToDate.Subtract(dtmFromDate).Days / (365.25 / 12));

                        sheet.Range["C" + intItemStart.ToString()].Text = "年額費用(" + intTotalMonth.ToString() + "ヶ月分)";
                        intItemStart++;


                        for (int itemIndex = 0; itemIndex < dtType3.Rows.Count; itemIndex++)
                        {
                            decimal decCost = decimal.Parse(dtBasic.Rows[itemIndex]["MONTHLY_COST"] == null ? "" : dtBasic.Rows[itemIndex]["MONTHLY_COST"].ToString());
                            string strItemText = dtBasic.Rows[itemIndex]["CONTRACT_NAME"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_NAME"].ToString();
                            string strContractUnit = (dtBasic.Rows[itemIndex]["CONTRACT_UNIT"] == null ? "0" : dtBasic.Rows[itemIndex]["CONTRACT_UNIT"].ToString());
                            int intContractQTY = int.Parse(dtBasic.Rows[itemIndex]["CONTRACT_QTY"] == null ? "" : dtBasic.Rows[itemIndex]["CONTRACT_QTY"].ToString());

                            if (intContractQTY > 0)
                            {
                                strItemText = strItemText + "[契約数量" + intContractQTY.ToString() + "] [契約単位" + strContractUnit + "]";

                            }
                            decTotal = decTotal + (decCost * intContractQTY);
                            sheet.Range["D" + intItemStart.ToString()].Text = strItemText;
                            sheet.Range["H" + intItemStart.ToString()].Text = intContractQTY.ToString();
                            sheet.Range["I" + intItemStart.ToString()].Text = decCost.ToString("N");
                            sheet.Range["I" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            sheet.Range["J" + intItemStart.ToString()].Text = (decCost * intContractQTY).ToString("N");
                            sheet.Range["J" + intItemStart.ToString()].Style.HorizontalAlignment = HorizontalAlignType.Right;
                            intItemStart++;
                            sheet.Range["D" + intItemStart.ToString()].Text = "期間：" + dtmFromDate.ToString("yyyy/M/d") + "~" + dtmToDate.ToString("yyyy/M/d");
                            intItemStart++;
                            intHeaderStart++;
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
                sheet.Range["J43"].Text = (decTotal + decDiscount).ToString("N0");
                #endregion

                #region Header Amount 
                sheet.Range["E12"].Text = (decTotal + decDiscount).ToString("N0");
                sheet.Range["E13"].Text = ((decTotal + decDiscount) * (TaxAmt * (decimal)0.01)).ToString("N0");//6
                sheet.Range["E14"].Text = ((decTotal + decDiscount) + (decTotal * (TaxAmt * (decimal)0.01))).ToString("N0");//7
                #endregion
                #endregion

                //Save excel file to pdf file.  
                string DownloadLink = HttpContext.Current.Server.MapPath("~" + savePath);
                workbook.SaveToFile(DownloadLink, Spire.Xls.FileFormat.PDF);

                DataRow dr = result.NewRow();
                dr["DownloadLink"] = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + savePath;
                result.Rows.Add(dr);
            }           
            return result;
        }
        #endregion

        #region SendMailCreate
        public MetaResponse SendMailCreate(string list, string authHeader)  //add more parameter
        {
            #region Parameters
            //message for pop up
            DataTable messagecode = new DataTable();
            messagecode.Columns.Add("Error Message");
            DataRow dr = messagecode.NewRow();

            DataTable dtParameter = Utility.Utility_Component.JsonToDt(list);

            COMPANY_NO_BOX = dtParameter.Rows[0]["COMPANY_NO_BOX"].ToString();
            REQ_SEQ = dtParameter.Rows[0]["REQ_SEQ"].ToString();
            COMPANY_NAME = dtParameter.Rows[0]["COMPANY_NAME"].ToString();
            EMAIL_ADDRESS = dtParameter.Rows[0]["EMAIL_ADDRESS"].ToString();
            EDI_ACCOUNT = dtParameter.Rows[0]["EDI_ACCOUNT"].ToString();
            FILENAME = dtParameter.Rows[0]["DOWNLOAD_LINK"].ToString();
            #endregion
            string msg = "";


            Login_ID = Utility_Component.DecodeAuthHeader(authHeader)[0] == null ? null : Utility_Component.DecodeAuthHeader(authHeader)[0];

            try
            {
                using (TransactionScope dbtnx = new TransactionScope())
                {
                    DateTime dtNow = DateTime.Now;
                    string conmletion_noti_date = dtNow.ToString("yyyy/MM/dd");
                    string update_at = dtNow.ToString("yyyyMMddHHmmss");

                    #region Update RequestDetail For CompleteNotificationSending
                    DAL_REQUEST_DETAIL.SendMailUpdate(COMPLETION_NOTIFICATION_DATE, COMPANY_NO_BOX, REQ_SEQ, update_at, Login_ID, out msg);
                    #endregion

                    if (String.IsNullOrEmpty(msg))
                    {
                        #region InsertReportHistroy
                        DateTime now = DateTime.Now;
                        string output_at = dtNow.ToString("yyyy/MM/dd HH:mm");
                        string date = now.ToString("yyyyMMddHHmmss");

                        string req_seq = REQ_SEQ.Length != 1 ? REQ_SEQ : "0" + REQ_SEQ;

                        string outputFile = COMPANY_NO_BOX + "-" + "3" + "-" + req_seq + "_完了通知書(" + EDI_ACCOUNT.Replace("@", "") + ")_" + COMPANY_NAME + ".pdf";
                        string msgText = outputFile;

                        int REPORTHISTORY_SEQ = DAL_REPORT_HISTORY.GetReportHistorySEQ(COMPANY_NO_BOX, 5, out msg);

                        if (string.IsNullOrEmpty(msg))
                        {
                            DAL_REPORT_HISTORY.InsertNotiSending(COMPANY_NO_BOX, REQ_SEQ, REPORTHISTORY_SEQ, outputFile, EMAIL_ADDRESS, Login_ID, output_at, date, out msg);

                            if (string.IsNullOrEmpty(msg))
                            {

                                BOL_CONFIG config = new BOL_CONFIG("CTS060", con);
                                BOL_CONFIG config1 = new BOL_CONFIG("SYSTEM", con);

                                string temPath = config1.getStringValue("temp.dir");
                                temPath = HttpContext.Current.Server.MapPath("/" + temPath + "/" + FILENAME);

                                string pdfSavePath = config.getStringValue("fileSavePath.completionNotice");
                                pdfSavePath = HttpContext.Current.Server.MapPath("~/" + pdfSavePath + "/" + outputFile);

                                //CopyAndMove File
                                int res = MovePdfFile(temPath, pdfSavePath);

                                if (res == 1)
                                {
                                    //BOL_CONFIG config1 = new BOL_CONFIG("SYSTEM", con);
                                    string zipStorageFolder = "/" + config1.getStringValue("temp.dir") + "/" + outputFile.Replace(".pdf", ".zip");

                                    string PASSWORD = config.getStringValue("password.Attachment");

                                    //Create ZipFile With Password
                                    string zipDownloadLink = ZipGenerator(temPath, PASSWORD, zipStorageFolder);

                                    if (zipDownloadLink != null)
                                    {
                                        #region SendMail
                                        String emailAddressCC = config.getStringValue("emailAddress.cc");
                                        string tempString = PrepareAndSendMail(COMPANY_NAME, PASSWORD);

                                        if (tempString != null)
                                        {
                                            string subjectString = config.getStringValue("emailSubject.notice");
                                            DataTable result = new DataTable();
                                            result.Clear();
                                            result.Columns.Add("ZipDownloadLink");
                                            result.Columns.Add("EmailAddressCC");
                                            result.Columns.Add("TemplateString");
                                            result.Columns.Add("SubjectString");

                                            DataRow dtRow = result.NewRow();
                                            dtRow["ZipDownloadLink"] = zipDownloadLink;
                                            dtRow["EmailAddressCC"] = emailAddressCC;
                                            dtRow["TemplateString"] = tempString;
                                            dtRow["SubjectString"] = subjectString.Replace("${companyName}", COMPANY_NAME);

                                            result.Rows.Add(dtRow);
                                            dbtnx.Complete();
                                            response.Data = Utility.Utility_Component.DtToJSon(result, "pdfData");
                                            response.Status = 1;
                                            return response;
                                        }
                                        else
                                        {
                                            return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB018);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB007);
                                    }
                                }
                                else
                                {
                                    return ResponseUtility.ReturnFailMessage(response, timer, messagecode, String.Format(Utility.Messages.Jimugo.E000WB001, msgText));
                                }

                            }
                            else
                            {
                                return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB003);
                            }
                        }
                        else
                        {
                            return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB002);
                        }

                        #endregion
                    }
                    else
                    {
                        return ResponseUtility.ReturnFailMessage(response, timer, messagecode, Utility.Messages.Jimugo.E000WB002);
                    }

                    //return response;
                }
            }
            catch (Exception ex)
            {
                return ResponseUtility.GetUnexpectedResponse(response, timer, ex);
            }
        }
        #endregion

        #region PrepareAndSendMail
        private string PrepareAndSendMail(string COMPANY_NAME, string CONTACT_NAME)
        {
            try
            {
                //get config object for CTS010
                BOL_CONFIG config = new BOL_CONFIG("CTS040", con);

                Dictionary<string, string> map = new Dictionary<string, string>() {
                        { "${companyName}", COMPANY_NAME },
                        { "${contactName}", CONTACT_NAME}
                    };

                //prepare for mail header
                string template_base_name = "CTS040_SendForms.txt";

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

        #region ZipCreateWithPassword
        public string ZipGenerator(string fileName, string PASSWORD, string ZIP_STORAGEFOLDER_PATH)
        {
            string result;
            try
            {
                //var files = Directory.GetFiles(@"D:\Git\Phase-2-test\amigo_webservice\AmigoProcessManagement\App_Data");

                //string something = HttpContext.Current.Server.;

                //something = something;

                string SaveFilePath = HttpContext.Current.Server.MapPath(ZIP_STORAGEFOLDER_PATH); //"~/App_Data/Ouput/output.pdf"


                using (var zip = new ZipFile())
                {
                    zip.Password = PASSWORD;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.AddFile(fileName, "");
                    zip.Save(SaveFilePath);
                }

                return result = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority) + ZIP_STORAGEFOLDER_PATH;
            }
            catch (Exception)
            {
                return result = null;

            }


        }
        #endregion

        #region MovePDFFIle
        private int MovePdfFile(string temPath, string pdfSavePath)
        {
            int status;
            try
            {
                #region CopyAndMove File
                // Create a new FileInfo object.    
                FileInfo fInfo = new FileInfo(temPath);
                //check if already exist.  
                FileInfo destinationInfo = new FileInfo(pdfSavePath);
                if (File.Exists(destinationInfo.FullName))
                {
                    destinationInfo.Delete();
                }
                fInfo.CopyTo(pdfSavePath);
                #endregion
                status = 1;
                return status;
            }
            catch (Exception)
            {
                status = 0;
                return 0;
                throw;
            }


        }
        #endregion

    }
}