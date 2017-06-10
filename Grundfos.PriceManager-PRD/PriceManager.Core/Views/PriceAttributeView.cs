using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PriceAttributeView
    {
        private int priceAttributeId;
        private int pricePurchaseCurrencyRateId;
        private int priceSuggestCurrencyRateId;

        public int PriceAttributeId
        {
            get { return priceAttributeId; }
            set { priceAttributeId = value; }
        }

        public int PricePurchaseCurrencyRateId
        {
            get { return pricePurchaseCurrencyRateId; }
            set { pricePurchaseCurrencyRateId = value; }
        }

        public int PriceSuggestCurrencyRateId
        {
            get { return priceSuggestCurrencyRateId; }
            set { priceSuggestCurrencyRateId = value; }
        }

        public PriceAttributeView() { }

        public PriceAttributeView(int priceAttributeId, int priceSuggestCurrencyRateId, int pricePurchaseCurrencyRateId)
        {
            this.priceAttributeId = priceAttributeId;
            this.pricePurchaseCurrencyRateId = pricePurchaseCurrencyRateId;
            this.priceSuggestCurrencyRateId = priceSuggestCurrencyRateId;
        }
    }
}
