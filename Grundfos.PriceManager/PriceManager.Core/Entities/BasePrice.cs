using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    public class PriceBaseHistory : PriceBaseAbstract
    {
        private HistoryStatus historyStatus;
        public virtual HistoryStatus HistoryStatus
        {
            get { return historyStatus; }
            set { historyStatus = value; }
        }

        public PriceBaseHistory() { }

        public PriceBaseHistory(int id)
        {
            this.id = id;
        }
    }

    public class PriceBase : PriceBaseAbstract
    {
        private ICollection<PriceImport> priceImports;
        public virtual ICollection<PriceImport> PriceImports
        {
            get { return priceImports; }
            set { priceImports = value; }
        }

        public PriceBase() { }
        public PriceBase(int id) { this.id = id; }
    }

    public abstract class PriceBaseAbstract : BaseAuditableEntity<int>
    {
        private decimal pricePurchase;
        private Currency pricePurchaseCurrency;
        private decimal priceSuggest;
        private Currency priceSuggestCurrency;
        private string providerCode = "";
        private Provider provider;
        private Product product;
        
        private decimal priceList;
        private Currency priceListCurrency;
        private PriceBaseStatus status;
        private ICollection<PriceAttribute> priceAttributes = new HashedSet<PriceAttribute>();
        private ICollection<PublishItem> publishItems = new HashedSet<PublishItem>();
        private CurrencyRate currencyRate;
        private CurrencyRate priceSuggestCurrencyRate;
        private CurrencyRate pricePurchaseCurrencyRate;

        public virtual string ProviderCode
        {
            get { return providerCode; }
            set { providerCode = value; }
        }

        [DomainSignature]
        public virtual Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        [DomainSignature]
        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual decimal PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual PriceBaseStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual Currency PriceListCurrency
        {
            get { return priceListCurrency; }
            set { priceListCurrency = value; }
        }

        public virtual ICollection<PriceAttribute> PriceAttributes
        {
            get { return priceAttributes; }
            set { priceAttributes = value; }
        }

        public virtual decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public virtual Currency PricePurchaseCurrency
        {
            get { return pricePurchaseCurrency; }
            set { pricePurchaseCurrency = value; }
        }

        public virtual decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual Currency PriceSuggestCurrency
        {
            get { return priceSuggestCurrency; }
            set { priceSuggestCurrency = value; }
        }

        public virtual ICollection<PublishItem> PublishItems
        {
            get { return publishItems; }
            set { publishItems = value; }
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
