
using ProjectBase.Data;
using System;

namespace PriceManager.Core
{
    [Serializable]
    public class Lookup : BaseAuditableEntity<int>
    {
        private LookupType lookupType;
        private string description;
        private string title;

        [DomainSignature]
        public virtual LookupType LookupType
        {
            get { return lookupType; }
            set { lookupType = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
        public virtual string Title
        {
            get { return title; }
            set { title = value; }
        }

        public Lookup(int id)
        {
            this.id = id;
        }

        public Lookup()
        {
        }
    }
}
