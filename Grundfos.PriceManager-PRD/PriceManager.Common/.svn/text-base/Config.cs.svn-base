using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Threading;
using ProjectBase.Data;
using ProjectBase.Utils;
using ProjectBase.Utils.Cache;

namespace PriceManager.Common
{
    public class Config
    {
        // Constantes
        private const string CONST_PRICEMANAGER = "grundfos";
        private const string CONST_SCALA = "scala";

        // Constantes para QueryString
        public const string QS_PRODUCT = "prd";
        public const string QS_SELECTION = "s";

        // Constantes para VIEWSTATE
        public const string VW_PRODUCT = "prd";

        // Constantes para SESSION
        public const string SE_PRODUCT = "prd";

        public static object Currencies
        {
            get { return CacheManager.GetCached("Currencies.GetRates"); }
        }

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

        public static string ImagesProductsPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["Images_ProductsPath"] != null)
                    return ConfigurationManager.AppSettings["Images_ProductsPath"];

                throw new Exception("Images_ProductsPath is not defined in configuration file.");
            }
        }

        public static string ImagesPicturesPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["Images_CategoriesPath"] != null)
                    return ConfigurationManager.AppSettings["Images_CategoriesPath"];

                throw new Exception("Images_CategoriesPath is not defined in configuration file.");
            }
        }


        public static string ImportFileFolder
        {
            get
            {
                if (ConfigurationManager.AppSettings["ImportFileFolder"] != null)
                    return ConfigurationManager.AppSettings["ImportFileFolder"];

                throw new Exception("Import File Folder is not defined in configuration file.");
            }
        }

        public static string SupportEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["SupportEmail"] != null)
                    return ConfigurationManager.AppSettings["SupportEmail"];

                throw new Exception("Support Email is not defined in configuration file.");
            }
        }

        public static char SeparationCharacter
        {
            get
            {
                if (ConfigurationManager.AppSettings["SeparationCharacter"] != null)
                    return Convert.ToChar(ConfigurationManager.AppSettings["SeparationCharacter"]);

                return ',';
            }
        }

        public static string AdministratorRole
        {
            get
            {
                if (ConfigurationManager.AppSettings["Membership_Administrator_Role"] != null)
                    return ConfigurationManager.AppSettings["Membership_Administrator_Role"];

                throw new Exception("Administrator Role is not defined in configuration file.");
            }
        }


        public static string RemotingProcessor
        {
            get
            {
                if (ConfigurationManager.AppSettings["RemotingProcessor"] != null)
                    return ConfigurationManager.AppSettings["RemotingProcessor"];

                throw new Exception("RemotingProcessor is not defined in configuration file.");
            }
        }


        public static string MembershipUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["Membership_Url"] != null)
                    return ConfigurationManager.AppSettings["Membership_Url"];

                throw new Exception("Url for membership is not defined in configuration file.");
            }
        }

        public static string SingleModificationMasterPriceView
        {
            get
            {
                return "IndModifMasterPriceView";
            }
        }

        public static string SingleModificationPriceGroupView
        {
            get
            {
                return "IndModifPriceGroupView";
            }
        }

        public static string SingleModificationPriceListProducts
        {
            get
            {
                return "IndModifPriceListProducts";
            }
        }

        public static string IndexColumn
        {
            get
            {
                return "ColIndex";
            }
        }

        public static string CtrColumn
        {
            get
            {
                return "ColCtr";
            }
        }

        public static string CtmColumn
        {
            get
            {
                return "ColCtm";
            }
        }

        public static string TpColumn
        {
            get
            {
                return "ColTp";
            }
        }

        public static string GrpColumn
        {
            get
            {
                return "ColGrp";
            }
        }

        public static string PLColumn
        {
            get
            {
                return "ColPL";
            }
        }

        public static string NotesControl
        {
            get
            {
                return "ucNotes";
            }
        }

        public static string ProviderFields
        {
            get
            {
                return "ProviderPurchaseFields";
            }
        }

        public static string DistributorFields
        {
            get
            {
                return "DistributorSaleFields";
            }
        }

        public static string SeeQuotes
        {
            get { return "AllQuotes"; }
        }

        public static string SeePriceLists
        {
            get { return "AllPriceLists"; }
        }

        public static string ProviderActivity
        {
            get { return "ProviderActivity"; }
        }

        public static string DistributorActivity
        {
            get { return "DistributorActivity"; }
        }

        public static string PriceListActivity
        {
            get { return "PriceListActivity"; }
        }

        public static string PriceCalculationActivity
        {
            get { return "PriceCalculationActivity"; }
        }

        public static string MailTemplatePath
        {
            get { return "/res/mail/"; }
        }

        public static string ProductListField
        {
            get
            {
                return "ColRollbackBase";
            }
        }

        public static string PriceAttributeHistoryField
        {
            get
            {
                return "ColRollbackGroup";
            }
        }

        public static string WorkListItemHistoryField
        {
            get
            {
                return "ColRollbackList";
            }
        }

        public static string PriceCalculationFormulasField
        {
            get
            {
                return "ColFormulas";
            }
        }

        public static string PriceListInactiveStatus
        {
            get
            {
                return "PriceListInactiveStatus";
            }
        }

        public static string DistributorInactiveStatus
        {
            get
            {
                return "DistributorInactiveStatus";
            }
        }

        public static string ProviderInactiveStatus
        {
            get
            {
                return "ProviderInactiveStatus";
            }
        }

        public static string SeeAllDistributors
        {
            get
            {
                return "SeeAllDistributors";
            }
        }

        public static string QuoteEraseColumn
        {
            get { return "QuoteEraseColumn"; }
        }

        public static string CategoryEraseColumn
        {
            get { return "CategoryEraseColumn"; }
        }

        public static string LookUpEraseColumn
        {
            get { return "LookUpEraseColumn"; }
        }

        public static string QuoteItemSourceColumn
        {
            get { return "QuoteItemSourceColumn"; }
        }

        public static string CanExportAll
        {
            get { return "CanExportAll"; }
        }
    }
}