using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using ProjectBase.Utils.Cache;

namespace PriceManager.Core
{
    [Serializable]
    public class CurrencyRate : Entity<int>
    {
        public const string CURRENCY_RATE = "Currencies.GetRates";

        public static CurrencyRateConverter[,] GetArray
        {
            get { return CacheManager.GetCached("Currencies.GetRates") as CurrencyRateConverter[,]; }
        }

        private Currency currency;
        private DateTime date;
        private decimal rate;

        [DomainSignature]
        public virtual Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        [DomainSignature]
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public virtual decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public CurrencyRate() { }

        public CurrencyRate(int id)
        {
            this.id = id;
        }
    }
}
