using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class Country : AuditableEntity<int>
    {
        private string name;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
