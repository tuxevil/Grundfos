using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class Currency : Entity
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
