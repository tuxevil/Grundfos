
using System.Collections.Generic;

namespace PriceManager.Core
{
    public class Selection : Entity
    {
        private string description;
        private IList<Product> products;
        private int user;

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

        public virtual int User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
