

using ProjectBase.Data;

namespace PriceManager.Core
{
    public class CtrRange : AuditableEntity<int>
    {
        private decimal min;
        private decimal max;
       
        public virtual decimal Min
        {
            get { return min; }
            set { min = value; }
        }

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
