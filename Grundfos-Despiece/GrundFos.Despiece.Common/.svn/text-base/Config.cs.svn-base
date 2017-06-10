using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace GrundFos.Despiece.Common
{
    public class Config
    {
        public static string SupportEmail
        {
            get { return ConfigurationSettings.AppSettings["SuppportEmail"].ToString(); }
        }

        public static int TimeZoneFix
        {
            get { return Convert.ToInt32(ConfigurationSettings.AppSettings["TimeZoneFix"]); }
        }
    }
}
