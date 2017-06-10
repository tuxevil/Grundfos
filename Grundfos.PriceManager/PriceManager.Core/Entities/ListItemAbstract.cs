using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    [Serializable]
    public abstract class ListItemAbstract : BaseAuditableEntity<int>
    {
        private Currency priceCurrency;
        private decimal price;

        private CurrencyRate currencyRate;
        private CurrencyRate priceSuggestCurrencyRate;
        private CurrencyRate pricePurchaseCurrencyRate;

        public virtual Currency PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual CurrencyRate CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        public virtual CurrencyRate PriceSuggestCurrencyRate
        {
            get { return priceSuggestCurrencyRate; }
            set { priceSuggestCurrencyRate = value; }
        }

        public virtual CurrencyRate PricePurchaseCurrencyRate
        {
            get { return pricePurchaseCurrencyRate; }
            set { pricePurchaseCurrencyRate = value; }
        }
    }

}
