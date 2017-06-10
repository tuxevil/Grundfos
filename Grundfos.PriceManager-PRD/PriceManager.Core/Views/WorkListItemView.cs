using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class WorkListItemView
    {
        private int workListItemId;
        private int priceBaseId;
        private decimal priceSuggest;
        private int priceSuggestCurrencyId;
        private decimal pricePurchase;
        private int pricePurchaseCurrencyId;

        public int WorkListItemId
        {
            get { return workListItemId; }
            set { workListItemId = value; }
        }

        public int PriceBaseId
        {
            get { return priceBaseId; }
            set { priceBaseId = value; }
        }

        public decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public int PriceSuggestCurrencyId
        {
            get { return priceSuggestCurrencyId; }
            set { priceSuggestCurrencyId = value; }
        }

        public decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public int PricePurchaseCurrencyId
        {
            get { return pricePurchaseCurrencyId; }
            set { pricePurchaseCurrencyId = value; }
        }

        public WorkListItemView() { }

        public WorkListItemView(int wliId, int pbId, decimal grp, int grpCurrencyId, decimal tp, int tpCurrencyId)
        {
            this.workListItemId = wliId;
            this.priceBaseId = pbId;
            this.priceSuggest = grp;
            this.priceSuggestCurrencyId = grpCurrencyId;
            this.pricePurchase = tp;
            this.pricePurchaseCurrencyId = tpCurrencyId;
        }
    }
    

}
