using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class IncotermFilter : DropDownFilter
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
            get { return "Incoterm"; }
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
            //DataSource = EnumHelper.GetList(typeof(Incoterm));
            DataSource = ControllerManager.Lookup.List(LookupType.Incoterm);
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Condición de Venta--", "0"));
        }

    }
}
