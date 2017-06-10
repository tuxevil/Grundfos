using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductInfoByPublishList : ProductInfoGeneric
    {
        private PublishItem publishItem;

        public virtual PublishItem PublishItem
        {
            get { return publishItem; }
            set { publishItem = value; }
        }
    }
}
