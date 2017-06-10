
using System.Collections.Generic;
using ProjectBase.Data;
using System;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class Selection : BaseAuditableEntity<int>
    {
        private string description;
        private ICollection<Product> products = new HashedSet<Product>();
        private Guid user;

        [DomainSignature]
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        [DomainSignature]
        public virtual Guid User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
