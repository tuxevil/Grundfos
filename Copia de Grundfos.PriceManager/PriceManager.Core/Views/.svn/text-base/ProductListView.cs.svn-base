using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class ProductListView : AuditableEntity<int>
    {
        private string code;
        private string description;
        private string priceSuggestCurrency;
        private decimal priceSuggest;
        private string pricePurchaseCurrency;
        private decimal pricePurchase;
        private string priceSellCurrency;
        private decimal priceSell;
        private string priceCurrency;
        private decimal price;
        private string lastPriceCurrency;
        private decimal lastPrice;
        private decimal cTM;
        private decimal cTR;
        private ProductType type;
        private decimal index;
        private decimal pCR;

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public virtual decimal LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }

        public virtual decimal CTM
        {
            get { return cTM; }
            set { cTM = value; }
        }

        public virtual decimal CTR
        {
            get { return cTR; }
            set { cTR = value; }
        }

        public virtual decimal PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual string PriceSuggestCurrency
        {
            get { return priceSuggestCurrency; }
            set { priceSuggestCurrency = value; }
        }

        public virtual string PricePurchaseCurrency
        {
            get { return pricePurchaseCurrency; }
            set { pricePurchaseCurrency = value; }
        }

        public virtual string PriceSellCurrency
        {
            get { return priceSellCurrency; }
            set { priceSellCurrency = value; }
        }

        public virtual string PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual string LastPriceCurrency
        {
            get { return lastPriceCurrency; }
            set { lastPriceCurrency = value; }
        }

        public virtual ProductType Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual decimal Index
        {
            get { return index; }
            set { index = value; }
        }

        public virtual decimal PCR
        {
            get { return pCR; }
            set { pCR = value; }
        }

        public virtual string PriceForExport
        {
            get { return( this.PriceCurrency +" "+ this.Price.ToString()); }
        }


        public ProductListView() {}

        public ProductListView(int id, string code, string description, string priceSuggestCurrency, decimal priceSuggest, string priceSellCurrency, decimal priceSell, string pricePurchaseCurrency, decimal pricePurchase, string priceCurrency, decimal price, decimal lastPrice, decimal cTM, decimal cTR, ProductType type, decimal priceSuggestCurrencyValue, decimal priceSellCurrencyValue, decimal pCR, DateTime modifiedOn)
        {
            this.id = id;
            this.code = code;
            this.description = description;
            this.priceSuggestCurrency = priceSuggestCurrency;
            this.priceSuggest = priceSuggest;
            this.pricePurchaseCurrency = pricePurchaseCurrency;
            this.pricePurchase = pricePurchase;
            this.priceSellCurrency = priceSellCurrency;
            this.priceSell = priceSell;
            this.priceCurrency = priceCurrency;
            this.price = price;
            this.lastPriceCurrency = priceCurrency;
            this.lastPrice = lastPrice;
            this.cTM = cTM;
            this.cTR = cTR;
            this.type = type;
            if (priceSuggest > 0)
                this.index = ((priceSell * priceSellCurrencyValue) / (priceSuggest * priceSuggestCurrencyValue));
            else this.index = 0;
            this.pCR = pCR;
        }

        public ProductListView(int id, string code, string description, decimal priceSuggestCurrency, decimal priceSuggest, string priceSellCurrency, decimal priceSell, decimal pricePurchaseCurrency, decimal pricePurchase, decimal priceCurrency, decimal price, decimal lastPrice, decimal cTM, decimal cTR, ProductType type, decimal discount)
        {
            this.id = id;
            this.code = code;
            this.description = description;
            this.priceSuggestCurrency = priceSuggestCurrency.ToString();
            this.priceSuggest = priceSuggest;
            this.pricePurchaseCurrency = pricePurchaseCurrency.ToString();
            this.pricePurchase = pricePurchase;
            this.priceSellCurrency = priceSellCurrency;
            this.priceSell = priceSell;
            this.priceCurrency = priceCurrency.ToString();
            this.price = price;
            this.lastPriceCurrency = priceCurrency.ToString();
            this.lastPrice = lastPrice;
            this.cTM = cTM;
            this.cTR = cTR;
            this.type = type;
            this.index = discount;
        }
    }
}
