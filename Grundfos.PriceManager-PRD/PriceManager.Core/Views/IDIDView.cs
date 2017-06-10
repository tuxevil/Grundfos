using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class IDIDView
    {
        private int id1;
        private int id2;

        public virtual int Id1
        {
            get { return id1; }
            set { id1 = value; }
        }

        public virtual int Id2
        {
            get { return id2; }
            set { id2 = value; }
        }
        public IDIDView() { }

        public IDIDView (int id1, int id2)
        {
            this.id1 = id1;
            this.id2 = id2;
        }
    }
}
