using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class Currency : BaseAuditableEntity<int>
    {
        private string description;
        private string code;
        private LastCurrencyRateView lastCurrencyRateView;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual LastCurrencyRateView LastCurrencyRateView
        {
            get { return lastCurrencyRateView; }
            set { lastCurrencyRateView = value; }
        }

        public Currency() {}

        public Currency(int id)
        {
            this.id = id;
        }
    }
}
