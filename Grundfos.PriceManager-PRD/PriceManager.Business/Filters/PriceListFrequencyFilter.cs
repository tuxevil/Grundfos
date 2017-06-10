using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class PriceListFrequencyFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(Frequency); }
        }

        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                Refresh();

            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(Frequency));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
            Items.Insert(0, new ListItem("--Frecuencia--", "0"));
        }

    }
}
