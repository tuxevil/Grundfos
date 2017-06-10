using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class PaymentTermFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(Lookup); }
        }

        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return "Payment"; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }

            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.Lookup.List(LookupType.PaymentTerm);
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Condiciones de Pago--", "0"));
        }

    }
}
