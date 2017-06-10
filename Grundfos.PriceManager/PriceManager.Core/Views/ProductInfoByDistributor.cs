using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductInfoByDistributor : ProductInfoGeneric
    {
        private PublishItem publishItem;
        private Distributor distributor;
        
        public virtual PublishItem PublishItem
        {
            get { return publishItem; }
            set { publishItem = value; }
        }

        public virtual Distributor Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }
    }
}
