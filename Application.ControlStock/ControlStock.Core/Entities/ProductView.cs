using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class ProductView : Identifier
    {
  
        private int description;
        private Product productCode;
        private Provider providerCode;

        public virtual int Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual Product ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public virtual Provider ProviderCode
        {
            get { return providerCode; }
            set { providerCode = value; }
        }
    }
}
