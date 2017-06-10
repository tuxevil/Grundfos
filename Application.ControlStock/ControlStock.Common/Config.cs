using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using ProjectBase.Data;
using ProjectBase.Utils;

namespace PartnerNet.Common
{
    public class Config
    {
        // Constantes
        private const string CONST_STOCKFORECAST = "grundfos";
        private const string CONST_SCALA = "scala";

        // Constantes para QueryString
        public const string QS_PRODUCT = "prd";

        public static string GrundfosFactoryConfigPath
        {
            get
            {
                OpenSessionInViewSection openSessionInViewSection = ConfigurationManager.GetSection("nhibernateSettings") as OpenSessionInViewSection;
                Check.Ensure(openSessionInViewSection != null, "The nhibernateSettings section was not found with ConfigurationManager.");
                Check.Ensure(openSessionInViewSection.SessionFactories[CONST_STOCKFORECAST] != null, "No session factory defined for " + CONST_STOCKFORECAST);
                return openSessionInViewSection.SessionFactories[CONST_STOCKFORECAST].FactoryConfigPath;
            }
        }

        public static DateTime CurrentDate
        {
            get
            {
                if (ConfigurationManager.AppSettings["RunDate"]!= null)
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

        public static string ScalaFactoryConfigPath
        {
            get
            {
                OpenSessionInViewSection openSessionInViewSection = ConfigurationManager.GetSection("nhibernateSettings") as OpenSessionInViewSection;
                Check.Ensure(openSessionInViewSection != null, "The nhibernateSettings section was not found with ConfigurationManager.");
                Check.Ensure(openSessionInViewSection.SessionFactories[CONST_SCALA] != null, "No session factory defined for " + CONST_SCALA);
                return openSessionInViewSection.SessionFactories[CONST_SCALA].FactoryConfigPath;
            }
        }
    }
}
