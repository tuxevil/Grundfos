using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class LastCurrencyRateView : Entity<int>
    {
        private Currency currency;
        private decimal rate;

        public virtual Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public virtual decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }
    }
}
