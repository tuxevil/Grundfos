using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceAttribute : PriceAttributeAbstract
    {
    }

    [Serializable]
    public class PriceAttributeHistory : PriceAttributeAbstract
    {
        private HistoryStatus historyStatus;
        public virtual HistoryStatus HistoryStatus
        {
            get { return historyStatus; }
            set { historyStatus = value; }
        }

        public PriceAttributeHistory() { }

        public PriceAttributeHistory(int id)
        {
            this.id = id;
        }
    }

    [Serializable]
    public abstract class PriceAttributeAbstract : BaseAuditableEntity<int>
    {
        private decimal price;
        private Currency priceCurrency;
        private PriceBase priceBase;
        private PriceGroup priceGroup;
        private ICollection<WorkListItem> workListItems = new HashedSet<WorkListItem>();
        private CurrencyRate currencyRate;
        private CurrencyRate priceSuggestCurrencyRate;
        private CurrencyRate pricePurchaseCurrencyRate;
        
        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [DomainSignature]
        public virtual PriceBase PriceBase
        {
            get { return priceBase; }
            set { priceBase = value; }
        }

        [DomainSignature]
        public virtual PriceGroup PriceGroup
        {
            get { return priceGroup; }
            set { priceGroup = value; }
        }

        public virtual Currency PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual ICollection<WorkListItem> WorkListItems
        {
            get { return workListItems; }
            set { workListItems = value; }
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
