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

namespace GrundFos.PriceManager.WebSite.admin.quoterange.view
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    ucQuoteRangeEditor.RangeId = Convert.ToInt32(Request.QueryString["Id"]);
                    ucQuoteRangeEditor.DataBind();
                }
            }
        }
    }
}
