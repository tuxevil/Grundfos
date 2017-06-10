using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class Note : BaseAuditableEntity<int>
    {
        private string subject;
        private string description;
        private string typeName;
        private int typeIdentifier;

        [DomainSignature]
        public virtual int TypeIdentifier
        {
            get { return typeIdentifier; }
            set { typeIdentifier = value; }
        }

        public virtual string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
        public virtual string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

    }
}
