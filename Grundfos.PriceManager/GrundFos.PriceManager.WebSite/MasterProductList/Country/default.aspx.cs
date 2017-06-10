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
using MenuItem=PriceManager.Business.MenuItem;


namespace GrundFos.PriceManager.WebSite.MasterProductList.Country
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PriceMasterList1.PriceGroupID = Convert.ToInt32(Request.QueryString["id"]);
                PriceMasterList1.DataBind();
            }
        }
    }
}
