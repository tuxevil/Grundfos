using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class ProductView : AuditableEntity<int>
    {
        private string description;
        private string code;
        private string arrow;
        private string color;
        private string priceSell;
        private string price;
        private string lastPrice;
        private string cTM;
        private string cTR;
        private string index;
        private string pCR;

        public virtual string Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual string Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }

        public virtual string Color
        {
            get { return color; }
            set { color = value; }
        }

        public virtual string LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }

        public virtual string CTM
        {
            get { return cTM; }
            set { cTM = value; }
        }

        public virtual string CTR
        {
            get { return cTR; }
            set { cTR = value; }
        }

        public virtual string PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual string Index
        {
            get { return index; }
            set { index = value; }
        }

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

        public virtual string PCR
        {
            get { return pCR; }
            set { pCR = value; }
        }

        public ProductView() {}

        public ProductView(int id, string description, string code, string priceSuggestCurrency, decimal priceSuggest, string priceSellCurrency, decimal priceSell, string pricePurchaseCurrency, decimal pricePurchase, string priceCurrency, decimal price, decimal lastPrice, decimal cTM, decimal cTR, decimal priceSuggestCurrencyValue, decimal priceSellCurrencyValue, decimal pCR, DateTime modifiedOn)
        {
            this.id = id;

            this.description = description;
            this.code = code;
            if (priceSell > priceSuggest)
                this.color = "pricegreen";
            else if ((priceSell < priceSuggest) && (priceSell > pricePurchase))
                this.color = "priceblack";
            else if (priceSell < pricePurchase)
                this.color = "pricered";
            if ((lastPrice > 0) && (lastPrice < price))
                this.arrow = "up";
            else if (lastPrice > price)
                this.arrow = "down";
            this.priceSell = priceSellCurrency + " " + priceSell.ToString("#,##0.00");
            this.price = priceCurrency + " " + price.ToString("#,##0.00");
            this.lastPrice = priceCurrency + " " + lastPrice.ToString("#,##0.00");
            this.cTM = "€ " + cTM.ToString("#,##0.00");
            this.cTR = cTR.ToString("##0.00") + "%";
            if (priceSuggest > 0)
                this.index = ((priceSell * priceSellCurrencyValue) / (priceSuggest * priceSuggestCurrencyValue)).ToString("##0.00");
            else this.index = 0.ToString("##0.00");
            this.pCR = pCR.ToString("##0.00") + "%";
        }
    }
}
