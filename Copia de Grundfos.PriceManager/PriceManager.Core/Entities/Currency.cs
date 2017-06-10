using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class Currency : AuditableEntity<int>
    {
        private string description;
        private decimal value; 

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual decimal Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
