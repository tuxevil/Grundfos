using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class CurrencyRateView
    {
        private Currency fromCurrency;
        private Currency toCurrency;
        private CurrencyRate fromCurrencyRate;
        private CurrencyRate toCurrencyRate;
        private decimal rate;

        public virtual CurrencyRate FromCurrencyRate
        {
            get { return fromCurrencyRate; }
            set { fromCurrencyRate = value; }
        }

        public virtual CurrencyRate ToCurrencyRate
        {
            get { return toCurrencyRate; }
            set { toCurrencyRate = value; }
        }

        public virtual Currency FromCurrency
        {
            get { return fromCurrency; }
            set { fromCurrency = value; }
        }

        public virtual Currency ToCurrency
        {
            get { return toCurrency; }
            set { toCurrency = value; }
        }

        public virtual decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public override bool Equals(object obj)
        {
            CurrencyRateView item = (CurrencyRateView)obj;
            return item.ToCurrency.ID == this.ToCurrency.ID && item.FromCurrency.ID == this.FromCurrency.ID;
        }

        public override int GetHashCode()
        {
            return this.ToCurrency.ID.GetHashCode() + this.FromCurrency.ID.GetHashCode();
        }
    }
}
