using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PriceGroup
    {
        private string name;
        private string description;
        private IList<PriceAttribute> priceAttributes;

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

        public virtual IList<PriceAttribute> PriceAttributes
        {
            get { return priceAttributes; }
            set { priceAttributes = value; }
        }
    }
}
