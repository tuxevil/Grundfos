using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class SearchFilter : TextBoxFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(Product); }
        }


        public override string PropertyName
        {
            get { return "Description"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion
    }
}
