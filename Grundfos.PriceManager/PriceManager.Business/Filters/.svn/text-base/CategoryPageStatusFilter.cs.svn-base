using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class CategoryPageStatusFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(CategoryPageStatus); }
        }

        public override string PropertyName
        {
            get { return "ID"; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }

            base.OnInit(e);
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Items.Insert(0, new ListItem("--Estado--", "0"));
                SelectedValue = Items.FindByValue(CategoryPageStatus.Active.ToString()).Value;

            }
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(CategoryPageStatus));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
            SelectedValue = Items.FindByValue(CategoryPageStatus.Active.ToString()).Value;
        }

    }
}
