using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductInfoGeneric
    {
        private int iD;
        private decimal priceSell;
        private decimal cTM;
        private decimal cTR;
        private decimal index;
        private decimal? lastPrice;
        private decimal? discount;
        private DateTime? modifiedOn;
        private decimal? pricePurchase;
        private decimal? priceSuggest;
        private decimal price;
        private int pPCurrencyId;
        private int pSCurrencyId;
        private int pLCurrencyId;
        private int lastPriceCurrencyId;

        public virtual int ID
        {
            get { return iD; }
            set { iD = value; }
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

        public virtual decimal Index
        {
            get { return index; }
            set { index = value; }
        }

        public virtual decimal? LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }

        public virtual decimal PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual DateTime? ModifiedOn
        {
            get { return modifiedOn; }
            set { modifiedOn = value; }
        }

        public virtual decimal? Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual decimal? PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public virtual decimal? PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual int PPCurrencyId
        {
            get { return pPCurrencyId; }
            set { pPCurrencyId = value; }
        }

        public virtual int PSCurrencyId
        {
            get { return pSCurrencyId; }
            set { pSCurrencyId = value; }
        }

        public virtual int PLCurrencyId
        {
            get { return pLCurrencyId; }
            set { pLCurrencyId = value; }
        }

        public virtual int LastPriceCurrencyId
        {
            get { return lastPriceCurrencyId; }
            set { lastPriceCurrencyId = value; }
        }
    }
}
