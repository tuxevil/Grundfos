using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Controllers;
using PriceManager.Common;

namespace PriceManager.Business
{
    public class ControllerManager
    {
        public static ProductController Product
        {
            get { return new ProductController(Config.GrundfosFactoryConfigPath);}
        }

        public static ProductAuditController ProductAudit
        {
            get { return new ProductAuditController(Config.GrundfosFactoryConfigPath); }
        }

        public static PriceListController PriceList
        {
            get { return new PriceListController(Config.GrundfosFactoryConfigPath);}
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
        
        public static ProductPriceController ProductPrice
        {
            get { return new ProductPriceController(Config.GrundfosFactoryConfigPath); }
        }

        public static ProductPriceAuditController ProductPriceAudit
        {
            get { return new ProductPriceAuditController(Config.GrundfosFactoryConfigPath); }
        }

        public static CurrencyController Currency
        {
            get { return new CurrencyController(Config.GrundfosFactoryConfigPath); }
        }

        public static DiscountController Discount
        {
            get { return new DiscountController(Config.GrundfosFactoryConfigPath); }
        }

    }
}
