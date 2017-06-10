

using ProjectBase.Data;
using System;

namespace PriceManager.Core
{
    [Serializable]
    public class IndexPrice : BaseAuditableEntity<int>
    {
        private decimal min;
        private decimal max;

        [DomainSignature]
        public virtual decimal Min
        {
            get { return min; }
            set { min = value; }
        }

        [DomainSignature]
        public virtual decimal Max
        {
            get { return max; }
            set { max = value; }
        }

        public virtual string Description
        {
            get 
            {
                string menor = Min.ToString("#0.#");
                string mayor = Max.ToString("#0.#");

                if (Min == -10000)
                    menor = "Menor";
                if (Max == 10000)
                {
                    mayor = menor;
                    menor = "Mayor";
                }
                return string.Format("{0} a {1}", menor, mayor); 
            }
        }
    }
}
