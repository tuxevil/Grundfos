using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace PriceManager.Common
{
    public class Resource
    {
        private static ResourceManager business;
        public static ResourceManager Business
        {
            get
            {
                if (ReferenceEquals(business, null))
                {
                    ResourceManager temp;

                    temp = new ResourceManager("PriceManager.Common.Resources.Business", System.Reflection.Assembly.GetExecutingAssembly());

                    business = temp;
                }

                return business;
            }
        }

    }
}
