using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;

namespace AmigoProcessManagement.Utility
{
    public class Utility_Component
    {
        #region dtColumnToDateTime
        public static DateTime? dtColumnToDateTime(string strValue)
        {
            DateTime dtm = new DateTime();
            DateTime.TryParse(strValue, out dtm);
            if (dtm == new DateTime())
            {
                return null;
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
            DataSet dataSet = (DataSet)JsonConvert.DeserializeObject<DataSet>(strJSON);
            DataTable dt = new DataTable();
            if (dataSet.Tables.Count > 0)
            {
                dt = dataSet.Tables[0];
            }
            return dt;
        }
        #endregion

        #region GetDate
        public static string GetYearMonth(string date, bool from)
        {
            if (!string.IsNullOrEmpty(date))
            {
                if (date.Length == 4)
                {
                    if (from)
                    {
                        return date.Substring(2).PadRight(4, '0');
                    }
                    else
                    {
                        return date.Substring(2) + "12";
                    }

                }
                else if (date.Length > 4)
                {
                    return DateTime.Parse(date).ToString("yyMM");
                }
            }
            return date;
        }

        public static string GetFullDate(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                return DateTime.Parse(date).ToString("yyyyMMdd");
            }
            return date;
        }
        #endregion

        #region DecodeAuthHeader
        public static string[] DecodeAuthHeader(string auth)
        {
            string encodedCredential = auth.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("US-ASCII");
            string decoded = encoding.GetString(Convert.FromBase64String(encodedCredential));
            string[] credential = decoded.Split(':');

            return credential;
        }
        #endregion

        #region Compare YearMonth
        public static bool IsFirstYearMonthGreater(DateTime date1, DateTime date2)
        {
            int data1 = int.Parse(date1.ToString("MMdd"));
            int data2 = int.Parse(date2.ToString("MMdd"));

            if (data1 > data2)
            {
                return true;
            }
            return false;

        }

        public static bool IsYearMonthEqual(DateTime date1, DateTime date2)
        {
            if (date1 == date2)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region DsToJSon
        public static string DsToJSon(DataSet ds, string strHeader)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }
        #endregion

        #region RoundedDown
        public static decimal RoundedDown(decimal value)
        {
            try
            {
                return Math.Floor(value);
            }
            catch (Exception)
            {
                return (decimal)0;
            }
        }
        #endregion

    }
}