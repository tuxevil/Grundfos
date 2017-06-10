using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class QuoteNotificationAlreadyExistException : Exception
    {
        public QuoteNotificationAlreadyExistException(string message) : base(message) { }
    }

    public class DistributorContactAlreadyExistsException : Exception
    {
        public DistributorContactAlreadyExistsException(string message) : base(message) { }
    }

}
