using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceGroup : BaseAuditableEntity<int>
    {
        private string name;
        private string description;
        private ICollection<PriceAttribute> priceAttributes = new HashedSet<PriceAttribute>();
        private decimal discount;
        private ICollection<PriceList> priceLists = new HashedSet<PriceList>();
        private decimal? adjust;
        private Currency currency;
        private decimal priceSuggestCoef;
        
        public PriceGroup(int id)
        {
            this.id = id;
        }

        public PriceGroup()
        {
        }

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ICollection<PriceAttribute> PriceAttributes
        {
            get { return priceAttributes; }
            set { priceAttributes = value; }
        }

        public virtual decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual ICollection<PriceList> PriceLists
        {
            get { return priceLists; }
            set { priceLists = value; }
        }

        public virtual decimal? Adjust
        {
            get { return adjust; }
            set { adjust = value; }
        }

        public virtual Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public virtual decimal PriceSuggestCoef
        {
            get { return priceSuggestCoef; }
            set { priceSuggestCoef = value; }
        }
    }
}
