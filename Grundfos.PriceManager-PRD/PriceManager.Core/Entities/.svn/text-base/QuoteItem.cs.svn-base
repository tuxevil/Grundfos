using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class QuoteItem : BaseAuditableEntity<int>
    {
        private PriceBase priceBase;
        private string observation;
        private decimal price;
        private Currency priceCurrency;
        private CurrencyRate currencyRate;
        private Quote quote;
        private string source;

        public virtual string Source
        {
            get { return source; }
            set { source = value; }
        }

        [DomainSignature]
        public virtual PriceBase PriceBase
        {
            get { return priceBase; }
            set { priceBase = value; }
        }

        public virtual string Observation
        {
            get { return observation; }
            set { observation = value; }
        }

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual Currency PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual CurrencyRate CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        [DomainSignature]
        public virtual Quote Quote
        {
            get { return quote; }
            set { quote = value; }
        }

        //Properties to see in screen
        public virtual string PriceSell
        {
            get { return PriceCurrency.Description + " " + (Price * ((100 - Quote.Distributor.Discount) / 100)).ToString("#,##0.00"); }
        }

        public virtual string PriceList
        {
            get { return PriceCurrency.Description + " " + Price.ToString("#,##0.00"); }
        }


        public virtual string Code
        {
            get
            {
                if (!string.IsNullOrEmpty(PriceBase.Product.Code))
                    return PriceBase.Product.Code;
                return PriceBase.ProviderCode;
            }
        }

        public virtual string Description
        {
            get { return PriceBase.Product.Model + " - " + PriceBase.Product.Description; }
        }

        public virtual string LeadTime
        {
            get { return "A confirmar por fábrica"; }
        }
    }
}
