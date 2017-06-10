using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class PriceGroupFilter : DropDownFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(PriceGroup); }
        }


        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
           Refresh();
           base.OnInit(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.PriceGroup.GetByPriceLists();
            DataTextField = "Name";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--País--", "0"));
        }

    }
}
