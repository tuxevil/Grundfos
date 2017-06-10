using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceCalculation : BaseAuditableEntity<int>
    {
        private CategoryBase categoryBase;
        private Provider provider;
        private string formula;
        private PriceCalculationPriority priority;
        private int level;
        private decimal weighing;
        private decimal sort;

        [DomainSignature]
        public virtual CategoryBase CategoryBase
        {
            get { return categoryBase; }
            set { categoryBase = value; }
        }

        [DomainSignature]
        public virtual Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        [DomainSignature]
        public virtual string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        public virtual PriceCalculationPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public virtual decimal Weighing
        {
            get { return weighing; }
            set { weighing = value; }
        }

        [DomainSignature]
        public virtual int Level
        {
            get { return level; }
            set { level = value; }
        }

        public virtual decimal Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        public virtual string CodeFormula
        {
            get { return ConvertFormula(); }
        }

        public virtual string ConvertFormula()
        {
            string lcFormula = string.Empty;
            bool convertion = false;
            foreach (char c in formula)
            {
                char temp = c;
                if (c == ',')
                    temp = '.';
                if (!(Char.IsDigit(temp) || temp == '.'))
                {
                    if (convertion)
                    {
                        lcFormula += ")";
                        convertion = false;
                    }
                    lcFormula += temp;
                }
                else
                {
                    if (!convertion)
                    {
                        lcFormula += "Convert.ToDecimal(";
                        convertion = true;
                    }
                    lcFormula += temp;
                }
            }
            if (convertion)
                lcFormula += ")";

            return lcFormula;
        }

        public PriceCalculation() { }

        public PriceCalculation(int id)
        {
            this.id = id;
        }

    }
}
