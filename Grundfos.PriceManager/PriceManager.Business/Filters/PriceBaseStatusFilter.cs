using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class PriceBaseStatusFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(PriceBaseStatus); }
        }

        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Items.Insert(0, new ListItem("--Estado del Precio--", "0"));
                SelectedValue = Items[0].Value;
            }
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(PriceBaseStatus));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
        }

    }
}
