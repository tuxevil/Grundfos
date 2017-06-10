using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class QuoteRange : BaseAuditableEntity<int>
    {
        public QuoteRange(int id)
        {
            this.id = id;
        }

        public QuoteRange()
        {
        }

        private string title;
        private Int32 minimum;
        private Int32 maximim;

        public virtual string Title
        {
            get { return title; }
            set { title = value; }
        }

        public virtual Int32 Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }

        public virtual Int32 Maximum
        {
            get { return maximim; }
            set { maximim = value; }
        }
    }
}
