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
using MenuItem = PriceManager.Business.MenuItem;

namespace GrundFos.PriceManager.WebSite.Products.History.PriceAttributeHistorys
{
    public partial class _default : ProductsPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {

                PriceMasterList1.ProductId = Convert.ToInt32(Request.QueryString["id"]);
                PriceMasterList1.DataBind();
                MenuItem mu = MenuItem.FindMenu(this.Page.AppRelativeVirtualPath);
                if (mu != null)
                {
                    Page.Title += " - " + mu.Description;
                }
            }
        }
    }
}
