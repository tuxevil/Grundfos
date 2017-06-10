using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class Country : BaseAuditableEntity<int>
    {
        public Country(int id)
        {
            this.id = id;
        }

        public Country()
        {
        }

        private string name;

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
