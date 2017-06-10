using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class PublishItem : ListItemAbstract
    {
        private PublishList publishList;
        private PriceBase priceBase;
        private decimal priceSuggest;
        private decimal pricePurchase;

        [DomainSignature]
        public virtual PublishList PublishList
        {
            get { return publishList; }
            set { publishList = value; }
        }

        [DomainSignature]
        public virtual PriceBase PriceBase
        {
            get { return priceBase; }
            set { priceBase = value; }
        }

        public virtual decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }
    }
}
