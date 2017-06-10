using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductInfoByGroup : ProductInfoGeneric
    {
        private PriceAttribute priceAttribute;
        private int priceGroupId;
        
        public virtual int PriceGroupId
        {
            get { return priceGroupId; }
            set { priceGroupId = value; }
        }

        public virtual PriceAttribute PriceAttribute
        {
            get { return priceAttribute; }
            set { priceAttribute = value; }
        }
    }
}
