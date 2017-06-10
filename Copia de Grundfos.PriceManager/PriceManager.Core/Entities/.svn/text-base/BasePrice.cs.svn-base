using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class BasePriceHistory : BasePrice
    {
    }

    public class BasePrice : AuditableEntity<int>
    {
        private decimal pricePurchase;
        private Currency pricePurchaseCurrency;
        private decimal priceSuggest;
        private Currency priceSuggestCurrency;
        private string providerCode;
        private Provider provider;
        private Product product;
        private PriceImport priceImport;
        private decimal priceList;
        private Currency priceListCurrency;
        private decimal basePrisceSell;
        private Currency basePrisceSellCurrency;
        private Status status;
        private IList<PriceAttribute> priceAttributes;

        public virtual string ProviderCode
        {
            get { return providerCode; }
            set { providerCode = value; }
        }

        public virtual Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual PriceImport PriceImport
        {
            get { return priceImport; }
            set { priceImport = value; }
        }

        public virtual decimal PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual decimal BasePrisceSell
        {
            get { return basePrisceSell; }
            set { basePrisceSell = value; }
        }

        public virtual Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual Currency PriceListCurrency
        {
            get { return priceListCurrency; }
            set { priceListCurrency = value; }
        }

        public virtual Currency BasePrisceSellCurrency
        {
            get { return basePrisceSellCurrency; }
            set { basePrisceSellCurrency = value; }
        }

        public virtual IList<PriceAttribute> PriceAttributes
        {
            get { return priceAttributes; }
            set { priceAttributes = value; }
        }

        public decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public Currency PricePurchaseCurrency
        {
            get { return pricePurchaseCurrency; }
            set { pricePurchaseCurrency = value; }
        }

        public decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public Currency PriceSuggestCurrency
        {
            get { return priceSuggestCurrency; }
            set { priceSuggestCurrency = value; }
        }
    }
}
