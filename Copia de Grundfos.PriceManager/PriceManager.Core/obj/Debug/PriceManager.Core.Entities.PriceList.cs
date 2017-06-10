using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PriceList : Entity
    {
        private string description;
        private Discount discount;
        private ProductType type;


        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual Discount Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual ProductType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}