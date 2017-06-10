using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class UpdateDateFilter : CalendarFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(PriceBase); }
        }

        public override string PropertyName
        {
            get { return "TimeStamp.ModifiedOn"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnInit(e);
        }
    }
}
