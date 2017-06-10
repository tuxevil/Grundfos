using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Threading;
using ProjectBase.Data;
using ProjectBase.Utils;

namespace PriceManager.Common
{
    public class Config
    {
        // Constantes
        private const string CONST_PRICEMANAGER = "grundfos";

        // Constantes para QueryString
        public const string QS_PRODUCT = "prd";
        public const string QS_SELECTION = "s";

        // Constantes para VIEWSTATE
        public const string VW_PRODUCT = "prd";

        // Constantes para SESSION
        public const string SE_PRODUCT = "prd";

        public static string GrundfosFactoryConfigPath
        {
            get
            {
                OpenSessionInViewSection openSessionInViewSection = ConfigurationManager.GetSection("nhibernateSettings") as OpenSessionInViewSection;
                Check.Ensure(openSessionInViewSection != null, "The nhibernateSettings section was not found with ConfigurationManager.");
                Check.Ensure(openSessionInViewSection.SessionFactories[CONST_PRICEMANAGER] != null, "No session factory defined for " + CONST_PRICEMANAGER);
                return openSessionInViewSection.SessionFactories[CONST_PRICEMANAGER].FactoryConfigPath;
            }
        }

        public static DateTime CurrentDate
        {
            get
            {
                if (ConfigurationManager.AppSettings["RunDate"] != null)
                    return Convert.ToDateTime(ConfigurationManager.AppSettings["RunDate"]);
                else
                    return DateTime.Today;
            }
        }

        public static int CurrentWeek
        {
            get
            {
                return
                    Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(CurrentDate,
                                                                               CalendarWeekRule.FirstFourDayWeek,
                                                                               DayOfWeek.Sunday);
            }
        }
    }
}
