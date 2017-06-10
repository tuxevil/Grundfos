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

namespace GrundFos.PriceManager.WebSite.pagelist.products
{
    public partial class _default : PageListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["Id"]))
            {   
                PriceMasterList1.CatalogPageID = Convert.ToInt32(Request.QueryString["Id"]);
                PriceMasterList1.DataBind();
            }
        }
    }
}
