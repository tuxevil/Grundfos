using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ContactQuoteNotification : BaseQuoteNotification
    {
        private Contact contact;

        public virtual Contact Contact
        {
            get { return contact; }
            set { contact = value; }
        }
    }
}
