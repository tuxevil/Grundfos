using System;
using System.Collections.Generic;
using System.Text;

namespace Grundfos.ScalaConnector
{
    public class Provider
    {
        private string id;
        private string name;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
