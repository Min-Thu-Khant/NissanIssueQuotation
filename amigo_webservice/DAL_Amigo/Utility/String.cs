using System;

namespace DAL_AmigoProcess.Utility
{
    public class StringUtil
    {
        public static string handleNullStringDate(string str, string key, string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                str = str.Replace(key, "IS NULL");
            }
            else
            {
                str = str.Replace(key, " = " + key);
            }
            return str;
        }
    }
}
