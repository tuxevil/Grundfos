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

namespace GrundFos.PriceManager.WebSite.Providers.items.assigned
{
    public partial class _default : ProviderPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack || string.IsNullOrEmpty(Request.QueryString["Id"])) return;

            Provider p = ControllerManager.Provider.GetById(Convert.ToInt32(Request.QueryString["Id"]));
            if (p != null)
            {
                PriceMasterList1.ProviderId = p.ID;
                PriceMasterList1.DataBind();
            }
            
        }
    }
}
