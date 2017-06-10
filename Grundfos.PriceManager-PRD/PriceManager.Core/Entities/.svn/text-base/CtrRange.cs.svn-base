using ProjectBase.Data;
using System;

namespace PriceManager.Core
{
    [Serializable]
    public class CtrRange : BaseAuditableEntity<int>
    {
        private decimal min;
        private decimal max;

        [DomainSignature]
        public virtual decimal Min
        {
            get { return min; }
            set { min = value; }
        }

        [DomainSignature]
        public virtual decimal Max
        {
            get { return max; }
            set { max = value; }
        }

        public virtual string Description
        {
            get { return string.Format("{0} a {1}", Min.ToString("#0"), Max.ToString("#0")); }
        }
    }
}
