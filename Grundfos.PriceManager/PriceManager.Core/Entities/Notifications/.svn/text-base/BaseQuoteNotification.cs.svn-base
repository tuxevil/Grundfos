using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public abstract class BaseQuoteNotification : BaseAuditableEntity<int>, IQuoteNotification
    {
        private string name;
        private string email;
        private Quote quote;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual Quote Quote
        {
            get { return quote; }
            set { quote = value; }
        }
}
}
