using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Web.Security;
using PriceManager.Common;
using ProjectBase.Data;
using NybbleMembership;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceImportView : Entity<Guid>
    {
        private int amountNew;
        private int amountChange;
        private int amountError;

        public virtual int AmountNew
        {
            get { return amountNew; }
            set { amountNew = value; }
        }

        public virtual int AmountChange
        {
            get { return amountChange; }
            set { amountChange = value; }
        }

        public virtual int AmountError
        {
            get { return amountError; }
            set { amountError = value; }
        }

    }
}
