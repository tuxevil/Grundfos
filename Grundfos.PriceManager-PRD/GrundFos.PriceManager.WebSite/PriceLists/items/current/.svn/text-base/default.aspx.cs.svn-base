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

namespace GrundFos.PriceManager.WebSite.PriceLists.items.current
{
    public partial class _default : PriceListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack || string.IsNullOrEmpty(Request.QueryString["Id"])) return;
            PublishList pl =
                ControllerManager.PublishList.GetCurrentList(Convert.ToInt32(Request.QueryString["Id"]));
            if (pl != null)
                PriceMasterList1.PublishListID = pl.ID;
            if (!string.IsNullOrEmpty(Request.QueryString["CatalogPageId"]))
                PriceMasterList1.CatalogPageID = Convert.ToInt32(Request.QueryString["CatalogPageId"]);
            PriceMasterList1.DataBind();
        }
    }
}
