using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using System.Web.UI.WebControls;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class DistributorStatusFilter : DropDownFilter
    {
        public override Type ClassName
        {
            get { return typeof(DistributorStatus); }
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
                Items.Insert(0, new ListItem("--Estado--", "0"));
                SelectedValue = Items.FindByValue(DistributorStatus.Active.ToString()).Value;
                Visible = PermissionManager.Check(this);
            }
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = EnumHelper.GetList(typeof(DistributorStatus));
            DataTextField = "Value";
            DataValueField = "Key";
            DataBind();
            SelectedValue =  Items.FindByValue(DistributorStatus.Active.ToString()).Value;
           
        }

    }
}
