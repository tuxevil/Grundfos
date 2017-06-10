using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class CurrencyRateConverter
    {
        private string description;
        private decimal rate;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public CurrencyRateConverter() { }

        public CurrencyRateConverter(string description, decimal rate)
        {
            this.description = description;
            this.rate = rate;
        }
    }
}
