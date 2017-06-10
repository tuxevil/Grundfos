using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using System.Collections.Generic;
using PriceManager.Common;
using System.Web.Services;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.PriceLists.Distributors
{
    public partial class _default : PriceListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack )
            {
                LoadInfo();
                addDistributor.Visible = PermissionManager.Check(btnSave);
            }
        }

        private void LoadInfo()
        {
            IList<Distributor> lst = ControllerManager.Distributor.GetByPriceList(PriceListId);
            if (lst.Count > 0)
            {
                rpterDistributors.DataSource = lst;
                rpterDistributors.DataBind();
            }
            else
                litNoItems.Visible = true;
        }

        protected void rpterDistributors_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Distributor d = (e.Item.DataItem as Distributor);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                hl.NavigateUrl = "/distributors/view/default.aspx?Id=" + d.ID;
                hl.Text = d.Name;
                hl.ToolTip = string.Format("Ingresar al distribuidor {0}", d.Name);

                (e.Item.FindControl("litCode") as Literal).Text = d.Code;
                (e.Item.FindControl("litDiscount") as Literal).Text = StringFormat.FormatPercentage(d.Discount);
                (e.Item.FindControl("litCountry") as Literal).Text = (d.Country != null) ? d.Country.Name : "N/D";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string[] code = txtDistributor.Text.Split('[', ']');
                ControllerManager.PriceList.AddDistributor(PriceListId, code[1]);
                
                LoadInfo();
            }
        }

        [WebMethod]
        public static bool HavePriceList(string distributor)
        {
            string[] code = distributor.Split('[', ']');
            Distributor d = ControllerManager.Distributor.GetByCode(code[1]);
            if (d.PriceList != null)
                return true;

            return false;
        }

    }
}
