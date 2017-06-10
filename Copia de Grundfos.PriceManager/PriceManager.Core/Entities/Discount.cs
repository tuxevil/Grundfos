
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class Discount : AuditableEntity<int>
    {
        private string description;
        private decimal maxDiscount;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual decimal MaxDiscount
        {
            get { return maxDiscount; }
            set { maxDiscount = value; }
        }

    }
}
