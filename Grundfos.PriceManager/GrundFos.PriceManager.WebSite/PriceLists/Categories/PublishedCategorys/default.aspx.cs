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

namespace GrundFos.PriceManager.WebSite.PriceLists.Categories.PublishedCategorys
{
    public partial class _default : PriceListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                CategoryView1.PriceListID = Convert.ToInt32(Request.QueryString["Id"]);

                PublishList pl = ControllerManager.PublishList.GetPublishedList(Convert.ToInt32(Request.QueryString["Id"]));
                if (pl != null)
                    CategoryView1.PublishListID = pl.ID;

                CategoryView1.UrlToNavigate = "/pricelists/items/published/";
                CategoryView1.DataBind();
            }
        }
    }
}
