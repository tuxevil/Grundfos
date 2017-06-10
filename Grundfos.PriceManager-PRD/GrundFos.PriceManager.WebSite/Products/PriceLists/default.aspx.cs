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
using PriceManager.Core;
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.Products.PriceLists
{
    public partial class _default : ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<PriceList> pl = ControllerManager.PriceList.GetForProduct(ProductId);
               
                if (pl.Count > 0)
                {
                    rpterPriceLists.DataSource = pl;
                    rpterPriceLists.DataBind();
                }
                else
                    litNoItems.Visible = true;

            }
        }


        protected void rpterPriceLists_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PriceList p = (e.Item.DataItem as PriceList);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                hl.NavigateUrl = "/pricelists/view/default.aspx?Id=" + p.ID;
                hl.Text = p.Name;
                hl.ToolTip = string.Format("Ingresar a la Lista de Precios {0}", p.Name);

                (e.Item.FindControl("litDiscount") as Literal).Text = StringFormat.FormatPercentage(p.Discount);
                (e.Item.FindControl("litCountry") as Literal).Text = (p.PriceGroup != null) ? p.PriceGroup.Name : "N/D";

                (e.Item.FindControl("litDescription") as Literal).Text = StringFormat.FormatHasValue(p.Description);
                (e.Item.FindControl("litIncoterm") as Literal).Text = (p.SaleCondition != null) ?  p.SaleCondition.Value.ToString() : "N/D";
                (e.Item.FindControl("litStatus") as Literal).Text = Resource.Business.GetString(p.PriceListStatus.ToString());
                if (p.CurrentState != null && p.CurrentState.LastPublishedOn != null)
                    (e.Item.FindControl("litLastPublish") as Literal).Text = p.CurrentState.LastPublishedOn.Value.ToShortDateString();
                else
                    (e.Item.FindControl("litLastPublish") as Literal).Text = "N/D";
            }
        }


    }
}
