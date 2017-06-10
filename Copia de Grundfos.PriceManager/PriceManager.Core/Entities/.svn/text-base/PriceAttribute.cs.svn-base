using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PriceAttributeHistory : PriceAttribute
    {
    }

    public class PriceAttribute
    {
        private decimal price;
        private Currency priceCurrency;
        private decimal priceSell;
        private Currency priceSellCurrency;
        private string productAttribute;
        private BasePrice basePrice;
        private PriceGroup priceGroup;

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual decimal PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual string ProductAttribute
        {
            get { return productAttribute; }
            set { productAttribute = value; }
        }

        public virtual BasePrice BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }

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

        public virtual Currency PriceSellCurrency
        {
            get { return priceSellCurrency; }
            set { priceSellCurrency = value; }
        }
    }
}
