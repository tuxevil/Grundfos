using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;

namespace PriceManager.Business.Filters
{
    public class ProductStatusFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(ProductStatus); }
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
                Items.Insert(0, new ListItem("--Estado del Producto--", "0"));
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(ProductStatus));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
            Items.Insert(0, new ListItem("--Estado del Producto--", "0"));
            SelectedValue = Items.FindByValue(ProductStatus.Active.ToString()).Value;
        }

    }
}
