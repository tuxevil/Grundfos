using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using PriceManager.Common;

namespace PriceManager.Business.Filters
{
    public class PriceListStatusFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(PublishListStatus); }
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
            {
                Refresh();
            }

            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(PublishListStatus));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
            Items.Insert(0, new ListItem("--Estado--", "0"));

            if (PermissionManager.Check(this) == false)
                Items.Remove(Items.FindByValue(PublishListStatus.Disable.ToString()));
        }

    }
}
