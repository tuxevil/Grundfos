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

namespace GrundFos.PriceManager.WebSite.Quotes.edit
{
    public partial class _default : QuotePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int quoteId = Convert.ToInt32(Request.QueryString["Id"]);
                    QuoteEditor1.QuoteId = quoteId;
                }
                QuoteEditor1.DataBind();
            }
        }
    }
}
