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
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.Products.Category
{
    public partial class _default : ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Product p = ControllerManager.Product.GetById(ProductId);
                
                if (p.Families.Count > 0)
                {
                    rpterCategory.DataSource = p.Families;
                    rpterCategory.DataBind();
                }
                else
                    litNoItems.Visible = true;
            }
        }

        protected void rpterCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CategoryBase f = (e.Item.DataItem as CategoryBase);

                HyperLink hl = (e.Item.FindControl("lnkGo") as HyperLink);
                if (f != null)
                {
                    hl.NavigateUrl = "/categorys/view/default.aspx?Id=" + f.ID;
                    hl.Text = f.Name;
                    hl.ToolTip = string.Format("Ingresar a la categoría {0}", f.Name);

                    (e.Item.FindControl("litDescription") as Literal).Text = StringFormat.FormatHasValue(f.Description);
                    if (f.Parent != null)
                        (e.Item.FindControl("litParent") as Literal).Text = StringFormat.FormatHasValue(f.Parent.Name);
                    else
                        (e.Item.FindControl("litParent") as Literal).Text = "N/D";
                }
            }
        }
    }
}
