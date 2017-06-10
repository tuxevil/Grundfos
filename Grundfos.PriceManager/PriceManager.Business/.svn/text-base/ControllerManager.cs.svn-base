using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using PriceManager.Common;
using PriceManager.Data.ControllerRepositories;
using ProjectBase.Data;

namespace PriceManager.Business
{
    public class ControllerManager
    {

        public static LookupController Lookup
        {
            get { return new LookupController(Config.GrundfosFactoryConfigPath); }
        }

        public static ProductController Product
        {
            get { return new ProductController(Config.GrundfosFactoryConfigPath);}
        }

        public static PriceListController PriceList
        {
            get { return new PriceListController(Config.GrundfosFactoryConfigPath);}
        }

        public static CategoryBaseController CategoryBase
        {
            get { return new CategoryBaseController(Config.GrundfosFactoryConfigPath); }
        }

        public static CatalogPageController CatalogPage
        {
            get { return new CatalogPageController(Config.GrundfosFactoryConfigPath); }
        }

        public static ProductTypeController ProductType
        {
            get { return new ProductTypeController(Config.GrundfosFactoryConfigPath); }
        }

        public static CtrRangeController CtrRange
        {
            get { return new CtrRangeController(Config.GrundfosFactoryConfigPath); }
        }

        public static FamilyController Family
        {
            get { return new FamilyController(Config.GrundfosFactoryConfigPath); }
        }

        public static SelectionController Selection
        {
            get { return new SelectionController(Config.GrundfosFactoryConfigPath); }
        }
        
        public static CurrencyController Currency
        {
            get { return new CurrencyController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceImportController PriceImport
        {
            get { return new PriceImportController(Config.GrundfosFactoryConfigPath); }
        }

        public static ProviderController Provider
        {
            get { return new ProviderController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceBaseController PriceBase
        {
            get { return new PriceBaseController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceBaseHistoryController PriceBaseHistory
        {
            get { return new PriceBaseHistoryController(Config.GrundfosFactoryConfigPath); }
        }


        public static IndexPriceController IndexPrice
        {
            get { return new IndexPriceController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceGroupController PriceGroup
        {
            get { return new PriceGroupController(Config.GrundfosFactoryConfigPath); }
        }

        public static NoteController Note
        {
            get { return new NoteController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceAttributeController PriceAttribute
        {
            get { return new PriceAttributeController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceAttributeHistoryController PriceAttributeHistory
        {
            get { return new PriceAttributeHistoryController(Config.GrundfosFactoryConfigPath); }
        }


        public static ProductInfoController ProductInfo
        {
            get { return new ProductInfoController(Config.GrundfosFactoryConfigPath); }
        }

        public static DistributorController Distributor
        {
            get { return new DistributorController(new DistributorRepository(Config.GrundfosFactoryConfigPath)); }
        }

        public static ISession CurrentSession
        {
            get { return NHibernateSessionManager.Instance.GetSessionFrom(Config.GrundfosFactoryConfigPath); }   
        }

        public static WorkListItemController WorkListItem
        {
            get { return new WorkListItemController(Config.GrundfosFactoryConfigPath); }
        }

        public static WorkListItemHistoryController WorkListItemHistory
        {
            get { return new WorkListItemHistoryController(Config.GrundfosFactoryConfigPath); }
        }

        public static ApplicationController Application
        {
            get { return new ApplicationController(Config.GrundfosFactoryConfigPath); }
        }

        public static PublishListController PublishList
        {
            get { return new PublishListController(Config.GrundfosFactoryConfigPath); }
        }

        public static PublishItemController PublishItem
        {
            get { return new PublishItemController(Config.GrundfosFactoryConfigPath); }
        }

        public static CountryController Country
        {
            get { return new CountryController(Config.GrundfosFactoryConfigPath); }
        }

        public static LogController Log
        {
            get { return new LogController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceCalculationController PriceCalculation
        {
            get { return new PriceCalculationController(Config.GrundfosFactoryConfigPath); }
        }

        public static QuoteController Quote
        {
            get { return new QuoteController(new QuoteRepository(Config.GrundfosFactoryConfigPath)); }
        }

        public static QuoteRangeController QuoteRange
        {
            get { return new QuoteRangeController(new QuoteRangeRepository(Config.GrundfosFactoryConfigPath)); }
        }

        public static QuoteItemController QuoteItem
        {
            get { return new QuoteItemController(Config.GrundfosFactoryConfigPath); }
        }

        public static CurrencyRateController CurrencyRate
        {
            get { return new CurrencyRateController(Config.GrundfosFactoryConfigPath); }
        }

        public static LineController Line
        {
            get { return new LineController(Config.GrundfosFactoryConfigPath); }
        }

        public static AreaController Area
        {
            get { return new AreaController(Config.GrundfosFactoryConfigPath); }
        }
    }
}
