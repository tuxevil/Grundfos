

using System.Collections.Generic;

namespace PriceManager.Core
{
    public class Family : Entity
    {
        private string description;
        private string name;
        private IList<Product> products;
        private int parent;

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

        public virtual IList<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public virtual int Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }
}
