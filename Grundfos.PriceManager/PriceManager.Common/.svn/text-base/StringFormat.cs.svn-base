using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PriceManager.Common
{
    public static class StringFormat
    {
        public static string FormatPercentage(decimal? value)
        {
            if (value.HasValue)
                return value.Value.ToString("#0.##") + " %";
            else
                return "N/D";
        }

        public static string FormatHasValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value;
            else
                return "N/D";
        }

        public static string FormatDecimal(decimal? value, string symbol)
        {
            if (value.HasValue) 
            {
                if (!string.IsNullOrEmpty(symbol))
                    return string.Format("{0} {1}", symbol, value.Value.ToString("##.##"));
                else
                    return value.Value.ToString("##.##");
            }
            else
                return "N/D";
        }

        public static string FormatDecimal(decimal? value)
        {        
            return FormatDecimal(value, null);
        }

        public static double MilliTimeStamp(DateTime TheDate)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = TheDate.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        public static bool IsDecimal(string val, NumberStyles NumberStyle, out decimal result)
        {
            return decimal.TryParse(val, NumberStyle, CultureInfo.CurrentCulture, out result);
        }

        public static bool IsInteger(string val, out Int32 result)
        {
            return Int32.TryParse(val, System.Globalization.NumberStyles.Integer, CultureInfo.CurrentCulture, out result);
        }

        public static string StripHtmlTags(string htmlText)
        {
            Regex reg = new Regex("<(.|\n)+?>");
            return reg.Replace(htmlText, "");
        }

        public static string ClearCommasOnJavascript(string text)
        {
            return text.Replace("'", "");
        }

        public static string Cut(string instr, int len)
        {
            instr = StripHtmlTags(instr);

            if (instr.Length > len)
            {
                //if (instr.LastIndexOf("&", len) > instr.LastIndexOf(";", len))
                //    len = instr.IndexOf(";", len) + 1;

                instr = instr.Substring(0, len-3) + "...";
            }

            return instr;
        }

    }
}
