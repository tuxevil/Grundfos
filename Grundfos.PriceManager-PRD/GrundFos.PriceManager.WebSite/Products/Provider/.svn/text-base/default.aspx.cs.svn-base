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
using Prov = PriceManager.Core.Provider;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.Products.Provider
{
    public partial class _default :ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Product p = ControllerManager.Product.GetById(ProductId);
                
                if (p.Providers.Count > 0)
                { 
                    rpterProvider.DataSource = p.Providers;
                    rpterProvider.DataBind();
                }
                else
                    litNoItems.Visible = true;

            }
        }

        protected void rpterProvider_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Prov p = (e.Item.DataItem as Prov);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                hl.NavigateUrl = "/providers/view/default.aspx?Id=" + p.ID;
                hl.Text = p.Name;
                hl.ToolTip = string.Format("Ingresar al proveedor {0}", p.Name);

                (e.Item.FindControl("litCode") as Literal).Text = p.Code;
                (e.Item.FindControl("litDiscount") as Literal).Text = StringFormat.FormatPercentage(p.Discount);
                (e.Item.FindControl("litCountry") as Literal).Text = (p.Country != null) ? p.Country.Name : "N/D";

                (e.Item.FindControl("litPhone") as Literal).Text = StringFormat.FormatHasValue(p.Telephone);
                (e.Item.FindControl("litFax") as Literal).Text = StringFormat.FormatHasValue(p.Fax);
                (e.Item.FindControl("litMail") as Literal).Text = StringFormat.FormatHasValue(p.Email);
                (e.Item.FindControl("litContact") as Literal).Text = StringFormat.FormatHasValue(p.Contact);
                (e.Item.FindControl("litAdress") as Literal).Text = StringFormat.FormatHasValue(p.Address);
                (e.Item.FindControl("litCity") as Literal).Text = StringFormat.FormatHasValue(p.City);

           }
        }
    }
}
