using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace AmigoPaperWorkProcessSystem.Core
{
    public static class Utility
    {
        #region Declare
        //declare log instance
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("activity");
        private static readonly log4net.ILog clientlog = log4net.LogManager.GetLogger("client");
        private static readonly log4net.ILog weblog = log4net.LogManager.GetLogger("web");
        private static string id, password;
        public enum DataType
        {
            EMAIL,
            TEXT,
            NUMBER,
            DATE,
            TIMESTAMP,
            EDI_ACCOUNT,
            ASCII, DATE_RANGE,
            YEARMONTH,
            HALF_NUMBER,
            HALF_KANA_ALPHA_NUMERIC,
            HALF_ALPHA_NUMERIC,
            FULL_WIDTH,
            MINIMUM,
            INPUT_TYPE,
            MINIMUM_TRANSFER_FEE,
            MINIMUM_EXPENSE
        };

        public enum LogType
        {
            Info,
            Warn,
            Error,
        }
        #endregion

        #region Properties
        public static string ImportFolderPath
        {
            get { return AmigoPapaerWorkProcessSystem.Core.Properties.Settings.Default.InputFolderPath; }
        }

        public static string ProcessedFolderPath
        {
            get { return AmigoPapaerWorkProcessSystem.Core.Properties.Settings.Default.ProcessedFolderPath; }
        }

        public static string Id
        {
            get { return id; }
            set { id = value; }
        }

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Methods
        #region WriteActivityLog
        public static void WriteActivityLog(string message, Enum type)
        {
            switch (type)
            {
                case LogType.Info:
                    log.Info(message);
                    break;
                case LogType.Warn:
                    log.Warn(message);
                    break;
                case LogType.Error:
                    log.Error(message);
                    break;
            }

        }
        #endregion

        #region WriteErrorLog
        public static void WriteErrorLog(string message, Exception ex, bool web)
        {
            if (web)
            {
                weblog.Fatal(message);
            }
            else
            {
                clientlog.Fatal(message, ex);
            }
        }
        #endregion

        #region CheckAndCreateConfig
        public static void CheckAndCreateConfigFolder()
        {
            try
            {
               
                // check if input directory is exist
                if (!Directory.Exists(ImportFolderPath))
                {
                    //create input and processed directory
                    Directory.CreateDirectory(ImportFolderPath);
                    Directory.CreateDirectory(ProcessedFolderPath);
                }


            }
            catch (Exception ex)
            {
                //log error
                WriteErrorLog(ex.Message,ex, false);
            }

        }
        #endregion

        #region CheckIfProcessIsRunning
        public static bool CheckIfProcessIsRunning(String processName)
        {
            bool isRunning = Process.GetProcessesByName(processName).FirstOrDefault(p => p.MainModule.FileName.Contains(processName)) != default(Process);

            return isRunning;
        }
        #endregion

        #region GetCredientalsFromCMD
        public static void GetUserIdAndPasswordFromCommandLine()
        {
            string[] args = Environment.GetCommandLineArgs();
            try
            {
                Id = args[1];
                Password = args[2];
            }
            catch (Exception)
            {
            }

        }

        public static void ExitApp()
        {
            Environment.Exit(1);
        }
        #endregion

        #region dtColumnToDateTime
        public static DateTime dtColumnToDateTime(string strValue)
        {
            DateTime dtm = new DateTime();
            DateTime.TryParse(strValue, out dtm);
            if (dtm == new DateTime())
            {
                dtm = new DateTime(1900, 1, 1);
            }
            return dtm;
        }
        #endregion

        #region dtColumnToDecimal
        public static decimal dtColumnToDecimal(string strValue)
        {
            Decimal decTMP = 0;
            Decimal.TryParse(strValue, out decTMP);
            return decTMP;
        }
        #endregion

        #region dtColumnToInt
        public static int dtColumnToInt(string strValue)
        {
            int intTMP = 0;
            int.TryParse(strValue, out intTMP);
            return intTMP;
        }
        #endregion

        #region DtToJSon
        public static string DtToJSon(DataTable dt, string strHeader)
        {
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)dt.Columns)
                    dictionary.Add(column.ColumnName, row[column]);
                dictionaryList.Add(dictionary);
            }
            return "{ \"" + strHeader + "\" : " + scriptSerializer.Serialize((object)dictionaryList) + "}";
        }
        #endregion

        #region JsonToDt
        public static DataTable JsonToDt(string strJSON)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet dataSet = (DataSet)JsonConvert.DeserializeObject<DataSet>(strJSON);
                
                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0];
                }
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region CheckLogIn

        public static async Task<int> CheckLogIn(string strUserName, string strPass)
        {
            //run from another thread. Let UI thread run
            await Task.Delay(1000).ConfigureAwait(false);
            try
            {
                var json = JsonConvert.SerializeObject(new { UserName = strUserName, Password = strPass });
                var data = new StringContent(json, Encoding.UTF8, "application/json");


                var client = new HttpClient();

                var response = client.PostAsync(AmigoPapaerWorkProcessSystem.Core.Properties.Settings.Default.CheckLogIn, data);


                string content = response.Result.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);

                if (result.Status == 1)
                {
                    Id = strUserName;
                    Password = strPass;
                }

                return result.Status;
            }
            catch (System.TimeoutException)
            {
                MessageBox.Show("server timeout");
                MessageBox.Show(Messages.General.ServerTimeOut);
                Utility.ExitApp();
                return 0;
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("check connection");
                Utility.ExitApp();
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region WriteToCsvFile
        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            //foreach (var col in dataTable.Columns)
            //{
            //    fileContent.Append(col.ToString() + ",");
            //}

            try
            {
                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }
            catch (Exception)
            {

            }

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString(), Encoding.UTF8);
        }
        #endregion

        #region SchedulePaymentExcel
        public static void SchedulePaymentExcel(this DataTable dataTable, string filePath, string strHeader, string strHeaderValue, string sheet_name)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add(sheet_name);
            workSheet.TabColor = System.Drawing.Color.Black;
            int intStartDataRow = 2;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            workSheet.Row(1).Style.Font.Bold = true;

            //Header year month
            workSheet.Cells[1, 1].Value = strHeader;
            if (strHeaderValue.Length != 4 )
            {
                strHeaderValue = strHeaderValue.Substring(0, 4);
            }
            strHeaderValue = strHeaderValue.Insert(2, "/");
            workSheet.Cells[1, 3].Value = strHeaderValue + " 月入金";
            intStartDataRow = 3;
            workSheet.Row(2).Height = 20;
            workSheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(2).Style.Font.Bold = true;


            // Header of the Excel sheet 
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                workSheet.Cells[intStartDataRow - 1, i + 1].Value = dataTable.Columns[i].ColumnName;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);

                //border
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            int last_row = 0;
            // Inserting the data into excel             
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    //border
                    if ( j + 1 == 7 || j + 1 == 8 || j + 1 ==9)
                    {
                        workSheet.Cells[intStartDataRow + i, j + 1].Style.Numberformat.Format = "¥#,##0";
                        workSheet.Cells[intStartDataRow + i, j + 1].Value = dataTable.Rows[i][j];
                    }else if ( j +1 == 2 || j + 1 == 10 || j + 1 == 11)
                    {
                        workSheet.Cells[intStartDataRow + i, j + 1].Style.Numberformat.Format = "yyyy/MM/dd";
                        try
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = DateTime.ParseExact(dataTable.Rows[i][j].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        }
                        catch (Exception)//total row or empty result
                        {
                            if (!String.IsNullOrEmpty(dataTable.Rows[i][j].ToString()))
                            {
                                workSheet.Cells[intStartDataRow + i, j + 1].Value = dataTable.Rows[i][j].ToString();
                            }
                        }
                    }else if (j + 1 == 6) // 品名
                    {
                        if (!String.IsNullOrEmpty(dataTable.Rows[i][j].ToString()))
                        {
                            string value = dataTable.Rows[i][j].ToString();
                            if (value.Substring(Math.Max(0, value.Length - 2)) == "IC")
                            {

                                workSheet.Cells[intStartDataRow + i, j + 1].Value = "Amigo初期費用";
                            }
                            else
                            {
                                workSheet.Cells[intStartDataRow + i, j + 1].Value = value;
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(dataTable.Rows[i][j].ToString()))
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = dataTable.Rows[i][j].ToString();
                        }
                    }
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    last_row = intStartDataRow + i;

                }
            }

            //total cell 
            workSheet.Cells[last_row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[last_row, 1].Style.Font.Bold = true;
            workSheet.Row(2).Style.Font.Bold = true;


            //autofitcolumns
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

            // Create excel file on physical disk  
            FileStream objFileStrm = File.Create(filePath);
            objFileStrm.Close();

            // Write content to excel file  
            File.WriteAllBytes(filePath, excel.GetAsByteArray());
            //Close Excel package 
            excel.Dispose();
        }
        #endregion

        #region AccountReceivableExcel
        public static void AccountReceivableExcel(this DataTable dataTable, string filePath, string sheet_name)
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add(sheet_name);
            workSheet.TabColor = System.Drawing.Color.Black;
            int intStartDataRow = 2;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                workSheet.Cells[intStartDataRow - 1, i + 1].Value = dataTable.Columns[i].ColumnName;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);

                //border
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[intStartDataRow - 1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            // Inserting the data into excel             
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (j + 1 == 9 || j + 1 == 10)
                    {
                        workSheet.Cells[intStartDataRow + i, j + 1].Style.Numberformat.Format ="¥#,##0";
                        workSheet.Cells[intStartDataRow + i, j + 1].Value = dataTable.Rows[i][j];
                    }
                    else if (j + 1 == 4 || j + 1 == 7 || j + 1 == 15)
                    {
                        try
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Style.Numberformat.Format = "yyyy/MM/dd";
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = DateTime.ParseExact(dataTable.Rows[i][j].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                        }

                    } else if (j + 1 == 16) {
                        workSheet.Cells[intStartDataRow + i, j + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[intStartDataRow + i, j + 1].Value = "04";

                    } 
                    else if (j + 1 == 18)
                    {
                        double tax = 0;
                        double deposit = 0;

                        double.TryParse(dataTable.Rows[i][9].ToString(), out tax);
                        double.TryParse(dataTable.Rows[i][8].ToString(), out deposit);

                        if (tax !=0)
                        {
                            //calcuate tax percentage
                            double tax_percent = tax / deposit;
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = Math.Round(tax_percent * 100,2) + "%";
                        }
                        else
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = "非課税";
                        }
                        
                    }else if (j+1 == 14)
                    {
                        if (sheet_name!= "当月入金出力")
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = DateTime.ParseExact(dataTable.Rows[i][j].ToString(), "yyyy/MM", CultureInfo.InvariantCulture).ToString("yyyy/MM");
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(dataTable.Rows[i][j].ToString()))
                        {
                            workSheet.Cells[intStartDataRow + i, j + 1].Value = dataTable.Rows[i][j].ToString();
                        }
                    }
                    //border
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[intStartDataRow + i, j + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
            }


            //autofitcolumns
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

            // Create excel file on physical disk  
            FileStream objFileStrm = File.Create(filePath);
            objFileStrm.Close();

            // Write content to excel file  
            File.WriteAllBytes(filePath, excel.GetAsByteArray());
            //Close Excel package 
            excel.Dispose();

        }
        #endregion

        #region CheckDataLength
        public static bool CheckDataLength(string data, int length)
        {
            if (data.Length <= length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region EnableDoubleBufferGridView
        public static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            try
            {
                Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv, setting, null);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region DeleteFiles
        public static void DeleteFiles(string rootFolder)
        {
            string[] files = Directory.GetFiles(rootFolder);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        #endregion

        #region GetParameterByName
        public static string GetParameterByName(string key, DataTable PARAMETERS)
        {
            try
            {
                return PARAMETERS.Rows[0][key].ToString();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                return "";
            }
        }
        #endregion

        #region RemoveTimpStampFromFileName
        public static string RemoveTimpStampFromFileName(string filename, string extension)
        {
            int last_index_of_underscore = filename.LastIndexOf("_") + 1;
            return filename.Substring(0, filename.Length - (filename.Length - last_index_of_underscore + 1)) + extension;
        }
        #endregion

        #region DeleteTempFile
        public static void DeleteTempFile(string path)
        {
            try
            {
                System.IO.File.Delete(path);
            }
            catch (Exception)
            {

            }
            
        }
        #endregion

        #endregion
    }
}
