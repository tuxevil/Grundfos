using System;
using System.Collections.Generic;

namespace PriceManager.Core
{
    public class Product : Entity
    {
        private string code;
        private string description;
        private decimal priceSuggest;
        private IList<Family> families;
        private decimal pricePurchase;
        private Currency priceSuggestCurrency;
        private Currency pricePurchaseCurrency;
        private IList<Selection> selections;
        private ProductStatus status;
        private IList<Provider> providers;
        private IList<BasePrice> basePrices;
        private string model;
        private string keywords;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual IList<Family> Families
        {
            get { return families; }
            set { families = value; }
        }

        public virtual decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public virtual Currency PriceSuggestCurrency
        {
            get { return priceSuggestCurrency; }
            set { priceSuggestCurrency = value; }
        }

        public virtual Currency PricePurchaseCurrency
        {
            get { return pricePurchaseCurrency; }
            set { pricePurchaseCurrency = value; }
        }

        public virtual IList<Selection> Selections
        {
            get { return selections; }
            set { selections = value; }
        }

        public virtual ProductStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual IList<Provider> Providers
        {
            get { return providers; }
            set { providers = value; }
        }

        public virtual IList<BasePrice> BasePrices
        {
            get { return basePrices; }
            set { basePrices = value; }
        }

        public virtual string Model
        {
            get { return model; }
            set { model = value; }
        }

        public virtual string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }
    }

}
